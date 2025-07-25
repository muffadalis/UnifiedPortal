//using Microsoft.Extensions.FileProviders;
//using RoutingGateway;

//var builder = WebApplication.CreateBuilder(args);
//var app = builder.Build();

//app.UseStaticFiles(); // Serve wwwroot

//// Serve SharedAssets folder statically
//app.UseStaticFiles(new StaticFileOptions
//{
//    FileProvider = new PhysicalFileProvider(
//        Path.Combine(builder.Environment.ContentRootPath, "SharedAssets")),
//    RequestPath = "/SharedAssets"
//});

//// Smart route middleware
//app.UseMiddleware<SmartRouteMiddleware>();

//// Fallback
//app.Run(async context =>
//{
//    await context.Response.WriteAsync($"Unhandled path: {context.Request.Path}");
//});

//app.Run();

using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add YARP services
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

//app.UseStaticFiles(new StaticFileOptions
//{
//    FileProvider = new PhysicalFileProvider(
//        Path.Combine(builder.Environment.ContentRootPath, "SharedAssets")),
//    RequestPath = "/SharedAssets"
//});


app.MapReverseProxy();

app.Run();


