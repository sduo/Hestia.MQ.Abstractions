using System;
using System.Threading.Tasks;

namespace Hestia.MQ.Abstractions
{

    public interface IWorker
    {
        public Task<ulong> GetRepubishOffesetAsync(Message message);

        public Task<int> OnMessageAsync(Message message);
    }
}
