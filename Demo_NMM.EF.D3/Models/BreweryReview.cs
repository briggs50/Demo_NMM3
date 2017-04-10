﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Demo_NMM.EF.D2.Models
{
    public class BreweryReview
    {
        public int ID { get; set; }

        [Display(Name = "Date Created")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DateCreated { get; set; }

        [Required]
        public string Content { get; set; }

        public int BreweryID { get; set; }
    }
}