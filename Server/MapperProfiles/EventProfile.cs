using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace Server.MapperProfiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventToShowDto>();
            CreateMap<EventToCreateDto, Event>();
        }
    }
}
