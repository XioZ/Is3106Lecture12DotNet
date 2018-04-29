using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using Is3106Lecture12DotNet.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceReference1;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Is3106Lecture12DotNet.Controllers
{
    public class Demo03Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult CreateBook()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> CreateBook([Bind("isbn,title,author")]book bk)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    BookWebServiceClient bookWebServiceClient = new BookWebServiceClient();
                    createBookReq req = new createBookReq();
                    req.book = bk;
                    createBookResponse response = await bookWebServiceClient.createBookAsync(req);
                    createBookRsp rsp = response.@return;

                    ViewData["InfoMessage"] = "New book created successfully: " + rsp.id;
                }
                catch(FaultException ex)
                {
                    ViewData["ErrorMessage"] = ex.Message;
                }
            }
            else
            {
                ViewData["ErrorMessage"] = "Please correct the input data error and try again";
            }

            return View(bk);
        }




        public async Task<IActionResult> ViewAllBooks()
        {
            BookWebServiceClient bookWebServiceClient = new BookWebServiceClient();
            retrieveAllBooksResponse response = await bookWebServiceClient.retrieveAllBooksAsync();
            retrieveAllBooksRsp rsp = response.@return;

            Demo03ViewModel demo03ViewModel = new Demo03ViewModel();
            demo03ViewModel.Books = rsp.books;

            return View(demo03ViewModel);
        }



        public async Task<IActionResult> ViewBookDetails(int id)
        {
            BookWebServiceClient bookWebServiceClient = new BookWebServiceClient();
            retrieveBookResponse response = await bookWebServiceClient.retrieveBookAsync(id);
            retrieveBookRsp rsp = response.@return;

            Demo03ViewModel demo03ViewModel = new Demo03ViewModel();
            demo03ViewModel.SelectedBookToView = rsp.book;

            return View(demo03ViewModel);
        }



        public async Task<IActionResult> UpdateBook(int id)
        {
            BookWebServiceClient bookWebServiceClient = new BookWebServiceClient();
            retrieveBookResponse response = await bookWebServiceClient.retrieveBookAsync(id);
            retrieveBookRsp rsp = response.@return;

            return View(rsp.book);
        }



        [HttpPost]
        public async Task<IActionResult> UpdateBook([Bind("id,isbn,title,author")]book bk)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    BookWebServiceClient bookWebServiceClient = new BookWebServiceClient();
                    updateBookReq req = new updateBookReq();
                    req.book = bk;
                    req.book.idSpecified = true;
                    
                    updateBookResponse response = await bookWebServiceClient.updateBookAsync(req);

                    ViewData["InfoMessage"] = "Book updated successfully";
                }
                catch (FaultException ex)
                {
                    ViewData["ErrorMessage"] = ex.Message;
                }
            }
            else
            {
                ViewData["ErrorMessage"] = "Please correct the input data error and try again";
            }            

            return View(bk);
        }



        public async Task<IActionResult> DeleteBook(int id)
        {
            BookWebServiceClient bookWebServiceClient = new BookWebServiceClient();
            deleteBookResponse response = await bookWebServiceClient.deleteBookAsync(id);

            return RedirectToAction("ViewAllBooks");
        }
    }    
}
