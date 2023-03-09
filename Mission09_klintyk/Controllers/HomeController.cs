using Microsoft.AspNetCore.Mvc;
using Mission09_klintyk.Models;
using Mission09_klintyk.Models.ViewModels;
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
    
        public IActionResult Index(string category, int page_num = 1)
        {
            int page_size = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(b => b.Category == category || category == null)
                .OrderBy(b => b.Title)
                .Skip((page_num - 1) * page_size)
                //take 10 per page
                .Take(page_size),

                PageInfo = new PageInfo
                {
                    TotalNumBooks =(category == null?  repo.Books.Count() : repo.Books.Where(x=>x.Category == category).Count()),
                    BooksPerPage = page_size,
                    CurrentPage = page_num
                }
            };
            return View(x);
        }
    }
}
