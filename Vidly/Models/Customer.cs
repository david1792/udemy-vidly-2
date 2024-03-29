﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter customer's name")]//this anotation make this attribute no nullable
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSuscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }
        [Display(Name = "Membership type")]
        public byte MembershipTypeId { get; set; }
        [Display(Name = "Date of birth")]
        //[Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }
    }  
}