using Database_01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using One.WebApplication1.Entities;

namespace One.WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetALlBLogs()
        {
            var blogs = BlogRepo.GetAll();
            return blogs is not null ? Ok(blogs) : BadRequest("Blog Not Found!");
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int? id)
        {
            if (BlogRepo.IsExist(id))
            {
                return Ok(BlogRepo.GetOne(id));
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult Create([FromBody]TblBlog blog)
        {
            bool res = BlogRepo.Create(blog);
            return !res ? BadRequest() : Ok(blog);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update([FromRoute]int? id , [FromBody]TblBlog blog)
        {
            var res = BlogRepo.update(id,blog);
            return res ? Ok(blog) : BadRequest();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute]int? id)
        {
            bool res = BlogRepo.Delete(id);
            return res ? Ok("Delete successs"): BadRequest();
        }

    }
}
