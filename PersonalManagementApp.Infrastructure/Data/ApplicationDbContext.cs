using PersonalManagementApp.Infrastructure.Data.Models.Calendar;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonalManagementApp.Infrastructure.Data.Models.Notes;
using PersonalManagementApp.Infrastructure.Data.Models.TodoList;

namespace PersonalManagementApp.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Event> Events { get; set; }
    public DbSet<Todo> Todos { get; set; }
    public DbSet<Note> Notes { get; set; }
}
