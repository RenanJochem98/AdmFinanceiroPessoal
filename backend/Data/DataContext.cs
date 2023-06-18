using backend.Mdl;
using backend.Svc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class DataContext : IdentityDbContext<Usuario, IdentityRole<long>, long>
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(SvcAppSettings.GetConnectionString());
        }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<ContaBancaria> ContasBancarias { get; set; }
        public DbSet<ContaBancaria> ValoresContaBancaria { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            FuncionarioDbCreate(builder);
            ValoresContaBancariaDbCreate(builder);
            ContaBancariaDbCreate(builder);
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

        private void ValoresContaBancariaDbCreate(ModelBuilder modelMuider)
        {
            modelMuider.Entity<ValorContaBancaria>()
                .ToTable(c => c.HasComment("Tabela responsável por armazenar os valores de uma conta bancária ao longo do tempo."))
                .Property(c => c.Valor)
                    .HasComment("Valor contido na conta bancária.");

            modelMuider.Entity<ValorContaBancaria>()
              .Property(c => c.Data)
                  .HasComment("Data em que a conta continha o valor.");


            modelMuider.Entity<ValorContaBancaria>().HasKey(c => c.Id);
            modelMuider.Entity<ValorContaBancaria>().HasIndex(c => c.ContaBancariaId);
            //modelMuider.Entity<ValorContaBancaria>().Has(c => c.C.WithMany();
        }

        private void ContaBancariaDbCreate(ModelBuilder modelMuider)
        {
            modelMuider.Entity<ContaBancaria>()
                .ToTable(c => c.HasComment("Tabela responsável por armazenar as contas bancárias dos usuários."))
                .Property(c => c.Nome)
                    .HasMaxLength(250)
                    .HasComment("Nome da conta bancária.");

            //modelMuider.Entity<ContaBancaria>()
            //  .Property(c => c.ValoresConta)
            //      .HasComment("Valor contido na conta bancária .");


            modelMuider.Entity<ContaBancaria>().HasKey(c => c.Id);
            modelMuider.Entity<ContaBancaria>().HasIndex(c => c.IdUsuario);
            modelMuider.Entity<ContaBancaria>()
                .HasMany(c => c.ValoresConta);
        }
    }
}
