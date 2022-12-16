using System.Threading.Tasks;

namespace Hestia.MQ.Abstractions
{
    public interface IStore
    {
        public Task<int?> BeginPublishAsync(Message message);

        public Task<int?> EndPublishAsync(Message message);

        public Task<int?> BeginConsumeAsync(Message message);

        public Task<int?> EndConsumeAsync(Message message);
    }
}
