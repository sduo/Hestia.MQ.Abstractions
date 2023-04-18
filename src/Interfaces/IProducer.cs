namespace Hestia.MQ.Abstractions
{
    public interface IProducer
    {
        string Name { get; }
        string Publish(Message message);
    }
}
