using LanguageExt.Common;
using ShouldDo.Contracts.Requests.Todo;

namespace ShouldDo.Application.Services.Interfaces;

public interface ITodoService
{
    /// <summary>
    /// Creates a new to do item and returns its unique identifier.
    /// </summary>
    /// <param name="request">A <see cref="CreateTodoRequest"/> object.</param>
    /// <returns></returns>
    Task<Result<Guid>> CreateTodoAsync(CreateTodoRequest request);
    
}