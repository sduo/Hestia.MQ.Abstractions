namespace Hestia.MQ.Abstractions
{
    public interface IProducer
    {
        string Publish(Message message);
    }
}
