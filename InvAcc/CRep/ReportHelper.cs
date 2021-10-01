//using ProShared.GeneralM;using ProShared;
//using ProShared.Stock_Data;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace InvAcc.CRep
//{
//    class ReportHelper
//    {
//        private T_InfoTb _Infotb = new T_InfoTb();
//        private T_User permission = new T_User();
//        void setparameteres()
//        {
//            Stock_DataDataContext db = new Stock_DataDataContext(VarGeneral.BranchCS);
//            Rate_DataDataContext dbc = new Rate_DataDataContext(VarGeneral.BranchRt);
//            List<T_InfoTb> listInfotb = db.StockInfoList();
//            _Infotb = listInfotb[0]; 
//            permission = dbc.Get_PermissionID(VarGeneral.UserID);
//            string vUsrNmA = "";
//            string vBranchNmA = "";
//            string vUsrNmE = "";
//            string vBranchNmE = "";
//            string vInvNo = "";
//            string vGdat = "";
//            string vHdat = "";
//            string vInvID = "";
//            string vInvCash = "";
//            string vTableNo = "";
//            string vTableTyp = "";
//            string vWaiterNm = "";
//            string orderTyp = " ";
//            string TaxNo = "";
//            string vCustNm = "";
//            string vCustNo = "";
//            string vNetwork = "";

//            try
//            {
//                vUsrNmA = VarGeneral.RepData.Tables[0].Rows[0]["UsrNamA"].ToString();
//            }
//            catch
//            {
//                vUsrNmA = "";
//            }
//            try
//            {
//                vNetwork = VarGeneral.RepData.Tables[0].Rows[0]["InvCashe"].ToString();
//            }
//            catch
//            {

//            }
//            try
//            {
//                vUsrNmE = VarGeneral.RepData.Tables[0].Rows[0]["UsrNamE"].ToString();
//            }
//            catch
//            {
//                vUsrNmE = "";
//            }
//            try
//            {
//                vBranchNmA = VarGeneral.RepData.Tables[0].Rows[0]["Branch_Name"].ToString();
//            }
//            catch
//            {
//                vBranchNmA = "";
//            }
//            try
//            {
//                vBranchNmE = VarGeneral.RepData.Tables[0].Rows[0]["Branch_NameE"].ToString();
//            }
//            catch
//            {
//                vBranchNmE = "";
//            }
//            try
//            {
//                vInvNo = VarGeneral.RepData.Tables[0].Rows[1]["InvNo"].ToString();
//            }
//            catch
//            {
//                vInvNo = "";
//            }
//            try
//            {
//                vCustNo = VarGeneral.RepData.Tables[0].Rows[1]["CusVenNo"].ToString();
//            }
//            catch
//            {
//                vCustNo = "";
//            }
//            try
//            {
//                vCustNm = VarGeneral.RepData.Tables[0].Rows[1]["CusVenNm"].ToString();
//            }
//            catch
//            {
//                vCustNm = "";
//            }
//            try
//            {
//                vGdat = VarGeneral.RepData.Tables[0].Rows[1]["GDat"].ToString();
//            }
//            catch
//            {
//                vGdat = "";
//            }
//            try
//            {
//                vHdat = VarGeneral.RepData.Tables[0].Rows[1]["HDat"].ToString();
//            }
//            catch
//            {
//                vHdat = "";
//            }
//            try
//            {
//                vInvID = VarGeneral.RepData.Tables[0].Rows[1]["vID"].ToString();
//            }
//            catch
//            {
//                vInvID = "";
//            }
//            try
//            {
//                vInvCash = VarGeneral.RepData.Tables[0].Rows[1]["InvCash"].ToString();
//            }
//            catch
//            {
//                vInvCash = "";
//            }
//            try
//            {
//                TaxNo = VarGeneral.RepData.Tables[0].Rows[1]["TaxAcc"].ToString();
//            }
//            catch
//            {
//                TaxNo = "";
//            }
//            if (VarGeneral.SSSLev == "R" || VarGeneral.SSSLev == "C" || VarGeneral.SSSLev == "H")
//            {
//                try
//                {
//                    vTableNo = db.StockRommID(db.StockInvHead(VarGeneral.InvTyp, vInvNo).RoomNo.Value).RomeNo.ToString();
//                }
//                catch
//                {
//                    vTableNo = "";
//                }
//                try
//                {
//                    orderTyp = VarGeneral.RepData.Tables[0].Rows[1]["OrderTyp"].ToString();
//                }
//                catch
//                {
//                    orderTyp = "";
//                }
//                try
//                {
//                    T_Room q = db.StockRommID(int.Parse(db.StockInvHead(VarGeneral.InvTyp, vInvNo).RoomNo.ToString()));
//                    vTableTyp = ((q == null || string.IsNullOrEmpty(q.RomeNo.ToString())) ? ((VarGeneral.CurrentLang.ToString() == "0") ? "بدون طاولة" : "WithOut Table") : ((q.Type == 1) ? ((VarGeneral.CurrentLang.ToString() == "0") ? "طاولات العوائل" : "Families Tables") : ((q.Type == 2) ? ((VarGeneral.CurrentLang.ToString() == "0") ? "طاولات الشباب" : "Boys Tables") : ((q.Type == 3) ? ((VarGeneral.CurrentLang.ToString() == "0") ? "طاولات خارجية" : "Extrnal Tables") : ((q.Type != 4) ? ((VarGeneral.CurrentLang.ToString() == "0") ? "بدون طاولة" : "WithOut Table") : ((VarGeneral.CurrentLang.ToString() == "0") ? "طاولات أخرى" : "Other Tables"))))));
//                }
//                catch
//                {
//                    vTableTyp = ((VarGeneral.CurrentLang.ToString() == "0") ? "بدون طاولة" : "WithOut Table");
//                }
//                try
//                {
//                    vWaiterNm = ((!(vTableNo == "") && !(vTableNo == "0")) ? ((VarGeneral.CurrentLang.ToString() == "0") ? db.StockRommID(db.StockInvHead(VarGeneral.InvTyp, vInvNo).RoomNo.Value).T_Waiter.Arb_Des : db.StockRommID(db.StockInvHead(VarGeneral.InvTyp, vInvNo).RoomNo.Value).T_Waiter.Eng_Des) : "");
//                }
//                catch
//                {
//                    vWaiterNm = "";
//                }
//            }
//            rpt.SetParameterValue("DTFrom", VarGeneral._DTFrom);
//            rpt.SetParameterValue("DTTo", VarGeneral._DTTo);
//            rpt.SetParameterValue("InvNo", vInvNo);
//            rpt.SetParameterValue("Gdat", vGdat);
//            rpt.SetParameterValue("Hdat", vHdat);
//            rpt.SetParameterValue("InvId", vInvID);
//            rpt.SetParameterValue("vCash", vInvCash);
//            rpt.SetParameterValue("TaxNo", TaxNo);
//            rpt.SetParameterValue("vCustNo", vCustNo);
//            rpt.SetParameterValue("vCustNm", vCustNm);
//            rpt.SetParameterValue("TableNo_", vTableNo);
//            rpt.SetParameterValue("TableTyp_", vTableTyp);
//            rpt.SetParameterValue("Waiter_", vWaiterNm);

