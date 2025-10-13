using Microsoft.AspNetCore.Http.HttpResults;
using ShouldDo.Application.Services.Interfaces;
using ShouldDo.Contracts.Requests.Todo;

namespace ShouldDo.Api.Endpoints.Todo;

public static class TodoEndpoints
{
    private const string BasePath = "api/todos";

    public static void MapTodoEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup(BasePath);
        
        group.MapPost(string.Empty, CreateTodo).WithName(nameof(CreateTodo)).WithDescription("Creates a new to do item.");
    }
    
    private static async Task<IResult> CreateTodo(CreateTodoRequest request, ITodoService todoService)
    {
        var todoResult = await todoService.CreateTodoAsync(request);

        return todoResult.Match(
            guid => TypedResults.Created(BasePath, guid),
            exception => exception.ToProblemResult());
    }
}