using Microsoft.EntityFrameworkCore;
using ShouldDo.Application.Database.Models;

namespace ShouldDo.Application.Database;

public class TodoContext(DbContextOptions<TodoContext> options) : DbContext(options)
{
    public DbSet<TodoItem> TodoItems { get; set; }
}