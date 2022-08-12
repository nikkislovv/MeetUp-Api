﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IEventRepository
    {
        void CreateEvent(Event eventToCreate);
        void DeleteEvent(Event eventToDelete);
        void UpdateEvent(Event eventToUpdate);
        Task<IEnumerable<Event>> GetAllEventsAsync(bool trackChanges);
        Task<Event> GetEventByIdAsync(Guid Id, bool trackChanges);
    }
}
