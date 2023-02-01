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

        public Paciente Adicionarpaciente(Paciente pacienteModel)
        {
            try
            {
                var retorno = _context.Pacientes.FirstOrDefault(X => X.Cpf == pacienteModel.Cpf);
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

        public Paciente buscarPacientePorNome(string nome)
        {
            try
            {
                var paciente = _context.Pacientes.FirstOrDefault(x => x.Nome == nome);

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
