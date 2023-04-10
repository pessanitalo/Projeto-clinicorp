using CliniCorp.Business.Interfaces;
using CliniCorp.Business.Models;
using CliniCorp.Data.Context;
using Microsoft.EntityFrameworkCore;
using ProjetoDemo;

namespace CliniCorp.Data.Repository
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly DataContext _context;

        public MedicoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Medico> buscarMedicoPorNome(string nome)
        {
            var medico = await _context.Medicos.FirstAsync(x => x.Nome == nome);
            if (medico == null) throw new Exception("Médico não encontrado.");
            return medico;
        }

        public Medico buscarMedico(int id)
        {
            var medico = _context.Medicos.FirstOrDefault(x => x.Id == id);
            return medico;
        }

        public async Task<Medico> AdicionarMedico(Medico medicoModel)
        {

            var retMedico = await _context.Medicos.FirstOrDefaultAsync(X => X.Cpf == medicoModel.Cpf);
            if (retMedico != null) throw new Exception("Já existe médico cadastrado com esse cpf.");

            var medico = new Medico
            {
                Id = 0,
                Nome = medicoModel.Nome.ToLower(),
                Especializacao = medicoModel.Especializacao.ToLower(),
                Cpf = medicoModel.Cpf,
            };
            _context.Medicos.Add(medico);
            _context.SaveChanges();
            return medico;
        }

        public async Task<PageList<Medico>> ListarMedicos(PageParams pageParams)
        {
            IQueryable<Medico> query = _context.Medicos;

            return await PageList<Medico>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);

        }

        public IEnumerable<ListMedicoPaientes> ListarTodosPacientesdoMedico(int id)
        {
            var query = from c in _context.Consultas
                        join p in _context.Pacientes on c.Paciente.Id equals p.Id
                        where c.Medico.Id == id
                        select new ListMedicoPaientes
                        {
                            Id = p.Id,
                            Nome = p.Nome,
                            Cpf = p.Cpf,
                            DataNascimento = p.DataNascimento
                        };
            List<ListMedicoPaientes> lista = query.ToList();
            return lista;
        }

    }
}
