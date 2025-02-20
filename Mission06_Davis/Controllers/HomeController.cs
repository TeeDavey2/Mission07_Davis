using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Davis.Models;

namespace Mission06_Davis.Controllers
{
    public class HomeController : Controller
    {
        private FilmCollectionContext _context;
        public HomeController(FilmCollectionContext temp) //Constructor
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AboutJoel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm()
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(c => c.CategoryName)
                .ToList();

            return View(new MovieModel());
        }

        [HttpPost]
        public IActionResult MovieForm(MovieModel response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response); //Add record to database
                _context.SaveChanges();

                return View("Response", response);
            }
            else //Invalid data
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();

                return View(response);
            }
        }

        public IActionResult MovieList()
        {
            var applications = _context.Movies
                .Include(m => m.Category)
                .OrderBy(x => x.Title)
                .ToList();

            return View(applications);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            MovieModel recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("MovieForm", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(MovieModel updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            MovieModel recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(MovieModel movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }

    }
}
