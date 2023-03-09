using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission09_klintyk.Models;

namespace Mission09_klintyk.Pages
{
    public class CheckoutModel : PageModel
    {
        private IBookstoreRepository repo { get; set; }

        public CheckoutModel(IBookstoreRepository temp)
        {
            repo = temp;
        }

        public Cart cart { get; set; }
        public void OnGet(Cart c)
        {
            cart = c;
        }

        public IActionResult OnPost(int bookid)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookid);
            cart = new Cart();
            cart.AddItem(b, 1);
            return RedirectToPage(cart);
        }
    }
}
