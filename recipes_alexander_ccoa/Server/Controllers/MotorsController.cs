using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using recipes_alexander_ccoa.Core.Models;
using recipes_alexander_ccoa.Core.Service;
using recipes_alexander_ccoa.Server.ExtensionMethods;
    
namespace recipes_alexander_ccoa.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotorsController : ControllerBase
    {
        private readonly crudService<Motores> service;

        public MotorsController(crudService<Motores> service)
        {
            this.service=service;
        }

        [HttpGet]
        public IActionResult Get() =>
            Ok(service.GetUnique(x => x.NoMotor));


        [HttpGet("{noMotor?}/{fi}/{ff}")]
        [HttpGet("{fi}/{ff}")]
        public IActionResult Get(string? noMotor , DateTime fi, DateTime ff) =>
            Ok(service.Get(x => ((noMotor != null && noMotor.Length>0) ? noMotor == x.NoMotor : true) && x.Fecha>= fi && x.Fecha<ff).ToList().GetReport());


    }
}
