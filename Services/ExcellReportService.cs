namespace BitacoraAPP.Services;

using BitacoraAPP.Models.EmpleadoUserViewModel;
using OfficeOpenXml;
using System.Drawing;

    public interface IExcellReportService
    {
    Task <string> CreateExcellGeneralReportService(List<ListarEmpleadosGeneralReport> ListaUsuarios);
       
    }
public class ExcellReportService : IExcellReportService
{
    public async Task <string> CreateExcellGeneralReportService(List<ListarEmpleadosGeneralReport> ListaUsuarios)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        using (ExcelPackage excelPackage = new ExcelPackage())
        {
            //Set some properties of the Excel document
            excelPackage.Workbook.Properties.Author = "Support SMIMX";
            excelPackage.Workbook.Properties.Title = "Lista de Entrada/Salida Empleados";
            excelPackage.Workbook.Properties.Subject = DateTime.Now.ToString();
            excelPackage.Workbook.Properties.Created = DateTime.Now;


            //Create the WorkSheet
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Entradas & Salidas de Empleados");

            //Add some text to cell A1
            worksheet.Cells["A1"].Value = "Empleado";
            worksheet.Cells["B1"].Value = "Nombre";
            worksheet.Cells["C1"].Value = "Hora Salida";
            worksheet.Cells["D1"].Value = "Hora Entrada";
            worksheet.Cells["E1"].Value = "Duracion En Minutos";
            worksheet.Cells["F1"].Value = "Cerrado por Sistema";

            worksheet.Column(1).Width = 8;
            worksheet.Column(2).Width = 25;
            worksheet.Column(3).Width = 18;
            worksheet.Column(4).Width = 18;
            worksheet.Column(5).Width = 16;
            worksheet.Column(6).Width = 16;

            //color column 
            worksheet.Row(1).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            worksheet.Row(1).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#ffe252"));
            //border column 
            //worksheet.Cells["A1:D5"].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thick;

            worksheet.Row(1).Style.Font.Bold = true;
            worksheet.Row(1).Style.Font.Name = "Arial";
            worksheet.Row(1).Style.Font.Size = 8;

            worksheet.HeaderFooter.FirstFooter.LeftAlignedText = "Registros de Entradas / Salidas";
            worksheet.HeaderFooter.FirstHeader.CenteredText = "Registros de Entradas / Salidas";


            int initialRow = 2;
            foreach (var empleados in ListaUsuarios)
            {

                worksheet.Cells[initialRow, 1].Value = empleados.ClaveUsuarios;
                worksheet.Cells[initialRow, 2].Value = empleados.NombreUsuarios;
                worksheet.Cells[initialRow, 3].Value = empleados.HoraSalida;
                worksheet.Cells[initialRow, 3].Value = empleados.HoraSalida;
                worksheet.Cells[initialRow, 4].Value = empleados.HoraEntrada;
                worksheet.Cells[initialRow, 5].Value = empleados.DuracionMinutos;
                switch (empleados.CerrarRegistro)
                {
                    case 0:
                        worksheet.Cells[initialRow, 6].Value = "NO";
                        break;
                    case 1:
                        worksheet.Cells[initialRow, 6].Value = "SI";
                        break;
                    case 2:
                        worksheet.Cells[initialRow, 6].Value = "AUSENTE";
                        break;
                }



                worksheet.Cells[initialRow, 1].Style.Font.Size = 8;
                worksheet.Cells[initialRow, 2].Style.Font.Size = 8;
                worksheet.Cells[initialRow, 3].Style.Font.Size = 8;
                worksheet.Cells[initialRow, 4].Style.Font.Size = 8;
                worksheet.Cells[initialRow, 5].Style.Font.Size = 8;
                worksheet.Cells[initialRow, 6].Style.Font.Size = 8;



                initialRow++;
            }
            //You could also use [line, column] notation:
            //worksheet.Cells[1, 2].Value = "This is cell B1!";
            string fileName = "Empleados" + Guid.NewGuid().ToString() + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + ".xlsx";
            //Save your file
            excelPackage.SaveAs(new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//Excel", fileName)));
            return fileName;
        }

    }
}

