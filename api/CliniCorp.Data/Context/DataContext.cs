using CliniCorp.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using ProjetoDemo;

namespace CliniCorp.Data.Context
{
    public class DataContext : DbContext
    {
        //teste
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

            builder.ApplyConfiguration(new ConsultaMapping());
            builder.ApplyConfiguration(new MedicoMapping());
            builder.ApplyConfiguration(new PacienteMapping());

        }
    }
}
