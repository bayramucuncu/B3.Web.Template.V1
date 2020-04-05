using System;
using System.Collections.Generic;
using B3.Infrastructure.Exceptions;
using B3.WebApi.ApiConsistency;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace B3.WebApi.ApiFilters
{
    public class ApiExceptionHandleWrapperFilter : IExceptionFilter
    {
        private readonly ILogger<ApiExceptionHandleWrapperFilter> _logger;

        public ApiExceptionHandleWrapperFilter(ILogger<ApiExceptionHandleWrapperFilter> logger)
        {
            _logger = logger;
        }

        public async void OnException(ExceptionContext context)
        {
           // _logger.LogError(context.Exception, context.Exception?.InnerException?.Message);

            var errorMessage = context.Exception?.Message;
            var statusCode = GetStatusCode(context.Exception);

            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = statusCode;

#if DEBUG
            errorMessage = string.Concat(context.Exception?.Message,
                context.Exception?.StackTrace,
                context.Exception?.InnerException?.Message);
#endif

            var apiResponse = new ApiResponse(statusCode, errorMessage: errorMessage);

            var text = JsonConvert.SerializeObject(apiResponse);

            await context.HttpContext.Response.WriteAsync(text);
        }

        private static int GetStatusCode(Exception exception)
        {
            var dictionary = new Dictionary<Type, int>
            {
                { typeof(IApplicationServiceException), 400 },
                { typeof(IDomainException), 400 },
                { typeof(INotFountException), 404 },
                { typeof(IUnauthorizedException), 403 }
            };

            return dictionary.TryGetValue(exception.GetType(), out var value) ? value : 500;
        }
    }
}