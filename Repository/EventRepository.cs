using Contracts;
using Entities;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EventRepository : RepositoryBase<Event>, IEventRepository
    {
        public EventRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public void CreateEvent(Event eventToCreate)
        {
            Create(eventToCreate);
        }
        public void DeleteEvent(Event eventToDelete)
        {
            Delete(eventToDelete);
        }
        public void UpdateEvent(Event eventToUpdate)
        {
            Update(eventToUpdate);
        }
        public async Task<PagedList<Event>> GetAllEventsAsync(EventParameters eventParameters,bool trackChanges)
        {
            var events = await FindAll(trackChanges)
                .FilterEvents(eventParameters.MinTime, eventParameters.MaxTime)//filtering by Time
                .OrderBy(e => e.Time)//sorting
                .Skip((eventParameters.PageNumber - 1) * eventParameters.PageSize)//paging
                .Take(eventParameters.PageSize)
                .ToListAsync();
            var count = await FindAll(false)
                .FilterEvents(eventParameters.MinTime, eventParameters.MaxTime)//filtering by Time
                .CountAsync();
            return new PagedList<Event>(events, count, eventParameters.PageNumber, eventParameters.PageSize);
        }
        public async Task<Event> GetEventByIdAsync(Guid Id, bool trackChanges)
        {
            return await FindByCondition(e => e.Id.Equals(Id), trackChanges).SingleOrDefaultAsync();
        }

    }
}
