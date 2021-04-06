using Demo.Models.Content;
using System.Drawing;
using System.Threading.Tasks;

namespace Demo.Models.Images
{
    public interface IImageStore
    {
        Task WriteAsync(Image image, ProductRef product);
        Task<Image> TryReadAsync(ProductRef product);
        Task RemoveAsync(ProductRef product);
    }
}
