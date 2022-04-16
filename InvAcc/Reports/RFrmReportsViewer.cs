using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using Framework.Cache;
using Library.RepShow;
using Microsoft.Win32;
using ProShared;
using ProShared.GeneralM;
using ProShared.Stock_Data;
using SSSDateTime.Date;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace InvAcc.Forms
{
    public class RFrmReportsViewer : Form
    {
        public bool _GroupsIsPrint = false;
        private T_InfoTb _Infotb = new T_InfoTb();
        public bool Barcod_Sts = false;
        public Dictionary<long, ColumnDictinary> columns_Names_visible = new Dictionary<long, ColumnDictinary>();
        public Dictionary<string, ColumnDictinaryPassport> columns_Names_visible_Passport = new Dictionary<string, ColumnDictinaryPassport>();
        public Dictionary<string, ColumnDictinarySNation> columns_Names_visibleSNAtion = new Dictionary<string, ColumnDictinarySNation>();
        private IContainer components = null;
        private void netResize1_AfterControlResize(object sender, Softgroup.NetResize.AfterControlResizeEventArgs e)
        {
            if (e.Control.GetType() == typeof(Label))
            {
                Label c = (e.Control as Label); if ((c.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))))) && (c.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))))) && (c.BackColor != System.Drawing.Color.SteelBlue))
                    c.BackColor = Color.Transparent; Size cc = c.PreferredSize;
                c.AutoSize = false;
                c.Size = cc;

                //  e.Control.Font= new System.Drawing.Font("Tahoma",(float) (c-0.5));

            }
        }


        private void FrmInvSale_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Maximized;
        }

        private void FrmInvSale_SizeChanged(object sender, EventArgs e)
        {
            netResize1.Refresh();
        }

        public Softgroup.NetResize.NetResize netResize1;

        private CrystalReportViewer crystalReportViewe_RepShow;
        private T_Salary data_this_salary;
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
        private List<T_InfoTb> listInfotb = new List<T_InfoTb>();
        private ReportDocument MainCryRep = new ReportDocument();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private PageSetupDialog pageSetupDialog1;
        string path = Application.StartupPath + "\\Rpt\\";
        private T_User permission = new T_User();
        private PrintDialog printDialog1;
        private bool printOrderNo = false;
        private string repvalue;
        private string sqlWhere;
        public Dictionary<long, familyPassport> vFamilyPassport = new Dictionary<long, familyPassport>();

        public RFrmReportsViewer()
        {
            InitializeComponent();//this.Load += langloads;
            ids = VarGeneral.InvTyp;
        }
        int ids = 0;
        public bool BarcodSts
        {
            get
            {
                return Barcod_Sts;
            }
            set
            {
                Barcod_Sts = value;
            }
        }

        public string Repvalue
        {
            get
            {
                return repvalue;
            }
            set
            {
                repvalue = value;
            }
        }

        public string RepCashier
        {
            get
            {
                return repvalue;
            }
            set
            {
                repvalue = value;
            }
        }

        public string SqlWhere
        {
            get
            {
                return sqlWhere;
            }
            set
            {
                sqlWhere = value;
            }
        }

        private Stock_DataDataContext db
        {
            get
            {
                dbInstance = null;
               // if (dbInstance == null)
                {
                    dbInstance = new Stock_DataDataContext(VarGeneral.BranchCS); 
                }
                return dbInstance;
            }
        }

        private Rate_DataDataContext dbc
        {
            get
            {
                if (dbInstanceRate == null)
                {
                    dbInstanceRate = new Rate_DataDataContext(VarGeneral.BranchRt);
                }
                return dbInstanceRate;
            }
        }

        public T_Salary Datathis_salary
        {
            get
            {
                return data_this_salary;
            }
            set
            {
                data_this_salary = value;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.RFrmReportsViewer));
            components = new System.ComponentModel.Container();

            crystalReportViewe_RepShow = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            printDialog1 = new System.Windows.Forms.PrintDialog();
            pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            SuspendLayout();
            crystalReportViewe_RepShow.AccessibleDescription = null;
            crystalReportViewe_RepShow.AccessibleName = null;
            crystalReportViewe_RepShow.ActiveViewIndex = -1;
            resources.ApplyResources(crystalReportViewe_RepShow, "crystalReportViewe_RepShow");
            crystalReportViewe_RepShow.BackgroundImage = null;
            crystalReportViewe_RepShow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            crystalReportViewe_RepShow.Font = null;
            crystalReportViewe_RepShow.Name = "crystalReportViewe_RepShow";
            crystalReportViewe_RepShow.SelectionFormula = string.Empty;
            crystalReportViewe_RepShow.ViewTimeSelectionFormula = string.Empty;
            printDialog1.UseEXDialog = true;
            base.AccessibleDescription = null;
            base.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundImage = null;
            base.Controls.Add(crystalReportViewe_RepShow);
            Font = null;
            base.KeyPreview = true;
            base.Name = "RFrmReportsViewer";
            base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            base.Load += new System.EventHandler(RFrmReportsViewer_Load);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Frm_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(Frm_KeyDown);
            ResumeLayout(false);
        }

        private void Frm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(RFrmReportsViewer));
                if (base.Parent.RightToLeft == RightToLeft.Yes)
                {
                    Language.ChangeLanguage("ar-SA", this, resources);
                }
                else
                {
                    Language.ChangeLanguage("en", this, resources);
                }
            }
        }

        public static void PrintSetFsOut(FastReport.Report rpt, int vLines, PaperOrientation vType, string vPeaperNm, int vReplay, string _PrintNm, double _mergBottom, double _mergleft, double _mergRight, double _mergTop)
        {

            PrintDocument prnt_doc = new PrintDocument();
            string _PrinterName = prnt_doc.PrinterSettings.PrinterName;
            try
            {
                prnt_doc.PrinterSettings.PrinterName = _PrintNm;
                if (!prnt_doc.PrinterSettings.IsValid)
                {
                    rpt.PrintSettings.Printer = _PrinterName;
                }
                else
                {
                    rpt.PrintSettings.Printer = _PrintNm;
                }
            }
            catch
            {
                rpt.PrintSettings.Printer = _PrinterName;
            }
            //rpt.PrintSettings.PaperOrientation = vType;
            try
            {
                //    rpt.PrintSettings.PaperSource = ((!string.IsNullOrEmpty(vPeaperNm)) ? vPaperSize(rpt.PrintSettings.Printer, vPeaperNm) : CrystalDecisions.Shared.PaperSize.DefaultPaperSize);
            }
            catch
            {
                try
                {
                    //      rpt.PrintSettings.PaperSource = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                }
                catch
                {
                }
            }
            if (vLines > 0)
            {
                rpt.SetParameterValue("vSts", true);
            }
            try
            {
                if (vReplay < 1)
                {
                    vReplay = 1;
                }
            }
            catch
            {
                vReplay = 1;
            }
            FastReport.ReportPage margins = (FastReport.ReportPage)rpt.Pages[0];
            margins.BottomMargin = (int)_mergBottom;
            margins.LeftMargin = (int)_mergleft;
            margins.RightMargin = (int)_mergRight;
            margins.TopMargin = (int)_mergTop;

            for (int i = 0; i < vReplay; i++)
            {
                rpt.Prepare();
                rpt.Print();

            }
        }
        private void PrintSet(ReportDocument rpt, int vLines, PaperOrientation vType, string vPeaperNm, int vReplay, string _PrintNm, double _mergBottom, double _mergleft, double _mergRight, double _mergTop)
        {
            setpagesetting(rpt);
            //      try { rpt.SetParameterValue("CATPrint", "False"); } catch { }
            TopMost = false;
            Hide();
            string ntyp = "";


            T_Printer _Invsetting = db.StockPrinterSetting(VarGeneral.UserID, ids);
            if (VarGeneral.IsGeneralUsed)
            {
                vLines = (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value;
                vType = (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape;
                vPeaperNm = VarGeneral.GeneralPrinter.defSizePaper_Setting;
                vReplay = VarGeneral.GeneralPrinter.DefLines_Setting.Value;
                _PrintNm = VarGeneral.GeneralPrinter.defPrn_Setting;
                _mergBottom = VarGeneral.GeneralPrinter.hAs_Setting.Value;
                _mergleft = VarGeneral.GeneralPrinter.hYs_Setting.Value;
                _mergRight = VarGeneral.GeneralPrinter.hYm_Setting.Value;
                _mergTop = VarGeneral.GeneralPrinter.hAl_Setting.Value;

            }
            else
            {
                vLines = (int)_Invsetting.lnPg.Value;
                vType = (_Invsetting.Orientation == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape;
                vPeaperNm = _Invsetting.defSizePaper;
                vReplay = _Invsetting.DefLines.Value;
                _PrintNm = _Invsetting.defPrn;
                _mergBottom = _Invsetting.hAs.Value;
                _mergleft = _Invsetting.hYs.Value;
                _mergRight = _Invsetting.hYm.Value;
                _mergTop = _Invsetting.hAl.Value;


            }


            PrintDocument prnt_doc = new PrintDocument();
            string _PrinterName = prnt_doc.PrinterSettings.PrinterName;
            try
            {
                prnt_doc.PrinterSettings.PrinterName = _PrintNm;
                if (!prnt_doc.PrinterSettings.IsValid)
                {
                    rpt.PrintOptions.PrinterName = _PrinterName;
                }
                else
                {
                    rpt.PrintOptions.PrinterName = _PrintNm;
                }

            }
            catch
            {
                rpt.PrintOptions.PrinterName = _PrinterName;
            }
            try
            {
                if (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Substring(14) + "\\" + Environment.UserName + "\\" + repvalue + ".txt"))
                {
                    FileInfo file = new FileInfo(Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Substring(14) + "\\" + Environment.UserName + "\\" + repvalue + ".txt");
                    FileStream fsToRead = file.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                    StreamReader sr = new StreamReader(fsToRead);
                    string _printNameOnline = sr.ReadToEnd();
                    sr.Close();
                    if (!string.IsNullOrEmpty(_printNameOnline))
                    {
                        List<string> _ListPrinter = new List<string>();
                        if (PrinterSettings.InstalledPrinters.Count != 0)
                        {
                            for (int iiCnt = 0; iiCnt < PrinterSettings.InstalledPrinters.Count; iiCnt++)
                            {
                                _ListPrinter.Add(PrinterSettings.InstalledPrinters[iiCnt]);
                            }
                        }
                        if (_ListPrinter.Count > 0)
                        {
                            for (int iiCnt = 0; iiCnt < _ListPrinter.Count; iiCnt++)
                            {
                                if (_ListPrinter[iiCnt].StartsWith(_printNameOnline) && _ListPrinter[iiCnt].Contains("#"))
                                {
                                    rpt.PrintOptions.PrinterName = _ListPrinter[iiCnt];
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            rpt.PrintOptions.PaperOrientation = vType;
            try
            {
                rpt.PrintOptions.PaperSize = ((!string.IsNullOrEmpty(vPeaperNm)) ? vPaperSize(rpt.PrintOptions.PrinterName, vPeaperNm) : CrystalDecisions.Shared.PaperSize.DefaultPaperSize);
            }
            catch
            {
                try
                {
                    rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                }
                catch
                {
                }

            }


            if (vLines > 0)
            {
                rpt.SetParameterValue("vSts", true);
            }
            try
            {
                if (vReplay < 1)
                {
                    vReplay = 1;
                }
            }
            catch
            {
                vReplay = 1;
            }

            PageMargins margins = rpt.PrintOptions.PageMargins;
            margins.bottomMargin = (int)_mergBottom;
            margins.leftMargin = (int)_mergleft;
            margins.rightMargin = (int)_mergRight;
            margins.topMargin = (int)_mergTop;
            try
            {
                rpt.PrintOptions.ApplyPageMargins(margins);
            }
            catch
            {

            }
            if ((VarGeneral.GeneralPrinter.ISCashierType && VarGeneral.IsGeneralUsed) || (_Invsetting.ISCashierType && !VarGeneral.IsGeneralUsed) || repvalue.ToLower().Contains("cashi"))
                rpt.PrintOptions.DissociatePageSizeAndPrinterPaperSize = false;
            if (vLines > 0)
            {
            //   rpt.SetParameterValue("vSts", true);
            }
            for (int i = 0; i < vReplay; i++)
            {
                try
                {
                    rpt.PrintToPrinter(1, collated: false, 0, 0);

                }
                catch (Exception ex)
                {

                    try
                    {
                        if ((VarGeneral.GeneralPrinter.ISCashierType && VarGeneral.IsGeneralUsed) || (_Invsetting.ISA4PaperType && !VarGeneral.IsGeneralUsed) || repvalue.ToLower().Contains("cashi"))

                            rpt.PrintOptions.DissociatePageSizeAndPrinterPaperSize = false;

                        rpt.PrintToPrinter(1, collated: false, 0, 0);
                    }
                    catch (Exception ddex)
                    { }
                }
            }
        }

        private CrystalDecisions.Shared.PaperSize vPaperSize(string vPrinterName, string vPeaperNm)
        {

            try
            {
                PrintDocument doctoprint = new PrintDocument();
                doctoprint.PrinterSettings.PrinterName = vPrinterName;
                int rawKind = 0;
                for (int i = 0; i <= doctoprint.PrinterSettings.PaperSizes.Count - 1; i++)
                {
                    if (doctoprint.PrinterSettings.PaperSizes[i].PaperName == vPeaperNm) // "LXP : Your Page Size"
                    {
                        rawKind = Convert.ToInt32(doctoprint.PrinterSettings.PaperSizes[i].GetType().GetField
                         ("kind",
                        System.Reflection.BindingFlags.Instance |
                        System.Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes[i]));
                        break;
                    }

                }

                return (CrystalDecisions.Shared.PaperSize)rawKind;
            }
            catch
            {
                return CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
            }
        }

        private int vStr(int vTy)
        {
            if (VarGeneral.InvTyp == 1 || VarGeneral.InvTyp == 21)
            {
                if (VarGeneral._IsPOS || VarGeneral._IsWaiter)
                {
                    return 27;
                }
                return 1;
            }
            if (VarGeneral.InvTyp == 1)
            {
                return 1;
            }
            if (VarGeneral.InvTyp == 2)
            {
                return 5;
            }
            if (VarGeneral.InvTyp == 3)
            {
                return 3;
            }
            if (VarGeneral.InvTyp == 4)
            {
                return 7;
            }
            if (VarGeneral.InvTyp == 7)
            {
                return 9;
            }
            if (VarGeneral.InvTyp == 8)
            {
                return 11;
            }
            if (VarGeneral.InvTyp == 9)
            {
                return 13;
            }
            if (VarGeneral.InvTyp == 14)
            {
                return 15;
            }
            if (VarGeneral.InvTyp == 5)
            {
                return 17;
            }
            if (VarGeneral.InvTyp == 6)
            {
                return 19;
            }
            if (VarGeneral.InvTyp == 17)
            {
                return 21;
            }
            if (VarGeneral.InvTyp == 20)
            {
                return 23;
            }
            return 25;
        }

        public string AddQuotesIfRequired(string path)
        {
            return "@" + path;
        }
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        private void SetDBLogonForReport(ConnectionInfo connectionInfo, ReportDocument reportDocument)
        {
            Tables tables = reportDocument.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table table in tables)
            {
                TableLogOnInfo tableLogonInfo = table.LogOnInfo;
                tableLogonInfo.ConnectionInfo = connectionInfo;
                table.ApplyLogOnInfo(tableLogonInfo);
            }
        }int KKS = 0;
        ReportDocument getdoc(string name)
        {
            string n = string.Empty;
            for (int i = 7; i < name.Length; i++)
                if (name[i] == '.')
                    n += "\\";
                else
                    n += name[i];
            n += ".rpt";
            MainCryRep = new ReportDocument();
            string spath = Path.GetFullPath(path + n);
            MainCryRep.Load(spath);
            if(spath.Contains("RepInvSal.rpt")|| spath.Contains("RepInvPurchase.rpt") || spath.Contains("RepInvCustQutation.rpt") ||
                spath.Contains("RepInvPurchaseReturn.rpt") || spath.Contains("RepInvSalReturn.rpt"))
            {
                KKS = 10;
            }
            MainCryRep.PrintOptions.DissociatePageSizeAndPrinterPaperSize = true;

          
            try
            {
                Image j = Utilites.generate(FrmReportsViewer.QRCodeData);
                DataTable dt = VarGeneral.RepData.Tables[0].Clone();
                dt.Rows.Clear();
                DataRow r = dt.NewRow();
                j.Save(Application.StartupPath + "\\qrcode.jpg");
                FileStream fr = new FileStream(Application.StartupPath + "\\qrcode.jpg", FileMode.Open);
                BinaryReader br = new BinaryReader(fr);
                Byte[] im = new Byte[fr.Length];
                im = br.ReadBytes(Convert.ToInt32((fr.Length)));


                r["LogImg"] = im;
                dt.Rows.Add(r);
                dt.TableName = "Table";
                MainCryRep.Database.Tables["Table"].SetDataSource(dt);
            }
            catch
            {

            }
            try
            {
                if (VarGeneral.Export_Bill_Name != "")
                {
                    MainCryRep.SummaryInfo.ReportTitle = VarGeneral.Export_Bill_Name;
                    VarGeneral.Export_Bill_Name = "";
                }
            }
            catch { }
            setHeaderDetailsCoputation();
            return MainCryRep;

        }
        public static ReportDocument addqrcode(ReportDocument MainCryRep)

        {
            try
            {
                Image j = Utilites.generate(FrmReportsViewer.QRCodeData);
                DataTable dt = VarGeneral.RepData.Tables[0].Clone();
                dt.Rows.Clear();
                DataRow r = dt.NewRow();
                j.Save(Application.StartupPath + "\\qrcode.jpg");
                FileStream fr = new FileStream(Application.StartupPath + "\\qrcode.jpg", FileMode.Open);
                BinaryReader br = new BinaryReader(fr);
                Byte[] im = new Byte[fr.Length];
                im = br.ReadBytes(Convert.ToInt32((fr.Length)));


                r["LogImg"] = im;
                dt.Rows.Add(r);
                dt.TableName = "Table";
                MainCryRep.Database.Tables["Table"].SetDataSource(dt);
            }
            catch
            {

            }
            return MainCryRep;
        }
        public static FastReport.Report addqrcode(FastReport.Report MainCryRep)

        {
            try
            {
                Image j = Utilites.generate(FrmReportsViewer.QRCodeData);
                DataTable dt = VarGeneral.RepData.Tables[0].Clone();
                dt.Rows.Clear();
                DataRow r = dt.NewRow();
                j.Save(Application.StartupPath + "\\qrcode.jpg");
                FileStream fr = new FileStream(Application.StartupPath + "\\qrcode.jpg", FileMode.Open);
                BinaryReader br = new BinaryReader(fr);
                Byte[] im = new Byte[fr.Length];
                im = br.ReadBytes(Convert.ToInt32((fr.Length)));


                (MainCryRep.FindObject("QRcodePic") as FastReport.PictureObject).Image = j;
                (MainCryRep.FindObject("QRcodePic") as FastReport.PictureObject).SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch
            {

            }
            return MainCryRep;

        }


        ReportDocument getdoc2(string name)
        {
            string n = string.Empty;

            n += ".rpt";
            MainCryRep = new ReportDocument();
            string spath = Path.GetFullPath(path + n);
            MainCryRep.Load(spath);
            return MainCryRep;
        }
        void hidmcoluns2(ReportDocument rpt)
        {

            rpt.ReportDefinition.ReportObjects["Line22"].ObjectFormat.EnableSuppress = true; 
            rpt.ReportDefinition.ReportObjects["Text28"].ObjectFormat.EnableSuppress = true;
            try
            {
                rpt.ReportDefinition.ReportObjects["Text40"].ObjectFormat.EnableSuppress = true;
                rpt.ReportDefinition.ReportObjects["Line13"].ObjectFormat.EnableSuppress = true;


            }
            catch
            {
            }
            rpt.ReportDefinition.ReportObjects["DatExper1"].ObjectFormat.EnableSuppress = true;
            try
            {
                rpt.ReportDefinition.ReportObjects["Line22t"].ObjectFormat.EnableSuppress = true;
            }
            catch
            {
            }
            rpt.ReportDefinition.ReportObjects["Text7"].Width = 1700;
            rpt.ReportDefinition.ReportObjects["Amount1"].Width = 1700;
            rpt.ReportDefinition.ReportObjects["Text7"].Left = 170;
         //   rpt.ReportDefinition.ReportObjects["Text32"].Left = 170;
            rpt.ReportDefinition.ReportObjects["Amount1"].Left = 170;
        }
        void hidmcoluns(ReportDocument rpt)
        {
            rpt.ReportDefinition.ReportObjects["Line3"].ObjectFormat.EnableSuppress = true; 
            rpt.ReportDefinition.ReportObjects["Text29"].ObjectFormat.EnableSuppress = true;
            try
            {
                rpt.ReportDefinition.ReportObjects["Text41"].ObjectFormat.EnableSuppress = true;
                rpt.ReportDefinition.ReportObjects["Line14"].ObjectFormat.EnableSuppress = true;
            }
            catch
            {
            }
            rpt.ReportDefinition.ReportObjects["RunCod1"].ObjectFormat.EnableSuppress = true;
            try
            {
                rpt.ReportDefinition.ReportObjects["Line3t"].ObjectFormat.EnableSuppress = true;
            }
            catch
            {
            }

            rpt.ReportDefinition.ReportObjects["Text28"].Width = 1632;
            rpt.ReportDefinition.ReportObjects["Text40"].Width = 1632;
            rpt.ReportDefinition.ReportObjects["Text28"].Left = 1156;
            rpt.ReportDefinition.ReportObjects["Text40"].Left = 1156;
        }
        void setpagesetting(ReportDocument rpt)
        {
            int vLines; PaperOrientation vType; string vPeaperNm; int vReplay; string _PrintNm;
            double _mergBottom;
            double _mergleft; double _mergRight;
            double _mergTop;
            if (KKS == 10)
            {
                string s = new Stock_DataDataContext(VarGeneral.BranchCS).SystemSettingStock().Seting;

                try
                {
                    if (VarGeneral.TString.ChkStatShow(s, 91))
                        MainCryRep.SetParameterValue("RepeateHeader", "True");
                    else
                        MainCryRep.SetParameterValue("RepeateHeader", "False");

                }
                catch
                {

                }
                int kk = 0;
                if (VarGeneral.TString.ChkStatShow(db.SystemSettingStock().Seting, 92) == true)
                {
                    foreach (DataRow r in VarGeneral.RepData.Tables[0].Rows)
                    {
                        try
                        {
                            if (r["RunCod"] == "") kk++;

                        }
                        catch
                        {

                        }
                    }
                    if (VarGeneral.RepData.Tables[0].Rows.Count - 1 == kk)
                        hidmcoluns(rpt);
                }
                if (VarGeneral.TString.ChkStatShow(db.SystemSettingStock().Seting, 91))
                {
                    kk = 0;
                    foreach (DataRow r in VarGeneral.RepData.Tables[0].Rows)
                    {
                        try
                        {
                            if (r["DatExper"] == "") kk++;

                        }
                        catch
                        {

                        }
                    }
                    if (VarGeneral.RepData.Tables[0].Rows.Count - 1 == kk)
                        hidmcoluns2(rpt);
                }
                try
                {
                    if (VarGeneral.TString.ChkStatShow(s, 92))
                        MainCryRep.SetParameterValue("RepeatTail", "True");
                    else
                        MainCryRep.SetParameterValue("RepeatTail", "False");

                }
                catch
                {

                }

                try
                {
                        if (!VarGeneral.TString.ChkStatShow(s, 90))
                        MainCryRep.SetParameterValue("ShowBalance", "True");
                    else
                        MainCryRep.SetParameterValue("ShowBalance", "False");


                }
                catch { }
            }
            string ntyp = "";
            T_Printer _Invsetting = db.StockPrinterSetting(VarGeneral.UserID, ids);
            if (VarGeneral.IsGeneralUsed)
            {
                vLines = (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value;
                vType = (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape;
                vPeaperNm = VarGeneral.GeneralPrinter.defSizePaper_Setting;
                vReplay = VarGeneral.GeneralPrinter.DefLines_Setting.Value;
                _PrintNm = VarGeneral.GeneralPrinter.defPrn_Setting;
                _mergBottom = VarGeneral.GeneralPrinter.hAs_Setting.Value;
                _mergleft = VarGeneral.GeneralPrinter.hYs_Setting.Value;
                _mergRight = VarGeneral.GeneralPrinter.hYm_Setting.Value;
                _mergTop = VarGeneral.GeneralPrinter.hAl_Setting.Value;

            }
            else
            {

                vLines = (int)_Invsetting.lnPg.Value;
                vType = (_Invsetting.Orientation == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape;
                vPeaperNm = _Invsetting.defSizePaper;
                vReplay = _Invsetting.DefLines.Value;
                _PrintNm = _Invsetting.defPrn;
                _mergBottom = _Invsetting.hAs.Value;
                _mergleft = _Invsetting.hYs.Value;
                _mergRight = _Invsetting.hYm.Value;
                _mergTop = _Invsetting.hAl.Value;


            }

            PrintDocument prnt_doc = new PrintDocument();
            string _PrinterName = prnt_doc.PrinterSettings.PrinterName;
            try
            {
                prnt_doc.PrinterSettings.PrinterName = _PrintNm;
                if (!prnt_doc.PrinterSettings.IsValid)
                {
                    rpt.PrintOptions.PrinterName = _PrinterName;
                }
                else
                {
                    rpt.PrintOptions.PrinterName = _PrintNm;
                }

            }
            catch
            {
                rpt.PrintOptions.PrinterName = _PrinterName;
            }
            try
            {
                if (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Substring(14) + "\\" + Environment.UserName + "\\" + repvalue + ".txt"))
                {
                    FileInfo file = new FileInfo(Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Substring(14) + "\\" + Environment.UserName + "\\" + repvalue + ".txt");
                    FileStream fsToRead = file.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                    StreamReader sr = new StreamReader(fsToRead);
                    string _printNameOnline = sr.ReadToEnd();
                    sr.Close();
                    if (!string.IsNullOrEmpty(_printNameOnline))
                    {
                        List<string> _ListPrinter = new List<string>();
                        if (PrinterSettings.InstalledPrinters.Count != 0)
                        {
                            for (int iiCnt = 0; iiCnt < PrinterSettings.InstalledPrinters.Count; iiCnt++)
                            {
                                _ListPrinter.Add(PrinterSettings.InstalledPrinters[iiCnt]);
                            }
                        }
                        if (_ListPrinter.Count > 0)
                        {
                            for (int iiCnt = 0; iiCnt < _ListPrinter.Count; iiCnt++)
                            {
                                if (_ListPrinter[iiCnt].StartsWith(_printNameOnline) && _ListPrinter[iiCnt].Contains("#"))
                                {
                                    rpt.PrintOptions.PrinterName = _ListPrinter[iiCnt];
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            rpt.PrintOptions.PaperOrientation = vType;
            try
            {
                rpt.PrintOptions.PaperSize = ((!string.IsNullOrEmpty(vPeaperNm)) ? vPaperSize(rpt.PrintOptions.PrinterName, vPeaperNm) : CrystalDecisions.Shared.PaperSize.DefaultPaperSize);
            }
            catch
            {
                try
                {
                    rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                }
                catch
                {
                }

            }


            if (vLines > 0)
            {
            //    rpt.SetParameterValue("vSts", true);
            }
            try
            {
                if (vReplay < 1)
                {
                    vReplay = 1;
                }
            }
            catch
            {
                vReplay = 1;
            }
            PageMargins margins = rpt.PrintOptions.PageMargins;
            margins.bottomMargin = (int)_mergBottom;
            margins.leftMargin = (int)_mergleft;
            margins.rightMargin = (int)_mergRight;
            margins.topMargin = (int)_mergTop;
            try
            {
                rpt.PrintOptions.ApplyPageMargins(margins);
            }
            catch
            {

            }
           
            if ((VarGeneral.GeneralPrinter.ISCashierType && VarGeneral.IsGeneralUsed) || (_Invsetting.ISCashierType && !VarGeneral.IsGeneralUsed) || repvalue.ToLower().Contains("cashi"))
                rpt.PrintOptions.DissociatePageSizeAndPrinterPaperSize = false;
            crystalReportViewe_RepShow.ReportSource = rpt;
        }

        void Repitems()
        {
            if (repvalue == "ItemsData")
            {
                if (VarGeneral.InvType == 1)
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        if (VarGeneral.GeneralPrinter.ISA4PaperType)
                        {
                            if (VarGeneral.itmDes == "OtherPrice")
                            {
                                MainCryRep = getdoc("InvAcc.Reports.RepItemsWithPrices");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.Reports.RepItems");
                            }
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsCasheir.RepItems");
                            //MainCryRep =getdoc("ReportDocument();
                            //string  spath = Path.GetFullPath(path + "ReportsCasheir\\RepItems.rpt");
                            // MainCryRep.Load(spath);
                        }
                    }
                    else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        if (VarGeneral.itmDes == "OtherPrice")
                        {
                            MainCryRep = getdoc("InvAcc.ReportsE.RepItemsWithPrices");
                            //  ReportsCasheir
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsE.RepItems");
                        }
                    }
                    else
                    {
                        MainCryRep = new ReportDocument();
                        string spath = Path.GetFullPath(path + "ReportsCasheirE\\RepItems.rpt");
                        MainCryRep.Load(spath);
                    }
                    ReportDocument rpt = MainCryRep;
                    rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
               setTarwisaa(rpt);try
                    {
                        (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                    }
                    catch
                    {
                    }
                    try
                    {
                        (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                    }
                    catch
                    {
                    }
                    try
                    {
                        if (VarGeneral.itmDes == "OtherPrice" && File.Exists(Application.StartupPath + "\\\\Script\\\\SecriptGlasses.dll"))
                        {
                            (rpt.ReportDefinition.ReportObjects["TextCat"] as TextObject).Text = "AYIS";
                            (rpt.ReportDefinition.ReportObjects["TextMnd"] as TextObject).Text = "CYL";
                            (rpt.ReportDefinition.ReportObjects["TextDistributor"] as TextObject).Text = "SPH";
                            (rpt.ReportDefinition.ReportObjects["TextWholeSale"] as TextObject).Text = "AYIS";
                            (rpt.ReportDefinition.ReportObjects["TextRetail"] as TextObject).Text = "CYL";
                            (rpt.ReportDefinition.ReportObjects["TextOther"] as TextObject).Text = "SPH";
                        }
                    }
                    catch
                    {
                    }
                    if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                    {
                        rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                    }
                    else
                    {
                        rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                    }
                    rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                    rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                    rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                    rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                    rpt.SetParameterValue("vSts", false);
                    rpt.SetParameterValue("vLines", 1);
                    rpt.SetParameterValue("vSts", false);
                    if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                    {
                        PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                    }
                    else
                    {
                        setpagesetting(rpt);
                    }
                }
                else if (VarGeneral.InvType == 2)
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        if (VarGeneral.GeneralPrinter.ISA4PaperType)
                        {
                            MainCryRep = getdoc("InvAcc.Reports.RepItemsQuantity");
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsCasheir.RepItemsQuantity");
                        }
                    }
                    else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.ReportsE.RepItemsQuantity");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepItemsQuantity");
                    }
                    ReportDocument rpt = MainCryRep;
                    rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
               setTarwisaa(rpt);try
                    {
                        (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                    }
                    catch
                    {
                    }
                    try
                    {
                        (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                    }
                    catch
                    {
                    }
                    if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                    {
                        rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                    }
                    else
                    {
                        rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                    }
                    rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                    rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                    rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                    rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                    rpt.SetParameterValue("vSts", false);
                    rpt.SetParameterValue("vLines", 1);
                    if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                    {
                        PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                    }
                    else
                    {
                        setpagesetting(rpt);
                    }
                }
                else if (VarGeneral.InvType == 3)
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        if (VarGeneral.GeneralPrinter.ISA4PaperType)
                        {
                            MainCryRep = getdoc("InvAcc.Reports.RepItemsCost");
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsCasheir.RepItemsCost");
                        }
                    }
                    else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.ReportsE.RepItemsCost");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepItemsCost");
                    }
                    ReportDocument rpt = MainCryRep;
                    rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
               setTarwisaa(rpt);try
                    {
                        (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                    }
                    catch
                    {
                    }
                    try
                    {
                        (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                    }
                    catch
                    {
                    }
                    try
                    {
                        (rpt.ReportDefinition.ReportObjects["CustHeaderX"] as TextObject).Text = VarGeneral.Customerlbl;
                    }
                    catch
                    {
                    }
                    try
                    {
                        if (VarGeneral.InvType == 3)
                        {
                            (rpt.ReportDefinition.ReportObjects["Text10"] as TextObject).Text = VarGeneral.Customerlbl;
                        }
                    }
                    catch
                    {
                    }
                    if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                    {
                        rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                    }
                    else
                    {
                        rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                    }
                    rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                    rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                    rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                    rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                    rpt.SetParameterValue("vSts", false);
                    rpt.SetParameterValue("vLines", 1);
                    if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                    {
                        PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                    }
                    else
                    {
                        setpagesetting(rpt);
                    }
                }
                else if (VarGeneral.InvType == 4)
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        if (VarGeneral.GeneralPrinter.ISA4PaperType)
                        {
                            MainCryRep = getdoc("InvAcc.Reports.RepItemsImport");
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsCasheir.RepItemsImport");
                        }
                    }
                    else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.ReportsE.RepItemsImport");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepItemsImport");
                    }
                    ReportDocument rpt = MainCryRep;
                    rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
               setTarwisaa(rpt);try
                    {
                        (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                    }
                    catch
                    {
                    }
                    try
                    {
                        (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                    }
                    catch
                    {
                    }
                    if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                    {
                        rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                    }
                    else
                    {
                        rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                    }
                    rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                    rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                    rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                    rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                    rpt.SetParameterValue("vSts", false);
                    rpt.SetParameterValue("vLines", 1);
                    if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                    {
                        PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                    }
                    else
                    {
                        setpagesetting(rpt);
                    }
                }
                else if (VarGeneral.InvType == 5)
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        if (VarGeneral.GeneralPrinter.ISA4PaperType)
                        {
                            MainCryRep = getdoc("InvAcc.Reports.RepItemsQuantity");
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsCasheir.RepItemsQuantity");
                        }
                    }
                    else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.ReportsE.RepItemsQuantity");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepItemsQuantity");
                    }
                    ReportDocument rpt = MainCryRep;
                    rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
               setTarwisaa(rpt);try
                    {
                        (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                    }
                    catch
                    {
                    }
                    try
                    {
                        (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                    }
                    catch
                    {
                    }
                    if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                    {
                        rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                    }
                    else
                    {
                        rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                    }
                    rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                    rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                    rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                    rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                    rpt.SetParameterValue("vSts", false);
                    rpt.SetParameterValue("vLines", 1);
                    if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                    {
                        PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                    }
                    else
                    {
                        setpagesetting(rpt);
                    }
                }
                else if (VarGeneral.InvType == 999)
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        if (VarGeneral.GeneralPrinter.ISA4PaperType)
                        {
                            MainCryRep = getdoc("InvAcc.Reports.RepItemsQuantityExpir");
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsCasheir.RepItemsQuantityExpir");
                        }
                    }
                    else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.ReportsE.RepItemsQuantityExpir");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepItemsQuantityExpir");
                    }
                    ReportDocument rpt = MainCryRep;
                    rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
               setTarwisaa(rpt);try
                    {
                        (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                    }
                    catch
                    {
                    }
                    try
                    {
                        (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                    }
                    catch
                    {
                    }
                    if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                    {
                        rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                    }
                    else
                    {
                        rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                    }
                    rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                    rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                    rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                    rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                    rpt.SetParameterValue("vSts", false);
                    rpt.SetParameterValue("vLines", 1);
                    if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                    {
                        PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                    }
                    else
                    {
                        setpagesetting(rpt);
                    }
                }
            }
        }

        private void RFrmReportsViewer_Load(object sender, EventArgs e)
        {
            Program.min();
            ids = VarGeneral.InvTyp;
            ComponentResourceManager resources = new ComponentResourceManager(typeof(RFrmReportsViewer));
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                Language.ChangeLanguage("ar-SA", this, resources);
            }
            else
            {
                Language.ChangeLanguage("en", this, resources);
            }

            try
            {
              
                _Proceess();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        public void segment1()
        {
            //	permission = dbc.Get_PermissionID(VarGeneral.UserID);
            try
            {
                if (!Directory.Exists(Application.StartupPath + "\\Reps"))
                {
                    Directory.CreateDirectory(Application.StartupPath + "\\Reps");
                }
            }
            catch
            {
            }
            try
            {
                if (!Directory.Exists(Application.StartupPath + "\\RepsE"))
                {
                    Directory.CreateDirectory(Application.StartupPath + "\\RepsE");
                }
            }
            catch
            {
            }
            try
            {
                if (VarGeneral.vDemo)
                {
                    crystalReportViewe_RepShow.ShowPrintButton = false;
                    crystalReportViewe_RepShow.ShowExportButton = false;
                }
                MainCryRep = new ReportDocument();
#pragma warning disable CS0168 // The variable 'num' is declared but never used
                int num;
#pragma warning restore CS0168 // The variable 'num' is declared but never used
#pragma warning disable CS0168 // The variable 'num2' is declared but never used
                int num2;
#pragma warning restore CS0168 // The variable 'num2' is declared but never used
                if (repvalue == "ItemsData\u064fExpir")
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        if (VarGeneral.GeneralPrinter.ISA4PaperType)
                        {
                            MainCryRep = getdoc("InvAcc.Reports.RepItemsExpir");
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsCasheir.RepItemsExpir");
                        }
                    }
                    else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.ReportsE.RepItemsExpir");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepItemsExpir");
                    }
                    ReportDocument rpt = MainCryRep;
                    rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
               setTarwisaa(rpt);try
                    {
                        (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                    }
                    catch
                    {
                    }
                    try
                    {
                        (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                    }
                    catch
                    {
                    }
                    if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                    {
                        rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                    }
                    else
                    {
                        rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                    }
                    rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                    rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                    rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                    rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                    rpt.SetParameterValue("vSts", false);
                    rpt.SetParameterValue("vLines", 1);
                    if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                    {
                        PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                    }
                    else
                    {
                        setpagesetting(rpt);
                    }
                }

                else
                {
                    int? orientationSetting = VarGeneral.Settings_Sys.AutoEmp;
#pragma warning disable CS0168 // The variable 'flag1' is declared but never used
#pragma warning disable CS0168 // The variable 'flag2' is declared but never used
                    bool flag1, flag2;
#pragma warning restore CS0168 // The variable 'flag2' is declared but never used
#pragma warning restore CS0168 // The variable 'flag1' is declared but never used
                    if (repvalue == "PaymentOrder")
                    {
                        T_Printer _InvSetting = new T_Printer();
                        _InvSetting = db.StockPrinterSetting(VarGeneral.UserID, VarGeneral.InvTyp);
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            try
                            {
                                if (VarGeneral.gUserName == "runsetting")
                                {
                                    if (File.Exists(Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepPaymentOrder.rpt"))
                                    {
                                        MainCryRep.FileName = Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepPaymentOrder.rpt";
                                        addqrcode(MainCryRep);
                                    }
                                    else
                                    {
                                        MainCryRep = getdoc("InvAcc.Reports.RepPaymentOrder");
                                    }
                                }
                                else if (File.Exists(Application.StartupPath + "\\Reps\\RepPaymentOrder.rpt"))
                                {
                                    MainCryRep.FileName = Application.StartupPath + "\\Reps\\RepPaymentOrder.rpt";
                                    addqrcode(MainCryRep);
                                }
                                else
                                {
                                    MainCryRep = getdoc("InvAcc.Reports.RepPaymentOrder");
                                }
                            }
                            catch
                            {
                                MainCryRep = getdoc("InvAcc.Reports.RepPaymentOrder");
                            }
                        }
                        else
                        {
                            try
                            {
                                if (VarGeneral.gUserName == "runsetting")
                                {
                                    if (File.Exists(Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepPaymentOrder.rpt"))
                                    {
                                        MainCryRep.FileName = Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepPaymentOrder.rpt";
                                        addqrcode(MainCryRep);
                                    }
                                    else
                                    {
                                        MainCryRep = getdoc("InvAcc.ReportsE.RepPaymentOrder");
                                    }
                                }
                                else if (File.Exists(Application.StartupPath + "\\RepsE\\RepPaymentOrder.rpt"))
                                {
                                    MainCryRep.FileName = Application.StartupPath + "\\RepsE\\RepPaymentOrder.rpt";
                                    addqrcode(MainCryRep);
                                }
                                else
                                {
                                    MainCryRep = getdoc("InvAcc.ReportsE.RepPaymentOrder");
                                }
                            }
                            catch
                            {
                                MainCryRep = getdoc("InvAcc.ReportsE.RepPaymentOrder");
                            }
                        }
                        ReportDocument rpt = MainCryRep;
                        string vUsrNmA = string.Empty;
                        string vBranchNmA = string.Empty;
                        string vUsrNmE = string.Empty;
                        string vBranchNmE = string.Empty;
                        try
                        {
                            vUsrNmA = VarGeneral.RepData.Tables[0].Rows[0]["UsrNamA"].ToString();
                        }
                        catch
                        {
                            vUsrNmA = string.Empty;
                        }
                        try
                        {
                            vUsrNmE = VarGeneral.RepData.Tables[0].Rows[0]["UsrNamE"].ToString();
                        }
                        catch
                        {
                            vUsrNmE = string.Empty;
                        }
                        try
                        {
                            vBranchNmA = VarGeneral.RepData.Tables[0].Rows[0]["Branch_Name"].ToString();
                        }
                        catch
                        {
                            vBranchNmA = string.Empty;
                        }
                        try
                        {
                            vBranchNmE = VarGeneral.RepData.Tables[0].Rows[0]["Branch_NameE"].ToString();
                        }
                        catch
                        {
                            vBranchNmE = string.Empty;
                        }
                        VarGeneral.RepData.Tables[0].Rows[0].Delete();
                        rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                   setTarwisaa(rpt);try
                        {
                            if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16))
                            {
                                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                                {
                                    rpt.ReportDefinition.Sections[3].ReportObjects["Line7"].ObjectFormat.EnableSuppress = true; rpt.ReportDefinition.Sections[3].ReportObjects["Text12"].ObjectFormat.EnableSuppress = true;
 try{ 
rpt.ReportDefinition.Sections[3].ReportObjects["Text33"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.Sections[3].ReportObjects["Line25"].ObjectFormat.EnableSuppress = true;
                                   
}catch{}
                                    rpt.ReportDefinition.Sections[3].ReportObjects["Text27"].Width = 1496;
                                    rpt.ReportDefinition.Sections[3].ReportObjects["SerialKey1"].Width = 1496;
                                    rpt.ReportDefinition.Sections[3].ReportObjects["Text27"].Left = 6494;
                                    rpt.ReportDefinition.Sections[3].ReportObjects["SerialKey1"].Left = 6494;
                                    try
                                    {
                                        rpt.ReportDefinition.Sections[3].ReportObjects["Line7t"].ObjectFormat.EnableSuppress = true;
rpt.ReportDefinition.Sections[3].ReportObjects["StoreNo1"].ObjectFormat.EnableSuppress = true;}
                                    catch
                                    {
                                    }
                                }
                                else
                                {
                                    rpt.ReportDefinition.Sections[3].ReportObjects["Line7"].ObjectFormat.EnableSuppress = true; rpt.ReportDefinition.Sections[3].ReportObjects["Text12"].ObjectFormat.EnableSuppress = true;
 try{ 
rpt.ReportDefinition.Sections[3].ReportObjects["Text33"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.Sections[3].ReportObjects["Line25"].ObjectFormat.EnableSuppress = true;
                                   
}catch{}
                                    rpt.ReportDefinition.Sections[3].ReportObjects["Text27"].Width = 1496;
                                    rpt.ReportDefinition.Sections[3].ReportObjects["SerialKey1"].Width = 1496;
                                    rpt.ReportDefinition.Sections[3].ReportObjects["Text27"].Left = 3162;
                                    rpt.ReportDefinition.Sections[3].ReportObjects["SerialKey1"].Left = 3162;
                                    try
                                    {
                                        rpt.ReportDefinition.Sections[3].ReportObjects["Line7t"].ObjectFormat.EnableSuppress = true;
rpt.ReportDefinition.Sections[3].ReportObjects["StoreNo1"].ObjectFormat.EnableSuppress = true;}
                                    catch
                                    {
                                    }
                                }
                            }
                        }
                        catch
                        {
                        }
                        try
                        {
                            setTarwisaatax(_InvSetting, rpt);
                        }
                        catch
                        {
                        }
                        try
                        {
                            rpt.SetParameterValue("IsCashCredit", VarGeneral.IsCashCredit ? "1" : "0");
                        }
                        catch
                        {
                        }
                        try
                        {
                            rpt.SetParameterValue("vDecimal", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? "1" : "0");
                        }
                        catch
                        {
                        }
                        try
                        {
                            rpt.SetParameterValue("IsTotWithTax", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 65) ? "1" : "0");
                        }
                        catch
                        {
                        }
                        try
                        {
                            (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                        }
                        catch
                        {
                        }
                        try
                        {
                            (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                        }
                        catch
                        {
                        }
                        rpt.SetParameterValue("StoreSts", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16) ? "Show" : "Hide");
                        if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                        {
                            rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                        }
                        else
                        {
                            rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                        }
                        rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                        rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                        rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                        rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                        rpt.SetParameterValue("vSts", false);
                        rpt.SetParameterValue("vLines", 1);
                        if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.LineDetailSts, vStr(VarGeneral.InvTyp)))
                        {
                            rpt.SetParameterValue("LineDetailNa", VarGeneral.Settings_Sys.LineDetailNameA);
                            rpt.SetParameterValue("LineDetailNa_Eng", VarGeneral.Settings_Sys.LineDetailNameE);
                        }
                        else
                        {
                            rpt.SetParameterValue("LineDetailNa", string.Empty);
                            rpt.SetParameterValue("LineDetailNa_Eng", string.Empty);
                        }
                        rpt.SetParameterValue("UserName", vUsrNmA);
                        rpt.SetParameterValue("BranchName", vBranchNmA);
                        rpt.SetParameterValue("UsrNamE", vUsrNmE);
                        rpt.SetParameterValue("BranchNameE", vBranchNmE);
                        try
                        {
                            if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 20))
                            {
                                rpt.ReportDefinition.ReportObjects["Line2"].ObjectFormat.EnableSuppress = true;
                                 rpt.ReportDefinition.ReportObjects["Text27"].ObjectFormat.EnableSuppress = true;
try{
rpt.ReportDefinition.ReportObjects["Text39"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line26"].ObjectFormat.EnableSuppress = true;

}catch
{
}
                                rpt.ReportDefinition.ReportObjects["SerialKey1"].ObjectFormat.EnableSuppress = true;
                                try
                                {
                                    rpt.ReportDefinition.Sections[3].ReportObjects["Line2t"].ObjectFormat.EnableSuppress = true;
                                }
                                catch
                                {
                                }
                                if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16))
                                {
                                    rpt.ReportDefinition.ReportObjects["Text13"].Width = 2924;
                                    rpt.ReportDefinition.ReportObjects["ItmDes1"].Width = 2924;
                                    rpt.ReportDefinition.ReportObjects["Text13"].Left = 7106;
                                    rpt.ReportDefinition.ReportObjects["ItmDes1"].Left = 7106;
                                }
                                else
                                {
                                    rpt.ReportDefinition.ReportObjects["Text13"].Width = 3536;
                                    rpt.ReportDefinition.ReportObjects["ItmDes1"].Width = 3536;
                                    rpt.ReportDefinition.ReportObjects["Text13"].Left = 6460;
                                    rpt.ReportDefinition.ReportObjects["ItmDes1"].Left = 6460;
                                }
                            }
                        }
                        catch
                        {
                        }setTotalsRpt(_InvSetting,rpt);if (_InvSetting.ISdirectPrinting)
                        {
                            PrintSet(rpt, (int)_InvSetting.lnPg.Value, (_InvSetting.Orientation == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, _InvSetting.defSizePaper, _InvSetting.DefLines.Value, _InvSetting.defPrn, _InvSetting.hAs.Value, _InvSetting.hYs.Value, _InvSetting.hYm.Value, _InvSetting.hAl.Value);
                        }
                        else
                        {
                            setpagesetting(rpt);
                        }
                    }
                    else if (repvalue == "PaymentOrderReturn")
                    {
                        T_Printer _InvSetting = new T_Printer();
                        _InvSetting = db.StockPrinterSetting(VarGeneral.UserID, VarGeneral.InvTyp);
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            try
                            {
                                if (VarGeneral.gUserName == "runsetting")
                                {
                                    if (File.Exists(Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepPaymentOrderReturn.rpt"))
                                    {
                                        MainCryRep.FileName = Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepPaymentOrderReturn.rpt";
                                        addqrcode(MainCryRep);
                                    }
                                    else
                                    {
                                        MainCryRep = getdoc("InvAcc.Reports.RepPaymentOrderReturn");
                                    }
                                }
                                else if (File.Exists(Application.StartupPath + "\\Reps\\RepPaymentOrderReturn.rpt"))
                                {
                                    MainCryRep.FileName = Application.StartupPath + "\\Reps\\RepPaymentOrderReturn.rpt";
                                    addqrcode(MainCryRep);
                                }
                                else
                                {
                                    MainCryRep = getdoc("InvAcc.Reports.RepPaymentOrderReturn");
                                }
                            }
                            catch
                            {
                                MainCryRep = getdoc("InvAcc.Reports.RepPaymentOrderReturn");
                            }
                        }
                        else
                        {
                            try
                            {
                                if (VarGeneral.gUserName == "runsetting")
                                {
                                    if (File.Exists(Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepPaymentOrderReturn.rpt"))
                                    {
                                        MainCryRep.FileName = Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepPaymentOrderReturn.rpt";
                                        addqrcode(MainCryRep);
                                    }
                                    else
                                    {
                                        MainCryRep = getdoc("InvAcc.ReportsE.RepPaymentOrderReturn");
                                    }
                                }
                                else if (File.Exists(Application.StartupPath + "\\RepsE\\RepPaymentOrderReturn.rpt"))
                                {
                                    MainCryRep.FileName = Application.StartupPath + "\\RepsE\\RepPaymentOrderReturn.rpt";
                                    addqrcode(MainCryRep);
                                }
                                else
                                {
                                    MainCryRep = getdoc("InvAcc.ReportsE.RepPaymentOrderReturn");
                                }
                            }
                            catch
                            {
                                MainCryRep = getdoc("InvAcc.ReportsE.RepPaymentOrderReturn");
                            }
                        }
                        ReportDocument rpt = MainCryRep;
                        string vUsrNmA = string.Empty;
                        string vBranchNmA = string.Empty;
                        string vUsrNmE = string.Empty;
                        string vBranchNmE = string.Empty;
                        try
                        {
                            vUsrNmA = VarGeneral.RepData.Tables[0].Rows[0]["UsrNamA"].ToString();
                        }
                        catch
                        {
                            vUsrNmA = string.Empty;
                        }
                        try
                        {
                            vUsrNmE = VarGeneral.RepData.Tables[0].Rows[0]["UsrNamE"].ToString();
                        }
                        catch
                        {
                            vUsrNmE = string.Empty;
                        }
                        try
                        {
                            vBranchNmA = VarGeneral.RepData.Tables[0].Rows[0]["Branch_Name"].ToString();
                        }
                        catch
                        {
                            vBranchNmA = string.Empty;
                        }
                        try
                        {
                            vBranchNmE = VarGeneral.RepData.Tables[0].Rows[0]["Branch_NameE"].ToString();
                        }
                        catch
                        {
                            vBranchNmE = string.Empty;
                        }
                        VarGeneral.RepData.Tables[0].Rows[0].Delete();
                        rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                   setTarwisaa(rpt);try
                        {
                            if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16))
                            {
                                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                                {
                                    rpt.ReportDefinition.Sections[3].ReportObjects["Line7"].ObjectFormat.EnableSuppress = true; rpt.ReportDefinition.Sections[3].ReportObjects["Text12"].ObjectFormat.EnableSuppress = true;
 try{ 
rpt.ReportDefinition.Sections[3].ReportObjects["Text33"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.Sections[3].ReportObjects["Line25"].ObjectFormat.EnableSuppress = true;
                                   
}catch{}
                                    rpt.ReportDefinition.Sections[3].ReportObjects["Text27"].Width = 1496;
                                    rpt.ReportDefinition.Sections[3].ReportObjects["SerialKey1"].Width = 1496;
                                    rpt.ReportDefinition.Sections[3].ReportObjects["Text27"].Left = 6494;
                                    rpt.ReportDefinition.Sections[3].ReportObjects["SerialKey1"].Left = 6494;
                                    try
                                    {
                                        rpt.ReportDefinition.Sections[3].ReportObjects["Line7t"].ObjectFormat.EnableSuppress = true;
rpt.ReportDefinition.Sections[3].ReportObjects["StoreNo1"].ObjectFormat.EnableSuppress = true;}
                                    catch
                                    {
                                    }
                                }
                                else
                                {
                                    rpt.ReportDefinition.Sections[3].ReportObjects["Line7"].ObjectFormat.EnableSuppress = true; rpt.ReportDefinition.Sections[3].ReportObjects["Text12"].ObjectFormat.EnableSuppress = true;
 try{ 
rpt.ReportDefinition.Sections[3].ReportObjects["Text33"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.Sections[3].ReportObjects["Line25"].ObjectFormat.EnableSuppress = true;
                                   
}catch{}
                                    rpt.ReportDefinition.Sections[3].ReportObjects["Text27"].Width = 1496;
                                    rpt.ReportDefinition.Sections[3].ReportObjects["SerialKey1"].Width = 1496;
                                    rpt.ReportDefinition.Sections[3].ReportObjects["Text27"].Left = 3162;
                                    rpt.ReportDefinition.Sections[3].ReportObjects["SerialKey1"].Left = 3162;
                                    try
                                    {
                                        rpt.ReportDefinition.Sections[3].ReportObjects["Line7t"].ObjectFormat.EnableSuppress = true;
rpt.ReportDefinition.Sections[3].ReportObjects["StoreNo1"].ObjectFormat.EnableSuppress = true;}
                                    catch
                                    {
                                    }
                                }
                            }
                        }
                        catch
                        {
                        }
                        try
                        {
                 setTarwisaatax(_InvSetting,rpt);}
                        catch
                        {
                        }
                        try
                        {
                            rpt.SetParameterValue("IsCashCredit", VarGeneral.IsCashCredit ? "1" : "0");
                        }
                        catch
                        {
                        }
                        try
                        {
                            rpt.SetParameterValue("vDecimal", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? "1" : "0");
                        }
                        catch
                        {
                        }
                        try
                        {
                            rpt.SetParameterValue("IsTotWithTax", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 65) ? "1" : "0");
                        }
                        catch
                        {
                        }
                        try
                        {
                            (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                        }
                        catch
                        {
                        }
                        try
                        {
                            (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                        }
                        catch
                        {
                        }
                        rpt.SetParameterValue("StoreSts", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16) ? "Show" : "Hide");
                        if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                        {
                            rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                        }
                        else
                        {
                            rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                        }
                        rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                        rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                        rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                        rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                        rpt.SetParameterValue("vSts", false);
                        rpt.SetParameterValue("vLines", 1);
                        if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.LineDetailSts, vStr(VarGeneral.InvTyp)))
                        {
                            rpt.SetParameterValue("LineDetailNa", VarGeneral.Settings_Sys.LineDetailNameA);
                            rpt.SetParameterValue("LineDetailNa_Eng", VarGeneral.Settings_Sys.LineDetailNameE);
                        }
                        else
                        {
                            rpt.SetParameterValue("LineDetailNa", string.Empty);
                            rpt.SetParameterValue("LineDetailNa_Eng", string.Empty);
                        }
                        rpt.SetParameterValue("UserName", vUsrNmA);
                        rpt.SetParameterValue("BranchName", vBranchNmA);
                        rpt.SetParameterValue("UsrNamE", vUsrNmE);
                        rpt.SetParameterValue("BranchNameE", vBranchNmE);
                        try
                        {
                            if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 20))
                            {
                                rpt.ReportDefinition.ReportObjects["Line2"].ObjectFormat.EnableSuppress = true;
                                 rpt.ReportDefinition.ReportObjects["Text27"].ObjectFormat.EnableSuppress = true;
try{
rpt.ReportDefinition.ReportObjects["Text39"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line26"].ObjectFormat.EnableSuppress = true;

}catch
{
}
                                rpt.ReportDefinition.ReportObjects["SerialKey1"].ObjectFormat.EnableSuppress = true;
                                try
                                {
                                    rpt.ReportDefinition.Sections[3].ReportObjects["Line2t"].ObjectFormat.EnableSuppress = true;
                                }
                                catch
                                {
                                }
                                if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16))
                                {
                                    rpt.ReportDefinition.ReportObjects["Text13"].Width = 2924;
                                    rpt.ReportDefinition.ReportObjects["ItmDes1"].Width = 2924;
                                    rpt.ReportDefinition.ReportObjects["Text13"].Left = 7106;
                                    rpt.ReportDefinition.ReportObjects["ItmDes1"].Left = 7106;
                                }
                                else
                                {
                                    rpt.ReportDefinition.ReportObjects["Text13"].Width = 3536;
                                    rpt.ReportDefinition.ReportObjects["ItmDes1"].Width = 3536;
                                    rpt.ReportDefinition.ReportObjects["Text13"].Left = 6460;
                                    rpt.ReportDefinition.ReportObjects["ItmDes1"].Left = 6460;
                                }
                            }
                        }
                        catch
                        {
                        }setTotalsRpt(_InvSetting,rpt);if (_InvSetting.ISdirectPrinting)
                        {
                            PrintSet(rpt, (int)_InvSetting.lnPg.Value, (_InvSetting.Orientation == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, _InvSetting.defSizePaper, _InvSetting.DefLines.Value, _InvSetting.defPrn, _InvSetting.hAs.Value, _InvSetting.hYs.Value, _InvSetting.hYm.Value, _InvSetting.hAl.Value);
                        }
                        else
                        {
                            setpagesetting(rpt);
                        }
                    }
                    else if (repvalue == "InvoicesComm")
                    {
                        long regval = 0L;
                        try
                        {
                            if (VarGeneral.SSSLev == "B" || VarGeneral.SSSLev == "F")
                            {
                                RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", writable: true);
                                try
                                {
                                    object q = hKey.GetValue("vCoCe");
                                    if (string.IsNullOrEmpty(q.ToString()))
                                    {
                                        hKey.CreateSubKey("vCoCe");
                                        hKey.SetValue("vCoCe", "0");
                                    }
                                }
                                catch
                                {
                                    hKey.CreateSubKey("vCoCe");
                                    hKey.SetValue("vCoCe", "0");
                                }
                                regval = long.Parse(hKey.GetValue("vCoCe").ToString());
                            }
                        }
                        catch
                        {
                            regval = 0L;
                        }
                        if (((VarGeneral.SSSLev == "B" || VarGeneral.SSSLev == "F") && regval == 0) || VarGeneral.SSSLev == "S" || VarGeneral.SSSLev == "C")
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                if (VarGeneral.GeneralPrinter.ISA4PaperType)
                                {
                                    MainCryRep = getdoc("InvAcc.Reports.RepInvoicCommWithCostCenter");
                                }
                                else
                                {
                                    MainCryRep = getdoc("InvAcc.ReportsCasheir.RepInvoicCommWithCostCenter");
                                }
                            }
                            else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsE.RepInvoicCommWithCostCenter");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepInvoicCommWithCostCenter");
                            }
                        }
                        else if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            if (VarGeneral.GeneralPrinter.ISA4PaperType)
                            {
                                MainCryRep = getdoc("InvAcc.Reports.RepInvoicComm");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsCasheir.RepInvoicComm");
                            }
                        }
                        else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                        {
                            MainCryRep = getdoc("InvAcc.ReportsE.RepInvoicComm");
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepInvoicComm");
                        }
                        ReportDocument rpt = MainCryRep;
                        rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                   setTarwisaa(rpt);try
                        {
                            (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                        }
                        catch
                        {
                        }
                        try
                        {
                            (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                        }
                        catch
                        {
                        }
                        if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                        {
                            rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                        }
                        else
                        {
                            rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                        }
                        rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                        rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                        rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                        rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                        rpt.SetParameterValue("vSts", false);
                        rpt.SetParameterValue("vLines", 1);
                        if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                        {
                            PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                        }
                        else
                        {
                            setpagesetting(rpt);
                        }
                    }
                    else if (repvalue == "GaidComm")
                    {
                        long regval = 0L;
                        try
                        {
                            if (VarGeneral.SSSLev == "B" || VarGeneral.SSSLev == "F")
                            {
                                RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", writable: true);
                                try
                                {
                                    object q = hKey.GetValue("vCoCe");
                                    if (string.IsNullOrEmpty(q.ToString()))
                                    {
                                        hKey.CreateSubKey("vCoCe");
                                        hKey.SetValue("vCoCe", "0");
                                    }
                                }
                                catch
                                {
                                    hKey.CreateSubKey("vCoCe");
                                    hKey.SetValue("vCoCe", "0");
                                }
                                regval = long.Parse(hKey.GetValue("vCoCe").ToString());
                            }
                        }
                        catch
                        {
                            regval = 0L;
                        }
                        if (((VarGeneral.SSSLev == "B" || VarGeneral.SSSLev == "F") && regval == 0) || VarGeneral.SSSLev == "S" || VarGeneral.SSSLev == "C")
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                if (VarGeneral.GeneralPrinter.ISA4PaperType)
                                {
                                    MainCryRep = getdoc("InvAcc.Reports.RepGaidCommWithCostCenter");
                                }
                                else
                                {
                                    MainCryRep = getdoc("InvAcc.ReportsCasheir.RepGaidCommWithCostCenter");
                                }
                            }
                            else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsE.RepGaidCommWithCostCenter");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepGaidCommWithCostCenter");
                            }
                        }
                        else if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            if (VarGeneral.GeneralPrinter.ISA4PaperType)
                            {
                                MainCryRep = getdoc("InvAcc.Reports.RepGaidComm");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsCasheir.RepGaidComm");
                            }
                        }
                        else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                        {
                            MainCryRep = getdoc("InvAcc.ReportsE.RepGaidComm");
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepGaidComm");
                        }
                        ReportDocument rpt = MainCryRep;
                        rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                   setTarwisaa(rpt);try
                        {
                            (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                        }
                        catch
                        {
                        }
                        try
                        {
                            (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                        }
                        catch
                        {
                        }
                        if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                        {
                            rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                        }
                        else
                        {
                            rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                        }
                        rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                        rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                        rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                        rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                        rpt.SetParameterValue("vSts", false);
                        rpt.SetParameterValue("vLines", 1);
                        if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                        {
                            PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                        }
                        else
                        {
                            setpagesetting(rpt);
                        }
                    }
                    else if (repvalue == "ItemsData\u064fExtrnalMnd")
                    {
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            if (VarGeneral.GeneralPrinter.ISA4PaperType)
                            {
                                MainCryRep = getdoc("InvAcc.Reports.RepItemsQuantityExtrnalMnd");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsCasheir.RepItemsQuantityExtrnalMnd");
                            }
                        }
                        else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                        {
                            MainCryRep = getdoc("InvAcc.ReportsE.RepItemsQuantityExtrnalMnd");
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepItemsQuantityExtrnalMnd");
                        }
                        ReportDocument rpt = MainCryRep;
                        rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                   setTarwisaa(rpt);try
                        {
                            (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                        }
                        catch
                        {
                        }
                        try
                        {
                            (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                        }
                        catch
                        {
                        }
                        if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                        {
                            rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                        }
                        else
                        {
                            rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                        }
                        rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                        rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                        rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                        rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                        rpt.SetParameterValue("vSts", false);
                        rpt.SetParameterValue("vLines", 1);
                        if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                        {
                            PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                        }
                        else
                        {
                            setpagesetting(rpt);
                        }
                    }
                    else if (repvalue == "RepGaid")
                    {
                        T_Printer _InvSetting = new T_Printer();
                        _InvSetting = db.StockPrinterSetting(VarGeneral.UserID, VarGeneral.InvTyp);
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            try
                            {
                                if (VarGeneral.gUserName == "runsetting")
                                {
                                    if (File.Exists(Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepGaid.rpt"))
                                    {
                                        MainCryRep.FileName = Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepGaid.rpt";
                                    }
                                    else
                                    {
                                        MainCryRep = getdoc("InvAcc.Reports.RepGaid");
                                    }
                                }
                                else if (File.Exists(Application.StartupPath + "\\Reps\\RepGaid.rpt"))
                                {
                                    MainCryRep.FileName = Application.StartupPath + "\\Reps\\RepGaid.rpt";
                                }
                                else
                                {
                                    MainCryRep = getdoc("InvAcc.Reports.RepGaid");
                                }
                            }
                            catch
                            {
                                MainCryRep = getdoc("InvAcc.Reports.RepGaid");
                            }
                        }
                        else
                        {
                            try
                            {
                                if (VarGeneral.gUserName == "runsetting")
                                {
                                    if (File.Exists(Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepGaid.rpt"))
                                    {
                                        MainCryRep.FileName = Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepGaid.rpt";
                                    }
                                    else
                                    {
                                        MainCryRep = getdoc("InvAcc.ReportsE.RepGaid");
                                    }
                                }
                                else if (File.Exists(Application.StartupPath + "\\RepsE\\RepGaid.rpt"))
                                {
                                    MainCryRep.FileName = Application.StartupPath + "\\RepsE\\RepGaid.rpt";
                                }
                                else
                                {
                                    MainCryRep = getdoc("InvAcc.ReportsE.RepGaid");
                                }
                            }
                            catch
                            {
                                MainCryRep = getdoc("InvAcc.ReportsE.RepGaid");
                            }
                        }
                        ReportDocument rpt = MainCryRep;
                        rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                   setTarwisaa(rpt);try
                        {
                            rpt.SetParameterValue("IsCashCredit", VarGeneral.IsCashCredit ? "1" : "0");
                        }
                        catch
                        {
                        }
                        try
                        {
                            rpt.SetParameterValue("vDecimal", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? "1" : "0");
                        }
                        catch
                        {
                        }
                        try
                        {
                            rpt.SetParameterValue("IsTotWithTax", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 65) ? "1" : "0");
                        }
                        catch
                        {
                        }
                        try
                        {
                            (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                        }
                        catch
                        {
                        }
                        try
                        {
                            (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                        }
                        catch
                        {
                        }
                        rpt.SetParameterValue("SSSLev", (VarGeneral.SSSLev == "G") ? "Show" : "Hide");
                        if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                        {
                            rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                        }
                        else
                        {
                            rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                        }
                        rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                        rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                        rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                        rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                        rpt.SetParameterValue("vSts", false);
                        rpt.SetParameterValue("vLines", 1);
                        if (_InvSetting.ISdirectPrinting || BarcodSts)
                        {
                            PrintSet(rpt, (int)_InvSetting.lnPg.Value, (_InvSetting.Orientation == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, _InvSetting.defSizePaper, _InvSetting.DefLines.Value, _InvSetting.defPrn, _InvSetting.hAs.Value, _InvSetting.hYs.Value, _InvSetting.hYm.Value, _InvSetting.hAl.Value);
                        }
                        else
                        {
                            setpagesetting(rpt);
                        }
                    }
                    else if (repvalue == "RepGaidBankPeaper")
                    {
                        T_Printer _InvSetting = new T_Printer();
                        _InvSetting = db.StockPrinterSetting(VarGeneral.UserID, VarGeneral.InvTyp);
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            MainCryRep = getdoc("InvAcc.Reports.RepBankPeaper");
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsE.RepBankPeaper");
                        }
                        ReportDocument rpt = MainCryRep;
                        rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                   setTarwisaa(rpt);try
                        {
                            rpt.SetParameterValue("IsCashCredit", VarGeneral.IsCashCredit ? "1" : "0");
                        }
                        catch
                        {
                        }
                        try
                        {
                            rpt.SetParameterValue("vDecimal", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? "1" : "0");
                        }
                        catch
                        {
                        }
                        try
                        {
                            rpt.SetParameterValue("IsTotWithTax", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 65) ? "1" : "0");
                        }
                        catch
                        {
                        }
                        try
                        {
                            (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                        }
                        catch
                        {
                        }
                        try
                        {
                            (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                        }
                        catch
                        {
                        }
                        rpt.SetParameterValue("SSSLev", (VarGeneral.InvTyp == 23 || VarGeneral.InvTyp == 24) ? "Show" : "Hide");
                        if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                        {
                            rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                        }
                        else
                        {
                            rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                        }
                        rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            rpt.SetParameterValue("vTitle", (VarGeneral.InvTyp == 23) ? "وارد مـن" : "محـرر لـ");
                        }
                        else
                        {
                            rpt.SetParameterValue("vTitle", (VarGeneral.InvTyp == 23) ? "Issued by" : "Editor");
                        }
                        rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                        rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                        rpt.SetParameterValue("vSts", false);
                        rpt.SetParameterValue("vLines", 1);
                        if (_InvSetting.ISdirectPrinting)
                        {
                            PrintSet(rpt, (int)_InvSetting.lnPg.Value, (_InvSetting.Orientation == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, _InvSetting.defSizePaper, _InvSetting.DefLines.Value, _InvSetting.defPrn, _InvSetting.hAs.Value, _InvSetting.hYs.Value, _InvSetting.hYm.Value, _InvSetting.hAl.Value);
                        }
                        else
                        {
                            setpagesetting(rpt);
                        }
                    }
                    else if (repvalue == "RepBankPeaperList")
                    {
                        T_Printer _InvSetting = new T_Printer();
                        _InvSetting = db.StockPrinterSetting(VarGeneral.UserID, VarGeneral.InvTyp);
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            if (VarGeneral.GeneralPrinter.ISA4PaperType)
                            {
                                MainCryRep = getdoc("InvAcc.Reports.RepBankPeaperList");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsCasheir.RepBankPeaperList");
                            }
                        }
                        else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                        {
                            MainCryRep = getdoc("InvAcc.ReportsE.RepBankPeaperList");
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepBankPeaperList");
                        }
                        ReportDocument rpt = MainCryRep;
                        rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                   setTarwisaa(rpt);if (VarGeneral.InvTyp == 23 || VarGeneral.InvTyp == 24)
                        {
                            rpt.SetParameterValue("SSSLev", "Show");
                        }
                        else
                        {
                            rpt.SetParameterValue("SSSLev", "Hide");
                            rpt.ReportDefinition.Sections[3].ReportObjects["Line10"].ObjectFormat.EnableSuppress = true;
                            rpt.ReportDefinition.Sections[3].ReportObjects["Line22"].ObjectFormat.EnableSuppress = true;
                            rpt.ReportDefinition.Sections[3].ReportObjects["Text33"].Width = 2618;
                            rpt.ReportDefinition.Sections[3].ReportObjects["AccDefNmBr1"].Width = 2618;
                            rpt.ReportDefinition.Sections[3].ReportObjects["Text33"].Left = 4012;
                            rpt.ReportDefinition.Sections[3].ReportObjects["AccDefNmBr1"].Left = 4012;
                            rpt.ReportDefinition.Sections[3].ReportObjects["Text8"].Width = 1802;
                            rpt.ReportDefinition.Sections[3].ReportObjects["PageDate1"].Width = 1802;
                            rpt.ReportDefinition.Sections[3].ReportObjects["Text8"].Left = 6800;
                            rpt.ReportDefinition.Sections[3].ReportObjects["PageDate1"].Left = 6800;
                        }
                        try
                        {
                            rpt.SetParameterValue("IsCashCredit", VarGeneral.IsCashCredit ? "1" : "0");
                        }
                        catch
                        {
                        }
                        try
                        {
                            rpt.SetParameterValue("vDecimal", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? "1" : "0");
                        }
                        catch
                        {
                        }
                        try
                        {
                            rpt.SetParameterValue("IsTotWithTax", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 65) ? "1" : "0");
                        }
                        catch
                        {
                        }
                        try
                        {
                            (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                        }
                        catch
                        {
                        }
                        try
                        {
                            (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                        }
                        catch
                        {
                        }
                        if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                        {
                            rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                        }
                        else
                        {
                            rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                        }
                        rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                        rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                        rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                        rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                        rpt.SetParameterValue("vSts", false);
                        rpt.SetParameterValue("vLines", 1);
                        if (_InvSetting.ISdirectPrinting)
                        {
                            PrintSet(rpt, (int)_InvSetting.lnPg.Value, (_InvSetting.Orientation == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, _InvSetting.defSizePaper, _InvSetting.DefLines.Value, _InvSetting.defPrn, _InvSetting.hAs.Value, _InvSetting.hYs.Value, _InvSetting.hYm.Value, _InvSetting.hAl.Value);
                        }
                        else
                        {
                            setpagesetting(rpt);
                        }
                    }
                    else if (repvalue == "RepGaidCatch")
                    {
                        T_Printer _InvSetting = new T_Printer();
                        _InvSetting = db.StockPrinterSetting(VarGeneral.UserID, VarGeneral.InvTyp);
                        if (VarGeneral.Snd_Gaid_Des == 1)
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                try
                                {
                                    if (VarGeneral.gUserName == "runsetting")
                                    {
                                        if (File.Exists(Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepGaidCatch.rpt"))
                                        {
                                            MainCryRep.FileName = Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepGaidCatch.rpt";
                                        }
                                        else
                                        {
                                            MainCryRep = getdoc("InvAcc.Reports.RepGaidCatch");
                                        }
                                    }
                                    else if (File.Exists(Application.StartupPath + "\\Reps\\RepGaidCatch.rpt"))
                                    {
                                        MainCryRep.FileName = Application.StartupPath + "\\Reps\\RepGaidCatch.rpt";
                                    }
                                    else
                                    {
                                        MainCryRep = getdoc("InvAcc.Reports.RepGaidCatch");
                                    }
                                }
                                catch
                                {
                                    MainCryRep = getdoc("InvAcc.Reports.RepGaidCatch");
                                }
                            }
                            else
                            {
                                try
                                {
                                    if (VarGeneral.gUserName == "runsetting")
                                    {
                                        if (File.Exists(Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepGaidCatch.rpt"))
                                        {
                                            MainCryRep.FileName = Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepGaidCatch.rpt";
                                        }
                                        else
                                        {
                                            MainCryRep = getdoc("InvAcc.ReportsE.RepGaidCatch");
                                        }
                                    }
                                    else if (File.Exists(Application.StartupPath + "\\RepsE\\RepGaidCatch.rpt"))
                                    {
                                        MainCryRep.FileName = Application.StartupPath + "\\RepsE\\RepGaidCatch.rpt";
                                    }
                                    else
                                    {
                                        MainCryRep = getdoc("InvAcc.ReportsE.RepGaidCatch");
                                    }
                                }
                                catch
                                {
                                    MainCryRep = getdoc("InvAcc.ReportsE.RepGaidCatch");
                                }
                            }
                        }
                        else if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            try
                            {
                                if (VarGeneral.gUserName == "runsetting")
                                {
                                    if (File.Exists(Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepGaidCatchSingle.rpt"))
                                    {
                                        MainCryRep.FileName = Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepGaidCatchSingle.rpt";
                                    }
                                    else
                                    {
                                        MainCryRep = getdoc("InvAcc.Reports.RepGaidCatchSingle");
                                    }
                                }
                                else if (File.Exists(Application.StartupPath + "\\Reps\\RepGaidCatchSingle.rpt"))
                                {
                                    MainCryRep.FileName = Application.StartupPath + "\\Reps\\RepGaidCatchSingle.rpt";
                                }
                                else
                                {
                                    MainCryRep = getdoc("InvAcc.Reports.RepGaidCatchSingle");
                                }
                            }
                            catch
                            {
                                MainCryRep = getdoc("InvAcc.Reports.RepGaidCatchSingle");
                            }
                        }
                        else
                        {
                            try
                            {
                                if (VarGeneral.gUserName == "runsetting")
                                {
                                    if (File.Exists(Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepGaidCatchSingle.rpt"))
                                    {
                                        MainCryRep.FileName = Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepGaidCatchSingle.rpt";
                                    }
                                    else
                                    {
                                        MainCryRep = getdoc("InvAcc.ReportsE.RepGaidCatchSingle");
                                    }
                                }
                                else if (File.Exists(Application.StartupPath + "\\RepsE\\RepGaidCatchSingle.rpt"))
                                {
                                    MainCryRep.FileName = Application.StartupPath + "\\RepsE\\RepGaidCatchSingle.rpt";
                                }
                                else
                                {
                                    MainCryRep = getdoc("InvAcc.ReportsE.RepGaidCatchSingle");
                                }
                            }
                            catch
                            {
                                MainCryRep = getdoc("InvAcc.ReportsE.RepGaidCatchSingle");
                            }
                        }
                        ReportDocument rpt = MainCryRep;
                        rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                   setTarwisaa(rpt);try
                        {
                            rpt.SetParameterValue("IsCashCredit", VarGeneral.IsCashCredit ? "1" : "0");
                        }
                        catch
                        {
                        }
                        try
                        {
                            rpt.SetParameterValue("vDecimal", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? "1" : "0");
                        }
                        catch
                        {
                        }
                        try
                        {
                            rpt.SetParameterValue("IsTotWithTax", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 65) ? "1" : "0");
                        }
                        catch
                        {
                        }
                        try
                        {
                            (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                        }
                        catch
                        {
                        }
                        try
                        {
                            (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                        }
                        catch
                        {
                        }
                        rpt.SetParameterValue("SSSLev", (VarGeneral.SSSLev == "G") ? "Show" : "Hide");
                        if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                        {
                            rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                        }
                        else
                        {
                            rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                        }
                        rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                        rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                        rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                        rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                        rpt.SetParameterValue("vSts", false);
                        rpt.SetParameterValue("vLines", 1);
                        if (_InvSetting.ISdirectPrinting || BarcodSts)
                        {
                            PrintSet(rpt, (int)_InvSetting.lnPg.Value, (_InvSetting.Orientation == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, _InvSetting.defSizePaper, _InvSetting.DefLines.Value, _InvSetting.defPrn, _InvSetting.hAs.Value, _InvSetting.hYs.Value, _InvSetting.hYm.Value, _InvSetting.hAl.Value);
                        }
                        else
                        {
                            setpagesetting(rpt);
                        }
                    }
                    else if (repvalue == "RepGaidSerf")
                    {
                        T_Printer _InvSetting = new T_Printer();
                        _InvSetting = db.StockPrinterSetting(VarGeneral.UserID, VarGeneral.InvTyp);
                        if (VarGeneral.Snd_Gaid_Des == 1)
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                try
                                {
                                    if (VarGeneral.gUserName == "runsetting")
                                    {
                                        if (File.Exists(Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepGaidSerf.rpt"))
                                        {
                                            MainCryRep.FileName = Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepGaidSerf.rpt";
                                        }
                                        else
                                        {
                                            MainCryRep = getdoc("InvAcc.Reports.RepGaidSerf");
                                        }
                                    }
                                    else if (File.Exists(Application.StartupPath + "\\Reps\\RepGaidSerf.rpt"))
                                    {
                                        MainCryRep.FileName = Application.StartupPath + "\\Reps\\RepGaidSerf.rpt";
                                    }
                                    else
                                    {
                                        MainCryRep = getdoc("InvAcc.Reports.RepGaidSerf");
                                    }
                                }
                                catch
                                {
                                    MainCryRep = getdoc("InvAcc.Reports.RepGaidSerf");
                                }
                            }
                            else
                            {
                                try
                                {
                                    if (VarGeneral.gUserName == "runsetting")
                                    {
                                        if (File.Exists(Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepGaidSerf.rpt"))
                                        {
                                            MainCryRep.FileName = Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepGaidSerf.rpt";
                                        }
                                        else
                                        {
                                            MainCryRep = getdoc("InvAcc.ReportsE.RepGaidSerf");
                                        }
                                    }
                                    else if (File.Exists(Application.StartupPath + "\\RepsE\\RepGaidSerf.rpt"))
                                    {
                                        MainCryRep.FileName = Application.StartupPath + "\\RepsE\\RepGaidSerf.rpt";
                                    }
                                    else
                                    {
                                        MainCryRep = getdoc("InvAcc.ReportsE.RepGaidSerf");
                                    }
                                }
                                catch
                                {
                                    MainCryRep = getdoc("InvAcc.ReportsE.RepGaidSerf");
                                }
                            }
                        }
                        else if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            try
                            {
                                if (VarGeneral.gUserName == "runsetting")
                                {
                                    if (File.Exists(Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepGaidSerfSingle.rpt"))
                                    {
                                        MainCryRep.FileName = Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepGaidSerfSingle.rpt";
                                    }
                                    else
                                    {
                                        MainCryRep = getdoc("InvAcc.Reports.RepGaidSerfSingle");
                                    }
                                }
                                else if (File.Exists(Application.StartupPath + "\\Reps\\RepGaidSerfSingle.rpt"))
                                {
                                    MainCryRep.FileName = Application.StartupPath + "\\Reps\\RepGaidSerfSingle.rpt";
                                }
                                else
                                {
                                    MainCryRep = getdoc("InvAcc.Reports.RepGaidSerfSingle");
                                }
                            }
                            catch
                            {
                                MainCryRep = getdoc("InvAcc.Reports.RepGaidSerfSingle");
                            }
                        }
                        else
                        {
                            try
                            {
                                if (VarGeneral.gUserName == "runsetting")
                                {
                                    if (File.Exists(Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepGaidSerfSingle.rpt"))
                                    {
                                        MainCryRep.FileName = Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepGaidSerfSingle.rpt";
                                    }
                                    else
                                    {
                                        MainCryRep = getdoc("InvAcc.ReportsE.RepGaidSerfSingle");
                                    }
                                }
                                else if (File.Exists(Application.StartupPath + "\\RepsE\\RepGaidSerfSingle.rpt"))
                                {
                                    MainCryRep.FileName = Application.StartupPath + "\\RepsE\\RepGaidSerfSingle.rpt";
                                }
                                else
                                {
                                    MainCryRep = getdoc("InvAcc.ReportsE.RepGaidSerfSingle");
                                }
                            }
                            catch
                            {
                                MainCryRep = getdoc("InvAcc.ReportsE.RepGaidSerfSingle");
                            }
                        }
                        ReportDocument rpt = MainCryRep;
                        rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                   setTarwisaa(rpt);try
                        {
                            rpt.SetParameterValue("IsCashCredit", VarGeneral.IsCashCredit ? "1" : "0");
                        }
                        catch
                        {
                        }
                        try
                        {
                            rpt.SetParameterValue("vDecimal", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? "1" : "0");
                        }
                        catch
                        {
                        }
                        try
                        {
                            rpt.SetParameterValue("IsTotWithTax", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 65) ? "1" : "0");
                        }
                        catch
                        {
                        }
                        try
                        {
                            (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                        }
                        catch
                        {
                        }
                        try
                        {
                            (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                        }
                        catch
                        {
                        }
                        rpt.SetParameterValue("SSSLev", (VarGeneral.SSSLev == "G") ? "Show" : "Hide");
                        if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                        {
                            rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                        }
                        else
                        {
                            rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                        }
                        rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                        rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                        rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                        rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                        rpt.SetParameterValue("vSts", false);
                        rpt.SetParameterValue("vLines", 1);
                        if (_InvSetting.ISdirectPrinting || BarcodSts)
                        {
                            PrintSet(rpt, (int)_InvSetting.lnPg.Value, (_InvSetting.Orientation == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, _InvSetting.defSizePaper, _InvSetting.DefLines.Value, _InvSetting.defPrn, _InvSetting.hAs.Value, _InvSetting.hYs.Value, _InvSetting.hYm.Value, _InvSetting.hAl.Value);
                        }
                        else
                        {
                            setpagesetting(rpt);
                        }
                    }
                    else if (repvalue == "RepGaidCatchPer")
                    {
                        T_Printer _InvSetting = new T_Printer();
                        _InvSetting = db.StockPrinterSetting(VarGeneral.UserID, VarGeneral.InvTyp);
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            try
                            {
                                if (VarGeneral.gUserName == "runsetting")
                                {
                                    if (File.Exists(Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepGaidCatchPer.rpt"))
                                    {
                                        MainCryRep.FileName = Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepGaidCatchPer.rpt";
                                    }
                                    else
                                    {
                                        MainCryRep = getdoc("InvAcc.ReportHotel.RepGaidCatchPer");
                                    }
                                }
                                else if (File.Exists(Application.StartupPath + "\\Reps\\RepGaidCatchPer.rpt"))
                                {
                                    MainCryRep.FileName = Application.StartupPath + "\\Reps\\RepGaidCatchPer.rpt";
                                }
                                else
                                {
                                    MainCryRep = getdoc("InvAcc.ReportHotel.RepGaidCatchPer");
                                }
                            }
                            catch
                            {
                                MainCryRep = getdoc("InvAcc.ReportHotel.RepGaidCatchPer");
                            }
                        }
                        else
                        {
                            try
                            {
                                if (VarGeneral.gUserName == "runsetting")
                                {
                                    if (File.Exists(Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepGaidCatchPer.rpt"))
                                    {
                                        MainCryRep.FileName = Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepGaidCatchPer.rpt";
                                    }
                                    else
                                    {
                                        MainCryRep = getdoc("InvAcc.ReportHotelE.RepGaidCatchPer");
                                    }
                                }
                                else if (File.Exists(Application.StartupPath + "\\RepsE\\RepGaidCatchPer.rpt"))
                                {
                                    MainCryRep.FileName = Application.StartupPath + "\\RepsE\\RepGaidCatchPer.rpt";
                                }
                                else
                                {
                                    MainCryRep = getdoc("InvAcc.ReportHotelE.RepGaidCatchPer");
                                }
                            }
                            catch
                            {
                                MainCryRep = getdoc("InvAcc.ReportHotelE.RepGaidCatchPer");
                            }
                        }
                        ReportDocument rpt = MainCryRep;
                        rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                   setTarwisaa(rpt);rpt.SetParameterValue("SSSLev", (VarGeneral.SSSLev == "G") ? "Show" : "Hide");
                        if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                        {
                            rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                        }
                        else
                        {
                            rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                        }
                        rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                        rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                        rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                        rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                        rpt.SetParameterValue("vSts", false);
                        rpt.SetParameterValue("vLines", 1);
                        if (_InvSetting.ISdirectPrinting)
                        {
                            PrintSet(rpt, (int)_InvSetting.lnPg.Value, (_InvSetting.Orientation == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, _InvSetting.defSizePaper, _InvSetting.DefLines.Value, _InvSetting.defPrn, _InvSetting.hAs.Value, _InvSetting.hYs.Value, _InvSetting.hYm.Value, _InvSetting.hAl.Value);
                        }
                        else
                        {
                            setpagesetting(rpt);
                        }
                    }
                    else if (repvalue == "RepGaidSerfPer")
                    {
                        T_Printer _InvSetting = new T_Printer();
                        _InvSetting = db.StockPrinterSetting(VarGeneral.UserID, VarGeneral.InvTyp);
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            try
                            {
                                if (VarGeneral.gUserName == "runsetting")
                                {
                                    if (File.Exists(Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepGaidSerfPer.rpt"))
                                    {
                                        MainCryRep.FileName = Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepGaidSerfPer.rpt";
                                    }
                                    else
                                    {
                                        MainCryRep = getdoc("InvAcc.ReportHotel.RepGaidSerfPer");
                                    }
                                }
                                else if (File.Exists(Application.StartupPath + "\\Reps\\RepGaidSerfPer.rpt"))
                                {
                                    MainCryRep.FileName = Application.StartupPath + "\\Reps\\RepGaidSerfPer.rpt";
                                }
                                else
                                {
                                    MainCryRep = getdoc("InvAcc.ReportHotel.RepGaidSerfPer");
                                }
                            }
                            catch
                            {
                                MainCryRep = getdoc("InvAcc.ReportHotel.RepGaidSerfPer");
                            }
                        }
                        else
                        {
                            try
                            {
                                if (VarGeneral.gUserName == "runsetting")
                                {
                                    if (File.Exists(Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepGaidSerfPer.rpt"))
                                    {
                                        MainCryRep.FileName = Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepGaidSerfPer.rpt";
                                    }
                                    else
                                    {
                                        MainCryRep = getdoc("InvAcc.ReportHotelE.RepGaidSerfPer");
                                    }
                                }
                                else if (File.Exists(Application.StartupPath + "\\RepsE\\RepGaidSerfPer.rpt"))
                                {
                                    MainCryRep.FileName = Application.StartupPath + "\\RepsE\\RepGaidSerfPer.rpt";
                                }
                                else
                                {
                                    MainCryRep = getdoc("InvAcc.ReportHotelE.RepGaidSerfPer");
                                }
                            }
                            catch
                            {
                                MainCryRep = getdoc("InvAcc.ReportHotelE.RepGaidSerfPer");
                            }
                        }
                        ReportDocument rpt = MainCryRep;
                        rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                   setTarwisaa(rpt);rpt.SetParameterValue("SSSLev", (VarGeneral.SSSLev == "G") ? "Show" : "Hide");
                        if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                        {
                            rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                        }
                        else
                        {
                            rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                        }
                        rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                        rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                        rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                        rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                        rpt.SetParameterValue("vSts", false);
                        rpt.SetParameterValue("vLines", 1);
                        if (_InvSetting.ISdirectPrinting)
                        {
                            PrintSet(rpt, (int)_InvSetting.lnPg.Value, (_InvSetting.Orientation == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, _InvSetting.defSizePaper, _InvSetting.DefLines.Value, _InvSetting.defPrn, _InvSetting.hAs.Value, _InvSetting.hYs.Value, _InvSetting.hYm.Value, _InvSetting.hAl.Value);
                        }
                        else
                        {
                            setpagesetting(rpt);
                        }
                    }
                    else if (repvalue == "RepGeneral")
                    {
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            if (VarGeneral.GeneralPrinter.ISA4PaperType)
                            {
                                MainCryRep = getdoc("InvAcc.Reports.RepGeneral");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsCasheir.RepGeneral");
                            }
                        }
                        else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                        {
                            MainCryRep = getdoc("InvAcc.ReportsE.RepGeneral");
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepGeneral");
                        }
                        ReportDocument rpt = MainCryRep;
                        rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                   setTarwisaa(rpt);try
                        {
                            (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                        }
                        catch
                        {
                        }
                        try
                        {
                            (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                        }
                        catch
                        {
                        }
                        if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                        {
                            rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                        }
                        else
                        {
                            rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                        }
                        rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                        rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                        rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                        rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                        rpt.SetParameterValue("vSts", false);
                        rpt.SetParameterValue("vLines", 1);
                        if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                        {
                            PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                        }
                        else
                        {
                            setpagesetting(rpt);
                        }
                    }
                    else if (repvalue == "RepCheckStQty")
                    {
                        MainCryRep = getdoc2("RepChkStQty");
                        ReportDocument rpt = MainCryRep;
                        rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                   setTarwisaa(rpt);try
                        {
                            (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                        }
                        catch
                        {
                        }
                        try
                        {
                            (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                        }
                        catch
                        {
                        }
                        if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                        {
                            rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                        }
                        else
                        {
                            rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                        }
                        rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                        rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                        rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                        rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                        rpt.SetParameterValue("vSts", false);
                        rpt.SetParameterValue("vLines", 1);
                        if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                        {
                            PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                        }
                        else
                        {
                            setpagesetting(rpt);
                        }
                    }
                    else if (repvalue == "RepGeneralSerial")
                    {
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            if (VarGeneral.GeneralPrinter.ISA4PaperType)
                            {
                                MainCryRep = getdoc("InvAcc.Reports.RepGeneralSerial");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsCasheir.RepGeneralSerial");
                            }
                        }
                        else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                        {
                            MainCryRep = getdoc("InvAcc.ReportsE.RepGeneralSerial");
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepGeneralSerial");
                        }
                        ReportDocument rpt = MainCryRep;
                        rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                   setTarwisaa(rpt);try
                        {
                            (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                        }
                        catch
                        {
                        }
                        try
                        {
                            (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                        }
                        catch
                        {
                        }
                        if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                        {
                            rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                        }
                        else
                        {
                            rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                        }
                        rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                        rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                        rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                        rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                        rpt.SetParameterValue("vSts", false);
                        rpt.SetParameterValue("vLines", 1);
                        if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                        {
                            PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                        }
                        else
                        {
                            setpagesetting(rpt);
                        }
                    }
                    else if (repvalue == "RepGeneral2")
                    {
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            if (VarGeneral.GeneralPrinter.ISA4PaperType)
                            {
                                MainCryRep = getdoc("InvAcc.Reports.RepGeneral2");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsCasheir.RepGeneral2");
                            }
                        }
                        else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                        {
                            MainCryRep = getdoc("InvAcc.ReportsE.RepGeneral2");
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepGeneral2");
                        }
                        ReportDocument rpt = MainCryRep;
                        rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                   setTarwisaa(rpt);try
                        {
                            (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                        }
                        catch
                        {
                        }
                        try
                        {
                            (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                        }
                        catch
                        {
                        }
                        if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                        {
                            rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                        }
                        else
                        {
                            rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                        }
                        rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                        rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                        rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                        rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                        rpt.SetParameterValue("vSts", false);
                        rpt.SetParameterValue("vLines", 1);
                        if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                        {
                            PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                        }
                        else
                        {
                            setpagesetting(rpt);
                        }
                    }
                    else if (repvalue == "RepRequestAlarm")
                    {
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            if (VarGeneral.GeneralPrinter.ISA4PaperType)
                            {
                                MainCryRep = getdoc("InvAcc.Reports.RepRequestAlarm");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsCasheir.RepRequestAlarm");
                            }
                        }
                        else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                        {
                            MainCryRep = getdoc("InvAcc.ReportsE.RepRequestAlarm");
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepRequestAlarm");
                        }
                        ReportDocument rpt = MainCryRep;
                        rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                   setTarwisaa(rpt);try
                        {
                            (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                        }
                        catch
                        {
                        }
                        try
                        {
                            (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                        }
                        catch
                        {
                        }
                        if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                        {
                            rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                        }
                        else
                        {
                            rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                        }
                        rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                        rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                        rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                        rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                        rpt.SetParameterValue("vSts", false);
                        rpt.SetParameterValue("vLines", 1);
                        if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                        {
                            PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                        }
                        else
                        {
                            setpagesetting(rpt);
                        }
                    }
                    else if (repvalue == "RepDateExpir")
                    {
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            if (VarGeneral.GeneralPrinter.ISA4PaperType)
                            {
                                MainCryRep = getdoc("InvAcc.Reports.RepDateExpire");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsCasheir.RepDateExpire");
                            }
                        }
                        else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                        {
                            MainCryRep = getdoc("InvAcc.ReportsE.RepDateExpire");
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepDateExpire");
                        }
                        ReportDocument rpt = MainCryRep;
                        rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                   setTarwisaa(rpt);try
                        {
                            (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                        }
                        catch
                        {
                        }
                        try
                        {
                            (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                        }
                        catch
                        {
                        }
                        if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                        {
                            rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                        }
                        else
                        {
                            rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                        }
                        rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                        rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                        rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                        rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                        rpt.SetParameterValue("vSts", false);
                        rpt.SetParameterValue("vLines", 1);
                        if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                        {
                            PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                        }
                        else
                        {
                            setpagesetting(rpt);
                        }
                    }
                    else
                    {
                        if (repvalue == "InvoiceCachier")
                        {
                            bool flag;
                            printOrderNo = false;
                            this.printOrderNo = false;
                            if (VarGeneral.InvTyp == 1)
                            {
                                orientationSetting = VarGeneral.Settings_Sys.AutoEmp;
                                if ((orientationSetting.GetValueOrDefault() != 0 ? false : orientationSetting.HasValue) || VarGeneral.EmptyTablePrint)
                                {
                                    goto Label2;
                                }
                                flag = (!(VarGeneral.SSSLev != "R") || !(VarGeneral.SSSLev != "C") ? true : !(VarGeneral.SSSLev != "H"));
                                goto Label1;
                            }
                            Label2:
                            flag = false;
                            Label1:
                            if (flag)
                            {
                                orientationSetting = VarGeneral.Settings_Sys.AutoEmp;
                                if ((orientationSetting.GetValueOrDefault() != 1 ? 0 : (orientationSetting.HasValue == true ? 1 : 0)) == 0)
                                {
                                    this.STEP_Cachier_1();
                               
                                  if ((this.db.StockPrinterSetting(VarGeneral.UserID, 1).ISdirectPrinting ? true : this.BarcodSts))
                                    {
                                        this.STEP_Cachier_2();
                                    }
                                }
                                else
                                {
                                    this.STEP_Cachier_2();
                                }
                            }
                            else
                            {
                                this.STEP_Cachier_1();
                            }
                        }
                        if (repvalue == "InvoiceCachierWaiter")
                        {
                            if ((!db.StockInvSetting(21).PrintCat.Value && !db.StockInvSetting(21).autoCommGaid.Value) || (VarGeneral.SSSLev != "R" && VarGeneral.SSSLev != "C" && VarGeneral.SSSLev != "H") || _GroupsIsPrint)
                            {
                                STEP_Cachier_1();
                            }
                            else if (db.StockInvSetting(21).PrintCat.Value && !db.StockInvSetting(21).autoCommGaid.Value)
                            {
                                STEP_Cachier_2();
                            }
                            else
                            {
                                STEP_Cachier_1();
                                if (db.StockInvSetting(21).ISdirectPrinting || BarcodSts)
                                {
                                    STEP_Cachier_2();
                                }
                            }
                        }
                        else if (repvalue == "StatmentOfAccount")
                        {
                            long regval = 0L;
                            try
                            {
                                if (VarGeneral.SSSLev == "B" || VarGeneral.SSSLev == "F")
                                {
                                    RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", writable: true);
                                    try
                                    {
                                        object q = hKey.GetValue("vCoCe");
                                        if (string.IsNullOrEmpty(q.ToString()))
                                        {
                                            hKey.CreateSubKey("vCoCe");
                                            hKey.SetValue("vCoCe", "0");
                                        }
                                    }
                                    catch
                                    {
                                        hKey.CreateSubKey("vCoCe");
                                        hKey.SetValue("vCoCe", "0");
                                    }
                                    regval = long.Parse(hKey.GetValue("vCoCe").ToString());
                                }
                            }
                            catch
                            {
                                regval = 0L;
                            }
                            if (((VarGeneral.SSSLev == "B" || VarGeneral.SSSLev == "F") && regval == 0) || VarGeneral.SSSLev == "S" || VarGeneral.SSSLev == "C")
                            {
                                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                                {
                                    if (VarGeneral.GeneralPrinter.ISA4PaperType)
                                    {
                                        MainCryRep = getdoc("InvAcc.Reports.RepStatmentAccWithOutCostCenter");
                                    }
                                    else
                                    {
                                        MainCryRep = getdoc("InvAcc.ReportsCasheir.RepStatmentAccWithOutCostCenter");
                                    }
                                }
                                else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                                {
                                    MainCryRep = getdoc("InvAcc.ReportsE.RepStatmentAccWithOutCostCenter");
                                }
                                else
                                {
                                    MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepStatmentAccWithOutCostCenter");
                                }
                            }
                            else if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                if (VarGeneral.GeneralPrinter.ISA4PaperType)
                                {
                                    MainCryRep = getdoc("InvAcc.Reports.RepStatmentAcc");
                                }
                                else
                                {
                                    MainCryRep = getdoc("InvAcc.ReportsCasheir.RepStatmentAcc");
                                }
                            }
                            else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsE.RepStatmentAcc");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepStatmentAcc");
                            }
                            ReportDocument rpt = MainCryRep;
                            rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                       setTarwisaa(rpt);try
                            {
                                (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                            }
                            catch
                            {
                            }
                            try
                            {
                                (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                            }
                            catch
                            {
                            }
                            if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                            {
                                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                            }
                            else
                            {
                                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                            }
                            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                            rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                            rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                            rpt.SetParameterValue("vSts", false);
                            rpt.SetParameterValue("vLines", 1);
                            if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                            {
                                PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                            }
                            else
                            {
                                setpagesetting(rpt);
                            }
                        }
                        else if (repvalue == "RegRep")
                        {
                            ReportDocument rpt2 = getdoc("InvAcc.Reports.RepReg");
                            rpt2.SetParameterValue("F1", VarGeneral.AutoAlarmitms[1] + " ");
                            rpt2.SetParameterValue("F2", VarGeneral.AutoAlarmitms[2] + " ");
                            rpt2.SetParameterValue("F3", VarGeneral.AutoAlarmitms[3] + " ");
                            rpt2.SetParameterValue("F4", VarGeneral.AutoAlarmitms[4] + " ");
                            rpt2.SetParameterValue("F5", VarGeneral.AutoAlarmitms[5] + " ");
                            rpt2.SetParameterValue("F6", VarGeneral.AutoAlarmitms[6] + " ");
                            rpt2.SetParameterValue("F7", VarGeneral.AutoAlarmitms[7] + " ");
                            rpt2.SetParameterValue("F8", VarGeneral.AutoAlarmitms[8] + " ");
                            rpt2.SetParameterValue("F9", VarGeneral.AutoAlarmitms[9] + " ");
                            rpt2.SetParameterValue("F11", VarGeneral.AutoAlarmitms[11] + " ");
                            rpt2.SetParameterValue("F12", VarGeneral.AutoAlarmitms[12] + " ");
                            rpt2.SetParameterValue("F13", VarGeneral.AutoAlarmitms[13] + " ");
                            rpt2.SetParameterValue("F14", VarGeneral.AutoAlarmitms[14] + " ");
                            rpt2.SetParameterValue("F15", VarGeneral.AutoAlarmitms[15] + " ");
                            rpt2.SetParameterValue("F16", VarGeneral.AutoAlarmitms[16] + " ");
                            rpt2.SetParameterValue("F17", VarGeneral.AutoAlarmitms[17] + " ");
                            rpt2.SetParameterValue("F18", VarGeneral.AutoAlarmitms[18] + " ");
                            rpt2.SetParameterValue("F19", VarGeneral.AutoAlarmitms[19] + " ");
                            rpt2.SetParameterValue("F20", VarGeneral.AutoAlarmitms[20] + " ");
                            rpt2.SetParameterValue("F21", VarGeneral.AutoAlarmitms[21] + " ");
                            rpt2.SetParameterValue("Address1", VarGeneral.vCompany);
                            rpt2.SetParameterValue("Address2", VarGeneral.vAboutAddress2);
                            rpt2.SetParameterValue("fWeb", VarGeneral.vAboutWeb);
                            rpt2.SetParameterValue("fMail", VarGeneral.vAboutEmail);
                            rpt2.SetParameterValue("WinType", VarGeneral.AutoAlarmitms[22] + " ");
                            rpt2.SetParameterValue("CPU", VarGeneral.AutoAlarmitms[23] + " ");
                            rpt2.SetParameterValue("HardDisk", VarGeneral.AutoAlarmitms[24] + " ");
                            rpt2.SetParameterValue("MotherBoard", VarGeneral.AutoAlarmitms[25] + " ");
                            crystalReportViewe_RepShow.ReportSource = rpt2;
                        }
                        else if (repvalue == "RepGaidCatchTenant")
                        {
                            T_Printer _InvSetting = new T_Printer();
                            _InvSetting = db.StockPrinterSetting(VarGeneral.UserID, VarGeneral.InvTyp);
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                try
                                {
                                    if (VarGeneral.gUserName == "runsetting")
                                    {
                                        if (File.Exists(Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepGaidCatchTenantSingle.rpt"))
                                        {
                                            MainCryRep.FileName = Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepGaidCatchTenantSingle.rpt";
                                        }
                                        else
                                        {
                                            MainCryRep = getdoc("InvAcc.ReportEqar.RepGaidCatchTenantSingle");
                                        }
                                    }
                                    else if (File.Exists(Application.StartupPath + "\\Reps\\RepGaidCatchTenantSingle.rpt"))
                                    {
                                        MainCryRep.FileName = Application.StartupPath + "\\Reps\\RepGaidCatchTenantSingle.rpt";
                                    }
                                    else
                                    {
                                        MainCryRep = getdoc("InvAcc.ReportEqar.RepGaidCatchTenantSingle");
                                    }
                                }
                                catch
                                {
                                    MainCryRep = getdoc("InvAcc.ReportEqar.RepGaidCatchTenantSingle");
                                }
                            }
                            else
                            {
                                try
                                {
                                    if (VarGeneral.gUserName == "runsetting")
                                    {
                                        if (File.Exists(Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepGaidCatchTenantSingle.rpt"))
                                        {
                                            MainCryRep.FileName = Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepGaidCatchTenantSingle.rpt";
                                        }
                                        else
                                        {
                                            MainCryRep = getdoc("InvAcc.ReportEqarE.RepGaidCatchTenantSingle");
                                        }
                                    }
                                    else if (File.Exists(Application.StartupPath + "\\RepsE\\RepGaidCatchTenantSingle.rpt"))
                                    {
                                        MainCryRep.FileName = Application.StartupPath + "\\RepsE\\RepGaidCatchTenantSingle.rpt";
                                    }
                                    else
                                    {
                                        MainCryRep = getdoc("InvAcc.ReportEqarE.RepGaidCatchTenantSingle");
                                    }
                                }
                                catch
                                {
                                    MainCryRep = getdoc("InvAcc.ReportEqarE.RepGaidCatchTenantSingle");
                                }
                            }
                            ReportDocument rpt = MainCryRep;
                            rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                       setTarwisaa(rpt);try
                            {
                                rpt.SetParameterValue("IsCashCredit", VarGeneral.IsCashCredit ? "1" : "0");
                            }
                            catch
                            {
                            }
                            try
                            {
                                rpt.SetParameterValue("vDecimal", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? "1" : "0");
                            }
                            catch
                            {
                            }
                            try
                            {
                                rpt.SetParameterValue("IsTotWithTax", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 65) ? "1" : "0");
                            }
                            catch
                            {
                            }
                            try
                            {
                                (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                            }
                            catch
                            {
                            }
                            try
                            {
                                (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                            }
                            catch
                            {
                            }
                            rpt.SetParameterValue("SSSLev", (VarGeneral.SSSLev == "G") ? "Show" : "Hide");
                            if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                            {
                                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                            }
                            else
                            {
                                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                            }
                            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                            rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                            rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                            rpt.SetParameterValue("vSts", false);
                            rpt.SetParameterValue("vLines", 1);
                            if (_InvSetting.ISdirectPrinting || BarcodSts)
                            {
                                PrintSet(rpt, (int)_InvSetting.lnPg.Value, (_InvSetting.Orientation == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, _InvSetting.defSizePaper, _InvSetting.DefLines.Value, _InvSetting.defPrn, _InvSetting.hAs.Value, _InvSetting.hYs.Value, _InvSetting.hYm.Value, _InvSetting.hAl.Value);
                            }
                            else
                            {
                                setpagesetting(rpt);
                            }
                        }
                        else if (repvalue == "RepGaidSerfTenant")
                        {
                            T_Printer _InvSetting = new T_Printer();
                            _InvSetting = db.StockPrinterSetting(VarGeneral.UserID, VarGeneral.InvTyp);
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                try
                                {
                                    if (VarGeneral.gUserName == "runsetting")
                                    {
                                        if (File.Exists(Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepGaidSerfTenantSingle.rpt"))
                                        {
                                            MainCryRep.FileName = Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepGaidSerfTenantSingle.rpt";
                                        }
                                        else
                                        {
                                            MainCryRep = getdoc("InvAcc.ReportEqar.RepGaidSerfTenantSingle");
                                        }
                                    }
                                    else if (File.Exists(Application.StartupPath + "\\Reps\\RepGaidSerfTenantSingle.rpt"))
                                    {
                                        MainCryRep.FileName = Application.StartupPath + "\\Reps\\RepGaidSerfTenantSingle.rpt";
                                    }
                                    else
                                    {
                                        MainCryRep = getdoc("InvAcc.ReportEqar.RepGaidSerfTenantSingle");
                                    }
                                }
                                catch
                                {
                                    MainCryRep = getdoc("InvAcc.ReportEqar.RepGaidSerfTenantSingle");
                                }
                            }
                            else
                            {
                                try
                                {
                                    if (VarGeneral.gUserName == "runsetting")
                                    {
                                        if (File.Exists(Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepGaidSerfTenantSingle.rpt"))
                                        {
                                            MainCryRep.FileName = Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepGaidSerfTenantSingle.rpt";
                                        }
                                        else
                                        {
                                            MainCryRep = getdoc("InvAcc.ReportEqarE.RepGaidSerfTenantSingle");
                                        }
                                    }
                                    else if (File.Exists(Application.StartupPath + "\\RepsE\\RepGaidSerfTenantSingle.rpt"))
                                    {
                                        MainCryRep.FileName = Application.StartupPath + "\\RepsE\\RepGaidSerfTenantSingle.rpt";
                                    }
                                    else
                                    {
                                        MainCryRep = getdoc("InvAcc.ReportEqarE.RepGaidSerfTenantSingle");
                                    }
                                }
                                catch
                                {
                                    MainCryRep = getdoc("InvAcc.ReportEqarE.RepGaidSerfTenantSingle");
                                }
                            }
                            ReportDocument rpt = MainCryRep;
                            rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                       setTarwisaa(rpt);try
                            {
                                rpt.SetParameterValue("IsCashCredit", VarGeneral.IsCashCredit ? "1" : "0");
                            }
                            catch
                            {
                            }
                            try
                            {
                                rpt.SetParameterValue("vDecimal", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? "1" : "0");
                            }
                            catch
                            {
                            }
                            try
                            {
                                rpt.SetParameterValue("IsTotWithTax", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 65) ? "1" : "0");
                            }
                            catch
                            {
                            }
                            try
                            {
                                (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                            }
                            catch
                            {
                            }
                            try
                            {
                                (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                            }
                            catch
                            {
                            }
                            rpt.SetParameterValue("SSSLev", (VarGeneral.SSSLev == "G") ? "Show" : "Hide");
                            if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                            {
                                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                            }
                            else
                            {
                                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                            }
                            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                            rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                            rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                            rpt.SetParameterValue("vSts", false);
                            rpt.SetParameterValue("vLines", 1);
                            if (_InvSetting.ISdirectPrinting || BarcodSts)
                            {
                                PrintSet(rpt, (int)_InvSetting.lnPg.Value, (_InvSetting.Orientation == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, _InvSetting.defSizePaper, _InvSetting.DefLines.Value, _InvSetting.defPrn, _InvSetting.hAs.Value, _InvSetting.hYs.Value, _InvSetting.hYm.Value, _InvSetting.hAl.Value);
                            }
                            else
                            {
                                setpagesetting(rpt);
                            }
                        }
                        else if (repvalue == "AccountTrancEqar")
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                if (VarGeneral.GeneralPrinter.ISA4PaperType)
                                {
                                    MainCryRep = getdoc("InvAcc.ReportEqar.RepGeneralLedgerEqar");
                                }
                                else
                                {
                                    MainCryRep = getdoc("InvAcc.ReportEqarCashierA.RepGeneralLedgerEqar");
                                }
                            }
                            else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                            {
                                MainCryRep = getdoc("InvAcc.ReportEqarE.RepGeneralLedgerEqar");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportEqarCashierE.RepGeneralLedgerEqar");
                            }
                            ReportDocument rpt = MainCryRep;
                            rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                       setTarwisaa(rpt);try
                            {
                                (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                            }
                            catch
                            {
                            }
                            try
                            {
                                (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                            }
                            catch
                            {
                            }
                            if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                            {
                                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                            }
                            else
                            {
                                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                            }
                            try
                            {
                                rpt.SetParameterValue("DTFrom", VarGeneral._DTFrom);
                            }
                            catch
                            {
                            }
                            try
                            {
                                rpt.SetParameterValue("DTTo", VarGeneral._DTTo);
                            }
                            catch
                            {
                            }
                            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                            rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                            rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                            rpt.SetParameterValue("vSts", false);
                            rpt.SetParameterValue("vLines", 1);
                            if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                            {
                                PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                            }
                            else
                            {
                                setpagesetting(rpt);
                            }
                        }
                        else if (repvalue == "AccountEqar")
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                if (VarGeneral.GeneralPrinter.ISA4PaperType)
                                {
                                    MainCryRep = getdoc("InvAcc.ReportEqar.RepGeneralLedgerEqarData");
                                }
                                else
                                {
                                    MainCryRep = getdoc("InvAcc.ReportEqarCashierA.RepGeneralLedgerEqarData");
                                }
                            }
                            else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                            {
                                MainCryRep = getdoc("InvAcc.ReportEqarE.RepGeneralLedgerEqarData");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportEqarCashierE.RepGeneralLedgerEqarData");
                            }
                            ReportDocument rpt = MainCryRep;
                            rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                       setTarwisaa(rpt);try
                            {
                                (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                            }
                            catch
                            {
                            }
                            try
                            {
                                (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                            }
                            catch
                            {
                            }
                            if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                            {
                                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                            }
                            else
                            {
                                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                            }
                            try
                            {
                                rpt.SetParameterValue("DTFrom", VarGeneral._DTFrom);
                            }
                            catch
                            {
                            }
                            try
                            {
                                rpt.SetParameterValue("DTTo", VarGeneral._DTTo);
                            }
                            catch
                            {
                            }
                            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                            rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                            rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                            rpt.SetParameterValue("vSts", false);
                            rpt.SetParameterValue("vLines", 1);
                            if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                            {
                                PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                            }
                            else
                            {
                                setpagesetting(rpt);
                            }
                        }
                        else if (repvalue == "RentData")
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                if (VarGeneral.GeneralPrinter.ISA4PaperType)
                                {
                                    MainCryRep = getdoc("InvAcc.ReportEqar.RepRentEqarData");
                                }
                                else
                                {
                                    MainCryRep = getdoc("InvAcc.ReportEqarCashierA.RepRentEqarData");
                                }
                            }
                            else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                            {
                                MainCryRep = getdoc("InvAcc.ReportEqarE.RepRentEqarData");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportEqarCashierE.RepRentEqarData");
                            }
                            ReportDocument rpt = MainCryRep;
                            rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                       setTarwisaa(rpt);try
                            {
                                (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                            }
                            catch
                            {
                            }
                            try
                            {
                                (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                            }
                            catch
                            {
                            }
                            if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                            {
                                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                            }
                            else
                            {
                                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                            }
                            try
                            {
                                rpt.SetParameterValue("DTFrom", VarGeneral._DTFrom);
                            }
                            catch
                            {
                            }
                            try
                            {
                                rpt.SetParameterValue("DTTo", VarGeneral._DTTo);
                            }
                            catch
                            {
                            }
                            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                            rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                            rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                            rpt.SetParameterValue("vSts", false);
                            rpt.SetParameterValue("vLines", 1);
                            if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                            {
                                PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                            }
                            else
                            {
                                setpagesetting(rpt);
                            }
                        }
                        else if (repvalue == "RepAlarmTenant")
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                if (VarGeneral.GeneralPrinter.ISA4PaperType)
                                {
                                    MainCryRep = getdoc("InvAcc.ReportEqar.RepTenantAlarm");
                                }
                                else
                                {
                                    MainCryRep = getdoc("InvAcc.ReportEqarCashierA.RepTenantAlarm");
                                }
                            }
                            else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                            {
                                MainCryRep = getdoc("InvAcc.ReportEqarE.RepTenantAlarm");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportEqarCashierE.RepTenantAlarm");
                            }
                            ReportDocument rpt = MainCryRep;
                            rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                       setTarwisaa(rpt);try
                            {
                                (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                            }
                            catch
                            {
                            }
                            try
                            {
                                (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                            }
                            catch
                            {
                            }
                            if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                            {
                                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                            }
                            else
                            {
                                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                            }
                            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                            rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                            rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                            rpt.SetParameterValue("vSts", false);
                            rpt.SetParameterValue("vLines", 1);
                            if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                            {
                                PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                            }
                            else
                            {
                                setpagesetting(rpt);
                            }
                        }
                    }
                }
                try
                {
                    RepShow _RepShow = new RepShow();
                    _RepShow = new RepShow();
                    if (repvalue == "EmpsRepShort" || repvalue == "EmpsRepDet")
                    {
                        _RepShow.Tables = " T_Emp LEFT JOIN  T_Bank ON T_Emp.Bank = T_Bank.Bank_No LEFT JOIN  T_BloodTyp ON T_Emp.BloodTyp = T_BloodTyp.BloodTyp_No LEFT JOIN  T_City ON T_Emp.CityNo = T_City.City_No AND T_Emp.ID_From = T_City.City_No AND T_Emp.Passport_From = T_City.City_No AND  T_Emp.License_From = T_City.City_No AND T_Emp.Form_From = T_City.City_No AND T_Emp.Insurance_From = T_City.City_No AND  T_Emp.BirthPlace = T_City.City_No LEFT JOIN  T_Contract ON T_Emp.ContrTyp = T_Contract.Contract_No LEFT JOIN  T_Dept ON T_Emp.Dept = T_Dept.Dept_No LEFT JOIN  T_Guarantor ON T_Emp.Guarantor = T_Guarantor.Guarantor_No LEFT JOIN  T_Job ON T_Emp.Job = T_Job.Job_No LEFT JOIN  T_MStatus ON T_Emp.MaritalStatus = T_MStatus.MStatusNo LEFT JOIN  T_Nationalities ON T_Emp.Nationalty = T_Nationalities.Nation_No LEFT JOIN  T_Religion ON T_Emp.Religion = T_Religion.Religion_No LEFT JOIN  T_SalStatus ON T_Emp.StatusSal = T_SalStatus.SalStatusNo LEFT JOIN  T_Section ON T_Emp.Section = T_Section.Section_No LEFT JOIN  T_Sex ON T_Emp.Sex = T_Sex.SexNo  left JOIN T_SYSSETTING ON T_Emp.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            _RepShow.Fields = " T_Emp.*, T_SalStatus.NameA AS SalStatusNameA, T_MStatus.NameA AS MStatusNameA, T_Guarantor.NameA AS GuarantorNameA,T_Guarantor.Address AS GuarntorAddress,T_Guarantor.Tel as GuarntorTel, T_City.NameA AS CityNameA, \r\n                                 T_Bank.NameA AS BankNameA, T_Sex.NameA AS SexNameA, T_Dept.NameA as DeptNameA, T_Job.NameA as JobNameA, T_Section.NameA as SectionNameA, T_Religion.NameA as ReligionNameA, T_Nationalities.NameA as NationNameA, \r\n                                 T_Contract.NameA AS ContractTypNameA, T_BloodTyp.NameA AS BloodTypeNameA,T_SYSSETTING.LogImg as LogoPic  ";
                        }
                        else
                        {
                            _RepShow.Fields = " T_Emp.*, T_SalStatus.NameE AS SalStatusNameA, T_MStatus.NameE AS MStatusNameA, T_Guarantor.NameE AS GuarantorNameA,T_Guarantor.Address AS GuarntorAddress,T_Guarantor.Tel as GuarntorTel, T_City.NameE AS CityNameA, \r\n                                 T_Bank.NameE AS BankNameA, T_Sex.NameE AS SexNameA, T_Dept.NameE as DeptNameA, T_Job.NameE as JobNameA, T_Section.NameE as SectionNameA, T_Religion.NameE as ReligionNameA, T_Nationalities.NameE as NationNameA, \r\n                                 T_Contract.NameE AS ContractTypNameA, T_BloodTyp.NameE AS BloodTypeNameA,T_SYSSETTING.LogImg as LogoPic  ";
                        }
                        _RepShow.Rule = " Where 1 = 1 " + sqlWhere;
                        _RepShow.Brn_No = string.Empty;
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                        if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                        {
                            if (repvalue == "EmpsRepShort")
                            {
                                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                                {
                                    MainCryRep = getdoc("InvAcc.ReportsEmp.RepEmps");
                                }
                                else
                                {
                                    MainCryRep = getdoc("InvAcc.ReportsEmp.RepEmps");
                                }
                            }
                            else if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepEmpDet");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepEmpDet");
                            }
                            ReportDocument rpt = MainCryRep;
                            rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                       setTarwisaa(rpt);if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                            {
                                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                            }
                            else
                            {
                                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                            }
                            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                            rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                            rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                            rpt.SetParameterValue("vSts", false);
                            rpt.SetParameterValue("vLines", 1);
                            if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                            {
                                PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                            }
                            else
                            {
                                setpagesetting(rpt);
                            }
                        }
                        else
                        {
                            MessageBox.Show((VarGeneral.CurrentLang.ToString() == "0") ? "لا توجد حقول للطباعة تأكد من إعدادات الطباعة" : "No printing fields make sure the print settings", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else if (repvalue == "EmpsRepShort_")
                    {
                        _RepShow.Tables = " T_AccDef LEFT JOIN  T_SYSSETTING ON T_AccDef.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                        _RepShow.Fields = " T_AccDef.AccDef_No as Emp_No," + ((VarGeneral.CurrentLang.ToString() == "0") ? "T_AccDef.Arb_Des as NameA" : "T_AccDef.Eng_Des as NameA") + ",T_AccDef.Telphone1 as Tel,T_AccDef.Mobile as PO_Box,T_AccDef.Adders as AddressA,T_AccDef.MainSal,T_AccDef.DateAppointment,T_SYSSETTING.LogImg as LogoPic  ";
                        _RepShow.Rule = " Where 1 = 1 " + sqlWhere;
                        _RepShow.Brn_No = string.Empty;
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                        if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepEmployees");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmpE.RepEmployees");
                            }
                            ReportDocument rpt = MainCryRep;
                            rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                       setTarwisaa(rpt);if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                            {
                                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                            }
                            else
                            {
                                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                            }
                            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                            rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                            rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                            rpt.SetParameterValue("vSts", false);
                            rpt.SetParameterValue("vLines", 1);
                            if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                            {
                                PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                            }
                            else
                            {
                                setpagesetting(rpt);
                            }
                        }
                        else
                        {
                            MessageBox.Show((VarGeneral.CurrentLang.ToString() == "0") ? "لا توجد حقول للطباعة تأكد من إعدادات الطباعة" : "No printing fields make sure the print settings", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else if (repvalue == "EmpsRepDocumnts_")
                    {
                        _RepShow.Tables = " T_AccDef LEFT JOIN  T_SYSSETTING ON T_AccDef.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                        _RepShow.Fields = " T_AccDef.AccDef_No as Emp_No," + ((VarGeneral.CurrentLang.ToString() == "0") ? "T_AccDef.Arb_Des as NameA" : "T_AccDef.Eng_Des as NameA") + ",ID_No,Passport_No,Insurance_No,ID_From as Form_No ,Passport_From as Form_Date ,Insurance_From as Form_DateEnd ,Passport_Date,Insurance_Date,Passport_DateEnd,Insurance_DateEnd,ID_Date,ID_DateEnd,T_AccDef.MainSal,T_AccDef.DateAppointment,T_SYSSETTING.LogImg as LogoPic  ";
                        _RepShow.Rule = " Where 1 = 1 " + sqlWhere;
                        _RepShow.Brn_No = string.Empty;
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                        if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepEmployeesDoc");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmpE.RepEmployees");
                            }
                            ReportDocument rpt = MainCryRep;
                            rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                       setTarwisaa(rpt);if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                            {
                                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                            }
                            else
                            {
                                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                            }
                            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                            rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                            rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                            rpt.SetParameterValue("vSts", VarGeneral.EmpDocType);
                            rpt.SetParameterValue("vLines", 1);
                            if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                            {
                                PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                            }
                            else
                            {
                                setpagesetting(rpt);
                            }
                        }
                        else
                        {
                            MessageBox.Show((VarGeneral.CurrentLang.ToString() == "0") ? "لا توجد حقول للطباعة تأكد من إعدادات الطباعة" : "No printing fields make sure the print settings", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else if (repvalue == "AdvancRep")
                    {
                        _RepShow.Tables = " T_Advances left JOIN  T_Premiums ON T_Advances.Advances_No = T_Premiums.Advances_No left JOIN  T_Emp ON T_Advances.EmpID = T_Emp.Emp_ID  left JOIN T_SYSSETTING ON T_Emp.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            _RepShow.Fields = " T_Premiums.PremiumsDate, T_Emp.NameA, T_Emp.Emp_No,T_SYSSETTING.LogImg as LogoPic  , T_Premiums.ValuePremiums, T_Premiums.Paying, T_Advances.Note ";
                        }
                        else
                        {
                            _RepShow.Fields = " T_Premiums.PremiumsDate, T_Emp.NameE as NameA, T_Emp.Emp_No,T_SYSSETTING.LogImg as LogoPic  , T_Premiums.ValuePremiums, T_Premiums.Paying, T_Advances.Note ";
                        }
                        _RepShow.Rule = " Where 1 = 1 " + sqlWhere + " order by T_Advances.EmpID,T_Premiums.PremiumsDate ";
                        _RepShow.Brn_No = string.Empty;
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                        if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepAdvances");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepAdvances");
                            }
                            ReportDocument rpt = MainCryRep;
                            rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                       setTarwisaa(rpt);if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                            {
                                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                            }
                            else
                            {
                                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                            }
                            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                            rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                            rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                            rpt.SetParameterValue("vSts", false);
                            rpt.SetParameterValue("vLines", 1);
                            if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                            {
                                PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                            }
                            else
                            {
                                setpagesetting(rpt);
                            }
                        }
                        else
                        {
                            MessageBox.Show((VarGeneral.CurrentLang.ToString() == "0") ? "لا توجد حقول للطباعة تأكد من إعدادات الطباعة" : "No printing fields make sure the print settings", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else if (repvalue == "IDRep")
                    {
                        _RepShow.Tables = " T_Emp left JOIN T_Bank ON T_Emp.Bank = T_Bank.Bank_No  LEFT JOIN T_City ON T_Emp.ID_From = T_City.City_No LEFT JOIN T_Dept ON T_Emp.Dept = T_Dept.Dept_No LEFT JOIN T_BloodTyp ON T_Emp.BloodTyp = T_BloodTyp.BloodTyp_No LEFT JOIN T_Sex ON T_Emp.Sex = T_Sex.SexNo LEFT JOIN T_Section ON T_Emp.Section = T_Section.Section_No LEFT JOIN T_SalStatus ON T_Emp.StatusSal = T_SalStatus.SalStatusNo LEFT JOIN T_Contract ON T_Emp.ContrTyp = T_Contract.Contract_No LEFT JOIN T_Religion ON T_Emp.Religion = T_Religion.Religion_No LEFT JOIN T_Nationalities ON T_Emp.Nationalty = T_Nationalities.Nation_No LEFT JOIN T_Job ON T_Emp.Job = T_Job.Job_No  left JOIN T_SYSSETTING ON T_Emp.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            _RepShow.Fields = " T_Emp.*,T_SYSSETTING.LogImg as LogoPic  , T_Dept.NameA as DeptNameA, T_Job.NameA as JobNameA, T_Section.NameA as SectionNameA ,T_City.NameA as CityNameA, T_Nationalities.NameA as NationNameA";
                        }
                        else
                        {
                            _RepShow.Fields = " T_Emp.*,T_SYSSETTING.LogImg as LogoPic  , T_Dept.NameE as DeptNameA, T_Job.NameE as JobNameA, T_Section.NameE as SectionNameA ,T_City.NameE as CityNameA, T_Nationalities.NameE as NationNameA";
                        }
                        _RepShow.Rule = " Where 1 = 1 " + sqlWhere;
                        _RepShow.Brn_No = string.Empty;
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                        if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepID");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepID");
                            }
                            ReportDocument rpt = MainCryRep;
                            rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                       setTarwisaa(rpt);if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                            {
                                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                            }
                            else
                            {
                                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                            }
                            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                            rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                            rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                            rpt.SetParameterValue("vSts", false);
                            rpt.SetParameterValue("vLines", 1);
                            if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                            {
                                PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                            }
                            else
                            {
                                setpagesetting(rpt);
                            }
                        }
                        else
                        {
                            MessageBox.Show((VarGeneral.CurrentLang.ToString() == "0") ? "لا توجد حقول للطباعة تأكد من إعدادات الطباعة" : "No printing fields make sure the print settings", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else if (repvalue == "PassportRep")
                    {
                        _RepShow.Tables = " T_Emp left JOIN T_Bank ON T_Emp.Bank = T_Bank.Bank_No  LEFT JOIN T_City ON T_Emp.Passport_From = T_City.City_No LEFT JOIN T_Dept ON T_Emp.Dept = T_Dept.Dept_No LEFT JOIN T_BloodTyp ON T_Emp.BloodTyp = T_BloodTyp.BloodTyp_No LEFT JOIN T_Sex ON T_Emp.Sex = T_Sex.SexNo LEFT JOIN T_Section ON T_Emp.Section = T_Section.Section_No LEFT JOIN T_SalStatus ON T_Emp.StatusSal = T_SalStatus.SalStatusNo LEFT JOIN T_Contract ON T_Emp.ContrTyp = T_Contract.Contract_No LEFT JOIN T_Religion ON T_Emp.Religion = T_Religion.Religion_No LEFT JOIN T_Nationalities ON T_Emp.Nationalty = T_Nationalities.Nation_No LEFT JOIN T_Job ON T_Emp.Job = T_Job.Job_No  left JOIN T_SYSSETTING ON T_Emp.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            _RepShow.Fields = " T_Emp.*,T_SYSSETTING.LogImg as LogoPic  , T_Dept.NameA as DeptNameA, T_Job.NameA as JobNameA, T_Section.NameA as SectionNameA ,T_City.NameA as CityNameA, T_Nationalities.NameA as NationNameA";
                        }
                        else
                        {
                            _RepShow.Fields = " T_Emp.*,T_SYSSETTING.LogImg as LogoPic  , T_Dept.NameE as DeptNameA, T_Job.NameE as JobNameA, T_Section.NameE as SectionNameA ,T_City.NameE as CityNameA, T_Nationalities.NameE as NationNameA";
                        }
                        _RepShow.Rule = " Where 1 = 1 " + sqlWhere;
                        _RepShow.Brn_No = string.Empty;
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                        if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepPassport");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepPassport");
                            }
                            ReportDocument rpt = MainCryRep;
                            rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                       setTarwisaa(rpt);if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                            {
                                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                            }
                            else
                            {
                                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                            }
                            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                            rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                            rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                            rpt.SetParameterValue("vSts", false);
                            rpt.SetParameterValue("vLines", 1);
                            if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                            {
                                PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                            }
                            else
                            {
                                setpagesetting(rpt);
                            }
                        }
                        else
                        {
                            MessageBox.Show((VarGeneral.CurrentLang.ToString() == "0") ? "لا توجد حقول للطباعة تأكد من إعدادات الطباعة" : "No printing fields make sure the print settings", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else if (repvalue == "licensRep")
                    {
                        _RepShow.Tables = " T_Emp left JOIN T_Bank ON T_Emp.Bank = T_Bank.Bank_No  LEFT JOIN T_City ON T_Emp.License_From = T_City.City_No LEFT JOIN T_Dept ON T_Emp.Dept = T_Dept.Dept_No LEFT JOIN T_BloodTyp ON T_Emp.BloodTyp = T_BloodTyp.BloodTyp_No LEFT JOIN T_Sex ON T_Emp.Sex = T_Sex.SexNo LEFT JOIN T_Section ON T_Emp.Section = T_Section.Section_No LEFT JOIN T_SalStatus ON T_Emp.StatusSal = T_SalStatus.SalStatusNo LEFT JOIN T_Contract ON T_Emp.ContrTyp = T_Contract.Contract_No LEFT JOIN T_Religion ON T_Emp.Religion = T_Religion.Religion_No LEFT JOIN T_Nationalities ON T_Emp.Nationalty = T_Nationalities.Nation_No LEFT JOIN T_Job ON T_Emp.Job = T_Job.Job_No  left JOIN T_SYSSETTING ON T_Emp.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            _RepShow.Fields = " T_Emp.*,T_SYSSETTING.LogImg as LogoPic  , T_Dept.NameA as DeptNameA, T_Job.NameA as JobNameA, T_Section.NameA as SectionNameA ,T_City.NameA as CityNameA, T_Nationalities.NameA as NationNameA";
                        }
                        else
                        {
                            _RepShow.Fields = " T_Emp.*,T_SYSSETTING.LogImg as LogoPic  , T_Dept.NameE as DeptNameA, T_Job.NameE as JobNameA, T_Section.NameE as SectionNameA ,T_City.NameE as CityNameA, T_Nationalities.NameE as NationNameA";
                        }
                        _RepShow.Rule = " Where 1 = 1 " + sqlWhere;
                        _RepShow.Brn_No = string.Empty;
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                        if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepLicen");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepLicen");
                            }
                            ReportDocument rpt = MainCryRep;
                            rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                       setTarwisaa(rpt);if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                            {
                                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                            }
                            else
                            {
                                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                            }
                            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                            rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                            rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                            rpt.SetParameterValue("vSts", false);
                            rpt.SetParameterValue("vLines", 1);
                            if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                            {
                                PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                            }
                            else
                            {
                                setpagesetting(rpt);
                            }
                        }
                        else
                        {
                            MessageBox.Show((VarGeneral.CurrentLang.ToString() == "0") ? "لا توجد حقول للطباعة تأكد من إعدادات الطباعة" : "No printing fields make sure the print settings", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else if (repvalue == "FormsRep")
                    {
                        _RepShow.Tables = " T_Emp left JOIN T_Bank ON T_Emp.Bank = T_Bank.Bank_No  LEFT JOIN T_City ON T_Emp.Form_From = T_City.City_No LEFT JOIN T_Dept ON T_Emp.Dept = T_Dept.Dept_No LEFT JOIN T_BloodTyp ON T_Emp.BloodTyp = T_BloodTyp.BloodTyp_No LEFT JOIN T_Sex ON T_Emp.Sex = T_Sex.SexNo LEFT JOIN T_Section ON T_Emp.Section = T_Section.Section_No LEFT JOIN T_SalStatus ON T_Emp.StatusSal = T_SalStatus.SalStatusNo LEFT JOIN T_Contract ON T_Emp.ContrTyp = T_Contract.Contract_No LEFT JOIN T_Religion ON T_Emp.Religion = T_Religion.Religion_No LEFT JOIN T_Nationalities ON T_Emp.Nationalty = T_Nationalities.Nation_No LEFT JOIN T_Job ON T_Emp.Job = T_Job.Job_No  left JOIN T_SYSSETTING ON T_Emp.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            _RepShow.Fields = " T_Emp.*,T_SYSSETTING.LogImg as LogoPic  , T_Dept.NameA as DeptNameA, T_Job.NameA as JobNameA, T_Section.NameA as SectionNameA ,T_City.NameA as CityNameA, T_Nationalities.NameA as NationNameA";
                        }
                        else
                        {
                            _RepShow.Fields = " T_Emp.*,T_SYSSETTING.LogImg as LogoPic  , T_Dept.NameE as DeptNameA, T_Job.NameE as JobNameA, T_Section.NameE as SectionNameA ,T_City.NameE as CityNameA, T_Nationalities.NameE as NationNameA";
                        }
                        _RepShow.Rule = " Where 1 = 1 " + sqlWhere;
                        _RepShow.Brn_No = string.Empty;
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                        if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepForms");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepForms");
                            }
                            ReportDocument rpt = MainCryRep;
                            rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                       setTarwisaa(rpt);if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                            {
                                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                            }
                            else
                            {
                                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                            }
                            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                            rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                            rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                            rpt.SetParameterValue("vSts", false);
                            rpt.SetParameterValue("vLines", 1);
                            if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                            {
                                PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                            }
                            else
                            {
                                setpagesetting(rpt);
                            }
                        }
                        else
                        {
                            MessageBox.Show((VarGeneral.CurrentLang.ToString() == "0") ? "لا توجد حقول للطباعة تأكد من إعدادات الطباعة" : "No printing fields make sure the print settings", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else if (repvalue == "EmpMidicalRep")
                    {
                        _RepShow.Tables = " T_Emp left JOIN T_Bank ON T_Emp.Bank = T_Bank.Bank_No  LEFT JOIN T_City ON T_Emp.Insurance_From = T_City.City_No LEFT JOIN T_Dept ON T_Emp.Dept = T_Dept.Dept_No LEFT JOIN T_BloodTyp ON T_Emp.BloodTyp = T_BloodTyp.BloodTyp_No LEFT JOIN T_Sex ON T_Emp.Sex = T_Sex.SexNo LEFT JOIN T_Section ON T_Emp.Section = T_Section.Section_No LEFT JOIN T_SalStatus ON T_Emp.StatusSal = T_SalStatus.SalStatusNo LEFT JOIN T_Contract ON T_Emp.ContrTyp = T_Contract.Contract_No LEFT JOIN T_Religion ON T_Emp.Religion = T_Religion.Religion_No LEFT JOIN T_Nationalities ON T_Emp.Nationalty = T_Nationalities.Nation_No LEFT JOIN T_Job ON T_Emp.Job = T_Job.Job_No LEFT JOIN T_Insurance ON T_Emp.InsuranceNo = T_Insurance.Insurance_No  left JOIN T_SYSSETTING ON T_Emp.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            _RepShow.Fields = " T_Emp.*,T_Insurance.NameA as CompanyInsuranceNm,T_SYSSETTING.LogImg as LogoPic , T_Dept.NameA as DeptNameA, T_Job.NameA as JobNameA, T_Section.NameA as SectionNameA ,T_City.NameA as CityNameA, T_Nationalities.NameA as NationNameA";
                        }
                        else
                        {
                            _RepShow.Fields = " T_Emp.*,,T_Insurance.NameE as CompanyInsuranceNm ,T_SYSSETTING.LogImg as LogoPic  , T_Dept.NameE as DeptNameA, T_Job.NameE as JobNameA, T_Section.NameE as SectionNameA ,T_City.NameE as CityNameA, T_Nationalities.NameE as NationNameA";
                        }
                        _RepShow.Rule = " Where 1 = 1 " + sqlWhere;
                        _RepShow.Brn_No = string.Empty;
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                        if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepInsurance");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepInsurance");
                            }
                            ReportDocument rpt = MainCryRep;
                            rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                       setTarwisaa(rpt);if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                            {
                                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                            }
                            else
                            {
                                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                            }
                            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                            rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                            rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                            rpt.SetParameterValue("vSts", false);
                            rpt.SetParameterValue("vLines", 1);
                            if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                            {
                                PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                            }
                            else
                            {
                                setpagesetting(rpt);
                            }
                        }
                        else
                        {
                            MessageBox.Show((VarGeneral.CurrentLang.ToString() == "0") ? "لا توجد حقول للطباعة تأكد من إعدادات الطباعة" : "No printing fields make sure the print settings", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else if (repvalue == "RepSecretariats")
                    {
                        _RepShow.Tables = " T_SecretariatsTyp Right JOIN \r\n                                         T_Secretariats ON T_SecretariatsTyp.SecretariatTyp_No = T_Secretariats.SecretariatsTyp left JOIN \r\n                                         T_Emp ON T_Secretariats.EmpID = T_Emp.Emp_ID  \r\n                                         LEFT JOIN  T_SYSSETTING ON T_Emp.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            _RepShow.Fields = " T_Emp.*, T_Secretariats.warnDate,T_SYSSETTING.LogImg as LogoPic, T_Secretariats.StartDate, T_Secretariats.EndDate, T_Secretariats.Note, T_Secretariats.IFState, \r\n                                             T_SecretariatsTyp.NameA AS TypeName";
                        }
                        else
                        {
                            _RepShow.Fields = " T_Emp.*, T_Secretariats.warnDate,T_SYSSETTING.LogImg as LogoPic, T_Secretariats.StartDate, T_Secretariats.EndDate, T_Secretariats.Note, T_Secretariats.IFState, \r\n                                             T_SecretariatsTyp.NameE AS TypeName";
                        }
                        _RepShow.Rule = " Where 1 = 1 " + sqlWhere;
                        _RepShow.Brn_No = string.Empty;
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                        if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepSecriatries");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepSecriatries");
                            }
                            ReportDocument rpt = MainCryRep;
                            rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                       setTarwisaa(rpt);if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                            {
                                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                            }
                            else
                            {
                                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                            }
                            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                            rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                            rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                            rpt.SetParameterValue("vSts", false);
                            rpt.SetParameterValue("vLines", 1);
                            if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                            {
                                PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                            }
                            else
                            {
                                setpagesetting(rpt);
                            }
                        }
                        else
                        {
                            MessageBox.Show((VarGeneral.CurrentLang.ToString() == "0") ? "لا توجد حقول للطباعة تأكد من إعدادات الطباعة" : "No printing fields make sure the print settings", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else if (repvalue == "AuthorizRep")
                    {
                        _RepShow.Tables = " T_Emp INNER JOIN  T_Authorization ON T_Emp.Emp_ID = T_Authorization.EmpID  left JOIN T_SYSSETTING ON T_Emp.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            _RepShow.Fields = "  T_Emp.NameA, T_Emp.Emp_No,T_SYSSETTING.LogImg as LogoPic  , T_Authorization.Date, T_Authorization.ExitTime, T_Authorization.BackTime, T_Authorization.reason, T_Authorization.RTime,T_Authorization.Note ";
                        }
                        else
                        {
                            _RepShow.Fields = "  T_Emp.NameE as NameA, T_Emp.Emp_No,T_SYSSETTING.LogImg as LogoPic  , T_Authorization.Date, T_Authorization.ExitTime, T_Authorization.BackTime, T_Authorization.reason, T_Authorization.RTime,T_Authorization.Note ";
                        }
                        _RepShow.Rule = " Where 1 = 1 " + sqlWhere;
                        _RepShow.Brn_No = string.Empty;
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                        if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepAuthorization");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepAuthorization");
                            }
                            ReportDocument rpt = MainCryRep;
                            rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                       setTarwisaa(rpt);if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                            {
                                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                            }
                            else
                            {
                                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                            }
                            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                            rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                            rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                            rpt.SetParameterValue("vSts", false);
                            rpt.SetParameterValue("vLines", 1);
                            if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                            {
                                PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                            }
                            else
                            {
                                setpagesetting(rpt);
                            }
                        }
                        else
                        {
                            MessageBox.Show((VarGeneral.CurrentLang.ToString() == "0") ? "لا توجد حقول للطباعة تأكد من إعدادات الطباعة" : "No printing fields make sure the print settings", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else if (repvalue == "VisaGoBackRep")
                    {
                        _RepShow.Tables = "T_VisaGoBack Left JOIN  T_Emp ON T_VisaGoBack.EmpID = T_Emp.Emp_ID  left JOIN  T_SYSSETTING ON T_Emp.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            _RepShow.Fields = " T_Emp.Emp_No, T_Emp.NameA,T_SYSSETTING.LogImg as LogoPic  , T_VisaGoBack.warnDate, T_VisaGoBack.VisaNo, T_VisaGoBack.VisaPlace, T_VisaGoBack.VisaBeginDate,T_VisaGoBack.VisaEndDate,T_VisaGoBack.DateGo,T_VisaGoBack.DateBack  ";
                        }
                        else
                        {
                            _RepShow.Fields = " T_Emp.Emp_No, T_Emp.NameE as NameA,T_SYSSETTING.LogImg as LogoPic  , T_VisaGoBack.warnDate, T_VisaGoBack.VisaNo, T_VisaGoBack.VisaPlace, T_VisaGoBack.VisaBeginDate,T_VisaGoBack.VisaEndDate,T_VisaGoBack.DateGo,T_VisaGoBack.DateBack  ";
                        }
                        _RepShow.Rule = " Where 1 = 1 " + sqlWhere;
                        _RepShow.Brn_No = string.Empty;
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                        if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepVisa");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepVisa");
                            }
                            ReportDocument rpt = MainCryRep;
                            rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                       setTarwisaa(rpt);if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                            {
                                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                            }
                            else
                            {
                                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                            }
                            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                            rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                            rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                            rpt.SetParameterValue("vSts", false);
                            rpt.SetParameterValue("vLines", 1);
                            if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                            {
                                PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                            }
                            else
                            {
                                setpagesetting(rpt);
                            }
                        }
                        else
                        {
                            MessageBox.Show((VarGeneral.CurrentLang.ToString() == "0") ? "لا توجد حقول للطباعة تأكد من إعدادات الطباعة" : "No printing fields make sure the print settings", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else if (repvalue == "VisaIntroRep")
                    {
                        _RepShow.Tables = "T_VisaIntroduction Left JOIN  T_Emp ON T_VisaIntroduction.EmpID = T_Emp.Emp_ID  left JOIN  T_SYSSETTING ON T_Emp.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            _RepShow.Fields = " T_Emp.Emp_No, T_Emp.NameA,T_SYSSETTING.LogImg as LogoPic  , T_VisaIntroduction.warnDate, T_VisaIntroduction.VisaNo, T_VisaIntroduction.VisaPlace, T_VisaIntroduction.VisaBeginDate,T_VisaIntroduction.VisaEndDate,T_VisaIntroduction.DateGo,T_VisaIntroduction.DateBack  ";
                        }
                        else
                        {
                            _RepShow.Fields = " T_Emp.Emp_No, T_Emp.NameE as NameA,T_SYSSETTING.LogImg as LogoPic  , T_VisaIntroduction.warnDate, T_VisaIntroduction.VisaNo, T_VisaIntroduction.VisaPlace, T_VisaIntroduction.VisaBeginDate,T_VisaIntroduction.VisaEndDate,T_VisaIntroduction.DateGo,T_VisaIntroduction.DateBack  ";
                        }
                        _RepShow.Rule = " Where 1 = 1 " + sqlWhere;
                        _RepShow.Brn_No = string.Empty;
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                        if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepVisaIntro");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepVisaIntro");
                            }
                            ReportDocument rpt = MainCryRep;
                            rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                       setTarwisaa(rpt);if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                            {
                                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                            }
                            else
                            {
                                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                            }
                            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                            rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                            rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                            rpt.SetParameterValue("vSts", false);
                            rpt.SetParameterValue("vLines", 1);
                            if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                            {
                                PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                            }
                            else
                            {
                                setpagesetting(rpt);
                            }
                        }
                        else
                        {
                            MessageBox.Show((VarGeneral.CurrentLang.ToString() == "0") ? "لا توجد حقول للطباعة تأكد من إعدادات الطباعة" : "No printing fields make sure the print settings", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else if (repvalue == "AddRep")
                    {
                        _RepShow.Tables = "T_Add Left JOIN  T_Emp ON T_Add.EmpID = T_Emp.Emp_ID  left JOIN  T_AddTyp on T_AddTyp.AddTyp_No = T_Add.AddTyp  left JOIN T_SYSSETTING ON T_Emp.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            _RepShow.Fields = " T_Emp.Emp_No, T_Emp.NameA,T_SYSSETTING.LogImg as LogoPic  , T_Add.warnDate, T_Add.AddTotaly, T_Add.Note, T_AddTyp.NameA AS AddTypNameA ";
                        }
                        else
                        {
                            _RepShow.Fields = " T_Emp.Emp_No, T_Emp.NameE as NameA,T_SYSSETTING.LogImg as LogoPic  , T_Add.warnDate, T_Add.AddTotaly, T_Add.Note, T_AddTyp.NameE AS AddTypNameA ";
                        }
                        _RepShow.Rule = " Where 1 = 1 " + sqlWhere;
                        _RepShow.Brn_No = string.Empty;
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                        if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepAdd");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepAdd");
                            }
                            ReportDocument rpt = MainCryRep;
                            rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                       setTarwisaa(rpt);if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                            {
                                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                            }
                            else
                            {
                                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                            }
                            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                            rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                            rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                            rpt.SetParameterValue("vSts", false);
                            rpt.SetParameterValue("vLines", 1);
                            if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                            {
                                PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                            }
                            else
                            {
                                setpagesetting(rpt);
                            }
                        }
                        else
                        {
                            MessageBox.Show((VarGeneral.CurrentLang.ToString() == "0") ? "لا توجد حقول للطباعة تأكد من إعدادات الطباعة" : "No printing fields make sure the print settings", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else if (repvalue == "CommentaryRep")
                    {
                        _RepShow.Tables = "T_Commentary Left JOIN  T_Emp ON T_Commentary.EmpID = T_Emp.Emp_ID  left JOIN  T_treatment on T_treatment.treatment_No = T_Commentary.treatmentNo  left JOIN T_SYSSETTING ON T_Emp.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            _RepShow.Fields = " T_Emp.Emp_No, T_Emp.NameA,T_SYSSETTING.LogImg as LogoPic  , T_Commentary.warnDate, T_Commentary.Value as AddTotaly, T_Commentary.Note, T_treatment.NameA AS AddTypNameA ";
                        }
                        else
                        {
                            _RepShow.Fields = " T_Emp.Emp_No, T_Emp.NameE as NameA,T_SYSSETTING.LogImg as LogoPic  , T_Commentary.warnDate, T_Commentary.Value as AddTotaly, T_Commentary.Note, T_treatment.NameE AS AddTypNameA ";
                        }
                        _RepShow.Rule = " Where 1 = 1 " + sqlWhere;
                        _RepShow.Brn_No = string.Empty;
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                        if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepCommantry");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepCommantry");
                            }
                            ReportDocument rpt = MainCryRep;
                            rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                       setTarwisaa(rpt);if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                            {
                                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                            }
                            else
                            {
                                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                            }
                            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                            rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                            rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                            rpt.SetParameterValue("vSts", false);
                            rpt.SetParameterValue("vLines", 1);
                            if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                            {
                                PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                            }
                            else
                            {
                                setpagesetting(rpt);
                            }
                        }
                        else
                        {
                            MessageBox.Show((VarGeneral.CurrentLang.ToString() == "0") ? "لا توجد حقول للطباعة تأكد من إعدادات الطباعة" : "No printing fields make sure the print settings", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else if (repvalue == "CarRep")
                    {
                        _RepShow.Tables = " T_Cars INNER JOIN T_CarTyp ON T_Cars.CarType = T_CarTyp.CarTyp_No  Right JOIN T_SYSSETTING ON T_Cars.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            _RepShow.Fields = " T_Cars.Car_No, T_Cars.NameA as CarNmA, T_Cars.Model, T_Cars.PlateNo, T_Cars.Color, T_Cars.Note, T_Cars.FormNo, T_Cars.FormBeginDate, T_Cars.FormEndDate, T_Cars.AllownceNo, T_Cars.AllownceBeginDate, T_Cars.AllownceEndDate, T_Cars.AllownceName, T_Cars.PlayCardNo,T_Cars.PlayCardBeginDate, T_Cars.PlayCardEndDate, T_CarTyp.NameA AS carTypeNmA,T_SYSSETTING.LogImg as LogoPic ";
                        }
                        else
                        {
                            _RepShow.Fields = " T_Cars.Car_No, T_Cars.NameE as CarNmA, T_Cars.Model, T_Cars.PlateNo, T_Cars.Color, T_Cars.Note, T_Cars.FormNo, T_Cars.FormBeginDate, T_Cars.FormEndDate, T_Cars.AllownceNo, T_Cars.AllownceBeginDate, T_Cars.AllownceEndDate, T_Cars.AllownceName, T_Cars.PlayCardNo,T_Cars.PlayCardBeginDate, T_Cars.PlayCardEndDate, T_CarTyp.NameE AS carTypeNmA,T_SYSSETTING.LogImg as LogoPic ";
                        }
                        _RepShow.Rule = " Where 1 = 1 " + sqlWhere;
                        _RepShow.Brn_No = string.Empty;
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                        if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepCars");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepCars");
                            }
                            ReportDocument rpt = MainCryRep;
                            rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                       setTarwisaa(rpt);if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                            {
                                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                            }
                            else
                            {
                                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                            }
                            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                            rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                            rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                            rpt.SetParameterValue("vSts", false);
                            rpt.SetParameterValue("vLines", 1);
                            if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                            {
                                PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                            }
                            else
                            {
                                setpagesetting(rpt);
                            }
                        }
                        else
                        {
                            MessageBox.Show((VarGeneral.CurrentLang.ToString() == "0") ? "لا توجد حقول للطباعة تأكد من إعدادات الطباعة" : "No printing fields make sure the print settings", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else if (repvalue == "UpdateDoc")
                    {
                        _RepShow.Tables = " T_UpdateDoc left JOIN  T_Insurance ON T_UpdateDoc.InsuranceNoAfter = T_Insurance.Insurance_No or T_UpdateDoc.InsuranceNoBefor = T_Insurance.Insurance_No left JOIN  T_Emp ON T_UpdateDoc.EmpID = T_Emp.Emp_ID left JOIN  T_SYSSETTING ON T_Emp.CompanyID = T_SYSSETTING.SYSSETTING_ID left JOIN  T_City ON T_UpdateDoc.DocFrom = T_City.City_No or T_UpdateDoc.DocFromAfter = T_City.City_No ";
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            _RepShow.Fields = " UpdateDoc_ID,T_UpdateDoc.EmpID, warnNo, warnDate, T_UpdateDoc.Note, BeginDateBefor, BeginDateAfter, EndDateAfter, EndDateBefor, DocNo,T_City.NameA as DocFrom, Insurance_NameBefor,T_Insurance.NameA as InsuranceNoBefor, Insurance_NameAfter,T_Insurance.NameA as InsuranceNoAfter,CASE DocTyp when 0 Then 'تجديد الهوية' WHEN  1 Then 'تجديد الجواز' WHEN  2 Then 'تجديد الرخصة' else 'تجديد التأمين' end as DocTyp, DocNoAfter,T_City.NameA as DocFromAfter, T_Emp.NameA as NameA,T_SYSSETTING.LogImg as LogoPic";
                        }
                        else
                        {
                            _RepShow.Fields = " UpdateDoc_ID,T_UpdateDoc.EmpID, warnNo, warnDate, T_UpdateDoc.Note, BeginDateBefor, BeginDateAfter, EndDateAfter, EndDateBefor, DocNo,T_City.NameE as DocFrom, Insurance_NameBefor,T_Insurance.NameE as InsuranceNoBefor, Insurance_NameAfter,T_Insurance.NameE as InsuranceNoAfter,CASE DocTyp when 0 Then 'ID' WHEN  1 Then 'Passport' WHEN  2 Then 'Licenses' else 'Allownce' end as DocTyp, DocNoAfter,T_City.NameE as DocFromAfter, T_Emp.NameE as NameA,T_SYSSETTING.LogImg as LogoPic";
                        }
                        _RepShow.Rule = " Where DocTyp <> 4 " + sqlWhere;
                        _RepShow.Brn_No = string.Empty;
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                        if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepUpdateDoc");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepUpdateDoc");
                            }
                            ReportDocument rpt = MainCryRep;
                            rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                       setTarwisaa(rpt);if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                            {
                                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                            }
                            else
                            {
                                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                            }
                            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                            rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                            rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                            rpt.SetParameterValue("vSts", false);
                            rpt.SetParameterValue("vLines", 1);
                            if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                            {
                                PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                            }
                            else
                            {
                                setpagesetting(rpt);
                            }
                        }
                        else
                        {
                            MessageBox.Show((VarGeneral.CurrentLang.ToString() == "0") ? "لا توجد حقول للطباعة تأكد من إعدادات الطباعة" : "No printing fields make sure the print settings", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else if (repvalue == "UpdateDocAllownce")
                    {
                        _RepShow.Tables = " T_UpdateDoc left JOIN  T_Insurance ON T_UpdateDoc.InsuranceNoAfter = T_Insurance.Insurance_No or T_UpdateDoc.InsuranceNoBefor = T_Insurance.Insurance_No left JOIN  T_Emp ON T_UpdateDoc.EmpID = T_Emp.Emp_ID left JOIN  T_SYSSETTING ON T_Emp.CompanyID = T_SYSSETTING.SYSSETTING_ID left JOIN  T_City ON T_UpdateDoc.DocFrom = T_City.City_No or T_UpdateDoc.DocFromAfter = T_City.City_No ";
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            _RepShow.Fields = " UpdateDoc_ID,T_UpdateDoc.EmpID, warnNo, warnDate, T_UpdateDoc.Note, BeginDateBefor, BeginDateAfter, EndDateAfter, EndDateBefor, DocNo,T_City.NameA as DocFrom, Insurance_NameBefor,T_Insurance.NameA as InsuranceNoBefor, Insurance_NameAfter,T_Insurance.NameA as InsuranceNoAfter,DocTyp, DocNoAfter,T_City.NameA as DocFromAfter, T_Emp.NameA as NameA,T_SYSSETTING.LogImg as LogoPic";
                        }
                        else
                        {
                            _RepShow.Fields = " UpdateDoc_ID,T_UpdateDoc.EmpID, warnNo, warnDate, T_UpdateDoc.Note, BeginDateBefor, BeginDateAfter, EndDateAfter, EndDateBefor, DocNo,T_City.NameE as DocFrom, Insurance_NameBefor,T_Insurance.NameE as InsuranceNoBefor, Insurance_NameAfter,T_Insurance.NameE as InsuranceNoAfter,DocTyp, DocNoAfter,T_City.NameE as DocFromAfter, T_Emp.NameE as NameA,T_SYSSETTING.LogImg as LogoPic";
                        }
                        _RepShow.Rule = " Where DocTyp = 4 " + sqlWhere;
                        _RepShow.Brn_No = string.Empty;
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                        if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepUpdateDocAllownce");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepUpdateDocAllownce");
                            }
                            ReportDocument rpt = MainCryRep;
                            rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                       setTarwisaa(rpt);if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                            {
                                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                            }
                            else
                            {
                                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                            }
                            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                            rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                            rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                            rpt.SetParameterValue("vSts", false);
                            rpt.SetParameterValue("vLines", 1);
                            if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                            {
                                PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                            }
                            else
                            {
                                setpagesetting(rpt);
                            }
                        }
                        else
                        {
                            MessageBox.Show((VarGeneral.CurrentLang.ToString() == "0") ? "لا توجد حقول للطباعة تأكد من إعدادات الطباعة" : "No printing fields make sure the print settings", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else if (repvalue == "SalaryOp")
                    {
                        _RepShow.Tables = " T_SalaryOp left JOIN  T_Emp ON T_SalaryOp.EmpID = T_Emp.Emp_ID left JOIN  T_OpMethod ON T_SalaryOp.AddTo = T_OpMethod.Method_No left JOIN  T_SYSSETTING ON T_Emp.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            _RepShow.Fields = " T_Emp.NameA, T_SalaryOp.warnNo, T_SalaryOp.warnDate, case when T_SalaryOp.opTyp = 0 then 'زيادة' else 'نقصان' end as opTyp, case when T_SalaryOp.opMethod = 0 then 'نسبة مئوية' else 'مبلغ مقطوع' end as opMethod,T_OpMethod.Name as AddTo, T_OpMethod.Name as opCalc, T_SalaryOp.AddValue,T_SalaryOp.Note, T_SalaryOp.ValueBefor, T_SalaryOp.ValueAfter, T_OpMethod.Name, T_SYSSETTING.LogImg as LogoPic";
                        }
                        else
                        {
                            _RepShow.Fields = " T_Emp.NameE as NameA, T_SalaryOp.warnNo, T_SalaryOp.warnDate, case when T_SalaryOp.opTyp = 0 then 'ADD' else 'Sub' end as opTyp, case when T_SalaryOp.opMethod = 0 then '%' else 'Value' end as opMethod,T_OpMethod.NameE as AddTo, T_OpMethod.NameE as opCalc, T_SalaryOp.AddValue,T_SalaryOp.Note, T_SalaryOp.ValueBefor, T_SalaryOp.ValueAfter, T_OpMethod.NameE, T_SYSSETTING.LogImg as LogoPic";
                        }
                        _RepShow.Rule = " Where 1 = 1 " + sqlWhere;
                        _RepShow.Brn_No = string.Empty;
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                        if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepSalaryOp");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepSalaryOp");
                            }
                            ReportDocument rpt = MainCryRep;
                            rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                       setTarwisaa(rpt);if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                            {
                                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                            }
                            else
                            {
                                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                            }
                            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                            rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                            rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                            rpt.SetParameterValue("vSts", false);
                            rpt.SetParameterValue("vLines", 1);
                            if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                            {
                                PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                            }
                            else
                            {
                                setpagesetting(rpt);
                            }
                        }
                        else
                        {
                            MessageBox.Show((VarGeneral.CurrentLang.ToString() == "0") ? "لا توجد حقول للطباعة تأكد من إعدادات الطباعة" : "No printing fields make sure the print settings", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else if (repvalue == "RewardRep")
                    {
                        _RepShow.Tables = " T_Emp Right JOIN  T_Rewards ON T_Emp.Emp_ID = T_Rewards.EmpID  left JOIN T_SYSSETTING ON T_Emp.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            _RepShow.Fields = " T_Emp.Emp_No, T_Emp.NameA,T_SYSSETTING.LogImg as LogoPic , T_Rewards.RewardDate, T_Rewards.RewardValue, T_Rewards.Note ";
                        }
                        else
                        {
                            _RepShow.Fields = " T_Emp.Emp_No, T_Emp.NameE as NameA,T_SYSSETTING.LogImg as LogoPic , T_Rewards.RewardDate, T_Rewards.RewardValue, T_Rewards.Note ";
                        }
                        _RepShow.Rule = " Where 1 = 1 " + sqlWhere;
                        _RepShow.Brn_No = string.Empty;
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                        if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepReward");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepReward");
                            }
                            ReportDocument rpt = MainCryRep;
                            rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                       setTarwisaa(rpt);if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                            {
                                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                            }
                            else
                            {
                                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                            }
                            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                            rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                            rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                            rpt.SetParameterValue("vSts", false);
                            rpt.SetParameterValue("vLines", 1);
                            if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                            {
                                PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                            }
                            else
                            {
                                setpagesetting(rpt);
                            }
                        }
                        else
                        {
                            MessageBox.Show((VarGeneral.CurrentLang.ToString() == "0") ? "لا توجد حقول للطباعة تأكد من إعدادات الطباعة" : "No printing fields make sure the print settings", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else if (repvalue == "ProjRep")
                    {
                        _RepShow.Tables = " T_AttendOperat INNER JOIN  T_DayOfWeek ON T_AttendOperat.Day = T_DayOfWeek.Day_No INNER JOIN  T_Project ON T_AttendOperat.ProjectNo = T_Project.Project_No INNER JOIN  T_Emp ON T_AttendOperat.EmpID = T_Emp.Emp_ID INNER JOIN  T_SYSSETTING ON T_Emp.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            _RepShow.Fields = " T_AttendOperat.Date,T_DayOfWeek.NameA as DayNameA, T_Project.NameA as PRojectNm,T_Project.Project_No,COUNT(T_AttendOperat.EmpID) as Emp_No,T_SYSSETTING.LogImg as LogoPic ";
                        }
                        else
                        {
                            _RepShow.Fields = " T_AttendOperat.Date,T_DayOfWeek.NameE as DayNameA, T_Project.NameE as PRojectNm,T_Project.Project_No,COUNT(T_AttendOperat.EmpID) as Emp_No,T_SYSSETTING.LogImg as LogoPic ";
                        }
                        _RepShow.Rule = " Where 1 = 1 " + sqlWhere + ((VarGeneral.CurrentLang.ToString() == "0") ? " Group by T_Project.NameA,T_Project.Project_No ,T_AttendOperat.Date,T_DayOfWeek.NameA,T_SYSSETTING.LogImg order by T_Project.Project_No " : " group by T_Project.NameE,T_Project.Project_No ,T_AttendOperat.Date,T_DayOfWeek.NameE,T_SYSSETTING.LogImg as LogoPic order by T_Project.Project_No");
                        _RepShow.Brn_No = string.Empty;
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                        if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepProjectFilter");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepProjectFilter");
                            }
                            ReportDocument rpt = MainCryRep;
                            rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                       setTarwisaa(rpt);if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                            {
                                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                            }
                            else
                            {
                                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                            }
                            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                            rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                            rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                            rpt.SetParameterValue("vSts", false);
                            rpt.SetParameterValue("vLines", 1);
                            if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                            {
                                PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                            }
                            else
                            {
                                setpagesetting(rpt);
                            }
                        }
                        else
                        {
                            MessageBox.Show((VarGeneral.CurrentLang.ToString() == "0") ? "لا توجد حقول للطباعة تأكد من إعدادات الطباعة" : "No printing fields make sure the print settings", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else if (repvalue == "DisRep")
                    {
                        _RepShow.Tables = " T_Emp Right JOIN  T_SalDiscount ON T_Emp.Emp_ID = T_SalDiscount.EmpID INNER JOIN  T_SubTyp ON T_SalDiscount.SubTyp = T_SubTyp.SubNo  left JOIN T_SYSSETTING ON T_Emp.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            _RepShow.Fields = " T_Emp.Emp_No, T_Emp.NameA,T_SYSSETTING.LogImg as LogoPic  , T_SalDiscount.warnDate, T_SalDiscount.ACount, T_SalDiscount.SubTotaly, T_SubTyp.NameA AS SubTypNameA, T_SalDiscount.Note ";
                        }
                        else
                        {
                            _RepShow.Fields = " T_Emp.Emp_No, T_Emp.NameE as NameA,T_SYSSETTING.LogImg as LogoPic  , T_SalDiscount.warnDate, T_SalDiscount.ACount, T_SalDiscount.SubTotaly, T_SubTyp.NameE AS SubTypNameA, T_SalDiscount.Note ";
                        }
                        _RepShow.Rule = " Where 1 = 1 " + sqlWhere;
                        _RepShow.Brn_No = string.Empty;
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                        if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepDiscount");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepDiscount");
                            }
                            ReportDocument rpt = MainCryRep;
                            rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                       setTarwisaa(rpt);if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                            {
                                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                            }
                            else
                            {
                                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                            }
                            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                            rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                            rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                            rpt.SetParameterValue("vSts", false);
                            rpt.SetParameterValue("vLines", 1);
                            if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                            {
                                PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                            }
                            else
                            {
                                setpagesetting(rpt);
                            }
                        }
                        else
                        {
                            MessageBox.Show((VarGeneral.CurrentLang.ToString() == "0") ? "لا توجد حقول للطباعة تأكد من إعدادات الطباعة" : "No printing fields make sure the print settings", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else if (repvalue == "EndServiceRep")
                    {
                        _RepShow.Tables = " T_Emp Right JOIN  T_EndService ON T_Emp.Emp_ID = T_EndService.EmpID  left JOIN T_SYSSETTING ON T_Emp.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            _RepShow.Fields = " T_Emp.Emp_No, T_Emp.NameA,T_SYSSETTING.LogImg as LogoPic  , T_EndService.warnDate, T_EndService.GenTotal, T_EndService.Note ";
                        }
                        else
                        {
                            _RepShow.Fields = " T_Emp.Emp_No, T_Emp.NameE as NameA,T_SYSSETTING.LogImg as LogoPic  , T_EndService.warnDate, T_EndService.GenTotal, T_EndService.Note ";
                        }
                        _RepShow.Rule = " Where 1 = 1 " + sqlWhere;
                        _RepShow.Brn_No = string.Empty;
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                        if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepEndService");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepEndService");
                            }
                            ReportDocument rpt = MainCryRep;
                            rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                       setTarwisaa(rpt);if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                            {
                                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                            }
                            else
                            {
                                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                            }
                            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                            rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                            rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                            rpt.SetParameterValue("vSts", false);
                            rpt.SetParameterValue("vLines", 1);
                            if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                            {
                                PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                            }
                            else
                            {
                                setpagesetting(rpt);
                            }
                        }
                        else
                        {
                            MessageBox.Show((VarGeneral.CurrentLang.ToString() == "0") ? "لا توجد حقول للطباعة تأكد من إعدادات الطباعة" : "No printing fields make sure the print settings", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else if (repvalue == "StatisticalNation")
                    {
                        if (columns_Names_visible.Count > 0)
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepSNation");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepSNation");
                            }
                            ReportDocument rpt = MainCryRep;
                            rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                       setTarwisaa(rpt);if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                            {
                                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                            }
                            else
                            {
                                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                            }
                            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                            rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                            rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                            rpt.SetParameterValue("vSts", false);
                            rpt.SetParameterValue("vLines", 1);
                            if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                            {
                                PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                            }
                            else
                            {
                                setpagesetting(rpt);
                            }
                        }
                        else
                        {
                            MessageBox.Show("لا توجد حقول للطباعة تأكد من إعدادات الطباعة", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else if (repvalue == "VacRep" || repvalue == "VacRepDet" || repvalue == "VacRepHold")
                    {
                        if (repvalue != "VacRepHold")
                        {
                            _RepShow.Tables = " T_Emp Right JOIN  T_Vacation ON T_Emp.Emp_ID = T_Vacation.EmpID LEFT JOIN  T_VacTyp ON T_Vacation.VacTyp = T_VacTyp.VacT_No LEFT JOIN  T_Dept ON T_Emp.Dept = T_Dept.Dept_No LEFT JOIN  T_Job ON T_Emp.Job = T_Job.Job_No LEFT JOIN  T_Nationalities ON T_Emp.Nationalty = T_Nationalities.Nation_No LEFT JOIN  T_Section ON T_Emp.Section = T_Section.Section_No  left JOIN T_SYSSETTING ON T_Emp.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                _RepShow.Fields = " T_Emp.*,T_SYSSETTING.LogImg as LogoPic  , T_Vacation.*, T_VacTyp.NameA AS VacTypNameA,  T_Dept.NameA AS DeptNameA, T_Job.NameA AS JobNameA, T_Section.NameA AS SectionNameA,T_Nationalities.NameA as NationNameA ";
                            }
                            else
                            {
                                _RepShow.Fields = " T_Emp.*,T_SYSSETTING.LogImg as LogoPic  , T_Vacation.*, T_VacTyp.NameE AS VacTypNameA,  T_Dept.NameE AS DeptNameA, T_Job.NameE AS JobNameA, T_Section.NameE AS SectionNameA,T_Nationalities.NameE as NationNameA ";
                            }
                            _RepShow.Rule = " Where 1 = 1 " + sqlWhere;
                            _RepShow.Brn_No = string.Empty;
                            _RepShow = _RepShow.Save();
                            VarGeneral.RepData = _RepShow.RepData;
                        }
                        if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                        {
                            if (repvalue == "VacRep")
                            {
                                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                                {
                                    MainCryRep = getdoc("InvAcc.ReportsEmp.RepVac");
                                }
                                else
                                {
                                    MainCryRep = getdoc("InvAcc.ReportsEmp.RepVac");
                                }
                            }
                            else if (repvalue == "VacRepHold")
                            {
                                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                                {
                                    MainCryRep = getdoc("InvAcc.ReportsEmp.VacationsHold");
                                }
                                else
                                {
                                    MainCryRep = getdoc("InvAcc.ReportsEmp.VacationsHold");
                                }
                            }
                            else if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepVacDetail");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepVacDetail");
                            }
                            ReportDocument rpt = MainCryRep;
                            rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                       setTarwisaa(rpt);if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                            {
                                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                            }
                            else
                            {
                                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                            }
                            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                            rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                            rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                            rpt.SetParameterValue("vSts", false);
                            rpt.SetParameterValue("vLines", 1);
                            if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                            {
                                PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                            }
                            else
                            {
                                setpagesetting(rpt);
                            }
                        }
                        else
                        {
                            MessageBox.Show((VarGeneral.CurrentLang.ToString() == "0") ? "لا توجد حقول للطباعة تأكد من إعدادات الطباعة" : "No printing fields make sure the print settings", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else if (repvalue == "TickitRep" || repvalue == "TickitRepDet")
                    {
                        _RepShow.Tables = " T_Emp left JOIN  T_Dept ON T_Emp.Dept = T_Dept.Dept_No left JOIN  T_SYSSETTING ON T_Emp.CompanyID = T_SYSSETTING.SYSSETTING_ID left JOIN  T_Job ON T_Emp.Job = T_Job.Job_No left JOIN  T_Nationalities ON T_Emp.Nationalty = T_Nationalities.Nation_No LEFT JOIN  T_Section ON T_Emp.Section = T_Section.Section_No Right JOIN  T_Tickets ON T_Emp.Emp_ID = T_Tickets.EmpID INNER JOIN  T_TicetTyp ON T_Tickets.TickTyp = T_TicetTyp.TicetT_No ";
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            _RepShow.Fields = " T_Emp.*,T_SYSSETTING.LogImg as LogoPic  , T_Dept.NameA AS DeptNameA, T_Section.NameA AS SectionNameA, T_Job.NameA AS JobNameA,T_Nationalities.NameA as NationNameA,  T_TicetTyp.NameA AS TicetTypNameA, T_Tickets.* ";
                        }
                        else
                        {
                            _RepShow.Fields = " T_Emp.*,T_SYSSETTING.LogImg as LogoPic  , T_Dept.NameE AS DeptNameA, T_Section.NameE AS SectionNameA, T_Job.NameE AS JobNameA,T_Nationalities.NameE as NationNameA,  T_TicetTyp.NameE AS TicetTypNameA, T_Tickets.* ";
                        }
                        _RepShow.Rule = " Where 1 = 1 " + sqlWhere;
                        _RepShow.Brn_No = string.Empty;
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                        if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                        {
                            if (repvalue == "TickitRep")
                            {
                                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                                {
                                    MainCryRep = getdoc("InvAcc.ReportsEmp.RepTicket");
                                }
                                else
                                {
                                    MainCryRep = getdoc("InvAcc.ReportsEmp.RepTicket");
                                }
                            }
                            else if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepTicketDet");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepTicketDet");
                            }
                            ReportDocument rpt = MainCryRep;
                            rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                       setTarwisaa(rpt);if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                            {
                                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                            }
                            else
                            {
                                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                            }
                            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                            rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                            rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                            rpt.SetParameterValue("vSts", false);
                            rpt.SetParameterValue("vLines", 1);
                            if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                            {
                                PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                            }
                            else
                            {
                                setpagesetting(rpt);
                            }
                        }
                        else
                        {
                            MessageBox.Show((VarGeneral.CurrentLang.ToString() == "0") ? "لا توجد حقول للطباعة تأكد من إعدادات الطباعة" : "No printing fields make sure the print settings", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else if (repvalue == "EmpsSalRep")
                    {
                        _RepShow.Tables = " T_Salary left JOIN  T_Emp ON T_Salary.EmpID = T_Emp.Emp_ID left JOIN  T_Advances ON T_Emp.Emp_ID = T_Advances.EmpID left JOIN  T_Bank ON T_Emp.Bank = T_Bank.Bank_No LEFT JOIN  T_Dept ON T_Salary.DeptNo = T_Dept.Dept_No AND T_Emp.Dept = T_Dept.Dept_No left JOIN  T_Job ON T_Salary.Job = T_Job.Job_No AND T_Emp.Job = T_Job.Job_No left JOIN  T_Section ON T_Salary.SectionNo = T_Section.Section_No left JOIN  T_Nationalities ON T_Emp.Nationalty = T_Nationalities.Nation_No  left JOIN T_SYSSETTING ON T_Emp.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            _RepShow.Fields = " T_Emp.Emp_No,T_Emp.NameA, T_Salary.*,T_Job.NameA as JobNameA ,T_SYSSETTING.LogImg as LogoPic,CONVERT(varchar(10),T_Salary.SalYear) + '/' + CONVERT(varchar(10),T_Salary.SalMonth) as YearMonth  ";
                        }
                        else
                        {
                            _RepShow.Fields = " T_Emp.Emp_No,T_Emp.NameE as NameA, T_Salary.*,T_Job.NameE as JobNameA ,T_SYSSETTING.LogImg as LogoPic,CONVERT(varchar(10),T_Salary.SalYear) + '/' + CONVERT(varchar(10),T_Salary.SalMonth) as YearMonth  ";
                        }
                        _RepShow.Rule = " Where 1 = 1 " + sqlWhere + " order by T_Emp.Emp_No ";
                        _RepShow.Brn_No = string.Empty;
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                        if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                        {
                            if (!VarGeneral.CheckDate(VarGeneral.dtFrom))
                            {
                                int? autoEmp = VarGeneral.Settings_Sys.Calendr;
                                VarGeneral.dtFrom = ((autoEmp.Value == 0 && autoEmp.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM"));
                            }
                            if (!VarGeneral.CheckDate(VarGeneral.dtTo))
                            {
                                int? autoEmp = VarGeneral.Settings_Sys.Calendr;
                                VarGeneral.dtTo = ((autoEmp.Value == 0 && autoEmp.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM"));
                            }
                            for (int i = 0; i < VarGeneral.RepData.Tables[0].Rows.Count; i++)
                            {
                                try
                                {
                                    if (!(Convert.ToDateTime(string.Concat(VarGeneral.RepData.Tables[0].Rows[i]["SalYear"], "/", VarGeneral.RepData.Tables[0].Rows[i]["SalMonth"])) >= Convert.ToDateTime(VarGeneral.dtFrom)) || !(Convert.ToDateTime(string.Concat(VarGeneral.RepData.Tables[0].Rows[i]["SalYear"], "/", VarGeneral.RepData.Tables[0].Rows[i]["SalMonth"])) <= Convert.ToDateTime(VarGeneral.dtTo)))
                                    {
                                        VarGeneral.RepData.Tables[0].Rows[i].Delete();
                                        VarGeneral.RepData.AcceptChanges();
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        VarGeneral.RepData.Tables[0].Rows[i].Delete();
                                        VarGeneral.RepData.AcceptChanges();
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                        }
                        if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepSalary");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepSalary");
                            }
                            ReportDocument rpt = MainCryRep;
                            rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                       setTarwisaa(rpt);if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                            {
                                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                            }
                            else
                            {
                                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                            }
                            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                            rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                            rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                            rpt.SetParameterValue("vSts", false);
                            rpt.SetParameterValue("vLines", 1);
                            if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                            {
                                PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                            }
                            else
                            {
                                setpagesetting(rpt);
                            }
                        }
                        else
                        {
                            MessageBox.Show((VarGeneral.CurrentLang.ToString() == "0") ? "لا توجد حقول للطباعة تأكد من إعدادات الطباعة" : "No printing fields make sure the print settings", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else if (repvalue == "AllowncRep" || repvalue == "AllowncRepMidical")
                    {
                        _RepShow.Tables = " T_Salary left JOIN  T_Emp ON T_Salary.EmpID = T_Emp.Emp_ID left JOIN  T_Advances ON T_Emp.Emp_ID = T_Advances.EmpID left JOIN  T_Bank ON T_Emp.Bank = T_Bank.Bank_No LEFT JOIN  T_Dept ON T_Salary.DeptNo = T_Dept.Dept_No AND T_Emp.Dept = T_Dept.Dept_No left JOIN  T_Job ON T_Salary.Job = T_Job.Job_No AND T_Emp.Job = T_Job.Job_No left JOIN  T_Section ON T_Salary.SectionNo = T_Section.Section_No left JOIN  T_Nationalities ON T_Emp.Nationalty = T_Nationalities.Nation_No  left JOIN T_SYSSETTING ON T_Emp.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            _RepShow.Fields = " T_Emp.Emp_ID,T_SYSSETTING.LogImg as LogoPic , T_Emp.Emp_No, T_Emp.NameA, T_Job.NameA as JobNameA,T_Emp.Nationalty,  T_Salary.Salary , SUM( T_Salary.HousingAllowance) as HousingAllowance, SUM(T_Salary.TransferAllowance) as TransferAllowance, SUM(T_Salary.OtherAllowance) as OtherAllowance, SUM(T_Salary.SubDay) as SubDay,SUM( T_Salary.LateHours) as LateHours, SUM(T_Salary.SubJaza) as SubJaza, SUM(T_Salary.SubOther) as SubOther, SUM(T_Salary.SubCallPhone) as SubCallPhone, SUM(T_Salary.SubCommentary) as SubCommentary,  SUM(T_Salary.MandateDay) as MandateDay, SUM(T_Salary.SocialInsuranceComp) as SocialInsuranceComp, SUM(T_Salary.SocialInsurance) as SocialInsurance, SUM(T_Salary.InsuranceMedicalCom) as InsuranceMedicalCom, SUM(T_Salary.InsuranceMedical) as InsuranceMedical, SUM(T_Salary.Advance) as Advance ,T_Nationalities.NameA as NationNameA,  SUM(T_Salary.Rewards) as Rewards,SUM( T_Salary.AddDay) as AddDay,SUM( T_Salary.AddHour) as AddHour ";
                            _RepShow.Rule = " Where T_Salary.SalaryStatus = 1 " + SqlWhere + " Group by T_SYSSETTING.LogImg,T_Salary.Salary,T_Emp.Emp_ID,T_Emp.Nationalty,T_Emp.Emp_No, T_Emp.NameA,T_Nationalities.NameA, T_Job.NameA order by T_Emp.Emp_No";
                        }
                        else
                        {
                            _RepShow.Fields = " T_Emp.Emp_ID,T_SYSSETTING.LogImg as LogoPic , T_Emp.Emp_No, T_Emp.NameE as NameA, T_Job.NameE as JobNameA,T_Emp.Nationalty,  T_Salary.Salary , SUM( T_Salary.HousingAllowance) as HousingAllowance, SUM(T_Salary.TransferAllowance) as TransferAllowance, SUM(T_Salary.OtherAllowance) as OtherAllowance, SUM(T_Salary.SubDay) as SubDay,SUM( T_Salary.LateHours) as LateHours, SUM(T_Salary.SubJaza) as SubJaza, SUM(T_Salary.SubOther) as SubOther, SUM(T_Salary.SubCallPhone) as SubCallPhone, SUM(T_Salary.SubCommentary) as SubCommentary,  SUM(T_Salary.MandateDay) as MandateDay, SUM(T_Salary.SocialInsuranceComp) as SocialInsuranceComp, SUM(T_Salary.SocialInsurance) as SocialInsurance, SUM(T_Salary.InsuranceMedicalCom) as InsuranceMedicalCom, SUM(T_Salary.InsuranceMedical) as InsuranceMedical, SUM(T_Salary.Advance) as Advance ,T_Nationalities.NameE as NationNameA,  SUM(T_Salary.Rewards) as Rewards,SUM( T_Salary.AddDay) as AddDay,SUM( T_Salary.AddHour) as AddHour ";
                            _RepShow.Rule = " Where T_Salary.SalaryStatus = 1 " + SqlWhere + " Group by T_SYSSETTING.LogImg,T_Salary.Salary,T_Emp.Emp_ID,T_Emp.Nationalty,T_Emp.Emp_No, T_Emp.NameE,T_Nationalities.NameE, T_Job.NameE order by T_Emp.Emp_No";
                        }
                        _RepShow.Brn_No = string.Empty;
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                        if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                        {
                            if (repvalue == "AllowncRep")
                            {
                                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                                {
                                    MainCryRep = getdoc("InvAcc.ReportsEmp.RepSocialAllownc");
                                }
                                else
                                {
                                    MainCryRep = getdoc("InvAcc.ReportsEmp.RepSocialAllownc");
                                }
                            }
                            else if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepMedicalAllownc_");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepMedicalAllownc_");
                            }
                            ReportDocument rpt = MainCryRep;
                            rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                       setTarwisaa(rpt);if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                            {
                                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                            }
                            else
                            {
                                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                            }
                            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                            rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                            rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                            rpt.SetParameterValue("vSts", false);
                            rpt.SetParameterValue("vLines", 1);
                            if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                            {
                                PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                            }
                            else
                            {
                                setpagesetting(rpt);
                            }
                        }
                        else
                        {
                            MessageBox.Show((VarGeneral.CurrentLang.ToString() == "0") ? "لا توجد حقول للطباعة تأكد من إعدادات الطباعة" : "No printing fields make sure the print settings", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else if (repvalue == "PrintAdvancRep" || repvalue == "PrintRewardRep" || repvalue == "PrintDisSal" || repvalue == "PrintAddSal" || repvalue == "PrintAllownceRep" || repvalue == "PrintBankSal" || repvalue == "PrintEmpsSal" || repvalue == "PrintEmpsSalDet")
                    {
                        _RepShow.Tables = " T_Salary left JOIN  T_Emp ON T_Salary.EmpID = T_Emp.Emp_ID left JOIN  T_Advances ON T_Emp.Emp_ID = T_Advances.EmpID left JOIN  T_Bank ON T_Emp.Bank = T_Bank.Bank_No LEFT JOIN  T_Dept ON T_Salary.DeptNo = T_Dept.Dept_No AND T_Emp.Dept = T_Dept.Dept_No left JOIN  T_Job ON T_Salary.Job = T_Job.Job_No AND T_Emp.Job = T_Job.Job_No left JOIN  T_Section ON T_Salary.SectionNo = T_Section.Section_No left JOIN  T_Nationalities ON T_Emp.Nationalty = T_Nationalities.Nation_No  left JOIN T_SYSSETTING ON T_Emp.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            _RepShow.Fields = " distinct T_Emp.Emp_No,T_Emp.NameA,T_SYSSETTING.LogImg as LogoPic , T_Salary.*,T_Job.NameA as JobNameA,T_Section.NameA as SectionNameA,T_Dept.NameA as DeptNameA,(select T_AccDef.Arb_Des from T_AccDef where T_AccDef.AccDef_No = T_Emp.AccountID) as BankNameA ,T_Bank.Cod ,T_Emp.AccountID";
                        }
                        else
                        {
                            _RepShow.Fields = " distinct T_Emp.Emp_No,T_Emp.NameE as NameA,T_SYSSETTING.LogImg as LogoPic , T_Salary.*,T_Job.NameE as JobNameA,T_Section.NameE as SectionNameA,T_Dept.NameE as DeptNameA,(select T_AccDef.Eng_Des from T_AccDef where T_AccDef.AccDef_No = T_Emp.AccountID) as BankNameA ,T_Bank.Cod ,T_Emp.AccountID";
                        }
                        _RepShow.Rule = sqlWhere;
                        _RepShow.Brn_No = string.Empty;
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                        if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                        {
                            if (repvalue == "PrintAdvancRep")
                            {
                                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                                {
                                    MainCryRep = getdoc("InvAcc.ReportsEmp.PrintAdvSal");
                                }
                                else
                                {
                                    MainCryRep = getdoc("InvAcc.ReportsEmp.PrintAdvSal");
                                }
                            }
                            else if (repvalue == "PrintRewardRep")
                            {
                                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                                {
                                    MainCryRep = getdoc("InvAcc.ReportsEmp.PrintRewardSal");
                                }
                                else
                                {
                                    MainCryRep = getdoc("InvAcc.ReportsEmp.PrintRewardSal");
                                }
                            }
                            else if (repvalue == "PrintDisSal")
                            {
                                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                                {
                                    MainCryRep = getdoc("InvAcc.ReportsEmp.PrintDisSal");
                                }
                                else
                                {
                                    MainCryRep = getdoc("InvAcc.ReportsEmp.PrintDisSal");
                                }
                            }
                            else if (repvalue == "PrintAddSal")
                            {
                                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                                {
                                    MainCryRep = getdoc("InvAcc.ReportsEmp.PrintAddSal");
                                }
                                else
                                {
                                    MainCryRep = getdoc("InvAcc.ReportsEmp.PrintAddSal");
                                }
                            }
                            else if (repvalue == "PrintAllownceRep")
                            {
                                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                                {
                                    MainCryRep = getdoc("InvAcc.ReportsEmp.PrintAllowncSal");
                                }
                                else
                                {
                                    MainCryRep = getdoc("InvAcc.ReportsEmp.PrintAllowncSal");
                                }
                            }
                            else if (repvalue == "PrintBankSal")
                            {
                                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                                {
                                    MainCryRep = getdoc("InvAcc.ReportsEmp.PrintBankSal");
                                }
                                else
                                {
                                    MainCryRep = getdoc("InvAcc.ReportsEmp.PrintBankSal");
                                }
                            }
                            else if (repvalue == "PrintEmpsSal")
                            {
                                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                                {
                                    MainCryRep = getdoc("InvAcc.ReportsEmp.PrintEmpsSal");
                                }
                                else
                                {
                                    MainCryRep = getdoc("InvAcc.ReportsEmp.PrintEmpsSal");
                                }
                            }
                            else if (repvalue == "PrintEmpsSalDet")
                            {
                                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                                {
                                    MainCryRep = getdoc("InvAcc.ReportsEmp.salrep");
                                }
                                else
                                {
                                    MainCryRep = getdoc("InvAcc.ReportsEmp.salrep");
                                }
                            }
                            ReportDocument rpt = MainCryRep;
                            rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                       setTarwisaa(rpt);if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                            {
                                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                            }
                            else
                            {
                                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                            }
                            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                            rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                            rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                            rpt.SetParameterValue("vSts", false);
                            rpt.SetParameterValue("vLines", 1);
                            rpt.SetParameterValue("DT", VarGeneral.AutoAlarmitms[0] + " ");
                            if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                            {
                                PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                            }
                            else
                            {
                                setpagesetting(rpt);
                            }
                        }
                        else
                        {
                            MessageBox.Show((VarGeneral.CurrentLang.ToString() == "0") ? "لا توجد حقول للطباعة تأكد من إعدادات الطباعة" : "No printing fields make sure the print settings", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else if (repvalue == "PrintEmpsSal_")
                    {
                        _RepShow.Tables = " T_Sal left JOIN  T_AccDef ON T_Sal.EmpID = T_AccDef.AccDef_No left JOIN  T_SYSSETTING ON T_AccDef.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            _RepShow.Fields = " distinct T_AccDef.AccDef_No,T_AccDef.Arb_Des as NameA,T_SYSSETTING.LogImg as LogoPic , T_Sal.* ";
                        }
                        else
                        {
                            _RepShow.Fields = " distinct T_AccDef.AccDef_No,T_AccDef.Eng_Des as NameA,T_SYSSETTING.LogImg as LogoPic , T_Sal.* ";
                        }
                        _RepShow.Rule = sqlWhere;
                        _RepShow.Brn_No = string.Empty;
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                        if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.PrintEmpsSalary");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmpE.PrintEmpsSalary");
                            }
                            ReportDocument rpt = MainCryRep;
                            rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                       setTarwisaa(rpt);if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                            {
                                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                            }
                            else
                            {
                                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                            }
                            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                            rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                            rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                            rpt.SetParameterValue("vSts", false);
                            rpt.SetParameterValue("vLines", 1);
                            rpt.SetParameterValue("DT", VarGeneral.AutoAlarmitms[0] + " ");
                            if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                            {
                                PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                            }
                            else
                            {
                                setpagesetting(rpt);
                            }
                        }
                        else
                        {
                            MessageBox.Show((VarGeneral.CurrentLang.ToString() == "0") ? "لا توجد حقول للطباعة تأكد من إعدادات الطباعة" : "No printing fields make sure the print settings", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else if (repvalue == "AttEmpRep")
                    {
                        _RepShow.Tables = " T_AttendOperat left JOIN\r\n                                     T_DayOfWeek ON T_AttendOperat.Day = T_DayOfWeek.Day_No left JOIN\r\n                                     T_Emp ON T_AttendOperat.EmpID = T_Emp.Emp_ID left JOIN\r\n                                     T_Project ON T_AttendOperat.ProjectNo = T_Project.Project_No LEFT JOIN\r\n                                     T_SYSSETTING ON T_Emp.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            _RepShow.Fields = " T_AttendOperat.*,T_Emp.Emp_No,T_Emp.NameA,T_DayOfWeek.NameA as DayNameA,T_SYSSETTING.LogImg as LogoPic,T_Project.NameA as PRojectNm ";
                        }
                        else
                        {
                            _RepShow.Fields = " T_AttendOperat.*,T_Emp.Emp_No,T_Emp.NameE as NameA,T_DayOfWeek.NameE as DayNameA,T_SYSSETTING.LogImg as LogoPic,T_Project.NameE as PRojectNm   ";
                        }
                        _RepShow.Rule = "Where T_Emp.EmpState = 1  " + sqlWhere + " order by T_Emp.Emp_No,T_AttendOperat.Date ";
                        _RepShow.Brn_No = string.Empty;
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                        if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.attemp");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.attemp");
                            }
                            ReportDocument rpt = MainCryRep;
                            rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                       setTarwisaa(rpt);if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                            {
                                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                            }
                            else
                            {
                                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                            }
                            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                            rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                            rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                            rpt.SetParameterValue("vSts", false);
                            rpt.SetParameterValue("vLines", 1);
                            if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                            {
                                PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                            }
                            else
                            {
                                setpagesetting(rpt);
                            }
                        }
                        else
                        {
                            MessageBox.Show((VarGeneral.CurrentLang.ToString() == "0") ? "لا توجد حقول للطباعة تأكد من إعدادات الطباعة" : "No printing fields make sure the print settings", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else if (repvalue == "PrintAutoAlarm")
                    {
                        if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepAutoAlarm");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepAutoAlarm");
                            }
                            ReportDocument rpt = MainCryRep;
                            rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                       setTarwisaa(rpt);
                            
                         if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                            {
                                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                            }
                            else
                            {
                                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                            }
                            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                            rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                            rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                            rpt.SetParameterValue("vSts", false);
                            rpt.SetParameterValue("vLines", 1);
                            rpt.SetParameterValue("AlarmName", VarGeneral.AutoAlarmitms[7] + " ");
                            rpt.SetParameterValue("Col_1", VarGeneral.AutoAlarmitms[1] + " ");
                            rpt.SetParameterValue("Col_2", VarGeneral.AutoAlarmitms[2] + " ");
                            rpt.SetParameterValue("Col_3", VarGeneral.AutoAlarmitms[3] + " ");
                            rpt.SetParameterValue("Col_4", VarGeneral.AutoAlarmitms[4] + " ");
                            rpt.SetParameterValue("Col_5", VarGeneral.AutoAlarmitms[5] + " ");
                            rpt.SetParameterValue("Col_6", VarGeneral.AutoAlarmitms[6] + " ");
                            if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                            {
                                PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                            }
                            else
                            {
                                setpagesetting(rpt);
                            }
                        }
                        else
                        {
                            MessageBox.Show((VarGeneral.CurrentLang.ToString() == "0") ? "لا توجد حقول للطباعة تأكد من إعدادات الطباعة" : "No printing fields make sure the print settings", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else if (repvalue == "PrintFiles")
                    {
                        if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepFiles");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsEmp.RepFiles");
                            }
                            ReportDocument rpt = MainCryRep;
                            rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                       setTarwisaa(rpt);if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                            {
                                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                            }
                            else
                            {
                                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                            }
                            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                            rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                            rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                            rpt.SetParameterValue("vSts", false);
                            rpt.SetParameterValue("vLines", 1);
                            if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                            {
                                PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                            }
                            else
                            {
                                setpagesetting(rpt);
                            }
                        }
                        else
                        {
                            MessageBox.Show((VarGeneral.CurrentLang.ToString() == "0") ? "لا توجد حقول للطباعة تأكد من إعدادات الطباعة" : "No printing fields make sure the print settings", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else if (repvalue == "PassportForms")
                    {
                        if (columns_Names_visible_Passport.Count > 0)
                        {
                            PrintForm1();
                        }
                        else
                        {
                            MessageBox.Show("لا توجد حقول للطباعة تأكد من إعدادات الطباعة", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else if (repvalue == "FamilyPassport")
                    {
                        if (vFamilyPassport.Count > 0)
                        {
                            ReportDocument familyPass = getdoc("InvAcc.ReportsEmp.Passprt2");
                            familyPass.SetDataSource(new BindingSource(vFamilyPassport.Values, null));
                            crystalReportViewe_RepShow.ReportSource = familyPass;
                        }
                        else
                        {
                            MessageBox.Show("لا توجد حقول للطباعة تأكد من إعدادات الطباعة", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
                catch (Exception error2)
                {
                    VarGeneral.DebLog.writeLog("RFrmReportsViewer_Load:", error2, enable: true);
                    MessageBox.Show(error2.Message);
                }
                //if (num == 0)
                //{
                //    STEP_1();
                //}
                //else if (VarGeneral.Settings_Sys.AutoEmp == 1)
                //{
                //    STEP_2();
                //}
                //else
                //{
                //    STEP_1();
                //    if (db.StockInvSetting(1).ISdirectPrinting || BarcodSts)
                //    {
                //        STEP_2();
                //    }
                //}
                //if (num2 == 0)
                //{
                //    STEP_Cachier_1();
                //}
                //else if (VarGeneral.Settings_Sys.AutoEmp == 1)
                //{
                //    STEP_Cachier_2();
                //}
                //else
                //{
                //    STEP_Cachier_1();
                //    if (db.StockInvSetting(1).ISdirectPrinting || BarcodSts)
                //    {
                //        STEP_Cachier_2();
                //    }
                //}
            }
            catch (Exception error2)
            {
                VarGeneral.DebLog.writeLog("RFrmReportsViewer_Load:", error2, enable: true);
            }
        }
        void setitemsoptionsRpt2(T_Printer _InvSetting,ReportDocument rpt)
        {
            try
            {
                rpt.SetParameterValue("IsCashCredit", VarGeneral.IsCashCredit ? "1" : "0");
            }
            catch
            {
            }
            try
            {
                rpt.SetParameterValue("vDecimal", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? "1" : "0");
            }
            catch
            {
            }
            try
            {
                rpt.SetParameterValue("IsTotWithTax", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 65) ? "1" : "0");
            }
            catch
            {
            }
            try
            {
                (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
            }
            catch
            {
            }
            try
            {
                (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
            }
            catch
            {
            }
            rpt.SetParameterValue("StoreSts", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16) ? "Show" : "Hide");
            if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
            {
                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
            }
            else
            {
                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
            }
            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
            rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
            try
            {
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    rpt.SetParameterValue("HDate", (!string.IsNullOrEmpty(_InvSetting.invGdADesc)) ? _InvSetting.invGdADesc : "شكرا\u064c لكم");
                }
                else
                {
                    rpt.SetParameterValue("HDate", (!string.IsNullOrEmpty(_InvSetting.invGdEDesc)) ? _InvSetting.invGdEDesc : "Thank you");
                }
            }
            catch
            {
                rpt.SetParameterValue("HDate", string.Empty);
            }
            rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
            rpt.SetParameterValue("vSts", false);
            rpt.SetParameterValue("vLines", 1);
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.LineDetailSts, vStr(VarGeneral.InvTyp)))
            {
                rpt.SetParameterValue("LineDetailNa", VarGeneral.Settings_Sys.LineDetailNameA);
                rpt.SetParameterValue("LineDetailNa_Eng", VarGeneral.Settings_Sys.LineDetailNameE);
            }
            else
            {
                rpt.SetParameterValue("LineDetailNa", string.Empty);
                rpt.SetParameterValue("LineDetailNa_Eng", string.Empty);
            }
            try
            {
                if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 20))
                {
                    rpt.ReportDefinition.ReportObjects["Line2"].ObjectFormat.EnableSuppress = true;
                     rpt.ReportDefinition.ReportObjects["Text27"].ObjectFormat.EnableSuppress = true;
try{
rpt.ReportDefinition.ReportObjects["Text39"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line26"].ObjectFormat.EnableSuppress = true;

}catch
{
}
                    rpt.ReportDefinition.ReportObjects["SerialKey1"].ObjectFormat.EnableSuppress = true;
                    try
                    {
                        rpt.ReportDefinition.Sections[3].ReportObjects["Line2t"].ObjectFormat.EnableSuppress = true;
                    }
                    catch
                    {
                    }
                    if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16))
                    {
                        rpt.ReportDefinition.ReportObjects["Text13"].Width = 2924;
                        rpt.ReportDefinition.ReportObjects["ItmDes1"].Width = 2924;
                        rpt.ReportDefinition.ReportObjects["Text13"].Left = 7106;
                        rpt.ReportDefinition.ReportObjects["ItmDes1"].Left = 7106;
                    }
                    else
                    {
                        rpt.ReportDefinition.ReportObjects["Text13"].Width = 3536;
                        rpt.ReportDefinition.ReportObjects["ItmDes1"].Width = 3536;
                        rpt.ReportDefinition.ReportObjects["Text13"].Left = 6460;
                        rpt.ReportDefinition.ReportObjects["ItmDes1"].Left = 6460;
                    }
                }
            }
            catch
            {
            }
        }
        void setitemsoptionsRpt(T_Printer _InvSetting ,ReportDocument rpt)
        {
                      try
            {
                if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16))
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        rpt.ReportDefinition.Sections[3].ReportObjects["Line7"].ObjectFormat.EnableSuppress = true; rpt.ReportDefinition.Sections[3].ReportObjects["Text12"].ObjectFormat.EnableSuppress = true;
 try{ 
rpt.ReportDefinition.Sections[3].ReportObjects["Text33"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.Sections[3].ReportObjects["Line25"].ObjectFormat.EnableSuppress = true;
                                   
}catch{}
                                    rpt.ReportDefinition.Sections[3].ReportObjects["Text27"].Width = 1496;
                        rpt.ReportDefinition.Sections[3].ReportObjects["SerialKey1"].Width = 1496;
                        rpt.ReportDefinition.Sections[3].ReportObjects["Text27"].Left = 6494;
                        rpt.ReportDefinition.Sections[3].ReportObjects["SerialKey1"].Left = 6494;
                        try
                        {
                            rpt.ReportDefinition.Sections[3].ReportObjects["Line7t"].ObjectFormat.EnableSuppress = true;
rpt.ReportDefinition.Sections[3].ReportObjects["StoreNo1"].ObjectFormat.EnableSuppress = true;}
                        catch
                        {
                        }
                    }
                    else
                    {
                        rpt.ReportDefinition.Sections[3].ReportObjects["Line7"].ObjectFormat.EnableSuppress = true; rpt.ReportDefinition.Sections[3].ReportObjects["Text12"].ObjectFormat.EnableSuppress = true;
 try{ 
rpt.ReportDefinition.Sections[3].ReportObjects["Text33"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.Sections[3].ReportObjects["Line25"].ObjectFormat.EnableSuppress = true;
                                   
}catch{}
                                    rpt.ReportDefinition.Sections[3].ReportObjects["Text27"].Width = 1496;
                        rpt.ReportDefinition.Sections[3].ReportObjects["SerialKey1"].Width = 1496;
                        rpt.ReportDefinition.Sections[3].ReportObjects["Text27"].Left = 3162;
                        rpt.ReportDefinition.Sections[3].ReportObjects["SerialKey1"].Left = 3162;
                        try
                        {
                            rpt.ReportDefinition.Sections[3].ReportObjects["Line7t"].ObjectFormat.EnableSuppress = true;
rpt.ReportDefinition.Sections[3].ReportObjects["StoreNo1"].ObjectFormat.EnableSuppress = true;}
                        catch
                        {
                        }
                    }
                }
            }
            catch
            {
            }

        }
        void invo()
        {
            int? orientationSetting = VarGeneral.Settings_Sys.AutoEmp;
#pragma warning disable CS0168 // The variable 'flag2' is declared but never used
            bool flag1, flag2;
#pragma warning restore CS0168 // The variable 'flag2' is declared but never used
            if (repvalue == "InvSal")
            {
                this.printOrderNo = false;
                if (VarGeneral.InvTyp == 1)
                {
                    orientationSetting = VarGeneral.Settings_Sys.AutoEmp;
                    if ((orientationSetting.GetValueOrDefault() != 0 ? false : orientationSetting.HasValue) || VarGeneral.EmptyTablePrint)
                    {
                        goto Label4;
                    }
                    flag1 = (!(VarGeneral.SSSLev != "R") || !(VarGeneral.SSSLev != "C") ? true : !(VarGeneral.SSSLev != "H"));
                    goto Label3;
                }
                Label4:
                flag1 = false;
                Label3:
                if (flag1)
                {
                    orientationSetting = VarGeneral.Settings_Sys.AutoEmp;
                    if ((orientationSetting.GetValueOrDefault() != 1 ? 0 : ((orientationSetting.HasValue) == true ? 1 : 0)) == 0)
                    {
                        this.STEP_1();
                        if ((this.db.StockInvSetting(1).ISdirectPrinting ? true : this.BarcodSts))
                        {
                            this.STEP_2();
                        }
                    }
                    else
                    {
                        this.STEP_2();
                    }
                }
                else
                {
                    this.STEP_1();
                }
            }
            if (repvalue == "InvSalReturn")
            {
                T_Printer _InvSetting = new T_Printer();
                _InvSetting = db.StockPrinterSetting(VarGeneral.UserID, VarGeneral.InvTyp);
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    try
                    {
                        if (VarGeneral.gUserName == "runsetting")
                        {
                            if (File.Exists(Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvSalReturn.rpt"))
                            {
                                MainCryRep.FileName = Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvSalReturn.rpt";
                                addqrcode(MainCryRep);
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.Reports.RepInvSalReturn");
                            }
                        }
                        else if (File.Exists(Application.StartupPath + "\\Reps\\RepInvSalReturn.rpt"))
                        {
                            MainCryRep.FileName = Application.StartupPath + "\\Reps\\RepInvSalReturn.rpt";
                            addqrcode(MainCryRep);
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.Reports.RepInvSalReturn");
                        }
                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    {
                        MainCryRep = getdoc("InvAcc.Reports.RepInvSalReturn");
                    }
                }
                else
                {
                    try
                    {
                        if (VarGeneral.gUserName == "runsetting")
                        {
                            if (File.Exists(Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvSalReturn.rpt"))
                            {
                                MainCryRep.FileName = Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvSalReturn.rpt";
                                addqrcode(MainCryRep);
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsE.RepInvSalReturn");
                            }
                        }
                        else if (File.Exists(Application.StartupPath + "\\RepsE\\RepInvSalReturn.rpt"))
                        {
                            MainCryRep.FileName = Application.StartupPath + "\\RepsE\\RepInvSalReturn.rpt";
                            addqrcode(MainCryRep);
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsE.RepInvSalReturn");
                        }
                    }
                    catch
                    {
                        MainCryRep = getdoc("InvAcc.ReportsE.RepInvSalReturn");
                    }
                }
                ReportDocument rpt = MainCryRep;
                string vUsrNmA = string.Empty;
                string vBranchNmA = string.Empty;
                string vUsrNmE = string.Empty;
                string vBranchNmE = string.Empty;
                try
                {
                    vUsrNmA = VarGeneral.RepData.Tables[0].Rows[0]["UsrNamA"].ToString();
                }
                catch
                {
                    vUsrNmA = string.Empty;
                }
                try
                {
                    vUsrNmE = VarGeneral.RepData.Tables[0].Rows[0]["UsrNamE"].ToString();
                }
                catch
                {
                    vUsrNmE = string.Empty;
                }
                try
                {
                    vBranchNmA = VarGeneral.RepData.Tables[0].Rows[0]["Branch_Name"].ToString();
                }
                catch
                {
                    vBranchNmA = string.Empty;
                }
                try
                {
                    vBranchNmE = VarGeneral.RepData.Tables[0].Rows[0]["Branch_NameE"].ToString();
                }
                catch
                {
                    vBranchNmE = string.Empty;
                }
                VarGeneral.RepData.Tables[0].Rows[0].Delete();
                rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
           setTarwisaa(rpt);try
                {
         setTarwisaatax(_InvSetting,rpt);}
                catch
                {
                }
   setitemsoptionsRpt(_InvSetting,rpt);setitemsoptionsRpt2(_InvSetting,rpt);
                rpt.SetParameterValue("UserName", vUsrNmA);
                rpt.SetParameterValue("BranchName", vBranchNmA);
                rpt.SetParameterValue("UsrNamE", vUsrNmE);
                rpt.SetParameterValue("BranchNameE", vBranchNmE);

                try
                {
                    if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 19) || !VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 21))
                    {
                        if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 19) && VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 21))
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                rpt.ReportDefinition.ReportObjects["Line22"].ObjectFormat.EnableSuppress = true; rpt.ReportDefinition.ReportObjects["Text28"].ObjectFormat.EnableSuppress = true;
try{
rpt.ReportDefinition.ReportObjects["Text40"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line13"].ObjectFormat.EnableSuppress = true;


}catch
{
}
                                rpt.ReportDefinition.ReportObjects["DatExper1"].ObjectFormat.EnableSuppress = true;
                                try
                                {
                                    rpt.ReportDefinition.ReportObjects["Line22t"].ObjectFormat.EnableSuppress = true;
                                }
                                catch
                                {
                                }
                                rpt.ReportDefinition.ReportObjects["Text7"].Width = 1700;
                                rpt.ReportDefinition.ReportObjects["Amount1"].Width = 1700;
                                rpt.ReportDefinition.ReportObjects["Text7"].Left = 170;
rpt.ReportDefinition.ReportObjects["Text32"].Left = 170;
                                rpt.ReportDefinition.ReportObjects["Amount1"].Left = 170;
                            }
                            else
                            {
                                rpt.ReportDefinition.ReportObjects["Line22"].ObjectFormat.EnableSuppress = true; rpt.ReportDefinition.ReportObjects["Text28"].ObjectFormat.EnableSuppress = true;
try{
rpt.ReportDefinition.ReportObjects["Text40"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line13"].ObjectFormat.EnableSuppress = true;


}catch
{
}
                                rpt.ReportDefinition.ReportObjects["DatExper1"].ObjectFormat.EnableSuppress = true;
                                try
                                {
                                    rpt.ReportDefinition.ReportObjects["Line22t"].ObjectFormat.EnableSuppress = true;
                                }
                                catch
                                {
                                }
                                rpt.ReportDefinition.ReportObjects["Text7"].Width = 1768;
                                rpt.ReportDefinition.ReportObjects["Amount1"].Width = 1768;
                                rpt.ReportDefinition.ReportObjects["Text7"].Left = 9282;
                                rpt.ReportDefinition.ReportObjects["Amount1"].Left = 9282;
                            }
                        }
                        else if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 19) && !VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 21))
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                rpt.ReportDefinition.ReportObjects["Line3"].ObjectFormat.EnableSuppress = true; rpt.ReportDefinition.ReportObjects["Text29"].ObjectFormat.EnableSuppress = true;
 try{
rpt.ReportDefinition.ReportObjects["Text41"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line14"].ObjectFormat.EnableSuppress = true;
}catch
{
}rpt.ReportDefinition.ReportObjects["RunCod1"].ObjectFormat.EnableSuppress = true;
                                try
                                {
                                    rpt.ReportDefinition.ReportObjects["Line3t"].ObjectFormat.EnableSuppress = true;
                                }
                                catch
                                {
                                }
                                rpt.ReportDefinition.ReportObjects["Text28"].Width = 1632;
rpt.ReportDefinition.ReportObjects["Text40"].Width = 1632;
                                rpt.ReportDefinition.ReportObjects["Text28"].Left = 1156;
rpt.ReportDefinition.ReportObjects["Text40"].Left = 1156;
                                rpt.ReportDefinition.ReportObjects["DatExper1"].Width = 1632;
                                rpt.ReportDefinition.ReportObjects["DatExper1"].Left = 1156;
                            }
                            else
                            {
                                rpt.ReportDefinition.ReportObjects["Line3"].ObjectFormat.EnableSuppress = true; rpt.ReportDefinition.ReportObjects["Text29"].ObjectFormat.EnableSuppress = true;
 try{
rpt.ReportDefinition.ReportObjects["Text41"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line14"].ObjectFormat.EnableSuppress = true;
}catch
{
}rpt.ReportDefinition.ReportObjects["RunCod1"].ObjectFormat.EnableSuppress = true;
                                try
                                {
                                    rpt.ReportDefinition.ReportObjects["Line3t"].ObjectFormat.EnableSuppress = true;
                                }
                                catch
                                {
                                }
                                rpt.ReportDefinition.ReportObjects["Text28"].Width = 1632;
rpt.ReportDefinition.ReportObjects["Text40"].Width = 1632;
                                rpt.ReportDefinition.ReportObjects["Text28"].Left = 8364;
                                rpt.ReportDefinition.ReportObjects["DatExper1"].Width = 1632;
                                rpt.ReportDefinition.ReportObjects["DatExper1"].Left = 8364;
                            }
                        }
                        else if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            rpt.ReportDefinition.ReportObjects["Line3"].ObjectFormat.EnableSuppress = true; rpt.ReportDefinition.ReportObjects["Text29"].ObjectFormat.EnableSuppress = true;
 try{
rpt.ReportDefinition.ReportObjects["Text41"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line14"].ObjectFormat.EnableSuppress = true;
}catch
{
}rpt.ReportDefinition.ReportObjects["RunCod1"].ObjectFormat.EnableSuppress = true;
                            try
                            {
                                rpt.ReportDefinition.ReportObjects["Line3t"].ObjectFormat.EnableSuppress = true;
                            }
                            catch
                            {
                            }
                            rpt.ReportDefinition.ReportObjects["Line22"].ObjectFormat.EnableSuppress = true;
                            try
                            {
                                rpt.ReportDefinition.ReportObjects["Line22t"].ObjectFormat.EnableSuppress = true;
                            }
                            catch
                            {
                            } rpt.ReportDefinition.ReportObjects["Text28"].ObjectFormat.EnableSuppress = true;
try{
rpt.ReportDefinition.ReportObjects["Text40"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line13"].ObjectFormat.EnableSuppress = true;


}catch
{
}
                            rpt.ReportDefinition.ReportObjects["DatExper1"].ObjectFormat.EnableSuppress = true;
                            rpt.ReportDefinition.ReportObjects["Text7"].Width = 2618;

rpt.ReportDefinition.ReportObjects["Text32"].Width = 2618;

                            rpt.ReportDefinition.ReportObjects["Amount1"].Width = 2618;
                            rpt.ReportDefinition.ReportObjects["Text7"].Left = 170;
rpt.ReportDefinition.ReportObjects["Text32"].Left = 170;
                            rpt.ReportDefinition.ReportObjects["Amount1"].Left = 170;
                        }
                        else
                        {
                            rpt.ReportDefinition.ReportObjects["Line3"].ObjectFormat.EnableSuppress = true; rpt.ReportDefinition.ReportObjects["Text29"].ObjectFormat.EnableSuppress = true;
 try{
rpt.ReportDefinition.ReportObjects["Text41"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line14"].ObjectFormat.EnableSuppress = true;
}catch
{
}rpt.ReportDefinition.ReportObjects["RunCod1"].ObjectFormat.EnableSuppress = true;
                            try
                            {
                                rpt.ReportDefinition.ReportObjects["Line3t"].ObjectFormat.EnableSuppress = true;
                            }
                            catch
                            {
                            }
                            rpt.ReportDefinition.ReportObjects["Line22"].ObjectFormat.EnableSuppress = true;
                            try
                            {
                                rpt.ReportDefinition.ReportObjects["Line22t"].ObjectFormat.EnableSuppress = true;
                            }
                            catch
                            {
                            } rpt.ReportDefinition.ReportObjects["Text28"].ObjectFormat.EnableSuppress = true;
try{
rpt.ReportDefinition.ReportObjects["Text40"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line13"].ObjectFormat.EnableSuppress = true;


}catch
{
}
                            rpt.ReportDefinition.ReportObjects["DatExper1"].ObjectFormat.EnableSuppress = true;
                            rpt.ReportDefinition.ReportObjects["Text7"].Width = 2618;

rpt.ReportDefinition.ReportObjects["Text32"].Width = 2618;

                            rpt.ReportDefinition.ReportObjects["Amount1"].Width = 2618;
                            rpt.ReportDefinition.ReportObjects["Text7"].Left = 8330;
                            rpt.ReportDefinition.ReportObjects["Amount1"].Left = 8330;
                        }
                    }
                }
                catch
                {
                }
                if (_InvSetting.ISdirectPrinting || BarcodSts)
                {
                    PrintSet(rpt, (int)_InvSetting.lnPg.Value, (_InvSetting.Orientation == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, _InvSetting.defSizePaper, _InvSetting.DefLines.Value, VarGeneral.Print_set_Gen_Stat ? VarGeneral.prnt_doc_Gen.PrinterSettings.PrinterName : _InvSetting.defPrn, _InvSetting.hAs.Value, _InvSetting.hYs.Value, _InvSetting.hYm.Value, _InvSetting.hAl.Value);
                }
                else
                {
                    setpagesetting(rpt);
                }
            }
            else if (repvalue == "InvSalTailor")
            {
                T_Printer _InvSetting = new T_Printer();
                _InvSetting = db.StockPrinterSetting(VarGeneral.UserID, VarGeneral.InvTyp);
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    try
                    {
                        if (VarGeneral.gUserName == "runsetting")
                        {
                            if (File.Exists(Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvSalTailor.rpt"))
                            {
                                MainCryRep.FileName = Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvSalTailor.rpt";
                                addqrcode(MainCryRep);
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.Reports.RepInvSalTailor");
                            }
                        }
                        else if (File.Exists(Application.StartupPath + "\\Reps\\RepInvSalTailor.rpt"))
                        {
                            MainCryRep.FileName = Application.StartupPath + "\\Reps\\RepInvSalTailor.rpt";
                            addqrcode(MainCryRep);
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.Reports.RepInvSalTailor");
                        }
                    }
                    catch
                    {
                        MainCryRep = getdoc("InvAcc.Reports.RepInvSalTailor");
                    }
                }
                else
                {
                    try
                    {
                        if (VarGeneral.gUserName == "runsetting")
                        {
                            if (File.Exists(Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvSalTailor.rpt"))
                            {
                                MainCryRep.FileName = Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvSalTailor.rpt";
                                addqrcode(MainCryRep);
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsE.RepInvSalTailor");
                            }
                        }
                        else if (File.Exists(Application.StartupPath + "\\RepsE\\RepInvSalTailor.rpt"))
                        {
                            MainCryRep.FileName = Application.StartupPath + "\\RepsE\\RepInvSalTailor.rpt";
                            addqrcode(MainCryRep);
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsE.RepInvSalTailor");
                        }
                    }
                    catch
                    {
                        MainCryRep = getdoc("InvAcc.ReportsE.RepInvSalTailor");
                    }
                }
                ReportDocument rpt = MainCryRep;
                string vUsrNmA = string.Empty;
                string vBranchNmA = string.Empty;
                string vUsrNmE = string.Empty;
                string vBranchNmE = string.Empty;
                try
                {
                    vUsrNmA = VarGeneral.RepData.Tables[0].Rows[0]["UsrNamA"].ToString();
                }
                catch
                {
                    vUsrNmA = string.Empty;
                }
                try
                {
                    vUsrNmE = VarGeneral.RepData.Tables[0].Rows[0]["UsrNamE"].ToString();
                }
                catch
                {
                    vUsrNmE = string.Empty;
                }
                try
                {
                    vBranchNmA = VarGeneral.RepData.Tables[0].Rows[0]["Branch_Name"].ToString();
                }
                catch
                {
                    vBranchNmA = string.Empty;
                }
                try
                {
                    vBranchNmE = VarGeneral.RepData.Tables[0].Rows[0]["Branch_NameE"].ToString();
                }
                catch
                {
                    vBranchNmE = string.Empty;
                }
                VarGeneral.RepData.Tables[0].Rows[0].Delete();
                rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
           setTarwisaa(rpt);try
                {
         setTarwisaatax(_InvSetting,rpt);}
                catch
                {
                }
   setitemsoptionsRpt(_InvSetting,rpt);try
                {
                    rpt.SetParameterValue("IsCashCredit", VarGeneral.IsCashCredit ? "1" : "0");
                }
                catch
                {
                }
                try
                {
                    rpt.SetParameterValue("vDecimal", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? "1" : "0");
                }
                catch
                {
                }
                try
                {
                    rpt.SetParameterValue("IsTotWithTax", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 65) ? "1" : "0");
                }
                catch
                {
                }
                try
                {
                    (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                }
                catch
                {
                }
                try
                {
                    (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                }
                catch
                {
                }
                rpt.SetParameterValue("StoreSts", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16) ? "Show" : "Hide");
                if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                {
                    rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                }
                else
                {
                    rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                }
                rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                rpt.SetParameterValue("vSts", false);
                rpt.SetParameterValue("vLines", 1);
                if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.LineDetailSts, vStr(VarGeneral.InvTyp)))
                {
                    rpt.SetParameterValue("LineDetailNa", VarGeneral.Settings_Sys.LineDetailNameA);
                    rpt.SetParameterValue("LineDetailNa_Eng", VarGeneral.Settings_Sys.LineDetailNameE);
                }
                else
                {
                    rpt.SetParameterValue("LineDetailNa", string.Empty);
                    rpt.SetParameterValue("LineDetailNa_Eng", string.Empty);
                }
                rpt.SetParameterValue("UserName", vUsrNmA);
                rpt.SetParameterValue("BranchName", vBranchNmA);
                rpt.SetParameterValue("UsrNamE", vUsrNmE);
                rpt.SetParameterValue("BranchNameE", vBranchNmE);
                try
                {
                    if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 20))
                    {
                        rpt.ReportDefinition.ReportObjects["Line2"].ObjectFormat.EnableSuppress = true;
                         rpt.ReportDefinition.ReportObjects["Text27"].ObjectFormat.EnableSuppress = true;
try{
rpt.ReportDefinition.ReportObjects["Text39"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line26"].ObjectFormat.EnableSuppress = true;

}catch
{
}
                        rpt.ReportDefinition.ReportObjects["SerialKey1"].ObjectFormat.EnableSuppress = true;
                        try
                        {
                            rpt.ReportDefinition.Sections[3].ReportObjects["Line2t"].ObjectFormat.EnableSuppress = true;
                        }
                        catch
                        {
                        }
                        if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16))
                        {
                            rpt.ReportDefinition.ReportObjects["Text13"].Width = 2924;
                            rpt.ReportDefinition.ReportObjects["ItmDes1"].Width = 2924;
                            rpt.ReportDefinition.ReportObjects["Text13"].Left = 7106;
                            rpt.ReportDefinition.ReportObjects["ItmDes1"].Left = 7106;
                        }
                        else
                        {
                            rpt.ReportDefinition.ReportObjects["Text13"].Width = 3536;
                            rpt.ReportDefinition.ReportObjects["ItmDes1"].Width = 3536;
                            rpt.ReportDefinition.ReportObjects["Text13"].Left = 6460;
                            rpt.ReportDefinition.ReportObjects["ItmDes1"].Left = 6460;
                        }
                    }
                }
                catch
                {
                }
                try
                {
                    if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 19) || !VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 21))
                    {
                        if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 19) && VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 21))
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                rpt.ReportDefinition.ReportObjects["Line22"].ObjectFormat.EnableSuppress = true; rpt.ReportDefinition.ReportObjects["Text28"].ObjectFormat.EnableSuppress = true;
try{
rpt.ReportDefinition.ReportObjects["Text40"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line13"].ObjectFormat.EnableSuppress = true;


}catch
{
}
                                rpt.ReportDefinition.ReportObjects["DatExper1"].ObjectFormat.EnableSuppress = true;
                                try
                                {
                                    rpt.ReportDefinition.ReportObjects["Line22t"].ObjectFormat.EnableSuppress = true;
                                }
                                catch
                                {
                                }
                                rpt.ReportDefinition.ReportObjects["Text7"].Width = 1700;
                                rpt.ReportDefinition.ReportObjects["Amount1"].Width = 1700;
                                rpt.ReportDefinition.ReportObjects["Text7"].Left = 170;
rpt.ReportDefinition.ReportObjects["Text32"].Left = 170;
                                rpt.ReportDefinition.ReportObjects["Amount1"].Left = 170;
                            }
                            else
                            {
                                rpt.ReportDefinition.ReportObjects["Line22"].ObjectFormat.EnableSuppress = true; rpt.ReportDefinition.ReportObjects["Text28"].ObjectFormat.EnableSuppress = true;
try{
rpt.ReportDefinition.ReportObjects["Text40"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line13"].ObjectFormat.EnableSuppress = true;


}catch
{
}
                                rpt.ReportDefinition.ReportObjects["DatExper1"].ObjectFormat.EnableSuppress = true;
                                try
                                {
                                    rpt.ReportDefinition.ReportObjects["Line22t"].ObjectFormat.EnableSuppress = true;
                                }
                                catch
                                {
                                }
                                rpt.ReportDefinition.ReportObjects["Text7"].Width = 1768;
                                rpt.ReportDefinition.ReportObjects["Amount1"].Width = 1768;
                                rpt.ReportDefinition.ReportObjects["Text7"].Left = 9282;
                                rpt.ReportDefinition.ReportObjects["Amount1"].Left = 9282;
                            }
                        }
                        else if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 19) && !VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 21))
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                rpt.ReportDefinition.ReportObjects["Line3"].ObjectFormat.EnableSuppress = true; rpt.ReportDefinition.ReportObjects["Text29"].ObjectFormat.EnableSuppress = true;
 try{
rpt.ReportDefinition.ReportObjects["Text41"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line14"].ObjectFormat.EnableSuppress = true;
}catch
{
}rpt.ReportDefinition.ReportObjects["RunCod1"].ObjectFormat.EnableSuppress = true;
                                try
                                {
                                    rpt.ReportDefinition.ReportObjects["Line3t"].ObjectFormat.EnableSuppress = true;
                                }
                                catch
                                {
                                }
                                rpt.ReportDefinition.ReportObjects["Text28"].Width = 1632;
rpt.ReportDefinition.ReportObjects["Text40"].Width = 1632;
                                rpt.ReportDefinition.ReportObjects["Text28"].Left = 1156;
rpt.ReportDefinition.ReportObjects["Text40"].Left = 1156;
                                rpt.ReportDefinition.ReportObjects["DatExper1"].Width = 1632;
                                rpt.ReportDefinition.ReportObjects["DatExper1"].Left = 1156;
                            }
                            else
                            {
                                rpt.ReportDefinition.ReportObjects["Line3"].ObjectFormat.EnableSuppress = true; rpt.ReportDefinition.ReportObjects["Text29"].ObjectFormat.EnableSuppress = true;
 try{
rpt.ReportDefinition.ReportObjects["Text41"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line14"].ObjectFormat.EnableSuppress = true;
}catch
{
}rpt.ReportDefinition.ReportObjects["RunCod1"].ObjectFormat.EnableSuppress = true;
                                try
                                {
                                    rpt.ReportDefinition.ReportObjects["Line3t"].ObjectFormat.EnableSuppress = true;
                                }
                                catch
                                {
                                }
                                rpt.ReportDefinition.ReportObjects["Text28"].Width = 1632;
rpt.ReportDefinition.ReportObjects["Text40"].Width = 1632;
                                rpt.ReportDefinition.ReportObjects["Text28"].Left = 8364;
                                rpt.ReportDefinition.ReportObjects["DatExper1"].Width = 1632;
                                rpt.ReportDefinition.ReportObjects["DatExper1"].Left = 8364;
                            }
                        }
                        else if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            rpt.ReportDefinition.ReportObjects["Line3"].ObjectFormat.EnableSuppress = true; rpt.ReportDefinition.ReportObjects["Text29"].ObjectFormat.EnableSuppress = true;
 try{
rpt.ReportDefinition.ReportObjects["Text41"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line14"].ObjectFormat.EnableSuppress = true;
}catch
{
}rpt.ReportDefinition.ReportObjects["RunCod1"].ObjectFormat.EnableSuppress = true;
                            try
                            {
                                rpt.ReportDefinition.ReportObjects["Line3t"].ObjectFormat.EnableSuppress = true;
                            }
                            catch
                            {
                            }
                            rpt.ReportDefinition.ReportObjects["Line22"].ObjectFormat.EnableSuppress = true;
                            try
                            {
                                rpt.ReportDefinition.ReportObjects["Line22t"].ObjectFormat.EnableSuppress = true;
                            }
                            catch
                            {
                            } rpt.ReportDefinition.ReportObjects["Text28"].ObjectFormat.EnableSuppress = true;
try{
rpt.ReportDefinition.ReportObjects["Text40"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line13"].ObjectFormat.EnableSuppress = true;


}catch
{
}
                            rpt.ReportDefinition.ReportObjects["DatExper1"].ObjectFormat.EnableSuppress = true;
                            rpt.ReportDefinition.ReportObjects["Text7"].Width = 2618;

rpt.ReportDefinition.ReportObjects["Text32"].Width = 2618;

                            rpt.ReportDefinition.ReportObjects["Amount1"].Width = 2618;
                            rpt.ReportDefinition.ReportObjects["Text7"].Left = 170;
rpt.ReportDefinition.ReportObjects["Text32"].Left = 170;
                            rpt.ReportDefinition.ReportObjects["Amount1"].Left = 170;
                        }
                        else
                        {
                            rpt.ReportDefinition.ReportObjects["Line3"].ObjectFormat.EnableSuppress = true; rpt.ReportDefinition.ReportObjects["Text29"].ObjectFormat.EnableSuppress = true;
 try{
rpt.ReportDefinition.ReportObjects["Text41"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line14"].ObjectFormat.EnableSuppress = true;
}catch
{
}rpt.ReportDefinition.ReportObjects["RunCod1"].ObjectFormat.EnableSuppress = true;
                            try
                            {
                                rpt.ReportDefinition.ReportObjects["Line3t"].ObjectFormat.EnableSuppress = true;
                            }
                            catch
                            {
                            }
                            rpt.ReportDefinition.ReportObjects["Line22"].ObjectFormat.EnableSuppress = true;
                            try
                            {
                                rpt.ReportDefinition.ReportObjects["Line22t"].ObjectFormat.EnableSuppress = true;
                            }
                            catch
                            {
                            } rpt.ReportDefinition.ReportObjects["Text28"].ObjectFormat.EnableSuppress = true;
try{
rpt.ReportDefinition.ReportObjects["Text40"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line13"].ObjectFormat.EnableSuppress = true;


}catch
{
}
                            rpt.ReportDefinition.ReportObjects["DatExper1"].ObjectFormat.EnableSuppress = true;
                            rpt.ReportDefinition.ReportObjects["Text7"].Width = 2618;

rpt.ReportDefinition.ReportObjects["Text32"].Width = 2618;

                            rpt.ReportDefinition.ReportObjects["Amount1"].Width = 2618;
                            rpt.ReportDefinition.ReportObjects["Text7"].Left = 8330;
                            rpt.ReportDefinition.ReportObjects["Amount1"].Left = 8330;
                        }
                    }
                }
                catch
                {
                }
                if (_InvSetting.ISdirectPrinting || BarcodSts)
                {
                    PrintSet(rpt, (int)_InvSetting.lnPg.Value, (_InvSetting.Orientation == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, _InvSetting.defSizePaper, _InvSetting.DefLines.Value, VarGeneral.Print_set_Gen_Stat ? VarGeneral.prnt_doc_Gen.PrinterSettings.PrinterName : _InvSetting.defPrn, _InvSetting.hAs.Value, _InvSetting.hYs.Value, _InvSetting.hYm.Value, _InvSetting.hAl.Value);
                }
                else
                {
                    setpagesetting(rpt);
                }
            }
            else if (repvalue == "InvSalWtr")
            {
                if ((!db.StockInvSetting(21).PrintCat.Value && !db.StockInvSetting(21).autoCommGaid.Value) || (VarGeneral.SSSLev != "R" && VarGeneral.SSSLev != "C" && VarGeneral.SSSLev != "H") || _GroupsIsPrint)
                {
                    STEP_1();
                }
                else if (db.StockInvSetting(21).PrintCat.Value && !db.StockInvSetting(21).autoCommGaid.Value)
                {
                    STEP_2();
                }
                else
                {
                    STEP_1();
                    if (db.StockInvSetting(21).ISdirectPrinting || BarcodSts)
                    {
                        STEP_2();
                    }
                }
            }
            else if (repvalue == "InvSalWaiter")
            {
                T_Printer _InvSetting = new T_Printer();
                _InvSetting = db.StockPrinterSetting(VarGeneral.UserID, VarGeneral.InvTyp);
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    try
                    {
                        if (VarGeneral.gUserName == "runsetting")
                        {
                            if (File.Exists(Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvWaiter.rpt"))
                            {
                                MainCryRep.FileName = Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvWaiter.rpt";
                                addqrcode(MainCryRep);
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.Reports.RepInvWaiter");
                            }
                        }
                        else if (File.Exists(Application.StartupPath + "\\Reps\\RepInvWaiter.rpt"))
                        {
                            MainCryRep.FileName = Application.StartupPath + "\\Reps\\RepInvWaiter.rpt";
                            addqrcode(MainCryRep);
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.Reports.RepInvWaiter");
                        }
                    }
                    catch
                    {
                        MainCryRep = getdoc("InvAcc.Reports.RepInvWaiter");
                    }
                }
                else
                {
                    try
                    {
                        if (VarGeneral.gUserName == "runsetting")
                        {
                            if (File.Exists(Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvWaiter.rpt"))
                            {
                                MainCryRep.FileName = Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvWaiter.rpt";
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsE.RepInvWaiter");
                            }
                        }
                        else if (File.Exists(Application.StartupPath + "\\RepsE\\RepInvWaiter.rpt"))
                        {
                            MainCryRep.FileName = Application.StartupPath + "\\RepsE\\RepInvWaiter.rpt";
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsE.RepInvWaiter");
                        }
                    }
                    catch
                    {
                        MainCryRep = getdoc("InvAcc.ReportsE.RepInvWaiter");
                    }
                }
                ReportDocument rpt = MainCryRep;
                string vUsrNmA = string.Empty;
                string vBranchNmA = string.Empty;
                string vUsrNmE = string.Empty;
                string vBranchNmE = string.Empty;
                try
                {
                    vUsrNmA = VarGeneral.RepData.Tables[0].Rows[0]["UsrNamA"].ToString();
                }
                catch
                {
                    vUsrNmA = string.Empty;
                }
                try
                {
                    vUsrNmE = VarGeneral.RepData.Tables[0].Rows[0]["UsrNamE"].ToString();
                }
                catch
                {
                    vUsrNmE = string.Empty;
                }
                try
                {
                    vBranchNmA = VarGeneral.RepData.Tables[0].Rows[0]["Branch_Name"].ToString();
                }
                catch
                {
                    vBranchNmA = string.Empty;
                }
                try
                {
                    vBranchNmE = VarGeneral.RepData.Tables[0].Rows[0]["Branch_NameE"].ToString();
                }
                catch
                {
                    vBranchNmE = string.Empty;
                }
                VarGeneral.RepData.Tables[0].Rows[0].Delete();
                rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
           setTarwisaa(rpt);try
                {
                    if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16))
                    {
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            rpt.ReportDefinition.Sections[3].ReportObjects["Line7"].ObjectFormat.EnableSuppress = true; rpt.ReportDefinition.Sections[3].ReportObjects["Text12"].ObjectFormat.EnableSuppress = true;
 try{ 
rpt.ReportDefinition.Sections[3].ReportObjects["Text33"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.Sections[3].ReportObjects["Line25"].ObjectFormat.EnableSuppress = true;
                                   
}catch{}
                                    rpt.ReportDefinition.Sections[3].ReportObjects["Text27"].Width = 1496;
                            rpt.ReportDefinition.Sections[3].ReportObjects["SerialKey1"].Width = 1496;
                            rpt.ReportDefinition.Sections[3].ReportObjects["Text27"].Left = 6494;
                            rpt.ReportDefinition.Sections[3].ReportObjects["SerialKey1"].Left = 6494;
                            try
                            {
                                rpt.ReportDefinition.Sections[3].ReportObjects["Line7t"].ObjectFormat.EnableSuppress = true;
rpt.ReportDefinition.Sections[3].ReportObjects["StoreNo1"].ObjectFormat.EnableSuppress = true;}
                            catch
                            {
                            }
                        }
                        else
                        {
                            rpt.ReportDefinition.Sections[3].ReportObjects["Line7"].ObjectFormat.EnableSuppress = true; rpt.ReportDefinition.Sections[3].ReportObjects["Text12"].ObjectFormat.EnableSuppress = true;
 try{ 
rpt.ReportDefinition.Sections[3].ReportObjects["Text33"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.Sections[3].ReportObjects["Line25"].ObjectFormat.EnableSuppress = true;
                                   
}catch{}
                                    rpt.ReportDefinition.Sections[3].ReportObjects["Text27"].Width = 1496;
                            rpt.ReportDefinition.Sections[3].ReportObjects["SerialKey1"].Width = 1496;
                            rpt.ReportDefinition.Sections[3].ReportObjects["Text27"].Left = 3162;
                            rpt.ReportDefinition.Sections[3].ReportObjects["SerialKey1"].Left = 3162;
                            try
                            {
                                rpt.ReportDefinition.Sections[3].ReportObjects["Line7t"].ObjectFormat.EnableSuppress = true;
rpt.ReportDefinition.Sections[3].ReportObjects["StoreNo1"].ObjectFormat.EnableSuppress = true;}
                            catch
                            {
                            }
                        }
                    }
                }
                catch
                {
                }
                try
                {
                    rpt.SetParameterValue("IsCashCredit", VarGeneral.IsCashCredit ? "1" : "0");
                }
                catch
                {
                }
                try
                {
                    rpt.SetParameterValue("vDecimal", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? "1" : "0");
                }
                catch
                {
                }
                try
                {
                    rpt.SetParameterValue("IsTotWithTax", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 65) ? "1" : "0");
                }
                catch
                {
                }
                try
                {
                    (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                }
                catch
                {
                }
                try
                {
                    (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                }
                catch
                {
                }
                rpt.SetParameterValue("StoreSts", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16) ? "Show" : "Hide");
                if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                {
                    rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                }
                else
                {
                    rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                }
                rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                rpt.SetParameterValue("vSts", false);
                rpt.SetParameterValue("vLines", 1);
                if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.LineDetailSts, vStr(VarGeneral.InvTyp)))
                {
                    rpt.SetParameterValue("LineDetailNa", VarGeneral.Settings_Sys.LineDetailNameA);
                    rpt.SetParameterValue("LineDetailNa_Eng", VarGeneral.Settings_Sys.LineDetailNameE);
                }
                else
                {
                    rpt.SetParameterValue("LineDetailNa", string.Empty);
                    rpt.SetParameterValue("LineDetailNa_Eng", string.Empty);
                }
                rpt.SetParameterValue("UserName", vUsrNmA);
                rpt.SetParameterValue("BranchName", vBranchNmA);
                rpt.SetParameterValue("UsrNamE", vUsrNmE);
                rpt.SetParameterValue("BranchNameE", vBranchNmE);
                try
                {
                    if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 20))
                    {
                        rpt.ReportDefinition.ReportObjects["Line2"].ObjectFormat.EnableSuppress = true;
                         rpt.ReportDefinition.ReportObjects["Text27"].ObjectFormat.EnableSuppress = true;
try{
rpt.ReportDefinition.ReportObjects["Text39"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line26"].ObjectFormat.EnableSuppress = true;

}catch
{
}
                        rpt.ReportDefinition.ReportObjects["SerialKey1"].ObjectFormat.EnableSuppress = true;
                        try
                        {
                            rpt.ReportDefinition.Sections[3].ReportObjects["Line2t"].ObjectFormat.EnableSuppress = true;
                        }
                        catch
                        {
                        }
                        if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16))
                        {
                            rpt.ReportDefinition.ReportObjects["Text13"].Width = 2924;
                            rpt.ReportDefinition.ReportObjects["ItmDes1"].Width = 2924;
                            rpt.ReportDefinition.ReportObjects["Text13"].Left = 7106;
                            rpt.ReportDefinition.ReportObjects["ItmDes1"].Left = 7106;
                        }
                        else
                        {
                            rpt.ReportDefinition.ReportObjects["Text13"].Width = 3536;
                            rpt.ReportDefinition.ReportObjects["ItmDes1"].Width = 3536;
                            rpt.ReportDefinition.ReportObjects["Text13"].Left = 6460;
                            rpt.ReportDefinition.ReportObjects["ItmDes1"].Left = 6460;
                        }
                    }
                }
                catch
                {
                }setTotalsRpt(_InvSetting,rpt);if (_InvSetting.ISdirectPrinting || BarcodSts)
                {
                    PrintSet(rpt, (int)_InvSetting.lnPg.Value, (_InvSetting.Orientation == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, _InvSetting.defSizePaper, _InvSetting.DefLines.Value, _InvSetting.defPrn, _InvSetting.hAs.Value, _InvSetting.hYs.Value, _InvSetting.hYm.Value, _InvSetting.hAl.Value);
                }
                else
                {
                    setpagesetting(rpt);
                }
            }
            else if (repvalue == "CustQutation")
            {
                T_Printer _InvSetting = new T_Printer();
                _InvSetting = db.StockPrinterSetting(VarGeneral.UserID, VarGeneral.InvTyp);
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    try
                    {
                        if (VarGeneral.gUserName == "runsetting")
                        {
                            if (File.Exists(Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvCustQutation.rpt"))
                            {
                                MainCryRep.FileName = Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvCustQutation.rpt";
                                addqrcode(MainCryRep);
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.Reports.RepInvCustQutation");
                            }
                        }
                        else if (File.Exists(Application.StartupPath + "\\Reps\\RepInvCustQutation.rpt"))
                        {
                            MainCryRep.FileName = Application.StartupPath + "\\Reps\\RepInvCustQutation.rpt";
                            addqrcode(MainCryRep);
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.Reports.RepInvCustQutation");
                        }
                    }
                    catch
                    {
                        MainCryRep = getdoc("InvAcc.Reports.RepInvCustQutation");
                    }
                }
                else
                {
                    try
                    {
                        if (VarGeneral.gUserName == "runsetting")
                        {
                            if (File.Exists(Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvCustQutation.rpt"))
                            {
                                MainCryRep.FileName = Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvCustQutation.rpt";
                                addqrcode(MainCryRep);
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsE.RepInvCustQutation");
                            }
                        }
                        else if (File.Exists(Application.StartupPath + "\\RepsE\\RepInvCustQutation.rpt"))
                        {
                            MainCryRep.FileName = Application.StartupPath + "\\RepsE\\RepInvCustQutation.rpt";
                            addqrcode(MainCryRep);
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsE.RepInvCustQutation");
                        }
                    }
                    catch
                    {
                        MainCryRep = getdoc("InvAcc.ReportsE.RepInvCustQutation");
                    }
                }
                ReportDocument rpt = MainCryRep;
                string vUsrNmA = string.Empty;
                string vBranchNmA = string.Empty;
                string vUsrNmE = string.Empty;
                string vBranchNmE = string.Empty;
                try
                {
                    vUsrNmA = VarGeneral.RepData.Tables[0].Rows[0]["UsrNamA"].ToString();
                }
                catch
                {
                    vUsrNmA = string.Empty;
                }
                try
                {
                    vUsrNmE = VarGeneral.RepData.Tables[0].Rows[0]["UsrNamE"].ToString();
                }
                catch
                {
                    vUsrNmE = string.Empty;
                }
                try
                {
                    vBranchNmA = VarGeneral.RepData.Tables[0].Rows[0]["Branch_Name"].ToString();
                }
                catch
                {
                    vBranchNmA = string.Empty;
                }
                try
                {
                    vBranchNmE = VarGeneral.RepData.Tables[0].Rows[0]["Branch_NameE"].ToString();
                }
                catch
                {
                    vBranchNmE = string.Empty;
                }
                VarGeneral.RepData.Tables[0].Rows[0].Delete();
                rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
           setTarwisaa(rpt);try
                {
         setTarwisaatax(_InvSetting,rpt);}
                catch
                {
                }
   setitemsoptionsRpt(_InvSetting,rpt);try
                {
                    rpt.SetParameterValue("IsCashCredit", VarGeneral.IsCashCredit ? "1" : "0");
                }
                catch
                {
                }
                try
                {
                    rpt.SetParameterValue("vDecimal", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? "1" : "0");
                }
                catch
                {
                }
                try
                {
                    rpt.SetParameterValue("IsTotWithTax", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 65) ? "1" : "0");
                }
                catch
                {
                }
                try
                {
                    (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                }
                catch
                {
                }
                try
                {
                    (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                }
                catch
                {
                }
                rpt.SetParameterValue("StoreSts", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16) ? "Show" : "Hide");
                if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                {
                    rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                }
                else
                {
                    rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                }
                rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                rpt.SetParameterValue("vSts", false);
                rpt.SetParameterValue("vLines", 1);
                if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.LineDetailSts, vStr(VarGeneral.InvTyp)))
                {
                    rpt.SetParameterValue("LineDetailNa", VarGeneral.Settings_Sys.LineDetailNameA);
                    rpt.SetParameterValue("LineDetailNa_Eng", VarGeneral.Settings_Sys.LineDetailNameE);
                }
                else
                {
                    rpt.SetParameterValue("LineDetailNa", string.Empty);
                    rpt.SetParameterValue("LineDetailNa_Eng", string.Empty);
                }
                rpt.SetParameterValue("UserName", vUsrNmA);
                rpt.SetParameterValue("BranchName", vBranchNmA);
                rpt.SetParameterValue("UsrNamE", vUsrNmE);
                rpt.SetParameterValue("BranchNameE", vBranchNmE);
                try
                {
                    if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 20))
                    {
                        rpt.ReportDefinition.ReportObjects["Line2"].ObjectFormat.EnableSuppress = true;
                         rpt.ReportDefinition.ReportObjects["Text27"].ObjectFormat.EnableSuppress = true;
try{
rpt.ReportDefinition.ReportObjects["Text39"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line26"].ObjectFormat.EnableSuppress = true;

}catch
{
}
                        rpt.ReportDefinition.ReportObjects["SerialKey1"].ObjectFormat.EnableSuppress = true;
                        try
                        {
                            rpt.ReportDefinition.Sections[3].ReportObjects["Line2t"].ObjectFormat.EnableSuppress = true;
                        }
                        catch
                        {
                        }
                        if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16))
                        {
                            rpt.ReportDefinition.ReportObjects["Text13"].Width = 2924;
                            rpt.ReportDefinition.ReportObjects["ItmDes1"].Width = 2924;
                            rpt.ReportDefinition.ReportObjects["Text13"].Left = 7106;
                            rpt.ReportDefinition.ReportObjects["ItmDes1"].Left = 7106;
                        }
                        else
                        {
                            rpt.ReportDefinition.ReportObjects["Text13"].Width = 3536;
                            rpt.ReportDefinition.ReportObjects["ItmDes1"].Width = 3536;
                            rpt.ReportDefinition.ReportObjects["Text13"].Left = 6460;
                            rpt.ReportDefinition.ReportObjects["ItmDes1"].Left = 6460;
                        }
                    }
                }
                catch
                {
                }setTotalsRpt(_InvSetting,rpt);if (_InvSetting.ISdirectPrinting || BarcodSts)
                {
                    PrintSet(rpt, (int)_InvSetting.lnPg.Value, (_InvSetting.Orientation == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, _InvSetting.defSizePaper, _InvSetting.DefLines.Value, _InvSetting.defPrn, _InvSetting.hAs.Value, _InvSetting.hYs.Value, _InvSetting.hYm.Value, _InvSetting.hAl.Value);
                }
                else
                {
                    setpagesetting(rpt);
                }
            }
            else if (repvalue == "InvTransInOut")
            {
                T_Printer _InvSetting = new T_Printer();
                _InvSetting = db.StockPrinterSetting(VarGeneral.UserID, VarGeneral.InvTyp);
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    try
                    {
                        if (VarGeneral.gUserName == "runsetting")
                        {
                            if (File.Exists(Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvTransInOut.rpt"))
                            {
                                MainCryRep.FileName = Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvTransInOut.rpt";
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.Reports.RepInvTransInOut");
                            }
                        }
                        else if (File.Exists(Application.StartupPath + "\\Reps\\RepInvTransInOut.rpt"))
                        {
                            MainCryRep.FileName = Application.StartupPath + "\\Reps\\RepInvTransInOut.rpt";
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.Reports.RepInvTransInOut");
                        }
                    }
                    catch
                    {
                        MainCryRep = getdoc("InvAcc.Reports.RepInvTransInOut");
                    }
                }
                else
                {
                    try
                    {
                        if (VarGeneral.gUserName == "runsetting")
                        {
                            if (File.Exists(Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvTransInOut.rpt"))
                            {
                                MainCryRep.FileName = Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvTransInOut.rpt";
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsE.RepInvTransInOut");
                            }
                        }
                        else if (File.Exists(Application.StartupPath + "\\RepsE\\RepInvTransInOut.rpt"))
                        {
                            MainCryRep.FileName = Application.StartupPath + "\\RepsE\\RepInvTransInOut.rpt";
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsE.RepInvTransInOut");
                        }
                    }
                    catch
                    {
                        MainCryRep = getdoc("InvAcc.ReportsE.RepInvTransInOut");
                    }
                }
                ReportDocument rpt = MainCryRep;
                string vUsrNmA = string.Empty;
                string vBranchNmA = string.Empty;
                string vUsrNmE = string.Empty;
                string vBranchNmE = string.Empty;
                try
                {
                    vUsrNmA = VarGeneral.RepData.Tables[0].Rows[0]["UsrNamA"].ToString();
                }
                catch
                {
                    vUsrNmA = string.Empty;
                }
                try
                {
                    vUsrNmE = VarGeneral.RepData.Tables[0].Rows[0]["UsrNamE"].ToString();
                }
                catch
                {
                    vUsrNmE = string.Empty;
                }
                try
                {
                    vBranchNmA = VarGeneral.RepData.Tables[0].Rows[0]["Branch_Name"].ToString();
                }
                catch
                {
                    vBranchNmA = string.Empty;
                }
                try
                {
                    vBranchNmE = VarGeneral.RepData.Tables[0].Rows[0]["Branch_NameE"].ToString();
                }
                catch
                {
                    vBranchNmE = string.Empty;
                }
                VarGeneral.RepData.Tables[0].Rows[0].Delete();
                rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
           setTarwisaa(rpt);try
                {
                    if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16))
                    {
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            rpt.ReportDefinition.Sections[3].ReportObjects["Line7"].ObjectFormat.EnableSuppress = true; rpt.ReportDefinition.Sections[3].ReportObjects["Text12"].ObjectFormat.EnableSuppress = true;
 try{ 
rpt.ReportDefinition.Sections[3].ReportObjects["Text33"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.Sections[3].ReportObjects["Line25"].ObjectFormat.EnableSuppress = true;
                                   
}catch{}
                                    rpt.ReportDefinition.Sections[3].ReportObjects["Text27"].Width = 1496;
                            rpt.ReportDefinition.Sections[3].ReportObjects["SerialKey1"].Width = 1496;
                            rpt.ReportDefinition.Sections[3].ReportObjects["Text27"].Left = 6494;
                            rpt.ReportDefinition.Sections[3].ReportObjects["SerialKey1"].Left = 6494;
                            try
                            {
                                rpt.ReportDefinition.Sections[3].ReportObjects["Line7t"].ObjectFormat.EnableSuppress = true;
rpt.ReportDefinition.Sections[3].ReportObjects["StoreNo1"].ObjectFormat.EnableSuppress = true;}
                            catch
                            {
                            }
                        }
                        else
                        {
                            rpt.ReportDefinition.Sections[3].ReportObjects["Line7"].ObjectFormat.EnableSuppress = true; rpt.ReportDefinition.Sections[3].ReportObjects["Text12"].ObjectFormat.EnableSuppress = true;
 try{ 
rpt.ReportDefinition.Sections[3].ReportObjects["Text33"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.Sections[3].ReportObjects["Line25"].ObjectFormat.EnableSuppress = true;
                                   
}catch{}
                                    rpt.ReportDefinition.Sections[3].ReportObjects["Text27"].Width = 1496;
                            rpt.ReportDefinition.Sections[3].ReportObjects["SerialKey1"].Width = 1496;
                            rpt.ReportDefinition.Sections[3].ReportObjects["Text27"].Left = 3162;
                            rpt.ReportDefinition.Sections[3].ReportObjects["SerialKey1"].Left = 3162;
                            try
                            {
                                rpt.ReportDefinition.Sections[3].ReportObjects["Line7t"].ObjectFormat.EnableSuppress = true;
rpt.ReportDefinition.Sections[3].ReportObjects["StoreNo1"].ObjectFormat.EnableSuppress = true;}
                            catch
                            {
                            }
                        }
                    }
                }
                catch
                {
                }
                try
                {
         setTarwisaatax(_InvSetting,rpt);}
                catch
                {
                }
                try
                {
                    rpt.SetParameterValue("IsCashCredit", VarGeneral.IsCashCredit ? "1" : "0");
                }
                catch
                {
                }
                try
                {
                    rpt.SetParameterValue("vDecimal", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? "1" : "0");
                }
                catch
                {
                }
                try
                {
                    rpt.SetParameterValue("IsTotWithTax", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 65) ? "1" : "0");
                }
                catch
                {
                }
                try
                {
                    (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                }
                catch
                {
                }
                try
                {
                    (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                }
                catch
                {
                }
                rpt.SetParameterValue("StoreSts", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16) ? "Show" : "Hide");
                if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                {
                    rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                }
                else
                {
                    rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                }
                rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                rpt.SetParameterValue("vSts", false);
                rpt.SetParameterValue("vLines", 1);
                if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.LineDetailSts, vStr(VarGeneral.InvTyp)))
                {
                    rpt.SetParameterValue("LineDetailNa", VarGeneral.Settings_Sys.LineDetailNameA);
                    rpt.SetParameterValue("LineDetailNa_Eng", VarGeneral.Settings_Sys.LineDetailNameE);
                }
                else
                {
                    rpt.SetParameterValue("LineDetailNa", string.Empty);
                    rpt.SetParameterValue("LineDetailNa_Eng", string.Empty);
                }
                rpt.SetParameterValue("UserName", vUsrNmA);
                rpt.SetParameterValue("BranchName", vBranchNmA);
                rpt.SetParameterValue("UsrNamE", vUsrNmE);
                rpt.SetParameterValue("BranchNameE", vBranchNmE);
                try
                {
                    if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 20))
                    {
                        rpt.ReportDefinition.ReportObjects["Line2"].ObjectFormat.EnableSuppress = true;
                         rpt.ReportDefinition.ReportObjects["Text27"].ObjectFormat.EnableSuppress = true;
try{
rpt.ReportDefinition.ReportObjects["Text39"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line26"].ObjectFormat.EnableSuppress = true;

}catch
{
}
                        rpt.ReportDefinition.ReportObjects["SerialKey1"].ObjectFormat.EnableSuppress = true;
                        try
                        {
                            rpt.ReportDefinition.Sections[3].ReportObjects["Line2t"].ObjectFormat.EnableSuppress = true;
                        }
                        catch
                        {
                        }
                        if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16))
                        {
                            rpt.ReportDefinition.ReportObjects["Text13"].Width = 2924;
                            rpt.ReportDefinition.ReportObjects["ItmDes1"].Width = 2924;
                            rpt.ReportDefinition.ReportObjects["Text13"].Left = 7106;
                            rpt.ReportDefinition.ReportObjects["ItmDes1"].Left = 7106;
                        }
                        else
                        {
                            rpt.ReportDefinition.ReportObjects["Text13"].Width = 3536;
                            rpt.ReportDefinition.ReportObjects["ItmDes1"].Width = 3536;
                            rpt.ReportDefinition.ReportObjects["Text13"].Left = 6460;
                            rpt.ReportDefinition.ReportObjects["ItmDes1"].Left = 6460;
                        }
                    }
                }
                catch
                {
                }setTotalsRpt(_InvSetting,rpt);if (_InvSetting.ISdirectPrinting)
                {
                    PrintSet(rpt, (int)_InvSetting.lnPg.Value, (_InvSetting.Orientation == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, _InvSetting.defSizePaper, _InvSetting.DefLines.Value, _InvSetting.defPrn, _InvSetting.hAs.Value, _InvSetting.hYs.Value, _InvSetting.hYm.Value, _InvSetting.hAl.Value);
                }
                else
                {
                    setpagesetting(rpt);
                }
            }
            else if (repvalue == "OpenQty")
            {
                T_Printer _InvSetting = new T_Printer();
                _InvSetting = db.StockPrinterSetting(VarGeneral.UserID, VarGeneral.InvTyp);
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    try
                    {
                        if (VarGeneral.gUserName == "runsetting")
                        {
                            if (File.Exists(Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepOpenQty.rpt"))
                            {
                                MainCryRep.FileName = Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepOpenQty.rpt";
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.Reports.RepOpenQty");
                            }
                        }
                        else if (File.Exists(Application.StartupPath + "\\Reps\\RepOpenQty.rpt"))
                        {
                            MainCryRep.FileName = Application.StartupPath + "\\Reps\\RepOpenQty.rpt";
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.Reports.RepOpenQty");
                        }
                    }
                    catch
                    {
                        MainCryRep = getdoc("InvAcc.Reports.RepOpenQty");
                    }
                }
                else
                {
                    try
                    {
                        if (VarGeneral.gUserName == "runsetting")
                        {
                            if (File.Exists(Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepOpenQty.rpt"))
                            {
                                MainCryRep.FileName = Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepOpenQty.rpt";
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsE.RepOpenQty");
                            }
                        }
                        else if (File.Exists(Application.StartupPath + "\\RepsE\\RepOpenQty.rpt"))
                        {
                            MainCryRep.FileName = Application.StartupPath + "\\RepsE\\RepOpenQty.rpt";
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsE.RepOpenQty");
                        }
                    }
                    catch
                    {
                        MainCryRep = getdoc("InvAcc.ReportsE.RepOpenQty");
                    }
                }
                ReportDocument rpt = MainCryRep;
                string vUsrNmA = string.Empty;
                string vBranchNmA = string.Empty;
                string vUsrNmE = string.Empty;
                string vBranchNmE = string.Empty;
                try
                {
                    vUsrNmA = VarGeneral.RepData.Tables[0].Rows[0]["UsrNamA"].ToString();
                }
                catch
                {
                    vUsrNmA = string.Empty;
                }
                try
                {
                    vUsrNmE = VarGeneral.RepData.Tables[0].Rows[0]["UsrNamE"].ToString();
                }
                catch
                {
                    vUsrNmE = string.Empty;
                }
                try
                {
                    vBranchNmA = VarGeneral.RepData.Tables[0].Rows[0]["Branch_Name"].ToString();
                }
                catch
                {
                    vBranchNmA = string.Empty;
                }
                try
                {
                    vBranchNmE = VarGeneral.RepData.Tables[0].Rows[0]["Branch_NameE"].ToString();
                }
                catch
                {
                    vBranchNmE = string.Empty;
                }
                VarGeneral.RepData.Tables[0].Rows[0].Delete();
                rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
           setTarwisaa(rpt);try
                {
         setTarwisaatax(_InvSetting,rpt);}
                catch
                {
                }
   setitemsoptionsRpt(_InvSetting,rpt);try
                {
                    rpt.SetParameterValue("IsCashCredit", VarGeneral.IsCashCredit ? "1" : "0");
                }
                catch
                {
                }
                try
                {
                    rpt.SetParameterValue("vDecimal", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? "1" : "0");
                }
                catch
                {
                }
                try
                {
                    rpt.SetParameterValue("IsTotWithTax", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 65) ? "1" : "0");
                }
                catch
                {
                }
                try
                {
                    (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                }
                catch
                {
                }
                try
                {
                    (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                }
                catch
                {
                }
                rpt.SetParameterValue("StoreSts", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16) ? "Show" : "Hide");
                if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                {
                    rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                }
                else
                {
                    rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                }
                rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                rpt.SetParameterValue("vSts", false);
                rpt.SetParameterValue("vLines", 1);
                if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.LineDetailSts, vStr(VarGeneral.InvTyp)))
                {
                    rpt.SetParameterValue("LineDetailNa", VarGeneral.Settings_Sys.LineDetailNameA);
                    rpt.SetParameterValue("LineDetailNa_Eng", VarGeneral.Settings_Sys.LineDetailNameE);
                }
                else
                {
                    rpt.SetParameterValue("LineDetailNa", string.Empty);
                    rpt.SetParameterValue("LineDetailNa_Eng", string.Empty);
                }
                rpt.SetParameterValue("UserName", vUsrNmA);
                rpt.SetParameterValue("BranchName", vBranchNmA);
                rpt.SetParameterValue("UsrNamE", vUsrNmE);
                rpt.SetParameterValue("BranchNameE", vBranchNmE);
                try
                {
                    if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 20))
                    {
                        rpt.ReportDefinition.ReportObjects["Line2"].ObjectFormat.EnableSuppress = true;
                         rpt.ReportDefinition.ReportObjects["Text27"].ObjectFormat.EnableSuppress = true;
try{
rpt.ReportDefinition.ReportObjects["Text39"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line26"].ObjectFormat.EnableSuppress = true;

}catch
{
}
                        rpt.ReportDefinition.ReportObjects["SerialKey1"].ObjectFormat.EnableSuppress = true;
                        try
                        {
                            rpt.ReportDefinition.Sections[3].ReportObjects["Line2t"].ObjectFormat.EnableSuppress = true;
                        }
                        catch
                        {
                        }
                        if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16))
                        {
                            rpt.ReportDefinition.ReportObjects["Text13"].Width = 2924;
                            rpt.ReportDefinition.ReportObjects["ItmDes1"].Width = 2924;
                            rpt.ReportDefinition.ReportObjects["Text13"].Left = 7106;
                            rpt.ReportDefinition.ReportObjects["ItmDes1"].Left = 7106;
                        }
                        else
                        {
                            rpt.ReportDefinition.ReportObjects["Text13"].Width = 3536;
                            rpt.ReportDefinition.ReportObjects["ItmDes1"].Width = 3536;
                            rpt.ReportDefinition.ReportObjects["Text13"].Left = 6460;
                            rpt.ReportDefinition.ReportObjects["ItmDes1"].Left = 6460;
                        }
                    }
                }
                catch
                {
                }setTotalsRpt(_InvSetting,rpt);if (_InvSetting.ISdirectPrinting || BarcodSts)
                {
                    PrintSet(rpt, (int)_InvSetting.lnPg.Value, (_InvSetting.Orientation == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, _InvSetting.defSizePaper, _InvSetting.DefLines.Value, _InvSetting.defPrn, _InvSetting.hAs.Value, _InvSetting.hYs.Value, _InvSetting.hYm.Value, _InvSetting.hAl.Value);
                }
                else
                {
                    setpagesetting(rpt);
                }
            }
            else if (repvalue == "OpenQtyEqual")
            {
                T_Printer _InvSetting = new T_Printer();
                _InvSetting = db.StockPrinterSetting(VarGeneral.UserID, VarGeneral.InvTyp);
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    try
                    {
                        if (VarGeneral.gUserName == "runsetting")
                        {
                            if (File.Exists(Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepStockEqual.rpt"))
                            {
                                MainCryRep.FileName = Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepStockEqual.rpt";
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.Reports.RepStockEqual");
                            }
                        }
                        else if (File.Exists(Application.StartupPath + "\\Reps\\RepStockEqual.rpt"))
                        {
                            MainCryRep.FileName = Application.StartupPath + "\\Reps\\RepStockEqual.rpt";
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.Reports.RepStockEqual");
                        }
                    }
                    catch
                    {
                        MainCryRep = getdoc("InvAcc.Reports.RepStockEqual");
                    }
                }
                else
                {
                    try
                    {
                        if (VarGeneral.gUserName == "runsetting")
                        {
                            if (File.Exists(Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepStockEqual.rpt"))
                            {
                                MainCryRep.FileName = Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepStockEqual.rpt";
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsE.RepStockEqual");
                            }
                        }
                        else if (File.Exists(Application.StartupPath + "\\RepsE\\RepStockEqual.rpt"))
                        {
                            MainCryRep.FileName = Application.StartupPath + "\\RepsE\\RepStockEqual.rpt";
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsE.RepStockEqual");
                        }
                    }
                    catch
                    {
                        MainCryRep = getdoc("InvAcc.ReportsE.RepStockEqual");
                    }
                }
                ReportDocument rpt = MainCryRep;
                string vUsrNmA = string.Empty;
                string vBranchNmA = string.Empty;
                string vUsrNmE = string.Empty;
                string vBranchNmE = string.Empty;
                try
                {
                    vUsrNmA = VarGeneral.RepData.Tables[0].Rows[0]["UsrNamA"].ToString();
                }
                catch
                {
                    vUsrNmA = string.Empty;
                }
                try
                {
                    vUsrNmE = VarGeneral.RepData.Tables[0].Rows[0]["UsrNamE"].ToString();
                }
                catch
                {
                    vUsrNmE = string.Empty;
                }
                try
                {
                    vBranchNmA = VarGeneral.RepData.Tables[0].Rows[0]["Branch_Name"].ToString();
                }
                catch
                {
                    vBranchNmA = string.Empty;
                }
                try
                {
                    vBranchNmE = VarGeneral.RepData.Tables[0].Rows[0]["Branch_NameE"].ToString();
                }
                catch
                {
                    vBranchNmE = string.Empty;
                }
                VarGeneral.RepData.Tables[0].Rows[0].Delete();
                rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
           setTarwisaa(rpt);try
                {
         setTarwisaatax(_InvSetting,rpt);}
                catch
                {
                }
   setitemsoptionsRpt(_InvSetting,rpt);try
                {
                    rpt.SetParameterValue("IsCashCredit", VarGeneral.IsCashCredit ? "1" : "0");
                }
                catch
                {
                }
                try
                {
                    rpt.SetParameterValue("vDecimal", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? "1" : "0");
                }
                catch
                {
                }
                try
                {
                    rpt.SetParameterValue("IsTotWithTax", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 65) ? "1" : "0");
                }
                catch
                {
                }
                try
                {
                    (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                }
                catch
                {
                }
                try
                {
                    (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                }
                catch
                {
                }
                rpt.SetParameterValue("StoreSts", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16) ? "Show" : "Hide");
                if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                {
                    rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                }
                else
                {
                    rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                }
                rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                rpt.SetParameterValue("vSts", false);
                rpt.SetParameterValue("vLines", 1);
                if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.LineDetailSts, vStr(VarGeneral.InvTyp)))
                {
                    rpt.SetParameterValue("LineDetailNa", VarGeneral.Settings_Sys.LineDetailNameA);
                    rpt.SetParameterValue("LineDetailNa_Eng", VarGeneral.Settings_Sys.LineDetailNameE);
                }
                else
                {
                    rpt.SetParameterValue("LineDetailNa", string.Empty);
                    rpt.SetParameterValue("LineDetailNa_Eng", string.Empty);
                }
                rpt.SetParameterValue("UserName", vUsrNmA);
                rpt.SetParameterValue("BranchName", vBranchNmA);
                rpt.SetParameterValue("UsrNamE", vUsrNmE);
                rpt.SetParameterValue("BranchNameE", vBranchNmE);
                try
                {
                    if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 20))
                    {
                        rpt.ReportDefinition.ReportObjects["Line2"].ObjectFormat.EnableSuppress = true;
                         rpt.ReportDefinition.ReportObjects["Text27"].ObjectFormat.EnableSuppress = true;
try{
rpt.ReportDefinition.ReportObjects["Text39"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line26"].ObjectFormat.EnableSuppress = true;

}catch
{
}
                        rpt.ReportDefinition.ReportObjects["SerialKey1"].ObjectFormat.EnableSuppress = true;
                        try
                        {
                            rpt.ReportDefinition.Sections[3].ReportObjects["Line2t"].ObjectFormat.EnableSuppress = true;
                        }
                        catch
                        {
                        }
                        if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16))
                        {
                            rpt.ReportDefinition.ReportObjects["Text13"].Width = 2924;
                            rpt.ReportDefinition.ReportObjects["ItmDes1"].Width = 2924;
                            rpt.ReportDefinition.ReportObjects["Text13"].Left = 7106;
                            rpt.ReportDefinition.ReportObjects["ItmDes1"].Left = 7106;
                        }
                        else
                        {
                            rpt.ReportDefinition.ReportObjects["Text13"].Width = 3536;
                            rpt.ReportDefinition.ReportObjects["ItmDes1"].Width = 3536;
                            rpt.ReportDefinition.ReportObjects["Text13"].Left = 6460;
                            rpt.ReportDefinition.ReportObjects["ItmDes1"].Left = 6460;
                        }
                    }
                }
                catch
                {
                }setTotalsRpt(_InvSetting,rpt);if (_InvSetting.ISdirectPrinting)
                {
                    PrintSet(rpt, (int)_InvSetting.lnPg.Value, (_InvSetting.Orientation == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, _InvSetting.defSizePaper, _InvSetting.DefLines.Value, _InvSetting.defPrn, _InvSetting.hAs.Value, _InvSetting.hYs.Value, _InvSetting.hYm.Value, _InvSetting.hAl.Value);
                }
                else
                {
                    setpagesetting(rpt);
                }
            }
        }

        void purch()
        {
            int? orientationSetting = VarGeneral.Settings_Sys.AutoEmp;
#pragma warning disable CS0168 // The variable 'flag2' is declared but never used
#pragma warning disable CS0168 // The variable 'flag1' is declared but never used
            bool flag1, flag2;
#pragma warning restore CS0168 // The variable 'flag1' is declared but never used
#pragma warning restore CS0168 // The variable 'flag2' is declared but never used
            if (repvalue == "Purchase")
            {
                T_Printer _InvSetting = new T_Printer();
                _InvSetting = db.StockPrinterSetting(VarGeneral.UserID, VarGeneral.InvTyp);
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    try
                    {
                        if (VarGeneral.gUserName == "runsetting")
                        {
                            if (File.Exists(Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvPurchase.rpt"))
                            {
                                MainCryRep.FileName = Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvPurchase.rpt";
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.Reports.RepInvPurchase");
                            }
                        }
                        else if (File.Exists(Application.StartupPath + "\\Reps\\RepInvPurchase.rpt"))
                        {
                            MainCryRep.FileName = Application.StartupPath + "\\Reps\\RepInvPurchase.rpt";
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.Reports.RepInvPurchase");
                        }
                    }
                    catch
                    {
                        MainCryRep = getdoc("InvAcc.Reports.RepInvPurchase");
                    }
                }
                else
                {
                    try
                    {
                        if (VarGeneral.gUserName == "runsetting")
                        {
                            if (File.Exists(Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvPurchase.rpt"))
                            {
                                MainCryRep.FileName = Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvPurchase.rpt";
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsE.RepInvPurchase");
                            }
                        }
                        else if (File.Exists(Application.StartupPath + "\\RepsE\\RepInvPurchase.rpt"))
                        {
                            MainCryRep.FileName = Application.StartupPath + "\\RepsE\\RepInvPurchase.rpt";
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsE.RepInvPurchase");
                        }
                    }
                    catch
                    {
                        MainCryRep = getdoc("InvAcc.ReportsE.RepInvPurchase");
                    }
                }
                ReportDocument rpt = MainCryRep;
                string vUsrNmA = string.Empty;
                string vBranchNmA = string.Empty;
                string vUsrNmE = string.Empty;
                string vBranchNmE = string.Empty;
                try
                {
                    vUsrNmA = VarGeneral.RepData.Tables[0].Rows[0]["UsrNamA"].ToString();
                }
                catch
                {
                    vUsrNmA = string.Empty;
                }
                try
                {
                    vUsrNmE = VarGeneral.RepData.Tables[0].Rows[0]["UsrNamE"].ToString();
                }
                catch
                {
                    vUsrNmE = string.Empty;
                }
                try
                {
                    vBranchNmA = VarGeneral.RepData.Tables[0].Rows[0]["Branch_Name"].ToString();
                }
                catch
                {
                    vBranchNmA = string.Empty;
                }
                try
                {
                    vBranchNmE = VarGeneral.RepData.Tables[0].Rows[0]["Branch_NameE"].ToString();
                }
                catch
                {
                    vBranchNmE = string.Empty;
                }
                VarGeneral.RepData.Tables[0].Rows[0].Delete();
                rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
           setTarwisaa(rpt);try
                {
         setTarwisaatax(_InvSetting,rpt);}
                catch
                {
                }
   setitemsoptionsRpt(_InvSetting,rpt);setitemsoptionsRpt2(_InvSetting,rpt);
                rpt.SetParameterValue("UserName", vUsrNmA);
                rpt.SetParameterValue("BranchName", vBranchNmA);
                rpt.SetParameterValue("UsrNamE", vUsrNmE);
                rpt.SetParameterValue("BranchNameE", vBranchNmE);

                setTotalsRpt(_InvSetting,rpt);
                
                if (_InvSetting.ISdirectPrinting || BarcodSts)
                {
                    PrintSet(rpt, (int)_InvSetting.lnPg.Value, (_InvSetting.Orientation == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, _InvSetting.defSizePaper, _InvSetting.DefLines.Value, VarGeneral.Print_set_Gen_Stat ? VarGeneral.prnt_doc_Gen.PrinterSettings.PrinterName : _InvSetting.defPrn, _InvSetting.hAs.Value, _InvSetting.hYs.Value, _InvSetting.hYm.Value, _InvSetting.hAl.Value);
                }
                else
                {
                    setpagesetting(rpt);
                }
            }
            else if (repvalue == "PurchaseReturn")
            {
                T_Printer _InvSetting = new T_Printer();
                _InvSetting = db.StockPrinterSetting(VarGeneral.UserID, VarGeneral.InvTyp);
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    try
                    {
                        if (VarGeneral.gUserName == "runsetting")
                        {
                            if (File.Exists(Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvPurchaseReturn.rpt"))
                            {
                                MainCryRep.FileName = Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvPurchaseReturn.rpt";
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.Reports.RepInvPurchaseReturn");
                            }
                        }
                        else if (File.Exists(Application.StartupPath + "\\Reps\\RepInvPurchaseReturn.rpt"))
                        {
                            MainCryRep.FileName = Application.StartupPath + "\\Reps\\RepInvPurchaseReturn.rpt";
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.Reports.RepInvPurchaseReturn");
                        }
                    }
                    catch
                    {
                        MainCryRep = getdoc("InvAcc.Reports.RepInvPurchaseReturn");
                    }
                }
                else
                {
                    try
                    {
                        if (VarGeneral.gUserName == "runsetting")
                        {
                            if (File.Exists(Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvPurchaseReturn.rpt"))
                            {
                                MainCryRep.FileName = Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvPurchaseReturn.rpt";
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsE.RepInvPurchaseReturn");
                            }
                        }
                        else if (File.Exists(Application.StartupPath + "\\RepsE\\RepInvPurchaseReturn.rpt"))
                        {
                            MainCryRep.FileName = Application.StartupPath + "\\RepsE\\RepInvPurchaseReturn.rpt";
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsE.RepInvPurchaseReturn");
                        }
                    }
                    catch
                    {
                        MainCryRep = getdoc("InvAcc.ReportsE.RepInvPurchaseReturn");
                    }
                }
                ReportDocument rpt = MainCryRep;
                string vUsrNmA = string.Empty;
                string vBranchNmA = string.Empty;
                string vUsrNmE = string.Empty;
                string vBranchNmE = string.Empty;
                try
                {
                    vUsrNmA = VarGeneral.RepData.Tables[0].Rows[0]["UsrNamA"].ToString();
                }
                catch
                {
                    vUsrNmA = string.Empty;
                }
                try
                {
                    vUsrNmE = VarGeneral.RepData.Tables[0].Rows[0]["UsrNamE"].ToString();
                }
                catch
                {
                    vUsrNmE = string.Empty;
                }
                try
                {
                    vBranchNmA = VarGeneral.RepData.Tables[0].Rows[0]["Branch_Name"].ToString();
                }
                catch
                {
                    vBranchNmA = string.Empty;
                }
                try
                {
                    vBranchNmE = VarGeneral.RepData.Tables[0].Rows[0]["Branch_NameE"].ToString();
                }
                catch
                {
                    vBranchNmE = string.Empty;
                }
                VarGeneral.RepData.Tables[0].Rows[0].Delete();
                rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
           setTarwisaa(rpt);try
                {
         setTarwisaatax(_InvSetting,rpt);}
                catch
                {
                }
   setitemsoptionsRpt(_InvSetting,rpt);try
                {
                    rpt.SetParameterValue("IsCashCredit", VarGeneral.IsCashCredit ? "1" : "0");
                }
                catch
                {
                }
                try
                {
                    rpt.SetParameterValue("vDecimal", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? "1" : "0");
                }
                catch
                {
                }
                try
                {
                    rpt.SetParameterValue("IsTotWithTax", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 65) ? "1" : "0");
                }
                catch
                {
                }
                try
                {
                    (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                }
                catch
                {
                }
                try
                {
                    (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                }
                catch
                {
                }
                rpt.SetParameterValue("StoreSts", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16) ? "Show" : "Hide");
                if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                {
                    rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                }
                else
                {
                    rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                }
                rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                try
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        rpt.SetParameterValue("HDate", (!string.IsNullOrEmpty(_InvSetting.invGdADesc)) ? _InvSetting.invGdADesc : "شكرا\u064c لكم");
                    }
                    else
                    {
                        rpt.SetParameterValue("HDate", (!string.IsNullOrEmpty(_InvSetting.invGdEDesc)) ? _InvSetting.invGdEDesc : "Thank you");
                    }
                }
                catch
                {
                    rpt.SetParameterValue("HDate", string.Empty);
                }

                rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                rpt.SetParameterValue("vSts", false);
                rpt.SetParameterValue("vLines", 1);
                if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.LineDetailSts, vStr(VarGeneral.InvTyp)))
                {
                    rpt.SetParameterValue("LineDetailNa", VarGeneral.Settings_Sys.LineDetailNameA);
                    rpt.SetParameterValue("LineDetailNa_Eng", VarGeneral.Settings_Sys.LineDetailNameE);
                }
                else
                {
                    rpt.SetParameterValue("LineDetailNa", string.Empty);
                    rpt.SetParameterValue("LineDetailNa_Eng", string.Empty);
                }
                rpt.SetParameterValue("UserName", vUsrNmA);
                rpt.SetParameterValue("BranchName", vBranchNmA);
                rpt.SetParameterValue("UsrNamE", vUsrNmE);
                rpt.SetParameterValue("BranchNameE", vBranchNmE);
                try
                {
                    if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 20))
                    {
                        rpt.ReportDefinition.ReportObjects["Line2"].ObjectFormat.EnableSuppress = true;
                         rpt.ReportDefinition.ReportObjects["Text27"].ObjectFormat.EnableSuppress = true;
try{
rpt.ReportDefinition.ReportObjects["Text39"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line26"].ObjectFormat.EnableSuppress = true;

}catch
{
}
                        rpt.ReportDefinition.ReportObjects["SerialKey1"].ObjectFormat.EnableSuppress = true;
                        try
                        {
                            rpt.ReportDefinition.Sections[3].ReportObjects["Line2t"].ObjectFormat.EnableSuppress = true;
                        }
                        catch
                        {
                        }
                        if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16))
                        {
                            rpt.ReportDefinition.ReportObjects["Text13"].Width = 2924;
                            rpt.ReportDefinition.ReportObjects["ItmDes1"].Width = 2924;
                            rpt.ReportDefinition.ReportObjects["Text13"].Left = 7106;
                            rpt.ReportDefinition.ReportObjects["ItmDes1"].Left = 7106;
                        }
                        else
                        {
                            rpt.ReportDefinition.ReportObjects["Text13"].Width = 3536;
                            rpt.ReportDefinition.ReportObjects["ItmDes1"].Width = 3536;
                            rpt.ReportDefinition.ReportObjects["Text13"].Left = 6460;
                            rpt.ReportDefinition.ReportObjects["ItmDes1"].Left = 6460;
                        }
                    }
                }
                catch
                {
                }setTotalsRpt(_InvSetting,rpt);if (_InvSetting.ISdirectPrinting || BarcodSts)
                {
                    PrintSet(rpt, (int)_InvSetting.lnPg.Value, (_InvSetting.Orientation == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, _InvSetting.defSizePaper, _InvSetting.DefLines.Value, VarGeneral.Print_set_Gen_Stat ? VarGeneral.prnt_doc_Gen.PrinterSettings.PrinterName : _InvSetting.defPrn, _InvSetting.hAs.Value, _InvSetting.hYs.Value, _InvSetting.hYm.Value, _InvSetting.hAl.Value);
                }
                else
                {
                    setpagesetting(rpt);
                }
            }
            else if (repvalue == "PurchaseOrder")
            {
                T_Printer _InvSetting = new T_Printer();
                _InvSetting = db.StockPrinterSetting(VarGeneral.UserID, VarGeneral.InvTyp);
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    try
                    {
                        if (VarGeneral.gUserName == "runsetting")
                        {
                            if (File.Exists(Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvPurOrder.rpt"))
                            {
                                MainCryRep.FileName = Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvPurOrder.rpt";
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.Reports.RepInvPurOrder");
                            }
                        }
                        else if (File.Exists(Application.StartupPath + "\\Reps\\RepInvPurOrder.rpt"))
                        {
                            MainCryRep.FileName = Application.StartupPath + "\\Reps\\RepInvPurOrder.rpt";
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.Reports.RepInvPurOrder");
                        }
                    }
                    catch
                    {
                        MainCryRep = getdoc("InvAcc.Reports.RepInvPurOrder");
                    }
                }
                else
                {
                    try
                    {
                        if (VarGeneral.gUserName == "runsetting")
                        {
                            if (File.Exists(Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvPurOrder.rpt"))
                            {
                                MainCryRep.FileName = Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvPurOrder.rpt";
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsE.RepInvPurOrder");
                            }
                        }
                        else if (File.Exists(Application.StartupPath + "\\RepsE\\RepInvPurOrder.rpt"))
                        {
                            MainCryRep.FileName = Application.StartupPath + "\\RepsE\\RepInvPurOrder.rpt";
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsE.RepInvPurOrder");
                        }
                    }
                    catch
                    {
                        MainCryRep = getdoc("InvAcc.ReportsE.RepInvPurOrder");
                    }
                }
                ReportDocument rpt = MainCryRep;
                string vUsrNmA = string.Empty;
                string vBranchNmA = string.Empty;
                string vUsrNmE = string.Empty;
                string vBranchNmE = string.Empty;
                try
                {
                    vUsrNmA = VarGeneral.RepData.Tables[0].Rows[0]["UsrNamA"].ToString();
                }
                catch
                {
                    vUsrNmA = string.Empty;
                }
                try
                {
                    vUsrNmE = VarGeneral.RepData.Tables[0].Rows[0]["UsrNamE"].ToString();
                }
                catch
                {
                    vUsrNmE = string.Empty;
                }
                try
                {
                    vBranchNmA = VarGeneral.RepData.Tables[0].Rows[0]["Branch_Name"].ToString();
                }
                catch
                {
                    vBranchNmA = string.Empty;
                }
                try
                {
                    vBranchNmE = VarGeneral.RepData.Tables[0].Rows[0]["Branch_NameE"].ToString();
                }
                catch
                {
                    vBranchNmE = string.Empty;
                }
                VarGeneral.RepData.Tables[0].Rows[0].Delete();
                rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
           setTarwisaa(rpt);try
                {
         setTarwisaatax(_InvSetting,rpt);}
                catch
                {
                }
   setitemsoptionsRpt(_InvSetting,rpt);try
                {
                    rpt.SetParameterValue("IsCashCredit", VarGeneral.IsCashCredit ? "1" : "0");
                }
                catch
                {
                }
                try
                {
                    rpt.SetParameterValue("vDecimal", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? "1" : "0");
                }
                catch
                {
                }
                try
                {
                    rpt.SetParameterValue("IsTotWithTax", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 65) ? "1" : "0");
                }
                catch
                {
                }
                try
                {
                    (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                }
                catch
                {
                }
                try
                {
                    (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                }
                catch
                {
                }
                rpt.SetParameterValue("StoreSts", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16) ? "Show" : "Hide");
                if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                {
                    rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                }
                else
                {
                    rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                }
                rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                try
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        rpt.SetParameterValue("HDate", (!string.IsNullOrEmpty(_InvSetting.invGdADesc)) ? _InvSetting.invGdADesc : "شكرا\u064c لكم");
                    }
                    else
                    {
                        rpt.SetParameterValue("HDate", (!string.IsNullOrEmpty(_InvSetting.invGdEDesc)) ? _InvSetting.invGdEDesc : "Thank you");
                    }
                }
                catch
                {
                    rpt.SetParameterValue("HDate", string.Empty);
                }

                rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                rpt.SetParameterValue("vSts", false);
                rpt.SetParameterValue("vLines", 1);
                if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.LineDetailSts, vStr(VarGeneral.InvTyp)))
                {
                    rpt.SetParameterValue("LineDetailNa", VarGeneral.Settings_Sys.LineDetailNameA);
                    rpt.SetParameterValue("LineDetailNa_Eng", VarGeneral.Settings_Sys.LineDetailNameE);
                }
                else
                {
                    rpt.SetParameterValue("LineDetailNa", string.Empty);
                    rpt.SetParameterValue("LineDetailNa_Eng", string.Empty);
                }
                rpt.SetParameterValue("UserName", vUsrNmA);
                rpt.SetParameterValue("BranchName", vBranchNmA);
                rpt.SetParameterValue("UsrNamE", vUsrNmE);
                rpt.SetParameterValue("BranchNameE", vBranchNmE);
                try
                {
                    if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 20))
                    {
                        rpt.ReportDefinition.ReportObjects["Line2"].ObjectFormat.EnableSuppress = true;
                         rpt.ReportDefinition.ReportObjects["Text27"].ObjectFormat.EnableSuppress = true;
try{
rpt.ReportDefinition.ReportObjects["Text39"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line26"].ObjectFormat.EnableSuppress = true;

}catch
{
}
                        rpt.ReportDefinition.ReportObjects["SerialKey1"].ObjectFormat.EnableSuppress = true;
                        try
                        {
                            rpt.ReportDefinition.Sections[3].ReportObjects["Line2t"].ObjectFormat.EnableSuppress = true;
                        }
                        catch
                        {
                        }
                        if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16))
                        {
                            rpt.ReportDefinition.ReportObjects["Text13"].Width = 2924;
                            rpt.ReportDefinition.ReportObjects["ItmDes1"].Width = 2924;
                            rpt.ReportDefinition.ReportObjects["Text13"].Left = 7106;
                            rpt.ReportDefinition.ReportObjects["ItmDes1"].Left = 7106;
                        }
                        else
                        {
                            rpt.ReportDefinition.ReportObjects["Text13"].Width = 3536;
                            rpt.ReportDefinition.ReportObjects["ItmDes1"].Width = 3536;
                            rpt.ReportDefinition.ReportObjects["Text13"].Left = 6460;
                            rpt.ReportDefinition.ReportObjects["ItmDes1"].Left = 6460;
                        }
                    }
                }
                catch
                {
                }setTotalsRpt(_InvSetting,rpt);if (_InvSetting.ISdirectPrinting || BarcodSts)
                {
                    PrintSet(rpt, (int)_InvSetting.lnPg.Value, (_InvSetting.Orientation == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, _InvSetting.defSizePaper, _InvSetting.DefLines.Value, _InvSetting.defPrn, _InvSetting.hAs.Value, _InvSetting.hYs.Value, _InvSetting.hYm.Value, _InvSetting.hAl.Value);
                }
                else
                {
                    setpagesetting(rpt);
                }
            }
            else if (repvalue == "PurchaseSuppliers")
            {
                T_Printer _InvSetting = new T_Printer();
                _InvSetting = db.StockPrinterSetting(VarGeneral.UserID, VarGeneral.InvTyp);
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    try
                    {
                        if (VarGeneral.gUserName == "runsetting")
                        {
                            if (File.Exists(Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SuppQutation.rpt"))
                            {
                                MainCryRep.FileName = Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SuppQutation.rpt";
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.Reports.SuppQutation");
                            }
                        }
                        else if (File.Exists(Application.StartupPath + "\\Reps\\SuppQutation.rpt"))
                        {
                            MainCryRep.FileName = Application.StartupPath + "\\Reps\\SuppQutation.rpt";
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.Reports.SuppQutation");
                        }
                    }
                    catch
                    {
                        MainCryRep = getdoc("InvAcc.Reports.SuppQutation");
                    }
                }
                else
                {
                    try
                    {
                        if (VarGeneral.gUserName == "runsetting")
                        {
                            if (File.Exists(Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SuppQutation.rpt"))
                            {
                                MainCryRep.FileName = Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SuppQutation.rpt";
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsE.SuppQutation");
                            }
                        }
                        else if (File.Exists(Application.StartupPath + "\\RepsE\\SuppQutation.rpt"))
                        {
                            MainCryRep.FileName = Application.StartupPath + "\\RepsE\\SuppQutation.rpt";
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsE.SuppQutation");
                        }
                    }
                    catch
                    {
                        MainCryRep = getdoc("InvAcc.ReportsE.SuppQutation");
                    }
                }
                ReportDocument rpt = MainCryRep;
                string vUsrNmA = string.Empty;
                string vBranchNmA = string.Empty;
                string vUsrNmE = string.Empty;
                string vBranchNmE = string.Empty;
                try
                {
                    vUsrNmA = VarGeneral.RepData.Tables[0].Rows[0]["UsrNamA"].ToString();
                }
                catch
                {
                    vUsrNmA = string.Empty;
                }
                try
                {
                    vUsrNmE = VarGeneral.RepData.Tables[0].Rows[0]["UsrNamE"].ToString();
                }
                catch
                {
                    vUsrNmE = string.Empty;
                }
                try
                {
                    vBranchNmA = VarGeneral.RepData.Tables[0].Rows[0]["Branch_Name"].ToString();
                }
                catch
                {
                    vBranchNmA = string.Empty;
                }
                try
                {
                    vBranchNmE = VarGeneral.RepData.Tables[0].Rows[0]["Branch_NameE"].ToString();
                }
                catch
                {
                    vBranchNmE = string.Empty;
                }
                VarGeneral.RepData.Tables[0].Rows[0].Delete();
                rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
           setTarwisaa(rpt);try
                {
         setTarwisaatax(_InvSetting,rpt);}
                catch
                {
                }
   setitemsoptionsRpt(_InvSetting,rpt);try
                {
                    rpt.SetParameterValue("IsCashCredit", VarGeneral.IsCashCredit ? "1" : "0");
                }
                catch
                {
                }
                try
                {
                    rpt.SetParameterValue("vDecimal", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? "1" : "0");
                }
                catch
                {
                }
                try
                {
                    rpt.SetParameterValue("IsTotWithTax", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 65) ? "1" : "0");
                }
                catch
                {
                }
                try
                {
                    (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                }
                catch
                {
                }
                try
                {
                    (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                }
                catch
                {
                }
                rpt.SetParameterValue("StoreSts", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16) ? "Show" : "Hide");
                if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                {
                    rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                }
                else
                {
                    rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                }
                rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                try
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        rpt.SetParameterValue("HDate", (!string.IsNullOrEmpty(_InvSetting.invGdADesc)) ? _InvSetting.invGdADesc : "شكرا\u064c لكم");
                    }
                    else
                    {
                        rpt.SetParameterValue("HDate", (!string.IsNullOrEmpty(_InvSetting.invGdEDesc)) ? _InvSetting.invGdEDesc : "Thank you");
                    }
                }
                catch
                {
                    rpt.SetParameterValue("HDate", string.Empty);
                }

                rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                rpt.SetParameterValue("vSts", false);
                rpt.SetParameterValue("vLines", 1);
                if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.LineDetailSts, vStr(VarGeneral.InvTyp)))
                {
                    rpt.SetParameterValue("LineDetailNa", VarGeneral.Settings_Sys.LineDetailNameA);
                    rpt.SetParameterValue("LineDetailNa_Eng", VarGeneral.Settings_Sys.LineDetailNameE);
                }
                else
                {
                    rpt.SetParameterValue("LineDetailNa", string.Empty);
                    rpt.SetParameterValue("LineDetailNa_Eng", string.Empty);
                }
                rpt.SetParameterValue("UserName", vUsrNmA);
                rpt.SetParameterValue("BranchName", vBranchNmA);
                rpt.SetParameterValue("UsrNamE", vUsrNmE);
                rpt.SetParameterValue("BranchNameE", vBranchNmE);
                try
                {
                    if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 20))
                    {
                        rpt.ReportDefinition.ReportObjects["Line2"].ObjectFormat.EnableSuppress = true;
                         rpt.ReportDefinition.ReportObjects["Text27"].ObjectFormat.EnableSuppress = true;
try{
rpt.ReportDefinition.ReportObjects["Text39"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line26"].ObjectFormat.EnableSuppress = true;

}catch
{
}
                        rpt.ReportDefinition.ReportObjects["SerialKey1"].ObjectFormat.EnableSuppress = true;
                        try
                        {
                            rpt.ReportDefinition.Sections[3].ReportObjects["Line2t"].ObjectFormat.EnableSuppress = true;
                        }
                        catch
                        {
                        }
                        if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16))
                        {
                            rpt.ReportDefinition.ReportObjects["Text13"].Width = 2924;
                            rpt.ReportDefinition.ReportObjects["ItmDes1"].Width = 2924;
                            rpt.ReportDefinition.ReportObjects["Text13"].Left = 7106;
                            rpt.ReportDefinition.ReportObjects["ItmDes1"].Left = 7106;
                        }
                        else
                        {
                            rpt.ReportDefinition.ReportObjects["Text13"].Width = 3536;
                            rpt.ReportDefinition.ReportObjects["ItmDes1"].Width = 3536;
                            rpt.ReportDefinition.ReportObjects["Text13"].Left = 6460;
                            rpt.ReportDefinition.ReportObjects["ItmDes1"].Left = 6460;
                        }
                    }
                }
                catch
                {
                }setTotalsRpt(_InvSetting,rpt);if (_InvSetting.ISdirectPrinting)
                {
                    PrintSet(rpt, (int)_InvSetting.lnPg.Value, (_InvSetting.Orientation == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, _InvSetting.defSizePaper, _InvSetting.DefLines.Value, _InvSetting.defPrn, _InvSetting.hAs.Value, _InvSetting.hYs.Value, _InvSetting.hYm.Value, _InvSetting.hAl.Value);
                }
                else
                {
                    setpagesetting(rpt);
                }
            }
        }

        void room14()
        {
            if (VarGeneral.vDemo)
            {
                crystalReportViewe_RepShow.ShowPrintButton = false;
                crystalReportViewe_RepShow.ShowExportButton = false;
            }
            MainCryRep = new ReportDocument();
#pragma warning disable CS0168 // The variable 'num' is declared but never used
            int num;
#pragma warning restore CS0168 // The variable 'num' is declared but never used
#pragma warning disable CS0168 // The variable 'num2' is declared but never used
            int num2;
#pragma warning restore CS0168 // The variable 'num2' is declared but never used
            if (repvalue == "CustAge15")
            {
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.Reports.RepClintAge15");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheir.RepClintAge15");
                    }
                }
                else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                {
                    MainCryRep = getdoc("InvAcc.ReportsE.RepClintAge15");
                }
                else
                {
                    MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepClintAge15");
                }
                ReportDocument rpt = MainCryRep;
                rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
           setTarwisaa(rpt);try
                {
                    (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                }
                catch
                {
                }
                try
                {
                    (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                }
                catch
                {
                }
                if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                {
                    rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                }
                else
                {
                    rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                }
                rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                rpt.SetParameterValue("vSts", false);
                rpt.SetParameterValue("vLines", 1);
                if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                {
                    PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                }
                else
                {
                    setpagesetting(rpt);
                }
            }
        }

        void room13()
        {
            if (VarGeneral.vDemo)
            {
                crystalReportViewe_RepShow.ShowPrintButton = false;
                crystalReportViewe_RepShow.ShowExportButton = false;
            }
            MainCryRep = new ReportDocument();
#pragma warning disable CS0168 // The variable 'num' is declared but never used
            int num;
#pragma warning restore CS0168 // The variable 'num' is declared but never used
#pragma warning disable CS0168 // The variable 'num2' is declared but never used
            int num2;
#pragma warning restore CS0168 // The variable 'num2' is declared but never used
            if (repvalue == "CustAge")
            {
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.Reports.RepClintAge");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheir.RepClintAge");
                    }
                }
                else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                {
                    MainCryRep = getdoc("InvAcc.ReportsE.RepClintAge");
                }
                else
                {
                    MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepClintAge");
                }
                ReportDocument rpt = MainCryRep;
                rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
           setTarwisaa(rpt);try
                {
                    (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                }
                catch
                {
                }
                try
                {
                    (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                }
                catch
                {
                }
                if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                {
                    rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                }
                else
                {
                    rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                }
                rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                rpt.SetParameterValue("vSts", false);
                rpt.SetParameterValue("vLines", 1);
                if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                {
                    PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                }
                else
                {
                    setpagesetting(rpt);
                }
            }
        }

        void room12()
        {
            if (VarGeneral.vDemo)
            {
                crystalReportViewe_RepShow.ShowPrintButton = false;
                crystalReportViewe_RepShow.ShowExportButton = false;
            }
            MainCryRep = new ReportDocument();
#pragma warning disable CS0168 // The variable 'num' is declared but never used
            int num;
#pragma warning restore CS0168 // The variable 'num' is declared but never used
#pragma warning disable CS0168 // The variable 'num2' is declared but never used
            int num2;
#pragma warning restore CS0168 // The variable 'num2' is declared but never used
            if (repvalue == "Cust_Supp")
            {
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.Reports.RepTradingAccount");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheir.RepTradingAccount");
                    }
                }
                else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                {
                    MainCryRep = getdoc("InvAcc.ReportsE.RepTradingAccount");
                }
                else
                {
                    MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepTradingAccount");
                }
                ReportDocument rpt = MainCryRep;
                rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
           setTarwisaa(rpt);try
                {
                    (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                }
                catch
                {
                }
                try
                {
                    (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                }
                catch
                {
                }
                if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                {
                    rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                }
                else
                {
                    rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                }
                try
                {
                    rpt.SetParameterValue("DTFrom", VarGeneral._DTFrom);
                }
                catch
                {
                }
                try
                {
                    rpt.SetParameterValue("DTTo", VarGeneral._DTTo);
                }
                catch
                {
                }
                rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                rpt.SetParameterValue("vSts", false);
                rpt.SetParameterValue("vLines", 1);
                if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                {
                    PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                }
                else
                {
                    setpagesetting(rpt);
                }
            }
        }

        void room11()
        {
            if (VarGeneral.vDemo)
            {
                crystalReportViewe_RepShow.ShowPrintButton = false;
                crystalReportViewe_RepShow.ShowExportButton = false;
            }
            MainCryRep = new ReportDocument();
#pragma warning disable CS0168 // The variable 'num' is declared but never used
            int num;
#pragma warning restore CS0168 // The variable 'num' is declared but never used
#pragma warning disable CS0168 // The variable 'num2' is declared but never used
            int num2;
#pragma warning restore CS0168 // The variable 'num2' is declared but never used
            if (repvalue == "RepGuestAcc")
            {
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.ReportHotel.Rep13");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportHotelCashier.Rep13");
                    }
                }
                else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                {
                    MainCryRep = getdoc("InvAcc.ReportHotelE.Rep13");
                }
                else
                {
                    MainCryRep = getdoc("InvAcc.ReportHotelCashierE.Rep13");
                }
                ReportDocument rpt = MainCryRep;
                rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
           setTarwisaa(rpt);if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                {
                    rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                }
                else
                {
                    rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                }
                rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                rpt.SetParameterValue("vSts", false);
                rpt.SetParameterValue("vLines", 1);
                if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                {
                    PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                }
                else
                {
                    setpagesetting(rpt);
                }
            }
        }

        void room10()
        {
            if (VarGeneral.vDemo)
            {
                crystalReportViewe_RepShow.ShowPrintButton = false;
                crystalReportViewe_RepShow.ShowExportButton = false;
            }
            MainCryRep = new ReportDocument();
#pragma warning disable CS0168 // The variable 'num' is declared but never used
            int num;
#pragma warning restore CS0168 // The variable 'num' is declared but never used
#pragma warning disable CS0168 // The variable 'num2' is declared but never used
            int num2;
#pragma warning restore CS0168 // The variable 'num2' is declared but never used
            if (repvalue == "RepGuestCalls")
            {
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.ReportHotel.Rep20");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportHotelCashier.Rep20");
                    }
                }
                else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                {
                    MainCryRep = getdoc("InvAcc.ReportHotelE.Rep20");
                }
                else
                {
                    MainCryRep = getdoc("InvAcc.ReportHotelCashierE.Rep20");
                }
                ReportDocument rpt = MainCryRep;
                rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
           setTarwisaa(rpt);if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                {
                    rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                }
                else
                {
                    rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                }
                rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                rpt.SetParameterValue("vSts", false);
                rpt.SetParameterValue("vLines", 1);
                if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                {
                    PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                }
                else
                {
                    setpagesetting(rpt);
                }
            }
        }

        void room9()
        {
            if (VarGeneral.vDemo)
            {
                crystalReportViewe_RepShow.ShowPrintButton = false;
                crystalReportViewe_RepShow.ShowExportButton = false;
            }
            MainCryRep = new ReportDocument();
#pragma warning disable CS0168 // The variable 'num' is declared but never used
            int num;
#pragma warning restore CS0168 // The variable 'num' is declared but never used
#pragma warning disable CS0168 // The variable 'num2' is declared but never used
            int num2;
#pragma warning restore CS0168 // The variable 'num2' is declared but never used
            if (repvalue == "RepGuestOrders")
            {
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.ReportHotel.Rep15");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportHotelCashier.Rep15");
                    }
                }
                else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                {
                    MainCryRep = getdoc("InvAcc.ReportHotelE.Rep15");
                }
                else
                {
                    MainCryRep = getdoc("InvAcc.ReportHotelCashierE.Rep15");
                }
                ReportDocument rpt = MainCryRep;
                rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
           setTarwisaa(rpt);if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                {
                    rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                }
                else
                {
                    rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                }
                rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                rpt.SetParameterValue("vSts", false);
                rpt.SetParameterValue("vLines", 1);
                if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                {
                    PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                }
                else
                {
                    setpagesetting(rpt);
                }
            }
        }

        void room8()
        {
            if (VarGeneral.vDemo)
            {
                crystalReportViewe_RepShow.ShowPrintButton = false;
                crystalReportViewe_RepShow.ShowExportButton = false;
            }
            MainCryRep = new ReportDocument();
#pragma warning disable CS0168 // The variable 'num' is declared but never used
            int num;
#pragma warning restore CS0168 // The variable 'num' is declared but never used
#pragma warning disable CS0168 // The variable 'num2' is declared but never used
            int num2;
#pragma warning restore CS0168 // The variable 'num2' is declared but never used
            if (repvalue == "RepPers_8" || repvalue == "RepPers_11" || repvalue == "RepPers_12")
            {
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.ReportHotel.Rep10");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportHotelCashier.Rep10");
                    }
                }
                else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                {
                    MainCryRep = getdoc("InvAcc.ReportHotelE.Rep10");
                }
                else
                {
                    MainCryRep = getdoc("InvAcc.ReportHotelCashierE.Rep10");
                }
                ReportDocument rpt = MainCryRep;
                rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
           setTarwisaa(rpt);rpt.SetParameterValue("RepTyp", (repvalue == "RepPers_8" || repvalue == "RepPers_12") ? "تاريخ السكن" : "تاريخ المغادرة");
                if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                {
                    rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                }
                else
                {
                    rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                }
                rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                rpt.SetParameterValue("vSts", false);
                rpt.SetParameterValue("vLines", 1);
                if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                {
                    PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                }
                else
                {
                    setpagesetting(rpt);
                }
            }
        }

        void room7()
        {
            if (VarGeneral.vDemo)
            {
                crystalReportViewe_RepShow.ShowPrintButton = false;
                crystalReportViewe_RepShow.ShowExportButton = false;
            }
            MainCryRep = new ReportDocument();
#pragma warning disable CS0168 // The variable 'num' is declared but never used
            int num;
#pragma warning restore CS0168 // The variable 'num' is declared but never used
#pragma warning disable CS0168 // The variable 'num2' is declared but never used
            int num2;
#pragma warning restore CS0168 // The variable 'num2' is declared but never used
            if (repvalue == "RepReserv")
            {
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.ReportHotel.Rep9");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportHotelCashier.Rep9");
                    }
                }
                else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                {
                    MainCryRep = getdoc("InvAcc.ReportHotelE.Rep9");
                }
                else
                {
                    MainCryRep = getdoc("InvAcc.ReportHotelCashierE.Rep9");
                }
                ReportDocument rpt = MainCryRep;
                rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
           setTarwisaa(rpt);if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                {
                    rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                }
                else
                {
                    rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                }
                rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                rpt.SetParameterValue("vSts", false);
                rpt.SetParameterValue("vLines", 1);
                if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                {
                    PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                }
                else
                {
                    setpagesetting(rpt);
                }
            }
        }

        void room6()
        {
            if (VarGeneral.vDemo)
            {
                crystalReportViewe_RepShow.ShowPrintButton = false;
                crystalReportViewe_RepShow.ShowExportButton = false;
            }
            MainCryRep = new ReportDocument();
#pragma warning disable CS0168 // The variable 'num' is declared but never used
            int num;
#pragma warning restore CS0168 // The variable 'num' is declared but never used
#pragma warning disable CS0168 // The variable 'num2' is declared but never used
            int num2;
#pragma warning restore CS0168 // The variable 'num2' is declared but never used
            if (repvalue == "RepGuestDataPer_1")
            {
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.ReportHotel.GuestData");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportHotelCashier.GuestData");
                    }
                }
                else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                {
                    MainCryRep = getdoc("InvAcc.ReportHotelE.GuestData");
                }
                else
                {
                    MainCryRep = getdoc("InvAcc.ReportHotelCashierE.GuestData");
                }
                ReportDocument rpt = MainCryRep;
                rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
           setTarwisaa(rpt);if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                {
                    rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                }
                else
                {
                    rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                }
                rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                rpt.SetParameterValue("vSts", false);
                rpt.SetParameterValue("vLines", 1);
                if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                {
                    PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                }
                else
                {
                    setpagesetting(rpt);
                }
            }
        }

        void room5()
        {
            if (VarGeneral.vDemo)
            {
                crystalReportViewe_RepShow.ShowPrintButton = false;
                crystalReportViewe_RepShow.ShowExportButton = false;
            }
            MainCryRep = new ReportDocument();
#pragma warning disable CS0168 // The variable 'num' is declared but never used
            int num;
#pragma warning restore CS0168 // The variable 'num' is declared but never used
#pragma warning disable CS0168 // The variable 'num2' is declared but never used
            int num2;
#pragma warning restore CS0168 // The variable 'num2' is declared but never used
            if (repvalue == "RepGuestData")
            {
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.ReportHotel.Rep3");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportHotelCashier.Rep3");
                    }
                }
                else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                {
                    MainCryRep = getdoc("InvAcc.ReportHotelE.Rep3");
                }
                else
                {
                    MainCryRep = getdoc("InvAcc.ReportHotelCashierE.Rep3");
                }
                ReportDocument rpt = MainCryRep;
                rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
           setTarwisaa(rpt);if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                {
                    rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                }
                else
                {
                    rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                }
                rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                rpt.SetParameterValue("vSts", false);
                rpt.SetParameterValue("vLines", 1);
                if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                {
                    PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                }
                else
                {
                    setpagesetting(rpt);
                }
            }
        }

        void room4()
        {
            if (VarGeneral.vDemo)
            {
                crystalReportViewe_RepShow.ShowPrintButton = false;
                crystalReportViewe_RepShow.ShowExportButton = false;
            }
            MainCryRep = new ReportDocument();
#pragma warning disable CS0168 // The variable 'num' is declared but never used
            int num;
#pragma warning restore CS0168 // The variable 'num' is declared but never used
#pragma warning disable CS0168 // The variable 'num2' is declared but never used
            int num2;
#pragma warning restore CS0168 // The variable 'num2' is declared but never used
            if (repvalue == "RepRoomGroup")
            {
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.ReportHotel.Rep24");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportHotelCashier.Rep24");
                    }
                }
                else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                {
                    MainCryRep = getdoc("InvAcc.ReportHotelE.Rep24");
                }
                else
                {
                    MainCryRep = getdoc("InvAcc.ReportHotelCashierE.Rep24");
                }
                ReportDocument rpt = MainCryRep;
                rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
           setTarwisaa(rpt);if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                {
                    rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                }
                else
                {
                    rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                }
                rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                rpt.SetParameterValue("vSts", false);
                rpt.SetParameterValue("vLines", 1);
                if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                {
                    PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                }
                else
                {
                    setpagesetting(rpt);
                }
            }
        }

        void room3()
        {
            if (VarGeneral.vDemo)
            {
                crystalReportViewe_RepShow.ShowPrintButton = false;
                crystalReportViewe_RepShow.ShowExportButton = false;
            }
            MainCryRep = new ReportDocument();
#pragma warning disable CS0168 // The variable 'num' is declared but never used
            int num;
#pragma warning restore CS0168 // The variable 'num' is declared but never used
#pragma warning disable CS0168 // The variable 'num2' is declared but never used
            int num2;
#pragma warning restore CS0168 // The variable 'num2' is declared but never used
            if (repvalue == "RepRoomReapir")
            {
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.ReportHotel.Rep8");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportHotelCashier.Rep8");
                    }
                }
                else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                {
                    MainCryRep = getdoc("InvAcc.ReportHotelE.Rep8");
                }
                else
                {
                    MainCryRep = getdoc("InvAcc.ReportHotelCashierE.Rep8");
                }
                ReportDocument rpt = MainCryRep;
                rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
           setTarwisaa(rpt);if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                {
                    rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                }
                else
                {
                    rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                }
                rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                rpt.SetParameterValue("vSts", false);
                rpt.SetParameterValue("vLines", 1);
                if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                {
                    PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                }
                else
                {
                    setpagesetting(rpt);
                }
            }
        }

        void room2()
        {
            if (VarGeneral.vDemo)
            {
                crystalReportViewe_RepShow.ShowPrintButton = false;
                crystalReportViewe_RepShow.ShowExportButton = false;
            }
            MainCryRep = new ReportDocument();
#pragma warning disable CS0168 // The variable 'num' is declared but never used
            int num;
#pragma warning restore CS0168 // The variable 'num' is declared but never used
#pragma warning disable CS0168 // The variable 'num2' is declared but never used
            int num2;
#pragma warning restore CS0168 // The variable 'num2' is declared but never used
            if (repvalue == "RepRoomMovement")
            {
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.ReportHotel.Rep21");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportHotelCashier.Rep21");
                    }
                }
                else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                {
                    MainCryRep = getdoc("InvAcc.ReportHotelE.Rep21");
                }
                else
                {
                    MainCryRep = getdoc("InvAcc.ReportHotelCashierE.Rep21");
                }
                ReportDocument rpt = MainCryRep;
                rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
           setTarwisaa(rpt);if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                {
                    rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                }
                else
                {
                    rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                }
                rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                rpt.SetParameterValue("vSts", false);
                rpt.SetParameterValue("vLines", 1);
                if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                {
                    PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                }
                else
                {
                    setpagesetting(rpt);
                }
            }
        }
        public static bool IsSettingOnly;
        internal bool iscar = false;
        internal bool iscarorder = false;

        void roomrep()
        {
            if (VarGeneral.vDemo)
            {
                crystalReportViewe_RepShow.ShowPrintButton = false;
                crystalReportViewe_RepShow.ShowExportButton = false;
            }
            MainCryRep = new ReportDocument();
#pragma warning disable CS0168 // The variable 'num' is declared but never used
            int num;
#pragma warning restore CS0168 // The variable 'num' is declared but never used
#pragma warning disable CS0168 // The variable 'num2' is declared but never used
            int num2;
#pragma warning restore CS0168 // The variable 'num2' is declared but never used
            if (repvalue == "RepRoomDesc")
            {
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.ReportHotel.Rep6");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportHotelCashier.Rep6");
                    }
                }
                else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                {
                    MainCryRep = getdoc("InvAcc.ReportHotelE.Rep6");
                }
                else
                {
                    MainCryRep = getdoc("InvAcc.ReportHotelCashierE.Rep6");
                }
                ReportDocument rpt = MainCryRep;
                rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
           setTarwisaa(rpt);if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                {
                    rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                }
                else
                {
                    rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                }
                rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                rpt.SetParameterValue("vSts", false);
                rpt.SetParameterValue("vLines", 1);
                if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                {
                    PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                }
                else
                {
                    setpagesetting(rpt);
                }
            }
        }

        void rep1rep2()
        {
            if (VarGeneral.vDemo)
            {
                crystalReportViewe_RepShow.ShowPrintButton = false;
                crystalReportViewe_RepShow.ShowExportButton = false;
            }
            MainCryRep = new ReportDocument();
#pragma warning disable CS0168 // The variable 'num' is declared but never used
            int num;
#pragma warning restore CS0168 // The variable 'num' is declared but never used
#pragma warning disable CS0168 // The variable 'num2' is declared but never used
            int num2;
#pragma warning restore CS0168 // The variable 'num2' is declared but never used
            if (repvalue == "RepRevenue_1" || repvalue == "RepRevenue_0")
            {
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.ReportHotel.Rep1");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportHotelCashier.Rep1");
                    }
                }
                else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                {
                    MainCryRep = getdoc("InvAcc.ReportHotelE.Rep1");
                }
                else
                {
                    MainCryRep = getdoc("InvAcc.ReportHotelCashierE.Rep1");
                }
                ReportDocument rpt = MainCryRep;
                rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
           setTarwisaa(rpt);rpt.SetParameterValue("vRepTp", "0");
                if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                {
                    rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                }
                else
                {
                    rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                }
                rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                rpt.SetParameterValue("vSts", false);
                rpt.SetParameterValue("vLines", 1);
                if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                {
                    PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                }
                else
                {
                    setpagesetting(rpt);
                }
            }
        }

        void account2()
        {
            if (VarGeneral.vDemo)
            {
                crystalReportViewe_RepShow.ShowPrintButton = false;
                crystalReportViewe_RepShow.ShowExportButton = false;
            }
            MainCryRep = new ReportDocument();
#pragma warning disable CS0168 // The variable 'num' is declared but never used
            int num;
#pragma warning restore CS0168 // The variable 'num' is declared but never used
#pragma warning disable CS0168 // The variable 'num2' is declared but never used
            int num2;
#pragma warning restore CS0168 // The variable 'num2' is declared but never used
            if (repvalue == "AccountTrancByAccNo")
            {
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    if (VarGeneral.itmDesIndex == 0)
                    {
                        if (VarGeneral.GeneralPrinter.ISA4PaperType)
                        {
                            MainCryRep = getdoc("InvAcc.Reports.RepGeneralLedgerByAccNo");
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsCasheir.RepGeneralLedgerByAccNo");
                        }
                    }
                    else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.Reports.RepGeneralLedgerShort");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheir.RepGeneralLedgerShort");
                    }
                }
                else if (VarGeneral.itmDesIndex == 0)
                {
                    if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.ReportsE.RepGeneralLedgerByAccNo");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepGeneralLedgerByAccNo");
                    }
                }
                else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                {
                    MainCryRep = getdoc("InvAcc.ReportsE.RepGeneralLedgerShort");
                }
                else
                {
                    MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepGeneralLedgerShort");
                }
                ReportDocument rpt = MainCryRep;
                rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                try
                {
                    (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                }
                catch
                {
                }
                try
                {
                    (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                }
                catch
                {
                }
                if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                {
                    rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                }
                else
                {
                    rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                }
                rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                rpt.SetParameterValue("vSts", false);
                rpt.SetParameterValue("vLines", 1);
                if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                {
                    PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                }
                else
                {
                    setpagesetting(rpt);
                }
            }
        }

        void accountttt()
        {
            if (VarGeneral.vDemo)
            {
                crystalReportViewe_RepShow.ShowPrintButton = false;
                crystalReportViewe_RepShow.ShowExportButton = false;
            }
            MainCryRep = new ReportDocument();
#pragma warning disable CS0168 // The variable 'num' is declared but never used
            int num;
#pragma warning restore CS0168 // The variable 'num' is declared but never used
#pragma warning disable CS0168 // The variable 'num2' is declared but never used
            int num2;
#pragma warning restore CS0168 // The variable 'num2' is declared but never used
            if (repvalue == "AccountTranc")
            {
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    if (VarGeneral.itmDesIndex == 0)
                    {
                        if (VarGeneral.GeneralPrinter.ISA4PaperType)
                        {
                            MainCryRep = getdoc("InvAcc.Reports.RepGeneralLedger");
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsCasheir.RepGeneralLedger");
                        }
                    }
                    else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.Reports.RepGeneralLedgerShort");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheir.RepGeneralLedgerShort");
                    }
                }
                else if (VarGeneral.itmDesIndex == 0)
                {
                    if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.ReportsE.RepGeneralLedger");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepGeneralLedger");
                    }
                }
                else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                {
                    MainCryRep = getdoc("InvAcc.ReportsE.RepGeneralLedgerShort");
                }
                else
                {
                    MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepGeneralLedgerShort");
                }
                ReportDocument rpt = MainCryRep;
                rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
           setTarwisaa(rpt);try
                {
                    (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                }
                catch
                {
                }
                try
                {
                    (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                }
                catch
                {
                }
                if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                {
                    rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                }
                else
                {
                    rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                }
                rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                rpt.SetParameterValue("vSts", false);
                rpt.SetParameterValue("vLines", 1);
                if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                {
                    PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                }
                else
                {
                    setpagesetting(rpt);
                }
            }
        }

        void accounttrans()
        {
            if (VarGeneral.vDemo)
            {
                crystalReportViewe_RepShow.ShowPrintButton = false;
                crystalReportViewe_RepShow.ShowExportButton = false;
            }
            MainCryRep = new ReportDocument();
#pragma warning disable CS0168 // The variable 'num' is declared but never used
            int num;
#pragma warning restore CS0168 // The variable 'num' is declared but never used
#pragma warning disable CS0168 // The variable 'num2' is declared but never used
            int num2;
#pragma warning restore CS0168 // The variable 'num2' is declared but never used
            if (repvalue == "AccountTrans")
            {
                if (VarGeneral.InvType == 1)
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        if (VarGeneral.GeneralPrinter.ISA4PaperType)
                        {
                            MainCryRep = getdoc("InvAcc.Reports.RepAllAcc");
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsCasheir.RepAllAcc");
                        }
                    }
                    else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.ReportsE.RepAllAcc");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepAllAcc");
                    }
                    ReportDocument rpt = MainCryRep;
                    rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
               setTarwisaa(rpt);try
                    {
                        (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                    }
                    catch
                    {
                    }
                    try
                    {
                        (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                    }
                    catch
                    {
                    }
                    if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                    {
                        rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                    }
                    else
                    {
                        rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                    }
                    try
                    {
                        rpt.SetParameterValue("DTFrom", VarGeneral._DTFrom);
                    }
                    catch
                    {
                    }
                    try
                    {
                        rpt.SetParameterValue("DTTo", VarGeneral._DTTo);
                    }
                    catch
                    {
                    }
                    rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                    rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                    rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                    rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                    rpt.SetParameterValue("vSts", false);
                    rpt.SetParameterValue("vLines", 1);
                    if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                    {
                        PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                    }
                    else
                    {
                        setpagesetting(rpt);
                    }
                }
                else if (VarGeneral.InvType == 2)
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        if (VarGeneral.GeneralPrinter.ISA4PaperType)
                        {
                            MainCryRep = getdoc("InvAcc.Reports.RepTrialbalanceofbalances");
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsCasheir.RepTrialbalanceofbalances");
                        }
                    }
                    else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.ReportsE.RepTrialbalanceofbalances");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepTrialbalanceofbalances");
                    }
                    ReportDocument rpt = MainCryRep;
                    rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
               setTarwisaa(rpt);try
                    {
                        (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                    }
                    catch
                    {
                    }
                    try
                    {
                        (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                    }
                    catch
                    {
                    }
                    if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                    {
                        rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                    }
                    else
                    {
                        rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                    }
                    try
                    {
                        rpt.SetParameterValue("DTFrom", VarGeneral._DTFrom);
                    }
                    catch
                    {
                    }
                    try
                    {
                        rpt.SetParameterValue("DTTo", VarGeneral._DTTo);
                    }
                    catch
                    {
                    }
                    rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                    rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                    rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                    rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                    rpt.SetParameterValue("vSts", false);
                    rpt.SetParameterValue("vLines", 1);
                    if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                    {
                        PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                    }
                    else
                    {
                        setpagesetting(rpt);
                    }
                }
                else if (VarGeneral.InvType == 3)
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        if (VarGeneral.GeneralPrinter.ISA4PaperType)
                        {
                            MainCryRep = getdoc("InvAcc.Reports.RepTotalsTrialBalance");
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsCasheir.RepTotalsTrialBalance");
                        }
                    }
                    else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.ReportsE.RepTotalsTrialBalance");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepTotalsTrialBalance");
                    }
                    ReportDocument rpt = MainCryRep;
                    rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
               setTarwisaa(rpt);try
                    {
                        (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                    }
                    catch
                    {
                    }
                    try
                    {
                        (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                    }
                    catch
                    {
                    }
                    if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                    {
                        rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                    }
                    else
                    {
                        rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                    }
                    try
                    {
                        rpt.SetParameterValue("DTFrom", VarGeneral._DTFrom);
                    }
                    catch
                    {
                    }
                    try
                    {
                        rpt.SetParameterValue("DTTo", VarGeneral._DTTo);
                    }
                    catch
                    {
                    }
                    rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                    rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                    rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                    rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                    rpt.SetParameterValue("vSts", false);
                    rpt.SetParameterValue("vLines", 1);
                    if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                    {
                        PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                    }
                    else
                    {
                        setpagesetting(rpt);
                    }
                }
                else if (VarGeneral.InvType == 4)
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        if (VarGeneral.GeneralPrinter.ISA4PaperType)
                        {
                            if (VarGeneral.itmDesIndex == 1)
                            {
                                MainCryRep = getdoc("InvAcc.Reports.RepBalanceandTotallyTrialBalanceWithOpenVal");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.Reports.RepBalanceandTotallyTrialBalance");
                            }
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsCasheir.RepBalanceandTotallyTrialBalance");
                        }
                    }
                    else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        if (VarGeneral.itmDesIndex == 1)
                        {
                            MainCryRep = getdoc("InvAcc.ReportsE.RepBalanceandTotallyTrialBalanceWithOpenVal");
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsE.RepBalanceandTotallyTrialBalance");
                        }
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepBalanceandTotallyTrialBalance");
                    }
                    ReportDocument rpt = MainCryRep;
                    rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
               setTarwisaa(rpt);try
                    {
                        (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                    }
                    catch
                    {
                    }
                    try
                    {
                        (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                    }
                    catch
                    {
                    }
                    if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                    {
                        rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                    }
                    else
                    {
                        rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                    }
                    try
                    {
                        rpt.SetParameterValue("DTFrom", VarGeneral._DTFrom);
                    }
                    catch
                    {
                    }
                    try
                    {
                        rpt.SetParameterValue("DTTo", VarGeneral._DTTo);
                    }
                    catch
                    {
                    }
                    rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                    rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                    rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                    rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                    rpt.SetParameterValue("vSts", false);
                    rpt.SetParameterValue("vLines", 1);
                    if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                    {
                        PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                    }
                    else
                    {
                        setpagesetting(rpt);
                    }
                }
                else if (VarGeneral.InvType == 5 || VarGeneral.InvType == 6)
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        if (VarGeneral.GeneralPrinter.ISA4PaperType)
                        {
                            MainCryRep = getdoc("InvAcc.Reports.RepTradingAccount");
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsCasheir.RepTradingAccount");
                        }
                    }
                    else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.ReportsE.RepTradingAccount");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepTradingAccount");
                    }
                    ReportDocument rpt = MainCryRep;
                    rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
               setTarwisaa(rpt);try
                    {
                        (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                    }
                    catch
                    {
                    }
                    try
                    {
                        (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                    }
                    catch
                    {
                    }
                    if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                    {
                        rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                    }
                    else
                    {
                        rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                    }
                    try
                    {
                        rpt.SetParameterValue("DTFrom", VarGeneral._DTFrom);
                    }
                    catch
                    {
                    }
                    try
                    {
                        rpt.SetParameterValue("DTTo", VarGeneral._DTTo);
                    }
                    catch
                    {
                    }
                    rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                    rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                    rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                    rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                    rpt.SetParameterValue("vSts", false);
                    rpt.SetParameterValue("vLines", 1);
                    if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                    {
                        PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                    }
                    else
                    {
                        setpagesetting(rpt);
                    }
                }
                else if (VarGeneral.InvType == 7)
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        if (VarGeneral.GeneralPrinter.ISA4PaperType)
                        {
                            MainCryRep = getdoc("InvAcc.Reports.RepGeneralBudget");
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsCasheir.RepGeneralBudget");
                        }
                    }
                    else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.ReportsE.RepGeneralBudget");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepGeneralBudget");
                    }
                    ReportDocument rpt = MainCryRep;
                    rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
               setTarwisaa(rpt);try
                    {
                        (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                    }
                    catch
                    {
                    }
                    try
                    {
                        (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                    }
                    catch
                    {
                    }
                    if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                    {
                        rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                    }
                    else
                    {
                        rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                    }
                    try
                    {
                        rpt.SetParameterValue("DTFrom", VarGeneral._DTFrom);
                    }
                    catch
                    {
                    }
                    try
                    {
                        rpt.SetParameterValue("DTTo", VarGeneral._DTTo);
                    }
                    catch
                    {
                    }
                    rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                    rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                    rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                    rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                    rpt.SetParameterValue("vSts", false);
                    rpt.SetParameterValue("vLines", 1);
                    if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                    {
                        PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                    }
                    else
                    {
                        setpagesetting(rpt);
                    }
                }
            }
        }

        void account1
        ()
        {
            if (VarGeneral.vDemo)
            {
                crystalReportViewe_RepShow.ShowPrintButton = false;
                crystalReportViewe_RepShow.ShowExportButton = false;
            }
            MainCryRep = new ReportDocument();
#pragma warning disable CS0168 // The variable 'num' is declared but never used
            int num;
#pragma warning restore CS0168 // The variable 'num' is declared but never used
#pragma warning disable CS0168 // The variable 'num2' is declared but never used
            int num2;
#pragma warning restore CS0168 // The variable 'num2' is declared but never used
            if (repvalue == "AccountSerfGabth")
            {
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.Reports.RepAccountSerfGabth");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheir.RepAccountSerfGabth");
                    }
                }
                else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                {
                    MainCryRep = getdoc("InvAcc.ReportsE.RepAccountSerfGabth");
                }
                else
                {
                    MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepAccountSerfGabth");
                }
                ReportDocument rpt = MainCryRep;
                rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
           setTarwisaa(rpt);try
                {
                    (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                }
                catch
                {
                }
                try
                {
                    (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                }
                catch
                {
                }
                if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                {
                    rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                }
                else
                {
                    rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                }
                rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                rpt.SetParameterValue("vSts", false);
                rpt.SetParameterValue("vLines", 1);
                if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                {
                    PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                }
                else
                {
                    setpagesetting(rpt);
                }
            }
        }

        void accountx()
        {
            if (VarGeneral.vDemo)
            {
                crystalReportViewe_RepShow.ShowPrintButton = false;
                crystalReportViewe_RepShow.ShowExportButton = false;
            }
            MainCryRep = new ReportDocument();
#pragma warning disable CS0168 // The variable 'num' is declared but never used
            int num;
#pragma warning restore CS0168 // The variable 'num' is declared but never used
#pragma warning disable CS0168 // The variable 'num2' is declared but never used
            int num2;
#pragma warning restore CS0168 // The variable 'num2' is declared but never used
            if (repvalue == "AccountTax")
            {
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.Reports.RepAccountTax");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheir.RepAccountTax");
                    }
                }
                else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                {
                    MainCryRep = getdoc("InvAcc.ReportsE.RepAccountTax");
                }
                else
                {
                    MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepAccountTax");
                }
                ReportDocument rpt = MainCryRep;
                rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
           setTarwisaa(rpt);try
                {
                    (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                }
                catch
                {
                }
                try
                {
                    (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                }
                catch
                {
                }
                if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                {
                    rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                }
                else
                {
                    rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                }
                rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                rpt.SetParameterValue("vSts", false);
                rpt.SetParameterValue("vLines", 1);
                if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                {
                    PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                }
                else
                {
                    setpagesetting(rpt);
                }
            }
        }

        void account()
        {
            if (VarGeneral.vDemo)
            {
                crystalReportViewe_RepShow.ShowPrintButton = false;
                crystalReportViewe_RepShow.ShowExportButton = false;
            }
            MainCryRep = new ReportDocument();
#pragma warning disable CS0168 // The variable 'num' is declared but never used
            int num;
#pragma warning restore CS0168 // The variable 'num' is declared but never used
#pragma warning disable CS0168 // The variable 'num2' is declared but never used
            int num2;
#pragma warning restore CS0168 // The variable 'num2' is declared but never used
            if (repvalue == "Account")
            {
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        if (VarGeneral.itmDesIndex == 0)
                        {
                            MainCryRep = getdoc("InvAcc.Reports.RepAccount");
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.Reports.RepAccountShort");
                        }
                    }
                    else if (VarGeneral.itmDesIndex == 0)
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheir.RepAccount");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheir.RepAccountShort");
                    }
                }
                else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                {
                    if (VarGeneral.itmDesIndex == 0)
                    {
                        MainCryRep = getdoc("InvAcc.ReportsE.RepAccount");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsE.RepAccountShort");
                    }
                }
                else if (VarGeneral.itmDesIndex == 0)
                {
                    MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepAccount");
                }
                else
                {
                    MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepAccountShort");
                }
                ReportDocument rpt = MainCryRep;
                rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
           setTarwisaa(rpt);try
                {
                    (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                }
                catch
                {
                }
                try
                {
                    (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                }
                catch
                {
                }
                if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                {
                    rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                }
                else
                {
                    rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                }
                rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                try
                {
                    rpt.SetParameterValue("DTFrom", VarGeneral._DTFrom);
                }
                catch
                {
                }
                try
                {
                    rpt.SetParameterValue("DTTo", VarGeneral._DTTo);
                }
                catch
                {
                }
                rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                rpt.SetParameterValue("vSts", false);
                rpt.SetParameterValue("vLines", 1);
                try
                {
                    rpt.SetParameterValue("OldBalance", VarGeneral.itmDes);
                }
                catch
                {
                }
                if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                {
                    PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                }
                else
                {
                    setpagesetting(rpt);
                }
            }
        }

        void itemmovprint()
        {
            if (VarGeneral.vDemo)
            {
                crystalReportViewe_RepShow.ShowPrintButton = false;
                crystalReportViewe_RepShow.ShowExportButton = false;
            }
            MainCryRep = new ReportDocument();
#pragma warning disable CS0168 // The variable 'num' is declared but never used
            int num;
#pragma warning restore CS0168 // The variable 'num' is declared but never used
#pragma warning disable CS0168 // The variable 'num2' is declared but never used
            int num2;
#pragma warning restore CS0168 // The variable 'num2' is declared but never used
            if (repvalue == "ItemsMovementPrint")
            {
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    if (VarGeneral.itmDesIndex == 0)
                    {
                        if (VarGeneral.GeneralPrinter.ISA4PaperType)
                        {
                            MainCryRep = getdoc("InvAcc.Reports.RepItemMovementPrint");
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsCasheir.RepItemMovementPrint");
                        }
                    }
                    else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.Reports.RepItemMovementPrintShort");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheir.RepItemMovementPrintShort");
                    }
                }
                else if (VarGeneral.itmDesIndex == 0)
                {
                    if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.ReportsE.RepItemMovementPrint");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepItemMovementPrint");
                    }
                }
                else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                {
                    MainCryRep = getdoc("InvAcc.ReportsE.RepItemMovementPrintShort");
                }
                else
                {
                    MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepItemMovementPrintShort");
                }
                ReportDocument rpt = MainCryRep;
                rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
           setTarwisaa(rpt);try
                {
                    (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                }
                catch
                {
                }
                try
                {
                    (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                }
                catch
                {
                }
                if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                {
                    rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                }
                else
                {
                    rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                }
                rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                rpt.SetParameterValue("vSts", false);
                rpt.SetParameterValue("vLines", 1);
                if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                {
                    PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                }
                else
                {
                    setpagesetting(rpt);
                }
            }
        }

        void itemtransexpir()
        {
            if (VarGeneral.vDemo)
            {
                crystalReportViewe_RepShow.ShowPrintButton = false;
                crystalReportViewe_RepShow.ShowExportButton = false;
            }
            MainCryRep = new ReportDocument();
#pragma warning disable CS0168 // The variable 'num' is declared but never used
            int num;
#pragma warning restore CS0168 // The variable 'num' is declared but never used
#pragma warning disable CS0168 // The variable 'num2' is declared but never used
            int num2;
#pragma warning restore CS0168 // The variable 'num2' is declared but never used
            if (repvalue == "ItemTransExpirDat")
            {
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.Reports.RepItemTransWithoutCostCenterExpir");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheir.RepItemTransWithoutCostCenterExpir");
                    }
                }
                else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                {
                    MainCryRep = getdoc2("RepItemTransWithoutCostCenterExpirE");
                }
                else
                {
                    MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepItemTransWithoutCostCenterExpir");
                }
                ReportDocument rpt = MainCryRep;
                rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
           setTarwisaa(rpt);try
                {
                    (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                }
                catch
                {
                }
                try
                {
                    (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                }
                catch
                {
                }
                if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                {
                    rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                }
                else
                {
                    rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                }
                rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                rpt.SetParameterValue("vSts", false);
                rpt.SetParameterValue("vLines", 1);
                if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                {
                    PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                }
                else
                {
                    setpagesetting(rpt);
                }
            }
        }

        void itemtrans()
        {
            if (VarGeneral.vDemo)
            {
                crystalReportViewe_RepShow.ShowPrintButton = false;
                crystalReportViewe_RepShow.ShowExportButton = false;
            }
            MainCryRep = new ReportDocument();
#pragma warning disable CS0168 // The variable 'num' is declared but never used
            int num;
#pragma warning restore CS0168 // The variable 'num' is declared but never used
#pragma warning disable CS0168 // The variable 'num2' is declared but never used
            int num2;
#pragma warning restore CS0168 // The variable 'num2' is declared but never used
            if (repvalue == "ItemTrans")
            {
                if (VarGeneral.itmDesIndex == 3)
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        if (VarGeneral.GeneralPrinter.ISA4PaperType)
                        {
                            MainCryRep = getdoc("InvAcc.Reports.RepItemTransShort");
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsCasheir.RepItemTransShort");
                        }
                    }
                    else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.ReportsE.RepItemTransShort");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepItemTransShort");
                    }
                }
                else
                {
                    long regval = 0L;
                    try
                    {
                        if (VarGeneral.SSSLev == "B" || VarGeneral.SSSLev == "F")
                        {
                            RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", writable: true);
                            try
                            {
                                object q = hKey.GetValue("vCoCe");
                                if (string.IsNullOrEmpty(q.ToString()))
                                {
                                    hKey.CreateSubKey("vCoCe");
                                    hKey.SetValue("vCoCe", "0");
                                }
                            }
                            catch
                            {
                                hKey.CreateSubKey("vCoCe");
                                hKey.SetValue("vCoCe", "0");
                            }
                            regval = long.Parse(hKey.GetValue("vCoCe").ToString());
                        }
                    }
                    catch
                    {
                        regval = 0L;
                    }
                    if (((VarGeneral.SSSLev == "B" || VarGeneral.SSSLev == "F") && regval == 0) || VarGeneral.SSSLev == "S" || VarGeneral.SSSLev == "C")
                    {
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            if (VarGeneral.GeneralPrinter.ISA4PaperType)
                            {
                                if (VarGeneral.itmDesIndex == 0)
                                {
                                    MainCryRep = getdoc("InvAcc.Reports.RepItemTrans");
                                }
                                else
                                {
                                    MainCryRep = getdoc("InvAcc.Reports.RepItemTransWithoutCostCenterWidth");
                                }
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsCasheir.RepItemTrans");
                            }
                        }
                        else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                        {
                            if (VarGeneral.itmDesIndex == 0)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsE.RepItemTrans");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsE.RepItemTransWithoutCostCenterWidth");
                            }
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepItemTrans");
                        }
                    }
                    else if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        if (VarGeneral.GeneralPrinter.ISA4PaperType)
                        {
                            if (VarGeneral.itmDesIndex == 0)
                            {
                                MainCryRep = getdoc("InvAcc.Reports.RepItemTrans");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.Reports.RepItemTransWidth");
                            }
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsCasheir.RepItemTrans");
                        }
                    }
                    else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        if (VarGeneral.itmDesIndex == 0)
                        {
                            MainCryRep = getdoc("InvAcc.ReportsE.RepItemTrans");
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsE.RepItemTransWidth");
                        }
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepItemTrans");
                    }
                }
                ReportDocument rpt = MainCryRep;
                rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
           setTarwisaa(rpt);try
                {
                    rpt.SetParameterValue("DetailesSts", VarGeneral.itmDes);
                }
                catch
                {
                }
                try
                {
                    if (VarGeneral.itmDes == "Note")
                    {
                        (rpt.ReportDefinition.ReportObjects["Text1"] as TextObject).Text = ((VarGeneral.CurrentLang.ToString() == "0") ? "الملاحظــات" : "Notes");
                    }
                }
                catch
                {
                }
                try
                {
                    if (VarGeneral.itmDes == "DatePay")
                    {
                        try
                        {
                            (rpt.ReportDefinition.ReportObjects["Text1"] as TextObject).Text = ((VarGeneral.CurrentLang.ToString() == "0") ? "تاريخ الإستحاق" : "due date");
                        }
                        catch
                        {
                        }
                        try
                        {
                            rpt.ReportDefinition.ReportObjects["GadeNox"].ObjectFormat.EnableSuppress = false;
                        }
                        catch
                        {
                        }
                        try
                        {
                            rpt.ReportDefinition.ReportObjects["InvProfit1x"].ObjectFormat.EnableSuppress = true;
                        }
                        catch
                        {
                        }
                        try
                        {
                            rpt.ReportDefinition.ReportObjects["RTotalProfit1x"].ObjectFormat.EnableSuppress = true;
                        }
                        catch
                        {
                        }
                    }
                }
                catch
                {
                }
                try
                {
                    rpt.SetParameterValue("ItmComm", -1);
                    if (VarGeneral.itemCommRep)
                    {
                        (rpt.ReportDefinition.ReportObjects["Text1"] as TextObject).Text = ((VarGeneral.CurrentLang.ToString() == "0") ? "عمولة الصنف" : "Item Comm");
                        rpt.SetParameterValue("ItmComm", VarGeneral.RepData.Tables[0].Compute("Sum(GadeNo)", string.Empty));
                    }
                }
                catch
                {
                }
                try
                {
                    (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                }
                catch
                {
                }
                try
                {
                    (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                }
                catch
                {
                }
                if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                {
                    rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                }
                else
                {
                    rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                }
                rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                rpt.SetParameterValue("vSts", false);
                rpt.SetParameterValue("vLines", 1);
                if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                {
                    PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                }
                else
                {
                    setpagesetting(rpt);
                }
            }
        }

        void itemmovcustpoint()
        {
            if (VarGeneral.vDemo)
            {
                crystalReportViewe_RepShow.ShowPrintButton = false;
                crystalReportViewe_RepShow.ShowExportButton = false;
            }
            MainCryRep = new ReportDocument();
#pragma warning disable CS0168 // The variable 'num' is declared but never used
            int num;
#pragma warning restore CS0168 // The variable 'num' is declared but never used
#pragma warning disable CS0168 // The variable 'num2' is declared but never used
            int num2;
#pragma warning restore CS0168 // The variable 'num2' is declared but never used
            if (repvalue == "ItemMovementsCustPoints")
            {
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.Reports.RepItemMovementPoints");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheir.RepItemMovementPoints");
                    }
                }
                else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                {
                    MainCryRep = getdoc("InvAcc.ReportsE.RepItemMovementPoints");
                }
                else
                {
                    MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepItemMovementPoints");
                }
                ReportDocument rpt = MainCryRep;
                rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
           setTarwisaa(rpt);try
                {
                    (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                }
                catch
                {
                }
                try
                {
                    (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                }
                catch
                {
                }
                if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                {
                    rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                }
                else
                {
                    rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                }
                rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                rpt.SetParameterValue("vSts", false);
                rpt.SetParameterValue("vLines", 1);
                if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                {
                    PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                }
                else
                {
                    setpagesetting(rpt);
                }
            }
        }

        void itemmovment()
        {
            if (VarGeneral.vDemo)
            {
                crystalReportViewe_RepShow.ShowPrintButton = false;
                crystalReportViewe_RepShow.ShowExportButton = false;
            }
            MainCryRep = new ReportDocument();
#pragma warning disable CS0168 // The variable 'num' is declared but never used
            int num;
#pragma warning restore CS0168 // The variable 'num' is declared but never used
#pragma warning disable CS0168 // The variable 'num2' is declared but never used
            int num2;
#pragma warning restore CS0168 // The variable 'num2' is declared but never used
            if (repvalue == "ItemMovements")
            {
                long regval = 0L;
                try
                {
                    if (VarGeneral.SSSLev == "B" || VarGeneral.SSSLev == "F")
                    {
                        RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", writable: true);
                        try
                        {
                            object q = hKey.GetValue("vCoCe");
                            if (string.IsNullOrEmpty(q.ToString()))
                            {
                                hKey.CreateSubKey("vCoCe");
                                hKey.SetValue("vCoCe", "0");
                            }
                        }
                        catch
                        {
                            hKey.CreateSubKey("vCoCe");
                            hKey.SetValue("vCoCe", "0");
                        }
                        regval = long.Parse(hKey.GetValue("vCoCe").ToString());
                    }
                }
                catch
                {
                    regval = 0L;
                }
                if (((VarGeneral.SSSLev == "B" || VarGeneral.SSSLev == "F") && regval == 0) || VarGeneral.SSSLev == "S" || VarGeneral.SSSLev == "C")
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        if (VarGeneral.GeneralPrinter.ISA4PaperType)
                        {
                            if (VarGeneral.itmDesIndex == 0)
                            {
                                MainCryRep = getdoc("InvAcc.Reports.RepItemMovement");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.Reports.RepItemMovementWidth");
                            }
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsCasheir.RepItemMovement");
                        }
                    }
                    else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        if (VarGeneral.itmDesIndex == 0)
                        {
                            MainCryRep = getdoc("InvAcc.ReportsE.RepItemMovement");
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsE.RepItemMovementWidth");
                        }
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepItemMovement");
                    }
                }
                else if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        if (VarGeneral.itmDesIndex == 0)
                        {
                            MainCryRep = getdoc("InvAcc.Reports.RepItemMovement");
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.Reports.RepItemMovementWidth");
                        }
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheir.RepItemMovement");
                    }
                }
                else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                {
                    if (VarGeneral.itmDesIndex == 0)
                    {
                        MainCryRep = getdoc("InvAcc.ReportsE.RepItemMovement");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsE.RepItemMovementWidth");
                    }
                }
                else
                {
                    MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepItemMovement");
                }
                ReportDocument rpt = MainCryRep;
                rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
           setTarwisaa(rpt);try
                {
                    (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                }
                catch
                {
                }
                try
                {
                    (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                }
                catch
                {
                }
                if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                {
                    rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                }
                else
                {
                    rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                }
                rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                rpt.SetParameterValue("vSts", false);
                rpt.SetParameterValue("vLines", 1);
                if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                {
                    PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                }
                else
                {
                    setpagesetting(rpt);
                }
            }
        }

        void partner()
        {
            if (VarGeneral.vDemo)
            {
                crystalReportViewe_RepShow.ShowPrintButton = false;
                crystalReportViewe_RepShow.ShowExportButton = false;
            }
            MainCryRep = new ReportDocument();
#pragma warning disable CS0168 // The variable 'num' is declared but never used
            int num;
#pragma warning restore CS0168 // The variable 'num' is declared but never used
#pragma warning disable CS0168 // The variable 'num2' is declared but never used
            int num2;
#pragma warning restore CS0168 // The variable 'num2' is declared but never used
            if (repvalue == "PartnerComm")
            {
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.Reports.RepInvoicCommAcc");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheir.RepInvoicCommAcc");
                    }
                }
                else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                {
                    MainCryRep = getdoc("InvAcc.ReportsE.RepInvoicCommAcc");
                }
                else
                {
                    MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepInvoicCommAcc");
                }
                ReportDocument rpt = MainCryRep;
                rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
           setTarwisaa(rpt);try
                {
                    (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                }
                catch
                {
                }
                try
                {
                    (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                }
                catch
                {
                }
                if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                {
                    rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                }
                else
                {
                    rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                }
                rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                rpt.SetParameterValue("vSts", false);
                rpt.SetParameterValue("vLines", 1);
                if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                {
                    PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                }
                else
                {
                    setpagesetting(rpt);
                }
            }
        }

        void itembestsale()
        {
            if (VarGeneral.vDemo)
            {
                crystalReportViewe_RepShow.ShowPrintButton = false;
                crystalReportViewe_RepShow.ShowExportButton = false;
            }
            MainCryRep = new ReportDocument();
#pragma warning disable CS0168 // The variable 'num' is declared but never used
            int num;
#pragma warning restore CS0168 // The variable 'num' is declared but never used
#pragma warning disable CS0168 // The variable 'num2' is declared but never used
            int num2;
#pragma warning restore CS0168 // The variable 'num2' is declared but never used
            if (repvalue == "ItemsDataBestSales")
            {
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.Reports.RepItemsDataBestSales");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheir.RepItemsDataBestSales");
                    }
                }
                else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                {
                    MainCryRep = getdoc("InvAcc.ReportsE.RepItemsDataBestSales");
                }
                else
                {
                    MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepItemsDataBestSales");
                }
                ReportDocument rpt = MainCryRep;
                rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
           setTarwisaa(rpt);if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                {
                    rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                }
                else
                {
                    rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                }
                rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                rpt.SetParameterValue("vSts", false);
                rpt.SetParameterValue("vLines", 1);
                if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                {
                    PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                }
                else
                {
                    setpagesetting(rpt);
                }
            }
        }

        void InvGaid()
        {
            if (VarGeneral.vDemo)
            {
                crystalReportViewe_RepShow.ShowPrintButton = false;
                crystalReportViewe_RepShow.ShowExportButton = false;
            }
            MainCryRep = new ReportDocument();

            if (repvalue == "InvoicesGaid")
            {
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        if (VarGeneral.itmDesIndex == 0)
                        {
                            MainCryRep = getdoc("InvAcc.Reports.RepInvoicGaid");
                        }
                        else if (VarGeneral.itmDesIndex == 1)
                        {
                            MainCryRep = getdoc("InvAcc.Reports.RepInvoicWidthGaid");
                        }
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheir.RepInvoicGaid");
                    }
                }
                else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                {
                    if (VarGeneral.itmDesIndex == 0)
                    {
                        MainCryRep = getdoc("InvAcc.ReportsE.RepInvoicGaid");
                    }
                    else if (VarGeneral.itmDesIndex == 1)
                    {
                        MainCryRep = getdoc("InvAcc.ReportsE.RepInvoicWidthGaid");
                    }
                }
                else
                {
                    MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepInvoicGaid");
                }
                ReportDocument rpt = MainCryRep;
                rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
           setTarwisaa(rpt);try
                {
                    if (VarGeneral.itmDes == "1")
                    {
                        (rpt.ReportDefinition.ReportObjects["Text3"] as TextObject).Text = ((VarGeneral.CurrentLang.ToString() == "0") ? "مدفوع منه" : "Puaid");
                        (rpt.ReportDefinition.ReportObjects["Text2"] as TextObject).Text = ((VarGeneral.CurrentLang.ToString() == "0") ? "المتبقي عليه" : "Remming");
                        (rpt.ReportDefinition.ReportObjects["Text9"] as TextObject).Text = ((VarGeneral.CurrentLang.ToString() == "0") ? "العميل" : "Customer");
                    }
                    else
                    {
                        (rpt.ReportDefinition.ReportObjects["Text3"] as TextObject).Text = ((VarGeneral.CurrentLang.ToString() == "0") ? "صر\u0651ف له" : "Dispose of him");
                        (rpt.ReportDefinition.ReportObjects["Text2"] as TextObject).Text = ((VarGeneral.CurrentLang.ToString() == "0") ? "المتبقي له" : "Remming");
                        (rpt.ReportDefinition.ReportObjects["Text9"] as TextObject).Text = ((VarGeneral.CurrentLang.ToString() == "0") ? "المورد" : "Supplier");
                    }
                }
                catch
                {
                }
                try
                {
                    (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                }
                catch
                {
                }
                try
                {
                    (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                }
                catch
                {
                }
                if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                {
                    rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                }
                else
                {
                    rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                }
                rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                rpt.SetParameterValue("vSts", false);
                rpt.SetParameterValue("vLines", 1);
                if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                {
                    PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                }
                else
                {
                    setpagesetting(rpt);
                }
            }
        }

        void InvMand()
        {
            if (VarGeneral.vDemo)
            {
                crystalReportViewe_RepShow.ShowPrintButton = false;
                crystalReportViewe_RepShow.ShowExportButton = false;
            }
            MainCryRep = new ReportDocument();
#pragma warning disable CS0168 // The variable 'num' is declared but never used
            int num;
#pragma warning restore CS0168 // The variable 'num' is declared but never used
#pragma warning disable CS0168 // The variable 'num2' is declared but never used
            int num2;
#pragma warning restore CS0168 // The variable 'num2' is declared but never used
            if (repvalue == "InvoicesMnd")
            {
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.Reports.RepInvoicWidthMnd");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheir.RepInvoic");
                    }
                }
                else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                {
                    MainCryRep = getdoc("InvAcc.ReportsE.RepInvoicWidthMnd");
                }
                else
                {
                    MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepInvoic");
                }
                ReportDocument rpt = MainCryRep;
                rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
           setTarwisaa(rpt);try
                {
                    if (VarGeneral.itmDes == "Note")
                    {
                        (rpt.ReportDefinition.ReportObjects["Text1"] as TextObject).Text = ((VarGeneral.CurrentLang.ToString() == "0") ? "الملاحظــات" : "Notes");
                    }
                }
                catch
                {
                }
                try
                {
                    if (VarGeneral.itmDes == "DatePay")
                    {
                        try
                        {
                            (rpt.ReportDefinition.ReportObjects["Text1"] as TextObject).Text = ((VarGeneral.CurrentLang.ToString() == "0") ? "تاريخ الإستحاق" : "due date");
                        }
                        catch
                        {
                        }
                        try
                        {
                            rpt.ReportDefinition.ReportObjects["GadeNox"].ObjectFormat.EnableSuppress = false;
                        }
                        catch
                        {
                        }
                        try
                        {
                            rpt.ReportDefinition.ReportObjects["InvProfit1x"].ObjectFormat.EnableSuppress = true;
                        }
                        catch
                        {
                        }
                        try
                        {
                            rpt.ReportDefinition.ReportObjects["RTotalProfit1x"].ObjectFormat.EnableSuppress = true;
                        }
                        catch
                        {
                        }
                    }
                }
                catch
                {
                }
                try
                {
                    rpt.SetParameterValue("ItmComm", -1);
                    if (VarGeneral.itemCommRep)
                    {
                        (rpt.ReportDefinition.ReportObjects["Text1"] as TextObject).Text = ((VarGeneral.CurrentLang.ToString() == "0") ? "عمولة الأصناف" : "Items Comm");
                        rpt.SetParameterValue("ItmComm", VarGeneral.RepData.Tables[0].Compute("Sum(GadeNo)", string.Empty));
                    }
                }
                catch
                {
                }
                try
                {
                    (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                }
                catch
                {
                }
                try
                {
                    (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                }
                catch
                {
                }
                if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                {
                    rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                }
                else
                {
                    rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                }
                rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                rpt.SetParameterValue("vSts", false);
                rpt.SetParameterValue("vLines", 1);
                if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                {
                    PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                }
                else
                {
                    setpagesetting(rpt);
                }
            }
        }

        void RepInv()
        {
            if (repvalue == "Invoices")
            {
                T_Printer _Invsetting = VarGeneral.GeneralPrinter;
                if (VarGeneral.InvTyp == 21)
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {

                        if (_Invsetting.ISA4PaperType)
                        {
                            MainCryRep = getdoc("InvAcc.Reports.RepInvoicWaiter");
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsCasheir.RepInvoicWaiter");
                        }
                    }
                    else if (_Invsetting.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.ReportsE.RepInvoicWaiter");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepInvoicWaiter");
                    }
                    ReportDocument rpt = MainCryRep;
                    rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
               setTarwisaa(rpt);try
                    {
                        (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                    }
                    catch
                    {
                    }
                    try
                    {
                        (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                    }
                    catch
                    {
                    }
                    if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                    {
                        rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                    }
                    else
                    {
                        rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                    }
                    rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                    rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                    rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                    rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                    rpt.SetParameterValue("vSts", false);
                    rpt.SetParameterValue("vLines", 1);
                    if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                    {
                        PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                    }
                    else
                    {
                        setpagesetting(rpt);
                    }
                }
                else if (VarGeneral.InvTyp == 1 || VarGeneral.InvTyp == 3 || VarGeneral.InvTyp == 7 || (VarGeneral.InvTyp == 2 && VarGeneral.itmDes == "DatePay") || VarGeneral.InvTyp == 2 || (VarGeneral.InvTyp == 4 && VarGeneral.itmDesIndex == 1))
                {
                    long regval = 0L;
                    try
                    {
                        if (VarGeneral.SSSLev == "B" || VarGeneral.SSSLev == "F")
                        {
                            RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", writable: true);
                            try
                            {
                                object q = hKey.GetValue("vCoCe");
                                if (string.IsNullOrEmpty(q.ToString()))
                                {
                                    hKey.CreateSubKey("vCoCe");
                                    hKey.SetValue("vCoCe", "0");
                                }
                            }
                            catch
                            {
                                hKey.CreateSubKey("vCoCe");
                                hKey.SetValue("vCoCe", "0");
                            }
                            regval = long.Parse(hKey.GetValue("vCoCe").ToString());
                        }
                    }
                    catch
                    {
                        regval = 0L;
                    }
                    if (((VarGeneral.SSSLev == "B" || VarGeneral.SSSLev == "F") && regval == 0) || VarGeneral.SSSLev == "S" || VarGeneral.SSSLev == "C")
                    {
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            if (_Invsetting.ISA4PaperType)
                            {
                                if (VarGeneral.itmDesIndex == 0)
                                {
                                    MainCryRep = getdoc("InvAcc.Reports.RepInvoic");
                                }
                                else if (VarGeneral.itmDesIndex == 1)
                                {
                                    MainCryRep = getdoc("InvAcc.Reports.RepInvoicWithoutCostCenterWidth");
                                }
                                else if (VarGeneral.itmDesIndex == 4)
                                {
                                    MainCryRep = getdoc("InvAcc.Reports.RepInvoicShort2");
                                }
                                else
                                {
                                    MainCryRep = getdoc("InvAcc.Reports.RepInvoicShort");
                                }
                            }
                            else if (VarGeneral.itmDesIndex == 3)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsCasheir.RepInvoicShort");
                            }
                            else if (VarGeneral.itmDesIndex == 4)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsCasheir.RepInvoicShort2");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsCasheir.RepInvoic");
                            }
                        }
                        else if (_Invsetting.ISA4PaperType)
                        {
                            if (VarGeneral.itmDesIndex == 0)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsE.RepInvoic");
                            }
                            else if (VarGeneral.itmDesIndex == 1)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsE.RepInvoicWithoutCostCenterWidth");
                            }
                            else if (VarGeneral.itmDesIndex == 4)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsE.RepInvoicShort2");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsE.RepInvoicShort");
                            }
                        }
                        else if (VarGeneral.itmDesIndex == 3)
                        {
                            MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepInvoicShort");
                        }
                        else if (VarGeneral.itmDesIndex == 4)
                        {
                            MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepInvoicShort2");
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepInvoic");
                        }
                    }
                    else if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        if (_Invsetting.ISA4PaperType)
                        {
                            if (VarGeneral.itmDesIndex == 0)
                            {
                                MainCryRep = getdoc("InvAcc.Reports.RepInvoic");
                            }
                            else if (VarGeneral.itmDesIndex == 1)
                            {
                                MainCryRep = getdoc("InvAcc.Reports.RepInvoicWidth");
                            }
                            else if (VarGeneral.itmDesIndex == 4)
                            {
                                MainCryRep = getdoc("InvAcc.Reports.RepInvoicShort2");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.Reports.RepInvoicShort");
                            }
                        }
                        else if (VarGeneral.itmDesIndex == 3)
                        {
                            MainCryRep = getdoc("InvAcc.ReportsCasheir.RepInvoicShort");
                        }
                        else if (VarGeneral.itmDesIndex == 4)
                        {
                            MainCryRep = getdoc("InvAcc.ReportsCasheir.RepInvoicShort2");
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsCasheir.RepInvoic");
                        }
                    }
                    else if (_Invsetting.ISA4PaperType)
                    {
                        if (VarGeneral.itmDesIndex == 0)
                        {
                            MainCryRep = getdoc("InvAcc.ReportsE.RepInvoic");
                        }
                        else if (VarGeneral.itmDesIndex == 1)
                        {
                            MainCryRep = getdoc("InvAcc.ReportsE.RepInvoicWidth");
                        }
                        else if (VarGeneral.itmDesIndex == 4)
                        {
                            MainCryRep = getdoc("InvAcc.ReportsE.RepInvoicShort2");
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsE.RepInvoicShort");
                        }
                    }
                    else if (VarGeneral.itmDesIndex == 3)
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepInvoicShort");
                    }
                    else if (VarGeneral.itmDesIndex == 4)
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepInvoicShort2");
                    }

                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepInvoic");
                    }
                    if (VarGeneral.ShowCRN)
                    {
                        try
                        {
                            if (MainCryRep.FileName.Contains(@"\ReportsE\RepInvoicWidth.rpt"))
                            {
                                try
                                {
                                    (MainCryRep.ReportDefinition.ReportObjects["Text10"] as TextObject).Text = "CRN";
                                    VarGeneral.CostCenterlbl = "السجل التجاري";
                                }
                                catch
                                {
                                    (MainCryRep.ReportDefinition.ReportObjects["Text3"] as TextObject).Text = "السجل التجاري";
                                }
                                for (int i = 0; i < VarGeneral.RepData.Tables[0].Rows.Count; i++)
                                {
                                    VarGeneral.RepData.Tables[0].Rows[i]["" +
                                        "CostCenteNm"] = VarGeneral.RepData.Tables[0].Rows[i]["CusVenCRN"];
                                }
                                VarGeneral.CostCenterlbl = "السجل التجاري";
                            }
                            else if (MainCryRep.FileName.Contains(@"\ReportsE\RepInvoic.rpt"))
                            {
                                {
                                    (MainCryRep.ReportDefinition.ReportObjects["Text3"] as TextObject).Text = "CRN";
                                }
                                for (int i = 0; i < VarGeneral.RepData.Tables[0].Rows.Count; i++)
                                {
                                    VarGeneral.RepData.Tables[0].Rows[i]["" +
                                        "CostCenteNm"] = VarGeneral.RepData.Tables[0].Rows[i]["CusVenCRN"];
                                }
                                VarGeneral.CostCenterlbl = "السجل التجاري";
                            }
                            else if (MainCryRep.FileName.Contains(@"\Reports\RepInvoicWidth.rpt"))
                            {
                                try
                                {
                                    (MainCryRep.ReportDefinition.ReportObjects["Text10"] as TextObject).Text = "CRN";
                                    VarGeneral.CostCenterlbl = "السجل التجاري";
                                }
                                catch
                                {
                                    (MainCryRep.ReportDefinition.ReportObjects["Text3"] as TextObject).Text = "السجل التجاري";
                                }
                                for (int i = 0; i < VarGeneral.RepData.Tables[0].Rows.Count; i++)
                                {
                                    VarGeneral.RepData.Tables[0].Rows[i]["" +
                                        "CostCenteNm"] = VarGeneral.RepData.Tables[0].Rows[i]["CusVenCRN"];
                                }
                                VarGeneral.CostCenterlbl = "السجل التجاري";
                            }
                            else if (MainCryRep.FileName.Contains(@"\Reports\RepInvoic.rpt"))
                            {
                                {
                                    (MainCryRep.ReportDefinition.ReportObjects["Text3"] as TextObject).Text = "CRN";
                                }
                                for (int i = 0; i < VarGeneral.RepData.Tables[0].Rows.Count; i++)
                                {
                                    VarGeneral.RepData.Tables[0].Rows[i]["" +
                                        "CostCenteNm"] = VarGeneral.RepData.Tables[0].Rows[i]["CusVenCRN"];
                                }
                                VarGeneral.CostCenterlbl = "السجل التجاري";
                            }

                        }
                        catch
                        {

                        }
                    }

                    ReportDocument rpt = MainCryRep;
                    rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
                    setTarwisaa(rpt);
                    try
                    {
                        if (VarGeneral.itmDes == "Note")
                        {
                            (rpt.ReportDefinition.ReportObjects["Text1"] as TextObject).Text = ((VarGeneral.CurrentLang.ToString() == "0") ? "الملاحظــات" : "Notes");
                            if (_Invsetting.ISA4PaperType)
                            {

                                rpt.ReportDefinition.ReportObjects["RTotalProfit1x"].ObjectFormat.EnableSuppress = true;
                            }
                        }
                    }
                    catch
                    {
                    }
            
                  
                    try
                    {
                        if (VarGeneral.itmDes == "العميل" || VarGeneral.itmDes == "المورد" || VarGeneral.itmDes == "Cust" || VarGeneral.itmDes == "Supp")
                        {
                            (rpt.ReportDefinition.ReportObjects["Text1"] as TextObject).Text = VarGeneral.itmDes;
                            (rpt.ReportDefinition.ReportObjects["Text3"] as TextObject).Text = ((VarGeneral.CurrentLang.ToString() == "0") ? "الرقم الضريبي" : "Tax No");
                            rpt.ReportDefinition.ReportObjects["SumofInvCost1"].ObjectFormat.EnableSuppress = true;
                            if (VarGeneral.CurrentLang.ToString() == "0" && _Invsetting.ISA4PaperType)
                            {
                                try
                                {
                                    (rpt.ReportDefinition.ReportObjects["Text3"] as TextObject).Width = 2073;
                                    (rpt.ReportDefinition.ReportObjects["Text3"] as TextObject).Left = 1545;
                                    rpt.ReportDefinition.ReportObjects["Text2"].ObjectFormat.EnableSuppress = true;
                                    rpt.ReportDefinition.ReportObjects["InvProfit1"].ObjectFormat.EnableSuppress = true;
                                    rpt.ReportDefinition.ReportObjects["RTotalProfit1"].ObjectFormat.EnableSuppress = true;
                                    rpt.ReportDefinition.Sections[3].ReportObjects["Line10"].ObjectFormat.EnableSuppress = true;
                                }
                                catch
                                {
                                }
                            }
                            if (_Invsetting.ISA4PaperType)
                            {
                                rpt.ReportDefinition.ReportObjects["RTotalProfit1x"].ObjectFormat.EnableSuppress = true;
                            }
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        if (VarGeneral.itmDes == "DatePay")
                        {
                            try
                            {
                                (rpt.ReportDefinition.ReportObjects["Text1"] as TextObject).Text = ((VarGeneral.CurrentLang.ToString() == "0") ? "تاريخ الإستحاق" : "due date");
                            }
                            catch
                            {
                            }
                            try
                            {
                                rpt.ReportDefinition.ReportObjects["GadeNox"].ObjectFormat.EnableSuppress = false;
                            }
                            catch
                            {
                            }
                            try
                            {
                                rpt.ReportDefinition.ReportObjects["InvProfit1x"].ObjectFormat.EnableSuppress = true;
                            }
                            catch
                            {
                            }
                            try
                            {
                                rpt.ReportDefinition.ReportObjects["RTotalProfit1x"].ObjectFormat.EnableSuppress = true;
                            }
                            catch
                            {
                            }
                            try
                            {
                                if (File.Exists(Application.StartupPath + "\\\\Script\\\\SecriptGlasses.dll") && VarGeneral.vTitle == "تنبيه بالفواتير حسب تاريخ الإستحقاق")
                                {
                                    (rpt.ReportDefinition.ReportObjects["Text13"] as TextObject).Text = ((VarGeneral.CurrentLang.ToString() == "0") ? "العميل" : "Customer");
                                }
                            }
                            catch
                            {
                            }
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        rpt.SetParameterValue("ItmComm", -1);
                        if (VarGeneral.itemCommRep)
                        {
                            (rpt.ReportDefinition.ReportObjects["Text1"] as TextObject).Text = ((VarGeneral.CurrentLang.ToString() == "0") ? "عمولة الأصناف" : "Items Comm");
                            rpt.SetParameterValue("ItmComm", VarGeneral.RepData.Tables[0].Compute("Sum(GadeNo)", string.Empty));
                            if (_Invsetting.ISA4PaperType)
                            {
                                rpt.ReportDefinition.ReportObjects["RTotalProfit1x"].ObjectFormat.EnableSuppress = true;
                            }
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                    }
                    catch
                    {
                    }
                    try
                    {
                        (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                    }
                    catch
                    {
                    }
                    if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                    {
                        rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                    }
                    else
                    {
                        rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                    }
                    rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                    rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                    rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                    rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                    rpt.SetParameterValue("vSts", false);
                    rpt.SetParameterValue("vLines", 1);
                    if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                    {
                        PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                    }
                    else
                    {
                        setpagesetting(rpt);
                    }
                }
                else if (VarGeneral.InvTyp == 0)
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        if (_Invsetting.ISA4PaperType)
                        {
                            MainCryRep = getdoc("InvAcc.Reports.RepInvoic_Sals_Return");
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsCasheir.RepInvoic_Sals_Return");
                        }
                    }
                    else if (_Invsetting.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.ReportsE.RepInvoic_Sals_Return");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheir.RepInvoic_Sals_Return");
                    }
                    ReportDocument rpt = MainCryRep;
                    rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
               setTarwisaa(rpt);try
                    {
                        (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                    }
                    catch
                    {
                    }
                    try
                    {
                        (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                    }
                    catch
                    {
                    }
                    if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                    {
                        rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                    }
                    else
                    {
                        rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                    }
                    rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                    rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                    rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                    rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                    rpt.SetParameterValue("vSts", false);
                    rpt.SetParameterValue("vLines", 1);
                    if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                    {
                        PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                    }
                    else
                    {
                        setpagesetting(rpt);
                    }
                }
                else
                {
                    long regval = 0L;
                    try
                    {
                        if (VarGeneral.SSSLev == "B" || VarGeneral.SSSLev == "F")
                        {
                            RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", writable: true);
                            try
                            {
                                object q = hKey.GetValue("vCoCe");
                                if (string.IsNullOrEmpty(q.ToString()))
                                {
                                    hKey.CreateSubKey("vCoCe");
                                    hKey.SetValue("vCoCe", "0");
                                }
                            }
                            catch
                            {
                                hKey.CreateSubKey("vCoCe");
                                hKey.SetValue("vCoCe", "0");
                            }
                            regval = long.Parse(hKey.GetValue("vCoCe").ToString());
                        }
                    }
                    catch
                    {
                        regval = 0L;
                    }
                    if (((VarGeneral.SSSLev == "B" || VarGeneral.SSSLev == "F") && regval == 0) || VarGeneral.SSSLev == "S" || VarGeneral.SSSLev == "C")
                    {
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            if (_Invsetting.ISA4PaperType)
                            {
                                if (VarGeneral.itmDesIndex == 3)
                                {
                                    MainCryRep = getdoc("InvAcc.Reports.RepInvoicShortPurachas");
                                }
                                else
                                {
                                    MainCryRep = getdoc("InvAcc.Reports.RepInvoicWithOutWCostCenter");
                                }
                            }
                            else if (VarGeneral.itmDesIndex == 3)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsCasheir.RepInvoicShort");
                            }
                            else if (VarGeneral.itmDesIndex == 4)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsCasheir.RepInvoicShort2");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsCasheir.RepInvoicWithOutWCostCenter");
                            }
                        }
                        else if (_Invsetting.ISA4PaperType)
                        {
                            if (VarGeneral.itmDesIndex == 3)
                            {
                                MainCryRep = getdoc("InvAcc.ReportsE.RepInvoicShortPurachas");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsE.RepInvoicWithOutWCostCenter");
                            }
                        }
                        else if (VarGeneral.itmDesIndex == 3)
                        {
                            MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepInvoicShort");
                        }
                        else if (VarGeneral.itmDesIndex == 4)
                        {
                            MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepInvoicShort2");
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepInvoicWithOutWCostCenter");
                        }
                    }
                    else if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        if (_Invsetting.ISA4PaperType)
                        {
                            if (VarGeneral.itmDesIndex == 3)
                            {
                                MainCryRep = getdoc("InvAcc.Reports.RepInvoicShortPurachas");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.Reports.RepInvoicWithOut");
                            }
                        }
                        else if (VarGeneral.itmDesIndex == 3)
                        {
                            MainCryRep = getdoc("InvAcc.ReportsCasheir.RepInvoicShort");
                        }
                        else if (VarGeneral.itmDesIndex == 4)
                        {
                            MainCryRep = getdoc("InvAcc.ReportsCasheir.RepInvoicShort2");
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsCasheir.RepInvoicWithOut");
                        }
                    }
                    else if (_Invsetting.ISA4PaperType)
                    {
                        if (VarGeneral.itmDesIndex == 3)
                        {
                            MainCryRep = getdoc("InvAcc.ReportsE.RepInvoicShortPurachas");
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsE.RepInvoicWithOut");
                        }
                    }
                    else if (VarGeneral.itmDesIndex == 3)
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepInvoicShort");
                    }
                    else if (VarGeneral.itmDesIndex == 4)
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepInvoicShort2");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepInvoicWithOut");
                    }
                    ReportDocument rpt = MainCryRep;
                    rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
               setTarwisaa(rpt);try
                    {
                        (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                    }
                    catch
                    {
                    }
                    try
                    {
                        (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                    }
                    catch
                    {
                    }
                    if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                    {
                        rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                    }
                    else
                    {
                        rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                    }
                    rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                    rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                    rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                    rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                    rpt.SetParameterValue("vSts", false);
                    rpt.SetParameterValue("vLines", 1);
                    if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                    {
                        PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                    }
                    else
                    {
                        setpagesetting(rpt);
                    }
                }
            }
        }

        void InvoicesCustPoints()
        {
            if (repvalue == "InvoicesCustPoints")
            {
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.Reports.RepInvoicPoints");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheir.RepInvoicPoints");
                    }
                }
                else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                {
                    MainCryRep = getdoc("InvAcc.ReportsE.RepInvoicPoints");
                }
                else
                {
                    MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepInvoicPoints");
                }
                ReportDocument rpt = MainCryRep;
                rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
           setTarwisaa(rpt);try
                {
                    (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                }
                catch
                {
                }
                try
                {
                    (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                }
                catch
                {
                }
                if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                {
                    rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                }
                else
                {
                    rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                }
                rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                rpt.SetParameterValue("vSts", false);
                rpt.SetParameterValue("vLines", 1);
                if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                {
                    PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                }
                else
                {
                    setpagesetting(rpt);
                }
            }
        }

        void InvoicesCustPointsALL()
        {
            if (repvalue == "InvoicesCustPointsALL")
            {
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    if (VarGeneral.GeneralPrinter.ISA4PaperType)
                    {
                        MainCryRep = getdoc("InvAcc.Reports.RepInvoicPointsALL");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsCasheir.RepInvoicPointsALL");
                    }
                }
                else if (VarGeneral.GeneralPrinter.ISA4PaperType)
                {
                    MainCryRep = getdoc("InvAcc.ReportsE.RepInvoicPointsALL");
                }
                else
                {
                    MainCryRep = getdoc("InvAcc.ReportsCasheirE.RepInvoicPointsALL");
                }
                ReportDocument rpt = MainCryRep;
                rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
           setTarwisaa(rpt);try
                {
                    (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                }
                catch
                {
                }
                try
                {
                    (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                }
                catch
                {
                }
                if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                {
                    rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                }
                else
                {
                    rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                }
                rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                rpt.SetParameterValue("vSts", false);
                rpt.SetParameterValue("vLines", 1);
                if (VarGeneral.GeneralPrinter.ISdirectPrinting)
                {
                    PrintSet(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);
                }
                else
                {
                    setpagesetting(rpt);
                }
            }
        }

        public void _Proceess()
        {
            TopMost = false;
            if (repvalue == "ItemsData")
            {
                Repitems();
            }
            else if (repvalue == "Invoices")
                RepInv();
            else if (repvalue == "InvoicesCustPoints")
                InvoicesCustPoints();
            else if (repvalue == "InvoicesCustPointsALL")
                InvoicesCustPointsALL();
            else if (repvalue == "InvoicesMnd")
                InvMand();
            else if (repvalue == "InvoicesGaid")
                InvGaid();
            else if (repvalue == "ItemsDataBestSales")
                itembestsale();
            else if (repvalue == "PartnerComm")
                partner();
            else if (repvalue == "ItemMovements")
                itemmovment();
            else if (repvalue == "ItemMovementsCustPoints")
                itemmovcustpoint();
            else if (repvalue == "ItemTrans")
                itemtrans();
            else if (repvalue == "ItemTransExpirDat")
                itemtransexpir();
            else if (repvalue == "ItemsMovementPrint")
                itemmovprint();
            else if (repvalue == "Account")
                account();
            else if (repvalue == "AccountTax")
                accountx();
            else if (repvalue == "AccountSerfGabth")
                account1();
            else if (repvalue == "AccountTrans")
                accounttrans();
            else if (repvalue == "AccountTranc")
                accountttt();
            else if (repvalue == "AccountTrancByAccNo")
                account2();
            else if (repvalue == "RepRevenue_1" || repvalue == "RepRevenue_0")
                rep1rep2();
            else if (repvalue == "RepRoomDesc")
                roomrep();
            else if (repvalue == "RepRoomMovement")
                room2();
            else if (repvalue == "RepRoomReapir")
                room3();
            else if (repvalue == "RepRoomGroup")
                room4();
            else if (repvalue == "RepGuestData")
                room5();
            else if (repvalue == "RepGuestDataPer_1")
                room6();
            else if (repvalue == "RepReserv")
                room7();
            else if (repvalue == "RepPers_8" || repvalue == "RepPers_11" || repvalue == "RepPers_12")
                room8();
            else if (repvalue == "RepGuestOrders")
                room9();
            else if (repvalue == "RepGuestCalls")
                room10();
            else if (repvalue == "RepGuestAcc")
                room11();
            else
            if (repvalue == "Cust_Supp")
                room12();
            else if (repvalue == "CustAge")
                room13();
            else if (repvalue == "CustAge15")
                room14();
            else if (repvalue == "Purchase" || repvalue == "PurchaseReturn" || repvalue == "PurchaseOrder" || repvalue == "PurchaseSuppliers")
                purch();
            else if (repvalue == "InvSal" || repvalue == "InvSalReturn" || repvalue == "InvSalTailor" || repvalue == "InvSalWtr" || repvalue == "CustQutation" || repvalue == "InvTransInOut" || repvalue == "OpenQty" || repvalue == "OpenQtyEqual")
                invo();
            segment1();
        }

        private void PrintForm1()
        {
            if (columns_Names_visible_Passport.Count > 0)
            {
                ReportDocument xx = getdoc("InvAcc.ReportsEmp.passprt1");
                xx.SetParameterValue("Type1", string.Empty);
                xx.SetParameterValue("Type2", string.Empty);
                xx.SetParameterValue("Type3", string.Empty);
                xx.SetParameterValue("Type4", string.Empty);
                xx.SetParameterValue("Type1_1", string.Empty);
                xx.SetParameterValue("Type1_2", string.Empty);
                xx.SetParameterValue("Type2_1", string.Empty);
                xx.SetParameterValue("Type2_2", string.Empty);
                xx.SetParameterValue("Type2_3", string.Empty);
                xx.SetParameterValue("Type4_1", string.Empty);
                xx.SetParameterValue("Type3_1", string.Empty);
                xx.SetParameterValue("Type3_2", string.Empty);
                xx.SetParameterValue("Type3_3", string.Empty);
                xx.SetParameterValue("SponsorType1", string.Empty);
                xx.SetParameterValue("SponsorType2", string.Empty);
                xx.SetParameterValue("SponsorType3", string.Empty);
                xx.SetParameterValue("SponsorType4", string.Empty);
                xx.SetParameterValue("Igama_1", string.Empty);
                xx.SetParameterValue("Igama_2", string.Empty);
                xx.SetParameterValue("Igama_3", string.Empty);
                xx.SetParameterValue("Igama_4", string.Empty);
                xx.SetParameterValue("Igama_5", string.Empty);
                xx.SetParameterValue("Igama_6", string.Empty);
                xx.SetParameterValue("Igama_7", string.Empty);
                xx.SetParameterValue("Igama_8", string.Empty);
                xx.SetParameterValue("Igama_9", string.Empty);
                xx.SetParameterValue("Igama_10", string.Empty);
                xx.SetParameterValue("S_1", string.Empty);
                xx.SetParameterValue("S_2", string.Empty);
                xx.SetParameterValue("S_3", string.Empty);
                xx.SetParameterValue("S_4", string.Empty);
                xx.SetParameterValue("S_5", string.Empty);
                xx.SetParameterValue("S_6", string.Empty);
                xx.SetParameterValue("S_7", string.Empty);
                xx.SetParameterValue("S_8", string.Empty);
                xx.SetParameterValue("S_9", string.Empty);
                xx.SetParameterValue("S_10", string.Empty);
                xx.SetParameterValue("E_1", string.Empty);
                xx.SetParameterValue("E_2", string.Empty);
                xx.SetParameterValue("E_3", string.Empty);
                xx.SetParameterValue("E_4", string.Empty);
                xx.SetParameterValue("E_5", string.Empty);
                xx.SetParameterValue("E_6", string.Empty);
                xx.SetParameterValue("E_7", string.Empty);
                xx.SetParameterValue("E_8", string.Empty);
                xx.SetParameterValue("E_9", string.Empty);
                xx.SetParameterValue("E_10", string.Empty);
                xx.SetParameterValue("NS_1", string.Empty);
                xx.SetParameterValue("NS_2", string.Empty);
                xx.SetParameterValue("NS_3", string.Empty);
                xx.SetParameterValue("NS_4", string.Empty);
                xx.SetParameterValue("NS_5", string.Empty);
                xx.SetParameterValue("NS_6", string.Empty);
                xx.SetParameterValue("NS_7", string.Empty);
                xx.SetParameterValue("NS_8", string.Empty);
                xx.SetParameterValue("NS_9", string.Empty);
                xx.SetParameterValue("NS_10", string.Empty);
                xx.SetParameterValue("PassPorts", string.Empty);
                xx.SetParameterValue("OrderName", string.Empty);
                xx.SetParameterValue("SponsorNo", string.Empty);
                xx.SetParameterValue("OrderType1", string.Empty);
                xx.SetParameterValue("OrderType2", string.Empty);
                xx.SetParameterValue("OrderType3", string.Empty);
                xx.SetParameterValue("OrderType4", string.Empty);
                xx.SetParameterValue("OrderType1_1", string.Empty);
                xx.SetParameterValue("OrderType1_2", string.Empty);
                xx.SetParameterValue("OrderType1_3", string.Empty);
                xx.SetParameterValue("OrderType2_1", string.Empty);
                xx.SetParameterValue("OrderType2_2", string.Empty);
                xx.SetParameterValue("OrderType2_3", string.Empty);
                xx.SetParameterValue("OrderType2_4", string.Empty);
                xx.SetParameterValue("OrderType3_1", string.Empty);
                xx.SetParameterValue("OrderType3_2", string.Empty);
                xx.SetParameterValue("OrderType3_3", string.Empty);
                xx.SetParameterValue("OrderType3_4", string.Empty);
                xx.SetParameterValue("IgamaExpire", string.Empty);
                xx.SetParameterValue("EnteryDate", string.Empty);
                xx.SetParameterValue("EnteryPort", string.Empty);
                xx.SetParameterValue("fName", string.Empty);
                xx.SetParameterValue("fFather", string.Empty);
                xx.SetParameterValue("fGrand", string.Empty);
                xx.SetParameterValue("fFamily", string.Empty);
                xx.SetParameterValue("EfName", string.Empty);
                xx.SetParameterValue("EfFather", string.Empty);
                xx.SetParameterValue("EfGrand", string.Empty);
                xx.SetParameterValue("EfFamily", string.Empty);
                xx.SetParameterValue("fNameJob", string.Empty);
                xx.SetParameterValue("fNameNationality", string.Empty);
                xx.SetParameterValue("fNameReligion", string.Empty);
                xx.SetParameterValue("BirthDate", string.Empty);
                xx.SetParameterValue("PassPortNo", string.Empty);
                xx.SetParameterValue("PassPortDate", string.Empty);
                xx.SetParameterValue("PassPortExpire", string.Empty);
                xx.SetParameterValue("PassPortPlace", string.Empty);
                xx.SetParameterValue("SponsorName", string.Empty);
                xx.SetParameterValue("SponsorType", string.Empty);
                xx.SetParameterValue("SponsorAddress", string.Empty);
                xx.SetParameterValue("SponsorTel", string.Empty);
                xx.SetParameterValue("NewSponsorName", string.Empty);
                xx.SetParameterValue("NewSponsorType", string.Empty);
                xx.SetParameterValue("NewSponsorAddress", string.Empty);
                xx.SetParameterValue("NewSponsorTel", string.Empty);
                xx.SetParameterValue("NewSponsorNo", string.Empty);
                xx.SetParameterValue("EnteryNo", string.Empty);
                xx.SetParameterValue("IgamaNo", string.Empty);
                xx.SetParameterValue("PassPorts", columns_Names_visible_Passport["PassPorts"].PassportField);
                xx.SetParameterValue("IgamaNo", columns_Names_visible_Passport["IgamaNo"].PassportField);
                xx.SetParameterValue("OrderName", columns_Names_visible_Passport["OrderName"].PassportField);
                xx.SetParameterValue("fNameNationality", columns_Names_visible_Passport["fNameNationality"].PassportField);
                xx.SetParameterValue("fNameJob", columns_Names_visible_Passport["fNameJob"].PassportField);
                xx.SetParameterValue("fNameReligion", columns_Names_visible_Passport["fNameReligion"].PassportField);
                xx.SetParameterValue("OrderType1", columns_Names_visible_Passport["OrderType1"].PassportField);
                xx.SetParameterValue("OrderType2", columns_Names_visible_Passport["OrderType2"].PassportField);
                xx.SetParameterValue("OrderType3", columns_Names_visible_Passport["OrderType3"].PassportField);
                xx.SetParameterValue("OrderType4", columns_Names_visible_Passport["OrderType4"].PassportField);
                xx.SetParameterValue("OrderType1_1", columns_Names_visible_Passport["OrderType1_1"].PassportField);
                xx.SetParameterValue("OrderType2_1", columns_Names_visible_Passport["OrderType2_1"].PassportField);
                xx.SetParameterValue("OrderType2_2", columns_Names_visible_Passport["OrderType2_2"].PassportField);
                xx.SetParameterValue("OrderType2_3", columns_Names_visible_Passport["OrderType2_3"].PassportField);
                xx.SetParameterValue("OrderType3_1", columns_Names_visible_Passport["OrderType3_1"].PassportField);
                xx.SetParameterValue("OrderType3_2", columns_Names_visible_Passport["OrderType3_2"].PassportField);
                xx.SetParameterValue("OrderType3_3", columns_Names_visible_Passport["OrderType3_3"].PassportField);
                xx.SetParameterValue("OrderType1_3", columns_Names_visible_Passport["OrderType1_3"].PassportField);
                xx.SetParameterValue("OrderType2_4", columns_Names_visible_Passport["OrderType2_4"].PassportField);
                xx.SetParameterValue("OrderType3_4", columns_Names_visible_Passport["OrderType3_4"].PassportField);
                xx.SetParameterValue("IgamaExpire", columns_Names_visible_Passport["IgamaExpire"].PassportField);
                xx.SetParameterValue("SponsorNo", columns_Names_visible_Passport["SponsorNo"].PassportField);
                xx.SetParameterValue("EnteryPort", columns_Names_visible_Passport["EnteryPort"].PassportField);
                xx.SetParameterValue("EnteryDate", columns_Names_visible_Passport["EnteryDate"].PassportField);
                xx.SetParameterValue("EnteryNo", columns_Names_visible_Passport["EnteryNo"].PassportField);
                xx.SetParameterValue("fName", columns_Names_visible_Passport["fName"].PassportField);
                xx.SetParameterValue("fFather", columns_Names_visible_Passport["fFather"].PassportField);
                xx.SetParameterValue("fGrand", columns_Names_visible_Passport["fGrand"].PassportField);
                xx.SetParameterValue("fFamily", columns_Names_visible_Passport["fFamily"].PassportField);
                xx.SetParameterValue("EfName", columns_Names_visible_Passport["EfName"].PassportField);
                xx.SetParameterValue("EfFather", columns_Names_visible_Passport["EfFather"].PassportField);
                xx.SetParameterValue("EfGrand", columns_Names_visible_Passport["EfGrand"].PassportField);
                xx.SetParameterValue("EfFamily", columns_Names_visible_Passport["EfFamily"].PassportField);
                xx.SetParameterValue("BirthDate", columns_Names_visible_Passport["BirthDate"].PassportField);
                xx.SetParameterValue("PassportDate", columns_Names_visible_Passport["PassportDate"].PassportField);
                xx.SetParameterValue("PassPortExpire", columns_Names_visible_Passport["PassPortExpire"].PassportField);
                xx.SetParameterValue("PassPortPlace", columns_Names_visible_Passport["PassPortPlace"].PassportField);
                xx.SetParameterValue("SponsorType", columns_Names_visible_Passport["SponsorType"].PassportField);
                xx.SetParameterValue("SponsorName", columns_Names_visible_Passport["SponsorName"].PassportField);
                xx.SetParameterValue("SponsorAddress", columns_Names_visible_Passport["SponsorAddress"].PassportField);
                xx.SetParameterValue("SponsorTel", columns_Names_visible_Passport["SponsorTel"].PassportField);
                xx.SetParameterValue("NewSponsorType", columns_Names_visible_Passport["NewSponsorType"].PassportField);
                xx.SetParameterValue("NewSponsorName", columns_Names_visible_Passport["NewSponsorName"].PassportField);
                xx.SetParameterValue("NewSponsorAddress", columns_Names_visible_Passport["NewSponsorAddress"].PassportField);
                xx.SetParameterValue("NewSponsorTel", columns_Names_visible_Passport["NewSponsorTel"].PassportField);
                xx.SetParameterValue("NewSponsorNo", columns_Names_visible_Passport["NewSponsorNo"].PassportField);
                xx.SetParameterValue("Igama_1", columns_Names_visible_Passport["Igama_1"].PassportField);
                xx.SetParameterValue("Igama_2", columns_Names_visible_Passport["Igama_2"].PassportField);
                xx.SetParameterValue("Igama_3", columns_Names_visible_Passport["Igama_3"].PassportField);
                xx.SetParameterValue("Igama_4", columns_Names_visible_Passport["Igama_4"].PassportField);
                xx.SetParameterValue("Igama_5", columns_Names_visible_Passport["Igama_5"].PassportField);
                xx.SetParameterValue("Igama_6", columns_Names_visible_Passport["Igama_6"].PassportField);
                xx.SetParameterValue("Igama_7", columns_Names_visible_Passport["Igama_7"].PassportField);
                xx.SetParameterValue("Igama_8", columns_Names_visible_Passport["Igama_8"].PassportField);
                xx.SetParameterValue("Igama_9", columns_Names_visible_Passport["Igama_9"].PassportField);
                xx.SetParameterValue("Igama_10", columns_Names_visible_Passport["Igama_10"].PassportField);
                xx.SetParameterValue("E_1", columns_Names_visible_Passport["E_1"].PassportField);
                xx.SetParameterValue("E_2", columns_Names_visible_Passport["E_2"].PassportField);
                xx.SetParameterValue("E_3", columns_Names_visible_Passport["E_3"].PassportField);
                xx.SetParameterValue("E_4", columns_Names_visible_Passport["E_4"].PassportField);
                xx.SetParameterValue("E_5", columns_Names_visible_Passport["E_5"].PassportField);
                xx.SetParameterValue("E_6", columns_Names_visible_Passport["E_6"].PassportField);
                xx.SetParameterValue("E_7", columns_Names_visible_Passport["E_7"].PassportField);
                xx.SetParameterValue("E_8", columns_Names_visible_Passport["E_8"].PassportField);
                xx.SetParameterValue("E_9", columns_Names_visible_Passport["E_9"].PassportField);
                xx.SetParameterValue("E_10", columns_Names_visible_Passport["E_10"].PassportField);
                xx.SetParameterValue("S_1", columns_Names_visible_Passport["S_1"].PassportField);
                xx.SetParameterValue("S_2", columns_Names_visible_Passport["S_2"].PassportField);
                xx.SetParameterValue("S_3", columns_Names_visible_Passport["S_3"].PassportField);
                xx.SetParameterValue("S_4", columns_Names_visible_Passport["S_4"].PassportField);
                xx.SetParameterValue("S_5", columns_Names_visible_Passport["S_5"].PassportField);
                xx.SetParameterValue("S_6", columns_Names_visible_Passport["S_6"].PassportField);
                xx.SetParameterValue("S_7", columns_Names_visible_Passport["S_7"].PassportField);
                xx.SetParameterValue("S_8", columns_Names_visible_Passport["S_8"].PassportField);
                xx.SetParameterValue("S_9", columns_Names_visible_Passport["S_9"].PassportField);
                xx.SetParameterValue("S_10", columns_Names_visible_Passport["S_10"].PassportField);
                xx.SetParameterValue("NS_1", columns_Names_visible_Passport["NS_1"].PassportField);
                xx.SetParameterValue("NS_2", columns_Names_visible_Passport["NS_2"].PassportField);
                xx.SetParameterValue("NS_3", columns_Names_visible_Passport["NS_3"].PassportField);
                xx.SetParameterValue("NS_4", columns_Names_visible_Passport["NS_4"].PassportField);
                xx.SetParameterValue("NS_5", columns_Names_visible_Passport["NS_5"].PassportField);
                xx.SetParameterValue("NS_6", columns_Names_visible_Passport["NS_6"].PassportField);
                xx.SetParameterValue("NS_7", columns_Names_visible_Passport["NS_7"].PassportField);
                xx.SetParameterValue("NS_8", columns_Names_visible_Passport["NS_8"].PassportField);
                xx.SetParameterValue("NS_9", columns_Names_visible_Passport["NS_9"].PassportField);
                xx.SetParameterValue("NS_10", columns_Names_visible_Passport["NS_10"].PassportField);
                xx.SetParameterValue("PassPortNo", columns_Names_visible_Passport["PassPortNo"].PassportField);
                crystalReportViewe_RepShow.ReportSource = xx;
            }
            else
            {
                MessageBox.Show("لا توجد حقول للطباعة تأكد من إعدادات الطباعة", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        void setHeaderDetailsCoputation()
        {
            try
            {
                string s = VarGeneral.RepData.Tables[0].Rows[1]["RefNo"].ToString();

                string s2 = VarGeneral.RepData.Tables[0].Rows[1]["TaxCustNo"].ToString();

                string s3 = VarGeneral.RepData.Tables[0].Rows[1]["LineDetails"].ToString();
                bool f = false;
                try
                {
                    object k = (MainCryRep.ReportDefinition.Sections["ReportHeaderSection2"].ReportObjects["LineDetail1"]);
              if(k!=null)      f = true;   
                }
                catch
                {
                    f = false;
                }
                foreach (DataRow r in VarGeneral.RepData.Tables[0].Rows)
                {
                    try
                    {
                        r["RefNo"] = s;
                    }
                    catch
                    {

                    }
                    try
                    {
                        r["TaxCustNo"] = s2;
                    }
                    catch
                    { }

                    try
                    {
                if(f&&VarGeneral.SSSLev!="R")      r["LineDetails"] = s3;
                    }
                    catch
                    { }
                }
            }
            catch
            {


            }
        }
        void setTarwisaa(ReportDocument rpt)
        {
            
            this.listInfotb = this.db.StockInfoList();
            this._Infotb = this.listInfotb[0];
            for (int iiCnt = 0; iiCnt < this.listInfotb.Count; iiCnt++)
            {
                this._Infotb = this.listInfotb[iiCnt];
                if ("lTrwes1" == this._Infotb.fldFlag.ToString())
                {
                    if (VarGeneral.TString.ChkStatShow(this.permission.StopBanner, 0))
                    {
                        rpt.SetParameterValue("CompanyNameE", (!VarGeneral.TString.ChkStatShow(this.permission.StopBanner, 1)) ? this._Infotb.fldValue : "");
                    }
                    else
                    {
                        rpt.SetParameterValue("CompanyNameE", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? this._Infotb.fldValue : "");
                    }
                }
                else if ("lTrwes2" == this._Infotb.fldFlag.ToString())
                {
                    if (VarGeneral.TString.ChkStatShow(this.permission.StopBanner, 0))
                    {
                        rpt.SetParameterValue("CompanyAddressE", (!VarGeneral.TString.ChkStatShow(this.permission.StopBanner, 1)) ? this._Infotb.fldValue : "");
                    }
                    else
                    {
                        rpt.SetParameterValue("CompanyAddressE", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? this._Infotb.fldValue : "");
                    }
                }
                else if ("lTrwes3" == this._Infotb.fldFlag.ToString())
                {
                    if (VarGeneral.TString.ChkStatShow(this.permission.StopBanner, 0))
                    {
                        rpt.SetParameterValue("CompanyTelE", (!VarGeneral.TString.ChkStatShow(this.permission.StopBanner, 1)) ? this._Infotb.fldValue : "");
                    }
                    else
                    {
                        rpt.SetParameterValue("CompanyTelE", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? this._Infotb.fldValue : "");
                    }
                }
                else if ("lTrwes4" == this._Infotb.fldFlag.ToString())
                {
                    if (VarGeneral.TString.ChkStatShow(this.permission.StopBanner, 0))
                    {
                        rpt.SetParameterValue("CompanyFaxE", (!VarGeneral.TString.ChkStatShow(this.permission.StopBanner, 1)) ? this._Infotb.fldValue : "");
                    }
                    else
                    {
                        rpt.SetParameterValue("CompanyFaxE", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? this._Infotb.fldValue : "");
                    }
                }
                else if ("rTrwes1" == this._Infotb.fldFlag.ToString())
                {
                    if (VarGeneral.TString.ChkStatShow(this.permission.StopBanner, 0))
                    {
                        rpt.SetParameterValue("CompanyName", (!VarGeneral.TString.ChkStatShow(this.permission.StopBanner, 1)) ? this._Infotb.fldValue : "");
                    }
                    else
                    {
                        rpt.SetParameterValue("CompanyName", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? this._Infotb.fldValue : "");
                    }
                }
                else if ("rTrwes2" == this._Infotb.fldFlag.ToString())
                {
                    if (VarGeneral.TString.ChkStatShow(this.permission.StopBanner, 0))
                    {
                        rpt.SetParameterValue("CompanyAddress", (!VarGeneral.TString.ChkStatShow(this.permission.StopBanner, 1)) ? this._Infotb.fldValue : "");
                    }
                    else
                    {
                        rpt.SetParameterValue("CompanyAddress", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? this._Infotb.fldValue : "");
                    }
                }
                else if ("rTrwes3" == this._Infotb.fldFlag.ToString())
                {
                    if (VarGeneral.TString.ChkStatShow(this.permission.StopBanner, 0))
                    {
                        rpt.SetParameterValue("CompanyTel", (!VarGeneral.TString.ChkStatShow(this.permission.StopBanner, 1)) ? this._Infotb.fldValue : "");
                    }
                    else
                    {
                        rpt.SetParameterValue("CompanyTel", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? this._Infotb.fldValue : "");
                    }
                }
                else if ("rTrwes4" == this._Infotb.fldFlag.ToString())
                {
                    if (VarGeneral.TString.ChkStatShow(this.permission.StopBanner, 0))
                    {
                        rpt.SetParameterValue("CompanyFax", (!VarGeneral.TString.ChkStatShow(this.permission.StopBanner, 1)) ? this._Infotb.fldValue : "");
                    }
                    else
                    {
                        rpt.SetParameterValue("CompanyFax", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? this._Infotb.fldValue : "");
                    }
                }
            }
        }

        private void STEP_Cachier_2()
        {
            VarGeneral._dbshared = null;
            for (int i = 0; i < VarGeneral.RepData.Tables[0].Rows.Count; i++)
            {
                try
                {
                    int k = int.Parse(VarGeneral.RepData.Tables[0].Rows[i]["defPrn"].ToString());

                    VarGeneral.RepData.Tables[0].Rows[i]["defPrn"] = (VarGeneral.dbshared.T_Printers.Single(ksa => ksa.InvID == k && ksa.User_ID == VarGeneral.UserID).defPrn);

                }
                catch (Exception ex)
                { }
            }
            string vTableNo;
            vTableNo = "";
            string vTableTyp;
            vTableTyp = "";
            string vWaiterNm;
            vWaiterNm = "";
            string orderTyp;
            orderTyp = "";
            string vUsrNmA;
            try
            {
                vUsrNmA = VarGeneral.RepData.Tables[0].Rows[0]["UsrNamA"].ToString();
            }
            catch
            {
                vUsrNmA = "";
            }
            string vUsrNmE;
            try
            {
                vUsrNmE = VarGeneral.RepData.Tables[0].Rows[0]["UsrNamE"].ToString();
            }
            catch
            {
                vUsrNmE = "";
            }
            string vBranchNmA;
            try
            {
                vBranchNmA = VarGeneral.RepData.Tables[0].Rows[0]["Branch_Name"].ToString();
            }
            catch
            {
                vBranchNmA = "";
            }
            string vBranchNmE;
            try
            {
                vBranchNmE = VarGeneral.RepData.Tables[0].Rows[0]["Branch_NameE"].ToString();
            }
            catch
            {
                vBranchNmE = "";
            }
            string vInvNo;
            try
            {
                vInvNo = VarGeneral.RepData.Tables[0].Rows[1]["InvNo"].ToString();
            }
            catch
            {
                vInvNo = "";
            }
            string vCustNo;
            try
            {
                vCustNo = VarGeneral.RepData.Tables[0].Rows[1]["CusVenNo"].ToString();
            }
            catch
            {
                vCustNo = "";
            }
            string vCustNm;
            try
            {
                vCustNm = VarGeneral.RepData.Tables[0].Rows[1]["CusVenNm"].ToString();
            }
            catch
            {
                vCustNm = "";
            }
            string vGdat;
            VarGeneral.printersNames.Clear();
            try
            {
                vGdat = VarGeneral.RepData.Tables[0].Rows[1]["GDat"].ToString();
            }
            catch
            {
                vGdat = "";
            }
            string vHdat;
            try
            {
                vHdat = VarGeneral.RepData.Tables[0].Rows[1]["HDat"].ToString();
            }
            catch
            {
                vHdat = "";
            }
            string vInvID;
            try
            {
                vInvID = VarGeneral.RepData.Tables[0].Rows[1]["vID"].ToString();
            }
            catch
            {
                vInvID = "";
            }
            string vInvCash;
            try
            {
                vInvCash = VarGeneral.RepData.Tables[0].Rows[1]["InvCash"].ToString();
            }
            catch
            {
                vInvCash = "";
            }
            string TaxNo;
            try
            {
                TaxNo = VarGeneral.RepData.Tables[0].Rows[1]["TaxAcc"].ToString();
            }
            catch
            {
                TaxNo = "";
            }
            if (VarGeneral.SSSLev == "R" || VarGeneral.SSSLev == "C" || VarGeneral.SSSLev == "H")
            {
                try
                {
                    vTableNo = this.db.StockRommID(this.db.StockInvHead(VarGeneral.InvTyp, vInvNo).RoomNo.Value).RomeNo.ToString();
                }
                catch
                {
                    vTableNo = "";
                }
                try
                {
                    orderTyp = VarGeneral.RepData.Tables[0].Rows[1]["OrderTyp"].ToString();
                }
                catch
                {
                    orderTyp = "";
                }
                try
                {
                    T_Room q;
                    q = this.db.StockRommID(int.Parse(this.db.StockInvHead(VarGeneral.InvTyp, vInvNo).RoomNo.ToString()));
                    vTableTyp = ((q == null || string.IsNullOrEmpty(q.RomeNo.ToString())) ? ((base.Tag.ToString() == "0") ? "بدون طاولة" : "WithOut Table") : ((q.Type == 1) ? ((base.Tag.ToString() == "0") ? "طاولات العوائل" : "Families Tables") : ((q.Type == 2) ? ((base.Tag.ToString() == "0") ? "طاولات الشباب" : "Boys Tables") : ((q.Type == 3) ? ((base.Tag.ToString() == "0") ? "طاولات خارجية" : "Extrnal Tables") : ((q.Type != 4) ? ((base.Tag.ToString() == "0") ? "بدون طاولة" : "WithOut Table") : ((base.Tag.ToString() == "0") ? "طاولات أخرى" : "Other Tables"))))));
                }
                catch
                {
                    vTableTyp = ((base.Tag.ToString() == "0") ? "بدون طاولة" : "WithOut Table");
                }
                try
                {
                    vWaiterNm = ((!(vTableNo == "") && !(vTableNo == "0")) ? ((base.Tag.ToString() == "0") ? this.db.StockRommID(this.db.StockInvHead(VarGeneral.InvTyp, vInvNo).RoomNo.Value).T_Waiter.Arb_Des : this.db.StockRommID(this.db.StockInvHead(VarGeneral.InvTyp, vInvNo).RoomNo.Value).T_Waiter.Eng_Des) : "");
                }
                catch
                {
                    vWaiterNm = "";
                }
            }
            VarGeneral.RepData.Tables[0].Rows.RemoveAt(0);
           
            DataRowCollection row;
            row = VarGeneral.RepData.Tables[0].Rows;

            List<int> myData;
            myData = (from myRow in VarGeneral.RepData.Tables[0].AsEnumerable()
                      select myRow.Field<int>("ItmCat")).Distinct().ToList();
            List<string> myData2;
            myData2 = (from s in (from myRow in VarGeneral.RepData.Tables[0].AsEnumerable()
                                  select myRow.Field<string>("defPrn")).Distinct().ToList()
                       where !string.IsNullOrEmpty(s)
                       select s).Distinct().ToList();
            try
            {
                bool typ = VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 33);

                for (int i = 0; i < (typ ? myData2.Count() : myData.Count()); i++)
                {
                    new T_INVSETTING();
                    T_Printer _InvSetting;

                    {
                        _InvSetting = (typ ? db.StockInvSettingInvoicesDefPrinter(VarGeneral.UserID, myData2[i]) : db.StockInvSettingInvoices(VarGeneral.UserID, myData[i]).InvpRINTERInfo);
                    }
                   
                    ReportDocument rpt;
                    DataSet newData;
                    DataRow[] query;
                    ids = _InvSetting.InvID;
                    if (_InvSetting.InvInfo.PrintCat.Value)
                    {
                        continue;
                    }
                    if (_InvSetting.ISCashierType)
                    {
                        try
                        {
                            if (base.Tag.ToString() == "0")
                            {
                                try
                                {
                                    if (VarGeneral.gUserName == "runsetting")
                                    {
                                        if (File.Exists(Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", "").Trim() + "\\RepInvoicCachier.rpt"))
                                        {
                                            this.MainCryRep.FileName = Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", "").Trim() + "\\RepInvoicCachier.rpt";
                                        }
                                        else
                                        {
                                            this.MainCryRep = getdoc("InvAcc.Reports.RepInvoicCachier");
                                        }
                                    }
                                    else if (File.Exists(Application.StartupPath + "\\Reps\\RepInvoicCachier.rpt"))
                                    {
                                        this.MainCryRep.FileName = Application.StartupPath + "\\Reps\\RepInvoicCachier.rpt";
                                    }
                                    else
                                    {
                                        this.MainCryRep = getdoc("InvAcc.Reports.RepInvoicCachier");
                                    }
                                }
                                catch
                                {
                                    this.MainCryRep = getdoc("InvAcc.Reports.RepInvoicCachier");
                                }
                            }
                            else
                            {
                                try
                                {
                                    if (VarGeneral.gUserName == "runsetting")
                                    {
                                        if (File.Exists(Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", "").Trim() + "\\RepInvoicCachier.rpt"))
                                        {
                                            this.MainCryRep.FileName = Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", "").Trim() + "\\RepInvoicCachier.rpt";
                                        }
                                        else
                                        {
                                            this.MainCryRep = getdoc("InvAcc.ReportsE.RepInvoicCachier");
                                        }
                                    }
                                    else if (File.Exists(Application.StartupPath + "\\RepsE\\RepInvoicCachier.rpt"))
                                    {
                                        this.MainCryRep.FileName = Application.StartupPath + "\\RepsE\\RepInvoicCachier.rpt";
                                    }
                                    else
                                    {
                                        this.MainCryRep = getdoc("InvAcc.ReportsE.RepInvoicCachier");
                                    }
                                }
                                catch
                                {
                                    this.MainCryRep = getdoc("InvAcc.ReportsE.RepInvoicCachier");
                                }
                            }
                            rpt = this.MainCryRep;
                            newData = new DataSet();


                            query = VarGeneral.RepData.Tables[0].Select(typ ? ("defPrn = '" + myData2[i] + "'") : ("ItmCat = " + myData[i]));
                            string s = "will send these Itmes";
                            foreach (DataRow d in query)
                                try { s += "-" + d["ItmDes"].ToString(); } catch { }
                            s += "  To Printer +" + _InvSetting.defPrn;
                            VarGeneral.printersNames.Add(s);
                            if (query.Count() <= 0)
                            {
                                continue;
                            }
                            newData.Tables.Add(query.CopyToDataTable());
                            rpt.SetDataSource(newData.Tables[0]);
                            setTarwisaa(rpt);

                            try
                            {
                                if (!VarGeneral.TString.ChkStatShow(_InvSetting.InvInfo.TaxOptions, 1))
                                {
                                    rpt.ReportDefinition.ReportObjects["TextTotTax"].ObjectFormat.EnableSuppress = true;
                                    rpt.ReportDefinition.ReportObjects["TotTax1"].ObjectFormat.EnableSuppress = true;
                                    rpt.ReportDefinition.ReportObjects["TextTaxHeader"].ObjectFormat.EnableSuppress = true;
                                    rpt.ReportDefinition.ReportObjects["TaxNo1"].ObjectFormat.EnableSuppress = true;
                                    rpt.ReportDefinition.Sections["DetailSection5"].SectionFormat.EnableSuppress = true;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 64))
                                {
                                    rpt.ReportDefinition.Sections["DetailSection5"].SectionFormat.EnableSuppress = true;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                rpt.SetParameterValue("CompanyFax", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 29) ? "Show" : "Hide");
                            }
                            catch
                            {
                            }
                            try
                            {
                                rpt.SetParameterValue("CompanyFaxE", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 43) ? "Show" : "Hide");
                            }
                            catch
                            {
                            }
                            try
                            {
                                if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 43))
                                {
                                    rpt.ReportDefinition.ReportObjects["Text14"].Width = rpt.ReportDefinition.ReportObjects["Text14"].Width * 2;
                                    rpt.ReportDefinition.ReportObjects["Amount1"].Width = rpt.ReportDefinition.ReportObjects["Amount1"].Width * 2;
                                    if (base.Tag.ToString() != "0")
                                    {
                                        rpt.ReportDefinition.ReportObjects["Text14"].Left = rpt.ReportDefinition.ReportObjects["Text7"].Left;
                                        rpt.ReportDefinition.ReportObjects["Amount1"].Left = rpt.ReportDefinition.ReportObjects["Text7"].Left;
                                    }
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                rpt.SetParameterValue("IsCashCredit", VarGeneral.IsCashCredit ? "1" : "0");
                            }
                            catch
                            {
                            }
                            try
                            {
                                rpt.SetParameterValue("vDecimal", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? "1" : "0");
                            }
                            catch
                            {
                            }
                            try
                            {
                                rpt.SetParameterValue("IsTotWithTax", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 65) ? "1" : "0");
                            }
                            catch
                            {
                            }
                            try
                            {
                                (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                            }
                            catch
                            {
                            }
                            try
                            {
                                (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                            }
                            catch
                            {
                            }
                            rpt.SetParameterValue("CompanyPic", (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) && VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 35)) ? "Show" : "Hide");
                            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                            try
                            {
                                if (base.Tag.ToString() == "0")
                                {
                                    rpt.SetParameterValue("HDate", (!string.IsNullOrEmpty(_InvSetting.invGdADesc)) ? _InvSetting.invGdADesc : "شكرا\u064c لكم");
                                }
                                else
                                {
                                    rpt.SetParameterValue("HDate", (!string.IsNullOrEmpty(_InvSetting.invGdEDesc)) ? _InvSetting.invGdEDesc : "Thank you");
                                }
                            }
                            catch
                            {
                                rpt.SetParameterValue("HDate", "");
                            }
                            rpt.SetParameterValue("vSts", false);
                            rpt.SetParameterValue("vLines", 1);
                            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.LineDetailSts, this.vStr(VarGeneral.InvTyp)))
                            {
                                rpt.SetParameterValue("LineDetailNa", VarGeneral.Settings_Sys.LineDetailNameA);
                                rpt.SetParameterValue("LineDetailNa_Eng", VarGeneral.Settings_Sys.LineDetailNameE);
                            }
                            else
                            {
                                rpt.SetParameterValue("LineDetailNa", "");
                                rpt.SetParameterValue("LineDetailNa_Eng", "");
                            }
                            rpt.SetParameterValue("UserName", vUsrNmA);
                            rpt.SetParameterValue("BranchName", vBranchNmA);
                            rpt.SetParameterValue("UsrNamE", vUsrNmE);
                            rpt.SetParameterValue("BranchNameE", vBranchNmE);
                            rpt.SetParameterValue("UsrNamE", vUsrNmE);
                            rpt.SetParameterValue("BranchNameE", vBranchNmE);
                            rpt.SetParameterValue("InvNo", vInvNo);
                            rpt.SetParameterValue("Gdat", vGdat);
                            rpt.SetParameterValue("Hdat", vHdat);
                            rpt.SetParameterValue("InvId", vInvID);
                            rpt.SetParameterValue("vCash", vInvCash);
                            rpt.SetParameterValue("TaxNo", TaxNo);
                            rpt.SetParameterValue("vCustNo", vCustNo);
                            rpt.SetParameterValue("vCustNm", vCustNm);
                            try
                            {
                                if (VarGeneral._IsPOS || VarGeneral._IsWaiter)
                                {
                                    rpt.SetParameterValue("TableNo_", vTableNo);
                                    rpt.SetParameterValue("TableTyp_", vTableTyp);
                                    rpt.SetParameterValue("Waiter_", vWaiterNm);
                                    switch (orderTyp)
                                    {
                                        case "0":
                                            rpt.SetParameterValue("OrderTyp", (base.Tag.ToString() == "0") ? "محلي" : "Local");
                                            break;
                                        case "1":
                                            rpt.SetParameterValue("OrderTyp", (base.Tag.ToString() == "0") ? "سفري" : "Take Away");
                                            break;
                                        case "2":
                                            rpt.SetParameterValue("OrderTyp", (base.Tag.ToString() == "0") ? "توصيل" : "Delivery");
                                            break;
                                        default:
                                            rpt.SetParameterValue("OrderTyp", "");
                                            break;
                                    }
                                }
                                else
                                {
                                    rpt.SetParameterValue("TableNo_", "");
                                    rpt.SetParameterValue("TableTyp_", "");
                                    rpt.SetParameterValue("Waiter_", "");
                                    rpt.SetParameterValue("OrderTyp", "");
                                }
                            }
                            catch
                            {
                                rpt.SetParameterValue("TableNo_", "");
                                rpt.SetParameterValue("TableTyp_", "");
                                rpt.SetParameterValue("Waiter_", "");
                                rpt.SetParameterValue("OrderTyp", "");
                            }
                            try
                            {
                                if (string.IsNullOrEmpty(vInvID) || vInvID == "0")
                                {
                                    if (base.Tag.ToString() == "0")
                                    {
                                        rpt.ReportDefinition.ReportObjects["InvNo1"].Width = 2108;
                                        rpt.ReportDefinition.ReportObjects["InvNo1"].Left = 204;
                                    }
                                    else
                                    {
                                        rpt.ReportDefinition.ReportObjects["InvNo1"].Width = 2006;
                                        rpt.ReportDefinition.ReportObjects["InvNo1"].Left = 1360;
                                    }
                                }
                            }
                            catch
                            {
                            }
                            if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 35))
                            {
                                try { rpt.SetParameterValue("CATPrint", "True"); } catch { }
                            }
                            //try { rpt.SetParameterValue("CATPrint", "4False"); } catch { }

                            this.PrintSet(rpt, (int)_InvSetting.lnPg.Value, (_InvSetting.Orientation == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, _InvSetting.defSizePaper, _InvSetting.DefLines.Value, _InvSetting.defPrn, _InvSetting.hAs.Value, _InvSetting.hYs.Value, _InvSetting.hYm.Value, _InvSetting.hAl.Value);

                            continue;
                        } catch (Exception ex)
                        {
                            MessageBox.Show("الرجاء الاتصال بالدعم الفني وارفاق صورة للرساله"+ex.Message);
                        }
                    }
                    else
                    {
                        if (base.Tag.ToString() == "0")
                        {
                            try
                            {
                                if (VarGeneral.gUserName == "runsetting")
                                {
                                    if (File.Exists(Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", "").Trim() + "\\RepInvSal.rpt"))
                                    {
                                        this.MainCryRep.FileName = Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", "").Trim() + "\\RepInvSal.rpt";
                                    }
                                    else
                                    {
                                        this.MainCryRep = getdoc("InvAcc.Reports.RepInvSal");
                                    }
                                }
                                else if (File.Exists(Application.StartupPath + "\\Reps\\RepInvSal.rpt"))
                                {
                                    this.MainCryRep.FileName = Application.StartupPath + "\\Reps\\RepInvSal.rpt";
                                }
                                else
                                {
                                    this.MainCryRep = getdoc("InvAcc.Reports.RepInvSal");
                                }
                            }
                            catch
                            {
                                this.MainCryRep = getdoc("InvAcc.Reports.RepInvSal");
                            }
                        }
                        else
                        {
                            try
                            {
                                if (VarGeneral.gUserName == "runsetting")
                                {
                                    if (File.Exists(Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", "").Trim() + "\\RepInvSal.rpt"))
                                    {
                                        this.MainCryRep.FileName = Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", "").Trim() + "\\RepInvSal.rpt";
                                    }
                                    else
                                    {
                                        this.MainCryRep = getdoc("InvAcc.ReportsE.RepInvSal");
                                    }
                                }
                                else if (File.Exists(Application.StartupPath + "\\RepsE\\RepInvSal.rpt"))
                                {
                                    this.MainCryRep.FileName = Application.StartupPath + "\\RepsE\\RepInvSal.rpt";
                                }
                                else
                                {
                                    this.MainCryRep = getdoc("InvAcc.ReportsE.RepInvSal");
                                }
                            }
                            catch
                            {
                                this.MainCryRep = getdoc("InvAcc.ReportsE.RepInvSal");
                            }
                        }
                        try
                        {
                            vUsrNmA = VarGeneral.RepData.Tables[0].Rows[0]["UsrNamA"].ToString();
                        }
                        catch
                        {
                            vUsrNmA = "";
                        }
                        try
                        {
                            vUsrNmE = VarGeneral.RepData.Tables[0].Rows[0]["UsrNamE"].ToString();
                        }
                        catch
                        {
                            vUsrNmE = "";
                        }
                        try
                        {
                            vBranchNmA = VarGeneral.RepData.Tables[0].Rows[0]["Branch_Name"].ToString();
                        }
                        catch
                        {
                            vBranchNmA = "";
                        }
                        try
                        {
                            vBranchNmE = VarGeneral.RepData.Tables[0].Rows[0]["Branch_NameE"].ToString();
                        }
                        catch
                        {
                            vBranchNmE = "";
                        }
                        rpt = this.MainCryRep;
                        newData = new DataSet();
                        query = VarGeneral.RepData.Tables[0].Select(typ ? ("defPrn = '" + myData2[i] + "'") : ("ItmCat = " + myData[i]));
                        if (query.Count() <= 0)
                        {
                            continue;
                        }
                        newData.Tables.Add(query.CopyToDataTable());
                        rpt.SetDataSource(newData.Tables[0]);
                        this.listInfotb = this.db.StockInfoList();
                        this._Infotb = this.listInfotb[0];
                        for (int iiCnt = 0; iiCnt < this.listInfotb.Count; iiCnt++)
                        {
                            this._Infotb = this.listInfotb[iiCnt];
                            if ("lTrwes1" == this._Infotb.fldFlag.ToString())
                            {
                                if (VarGeneral.TString.ChkStatShow(this.permission.StopBanner, 0))
                                {
                                    rpt.SetParameterValue("CompanyNameE", (!VarGeneral.TString.ChkStatShow(this.permission.StopBanner, 1)) ? this._Infotb.fldValue : "");
                                }
                                else
                                {
                                    rpt.SetParameterValue("CompanyNameE", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? this._Infotb.fldValue : "");
                                }
                            }
                            else if ("lTrwes2" == this._Infotb.fldFlag.ToString())
                            {
                                if (VarGeneral.TString.ChkStatShow(this.permission.StopBanner, 0))
                                {
                                    rpt.SetParameterValue("CompanyAddressE", (!VarGeneral.TString.ChkStatShow(this.permission.StopBanner, 1)) ? this._Infotb.fldValue : "");
                                }
                                else
                                {
                                    rpt.SetParameterValue("CompanyAddressE", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? this._Infotb.fldValue : "");
                                }
                            }
                            else if ("lTrwes3" == this._Infotb.fldFlag.ToString())
                            {
                                if (VarGeneral.TString.ChkStatShow(this.permission.StopBanner, 0))
                                {
                                    rpt.SetParameterValue("CompanyTelE", (!VarGeneral.TString.ChkStatShow(this.permission.StopBanner, 1)) ? this._Infotb.fldValue : "");
                                }
                                else
                                {
                                    rpt.SetParameterValue("CompanyTelE", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? this._Infotb.fldValue : "");
                                }
                            }
                            else if ("lTrwes4" == this._Infotb.fldFlag.ToString())
                            {
                                if (VarGeneral.TString.ChkStatShow(this.permission.StopBanner, 0))
                                {
                                    rpt.SetParameterValue("CompanyFaxE", (!VarGeneral.TString.ChkStatShow(this.permission.StopBanner, 1)) ? this._Infotb.fldValue : "");
                                }
                                else
                                {
                                    rpt.SetParameterValue("CompanyFaxE", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? this._Infotb.fldValue : "");
                                }
                            }
                            else if ("rTrwes1" == this._Infotb.fldFlag.ToString())
                            {
                                if (VarGeneral.TString.ChkStatShow(this.permission.StopBanner, 0))
                                {
                                    rpt.SetParameterValue("CompanyName", (!VarGeneral.TString.ChkStatShow(this.permission.StopBanner, 1)) ? this._Infotb.fldValue : "");
                                }
                                else
                                {
                                    rpt.SetParameterValue("CompanyName", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? this._Infotb.fldValue : "");
                                }
                            }
                            else if ("rTrwes2" == this._Infotb.fldFlag.ToString())
                            {
                                if (VarGeneral.TString.ChkStatShow(this.permission.StopBanner, 0))
                                {
                                    rpt.SetParameterValue("CompanyAddress", (!VarGeneral.TString.ChkStatShow(this.permission.StopBanner, 1)) ? this._Infotb.fldValue : "");
                                }
                                else
                                {
                                    rpt.SetParameterValue("CompanyAddress", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? this._Infotb.fldValue : "");
                                }
                            }
                            else if ("rTrwes3" == this._Infotb.fldFlag.ToString())
                            {
                                if (VarGeneral.TString.ChkStatShow(this.permission.StopBanner, 0))
                                {
                                    rpt.SetParameterValue("CompanyTel", (!VarGeneral.TString.ChkStatShow(this.permission.StopBanner, 1)) ? this._Infotb.fldValue : "");
                                }
                                else
                                {
                                    rpt.SetParameterValue("CompanyTel", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? this._Infotb.fldValue : "");
                                }
                            }
                            else if ("rTrwes4" == this._Infotb.fldFlag.ToString())
                            {
                                if (VarGeneral.TString.ChkStatShow(this.permission.StopBanner, 0))
                                {
                                    rpt.SetParameterValue("CompanyFax", (!VarGeneral.TString.ChkStatShow(this.permission.StopBanner, 1)) ? this._Infotb.fldValue : "");
                                }
                                else
                                {
                                    rpt.SetParameterValue("CompanyFax", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? this._Infotb.fldValue : "");
                                }
                            }
                        }
                        try
                        {
                            if (!VarGeneral.TString.ChkStatShow(_InvSetting.InvInfo.TaxOptions, 1))
                            {
                                rpt.ReportDefinition.ReportObjects["TextTotTax"].ObjectFormat.EnableSuppress = true;
                                rpt.ReportDefinition.ReportObjects["TotTax1"].ObjectFormat.EnableSuppress = true;
                                rpt.ReportDefinition.ReportObjects["TextTaxHeader"].ObjectFormat.EnableSuppress = true;
                                rpt.ReportDefinition.ReportObjects["TaxNo1"].ObjectFormat.EnableSuppress = true;
                                rpt.ReportDefinition.Sections["DetailSection5"].SectionFormat.EnableSuppress = true;
                            }
                        }
                        catch
                        {
                        }
                        try
                        {
                            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 64))
                            {
                                rpt.ReportDefinition.Sections["DetailSection5"].SectionFormat.EnableSuppress = true;
                            }
                        }
                        catch
                        {
                        }
                        try
                        {
                            if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16))
                            {
                                rpt.ReportDefinition.Sections[3].ReportObjects["Line7"].ObjectFormat.EnableSuppress = true; rpt.ReportDefinition.Sections[3].ReportObjects["Text12"].ObjectFormat.EnableSuppress = true;
                                try
                                {
                                    rpt.ReportDefinition.Sections[3].ReportObjects["Text33"].ObjectFormat.EnableSuppress = true;
                                    rpt.ReportDefinition.Sections[3].ReportObjects["Line25"].ObjectFormat.EnableSuppress = true;

                                }
                                catch { }
                                rpt.ReportDefinition.Sections[3].ReportObjects["Text27"].Width = 1496;
                                rpt.ReportDefinition.Sections[3].ReportObjects["SerialKey1"].Width = 1496;
                                rpt.ReportDefinition.Sections[3].ReportObjects["Text27"].Left = 6494;
                                rpt.ReportDefinition.Sections[3].ReportObjects["SerialKey1"].Left = 6494;
                                try
                                {
                                    rpt.ReportDefinition.Sections[3].ReportObjects["Line7t"].ObjectFormat.EnableSuppress = true;
                                    rpt.ReportDefinition.Sections[3].ReportObjects["StoreNo1"].ObjectFormat.EnableSuppress = true;
                                }
                                catch
                                {
                                }
                            }
                        }
                        catch
                        {
                        }
                        try
                        {
                            rpt.SetParameterValue("CompanyFaxE", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 43) ? "Show" : "Hide");
                        }
                        catch
                        {
                        }
                        try
                        {
                            if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 43))
                            {
                                rpt.ReportDefinition.ReportObjects["Text14"].Width = rpt.ReportDefinition.ReportObjects["Text14"].Width * 2;
                                rpt.ReportDefinition.ReportObjects["Amount1"].Width = rpt.ReportDefinition.ReportObjects["Amount1"].Width * 2;
                                if (base.Tag.ToString() != "0")
                                {
                                    rpt.ReportDefinition.ReportObjects["Text14"].Left = rpt.ReportDefinition.ReportObjects["Text7"].Left;
                                    rpt.ReportDefinition.ReportObjects["Amount1"].Left = rpt.ReportDefinition.ReportObjects["Text7"].Left;
                                }
                            }
                        }
                        catch
                        {
                        }

                        try
                        {
                            rpt.SetParameterValue("IsCashCredit", VarGeneral.IsCashCredit ? "1" : "0");
                        }
                        catch
                        {
                        }
                        try
                        {
                            rpt.SetParameterValue("vDecimal", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? "1" : "0");
                        }
                        catch
                        {
                        }
                        try
                        {
                            rpt.SetParameterValue("IsTotWithTax", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 65) ? "1" : "0");
                        }
                        catch
                        {
                        }
                        try
                        {
                            (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                        }
                        catch
                        {
                        }
                        try
                        {
                            (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                        }
                        catch
                        {
                        }
                        rpt.SetParameterValue("StoreSts", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16) ? "Show" : "Hide");
                        rpt.SetParameterValue("CompanyPic", (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) && VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 35)) ? "Show" : "Hide");
                        rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                        rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                        rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : "");
                        rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : "");
                        rpt.SetParameterValue("vSts", false);
                        rpt.SetParameterValue("vLines", 1);
                        if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.LineDetailSts, this.vStr(VarGeneral.InvTyp)))
                        {
                            rpt.SetParameterValue("LineDetailNa", VarGeneral.Settings_Sys.LineDetailNameA);
                            rpt.SetParameterValue("LineDetailNa_Eng", VarGeneral.Settings_Sys.LineDetailNameE);
                        }
                        else
                        {
                            rpt.SetParameterValue("LineDetailNa", "");
                            rpt.SetParameterValue("LineDetailNa_Eng", "");
                        }
                        rpt.SetParameterValue("UserName", vUsrNmA);
                        rpt.SetParameterValue("BranchName", vBranchNmA);
                        rpt.SetParameterValue("UsrNamE", vUsrNmE);
                        rpt.SetParameterValue("BranchNameE", vBranchNmE);
                        rpt.SetParameterValue("UsrNamE", vUsrNmE);
                        rpt.SetParameterValue("BranchNameE", vBranchNmE);
                        try
                        {
                            if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 20))
                            {
                                rpt.ReportDefinition.ReportObjects["Line2"].ObjectFormat.EnableSuppress = true;
                                rpt.ReportDefinition.ReportObjects["Text27"].ObjectFormat.EnableSuppress = true;
                                try
                                {
                                    rpt.ReportDefinition.ReportObjects["Text39"].ObjectFormat.EnableSuppress = true;
                                    rpt.ReportDefinition.ReportObjects["Line26"].ObjectFormat.EnableSuppress = true;

                                }
                                catch
                                {
                                }
                                rpt.ReportDefinition.ReportObjects["SerialKey1"].ObjectFormat.EnableSuppress = true;
                                try
                                {
                                    rpt.ReportDefinition.Sections[3].ReportObjects["Line2t"].ObjectFormat.EnableSuppress = true;
                                }
                                catch
                                {
                                }
                                if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16))
                                {
                                    rpt.ReportDefinition.ReportObjects["Text13"].Width = 2924;
                                    rpt.ReportDefinition.ReportObjects["ItmDes1"].Width = 2924;
                                    rpt.ReportDefinition.ReportObjects["Text13"].Left = 7106;
                                    rpt.ReportDefinition.ReportObjects["ItmDes1"].Left = 7106;
                                }
                                else
                                {
                                    rpt.ReportDefinition.ReportObjects["Text13"].Width = 3536;
                                    rpt.ReportDefinition.ReportObjects["ItmDes1"].Width = 3536;
                                    rpt.ReportDefinition.ReportObjects["Text13"].Left = 6460;
                                    rpt.ReportDefinition.ReportObjects["ItmDes1"].Left = 6460;
                                }
                            }
                        }
                        catch
                        {
                        }
                        if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 19) || !VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 21))
                        {
                            if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 19) && VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 21))
                            {
                                try
                                {
                                    rpt.ReportDefinition.ReportObjects["Line22"].ObjectFormat.EnableSuppress = true; rpt.ReportDefinition.ReportObjects["Text28"].ObjectFormat.EnableSuppress = true;
                                    try
                                    {
                                        rpt.ReportDefinition.ReportObjects["Text40"].ObjectFormat.EnableSuppress = true;
                                        rpt.ReportDefinition.ReportObjects["Line13"].ObjectFormat.EnableSuppress = true;


                                    }
                                    catch
                                    {
                                    }
                                    rpt.ReportDefinition.ReportObjects["DatExper1"].ObjectFormat.EnableSuppress = true;
                                    rpt.ReportDefinition.ReportObjects["Text7"].Width = 1700;
                                    rpt.ReportDefinition.ReportObjects["Amount1"].Width = 1700;
                                    rpt.ReportDefinition.ReportObjects["Text7"].Left = 170;
                                    rpt.ReportDefinition.ReportObjects["Text32"].Left = 170;
                                    rpt.ReportDefinition.ReportObjects["Amount1"].Left = 170;
                                }
                                catch
                                {
                                }
                            }
                            else if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 19) && !VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 21))
                            {
                                try
                                {
                                    rpt.ReportDefinition.ReportObjects["Line3"].ObjectFormat.EnableSuppress = true; rpt.ReportDefinition.ReportObjects["Text29"].ObjectFormat.EnableSuppress = true;
                                    try
                                    {
                                        rpt.ReportDefinition.ReportObjects["Text41"].ObjectFormat.EnableSuppress = true;
                                        rpt.ReportDefinition.ReportObjects["Line14"].ObjectFormat.EnableSuppress = true;
                                    }
                                    catch
                                    {
                                    }
                                    rpt.ReportDefinition.ReportObjects["RunCod1"].ObjectFormat.EnableSuppress = true;
                                    try
                                    {
                                        rpt.ReportDefinition.ReportObjects["Line3t"].ObjectFormat.EnableSuppress = true;
                                    }
                                    catch
                                    {
                                    }
                                    rpt.ReportDefinition.ReportObjects["Text28"].Width = 1632;
                                    rpt.ReportDefinition.ReportObjects["Text40"].Width = 1632;
                                    rpt.ReportDefinition.ReportObjects["Text28"].Left = 1156;
                                    rpt.ReportDefinition.ReportObjects["Text40"].Left = 1156;
                                    rpt.ReportDefinition.ReportObjects["DatExper1"].Width = 1632;
                                    rpt.ReportDefinition.ReportObjects["DatExper1"].Left = 1156;
                                }
                                catch
                                {
                                }
                            }
                            else
                            {
                                try
                                {
                                    rpt.ReportDefinition.ReportObjects["Line3"].ObjectFormat.EnableSuppress = true;
                                    rpt.ReportDefinition.ReportObjects["Text29"].ObjectFormat.EnableSuppress = true;
                                    try
                                    {
                                        rpt.ReportDefinition.ReportObjects["Text41"].ObjectFormat.EnableSuppress = true;
                                        rpt.ReportDefinition.ReportObjects["Line14"].ObjectFormat.EnableSuppress = true;
                                    }
                                    catch
                                    {
                                    }
                                    rpt.ReportDefinition.ReportObjects["RunCod1"].ObjectFormat.EnableSuppress = true;
                                    try
                                    {
                                        rpt.ReportDefinition.ReportObjects["Line3t"].ObjectFormat.EnableSuppress = true;
                                    }
                                    catch
                                    {
                                    }
                                    rpt.ReportDefinition.ReportObjects["Line22"].ObjectFormat.EnableSuppress = true; rpt.ReportDefinition.ReportObjects["Text28"].ObjectFormat.EnableSuppress = true;
                                    try
                                    {
                                        rpt.ReportDefinition.ReportObjects["Text40"].ObjectFormat.EnableSuppress = true;
                                        rpt.ReportDefinition.ReportObjects["Line13"].ObjectFormat.EnableSuppress = true;


                                    }
                                    catch
                                    {
                                    }
                                    rpt.ReportDefinition.ReportObjects["DatExper1"].ObjectFormat.EnableSuppress = true;
                                    rpt.ReportDefinition.ReportObjects["Text7"].Width = 2618;

                                    rpt.ReportDefinition.ReportObjects["Text32"].Width = 2618;

                                    rpt.ReportDefinition.ReportObjects["Amount1"].Width = 2618;
                                    rpt.ReportDefinition.ReportObjects["Text7"].Left = 170;
                                    rpt.ReportDefinition.ReportObjects["Text32"].Left = 170;
                                    rpt.ReportDefinition.ReportObjects["Amount1"].Left = 170;
                                }
                                catch
                                {
                                }
                            }
                        }

                        if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 35))
                        {
                            try { rpt.SetParameterValue("CATPrint", "True"); } catch { }
                        }
                        if (_InvSetting.ISdirectPrinting || this.BarcodSts)
                        {

                            this.PrintSet(rpt, (int)_InvSetting.lnPg.Value, (_InvSetting.Orientation == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, _InvSetting.defSizePaper, _InvSetting.DefLines.Value, _InvSetting.defPrn, _InvSetting.hAs.Value, _InvSetting.hYs.Value, _InvSetting.hYm.Value, _InvSetting.hAl.Value);
                        }
                        else
                        {
                            this.setpagesetting(rpt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                VarGeneral.DebLog.writeLog("crystalReportViewe_RepShow:", ex, enable: true);

            }
        }
        private void STEP_2()
        {
            VarGeneral._dbshared = null;
            for (int i = 0; i < VarGeneral.RepData.Tables[0].Rows.Count; i++)
            {
                try
                {
                    int k = int.Parse(VarGeneral.RepData.Tables[0].Rows[i]["defPrn"].ToString());

                    VarGeneral.RepData.Tables[0].Rows[i]["defPrn"] = (VarGeneral.dbshared.T_Printers.Single(ksa => ksa.InvID == k && ksa.User_ID == VarGeneral.UserID).defPrn);

                }
                catch (Exception ex)
                { }
            }

            string vUsrNmA = string.Empty;
            string vBranchNmA = string.Empty;
            string vUsrNmE = string.Empty;
            string vBranchNmE = string.Empty;
            try
            {
                vUsrNmA = VarGeneral.RepData.Tables[0].Rows[0]["UsrNamA"].ToString();
            }
            catch
            {
                vUsrNmA = string.Empty;
            }
            try
            {
                vUsrNmE = VarGeneral.RepData.Tables[0].Rows[0]["UsrNamE"].ToString();
            }
            catch
            {
                vUsrNmE = string.Empty;
            }
            try
            {
                vBranchNmA = VarGeneral.RepData.Tables[0].Rows[0]["Branch_Name"].ToString();
            }
            catch
            {
                vBranchNmA = string.Empty;
            }
            try
            {
                vBranchNmE = VarGeneral.RepData.Tables[0].Rows[0]["Branch_NameE"].ToString();
            }
            catch
            {
                vBranchNmE = string.Empty;
            }
            VarGeneral.RepData.Tables[0].Rows.RemoveAt(0);
            for (int i = 0; i < VarGeneral.RepData.Tables[0].Rows.Count; i++)
            {
                try
                {
                    int k = int.Parse(VarGeneral.RepData.Tables[0].Rows[i]["defPrn"].ToString());

                    VarGeneral.RepData.Tables[0].Rows[i]["defPrn"] = (VarGeneral.dbshared.T_Printers.Single(ksa => ksa.InvID == k && ksa.User_ID == VarGeneral.UserID).defPrn);

                }
                catch { }
            }
            DataRowCollection qq = VarGeneral.RepData.Tables[0].Rows;
            List<int> myData = (from myRow in VarGeneral.RepData.Tables[0].AsEnumerable()
                                select myRow.Field<int>("ItmCat")).Distinct().ToList();
            List<string> myData2 = (from myRow in VarGeneral.RepData.Tables[0].AsEnumerable()
                                    select myRow.Field<string>("defPrn")).Distinct().ToList();
            myData2 = myData2.Where((string s) => !string.IsNullOrEmpty(s)).Distinct().ToList();

            for (int i = 0; i < (false ? myData2.Count() : myData.Count()); i++)
            {
                T_Printer _InvSetting = new T_Printer();
                _InvSetting = (false ? db.StockInvSettingInvoicesDefPrinter(VarGeneral.UserID, myData2[i]) : db.StockInvSettingInvoices(VarGeneral.UserID, myData[i]).InvpRINTERInfo);
                if (_InvSetting.InvInfo.PrintCat.Value)
                {
                    continue;
                }
                ids = _InvSetting.InvID;
                ReportDocument rpt;
                DataSet newData;
                DataRow[] query;
                if (_InvSetting.ISA4PaperType)
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        try
                        {
                            if (VarGeneral.gUserName == "runsetting")
                            {
                                if (File.Exists(Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvSal.rpt"))
                                {
                                    MainCryRep.FileName = Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvSal.rpt";
                                    addqrcode(MainCryRep);
                                }
                                else
                                {
                                    MainCryRep = getdoc("InvAcc.Reports.RepInvSal");
                                }
                            }
                            else if (File.Exists(Application.StartupPath + "\\Reps\\RepInvSal.rpt"))
                            {
                                MainCryRep.FileName = Application.StartupPath + "\\Reps\\RepInvSal.rpt";
                                addqrcode(MainCryRep);
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.Reports.RepInvSal");
                            }
                        }
                        catch
                        {
                            MainCryRep = getdoc("InvAcc.Reports.RepInvSal");
                        }
                    }
                    else
                    {
                        try
                        {
                            if (VarGeneral.gUserName == "runsetting")
                            {
                                if (File.Exists(Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvSal.rpt"))
                                {
                                    MainCryRep.FileName = Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvSal.rpt";
                                    addqrcode(MainCryRep);
                                }
                                else
                                {
                                    MainCryRep = getdoc("InvAcc.ReportsE.RepInvSal");
                                }
                            }
                            else if (File.Exists(Application.StartupPath + "\\RepsE\\RepInvSal.rpt"))
                            {
                                MainCryRep.FileName = Application.StartupPath + "\\RepsE\\RepInvSal.rpt";
                                addqrcode(MainCryRep);
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsE.RepInvSal");
                            }
                        }
                        catch
                        {
                            MainCryRep = getdoc("InvAcc.ReportsE.RepInvSal");
                        }
                    }
                    rpt = MainCryRep;
                    newData = new DataSet();
                    this.netResize1 = new Softgroup.NetResize.NetResize(this.components); this.netResize1.LabelsAutoEllipse = false;
                    this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
                    this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
                    this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
                    ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();

                    query = VarGeneral.RepData.Tables[0].Select(false ? ("defPrn = '" + myData2[i] + "'") : ("ItmCat = " + myData[i]));
                    if (query.Count() <= 0)
                    {
                        continue;
                    }
                    newData.Tables.Add(query.CopyToDataTable());
                    rpt.SetDataSource(newData.Tables[0]);
                    setpagesetting(rpt);
                    try
                    {
             setTarwisaatax(_InvSetting,rpt);}
                    catch
                    {
                    }
                    try
                    {
                        if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16))
                        {
                            rpt.ReportDefinition.Sections[3].ReportObjects["Line7"].ObjectFormat.EnableSuppress = true; rpt.ReportDefinition.Sections[3].ReportObjects["Text12"].ObjectFormat.EnableSuppress = true;
 try{ 
rpt.ReportDefinition.Sections[3].ReportObjects["Text33"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.Sections[3].ReportObjects["Line25"].ObjectFormat.EnableSuppress = true;
                                   
}catch{}
                                    rpt.ReportDefinition.Sections[3].ReportObjects["Text27"].Width = 1496;
                            rpt.ReportDefinition.Sections[3].ReportObjects["SerialKey1"].Width = 1496;
                            rpt.ReportDefinition.Sections[3].ReportObjects["Text27"].Left = 6494;
                            rpt.ReportDefinition.Sections[3].ReportObjects["SerialKey1"].Left = 6494;
                            try
                            {
                                rpt.ReportDefinition.Sections[3].ReportObjects["Line7t"].ObjectFormat.EnableSuppress = true;
rpt.ReportDefinition.Sections[3].ReportObjects["StoreNo1"].ObjectFormat.EnableSuppress = true;}
                            catch
                            {
                            }
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        rpt.SetParameterValue("IsCashCredit", VarGeneral.IsCashCredit ? "1" : "0");
                    }
                    catch
                    {
                    }
                    try
                    {
                        rpt.SetParameterValue("vDecimal", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? "1" : "0");
                    }
                    catch
                    {
                    }
                    try
                    {
                        rpt.SetParameterValue("IsTotWithTax", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 65) ? "1" : "0");
                    }
                    catch
                    {
                    }
                    try
                    {
                        (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                    }
                    catch
                    {
                    }
                    try
                    {
                        (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                    }
                    catch
                    {
                    }
                    rpt.SetParameterValue("StoreSts", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16) ? "Show" : "Hide");
                    if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                    {
                        rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                    }
                    else
                    {
                        rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                    }
                    rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                    rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                    rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
                    rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
                    rpt.SetParameterValue("vSts", false);
                    rpt.SetParameterValue("vLines", 1);
                    if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.LineDetailSts, vStr(VarGeneral.InvTyp)))
                    {
                        rpt.SetParameterValue("LineDetailNa", VarGeneral.Settings_Sys.LineDetailNameA);
                        rpt.SetParameterValue("LineDetailNa_Eng", VarGeneral.Settings_Sys.LineDetailNameE);
                    }
                    else
                    {
                        rpt.SetParameterValue("LineDetailNa", string.Empty);
                        rpt.SetParameterValue("LineDetailNa_Eng", string.Empty);
                    }
                    rpt.SetParameterValue("UserName", vUsrNmA);
                    rpt.SetParameterValue("BranchName", vBranchNmA);
                    rpt.SetParameterValue("UsrNamE", vUsrNmE);
                    rpt.SetParameterValue("BranchNameE", vBranchNmE);
                    rpt.SetParameterValue("UsrNamE", vUsrNmE);
                    rpt.SetParameterValue("BranchNameE", vBranchNmE);
                    try
                    {
                        if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 20))
                        {
                            rpt.ReportDefinition.ReportObjects["Line2"].ObjectFormat.EnableSuppress = true;
                             rpt.ReportDefinition.ReportObjects["Text27"].ObjectFormat.EnableSuppress = true;
try{
rpt.ReportDefinition.ReportObjects["Text39"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line26"].ObjectFormat.EnableSuppress = true;

}catch
{
}
                            rpt.ReportDefinition.ReportObjects["SerialKey1"].ObjectFormat.EnableSuppress = true;
                            try
                            {
                                rpt.ReportDefinition.Sections[3].ReportObjects["Line2t"].ObjectFormat.EnableSuppress = true;
                            }
                            catch
                            {
                            }
                            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16))
                            {
                                rpt.ReportDefinition.ReportObjects["Text13"].Width = 2924;
                                rpt.ReportDefinition.ReportObjects["ItmDes1"].Width = 2924;
                                rpt.ReportDefinition.ReportObjects["Text13"].Left = 7106;
                                rpt.ReportDefinition.ReportObjects["ItmDes1"].Left = 7106;
                            }
                            else
                            {
                                rpt.ReportDefinition.ReportObjects["Text13"].Width = 3536;
                                rpt.ReportDefinition.ReportObjects["ItmDes1"].Width = 3536;
                                rpt.ReportDefinition.ReportObjects["Text13"].Left = 6460;
                                rpt.ReportDefinition.ReportObjects["ItmDes1"].Left = 6460;
                            }
                        }
                    }
                    catch
                    {
                    }
                    if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 19) || !VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 21))
                    {
                        if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 19) && VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 21))
                        {
                            try
                            {
                                rpt.ReportDefinition.ReportObjects["Line22"].ObjectFormat.EnableSuppress = true;
                                try
                                {
                                    rpt.ReportDefinition.ReportObjects["Line22t"].ObjectFormat.EnableSuppress = true;
                                }
                                catch
                                {
                                } 
                                rpt.ReportDefinition.ReportObjects["Text28"].ObjectFormat.EnableSuppress = true;
try{
rpt.ReportDefinition.ReportObjects["Text40"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line13"].ObjectFormat.EnableSuppress = true;


}catch
{
}
                                rpt.ReportDefinition.ReportObjects["DatExper1"].ObjectFormat.EnableSuppress = true;
                                rpt.ReportDefinition.ReportObjects["Text7"].Width = 1700;
                                rpt.ReportDefinition.ReportObjects["Amount1"].Width = 1700;
                                rpt.ReportDefinition.ReportObjects["Text7"].Left = 170;
rpt.ReportDefinition.ReportObjects["Text32"].Left = 170;
                                rpt.ReportDefinition.ReportObjects["Amount1"].Left = 170;
                            }
                            catch
                            {
                            }
                        }
                        else if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 19) && !VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 21))
                        {
                            try
                            {
                                rpt.ReportDefinition.ReportObjects["Line3"].ObjectFormat.EnableSuppress = true; rpt.ReportDefinition.ReportObjects["Text29"].ObjectFormat.EnableSuppress = true;
 try{
rpt.ReportDefinition.ReportObjects["Text41"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line14"].ObjectFormat.EnableSuppress = true;
}catch
{
}rpt.ReportDefinition.ReportObjects["RunCod1"].ObjectFormat.EnableSuppress = true;
                                try
                                {
                                    rpt.ReportDefinition.ReportObjects["Line3t"].ObjectFormat.EnableSuppress = true;
                                }
                                catch
                                {
                                }
                                rpt.ReportDefinition.ReportObjects["Text28"].Width = 1632;
rpt.ReportDefinition.ReportObjects["Text40"].Width = 1632;
                                rpt.ReportDefinition.ReportObjects["Text28"].Left = 1156;
rpt.ReportDefinition.ReportObjects["Text40"].Left = 1156;
                                rpt.ReportDefinition.ReportObjects["DatExper1"].Width = 1632;
                                rpt.ReportDefinition.ReportObjects["DatExper1"].Left = 1156;
                            }
                            catch
                            {
                            }
                        }
                        else
                        {
                            try
                            {
                                rpt.ReportDefinition.ReportObjects["Line3"].ObjectFormat.EnableSuppress = true; rpt.ReportDefinition.ReportObjects["Text29"].ObjectFormat.EnableSuppress = true;
 try{
rpt.ReportDefinition.ReportObjects["Text41"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line14"].ObjectFormat.EnableSuppress = true;
}catch
{
}rpt.ReportDefinition.ReportObjects["RunCod1"].ObjectFormat.EnableSuppress = true;
                                try
                                {
                                    rpt.ReportDefinition.ReportObjects["Line3t"].ObjectFormat.EnableSuppress = true;
                                }
                                catch
                                {
                                }
                                rpt.ReportDefinition.ReportObjects["Line22"].ObjectFormat.EnableSuppress = true;
                                try
                                {
                                    rpt.ReportDefinition.ReportObjects["Line22t"].ObjectFormat.EnableSuppress = true;
                                }
                                catch
                                {
                                } rpt.ReportDefinition.ReportObjects["Text28"].ObjectFormat.EnableSuppress = true;
try{
rpt.ReportDefinition.ReportObjects["Text40"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line13"].ObjectFormat.EnableSuppress = true;


}catch
{
}
                                rpt.ReportDefinition.ReportObjects["DatExper1"].ObjectFormat.EnableSuppress = true;
                                rpt.ReportDefinition.ReportObjects["Text7"].Width = 2618;

rpt.ReportDefinition.ReportObjects["Text32"].Width = 2618;

                                rpt.ReportDefinition.ReportObjects["Amount1"].Width = 2618;
                                rpt.ReportDefinition.ReportObjects["Text7"].Left = 170;
rpt.ReportDefinition.ReportObjects["Text32"].Left = 170;
                                rpt.ReportDefinition.ReportObjects["Amount1"].Left = 170;
                            }
                            catch
                            {
                            }
                        }
                    }
                    if (db.StockInvSetting(VarGeneral.InvTyp).ISdirectPrinting || BarcodSts)
                    {
                        PrintSet(rpt, (int)_InvSetting.lnPg.Value, (_InvSetting.Orientation == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, _InvSetting.defSizePaper, _InvSetting.DefLines.Value, _InvSetting.defPrn, _InvSetting.hAs.Value, _InvSetting.hYs.Value, _InvSetting.hYm.Value, _InvSetting.hAl.Value);
                    }
                    else
                    {
                        setpagesetting(rpt);
                    }
                    continue;
                }
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    try
                    {
                        if (VarGeneral.gUserName == "runsetting")
                        {
                            if (File.Exists(Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvoicCachier.rpt"))
                            {
                                MainCryRep.FileName = Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvoicCachier.rpt";
                                addqrcode(MainCryRep);
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.Reports.RepInvoicCachier");
                            }
                        }
                        else if (File.Exists(Application.StartupPath + "\\Reps\\RepInvoicCachier.rpt"))
                        {
                            MainCryRep.FileName = Application.StartupPath + "\\Reps\\RepInvoicCachier.rpt";
                            addqrcode(MainCryRep);
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.Reports.RepInvoicCachier");
                        }
                    }
                    catch
                    {
                        MainCryRep = getdoc("InvAcc.Reports.RepInvoicCachier");
                    }
                }
                else
                {
                    try
                    {
                        if (VarGeneral.gUserName == "runsetting")
                        {
                            if (File.Exists(Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvoicCachier.rpt"))
                            {
                                MainCryRep.FileName = Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvoicCachier.rpt";
                                addqrcode(MainCryRep);
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.ReportsE.RepInvoicCachier");
                            }
                        }
                        else if (File.Exists(Application.StartupPath + "\\RepsE\\RepInvoicCachier.rpt"))
                        {
                            MainCryRep.FileName = Application.StartupPath + "\\RepsE\\RepInvoicCachier.rpt";
                            addqrcode(MainCryRep);
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsE.RepInvoicCachier");
                        }
                    }
                    catch
                    {
                        MainCryRep = getdoc("InvAcc.ReportsE.RepInvoicCachier");
                    }
                }
                string vInvNo = string.Empty;
                string vGdat = string.Empty;
                string vHdat = string.Empty;
                string vInvID = string.Empty;
                string vTableNo = string.Empty;
                string vTableTyp = string.Empty;
                string vWaiterNm = string.Empty;
                string orderTyp = string.Empty;
                try
                {
                    vInvNo = VarGeneral.RepData.Tables[0].Rows[1]["InvNo"].ToString();
                }
                catch
                {
                    vInvNo = string.Empty;
                }
                try
                {
                    vGdat = VarGeneral.RepData.Tables[0].Rows[1]["GDat"].ToString();
                }
                catch
                {
                    vGdat = string.Empty;
                }
                try
                {
                    vHdat = VarGeneral.RepData.Tables[0].Rows[1]["HDat"].ToString();
                }
                catch
                {
                    vHdat = string.Empty;
                }
                try
                {
                    vInvID = VarGeneral.RepData.Tables[0].Rows[1]["vID"].ToString();
                }
                catch
                {
                    vInvID = string.Empty;
                }
                if (VarGeneral.SSSLev == "R" || VarGeneral.SSSLev == "C" || VarGeneral.SSSLev == "H")
                {
                    try
                    {
                        vTableNo = db.StockRommID(db.StockInvHead(VarGeneral.InvTyp, vInvNo).RoomNo.Value).RomeNo.ToString();
                    }
                    catch
                    {
                        vTableNo = string.Empty;
                    }
                    try
                    {
                        orderTyp = VarGeneral.RepData.Tables[0].Rows[1]["OrderTyp"].ToString();
                    }
                    catch
                    {
                        orderTyp = string.Empty;
                    }
                    try
                    {
                        T_Room q = db.StockRommID(int.Parse(db.StockInvHead(VarGeneral.InvTyp, vInvNo).RoomNo.ToString()));
                        vTableTyp = ((q == null || string.IsNullOrEmpty(q.RomeNo.ToString())) ? ((VarGeneral.CurrentLang.ToString() == "0") ? "بدون طاولة" : "WithOut Table") : ((q.Type == 1) ? ((VarGeneral.CurrentLang.ToString() == "0") ? "طاولات العوائل" : "Families Tables") : ((q.Type == 2) ? ((VarGeneral.CurrentLang.ToString() == "0") ? "طاولات الشباب" : "Boys Tables") : ((q.Type == 3) ? ((VarGeneral.CurrentLang.ToString() == "0") ? "طاولات خارجية" : "Extrnal Tables") : ((q.Type != 4) ? ((VarGeneral.CurrentLang.ToString() == "0") ? "بدون طاولة" : "WithOut Table") : ((VarGeneral.CurrentLang.ToString() == "0") ? "طاولات أخرى" : "Other Tables"))))));
                    }
                    catch
                    {
                        vTableTyp = ((VarGeneral.CurrentLang.ToString() == "0") ? "بدون طاولة" : "WithOut Table");
                    }
                    try
                    {
                        vWaiterNm = ((!(vTableNo == string.Empty) && !(vTableNo == "0")) ? ((VarGeneral.CurrentLang.ToString() == "0") ? db.StockRommID(db.StockInvHead(VarGeneral.InvTyp, vInvNo).RoomNo.Value).T_Waiter.Arb_Des : db.StockRommID(db.StockInvHead(VarGeneral.InvTyp, vInvNo).RoomNo.Value).T_Waiter.Eng_Des) : string.Empty);
                    }
                    catch
                    {
                        vWaiterNm = string.Empty;
                    }
                }
                rpt = MainCryRep;
                newData = new DataSet();
                this.netResize1 = new Softgroup.NetResize.NetResize(this.components); this.netResize1.LabelsAutoEllipse = false;
                this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
                this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
                this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
                ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();

                query = VarGeneral.RepData.Tables[0].Select(false ? ("defPrn = '" + myData2[i] + "'") : ("ItmCat = " + myData[i]));
                if (query.Count() <= 0)
                {
                    continue;
                }
                newData.Tables.Add(query.CopyToDataTable());
                rpt.SetDataSource(newData.Tables[0]);
                listInfotb = db.StockInfoList();
                try
                {
         setTarwisaatax(_InvSetting,rpt);}
                catch
                {
                }
                try
                {
                    rpt.SetParameterValue("IsCashCredit", VarGeneral.IsCashCredit ? "1" : "0");
                }
                catch
                {
                }
                try
                {
                    rpt.SetParameterValue("vDecimal", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? "1" : "0");
                }
                catch
                {
                }
                try
                {
                    rpt.SetParameterValue("IsTotWithTax", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 65) ? "1" : "0");
                }
                catch
                {
                }
                try
                {
                    rpt.SetParameterValue("CompanyFax", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 29) ? "Show" : "Hide");
                }
                catch
                {
                }
                try
                {
                    (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
                }
                catch
                {
                }
                try
                {
                    (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
                }
                catch
                {
                }
                if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                {
                    rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
                }
                else
                {
                    rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
                }
                rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
                rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                try
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        rpt.SetParameterValue("HDate", (!string.IsNullOrEmpty(_InvSetting.invGdADesc)) ? _InvSetting.invGdADesc : "شكرا\u064c لكم");
                    }
                    else
                    {
                        rpt.SetParameterValue("HDate", (!string.IsNullOrEmpty(_InvSetting.invGdEDesc)) ? _InvSetting.invGdEDesc : "Thank you");
                    }
                }
                catch
                {
                    rpt.SetParameterValue("HDate", string.Empty);
                }
                rpt.SetParameterValue("vSts", false);
                rpt.SetParameterValue("vLines", 1);
                if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.LineDetailSts, vStr(VarGeneral.InvTyp)))
                {
                    rpt.SetParameterValue("LineDetailNa", VarGeneral.Settings_Sys.LineDetailNameA);
                    rpt.SetParameterValue("LineDetailNa_Eng", VarGeneral.Settings_Sys.LineDetailNameE);
                }
                else
                {
                    rpt.SetParameterValue("LineDetailNa", string.Empty);
                    rpt.SetParameterValue("LineDetailNa_Eng", string.Empty);
                }
                rpt.SetParameterValue("UserName", vUsrNmA);
                rpt.SetParameterValue("BranchName", vBranchNmA);
                rpt.SetParameterValue("UsrNamE", vUsrNmE);
                rpt.SetParameterValue("BranchNameE", vBranchNmE);
                rpt.SetParameterValue("UsrNamE", vUsrNmE);
                rpt.SetParameterValue("BranchNameE", vBranchNmE);
                rpt.SetParameterValue("InvNo", vInvNo);
                rpt.SetParameterValue("Gdat", vGdat);
                rpt.SetParameterValue("Hdat", vHdat);
                rpt.SetParameterValue("InvId", vInvID);
                try
                {
                    if (VarGeneral._IsPOS || VarGeneral._IsWaiter)
                    {
                        rpt.SetParameterValue("TableNo_", vTableNo);
                        rpt.SetParameterValue("TableTyp_", vTableTyp);
                        rpt.SetParameterValue("Waiter_", vWaiterNm);
                        switch (orderTyp)
                        {
                            case "0":
                                rpt.SetParameterValue("OrderTyp", (VarGeneral.CurrentLang.ToString() == "0") ? "محلي" : "Local");
                                break;
                            case "1":
                                rpt.SetParameterValue("OrderTyp", (VarGeneral.CurrentLang.ToString() == "0") ? "سفري" : "Take Away");
                                break;
                            case "2":
                                rpt.SetParameterValue("OrderTyp", (VarGeneral.CurrentLang.ToString() == "0") ? "توصيل" : "Delivery");
                                break;
                            default:
                                rpt.SetParameterValue("OrderTyp", string.Empty);
                                break;
                        }
                    }
                    else
                    {
                        rpt.SetParameterValue("TableNo_", string.Empty);
                        rpt.SetParameterValue("TableTyp_", string.Empty);
                        rpt.SetParameterValue("Waiter_", string.Empty);
                        rpt.SetParameterValue("OrderTyp", string.Empty);
                    }
                }
                catch
                {
                    rpt.SetParameterValue("TableNo_", string.Empty);
                    rpt.SetParameterValue("TableTyp_", string.Empty);
                    rpt.SetParameterValue("Waiter_", string.Empty);
                    rpt.SetParameterValue("OrderTyp", string.Empty);
                }
                try
                {
                    if (string.IsNullOrEmpty(vInvID) || vInvID == "0")
                    {
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            rpt.ReportDefinition.ReportObjects["InvNo1"].Width = 2108;
                            rpt.ReportDefinition.ReportObjects["InvNo1"].Left = 204;
                        }
                        else
                        {
                            rpt.ReportDefinition.ReportObjects["InvNo1"].Width = 2006;
                            rpt.ReportDefinition.ReportObjects["InvNo1"].Left = 1360;
                        }
                    }
                }
                catch
                {
                }
                try { rpt.SetParameterValue("CATPrint", "True"); } catch { }

                if (_InvSetting.ISdirectPrinting || BarcodSts)
                {
                    PrintSet(rpt, (int)_InvSetting.lnPg.Value, (_InvSetting.Orientation == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, _InvSetting.defSizePaper, _InvSetting.DefLines.Value, _InvSetting.defPrn, _InvSetting.hAs.Value, _InvSetting.hYs.Value, _InvSetting.hYm.Value, _InvSetting.hAl.Value);
                }
                else
                {
                    try
                    {
                        setpagesetting(rpt);
                    }
                    catch (Exception ex)
                    {
                        VarGeneral.DebLog.writeLog("crystalReportViewe_RepShow:", ex, enable: true);
                    }
                }
            }
        }

        private void STEP_Cachier_1()
        {
            Program.min();
            T_Printer _InvSetting = new T_Printer();
            for (int i = 0; i < VarGeneral.RepData.Tables[0].Rows.Count; i++)
            {
                if (VarGeneral.RepData.Tables[0].Rows[0][53].ToString() == "")
                {

                }
            }

            _InvSetting = db.StockPrinterSetting(VarGeneral.UserID, VarGeneral.InvTyp);
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                if (VarGeneral.itmDes == "HOLD")
                {
                    try
                    {
                        if (VarGeneral.gUserName == "runsetting")
                        {
                            if (File.Exists(Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvoicCachierHold.rpt"))
                            {
                                MainCryRep.FileName = Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvoicCachierHold.rpt";
                                addqrcode(MainCryRep);
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.Reports.RepInvoicCachierHold");
                            }
                        }
                        else if (File.Exists(Application.StartupPath + "\\Reps\\RepInvoicCachierHold.rpt"))
                        {
                            MainCryRep.FileName = Application.StartupPath + "\\Reps\\RepInvoicCachierHold.rpt";
                            addqrcode(MainCryRep);
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.Reports.RepInvoicCachierHold");
                        }
                    }
                    catch
                    {
                        MainCryRep = getdoc("InvAcc.Reports.RepInvoicCachierHold");
                    }
                }
                else
                {
                    try
                    {
                        if (VarGeneral.gUserName == "runsetting")
                        {
                            if (File.Exists(Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvoicCachier.rpt"))
                            {
                                MainCryRep.FileName = Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvoicCachier.rpt";
                                addqrcode(MainCryRep);
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.Reports.RepInvoicCachier");
                            }
                        }
                        else if (File.Exists(Application.StartupPath + "\\Reps\\RepInvoicCachier.rpt"))
                        {
                            MainCryRep.FileName = Application.StartupPath + "\\Reps\\RepInvoicCachier.rpt";
                            addqrcode(MainCryRep);
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.Reports.RepInvoicCachier");
                        }
                    }
                    catch
                    {
                        MainCryRep = getdoc("InvAcc.Reports.RepInvoicCachier");
                    }
                }
            }
            else if (VarGeneral.itmDes == "HOLD")
            {
                try
                {
                    if (VarGeneral.gUserName == "runsetting")
                    {
                        if (File.Exists(Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvoicCachierHold.rpt"))
                        {
                            MainCryRep.FileName = Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvoicCachierHold.rpt";
                            addqrcode(MainCryRep);
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsE.RepInvoicCachierHold");
                        }
                    }
                    else if (File.Exists(Application.StartupPath + "\\RepsE\\RepInvoicCachierHold.rpt"))
                    {
                        MainCryRep.FileName = Application.StartupPath + "\\RepsE\\RepInvoicCachierHold.rpt";
                        addqrcode(MainCryRep);
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsE.RepInvoicCachierHold");
                    }
                }
                catch
                {
                    MainCryRep = getdoc("InvAcc.ReportsE.RepInvoicCachierHold");
                }
            }
            else
            {
                try
                {
                    if (VarGeneral.gUserName == "runsetting")
                    {
                        if (File.Exists(Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvoicCachier.rpt"))
                        {
                            MainCryRep.FileName = Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvoicCachier.rpt";
                            addqrcode(MainCryRep);
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsE.RepInvoicCachier");
                        }
                    }
                    else if (File.Exists(Application.StartupPath + "\\RepsE\\RepInvoicCachier.rpt"))
                    {
                        MainCryRep.FileName = Application.StartupPath + "\\RepsE\\RepInvoicCachier.rpt";
                        addqrcode(MainCryRep);
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsE.RepInvoicCachier");
                    }
                }
                catch
                {
                    MainCryRep = getdoc("InvAcc.ReportsE.RepInvoicCachier");
                }
            }

            if (iscar)
            {
                if (iscarorder)
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        MainCryRep = getdoc("InvAcc.Reports.RepOrderCachierCar");
                    else
                        MainCryRep = getdoc("InvAcc.ReportsE.RepOrderCachierCar");
                }
                else
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        MainCryRep = getdoc("InvAcc.Reports.RepInvoicCachierCar");
                    else
                        MainCryRep = getdoc("InvAcc.ReportsE.RepInvoicCachierCar");
                }
            }

            ReportDocument rpt = MainCryRep;
      
            string vUsrNmA = string.Empty;
            string vBranchNmA = string.Empty;
            string vUsrNmE = string.Empty;
        
            string vBranchNmE = string.Empty;
            string vInvNo = string.Empty;
            string vGdat = string.Empty;
            string vHdat = string.Empty;
            string vInvID = string.Empty;
            string vInvCash = string.Empty;
            string vTableNo = string.Empty;
            string vTableTyp = string.Empty;
            string vWaiterNm = string.Empty;
            string orderTyp = " ";
            string TaxNo = string.Empty;
            string vCustNm = string.Empty;
            string vCustNo = string.Empty;
            string vNetwork = string.Empty;

            try
            {
                vUsrNmA = VarGeneral.RepData.Tables[0].Rows[0]["UsrNamA"].ToString();
            }
            catch
            {
                vUsrNmA = string.Empty;
            }
            try
            {
                vNetwork = VarGeneral.RepData.Tables[0].Rows[0]["InvCashe"].ToString();
            }
            catch
            {

            }
            try
            {
                vUsrNmE = VarGeneral.RepData.Tables[0].Rows[0]["UsrNamE"].ToString();
            }
            catch
            {
                vUsrNmE = string.Empty;
            }
            try
            {
                vBranchNmA = VarGeneral.RepData.Tables[0].Rows[0]["Branch_Name"].ToString();
            }
            catch
            {
                vBranchNmA = string.Empty;
            }
            try
            {
                vBranchNmE = VarGeneral.RepData.Tables[0].Rows[0]["Branch_NameE"].ToString();
            }
            catch
            {
                vBranchNmE = string.Empty;
            }
            try
            {
                vInvNo = VarGeneral.RepData.Tables[0].Rows[1]["InvNo"].ToString();
            }
            catch
            {
                vInvNo = string.Empty;
            }
            try
            {
                vCustNo = VarGeneral.RepData.Tables[0].Rows[1]["CusVenNo"].ToString();
            }
            catch
            {
                vCustNo = string.Empty;
            }
            try
            {
                vCustNm = VarGeneral.RepData.Tables[0].Rows[1]["CusVenNm"].ToString();
            }
            catch
            {
                vCustNm = string.Empty;
            }
            try
            {
                vGdat = VarGeneral.RepData.Tables[0].Rows[1]["GDat"].ToString();
            }
            catch
            {
                vGdat = string.Empty;
            }
            try
            {
                vHdat = VarGeneral.RepData.Tables[0].Rows[1]["HDat"].ToString();
            }
            catch
            {
                vHdat = string.Empty;
            }
            try
            {
                vInvID = VarGeneral.RepData.Tables[0].Rows[1]["vID"].ToString();
            }
            catch
            {
                vInvID = string.Empty;
            }
            try
            {
                vInvCash = VarGeneral.RepData.Tables[0].Rows[1]["InvCash"].ToString();
            }
            catch
            {
                vInvCash = string.Empty;
            }
            try
            {
                TaxNo = VarGeneral.RepData.Tables[0].Rows[1]["TaxAcc"].ToString();
            }
            catch
            {
                TaxNo = string.Empty;
            }
            if (VarGeneral.SSSLev == "R" || VarGeneral.SSSLev == "C" || VarGeneral.SSSLev == "H")
            {
                try
                {
                    vTableNo = db.StockRommID(db.StockInvHead(VarGeneral.InvTyp, vInvNo).RoomNo.Value).RomeNo.ToString();
                }
                catch
                {
                    vTableNo = string.Empty;
                }
                try
                {
                    orderTyp = VarGeneral.RepData.Tables[0].Rows[1]["OrderTyp"].ToString();
                }
                catch
                {
                    orderTyp = "";
                }
                try
                {
                    T_Room q = db.StockRommID(int.Parse(db.StockInvHead(VarGeneral.InvTyp, vInvNo).RoomNo.ToString()));
                    vTableTyp = ((q == null || string.IsNullOrEmpty(q.RomeNo.ToString())) ? ((VarGeneral.CurrentLang.ToString() == "0") ? "بدون طاولة" : "WithOut Table") : ((q.Type == 1) ? ((VarGeneral.CurrentLang.ToString() == "0") ? "طاولات العوائل" : "Families Tables") : ((q.Type == 2) ? ((VarGeneral.CurrentLang.ToString() == "0") ? "طاولات الشباب" : "Boys Tables") : ((q.Type == 3) ? ((VarGeneral.CurrentLang.ToString() == "0") ? "طاولات خارجية" : "Extrnal Tables") : ((q.Type != 4) ? ((VarGeneral.CurrentLang.ToString() == "0") ? "بدون طاولة" : "WithOut Table") : ((VarGeneral.CurrentLang.ToString() == "0") ? "طاولات أخرى" : "Other Tables"))))));
                }
                catch
                {
                    vTableTyp = ((VarGeneral.CurrentLang.ToString() == "0") ? "بدون طاولة" : "WithOut Table");
                }
                try
                {
                    vWaiterNm = ((!(vTableNo == string.Empty) && !(vTableNo == "0")) ? ((VarGeneral.CurrentLang.ToString() == "0") ? db.StockRommID(db.StockInvHead(VarGeneral.InvTyp, vInvNo).RoomNo.Value).T_Waiter.Arb_Des : db.StockRommID(db.StockInvHead(VarGeneral.InvTyp, vInvNo).RoomNo.Value).T_Waiter.Eng_Des) : string.Empty);
                }
                catch
                {
                    vWaiterNm = string.Empty;
                }
            }
      
            rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
            setTarwisaa(rpt);


            try
            {
                if (!VarGeneral.TString.ChkStatShow(_InvSetting.InvInfo.TaxOptions, 1))
                {
                    rpt.ReportDefinition.ReportObjects["TextTotTax"].ObjectFormat.EnableSuppress = true;
                    rpt.ReportDefinition.ReportObjects["TotTax1"].ObjectFormat.EnableSuppress = true;
                    rpt.ReportDefinition.ReportObjects["TextTaxHeader"].ObjectFormat.EnableSuppress = true;
                    rpt.ReportDefinition.ReportObjects["TaxNo1"].ObjectFormat.EnableSuppress = true;
                    rpt.ReportDefinition.Sections["DetailSection5"].SectionFormat.EnableSuppress = true;
                }
            }
            catch
            {
            }
            try
            {
                if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 64))
                {
                    rpt.ReportDefinition.Sections["DetailSection5"].SectionFormat.EnableSuppress = true;
                }
            }
            catch
            {
            }
            try
            {
                rpt.SetParameterValue("IsCashCredit", VarGeneral.IsCashCredit ? "1" : "0");
            }
            catch
            {
            }
            try
            {
                rpt.SetParameterValue("vDecimal", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? "1" : "0");
            }
            catch
            {
            }
            try
            {
                rpt.SetParameterValue("IsTotWithTax", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 65) ? "1" : "0");
            }
            catch
            {
            }
            try
            {
                rpt.SetParameterValue("CompanyFax", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 29) ? "Show" : "Hide");
            }
            catch
            {
            }
            try
            {
                (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
            }
            catch
            {
            }
            try
            {
                (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
            }
            catch
            {
            }
            if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
            {
                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
            }
            else
            {
                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
            }
            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
            try
            {
                if (Repvalue.Contains("Cash"))
                {
                    rpt.SetParameterValue("vNetwork", vNetwork);
                }
            }
            catch
            {

            }
            try
            {
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    rpt.SetParameterValue("HDate", (!string.IsNullOrEmpty(_InvSetting.invGdADesc)) ? _InvSetting.invGdADesc : "شكرا\u064c لكم");
                }
                else
                {
                    rpt.SetParameterValue("HDate", (!string.IsNullOrEmpty(_InvSetting.invGdEDesc)) ? _InvSetting.invGdEDesc : "Thank you");
                }
            }
            catch
            {
                rpt.SetParameterValue("HDate", string.Empty);
            }
            rpt.SetParameterValue("vSts", false);
            rpt.SetParameterValue("vLines", 1);
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.LineDetailSts, vStr(VarGeneral.InvTyp)))
            {
                rpt.SetParameterValue("LineDetailNa", VarGeneral.Settings_Sys.LineDetailNameA);
                rpt.SetParameterValue("LineDetailNa_Eng", VarGeneral.Settings_Sys.LineDetailNameE);
            }
            else
            {
                rpt.SetParameterValue("LineDetailNa", string.Empty);
                rpt.SetParameterValue("LineDetailNa_Eng", string.Empty);
            }
            rpt.SetParameterValue("UserName", vUsrNmA);
            rpt.SetParameterValue("BranchName", vBranchNmA);
            rpt.SetParameterValue("UsrNamE", vUsrNmE);
            rpt.SetParameterValue("BranchNameE", vBranchNmE);
            rpt.SetParameterValue("UsrNamE", vUsrNmE);
            rpt.SetParameterValue("BranchNameE", vBranchNmE);
            rpt.SetParameterValue("InvNo", vInvNo);
            rpt.SetParameterValue("Gdat", vGdat);
            rpt.SetParameterValue("Hdat", vHdat);
            rpt.SetParameterValue("InvId", vInvID);
            rpt.SetParameterValue("vCash", vInvCash);
            rpt.SetParameterValue("TaxNo", TaxNo);
            rpt.SetParameterValue("vCustNo", vCustNo);
            rpt.SetParameterValue("vCustNm", vCustNm);
            try
            {
                if (VarGeneral._IsPOS || VarGeneral._IsWaiter)
                {
                    rpt.SetParameterValue("TableNo_", vTableNo);
                    rpt.SetParameterValue("TableTyp_", vTableTyp);
                    rpt.SetParameterValue("Waiter_", vWaiterNm);
                    switch (orderTyp)
                    {
                        case "0":
                            rpt.SetParameterValue("OrderTyp", (VarGeneral.CurrentLang.ToString() == "0") ? "محلي" : "Local");
                            break;
                        case "1":
                            rpt.SetParameterValue("OrderTyp", (VarGeneral.CurrentLang.ToString() == "0") ? "سفري" : "Take Away");
                            break;
                        case "2":
                            rpt.SetParameterValue("OrderTyp", (VarGeneral.CurrentLang.ToString() == "0") ? "توصيل" : "Delivery");
                            break;
                        default:
                            rpt.SetParameterValue("OrderTyp", string.Empty);
                            break;
                    }
                }
                else
                {
                    rpt.SetParameterValue("TableNo_", string.Empty);
                    rpt.SetParameterValue("TableTyp_", string.Empty);
                    rpt.SetParameterValue("Waiter_", string.Empty);
                    rpt.SetParameterValue("OrderTyp", string.Empty);
                }
            }
            catch
            {
                rpt.SetParameterValue("TableNo_", string.Empty);
                rpt.SetParameterValue("TableTyp_", string.Empty);
                rpt.SetParameterValue("Waiter_", string.Empty);
                rpt.SetParameterValue("OrderTyp", string.Empty);
            }
            try
            {
                if (string.IsNullOrEmpty(vInvID) || vInvID == "0")
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        rpt.ReportDefinition.ReportObjects["InvNo1"].Width = 2108;
                        rpt.ReportDefinition.ReportObjects["InvNo1"].Left = 204;
                    }
                    else
                    {
                        rpt.ReportDefinition.ReportObjects["InvNo1"].Width = 2006;
                        rpt.ReportDefinition.ReportObjects["InvNo1"].Left = 1360;
                    }
                }
            }
            catch
            {
            }
            if (printOrderNo)
            {
                try
                {
                    try
                    {
                        rpt.SetParameterValue("CompanyFax", "Hide");
                        rpt.SetParameterValue("CompanyFaxE", "Hide");
                        rpt.SetParameterValue("LineDetailNa", string.Empty);
                        rpt.SetParameterValue("LineDetailNa_Eng", string.Empty);
                    }
                    catch
                    {
                    }
                    rpt.ReportDefinition.Sections["Section3"].SectionFormat.EnableSuppress = true;
                    try
                    {
                        rpt.ReportDefinition.ReportObjects["Box2"].ObjectFormat.EnableSuppress = true;
                        rpt.ReportDefinition.ReportObjects["Line29"].ObjectFormat.EnableSuppress = true;
                        rpt.ReportDefinition.ReportObjects["Text13"].ObjectFormat.EnableSuppress = true;
                        rpt.ReportDefinition.ReportObjects["Text11"].ObjectFormat.EnableSuppress = true;
                        rpt.ReportDefinition.ReportObjects["Text10"].ObjectFormat.EnableSuppress = true;
                        rpt.ReportDefinition.ReportObjects["Text7"].ObjectFormat.EnableSuppress = true;
                        rpt.ReportDefinition.ReportObjects["Text14"].ObjectFormat.EnableSuppress = true;
                    }
                    catch
                    {
                    }
                    rpt.ReportDefinition.Sections["DetailSection3"].SectionFormat.EnableSuppress = true;
                    rpt.ReportDefinition.Sections["DetailSection1"].SectionFormat.EnableSuppress = true;
                    rpt.ReportDefinition.Sections["DetailSection2"].SectionFormat.EnableSuppress = true;
                    rpt.ReportDefinition.Sections["Section4"].SectionFormat.EnableSuppress = true;
                    rpt.ReportDefinition.Sections["Section5"].SectionFormat.EnableSuppress = true;
                }
                catch
                {
                }

            }
            try
            {
                rpt.SetParameterValue("CATPrint", "True");
            }
            catch { }

            if (_InvSetting.ISdirectPrinting || BarcodSts)
            {
                PrintSet(rpt, (int)_InvSetting.lnPg.Value, (_InvSetting.Orientation == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, _InvSetting.defSizePaper, _InvSetting.DefLines.Value, VarGeneral.Print_set_Gen_Stat ? VarGeneral.prnt_doc_Gen.PrinterSettings.PrinterName : _InvSetting.defPrn, _InvSetting.hAs.Value, _InvSetting.hYs.Value, _InvSetting.hYm.Value, _InvSetting.hAl.Value);
            }
            else
            {
                setpagesetting(rpt);
            }
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 54) && !printOrderNo && (VarGeneral.SSSLev == "R" || VarGeneral.SSSLev == "C" || VarGeneral.SSSLev == "H"))
            {
                printOrderNo = true;
                STEP_Cachier_1();
            }
        }
        void setTotalsRpt(T_Printer _InvSetting, ReportDocument rpt)

        {


            try
            {
                if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 19) || !VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 21))
                {
                    if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 19) && VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 21))
                    {
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            rpt.ReportDefinition.ReportObjects["Line22"].ObjectFormat.EnableSuppress = true;
                            try
                            {
                                rpt.ReportDefinition.ReportObjects["Line22t"].ObjectFormat.EnableSuppress = true;
                            }
                            catch
                            {
                            } rpt.ReportDefinition.ReportObjects["Text28"].ObjectFormat.EnableSuppress = true;
try{
rpt.ReportDefinition.ReportObjects["Text40"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line13"].ObjectFormat.EnableSuppress = true;


}catch
{
}
                            rpt.ReportDefinition.ReportObjects["DatExper1"].ObjectFormat.EnableSuppress = true;
                            rpt.ReportDefinition.ReportObjects["Text7"].Width = 1700;
                            rpt.ReportDefinition.ReportObjects["Amount1"].Width = 1700;
                            rpt.ReportDefinition.ReportObjects["Text7"].Left = 170;
rpt.ReportDefinition.ReportObjects["Text32"].Left = 170;
                            rpt.ReportDefinition.ReportObjects["Amount1"].Left = 170;
                        }
                        else
                        {
                            rpt.ReportDefinition.ReportObjects["Line22"].ObjectFormat.EnableSuppress = true;
                            try
                            {
                                rpt.ReportDefinition.ReportObjects["Line22t"].ObjectFormat.EnableSuppress = true;
                            }
                            catch
                            {
                            } rpt.ReportDefinition.ReportObjects["Text28"].ObjectFormat.EnableSuppress = true;
try{
rpt.ReportDefinition.ReportObjects["Text40"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line13"].ObjectFormat.EnableSuppress = true;


}catch
{
}
                            rpt.ReportDefinition.ReportObjects["DatExper1"].ObjectFormat.EnableSuppress = true;
                            rpt.ReportDefinition.ReportObjects["Text7"].Width = 1768;
                            rpt.ReportDefinition.ReportObjects["Amount1"].Width = 1768;
                            rpt.ReportDefinition.ReportObjects["Text7"].Left = 9282;
                            rpt.ReportDefinition.ReportObjects["Amount1"].Left = 9282;
                        }
                    }
                    else if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 19) && !VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 21))
                    {
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            rpt.ReportDefinition.ReportObjects["Line3"].ObjectFormat.EnableSuppress = true;
                            rpt.ReportDefinition.ReportObjects["Text29"].ObjectFormat.EnableSuppress = true;
 try{
rpt.ReportDefinition.ReportObjects["Text41"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line14"].ObjectFormat.EnableSuppress = true;
}catch
{
}rpt.ReportDefinition.ReportObjects["RunCod1"].ObjectFormat.EnableSuppress = true;
                            try
                            {
                                rpt.ReportDefinition.ReportObjects["Line3t"].ObjectFormat.EnableSuppress = true;
                            }
                            catch
                            {
                            }
                            rpt.ReportDefinition.ReportObjects["Text28"].Width = 1632;
rpt.ReportDefinition.ReportObjects["Text40"].Width = 1632;
                            rpt.ReportDefinition.ReportObjects["Text28"].Left = 1156;
rpt.ReportDefinition.ReportObjects["Text40"].Left = 1156;
                            rpt.ReportDefinition.ReportObjects["DatExper1"].Width = 1632;
                            rpt.ReportDefinition.ReportObjects["DatExper1"].Left = 1156;
                        }
                        else
                        {
                            rpt.ReportDefinition.ReportObjects["Line3"].ObjectFormat.EnableSuppress = true; 
                            
                            rpt.ReportDefinition.ReportObjects["Text29"].ObjectFormat.EnableSuppress = true;
 try{
rpt.ReportDefinition.ReportObjects["Text41"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line14"].ObjectFormat.EnableSuppress = true;
}catch
{
}rpt.ReportDefinition.ReportObjects["RunCod1"].ObjectFormat.EnableSuppress = true;
                            try
                            {
                                rpt.ReportDefinition.ReportObjects["Line3t"].ObjectFormat.EnableSuppress = true;
                            }
                            catch
                            {
                            }
                            rpt.ReportDefinition.ReportObjects["Text28"].Width = 1632;
rpt.ReportDefinition.ReportObjects["Text40"].Width = 1632;
                            rpt.ReportDefinition.ReportObjects["Text28"].Left = 8364;
                            rpt.ReportDefinition.ReportObjects["DatExper1"].Width = 1632;
                            rpt.ReportDefinition.ReportObjects["DatExper1"].Left = 8364;
                        }
                    }
                    else if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        rpt.ReportDefinition.ReportObjects["Line3"].ObjectFormat.EnableSuppress = true; rpt.ReportDefinition.ReportObjects["Text29"].ObjectFormat.EnableSuppress = true;
 try{
rpt.ReportDefinition.ReportObjects["Text41"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line14"].ObjectFormat.EnableSuppress = true;
}catch
{
}rpt.ReportDefinition.ReportObjects["RunCod1"].ObjectFormat.EnableSuppress = true;
                        try
                        {
                            rpt.ReportDefinition.ReportObjects["Line3t"].ObjectFormat.EnableSuppress = true;
                        }
                        catch
                        {
                        }
                        rpt.ReportDefinition.ReportObjects["Line22"].ObjectFormat.EnableSuppress = true;
                        try
                        {
                            rpt.ReportDefinition.ReportObjects["Line22t"].ObjectFormat.EnableSuppress = true;
                        }
                        catch
                        {
                        } rpt.ReportDefinition.ReportObjects["Text28"].ObjectFormat.EnableSuppress = true;
try{
rpt.ReportDefinition.ReportObjects["Text40"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line13"].ObjectFormat.EnableSuppress = true;


}catch
{
}
                        rpt.ReportDefinition.ReportObjects["DatExper1"].ObjectFormat.EnableSuppress = true;
                        rpt.ReportDefinition.ReportObjects["Text7"].Width = 2618;

rpt.ReportDefinition.ReportObjects["Text32"].Width = 2618;

                        rpt.ReportDefinition.ReportObjects["Amount1"].Width = 2618;
                        rpt.ReportDefinition.ReportObjects["Text7"].Left = 170;
rpt.ReportDefinition.ReportObjects["Text32"].Left = 170;
                        rpt.ReportDefinition.ReportObjects["Amount1"].Left = 170;
                    }
                    else
                    {
                        rpt.ReportDefinition.ReportObjects["Line3"].ObjectFormat.EnableSuppress = true; rpt.ReportDefinition.ReportObjects["Text29"].ObjectFormat.EnableSuppress = true;
 try{
rpt.ReportDefinition.ReportObjects["Text41"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line14"].ObjectFormat.EnableSuppress = true;
}catch
{
}rpt.ReportDefinition.ReportObjects["RunCod1"].ObjectFormat.EnableSuppress = true;
                        try
                        {
                            rpt.ReportDefinition.ReportObjects["Line3t"].ObjectFormat.EnableSuppress = true;
                        }
                        catch
                        {
                        }
                        rpt.ReportDefinition.ReportObjects["Line22"].ObjectFormat.EnableSuppress = true;
                        try
                        {
                            rpt.ReportDefinition.ReportObjects["Line22t"].ObjectFormat.EnableSuppress = true;
                        }
                        catch
                        {
                        } rpt.ReportDefinition.ReportObjects["Text28"].ObjectFormat.EnableSuppress = true;
try{
rpt.ReportDefinition.ReportObjects["Text40"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line13"].ObjectFormat.EnableSuppress = true;


}catch
{
}
                        rpt.ReportDefinition.ReportObjects["DatExper1"].ObjectFormat.EnableSuppress = true;
                        rpt.ReportDefinition.ReportObjects["Text7"].Width = 2618;

rpt.ReportDefinition.ReportObjects["Text32"].Width = 2618;

                        rpt.ReportDefinition.ReportObjects["Amount1"].Width = 2618;
                        rpt.ReportDefinition.ReportObjects["Text7"].Left = 8330;
                        rpt.ReportDefinition.ReportObjects["Amount1"].Left = 8330;
                    }
                }
            }
            catch
            {
            }

        }
        void setTarwisaatax(T_Printer _InvSetting,ReportDocument rpt)
        {
            if (!VarGeneral.TString.ChkStatShow(_InvSetting.InvInfo.TaxOptions, 1))
            {
                rpt.ReportDefinition.ReportObjects["LineTax"].ObjectFormat.EnableSuppress = true;
                rpt.ReportDefinition.ReportObjects["TextTax"].ObjectFormat.EnableSuppress = true;
                rpt.ReportDefinition.ReportObjects["TaxValue1"].ObjectFormat.EnableSuppress = true;
                try
                {
                    rpt.ReportDefinition.ReportObjects["LineTaxt"].ObjectFormat.EnableSuppress = true;
                }
                catch
                {
                }
                rpt.ReportDefinition.ReportObjects["TextTotTax"].ObjectFormat.EnableSuppress = true;
                rpt.ReportDefinition.ReportObjects["TotTax1"].ObjectFormat.EnableSuppress = true;
                rpt.ReportDefinition.ReportObjects["TextTaxHeader"].ObjectFormat.EnableSuppress = true;
                rpt.ReportDefinition.ReportObjects["TaxAcc1"].ObjectFormat.EnableSuppress = true;
                rpt.ReportDefinition.ReportObjects["TextTaxSpace"].ObjectFormat.EnableSuppress = true;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    rpt.ReportDefinition.ReportObjects["Text9"].Width = 1326;
                    rpt.ReportDefinition.ReportObjects["Price1"].Width = 1326;
                    rpt.ReportDefinition.ReportObjects["Text9"].Left = 3536;
                    rpt.ReportDefinition.ReportObjects["Price1"].Left = 3536;
                }
                else
                {
                    rpt.ReportDefinition.ReportObjects["Text9"].Width = 1292;
                    rpt.ReportDefinition.ReportObjects["Price1"].Width = 1292;
                    rpt.ReportDefinition.ReportObjects["Text9"].Left = 6358;
                    rpt.ReportDefinition.ReportObjects["Price1"].Left = 6358;
                }
            }

        }
        private void STEP_1()
        {
            T_Printer _InvSetting = new T_Printer();
            _InvSetting = db.StockPrinterSetting(VarGeneral.UserID, VarGeneral.InvTyp);
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                try
                {
                    if (VarGeneral.gUserName == "runsetting")
                    {
                        if (File.Exists(Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim().Replace(Environment.MachineName + "\\", string.Empty)
                            .Trim() + "\\RepInvSal.rpt"))
                        {
                            MainCryRep.FileName = Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim().Replace(Environment.MachineName + "\\", string.Empty)
                                .Trim() + "\\RepInvSal.rpt"; addqrcode(MainCryRep);
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.Reports.RepInvSal");
                        }
                    }
                    else if (File.Exists(Application.StartupPath + "\\Reps\\RepInvSal.rpt"))
                    {
                        MainCryRep.FileName = Application.StartupPath + "\\Reps\\RepInvSal.rpt"; addqrcode(MainCryRep);
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.Reports.RepInvSal");
                    }
                }
                catch
                {
                    MainCryRep = getdoc("InvAcc.Reports.RepInvSal");
                }
            }
            else
            {
                try
                {
                    if (VarGeneral.gUserName == "runsetting")
                    {
                        if (File.Exists(Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvSal.rpt"))
                        {
                            MainCryRep.FileName = Application.StartupPath + "\\RepsE\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\RepInvSal.rpt";
                            addqrcode(MainCryRep);
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.ReportsE.RepInvSal");
                        }
                    }
                    else if (File.Exists(Application.StartupPath + "\\RepsE\\RepInvSal.rpt"))
                    {
                        MainCryRep.FileName = Application.StartupPath + "\\RepsE\\RepInvSal.rpt";
                        addqrcode(MainCryRep);
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.ReportsE.RepInvSal");
                    }
                }
                catch
                {
                    MainCryRep = getdoc("InvAcc.ReportsE.RepInvSal");
                }
            }
            ReportDocument rpt = MainCryRep;
            string vUsrNmA = string.Empty;
            string vBranchNmA = string.Empty;
            string vUsrNmE = string.Empty;
            string vBranchNmE = string.Empty;
            try
            {
                vUsrNmA = VarGeneral.RepData.Tables[0].Rows[0]["UsrNamA"].ToString();
            }
            catch
            {
                vUsrNmA = string.Empty;
            }
            try
            {
                vUsrNmE = VarGeneral.RepData.Tables[0].Rows[0]["UsrNamE"].ToString();
            }
            catch
            {
                vUsrNmE = string.Empty;
            }
            try
            {
                vBranchNmA = VarGeneral.RepData.Tables[0].Rows[0]["Branch_Name"].ToString();
            }
            catch
            {
                vBranchNmA = string.Empty;
            }
            try
            {
                vBranchNmE = VarGeneral.RepData.Tables[0].Rows[0]["Branch_NameE"].ToString();
            }
            catch
            {
                vBranchNmE = string.Empty;
            }
            VarGeneral.RepData.Tables[0].Rows[0].Delete();
            rpt.SetDataSource(VarGeneral.RepData.Tables[0]);
       setTarwisaa(rpt);try
            {
     setTarwisaatax(_InvSetting,rpt);
            }
            catch
            {
            }
            try
            {
                if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16))
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        rpt.ReportDefinition.Sections[3].ReportObjects["Line7"].ObjectFormat.EnableSuppress = true; rpt.ReportDefinition.Sections[3].ReportObjects["Text12"].ObjectFormat.EnableSuppress = true;
 try{ 
rpt.ReportDefinition.Sections[3].ReportObjects["Text33"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.Sections[3].ReportObjects["Line25"].ObjectFormat.EnableSuppress = true;
                                   
}catch{}
                                    rpt.ReportDefinition.Sections[3].ReportObjects["Text27"].Width = 1496;
                        rpt.ReportDefinition.Sections[3].ReportObjects["SerialKey1"].Width = 1496;
                        rpt.ReportDefinition.Sections[3].ReportObjects["Text27"].Left = 6494;
                        rpt.ReportDefinition.Sections[3].ReportObjects["SerialKey1"].Left = 6494;
                        try
                        {
                            rpt.ReportDefinition.Sections[3].ReportObjects["Line7t"].ObjectFormat.EnableSuppress = true;
rpt.ReportDefinition.Sections[3].ReportObjects["StoreNo1"].ObjectFormat.EnableSuppress = true;}
                        catch
                        {
                        }
                    }
                    else
                    {
                        rpt.ReportDefinition.Sections[3].ReportObjects["Line7"].ObjectFormat.EnableSuppress = true; rpt.ReportDefinition.Sections[3].ReportObjects["Text12"].ObjectFormat.EnableSuppress = true;
 try{ 
rpt.ReportDefinition.Sections[3].ReportObjects["Text33"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.Sections[3].ReportObjects["Line25"].ObjectFormat.EnableSuppress = true;
                                   
}catch{}
                                    rpt.ReportDefinition.Sections[3].ReportObjects["Text27"].Width = 1496;
                        rpt.ReportDefinition.Sections[3].ReportObjects["SerialKey1"].Width = 1496;
                        rpt.ReportDefinition.Sections[3].ReportObjects["Text27"].Left = 3162;
                        rpt.ReportDefinition.Sections[3].ReportObjects["SerialKey1"].Left = 3162;
                        try
                        {
                            rpt.ReportDefinition.Sections[3].ReportObjects["Line7t"].ObjectFormat.EnableSuppress = true;

rpt.ReportDefinition.Sections[3].ReportObjects["StoreNo1"].ObjectFormat.EnableSuppress = true;}
                        catch
                        {
                        }
                    }
                }
            }
            catch
            {
            }
            try
            {
                rpt.SetParameterValue("IsCashCredit", VarGeneral.IsCashCredit ? "1" : "0");
            }
            catch
            {
            }
            try
            {
                rpt.SetParameterValue("vDecimal", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? "1" : "0");
            }
            catch
            {
            }
            try
            {
                rpt.SetParameterValue("IsTotWithTax", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 65) ? "1" : "0");
            }
            catch
            {
            }
            try
            {
                (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
            }
            catch
            {
            }
            try
            {
                (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
            }
            catch
            {
            }
            rpt.SetParameterValue("StoreSts", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16) ? "Show" : "Hide");
            if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
            {
                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
            }
            else
            {
                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
            }
            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
            rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : string.Empty);
            try
            {
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    rpt.SetParameterValue("HDate", (!string.IsNullOrEmpty(_InvSetting.invGdADesc)) ? _InvSetting.invGdADesc : "شكرا\u064c لكم");
                }
                else
                {
                    rpt.SetParameterValue("HDate", (!string.IsNullOrEmpty(_InvSetting.invGdEDesc)) ? _InvSetting.invGdEDesc : "Thank you");
                }
            }
            catch
            {
                rpt.SetParameterValue("HDate", string.Empty);
            }
            rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : string.Empty);
            rpt.SetParameterValue("vSts", false);
            rpt.SetParameterValue("vLines", 1);
            TopMost = false;
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.LineDetailSts, vStr(VarGeneral.InvTyp)))
            {
                rpt.SetParameterValue("LineDetailNa", VarGeneral.Settings_Sys.LineDetailNameA);
                rpt.SetParameterValue("LineDetailNa_Eng", VarGeneral.Settings_Sys.LineDetailNameE);
            }
            else
            {
                rpt.SetParameterValue("LineDetailNa", string.Empty);
                rpt.SetParameterValue("LineDetailNa_Eng", string.Empty);
            }
            rpt.SetParameterValue("UserName", vUsrNmA);
            rpt.SetParameterValue("BranchName", vBranchNmA);
            rpt.SetParameterValue("UsrNamE", vUsrNmE);
            rpt.SetParameterValue("BranchNameE", vBranchNmE);
            rpt.SetParameterValue("UsrNamE", vUsrNmE);
            rpt.SetParameterValue("BranchNameE", vBranchNmE);
            try
            {
                if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 20))
                {
                    rpt.ReportDefinition.ReportObjects["Line2"].ObjectFormat.EnableSuppress = true;
                     rpt.ReportDefinition.ReportObjects["Text27"].ObjectFormat.EnableSuppress = true;
try{
rpt.ReportDefinition.ReportObjects["Text39"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line26"].ObjectFormat.EnableSuppress = true;

}catch
{
}
                    rpt.ReportDefinition.ReportObjects["SerialKey1"].ObjectFormat.EnableSuppress = true;
                    try
                    {
                        rpt.ReportDefinition.Sections[3].ReportObjects["Line2t"].ObjectFormat.EnableSuppress = true;
                    }
                    catch
                    {
                    }
                    if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16))
                    {
                        rpt.ReportDefinition.ReportObjects["Text13"].Width = 2924;
                        rpt.ReportDefinition.ReportObjects["ItmDes1"].Width = 2924;
                        rpt.ReportDefinition.ReportObjects["Text13"].Left = 7106;
                        rpt.ReportDefinition.ReportObjects["ItmDes1"].Left = 7106;
                    }
                    else
                    {
                        rpt.ReportDefinition.ReportObjects["Text13"].Width = 3536;
                        rpt.ReportDefinition.ReportObjects["ItmDes1"].Width = 3536;
                        rpt.ReportDefinition.ReportObjects["Text13"].Left = 6460;
                        rpt.ReportDefinition.ReportObjects["ItmDes1"].Left = 6460;
                    }
                }
            }
            catch
            {
            }
            if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 19) || !VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 21))
            {
                if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 19) && VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 21))
                {
                    try
                    {
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            rpt.ReportDefinition.ReportObjects["Line22"].ObjectFormat.EnableSuppress = true;
                            try
                            {
                                rpt.ReportDefinition.ReportObjects["Line22t"].ObjectFormat.EnableSuppress = true;
                            }
                            catch
                            {
                            } rpt.ReportDefinition.ReportObjects["Text28"].ObjectFormat.EnableSuppress = true;
try{
rpt.ReportDefinition.ReportObjects["Text40"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line13"].ObjectFormat.EnableSuppress = true;


}catch
{
}
                            rpt.ReportDefinition.ReportObjects["DatExper1"].ObjectFormat.EnableSuppress = true;
                            rpt.ReportDefinition.ReportObjects["Text7"].Width = 1700;
                            rpt.ReportDefinition.ReportObjects["Amount1"].Width = 1700;
                            rpt.ReportDefinition.ReportObjects["Text7"].Left = 170;
rpt.ReportDefinition.ReportObjects["Text32"].Left = 170;
                            rpt.ReportDefinition.ReportObjects["Amount1"].Left = 170;
                        }
                        else
                        {
                            rpt.ReportDefinition.ReportObjects["Line22"].ObjectFormat.EnableSuppress = true;
                            try
                            {
                                rpt.ReportDefinition.ReportObjects["Line22t"].ObjectFormat.EnableSuppress = true;
                            }
                            catch
                            {
                            } rpt.ReportDefinition.ReportObjects["Text28"].ObjectFormat.EnableSuppress = true;
try{
rpt.ReportDefinition.ReportObjects["Text40"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line13"].ObjectFormat.EnableSuppress = true;


}catch
{
}
                            rpt.ReportDefinition.ReportObjects["DatExper1"].ObjectFormat.EnableSuppress = true;
                            rpt.ReportDefinition.ReportObjects["Text7"].Width = 1768;
                            rpt.ReportDefinition.ReportObjects["Amount1"].Width = 1768;
                            rpt.ReportDefinition.ReportObjects["Text7"].Left = 9282;
                            rpt.ReportDefinition.ReportObjects["Amount1"].Left = 9282;
                        }
                    }
                    catch
                    {
                    }
                }
                else if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 19) && !VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 21))
                {
                    try
                    {
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            rpt.ReportDefinition.ReportObjects["Line3"].ObjectFormat.EnableSuppress = true; rpt.ReportDefinition.ReportObjects["Text29"].ObjectFormat.EnableSuppress = true;
 try{
rpt.ReportDefinition.ReportObjects["Text41"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line14"].ObjectFormat.EnableSuppress = true;
}catch
{
}rpt.ReportDefinition.ReportObjects["RunCod1"].ObjectFormat.EnableSuppress = true;
                            try
                            {
                                rpt.ReportDefinition.ReportObjects["Line3t"].ObjectFormat.EnableSuppress = true;
                            }
                            catch
                            {
                            }
                            rpt.ReportDefinition.ReportObjects["Text28"].Width = 1632;
rpt.ReportDefinition.ReportObjects["Text40"].Width = 1632;
                            rpt.ReportDefinition.ReportObjects["Text28"].Left = 1156;
rpt.ReportDefinition.ReportObjects["Text40"].Left = 1156;
                            rpt.ReportDefinition.ReportObjects["DatExper1"].Width = 1632;
                            rpt.ReportDefinition.ReportObjects["DatExper1"].Left = 1156;
                        }
                        else
                        {
                            rpt.ReportDefinition.ReportObjects["Line3"].ObjectFormat.EnableSuppress = true; 
                            rpt.ReportDefinition.ReportObjects["Text29"].ObjectFormat.EnableSuppress = true;
 try{
rpt.ReportDefinition.ReportObjects["Text41"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line14"].ObjectFormat.EnableSuppress = true;
}catch
{
}rpt.ReportDefinition.ReportObjects["RunCod1"].ObjectFormat.EnableSuppress = true;
                            try
                            {
                                rpt.ReportDefinition.ReportObjects["Line3t"].ObjectFormat.EnableSuppress = true;
                            }
                            catch
                            {
                            }
                            rpt.ReportDefinition.ReportObjects["Text28"].Width = 1632;
rpt.ReportDefinition.ReportObjects["Text40"].Width = 1632;
                            rpt.ReportDefinition.ReportObjects["Text28"].Left = 8364;
                            rpt.ReportDefinition.ReportObjects["DatExper1"].Width = 1632;
                            rpt.ReportDefinition.ReportObjects["DatExper1"].Left = 8364;
                        }
                    }
                    catch
                    {
                    }
                }
                else
                {
                    try
                    {
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            rpt.ReportDefinition.ReportObjects["Line3"].ObjectFormat.EnableSuppress = true; rpt.ReportDefinition.ReportObjects["Text29"].ObjectFormat.EnableSuppress = true;
 try{
rpt.ReportDefinition.ReportObjects["Text41"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line14"].ObjectFormat.EnableSuppress = true;
}catch
{
}rpt.ReportDefinition.ReportObjects["RunCod1"].ObjectFormat.EnableSuppress = true;
                            try
                            {
                                rpt.ReportDefinition.ReportObjects["Line3t"].ObjectFormat.EnableSuppress = true;
                            }
                            catch
                            {
                            }
                            rpt.ReportDefinition.ReportObjects["Line22"].ObjectFormat.EnableSuppress = true;
                            try
                            {
                                rpt.ReportDefinition.ReportObjects["Line22t"].ObjectFormat.EnableSuppress = true;
                            }
                            catch
                            {
                            } rpt.ReportDefinition.ReportObjects["Text28"].ObjectFormat.EnableSuppress = true;
try{
rpt.ReportDefinition.ReportObjects["Text40"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line13"].ObjectFormat.EnableSuppress = true;


}catch
{
}
                            rpt.ReportDefinition.ReportObjects["DatExper1"].ObjectFormat.EnableSuppress = true;
                            rpt.ReportDefinition.ReportObjects["Text7"].Width = 2618;

rpt.ReportDefinition.ReportObjects["Text32"].Width = 2618;

                            rpt.ReportDefinition.ReportObjects["Amount1"].Width = 2618;
                            rpt.ReportDefinition.ReportObjects["Text7"].Left = 170;
rpt.ReportDefinition.ReportObjects["Text32"].Left = 170;
                            rpt.ReportDefinition.ReportObjects["Amount1"].Left = 170;
                        }
                        else
                        {
                            rpt.ReportDefinition.ReportObjects["Line3"].ObjectFormat.EnableSuppress = true; rpt.ReportDefinition.ReportObjects["Text29"].ObjectFormat.EnableSuppress = true;
 try{
rpt.ReportDefinition.ReportObjects["Text41"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line14"].ObjectFormat.EnableSuppress = true;
}catch
{
}rpt.ReportDefinition.ReportObjects["RunCod1"].ObjectFormat.EnableSuppress = true;
                            try
                            {
                                rpt.ReportDefinition.ReportObjects["Line3t"].ObjectFormat.EnableSuppress = true;
                            }
                            catch
                            {
                            }
                            rpt.ReportDefinition.ReportObjects["Line22"].ObjectFormat.EnableSuppress = true;
                            try
                            {
                                rpt.ReportDefinition.ReportObjects["Line22t"].ObjectFormat.EnableSuppress = true;
                            }
                            catch
                            {
                            } rpt.ReportDefinition.ReportObjects["Text28"].ObjectFormat.EnableSuppress = true;
try{
rpt.ReportDefinition.ReportObjects["Text40"].ObjectFormat.EnableSuppress = true;
 rpt.ReportDefinition.ReportObjects["Line13"].ObjectFormat.EnableSuppress = true;


}catch
{
}
                            rpt.ReportDefinition.ReportObjects["DatExper1"].ObjectFormat.EnableSuppress = true;
                            rpt.ReportDefinition.ReportObjects["Text7"].Width = 2618;

rpt.ReportDefinition.ReportObjects["Text32"].Width = 2618;

                            rpt.ReportDefinition.ReportObjects["Amount1"].Width = 2618;
                            rpt.ReportDefinition.ReportObjects["Text7"].Left = 8330;
                            rpt.ReportDefinition.ReportObjects["Amount1"].Left = 8330;
                        }
                    }
                    catch
                    {
                    }
                }
            }
            if (_InvSetting.ISdirectPrinting || BarcodSts)
            {
                PrintSet(rpt, (int)_InvSetting.lnPg.Value, (_InvSetting.Orientation == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, _InvSetting.defSizePaper, _InvSetting.DefLines.Value, VarGeneral.Print_set_Gen_Stat ? VarGeneral.prnt_doc_Gen.PrinterSettings.PrinterName : _InvSetting.defPrn, _InvSetting.hAs.Value, _InvSetting.hYs.Value, _InvSetting.hYm.Value, _InvSetting.hAl.Value);
            }
            else
            {
                setpagesetting(rpt);
            }
        }


        public class ColumnDictinary
        {
            public string JOb = string.Empty;
            public string NAtion = string.Empty;
            public int Tot = 0;

            public ColumnDictinary(int tot, string nAtion, string jOb)
            {
                Tot = tot;
                NAtion = nAtion;
                JOb = jOb;
            }
        }

        public class ColumnDictinarySNation
        {
            public string H1 = string.Empty;
            public string H2 = string.Empty;
            public string H3 = string.Empty;

            public ColumnDictinarySNation(string h1, string h2, string h3)
            {
                H1 = h1;
                H2 = h2;
                H3 = h3;
            }
        }

        public class familyPassport
        {
            public string BornDate = string.Empty;
            public string EnteryNo = string.Empty;
            public string EnteryPort = string.Empty;
            public string ID = string.Empty;
            public string IND = string.Empty;
            public string Link = string.Empty;
            public string name = string.Empty;
            public string PassEnd = string.Empty;
            public string PassNo = string.Empty;

            public familyPassport(string ind, string id, string nam, string borndate, string link, string passno, string passend, string enteryport, string enteryno)
            {
                IND = ind;
                ID = id;
                name = nam;
                BornDate = borndate;
                Link = link;
                PassNo = passno;
                PassEnd = passend;
                EnteryPort = enteryport;
                EnteryNo = enteryno;
            }
        }

        public class ColumnDictinaryPassport
        {
            public string PassportField = string.Empty;

            public ColumnDictinaryPassport(string vPassportField)
            {

                PassportField = vPassportField;
            }
        }

        public class FlexPrintDocument : PrintDocument
        {
            public FlexPrintDocument(ReportDocument MainCryRep)
            {
                MainCryRep.PrintOptions.ApplyPageMargins(new PageMargins((CacheManager.MarginPrint[0] != 0m) ? decimal.ToInt32(CacheManager.MarginPrint[0]) : 360, (CacheManager.MarginPrint[1] != 0m) ? decimal.ToInt32(CacheManager.MarginPrint[1]) : 360, (CacheManager.MarginPrint[0] != 0m) ? decimal.ToInt32(CacheManager.MarginPrint[2]) : 360, (CacheManager.MarginPrint[3] != 0m) ? decimal.ToInt32(CacheManager.MarginPrint[3]) : 360));
            }
        }
    }
}
