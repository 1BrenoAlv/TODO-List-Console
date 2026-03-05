
using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using TaskSuppy.Entities;

namespace TaskSuppy.Db
{
     public class AppDbContext : DbContext
    {
        private string connectionString = ConexaoDb.connection;

        public DbSet<Tarefa> Tarefa { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
