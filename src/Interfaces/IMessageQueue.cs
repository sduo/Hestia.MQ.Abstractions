namespace Hestia.MQ.Abstractions
{
    public interface IMessageQueue
    {
        string Name { get; }

        IProducer CreateProducer(string name);

        IConsumer CreateConsumer(string name);
    }
}
