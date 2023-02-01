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
        private readonly IConsultaRepository _consultarepository;
        private readonly IMapper _mapper;

        public ConsultaController(IConsultaRepository consultarepository, IMapper mapper)
        {
            _consultarepository = consultarepository;
            _mapper = mapper;
        }

        [HttpGet("list")]
        public async Task<IEnumerable<ListConsultaViewModel>> obterLista()
        {
            return _mapper.Map<IEnumerable<ListConsultaViewModel>>(await _consultarepository.ListarTodos());
        }

        [HttpPost("created")]
        public IActionResult create(CreateConsultaViewModel consultaModel)
        {
            try
            {
                var consulta = _mapper.Map<Consulta>(consultaModel);
                _consultarepository.AdicionarDemo(consulta);
                return Ok(consulta);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }

        }

        [HttpPost("testeNovo")]
        public IActionResult novo(Consulta consulta, int pacienteId, int medicoId)
        {
            try
            {
                _consultarepository.Adicionar(consulta, pacienteId, medicoId);
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
            var consulta = _mapper.Map<DetalhesConsultaViewModel>(_consultarepository.Detalhes(id));
            if (consulta == null) return BadRequest("consulta não existente");

            return Ok(consulta);
        }

        [HttpPut("cancel")]
        public IActionResult updateStatus(Consulta consulta)
        {
            var query = _consultarepository.AtualizarStatus(consulta.Id);

            if (query == null) return BadRequest("consulta não existente");

            _consultarepository.AtualizarStatus(consulta);

            return Ok(consulta);

        }

        [HttpPut("updatedate")]
        public IActionResult updatedate(Consulta consulta)
        {
            var query = _consultarepository.Detalhes(consulta.Id);

            if (query == null) return BadRequest("consulta não existente");

            _consultarepository.AtualizarDataConsulta(consulta);

            return Ok(consulta);
        }

    }
}
