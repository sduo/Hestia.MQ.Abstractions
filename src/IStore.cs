using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hestia.MQ.Abstractions
{
    public interface IStore
    {
        public Task<int> PublishAsync(Message message);
        public Task<int> PublishReportAsync(Message message);

        public Task<int> ConsumeAsync(Message message);

        public Task<int> ConsumeReportAsync(Message message);
    }
}
