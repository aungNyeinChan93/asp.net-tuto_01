using Dapper.WebApplication1.DataModels;
using Dapper.WebApplication1.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dapper.WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllBlogs()
        {
            var blogs = BlogRepo.AllBlogs();
            return blogs is not null ? Ok(new { message = "success", blogs }) : BadRequest("Blogs not found!");
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute]int? id)
        {
            var blog = BlogRepo.GetOne(id);
            return blog is null ? NotFound() : Ok(blog);
        }

        [HttpPost]
        public IActionResult CreateBLog([FromBody]BlogDataModel blog)
        {
            var result = BlogRepo.Create(blog);
            return result ? NoContent(): BadRequest("Create Fail");
        }

        [HttpGet]
        [Route("/api/blogs/test")]
        public IActionResult Test()
        {
            return Ok("test");
        }

        [HttpPut("{id:int}")]
        public IActionResult DeleteBLog([FromRoute]int id, [FromBody]BlogDataModel blog)
        {
            var result = BlogRepo.Update(id, blog);
            return result ? Ok("Update success") : BadRequest("Update Fail");
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteBLog([FromRoute]int? id)
        {
            var res = BlogRepo.Delete(id);
            return res ? NoContent() : BadRequest("Delete Fail");
        }
    }
}
