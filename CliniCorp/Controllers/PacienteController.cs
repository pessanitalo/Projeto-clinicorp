using AutoMapper;
using CliniCorp.Business.Interfaces;
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
    }
}
