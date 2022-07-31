using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using recipes_alexander_ccoa.Core.Models;
using recipes_alexander_ccoa.Core.Service;
using recipes_alexander_ccoa.Server.ExtensionMethods;
using recipes_alexander_ccoa.web.Reports;

namespace recipes_alexander_ccoa.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly crudService<Recetas> service;
        private readonly RecipesReport report;

        public RecipesController(crudService<Recetas> service, RecipesReport report )
        {
            this.service=service;
            this.report=report;
        }

        [HttpGet("list")]
        public IActionResult Get() =>
            Ok(service.GetUnique(x => x.Mezcla));

        [HttpGet]
        public IActionResult Get(DateTime fi, DateTime ff) =>
            Ok(service.Get(x => x.Fecha>=fi && x.Fecha<ff).GetResume());

        [HttpGet("{mezcla}/{fi}/{ff}")]
        public IActionResult Get(string mezcla, DateTime fi, DateTime ff) =>
            Ok(service.Get(x => x.Mezcla == mezcla && x.Fecha>=fi && x.Fecha<=ff).GetReport(fi,ff));

        [HttpGet("excel/{fi}/{ff}")]
        public FileResult Excel( DateTime fi, DateTime ff) =>
            File(
                report
                .Reports(
                service
                .Get(x => x.Fecha>=fi && x.Fecha<ff)
                .GetResume())
                , "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "Reporte Recetas.xlsx"
               );

            

           
        
    }
}
