using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShouldDo.Application.Database;
using ShouldDo.Application.Services;
using ShouldDo.Application.Services.Interfaces;
using ShouldDo.Application.Validators.Interfaces;
using ShouldDo.Application.Validators.Todo;
using ShouldDo.Contracts.Requests.Todo;

namespace ShouldDo.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<TodoContext>(options =>
            options.UseNpgsql(connectionString)
#if DEBUG
                .EnableSensitiveDataLogging()
#endif
            );
        return services;
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ITodoService, TodoService>();
        services.AddScoped<IValidator<CreateTodoRequest>, TodoValidator>();
        return services;
    }
}