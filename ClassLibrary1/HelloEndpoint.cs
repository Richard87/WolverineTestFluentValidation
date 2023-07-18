using FluentValidation;
using Microsoft.AspNetCore.Http;
using Wolverine.Http;

namespace Utility;

public record HelloEndpointCommand(string Name)
{
    
    public class NameValidator : AbstractValidator<HelloEndpointCommand>
    {
        public NameValidator()
        {
            RuleFor(x => x.Name).NotNull().MinimumLength(10);
        }
    }
};

public class HelloEndpoint
{
    [WolverinePost("/hello/name")]
    public static  async Task<IResult> Post(HelloEndpointCommand helloEndpointCommand)
    {
        return Results.Ok($"Hello {helloEndpointCommand.Name}");
    }
}