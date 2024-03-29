﻿using System.Collections.Generic;
using QuizApp.Models;

namespace QuizApp.ViewModels
{
    public class DetailsQuestionViewModel
    {
        public Genre Genre { get; set; }
        public Test Test { get; set; }
        public Question Question { get; set; }
        public List<Answer> Answer { get; set; }
    }
}
