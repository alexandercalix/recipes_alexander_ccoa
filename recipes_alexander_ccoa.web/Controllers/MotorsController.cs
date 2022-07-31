using DocumentFormat.OpenXml.Bibliography;
using Microsoft.AspNetCore.Mvc;
using recipes_alexander_ccoa.Core.Models;
using recipes_alexander_ccoa.Core.Service;
using recipes_alexander_ccoa.Server.ExtensionMethods;
using recipes_alexander_ccoa.web.Reports;

namespace recipes_alexander_ccoa.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotorsController : ControllerBase
    {
        private readonly crudService<Motores> service;
        private readonly MaintenanceReport report;
        public MotorsController(crudService<Motores> service, MaintenanceReport report)
        {
            this.service=service;
            this.report=report;
        }

        [HttpGet]
        public IActionResult Get() =>
            Ok(service.GetUnique(x => x.NoMotor));


        [HttpGet("{noMotor?}/{fi}/{ff}")]
        [HttpGet("{fi}/{ff}")]
        public IActionResult Get(string? noMotor, DateTime fi, DateTime ff) =>
            Ok(service.Get(x => ((noMotor != null && noMotor.Length>0) ? noMotor == x.NoMotor : true) && x.Fecha>= fi && x.Fecha<ff).ToList().GetReport());

        [HttpGet("rt")]
        public IActionResult GetLast() =>
            Ok(service.GetLast(x => x.NoMotor, x => x.OrderByDescending(x => x.Fecha).FirstOrDefault()));

        [HttpGet("excel/{noMotor?}/{fi}/{ff}")]
        [HttpGet("excel/{fi}/{ff}")]
        public FileResult Excel(string? noMotor, DateTime fi, DateTime ff) =>
          File(
            report
            .Reports(
                 service.Get(x => ((noMotor != null && noMotor.Length>0) ? noMotor == x.NoMotor : true) && x.Fecha>= fi && x.Fecha<ff).ToList().GetReport().history
            ),
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            "Reporte Motores.xlsx"
             );


    }
}
