using CliniCorp.Business.Interfaces;
using CliniCorp.Data.Context;
using Microsoft.CodeAnalysis.FlowAnalysis;
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

        public async Task<Paciente> Adicionarpaciente(Paciente pacienteModel)
        {
            try
            {
                var retorno = await _context.Pacientes.FirstOrDefaultAsync(X => X.Cpf == pacienteModel.Cpf);
                if (retorno != null) throw new Exception("Já existe médico cadastrado com esse cpf.");

                var paciente = new Paciente
                {
                    Id = 0,
                    Nome = pacienteModel.Nome.ToLower(),
                    Cpf = pacienteModel.Cpf,
                    DataNascimento = pacienteModel.DataNascimento,
                    Email = pacienteModel.Email,
                };
                _context.Pacientes.Add(paciente);
                _context.SaveChanges();
                return paciente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Paciente> buscarPacientePorNome(string nome, string cpf)
        {
            try
            {
                var paciente = await _context.Pacientes.FirstOrDefaultAsync(x => x.Nome == nome && x.Cpf == cpf);

                if (paciente == null) throw new Exception("Paciente não encontrado");

                return paciente;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
 
        }

        public async Task<IEnumerable<Paciente>> ListarPacientes()
        {
            return await _context.Pacientes.ToListAsync();

        }

    }
}
