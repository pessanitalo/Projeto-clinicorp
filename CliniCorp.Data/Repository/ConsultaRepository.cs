using CliniCorp.Business.Interfaces;
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

        public async Task<IEnumerable<Consulta>> ListarTodos()
        {
            return await _context.Consultas.Include(c => c.Medico).Include(c => c.Paciente).ToListAsync();

        }
        public Consulta AtualizarStatus(int id)
        {
            var query =  _context.Consultas.First(X => X.Id == id);
            return query;
        }

        public Consulta Adicionar(Consulta consulta, int pacienteId, int medicoId)
        {
            var paciente = _context.Pacientes.FirstOrDefault(X => X.Id == pacienteId);
            var medico = buscarMedico(medicoId);

            if (medico == null) throw new Exception("Médico não encontrado.");

            try
            {
                var consultaNova = new Consulta
                {
                    Id = 0,
                    DescricaoConsulta = consulta.DescricaoConsulta.ToLower(),
                    DataConsulta = consulta.DataConsulta,
                    Status = 0,
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

        public async Task<Consulta> Adicionar(Consulta consulta)
        {
            var paciente = await _context.Pacientes.FirstOrDefaultAsync(X => X.Id == consulta.Paciente.Id);
            var medico = buscarMedico(consulta.Medico.Id);

            if (medico == null) throw new Exception("Médico não encontrado.");

            try
            {
                var consultaNova = new Consulta
                {
                    Id = 0,
                    DescricaoConsulta = consulta.DescricaoConsulta.ToLower(),
                    DataConsulta = consulta.DataConsulta,
                    Status = 0,
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

        public async  Task<Consulta> Detalhes(int id)
        {
            var consulta =await _context.Consultas.Include
                (c => c.Medico)
                .Include(c => c.Medico)
                .FirstAsync(X => X.Id == id);

            return consulta;
        }

        public Consulta AtualizarStatus(Consulta consulta)
        {
            var query = AtualizarStatus(consulta.Id);

            query.Status = 2;
            query.StatusConsulta = "Cancelada";

            _context.Update(query);
            _context.SaveChanges();
            return query;
        }

        public Consulta AtualizarDataConsulta(Consulta consulta)
        {
            var query = AtualizarStatus(consulta.Id);

            query.DataConsulta = consulta.DataConsulta;
            query.Status = 1;
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


    }
}
