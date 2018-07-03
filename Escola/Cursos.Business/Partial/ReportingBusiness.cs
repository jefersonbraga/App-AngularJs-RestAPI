using ClosedXML.Excel;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Cursos.Business.Interfaces;
using Cursos.Repository.Services.Interfaces;
using Cursos.ViewModel;
using static System.Net.Mime.MediaTypeNames;

namespace Cursos.Business
{
    public class ColunasReport
    {
        public string Letra { get; set; }
        public string Coluna { get; set; }
    }

    public partial class ReportingBusiness : IReportingBusiness
    {
        private List<string> listaCelulas;
        private readonly IClienteService m_ClienteService;
        private readonly IInscricaoService m_InscricaoService;
        private Dictionary<string, string> dicionarioColunas;

        public ReportingBusiness(IClienteService clienteService, IInscricaoService inscricaoService)
        {
            m_ClienteService = clienteService;
            m_InscricaoService = inscricaoService;
            listaCelulas = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "X", "Y", "Z",
            "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AX", "AY", "AZ"};
            dicionarioColunas = new Dictionary<string, string>
            {
                { "Id", "Código" },
                { "Nome", "Nome" },
                { "Email", "Email" },
                { "Rg", "Rg" },
                { "Orgaoemissor", "Orgao Emissão" },
                { "Ufemissor", "Uf Emissão" },
                { "Dtemissao", "Emissão" },
                { "Cpf", "Cpf" },
                { "Nacionalidade", "Nacionalidade" },
                { "Naturalidade", "Naturalidade" },
                { "Dtnascimento", "Nascimento" },
                { "Sexo", "Sexo" },
                { "Nomepai", "Nome Pai" },
                { "Nomemae", "Nome Mãe" },
                { "Cep", "Cep" },
                { "Endereco", "Endereço" },
                { "Bairro", "Bairro" },
                { "Numero", "Numero" },
                { "Complemento", "Complemento" },
                { "Cidade", "Cidade" },
                { "Estado", "Estado" },
                { "Telresidencial", "Tel. Residencial" },
                { "Telcomercial", "Tel. Comercial" },
                { "Telcelular", "Tel. Celular" },
                { "Cadadministracao", "Cad Administração" },
                { "Enviosenha", "Envio Senha" },
                { "Orgaotrabalhoid", "Orgão Trabalho" },
                { "Escolaridadeid", "Escolaridade" },
                { "Instituicao", "Instituição" },
                { "Dtconclusao", "Conclusão" },
                { "Dtregistro", "Registro" },
                { "Dtultimaalteracao", "Última Alteração" },
                { "Dtultimoacesso", "Último acessso" },
                { "Idantigo", "Antigo" },
                { "Qtdacesso", "Acesso" },
                { "Receberfeeds", "Receber Feeds" }
            };
        }

        #region Relatorio Clientes

        public MemoryStream ReportCliente(string usuario, string fileName, FilterClientes filter)
        {
            var totalRegistros = m_ClienteService.GetTotalRegistros(filter);
            string[] colunas = filter.Columnsreport.Split(';');
            var listaColunas = new List<ColunasReport>();
            var indiceColunaMeio = (colunas.Length - 1) / 2;
            var colunaAntMeio = string.Empty;
            var colunaPosMeio = string.Empty;

            for (int i = 0; i < colunas.Length; i++)
            {
                if (colunas[i].Length == 0) continue;

                listaColunas.Add(new ColunasReport { Letra = listaCelulas[i], Coluna = colunas[i] });
                if (i == indiceColunaMeio)
                {
                    colunaAntMeio = listaCelulas[i - 1];
                    colunaPosMeio = listaCelulas[i];
                }
            }

            var clientes = m_ClienteService.GetClientePaginacao(filter, "asc", 0, totalRegistros);

            if (fileName.Contains("xlsx"))
                return ReportExcel(clientes, listaColunas, colunaAntMeio, colunaPosMeio, usuario);
            else if (fileName.Contains("docx"))
                return ReportWordPDF(clientes, listaColunas, colunaAntMeio, colunaPosMeio, fileName);//  ReportWord(clientes, listaColunas, colunaAntMeio, colunaPosMeio, fileName);
            else if (fileName.Contains("pdf"))
                return ReportWordPDF(clientes, listaColunas, colunaAntMeio, colunaPosMeio, fileName);
            return null;
        }     

