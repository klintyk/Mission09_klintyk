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
        private IBookstoreRepository repo; 
        public HomeController (IBookstoreRepository temp)
        {
            repo = temp;
        }
    
        public IActionResult Index(int page_num = 1)
        {
            int page_size = 10;
            var book = repo.Books
                .OrderBy(b => b.Title)
                .Skip((page_num-1)*page_size)
                //take 10 per page
                .Take(page_size);
            return View(book);
        }
    }
}
