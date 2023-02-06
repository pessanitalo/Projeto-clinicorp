using AutoMapper;
using CliniCorp.Business.Interfaces;
using CliniCorp.ViewModels;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> create(CreateConsultaViewModel consultaModel)
        {
            try
            {
                var consulta = _mapper.Map<Consulta>(consultaModel);
                await _consultarepository.Adicionar(consulta);
                return Ok(consulta);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }

        }

        [HttpGet("detalhes/{id}")]
        public async Task<IActionResult> detalhes(int id)
        {
            var consulta = _mapper.Map<DetalhesConsultaViewModel>(await _consultarepository.Detalhes(id));
            if (consulta == null) return BadRequest("consulta não existente");

            return Ok(consulta);
        }

        [HttpPut("cancel")]
        //testar
        public IActionResult updateStatus(CancelarConsultaViewModel consultaModel)
        {
            var query = _consultarepository.BuscarporId(consultaModel.Id);

            if (query == null) return BadRequest("consulta não existente");

            var consultaret = _mapper.Map<Consulta>(consultaModel);
            _consultarepository.CancelarConsulta(consultaret);

            return Ok(consultaret);

        }

        [HttpPut("updatedate/{id}")]
        //ok
        public IActionResult updatedate(RemarcarConsultaViewModel consultaModel, int id)
        {
            try
            {
                var busca = _consultarepository.BuscarporId(id);
         
                var consulta = _mapper.Map<Consulta>(consultaModel);

                _consultarepository.RemarcarConsulta(consulta, id);

                return Ok(consulta);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }

        }
    }
}
