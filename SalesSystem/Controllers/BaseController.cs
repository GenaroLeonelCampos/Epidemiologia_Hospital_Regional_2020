//using System;
//using System.Collections.Generic;
//using cm = System.ComponentModel;
//using System.IO;
//using System.Linq;
//using System.Net.Http.Headers;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Epidemiologia.Class
//using MiPrimeraAplicacionEnNetCore.Models;
//using OfficeOpenXml;
//using iText.Kernel.Pdf;
//using iText.Layout;
//using iText.Layout.Element;
//using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
//using Syncfusion.DocIO.DLS;
//using Syncfusion.DocIO;



//namespace Epidemiologia.Controllers
//{
//    public class BaseController
//    {

//        public byte[] exportarPDFDatos<T>(string[] nombrePropiedades, List<T> lista)
//        {
//            using (MemoryStream ms = new MemoryStream())
//            {
//                Dictionary<string, string> diccionario = cm.TypeDescriptor.
//                      GetProperties(typeof(T))
//                      .Cast<cm.PropertyDescriptor>().
//                      ToDictionary(p => p.Name, p => p.DisplayName);


//                PdfWriter writer = new PdfWriter(ms);
//                using (var pdfDoc = new PdfDocument(writer))
//                {
//                    Document doc = new Document(pdfDoc);
//                    Paragraph c1 = new Paragraph("Reporte en PDF");
//                    c1.SetFontSize(20);
//                    c1.SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);

//                    doc.Add(c1);
//                    if (nombrePropiedades != null && nombrePropiedades.Length > 0)
//                    {
//                        //Crearemos la tabla
//                        Table table = new Table(nombrePropiedades.Length);
//                        Cell celda;
//                        for (int i = 0; i < nombrePropiedades.Length; i++)
//                        {
//                            celda = new Cell();
//                            celda.Add(new Paragraph(diccionario[nombrePropiedades[i]]));
//                            table.AddHeaderCell(celda);
//                        }
//                        if (lista != null)
//                        {
//                            foreach (object item in lista)
//                            {
//                                foreach (string propiedad in nombrePropiedades)
//                                {
//                                    celda = new Cell();
//                                    celda.Add(new Paragraph(
//                                         item.GetType().GetProperty(propiedad).GetValue(item).ToString()
//                                        ));
//                                    table.AddCell(celda);
//                                }

//                            }
//                        }

//                        doc.Add(table);
//                    }
//                    doc.Close();
//                    writer.Close();




//                }

//                return ms.ToArray();
//            }


//        }

//        public byte[] exportarWordDatos<T>(string[] nombrePropiedades, List<T> lista)
//        {
//            using (MemoryStream ms = new MemoryStream())
//            {
//                WordDocument document = new WordDocument();
//                WSection section = document.AddSection() as WSection;
//                section.PageSetup.Margins.All = 72;
//                section.PageSetup.PageSize = new Syncfusion.Drawing.SizeF(612, 792);
//                IWParagraph paragraph = section.AddParagraph();
//                paragraph.ApplyStyle("Normal");
//                paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
//                WTextRange textRange = paragraph.AppendText("Reporte en Word") as WTextRange;
//                textRange.CharacterFormat.FontSize = 20f;
//                textRange.CharacterFormat.FontName = "Calibri";
//                textRange.CharacterFormat.TextColor = Syncfusion.Drawing.Color.Blue;
//                if (nombrePropiedades != null && nombrePropiedades.Length > 0)
//                {
//                    IWTable table = section.AddTable();

//                    int numeroColumnas = nombrePropiedades.Length;
//                    int nfilas = lista.Count;
//                    table.ResetCells(nfilas + 1, numeroColumnas);
//                    Dictionary<string, string> diccionario = cm.TypeDescriptor.
//                        GetProperties(typeof(T))
//                        .Cast<cm.PropertyDescriptor>().
//                        ToDictionary(p => p.Name, p => p.DisplayName);
//                    for (int i = 0; i < numeroColumnas; i++)
//                    {
//                        table[0, i].AddParagraph().AppendText(diccionario[nombrePropiedades[i]]);
//                    }
//                    int fila = 1;
//                    int col = 0;
//                    if (lista != null)
//                    {
//                        foreach (object item in lista)
//                        {
//                            col = 0;
//                            foreach (string propiedad in nombrePropiedades)
//                            {
//                                table[fila, col].AddParagraph().AppendText(
//                                     item.GetType().GetProperty(propiedad).GetValue(item).ToString()
//                                    );
//                                col++;
//                            }
//                            fila++;
//                        }
//                    }

//                }
//                document.Save(ms, FormatType.Docx);
//                return ms.ToArray();

//            }
//        }

//        public byte[] exportarExcelDatos<T>(string[] nombrePropiedades,
//          List<T> lista)
//        {
//            using (MemoryStream ms = new MemoryStream())
//            {
//                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
//                using (ExcelPackage ep = new ExcelPackage())
//                {
//                    ep.Workbook.Worksheets.Add("Hoja");

//                    ExcelWorksheet ew = ep.Workbook.Worksheets[0];
//                    Dictionary<string, string> diccionario = cm.TypeDescriptor.
//                        GetProperties(typeof(T))
//                        .Cast<cm.PropertyDescriptor>().
//                        ToDictionary(p => p.Name, p => p.DisplayName);
//                    if (nombrePropiedades != null && nombrePropiedades.Length > 0)
//                    {
//                        for (int i = 0; i < nombrePropiedades.Length; i++)
//                        {
//                            ew.Cells[1, i + 1].Value = diccionario[nombrePropiedades[i]];
//                            ew.Column(i + 1).Width = 50;
//                        }
//                        int fila = 2;
//                        int col = 1;
//                        if (lista != null)
//                        {
//                            foreach (object item in lista)
//                            {
//                                col = 1;
//                                foreach (string propiedad in nombrePropiedades)
//                                {
//                                    ew.Cells[fila, col].Value =
//                                        item.GetType().GetProperty(propiedad).GetValue(item).ToString();
//                                    col++;
//                                }
//                                fila++;

//                            }
//                        }
//                    }


//                    ep.SaveAs(ms);
//                    byte[] buffer = ms.ToArray();
//                    return buffer;
//                }


//            }


//        }
//    }