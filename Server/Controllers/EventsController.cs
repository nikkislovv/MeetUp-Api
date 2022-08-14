using AutoMapper;
using Contracts;
using Entities.DataTransferObjects.EventDTO;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
    [Authorize]
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

        /// <summary>
        /// Get list of all Events
        /// </summary>
        /// <param name="eventParameters"></param>
        /// <returns>The list of Events</returns>
        /// <response code="200">Returns the list of all Events</response>
        /// <response code="400">Request parameters are not valid</response>
        /// <response code="401">You are not authorized</response>
        /// <response code="500">Server error</response>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllEventsAsync([FromQuery] EventParameters eventParameters)       
        {
            if (!eventParameters.ValidDateRange)
                return BadRequest("Max Date can't be less than min Date.");
            var events = await _repository.Event.GetAllEventsAsync(eventParameters,false);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(events.MetaData));
            var eventsDto = _mapper.Map<IEnumerable<EventToShowDto>>(events);
            return Ok(eventsDto);
        }

        /// <summary>
        /// Return one Event by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Event</returns>
        /// <response code="200">Returns one Event</response>
        /// <response code="401">You are not authorized</response>
        /// <response code="404">Event with this id not found</response>
        /// <response code="500">Server error</response>
        [HttpGet("{Id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetEventByIdAsync([FromRoute] Guid Id)
        {
            var _event = await _repository.Event.GetEventByIdAsync(Id, false);
            if (_event == null)
            {
                _logger.LogInfo($"Event with id: {Id} doesn't exist in the database.");
                return NotFound();
            }
            var eventDto = _mapper.Map<EventToShowDto>(_event);
            return Ok(eventDto);
        }

        /// <summary>
        ///  Create one new Event
        /// </summary>
        /// <param name="eventDto"></param>
        /// <returns></returns>
        /// <response code="201">Event created</response>
        /// <response code="400">New Event is null</response>
        /// <response code="401">You are not authorized</response>
        /// <response code="403">You have no rules</response>
        /// <response code="422">New Event is not valid</response>
        /// <response code="500">Server error</response>
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateEventAsync([FromBody] EventToCreateDto eventDto)
        {
            var _event=_mapper.Map<Event>(eventDto);
            _repository.Event.CreateEvent(_event);
            await _repository.SaveAsync();
            return StatusCode(201);
        }

        /// <summary>
        /// Update Event by id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="eventDto"></param>
        /// <returns></returns>
        /// <response code="204">Event updated</response>
        /// <response code="400">New Event is null</response>
        /// <response code="401">Not authorized</response>
        /// <response code="403">You have no rules</response>
        /// <response code="404">Event with this id not found</response>
        /// <response code="422">New Event not valid</response>
        /// <response code="500">Server error</response>
        [HttpPut("{Id}")]
        [Authorize(Roles = "admin")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
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

        /// <summary>
        /// Delete Event by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// <response code="204">Event deleted</response>
        /// <response code="401">Not authorized</response>
        /// <response code="403">You have no rules</response>
        /// <response code="404">Event with this id not found</response>
        /// <response code="500">Server error</response>
        [HttpDelete("{Id}")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
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