//            rpt.SetParameterValue("UserName", vUsrNmA);
//            rpt.SetParameterValue("BranchName", vBranchNmA);
//            rpt.SetParameterValue("UsrNamE", vUsrNmE);
//            rpt.SetParameterValue("BranchNameE", vBranchNmE);

//            try
//            {
//                rpt.SetParameterValue("IsCashCredit", VarGeneral.IsCashCredit ? "1" : "0");
//            }
//            catch
//            {
//            }
//            try
//            {
//                rpt.SetParameterValue("vDecimal", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? "1" : "0");
//            }
//            catch
//            {
//            }
//            try
//            {
//                rpt.SetParameterValue("IsTotWithTax", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 65) ? "1" : "0");
//            }
//            catch
//            {
//            }
//            try
//            {
//                (rpt.ReportDefinition.ReportObjects["TextCostCenter"] as TextObject).Text = VarGeneral.CostCenterlbl;
//            }
//            catch
//            {
//            }
//            try
//            {
//                (rpt.ReportDefinition.ReportObjects["TextMndob"] as TextObject).Text = VarGeneral.Mndoblbl;
//            }
//            catch
//            {
//            }
//            rpt.SetParameterValue("StoreSts", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16) ? "Show" : "Hide");
//            if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
//            {
//                rpt.SetParameterValue("CompanyPic", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? "Show" : "Hide");
//            }
//            else
//            {
//                rpt.SetParameterValue("CompanyPic", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide");
//            }


