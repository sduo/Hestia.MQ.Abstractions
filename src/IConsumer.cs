﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hestia.MQ.Abstractions
{
    public interface IConsumer
    {
        public string Group { get; }

        public Task<List<Message>> Consume();
    }
}
