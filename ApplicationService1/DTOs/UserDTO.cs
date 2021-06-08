using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService1.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }


        public DateTime userCreated { get; set; }

        public double userAge { get; set; }
    }
}
