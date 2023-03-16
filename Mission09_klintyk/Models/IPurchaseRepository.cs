using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_klintyk.Models
{
    public class IPurchaseRepository
    {
        public IQueryable<Purchase> Purchases { get; }
        public void SavePurchase(Purchase purchase);
    }
}
