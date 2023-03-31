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
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteRepository _Pacienterepository;
        private readonly IMapper _mapper;


        //localhost:60684/api/paciente/listarPacientes *postman
        //http://localhost:60684/swagger/index.html
        public PacienteController(IPacienteRepository pacienterepository, IMapper mapper)
        {
            _Pacienterepository = pacienterepository;
            _mapper = mapper;
        }

        [HttpGet("listarPacientes")]
        public async Task<IEnumerable<Paciente>> lista([FromQuery] PageParams pageParams)
        {
            return await _Pacienterepository.ListarPacientes(pageParams);
        }

        [HttpPost]
        public async Task<IActionResult> create(PacienteViewModel pacienteViewModel)
        {
            try
            {
                var paciente = _mapper.Map<Paciente>(pacienteViewModel);
                await _Pacienterepository.Adicionarpaciente(paciente);
                return Ok(paciente);
            }
            catch (Exception ex)
            {

                return StatusCode(400, ex.Message);
            }
        }

        [HttpGet("pesquisarpaciente/{nome}/{cpf}")]
        public async Task<IActionResult> pesquisarpaciente(string nome, string cpf)
        {
            try
            {
                var paciente = await _Pacienterepository.buscarPacientePorNome(nome,cpf);
                return Ok(paciente);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }

        }
    }
}
