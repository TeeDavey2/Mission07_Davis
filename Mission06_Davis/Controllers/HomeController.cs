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

        //CREATE ROUTE
        [HttpGet]
        public IActionResult MovieForm()
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(cat => cat.CategoryName)
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
                    .OrderBy(cat => cat.CategoryName)
                    .ToList();

                return View(response);
            }
        }

        //VIEW ROUTE
        public IActionResult MovieList()
        {
            //Including the Category model & table to load in the MovieList
            var movies = _context.Movies
                .Include(movie => movie.Category)
                .OrderBy(movie => movie.Title)
                .ToList();

            return View(movies);
        }
        
        //EDIT ROUTE
        [HttpGet]
        public IActionResult Edit(int id)
        {
            MovieModel recordToEdit = _context.Movies
                .Single(movie => movie.MovieId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(cat => cat.CategoryName)
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

        //DELETE ROUTE
        [HttpGet]
        public IActionResult Delete(int id)
        {
            MovieModel recordToDelete = _context.Movies
                .Single(movie => movie.MovieId == id);

            return View("Delete", recordToDelete);
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
