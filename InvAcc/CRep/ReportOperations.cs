using FastReport;
using FastReport.Utils;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace InvAcc
{
    class ReportOperations
    {
        private T_User permission = new T_User();
#pragma warning disable CS0169 // The field 'ReportOperations.printDialog1' is never used
        private PrintDialog printDialog1;
#pragma warning restore CS0169 // The field 'ReportOperations.printDialog1' is never used
        private T_InfoTb _Infotb = new T_InfoTb();
        Rate_DataDataContext dbc = new Rate_DataDataContext(VarGeneral.BranchRt);
        private List<T_InfoTb> listInfotb = new List<T_InfoTb>();
        public ReportOperations()
        {
            permission = dbc.Get_PermissionID(VarGeneral.UserID);
        }
        FastReport.Report Carprint()
        {
            FastReport.Report rr = new FastReport.Report();
            try
            {
                DataTable Rep, cats;
                Rep = TRep;

                Rep.TableName = "item1";
                cats = getcats(Rep);
                DataSet cd = new DataSet();

                cats.TableName = "CatTable1";
                cd.Tables.Add(Rep.Copy());
                cd.Tables.Add(cats.Copy());
                cd.WriteXml(Application.StartupPath + "\\multiple.xml");

                DataSet dsd = new DataSet();
                dsd.ReadXml(Application.StartupPath + "\\multiple.xml");


                rr.Load(getpath());
                try
                {
               rr=     Utilites.addqrcode(rr);
                }
                catch { }
                rr.RegisterData(dsd);
                rr.GetDataSource("CatTable1").Enabled = true;
                rr.GetDataSource("item1").Enabled = true;

            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Creat Car item Categories :", error, enable: true);
                MessageBox.Show("Creat Car item Categories : " + error.Message);
            }


            return rr;

        }

        private string getpath()
        {


            if (repval == "CustQutation")

                return Application.StartupPath + @"\Rpt\ReportsCar\CarRepOrder.frx";
            else

                return Application.StartupPath + @"\Rpt\ReportsCar\CarRepInvSal.frx";
        }


        List<T_CATEGORY> LCat;
        string getcatname(string i)
        {
            if (LCat == null) { LCat = db.T_CATEGORies.ToList<T_CATEGORY>(); }
            string s = "";
            var q = from k in LCat
                    where k.CAT_No == i.ToString()
                    select k;
            if (q.Count() > 0)
            {
                s = (VarGeneral.UserLang == 0 ? q.FirstOrDefault().Arb_Des : q.FirstOrDefault().Eng_Des);
            }
            return s;
        }
        public DataTable TRep;
        DataTable getcats(DataTable rr)
        {
            cats = new List<string>();
            DataTable ffss = new DataTable();
            DataColumn csa = new DataColumn("ItemName");
            ffss.Columns.Add(csa);
            int aa = 0;
            if (!rr.Columns.Contains("CatNmA"))
            {
                aa = 1;
                csa = new DataColumn("CatNmA");
                rr.Columns.Add(csa);

            }
            csa = new DataColumn("Type");
            ffss.Columns.Add(csa);
            csa = new DataColumn("Cat");
            ffss.Columns.Add(csa);
            csa = new DataColumn("Code");
            ffss.Columns.Add(csa);
            csa = new DataColumn("Flage");
            csa.DataType = typeof(bool);
            ffss.Columns.Add(csa);
            csa = new DataColumn("MultiFlag");
            csa.DataType = typeof(bool);
            ffss.Columns.Add(csa);
            ffss.TableName = "CatTable";
            List<T_Item> c = db.StockItemListcat();
            foreach (T_Item i in c)
            {
                DataRow r = ffss.NewRow();
                r[0] = (VarGeneral.UserLang == 0 ? i.Arb_Des : i.Eng_Des);
                r[2] = getcatname(i.ItmCat.ToString());
                if (aa == 1)
                {
                    for (int ia = 0; ia < rr.Rows.Count; ia++)
                    {

                        if (rr.Rows[ia]["ItmNo"].ToString() == i.Itm_No)

                        {
                            rr.Rows[ia]["CatNmA"] = r[2];
                        }
                    }

                }
                DataRow rd = Getrow(rr, i.Itm_No);
                if (rd != null)
                {

                    r[1] = rd["ItmUnt"].ToString();



                    r["Flage"] = true;
                    r["MultiFlag"] = true;
                    ffss.Rows.Add(r);


                }
                else
                {
                    r[1] = (VarGeneral.UserLang == 0 ? i.T_Unit.Arb_Des.ToString() : i.T_Unit.Eng_Des.ToString());



                    r["Flage"] = false;
                    r["MultiFlag"] = getMultiflage(i);
                   // ffss.Rows.Add(r);

                }


            }
            foreach (DataRow r in ffss.Rows)
            {
                if (cats.Contains(r[2].ToString()))
                {
                    r["MultiFlag"] = true;
                }
            }
            if (aa == 1)
                TRep = rr.Copy();
            return ffss;
        
        }

        private DataRow Getrow(DataTable ff, string itm_No)
        {
            foreach (DataRow rr in ff.Rows)
            {
                if (rr["ItmNo"].ToString() == itm_No)
                {
                    return rr;
                }
            }
            return null;
        }

        List<string> cats = new List<string>();
        public string repval = "";
        private bool getMultiflage(T_Item i)
        {


            int k = 0;
            if (i.Unit1.HasValue)
                k++;

            if (i.Unit2.HasValue)
                k++;
            if (i.Unit3.HasValue)
                k++;
            if (i.Unit4.HasValue)
                k++;
            if (i.Unit5.HasValue)
                k++;


            if (k > 1)
            {
                if (!cats.Contains((VarGeneral.UserLang==0?i.T_CATEGORY.Arb_Des: i.T_CATEGORY.Eng_Des)))
                    cats.Add((VarGeneral.UserLang == 0 ? i.T_CATEGORY.Arb_Des : i.T_CATEGORY.Eng_Des));
                return true;

            }
            else
                return false;

        }

        private bool getflage(string arb_Des, string un, DataTable r)
        {
            bool c = false;

            foreach (DataRow rr in r.Rows)
            {

                if (rr["ItmNo"].ToString() == arb_Des && rr["ItmUnt"].ToString() == un)
                {
                    c = true; break;
                }
            }
            return c;
        }

        public T_INVSETTING _InvSetting;
        Stock_DataDataContext db = new Stock_DataDataContext(VarGeneral.BranchCS);
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
        FastReport.Report rpt;
        public void setgeneralinfo()
        {
            DataRow Rep0 = VarGeneral.RepData.Tables[0].Rows[0];
            try
            {
                vUsrNmA = Rep0["UsrNamA"].ToString();
            }
            catch
            {
                vUsrNmA = "";
            }
            try
            {
                vUsrNmE = Rep0["UsrNamE"].ToString();
            }
            catch
            {
                vUsrNmE = "";
            }
            try
            {
                vBranchNmA = Rep0["Branch_Name"].ToString();
            }
            catch
            {
                vBranchNmA = "";
            }
            try
            {
                vBranchNmE = Rep0["Branch_NameE"].ToString();
            }
            catch
            {
                vBranchNmE = "";
            }

            VarGeneral.RepData.Tables[0].Rows[0].Delete();

        }
        public void setimages(string invid)
        {
            List<System.Drawing.Image> g = Utilites.GetImag2e(invid, 0);
            for (int i = 0; i < g.Count; i++)
            {

                if (g[i] != null)
                {
                    ReportPage page = new ReportPage();
                    rpt.Pages.Add(page);
                    page.CreateUniqueName();
                    //App data band
                    DataBand data = new DataBand();
                    //Add data band to page
                    page.Bands.Add(data);
                    data.CreateUniqueName();
                    data.Height = 500;
                    PictureObject pic = new PictureObject();
                    pic.Dock = DockStyle.Fill;
                    pic.Image = g[i];
                    pic.Parent = data; //Set picture parent object
                    pic.CreateUniqueName();
                }

            }

        }
        private void PrintSet(int vLines, string vPeaperNm, int vReplay, string _PrintNm, double _mergBottom, double _mergleft, double _mergRight, double _mergTop)
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
            try
            {
                if (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Substring(14) + "\\" + Environment.UserName + "\\" + repval + ".txt"))
                {
                    FileInfo file = new FileInfo(Application.StartupPath + "\\Reps\\" + VarGeneral.gServerName.Substring(14) + "\\" + Environment.UserName + "\\" + repval + ".txt");
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
                                    rpt.PrintSettings.Printer = _ListPrinter[iiCnt];
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

        }


        public void DirectPrint(string invid)
        {



        }
        public void showreport(string invid)
        {

            try
            {
                setgeneralinfo();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog(" setgeneralinfo:", error, enable: true);
                MessageBox.Show("setgeneralinfo: " + error.Message);
            }

            DataTable t = VarGeneral.RepData.Tables[0].Copy();
            rpt = Carprint();
            try
            {
                Reportshow();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Reportshow :", error, enable: true);
                MessageBox.Show("Reportshow: " + error.Message);
            }
            try
            {
                setimages(invid);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("setimages :", error, enable: true);
                MessageBox.Show("Setimages: " + error.Message);

            }

            if (_InvSetting.InvpRINTERInfo.nTyp.Substring(2, 1) == "1")
            {
                PrintSet(1, _InvSetting.defSizePaper, _InvSetting.InvpRINTERInfo.DefLines.Value, _InvSetting.defPrn, _InvSetting.InvpRINTERInfo.hAs.Value, _InvSetting.InvpRINTERInfo.hYs.Value, _InvSetting.InvpRINTERInfo.hYm.Value, _InvSetting.InvpRINTERInfo.hAl.Value);
                rpt.Print();
                return;
            }
            FrmReport frm = new FrmReport();
            rpt.Prepare();
            frm.WindowState = FormWindowState.Maximized;
            rpt.Show(frm);

            frm.ShowDialog();
            frm.BringToFront();

        }
        string vUsrNmA = "";
        string vBranchNmA = "";
        string vUsrNmE = "";
        string vBranchNmE = "";
        void Reportshow()
        {

            listInfotb = db.StockInfoList();
            _Infotb = listInfotb[0];
            try
            {
                for (int iiCnt = 0; iiCnt < listInfotb.Count; iiCnt++)
                {
                    _Infotb = listInfotb[iiCnt];
                    if ("lTrwes1" == _Infotb.fldFlag.ToString())
                    {
                        if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                        {
                            rpt.SetParameterValue("CompanyNameE", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? _Infotb.fldValue : "");
                        }
                        else
                        {
                            rpt.SetParameterValue("CompanyNameE", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? _Infotb.fldValue : "");
                        }
                    }
                    else if ("lTrwes2" == _Infotb.fldFlag.ToString())
                    {
                        if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                        {
                            rpt.SetParameterValue("CompanyAddressE", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? _Infotb.fldValue : "");
                        }
                        else
                        {
                            rpt.SetParameterValue("CompanyAddressE", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? _Infotb.fldValue : "");
                        }
                    }
                    else if ("lTrwes3" == _Infotb.fldFlag.ToString())
                    {
                        if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                        {
                            rpt.SetParameterValue("CompanyTelE", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? _Infotb.fldValue : "");
                        }
                        else
                        {
                            rpt.SetParameterValue("CompanyTelE", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? _Infotb.fldValue : "");
                        }
                    }
                    else if ("lTrwes4" == _Infotb.fldFlag.ToString())
                    {
                        if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                        {
                            rpt.SetParameterValue("CompanyFaxE", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? _Infotb.fldValue : "");
                        }
                        else
                        {
                            rpt.SetParameterValue("CompanyFaxE", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? _Infotb.fldValue : "");
                        }
                    }
                    else if ("rTrwes1" == _Infotb.fldFlag.ToString())
                    {
                        if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                        {
                            rpt.SetParameterValue("CompanyName", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? _Infotb.fldValue : "");
                        }
                        else
                        {
                            rpt.SetParameterValue("CompanyName", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? _Infotb.fldValue : "");
                        }
                    }
                    else if ("rTrwes2" == _Infotb.fldFlag.ToString())
                    {
                        if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                        {
                            rpt.SetParameterValue("CompanyAddress", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? _Infotb.fldValue : "");
                        }
                        else
                        {
                            rpt.SetParameterValue("CompanyAddress", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? _Infotb.fldValue : "");
                        }
                    }
                    else if ("rTrwes3" == _Infotb.fldFlag.ToString())
                    {
                        if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                        {
                            rpt.SetParameterValue("CompanyTel", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? _Infotb.fldValue : "");
                        }
                        else
                        {
                            rpt.SetParameterValue("CompanyTel", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? _Infotb.fldValue : "");
                        }
                    }
                    else if ("rTrwes4" == _Infotb.fldFlag.ToString())
                    {
                        if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                        {
                            rpt.SetParameterValue("CompanyFax", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? _Infotb.fldValue : "");
                        }
                        else
                        {
                            rpt.SetParameterValue("CompanyFax", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? _Infotb.fldValue : "");
                        }
                    }
                }
            }
            catch { }
            try
            {
                rpt.SetParameterValue("TaxOption", VarGeneral.TString.ChkStatShow(_InvSetting.TaxOptions, 1));

                //if (!VarGeneral.TString.ChkStatShow(_InvSetting.TaxOptions, 1))
                //{



                //    rpt.ReportDefinition.ReportObjects["LineTax"].ObjectFormat.EnableSuppress = true;
                //    rpt.ReportDefinition.ReportObjects["TextTax"].ObjectFormat.EnableSuppress = true;
                //    rpt.ReportDefinition.ReportObjects["TaxValue1"].ObjectFormat.EnableSuppress = true;
                //    try
                //    {
                //        rpt.ReportDefinition.ReportObjects["LineTaxt"].ObjectFormat.EnableSuppress = true;
                //    }
                //    catch
                //    {
                //    }
                //    rpt.ReportDefinition.ReportObjects["TextTotTax"].ObjectFormat.EnableSuppress = true;
                //    rpt.ReportDefinition.ReportObjects["TotTax1"].ObjectFormat.EnableSuppress = true;
                //    rpt.ReportDefinition.ReportObjects["TextTaxHeader"].ObjectFormat.EnableSuppress = true;
                //    rpt.ReportDefinition.ReportObjects["TaxAcc1"].ObjectFormat.EnableSuppress = true;
                //    rpt.ReportDefinition.ReportObjects["TextTaxSpace"].ObjectFormat.EnableSuppress = true;
                //    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                //    {
                //        rpt.ReportDefinition.ReportObjects["Text9"].Width = 1326;
                //        rpt.ReportDefinition.ReportObjects["Price1"].Width = 1326;
                //        rpt.ReportDefinition.ReportObjects["Text9"].Left = 3536;
                //        rpt.ReportDefinition.ReportObjects["Price1"].Left = 3536;
                //    }
                //    else
                //    {
                //        rpt.ReportDefinition.ReportObjects["Text9"].Width = 1292;
                //        rpt.ReportDefinition.ReportObjects["Price1"].Width = 1292;
                //        rpt.ReportDefinition.ReportObjects["Text9"].Left = 6358;
                //        rpt.ReportDefinition.ReportObjects["Price1"].Left = 6358;
                //    }
                //}
            }
            catch
            {
            }
            try
            {
                rpt.SetParameterValue("ShowStore", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16));
                //    if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16))
                //    {
                //        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                //        {
                //            rpt.ReportDefinition.Sections[3].ReportObjects["Line7"].ObjectFormat.EnableSuppress = true;
                //            rpt.ReportDefinition.Sections[3].ReportObjects["Text12"].ObjectFormat.EnableSuppress = true;
                //            rpt.ReportDefinition.Sections[3].ReportObjects["Text27"].Width = 1496;
                //            rpt.ReportDefinition.Sections[3].ReportObjects["SerialKey1"].Width = 1496;
                //            rpt.ReportDefinition.Sections[3].ReportObjects["Text27"].Left = 6494;
                //            rpt.ReportDefinition.Sections[3].ReportObjects["SerialKey1"].Left = 6494;
                //            try
                //            {
                //                rpt.ReportDefinition.Sections[3].ReportObjects["Line7t"].ObjectFormat.EnableSuppress = true;
                //            }
                //            catch
                //            {
                //            }
                //        }
                //        else
                //        {
                //            rpt.ReportDefinition.Sections[3].ReportObjects["Line7"].ObjectFormat.EnableSuppress = true;
                //            rpt.ReportDefinition.Sections[3].ReportObjects["Text12"].ObjectFormat.EnableSuppress = true;
                //            rpt.ReportDefinition.Sections[3].ReportObjects["Text27"].Width = 1496;
                //            rpt.ReportDefinition.Sections[3].ReportObjects["SerialKey1"].Width = 1496;
                //            rpt.ReportDefinition.Sections[3].ReportObjects["Text27"].Left = 3162;
                //            rpt.ReportDefinition.Sections[3].ReportObjects["SerialKey1"].Left = 3162;
                //            try
                //            {
                //                rpt.ReportDefinition.Sections[3].ReportObjects["Line7t"].ObjectFormat.EnableSuppress = true;
                //            }
                //            catch
                //            {
                //            }
                //        }
                //    }
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
                rpt.SetParameterValue("vDecimal", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49));
            }
            catch
            {
            }
            try
            {
                rpt.SetParameterValue("IsTotWithTax", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 65));
            }
            catch
            {
            }
            try
            {
                rpt.SetParameterValue("CostCenter", VarGeneral.CostCenterlbl);
            }
            catch
            {
            }
            try
            {
                rpt.SetParameterValue("Mndob", VarGeneral.Mndoblbl);
            }
            catch
            {
            }
            try
            {
                rpt.SetParameterValue("StoreSts", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16) ? "Show" : "Hide");
            }
            catch { }
            try
            {
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
                rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : "");
                rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : "");
                rpt.SetParameterValue("vSts", false);
                rpt.SetParameterValue("vLines", 1);
                if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.LineDetailSts, vStr(VarGeneral.InvTyp)))
                {
                    rpt.SetParameterValue("LineDetailNa", VarGeneral.Settings_Sys.LineDetailNameA);
                    rpt.SetParameterValue("LineDetailNa_Eng", VarGeneral.Settings_Sys.LineDetailNameE);
                }
                else
                {
                    rpt.SetParameterValue("LineDetailNa", "");
                    rpt.SetParameterValue("LineDetailNa_Eng", "");
                }
            }
            catch
            { }
            rpt.SetParameterValue("UserName", vUsrNmA);
            rpt.SetParameterValue("BranchName", vBranchNmA);
            rpt.SetParameterValue("UsrNamE", vUsrNmE);
            rpt.SetParameterValue("BranchNameE", vBranchNmE);
            try
            {
                rpt.SetParameterValue("ShowSerial", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 20));
                //if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 20))
                //{
                //    rpt.ReportDefinition.ReportObjects["Line2"].ObjectFormat.EnableSuppress = true;
                //    rpt.ReportDefinition.ReportObjects["Text27"].ObjectFormat.EnableSuppress = true;
                //    rpt.ReportDefinition.ReportObjects["SerialKey1"].ObjectFormat.EnableSuppress = true;
                //    try
                //    {
                //        rpt.ReportDefinition.Sections[3].ReportObjects["Line2t"].ObjectFormat.EnableSuppress = true;
                //    }
                //    catch
                //    {
                //    }
                //    if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16))
                //    {
                //        rpt.ReportDefinition.ReportObjects["Text13"].Width = 2924;
                //        rpt.ReportDefinition.ReportObjects["ItmDes1"].Width = 2924;
                //        rpt.ReportDefinition.ReportObjects["Text13"].Left = 7106;
                //        rpt.ReportDefinition.ReportObjects["ItmDes1"].Left = 7106;
                //    }
                //    else
                //    {
                //        rpt.ReportDefinition.ReportObjects["Text13"].Width = 3536;
                //        rpt.ReportDefinition.ReportObjects["ItmDes1"].Width = 3536;
                //        rpt.ReportDefinition.ReportObjects["Text13"].Left = 6460;
                //        rpt.ReportDefinition.ReportObjects["ItmDes1"].Left = 6460;
                //    }
                //}
            }
            catch
            {
            }
            try
            {
                rpt.SetParameterValue("ShowProductionNo", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 21));
                if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 19) || !VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 21))
                {
                    if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 19) && VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 21))
                    {
                        //    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                        //    {
                        //        rpt.ReportDefinition.ReportObjects["Line22"].ObjectFormat.EnableSuppress = true;
                        //        try
                        //        {
                        //            rpt.ReportDefinition.ReportObjects["Line22t"].ObjectFormat.EnableSuppress = true;
                        //        }
                        //        catch
                        //        {
                        //        }
                        //        rpt.ReportDefinition.ReportObjects["Text28"].ObjectFormat.EnableSuppress = true;
                        //        rpt.ReportDefinition.ReportObjects["DatExper1"].ObjectFormat.EnableSuppress = true;
                        //        rpt.ReportDefinition.ReportObjects["Text7"].Width = 1700;
                        //        rpt.ReportDefinition.ReportObjects["Amount1"].Width = 1700;
                        //        rpt.ReportDefinition.ReportObjects["Text7"].Left = 170;
                        //        rpt.ReportDefinition.ReportObjects["Amount1"].Left = 170;
                        //    }
                        //    else
                        //    {
                        //        rpt.ReportDefinition.ReportObjects["Line22"].ObjectFormat.EnableSuppress = true;
                        //        try
                        //        {
                        //            rpt.ReportDefinition.ReportObjects["Line22t"].ObjectFormat.EnableSuppress = true;
                        //        }
                        //        catch
                        //        {
                        //        }
                        //        rpt.ReportDefinition.ReportObjects["Text28"].ObjectFormat.EnableSuppress = true;
                        //        rpt.ReportDefinition.ReportObjects["DatExper1"].ObjectFormat.EnableSuppress = true;
                        //        rpt.ReportDefinition.ReportObjects["Text7"].Width = 1768;
                        //        rpt.ReportDefinition.ReportObjects["Amount1"].Width = 1768;
                        //        rpt.ReportDefinition.ReportObjects["Text7"].Left = 9282;
                        //        rpt.ReportDefinition.ReportObjects["Amount1"].Left = 9282;
                        //    }
                        //}
                        //else if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 19) && !VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 21))
                        //{
                        //    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                        //    {
                        //        rpt.ReportDefinition.ReportObjects["Line3"].ObjectFormat.EnableSuppress = true;
                        //        rpt.ReportDefinition.ReportObjects["Text29"].ObjectFormat.EnableSuppress = true;
                        //        rpt.ReportDefinition.ReportObjects["RunCod1"].ObjectFormat.EnableSuppress = true;
                        //        try
                        //        {
                        //            rpt.ReportDefinition.ReportObjects["Line3t"].ObjectFormat.EnableSuppress = true;
                        //        }
                        //        catch
                        //        {
                        //        }
                        //        rpt.ReportDefinition.ReportObjects["Text28"].Width = 1632;
                        //        rpt.ReportDefinition.ReportObjects["Text28"].Left = 1156;
                        //        rpt.ReportDefinition.ReportObjects["DatExper1"].Width = 1632;
                        //        rpt.ReportDefinition.ReportObjects["DatExper1"].Left = 1156;
                        //    }
                        //    else
                        //    {
                        //        rpt.ReportDefinition.ReportObjects["Line3"].ObjectFormat.EnableSuppress = true;
                        //        rpt.ReportDefinition.ReportObjects["Text29"].ObjectFormat.EnableSuppress = true;
                        //        rpt.ReportDefinition.ReportObjects["RunCod1"].ObjectFormat.EnableSuppress = true;
                        //        try
                        //        {
                        //            rpt.ReportDefinition.ReportObjects["Line3t"].ObjectFormat.EnableSuppress = true;
                        //        }
                        //        catch
                        //        {
                        //        }
                        //        rpt.ReportDefinition.ReportObjects["Text28"].Width = 1632;
                        //        rpt.ReportDefinition.ReportObjects["Text28"].Left = 8364;
                        //        rpt.ReportDefinition.ReportObjects["DatExper1"].Width = 1632;
                        //        rpt.ReportDefinition.ReportObjects["DatExper1"].Left = 8364;
                        //    }
                        //}
                        //else if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                        //{
                        //    rpt.ReportDefinition.ReportObjects["Line3"].ObjectFormat.EnableSuppress = true;
                        //    rpt.ReportDefinition.ReportObjects["Text29"].ObjectFormat.EnableSuppress = true;
                        //    rpt.ReportDefinition.ReportObjects["RunCod1"].ObjectFormat.EnableSuppress = true;
                        //    try
                        //    {
                        //        rpt.ReportDefinition.ReportObjects["Line3t"].ObjectFormat.EnableSuppress = true;
                        //    }
                        //    catch
                        //    {
                        //    }
                        //    rpt.ReportDefinition.ReportObjects["Line22"].ObjectFormat.EnableSuppress = true;
                        //    try
                        //    {
                        //        rpt.ReportDefinition.ReportObjects["Line22t"].ObjectFormat.EnableSuppress = true;
                        //    }
                        //    catch
                        //    {
                        //    }
                        //    rpt.ReportDefinition.ReportObjects["Text28"].ObjectFormat.EnableSuppress = true;
                        //    rpt.ReportDefinition.ReportObjects["DatExper1"].ObjectFormat.EnableSuppress = true;
                        //    rpt.ReportDefinition.ReportObjects["Text7"].Width = 2618;
                        //    rpt.ReportDefinition.ReportObjects["Amount1"].Width = 2618;
                        //    rpt.ReportDefinition.ReportObjects["Text7"].Left = 170;
                        //    rpt.ReportDefinition.ReportObjects["Amount1"].Left = 170;
                        //}
                        //else
                        //{
                        //    rpt.ReportDefinition.ReportObjects["Line3"].ObjectFormat.EnableSuppress = true;
                        //    rpt.ReportDefinition.ReportObjects["Text29"].ObjectFormat.EnableSuppress = true;
                        //    rpt.ReportDefinition.ReportObjects["RunCod1"].ObjectFormat.EnableSuppress = true;
                        //    try
                        //    {
                        //        rpt.ReportDefinition.ReportObjects["Line3t"].ObjectFormat.EnableSuppress = true;
                        //    }
                        //    catch
                        //    {
                        //    }
                        //    rpt.ReportDefinition.ReportObjects["Line22"].ObjectFormat.EnableSuppress = true;
                        //    try
                        //    {
                        //        rpt.ReportDefinition.ReportObjects["Line22t"].ObjectFormat.EnableSuppress = true;
                        //    }
                        //    catch
                        //    {
                        //    }
                        //    //rpt.ReportDefinition.ReportObjects["Text28"].ObjectFormat.EnableSuppress = true;
                        //    //rpt.ReportDefinition.ReportObjects["DatExper1"].ObjectFormat.EnableSuppress = true;
                        //    //rpt.ReportDefinition.ReportObjects["Text7"].Width = 2618;
                        //    //rpt.ReportDefinition.ReportObjects["Amount1"].Width = 2618;
                        //    //rpt.ReportDefinition.ReportObjects["Text7"].Left = 8330;
                        //    //rpt.ReportDefinition.ReportObjects["Amount1"].Left = 8330;
                    }
                }
            }
            catch
            {
            }

        }
    }
}
