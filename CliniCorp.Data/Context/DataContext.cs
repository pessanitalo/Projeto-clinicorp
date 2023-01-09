using CliniCorp.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using ProjetoDemo;

namespace CliniCorp.Data.Context
{
    public class DataContext : DbContext
    {
        //Add-Migration nova-arquitetura -Context Context
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Medico> Medicos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //modelBuilder.ApplyConfiguration(new ConsultaMapping());
            //modelBuilder.ApplyConfiguration(new MedicoMapping());
            //modelBuilder.ApplyConfiguration(new PacienteMapping());


            //table consulta
            builder.Entity<Consulta>()
                .HasKey(e => e.Id);

            builder.Entity<Consulta>()
           .HasOne(c => c.Paciente);

            builder.Entity<Consulta>()
                .HasOne(c => c.Medico);

            builder.Entity<Consulta>(p =>
            {
                p.Property(b => b.StatusConsulta).HasColumnType("int");
                p.Property(b => b.DescricaoConsulta).HasColumnType("varchar(500)");
                p.Property(b => b.dataConsulta).HasColumnType("datetime");

            });

            //table medico

            builder.Entity<Medico>()
                .HasKey(e => e.Id);

            builder.Entity<Medico>()
                .HasOne(c => c.Paciente);

       
            builder.Entity<Medico>(p =>
            {
                p.Property(b => b.Nome).HasColumnType("varchar(50)");
                p.Property(b => b.Cpf).HasColumnType("varchar(11)");
                p.Property(b => b.Crm).HasColumnType("varchar(11)");
                p.Property(b => b.Especializacao).HasColumnType("varchar(50)");

            });



            //table paciente
            builder.Entity<Paciente>(p =>
            {
                p.Property(b => b.Nome).HasColumnType("varchar(50)");
                p.Property(b => b.Cpf).HasColumnType("varchar(11)");
                p.Property(b => b.Email).HasColumnType("varchar(50)");

            });
        }
    }
}
