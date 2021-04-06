using System.Threading.Tasks;
using Demo.Infrastructure;
using Demo.Models.Content;
using Demo.Models.Images;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.Pages.images.product
{
    public class InsertModel : PageModel
    {
        private IReadDbContext DbContext { get; }
        private IImageStore ImageStore { get; }

        public InsertModel(FullOwnershipContentContext dbContext, IImageStore imageStore)
        {
            this.DbContext = dbContext;
            this.ImageStore = imageStore;
        }

        public async Task<IActionResult> OnPostAsync(int productId, IFormFile uploadImage)
        {
            await this.ImageStore.WriteAsync(
                () => uploadImage?.OpenReadStream(),
                this.DbContext.Find<Product>(productId));
            return RedirectToPage("/products/details", new { productId = productId });
        }
    }
}
