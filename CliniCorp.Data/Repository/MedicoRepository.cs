using CliniCorp.Business.Interfaces;
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
            try
            {
                var medico = await _context.Medicos.FirstAsync(x => x.Nome == nome);
                if (medico == null) throw new Exception("Médico não encontrado.");
                return  medico;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public async Task<Medico> AdicionarMedico(Medico medicoobj)
        {
            try
            {
                var retorno = await _context.Medicos.FirstAsync(X => X.Cpf == medicoobj.Cpf);
                if (retorno != null) throw new Exception("Já existe médico cadastrado com esse cpf.");

                var medico = new Medico
                {
                    Id = 0,
                    Nome = medicoobj.Nome.ToLower(),
                    Especializacao = medicoobj.Especializacao.ToLower(),
                    Cpf = medicoobj.Cpf,
                };
                _context.Medicos.Add(medico);
                _context.SaveChanges();
                return medico;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<IEnumerable<Medico>> ListarMedicos()
        {
            return await _context.Medicos.ToListAsync();
        }

        public Medico ListarTodosPacientesdoMedico(int id)
        {
            var medico = _context.Medicos.First(c => c.Id == id);
            return medico;
        }
    }
}
