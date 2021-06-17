using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyKoloApi.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [MaxLength(11)]
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public virtual IEnumerable<Savings> Savings { get; set; }
        public virtual IEnumerable<Expense> Expenses { get; set; }
    }
}