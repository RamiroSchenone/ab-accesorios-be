using ab_accesorios_be.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace ab_accesorios_be.Controllers
{

    [ApiController]
    public class FilesController : ControllerBase
    {

        private readonly ArchivoAppService _appService;

        public FilesController(ArchivoAppService appService)
        {
            _appService = appService;
        }

        [HttpPost]
        [Route("upload-file")]
        public async Task<IActionResult> UploadFile(IFormFile file, CancellationToken cancellationtoken)
        {
            var newFileName = await _appService.WriteFile(file);
            var result = await _appService.SaveChanges(file, newFileName);

            return Ok(result);
        }

        [HttpGet]
        [Route("get-file")]
        public async Task<IActionResult> GetFile(string filename)
        {
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Resources\\filesUpload", filename);

            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filepath, out var contenttype))
            {
                contenttype = "application/octet-stream";
            }

            var bytes = await System.IO.File.ReadAllBytesAsync(filepath);
            return File(bytes, contenttype, Path.GetFileName(filepath));
        }

    }
}
