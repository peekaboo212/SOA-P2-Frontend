using Domain.Request;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;

namespace SOA_P2_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActivoController : Controller
    {
        private readonly IActivo _activo;

        public ActivoController(IActivo activo)
        {
            _activo = activo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_activo.GetAll());
        }
        [HttpPost]
        public IActionResult Create([FromBody] RequestPostCreateActivo newActivo)
        {
            return Ok(_activo.AddActivo(newActivo));
        }
        [HttpPatch]
        public IActionResult Update(RequestPatchUpdateStatusActivo newStatus)
        {
            return Ok(_activo.UpdateStatusActivo(newStatus));
        }
    }
}
