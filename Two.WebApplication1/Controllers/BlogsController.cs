using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Two.WebApplication1.Repositories;

namespace Two.WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllBLogs()
        {
             var blogs = new BlogRepo().getALl();
            return blogs is not null ? Ok(blogs) : NotFound();
        }
    }
}
