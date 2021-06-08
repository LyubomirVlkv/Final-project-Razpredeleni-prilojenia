using ClassContext.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBContext.Entities
{
    public class Thread : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string threadName { get; set; }
        [Required]
        public string threadDiscription { get; set; }
        [Required]
        public string threadKeyTerms { get; set; }

        public DateTime threadCreationDate { get; set; }

        public long threadNumber { get; set; }

        public int PostId { get; set; }
        public virtual Post post { get; set; }

        public int UserId { get; set; }

        public virtual User user { get; set; }




    }
}
