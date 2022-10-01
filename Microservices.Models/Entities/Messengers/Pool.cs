using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Models.Entities.Messengers
{
    public class Pool: BaseEntity
    {
        public List<Member> Members { get; set; }
        public List<Message> Messages { get; set; }
    }
}
