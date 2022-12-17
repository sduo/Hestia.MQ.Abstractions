using Hestia.MQ.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Hestia.MQ
{
    public sealed class Producer
    {
        private readonly IServiceProvider services;

        public Producer(IServiceProvider services)
        {            
            this.services = services;
        }

        public async Task<int> PublishAsync(Message message)
        {
            if (string.IsNullOrEmpty(message.Id)) { return 0x0101;}
            if (string.IsNullOrEmpty(message.Source)) { return 0x0102; }
            if (string.IsNullOrEmpty(message.Instance)) { return 0x0103; }
            if (string.IsNullOrEmpty(message.Topic)) { return 0x0104; }
            if (string.IsNullOrEmpty(message.Body)) { return 0x0105; }
            if (string.IsNullOrEmpty(message.ChainId)) { message.ChainId = message.Id; }
            if (string.IsNullOrEmpty(message.OrginId)) { message.OrginId = message.Id; }

            IProducer producer = services.GetRequiredService<IProducer>();
            IStore store = services.GetService<IStore>();
            if (store != null)
            {
                int rows = await store.BeginPublishAsync(message);
                if (rows == 0) { return 0x0201; }
            }
            int code = 0x0200;
            try
            {
                code = await producer.PublishAsync(message);
            }
            catch (Exception ex)
            {
                code = 0x0202;
                message.ReasonPhrase = ex.ToString();
            }
            finally
            {
                if (store != null)
                {
                    message.StatusCode = code;
                    await store.EndPublishAsync(message);
                }
            }
            return code;
        }
    }
}
