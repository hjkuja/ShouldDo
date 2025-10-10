using LanguageExt.Common;
using ShouldDo.Application.Validators.Interfaces;
using ShouldDo.Contracts.Requests.Todo;

namespace ShouldDo.Application.Validators.Todo;

public class TodoValidator : IValidator<CreateTodoRequest>
{
    public Task<Error[]> ValidateAsync(CreateTodoRequest item)
    {
        List<Error> errors = [];
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