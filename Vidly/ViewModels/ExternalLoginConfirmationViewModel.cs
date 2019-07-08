﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



namespace Vidly.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "DrivingLicense")]
        public string DrivingLicense { get; set; }
        [Required]
        [Display(Name = "Phone")]
        public string Phone { get; set; }
    }
}