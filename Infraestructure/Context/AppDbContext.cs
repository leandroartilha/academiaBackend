using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infraestructure.Context
{
    public class AppDbContext : DbContext
    {
        [STAThread]
        static void Main()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Plano> Planos { get; set; }
        public DbSet<FormaPagamento> FormaPagamento { get; set; }
        public DbSet<User> User { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

    }
}