using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService1.DTOs
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string title { get; set; }

        public string smallerdescription { get; set; }

        public string description { get; set; }

        public string keyterms { get; set; }

        public DateTime postcreated { get; set; }

        public long postNumber { get; set; }

    }
}
