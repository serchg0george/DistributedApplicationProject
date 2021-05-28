﻿using ApplicationService.DTOs;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            List<BookVM> booksVM = new List<BookVM>();

            using(SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                foreach(var item in service.GetBooks())
                {
                    booksVM.Add(new BookVM(item));
                }
                
            }
               
            return View(booksVM);
        }

        public ActionResult Create(BookVM bookVM)
        {
            try
            {
                using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                {
                    if(ModelState.IsValid)
                    {
                        BookDTO bookDTO = new BookDTO
                        {
                            Author = bookVM.Author,
                            Name = bookVM.Name,
                            Pages = bookVM.Pages,
                            Price = bookVM.Price,
                            Publisher = bookVM.Publisher,
                            Year = bookVM.Year

                        };
                        service.PostBook(bookDTO);

                        return RedirectToAction("Index");
                    }

                    return View();

                }
            }

            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                service.DeleteBook(id);
            }
            return RedirectToAction("Index");
        }


    }
}