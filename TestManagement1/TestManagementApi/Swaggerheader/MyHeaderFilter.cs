using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestManagementApi.Swaggerheader
{
    public class MyHeaderFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (string.Equals(context.ApiDescription.HttpMethod,HttpMethod.Get.Method, StringComparison.InvariantCultureIgnoreCase))
            {
                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "my-default-header",
                    In = ParameterLocation.Header,
                    Required = false,
                    Example = new OpenApiString("my-default-header-value")
                });
            }
        }
    }
        
}
