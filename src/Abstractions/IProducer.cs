using System.Threading.Tasks;

namespace Hestia.MQ.Abstractions
{
    public interface IProducer
    {
        public Task<byte> PublishAsync(Message message);

        
    }
}
