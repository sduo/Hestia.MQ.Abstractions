﻿using Hestia.MQ.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Hestia.MQ
{
    public delegate void OnException(Exception ex);

    public sealed class Consumer
    {
        public string Name { get; private set; }

        private readonly IServiceProvider services;

        public event OnException OnException;

        public Consumer(IServiceProvider services) : this(null, services) { }

        public Consumer(string name, IServiceProvider services)
        {
            var machine = Environment.GetEnvironmentVariable("Machine") ?? Environment.MachineName;
            if (string.IsNullOrEmpty(name))
            {
                var process = Process.GetCurrentProcess();
                Name = string.Join(":", machine, process.ProcessName, process.Id);
            }
            else
            {
                Name = string.Join(":", machine, name);
            }
            this.services = services;
        }

        private void Rebuild(Message message, string group, ulong offset)
        {
            message.Source = Name;
            message.Offset = offset;
            message.TotalConsumed += 1;
            message.ChainId = message.Id;
            message.TargetGroup = group;
        }

        public async void ConsumeAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    var producer = services.GetRequiredService<IProducer>();
                    var consumer = services.GetRequiredService<IConsumer>();
                    var worker = services.GetRequiredService<IWorker>();
                    var store = services.GetService<IStore>();

                    List<Message> messages = await consumer.ConsumeAsync();

                    foreach (var message in messages)
                    {
                        message.Consumer = Name;

                        if (store != null)
                        {
                            int rows = await store.BeginConsumeAsync(message);
                            if (rows == 0)
                            {
                                var offset = await worker.GetRepubishOffesetAsync(message);
                                Rebuild(message, consumer.Group, offset);
                                await consumer.RebuildAsync(message);
                                await producer.PublishAsync(message);
                                continue;
                            }
                        }

                        if (!string.IsNullOrEmpty(message.TargetGroup) && !string.Equals(message.TargetGroup, consumer.Group))
                        {
                            if (store != null)
                            {
                                message.State = 0x0010;
                                await store.EndConsumeAsync(message);
                            }
                            continue;
                        }

                        int code = await worker.OnMessageAsync(message);

                        if (store != null)
                        {
                            message.State = 0x0000;
                            await store.EndConsumeAsync(message);
                        }

                        if (code > 0)
                        {
                            var offset = await worker.GetRepubishOffesetAsync(message);
                            Rebuild(message, consumer.Group, offset);
                            await consumer.RebuildAsync(message);
                            await producer.PublishAsync(message);
                        }
                    }

                }
                catch (Exception ex)
                {
                    OnException?.Invoke(ex);
                    continue;
                }
            }
        }
    }
}
