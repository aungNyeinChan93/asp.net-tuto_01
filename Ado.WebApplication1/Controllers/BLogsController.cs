using Ado.WebApplication1.DataModels;
using Ado.WebApplication1.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ado.WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BLogsController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAllBLogs()
        {
            var blogs = BLogRepo.GetAll() as List<BlogDataModel>;
            return Ok(new {blogs});
        }
    }
}
