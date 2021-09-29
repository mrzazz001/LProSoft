using DevComponents.DotNetBar.SuperGrid;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace InvAcc
{
    public class ExportExcel
    {
        public static void ExportToExcel(SuperGridControl dgv2, string title)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "xls";
            saveFileDialog.Title = "Save file as ...";
            saveFileDialog.Filter = "Excel Files|*.xls";
            SaveFileDialog dialog = saveFileDialog;
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            int num = 0;
            DateTime now = DateTime.Now;
            StringBuilder builder = new StringBuilder();
            List<string> source = new List<string>();
            for (int i = 0; i < dgv2.PrimaryGrid.Columns.Count; i++)
            {
                if (dgv2.PrimaryGrid.Columns[i].Visible)
                {
                    source.Add(dgv2.PrimaryGrid.Columns[i].Name);
                }
            }
            builder.Append("<Row ss:AutoFitHeight=\"0\" ss:StyleID=\"s62\">");
            builder.Append("<Cell ss:MergeAcross=\"" + (source.Count - 1) + "\" ss:StyleID=\"s66\"><Data ss:Type=\"String\">" + title + "</Data></Cell>");
            builder.Append("</Row>");
            builder.Append("<Row ss:AutoFitHeight=\"0\" ss:StyleID=\"s62\">");
            foreach (string str in source)
            {
                num++;
                builder.Append("<Cell><Data ss:Type=\"String\">" + dgv2.PrimaryGrid.Columns[str].HeaderText + "</Data></Cell>");
            }
            builder.Append("</Row>");
            foreach (GridElement element in dgv2.PrimaryGrid.Rows)
            {
                builder.Append("<Row ss:AutoFitHeight=\"0\">");
                for (int j = 0; j < num; j++)
                {
                    object obj2 = (element as GridRow).Cells[source[j]].Value;
                    builder.Append("<Cell><Data ss:Type=\"String\">" + ((obj2 == null) ? "" : obj2.ToString()) + "</Data></Cell>");
                }
                builder.Append("</Row>");
            }
            string contents = "<?xml version=\"1.0\"?>\r\n                    <?mso-application progid=\"Excel.Sheet\"?>\r\n                    <Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"\r\n                        xmlns:o=\"urn:schemas-microsoft-com:office:office\"\r\n                        xmlns:x=\"urn:schemas-microsoft-com:office:excel\"\r\n                        xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\"\r\n                        xmlns:html=\"http://www.w3.org/TR/REC-html40\">\r\n                        <DocumentProperties xmlns=\"urn:schemas-microsoft-com:office:office\">\r\n                            <Author>Multi Soft</Author>\r\n                            <LastAuthor>Multi Soft</LastAuthor>\r\n                            <Created>" + DateTime.Now.ToString("yyyy-MM-dd") + "2011-07-12T23:40:11Z</Created>\r\n                            <Company>Multisoft Co.</Company>\r\n                            <Version>3.80</Version>\r\n                        </DocumentProperties>\r\n                        <ExcelWorkbook xmlns=\"urn:schemas-microsoft-com:office:excel\">\r\n                            <WindowHeight>6600</WindowHeight>\r\n                            <WindowWidth>12255</WindowWidth>\r\n                            <WindowTopX>0</WindowTopX>\r\n                            <WindowTopY>60</WindowTopY>\r\n                            <ProtectStructure>False</ProtectStructure>\r\n                            <ProtectWindows>False</ProtectWindows>\r\n                        </ExcelWorkbook>\r\n                        <Styles>\r\n                            <Style ss:ID=\"Default\" ss:Name=\"Normal\">\r\n                                <Alignment ss:Vertical=\"Bottom\"/>\r\n                                <Borders/>\r\n                                <Font ss:FontName=\"Calibri\" x:Family=\"Swiss\" ss:Size=\"11\" ss:Color=\"#000000\"/>\r\n                                <Interior/>\r\n                                <NumberFormat/>\r\n                                <Protection/>\r\n                            </Style>\r\n                            <Style ss:ID=\"s62\">\r\n                                <Font ss:FontName=\"Calibri\" x:Family=\"Swiss\" ss:Size=\"11\" ss:Color=\"#000000\"\r\n                                    ss:Bold=\"1\"/>\r\n                            </Style>\r\n                            <Style ss:ID=\"s66\">\r\n                            <Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Bottom\"/>\r\n                            <Font ss:FontName=\"Calibri\" x:Family=\"Swiss\" ss:Size=\"12\" ss:Color=\"#000000\"\r\n                            ss:Bold=\"1\"/>\r\n                           </Style>\r\n                        </Styles>\r\n                        <Worksheet ss:Name=\"Sheet1\">\r\n                            <Table ss:ExpandedColumnCount=\"" + (source.Count() + 1) + "\" ss:ExpandedRowCount=\"" + (dgv2.PrimaryGrid.Rows.Count + 2) + "\" x:FullColumns=\"1\"\r\n                                x:FullRows=\"1\" ss:DefaultRowHeight=\"15\">\r\n                                " + builder.ToString() + "\r\n                            </Table>\r\n                            <WorksheetOptions xmlns=\"urn:schemas-microsoft-com:office:excel\">\r\n                                <PageSetup>\r\n                                    <Header x:Margin=\"0.3\"/>\r\n                                    <Footer x:Margin=\"0.3\"/>\r\n                                    <PageMargins x:Bottom=\"0.75\" x:Left=\"0.7\" x:Right=\"0.7\" x:Top=\"0.75\"/>\r\n                                </PageSetup>\r\n                                <Print>\r\n                                    <ValidPrinterInfo/>\r\n                                    <HorizontalResolution>300</HorizontalResolution>\r\n                                    <VerticalResolution>300</VerticalResolution>\r\n                                </Print>\r\n                                <Selected/>\r\n                                <Panes>\r\n                                    <Pane>\r\n                                        <Number>3</Number>\r\n                                        <ActiveCol>2</ActiveCol>\r\n                                    </Pane>\r\n                                </Panes>\r\n                                <ProtectObjects>False</ProtectObjects>\r\n                                <ProtectScenarios>False</ProtectScenarios>\r\n                            </WorksheetOptions>\r\n                        </Worksheet>\r\n                        <Worksheet ss:Name=\"Sheet2\">\r\n                            <Table ss:ExpandedColumnCount=\"1\" ss:ExpandedRowCount=\"1\" x:FullColumns=\"1\"\r\n                                x:FullRows=\"1\" ss:DefaultRowHeight=\"15\">\r\n                            </Table>\r\n                            <WorksheetOptions xmlns=\"urn:schemas-microsoft-com:office:excel\">\r\n                                <PageSetup>\r\n                                    <Header x:Margin=\"0.3\"/>\r\n                                    <Footer x:Margin=\"0.3\"/>\r\n                                    <PageMargins x:Bottom=\"0.75\" x:Left=\"0.7\" x:Right=\"0.7\" x:Top=\"0.75\"/>\r\n                                </PageSetup>\r\n                                <ProtectObjects>False</ProtectObjects>\r\n                                <ProtectScenarios>False</ProtectScenarios>\r\n                            </WorksheetOptions>\r\n                        </Worksheet>\r\n                        <Worksheet ss:Name=\"Sheet3\">\r\n                            <Table ss:ExpandedColumnCount=\"1\" ss:ExpandedRowCount=\"1\" x:FullColumns=\"1\"\r\n                                x:FullRows=\"1\" ss:DefaultRowHeight=\"15\">\r\n                            </Table>\r\n                            <WorksheetOptions xmlns=\"urn:schemas-microsoft-com:office:excel\">\r\n                                <PageSetup>\r\n                                    <Header x:Margin=\"0.3\"/>\r\n                                    <Footer x:Margin=\"0.3\"/>\r\n                                    <PageMargins x:Bottom=\"0.75\" x:Left=\"0.7\" x:Right=\"0.7\" x:Top=\"0.75\"/>\r\n                                </PageSetup>\r\n                                <ProtectObjects>False</ProtectObjects>\r\n                                <ProtectScenarios>False</ProtectScenarios>\r\n                            </WorksheetOptions>\r\n                        </Worksheet>\r\n                    </Workbook>";
            File.WriteAllText(dialog.FileName, contents);
            MessageBox.Show("تم التصدير بنجاح");
        }
    }
}
