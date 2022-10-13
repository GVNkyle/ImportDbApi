using ImportDbApi._Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ImportDbApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IService _service;

        public MainController(IService service)
        {
            _service = service;
        }

        [HttpPost("UploadExcel")]
        public async Task<IActionResult> UploadExcel(IFormFile file)
        {
            var result = await _service.UploadExcel(file);
            return Ok(result);
        }
    }
}