using Microsoft.AspNetCore.Mvc;
using Mission09_klintyk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_klintyk.Controllers
{
    public class HomeController : Controller
    {
        private BookstoreContext context { get; set; }
        //public HomeController(BookstoreContext temp)
        //{
        //    context = temp;
        //}

        //shortcut of above code
        public HomeController(BookstoreContext temp) => context = temp;
        public IActionResult Index()
        {
            var book = context.Books.ToList();
            return View(book);
        }
    }
}
