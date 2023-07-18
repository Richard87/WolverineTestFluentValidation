using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Oakton;
using Utility;
using Wolverine;
using Wolverine.FluentValidation;
using Wolverine.Http;
using Wolverine.Http.FluentValidation;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseWolverine(opts =>
{
    opts.UseFluentValidation();
    opts.Discovery.IncludeAssembly(typeof(HelloEndpointCommand).Assembly);
    opts.Discovery.IncludeAssembly(typeof(HelloEndpoint).Assembly);
});
builder.Host.ApplyOaktonExtensions();


var app = builder.Build();

app.MapGet("/hello", () => "Hello World!");

// Let's add in Wolverine HTTP endpoints to the routing tree
app.MapWolverineEndpoints(opts =>
{
    opts.UseFluentValidationProblemDetailMiddleware();
});

return await app.RunOaktonCommands(args);

// public record HelloEndpointCommand(string Name)
// {
//     public class NameValidator : AbstractValidator<HelloEndpointCommand>
//     {
//         public NameValidator()
//         {
//             RuleFor(x => x.Name).NotNull().MinimumLength(10);
//         }
//     }
// };
// public class HelloEndpoint
// {
//     
//     
//     
//     [WolverinePost("/hello/name")]
//     public static  async Task<IResult> Post(HelloEndpointCommand helloEndpointCommand)
//     {
//         return Results.Ok($"Hello {helloEndpointCommand.Name}");
//     }
// }