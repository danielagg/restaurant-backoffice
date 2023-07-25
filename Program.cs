var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvcCore().AddApiExplorer();
builder.Services.AddSwaggerDocument();

var app = builder.Build();

app.MapDefaultControllerRoute();

app.UseOpenApi();
app.UseSwaggerUi3();

app.MapGet("/", () => "Hello World!");

app.Run();
