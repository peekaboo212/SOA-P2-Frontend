using Domain.Entities;
using Domain.Request;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;

namespace SOA_P2_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Activo_EmployeeController : Controller
    {
        private readonly IActivo_Employee _activo_Employee;

        public Activo_EmployeeController(IActivo_Employee activo_Employee)
        {
            _activo_Employee = activo_Employee;
        }
        [HttpGet]
        [Route("undelivery")]
        public ActionResult GetAll()
        {
            return Ok(_activo_Employee.GetAllUndelivered());
        }
        [HttpPost]
        public IActionResult Index([FromBody] RequestPostAssignActivo assignActivo)
        {
            return Ok(_activo_Employee.AssignActivo(assignActivo));
        }
        [HttpPatch]
        public IActionResult Update(RequestPatchDeliveryActivo deliveryActivo)
        {
            return Ok(_activo_Employee.DeliveryActivo(deliveryActivo));
        }
    }
}
