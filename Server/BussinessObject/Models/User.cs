﻿using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class User
    {
        public User()
        {
            Activities = new HashSet<Activity>();
            Notes = new HashSet<Note>();
            Orders = new HashSet<Order>();
            Roles = new HashSet<Role>();
        }

        public int UserId { get; set; }
        public string? Username { get; set; }
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
        public string? Token { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
