﻿using CliniCorp.Business.Interfaces;
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

            VerificarHorario(consulta.Medico.Id, consulta.DataConsulta);

            var paciente = await _context.Pacientes.FirstOrDefaultAsync(X => X.Id == consulta.Paciente.Id);
            var medico = await _context.Medicos.FirstOrDefaultAsync(X => X.Id == consulta.Medico.Id);
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

        public async Task<Consulta> Detalhes(int id)
        {
            var consulta = await _context.Consultas.Include(c => c.Medico)
                .Include(c => c.Paciente)
                .FirstOrDefaultAsync(X => X.Id == id);
            return consulta;
        }
        public Consulta CancelarConsulta(int id)
        {
            var query = BuscarporId(id);

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
        public Consulta BuscarporId(int id)
        {
            var ret = _context.Consultas.FirstOrDefault(X => X.Id == id);
            return ret;
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