        private string ImagemBase(string caminho)
        {
            System.Drawing.Image image = System.Drawing.Image.FromFile(caminho);
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
            //byte[] bytes = System.Text.ASCIIEncoding.ASCII.GetBytes(caminho);
            //string base64String = System.Convert.ToBase64String(bytes);
            //return base64String;
        }

        public MemoryStream ReportWordPDF(IEnumerable<Data.EV_CLIENTE> clientes, List<ColunasReport> listaColunas, string colunaAntMeio, string colunaPosMeio, object filename)
        {

            StringBuilder html = new StringBuilder();



            #region Monta Style e Cabecalho
            html.Append("<html>");
            html.Append("<head>");
            html.Append("<metahttp-equiv=Content-Typecontent=\"text/html;charset=windows-1252\">");
            html.Append("<style>");
            html.Append(" @font-face");
            html.Append("{");
            html.Append("font-family:\"Cambria Math\";");
            html.Append("panose-1:2 4 5 3 5 4 6 3 2 4;");
            html.Append("}");
            html.Append("@font-face");
            html.Append("{");
            html.Append("font-family:Calibri;");
            html.Append("panose-1:2 15 5 2 2 2 4 3 2 4;");
            html.Append("}");
            html.Append("p.MsoNormal, li.MsoNormal, div.MsoNormal");
            html.Append("{");
            html.Append("margin-top:0cm;");
            html.Append("margin-right:0cm;");
            html.Append("margin-bottom:8.0pt;");
            html.Append("margin-left:0cm;");
            html.Append("line-height:107 %;");
            html.Append("font-size:11.0pt;");
            html.Append("font-family:\"Calibri\",sans-serif;");
            html.Append("}");
            html.Append("p.MsoHeader, li.MsoHeader, div.MsoHeader");
            html.Append("{");
            html.Append("mso-style-link:\"Cabeçalho Char\";");
            html.Append("margin: 0cm;");
            html.Append("margin-bottom:.0001pt;");
            html.Append("font-size:11.0pt;");
            html.Append("font-family:\"Calibri\",sans-serif;");
            html.Append("}");
            html.Append("p.MsoFooter, li.MsoFooter, div.MsoFooter");
            html.Append("{");
            html.Append("mso-style-link:\"Rodapé Char\";");
            html.Append("margin: 0cm;");
            html.Append("margin-bottom:.0001pt;");
            html.Append("font-size:11.0pt;");
            html.Append("font-family:\"Calibri\",sans-serif;");
            html.Append("}");
            html.Append("span.CabealhoChar");
            html.Append("{");
            html.Append("mso-style-name:\"Cabeçalho Char\";");
            html.Append("mso-style-link:Cabeçalho;");
            html.Append("}");
            html.Append("span.RodapChar");
            html.Append("{");
            html.Append("mso-style-name:\"Rodapé Char\";");
            html.Append("mso-style-link:Rodapé;");
            html.Append("}");
            html.Append(".MsoChpDefault");
            html.Append("{ font-family:\"Calibri\",sans-serif; }");
            html.Append(".MsoPapDefault");
            html.Append("{");
            html.Append("margin-bottom:8.0pt;");
            html.Append("line-height:107 %;");
            html.Append("}");
            html.Append("@page WordSection1");
            html.Append("{");
            html.Append("size: 792.0pt 612.0pt;");
            html.Append("margin: 36.0pt 36.0pt 36.0pt 36.0pt;");
            html.Append("}");
            html.Append("div.WordSection1");
            html.Append("{ page: WordSection1; }");

            html.Append("table.MsoNormalTable");
            html.Append("{");
            html.Append("mso-style-name:\"Tabela normal\";");
            html.Append("mso-tstyle-rowband-size:0;");
            html.Append("mso-tstyle-colband-size:0;");
            html.Append("mso-style-noshow:yes;");
            html.Append("mso-style-priority:99;");
            html.Append("mso-style-parent:\"\";");
            html.Append("mso-padding-alt:0cm 5.4pt 0cm 5.4pt;");
            html.Append("mso-para-margin-top:0cm;");
            html.Append("mso-para-margin-right:0cm;");
            html.Append("mso-para-margin-bottom:8.0pt;");
            html.Append("mso-para-margin-left:0cm;");
            html.Append("line-height:107%;");
            html.Append("mso-pagination:widow-orphan;");
            html.Append("font-size:11.0pt;");
            html.Append("font-family:\"Calibri\",sans-serif;");
            html.Append("mso-ascii-font-family:Calibri;");
            html.Append("mso-ascii-theme-font:minor-latin;");
            html.Append("mso-hansi-font-family:Calibri;");
            html.Append("mso-hansi-theme-font:minor-latin;");
            html.Append("mso-ansi-language:PT-BR;");
            html.Append("mso-fareast-language:PT-BR;");
            html.Append("}");
            html.Append("table.MsoTableGrid");
            html.Append("{");
            html.Append("mso-style-name:\"Tabela com grade\";");
            html.Append("mso-tstyle-rowband-size:0;");
            html.Append("mso-tstyle-colband-size:0;");
            html.Append("mso-style-priority:39;");
            html.Append("mso-style-unhide:no;");
            html.Append("border: solid windowtext 1.0pt;");
            html.Append("mso-border-alt:solid windowtext .5pt;");
            html.Append("mso-padding-alt:0cm 5.4pt 0cm 5.4pt;");
            html.Append("mso-border-insideh:.5pt solid windowtext;");
            html.Append("mso-border-insidev:.5pt solid windowtext;");
            html.Append("mso-para-margin:0cm;");
            html.Append("mso-para-margin-bottom:.0001pt;");
            html.Append("mso-pagination:widow-orphan;");
            html.Append("font-size:11.0pt;");
            html.Append("font-family:\"Calibri\",sans-serif;");
            html.Append("mso-ascii-font-family:Calibri;");
            html.Append("mso-ascii-theme-font:minor-latin;");
            html.Append("mso-hansi-font-family:Calibri;");
            html.Append("mso-hansi-theme-font:minor-latin;");
            html.Append("mso-ansi-language:PT-BR;");
            html.Append("mso-fareast-language:PT-BR;");
            html.Append("}");
            html.Append("</style>");
            html.Append("</head>");
            #endregion

            html.Append("<body lang=PT-BR>");
            html.Append("<div class=WordSection1>");
            #region  cabecalho Tabela
            html.Append("<table class=\"MsoTableGrid\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"0\" style=\"width:730.75pt;border-collapse:collapse;border:none;mso-yfti-tbllook:1184;mso-padding-alt:0cm 5.4pt 0cm 5.4pt;mso-border-insideh:none;mso-border-insidev: none\">");
            html.Append("<tbody>");
            html.Append("<tr style=\"mso-yfti-irow:0;mso-yfti-firstrow:yes;mso-yfti-lastrow:yes;height:30.35pt\" >");
            html.Append("<td width=\"187\" valign=\"top\" style=\"width:140.5pt;padding:0cm 5.4pt 0cm 5.4pt; height:30.35pt\">");
            html.Append("<p class=\"MsoHeader\">");
            html.Append("<span style = \"mso-fareast-language:PT-BR;mso-no-proof:yes\" >");
            html.AppendFormat("<img width=\"170\" height=\"54\"  src=\"data:image/png;base64,{0}\">", ImagemBase(string.Format(@"{0}reporttemplate\logo2.png", HttpRuntime.AppDomainAppPath)));
            html.Append("</span><o:p></o:p>");
            html.Append("</p>");
            html.Append("</td>");
            html.Append("<td width = \"604\" valign=\"top\" style=\"width:453.25pt;padding:0cm 5.4pt 0cm 5.4pt;height:30.35pt\">");
            html.Append("<p class=\"MsoHeader\" align=\"center\" style=\"text-align:center\"><span style = \"font-size:22.0pt\" > Relatório de Clientes<o:p></o:p></span></p>");
            html.Append("</td>");
            html.Append("<td width = \"183\" valign= \"top\" style= \"width:137.0pt;padding:0cm 5.4pt 0cm 5.4pt;height:30.35pt\">");
            html.Append("<p class=\"MsoHeader\" align=\"right\" style=\"text-align:right\">Emitido em: &lt;DATA&gt;<o:p></o:p></p>");
            html.Append("<p class=\"MsoHeader\" align=\"right\" style=\"text-align:right\">Usuário:&lt;USUARIO&gt;<o:p></o:p>");
            html.Append("</p>");
            html.Append("</td>");
            html.Append("</tr>");
            html.Append("</tbody>");
            html.Append("</table>");
            #endregion

            html.Append("<p class=MsoNormal><span lang=PT-BR>&nbsp;</span></p>");
            html.Append("<table class=MsoNormalTable border=0 cellspacing=0 cellpadding=0 style='border-collapse:collapse'>");
            html.Append("<tr>");

            ///Monta Cabecalho colunas da Tabela
            for (var iCols = 0; iCols < listaColunas.Count; iCols++)
            {
                var textoColuna = dicionarioColunas.FirstOrDefault(x => x.Key == listaColunas[iCols].Coluna);
                html.AppendFormat("<td width=91 valign=top style='width:72.0pt;border:solid windowtext 1.0pt;background:#D9D9D9;padding:0cm 3.5pt 0cm 3.5pt'>");
                html.AppendFormat("<p class=MsoNormal style='margin-bottom:6.0pt'><b><span lang=PT-BR>{0}</span></b></p>", textoColuna.Value);
                html.AppendFormat("</td>");
                //objDoc.Tables[1].Cell(1, iCols + 1).Range.Text = textoColuna.Value; //add some text to cell
                //objDoc.Tables[1].Cell(1, iCols + 1).Range.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;// [WdBorderType.wdBorderLeft].LineStyle = WdLineStyle.wdLineStyleSingle;
            }
            html.Append("</tr>");
            ///Monta Linhas da tabela

            foreach (var item in clientes)
            {
                html.AppendFormat("<tr>");
                for (int i = 0; i < listaColunas.Count; i++)
                {
                    var coluna = dicionarioColunas.FirstOrDefault(x => x.Key == listaColunas[i].Coluna);
                    var colunasErrado = string.Empty;
                    var keyColuna = coluna.Key.ToUpper();

                    if (keyColuna == "TELCELULAR") keyColuna = "TEL_CELULAR";
                    if (keyColuna == "TELCOMERCIAL") keyColuna = "TEL_COMERCIAL";
                    if (keyColuna == "TELRESIDENCIAL") keyColuna = "TEL_RESIDENCIAL";
                    if (keyColuna == "ENVIOSENHA") keyColuna = "ENVIO_SENHA";
                    if (keyColuna == "DTREGISTRO") keyColuna = "DT_REGISTRO";
                    if (keyColuna == "DTULTIMAALTERACAO") keyColuna = "DT_ULTIMAALTERACAO";

                    var valorColuna = item.GetType().GetProperty(keyColuna).GetValue(item, null);
                    html.AppendFormat("<td width=91 valign=top style='width:72.0pt;border:solid windowtext 1.0pt;border-top:none; padding: 0cm 3.5pt 0cm 3.5pt'>");
                    html.AppendFormat("<p class=MsoNormal style='margin-bottom:6.0pt'><span lang=PT-BR>{0}</span></p></td>", valorColuna == null ? string.Empty : valorColuna.ToString());
                }
                html.AppendFormat("</tr>");
            }


            html.Append("</table>");
            html.Append("<p class=MsoNormal><span lang=PT-BR >&nbsp;</span></p>");
            html.Append("<p class=MsoNormal><span lang=PT-BR >&nbsp;</span></p>");
            html.Append("</div>");
            html.Append("</body>");
            html.Append("</html>");
            var _html = html.ToString();

            SelectPdf.HtmlToPdf converter = new SelectPdf.HtmlToPdf();

            SelectPdf.PdfDocument doc = converter.ConvertHtmlString(html.ToString());

            MemoryStream ms = new MemoryStream();
            doc.Save(ms);
            return ms;// new MemoryStream(Encoding.UTF8.GetBytes(doc.ParsedText));
        }

