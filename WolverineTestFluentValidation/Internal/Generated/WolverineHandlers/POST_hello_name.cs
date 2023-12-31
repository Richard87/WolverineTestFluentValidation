// <auto-generated/>
#pragma warning disable
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using Wolverine.Http;

namespace Internal.Generated.WolverineHandlers
{
    // START: POST_hello_name
    public class POST_hello_name : Wolverine.Http.HttpHandler
    {
        private readonly Wolverine.Http.WolverineHttpOptions _wolverineHttpOptions;

        public POST_hello_name(Wolverine.Http.WolverineHttpOptions wolverineHttpOptions) : base(wolverineHttpOptions)
        {
            _wolverineHttpOptions = wolverineHttpOptions;
        }



        public override async System.Threading.Tasks.Task Handle(Microsoft.AspNetCore.Http.HttpContext httpContext)
        {
            var (helloEndpointCommand, jsonContinue) = await ReadJsonAsync<Utility.HelloEndpointCommand>(httpContext);
            if (jsonContinue == Wolverine.HandlerContinuation.Stop) return;
            var result = await Utility.HelloEndpoint.Post(helloEndpointCommand).ConfigureAwait(false);
            await result.ExecuteAsync(httpContext).ConfigureAwait(false);
        }

    }

    // END: POST_hello_name
    
    
}

