using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hestia.MQ.Abstractions
{
    public interface IConsumer
    {
        public string Group { get; }

        public Task<List<Message>> ConsumeAsync();

        public Task<byte> RebuildAsync(Message message);
    }
}
