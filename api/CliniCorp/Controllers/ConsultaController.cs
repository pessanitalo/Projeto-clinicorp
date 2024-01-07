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
        private readonly IConsultaRepository _consultarepository;
        private readonly IMapper _mapper;

        public ConsultaController(IConsultaRepository consultarepository, IMapper mapper)
        {
            _consultarepository = consultarepository;
            _mapper = mapper;
        }

        [HttpGet("list")]
        public async Task<IActionResult> obterLista([FromQuery] PageParams pageParams)
        {

            try
            {
                var lista = _mapper.Map<List<ListConsultaViewModel>>(await _consultarepository.ListarTodos(pageParams));
                return Ok(lista);
            }
            catch { return StatusCode(500, "Falha interna no servidor."); }

        }

        [HttpPost("created")]
        public async Task<IActionResult> create(CreateConsultaViewModel consultaModel)
        {
            try
            {
                var consulta = _mapper.Map<Consulta>(consultaModel);
                await _consultarepository.Adicionar(consulta);
                return Ok(consulta);
            }
            catch { return StatusCode(500, "Falha interna no servidor."); }

        }

        [HttpGet("detalhes/{id:int}")]
        public async Task<IActionResult> detalhes(int id)
        {
            try
            {
                var consulta = _mapper.Map<DetalhesConsultaViewModel>(await _consultarepository.Detalhes(id));
                if (consulta == null) return NotFound(new ResultViewModel<DetalhesConsultaViewModel>("Consulta não encontrada."));

                return Ok(consulta);
            }
            catch { return StatusCode(500, "Falha interna no servidor."); }
        }

        [HttpPut("cancel")]
        public IActionResult updateStatus(CancelarConsultaViewModel consultaModel)
        {
            try
            {
                var query = _consultarepository.BuscarporId(consultaModel.Id);

                if (query == null) return NotFound(new ResultViewModel<DetalhesConsultaViewModel>("Consulta não encontrada."));

                var consultaret = _consultarepository.CancelarConsulta(consultaModel.Id);

                return Ok(consultaret);
            }
            catch { return StatusCode(500, "Falha interna no servidor."); }

        }

        [HttpPut("updatedate")]
        public IActionResult updatedate(RemarcarConsultaViewModel consultaModel)
        {
            try
            {
                var busca = _consultarepository.BuscarporId(consultaModel.Id);
                if (busca == null) return NotFound(new ResultViewModel<DetalhesConsultaViewModel>("Consulta não encontrada.")); ;

                var consulta = _mapper.Map<Consulta>(consultaModel);

                _consultarepository.RemarcarConsulta(consulta, consultaModel.Id);

                return Ok(consulta);
            }
            catch { return StatusCode(500, "Falha interna no servidor."); }
        }
    }
}
