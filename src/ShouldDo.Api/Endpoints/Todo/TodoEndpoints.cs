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
    
    private static async Task<Results<Created<Guid>, BadRequest<string>>> CreateTodo(CreateTodoRequest request, ITodoService todoService)
    {
        var todoResult= await todoService.CreateTodoAsync(request);

        return todoResult.Match<Results<Created<Guid>, BadRequest<string>>>(
            guid => TypedResults.Created(BasePath, guid), 
            exception => TypedResults.BadRequest(exception.Message));
    }
}