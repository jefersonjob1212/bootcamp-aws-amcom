using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bootcamp.Servless.API.Config;
using Bootcamp.Servless.Services.Interfaces;
using Bootcamp.Servless.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.Servless.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FileController : Controller
    {
        private readonly IFilesService _filesService;
        private readonly AmazonWebServiceConfiguration _config;

        public FileController(IFilesService filesService, AmazonWebServiceConfiguration config)
        {
            _filesService = filesService;
            _config = config;
        }
        
        [HttpGet]
        public async Task<IEnumerable<S3FilesDTO>> findAllImages()
        {
            try
            {
                return await _filesService.ListAsync(_config.AccessKey, _config.SecretKey, _config.BucketName);
            }
            catch (Exception e)
            {
                throw new BadHttpRequestException(e.Message);
            }
        }
        
        [HttpGet("{directory}")]
        public async Task<IEnumerable<S3FilesDTO>> findImagesByDirectory(string directory, [FromQuery] string folder)
        {
            try
            {
                var fullPath = directory + "/" + folder;
                return await _filesService.ListAsync(_config.AccessKey, _config.SecretKey, _config.BucketName, fullPath);
            }
            catch (Exception e)
            {
                throw new BadHttpRequestException(e.Message);
            }
        }
    }
}