using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hestia.MQ.Abstractions
{
    public sealed class Message
    {                

        public string Id { get; set; }

        public string ChainId { get; set; }

        public string OrginId { get; set; }

        public string MessageId { get; set; }

        public string Instance { get; set; }

        public string Topic { get; set; }

        public string Group { get; set; }      

        public string Tag { get; set; }

        public string Consumer { get; set; }

        public string Body { get; set; }

        public string Key { get; set; }       

        public long Deliver { get; set; }

        public uint TotalConsumed { set; get; }

        public string Target { get; set; }

        public string Source { get; set; }

        public Dictionary<string, string> Properties { get; private set; } = new Dictionary<string, string>();
    }
}
