namespace Hestia.MQ.Abstractions
{
    public interface IProducer
    {
        public string Publish(Message message);
    }
}
