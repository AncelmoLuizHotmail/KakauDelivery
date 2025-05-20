namespace KakauDelivery.API.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;
        private readonly IWebHostEnvironment _environment;
        public GlobalExceptionMiddleware(RequestDelegate next,
            ILogger<GlobalExceptionMiddleware> logger, 
            IWebHostEnvironment environment)
        {
            _next = next;
            _logger = logger;
            _environment = environment;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error: {Message}",ex.Message);

                var statusCode = ex switch
                {
                    ArgumentNullException => StatusCodes.Status400BadRequest,
                    ArgumentException => StatusCodes.Status400BadRequest,
                    InvalidOperationException => StatusCodes.Status400BadRequest,
                    KeyNotFoundException => StatusCodes.Status404NotFound,
                    _ => StatusCodes.Status500InternalServerError
                };

                context.Response.StatusCode = statusCode;
                context.Response.ContentType = "application/json";

                var isDevelopment = _environment.IsDevelopment();
                var details = isDevelopment ? ex.StackTrace : "";

                var errorResponse = new
                {
                    Type = "https://httpstatuses.com/" + statusCode,
                    Title = "Erro inesperado!",
                    Instance = context.Request.Path,
                    StatusCode = statusCode,
                    Detail = details
                };

                await context.Response.WriteAsJsonAsync(errorResponse);
            }
        }
    }
}
