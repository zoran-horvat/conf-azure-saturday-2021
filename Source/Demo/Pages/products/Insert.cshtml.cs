using Demo.Infrastructure;
using Demo.Models.Authentication;
using Demo.Models.Content;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.Pages.Products
{
    public class InsertModel : PageModel
    {
        private IWriteDbContext<Product> DbContext { get; }

        public InsertModel(FullOwnershipContentContext dbContext)
        {
            this.DbContext = dbContext;
        }

        [BindProperty] public string NewProductName { get; set; } = string.Empty;

        public IActionResult OnPost()
        {
            if (!string.IsNullOrWhiteSpace(this.NewProductName))
            {
                this.DbContext.Add(Product.CreateNew(this.NewProductName, this.AuthenticatedUser));
                this.DbContext.SaveChanges();
            }
            return RedirectToPage("./index");
        }

        private UserRef AuthenticatedUser =>
            base.HttpContext.GetAuthenticatedUser();
    }
}
