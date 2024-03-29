﻿using System;

namespace Hestia.MQ.Abstractions
{
    public interface IConsumer
    {
        string Name { get; }

        [Obsolete("Consume(Func<Message, long> callback)")]
        public void Consume(Action<Message> callback);
        [Obsolete("Consume(Func<Message, long> callback)")]
        public void Consume(Func<Message,bool> callback);
        public void Consume(Func<Message, long> callback);
    }
}