using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Demo
{
    public static class ConfigurationExtensions
    {
        public static string DatabaseConectionString(
            this IConfiguration config, IWebHostEnvironment env) =>
            config.ConnectionStringsSetting("SecretsDemo",
                env.IsDevelopment() 
                    ? "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SecretsDemo" 
                    : string.Empty);

        public static string ImageStoreContainerName(
            this IConfiguration config, IWebHostEnvironment env) =>
            config.ImageStoreSetting("ContainerName", 
                env.IsDevelopment() ? "images" : string.Empty);

        public static string ImageStoreConnectionString(
            this IConfiguration config, IWebHostEnvironment env) =>
            env.IsDevelopment() ? config.AzuriteStorageConnectionString()
            : config.AzureStorageConnectionString();

        private static string AzuriteStorageConnectionString(this IConfiguration config) =>
            $"AccountName=devstoreaccount1;" +
            $"AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;" +
            $"DefaultEndpointsProtocol=http;" +
            $"BlobEndpoint=http://{config.AzuriteAddress()}/devstoreaccount1;";

        private static string AzuriteAddress(this IConfiguration config) =>
            config.ImageStoreSetting("AzuriteAddress", "127.0.0.1:10000");

        private static string AzureStorageConnectionString(this IConfiguration config) =>
            config.ImageStoreSetting("ConnectionString");

        private static string ImageStoreSetting(
            this IConfiguration config, string settingName, string defaultIfMissing = "") =>
            config.GetSection("ImageStore")[settingName] ?? defaultIfMissing;

        private static string ConnectionStringsSetting(
            this IConfiguration config, string settingName, string defaultIfMissing = "") =>
            config.GetSection("ConnectionStrings")[settingName] ?? defaultIfMissing;
    }
}
