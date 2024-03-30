using InfnetMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InfnetMVC.DAL
{
    public class InfnetDbContext : IdentityDbContext
    {
        public DbSet<Departamento> Funcionarios { get; set; }
        public DbSet<Funcionario> Departamentos { get; set; }

        public InfnetDbContext(DbContextOptions options) : base (options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Funcionario>().HasOne(m => m.Departamento).WithMany(m => m.Funcionarios).HasForeignKey(m => m.IdDepartamento);
        }
    }
}
