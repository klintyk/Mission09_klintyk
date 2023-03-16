﻿using Microsoft.AspNetCore.Mvc;
using Mission09_klintyk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_klintyk.Controllers
{
    public class PurchaseController : Controller
    {
        private IPurchaseRepository repo { get; set; }
        private Cart cart { get; set; }
        public PurchaseController(IPurchaseRepository temp, Cart c)
        {
            repo = temp;
            cart = c;
        }

        [HttpGet]
        public IActionResult Purchase()
        {
            return View(new Purchase());
        }
        [HttpPost]
        public IActionResult Purchase(Purchase purchase)
        {
           if(cart.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, Your Basket is Empty");
            }
            if (ModelState.IsValid)
            {
                purchase.Lines = cart.Items.ToArray();
                repo.SavePurchase(purchase);
                cart.ClearCart();

                return RedirectToPage("/Confirmation");
            }

            else
            {
                return View();
            }
        }
    }
}
