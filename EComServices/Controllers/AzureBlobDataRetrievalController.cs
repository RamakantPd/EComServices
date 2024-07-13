using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace EComServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentDto
    {
        public Stream? Content { get; set; }
        public string? Name { get; set; }
        public string? ContentType { get; set; }
    }
    public class BlobDto
    {
        public string? Name { get; set; }
        public string? FileUrl { get; set; }
        public string? ContentType { get; set; }
    }
    public interface IBlobService
    {
        Task<List<BlobDto>> GetBlobFiles();

        Task<ContentDto> GetBlobFile(string name);
    }
    public class AzureBlobDataRetrievalController : ControllerBase//, IBlobService
    {
        //private readonly string _blobConnectionString;
        private const string _blobContainerName="blobtest";

        public AzureBlobDataRetrievalController(IConfiguration configuration)
        {
           // _blobConnectionString = configuration.GetConnectionString("blobConnectionString");
        }
        //public async Task<List<BlobDto>> GetBlobFiles()
        //{
        //    var blobs = new List<BlobDto>();
        //    var container = new BlobContainerClient(_blobConnectionString, _blobContainerName);

        //    await foreach (var blob in container.GetBlobsAsync())
        //    {
        //        var blobDto = new BlobDto()
        //        {
        //            Name = blob.Name,
        //            FileUrl = container.Uri.AbsoluteUri + "/" + blob.Name,
        //            ContentType = blob.Properties.ContentType
        //        };
        //        blobs.Add(blobDto);
        //    }
        //    return blobs;
        //}

        //public async Task<ContentDto> GetBlobFile(string name)
        //{
        //    var container = new BlobContainerClient(_blobConnectionString, _blobContainer);
        //    var blob = container.GetBlobClient(name);

        //    if (await blob.ExistsAsync())
        //    {
        //        var a = await blob.DownloadAsync();
        //        var contentDto = new ContentDto()
        //        {
        //            Content = a.Value.Content,
        //            ContentType = a.Value.ContentType,
        //            Name = name
        //        };

        //        return contentDto;
        //    }

        //    return null;
        //}


    }
}
