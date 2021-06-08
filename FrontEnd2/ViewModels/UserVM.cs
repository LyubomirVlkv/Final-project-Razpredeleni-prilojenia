using FrontEnd2.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd2.ViewModels
{
    public class UserVM
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Username { get; set; }
        [Required]
        [StringLength(30)]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }

        public string Description { get; set; }

        [Display(Name = "User created / User updated")]
        [DataType(DataType.Date)]
        public DateTime userCreated { get; set; }
        [Display(Name = "Age")]
        public double userAge { get; set; }

        public UserVM(){}

        public UserVM(UserDTO userDTO)
        {
            Id = userDTO.Id;
            Username = userDTO.Username;
            Password = userDTO.Password;
            Email = userDTO.Password;
            Description = userDTO.Description;
            userCreated = userDTO.userCreated;
            userAge = userDTO.userAge;
        }
    }
}