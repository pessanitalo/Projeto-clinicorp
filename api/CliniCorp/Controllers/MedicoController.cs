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

        [HttpGet("list")]
        public async Task<IActionResult> obterLista([FromQuery] PageParams pageParams)
        {
            try
            {
                var obterLista = await _medicorepository.ListarMedicos(pageParams);
                return Ok(obterLista);
            }
            catch { return StatusCode(500, "Falha interna no servidor."); }
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
            catch { return StatusCode(500, "Falha interna no servidor."); }
        }

        [HttpGet("pesquisarMedico/{id:int}")]
        public IActionResult pesquisarmedico(int id)
        {
            try
            {
                var medico = _medicorepository.buscarMedico(id);
                if (medico == null) return NotFound(new ResultViewModel<MedicoViewModel>("Medico não encontrado."));
                return Ok(medico);
            }
            catch { return StatusCode(500, "Falha interna no servidor."); }
        }

        [HttpGet("buscarmediconome/{nome}")]
        public async Task<IActionResult> detalhes(string nome)
        {
            try
            {
                var busca = await _medicorepository.buscarMedicoPorNome(nome);
                if (busca == null) return NotFound(new ResultViewModel<MedicoViewModel>("Medico não encontrado."));

                return Ok(busca);
            }
            catch { return StatusCode(500, "Falha interna no servidor."); }

        }

        [HttpGet("medicospacientes/{id:int}")]
        public IActionResult medicosPacintes(int id)
        {
            try
            {
                List<ListMedicoPaientes> busca = (List<ListMedicoPaientes>)_medicorepository.ListarTodosPacientesdoMedico(id);
                if (busca.Count <= 0) return NotFound(new ResultViewModel<MedicoViewModel>("paciente não encontrado."));

                return Ok(busca);
            }
            catch { return StatusCode(500, "Falha interna no servidor."); }

        }
    }
}
