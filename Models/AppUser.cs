using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace TradingTrainer.Models
{
    public class User : IdentityUser<int>
    {
        [NotMapped]
        public int UserId {
            get { return Id; }
        }
        public string Gender { get; set; }
        public DateTime DateofBirth { get; set; }
        [Required]
        [MaxLength(256)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(256)]
        public string LastName { get; set; }
        public DateTime LastActive { get; set; }

    }
}