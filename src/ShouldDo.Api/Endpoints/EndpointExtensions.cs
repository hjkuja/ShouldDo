using ShouldDo.Api.Endpoints.Todo;

namespace ShouldDo.Api.Endpoints;

public static class EndpointExtensions
{
    internal static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapTodoEndpoints();
        return endpoints;
    }
}