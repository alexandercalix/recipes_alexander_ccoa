using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using recipes_alexander_ccoa.Core.Models;
using recipes_alexander_ccoa.Core.Service;
using recipes_alexander_ccoa.Server.ExtensionMethods;

namespace recipes_alexander_ccoa.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly crudService<Recetas> service;

        public RecipesController(crudService<Recetas> service)
        {
            this.service=service;
        }

        [HttpGet]
        public IActionResult Get(DateTime fi, DateTime ff) =>
            Ok(service.Get(x => x.Fecha>=fi && x.Fecha<ff).GetResume());
        
    }
}
