using Microsoft.EntityFrameworkCore;
using task_app.Models;

namespace task_app.Context
{
    //create database session
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }
        
        //binding model to database
        public DbSet<Task> Tasks { get; set; }
    }
}