using Demo.Models.Content;
using System.Drawing;
using System.Threading.Tasks;

namespace Demo.Models.Images
{
    public interface IImageStore                                                                                                                                                                                                                // snp18 Image store interface is abstracting storage away
    {
        Task WriteAsync(Image image, ProductRef product);
        Task<Image> TryReadAsync(ProductRef product);
        Task RemoveAsync(ProductRef product);
    }
}
