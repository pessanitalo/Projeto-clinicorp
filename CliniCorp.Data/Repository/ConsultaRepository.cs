using CliniCorp.Business.Interfaces;
using CliniCorp.Business.Models;
using CliniCorp.Data.Context;
using Microsoft.EntityFrameworkCore;
using ProjetoDemo;

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

        public Consulta AtualizarStatus(int id)
        {
            var query = _context.Consultas.FirstOrDefault(X => X.Id == id);
            return query;
        }

        public Consulta Adicionar(Consulta consulta)
        {
            _context.Add(consulta);
            _context.SaveChanges();
            return consulta;
        }

        public Consulta Detalhes(int id)
        {
            var consulta = _context.Consultas.Include(c => c.Medico)
                            .Include(p => p.Medico.Paciente).
                            FirstOrDefault(X => X.Id == id);
            return consulta;
        }

        public Consulta AtualizarStatus(Consulta consulta)
        {
            var query = AtualizarStatus(consulta.Id);

            query.StatusConsulta = consulta.StatusConsulta;

            _context.Update(query);
            _context.SaveChanges();
            return query;
        }

        public Consulta AtualizarDataConsulta(Consulta consulta)
        {
            var query = AtualizarStatus(consulta.Id);

            query.dataConsulta = consulta.dataConsulta;

            _context.Update(query);
            _context.SaveChanges();
            return query;
        }
    }
}
