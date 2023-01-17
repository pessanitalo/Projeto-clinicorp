using CliniCorp.Business.Interfaces;
using CliniCorp.Data.Context;
using Microsoft.EntityFrameworkCore;
using ProjetoDemo;
using System;
using static System.Net.Mime.MediaTypeNames;


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

            //var consul = new Consulta
            //{
            //    Id = 0,
            //    DescricaoConsulta = consulta.DescricaoConsulta,
            //    dataConsulta = consulta.dataConsulta,
            //    StatusConsulta = consulta.StatusConsulta,
            //};
            if (paciente != null)
            {
                var consul = new Consulta
                {
                    Id = 0,
                    DescricaoConsulta = consulta.DescricaoConsulta,
                    dataConsulta = consulta.dataConsulta,
                    StatusConsulta = consulta.StatusConsulta,
                    Paciente = paciente,
                    Medico = medico
                };
                //consulta.Medico = medico;
                //consulta.Paciente = paciente;
                _context.Add(consul);
                _context.SaveChanges();
                return consul;
            }

            consulta.Medico = medico;
            _context.Add(consulta);
            _context.SaveChanges();
            return consulta;

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

        public Medico AdicionarMedico(Medico medico)
        {
            _context.Medicos.Add(medico);
            _context.SaveChanges();
            return medico;
        }
    }
}
