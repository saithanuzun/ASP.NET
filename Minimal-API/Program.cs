using Microsoft.AspNetCore.Mvc;
using Minimal_API;


var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

var mapGroup = app.MapGroup("/products");

mapGroup.MapGet("/{id:guid}", (HttpContext c,Guid? id) =>
{
    Results.Ok($"hello World {id}");
});

mapGroup.MapPut("/", (HttpContext context, [FromBody] Product product) =>
{
    Results.Ok($"name:{product.Name}");
});

mapGroup.MapDelete("/{id:int}", (HttpContext context,int id) =>
{
    Results.BadRequest($"{id}");
});

mapGroup.MapPost("/", (HttpContext context, [FromBody] Product product) =>
{
    Results.Ok($"name:{product.Name}");
}).AddEndpointFilter(async (context, next) =>
{
    //before logic here
    var result = await next(context);
    //after logic here
    return result;
}).AddEndpointFilter<CustomEndpointFilter>();

app.Run();

public record Product(int Id, string Name);

