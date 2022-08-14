using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasData
            (
            new Event
            {
                Id = new Guid("6cead492-73c4-48cf-9d77-4c3ef35052cb"),
                Name = "Excursion",
                Description = "Excursion to the Museum of old cars",
                Organizer = "Nikita Kislov",
                Time = new DateTime(2022, 9, 22),
                Place = "L.Sapegi 5"
            },
            new Event
            {
                Id = new Guid("2195fd5f-7453-47d1-9387-3a45042c68a1"),
                Name = "Movie Night",
                Description = "Сinema evening of scary movies",
                Organizer = "Ivan Filimonov",
                Time = new DateTime(2022, 10, 11),
                Place = "R.Slovat 44"
            },
            new Event
            {
                Id = new Guid("568b22ff-d7a2-4e8e-8291-e70219781699"),
                Name = "Birthday",
                Description = "Birthday of Nick, 25 years",
                Organizer = "Andrey Ivanov",
                Time = new DateTime(2022, 8, 27),
                Place = "O.Rydnova 32"
            },
            new Event
            {
                Id = new Guid("1bdbc616-2a86-4a08-a804-bb8fddc1b6ee"),
                Name = "Fitness Training",
                Description = "Fitness training for beginners",
                Organizer = "Alex Ivanov",
                Time = new DateTime(2022, 9, 5),
                Place = "Pavlov Park"
            }
            );
        }
    }
}
