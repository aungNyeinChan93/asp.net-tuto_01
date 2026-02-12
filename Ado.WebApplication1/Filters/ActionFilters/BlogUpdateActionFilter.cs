using Ado.WebApplication1.DataModels;
using Ado.WebApplication1.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Ado.WebApplication1.Filters.ActionFilters
{
    public class BlogUpdateActionFilter :ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            int? id = context.ActionArguments["id"] as int?;
            var blog = context.ActionArguments["blog"] as BlogDataModel;

            if(!id.HasValue && blog is null)
            {
                context.ModelState.AddModelError("Update Blog", "Update Fail");
                context.Result = new BadRequestObjectResult(new ValidationProblemDetails(context.ModelState) { Status = 400});
            }

            if(id <= 0)
            {
                context.ModelState.AddModelError("Update Blog", "Update Fail");
                context.Result = new BadRequestObjectResult(new ValidationProblemDetails(context.ModelState) { Status = 400 });
            }


        }
    }
}
