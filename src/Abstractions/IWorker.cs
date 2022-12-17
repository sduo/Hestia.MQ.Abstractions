using System;
using System.Threading.Tasks;

namespace Hestia.MQ.Abstractions
{

    public interface IWorker
    {
        public Task<ulong> GetDeliverAtAsync(Message message);

        public Task<int> OnMessageAsync(Message message);
    }
}
