using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_klintyk.Models
{
    public class Purchase
    {
        [key]
        [BindNever]
        public int PurchaseID { get; set; }
        [BindNever]
        public ICollection<CartLineItem> Lines { get; set;  }
        [Required(ErrorMessage = "Please enter a Name: ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter first line in address: ")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }

        [Required(ErrorMessage = "Please enter City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter State")]
        public string State { get; set; }
        [Required(ErrorMessage = "Please enter ZipCode")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Please enter Country")]
        public string Country { get; set; }

        [BindNever]
        public bool OrderReceived { get; set; } = false;
    }
}
