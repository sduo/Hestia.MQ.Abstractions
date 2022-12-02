using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hestia.MQ.Abstractions
{
    public interface IWorker
    {
        public Task<(int, Action<Message>)> OnMessageAsync(Message message);
    }
}
