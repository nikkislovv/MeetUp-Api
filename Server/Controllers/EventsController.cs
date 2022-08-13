using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public EventsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEventsAsync()
        {
            var events = await _repository.Event.GetAllEventsAsync(false);
            var eventsDto = _mapper.Map<IEnumerable<EventToShowDto>>(events);
            return Ok(eventsDto);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetEventByIdAsync([FromRoute] Guid id)
        {
            var _event = await _repository.Event.GetEventByIdAsync(id, false);
            if (_event == null)
            {
                _logger.LogInfo($"Event with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            var eventDto = _mapper.Map<EventToShowDto>(_event);
            return Ok(eventDto);
        }

    }
}
