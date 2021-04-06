using System.Threading.Tasks;
using Demo.Infrastructure;
using Demo.Models.Content;
using Demo.Models.Images;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.Pages.images.product
{
    public class DeleteModel : PageModel
    {
        private IReadDbContext DbContext { get; }
        private IImageStore ImageStore { get; }

        public DeleteModel(FullOwnershipContentContext dbContext, IImageStore imageStore)
        {
            this.DbContext = dbContext;
            this.ImageStore = imageStore;
        }

        public async Task<IActionResult> OnPostAsync(int productId)
        {
            if (this.DbContext.Find<Product>(productId) is Product product)
            {
                await this.ImageStore.RemoveAsync(product.Reference);
            }
            return RedirectToPage("/products/details", new { productId = productId });
        }
    }
}
