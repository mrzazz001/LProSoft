using CrystalDecisions.Shared;
using InvAcc.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace InvAcc.Forms
{
    public class FrmReportsViewer 
    {
        public object Tag;
        public bool tt = false;

        public bool TopMost
        {
            get { return tt; }
            set
            {
                tt = value;
                if (TypeOfReporting == 0)
                { CrFrm.TopMost = value; CrFrm.BringToFront(); }
                else
                {
                    FastFrm.TopMost = value;

                    FastFrm.BringToFront();
                }


            }
        }
        bool GroupsIsPrint = false;
        public bool _GroupsIsPrint
        {
            get
            {
                return GroupsIsPrint;
            }
            set
            {
                if (TypeOfReporting == 0)
                    CrFrm._GroupsIsPrint = value;
                else
                    FastFrm._GroupsIsPrint = value;
            }
        }
        bool icar=false;
        bool icarorder = false;
        internal bool iscar { 
        get { return icar; }
            set
            {
                if (TypeOfReporting == 0)
                    CrFrm.iscar = value;
                else
                    FastFrm.iscar = value;
                icar = value;
            }
        }
        internal bool iscarorder
        {
            get { return icarorder; }
            set
            {
                if (TypeOfReporting == 0)
                    CrFrm.iscarorder = value;
                else
                    FastFrm.iscarorder = value;
                icarorder = value;
            }
        }
        static bool sss;
        public static bool IsSettingOnly
        {
            get { return sss; }
            set
            {
                if (TypeOfReporting == 0)
                    RFrmReportsViewer.IsSettingOnly = value;
                else
                    FFrmReportsViewer.IsSettingOnly = value;
                sss = value;
            }
        }
        public Dictionary<long, familyPassport> vFamilyPassport = new Dictionary<long, familyPassport>();
        public void _Proceess()
        {
            if (TypeOfReporting == 0)
                CrFrm._Proceess();
            else
                FastFrm._Proceess();
        }
        RFrmReportsViewer CrFrm;
        FFrmReportsViewer FastFrm;
        public bool BarcodSts
        {
            get
            {
                return Barcod_Sts;
            }
            set
            {
                if (TypeOfReporting == 0)
                    CrFrm.BarcodSts = value;
                else
                    FastFrm.BarcodSts = value;
                Barcod_Sts = value;
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

        public bool Barcod_Sts = false;
        public Dictionary<long, ColumnDictinary> columns_Names_visible = new Dictionary<long, ColumnDictinary>();
        public Dictionary<string, ColumnDictinaryPassport> columns_Names_visible_Passport = new Dictionary<string, ColumnDictinaryPassport>();
        public Dictionary<string, ColumnDictinarySNation> columns_Names_visibleSNAtion = new Dictionary<string, ColumnDictinarySNation>();

        public string Repvalue
        {
            get
            {
                return repvalue;
            }
            set
            {if (TypeOfReporting == 0)
                    CrFrm.Repvalue = value;
                else
                    FastFrm.Repvalue = value;
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
                if (TypeOfReporting == 0)
                    CrFrm.RepCashier = value;
                else
                    FastFrm.RepCashier = value;
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
                if (TypeOfReporting == 0)
                    CrFrm.SqlWhere = value;
                else
                    FastFrm.SqlWhere = value;
                sqlWhere = value;
            }
        }

        public static string QRCodeData { get; internal set; }

        private string repvalue;
        private string sqlWhere;
        public static int TypeOfReporting = 0;

      public   FrmReportsViewer()
        {
            if (TypeOfReporting == 0)
            {
                CrFrm = new RFrmReportsViewer();
            }
            else
                FastFrm = new FFrmReportsViewer();
        }
        public static void PrintSetFsOut(FastReport.Report rpt, int vLines, PaperOrientation vType, string vPeaperNm, int vReplay, string _PrintNm, double _mergBottom, double _mergleft, double _mergRight, double _mergTop)
        {
            FFrmReportsViewer.PrintSetFsOut(rpt, vLines, vType, vPeaperNm, vReplay, _PrintNm, _mergBottom, _mergleft, _mergRight, _mergTop);
        }

      

        private void FrmReportsViewer_Load(object sender, System.EventArgs e)
        {
        }

        private void closingss(object sender, FormClosedEventArgs e)
        {
        }
        public int ShowDialog()
        {
            if (TypeOfReporting == 0)
            {
                CrFrm.ShowDialog();
                CrFrm.FormClosed += closingss;
            }
            else
            {
                FastFrm.ShowDialog();
                FastFrm.FormClosed += closingss;
            }
            return 1;

        }
        public void Show()
        {
            if (TypeOfReporting == 0)
            {
                CrFrm.Show();
                CrFrm.FormClosed += closingss;
            }
            else
            {
                FastFrm.Show();
                FastFrm.FormClosed += closingss;
            }

        }
       
       
            private void FrmReportsViewer_Shown(object sender, EventArgs e)
        {
           
        }
    }
    }
