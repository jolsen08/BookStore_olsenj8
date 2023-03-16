using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore_olsenj8.Infrastructure;
using BookStore_olsenj8.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore_olsenj8.Pages
{
    //Here is our Model which inherits from PageModel. We are doing similar things to what we did in our previous models here but with 
    //the Cart page in mind.
    public class BuyModel : PageModel
    {
        private IBookStoreRepository repo { get; set; }
        public Cart cart { get; set; }
        public string ReturnUrl { get; set; }

        public BuyModel (IBookStoreRepository temp, Cart c)
        {
            repo = temp;
            cart = c;
        }

        //This variable takes in the returnUrl and assigns it to the ReturnUrl variable, which will be used later on
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        //OnPost finds the book object that matches the bookId brought in from the user, adds the item to the cart, and sets
        //the Http Session Json to the cart object. 
        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);
 
            cart.AddItem(b, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
        //Removing the book associated with the bookid from the form post
        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            cart.RemoveItem(cart.Items.First(x => x.Book.BookId == bookId).Book);
            return RedirectToPage(new {ReturnUrl = returnUrl});
        }
    }
}
