using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_olsenj8.Models
{
    //Here we are creating our Cart class, which will add items to the cart as a typical online shopping cart would do
    public class Cart
    {
        public List<CartLineItem> Items { get; set; } = new List<CartLineItem>();

        //Here is our AddItem method which adds a book and quantity to the cart
        public void AddItem (Book book, int qty)
        {
            CartLineItem line = Items
                .Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();

            //If the line is null (the book hasn't been added yet), we will create a new line item. If the book has been added previously,
            //we stay on the same line but add to the quantity (which will then alter the price)
            if (line == null)
            {
                Items.Add(new CartLineItem
                {
                    Book = book,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        //Our CalculateTotal method takes the quantity and book price of each line item, multiplies them, and then sums the total of all the line
        //items
        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Book.Price);
            return sum;

        }
    }

   

    public class CartLineItem
    {
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
