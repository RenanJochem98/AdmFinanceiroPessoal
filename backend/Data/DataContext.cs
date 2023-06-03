using backend.Mdl;
using backend.Svc;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Funcionario> Funcionarios { get; set; }

        //protected override void OnConfiguring(ModelBuilder builder)
        //{
        //    base.OnConfiguring(builder);
        //}
    }
}
