using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;

namespace AzureEx.Service
{
    public class BlobStorageService : IBlobStorageService
    {
        private readonly IConfiguration _configuration;
        private string containerName = "attendeeimages";

        public BlobStorageService(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        private async Task<BlobContainerClient> GetBlobContainerClient()
        {
            try
            {
                BlobContainerClient blobContainerClient = new BlobContainerClient(_configuration["StorageConnectionString"], containerName);
                await blobContainerClient.CreateIfNotExistsAsync();

                return blobContainerClient;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> UploadBlob(IFormFile formFile, string imageName)
        {
            var blobName = $"{imageName}{Path.GetExtension(formFile.FileName)}";
            var container = await GetBlobContainerClient();

            using var memoryStream = new MemoryStream();

            formFile.CopyTo(memoryStream);
            memoryStream.Position = 0;
            var blob = container.GetBlobClient(imageName);
            //await blob.UploadAsync(content: memoryStream, overwrite: true); // with this line, it is uploading but while retriving it is giving error

            var client = await container.UploadBlobAsync(blobName, memoryStream);

            return blobName;


        }


        public async Task<string> GetBlobUrl(string imageName)
        {
            var container = await GetBlobContainerClient();
            
            if(imageName != null)
            {
                var blob = container.GetBlobClient(imageName);


                BlobSasBuilder blobSasBuilder = new BlobSasBuilder
                {

                    BlobContainerName = blob.BlobContainerName,
                    BlobName = blob.Name,
                    ExpiresOn = DateTime.UtcNow.AddMinutes(3),
                    Protocol = SasProtocol.Https,
                    Resource = "b"
                };


                blobSasBuilder.SetPermissions(BlobAccountSasPermissions.Read);

                return blob.GenerateSasUri(blobSasBuilder).ToString();

            }

            return string.Empty;
           

        }


        public async Task RemoveBlob(string imageName)
        {
            var container = await GetBlobContainerClient();
            var blob = container.GetBlobClient(imageName);
            await blob.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
        }


    }
}
