using AutoMapper;
using CliniCorp.Business.Interfaces;
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
        public async Task<IEnumerable<ListConsultaViewModel>> obterLista()
        {
            return _mapper.Map<IEnumerable<ListConsultaViewModel>>(await _repository.ListarTodos());
        }

        [HttpPost("created")]
        public IActionResult create(CreateConsultaViewModel consultaModel)
        {
            try
            {
                var consulta = _mapper.Map<Consulta>(consultaModel);
                _repository.Adicionar(consulta);
                return Ok(consulta);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }

        }

        [HttpGet("detalhes/{id}")]
        public IActionResult detalhes(int id)
        {
            var consulta = _mapper.Map<DetalhesConsultaViewModel>(_repository.Detalhes(id));
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
