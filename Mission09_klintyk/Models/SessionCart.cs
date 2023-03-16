using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Mission09_klintyk.Infrastructuer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mission09_klintyk.Models
{
    public class SessionCart : Cart
    {
        [JsonIgnore]
        public ISession Session { get; set; }

        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("cart") ?? new SessionCart();
            cart.Session = session;
            return cart;
        }

        public override void AddItem(Book book, int qty)
        {
            base.AddItem(book, qty);
            Session.SetJson("cart", this);
        }

        public override void RemoveItem(Book book)
        {
            base.RemoveItem(book);
            Session.SetJson("cart", this);
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
            Session.Remove("cart");
        }

    }
}
