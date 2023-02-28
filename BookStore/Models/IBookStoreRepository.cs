using BookStore_olsenj8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_olsenj8.Models
{
    //This interface object creates the IQueryable type object "Books". This class will be referenced in the 
    //EFBookStoreRepository class
    public interface IBookStoreRepository
    {
        IQueryable<Book> Books { get; }
    }
}
