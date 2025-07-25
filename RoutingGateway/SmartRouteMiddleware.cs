namespace RoutingGateway;


public class SmartRouteMiddleware
{
    private readonly RequestDelegate _next;
    private readonly Dictionary<string, string> _routeMappings;

    public SmartRouteMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;

        // Load the "Mappings" section from appsettings.json
        _routeMappings = configuration
            .GetSection("Mappings")
            .Get<Dictionary<string, string>>() ?? [];
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var path = context.Request.Path.Value?.ToLower() ?? "/";

        var match = _routeMappings
            .FirstOrDefault(m => path == m.Key || path.StartsWith(m.Key + "/"));

        if (match.Key != null)
        {
            if (match.Value == "webforms")
                context.Request.Path = new PathString("https://localhost:44388/" + path);
            else if (match.Value == "blazor")
                context.Request.Path = new PathString("/New" + path);
        }
        else
        {
            context.Request.Path = new PathString("https://localhost:44388/" + path); // Default fallback
        }

        await _next(context);
    }
}

