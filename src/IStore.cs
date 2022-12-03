using System.Threading.Tasks;

namespace Hestia.MQ.Abstractions
{
    public interface IStore
    {
        public Task<int> PublishAsync(Message message);

        public Task<int> ConsumeAsync(Message message);

        public Task<int> ReportAsync(Message message);
    }
}
