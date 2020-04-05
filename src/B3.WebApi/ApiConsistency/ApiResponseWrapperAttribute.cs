using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace B3.WebApi.ApiConsistency
{
    public class ApiResponseWrapperAttribute : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            ApiResponse apiResponse;

            switch (context.Result)
            {
                case BadRequestObjectResult result:
                    apiResponse = new ApiResponse((int)HttpStatusCode.BadRequest, errorMessage: $"Model validation error: {result.Value}");
                    break;
                case OkObjectResult json:
                    apiResponse = new ApiResponse(context.HttpContext.Response.StatusCode, json.Value);
                    break;
                case ObjectResult json:
                    apiResponse = new ApiResponse(context.HttpContext.Response.StatusCode, json.Value);
                    break;
                default:
                    apiResponse = new ApiResponse((int)HttpStatusCode.InternalServerError, errorMessage: "Unknown error");
                    break;
            }

            var text = JsonConvert.SerializeObject(apiResponse);

            context.HttpContext.Response.ContentType = "application/json";

            await context.HttpContext.Response.WriteAsync(text);
        }
    }
}