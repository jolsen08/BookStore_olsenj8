using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Creating the PathAndQuery Method which will be used elsewhere to bring the user back to the page they were originally shopping on when
//they added an item to the cart.
namespace BookStore_olsenj8.Infrastructure
{
    public static class UrlExtensions
    {
        public static string PathAndQuery(this HttpRequest request) =>
            request.QueryString.HasValue ? $"{request.Path}{request.QueryString}" : request.Path.ToString();
    }
}