//            rpt.SetParameterValue("vPage", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide");
//            rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
//            rpt.SetParameterValue("HDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : "");
//            rpt.SetParameterValue("GDate", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : "");
//            rpt.SetParameterValue("StoreSts", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 16) ? "Show" : "Hide");
//            rpt.SetParameterValue("LineDetailNa", VarGeneral.Settings_Sys.LineDetailNameA);
//            rpt.SetParameterValue("LineDetailNa_Eng", VarGeneral.Settings_Sys.LineDetailNameE);
//            rpt.SetParameterValue("CompanyNameE", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? _Infotb.fldValue : "");
//            rpt.SetParameterValue("CompanyNameE", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? _Infotb.fldValue : "");
//            rpt.SetParameterValue("CompanyAddressE", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? _Infotb.fldValue : "");
//            rpt.SetParameterValue("CompanyAddressE", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? _Infotb.fldValue : "");
//            rpt.SetParameterValue("CompanyTelE", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? _Infotb.fldValue : "");
//            rpt.SetParameterValue("CompanyTelE", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? _Infotb.fldValue : "");
//            rpt.SetParameterValue("CompanyFaxE", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? _Infotb.fldValue : "");
//            rpt.SetParameterValue("CompanyFaxE", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? _Infotb.fldValue : "");
//            rpt.SetParameterValue("CompanyName", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? _Infotb.fldValue : "");
//            rpt.SetParameterValue("CompanyName", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? _Infotb.fldValue : "");
//            rpt.SetParameterValue("CompanyAddress", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? _Infotb.fldValue : "");
//            rpt.SetParameterValue("CompanyAddress", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? _Infotb.fldValue : "");
//            rpt.SetParameterValue("CompanyTel", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? _Infotb.fldValue : "");
//            rpt.SetParameterValue("CompanyTel", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? _Infotb.fldValue : "");
//            rpt.SetParameterValue("CompanyFax", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? _Infotb.fldValue : "");
//            rpt.SetParameterValue("CompanyFax", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? _Infotb.fldValue : "");
//            rpt.SetParameterValue("vSts", VarGeneral.EmpDocType);
//            rpt.SetParameterValue("DT", VarGeneral.AutoAlarmitms[0] + " ");
//            rpt.SetParameterValue("AlarmName", VarGeneral.AutoAlarmitms[7] + " ");
//            rpt.SetParameterValue("Col_1", VarGeneral.AutoAlarmitms[1] + " ");
//            rpt.SetParameterValue("Col_2", VarGeneral.AutoAlarmitms[2] + " ");
//            rpt.SetParameterValue("Col_3", VarGeneral.AutoAlarmitms[3] + " ");
//            rpt.SetParameterValue("Col_4", VarGeneral.AutoAlarmitms[4] + " ");
//            rpt.SetParameterValue("Col_5", VarGeneral.AutoAlarmitms[5] + " ");
//            rpt.SetParameterValue("Col_6", VarGeneral.AutoAlarmitms[6] + " ");
//            rpt.SetParameterValue("CompanyFaxE", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 43) ? "Show" : "Hide");
//            rpt.SetParameterValue("CompanyPic", (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) && VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 34)) ? "Show" : "Hide");


//            rpt.SetParameterValue("vSts", false);
//            rpt.SetParameterValue("vLines", 1);


//            rpt.SetParameterValue("LineDetailNa", "");
//            rpt.SetParameterValue("LineDetailNa_Eng", "");

//            rpt.SetParameterValue("SSSLev", (VarGeneral.SSSLev == "G") ? "Show" : "Hide");
//            rpt.SetParameterValue("SSSLev", (VarGeneral.InvTyp == 23 || VarGeneral.InvTyp == 24) ? "Show" : "Hide");
//            rpt.SetParameterValue("vTitle", (VarGeneral.InvTyp == 23) ? "وارد مـن" : "محـرر لـ");
//            rpt.SetParameterValue("vTitle", (VarGeneral.InvTyp == 23) ? "Issued by" : "Editor");
//            rpt.SetParameterValue("SSSLev", "Show");
//            rpt.SetParameterValue("SSSLev", "Hide");
//            rpt.SetParameterValue("RepTyp", (repvalue == "RepPers_8" || repvalue == "RepPers_12") ? "تاريخ السكن" : "تاريخ المغادرة");
//            rpt.SetParameterValue("vRepTp", "0");
//            rpt.SetParameterValue("OldBalance", VarGeneral.itmDes);
//            rpt.SetParameterValue("DetailesSts", VarGeneral.itmDes);
//            rpt.SetParameterValue("ItmComm", -1);
//            rpt.SetParameterValue("ItmComm", VarGeneral.RepData.Tables[0].Compute("Sum(GadeNo)", ""));
//            rpt.SetParameterValue("CompanyFax", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 29) ? "Show" : "Hide");
//            rpt.SetParameterValue("vNetwork", vNetwork);
//            rpt.SetParameterValue("HDate", (!string.IsNullOrEmpty(_InvSetting.invGdADesc)) ? _InvSetting.invGdADesc : "شكرا\u064c لكم");
//            rpt.SetParameterValue("HDate", (!string.IsNullOrEmpty(_InvSetting.invGdEDesc)) ? _InvSetting.invGdEDesc : "Thank you");
//            rpt.SetParameterValue("HDate", "");
//            rpt.SetParameterValue("OrderTyp", (VarGeneral.CurrentLang.ToString() == "0") ? "محلي" : "Local");
//            rpt.SetParameterValue("OrderTyp", (VarGeneral.CurrentLang.ToString() == "0") ? "سفري" : "Take Away");
//            rpt.SetParameterValue("OrderTyp", (VarGeneral.CurrentLang.ToString() == "0") ? "توصيل" : "Delivery");
//            rpt.SetParameterValue("OrderTyp", "");
//            rpt.SetParameterValue("TableNo_", "");
//            rpt.SetParameterValue("TableTyp_", "");
//            rpt.SetParameterValue("Waiter_", "");
//            rpt.SetParameterValue("CompanyFax", "Hide");
//            rpt.SetParameterValue("CompanyFaxE", "Hide");

//        }
//    }
//}
