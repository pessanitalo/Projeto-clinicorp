using CliniCorp.DataContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CliniCorp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly Context _context;

        public PacienteController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult get()
        {
            var ret = _context.Pacientes.ToList();
            return Ok(ret);
        }
    }
}
