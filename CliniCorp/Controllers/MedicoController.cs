using CliniCorp.DataContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CliniCorp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly Context _context;

        public MedicoController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult get()
        {
            var ret = _context.Medicos.ToList();
            return Ok(ret);
        }
    }
}
