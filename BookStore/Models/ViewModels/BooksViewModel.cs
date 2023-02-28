using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_olsenj8.Models.ViewModels
{
    public class BooksViewModel
    {
        //Using an IQueryable type variable for Book and creating the PageInfo variable which will be used elsewhere
        public IQueryable<Book> Books { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
