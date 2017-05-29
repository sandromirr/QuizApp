﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.ViewModels
{
    public class CreateUserViewModel
    {
        [Required]
        public string Fullname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        [Required]
        [MinLength(6)]
        [Compare(nameof(Password), ErrorMessage = "არ ემთხვევა პაროლები")]
        public string Repeat { get; set; }
    }
}
