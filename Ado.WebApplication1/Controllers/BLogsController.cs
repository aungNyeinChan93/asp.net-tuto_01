using Ado.WebApplication1.DataModels;
using Ado.WebApplication1.Entities;
using Ado.WebApplication1.Filters.ActionFilters;
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

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute]int? id)
        { 
            var blog = BLogRepo.GetOne(id);
            return blog is not null ? Ok(blog) : BadRequest("Blog Not Found!");
        }

        [HttpPut("{id:int}")]
        [BlogUpdateActionFilter]
        public IActionResult UpdateBLog([FromRoute]int? id, [FromBody]BlogDataModel blog)
        {
            bool isUpdateSuccess = BLogRepo.Update(id, blog);
            return isUpdateSuccess ? Ok(blog) : BadRequest("Update Fail");
        }

        [HttpPatch("{id:int}")]
        public IActionResult UpdateOne([FromRoute]int? id, [FromBody]BlogDataModel blog)
        {
            bool res = BLogRepo.UpdateByPatch(id, blog);
            return res ? Ok("update success") : BadRequest(" update fail");
        }

        [HttpPost]
        public IActionResult CreateBlog([FromBody]BlogDataModel blog)
        {
            bool res = BLogRepo.Create(blog);
            return res ? Created() : BadRequest("Create Fail");
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteBLog([FromRoute]int? id)
        {
            var res = BLogRepo.Delete(id);
            return res ? NoContent() : BadRequest("delete blog fail");
        }
    }
}
