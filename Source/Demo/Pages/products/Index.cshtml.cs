using System.Collections.Generic;
using System.Linq;
using Demo.Infrastructure;
using Demo.Models.Content;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.Pages.Products
{
    public class IndexModel : PageModel
    {
        private IContentReadContext DbContext { get; }

        [BindProperty] public string NewProductName { get; set; } = string.Empty;
        public IEnumerable<Product> AllProducts { get; private set; } = Enumerable.Empty<Product>();

        public IndexModel(AssignedContentReadingContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public void OnGet()
        {
            this.AllProducts = this.DbContext.Products.ToList();
        }
    }
}
