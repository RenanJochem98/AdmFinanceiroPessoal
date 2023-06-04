using backend.Mdl;
using backend.Svc;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Funcionario> Funcionarios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            FuncionarioDbCreate(builder);
        }

        private void FuncionarioDbCreate(ModelBuilder funcModelMuider)
        {
            funcModelMuider.Entity<Funcionario>()
                .ToTable(f => f.HasComment("Tabela responsável por armazenar funcionarios da empresa."))
                .Property(f => f.VinculoEmpregaticio)
                    .HasColumnType("integer")
                    .HasComment("Tipo de ligação do funcionário com a empresa.");

            funcModelMuider.Entity<Funcionario>()
              .Property(f => f.Nome)
                  .HasMaxLength(100)
                  .HasComment("Tipo de ligação do funcionário com a empresa.");

            funcModelMuider.Entity<Funcionario>().HasKey(f => f.Id);
            funcModelMuider.Entity<Funcionario>().HasIndex(f => f.VinculoEmpregaticio);
        }
    }
}
