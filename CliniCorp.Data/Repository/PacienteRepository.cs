using CliniCorp.Business.Interfaces;
using CliniCorp.Data.Context;
using Microsoft.EntityFrameworkCore;
using ProjetoDemo;

namespace CliniCorp.Data.Repository
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly DataContext _context;

        public PacienteRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Paciente>> ListarPacientes()
        {
            return await _context.Pacientes.ToListAsync();

        }
    }
}
