using BookStore_olsenj8.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_olsenj8.Components
{
    public class TypesViewComponent : ViewComponent
    {
        //Loading up a dataset
        private IBookStoreRepository repo { get; set; }
        public TypesViewComponent (IBookStoreRepository temp)
        {
            repo = temp;
        }

        //Pulling the distinct category types and returning it to a view
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["bookCategory"];

            var types = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);
            return View(types);
        }
    }
}
