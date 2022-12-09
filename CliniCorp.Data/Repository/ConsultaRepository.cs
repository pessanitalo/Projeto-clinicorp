using CliniCorp.Business.Interfaces;
using CliniCorp.Business.Models;
using CliniCorp.Data.Context;

namespace CliniCorp.Data.Repository
{
    public class ConsultaRepository : IRepository
    {
        private readonly DataContext _context;

        public ConsultaRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<consultaLista>> ListarTodos()
        {
            var query = from c in _context.Consultas
                        join m in _context.Medicos on c.Id equals m.Id
                        join p in _context.Pacientes on m.Id equals p.Id
                        select new consultaLista
                        {
                            Id = c.Id,
                            dataConsulta = c.dataConsulta,
                            DescricaoConsulta = c.DescricaoConsulta,
                            StatusConsulta = c.StatusConsulta,
                            Nome = m.Nome,
                            Especializacao = m.Especializacao,
                            NomePaciente = p.Nome
                        };

            List<consultaLista> lista = query.ToList();
            return lista;
        }
    }
}
