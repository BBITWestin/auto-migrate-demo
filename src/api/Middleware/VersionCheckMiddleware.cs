namespace SimpleTodo.Api.Middleware
{
    public class VersionCheckMiddleware
    {
        private readonly RequestDelegate _next;
        // Hardcoded backend version, represented as an ETag
        private const string CurrentVersionETag = "1.0.0";

        public VersionCheckMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Headers.ContainsKey("If-Match"))
            {
                var incomingETag = context.Request.Headers["If-Match"].ToString();
                // Check if the incoming ETag (version) matches the current version
                if (!CurrentVersionETag.Equals(incomingETag))
                {
                    // If versions don't match, return a custom status code to prompt refresh
                    // Assuming 409 Conflict as the custom code for simplicity
                    context.Response.StatusCode = 409; // Conflict
                    await context.Response.WriteAsync("Version mismatch, please refresh.");
                    return; // Prevent further processing
                }
            }

            await _next(context);
        }
    }
}