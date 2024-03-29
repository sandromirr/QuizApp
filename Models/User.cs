﻿
using QuizApp.Extensions;

namespace QuizApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get;set;}
        public int IsActive { get; set; }
        public int UserRoleId { get; set; }
    }
}
