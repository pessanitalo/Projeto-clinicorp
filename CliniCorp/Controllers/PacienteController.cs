using AutoMapper;
using CliniCorp.Business.Interfaces;
using CliniCorp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ProjetoDemo;

namespace CliniCorp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteRepository _Pacienterepository;
        private readonly IMapper _mapper;

        public PacienteController(IPacienteRepository repository, IMapper mapper)
        {
            _Pacienterepository = repository;
            _mapper = mapper;
        }

        [HttpGet("listarPacientes")]
        public async Task<IEnumerable<Paciente>> lista()
        {
            return await _Pacienterepository.ListarPacientes();
        }

        [HttpPost]
        public IActionResult create(PacienteViewModel pacienteViewModel)
        {
            try
            {
                var paciente = _mapper.Map<Paciente>(pacienteViewModel);
                _Pacienterepository.Adicionarpaciente(paciente);
                return Ok(paciente);
            }
            catch (Exception ex)
            {

                return StatusCode(400, ex.Message);
            }
        }

        [HttpGet("pesquisarpaciente/{nome}")]
        public IActionResult pesquisarpaciente(string nome)
        {
            try
            {
                var paciente = _Pacienterepository.buscarPacientePorNome(nome);
                return Ok(paciente);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }

        }
    }
}
