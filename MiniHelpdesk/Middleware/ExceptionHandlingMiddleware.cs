using System.Text;

namespace MiniHelpdesk.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(
        RequestDelegate next,
        ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "text/html; charset=utf-8";

            await context.Response.WriteAsync("""
                                              <!DOCTYPE html>
                                              <html lang="pl">
                                              <head>
                                                  <meta charset="utf-8">
                                                  <title>Błąd</title>
                                              </head>
                                              <body>
                                                  <h2>Wystąpił błąd aplikacji.</h2>
                                                  <p>Spróbuj ponownie później.</p>
                                              </body>
                                              </html>
                                              """, Encoding.UTF8);
        }
    }
}