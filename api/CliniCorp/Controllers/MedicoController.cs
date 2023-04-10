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
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoRepository _medicorepository;
        private readonly IMapper _mapper;

        public MedicoController(IMedicoRepository medicorepository, IMapper mapper)
        {
            _medicorepository = medicorepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> create(CreateMedicoViewModel medicoViewModel)
        {
            try
            {
                var medico = _mapper.Map<Medico>(medicoViewModel);
                await _medicorepository.AdicionarMedico(medico);
                return Ok(medico);
            }
            catch (Exception ex)
            {

                return StatusCode(400, ex.Message);
            }
        }

        [HttpGet("list")]
        public async Task<IEnumerable<Medico>> obterLista([FromQuery] PageParams pageParams)
        {
            return await _medicorepository.ListarMedicos(pageParams);
        }

        [HttpGet("pesquisarMedico/{id:int}")]
        public IActionResult pesquisarmedico(int id)
        {
            var medico = _medicorepository.buscarMedico(id);
            if (medico == null) return NotFound("Médico não encontrado.");
            return Ok(medico);
        }

        [HttpGet("buscarmediconome/{nome}")]
        public async Task<IActionResult> detalhes(string nome)
        {
            try
            {
                var busca = await _medicorepository.buscarMedicoPorNome(nome);
                if (busca == null) return NotFound("Médico não encontrado.");

                return Ok(busca);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }

        }

        [HttpGet("medicospacientes/{id:int}")]
        public IActionResult medicosPacintes(int id)
        {
            var busca = _medicorepository.ListarTodosPacientesdoMedico(id);
            if(busca == null) return NotFound("Não foram encontrados pacientes para esse médico.");

            return Ok(busca);

        }
    }
}
