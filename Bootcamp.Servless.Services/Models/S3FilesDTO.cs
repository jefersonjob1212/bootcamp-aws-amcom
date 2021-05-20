using System;

namespace Bootcamp.Servless.Services.Models
{
    public class S3FilesDTO
    {
        public string ETag { get; set; }
        public string Key { get; set; }
        public DateTime LastModified { get; set; }
        public long Size { get; set; }
    }
}