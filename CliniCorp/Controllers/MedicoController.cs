using AutoMapper;
using CliniCorp.Business.Interfaces;
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

        public MedicoController(IMedicoRepository repository, IMapper mapper)
        {
            _medicorepository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult create(CreateMedicoViewModel medicoViewModel)
        {
            try
            {
                var medico = _mapper.Map<Medico>(medicoViewModel);
                _medicorepository.AdicionarMedico(medico);
                return Ok(medico);
            }
            catch (Exception ex)
            {

                return StatusCode(400, ex.Message);
            }
        }

        [HttpGet("list")]
        public async Task<IEnumerable<Medico>> obterLista()
        {
            return await _medicorepository.ListarMedicos();
        }

        [HttpGet("pesquisarMedico/{id}")]
        public Medico pesquisarmedico(int id)
        {
            return _medicorepository.ListarTodosPacientesdoMedico(id);
        }

        [HttpGet("buscarmediconome/{nome}")]
        public IActionResult detalhes(string nome)
        {
            try
            {
                var busca = _medicorepository.buscarMedicoPorNome(nome);

                return Ok(busca);
            }
            catch (Exception ex)
            {

                return StatusCode(400, ex.Message);
            }

        }

    }
}
