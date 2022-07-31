using ClosedXML.Excel;
using recipes_alexander_ccoa.Shared.DTO;

namespace recipes_alexander_ccoa.web.Reports
{
    public class MaintenanceReport
    {

        readonly string[] MOTOR_STATUS = new string[] { "Paro","Trabajando","Sobrecarga", "Protección Desactivada" };

        public byte[] Reports(IEnumerable<MotorDTO> data)
        {
            var wb = new XLWorkbook();
            IXLWorksheet ws = wb.Worksheets.Add("Reporte");

            ws.Range(1, 1, 2, 4).Merge()
                .SetValue("Reporte Motores")
                .Style
                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                .Font.SetBold(true)
                .Font.SetFontSize(15);

            ws.Cell(3, 1).Value = "No Motor";
            ws.Cell(3, 2).Value = "Inicio";
            ws.Cell(3, 3).Value = "Fin";
            ws.Cell(3, 4).Value = "Estado";


            foreach (var (status,index) in data.Select((status,index)=>(status,index)).ToList() )
            {
                ws.Cell(index+4, 1).Value = status.noMotor;
                ws.Cell(index+4, 2).Value = status.start.ToString("g");
                ws.Cell(index+4, 3).Value = status.end.ToString("g");
                ws.Cell(index+4, 4).Value = MOTOR_STATUS[status.status];
            }

            ws.Columns().AdjustToContents();

            using (MemoryStream stream = new MemoryStream())
            {
                wb.SaveAs(stream);
                string name = "Estado Motores";
                return stream.ToArray();
            }

        }

    }
}
