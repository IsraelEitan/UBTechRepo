using System;
using System.Collections.Generic;
using System.Text;

namespace UBTech.Service.DTOS
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Role { get; set; }
    }
}
