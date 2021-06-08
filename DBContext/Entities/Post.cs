using ClassContext.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBContext.Entities
{
    public class Post : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string title { get; set; }

        public string smallerdescription { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        [StringLength(20)]
        public string keyterms { get; set; }

        public DateTime postcreated { get; set; }

        public long postNumber { get; set; }

        public virtual ICollection<Thread> Threads { get; set; }



    }
}
