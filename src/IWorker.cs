using System;
using System.Threading.Tasks;

namespace Hestia.MQ.Abstractions
{
    public interface IWorker
    {
        public Task<(int, Action<Message>)> OnMessageAsync(Message message);
    }
}
