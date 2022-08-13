using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestFeatures
{
    public class EventParameters : RequestParameters
    {
        public DateTime MinTime { get; set; }= DateTime.MinValue;
        public DateTime MaxTime { get; set; } = DateTime.MaxValue;
        public bool ValidDateRange => MaxTime > MinTime;
    }
}
