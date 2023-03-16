using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission09_klintyk.Infrastructuer;
using Mission09_klintyk.Models;

namespace Mission09_klintyk.Pages
{
    public class CheckoutModel : PageModel
    {
        private IBookstoreRepository repo { get; set; } 
        public Cart cart { get; set; }
        public string ReturnUrl { get; set; }

        public CheckoutModel(IBookstoreRepository temp, Cart c)
        {
            repo = temp;
            cart = c;
        }

       
        public void OnGet(string returnurl)
        {
            ReturnUrl = returnurl ?? "/";
            //cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(int bookid, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookid);
            //cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            cart.AddItem(b, 1);
            //HttpContext.Session.SetJson("cart", cart);
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(int bookid, string returnurl)
        {
            cart.RemoveItem(cart.Items.First(x => x.Book.BookId == bookid).Book);
            return RedirectToPage(new {ReturnUrl = returnurl});

        }
    }
}
