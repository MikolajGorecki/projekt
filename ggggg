using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using System.Text;

namespace WebApiZapytania.Services
{
    public class PlikService
    {
        private readonly ShareClient _shareClient;

        public PlikService(IConfiguration config)
        {
            var connectionString = config["AzureFileShare:ConnectionString"];
            var shareName = config["AzureFileShare:ShareName"];

            _shareClient = new ShareClient(connectionString, shareName);
            _shareClient.CreateIfNotExists();
        }

        public async Task ZapiszDoPlikuAsync(string email, string zapytanie)
        {
            var directory = _shareClient.GetRootDirectoryClient();
            string fileName = $"zapytanie_{Guid.NewGuid():N}.txt";

            var fileClient = directory.GetFileClient(fileName);

            byte[] contentBytes = Encoding.UTF8.GetBytes($"Email: {email}\nZapytanie: {zapytanie}");
            using var stream = new MemoryStream(contentBytes);

            await fileClient.CreateAsync(stream.Length);
            await fileClient.UploadRangeAsync(new HttpRange(0, stream.Length), stream);
        }
    }
}
