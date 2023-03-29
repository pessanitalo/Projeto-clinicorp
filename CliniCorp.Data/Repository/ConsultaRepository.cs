using CliniCorp.Business.Interfaces;
using CliniCorp.Business.Models;
using CliniCorp.Data.Context;
using Microsoft.EntityFrameworkCore;
using ProjetoDemo;

namespace CliniCorp.Data.Repository
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly DataContext _context;
        public ConsultaRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<PageList<Consulta>> ListarTodos(PageParams pageParams)
        {
            IQueryable<Consulta> query = _context.Consultas.Include(c => c.Medico).Include(c => c.Paciente);

            return await PageList<Consulta>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }
        public async Task<Consulta> Adicionar(Consulta consulta)
        {
            try
            {
                VerificarHorario(consulta.Medico.Id, consulta.DataConsulta);

                var paciente = await _context.Pacientes.FirstOrDefaultAsync(X => X.Id == consulta.Paciente.Id);
                var medico = buscarMedico(consulta.Medico.Id);

                if (medico == null) throw new Exception("Médico não encontrado.");

                var consultaNova = new Consulta
                {
                    Id = 0,
                    DescricaoConsulta = consulta.DescricaoConsulta.ToLower(),
                    DataConsulta = consulta.DataConsulta,
                    Status = (int)StatusConsulta.Agendada,
                    StatusConsulta = "Agendada",
                    Paciente = paciente,
                    Medico = medico
                };
                _context.Add(consultaNova);
                _context.SaveChanges();
                return consultaNova;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Consulta> Detalhes(int id)
        {
            var consulta = await _context.Consultas.Include(c => c.Medico)
                .Include(c => c.Paciente)
                .FirstAsync(X => X.Id == id);
            return consulta;
        }
        public Consulta CancelarConsulta(Consulta consulta)
        {
            var query = BuscarporId(consulta.Id);

            query.Status = (int)StatusConsulta.Cancelada;
            query.StatusConsulta = "Cancelada";

            _context.Update(query);
            _context.SaveChanges();
            return query;
        }
        public Consulta RemarcarConsulta(Consulta consulta, int id)
        {
            var query = BuscarporId(id);

            query.DataConsulta = consulta.DataConsulta;
            query.Status = (int)StatusConsulta.Reagendada;
            query.StatusConsulta = "Reagendada";

            _context.Update(query);
            _context.SaveChanges();
            return query;
        }
        public Medico buscarMedico(int id)
        {
            var medico = _context.Medicos.FirstOrDefault(x => x.Id == id);
            return medico;
        }
        public Consulta BuscarporId(int id)
        {
            try
            {
                var ret = _context.Consultas.First(X => X.Id == id);

                if (ret == null) throw new Exception("Consulta não encontrado.");

                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public bool VerificarHorario(int id, DateTime novaConsulta)
        {
            var query = _context.Consultas.Where(c => c.Medico.Id.Equals(id)).ToList();

            for (int i = 0; i < query.Count; i++)
            {
                foreach (var item in query)
                {
                    var dataAtual = item.DataConsulta.AddHours(1);

                    if (novaConsulta < dataAtual)
                    {
                        throw new Exception("Horário inválido.");
                    }
                }
            }

            return true;
        }
    }
}
