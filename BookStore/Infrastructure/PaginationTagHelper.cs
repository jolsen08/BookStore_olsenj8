using BookStore_olsenj8.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_olsenj8.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-blah")]
    public class PaginationTagHelper : TagHelper
    {
        //Dynamically create page links
        private IUrlHelperFactory uhf;

        //Making the PaginationTagHelper and setting it equal to the temp object
        public PaginationTagHelper (IUrlHelperFactory temp)
        {
            uhf = temp;
        }

        //Adding ViewContext and HtmlAttributeNotBound features to the ViewContext variable
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext vc { get; set; }

        //Different than the View Context
        public PageInfo PageBlah { get; set; }
        public string PageAction { get; set; }

        //These variables are for the styling of the page numbers at the bottom of the page.
        //This is referenced in the index.cshtml page
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        //Creating the method that will take the TagHelperContext and TagHelperOutput as inputs
        public override void Process (TagHelperContext thc, TagHelperOutput tho)
        {
            IUrlHelper uh = uhf.GetUrlHelper(vc);

            //Creating a new Tag Builder for div tags
            TagBuilder final = new TagBuilder("div");

            //Looping through each page and creating the necessary tags based on the total pages variable from the 
            //PageBlah object. This will dynamically add pages depending on the number of books in the database
            for (int i = 1; i <= PageBlah.TotalPages; i++)
            {
                //Making a new tagbuilder variable for a tags
                TagBuilder tb = new TagBuilder("a");
                tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = i });

                //This if statement is for styling
                if (PageClassesEnabled)
                {
                    tb.AddCssClass(PageClass);
                    tb.AddCssClass(i == PageBlah.CurrentPage ? PageClassSelected : PageClassNormal);

                }
                //Appending the number (i) to the tb object (to display page numbers)
                tb.InnerHtml.Append(i.ToString());

                //Apending the tb object to the final object (which makes div tags)
                final.InnerHtml.AppendHtml(tb);
            }

            //Appending the final object to the TagHelperOutput tho object
            tho.Content.AppendHtml(final.InnerHtml);
        }
    }
}
