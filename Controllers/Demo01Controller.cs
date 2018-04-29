using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Is3106Lecture12DotNet.Models;
using Newtonsoft.Json;

namespace Is3106Lecture12DotNet.Controllers
{
    public class Demo01Controller : Controller
    {
        Demo01ViewModel demo01ViewModel;



        public Demo01Controller()
        {
            demo01ViewModel = new Demo01ViewModel();
        }



        public IActionResult Index()
        {
            return View();
        }



        public IActionResult IntegerCounter()
        {
            return View(demo01ViewModel);
        }



        [HttpPost]
        public IActionResult IntegerCounter(int _notUsed)
        {
            loadSessionIntegerCounter();
            demo01ViewModel.incrementCounters();
            updateSessionIntegerCounter();

            return View(demo01ViewModel);
        }



        public IActionResult StringAndObject()
        {
            loadSessionStringAndObjectInitial();
            return View(demo01ViewModel);
        }



        public IActionResult StringAndObjectRedirect()
        {
            loadSessionStringAndObjectRedirect();
            return View(demo01ViewModel);
        }



        private void loadSessionIntegerCounter()
        {
            int? sessionScopedCounter = HttpContext.Session.GetInt32("sessionScopedCounter");

            if (sessionScopedCounter == null)
            {
                sessionScopedCounter = 0;
                HttpContext.Session.SetInt32("sessionScopedCounter", 0);
            }

            demo01ViewModel.SessionScopedCounter = (int)sessionScopedCounter;
        }



        private void updateSessionIntegerCounter()
        {
            HttpContext.Session.SetInt32("sessionScopedCounter", demo01ViewModel.SessionScopedCounter);
        }



        private void loadSessionStringAndObjectInitial()
        {
            var sessionScopedString = HttpContext.Session.GetString("sessionScopedString");

            if (string.IsNullOrEmpty(sessionScopedString))
            {
                sessionScopedString = "Hello World! I am session scoped!";
                HttpContext.Session.SetString("sessionScopedString", sessionScopedString);
            }

            var sessionScopedObject = HttpContext.Session.GetString("sessionScopedObject");            

            if (string.IsNullOrEmpty(sessionScopedObject))
            {
                Book book = new Book(1, "978-8-01-111111-8", "Book 01", "Author 01");
                sessionScopedObject = JsonConvert.SerializeObject(book);
                HttpContext.Session.SetString("sessionScopedObject", sessionScopedObject);
            }

            demo01ViewModel.SessionScopedString = sessionScopedString;
            demo01ViewModel.SessionScopedObject = JsonConvert.DeserializeObject<Book>(sessionScopedObject);
        }



        private void loadSessionStringAndObjectRedirect()
        {
            // Don't need to check for null or empty value since we assume the respective session state already set
            var sessionScopedString = HttpContext.Session.GetString("sessionScopedString");            
            var sessionScopedObject = HttpContext.Session.GetString("sessionScopedObject");
        
            demo01ViewModel.SessionScopedString = sessionScopedString;
            demo01ViewModel.SessionScopedObject = JsonConvert.DeserializeObject<Book>(sessionScopedObject);
        }
    }
}
