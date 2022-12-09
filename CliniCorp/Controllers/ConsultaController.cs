using CliniCorp.Business.Interfaces;
using CliniCorp.Business.Models;
using CliniCorp.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoDemo;


namespace CliniCorp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IRepository _repository;

        public ConsultaController(DataContext context, IRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        [HttpGet]
        [Route("list")]
        public async Task <IEnumerable<consultaLista>> get()
        {
            return await _repository.ListarTodos();
        }

        [HttpPost]
        [Route("created")]
        public IActionResult create(Consulta consulta)
        {
            _context.Consultas.Add(consulta);
            _context.SaveChanges();
            return Ok(consulta);

        }

        [HttpGet]
        [Route("queryid/{id}")]
        public IActionResult getqueryid(int id)
        {
            var ret1 = _context.Consultas.FirstOrDefault(X => X.Id == id);
            if (ret1 == null) return BadRequest("consulta não existente");

            return Ok(ret1);
        }

        [HttpPut]
        [Route("updatestatus")]
        public IActionResult updateStatus(Consulta consulta)
        {
            var query = _context.Consultas.FirstOrDefault(X => X.Id == consulta.Id);

            if (query == null) return BadRequest("consulta não existente");

            query.StatusConsulta = consulta.StatusConsulta;

            _context.Update(query);
            _context.SaveChanges();
            return Ok(query);
        }

        [HttpGet]
        [Route("detalhes/{id}")]
        public IActionResult detalhes(int id)
        {
            var consulta = _context.Consultas.Include(c => c.Medico)
                            .Include(p => p.Medico.Paciente).
                            FirstOrDefault(X => X.Id == id);

            if (consulta == null) return BadRequest("consulta não existente");
            return Ok(consulta);
        }

        [HttpPut]
        [Route("updatedate")]
        public IActionResult updatedate(Consulta consulta)
        {
            var query = _context.Consultas.FirstOrDefault(X => X.Id == consulta.Id);

            if (query == null) return BadRequest("consulta não existente");

            query.dataConsulta = consulta.dataConsulta;

            _context.Update(query);
            _context.SaveChanges();
            return Ok(query);
        }


    }
}
