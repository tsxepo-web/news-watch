using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Middleware
{
    public class ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger = logger;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NewsArticleNotFoundException ex)
            {
                _logger.LogWarning(ex, "Resource not found");
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync(ex.Message);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Invalid argument.");
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Invalid request format.");
            }
            catch (ApplicationException ex)
            {
                _logger.LogWarning(ex, "An Application error occurred.");
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync("An unexpected error has occurred. Please try again later.");
            }
        }
        public class NewsArticleNotFoundException(string id) : Exception($"No news article found with id: {id}")
        {
        }
    }
}