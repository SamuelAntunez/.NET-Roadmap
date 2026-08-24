using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Persons
{
    public class UpdatePersonDto
    {
        public Guid id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;


    }
}
