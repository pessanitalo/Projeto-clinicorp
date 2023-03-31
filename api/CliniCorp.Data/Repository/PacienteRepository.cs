using CliniCorp.Business.Interfaces;
using CliniCorp.Business.Models;
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

        public async Task<Paciente> Adicionarpaciente(Paciente pacienteModel)
        {
            try
            {
                var retPaciente = await _context.Pacientes.FirstOrDefaultAsync(X => X.Cpf == pacienteModel.Cpf);
                if (retPaciente != null) throw new Exception("Já existe médico cadastrado com esse cpf.");

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

        public async Task<PageList<Paciente>> ListarPacientes(PageParams pageParams)
        {
            IQueryable<Paciente> query =  _context.Pacientes;

            return await PageList<Paciente>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);

        }

    }
}
