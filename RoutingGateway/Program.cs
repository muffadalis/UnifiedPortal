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


