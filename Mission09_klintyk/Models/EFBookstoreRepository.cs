﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_klintyk.Models
{
    public class EFBookstoreRepository : IBookstoreRepository
    {
        private BookstoreContext context { get; set; }

        private EFBookstoreRepository(BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Book> Books => context.Books;
    }
}