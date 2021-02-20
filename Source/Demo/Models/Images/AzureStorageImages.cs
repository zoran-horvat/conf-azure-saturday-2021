using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Demo.Models.Content;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;

namespace Demo.Models.Images
{
    public class AzureStorageImages : IImageStore                                                                                                                                                                                               // snp19 Azure storage client is specific implementation
    {
        private string ContainerName { get; }                                                                                                                                                                                                   // snp20 It requires container name and connection string to storage
        private string ConnectionString { get; }                                                                                                                                                                                                // snp20 end

        public AzureStorageImages(string containerName, string connectionString)                                                                                                                                                                // snp32 Now we need to inject these values from configuration
        {
            this.ContainerName = containerName;
            this.ConnectionString = connectionString;
        }

        public async Task WriteAsync(Image image, ProductRef product)
        {
            using Stream stream = this.Load(image);
            await (await this.OpenBlobClient(product)).UploadAsync(stream, true);
        }

        public async Task<Image> TryReadAsync(ProductRef product)
        {
            BlobClient blob = await this.OpenBlobClient(product);
            if (!(await blob.ExistsAsync()))
                return null;

            using BlobDownloadInfo download = await blob.DownloadAsync();
            try
            {
                return Image.FromStream(download.Content);
            }
            catch { }
            return null;
        }

        public async Task RemoveAsync(ProductRef product)
        {
            BlobClient blob = await this.OpenBlobClient(product);
            if ((await blob.ExistsAsync()))
            {
                await blob.DeleteAsync();
            }
        }

        private async Task<BlobClient> OpenBlobClient(ProductRef product) =>
            (await this.GetBlobContainer()).GetBlobClient(product.Value);

        private async Task<BlobContainerClient> GetBlobContainer()
        {
            BlobServiceClient service = this.GetBlobService();
            BlobContainerClient container = service.GetBlobContainerClient(this.ContainerName);                                                                                                                                                 // snp22 Container name is used to open a container
            if (!(await container.ExistsAsync()))
            {
                container = await service.CreateBlobContainerAsync(this.ContainerName);                                                                                                                                                         // snp23 If container doesn't exist, it will be created
            }
            return container;
        }

        private BlobServiceClient GetBlobService() =>
            new BlobServiceClient(this.ConnectionString);                                                                                                                                                                                       // snp21 Connection string is used to connect to BLOB service

        private Stream Load(Image image)
        {
            Stream stream = new MemoryStream();
            image.Save(stream, ImageFormat.Jpeg);
            stream.Position = 0;
            return stream;
        }
    }
}
