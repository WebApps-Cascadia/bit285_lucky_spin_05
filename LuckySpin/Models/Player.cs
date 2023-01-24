﻿using System.ComponentModel.DataAnnotations;
namespace LuckySpin.Models
{
    public class Player //TODO: Add and Annotate a decimal property called Balance
    {

        [Required(ErrorMessage ="Name is required")]
        public string FirstName { get; set; }

        [Range(1,10, ErrorMessage = "Choose a number, 1-10")]
        public int Luck { get; set; }

        [Range (3.0, 10.0, ErrorMessage = "The value is invalid")]
        public decimal Balance { get; set; }
    }
}