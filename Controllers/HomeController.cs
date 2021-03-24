using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FilmCollection.Models;

namespace FilmCollection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private FilmDbContext context { get; set; }


        public HomeController(ILogger<HomeController> logger, FilmDbContext con)
        {
            _logger = logger;
            context = con;
        }

    
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult FilmApplication()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FilmApplication(Response response)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                TempStorage.AddApplication(response);
                //below adds the file to the SqlLite database
                context.Films.Add(response);
                context.SaveChanges();

                
                return View("Confirmation", response);
            }
        }


        public IActionResult List()
        {
            //use database instead of the method
            return View(context.Films);
        }

   
        [HttpPost]
        public IActionResult EditForm(int editId)
        {
            Response movieToEdit = context.Films.FirstOrDefault(s => s.SubmissionId == editId);
            ViewBag.movieToEdit = movieToEdit;
            return View("EditForm");
        }

        //Edit the database record
        [HttpPost]
        public IActionResult Edit(Response movieWithEdits)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.movieToEdit = movieWithEdits; 
                return View("EditForm");
            }
            else
            {
                var movieToEdit = context.Films.FirstOrDefault(s => s.SubmissionId == movieWithEdits.SubmissionId);
                movieToEdit.Category = movieWithEdits.Category;
                movieToEdit.Title = movieWithEdits.Title;
                movieToEdit.Year = movieWithEdits.Year;
                movieToEdit.Director = movieWithEdits.Director;
                movieToEdit.Rating = movieWithEdits.Rating;
                movieToEdit.Edited = movieWithEdits.Edited;
                movieToEdit.LentTo = movieWithEdits.LentTo;
                movieToEdit.Notes = movieWithEdits.Notes;
                context.SaveChanges();
                return View("List", context.Films);
            }

        }

        //Delete 
        [HttpPost]
        public IActionResult Delete(int deletionId)
        {
            context.Remove(context.Films.FirstOrDefault(s => s.SubmissionId == deletionId));
            context.SaveChanges();
            return View("List", context.Films);
        }

        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
