using ClassContext.Entities;
using DBContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService1.DTOs
{
    public class ThreadDTO

    {
        public int Id { get; set; }
        public string threadName { get; set; }
      
        public string threadDiscription { get; set; }
     
        public string threadKeyTerms { get; set; }

        public DateTime threadCreationDate { get; set; }

        public long threadNumber { get; set; }

        public int PostId { get; set; }
        public virtual PostDTO post { get; set; }

        public int UserId { get; set; }

        public virtual UserDTO user { get; set; }
    }
}
