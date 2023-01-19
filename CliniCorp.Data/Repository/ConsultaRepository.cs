using CliniCorp.Business.Interfaces;
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

        public async Task<IEnumerable<Consulta>> ListarTodos()
        {
            return await _context.Consultas.Include(c => c.Medico).Include(c => c.Medico.Pacientes).ToListAsync();

        }

        public async Task<IEnumerable<Consulta>> ListarDemo()
        {
            return await _context.Consultas.ToListAsync();
        }

        public Consulta AtualizarStatus(int id)
        {
            var query = _context.Consultas.FirstOrDefault(X => X.Id == id);
            return query;
        }

        public Consulta Adicionar(Consulta consulta)
        {
            var paciente = _context.Pacientes.FirstOrDefault(X => X.Cpf == consulta.Paciente.Cpf);
            var medico = buscarMedico(consulta.Paciente.MedicoId);

            if (medico == null) throw new Exception("Médico não encontrado.");

            try
            {
                if (paciente != null)
                {
                    var consul = new Consulta
                    {
                        Id = 0,
                        DescricaoConsulta = consulta.DescricaoConsulta.ToLower(),
                        dataConsulta = consulta.dataConsulta,
                        StatusConsulta = consulta.StatusConsulta,
                        Paciente = paciente,
                        Medico = medico
                    };
                    _context.Add(consul);
                    _context.SaveChanges();
                    return consul;
                }

                consulta.Medico = medico;
                _context.Add(consulta);
                _context.SaveChanges();
                return consulta;
            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public Consulta Detalhes(int id)
        {
            var consulta = _context.Consultas.Include
                (c => c.Medico)
                .Include(c => c.Medico.Pacientes)
                .First(X => X.Id == id);

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

        public Medico buscarMedico(int id)
        {
            var medico = _context.Medicos.FirstOrDefault(x => x.Id == id);
            return medico;
        }

        public Medico AdicionarMedico(Medico medicoobj)
        {
            try
            {
                var retorno = _context.Medicos.FirstOrDefault(X => X.Cpf == medicoobj.Cpf);
                if (retorno != null) throw new Exception("Já existe médico cadastrado com esse cpf.");

                var medico = new Medico
                {
                    Id = 0,
                    Nome = medicoobj.Nome.ToLower(),
                    Especializacao = medicoobj.Especializacao.ToLower(),
                    Crm = medicoobj.Crm,
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
    }
}
