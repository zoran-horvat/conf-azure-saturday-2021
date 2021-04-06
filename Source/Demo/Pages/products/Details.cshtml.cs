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
        private IImageStore ImageStore { get; }

        public string ProductImage { get; private set; }
        public string ProductImageClass { get; private set; }

        [BindProperty] public int ProductId { get; set; }
        public Product Product { get; private set; }

        public DetailsModel(AssignedContentReadingContext dbContext, IImageStore imageStore)
        {
            this.DbContext = dbContext;
            this.ImageStore = imageStore;
        }

        public async Task OnGet(int productId)
        {
            this.ProductId = productId;
            this.Product = this.DbContext.Find<Product>(productId);

            this.ProductImage = (await this.TryReadImage()).ToBase64String();
            this.ProductImageClass = this.ProductImage.Length == 0 ? "collapse" : string.Empty;
        }

        private async Task<Image> TryReadImage() =>
            this.Product is null ? null
            : await this.ImageStore.TryReadAsync(this.Product.Reference);
    }
}
