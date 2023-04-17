using System.Collections.Generic;

namespace Hestia.MQ.Abstractions
{
    public sealed class Message
    {        
        public string Id { get; set; }
        
        public string Body { get; set; }
        public string Tag { get; set; } = null;
        public string Key { get; set; } = null;       

        public long Delay { get; set; } = 0L;

        public bool IsOffsetDelay { get; set; } = true;

        public Dictionary<string, string> Properties { get; private set; } = new();

    }
}