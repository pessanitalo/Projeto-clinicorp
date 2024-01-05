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

            var retPaciente = await _context.Pacientes.FirstOrDefaultAsync(X => X.Cpf == pacienteModel.Cpf);
            if (retPaciente != null) throw new Exception("Já existe um paciente cadastrado com esse cpf.");

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

        public async Task<Paciente> buscarPacientePorNome(string cpf)
        {
            var paciente = await _context.Pacientes.FirstOrDefaultAsync(x => x.Cpf == cpf);
            return paciente;
        }

        public Paciente pesquisarPaciente(int id)
        {
            var paciente = _context.Pacientes.FirstOrDefault(x => x.Id == id);
            return paciente;
        }

        public async Task<PageList<Paciente>> ListarPacientes(PageParams pageParams)
        {
            IQueryable<Paciente> query = _context.Pacientes;

            return await PageList<Paciente>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);

        }

    }
}
