using Error_Handling.Exceptions;
using Error_Handling.Middleware;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapGet("/", () => "Hello World!");

app.MapGet("/Exception", (context) => throw new CustomException("Sample Exception"));

app.Run();