using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BussinessObject.Models
{
    public partial class User
    {
        public User()
        {
            Activities = new HashSet<Activity>();
            Notes = new HashSet<Note>();
            Orders = new HashSet<Order>();
        }

        public int UserId { get; set; }
        [Required]       
        public string? Username { get; set; }
        [Required]		
		public string? Password { get; set; }
        public string? FullName { get; set; }
        public string? Description { get; set; }
        public int? Age { get; set; }
        public int? Gender { get; set; }
        public string? Location { get; set; }
        public string? Email { get; set; }
        public int? Status { get; set; }
        public string? Avatar { get; set; }
        public bool? IsPrivate { get; set; }
        public bool? DeleteFlag { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
