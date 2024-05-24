using Microsoft.EntityFrameworkCore;
using ToDoListEF.Models;
namespace ToDoListEF.Data
{
    public class TodolistDbContext : DbContext

    {
		
		public TodolistDbContext()
		{
		}

		public  TodolistDbContext(DbContextOptions<TodolistDbContext> options) : base(options)
        {

        }

        public DbSet<TodoModel> Todos { get; set; }
    }

    
}
