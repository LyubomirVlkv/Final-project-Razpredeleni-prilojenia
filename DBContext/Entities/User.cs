using DBContext.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassContext.Entities
{
    public class User : BaseEntity
    {
        [Required]
        [StringLength(30)]
        public string Username { get; set; }
        [Required]
        [StringLength(30)]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }

        public string Description { get; set; }

        public DateTime userCreated { get; set; }

        public double userAge { get; set; }

        public virtual ICollection<Thread> Threads { get; set; }

    }
}
