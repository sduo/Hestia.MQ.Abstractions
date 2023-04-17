using System;

namespace Hestia.MQ.Abstractions
{
    public interface IConsumer
    {
        [Obsolete]
        public void Consume(Action<Message> callback);
        [Obsolete]
        public void Consume(Func<Message,bool> callback);
        public void Consume(Func<Message, long> callback);
    }
}