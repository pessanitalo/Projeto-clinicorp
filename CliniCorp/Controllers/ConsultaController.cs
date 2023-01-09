using AutoMapper;
using CliniCorp.Business.Interfaces;
using CliniCorp.Business.Models;
using CliniCorp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ProjetoDemo;


namespace CliniCorp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public ConsultaController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("list")]
        public async Task<IEnumerable<consultaLista>> get()
        {
            return await _repository.ListarTodos();
        }

        [HttpPost("created")]
        public IActionResult create(ConsultaViewModel consultaModel)
        {
            var consulta = _mapper.Map<Consulta>(consultaModel);
            _repository.Adicionar(consulta);
            return Ok(consulta);
        }

        [HttpGet("detalhes/{id}")]
        public IActionResult detalhes(int id)
        {
            var consulta = _repository.Detalhes(id);
            if (consulta == null) return BadRequest("consulta não existente");

            return Ok(consulta);
        }


        [HttpPut("updatestatus")]
        public IActionResult updateStatus(Consulta consulta)
        {
            var query = _repository.AtualizarStatus(consulta.Id);

            if (query == null) return BadRequest("consulta não existente");

            _repository.AtualizarStatus(consulta);

            return Ok(consulta);

        }

        [HttpPut("updatedate")]
        public IActionResult updatedate(Consulta consulta)
        {
            var query = _repository.Detalhes(consulta.Id);

            if (query == null) return BadRequest("consulta não existente");

            _repository.AtualizarDataConsulta(consulta);

            return Ok(consulta);
        }

    }
}
