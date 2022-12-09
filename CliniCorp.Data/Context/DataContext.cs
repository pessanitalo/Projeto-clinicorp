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
    }
}
