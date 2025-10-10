using System.ComponentModel.DataAnnotations;

namespace ShouldDo.Contracts.Requests.Todo;

public struct CreateTodoRequest(string title)
{
    public required string Title { get; init; } = title;
    
    public string Description { get; set; } = string.Empty;
}