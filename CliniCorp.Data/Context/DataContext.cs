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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.ApplyConfiguration(new ConsultaMapping());
            modelBuilder.ApplyConfiguration(new MedicoMapping());
            modelBuilder.ApplyConfiguration(new PacienteMapping());

        }
    }
}
