using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Bootcamp.Servless.Services.Interfaces;
using Bootcamp.Servless.Services.Models;
using Bootcamp.Servless.Services.Utils;

namespace Bootcamp.Servless.Services.Implements
{
    public class FilesService : IFilesService
    {
        public async Task<IEnumerable<S3FilesDTO>> ListAsync(string accessKey, string secretKey,
            string bucketName, string fullPath = null)
        {
            try
            {
                var s3Client = new AmazonS3Client(accessKey, secretKey, RegionEndpoint.USEast1);
                var lista = await s3Client.ListObjectsAsync(bucketName, fullPath);
                return lista.S3Objects
                    .AsEnumerable()
                    .Where(x => x.Key.IsFile())
                    .Select(file => new S3FilesDTO
                    {
                        ETag = file.ETag,
                        LastModified = file.LastModified,
                        Key = file.Key,
                        Size = file.Size
                    });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}