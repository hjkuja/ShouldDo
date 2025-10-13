using LanguageExt.Common;
using ShouldDo.Application.Validators.Interfaces;
using ShouldDo.Contracts.Requests.Todo;

namespace ShouldDo.Application.Validators.Todo;

/// <summary>
/// Validates todo items.
/// </summary>
public class TodoValidator : IValidator<CreateTodoRequest>
{
    /// <summary>
    /// Validates that a todo create request can be converted to a valid database entity.
    /// </summary>
    /// <param name="item">The requested todo to add.</param>
    /// <returns>Array of <see cref="Error"/>.</returns>
    public Task<Error[]> ValidateAsync(CreateTodoRequest item)
    {
        List<Error> errors = [];

        // Error.Add(<string>) adds an "expected" error,
        // while Error.Add(<Exception>) adds an "unexpected" error.
        // These can be useful while handling the operation results.

        if (string.IsNullOrWhiteSpace(item.Title))
        {
            errors.Add("Title is required.");
        }
        else if (item.Title.Length > 100)
        {
            errors.Add("Title cannot be longer than 100 characters.");
        }
        
        return Task.FromResult<Error[]>([.. errors]);
    }
}