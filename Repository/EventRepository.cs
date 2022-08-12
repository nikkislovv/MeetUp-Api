﻿using Contracts;
using Entities;
using Entities.Models;
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
        public async Task<IEnumerable<Event>> GetAllEventsAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }
        public async Task<Event> GetEventByIdAsync(Guid Id, bool trackChanges)
        {
            return await FindByCondition(e => e.Id.Equals(Id), trackChanges).SingleOrDefaultAsync();
        }

    }
}
