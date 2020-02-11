using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;



namespace TestManagement1.Validation_Filter
{
    public class ModelStateValidationFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {

            if (!actionContext.ModelState.IsValid)
            {
                actionContext.Result = new BadRequestObjectResult(actionContext.ModelState);
                actionContext.Result = new BadRequestObjectResult(HttpStatusCode.OK);
            }
        }

        //public  void OnActionExecuting(HttpActionContext actionContext)
        //{
        //    var modelState = actionContext.ModelState;

        //    if (!modelState.IsValid)
        //    {
        //        actionContext.Response = actionContext.Request
        //             .CreateErrorResponse(HttpStatusCode.BadRequest, modelState);
        //    }
        //}
        //public override void OnException(HttpActionExecutedContext context)
        //{
        //    var exception = context.Exception as ApiException;
        //    if (exception != null)
        //    {
        //        context.Response = context.Request.CreateErrorResponse(exception.StatusCode, exception.Message);
        //    }
        //}



    }
}

