using FrontEnd2.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd2.ViewModels
{
    public class ThreadVM
    {
        public int Id { get; set; }
        [Display(Name = "Thread title")]
        [Required]
        [StringLength(50)]
        public string threadName { get; set; }
        [Display(Name = "Thread Description")]
        [Required]
        public string threadDiscription { get; set; }
        [Display(Name = "Thread key terms")]
        [Required]
        public string threadKeyTerms { get; set; }


        [Display(Name = "Date of Thread Create/Edited")]
        [DataType(DataType.Date)]
        public DateTime threadCreationDate { get; set; }
        [Display(Name = "Thread number")]
        public long threadNumber { get; set; }
        public int PostId { get; set; }
        public PostVM postVM { get; set; }
        public int UserId { get; set; }
        public UserVM userVM { get; set; }

        public ThreadVM() { }

        public ThreadVM(ThreadDTO threadDTO)
        {
            Id = threadDTO.Id;
            threadName = threadDTO.threadName;
            threadDiscription = threadDTO.threadDiscription;
            threadKeyTerms = threadDTO.threadKeyTerms;
            threadCreationDate = threadDTO.threadCreationDate;
            threadNumber = threadDTO.threadNumber;
            PostId = threadDTO.PostId;
            postVM = new PostVM
            {
                Id = threadDTO.PostId,
                title = threadDTO.post.title,
                smallerdescription = threadDTO.post.smallerdescription,
                description = threadDTO.post.description,
                keyterms = threadDTO.post.keyterms,
                postcreated = threadDTO.post.postcreated,
                postNumber = threadDTO.post.postNumber,
            };
            UserId = threadDTO.UserId;
            userVM = new UserVM
            {
                Id = threadDTO.UserId,
            Username = threadDTO.user.Username,
            Password = threadDTO.user.Password,
            Email = threadDTO.user.Password,
            Description = threadDTO.user.Description,
            userCreated = threadDTO.user.userCreated,
            userAge = threadDTO.user.userAge,
            };
        }

      
    }
}