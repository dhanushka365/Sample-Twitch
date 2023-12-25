using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Contracts
{

    public interface SubmitOrder
    {
        public Guid OrderId { get; }
        public DateTime Timestamp { get; }
        public string CustomerNumber { get; }
        public string[] Items { get; }

    }

}
