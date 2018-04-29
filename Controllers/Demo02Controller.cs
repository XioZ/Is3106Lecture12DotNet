using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Is3106Lecture12DotNet.Models;
using Microsoft.AspNetCore.Mvc;



namespace Is3106Lecture12DotNet.Controllers
{
    public class Demo02Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult OneWayDataBinding()
        {
            Book book = new Book(1, "978-8-01-111111-8", "Book 01", "Author 01");

            return View(book);
        }



        public IActionResult TwoWayDataBinding()
        {
            return View();
        }



        [HttpPost]
        public IActionResult TwoWayDataBinding([Bind("ID,Isbn,Title,Author")]Book book)
        {
            if (ModelState.IsValid)
            {
                ViewData["InfoMessage"] = "New book created successfully: " + book.ID + "; " + book.Isbn + "; " + book.Title + "; " + book.Author;
            }
            else
            {
                ViewData["ErrorMessage"] = "Please correct the input data error and try again";
            }

            return View();
        }



        public IActionResult ViewModelBinding()
        {
            Console.WriteLine("********* HERE0");
            Demo02ViewModel demo02ViewModel = new Demo02ViewModel();
            demo02ViewModel.loadDefaultData();

            return View(demo02ViewModel);
        }



        [HttpPost]
        public IActionResult ViewModelBinding([Bind("SearchQuery")]Demo02ViewModel demo02ViewModel)
        {
            if (string.IsNullOrEmpty(demo02ViewModel.SearchQuery))
            {
                demo02ViewModel.loadDefaultData();
            }
            else
            {
                demo02ViewModel.search();
            }

            return View(demo02ViewModel);
        }
    }
}
