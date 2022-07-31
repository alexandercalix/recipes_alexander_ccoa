using ClosedXML.Excel;
using recipes_alexander_ccoa.Shared.DTO;

namespace recipes_alexander_ccoa.web.Reports
{
    public class RecipesReport
    {
        public byte[] Reports(IEnumerable<RecipesDTO> recipes)
        {
            var wb = new XLWorkbook();
            IXLWorksheet ws = wb.Worksheets.Add("Reporte");

            ws.Range("A1:R2").Merge()
                .SetValue("Reporte Recetas")
                .Style
                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                .Font.SetBold(true)
                .Font.SetFontSize(16);

            ws.Cell("A4").Value = "Nombre Mezcla";
            ws.Cell("B4").Value = "Fecha";

            ws.Range("C3:D3").Merge().Value = "Insumo 1";
            ws.Cell("C4").Value = "Nombre";
            ws.Cell("D4").Value = "Cantidad";

            ws.Range("E3:F3").Merge().Value = "Insumo 2";
            ws.Cell("E4").Value = "Nombre";
            ws.Cell("F4").Value = "Cantidad";

            ws.Range("G3:H3").Merge().Value = "Insumo 3";
            ws.Cell("G4").Value = "Nombre";
            ws.Cell("H4").Value = "Cantidad";

            ws.Range("I3:J3").Merge().Value = "Insumo 4";
            ws.Cell("I4").Value = "Nombre";
            ws.Cell("J4").Value = "Cantidad";

            ws.Range("K3:L3").Merge().Value = "Insumo 5";
            ws.Cell("K4").Value = "Nombre";
            ws.Cell("L4").Value = "Cantidad";

            ws.Range("M3:N3").Merge().Value = "Insumo 6";
            ws.Cell("M4").Value = "Nombre";
            ws.Cell("N4").Value = "Cantidad";

            ws.Range("O3:P3").Merge().Value = "Insumo 7";
            ws.Cell("O4").Value = "Nombre";
            ws.Cell("P4").Value = "Cantidad";

            ws.Range("Q3:R3").Merge().Value = "Insumo 8";
            ws.Cell("Q4").Value = "Nombre";
            ws.Cell("R4").Value = "Cantidad";



            foreach (var (recipe,index) in recipes.Select((recipe,index)=>(recipe,index)).ToList())
            {
                ws.Cell(index+5, 1).Value = recipe.mezcla;
                ws.Cell(index+5, 2).Value = recipe.fecha.ToString("g");
                foreach(var (item,pos) in recipe.items.Select((item,pos)=>(item,pos)).ToList())
                {
                    ws.Cell(index+5, (pos*2)+3).Value = item.name;
                    ws.Cell(index+5, (pos*2+1)+3).Value = item.quantity;
                }
            }

            ws.Columns().AdjustToContents();
            ws.Range("A3:R4").Style
                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                .Font.SetBold(true)
                .Font.SetFontSize(12);


            using (MemoryStream stream = new MemoryStream())
            {
                wb.SaveAs(stream);
                string name = "Reporte de Recetas";
                return stream.ToArray();
            }


        }
    }
}
