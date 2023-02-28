using BookStore_olsenj8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_olsenj8.Models
{
    //The EFBookStoreRepository class inherits from IBookStoreRepository and adds the context variable as well as
    //the IQueryable type object from Book "Books"
    public class EFBookStoreRepository : IBookStoreRepository
    {

        private BookstoreContext context { get; set; }

        public EFBookStoreRepository (BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Book> Books => context.Books;
    }
}
