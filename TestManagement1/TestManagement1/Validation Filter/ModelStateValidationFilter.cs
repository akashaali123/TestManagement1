using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestManagement1.Validation_Filter
{
    public class ModelStateValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            if (!context.ModelState.IsValid)
            {
                List<string> list = (from modelState in context.ModelState.Values from error in modelState.Errors select error.ErrorMessage).ToList();

                //Also add exceptions.
                list.AddRange(from modelState in context.ModelState.Values from error in modelState.Errors select error.Exception.ToString());

                context.Result = new BadRequestObjectResult(list);


               
            }

            base.OnActionExecuting(context);
        }
    }
}
