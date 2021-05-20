using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.S3.Model;
using Bootcamp.Servless.Services.Models;

namespace Bootcamp.Servless.Services.Interfaces
{
    public interface IFilesService
    {
        Task<IEnumerable<S3FilesDTO>> ListAsync(string accessKey, 
            string secretKey, string bucketName, string fullPath = null);
    }
}