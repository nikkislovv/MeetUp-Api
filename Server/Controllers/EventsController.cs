using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.ActionFilters;
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

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateEventAsync([FromBody] EventToCreateDto eventDto)
        {
            var _event=_mapper.Map<Event>(eventDto);
            _repository.Event.CreateEvent(_event);
            await _repository.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateEventAsync([FromRoute] Guid Id,[FromBody] EventToUpdateDto eventDto)
        {
            var _event = await _repository.Event.GetEventByIdAsync(Id, true);
            if (_event==null)
            {
                _logger.LogInfo($"Event with id: {Id} doesn't exist in the database.");
                return NotFound();
            }
            _mapper.Map(eventDto, _event);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteEventAsync([FromRoute] Guid Id)
        {
            var _event = await _repository.Event.GetEventByIdAsync(Id, false);
            if (_event==null)
            {
                _logger.LogInfo($"Event with id: {Id} doesn't exist in the database.");
                return NotFound();
            }
            _repository.Event.DeleteEvent(_event);
            await _repository.SaveAsync();
            return NoContent();
        }



    }
}
