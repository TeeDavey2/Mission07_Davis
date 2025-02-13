using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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
            return View();
        }

        [HttpPost]
        public IActionResult MovieForm(Application response)
        {
            _context.Applications.Add(response); //Add record to database
            _context.SaveChanges();

            return View("Response", response);
        }



    }
}
