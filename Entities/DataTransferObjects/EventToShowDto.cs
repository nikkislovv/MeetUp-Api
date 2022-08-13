using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class EventToShowDto 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Organizer { get; set; }
        public DateTime Time { get; set; }
        public string Place { get; set; }
    }
}
