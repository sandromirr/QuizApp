﻿using System.ComponentModel.DataAnnotations;

namespace QuizApp.ViewModels
{
    public class CreateTestViewModel
    {
        [Required]
        public int GenreId { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(150)]
        public string Title { get; set; }
        [Required]
        public int Difficulty { get; set; }
    }
}
