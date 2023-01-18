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
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public MedicoController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult create(CreateMedicoViewModel medicoViewModel)
        {      

            var medico = _mapper.Map<Medico>(medicoViewModel);
            _repository.AdicionarMedico(medico);
            return Ok(medico);
        }
    }
}
