using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Two.WebApplication1.Models;
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

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute]int? id)
        {
            var blog = new BlogRepo().GetOne(id) as BlogDataModel;
            return blog is not null ? Ok(blog) : NotFound();
        }
    }

  
}
