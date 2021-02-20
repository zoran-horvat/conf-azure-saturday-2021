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
                                                                                                                                                                                                                                                // snp28 Inject IImageStore
        public InsertModel(FullOwnershipContentContext dbContext)
        {
            this.DbContext = dbContext;                                                                                                                                                                                                         // snp28 end
        }

        public async Task<IActionResult> OnPostAsync(int productId, IFormFile uploadImage)
        {
            await Task.CompletedTask;                                                                                                                                                                                                           // snp29 Implement functionality
            return RedirectToPage("/products/details", new { productId = productId });
        }
    }
}
