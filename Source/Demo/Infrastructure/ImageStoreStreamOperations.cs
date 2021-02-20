using Demo.Models.Content;
using Demo.Models.Images;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace Demo.Infrastructure
{
    public static class ImageStoreStreamOperations
    {
        public static async Task WriteAsync(this IImageStore imageStore, Func<Stream> streamFactory, Product product)
        {
            try
            {
                if (product is null) return;
                using Stream stream = streamFactory();
                if (stream is null) return;

                Image image = Image.FromStream(stream);
                await imageStore.WriteAsync(image, product.Reference);
            }
            catch
            {
            }
        }
    }
}
