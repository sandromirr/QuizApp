﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuizApp.DB;
using QuizApp.Models;
using QuizApp.Extensions;
using QuizApp.Filters;
using QuizApp.Repository;
using QuizApp.ViewModels;

namespace QuizApp.Controllers
{
    [AdminFilter]
    public class TestController : Controller
    {

        private readonly IRepository<Test> testRepository;
        private readonly IRepository<Genre> genreRepository;
        private readonly IRepository<Question> questionRepository;

        public TestController()
        {
            genreRepository = new GenreRepository();
            testRepository = new TestRepository();
            questionRepository = new QuestionRepository();
        }

        public IActionResult Index()
        {
            var tests = testRepository.getAll();
            return View(tests);
        }

        public IActionResult Create()
        {
            var genres = genreRepository.getAll();
            return View(genres);
        }

        [HttpPost]
        public IActionResult Create(CreateTestViewModel vm)
        {
            var genres = genreRepository.getAll();

            if (!ModelState.IsValid)
            {
                return View(genres);
            }

            if (vm.Difficulty < 0 || vm.Difficulty > 10)
            {
                ModelState.AddModelError("errors", "არასწორია სირთულის დონე");
                return View(genres);
            }

            if (genres.Where(x => x.Id == vm.GenreId).FirstOrDefault() == null)
            {
                ModelState.AddModelError("errors", "არ არსებობს ასეთი ჟანრი");
                return View(genres);
            }

            Test test = new Test
            {
                Title = vm.Title,
                Difficulty = vm.Difficulty,
                GenreId = vm.GenreId
            };

            testRepository.Add(test);

            return RedirectToAction("Index", "Test");
        }

        public IActionResult Details(int Id)
        {
            var test = testRepository.Get(Id);
            var questions = questionRepository
                .getAll()
                .Where(x => x.TestId == test.Id)
                .ToList();

            DetailsTestViewModel vm = new DetailsTestViewModel
            {
                Test = test,
                Question = questions
            };

            return View(vm);
        }

        public IActionResult Search(string query)
        {
            var tests = testRepository.getAll()
                .Where(x => x.Title.ToLower().Contains(query.ToLower()))
                .ToList();
            return View(tests);
        }
    }
}