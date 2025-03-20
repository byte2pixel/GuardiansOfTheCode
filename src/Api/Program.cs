using Api.Services;
using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddFastEndpoints().SwaggerDocument();
builder.Services.AddTransient<ICardService, CardService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseFastEndpoints();
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerGen();
}

await app.RunAsync();
