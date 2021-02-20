using Demo.Infrastructure;
using Demo.Models.Content;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Demo.Models.Images;
using System.Threading.Tasks;
using System.Drawing;

namespace Demo.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private IContentReadContext DbContext { get; }
                                                                                                                                                                                                                                                // snp24 Depend on IImageStore
        public string ProductImage { get; private set; }
        public string ProductImageClass { get; private set; }

        [BindProperty] public int ProductId { get; set; }
        public Product Product { get; private set; }

        public DetailsModel(AssignedContentReadingContext dbContext)                                                                                                                                                                            // snp25 Initialize IImageStore
        {
            this.DbContext = dbContext;                                                                                                                                                                                                         // snp25 end
        }

        public async Task OnGet(int productId)
        {
            this.ProductId = productId;
            this.Product = this.DbContext.Find<Product>(productId);

            this.ProductImage = await Task.FromResult(string.Empty);                                                                                                                                                                            // snp26 Load image from the store
            this.ProductImageClass = this.ProductImage.Length == 0 ? "collapse" : string.Empty;
        }                                                                                                                                                                                                                                       // snp27 Implement the TryReadImage method
    }
}
