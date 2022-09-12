using iTextSharp.text;
using iTextSharp.text.pdf;
using MatriculasUPN.CapaEntidad;
using MatriculasUPN.CapaReportes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MatriculasUPN.Reports
{
    public class MatriculaReport
    {
        #region Declaration
        int totalColumn = 6;
        Document document;
        Font fontStyle;
        PdfPTable pdfTable = new PdfPTable(6);
        PdfPCell pdfPCell;
        MemoryStream memoryStream = new MemoryStream();
        List<ReporteMatricula> matriculas = new List<ReporteMatricula>();
        #endregion Declaration

        public byte[] PrepararReportes(List<ReporteMatricula> reporteMatriculas)
        {
            matriculas = reporteMatriculas;

            #region
            document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            document.SetPageSize(PageSize.A4);
            document.SetMargins(20f, 20f, 20f, 20f);
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfWriter.GetInstance(document,memoryStream);
            document.Open();
            pdfTable.SetWidths(new float[] { 20f ,20f, 20f, 20f, 20f, 40f });
            #endregion

            this.ReportHeadear();
            this.ReportBody();
            pdfTable.HeaderRows = 2;
            document.Add(pdfTable);
            document.Close();
            return memoryStream.ToArray();
        }
        private void ReportHeadear()
        {
            fontStyle = FontFactory.GetFont("Tahoma", 20f, 1);
            pdfPCell = new PdfPCell(new Phrase("Universidad Privada del Norte", fontStyle));
            pdfPCell.Colspan = totalColumn;
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.Border = 0;
            pdfPCell.BackgroundColor = BaseColor.WHITE;
            pdfPCell.ExtraParagraphSpace = 10f;
            pdfTable.AddCell(pdfPCell);
            pdfTable.CompleteRow();

            fontStyle = FontFactory.GetFont("Tahoma", 9f, 1);
            pdfPCell = new PdfPCell(new Phrase("REPORTE DE MATRICULAS", fontStyle));
            pdfPCell.Colspan = totalColumn;
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.Border = 0;
            pdfPCell.BackgroundColor = BaseColor.WHITE;
            pdfPCell.ExtraParagraphSpace = 0;
            pdfTable.AddCell(pdfPCell);
            pdfTable.CompleteRow();
        }
        private void ReportBody()
        {
            #region tableHeader
            fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);

            pdfPCell = new PdfPCell(new Phrase("Código de Estudiante", fontStyle));
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            pdfTable.AddCell(pdfPCell);

            pdfPCell = new PdfPCell(new Phrase("Nombres de Estudiante", fontStyle));
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            pdfTable.AddCell(pdfPCell);

            pdfPCell = new PdfPCell(new Phrase("Periodo", fontStyle));
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            pdfTable.AddCell(pdfPCell);

            pdfPCell = new PdfPCell(new Phrase("Cursos", fontStyle));
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            pdfTable.AddCell(pdfPCell);

            pdfPCell = new PdfPCell(new Phrase("Código de Clases", fontStyle));
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            pdfTable.AddCell(pdfPCell);

            pdfPCell = new PdfPCell(new Phrase("Movimientos", fontStyle));
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            pdfTable.AddCell(pdfPCell);
            #endregion tableHeader

            #region tableBody
            fontStyle = FontFactory.GetFont("Tahoma", 8f, 0);
            foreach(ReporteMatricula matricula in matriculas)
            {
                pdfPCell = new PdfPCell(new Phrase(matricula.estudiante.code, fontStyle));
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                pdfTable.AddCell(pdfPCell);

                pdfPCell = new PdfPCell(new Phrase(matricula.estudiante.GetNames(), fontStyle));
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                pdfTable.AddCell(pdfPCell);

                pdfPCell = new PdfPCell(new Phrase(matricula.getPeriodos(), fontStyle));
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                pdfTable.AddCell(pdfPCell);

                pdfPCell = new PdfPCell(new Phrase(matricula.getCursos(), fontStyle));
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                pdfTable.AddCell(pdfPCell);

                pdfPCell = new PdfPCell(new Phrase(matricula.getClases(), fontStyle));
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                pdfTable.AddCell(pdfPCell);

                pdfPCell = new PdfPCell(new Phrase(matricula.matriculaLog.getMovimientos(), fontStyle));
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                pdfTable.AddCell(pdfPCell);
            }
            #endregion tableBody
        }
    }
}