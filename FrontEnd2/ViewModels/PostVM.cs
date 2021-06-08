using FrontEnd2.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd2.ViewModels
{
    public class PostVM
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Post title")]
        public string title { get; set; }

        [Display(Name = "Small description")]
        public string smallerdescription { get; set; }
        [Display(Name = "Description")]
        [Required]
        public string description { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Key Terms")]
        public string keyterms { get; set; }

        [Display(Name = "Post Created / Post edited")]
        [DataType(DataType.Date)]
        public DateTime postcreated { get; set; }

        [Display(Name = "Post number")]
        public long postNumber { get; set; }

        public PostVM() { }

        public PostVM(PostDTO postDTO)
        {
            Id = postDTO.Id;
            title = postDTO.title;
            smallerdescription = postDTO.smallerdescription;
            description = postDTO.description;
            keyterms = postDTO.keyterms;
            postcreated = postDTO.postcreated;
            postNumber = postDTO.postNumber;
        }
    }
}