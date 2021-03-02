using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPIWithASP_Net5.Business;
using RestAPIWithASP_Net5.Data.VO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIWithASP_Net5.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiversion}")]
    [ApiController]
    [Authorize("Bearer")]
    public class FileController : ControllerBase
    {
        private readonly IFileBusiness FileBusiness;

        public FileController(IFileBusiness fileBusiness)
        {
            FileBusiness = fileBusiness;
        }
        [HttpPost("uploadFile")]
        [ProducesResponseType((200), Type = typeof(List<FileDetailVO>))]
        [ProducesResponseType((204))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        [Produces("application/json")]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
        {
            var details = await FileBusiness.SaveFileToDisk(file);
            return Ok(details);
        }


        [HttpPost("uploadMultipleFiles")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Produces("application/json")]
        public async Task<IActionResult> UploadManyFiles([FromForm] List<IFormFile> files)
        {
            List<FileDetailVO> listFiles = await FileBusiness.SaveFilesToDisk(files);
            return new OkObjectResult(listFiles);
        }


        [HttpGet("downloadFiles/{fileName}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Produces("application/octet-stream")]
        public async Task<IActionResult> GetFile(string fileName)
        {
            byte[] buffer = FileBusiness.GetFile(fileName);
            if (true)
            {
                HttpContext.Response.ContentType = $"application/{Path.GetExtension(fileName).Replace(".", "")}";
                HttpContext.Response.Headers.Add("content-lenght", buffer.Length.ToString());
                await HttpContext.Response.Body.WriteAsync(buffer, 0, buffer.Length);
            }

            return new ContentResult();
        }

    }
}