        public MemoryStream ReportWord(IEnumerable<Data.EV_CLIENTE> clientes, List<ColunasReport> listaColunas, string colunaAntMeio, string colunaPosMeio, object filename)
        {
            try
            {

                object objMiss = System.Reflection.Missing.Value;
                object objEndOfDocFlag = "\\endofdoc"; /* \endofdoc is a predefined bookmark */
                object template = string.Format(@"{0}reporttemplate\{1}", HttpRuntime.AppDomainAppPath, listaColunas.Count > 5 ? "templateHorizontal.docx" : "templateVertical.docx");

                //Start Word and create a new document.
                var objApp = new Microsoft.Office.Interop.Word.Application
                {
                    Visible = true
                };
                var objDoc = objApp.Documents.Add(ref template, ref objMiss, ref objMiss, ref objMiss);

                //Insert a paragraph at the end of the document.
                object oRng = objDoc.Bookmarks.get_Item(ref objEndOfDocFlag).Range; //go to end of the page
                var objPara2 = objDoc.Content.Paragraphs.Add(ref oRng); //add paragraph at end of document
                //objPara2.Range.Text = "Test Table Caption"; //add some text in paragraph
                //objPara2.Format.SpaceAfter = 10; //defind some style
                //objPara2.Range.InsertParagraphAfter(); //insert paragraph

                //Insert a 2 x 2 table, (table with 2 row and 2 column)
                var objWordRng = objDoc.Bookmarks.get_Item(ref objEndOfDocFlag).Range; //go to end of document
                var objTab1 = objDoc.Tables.Add(objWordRng, 1, listaColunas.Count + 1, ref objMiss, ref objMiss); //add table object in word document
                objTab1.Range.ParagraphFormat.SpaceAfter = 6;

                for (var iCols = 0; iCols < listaColunas.Count; iCols++)
                {


                    var textoColuna = dicionarioColunas.FirstOrDefault(x => x.Key == listaColunas[iCols].Coluna);
                    var iidd = objDoc.Tables.Creator;
                    // objDoc.Tables[1].Cell(1, iCols + 1).Range.Text = textoColuna.Value; //add some text to cell
                    // objDoc.Tables[1].Cell(1, iCols + 1).Range.Text = textoColuna.Value; //add some text to cell
                    //  objDoc.Tables[1].Cell(1, iCols + 1).Range.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;//[WdBorderType.wdBorderLeft].LineStyle = WdLineStyle.wdLineStyleSingle;
                    //objDoc.Tables[1].Cell(1, iCols + 1).Range.Borders[WdBorderType.wdBorderRight].LineStyle = WdLineStyle.wdLineStyleSingle;
                    //objDoc.Tables[1].Cell(1, iCols + 1).Range.Borders[WdBorderType.wdBorderTop].LineStyle = WdLineStyle.wdLineStyleSingle;
                    //objDoc.Tables[1].Cell(1, iCols + 1).Range.Borders[WdBorderType.wdBorderBottom].LineStyle = WdLineStyle.wdLineStyleSingle;

                    objDoc.Tables[1].Cell(1, iCols + 1).Range.Text = textoColuna.Value; //add some text to cell
                    objDoc.Tables[1].Cell(1, iCols + 1).Range.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;// [WdBorderType.wdBorderLeft].LineStyle = WdLineStyle.wdLineStyleSingle;

                    //objTab1.Cell(1, iCols + 1).Range.Borders[WdBorderType.wdBorderRight].LineStyle = WdLineStyle.wdLineStyleSingle;
                    //objTab1.Cell(1, iCols + 1).Range.Borders[WdBorderType.wdBorderTop].LineStyle = WdLineStyle.wdLineStyleSingle;
                    //objTab1.Cell(1, iCols + 1).Range.Borders[WdBorderType.wdBorderBottom].LineStyle = WdLineStyle.wdLineStyleSingle;
                }

                objDoc.Tables[1].Rows[1].Shading.BackgroundPatternColor = WdColor.wdColorGray15;
                objDoc.Tables[1].Rows[1].Range.Font.Bold = 1; //make first row of table BOLD
                objDoc.Tables[1].Rows.Add(objDoc.Tables[1].Rows[2]);
                //objTab1.Columns[1].Width = objApp.InchesToPoints(3); //increase first column width
                int iLinha = 2;
                foreach (var item in clientes)
                {
                    for (int i = 0; i < listaColunas.Count; i++)
                    {
                        var coluna = dicionarioColunas.FirstOrDefault(x => x.Key == listaColunas[i].Coluna);
                        var colunasErrado = string.Empty;
                        var keyColuna = coluna.Key.ToUpper();

                        if (keyColuna == "TELCELULAR") keyColuna = "TEL_CELULAR";
                        if (keyColuna == "TELCOMERCIAL") keyColuna = "TEL_COMERCIAL";
                        if (keyColuna == "TELRESIDENCIAL") keyColuna = "TEL_RESIDENCIAL";
                        if (keyColuna == "ENVIOSENHA") keyColuna = "ENVIO_SENHA";
                        if (keyColuna == "DTREGISTRO") keyColuna = "DT_REGISTRO";
                        if (keyColuna == "DTULTIMAALTERACAO") keyColuna = "DT_ULTIMAALTERACAO";

                        var valorColuna = item.GetType().GetProperty(keyColuna).GetValue(item, null);

                        ///objTab1.Cell(iLinha, i + 1).Range.Text = valorColuna == null ? "" : valorColuna.ToString();
                        //objTab1.Cell(iLinha, i + 1).Range.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;
                        objDoc.Tables[1].Cell(iLinha, i + 1).Range.Text = valorColuna == null ? "" : valorColuna.ToString();
                        objDoc.Tables[1].Cell(iLinha, i + 1).Range.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;// [WdBorderType.wdBorderLeft].LineStyle = WdLineStyle.wdLineStyleSingle;

                        //[WdBorderType.wdBorderLeft].LineStyle = WdLineStyle.wdLineStyleSingle;
                        //objTab1.Cell(iLinha, i + 1).Range.Borders[WdBorderType.wdBorderRight].LineStyle = WdLineStyle.wdLineStyleSingle;
                        //objTab1.Cell(iLinha, i + 1).Range.Borders[WdBorderType.wdBorderTop].LineStyle = WdLineStyle.wdLineStyleSingle;
                        //objTab1.Cell(iLinha, i + 1).Range.Borders[WdBorderType.wdBorderBottom].LineStyle = WdLineStyle.wdLineStyleSingle;
                    }
                    iLinha++;
                    objDoc.Tables[1].Rows.Add(objDoc.Tables[1].Rows[iLinha]);
                }
                //Add some text after table
                objWordRng = objDoc.Bookmarks.get_Item(ref objEndOfDocFlag).Range;
                objWordRng.InsertParagraphAfter(); //put enter in document
                //objWordRng.InsertAfter("THIS IS THE SIMPLE WORD DEMO : THANKS YOU.");

                object localFolder = string.Format(@"{0}reporttemplate\{1}", HttpRuntime.AppDomainAppPath, filename);

                if (filename.ToString().Contains("pdf"))
                {
                    object fileFormat = WdSaveFormat.wdFormatPDF;
                    objDoc.SaveAs(ref localFolder, ref fileFormat);
                }
                else
                {
                    objDoc.SaveAs(ref localFolder);
                }

                objDoc.Close();
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (Stream input = File.OpenRead((string)localFolder))
                    {
                        input.CopyTo(memoryStream);
                    }
                    return memoryStream;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private MemoryStream ReportExcel(IEnumerable<Data.EV_CLIENTE> clientes, List<ColunasReport> listaColunas, string colunaAntMeio, string colunaPosMeio, string usuario)
        {
            //var localFolder = string.Format(@"{0}reporttemplate\template.xlsx", HttpRuntime.AppDomainAppPath);
            using (var wb = new XLWorkbook())
            {

                var ws = wb.Worksheets.Add("Relatório Clientes");
                var ultimaColuna = listaColunas.LastOrDefault().Letra;

                //Main Title
                ws.Cell("A1").Value = "Relatório de Clientes";
                ws.Cell("A1").Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                ws.Cell("A1").Style.Font.SetBold().Fill.SetBackgroundColor(XLColor.FromArgb(36, 86, 97)).Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);
                ws.Cell("A1").Style.Font.FontName = "Calibri";
                ws.Cell("A1").Style.Font.FontSize = 18;
                ws.Cell("A1").Style.Font.FontColor = XLColor.White;

                ws.Range(string.Format("A1:{0}1", colunaAntMeio)).Merge();

                ws.Cell(string.Format("{0}1", colunaPosMeio)).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                ws.Cell(string.Format("{0}1", colunaPosMeio)).Style.Font.SetBold().Fill.SetBackgroundColor(XLColor.FromArgb(36, 86, 97)).Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
                ws.Cell(string.Format("{0}1", colunaPosMeio)).Style.Font.FontName = "Calibri";
                ws.Cell(string.Format("{0}1", colunaPosMeio)).Style.Font.FontSize = 12;
                ws.Cell(string.Format("{0}1", colunaPosMeio)).Style.Font.FontColor = XLColor.White;
                ws.Cell(string.Format("{0}1", colunaPosMeio)).Value = string.Format("Emitido Em: {0} \r\n Usuário: {1}", DateTime.Now.ToString("dd/MM/yyyy"), usuario);
                ws.Range(string.Format("{0}1:{1}1", colunaPosMeio, ultimaColuna)).Merge();
                ///PDI

                foreach (var item in listaColunas)
                {
                    var textoColuna = dicionarioColunas.FirstOrDefault(x => x.Key == item.Coluna);
                    ws.Cell(string.Format("{0}2", item.Letra)).Value = textoColuna.Value;
                }

                var rngHeaders = ws.Range(string.Format("A2:{0}2", ultimaColuna));

                //ws.Range("AS1:AT2").Merge();

                rngHeaders.Style.Font.SetBold().Fill.SetBackgroundColor(XLColor.FromArgb(49, 157, 181)).Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                rngHeaders.Style.Font.FontColor = XLColor.White;
                rngHeaders.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                rngHeaders.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                rngHeaders.Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                rngHeaders.Style.Alignment.WrapText = true;

                ws.SheetView.FreezeRows(1);
                ws.SheetView.FreezeRows(2);

                var rowCount = 3;
                foreach (var item in clientes)
                {
                    foreach (var itemColuna in listaColunas)
                    {
                        var coluna = dicionarioColunas.FirstOrDefault(x => x.Key == itemColuna.Coluna);
                        var colunasErrado = string.Empty;
                        var keyColuna = coluna.Key.ToUpper();
                        try
                        {
                            if (keyColuna == "TELCELULAR") keyColuna = "TEL_CELULAR";
                            if (keyColuna == "TELCOMERCIAL") keyColuna = "TEL_COMERCIAL";
                            if (keyColuna == "TELRESIDENCIAL") keyColuna = "TEL_RESIDENCIAL";
                            if (keyColuna == "ENVIOSENHA") keyColuna = "ENVIO_SENHA";
                            if (keyColuna == "DTREGISTRO") keyColuna = "DT_REGISTRO";
                            if (keyColuna == "DTULTIMAALTERACAO") keyColuna = "DT_ULTIMAALTERACAO";

                            var valorColuna = item.GetType().GetProperty(keyColuna).GetValue(item, null);

                            ws.Cell(itemColuna.Letra + rowCount).Value = valorColuna;
                            ws.Cell(itemColuna.Letra + rowCount).Style.Font.SetBold().Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);
                            ws.Cell(itemColuna.Letra + rowCount).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        }
                        catch (Exception ex)
                        {
                            colunasErrado += keyColuna;
                        }
                    }

                    rowCount++;
                }

                using (MemoryStream streamWorksheet = new MemoryStream())
                {
                    wb.SaveAs(streamWorksheet);
                    return streamWorksheet;
                }
            }
        }

        #endregion Relatorio Clientes
    }
}