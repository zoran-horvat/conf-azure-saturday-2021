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
                                                                                                                                                                                                                                                // snp30 Inject dependency
        public DeleteModel(FullOwnershipContentContext dbContext)
        {
            this.DbContext = dbContext;                                                                                                                                                                                                         // snp30 end
        }

        public async Task<IActionResult> OnPostAsync(int productId)
        {
            await Task.CompletedTask;                                                                                                                                                                                                           // snp31 Implement functionality
            return RedirectToPage("/products/details", new { productId = productId });
        }
    }
}
