using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.EventDTO
{
    public class EventToHandleDto
    {
        [Required(ErrorMessage = "Name is a required field.")]
        [MaxLength(20, ErrorMessage = "Maximum length for the Name is 20 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is a required field.")]
        [MaxLength(150, ErrorMessage = "Maximum length for the Description is 150 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Organizer is a required field.")]
        [MaxLength(20, ErrorMessage = "Maximum length for the Organizer is 20 characters")]
        public string Organizer { get; set; }

        [Required(ErrorMessage = "Time is required")]
        [DataType(DataType.DateTime)]
        public DateTime Time { get; set; }

        [Required(ErrorMessage = "Place is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Place is 30 characters")]
        public string Place { get; set; }
    }
}
