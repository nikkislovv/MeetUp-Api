using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public static class RepositoryEventExtensions
    {
        public static IQueryable<Event> FilterEvents(this IQueryable<Event> events, DateTime minTime, DateTime maxTime)
        {
            return events.Where(e => (e.Time >= minTime && e.Time <= maxTime));
        }
    }
}
