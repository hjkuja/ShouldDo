using System.ComponentModel.DataAnnotations;
using LanguageExt.Common;
using ShouldDo.Application.Database;
using ShouldDo.Application.Database.Models;
using ShouldDo.Application.Services.Interfaces;
using ShouldDo.Application.Validators.Interfaces;
using ShouldDo.Contracts.Exceptions.ValidationExceptions;
using ShouldDo.Contracts.Requests.Todo;

namespace ShouldDo.Application.Services;

public class TodoService : ITodoService
{
    private readonly TodoContext _context;
    private readonly IValidator<CreateTodoRequest> _validator;
    
    public TodoService(TodoContext context, IValidator<CreateTodoRequest> validator)
    {
        _context = context;
        _validator = validator;
    }
    
    /// <inheritdoc />
    public async Task<Result<Guid>> CreateTodoAsync(CreateTodoRequest request)
    {
        var errors = await _validator.ValidateAsync(request);

        if (errors.Length != 0)
        {
            return new Result<Guid>(new TodoValidationException("Todo item validation failed.", errors));
        }
        
        var todoItem = new TodoItem
        {
            Title = request.Title,
            Description = request.Description
        };
        
        var entity = _context.TodoItems.Add(todoItem).Entity;
        await _context.SaveChangesAsync();
        
        return await Task.FromResult(entity.Id);
    }
}