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
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public PacienteController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("listarPacientes")]
        public async Task<IEnumerable<Paciente>> lista()
        {
            return await _repository.ListarPacientes();
        }
    }
}
