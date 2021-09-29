using Check_Data.Forms;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.DBUdate
{
    class DbUpdates
    {public static void cloneDbBranches(int brno,Stock_Data.Stock_DataDataContext db2)
        {

        }
        public static string addbuyer = @"
ALTER TABLE dbo.T_AccDef ADD
	Group_VAT_Number varchar(MAX) NULL,
	Buyer_Name varchar(MAX) NULL,
	Buyer_Other_ID varchar(MAX) NULL,
	Building_Number varchar(MAX) NULL,
		Addational_Address_Number varchar(MAX) NULL,
	Street_Line1 varchar(MAX) NULL,
	Street_Line2 varchar(MAX) NULL,
		Buyer_City varchar(MAX) NULL,
	
	City_Provision_District varchar(MAX) NULL,
	Country_Code varchar(MAX) NULL
	,
	Buyer_VAT_Number varchar(MAX) NULL

";
        public static string addsellerer = @"
ALTER TABLE dbo.T_Company ADD
	Group_VAT_Number varchar(MAX) NULL,
	Seller_Name varchar(MAX) NULL,
	Seller_Other_ID varchar(MAX) NULL,
	Building_Number varchar(MAX) NULL,
		Addational_Address_Number varchar(MAX) NULL,
	Street_Line1 varchar(MAX) NULL,
	Street_Line2 varchar(MAX) NULL,
		Seller_City varchar(MAX) NULL,
	
	City_Provision_District varchar(MAX) NULL,
	Country_Code varchar(MAX) NULL
	,
	Seller_VAT_Number varchar(MAX) NULL

";
        public static string Addimagecat = @"ALTER TABLE dbo.T_CATEGORY ADD
	CatImage varbinary(MAX) NULL";
        public static string addusersbaranch = @"
/****** Object:  Table [dbo].[T_Branch]    Script Date: 09/06/2021 7:23:48 PM ******/
CREATE TABLE [dbo].[T_Branch](
	[Branch_ID] [int] IDENTITY(1,1) NOT NULL,
	[Branch_no] [varchar](50) NOT NULL,
	[Branch_Name] [varchar](50) NULL,
	[Branch_NameE] [varchar](50) NULL,
	[Branch_address] [varchar](50) NULL,
	[Branch_city] [varchar](50) NULL,
	[Branch_phone] [varchar](50) NULL,
	[Branch_fax] [varchar](50) NULL,
	[Branch_mem] [varchar](max) NULL,
	[REP_FLG] [int] NULL,
	[StartEg] [varchar](30) NULL,
	[EndEg] [varchar](30) NULL,
	[crNo] [varchar](50) NULL,
	[crIssu] [varchar](50) NULL,
	[crExp] [varchar](50) NULL,
	[BldNo] [varchar](50) NULL,
	[BldIssu] [varchar](50) NULL,
	[BldExp] [varchar](50) NULL,
	[dfNo] [varchar](50) NULL,
	[dfIssu] [varchar](10) NULL,
	[dfExp] [varchar](10) NULL,
 CONSTRAINT [PK_T_Branch] PRIMARY KEY CLUSTERED 
(
	[Branch_no] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

CREATE TABLE [dbo].[T_Users](
	[Usr_ID] [int] IDENTITY(1,1) NOT NULL,
	[UsrNo] [varchar](3) NOT NULL,
	[UsrNamA] [varchar](50) NULL,
	[UsrNamE] [varchar](50) NULL,
	[Pass] [varchar](250) NULL,
	[Brn] [varchar](50) NULL,
	[Sts] [int] NULL,
	[Typ] [int] NULL,
	[ProLng] [int] NULL,
	[FilStr] [varchar](150) NULL,
	[InvStr] [varchar](150) NULL,
	[SndStr] [varchar](150) NULL,
	[StkRep] [varchar](150) NULL,
	[AccRep] [varchar](150) NULL,
	[SetStr] [varchar](150) NULL,
	[EditCost] [varchar](1) NULL,
	[PassQty] [varchar](150) NULL,
	[RepInv1] [varchar](100) NULL,
	[RepInv2] [varchar](100) NULL,
	[RepInv3] [varchar](100) NULL,
	[RepInv4] [varchar](100) NULL,
	[RepInv5] [varchar](100) NULL,
	[RepInv6] [varchar](100) NULL,
	[RepAcc1] [varchar](100) NULL,
	[RepAcc2] [varchar](100) NULL,
	[RepAcc3] [varchar](100) NULL,
	[RepAcc4] [varchar](100) NULL,
	[RepAcc5] [varchar](100) NULL,
	[RepAcc6] [varchar](100) NULL,
	[Emp_FilStr] [varchar](100) NULL,
	[Emp_MovStr] [varchar](100) NULL,
	[Emp_SalStr] [varchar](100) NULL,
	[Emp_RepStr] [varchar](100) NULL,
	[Emp_GenStr] [varchar](100) NULL,
	[CreateGaid] [int] NULL,
	[UserPointTyp] [int] NULL,
	[CashAccNo_D] [varchar](30) NULL,
	[CashAccNo_C] [varchar](30) NULL,
	[NetworkAccNo_D] [varchar](30) NULL,
	[NetworkAccNo_C] [varchar](30) NULL,
	[CreaditAccNo_D] [varchar](30) NULL,
	[CreaditAccNo_C] [varchar](30) NULL,
	[CashAccNo_D_R] [varchar](30) NULL,
	[CashAccNo_C_R] [varchar](30) NULL,
	[NetworkAccNo_D_R] [varchar](30) NULL,
	[NetworkAccNo_C_R] [varchar](30) NULL,
	[CreaditAccNo_D_R] [varchar](30) NULL,
	[CreaditAccNo_C_R] [varchar](30) NULL,
	[Comm_Inv] [float] NULL,
	[Comm_Gaid] [float] NULL,
	[PeaperTyp] [varchar](150) NULL,
	[StorePrmission] [varchar](250) NULL,
	[DefStores] [int] NULL,
	[StopBanner] [varchar](50) NULL,
	[UsrImg] [varbinary](max) NULL,
	[MaxDiscountSals] [float] NULL,
	[MaxDiscountPurchaes] [float] NULL,
	[vColumnStr1] [varchar](250) NULL,
	[vColumnStr2] [varchar](250) NULL,
	[vColumnStr3] [varchar](250) NULL,
	[vColumnStr4] [varchar](250) NULL,
	[vColumnNum1] [float] NULL,
	[vColumnNum2] [int] NULL,
	[Eqar_FilStr] [varchar](100) NULL,
	[Eqar_TenantStr] [varchar](100) NULL,
	[Eqar_RepStr] [varchar](100) NULL,
	[Eqar_GenStr] [varchar](100) NULL,
 CONSTRAINT [PK_T_Users] PRIMARY KEY CLUSTERED 
(
	[UsrNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
SET IDENTITY_INSERT [dbo].[T_Branch] ON 
INSERT [dbo].[T_Branch] ([Branch_ID], [Branch_no], [Branch_Name], [Branch_NameE], [Branch_address], [Branch_city], [Branch_phone], [Branch_fax], [Branch_mem], [REP_FLG], [StartEg], [EndEg], [crNo], [crIssu], [crExp], [BldNo], [BldIssu], [BldExp], [dfNo], [dfIssu], [dfExp]) VALUES (1, N'1', N'الفرع الرئيسي', N'Main Branch', N'----------', N'------------', N'-------------', N'', N'-------------', 0, N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
SET IDENTITY_INSERT [dbo].[T_Branch] OFF
SET IDENTITY_INSERT [dbo].[T_Users] ON 
INSERT [dbo].[T_Users] ([Usr_ID], [UsrNo], [UsrNamA], [UsrNamE], [Pass], [Brn], [Sts], [Typ], [ProLng], [FilStr], [InvStr], [SndStr], [StkRep], [AccRep], [SetStr], [EditCost], [PassQty], [RepInv1], [RepInv2], [RepInv3], [RepInv4], [RepInv5], [RepInv6], [RepAcc1], [RepAcc2], [RepAcc3], [RepAcc4], [RepAcc5], [RepAcc6], [Emp_FilStr], [Emp_MovStr], [Emp_SalStr], [Emp_RepStr], [Emp_GenStr], [CreateGaid], [UserPointTyp], [CashAccNo_D], [CashAccNo_C], [NetworkAccNo_D], [NetworkAccNo_C], [CreaditAccNo_D], [CreaditAccNo_C], [CashAccNo_D_R], [CashAccNo_C_R], [NetworkAccNo_D_R], [NetworkAccNo_C_R], [CreaditAccNo_D_R], [CreaditAccNo_C_R], [Comm_Inv], [Comm_Gaid], [PeaperTyp], [StorePrmission], [DefStores], [StopBanner], [UsrImg], [MaxDiscountSals], [MaxDiscountPurchaes], [vColumnStr1], [vColumnStr2], [vColumnStr3], [vColumnStr4], [vColumnNum1], [vColumnNum2], [Eqar_FilStr], [Eqar_TenantStr], [Eqar_RepStr], [Eqar_GenStr]) VALUES (1, N'1', N'الدعم الفني', N'Support', N'flm8ZAF33tWSzGqBtqx+7z3fzGlwHHymse1vRjXS93smXO4DliC+wNFW5VWj9v7o', N'1', 0, 0, 0, N'11111111111111111111111111111111111111111111111111111111', N'1111111111111111111111111111111111111111111111111111111111111111111111', N'1111111111111111111111111111111111111111', N'111111111111111111111111111111', N'11111111111111', N'1111111111111111111111111111111111111111111110110111', N'0', N'1111111110001', N'1', N'0', N'0', N'0', N'', N'0', N'1111111111111111', N'1111111111111111111111111111', N'111111111111', N'111111111111111', N'0', N'0', N'1111111111111111111111111111111111111111111111111111', N'111111111111111111111111111111111111111111111111', N'1111111111', N'11111111111111111111111', N'1111111111111', 0, 0, N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'0000000000000', N'', 0, N'00', NULL, 0, 0, N'', N'', N'', N'', 0, 0, N'1111111111111111111111111111', N'1111111111111111', N'111111', N'1')
INSERT [dbo].[T_Users] ([Usr_ID], [UsrNo], [UsrNamA], [UsrNamE], [Pass], [Brn], [Sts], [Typ], [ProLng], [FilStr], [InvStr], [SndStr], [StkRep], [AccRep], [SetStr], [EditCost], [PassQty], [RepInv1], [RepInv2], [RepInv3], [RepInv4], [RepInv5], [RepInv6], [RepAcc1], [RepAcc2], [RepAcc3], [RepAcc4], [RepAcc5], [RepAcc6], [Emp_FilStr], [Emp_MovStr], [Emp_SalStr], [Emp_RepStr], [Emp_GenStr], [CreateGaid], [UserPointTyp], [CashAccNo_D], [CashAccNo_C], [NetworkAccNo_D], [NetworkAccNo_C], [CreaditAccNo_D], [CreaditAccNo_C], [CashAccNo_D_R], [CashAccNo_C_R], [NetworkAccNo_D_R], [NetworkAccNo_C_R], [CreaditAccNo_D_R], [CreaditAccNo_C_R], [Comm_Inv], [Comm_Gaid], [PeaperTyp], [StorePrmission], [DefStores], [StopBanner], [UsrImg], [MaxDiscountSals], [MaxDiscountPurchaes], [vColumnStr1], [vColumnStr2], [vColumnStr3], [vColumnStr4], [vColumnNum1], [vColumnNum2], [Eqar_FilStr], [Eqar_TenantStr], [Eqar_RepStr], [Eqar_GenStr]) VALUES (2, N'2', N'الرئيسي', N'Main', N'mELirpUhRYksFj7k8/XBcQ==', N'1', 0, 0, 0, N'11111111111111111111111111111111111111111111111111111111', N'1111111111111111111111111111111111111111111111111111111111111111111111', N'1111111111111111111111111111111111111111', N'111111111111111111111111111111', N'11111111111111', N'1111111111111111111111111111111111111111111110110111', N'0', N'1110111', N'1', N'0', N'0', N'0', N'', N'0', N'1111111111111111', N'1111111111111111111111111111', N'111111111111', N'111111111111111', N'0', N'0', N'1111111111111111111111111111111111111111111111111111', N'111111111111111111111111111111111111111111111111', N'1111111111', N'11111111111111111111111', N'1111111111111', 0, 0, N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'0000000000000', N'', 0, N'00', NULL, 0, 0, N'', N'', N'', N'', 0, 0, N'1111111111111111111111111111', N'1111111111111111', N'111111', N'1')
SET IDENTITY_INSERT [dbo].[T_Users] OFF
ALTER TABLE [dbo].[T_Users]  WITH CHECK ADD  CONSTRAINT [FK_T_Users_T_Branch] FOREIGN KEY([Brn])
REFERENCES [dbo].[T_Branch] ([Branch_no])
ALTER TABLE [dbo].[T_Users] CHECK CONSTRAINT [FK_T_Users_T_Branch]
/****** Object:  StoredProcedure [dbo].[S_T_Report]    Script Date: 09/06/2021 7:23:48 PM ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

";
        public static string altinvdet = @"ALTER TABLE dbo.T_INVDET ADD
	IfRet int NULL,
	RetQty float NULL";
        public static string ExecutionTable = @"
ALTER TABLE dbo.T_INVDET ADD
	CaExState int NULL";
        public static string hashadd = @"ALTER TABLE dbo.T_INVHED ADD
	Hash_Value varchar(MAX) NULL";
        public static void copysetting2()

        {
            Stock_DataDataContext db = new Stock_DataDataContext(VarGeneral.BranchCS);

            T_Printer r;
            {
                foreach (T_INVSETTING f in db.T_INVSETTINGs)
                {
                    if (db.StockPrinterSetting2(VarGeneral.UserID, f.InvID) != null) continue;
                    if (f.InvID == -101) continue;
                    T_Printer t = new T_Printer();
                    t.P_ID = db.MaxPrinterSettings;
                    t.DefLines = f.DefLines;
                    t.defPrn = f.defPrn;
                    t.defSizePaper = f.defSizePaper;
                    t.hAl = f.hAl;
                    t.hAs = f.hAs;
                    t.hYm = f.hYm;
                    t.hYs = f.hYs;
                    t.invGdADesc = f.invGdADesc;
                    t.invGdEDesc = f.invGdEDesc;
                    t.InvID = f.InvID;
                    t.lnPg = f.lnPg;
                    t.lnSpc = f.lnSpc;
                    t.nTyp = f.nTyp;
                    t.Orientation = f.Orientation;
                    t.User_ID = VarGeneral.UserID;
                    db.T_Printers.InsertOnSubmit(t);


                }
            }
            r = db.StockPrinterSetting2(VarGeneral.UserID, 1091);
            if (r == null)
            {
                T_SYSSETTING f = db.SystemSettingStock();
                T_Printer t = new T_Printer();
                t.DefLines_Setting = f.DefLines_Setting;
                t.defPrn_Setting = f.defPrn_Setting;
                t.defSizePaper_Setting = f.defSizePaper_Setting;
                t.hAl_Setting = f.hAl_Setting;
                t.hAs_Setting = f.hAs_Setting;
                t.hYm_Setting = f.hYm_Setting;
                t.hYs_Setting = f.hYs_Setting;
                t.P_ID = db.MaxPrinterSettings;
                t.InvID = 1091;
                t.lnPg_Setting = f.lnPg_Setting;
                t.lnSpc_Setting = f.lnSpc_Setting;
                t.nTyp_Setting = f.nTyp_Setting;
                if (t.nTyp_Setting.Length == 2)
                    t.nTyp_Setting = "1" + t.nTyp_Setting;
                t.Orientation_Setting = f.Orientation_Setting;
                t.User_ID = VarGeneral.UserID;
                db.T_Printers.InsertOnSubmit(t);


            }

            db.SubmitChanges();
        }

        public static void copysetting()

        {
            Stock_DataDataContext db = new Stock_DataDataContext(VarGeneral.BranchCS);
            DBUdate.DbUpdates.executes("Delete From T_INVSETTING Where User_ID IS NOT NULL;", VarGeneral.BranchCS);
            string d = @"ALTER TABLE[dbo].[T_INVSETTING]  WITH CHECK ADD CONSTRAINT[FK_T_INVSETTING_T_CATEGORY] FOREIGN KEY([CatID]);
";
            string d2 = @" REFERENCES[dbo].[T_CATEGORY]([CAT_ID]);";
            string d3 = @"ALTER TABLE[dbo].[T_INVSETTING] CHECK CONSTRAINT[FK_T_INVSETTING_T_CATEGORY]";
            DBUdate.DbUpdates.executes(d, VarGeneral.BranchCS);
            DBUdate.DbUpdates.executes(d2, VarGeneral.BranchCS);

            DBUdate.DbUpdates.executes(d3, VarGeneral.BranchCS);

            T_Printer r;
            {
                foreach (T_INVSETTING f in db.T_INVSETTINGs)
                {
                    if (db.StockPrinterSetting2(VarGeneral.UserID, f.InvID) != null) continue;
                    if (f.InvID == -101) continue;
                    T_Printer t = new T_Printer();
                    t.P_ID = db.MaxPrinterSettings;
                    t.DefLines = f.DefLines;
                    t.defPrn = f.defPrn;
                    t.defSizePaper = f.defSizePaper;
                    t.hAl = f.hAl;
                    t.hAs = f.hAs;
                    t.hYm = f.hYm;
                    t.hYs = f.hYs;
                    t.invGdADesc = f.invGdADesc;
                    t.invGdEDesc = f.invGdEDesc;
                    t.InvID = f.InvID;
                    t.lnPg = f.lnPg;
                    t.lnSpc = f.lnSpc;
                    t.nTyp = f.nTyp;
                    t.Orientation = f.Orientation;
                    t.User_ID = VarGeneral.UserID;
                    db.T_Printers.InsertOnSubmit(t);


                }
            }
            r = db.StockPrinterSetting2(VarGeneral.UserID, 1091);
            if (r == null)
            {
                T_SYSSETTING f = db.SystemSettingStock();
                T_Printer t = new T_Printer();
                t.DefLines_Setting = f.DefLines_Setting;
                t.defPrn_Setting = f.defPrn_Setting;
                t.defSizePaper_Setting = f.defSizePaper_Setting;
                t.hAl_Setting = f.hAl_Setting;
                t.hAs_Setting = f.hAs_Setting;
                t.hYm_Setting = f.hYm_Setting;
                t.hYs_Setting = f.hYs_Setting;
                t.P_ID = db.MaxPrinterSettings;
                t.InvID = 1091;
                t.lnPg_Setting = f.lnPg_Setting;
                t.lnSpc_Setting = f.lnSpc_Setting;
                t.nTyp_Setting = f.nTyp_Setting;
                if (t.nTyp_Setting.Length == 2)
                    t.nTyp_Setting = "1" + t.nTyp_Setting;
                t.Orientation_Setting = f.Orientation_Setting;
                t.User_ID = VarGeneral.UserID;
                db.T_Printers.InsertOnSubmit(t);


            }

            db.SubmitChanges();
        }

        public static void copyforallusers()
        { int us = VarGeneral.UserID;
            Rate_DataDataContext dbc = new Rate_DataDataContext(VarGeneral.BranchRt);
            foreach (T_User i in dbc.T_Users)
            {
                VarGeneral.UserID = i.Usr_ID;
                copysetting2();
            }

        }
        public static string CreatePrinterSettingsTable = @"

CREATE TABLE [dbo].[T_Printers](
	[P_ID] [int] IDENTITY(1,1) NOT NULL,
	[Printer_Name] [varchar](max) NULL,
	[Paper_Size] [varchar](50) NULL,
	[Default_Operation] [varchar](max) NULL,
	[DefLines_Setting] [int] NULL,
	[hAl_Setting] [float] NULL,
	[hAs_Setting] [float] NULL,
	[hYm_Setting] [float] NULL,
	[hYs_Setting] [float] NULL,
	[lnPg_Setting] [float] NULL,
	[lnSpc_Setting] [float] NULL,
	[defPrn_Setting] [varchar](100) NULL,
	[nTyp_Setting] [varchar](3) NULL,
	[defSizePaper_Setting] [varchar](100) NULL,
	[Orientation_Setting] [int] NULL,
	[DefLines] [int] NULL,
	[hAl] [float] NULL,
	[hAs] [float] NULL,
	[hYm] [float] NULL,
	[hYs] [float] NULL,
	[lnPg] [float] NULL,
	[lnSpc] [float] NULL,
	[defPrn] [varchar](100) NULL,
	[nTyp] [varchar](3) NULL,
	[defSizePaper] [varchar](100) NULL,
	[Orientation] [int] NULL,
	[InvID] [int] NOT NULL,
	[User_ID] [int] NULL,
	[Branch_ID] [varchar](50) NULL,
	[Company] [varchar](50) NULL,
	[invGdADesc] [varchar](max) NULL,
	[invGdEDesc] [varchar](max) NULL,
 CONSTRAINT [PK_T_Printers] PRIMARY KEY CLUSTERED 
(
	[P_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY];
";
        public static void insertGeneralRep(int ii)
        {
            //Stock_DataDataContext db = new Stock_DataDataContext(VarGeneral.BranchCS); Rate_DataDataContext rdb = new Rate_DataDataContext(VarGeneral.BranchRt);
            //try
            //{
            //    db.ExecuteCommand(alterusersettings.Replace("GO",""));
            //}
            //catch
            //{ }

            //try
            //{

            //  db.ExecuteCommand(insertsystemsettingsg.Replace("usIdddds", ii.ToString()));
            //}
            //catch
            //{ }

        }
        public static void updateusersettings()
        {
            //            Stock_DataDataContext db = new Stock_DataDataContext(VarGeneral.BranchCS); Rate_DataDataContext rdb = new Rate_DataDataContext(VarGeneral.BranchRt);

            //            try
            //            {
            //                try
            //                {
            //                    db.ExecuteCommand(alterusersettings);
            //                }catch
            //                { }
            //                try { db.ExecuteCommand(alterinvsitting); } catch { }
            //                try
            //                {
            //                    db.ExecuteCommand(@"ALTER TABLE dbo.T_INVSETTING ADD

            //    User_ID int NULL");
            //                }
            //                catch { }
            //             //   db.ExecuteCommand(insertsystemsettings);
            //            }
            //            catch
            //            { }
            //            List<T_User> users = rdb.T_Users.ToList();
            //            try
            //            {
            //                try
            //                {
            //                    db.ExecuteCommand(@"ALTER TABLE dbo.T_INVSETTING ADD CONSTRAINT
            //	PK_T_INVSETTING PRIMARY KEY CLUSTERED 
            //	(
            //	InvSet_ID
            //	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
            //");
            //                }
            //                catch
            //                { }

            //                //db.ExecuteCommand(stringusersettingscript);
            //                foreach (T_User r in users)
            //                {
            //                    int i = 0;
            //                    foreach (T_INVSETTING h in db.T_INVSETTINGs)
            //                    {
            //                        if (h.User_ID == r.Usr_ID)
            //                        { i = 1; break; }
            //                    }
            //                    int j = 0;
            //                    foreach (T_INVSETTING h in db.T_INVSETTINGs)
            //                    {
            //                        if (h.User_ID == r.Usr_ID)
            //                            if(h.InvID==1091)
            //                        { j = 1;break; }
            //                    }
            //                    try
            //                    {
            //                        if (j != 1)
            //                        {
            //                         //   insertGeneralRep(r.Usr_ID);
            //                        }
            //                    }
            //                    catch { }
            //                    if (i == 1) continue;
            //                    string f = CopySttingString.Clone().ToString() ;
            //                    db.ExecuteCommand(CopySttingString.Replace("usIds", r.Usr_ID.ToString()));
            //                }
            //            }
            //            catch
            //            {

            //            }

        }
        public static void updateBranchNo(int bno , Stock_DataDataContext db)
        {
            string sv = @"UPDATE T_Bank SET Branch_Number = '1' 
UPDATE T_INVSETTING SET Branch_Number = '1' 
UPDATE T_Loc SET Branch_Number = '1' 
UPDATE T_Guarantor SET Branch_Number = '1' 
UPDATE T_TransEmployee SET Branch_Number = '1' 
UPDATE T_mInvPrint SET Branch_Number = '1' 
UPDATE T_Religion SET Branch_Number = '1' 
UPDATE T_SYSSETTING SET Branch_Number = '1' 
UPDATE T_Insurance SET Branch_Number = '1' 
UPDATE T_AddTyp SET Branch_Number = '1' 
UPDATE T_Offer SET Branch_Number = '1' 
UPDATE T_Unit SET Branch_Number = '1' 
UPDATE T_TicetTyp SET Branch_Number = '1' 
UPDATE T_OfferDet SET Branch_Number = '1' 
UPDATE T_Boss SET Branch_Number = '1' 
UPDATE T_TbSalary SET Branch_Number = '1' 
UPDATE T_SubTyp SET Branch_Number = '1' 
UPDATE T_Mndob SET Branch_Number = '1' 
UPDATE T_Sex SET Branch_Number = '1' 
UPDATE T_AccCat SET Branch_Number = '1' 
UPDATE T_OfferQFree SET Branch_Number = '1' 
UPDATE T_Section SET Branch_Number = '1' 
UPDATE T_Store SET Branch_Number = '1' 
UPDATE T_SalStatus SET Branch_Number = '1' 
UPDATE T_InfoTb SET Branch_Number = '1' 
UPDATE T_OpMethod SET Branch_Number = '1' 
UPDATE T_EmpCards SET Branch_Number = '1' 
UPDATE T_Nationalities SET Branch_Number = '1' 
UPDATE T_Curency SET Branch_Number = '1' 
UPDATE T_EqarTyp SET Branch_Number = '1' 
UPDATE T_MStatus SET Branch_Number = '1' 
UPDATE T_CstTbl SET Branch_Number = '1' 
UPDATE T_EqarNatural SET Branch_Number = '1' 
UPDATE T_LiquidationTyp SET Branch_Number = '1' 
UPDATE T_CATEGORY SET Branch_Number = '1' 
UPDATE T_AinTyp SET Branch_Number = '1' 
UPDATE T_Job SET Branch_Number = '1' 
UPDATE T_AccDef SET Branch_Number = '1' 
UPDATE T_AinNatural SET Branch_Number = '1' 
UPDATE T_CallPhone SET Branch_Number = '1' 
UPDATE T_VacTyp SET Branch_Number = '1' 
UPDATE T_GDHEAD SET Branch_Number = '1' 
UPDATE T_Owner SET Branch_Number = '1' 
UPDATE T_Info SET Branch_Number = '1' 
UPDATE T_INVHED SET Branch_Number = '1' 
UPDATE T_SalaryOp SET Branch_Number = '1' 
UPDATE T_EqarsData SET Branch_Number = '1' 
UPDATE T_Emp SET Branch_Number = '1' 
UPDATE T_Items SET Branch_Number = '1' 
UPDATE T_Vacation SET Branch_Number = '1' 
UPDATE T_ItemDet SET Branch_Number = '1' 
UPDATE T_UpdateDoc SET Branch_Number = '1' 
UPDATE T_Authorization SET Branch_Number = '1' 
UPDATE T_StoreMnd SET Branch_Number = '1' 
UPDATE T_AttendOperat SET Branch_Number = '1' 
UPDATE T_STKSQTY SET Branch_Number = '1' 
UPDATE T_AinsData SET Branch_Number = '1' 
UPDATE T_Attend SET Branch_Number = '1' 
UPDATE T_QTYEXP SET Branch_Number = '1' 
UPDATE T_Advances SET Branch_Number = '1' 
UPDATE T_treatment SET Branch_Number = '1' 
UPDATE T_INVDET SET Branch_Number = '1' 
UPDATE T_Family SET Branch_Number = '1' 
UPDATE T_EqarContract SET Branch_Number = '1' 
UPDATE T_Commentary SET Branch_Number = '1' 
UPDATE T_GDDET SET Branch_Number = '1' 
UPDATE T_EndService SET Branch_Number = '1' 
UPDATE T_SalDiscount SET Branch_Number = '1' 
UPDATE T_EqarSale SET Branch_Number = '1' 
UPDATE T_Sal SET Branch_Number = '1' 
UPDATE T_Salary SET Branch_Number = '1' 
UPDATE T_Rewards SET Branch_Number = '1' 
UPDATE T_Tenant SET Branch_Number = '1' 
UPDATE T_Chauffeur SET Branch_Number = '1' 
UPDATE T_Tickets SET Branch_Number = '1' 
UPDATE T_Rooms SET Branch_Number = '1' 
UPDATE T_Add SET Branch_Number = '1' 
UPDATE T_TenantContract SET Branch_Number = '1' 
UPDATE T_Premiums SET Branch_Number = '1' 
UPDATE T_Waiter SET Branch_Number = '1' 
UPDATE T_AlarmTenant SET Branch_Number = '1' 
UPDATE T_TenantPayment SET Branch_Number = '1' 
UPDATE T_InvDetNote SET Branch_Number = '1' 
UPDATE T_PatientCout SET Branch_Number = '1' 
UPDATE T_Colors SET Branch_Number = '1' 
UPDATE T_Pine SET Branch_Number = '1' 
UPDATE T_INVDET_Repair SET Branch_Number = '1' 
UPDATE T_ItemSerial SET Branch_Number = '1' 
UPDATE T_CarCheckPIC SET Branch_Number = '1' 
UPDATE T_IDType SET Branch_Number = '1' 
UPDATE T_CarNames SET Branch_Number = '1' 
UPDATE T_StsReas SET Branch_Number = '1' 
UPDATE T_MTemplates SET Branch_Number = '1' 
UPDATE T_Rom SET Branch_Number = '1' 
UPDATE T_Printers SET Branch_Number = '1' 
UPDATE T_per SET Branch_Number = '1' 
UPDATE T_RomChart SET Branch_Number = '1' 
UPDATE T_Branch SET Branch_Number = '1' 
UPDATE T_BlackList SET Branch_Number = '1' 
UPDATE T_Users SET Branch_Number = '1' 
UPDATE T_per1 SET Branch_Number = '1' 
UPDATE TmpTbl SET Branch_Number = '1' 
UPDATE T_EditItemPrice SET Branch_Number = '1' 
UPDATE T_romtrn SET Branch_Number = '1' 
UPDATE T_SINVDET SET Branch_Number = '1' 
UPDATE T_tel SET Branch_Number = '1' 
UPDATE T_BankPeaper SET Branch_Number = '1' 
UPDATE T_tran SET Branch_Number = '1' 
UPDATE T_CarTyp SET Branch_Number = '1' 
UPDATE T_Cars SET Branch_Number = '1' 
UPDATE T_sertyp SET Branch_Number = '1' 
UPDATE T_SecretariatsTyp SET Branch_Number = '1' 
UPDATE T_Dept SET Branch_Number = '1' 
UPDATE T_Secretariats SET Branch_Number = '1' 
UPDATE T_DaysOfMonth SET Branch_Number = '1' 
UPDATE T_Reserv SET Branch_Number = '1' 
UPDATE T_DayOfWeek SET Branch_Number = '1' 
UPDATE T_VisaGoBack SET Branch_Number = '1' 
UPDATE T_Contract SET Branch_Number = '1' 
UPDATE cod SET Branch_Number = '1' 
UPDATE T_City SET Branch_Number = '1' 
UPDATE T_VisaIntroduction SET Branch_Number = '1'
UPDATE T_telmn SET Branch_Number = '1' 
UPDATE T_BloodTyp SET Branch_Number = '1' 
UPDATE T_Company SET Branch_Number = '1' 
UPDATE T_Snd SET Branch_Number = '1' 
UPDATE T_BirthPlace SET Branch_Number = '1' 
UPDATE T_Project SET Branch_Number = '1' 
UPDATE T_GdAuto SET Branch_Number = '1' ".Replace("'1'",bno.ToString());
            db.ExecuteCommand(sv);

        }
        public static void addcolumntoalltables(string n, string t,Stock_DataDataContext cos)
        {
            string script = @"EXEC sp_MSforeachtable '
if not exists (select * from sys.columns 
               where object_id = object_id(''?'')
               and name = ''ccc'') 
begin
    ALTER TABLE ? ADD ccc type;
end';".Replace("ccc", n).Replace("type", t);
          
            try
            {
                cos.ExecuteCommand(script);
            }
            catch
            {

            }
        }
        public static void Deletecolumntoalltables(string n, string t)
        {
            string script = @"EXEC sp_MSforeachtable '
if  exists (select * from sys.columns 
               where object_id = object_id(''?'')
               and name = ''fff'') 
begin
    ALTER TABLE ?  ccc 
end';".Replace("ccc", "	DROP COLUMN " + n).Replace("fff", n);
            SqlConnection conn = new SqlConnection(VarGeneral.BranchCS);
            var server = new Server(new ServerConnection(conn));
            try
            {
                server.ConnectionContext.ExecuteNonQuery(script);
            }
            catch
            {

            }
        }

        public static string CreateCarCheckTable = @"IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[T_CarCheckPIC]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[T_CarCheckPIC](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[INVHED_ID] [varchar](max) NULL,
	[Pic_1] [image] NULL,
	[Pic_2] [image] NULL,
	[Pic_3] [image] NULL,
	[Pic_4] [image] NULL,
	[Pic_5] [image] NULL,
 CONSTRAINT [PK_T_CarCheckPIC] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


END";
        public static string colorstableUpdate = @"BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_T_Colors
	(
	ID int NOT NULL,
	Color_Name varchar(50) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_T_Colors SET (LOCK_ESCALATION = TABLE)
GO
IF EXISTS(SELECT * FROM dbo.T_Colors)
	 EXEC('INSERT INTO dbo.Tmp_T_Colors (ID, Color_Name)
		SELECT ID, Color_Name FROM dbo.T_Colors WITH (HOLDLOCK TABLOCKX)')
GO
DROP TABLE dbo.T_Colors
GO
EXECUTE sp_rename N'dbo.Tmp_T_Colors', N'T_Colors', 'OBJECT' 
GO
COMMIT
select Has_Perms_By_Name(N'dbo.T_Colors', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.T_Colors', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.T_Colors', 'Object', 'CONTROL') as Contr_Per 

GO
ALTER TABLE dbo.T_Colors ADD CONSTRAINT
	PK_T_Colors PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
;";
        public static string CarNames = @"IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[T_CarNames]') AND type in (N'U'))
begin 
CREATE TABLE [dbo].[T_CarNames](
	[Car_ID] [varchar](40) NOT NULL,
	[Car_No] [int] NOT NULL,
	[NameA] [varchar](50) NULL,
	[NameE] [varchar](50) NULL,
	[Note] [varchar](250) NULL,
	[CarType] [int] NULL
	CONSTRAINT [PK_T_CarNames] PRIMARY KEY CLUSTERED 
(
	[Car_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
";
        public static string colortable = @"IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[T_Colors]') AND type in (N'U'))
begin 
CREATE TABLE dbo.T_Colors
	(
	ID int NOT NULL IDENTITY (1, 1),
	Color_Name varchar(50) NULL
	)  ON [PRIMARY]

END;";
        public static string pinestable = @"IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[T_Pine]') AND type in (N'U'))
begin 
CREATE TABLE [dbo].[T_Pine](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Pic_no] [int] NULL,
	[Inv_ID] [varchar](50) NULL,
	[X] [int] NULL,
	[Y] [int] NULL,
	[Note] [varchar](max) NULL,
 CONSTRAINT [PK_T_Pine] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END;";
        public static string invalter = @"IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[T_INVHED]') 
         AND name = 'Car_ID'
)
BEGIN
ALTER TABLE dbo.T_INVHED ADD
	Car_ID int NULL,
	Car_TypeNameA varchar(50) NULL,
	Car_TypeNameE varchar(50) NULL,
	Car_NameA varchar(50) NULL,
	Car_NameE varchar(50) NULL,
	PlateNo varchar(50) NULL,
	Color varchar(50) NULL,
	ModelNo varchar(50) NULL,
	Delevery_Date date NULL
END;";
        public static string getoneColumnAddscript(string table, string column, string typ)
        {
            string s = @"IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[T_INVHED]') 
         AND name = 'Car_ID'
)
BEGIN
ALTER TABLE dbo.T_INVHED ADD
	Car_ID int NULL
END;";
            return s.Replace("T_INVHED", table).Replace("Car_ID", column).Replace("int", typ);
        }
        public static string invupdatecars = @"ALTER PROCEDURE [dbo].[S_T_INVHED_UPDATE](
                                                                                 @InvHed_ID INT ,
                                                                                 @InvId FLOAT =NULL,
                                                                                 @InvNo VARCHAR (10),
                                                                                 @InvTyp INT =NULL,
                                                                                 @InvCashPay INT =NULL,
                                                                                 @CusVenNo VARCHAR (20)=NULL,
                                                                                 @CusVenNm VARCHAR (50)=NULL,
                                                                                 @CusVenAdd VARCHAR (100)=NULL,
                                                                                 @CusVenTel VARCHAR (30)=NULL,
                                                                                 @Remark VARCHAR (MAX)=NULL,
                                                                                 @HDat VARCHAR (10)=NULL,
                                                                                 @GDat VARCHAR (10)=NULL,
                                                                                 @MndNo INT =NULL,
                                                                                 @SalsManNo VARCHAR (3)=NULL,
                                                                                 @SalsManNam VARCHAR (50)=NULL,
                                                                                 @InvTot FLOAT =NULL,
                                                                                 @InvTotLocCur FLOAT =NULL,
                                                                                 @InvDisPrs FLOAT =NULL,
                                                                                 @InvDisVal FLOAT =NULL,
                                                                                 @InvDisValLocCur FLOAT =NULL,
                                                                                 @InvNet FLOAT =NULL,
                                                                                 @InvNetLocCur FLOAT =NULL,
                                                                                 @CashPay FLOAT =NULL,
                                                                                 @CashPayLocCur FLOAT =NULL,
                                                                                 @IfRet INT =NULL,
                                                                                 @GadeNo FLOAT =NULL,
                                                                                 @GadeId FLOAT =NULL,
                                                                                 @IfDel INT =NULL,
                                                                                 @RetNo VARCHAR (10)=NULL,
                                                                                 @RetId FLOAT =NULL,
                                                                                 @InvCstNo INT =NULL,
                                                                                 @InvCashPayNm VARCHAR (100)=NULL,
                                                                                 @RefNo VARCHAR (20)=NULL,
                                                                                 @InvCost FLOAT =NULL,
                                                                                 @EstDat VARCHAR (10)=NULL,
                                                                                 @CustPri INT =NULL,
                                                                                 @ArbTaf VARCHAR (150)=NULL,
                                                                                 @CurTyp INT =NULL,
                                                                                 @InvCash VARCHAR (20)=NULL,
                                                                                 @ToStore VARCHAR (3)=NULL,
                                                                                 @ToStoreNm VARCHAR (50)=NULL,
                                                                                 @InvQty FLOAT =NULL,
                                                                                 @EngTaf VARCHAR (150)=NULL,
                                                                                 @IfTrans INT =NULL,
                                                                                 @CustRep FLOAT =NULL,
                                                                                 @CustNet FLOAT =NULL,
                                                                                 @InvWight_T FLOAT =NULL,
                                                                                 @IfPrint INT =NULL,
                                                                                 @LTim VARCHAR (10)=NULL,
                                                                                 @CREATED_BY VARCHAR(100) =NULL,
                                                                                 @DATE_CREATED datetime =NULL,
                                                                                 @MODIFIED_BY VARCHAR (100)=NULL,
                                                                                 @DATE_MODIFIED datetime=NULL,
                                                                                 @CreditPay float=NULL,
                                                                                 @CreditPayLocCur float=NULL,
                                                                                 @NetworkPay float=NULL,
                                                                                 @NetworkPayLocCur float=NULL,
                                                                                 @CommMnd_Inv float=NULL,
                                                                                 @MndExtrnal bit=NULL,
                                                                                 @CompanyID int=NULL,
                                                                                 @InvAddCost float=NULL,
                                                                                 @InvAddCostLoc float=NULL,
                                                                                 @InvAddCostExtrnal float=NULL,
                                                                                 @InvAddCostExtrnalLoc float=NULL,
                                                                                 @IsExtrnalGaid bit=NULL,
                                                                                 @ExtrnalCostGaidID float=NULL,
                                                                                 @Puyaid float=NULL,
                                                                                 @Remming float=NULL,
                                                                                 @RoomNo int=NULL,
                                                                                 @OrderTyp int=NULL,
                                                                                 @RoomSts bit=NULL,
                                                                                 @chauffeurNo int=NULL,
                                                                                 @RoomPerson int=NULL,
                                                                                 @ServiceValue float=NULL,
                                                                                 @Sts bit=NULL,
                                                                                 @PaymentOrderTyp int=NULL,
                                                                                 @AdminLock bit=NULL,
                                                                                 @DeleteDate VARCHAR (10)=NULL,
                                                                                 @DeleteTime VARCHAR (10)=NULL,
                                                                                 @UserNew VARCHAR (3)=NULL,
                                                                                 @IfEnter int=NULL,
                                                                                 @InvAddTax float=NULL,
                                                                                 @InvAddTaxlLoc float=NULL,
                                                                                 @IsTaxGaid bit=NULL,
                                                                                 @TaxGaidID float=NULL,
                                                                                 @IsTaxUse bit=NULL,
                                                                                 @InvValGaidDis float=NULL,
                                                                                 @InvValGaidDislLoc float=NULL,
                                                                                 @IsDisGaid bit=NULL,
                                                                                 @DisGaidID1 float=NULL,
                                                                                 @IsDisUse1 bit=NULL,
                                                                                 @InvComm float=NULL,
                                                                                 @InvCommLoc float=NULL,
                                                                                 @IsCommGaid bit=NULL,
                                                                                 @CommGaidID float=NULL,
                                                                                 @IsCommUse bit=NULL,
                                                                                 @IsTaxLines bit=NULL,
                                                                                 @IsTaxByTotal bit=NULL,
                                                                                 @IsTaxByNet bit=NULL,
                                                                                 @TaxByNetValue float=NULL,
                                                                                 @DesPointsValue float=NULL,
																			     @DesPointsValueLocCur float=NULL,
																			     @PointsCount float=NULL,
                                                                                 @IsPoints bit=NULL,
                                                                                 @tailor1  VARCHAR (100)=NULL,
                                                                                 @tailor2  VARCHAR (100)=NULL,
                                                                                 @tailor3  VARCHAR (100)=NULL,
                                                                                 @tailor4  VARCHAR (100)=NULL,
                                                                                 @tailor5  VARCHAR (100)=NULL,
                                                                                 @tailor6  VARCHAR (100)=NULL,
                                                                                 @tailor7  VARCHAR (100)=NULL,
                                                                                 @tailor8  VARCHAR  (100)=NULL,
                                                                                 @tailor9  VARCHAR  (100)=NULL,
                                                                                 @tailor10 VARCHAR (100)=NULL,
                                                                                 @tailor11 VARCHAR (100)=NULL,
                                                                                 @tailor12 VARCHAR (100)=NULL,
                                                                                 @tailor13 VARCHAR (100)=NULL,
                                                                                 @tailor14 VARCHAR (100)=NULL,
                                                                                 @tailor15 VARCHAR (100)=NULL,
                                                                                 @tailor16 VARCHAR (100)=NULL,
                                                                                 @tailor17 VARCHAR (100)=NULL,
                                                                                 @tailor18 VARCHAR (100)=NULL,
                                                                                 @tailor19 VARCHAR (100)=NULL,
                                                                                 @tailor20 VARCHAR (100)=NULL,
                                                                                 @InvImg   VARBINARY(max) =NULL,
                                                                                 @CusVenMob VARCHAR(50) =NULL,
                                                                                 @PriceIncludeTax BIT = NULL,
																				 													 @CInvType INT =NULL,
																	 @Car_ID int =NULL,
	@Car_TypeNameA varchar(50) =NULL,
	@Car_TypeNameE varchar(50) =NULL,
	@Car_NameA varchar(50) =NULL,
	@Car_NameE varchar(50) =NULL,
	@PlateNo varchar(50) =NULL,
	@Color varchar(50) =NULL,
	@ModelNo varchar(50) =NULL,
	@Delevery_Date date =NULL,
	@VehiclechassisNumber Varchar(100) =Null
                                                                 
                                  )
                                  AS
                                  BEGIN
                                  UPDATE T_INVHED
                                  SET    InvId = @InvId,
                                         InvNo = @InvNo,
                                         InvTyp = @InvTyp,
                                         InvCashPay = @InvCashPay,
                                         CusVenNo = @CusVenNo,
                                         CusVenNm = @CusVenNm,
                                         CusVenAdd = @CusVenAdd,
                                         CusVenTel = @CusVenTel,
                                         Remark = @Remark,
                                         HDat = @HDat,
                                         GDat = @GDat,
                                         MndNo = @MndNo,
                                         SalsManNo = @SalsManNo,
                                         SalsManNam = @SalsManNam,
                                         InvTot = @InvTot,
                                         InvTotLocCur = @InvTotLocCur,
                                         InvDisPrs = @InvDisPrs,
                                         InvDisVal = @InvDisVal,
                                         InvDisValLocCur = @InvDisValLocCur,
                                         InvNet = @InvNet,
                                         InvNetLocCur = @InvNetLocCur,
                                         CashPay = @CashPay,
                                         CashPayLocCur = @CashPayLocCur,
                                         IfRet = @IfRet,
                                         GadeNo = @GadeNo,
                                         GadeId = @GadeId,
                                         IfDel = @IfDel,
                                         RetNo = @RetNo,
                                         RetId = @RetId,
                                         InvCstNo = @InvCstNo,
                                         InvCashPayNm = @InvCashPayNm,
                                         RefNo = @RefNo,
                                         InvCost = @InvCost,
                                         EstDat = @EstDat,
                                         CustPri = @CustPri,
                                         ArbTaf = @ArbTaf,
                                         CurTyp = @CurTyp,
                                         InvCash = @InvCash,
                                         ToStore = @ToStore,
                                         ToStoreNm = @ToStoreNm,
                                         InvQty = @InvQty,
                                         EngTaf = @EngTaf,
                                         IfTrans = @IfTrans,
                                         CustRep = @CustRep,
                                         CustNet = @CustNet,
                                         InvWight_T = @InvWight_T,
                                         IfPrint = @IfPrint,
                                         LTim = @LTim,
                                         MODIFIED_BY = @MODIFIED_BY,
                                         DATE_MODIFIED = @DATE_MODIFIED,
                                                                                 CreditPay = @CreditPay,
                                                                                 CreditPayLocCur = @CreditPayLocCur,
                                                                                 NetworkPay = @NetworkPay,
                                                                                 NetworkPayLocCur = @NetworkPayLocCur,
                                                                                 CommMnd_Inv = @CommMnd_Inv,
                                                                                 MndExtrnal = @MndExtrnal,
                                                                                 CompanyID = @CompanyID,
                                                                                 InvAddCost = @InvAddCost,
                                                                                 InvAddCostLoc = @InvAddCostLoc,
                                                                                 InvAddCostExtrnal = @InvAddCostExtrnal,
                                                                                 InvAddCostExtrnalLoc = @InvAddCostExtrnalLoc,
                                                                                 IsExtrnalGaid = @IsExtrnalGaid,
                                                                                 ExtrnalCostGaidID = @ExtrnalCostGaidID,
                                                                                 Puyaid = @Puyaid,
                                                                                 Remming = @Remming,
                                                                                 RoomNo = @RoomNo,
                                                                                 OrderTyp = @OrderTyp,
                                                                                 RoomSts = @RoomSts,
                                                                                 chauffeurNo = @chauffeurNo,
                                                                                 RoomPerson = @RoomPerson,
                                                                                 ServiceValue = @ServiceValue,
                                                                                 Sts = @Sts,
                                                                                 PaymentOrderTyp = @PaymentOrderTyp,
                                                                                 AdminLock = @AdminLock,
                                                                                 DeleteDate = @DeleteDate,
                                                                                 DeleteTime = @DeleteTime,
                                                                                 UserNew = @UserNew,
                                                                                 IfEnter = @IfEnter,
                                                                                 InvAddTax = @InvAddTax,
                                                                                 InvAddTaxlLoc = @InvAddTaxlLoc,
                                                                                 IsTaxGaid = @IsTaxGaid,
                                                                                 TaxGaidID = @TaxGaidID,
                                                                                 IsTaxUse = @IsTaxUse,
                                                                                 InvValGaidDis = @InvValGaidDis,
                                                                                 InvValGaidDislLoc = @InvValGaidDislLoc,
                                                                                 IsDisGaid = @IsDisGaid,
                                                                                 DisGaidID1 = @DisGaidID1,
                                                                                 IsDisUse1 = @IsDisUse1,
                                                                                 InvComm = @InvComm,
                                                                                 InvCommLoc = @InvCommLoc,
                                                                                 IsCommGaid = @IsCommGaid,
                                                                                 CommGaidID = @CommGaidID,
                                                                                 IsCommUse = @IsCommUse,
                                                                                 IsTaxLines = @IsTaxLines,
                                                                                 IsTaxByTotal = @IsTaxByTotal,
                                                                                 IsTaxByNet = @IsTaxByNet,
                                                                                 TaxByNetValue = @TaxByNetValue,
                                                                                 DesPointsValue = @DesPointsValue ,
																				 DesPointsValueLocCur = @DesPointsValueLocCur ,
																				 PointsCount = @PointsCount,
                                                                                 IsPoints = @IsPoints,
                                                                                 tailor1 = @tailor1 ,
																				 tailor2 = @tailor2,
																				 tailor3 = @tailor3,
																				 tailor4 = @tailor4,
																				 tailor5 = @tailor5,
																				 tailor6 = @tailor6,
																				 tailor7 = @tailor7,
																				 tailor8 = @tailor8,
																				 tailor9 = @tailor9,
																				 tailor10 = @tailor10,
																				 tailor11 = @tailor11,
																				 tailor12 = @tailor12,
																				 tailor13 = @tailor13,
																				 tailor14 = @tailor14,
																				 tailor15 = @tailor15,
																				 tailor16 = @tailor16,
																				 tailor17 = @tailor17,
																				 tailor18 = @tailor18,
																				 tailor19 = @tailor19,
																				 tailor20 = @tailor20,
                                                                                 InvImg   = @InvImg,
                                                                                 CusVenMob = @CusVenMob,
                                                                                 PriceIncludTax =@PriceIncludeTax,
																				 Car_ID=@Car_ID,
																				 Car_TypeNameA=@Car_TypeNameA,
																				 Car_TypeNameE=@Car_TypeNameE,
																				 Car_NameA=@Car_NameA,
																				 Car_NameE=@Car_NameE,
																				 PlateNo=@PlateNo,
																				 color=@Color,
																				 ModelNo=@ModelNo,
																				 Delevery_Date=@Delevery_Date
                                                                                ,VehiclechassisNumber=@VehiclechassisNumber
							 WHERE  @InvHed_ID = InvHed_ID
                                  RETURN
                                  END;";
        public static string invinsertcars = @"ALTER PROCEDURE[dbo].[S_T_INVHED_INSERT]
        (
                                                                    @InvHed_ID INT OUTPUT,
                                                                    @InvId FLOAT =NULL,
                                                                     @InvNo VARCHAR(10),
                                                                     @InvTyp INT = NULL,
                                                                     @InvCashPay INT =NULL,
                                                                     @CusVenNo VARCHAR(20)=NULL,
                                                                     @CusVenNm VARCHAR(50)=NULL,
                                                                     @CusVenAdd VARCHAR(100)=NULL,
                                                                     @CusVenTel VARCHAR(30)=NULL,
                                                                     @Remark VARCHAR(MAX)=NULL,
                                                                     @HDat VARCHAR(10)=NULL,
                                                                     @GDat VARCHAR(10)=NULL,
                                                                     @MndNo INT = NULL,
                                                                     @SalsManNo VARCHAR(3)=NULL,
                                                                     @SalsManNam VARCHAR(50)=NULL,
                                                                     @InvTot FLOAT = NULL,
                                                                     @InvTotLocCur FLOAT =NULL,
                                                                     @InvDisPrs FLOAT = NULL,
                                                                     @InvDisVal FLOAT =NULL,
                                                                     @InvDisValLocCur FLOAT = NULL,
                                                                     @InvNet FLOAT =NULL,
                                                                     @InvNetLocCur FLOAT = NULL,
                                                                     @CashPay FLOAT =NULL,
                                                                     @CashPayLocCur FLOAT = NULL,
                                                                     @IfRet INT =NULL,
                                                                     @GadeNo FLOAT = NULL,
                                                                     @GadeId FLOAT =NULL,
                                                                     @IfDel INT = NULL,
                                                                     @RetNo VARCHAR(10)=NULL,
                                                                     @RetId FLOAT = NULL,
                                                                     @InvCstNo INT =NULL,
                                                                     @InvCashPayNm VARCHAR(100)=NULL,
                                                                     @RefNo VARCHAR(20)=NULL,
                                                                     @InvCost FLOAT = NULL,
                                                                     @EstDat VARCHAR(10)=NULL,
                                                                     @CustPri INT = NULL,
                                                                     @ArbTaf VARCHAR(150)=NULL,
                                                                     @CurTyp INT = NULL,
                                                                     @InvCash VARCHAR(20)=NULL,
                                                                     @ToStore VARCHAR(3)=NULL,
                                                                     @ToStoreNm VARCHAR(50)=NULL,
                                                                     @InvQty FLOAT = NULL,
                                                                     @EngTaf VARCHAR(150)=NULL,
                                                                     @IfTrans INT = NULL,
                                                                     @CustRep FLOAT =NULL,
                                                                     @CustNet FLOAT = NULL,
                                                                     @InvWight_T FLOAT =NULL,
                                                                     @IfPrint INT = NULL,
                                                                     @LTim VARCHAR(10)=NULL,
                                                                     @CREATED_BY VARCHAR(100) =NULL,
                                                                     @DATE_CREATED datetime = NULL,
                                                                     @MODIFIED_BY VARCHAR(100)=NULL,
                                                                     @DATE_MODIFIED datetime = NULL,
                                                                     @CreditPay float=NULL,
                                                                     @CreditPayLocCur float=NULL,
                                                                     @NetworkPay float=NULL,
                                                                     @NetworkPayLocCur float=NULL,
                                                                     @CommMnd_Inv float=NULL,
                                                                     @MndExtrnal bit = NULL,
                                                                     @CompanyID int=NULL,
                                                                     @InvAddCost float=NULL,
                                                                     @InvAddCostLoc float=NULL,
                                                                     @InvAddCostExtrnal float=NULL,
                                                                     @InvAddCostExtrnalLoc float=NULL,
                                                                     @IsExtrnalGaid bit = NULL,
                                                                     @ExtrnalCostGaidID float=NULL,
                                                                     @Puyaid float=NULL,
                                                                     @Remming float=NULL,
                                                                     @RoomNo int=NULL,
                                                                     @OrderTyp int=NULL,
                                                                     @RoomSts bit = NULL,
                                                                     @chauffeurNo int=NULL,
                                                                     @RoomPerson int=NULL,
                                                                     @ServiceValue float=NULL,
                                                                     @Sts bit = NULL,
                                                                     @PaymentOrderTyp int=NULL,
                                                                     @AdminLock bit = NULL,
                                                                     @DeleteDate VARCHAR(10)=NULL,
                                                                     @DeleteTime VARCHAR(10)=NULL,
                                                                     @UserNew VARCHAR(3)=NULL,
                                                                     @IfEnter int=NULL,
                                                                     @InvAddTax float=NULL,
                                                                     @InvAddTaxlLoc float=NULL,
                                                                     @IsTaxGaid bit = NULL,
                                                                     @TaxGaidID float=NULL,
                                                                     @IsTaxUse bit = NULL,
                                                                     @InvValGaidDis float=NULL,
                                                                     @InvValGaidDislLoc float=NULL,
                                                                     @IsDisGaid bit = NULL,
                                                                     @DisGaidID1 float=NULL,
                                                                     @IsDisUse1 bit = NULL,
                                                                     @InvComm float=NULL,
                                                                     @InvCommLoc float=NULL,
                                                                     @IsCommGaid bit = NULL,
                                                                     @CommGaidID float=NULL,
                                                                     @IsCommUse bit = NULL,
                                                                     @IsTaxLines bit=NULL,
                                                                     @IsTaxByTotal bit = NULL,
                                                                     @IsTaxByNet bit=NULL,
                                                                     @TaxByNetValue float=NULL,
                                                                     @DesPointsValue float=NULL,
                                                                     @DesPointsValueLocCur float=NULL,
                                                                     @PointsCount float=NULL,
                                                                     @IsPoints bit = NULL,
                                                                     @tailor1 VARCHAR(100)=NULL,
                                                                     @tailor2 VARCHAR(100)=NULL,
                                                                     @tailor3 VARCHAR(100)=NULL,
                                                                     @tailor4 VARCHAR(100)=NULL,
                                                                     @tailor5 VARCHAR(100)=NULL,
                                                                     @tailor6 VARCHAR(100)=NULL,
                                                                     @tailor7 VARCHAR(100)=NULL,
                                                                     @tailor8 VARCHAR(100)=NULL,
                                                                     @tailor9 VARCHAR(100)=NULL,
                                                                     @tailor10 VARCHAR(100)=NULL,
                                                                     @tailor11 VARCHAR(100)=NULL,
                                                                     @tailor12 VARCHAR(100)=NULL,
                                                                     @tailor13 VARCHAR(100)=NULL,
                                                                     @tailor14 VARCHAR(100)=NULL,
                                                                     @tailor15 VARCHAR(100)=NULL,
                                                                     @tailor16 VARCHAR(100)=NULL,
                                                                     @tailor17 VARCHAR(100)=NULL,
                                                                     @tailor18 VARCHAR(100)=NULL,
                                                                     @tailor19 VARCHAR(100)=NULL,
                                                                     @tailor20 VARCHAR(100)=NULL,
                                                                     @InvImg[varbinary] (max) =NULL,
                                                                     @CusVenMob VARCHAR(50) =NULL,
                                                                     @PriceIncludeTax BIT = NULL,
																	 @CInvType INT =NULL,
																	 @Car_ID int =NULL,
	@Car_TypeNameA varchar(50) =NULL,
	@Car_TypeNameE varchar(50) =NULL,
	@Car_NameA varchar(50) =NULL,
	@Car_NameE varchar(50) =NULL,
	@PlateNo varchar(50) =NULL,
	@Color varchar(50) =NULL,
	@ModelNo varchar(50) =NULL,
	@Delevery_Date date =NULL,
	@VehiclechassisNumber varchar(100) =NULL,
	@OrderStatus INT =NULL
                                                              )
                                                              AS
                                                              BEGIN
                                                              INSERT INTO T_INVHED(
                                                                     InvId,
                                                                     InvNo,
                                                                     InvTyp,
                                                                     InvCashPay,
                                                                     CusVenNo,
                                                                     CusVenNm,
                                                                     HDat,
                                                                     CusVenAdd,
                                                                     CusVenTel,
                                                                     Remark,
                                                                     GDat,
                                                                     MndNo,
                                                                     SalsManNo,
                                                                     SalsManNam,
                                                                     InvTot,
                                                                     InvTotLocCur,
                                                                     InvDisPrs,
                                                                     InvDisVal,
                                                                     InvDisValLocCur,
                                                                     InvNet,
                                                                     InvNetLocCur,
                                                                     CashPay,
                                                                     CashPayLocCur,
                                                                     IfRet,
                                                                     GadeNo,
                                                                     GadeId,
                                                                     IfDel,
                                                                     RetNo,
                                                                     RetId,
                                                                     InvCstNo,
                                                                     InvCashPayNm,
                                                                     RefNo,
                                                                     InvCost,
                                                                     EstDat,
                                                                     CustPri,
                                                                     ArbTaf,
                                                                     CurTyp,
                                                                     InvCash,
                                                                     ToStore,
                                                                     ToStoreNm,
                                                                     InvQty,
                                                                     EngTaf,
                                                                     IfTrans,
                                                                     CustRep,
                                                                     CustNet,
                                                                     InvWight_T,
                                                                     IfPrint,
                                                                     LTim,
                                                                     CREATED_BY,
                                                                     DATE_CREATED,
                                                                     MODIFIED_BY ,
                                                                     DATE_MODIFIED ,
                                                                     CreditPay ,
                                                                     CreditPayLocCur ,
                                                                     NetworkPay ,
                                                                     NetworkPayLocCur ,
                                                                     CommMnd_Inv ,
                                                                     MndExtrnal ,
                                                                     CompanyID ,
                                                                     InvAddCost ,
                                                                     InvAddCostLoc ,
                                                                     InvAddCostExtrnal ,
                                                                     InvAddCostExtrnalLoc ,
                                                                     IsExtrnalGaid ,
                                                                     ExtrnalCostGaidID ,
                                                                     Puyaid ,
                                                                     Remming ,
                                                                     RoomNo ,
                                                                     OrderTyp ,
                                                                     RoomSts ,
                                                                     chauffeurNo ,
                                                                     RoomPerson ,
                                                                     ServiceValue ,
                                                                     Sts ,
                                                                     PaymentOrderTyp ,
                                                                     AdminLock ,
                                                                     DeleteDate ,
                                                                     DeleteTime ,
                                                                     UserNew ,
                                                                     IfEnter ,
                                                                     InvAddTax ,
                                                                     InvAddTaxlLoc ,
                                                                     IsTaxGaid ,
                                                                     TaxGaidID ,
                                                                     IsTaxUse ,
                                                                     InvValGaidDis ,
                                                                     InvValGaidDislLoc ,
                                                                     IsDisGaid ,
                                                                     DisGaidID1 ,
                                                                     IsDisUse1 ,
                                                                     InvComm ,
                                                                     InvCommLoc ,
                                                                     IsCommGaid ,
                                                                     CommGaidID ,
                                                                     IsCommUse ,
                                                                     IsTaxLines ,
                                                                     IsTaxByTotal ,
                                                                     IsTaxByNet ,
                                                                     TaxByNetValue ,
                                                                     DesPointsValue ,
                                                                     DesPointsValueLocCur ,
                                                                     PointsCount,
                                                                     IsPoints,
                                                                     tailor1 ,
                                                                     tailor2 ,
                                                                     tailor3 ,
                                                                     tailor4 ,
                                                                     tailor5 ,
                                                                     tailor6 ,
                                                                     tailor7 ,
                                                                     tailor8 ,
                                                                     tailor9 ,
                                                                     tailor10 ,
                                                                     tailor11 ,
                                                                     tailor12 ,
                                                                     tailor13 ,
                                                                     tailor14 ,
                                                                     tailor15 ,
                                                                     tailor16 ,
                                                                     tailor17 ,
                                                                     tailor18 ,
                                                                     tailor19 ,
                                                                     tailor20,
                                                                     InvImg,
                                                                     CusVenMob,
                                                                     PriceIncludTax,
																	 CInvType,
																	 Car_ID,
																	 Car_TypeNameA,
																	 Car_TypeNameE,
																	 Car_NameA,
																	 Car_NameE,
																	 PlateNo,
																	 Color,
																	 ModelNo,
																	 Delevery_Date
																	 ,VehiclechassisNumber,
																	 OrderStatus
                                                              )
                                                              VALUES
                                                              (
                                                                    @InvId,
                                                                    @InvNo,
                                                                    @InvTyp,
                                                                    @InvCashPay,
                                                                    @CusVenNo,
                                                                    @CusVenNm,
                                                                    @HDat,
                                                                    @CusVenAdd,
                                                                    @CusVenTel,
                                                                    @Remark,
                                                                    @GDat,
                                                                    @MndNo,
                                                                    @SalsManNo,
                                                                    @SalsManNam,
                                                                    @InvTot,
                                                                    @InvTotLocCur,
                                                                    @InvDisPrs,
                                                                    @InvDisVal,
                                                                    @InvDisValLocCur,
                                                                    @InvNet,
                                                                    @InvNetLocCur,
                                                                    @CashPay,
                                                                    @CashPayLocCur,
                                                                    @IfRet,
                                                                    @GadeNo,
                                                                    @GadeId,
                                                                    @IfDel,
                                                                    @RetNo,
                                                                    @RetId,
                                                                    @InvCstNo,
                                                                    @InvCashPayNm,
                                                                    @RefNo,
                                                                    @InvCost,
                                                                    @EstDat,
                                                                    @CustPri,
                                                                    @ArbTaf,
                                                                    @CurTyp,
                                                                    @InvCash,
                                                                    @ToStore,
                                                                    @ToStoreNm,
                                                                    @InvQty,
                                                                    @EngTaf,
                                                                    @IfTrans,
                                                                    @CustRep,
                                                                    @CustNet,
                                                                    @InvWight_T,
                                                                    @IfPrint,
                                                                    @LTim,
                                                                    @CREATED_BY,
                                                                    @DATE_CREATED,
                                                                    @MODIFIED_BY ,
                                                                    @DATE_MODIFIED ,
                                                                    @CreditPay ,
                                                                    @CreditPayLocCur ,
                                                                    @NetworkPay ,
                                                                    @NetworkPayLocCur ,
                                                                    @CommMnd_Inv ,
                                                                    @MndExtrnal ,
                                                                    @CompanyID ,
                                                                    @InvAddCost ,
                                                                    @InvAddCostLoc ,
                                                                    @InvAddCostExtrnal ,
                                                                    @InvAddCostExtrnalLoc ,
                                                                    @IsExtrnalGaid ,
                                                                    @ExtrnalCostGaidID ,
                                                                    @Puyaid ,
                                                                    @Remming ,
                                                                    @RoomNo ,
                                                                    @OrderTyp ,
                                                                    @RoomSts ,
                                                                    @chauffeurNo ,
                                                                    @RoomPerson ,
                                                                    @ServiceValue ,
                                                                    @Sts ,
                                                                    @PaymentOrderTyp ,
                                                                    @AdminLock ,
                                                                    @DeleteDate ,
                                                                    @DeleteTime ,
                                                                    @UserNew ,
                                                                    @IfEnter ,
                                                                    @InvAddTax ,
                                                                    @InvAddTaxlLoc ,
                                                                    @IsTaxGaid ,
                                                                    @TaxGaidID ,
                                                                    @IsTaxUse ,
                                                                    @InvValGaidDis ,
                                                                    @InvValGaidDislLoc ,
                                                                    @IsDisGaid ,
                                                                    @DisGaidID1 ,
                                                                    @IsDisUse1 ,
                                                                    @InvComm ,
                                                                    @InvCommLoc ,
                                                                    @IsCommGaid ,
                                                                    @CommGaidID ,
                                                                    @IsCommUse ,
                                                                    @IsTaxLines ,
                                                                    @IsTaxByTotal ,
                                                                    @IsTaxByNet ,
                                                                    @TaxByNetValue ,
                                                                    @DesPointsValue ,
                                                                    @DesPointsValueLocCur ,
                                                                    @PointsCount,
                                                                    @IsPoints,
                                                                    @tailor1 ,
                                                                    @tailor2 ,
                                                                    @tailor3 ,
                                                                    @tailor4 ,
                                                                    @tailor5 ,
                                                                    @tailor6 ,
                                                                    @tailor7 ,
                                                                    @tailor8 ,
                                                                    @tailor9 ,
                                                                    @tailor10 ,
                                                                    @tailor11 ,
                                                                    @tailor12 ,
                                                                    @tailor13 ,
                                                                    @tailor14 ,
                                                                    @tailor15 ,
                                                                    @tailor16 ,
                                                                    @tailor17 ,
                                                                    @tailor18 ,
                                                                    @tailor19 ,
                                                                    @tailor20,
                                                                    @InvImg,
                                                                    @CusVenMob,
                                                                    @PriceIncludeTax,
																	@CInvType,
																	@Car_ID,
																	@Car_TypeNameA,
																	@Car_TypeNameE,
																	@Car_NameA,
																	@Car_NameE,
																	@PlateNo,
																	@Color,
																@ModelNo,
																@Delevery_Date,
																@VehiclechassisNumber,
																@OrderStatus
                                                              )
                                                              SELECT @InvHed_ID = SCOPE_IDENTITY()
                                                              RETURN 
                                                              END; 

";
        public static string BrTable = @"IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[T_Branch]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[T_Branch](
	[Branch_ID] [int] IDENTITY(1,1) NOT NULL,
	[Branch_no] [varchar](50) NOT NULL,
	[Branch_Name] [varchar](50) NULL,
	[Branch_NameE] [varchar](50) NULL,
	[Branch_address] [varchar](50) NULL,
	[Branch_city] [varchar](50) NULL,
	[Branch_phone] [varchar](50) NULL,
	[Branch_fax] [varchar](50) NULL,
	[Branch_mem] [varchar](max) NULL,
	[REP_FLG] [int] NULL,
	[StartEg] [varchar](30) NULL,
	[EndEg] [varchar](30) NULL,
	[crNo] [varchar](50) NULL,
	[crIssu] [varchar](50) NULL,
	[crExp] [varchar](50) NULL,
	[BldNo] [varchar](50) NULL,
	[BldIssu] [varchar](50) NULL,
	[BldExp] [varchar](50) NULL,
	[dfNo] [varchar](50) NULL,
	[dfIssu] [varchar](10) NULL,
	[dfExp] [varchar](10) NULL,
 CONSTRAINT [PK_T_Branch] PRIMARY KEY CLUSTERED 
(
	[Branch_no] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[T_Branch] ON 

INSERT [dbo].[T_Branch] ([Branch_ID], [Branch_no], [Branch_Name], [Branch_NameE], [Branch_address], [Branch_city], [Branch_phone], [Branch_fax], [Branch_mem], [REP_FLG], [StartEg], [EndEg], [crNo], [crIssu], [crExp], [BldNo], [BldIssu], [BldExp], [dfNo], [dfIssu], [dfExp]) VALUES (1, N'1', N'����� �������', N'Main Branch', N'----------', N'------------', N'-------------', N'', N'-------------', 0, N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
SET IDENTITY_INSERT [dbo].[T_Branch] OFF

END
";
        public static string UTable = @"IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[T_Users]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[T_Users](
	[Usr_ID] [int] IDENTITY(1,1) NOT NULL,
	[UsrNo] [varchar](3) NOT NULL,
	[UsrNamA] [varchar](50) NULL,
	[UsrNamE] [varchar](50) NULL,
	[Pass] [varchar](250) NULL,
	[Brn] [varchar](50) NULL,
	[Sts] [int] NULL,
	[Typ] [int] NULL,
	[ProLng] [int] NULL,
	[FilStr] [varchar](150) NULL,
	[InvStr] [varchar](150) NULL,
	[SndStr] [varchar](150) NULL,
	[StkRep] [varchar](150) NULL,
	[AccRep] [varchar](150) NULL,
	[SetStr] [varchar](150) NULL,
	[EditCost] [varchar](1) NULL,
	[PassQty] [varchar](150) NULL,
	[RepInv1] [varchar](100) NULL,
	[RepInv2] [varchar](100) NULL,
	[RepInv3] [varchar](100) NULL,
	[RepInv4] [varchar](100) NULL,
	[RepInv5] [varchar](100) NULL,
	[RepInv6] [varchar](100) NULL,
	[RepAcc1] [varchar](100) NULL,
	[RepAcc2] [varchar](100) NULL,
	[RepAcc3] [varchar](100) NULL,
	[RepAcc4] [varchar](100) NULL,
	[RepAcc5] [varchar](100) NULL,
	[RepAcc6] [varchar](100) NULL,
	[Emp_FilStr] [varchar](100) NULL,
	[Emp_MovStr] [varchar](100) NULL,
	[Emp_SalStr] [varchar](100) NULL,
	[Emp_RepStr] [varchar](100) NULL,
	[Emp_GenStr] [varchar](100) NULL,
	[CreateGaid] [int] NULL,
	[UserPointTyp] [int] NULL,
	[CashAccNo_D] [varchar](30) NULL,
	[CashAccNo_C] [varchar](30) NULL,
	[NetworkAccNo_D] [varchar](30) NULL,
	[NetworkAccNo_C] [varchar](30) NULL,
	[CreaditAccNo_D] [varchar](30) NULL,
	[CreaditAccNo_C] [varchar](30) NULL,
	[Comm_Inv] [float] NULL,
	[Comm_Gaid] [float] NULL,
	[CashAccNo_D_R] [varchar](30) NULL,
	[CashAccNo_C_R] [varchar](30) NULL,
	[NetworkAccNo_D_R] [varchar](30) NULL,
	[NetworkAccNo_C_R] [varchar](30) NULL,
	[CreaditAccNo_D_R] [varchar](30) NULL,
	[CreaditAccNo_C_R] [varchar](30) NULL,
	[PeaperTyp] [varchar](150) NULL,
	[StorePrmission] [varchar](250) NULL,
	[DefStores] [int] NULL,
	[StopBanner] [varchar](50) NULL,
	[UsrImg] [varbinary](max) NULL,
	[MaxDiscountSals] [float] NULL,
	[MaxDiscountPurchaes] [float] NULL,
	[vColumnStr1] [varchar](250) NULL,
	[vColumnStr2] [varchar](250) NULL,
	[vColumnStr3] [varchar](250) NULL,
	[vColumnStr4] [varchar](250) NULL,
	[vColumnNum1] [float] NULL,
	[vColumnNum2] [int] NULL,
	[Eqar_FilStr] [varchar](100) NULL,
	[Eqar_TenantStr] [varchar](100) NULL,
	[Eqar_RepStr] [varchar](100) NULL,
	[Eqar_GenStr] [varchar](100) NULL,
 CONSTRAINT [PK_T_Users] PRIMARY KEY CLUSTERED 
(
	[UsrNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

ALTER TABLE [dbo].[T_Users]  WITH CHECK ADD  CONSTRAINT [FK_T_Users_T_Branch] FOREIGN KEY([Brn])
REFERENCES [dbo].[T_Branch] ([Branch_no])

ALTER TABLE [dbo].[T_Users] CHECK CONSTRAINT [FK_T_Users_T_Branch]


SET IDENTITY_INSERT [dbo].[T_Users] ON 

INSERT [dbo].[T_Users] ([Usr_ID], [UsrNo], [UsrNamA], [UsrNamE], [Pass], [Brn], [Sts], [Typ], [ProLng], [FilStr], [InvStr], [SndStr], [StkRep], [AccRep], [SetStr], [EditCost], [PassQty], [RepInv1], [RepInv2], [RepInv3], [RepInv4], [RepInv5], [RepInv6], [RepAcc1], [RepAcc2], [RepAcc3], [RepAcc4], [RepAcc5], [RepAcc6], [Emp_FilStr], [Emp_MovStr], [Emp_SalStr], [Emp_RepStr], [Emp_GenStr], [CreateGaid], [UserPointTyp], [CashAccNo_D], [CashAccNo_C], [NetworkAccNo_D], [NetworkAccNo_C], [CreaditAccNo_D], [CreaditAccNo_C], [CashAccNo_D_R], [CashAccNo_C_R], [NetworkAccNo_D_R], [NetworkAccNo_C_R], [CreaditAccNo_D_R], [CreaditAccNo_C_R], [Comm_Inv], [Comm_Gaid], [PeaperTyp], [StorePrmission], [DefStores], [StopBanner], [UsrImg], [MaxDiscountSals], [MaxDiscountPurchaes], [vColumnStr1], [vColumnStr2], [vColumnStr3], [vColumnStr4], [vColumnNum1], [vColumnNum2], [Eqar_FilStr], [Eqar_TenantStr], [Eqar_RepStr], [Eqar_GenStr]) VALUES (1, N'1', N'����� �����', N'Support', N'flm8ZAF33tWSzGqBtqx+7z3fzGlwHHymse1vRjXS93smXO4DliC+wNFW5VWj9v7o', N'1', 0, 0, 0, N'11111111111111111111111111111111111111111111111111111111', N'1111111111111111111111111111111111111111111111111111111111111111111111', N'1111111111111111111111111111111111111111', N'111111111111111111111111111111', N'11111111111111', N'1111111111111111111111111111111111111111111110110111', N'0', N'1111111110001', N'1', N'0', N'0', N'0', N'', N'0', N'1111111111111111', N'1111111111111111111111111111', N'111111111111', N'111111111111111', N'0', N'0', N'1111111111111111111111111111111111111111111111111111', N'111111111111111111111111111111111111111111111111', N'1111111111', N'11111111111111111111111', N'1111111111111', 0, 0, N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'0000000000000', N'', 0, N'00', NULL, 0, 0, N'', N'', N'', N'', 0, 0, N'1111111111111111111111111111', N'1111111111111111', N'111111', N'1')
INSERT [dbo].[T_Users] ([Usr_ID], [UsrNo], [UsrNamA], [UsrNamE], [Pass], [Brn], [Sts], [Typ], [ProLng], [FilStr], [InvStr], [SndStr], [StkRep], [AccRep], [SetStr], [EditCost], [PassQty], [RepInv1], [RepInv2], [RepInv3], [RepInv4], [RepInv5], [RepInv6], [RepAcc1], [RepAcc2], [RepAcc3], [RepAcc4], [RepAcc5], [RepAcc6], [Emp_FilStr], [Emp_MovStr], [Emp_SalStr], [Emp_RepStr], [Emp_GenStr], [CreateGaid], [UserPointTyp], [CashAccNo_D], [CashAccNo_C], [NetworkAccNo_D], [NetworkAccNo_C], [CreaditAccNo_D], [CreaditAccNo_C], [CashAccNo_D_R], [CashAccNo_C_R], [NetworkAccNo_D_R], [NetworkAccNo_C_R], [CreaditAccNo_D_R], [CreaditAccNo_C_R], [Comm_Inv], [Comm_Gaid], [PeaperTyp], [StorePrmission], [DefStores], [StopBanner], [UsrImg], [MaxDiscountSals], [MaxDiscountPurchaes], [vColumnStr1], [vColumnStr2], [vColumnStr3], [vColumnStr4], [vColumnNum1], [vColumnNum2], [Eqar_FilStr], [Eqar_TenantStr], [Eqar_RepStr], [Eqar_GenStr]) VALUES (2, N'2', N'�������', N'Main', N'mELirpUhRYksFj7k8/XBcQ==', N'1', 0, 0, 0, N'11111111111111111111111111111111111111111111111111111111', N'1111111111111111111111111111111111111111111111111111111111111111111111', N'1111111111111111111111111111111111111111', N'111111111111111111111111111111', N'11111111111111', N'1111111111111111111111111111111111111111111110110111', N'0', N'1110111', N'1', N'0', N'0', N'0', N'', N'0', N'1111111111111111', N'1111111111111111111111111111', N'111111111111', N'111111111111111', N'0', N'0', N'1111111111111111111111111111111111111111111111111111', N'111111111111111111111111111111111111111111111111', N'1111111111', N'11111111111111111111111', N'1111111111111', 0, 0, N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'0000000000000', N'', 0, N'00', NULL, 0, 0, N'', N'', N'', N'', 0, 0, N'1111111111111111111111111111', N'1111111111111111', N'111111', N'1')
SET IDENTITY_INSERT [dbo].[T_Users] OFF



END";
        public static string Uptate3 = @"IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[T_SYSSETTING]') 
         AND name = 'AfterDotNum'
)
BEGIN
ALTER TABLE dbo.T_SYSSETTING ADD
	AfterDotNum int NULL
END ;";
        public static string Uptate4 = @"IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[T_INVHED]') 
         AND name = 'CInvType'
)
BEGIN
ALTER TABLE dbo.T_INVHED ADD
	CInvType int NULL
END ;";
        public static string Uptate5 = @"IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[T_INVDET]') 
         AND name = 'CInvType'
)
BEGIN
ALTER TABLE dbo.T_INVDET ADD
	CInvType int NULL
END ;";
        public static string BarbraScr = @"BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.T_INVDET ADD
	Mand_Name varchar(100) NULL,
	Mnd_ID int NULL,
	Mnd_No varchar(30) NULL
GO
ALTER TABLE dbo.T_INVDET SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.T_INVDET', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.T_INVDET', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.T_INVDET', 'Object', 'CONTROL') as Contr_Per ";
        public static string s8 = @"ALTER PROCEDURE [dbo].[S_T_SINVDET_DELETE](
                                                                @SInvDet_ID INT 
                                          )
                                          AS
                                          BEGIN
                                            declare @SInvTyp int 
                                            declare @SInvId int
                                            declare @SMndID int
                                            declare @SItemCountMnd int 
                                            declare @SMndKind int 
                                            declare @SRelation int
                                                   
                                            select @SInvId = SInvId from T_SINVDET where SInvDet_ID = @SInvDet_ID;
                                            select @SRelation = InvId from T_INVDET where InvDet_ID = @SInvId;
                                            select @SInvTyp = InvTyp from T_INVHED where InvHed_ID = @SRelation;
                                            select @SMndID = MndNo from T_INVHED where InvHed_ID = @SRelation;
                                            
                                            select @SMndKind = Mnd_Typ from T_Mndob where Mnd_ID = @SMndID;
                                            
                                            if(@SInvTyp != 7 and @SInvTyp != 8 and @SInvTyp != 9 and @SInvTyp != 21)
                                            begin
                                              if(@SMndKind != 1 or @SMndKind is null)
		                                          begin
			                                          UPDATE T_Items SET T_Items.OpenQty = T_Items.OpenQty - T_SINVDET.SRealQty 
			                                          From T_SINVDET Left Join T_Items ON (T_SINVDET.SItmNo = T_Items.Itm_No) 
			                                          where (SInvDet_ID = @SInvDet_ID) and (T_SINVDET.SItmTyp <> 3) and (T_SINVDET.SItmTyp <> 2);
			                                          UPDATE T_STKSQTY SET T_STKSQTY.stkQty = T_STKSQTY.stkQty - T_SINVDET.SRealQty 
			                                          From T_SINVDET Left Join T_STKSQTY ON (T_SINVDET.SItmNo = T_STKSQTY.itmNo) AND (T_SINVDET.SStoreNo = T_STKSQTY.storeNo)  
			                                          where @SInvDet_ID = SInvDet_ID and T_SINVDET.SItmTyp <> 3 and (T_SINVDET.SItmTyp <> 2);
                                        			  
			                                          UPDATE T_QTYEXP SET T_QTYEXP.stkQty = T_QTYEXP.stkQty - T_SINVDET.SRealQty 
			                                          From  T_SINVDET Left Join T_QTYEXP ON (T_SINVDET.SItmNo = T_QTYEXP.itmNo) AND (T_SINVDET.SStoreNo = T_QTYEXP.storeNo) AND (T_SINVDET.SDatExper = T_QTYEXP.DatExper)
			                                          where @SInvDet_ID = SInvDet_ID and T_SINVDET.SItmTyp <> 3 and (T_SINVDET.SItmTyp <> 2);
		                                          end
                                              if(@SInvTyp = 14)
		                                          begin
			                                          UPDATE T_STKSQTY SET T_STKSQTY.stkInt = T_STKSQTY.stkInt - T_SINVDET.SRealQty 
			                                          From T_SINVDET Left Join T_STKSQTY ON (T_SINVDET.SItmNo = T_STKSQTY.itmNo) AND (T_SINVDET.SStoreNo = T_STKSQTY.storeNo)  
			                                          where @SInvDet_ID = SInvDet_ID and T_SINVDET.SItmTyp <> 3 and (T_SINVDET.SItmTyp <> 2);
		                                          end
                                             if(@SInvTyp = 17)
	                                         begin
	 		                                          UPDATE T_Items SET T_Items.OpenQty = T_Items.OpenQty - T_SINVDET.SRealQty 
			                                          From T_SINVDET Left Join T_Items ON (T_SINVDET.SItmNo = T_Items.Itm_No) 
			                                          where (SInvDet_ID = @SInvDet_ID) and (T_SINVDET.SItmTyp <> 3) and (T_SINVDET.SItmTyp <> 2);
			                                          UPDATE T_STKSQTY SET T_STKSQTY.stkQty = T_STKSQTY.stkQty - T_SINVDET.SRealQty 
			                                          From T_SINVDET Left Join T_STKSQTY ON (T_SINVDET.SItmNo = T_STKSQTY.itmNo) AND (T_SINVDET.SStoreNo = T_STKSQTY.storeNo)  
			                                          where @SInvDet_ID = SInvDet_ID and T_SINVDET.SItmTyp <> 3 and (T_SINVDET.SItmTyp <> 2);
                                        			  
			                                          UPDATE T_QTYEXP SET T_QTYEXP.stkQty = T_QTYEXP.stkQty - T_SINVDET.SRealQty 
			                                          From  T_SINVDET Left Join T_QTYEXP ON (T_SINVDET.SItmNo = T_QTYEXP.itmNo) AND (T_SINVDET.SStoreNo = T_QTYEXP.storeNo) AND (T_SINVDET.SDatExper = T_QTYEXP.DatExper)
			                                          where @SInvDet_ID = SInvDet_ID and T_SINVDET.SItmTyp <> 3 ;
                                        			  
	                                             -- select @SMndID = MndNo from T_INVHED where InvHed_ID = @SRelation;
		                                         -- UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty - abs(T_SINVDET.SRealQty)
		                                         -- From T_SINVDET Left Join T_StoreMnd ON (T_SINVDET.SItmNo = T_StoreMnd.itmNo) AND (T_SINVDET.SStoreNo = T_StoreMnd.storeNo)  
		                                         -- where @SInvDet_ID = SInvDet_ID and T_SINVDET.SItmTyp <> 3 and (T_SINVDET.SItmTyp <> 2) and T_StoreMnd.MndNo = @SMndID ;
                                             end
                                             
                                             if(@SInvTyp = 20)
	                                         begin
	       	                                          UPDATE T_Items SET T_Items.OpenQty = T_Items.OpenQty - T_SINVDET.SRealQty 
			                                          From T_SINVDET Left Join T_Items ON (T_SINVDET.SItmNo = T_Items.Itm_No) 
			                                          where (SInvDet_ID = @SInvDet_ID) and (T_SINVDET.SItmTyp <> 3) and (T_SINVDET.SItmTyp <> 2);
			                                          UPDATE T_STKSQTY SET T_STKSQTY.stkQty = T_STKSQTY.stkQty - T_SINVDET.SRealQty 
			                                          From T_SINVDET Left Join T_STKSQTY ON (T_SINVDET.SItmNo = T_STKSQTY.itmNo) AND (T_SINVDET.SStoreNo = T_STKSQTY.storeNo)  
			                                          where @SInvDet_ID = SInvDet_ID and T_SINVDET.SItmTyp <> 3 and (T_SINVDET.SItmTyp <> 2);
                                        			  
			                                          UPDATE T_QTYEXP SET T_QTYEXP.stkQty = T_QTYEXP.stkQty - T_SINVDET.SRealQty 
			                                          From  T_SINVDET Left Join T_QTYEXP ON (T_SINVDET.SItmNo = T_QTYEXP.itmNo) AND (T_SINVDET.SStoreNo = T_QTYEXP.storeNo) AND (T_SINVDET.SDatExper = T_QTYEXP.DatExper)
			                                          where @SInvDet_ID = SInvDet_ID and T_SINVDET.SItmTyp <> 3 and (T_SINVDET.SItmTyp <> 2);
                                        			  
	                                            --  select @SMndID = MndNo from T_INVHED where InvHed_ID = @SRelation;
		                                        --  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty + T_SINVDET.SRealQty 
		                                        --  From T_SINVDET Left Join T_StoreMnd ON (T_SINVDET.SItmNo = T_StoreMnd.itmNo) AND (T_SINVDET.SStoreNo = T_StoreMnd.storeNo)  
		                                        --  where @SInvDet_ID = SInvDet_ID and T_SINVDET.SItmTyp <> 3 and (T_SINVDET.SItmTyp <> 2) and T_StoreMnd.MndNo = @SMndID ;
                                             end
                                            end
                                        
                                          DELETE FROM T_SINVDET
                                          WHERE      @SInvDet_ID = SInvDet_ID   
                                          RETURN
                                          END
";
        public static string s5 = @"  ALTER PROCEDURE [dbo].[S_T_INVDET_DELETE](
                                                      @InvDet_ID INT 
                                          )
                                          AS
                                          BEGIN
                                        declare @InvTyp int 
                                        declare @InvId int
                                        declare @MndID int
                                        declare @CusVenNo varchar(30)
                                        declare @PaymentOrderTyp int
                                        declare @ItemCountMnd int 
                                        declare @MndKind int 
                                         
                                        select @InvId = InvId from T_INVDET where InvDet_ID = @InvDet_ID;
                                        select @InvTyp = InvTyp from T_INVHED where InvHed_ID = @InvId;
                                        select @MndID = MndNo from T_INVHED where InvHed_ID = @InvId;
                                        
                                        select @PaymentOrderTyp = PaymentOrderTyp from T_INVHED where InvHed_ID = @InvId;
                                        select @CusVenNo = CusVenNo from T_INVHED where InvHed_ID = @InvId;
                                        
                                        select @MndKind = Mnd_Typ from T_Mndob where Mnd_ID = @MndID;
                                        
                                        if(@InvTyp != 7 and @InvTyp != 8 and @InvTyp != 9 and @InvTyp != 21)
                                        begin
                                             if((@PaymentOrderTyp <= 0 or @PaymentOrderTyp is null) or  ((@PaymentOrderTyp = 1 or @PaymentOrderTyp = 2) and (@InvTyp = 17 or @InvTyp = 20) ))
		                                      begin
			                                      UPDATE T_Items SET T_Items.OpenQty = T_Items.OpenQty - T_INVDET.RealQty 
			                                      From T_INVDET Left Join T_Items ON (T_INVDET.ItmNo = T_Items.Itm_No) 
			                                      where (InvDet_ID = @InvDet_ID) and (T_INVDET.ItmTyp <> 3) and (T_INVDET.ItmTyp <> 2);
			                                      UPDATE T_STKSQTY SET T_STKSQTY.stkQty = T_STKSQTY.stkQty - T_INVDET.RealQty 
			                                      From T_INVDET Left Join T_STKSQTY ON (T_INVDET.ItmNo = T_STKSQTY.itmNo) AND (T_INVDET.StoreNo = T_STKSQTY.storeNo)  
			                                      where @InvDet_ID = InvDet_ID and T_INVDET.ItmTyp <> 3 and (T_INVDET.ItmTyp <> 2);
                                    			  
			                                      UPDATE T_QTYEXP SET T_QTYEXP.stkQty = T_QTYEXP.stkQty - T_INVDET.RealQty 
			                                      From  T_INVDET Left Join T_QTYEXP ON (T_INVDET.ItmNo = T_QTYEXP.itmNo) AND (T_INVDET.StoreNo = T_QTYEXP.storeNo) AND (T_INVDET.DatExper = T_QTYEXP.DatExper and T_INVDET.RunCod = T_QTYEXP.RunCod )
			                                      where @InvDet_ID = InvDet_ID and T_INVDET.ItmTyp <> 3 and (T_INVDET.ItmTyp <> 2);
                                             end
                                             if(@InvTyp = 14)
		                                      begin
			                                      UPDATE T_STKSQTY SET T_STKSQTY.stkInt = T_STKSQTY.stkInt - T_INVDET.RealQty 
			                                      From T_INVDET Left Join T_STKSQTY ON (T_INVDET.ItmNo = T_STKSQTY.itmNo) AND (T_INVDET.StoreNo = T_STKSQTY.storeNo)  
			                                      where @InvDet_ID = InvDet_ID and T_INVDET.ItmTyp <> 3 and (T_INVDET.ItmTyp <> 2);
		                                      end
                                         if(@InvTyp = 17)
	                                     begin
                                    				  
													  select @MndID = MndNo from T_INVHED where InvHed_ID = @InvId;
													  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty - abs(T_INVDET.RealQty)
													  From T_INVDET Left Join T_StoreMnd ON (T_INVDET.ItmNo = T_StoreMnd.itmNo) AND (T_INVDET.StoreNo = T_StoreMnd.storeNo)  
													  where @InvDet_ID = InvDet_ID and T_INVDET.ItmTyp <> 3 and T_StoreMnd.MndNo = @MndID ;
				                                      
													  select @CusVenNo = CusVenNo from T_INVHED where InvHed_ID = @InvId;
													  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty - abs(T_INVDET.RealQty)
													  From T_INVDET Left Join T_StoreMnd ON (T_INVDET.ItmNo = T_StoreMnd.itmNo) AND (T_INVDET.StoreNo = T_StoreMnd.storeNo)  
													  where @InvDet_ID = InvDet_ID and T_INVDET.ItmTyp <> 3 and T_StoreMnd.CusVenNo = @CusVenNo ;
                                         end
                                         
                                         if(@InvTyp = 20)
	                                     begin
                                    				   
														  select @MndID = MndNo from T_INVHED where InvHed_ID = @InvId;
														  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty + T_INVDET.RealQty 
														  From T_INVDET Left Join T_StoreMnd ON (T_INVDET.ItmNo = T_StoreMnd.itmNo) AND (T_INVDET.StoreNo = T_StoreMnd.storeNo)  
														  where @InvDet_ID = InvDet_ID and T_INVDET.ItmTyp <> 3 and T_StoreMnd.MndNo = @MndID ;
					                                      
														  select @CusVenNo = CusVenNo from T_INVHED where InvHed_ID = @InvId;
														  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty + T_INVDET.RealQty 
														  From T_INVDET Left Join T_StoreMnd ON (T_INVDET.ItmNo = T_StoreMnd.itmNo) AND (T_INVDET.StoreNo = T_StoreMnd.storeNo)  
														  where @InvDet_ID = InvDet_ID and T_INVDET.ItmTyp <> 3 and T_StoreMnd.CusVenNo = @CusVenNo ;
                                         end
                                        end
                                         
                                          DELETE FROM T_INVDET
                                          WHERE      @InvDet_ID = InvDet_ID    
                                          RETURN
                                          END
";
        public static string s9 = @" ALTER PROCEDURE [dbo].[S_T_SINVDET_INSERT](   
                                                 @SInvDet_ID INT OUTPUT,
                                                 @SInvNo VARCHAR (10)=NULL,
                                                 @SInvId INT =NULL,
                                                 @SInvSer INT =NULL,
                                                 @SItmNo VARCHAR (50)=NULL,
                                                 @SCost FLOAT =NULL,
                                                 @SQty FLOAT =NULL,
                                                 @SItmDes VARCHAR (50)=NULL,
                                                 @SItmUnt VARCHAR (100)=NULL,
                                                 @SItmDesE VARCHAR (50)=NULL,
                                                 @SItmUntE VARCHAR (100)=NULL,
                                                 @SItmUntPak FLOAT =NULL,
                                                 @SStoreNo INT=NULL,
                                                 @SPrice FLOAT =NULL,
                                                 @SAmount FLOAT =NULL,
                                                 @SRealQty FLOAT =NULL,
                                                 @SitmInvDsc FLOAT =NULL,
                                                 @SDatExper VARCHAR (11)=NULL,
                                                 @SItmDis FLOAT =NULL,
                                                 @SItmTyp INT =NULL,
                                                 @SItmIndex INT =NULL,
                                                 @SItmWight FLOAT =NULL,
                                                 @SItmWight_T FLOAT =NULL,
                                                 @SQtyDef FLOAT =NULL,
                                                 @SPriceDef FLOAT =NULL,
                                                 @SInvIdHEAD INT =NULL,
                                                 @SItmTax FLOAT =NULL  
                                                 
                                          )
                                          AS
                                          BEGIN
                                          INSERT INTO T_SINVDET(
                                                 SInvNo,
                                                 SInvId,
                                                 SInvSer,
                                                 SItmNo,
                                                 SCost,
                                                 SQty,
                                                 SItmDes,
                                                 SItmUnt,
                                                 SItmDesE,
                                                 SItmUntE,
                                                 SItmUntPak,
                                                 SStoreNo,
                                                 SPrice,
                                                 SAmount,
                                                 SRealQty,
                                                 SitmInvDsc,
                                                 SDatExper,
                                                 SItmDis,
                                                 SItmTyp,
                                                 SItmIndex,
                                                 SItmWight,
                                                 SItmWight_T,
                                                 SQtyDef,
                                                 SPriceDef,
                                                 SInvIdHEAD,
                                                 SItmTax
                                          )
                                          VALUES
                                          (
                                                @SInvNo,
                                                @SInvId,
                                                @SInvSer,
                                                @SItmNo,
                                                @SCost,
                                                @SQty,
                                                @SItmDes,
                                                @SItmUnt,
                                                @SItmDesE,
                                                @SItmUntE,
                                                @SItmUntPak,
                                                @SStoreNo,
                                                @SPrice,
                                                @SAmount,
                                                @SRealQty,
                                                @SitmInvDsc,
                                                @SDatExper,
                                                @SItmDis,
                                                @SItmTyp,
                                                @SItmIndex,
                                                @SItmWight,
                                                @SItmWight_T,
                                                @SQtyDef,
                                                @SPriceDef,
                                                @SInvIdHEAD,
                                                @SItmTax
                                          )
                                          SELECT @SInvDet_ID = SCOPE_IDENTITY()
                                                declare @SItemCount int  
                                                declare @SInvTyp int
                                                declare @SMndID int
                                                declare @SItemCountMnd int 
                                                declare @SRelation int
                                                   
                                                select @SRelation = InvId from T_INVDET where InvDet_ID = @SInvId;
                                                select @SItemCount = Count(*) from T_STKSQTY where itmNo = @SItmNo and storeNo =@SStoreNo;
                                                select @SInvTyp = InvTyp from T_INVHED where InvHed_ID = @SRelation;
                                                if((@SInvTyp != 7 and @SInvTyp != 8 and @SInvTyp != 9 and @SInvTyp != 21) and @SItmTyp <> 3 and @SItmTyp <> 2)
                                                begin
                                                    Update T_Items SET OpenQty = OpenQty+@SRealQty WHERE Itm_No = @SItmNo;
                                                    if(@SItemCount > 0)
                                                    begin
                                                    Update T_STKSQTY SET stkQty = stkQty+@SRealQty WHERE itmNo = @SItmNo and storeNo = @SStoreNo;
                                                    end
                                                    if(@SItemCount = 0)
                                                    begin 
                                                    INSERT INTO T_STKSQTY(itmNo,storeNo,stkQty,stkInt) VALUES(@SItmNo,@SStoreNo,@SRealQty,0);
                                                    END
                                                    if(@SInvTyp = 14)
                                                    begin
                                                        Update T_STKSQTY SET stkInt = stkInt+@SRealQty WHERE itmNo = @SItmNo and storeNo = @SStoreNo;
                                                    end
                                                    select @SItemCount = Count(*) from T_QTYEXP where itmNo = @SItmNo and storeNo =@SStoreNo and DatExper = @SDatExper;
                                                    if(@SItemCount > 0 and @SDatExper <> '')
                                                    begin
                                                    Update T_QTYEXP SET stkQty = stkQty+@SRealQty WHERE itmNo = @SItmNo and storeNo = @SStoreNo and DatExper = @SDatExper;
                                                    end
                                                    if(@SItemCount = 0 and @SDatExper <> '')
                                                    begin 
                                                    INSERT INTO T_QTYEXP(itmNo,storeNo,DatExper,stkQty) VALUES(@SItmNo,@SStoreNo,@SDatExper,@SRealQty);
                                                    END
--                                                    if(@SInvTyp = 17)
--                                                        begin
--                                                         select @SMndID = MndNo from T_INVHED where InvHed_ID = @SRelation;
--                                                            select @SItemCountMnd = Count(*) from T_StoreMnd where itmNo = @SItmNo and storeNo =@SStoreNo and MndNo = @SMndID;
--                                                                    if(@SItemCountMnd > 0)
--                                                                    begin
--                                                                         Update T_StoreMnd SET stkQty = stkQty + abs(@SRealQty) WHERE itmNo = @SItmNo and storeNo = @SStoreNo and MndNo = @SMndID;
--                                                                    end
--
--                                                                    if(@SItemCountMnd = 0)
--                                                                    begin 
--                                                                         INSERT INTO T_StoreMnd(itmNo,storeNo,stkQty,stkInt,MndNo) VALUES(@SItmNo,@SStoreNo,abs(@SRealQty),0,@SMndID);
--                                                                    END
--                                                        end	
--                                                    if(@SInvTyp = 20)
--                                                        begin
--                                                         select @SMndID = MndNo from T_INVHED where InvHed_ID = @SRelation;
--                                                            select @SItemCountMnd = Count(*) from T_StoreMnd where itmNo = @SItmNo and storeNo =@SStoreNo and MndNo = @SMndID;
--                                                                    if(@SItemCountMnd > 0)
--                                                                    begin
--                                                                         Update T_StoreMnd SET stkQty = stkQty + (-@SRealQty) WHERE itmNo = @SItmNo and storeNo = @SStoreNo and MndNo = @SMndID;
--                                                                    end
--
--                                                                    if(@SItemCountMnd = 0)
--                                                                    begin 
--                                                                         INSERT INTO T_StoreMnd(itmNo,storeNo,stkQty,stkInt,MndNo) VALUES(@SItmNo,@SStoreNo,-@SRealQty,0,@SMndID);
--                                                                    END
--                                                        end
                                                end
                                              RETURN
                                              END
";
        public static string s10 = @"ALTER PROCEDURE[dbo].[S_T_INVHED_INSERT]
        (
                                                                    @InvHed_ID INT OUTPUT,
                                                                    @InvId FLOAT =NULL,
                                                                     @InvNo VARCHAR(10),
                                                                     @InvTyp INT = NULL,
                                                                     @InvCashPay INT =NULL,
                                                                     @CusVenNo VARCHAR(20)=NULL,
                                                                     @CusVenNm VARCHAR(50)=NULL,
                                                                     @CusVenAdd VARCHAR(100)=NULL,
                                                                     @CusVenTel VARCHAR(30)=NULL,
                                                                     @Remark VARCHAR(MAX)=NULL,
                                                                     @HDat VARCHAR(10)=NULL,
                                                                     @GDat VARCHAR(10)=NULL,
                                                                     @MndNo INT = NULL,
                                                                     @SalsManNo VARCHAR(3)=NULL,
                                                                     @SalsManNam VARCHAR(50)=NULL,
                                                                     @InvTot FLOAT = NULL,
                                                                     @InvTotLocCur FLOAT =NULL,
                                                                     @InvDisPrs FLOAT = NULL,
                                                                     @InvDisVal FLOAT =NULL,
                                                                     @InvDisValLocCur FLOAT = NULL,
                                                                     @InvNet FLOAT =NULL,
                                                                     @InvNetLocCur FLOAT = NULL,
                                                                     @CashPay FLOAT =NULL,
                                                                     @CashPayLocCur FLOAT = NULL,
                                                                     @IfRet INT =NULL,
                                                                     @GadeNo FLOAT = NULL,
                                                                     @GadeId FLOAT =NULL,
                                                                     @IfDel INT = NULL,
                                                                     @RetNo VARCHAR(10)=NULL,
                                                                     @RetId FLOAT = NULL,
                                                                     @InvCstNo INT =NULL,
                                                                     @InvCashPayNm VARCHAR(100)=NULL,
                                                                     @RefNo VARCHAR(20)=NULL,
                                                                     @InvCost FLOAT = NULL,
                                                                     @EstDat VARCHAR(10)=NULL,
                                                                     @CustPri INT = NULL,
                                                                     @ArbTaf VARCHAR(150)=NULL,
                                                                     @CurTyp INT = NULL,
                                                                     @InvCash VARCHAR(20)=NULL,
                                                                     @ToStore VARCHAR(3)=NULL,
                                                                     @ToStoreNm VARCHAR(50)=NULL,
                                                                     @InvQty FLOAT = NULL,
                                                                     @EngTaf VARCHAR(150)=NULL,
                                                                     @IfTrans INT = NULL,
                                                                     @CustRep FLOAT =NULL,
                                                                     @CustNet FLOAT = NULL,
                                                                     @InvWight_T FLOAT =NULL,
                                                                     @IfPrint INT = NULL,
                                                                     @LTim VARCHAR(10)=NULL,
                                                                     @CREATED_BY VARCHAR(100) =NULL,
                                                                     @DATE_CREATED datetime = NULL,
                                                                     @MODIFIED_BY VARCHAR(100)=NULL,
                                                                     @DATE_MODIFIED datetime = NULL,
                                                                     @CreditPay float=NULL,
                                                                     @CreditPayLocCur float=NULL,
                                                                     @NetworkPay float=NULL,
                                                                     @NetworkPayLocCur float=NULL,
                                                                     @CommMnd_Inv float=NULL,
                                                                     @MndExtrnal bit = NULL,
                                                                     @CompanyID int=NULL,
                                                                     @InvAddCost float=NULL,
                                                                     @InvAddCostLoc float=NULL,
                                                                     @InvAddCostExtrnal float=NULL,
                                                                     @InvAddCostExtrnalLoc float=NULL,
                                                                     @IsExtrnalGaid bit = NULL,
                                                                     @ExtrnalCostGaidID float=NULL,
                                                                     @Puyaid float=NULL,
                                                                     @Remming float=NULL,
                                                                     @RoomNo int=NULL,
                                                                     @OrderTyp int=NULL,
                                                                     @RoomSts bit = NULL,
                                                                     @chauffeurNo int=NULL,
                                                                     @RoomPerson int=NULL,
                                                                     @ServiceValue float=NULL,
                                                                     @Sts bit = NULL,
                                                                     @PaymentOrderTyp int=NULL,
                                                                     @AdminLock bit = NULL,
                                                                     @DeleteDate VARCHAR(10)=NULL,
                                                                     @DeleteTime VARCHAR(10)=NULL,
                                                                     @UserNew VARCHAR(3)=NULL,
                                                                     @IfEnter int=NULL,
                                                                     @InvAddTax float=NULL,
                                                                     @InvAddTaxlLoc float=NULL,
                                                                     @IsTaxGaid bit = NULL,
                                                                     @TaxGaidID float=NULL,
                                                                     @IsTaxUse bit = NULL,
                                                                     @InvValGaidDis float=NULL,
                                                                     @InvValGaidDislLoc float=NULL,
                                                                     @IsDisGaid bit = NULL,
                                                                     @DisGaidID1 float=NULL,
                                                                     @IsDisUse1 bit = NULL,
                                                                     @InvComm float=NULL,
                                                                     @InvCommLoc float=NULL,
                                                                     @IsCommGaid bit = NULL,
                                                                     @CommGaidID float=NULL,
                                                                     @IsCommUse bit = NULL,
                                                                     @IsTaxLines bit=NULL,
                                                                     @IsTaxByTotal bit = NULL,
                                                                     @IsTaxByNet bit=NULL,
                                                                     @TaxByNetValue float=NULL,
                                                                     @DesPointsValue float=NULL,
                                                                     @DesPointsValueLocCur float=NULL,
                                                                     @PointsCount float=NULL,
                                                                     @IsPoints bit = NULL,
                                                                     @tailor1 VARCHAR(100)=NULL,
                                                                     @tailor2 VARCHAR(100)=NULL,
                                                                     @tailor3 VARCHAR(100)=NULL,
                                                                     @tailor4 VARCHAR(100)=NULL,
                                                                     @tailor5 VARCHAR(100)=NULL,
                                                                     @tailor6 VARCHAR(100)=NULL,
                                                                     @tailor7 VARCHAR(100)=NULL,
                                                                     @tailor8 VARCHAR(100)=NULL,
                                                                     @tailor9 VARCHAR(100)=NULL,
                                                                     @tailor10 VARCHAR(100)=NULL,
                                                                     @tailor11 VARCHAR(100)=NULL,
                                                                     @tailor12 VARCHAR(100)=NULL,
                                                                     @tailor13 VARCHAR(100)=NULL,
                                                                     @tailor14 VARCHAR(100)=NULL,
                                                                     @tailor15 VARCHAR(100)=NULL,
                                                                     @tailor16 VARCHAR(100)=NULL,
                                                                     @tailor17 VARCHAR(100)=NULL,
                                                                     @tailor18 VARCHAR(100)=NULL,
                                                                     @tailor19 VARCHAR(100)=NULL,
                                                                     @tailor20 VARCHAR(100)=NULL,
                                                                     @InvImg[varbinary] (max) =NULL,
                                                                     @CusVenMob VARCHAR(50) =NULL,
                                                                     @PriceIncludeTax BIT = NULL
                                                              )
                                                              AS
                                                              BEGIN
                                                              INSERT INTO T_INVHED(
                                                                     InvId,
                                                                     InvNo,
                                                                     InvTyp,
                                                                     InvCashPay,
                                                                     CusVenNo,
                                                                     CusVenNm,
                                                                     HDat,
                                                                     CusVenAdd,
                                                                     CusVenTel,
                                                                     Remark,
                                                                     GDat,
                                                                     MndNo,
                                                                     SalsManNo,
                                                                     SalsManNam,
                                                                     InvTot,
                                                                     InvTotLocCur,
                                                                     InvDisPrs,
                                                                     InvDisVal,
                                                                     InvDisValLocCur,
                                                                     InvNet,
                                                                     InvNetLocCur,
                                                                     CashPay,
                                                                     CashPayLocCur,
                                                                     IfRet,
                                                                     GadeNo,
                                                                     GadeId,
                                                                     IfDel,
                                                                     RetNo,
                                                                     RetId,
                                                                     InvCstNo,
                                                                     InvCashPayNm,
                                                                     RefNo,
                                                                     InvCost,
                                                                     EstDat,
                                                                     CustPri,
                                                                     ArbTaf,
                                                                     CurTyp,
                                                                     InvCash,
                                                                     ToStore,
                                                                     ToStoreNm,
                                                                     InvQty,
                                                                     EngTaf,
                                                                     IfTrans,
                                                                     CustRep,
                                                                     CustNet,
                                                                     InvWight_T,
                                                                     IfPrint,
                                                                     LTim,
                                                                     CREATED_BY,
                                                                     DATE_CREATED,
                                                                     MODIFIED_BY ,
                                                                     DATE_MODIFIED ,
                                                                     CreditPay ,
                                                                     CreditPayLocCur ,
                                                                     NetworkPay ,
                                                                     NetworkPayLocCur ,
                                                                     CommMnd_Inv ,
                                                                     MndExtrnal ,
                                                                     CompanyID ,
                                                                     InvAddCost ,
                                                                     InvAddCostLoc ,
                                                                     InvAddCostExtrnal ,
                                                                     InvAddCostExtrnalLoc ,
                                                                     IsExtrnalGaid ,
                                                                     ExtrnalCostGaidID ,
                                                                     Puyaid ,
                                                                     Remming ,
                                                                     RoomNo ,
                                                                     OrderTyp ,
                                                                     RoomSts ,
                                                                     chauffeurNo ,
                                                                     RoomPerson ,
                                                                     ServiceValue ,
                                                                     Sts ,
                                                                     PaymentOrderTyp ,
                                                                     AdminLock ,
                                                                     DeleteDate ,
                                                                     DeleteTime ,
                                                                     UserNew ,
                                                                     IfEnter ,
                                                                     InvAddTax ,
                                                                     InvAddTaxlLoc ,
                                                                     IsTaxGaid ,
                                                                     TaxGaidID ,
                                                                     IsTaxUse ,
                                                                     InvValGaidDis ,
                                                                     InvValGaidDislLoc ,
                                                                     IsDisGaid ,
                                                                     DisGaidID1 ,
                                                                     IsDisUse1 ,
                                                                     InvComm ,
                                                                     InvCommLoc ,
                                                                     IsCommGaid ,
                                                                     CommGaidID ,
                                                                     IsCommUse ,
                                                                     IsTaxLines ,
                                                                     IsTaxByTotal ,
                                                                     IsTaxByNet ,
                                                                     TaxByNetValue ,
                                                                     DesPointsValue ,
                                                                     DesPointsValueLocCur ,
                                                                     PointsCount,
                                                                     IsPoints,
                                                                     tailor1 ,
                                                                     tailor2 ,
                                                                     tailor3 ,
                                                                     tailor4 ,
                                                                     tailor5 ,
                                                                     tailor6 ,
                                                                     tailor7 ,
                                                                     tailor8 ,
                                                                     tailor9 ,
                                                                     tailor10 ,
                                                                     tailor11 ,
                                                                     tailor12 ,
                                                                     tailor13 ,
                                                                     tailor14 ,
                                                                     tailor15 ,
                                                                     tailor16 ,
                                                                     tailor17 ,
                                                                     tailor18 ,
                                                                     tailor19 ,
                                                                     tailor20,
                                                                     InvImg,
                                                                     CusVenMob,
                                                                     PriceIncludTax
                                                              )
                                                              VALUES
                                                              (
                                                                    @InvId,
                                                                    @InvNo,
                                                                    @InvTyp,
                                                                    @InvCashPay,
                                                                    @CusVenNo,
                                                                    @CusVenNm,
                                                                    @HDat,
                                                                    @CusVenAdd,
                                                                    @CusVenTel,
                                                                    @Remark,
                                                                    @GDat,
                                                                    @MndNo,
                                                                    @SalsManNo,
                                                                    @SalsManNam,
                                                                    @InvTot,
                                                                    @InvTotLocCur,
                                                                    @InvDisPrs,
                                                                    @InvDisVal,
                                                                    @InvDisValLocCur,
                                                                    @InvNet,
                                                                    @InvNetLocCur,
                                                                    @CashPay,
                                                                    @CashPayLocCur,
                                                                    @IfRet,
                                                                    @GadeNo,
                                                                    @GadeId,
                                                                    @IfDel,
                                                                    @RetNo,
                                                                    @RetId,
                                                                    @InvCstNo,
                                                                    @InvCashPayNm,
                                                                    @RefNo,
                                                                    @InvCost,
                                                                    @EstDat,
                                                                    @CustPri,
                                                                    @ArbTaf,
                                                                    @CurTyp,
                                                                    @InvCash,
                                                                    @ToStore,
                                                                    @ToStoreNm,
                                                                    @InvQty,
                                                                    @EngTaf,
                                                                    @IfTrans,
                                                                    @CustRep,
                                                                    @CustNet,
                                                                    @InvWight_T,
                                                                    @IfPrint,
                                                                    @LTim,
                                                                    @CREATED_BY,
                                                                    @DATE_CREATED,
                                                                    @MODIFIED_BY ,
                                                                    @DATE_MODIFIED ,
                                                                    @CreditPay ,
                                                                    @CreditPayLocCur ,
                                                                    @NetworkPay ,
                                                                    @NetworkPayLocCur ,
                                                                    @CommMnd_Inv ,
                                                                    @MndExtrnal ,
                                                                    @CompanyID ,
                                                                    @InvAddCost ,
                                                                    @InvAddCostLoc ,
                                                                    @InvAddCostExtrnal ,
                                                                    @InvAddCostExtrnalLoc ,
                                                                    @IsExtrnalGaid ,
                                                                    @ExtrnalCostGaidID ,
                                                                    @Puyaid ,
                                                                    @Remming ,
                                                                    @RoomNo ,
                                                                    @OrderTyp ,
                                                                    @RoomSts ,
                                                                    @chauffeurNo ,
                                                                    @RoomPerson ,
                                                                    @ServiceValue ,
                                                                    @Sts ,
                                                                    @PaymentOrderTyp ,
                                                                    @AdminLock ,
                                                                    @DeleteDate ,
                                                                    @DeleteTime ,
                                                                    @UserNew ,
                                                                    @IfEnter ,
                                                                    @InvAddTax ,
                                                                    @InvAddTaxlLoc ,
                                                                    @IsTaxGaid ,
                                                                    @TaxGaidID ,
                                                                    @IsTaxUse ,
                                                                    @InvValGaidDis ,
                                                                    @InvValGaidDislLoc ,
                                                                    @IsDisGaid ,
                                                                    @DisGaidID1 ,
                                                                    @IsDisUse1 ,
                                                                    @InvComm ,
                                                                    @InvCommLoc ,
                                                                    @IsCommGaid ,
                                                                    @CommGaidID ,
                                                                    @IsCommUse ,
                                                                    @IsTaxLines ,
                                                                    @IsTaxByTotal ,
                                                                    @IsTaxByNet ,
                                                                    @TaxByNetValue ,
                                                                    @DesPointsValue ,
                                                                    @DesPointsValueLocCur ,
                                                                    @PointsCount,
                                                                    @IsPoints,
                                                                    @tailor1 ,
                                                                    @tailor2 ,
                                                                    @tailor3 ,
                                                                    @tailor4 ,
                                                                    @tailor5 ,
                                                                    @tailor6 ,
                                                                    @tailor7 ,
                                                                    @tailor8 ,
                                                                    @tailor9 ,
                                                                    @tailor10 ,
                                                                    @tailor11 ,
                                                                    @tailor12 ,
                                                                    @tailor13 ,
                                                                    @tailor14 ,
                                                                    @tailor15 ,
                                                                    @tailor16 ,
                                                                    @tailor17 ,
                                                                    @tailor18 ,
                                                                    @tailor19 ,
                                                                    @tailor20,
                                                                    @InvImg,
                                                                    @CusVenMob,
                                                                    @PriceIncludeTax
                                                              )
                                                              SELECT @InvHed_ID = SCOPE_IDENTITY()
                                                              RETURN @InvHed_ID
                                                              END;";
        public static string s1 = @"
CREATE PROCEDURE[dbo].[S_T_INVHED_INSERT]
        (
                                                                    @InvHed_ID INT OUTPUT,
                                                                    @InvId FLOAT =NULL,
                                                                     @InvNo VARCHAR(10),
                                                                     @InvTyp INT = NULL,
                                                                     @InvCashPay INT =NULL,
                                                                     @CusVenNo VARCHAR(20)=NULL,
                                                                     @CusVenNm VARCHAR(50)=NULL,
                                                                     @CusVenAdd VARCHAR(100)=NULL,
                                                                     @CusVenTel VARCHAR(30)=NULL,
                                                                     @Remark VARCHAR(MAX)=NULL,
                                                                     @HDat VARCHAR(10)=NULL,
                                                                     @GDat VARCHAR(10)=NULL,
                                                                     @MndNo INT = NULL,
                                                                     @SalsManNo VARCHAR(3)=NULL,
                                                                     @SalsManNam VARCHAR(50)=NULL,
                                                                     @InvTot FLOAT = NULL,
                                                                     @InvTotLocCur FLOAT =NULL,
                                                                     @InvDisPrs FLOAT = NULL,
                                                                     @InvDisVal FLOAT =NULL,
                                                                     @InvDisValLocCur FLOAT = NULL,
                                                                     @InvNet FLOAT =NULL,
                                                                     @InvNetLocCur FLOAT = NULL,
                                                                     @CashPay FLOAT =NULL,
                                                                     @CashPayLocCur FLOAT = NULL,
                                                                     @IfRet INT =NULL,
                                                                     @GadeNo FLOAT = NULL,
                                                                     @GadeId FLOAT =NULL,
                                                                     @IfDel INT = NULL,
                                                                     @RetNo VARCHAR(10)=NULL,
                                                                     @RetId FLOAT = NULL,
                                                                     @InvCstNo INT =NULL,
                                                                     @InvCashPayNm VARCHAR(100)=NULL,
                                                                     @RefNo VARCHAR(20)=NULL,
                                                                     @InvCost FLOAT = NULL,
                                                                     @EstDat VARCHAR(10)=NULL,
                                                                     @CustPri INT = NULL,
                                                                     @ArbTaf VARCHAR(150)=NULL,
                                                                     @CurTyp INT = NULL,
                                                                     @InvCash VARCHAR(20)=NULL,
                                                                     @ToStore VARCHAR(3)=NULL,
                                                                     @ToStoreNm VARCHAR(50)=NULL,
                                                                     @InvQty FLOAT = NULL,
                                                                     @EngTaf VARCHAR(150)=NULL,
                                                                     @IfTrans INT = NULL,
                                                                     @CustRep FLOAT =NULL,
                                                                     @CustNet FLOAT = NULL,
                                                                     @InvWight_T FLOAT =NULL,
                                                                     @IfPrint INT = NULL,
                                                                     @LTim VARCHAR(10)=NULL,
                                                                     @CREATED_BY VARCHAR(100) =NULL,
                                                                     @DATE_CREATED datetime = NULL,
                                                                     @MODIFIED_BY VARCHAR(100)=NULL,
                                                                     @DATE_MODIFIED datetime = NULL,
                                                                     @CreditPay float=NULL,
                                                                     @CreditPayLocCur float=NULL,
                                                                     @NetworkPay float=NULL,
                                                                     @NetworkPayLocCur float=NULL,
                                                                     @CommMnd_Inv float=NULL,
                                                                     @MndExtrnal bit = NULL,
                                                                     @CompanyID int=NULL,
                                                                     @InvAddCost float=NULL,
                                                                     @InvAddCostLoc float=NULL,
                                                                     @InvAddCostExtrnal float=NULL,
                                                                     @InvAddCostExtrnalLoc float=NULL,
                                                                     @IsExtrnalGaid bit = NULL,
                                                                     @ExtrnalCostGaidID float=NULL,
                                                                     @Puyaid float=NULL,
                                                                     @Remming float=NULL,
                                                                     @RoomNo int=NULL,
                                                                     @OrderTyp int=NULL,
                                                                     @RoomSts bit = NULL,
                                                                     @chauffeurNo int=NULL,
                                                                     @RoomPerson int=NULL,
                                                                     @ServiceValue float=NULL,
                                                                     @Sts bit = NULL,
                                                                     @PaymentOrderTyp int=NULL,
                                                                     @AdminLock bit = NULL,
                                                                     @DeleteDate VARCHAR(10)=NULL,
                                                                     @DeleteTime VARCHAR(10)=NULL,
                                                                     @UserNew VARCHAR(3)=NULL,
                                                                     @IfEnter int=NULL,
                                                                     @InvAddTax float=NULL,
                                                                     @InvAddTaxlLoc float=NULL,
                                                                     @IsTaxGaid bit = NULL,
                                                                     @TaxGaidID float=NULL,
                                                                     @IsTaxUse bit = NULL,
                                                                     @InvValGaidDis float=NULL,
                                                                     @InvValGaidDislLoc float=NULL,
                                                                     @IsDisGaid bit = NULL,
                                                                     @DisGaidID1 float=NULL,
                                                                     @IsDisUse1 bit = NULL,
                                                                     @InvComm float=NULL,
                                                                     @InvCommLoc float=NULL,
                                                                     @IsCommGaid bit = NULL,
                                                                     @CommGaidID float=NULL,
                                                                     @IsCommUse bit = NULL,
                                                                     @IsTaxLines bit=NULL,
                                                                     @IsTaxByTotal bit = NULL,
                                                                     @IsTaxByNet bit=NULL,
                                                                     @TaxByNetValue float=NULL,
                                                                     @DesPointsValue float=NULL,
                                                                     @DesPointsValueLocCur float=NULL,
                                                                     @PointsCount float=NULL,
                                                                     @IsPoints bit = NULL,
                                                                     @tailor1 VARCHAR(100)=NULL,
                                                                     @tailor2 VARCHAR(100)=NULL,
                                                                     @tailor3 VARCHAR(100)=NULL,
                                                                     @tailor4 VARCHAR(100)=NULL,
                                                                     @tailor5 VARCHAR(100)=NULL,
                                                                     @tailor6 VARCHAR(100)=NULL,
                                                                     @tailor7 VARCHAR(100)=NULL,
                                                                     @tailor8 VARCHAR(100)=NULL,
                                                                     @tailor9 VARCHAR(100)=NULL,
                                                                     @tailor10 VARCHAR(100)=NULL,
                                                                     @tailor11 VARCHAR(100)=NULL,
                                                                     @tailor12 VARCHAR(100)=NULL,
                                                                     @tailor13 VARCHAR(100)=NULL,
                                                                     @tailor14 VARCHAR(100)=NULL,
                                                                     @tailor15 VARCHAR(100)=NULL,
                                                                     @tailor16 VARCHAR(100)=NULL,
                                                                     @tailor17 VARCHAR(100)=NULL,
                                                                     @tailor18 VARCHAR(100)=NULL,
                                                                     @tailor19 VARCHAR(100)=NULL,
                                                                     @tailor20 VARCHAR(100)=NULL,
                                                                     @InvImg[varbinary] (max) =NULL,
                                                                     @CusVenMob VARCHAR(50) =NULL,
                                                                     @PriceIncludeTax BIT = NULL
                                                              )
                                                              AS
                                                              BEGIN
                                                              INSERT INTO T_INVHED(
                                                                     InvId,
                                                                     InvNo,
                                                                     InvTyp,
                                                                     InvCashPay,
                                                                     CusVenNo,
                                                                     CusVenNm,
                                                                     HDat,
                                                                     CusVenAdd,
                                                                     CusVenTel,
                                                                     Remark,
                                                                     GDat,
                                                                     MndNo,
                                                                     SalsManNo,
                                                                     SalsManNam,
                                                                     InvTot,
                                                                     InvTotLocCur,
                                                                     InvDisPrs,
                                                                     InvDisVal,
                                                                     InvDisValLocCur,
                                                                     InvNet,
                                                                     InvNetLocCur,
                                                                     CashPay,
                                                                     CashPayLocCur,
                                                                     IfRet,
                                                                     GadeNo,
                                                                     GadeId,
                                                                     IfDel,
                                                                     RetNo,
                                                                     RetId,
                                                                     InvCstNo,
                                                                     InvCashPayNm,
                                                                     RefNo,
                                                                     InvCost,
                                                                     EstDat,
                                                                     CustPri,
                                                                     ArbTaf,
                                                                     CurTyp,
                                                                     InvCash,
                                                                     ToStore,
                                                                     ToStoreNm,
                                                                     InvQty,
                                                                     EngTaf,
                                                                     IfTrans,
                                                                     CustRep,
                                                                     CustNet,
                                                                     InvWight_T,
                                                                     IfPrint,
                                                                     LTim,
                                                                     CREATED_BY,
                                                                     DATE_CREATED,
                                                                     MODIFIED_BY ,
                                                                     DATE_MODIFIED ,
                                                                     CreditPay ,
                                                                     CreditPayLocCur ,
                                                                     NetworkPay ,
                                                                     NetworkPayLocCur ,
                                                                     CommMnd_Inv ,
                                                                     MndExtrnal ,
                                                                     CompanyID ,
                                                                     InvAddCost ,
                                                                     InvAddCostLoc ,
                                                                     InvAddCostExtrnal ,
                                                                     InvAddCostExtrnalLoc ,
                                                                     IsExtrnalGaid ,
                                                                     ExtrnalCostGaidID ,
                                                                     Puyaid ,
                                                                     Remming ,
                                                                     RoomNo ,
                                                                     OrderTyp ,
                                                                     RoomSts ,
                                                                     chauffeurNo ,
                                                                     RoomPerson ,
                                                                     ServiceValue ,
                                                                     Sts ,
                                                                     PaymentOrderTyp ,
                                                                     AdminLock ,
                                                                     DeleteDate ,
                                                                     DeleteTime ,
                                                                     UserNew ,
                                                                     IfEnter ,
                                                                     InvAddTax ,
                                                                     InvAddTaxlLoc ,
                                                                     IsTaxGaid ,
                                                                     TaxGaidID ,
                                                                     IsTaxUse ,
                                                                     InvValGaidDis ,
                                                                     InvValGaidDislLoc ,
                                                                     IsDisGaid ,
                                                                     DisGaidID1 ,
                                                                     IsDisUse1 ,
                                                                     InvComm ,
                                                                     InvCommLoc ,
                                                                     IsCommGaid ,
                                                                     CommGaidID ,
                                                                     IsCommUse ,
                                                                     IsTaxLines ,
                                                                     IsTaxByTotal ,
                                                                     IsTaxByNet ,
                                                                     TaxByNetValue ,
                                                                     DesPointsValue ,
                                                                     DesPointsValueLocCur ,
                                                                     PointsCount,
                                                                     IsPoints,
                                                                     tailor1 ,
                                                                     tailor2 ,
                                                                     tailor3 ,
                                                                     tailor4 ,
                                                                     tailor5 ,
                                                                     tailor6 ,
                                                                     tailor7 ,
                                                                     tailor8 ,
                                                                     tailor9 ,
                                                                     tailor10 ,
                                                                     tailor11 ,
                                                                     tailor12 ,
                                                                     tailor13 ,
                                                                     tailor14 ,
                                                                     tailor15 ,
                                                                     tailor16 ,
                                                                     tailor17 ,
                                                                     tailor18 ,
                                                                     tailor19 ,
                                                                     tailor20,
                                                                     InvImg,
                                                                     CusVenMob,
                                                                     PriceIncludTax
                                                              )
                                                              VALUES
                                                              (
                                                                    @InvId,
                                                                    @InvNo,
                                                                    @InvTyp,
                                                                    @InvCashPay,
                                                                    @CusVenNo,
                                                                    @CusVenNm,
                                                                    @HDat,
                                                                    @CusVenAdd,
                                                                    @CusVenTel,
                                                                    @Remark,
                                                                    @GDat,
                                                                    @MndNo,
                                                                    @SalsManNo,
                                                                    @SalsManNam,
                                                                    @InvTot,
                                                                    @InvTotLocCur,
                                                                    @InvDisPrs,
                                                                    @InvDisVal,
                                                                    @InvDisValLocCur,
                                                                    @InvNet,
                                                                    @InvNetLocCur,
                                                                    @CashPay,
                                                                    @CashPayLocCur,
                                                                    @IfRet,
                                                                    @GadeNo,
                                                                    @GadeId,
                                                                    @IfDel,
                                                                    @RetNo,
                                                                    @RetId,
                                                                    @InvCstNo,
                                                                    @InvCashPayNm,
                                                                    @RefNo,
                                                                    @InvCost,
                                                                    @EstDat,
                                                                    @CustPri,
                                                                    @ArbTaf,
                                                                    @CurTyp,
                                                                    @InvCash,
                                                                    @ToStore,
                                                                    @ToStoreNm,
                                                                    @InvQty,
                                                                    @EngTaf,
                                                                    @IfTrans,
                                                                    @CustRep,
                                                                    @CustNet,
                                                                    @InvWight_T,
                                                                    @IfPrint,
                                                                    @LTim,
                                                                    @CREATED_BY,
                                                                    @DATE_CREATED,
                                                                    @MODIFIED_BY ,
                                                                    @DATE_MODIFIED ,
                                                                    @CreditPay ,
                                                                    @CreditPayLocCur ,
                                                                    @NetworkPay ,
                                                                    @NetworkPayLocCur ,
                                                                    @CommMnd_Inv ,
                                                                    @MndExtrnal ,
                                                                    @CompanyID ,
                                                                    @InvAddCost ,
                                                                    @InvAddCostLoc ,
                                                                    @InvAddCostExtrnal ,
                                                                    @InvAddCostExtrnalLoc ,
                                                                    @IsExtrnalGaid ,
                                                                    @ExtrnalCostGaidID ,
                                                                    @Puyaid ,
                                                                    @Remming ,
                                                                    @RoomNo ,
                                                                    @OrderTyp ,
                                                                    @RoomSts ,
                                                                    @chauffeurNo ,
                                                                    @RoomPerson ,
                                                                    @ServiceValue ,
                                                                    @Sts ,
                                                                    @PaymentOrderTyp ,
                                                                    @AdminLock ,
                                                                    @DeleteDate ,
                                                                    @DeleteTime ,
                                                                    @UserNew ,
                                                                    @IfEnter ,
                                                                    @InvAddTax ,
                                                                    @InvAddTaxlLoc ,
                                                                    @IsTaxGaid ,
                                                                    @TaxGaidID ,
                                                                    @IsTaxUse ,
                                                                    @InvValGaidDis ,
                                                                    @InvValGaidDislLoc ,
                                                                    @IsDisGaid ,
                                                                    @DisGaidID1 ,
                                                                    @IsDisUse1 ,
                                                                    @InvComm ,
                                                                    @InvCommLoc ,
                                                                    @IsCommGaid ,
                                                                    @CommGaidID ,
                                                                    @IsCommUse ,
                                                                    @IsTaxLines ,
                                                                    @IsTaxByTotal ,
                                                                    @IsTaxByNet ,
                                                                    @TaxByNetValue ,
                                                                    @DesPointsValue ,
                                                                    @DesPointsValueLocCur ,
                                                                    @PointsCount,
                                                                    @IsPoints,
                                                                    @tailor1 ,
                                                                    @tailor2 ,
                                                                    @tailor3 ,
                                                                    @tailor4 ,
                                                                    @tailor5 ,
                                                                    @tailor6 ,
                                                                    @tailor7 ,
                                                                    @tailor8 ,
                                                                    @tailor9 ,
                                                                    @tailor10 ,
                                                                    @tailor11 ,
                                                                    @tailor12 ,
                                                                    @tailor13 ,
                                                                    @tailor14 ,
                                                                    @tailor15 ,
                                                                    @tailor16 ,
                                                                    @tailor17 ,
                                                                    @tailor18 ,
                                                                    @tailor19 ,
                                                                    @tailor20,
                                                                    @InvImg,
                                                                    @CusVenMob,
                                                                    @PriceIncludeTax
                                                              )
                                                              SELECT @InvHed_ID = SCOPE_IDENTITY()
                                                              RETURN @InvHed_ID
                                                              END;";
        public static string s6 = @"ALTER PROCEDURE [dbo].[S_T_INVHED_DELETE](
                                              @InvHed_ID INT 
                                  )
                                  AS
                                  BEGIN
                                  declare @InvTyp int
                                  declare @MndID int
                                  declare @CusVenNo varchar(30)
                                  declare @PaymentOrderTyp int
                                  declare @MndKind int 
                                       
                                  select @InvTyp = InvTyp from T_INVHED where InvHed_ID = @InvHed_ID;
                                select @MndID = MndNo from T_INVHED where InvHed_ID = @InvHed_ID;
                                
                                select @PaymentOrderTyp = PaymentOrderTyp from T_INVHED where InvHed_ID = @InvHed_ID;
                                select @CusVenNo = CusVenNo from T_INVHED where InvHed_ID = @InvHed_ID;
                                select @MndKind = Mnd_Typ from T_Mndob where Mnd_ID = @MndID;
                                
                                  if(@InvTyp != 7 and @InvTyp != 8 and @InvTyp != 9 and @InvTyp != 21)
                                begin
                                  if(@PaymentOrderTyp <= 0 or @PaymentOrderTyp is null)
	                              begin
		                              UPDATE T_Items SET T_Items.OpenQty = T_Items.OpenQty - T_INVDET.RealQty 
		                              From T_INVDET Left Join T_Items ON (T_INVDET.ItmNo = T_Items.Itm_No) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID) 
		                              where (InvHed_ID = @InvHed_ID) and (T_INVDET.ItmTyp <> 3) and (T_INVDET.ItmTyp <> 2);
		                              UPDATE T_STKSQTY SET T_STKSQTY.stkQty = T_STKSQTY.stkQty - T_INVDET.RealQty 
		                              From T_INVDET Left Join T_STKSQTY ON (T_INVDET.ItmNo = T_STKSQTY.itmNo) AND (T_INVDET.StoreNo = T_STKSQTY.storeNo) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)  
		                              where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and (T_INVDET.ItmTyp <> 2);
                            		  
		                              UPDATE T_QTYEXP SET T_QTYEXP.stkQty = T_QTYEXP.stkQty - T_INVDET.RealQty 
		                              From  T_INVDET Left Join T_QTYEXP ON (T_INVDET.ItmNo = T_QTYEXP.itmNo) AND (T_INVDET.StoreNo = T_QTYEXP.storeNo) AND (T_INVDET.DatExper = T_QTYEXP.DatExper and T_INVDET.RunCod = T_QTYEXP.RunCod ) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)
		                              where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and (T_INVDET.ItmTyp <> 2);
                                  end
                                 if(@InvTyp = 17)
	                             begin
                                         if(@PaymentOrderTyp > 0)
	                                      begin
 										      UPDATE T_Items SET T_Items.OpenQty = T_Items.OpenQty - T_INVDET.RealQty 
										      From T_INVDET Left Join T_Items ON (T_INVDET.ItmNo = T_Items.Itm_No) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID) 
										      where (InvHed_ID = @InvHed_ID) and (T_INVDET.ItmTyp <> 3) and (T_INVDET.ItmTyp <> 2);
										      UPDATE T_STKSQTY SET T_STKSQTY.stkQty = T_STKSQTY.stkQty - T_INVDET.RealQty 
										      From T_INVDET Left Join T_STKSQTY ON (T_INVDET.ItmNo = T_STKSQTY.itmNo) AND (T_INVDET.StoreNo = T_STKSQTY.storeNo) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)  
										      where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and (T_INVDET.ItmTyp <> 2);
                                			  
										      UPDATE T_QTYEXP SET T_QTYEXP.stkQty = T_QTYEXP.stkQty - T_INVDET.RealQty 
										      From  T_INVDET Left Join T_QTYEXP ON (T_INVDET.ItmNo = T_QTYEXP.itmNo) AND (T_INVDET.StoreNo = T_QTYEXP.storeNo) AND (T_INVDET.DatExper = T_QTYEXP.DatExper and T_INVDET.RunCod = T_QTYEXP.RunCod ) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)
										      where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and (T_INVDET.ItmTyp <> 2);
                                          end
										  select @MndID = MndNo from T_INVHED where InvHed_ID = @InvHed_ID;  	  
										  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty - abs(T_INVDET.RealQty)
										  From T_INVDET Left Join T_StoreMnd ON (T_INVDET.ItmNo = T_StoreMnd.itmNo) AND (T_INVDET.StoreNo = T_StoreMnd.storeNo) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)  
										  where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and T_StoreMnd.MndNo = @MndID ;
										  
										  select @CusVenNo = CusVenNo from T_INVHED where InvHed_ID = @InvHed_ID;  	  
										  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty - abs(T_INVDET.RealQty)
										  From T_INVDET Left Join T_StoreMnd ON (T_INVDET.ItmNo = T_StoreMnd.itmNo) AND (T_INVDET.StoreNo = T_StoreMnd.storeNo) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)  
										  where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and T_StoreMnd.CusVenNo = @CusVenNo ;
                                 end
                                 
                                 if(@InvTyp = 20)
	                             begin
                                         if(@PaymentOrderTyp > 0)
	                                      begin
 										      UPDATE T_Items SET T_Items.OpenQty = T_Items.OpenQty - T_INVDET.RealQty 
										      From T_INVDET Left Join T_Items ON (T_INVDET.ItmNo = T_Items.Itm_No) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID) 
										      where (InvHed_ID = @InvHed_ID) and (T_INVDET.ItmTyp <> 3) and (T_INVDET.ItmTyp <> 2);
										      UPDATE T_STKSQTY SET T_STKSQTY.stkQty = T_STKSQTY.stkQty - T_INVDET.RealQty 
										      From T_INVDET Left Join T_STKSQTY ON (T_INVDET.ItmNo = T_STKSQTY.itmNo) AND (T_INVDET.StoreNo = T_STKSQTY.storeNo) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)  
										      where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and (T_INVDET.ItmTyp <> 2);
                                			  
										      UPDATE T_QTYEXP SET T_QTYEXP.stkQty = T_QTYEXP.stkQty - T_INVDET.RealQty 
										      From  T_INVDET Left Join T_QTYEXP ON (T_INVDET.ItmNo = T_QTYEXP.itmNo) AND (T_INVDET.StoreNo = T_QTYEXP.storeNo) AND (T_INVDET.DatExper = T_QTYEXP.DatExper and T_INVDET.RunCod = T_QTYEXP.RunCod ) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)
										      where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and (T_INVDET.ItmTyp <> 2);
                                          end
												  select @MndID = MndNo from T_INVHED where InvHed_ID = @InvHed_ID;  	  
												  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty + T_INVDET.RealQty 
												  From T_INVDET Left Join T_StoreMnd ON (T_INVDET.ItmNo = T_StoreMnd.itmNo) AND (T_INVDET.StoreNo = T_StoreMnd.storeNo) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)  
												  where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and T_StoreMnd.MndNo = @MndID ;
												  
												  select @CusVenNo = CusVenNo from T_INVHED where InvHed_ID = @InvHed_ID;  	  
												  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty + T_INVDET.RealQty 
												  From T_INVDET Left Join T_StoreMnd ON (T_INVDET.ItmNo = T_StoreMnd.itmNo) AND (T_INVDET.StoreNo = T_StoreMnd.storeNo) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)  
												  where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and T_StoreMnd.CusVenNo = @CusVenNo ;
                                 end
                             
                                  if(@InvTyp = 14)
                                  begin
		                              UPDATE T_STKSQTY SET T_STKSQTY.stkInt = T_STKSQTY.stkInt - T_INVDET.RealQty 
		                              From T_INVDET Left Join T_STKSQTY ON (T_INVDET.ItmNo = T_STKSQTY.itmNo) AND (T_INVDET.StoreNo = T_STKSQTY.storeNo) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)  
		                              where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and (T_INVDET.ItmTyp <> 2);
                                  end       
                                  
                                end
                                  UPDATE T_INVHED SET T_INVHED.IfDel = 1 
                                  FROM  T_INVHED
                                  WHERE  @InvHed_ID = InvHed_ID
                                  RETURN
                                  END
";
        public static string s4 = @"ALTER PROCEDURE [dbo].[S_T_INVHED_UPDATE](
                                                                                 @InvHed_ID INT ,
                                                                                 @InvId FLOAT =NULL,
                                                                                 @InvNo VARCHAR (10),
                                                                                 @InvTyp INT =NULL,
                                                                                 @InvCashPay INT =NULL,
                                                                                 @CusVenNo VARCHAR (20)=NULL,
                                                                                 @CusVenNm VARCHAR (50)=NULL,
                                                                                 @CusVenAdd VARCHAR (100)=NULL,
                                                                                 @CusVenTel VARCHAR (30)=NULL,
                                                                                 @Remark VARCHAR (MAX)=NULL,
                                                                                 @HDat VARCHAR (10)=NULL,
                                                                                 @GDat VARCHAR (10)=NULL,
                                                                                 @MndNo INT =NULL,
                                                                                 @SalsManNo VARCHAR (3)=NULL,
                                                                                 @SalsManNam VARCHAR (50)=NULL,
                                                                                 @InvTot FLOAT =NULL,
                                                                                 @InvTotLocCur FLOAT =NULL,
                                                                                 @InvDisPrs FLOAT =NULL,
                                                                                 @InvDisVal FLOAT =NULL,
                                                                                 @InvDisValLocCur FLOAT =NULL,
                                                                                 @InvNet FLOAT =NULL,
                                                                                 @InvNetLocCur FLOAT =NULL,
                                                                                 @CashPay FLOAT =NULL,
                                                                                 @CashPayLocCur FLOAT =NULL,
                                                                                 @IfRet INT =NULL,
                                                                                 @GadeNo FLOAT =NULL,
                                                                                 @GadeId FLOAT =NULL,
                                                                                 @IfDel INT =NULL,
                                                                                 @RetNo VARCHAR (10)=NULL,
                                                                                 @RetId FLOAT =NULL,
                                                                                 @InvCstNo INT =NULL,
                                                                                 @InvCashPayNm VARCHAR (100)=NULL,
                                                                                 @RefNo VARCHAR (20)=NULL,
                                                                                 @InvCost FLOAT =NULL,
                                                                                 @EstDat VARCHAR (10)=NULL,
                                                                                 @CustPri INT =NULL,
                                                                                 @ArbTaf VARCHAR (150)=NULL,
                                                                                 @CurTyp INT =NULL,
                                                                                 @InvCash VARCHAR (20)=NULL,
                                                                                 @ToStore VARCHAR (3)=NULL,
                                                                                 @ToStoreNm VARCHAR (50)=NULL,
                                                                                 @InvQty FLOAT =NULL,
                                                                                 @EngTaf VARCHAR (150)=NULL,
                                                                                 @IfTrans INT =NULL,
                                                                                 @CustRep FLOAT =NULL,
                                                                                 @CustNet FLOAT =NULL,
                                                                                 @InvWight_T FLOAT =NULL,
                                                                                 @IfPrint INT =NULL,
                                                                                 @LTim VARCHAR (10)=NULL,
                                                                                 @CREATED_BY VARCHAR(100) =NULL,
                                                                                 @DATE_CREATED datetime =NULL,
                                                                                 @MODIFIED_BY VARCHAR (100)=NULL,
                                                                                 @DATE_MODIFIED datetime=NULL,
                                                                                 @CreditPay float=NULL,
                                                                                 @CreditPayLocCur float=NULL,
                                                                                 @NetworkPay float=NULL,
                                                                                 @NetworkPayLocCur float=NULL,
                                                                                 @CommMnd_Inv float=NULL,
                                                                                 @MndExtrnal bit=NULL,
                                                                                 @CompanyID int=NULL,
                                                                                 @InvAddCost float=NULL,
                                                                                 @InvAddCostLoc float=NULL,
                                                                                 @InvAddCostExtrnal float=NULL,
                                                                                 @InvAddCostExtrnalLoc float=NULL,
                                                                                 @IsExtrnalGaid bit=NULL,
                                                                                 @ExtrnalCostGaidID float=NULL,
                                                                                 @Puyaid float=NULL,
                                                                                 @Remming float=NULL,
                                                                                 @RoomNo int=NULL,
                                                                                 @OrderTyp int=NULL,
                                                                                 @RoomSts bit=NULL,
                                                                                 @chauffeurNo int=NULL,
                                                                                 @RoomPerson int=NULL,
                                                                                 @ServiceValue float=NULL,
                                                                                 @Sts bit=NULL,
                                                                                 @PaymentOrderTyp int=NULL,
                                                                                 @AdminLock bit=NULL,
                                                                                 @DeleteDate VARCHAR (10)=NULL,
                                                                                 @DeleteTime VARCHAR (10)=NULL,
                                                                                 @UserNew VARCHAR (3)=NULL,
                                                                                 @IfEnter int=NULL,
                                                                                 @InvAddTax float=NULL,
                                                                                 @InvAddTaxlLoc float=NULL,
                                                                                 @IsTaxGaid bit=NULL,
                                                                                 @TaxGaidID float=NULL,
                                                                                 @IsTaxUse bit=NULL,
                                                                                 @InvValGaidDis float=NULL,
                                                                                 @InvValGaidDislLoc float=NULL,
                                                                                 @IsDisGaid bit=NULL,
                                                                                 @DisGaidID1 float=NULL,
                                                                                 @IsDisUse1 bit=NULL,
                                                                                 @InvComm float=NULL,
                                                                                 @InvCommLoc float=NULL,
                                                                                 @IsCommGaid bit=NULL,
                                                                                 @CommGaidID float=NULL,
                                                                                 @IsCommUse bit=NULL,
                                                                                 @IsTaxLines bit=NULL,
                                                                                 @IsTaxByTotal bit=NULL,
                                                                                 @IsTaxByNet bit=NULL,
                                                                                 @TaxByNetValue float=NULL,
                                                                                 @DesPointsValue float=NULL,
																			     @DesPointsValueLocCur float=NULL,
																			     @PointsCount float=NULL,
                                                                                 @IsPoints bit=NULL,
                                                                                 @tailor1 VARCHAR (100)=NULL,
                                                                                 @tailor2 VARCHAR (100)=NULL,
                                                                                 @tailor3 VARCHAR (100)=NULL,
                                                                                 @tailor4 VARCHAR (100)=NULL,
                                                                                 @tailor5 VARCHAR (100)=NULL,
                                                                                 @tailor6 VARCHAR (100)=NULL,
                                                                                 @tailor7 VARCHAR (100)=NULL,
                                                                                 @tailor8 VARCHAR (100)=NULL,
                                                                                 @tailor9 VARCHAR (100)=NULL,
                                                                                 @tailor10 VARCHAR (100)=NULL,
                                                                                 @tailor11 VARCHAR (100)=NULL,
                                                                                 @tailor12 VARCHAR (100)=NULL,
                                                                                 @tailor13 VARCHAR (100)=NULL,
                                                                                 @tailor14 VARCHAR (100)=NULL,
                                                                                 @tailor15 VARCHAR (100)=NULL,
                                                                                 @tailor16 VARCHAR (100)=NULL,
                                                                                 @tailor17 VARCHAR (100)=NULL,
                                                                                 @tailor18 VARCHAR (100)=NULL,
                                                                                 @tailor19 VARCHAR (100)=NULL,
                                                                                 @tailor20 VARCHAR (100)=NULL,
                                                                                 @InvImg VARBINARY(max) =NULL,
                                                                                 @CusVenMob VARCHAR(50) =NULL,
                                                                                 @PriceIncludeTax BIT = NULL
                                                                 
                                  )
                                  AS
                                  BEGIN
                                  UPDATE T_INVHED
                                  SET    InvId = @InvId,
                                         InvNo = @InvNo,
                                         InvTyp = @InvTyp,
                                         InvCashPay = @InvCashPay,
                                         CusVenNo = @CusVenNo,
                                         CusVenNm = @CusVenNm,
                                         CusVenAdd = @CusVenAdd,
                                         CusVenTel = @CusVenTel,
                                         Remark = @Remark,
                                         HDat = @HDat,
                                         GDat = @GDat,
                                         MndNo = @MndNo,
                                         SalsManNo = @SalsManNo,
                                         SalsManNam = @SalsManNam,
                                         InvTot = @InvTot,
                                         InvTotLocCur = @InvTotLocCur,
                                         InvDisPrs = @InvDisPrs,
                                         InvDisVal = @InvDisVal,
                                         InvDisValLocCur = @InvDisValLocCur,
                                         InvNet = @InvNet,
                                         InvNetLocCur = @InvNetLocCur,
                                         CashPay = @CashPay,
                                         CashPayLocCur = @CashPayLocCur,
                                         IfRet = @IfRet,
                                         GadeNo = @GadeNo,
                                         GadeId = @GadeId,
                                         IfDel = @IfDel,
                                         RetNo = @RetNo,
                                         RetId = @RetId,
                                         InvCstNo = @InvCstNo,
                                         InvCashPayNm = @InvCashPayNm,
                                         RefNo = @RefNo,
                                         InvCost = @InvCost,
                                         EstDat = @EstDat,
                                         CustPri = @CustPri,
                                         ArbTaf = @ArbTaf,
                                         CurTyp = @CurTyp,
                                         InvCash = @InvCash,
                                         ToStore = @ToStore,
                                         ToStoreNm = @ToStoreNm,
                                         InvQty = @InvQty,
                                         EngTaf = @EngTaf,
                                         IfTrans = @IfTrans,
                                         CustRep = @CustRep,
                                         CustNet = @CustNet,
                                         InvWight_T = @InvWight_T,
                                         IfPrint = @IfPrint,
                                         LTim = @LTim,
                                         MODIFIED_BY = @MODIFIED_BY,
                                         DATE_MODIFIED = @DATE_MODIFIED,
                                                                                 CreditPay = @CreditPay,
                                                                                 CreditPayLocCur = @CreditPayLocCur,
                                                                                 NetworkPay = @NetworkPay,
                                                                                 NetworkPayLocCur = @NetworkPayLocCur,
                                                                                 CommMnd_Inv = @CommMnd_Inv,
                                                                                 MndExtrnal = @MndExtrnal,
                                                                                 CompanyID = @CompanyID,
                                                                                 InvAddCost = @InvAddCost,
                                                                                 InvAddCostLoc = @InvAddCostLoc,
                                                                                 InvAddCostExtrnal = @InvAddCostExtrnal,
                                                                                 InvAddCostExtrnalLoc = @InvAddCostExtrnalLoc,
                                                                                 IsExtrnalGaid = @IsExtrnalGaid,
                                                                                 ExtrnalCostGaidID = @ExtrnalCostGaidID,
                                                                                 Puyaid = @Puyaid,
                                                                                 Remming = @Remming,
                                                                                 RoomNo = @RoomNo,
                                                                                 OrderTyp = @OrderTyp,
                                                                                 RoomSts = @RoomSts,
                                                                                 chauffeurNo = @chauffeurNo,
                                                                                 RoomPerson = @RoomPerson,
                                                                                 ServiceValue = @ServiceValue,
                                                                                 Sts = @Sts,
                                                                                 PaymentOrderTyp = @PaymentOrderTyp,
                                                                                 AdminLock = @AdminLock,
                                                                                 DeleteDate = @DeleteDate,
                                                                                 DeleteTime = @DeleteTime,
                                                                                 UserNew = @UserNew,
                                                                                 IfEnter = @IfEnter,
                                                                                 InvAddTax = @InvAddTax,
                                                                                 InvAddTaxlLoc = @InvAddTaxlLoc,
                                                                                 IsTaxGaid = @IsTaxGaid,
                                                                                 TaxGaidID = @TaxGaidID,
                                                                                 IsTaxUse = @IsTaxUse,
                                                                                 InvValGaidDis = @InvValGaidDis,
                                                                                 InvValGaidDislLoc = @InvValGaidDislLoc,
                                                                                 IsDisGaid = @IsDisGaid,
                                                                                 DisGaidID1 = @DisGaidID1,
                                                                                 IsDisUse1 = @IsDisUse1,
                                                                                 InvComm = @InvComm,
                                                                                 InvCommLoc = @InvCommLoc,
                                                                                 IsCommGaid = @IsCommGaid,
                                                                                 CommGaidID = @CommGaidID,
                                                                                 IsCommUse = @IsCommUse,
                                                                                 IsTaxLines = @IsTaxLines,
                                                                                 IsTaxByTotal = @IsTaxByTotal,
                                                                                 IsTaxByNet = @IsTaxByNet,
                                                                                 TaxByNetValue = @TaxByNetValue,
                                                                                 DesPointsValue = @DesPointsValue ,
																				 DesPointsValueLocCur = @DesPointsValueLocCur ,
																				 PointsCount = @PointsCount,
                                                                                 IsPoints = @IsPoints,
                                                                                 tailor1 = @tailor1 ,
																				 tailor2 = @tailor2,
																				 tailor3 = @tailor3,
																				 tailor4 = @tailor4,
																				 tailor5 = @tailor5,
																				 tailor6 = @tailor6,
																				 tailor7 = @tailor7,
																				 tailor8 = @tailor8,
																				 tailor9 = @tailor9,
																				 tailor10 = @tailor10,
																				 tailor11 = @tailor11,
																				 tailor12 = @tailor12,
																				 tailor13 = @tailor13,
																				 tailor14 = @tailor14,
																				 tailor15 = @tailor15,
																				 tailor16 = @tailor16,
																				 tailor17 = @tailor17,
																				 tailor18 = @tailor18,
																				 tailor19 = @tailor19,
																				 tailor20 = @tailor20,
                                                                                 InvImg   = @InvImg,
                                                                                 CusVenMob = @CusVenMob,
                                                                                 PriceIncludTax =@PriceIncludeTax
                                  WHERE  @InvHed_ID = InvHed_ID
                                  RETURN
                                  END;";
        public static string s7 = @"  ALTER PROCEDURE [dbo].[S_T_GDDET_INSERT](   
                                                 @GDDET_ID INT OUTPUT,
                                                 @gdID INT =NULL,
                                                 @gdNo VARCHAR (10)=NULL,
                                                 @gdDes VARCHAR (100)=NULL,
                                                 @gdDesE VARCHAR (100)=NULL,
                                                 @recptTyp VARCHAR (20)=NULL,
                                                 @AccNo VARCHAR (30)=NULL,
                                                 @AccName VARCHAR (50)=NULL,
                                                 @gdValue FLOAT =NULL,
                                                 @recptNo VARCHAR (20)=NULL,
                                                 @Lin INT =NULL,
                                                 @AccNoDestruction VARCHAR (30)=NULL
                                                 
                                          )
                                          AS
                                          BEGIN
                                          INSERT INTO T_GDDET(
                                                 gdID,
                                                 gdNo,
                                                 gdDes,
                                                 gdDesE,
                                                 recptTyp,
                                                 AccNo,
                                                 AccName,
                                                 gdValue,
                                                 recptNo,
                                                 Lin,
                                                 AccNoDestruction
                                          )
                                          VALUES
                                          (
                                                 
                                                @gdID,
                                                @gdNo,
                                                @gdDes,
                                                @gdDesE,
                                                @recptTyp,
                                                @AccNo,
                                                @AccName,
                                                @gdValue,
                                                @recptNo,
                                                @Lin,
                                                @AccNoDestruction
                                          )
                                          SELECT @GDDET_ID = SCOPE_IDENTITY()
                                          UPDATE T_AccDef SET T_AccDef.Debit = T_AccDef.Debit + ROUND( T_GDDET.gdValue, case when Substring((select MAX(T_SYSSETTING.Seting) from T_SYSSETTING),49,1) = 0 then 2 else 3 end)
                                          From T_AccDef Left Join T_GDDET ON (T_AccDef.AccDef_No = T_GDDET.AccNo) 
                                          where @GDDET_ID = GDDET_ID and  T_GDDET.gdValue > 0 ;
                                          UPDATE T_AccDef SET T_AccDef.Credit = T_AccDef.Credit + ABS(ROUND( T_GDDET.gdValue, case when Substring((select MAX(T_SYSSETTING.Seting) from T_SYSSETTING),49,1) = 0 then 2 else 3 end))
                                          From T_AccDef Left Join T_GDDET ON (T_AccDef.AccDef_No = T_GDDET.AccNo) 
                                          where @GDDET_ID = GDDET_ID and  T_GDDET.gdValue < 0 ;
                                          UPDATE T_AccDef SET T_AccDef.Balance = T_AccDef.Debit - T_AccDef.Credit
                                          From T_AccDef Left Join T_GDDET ON (T_AccDef.AccDef_No = T_GDDET.AccNo) 
                                          where @GDDET_ID = GDDET_ID ;
                                          RETURN
                                          END";
        public static string s2 = @"CREATE PROCEDURE [dbo].[S_T_INVHED_UPDATE](
                                                                                 @InvHed_ID INT ,
                                                                                 @InvId FLOAT =NULL,
                                                                                 @InvNo VARCHAR (10),
                                                                                 @InvTyp INT =NULL,
                                                                                 @InvCashPay INT =NULL,
                                                                                 @CusVenNo VARCHAR (20)=NULL,
                                                                                 @CusVenNm VARCHAR (50)=NULL,
                                                                                 @CusVenAdd VARCHAR (100)=NULL,
                                                                                 @CusVenTel VARCHAR (30)=NULL,
                                                                                 @Remark VARCHAR (MAX)=NULL,
                                                                                 @HDat VARCHAR (10)=NULL,
                                                                                 @GDat VARCHAR (10)=NULL,
                                                                                 @MndNo INT =NULL,
                                                                                 @SalsManNo VARCHAR (3)=NULL,
                                                                                 @SalsManNam VARCHAR (50)=NULL,
                                                                                 @InvTot FLOAT =NULL,
                                                                                 @InvTotLocCur FLOAT =NULL,
                                                                                 @InvDisPrs FLOAT =NULL,
                                                                                 @InvDisVal FLOAT =NULL,
                                                                                 @InvDisValLocCur FLOAT =NULL,
                                                                                 @InvNet FLOAT =NULL,
                                                                                 @InvNetLocCur FLOAT =NULL,
                                                                                 @CashPay FLOAT =NULL,
                                                                                 @CashPayLocCur FLOAT =NULL,
                                                                                 @IfRet INT =NULL,
                                                                                 @GadeNo FLOAT =NULL,
                                                                                 @GadeId FLOAT =NULL,
                                                                                 @IfDel INT =NULL,
                                                                                 @RetNo VARCHAR (10)=NULL,
                                                                                 @RetId FLOAT =NULL,
                                                                                 @InvCstNo INT =NULL,
                                                                                 @InvCashPayNm VARCHAR (100)=NULL,
                                                                                 @RefNo VARCHAR (20)=NULL,
                                                                                 @InvCost FLOAT =NULL,
                                                                                 @EstDat VARCHAR (10)=NULL,
                                                                                 @CustPri INT =NULL,
                                                                                 @ArbTaf VARCHAR (150)=NULL,
                                                                                 @CurTyp INT =NULL,
                                                                                 @InvCash VARCHAR (20)=NULL,
                                                                                 @ToStore VARCHAR (3)=NULL,
                                                                                 @ToStoreNm VARCHAR (50)=NULL,
                                                                                 @InvQty FLOAT =NULL,
                                                                                 @EngTaf VARCHAR (150)=NULL,
                                                                                 @IfTrans INT =NULL,
                                                                                 @CustRep FLOAT =NULL,
                                                                                 @CustNet FLOAT =NULL,
                                                                                 @InvWight_T FLOAT =NULL,
                                                                                 @IfPrint INT =NULL,
                                                                                 @LTim VARCHAR (10)=NULL,
                                                                                 @CREATED_BY VARCHAR(100) =NULL,
                                                                                 @DATE_CREATED datetime =NULL,
                                                                                 @MODIFIED_BY VARCHAR (100)=NULL,
                                                                                 @DATE_MODIFIED datetime=NULL,
                                                                                 @CreditPay float=NULL,
                                                                                 @CreditPayLocCur float=NULL,
                                                                                 @NetworkPay float=NULL,
                                                                                 @NetworkPayLocCur float=NULL,
                                                                                 @CommMnd_Inv float=NULL,
                                                                                 @MndExtrnal bit=NULL,
                                                                                 @CompanyID int=NULL,
                                                                                 @InvAddCost float=NULL,
                                                                                 @InvAddCostLoc float=NULL,
                                                                                 @InvAddCostExtrnal float=NULL,
                                                                                 @InvAddCostExtrnalLoc float=NULL,
                                                                                 @IsExtrnalGaid bit=NULL,
                                                                                 @ExtrnalCostGaidID float=NULL,
                                                                                 @Puyaid float=NULL,
                                                                                 @Remming float=NULL,
                                                                                 @RoomNo int=NULL,
                                                                                 @OrderTyp int=NULL,
                                                                                 @RoomSts bit=NULL,
                                                                                 @chauffeurNo int=NULL,
                                                                                 @RoomPerson int=NULL,
                                                                                 @ServiceValue float=NULL,
                                                                                 @Sts bit=NULL,
                                                                                 @PaymentOrderTyp int=NULL,
                                                                                 @AdminLock bit=NULL,
                                                                                 @DeleteDate VARCHAR (10)=NULL,
                                                                                 @DeleteTime VARCHAR (10)=NULL,
                                                                                 @UserNew VARCHAR (3)=NULL,
                                                                                 @IfEnter int=NULL,
                                                                                 @InvAddTax float=NULL,
                                                                                 @InvAddTaxlLoc float=NULL,
                                                                                 @IsTaxGaid bit=NULL,
                                                                                 @TaxGaidID float=NULL,
                                                                                 @IsTaxUse bit=NULL,
                                                                                 @InvValGaidDis float=NULL,
                                                                                 @InvValGaidDislLoc float=NULL,
                                                                                 @IsDisGaid bit=NULL,
                                                                                 @DisGaidID1 float=NULL,
                                                                                 @IsDisUse1 bit=NULL,
                                                                                 @InvComm float=NULL,
                                                                                 @InvCommLoc float=NULL,
                                                                                 @IsCommGaid bit=NULL,
                                                                                 @CommGaidID float=NULL,
                                                                                 @IsCommUse bit=NULL,
                                                                                 @IsTaxLines bit=NULL,
                                                                                 @IsTaxByTotal bit=NULL,
                                                                                 @IsTaxByNet bit=NULL,
                                                                                 @TaxByNetValue float=NULL,
                                                                                 @DesPointsValue float=NULL,
																			     @DesPointsValueLocCur float=NULL,
																			     @PointsCount float=NULL,
                                                                                 @IsPoints bit=NULL,
                                                                                 @tailor1 VARCHAR (100)=NULL,
                                                                                 @tailor2 VARCHAR (100)=NULL,
                                                                                 @tailor3 VARCHAR (100)=NULL,
                                                                                 @tailor4 VARCHAR (100)=NULL,
                                                                                 @tailor5 VARCHAR (100)=NULL,
                                                                                 @tailor6 VARCHAR (100)=NULL,
                                                                                 @tailor7 VARCHAR (100)=NULL,
                                                                                 @tailor8 VARCHAR (100)=NULL,
                                                                                 @tailor9 VARCHAR (100)=NULL,
                                                                                 @tailor10 VARCHAR (100)=NULL,
                                                                                 @tailor11 VARCHAR (100)=NULL,
                                                                                 @tailor12 VARCHAR (100)=NULL,
                                                                                 @tailor13 VARCHAR (100)=NULL,
                                                                                 @tailor14 VARCHAR (100)=NULL,
                                                                                 @tailor15 VARCHAR (100)=NULL,
                                                                                 @tailor16 VARCHAR (100)=NULL,
                                                                                 @tailor17 VARCHAR (100)=NULL,
                                                                                 @tailor18 VARCHAR (100)=NULL,
                                                                                 @tailor19 VARCHAR (100)=NULL,
                                                                                 @tailor20 VARCHAR (100)=NULL,
                                                                                 @InvImg VARBINARY(max) =NULL,
                                                                                 @CusVenMob VARCHAR(50) =NULL,
                                                                                 @PriceIncludeTax BIT = NULL
                                                                 
                                  )
                                  AS
                                  BEGIN
                                  UPDATE T_INVHED
                                  SET    InvId = @InvId,
                                         InvNo = @InvNo,
                                         InvTyp = @InvTyp,
                                         InvCashPay = @InvCashPay,
                                         CusVenNo = @CusVenNo,
                                         CusVenNm = @CusVenNm,
                                         CusVenAdd = @CusVenAdd,
                                         CusVenTel = @CusVenTel,
                                         Remark = @Remark,
                                         HDat = @HDat,
                                         GDat = @GDat,
                                         MndNo = @MndNo,
                                         SalsManNo = @SalsManNo,
                                         SalsManNam = @SalsManNam,
                                         InvTot = @InvTot,
                                         InvTotLocCur = @InvTotLocCur,
                                         InvDisPrs = @InvDisPrs,
                                         InvDisVal = @InvDisVal,
                                         InvDisValLocCur = @InvDisValLocCur,
                                         InvNet = @InvNet,
                                         InvNetLocCur = @InvNetLocCur,
                                         CashPay = @CashPay,
                                         CashPayLocCur = @CashPayLocCur,
                                         IfRet = @IfRet,
                                         GadeNo = @GadeNo,
                                         GadeId = @GadeId,
                                         IfDel = @IfDel,
                                         RetNo = @RetNo,
                                         RetId = @RetId,
                                         InvCstNo = @InvCstNo,
                                         InvCashPayNm = @InvCashPayNm,
                                         RefNo = @RefNo,
                                         InvCost = @InvCost,
                                         EstDat = @EstDat,
                                         CustPri = @CustPri,
                                         ArbTaf = @ArbTaf,
                                         CurTyp = @CurTyp,
                                         InvCash = @InvCash,
                                         ToStore = @ToStore,
                                         ToStoreNm = @ToStoreNm,
                                         InvQty = @InvQty,
                                         EngTaf = @EngTaf,
                                         IfTrans = @IfTrans,
                                         CustRep = @CustRep,
                                         CustNet = @CustNet,
                                         InvWight_T = @InvWight_T,
                                         IfPrint = @IfPrint,
                                         LTim = @LTim,
                                         MODIFIED_BY = @MODIFIED_BY,
                                         DATE_MODIFIED = @DATE_MODIFIED,
                                                                                 CreditPay = @CreditPay,
                                                                                 CreditPayLocCur = @CreditPayLocCur,
                                                                                 NetworkPay = @NetworkPay,
                                                                                 NetworkPayLocCur = @NetworkPayLocCur,
                                                                                 CommMnd_Inv = @CommMnd_Inv,
                                                                                 MndExtrnal = @MndExtrnal,
                                                                                 CompanyID = @CompanyID,
                                                                                 InvAddCost = @InvAddCost,
                                                                                 InvAddCostLoc = @InvAddCostLoc,
                                                                                 InvAddCostExtrnal = @InvAddCostExtrnal,
                                                                                 InvAddCostExtrnalLoc = @InvAddCostExtrnalLoc,
                                                                                 IsExtrnalGaid = @IsExtrnalGaid,
                                                                                 ExtrnalCostGaidID = @ExtrnalCostGaidID,
                                                                                 Puyaid = @Puyaid,
                                                                                 Remming = @Remming,
                                                                                 RoomNo = @RoomNo,
                                                                                 OrderTyp = @OrderTyp,
                                                                                 RoomSts = @RoomSts,
                                                                                 chauffeurNo = @chauffeurNo,
                                                                                 RoomPerson = @RoomPerson,
                                                                                 ServiceValue = @ServiceValue,
                                                                                 Sts = @Sts,
                                                                                 PaymentOrderTyp = @PaymentOrderTyp,
                                                                                 AdminLock = @AdminLock,
                                                                                 DeleteDate = @DeleteDate,
                                                                                 DeleteTime = @DeleteTime,
                                                                                 UserNew = @UserNew,
                                                                                 IfEnter = @IfEnter,
                                                                                 InvAddTax = @InvAddTax,
                                                                                 InvAddTaxlLoc = @InvAddTaxlLoc,
                                                                                 IsTaxGaid = @IsTaxGaid,
                                                                                 TaxGaidID = @TaxGaidID,
                                                                                 IsTaxUse = @IsTaxUse,
                                                                                 InvValGaidDis = @InvValGaidDis,
                                                                                 InvValGaidDislLoc = @InvValGaidDislLoc,
                                                                                 IsDisGaid = @IsDisGaid,
                                                                                 DisGaidID1 = @DisGaidID1,
                                                                                 IsDisUse1 = @IsDisUse1,
                                                                                 InvComm = @InvComm,
                                                                                 InvCommLoc = @InvCommLoc,
                                                                                 IsCommGaid = @IsCommGaid,
                                                                                 CommGaidID = @CommGaidID,
                                                                                 IsCommUse = @IsCommUse,
                                                                                 IsTaxLines = @IsTaxLines,
                                                                                 IsTaxByTotal = @IsTaxByTotal,
                                                                                 IsTaxByNet = @IsTaxByNet,
                                                                                 TaxByNetValue = @TaxByNetValue,
                                                                                 DesPointsValue = @DesPointsValue ,
																				 DesPointsValueLocCur = @DesPointsValueLocCur ,
																				 PointsCount = @PointsCount,
                                                                                 IsPoints = @IsPoints,
                                                                                 tailor1 = @tailor1 ,
																				 tailor2 = @tailor2,
																				 tailor3 = @tailor3,
																				 tailor4 = @tailor4,
																				 tailor5 = @tailor5,
																				 tailor6 = @tailor6,
																				 tailor7 = @tailor7,
																				 tailor8 = @tailor8,
																				 tailor9 = @tailor9,
																				 tailor10 = @tailor10,
																				 tailor11 = @tailor11,
																				 tailor12 = @tailor12,
																				 tailor13 = @tailor13,
																				 tailor14 = @tailor14,
																				 tailor15 = @tailor15,
																				 tailor16 = @tailor16,
																				 tailor17 = @tailor17,
																				 tailor18 = @tailor18,
																				 tailor19 = @tailor19,
																				 tailor20 = @tailor20,
                                                                                 InvImg   = @InvImg,
                                                                                 CusVenMob = @CusVenMob,
                                                                                 PriceIncludTax =@PriceIncludeTax
                                  WHERE  @InvHed_ID = InvHed_ID
                                  RETURN
                                  END;";
        public static List<string> scripts;
        public static string update001 = @"BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
ALTER TABLE dbo.T_INVHED ADD
	PriceIncludTax bit NULL
ALTER TABLE dbo.T_INVHED SET (LOCK_ESCALATION = TABLE)
COMMIT
select Has_Perms_By_Name(N'dbo.T_INVHED', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.T_INVHED', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.T_INVHED', 'Object', 'CONTROL') as Contr_Per 
BEGIN TRANSACTION
ALTER TABLE dbo.T_INVHED ADD
	CusVenMob varchar(50) NULL
ALTER TABLE dbo.T_INVHED SET (LOCK_ESCALATION = TABLE)
COMMIT
select Has_Perms_By_Name(N'dbo.T_INVHED', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.T_INVHED', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.T_INVHED', 'Object', 'CONTROL') as Contr_Per  ";
        public static string S_T_INVDET_CREATE = @"  CREATE PROCEDURE [dbo].[S_T_INVDET_INSERT](   
                                                                 @InvDet_ID INT OUTPUT,
                                                                 @InvNo VARCHAR (10)=NULL,
                                                                 @InvId INT =NULL,
                                                                 @InvSer INT =NULL,
                                                                 @ItmNo VARCHAR (50)=NULL,
                                                                 @Cost FLOAT =NULL,
                                                                 @Qty FLOAT =NULL,
                                                                 @ItmDes VARCHAR (50)=NULL,
                                                                 @ItmUnt VARCHAR (100)=NULL,
                                                                 @ItmDesE VARCHAR (50)=NULL,
                                                                 @ItmUntE VARCHAR (100)=NULL,
                                                                 @ItmUntPak FLOAT =NULL,
                                                                 @StoreNo INT=NULL,
                                                                 @Price FLOAT =NULL,
                                                                 @Amount FLOAT =NULL,
                                                                 @RealQty FLOAT =NULL,
                                                                 @itmInvDsc FLOAT =NULL,
                                                                 @DatExper VARCHAR (11)=NULL,
                                                                 @ItmDis FLOAT =NULL,
                                                                 @ItmTyp INT =NULL,
                                                                 @ItmIndex INT =NULL,
                                                                 @ItmWight FLOAT =NULL,
                                                                 @ItmWight_T FLOAT =NULL,
                                                                 @ItmAddCost FLOAT =NULL,
                                                                 @RunCod VARCHAR (100)=NULL,
                                                                 @LineDetails VARCHAR (250)=NULL,
                                                                 @Serial_Key VARCHAR (100)=NULL,
                                                                 @ItmTax FLOAT =NULL,
                                                                 @OfferTyp INT =NULL                                              
                                                          )
                                                          AS
                                                          BEGIN
                                                          INSERT INTO T_INVDET(
                                                                 InvNo,
                                                                 InvId,
                                                                 InvSer,
                                                                 ItmNo,
                                                                 Cost,
                                                                 Qty,
                                                                 ItmDes,
                                                                 ItmUnt,
                                                                 ItmDesE,
                                                                 ItmUntE,
                                                                 ItmUntPak,
                                                                 StoreNo,
                                                                 Price,
                                                                 Amount,
                                                                 RealQty,
                                                                 itmInvDsc,
                                                                 DatExper,
                                                                 ItmDis,
                                                                 ItmTyp,
                                                                 ItmIndex,
                                                                 ItmWight,
                                                                 ItmWight_T,
                                                                 ItmAddCost,
                                                                 RunCod,
                                                                 LineDetails,
                                                                 Serial_Key,
                                                                 ItmTax,
                                                                OfferTyp  
                                                          )
                                                          VALUES
                                                          (
                                                                 
                                                                @InvNo,
                                                                @InvId,
                                                                @InvSer,
                                                                @ItmNo,
                                                                @Cost,
                                                                @Qty,
                                                                @ItmDes,
                                                                @ItmUnt,
                                                                @ItmDesE,
                                                                @ItmUntE,
                                                                @ItmUntPak,
                                                                @StoreNo,
                                                                @Price,
                                                                @Amount,
                                                                @RealQty,
                                                                @itmInvDsc,
                                                                @DatExper,
                                                                @ItmDis,
                                                                @ItmTyp,
                                                                @ItmIndex,
                                                                @ItmWight,
                                                                @ItmWight_T,
                                                                @ItmAddCost,
                                                                @RunCod,
                                                                @LineDetails,
                                                                @Serial_Key,
                                                                @ItmTax,
                                                                @OfferTyp
                                                          )
                                                          SELECT @InvDet_ID = SCOPE_IDENTITY()
                                                            declare @ItemCount int  
                                                            declare @InvTyp int
                                                            declare @MndID int
                                                            declare @CusVenNo varchar(30)
                                                            declare @ItemCountMnd int 
                                                            declare @ItemCountCust int 
		                                                    select @ItemCount = Count(*) from T_STKSQTY where itmNo = @ItmNo and storeNo =@StoreNo;
                                                            select @InvTyp = InvTyp from T_INVHED where InvHed_ID = @InvId;
                                                            if((@InvTyp != 7 and @InvTyp != 8 and @InvTyp != 9 and @InvTyp != 21) and @ItmTyp <> 3)
                                                            begin
			                                                          if(@ItmTyp <> 2)
			                                                          begin
		                                                                    Update T_Items SET OpenQty = OpenQty+@RealQty WHERE Itm_No = @ItmNo;
			                                                                if(@ItemCount > 0)
			                                                                begin
			                                                                Update T_STKSQTY SET stkQty = stkQty+@RealQty WHERE itmNo = @ItmNo and storeNo = @StoreNo;
			                                                                end
			                                                                if(@ItemCount = 0)
			                                                                begin 
			                                                                INSERT INTO T_STKSQTY(itmNo,storeNo,stkQty,stkInt) VALUES(@ItmNo,@StoreNo,@RealQty,0);
			                                                                END
                                                                            if(@InvTyp = 14)
                                                                            begin
				                                                                Update T_STKSQTY SET stkInt = stkInt+@RealQty WHERE itmNo = @ItmNo and storeNo = @StoreNo;
                                                                            end
			                                                                select @ItemCount = Count(*) from T_QTYEXP where itmNo = @ItmNo and storeNo =@StoreNo and (DatExper = @DatExper and RunCod = @RunCod);
			                                                                if(@ItemCount > 0 and (@DatExper <> '' or @RunCod <> ''))
			                                                                begin
			                                                                Update T_QTYEXP SET stkQty = stkQty+@RealQty WHERE itmNo = @ItmNo and storeNo = @StoreNo and (DatExper = @DatExper and RunCod = @RunCod);
			                                                                end
			                                                                if(@ItemCount = 0 and (@DatExper <> '' or @RunCod <> ''))
			                                                                begin 
			                                                                INSERT INTO T_QTYEXP(itmNo,storeNo,DatExper,stkQty,RunCod) VALUES(@ItmNo,@StoreNo,@DatExper,@RealQty,@RunCod);
			                                                                END
                                                                END
			                                                          if(@InvTyp = 17)
				                                                          begin
														                       select @MndID = MndNo from T_INVHED where InvHed_ID = @InvId;
														                       select @CusVenNo = CusVenNo from T_INVHED where InvHed_ID = @InvId;
														                       if(@MndID > 0 )
															                    begin
															                              select @ItemCountMnd = Count(*) from T_StoreMnd where itmNo = @ItmNo and storeNo =@StoreNo and MndNo = @MndID;
																	                      if(@ItemCountMnd > 0)
																	                      begin
																		                       Update T_StoreMnd SET stkQty = stkQty + abs(@RealQty) WHERE itmNo = @ItmNo and storeNo = @StoreNo and MndNo = @MndID;
																	                      end
																	                      if(@ItemCountMnd = 0)
																	                      begin 
																		                       INSERT INTO T_StoreMnd(itmNo,storeNo,stkQty,stkInt,MndNo) VALUES(@ItmNo,@StoreNo,abs(@RealQty),0,@MndID);
																	                      END
															                    END
														                      else
									                                            begin
															                             select @ItemCountCust = Count(*) from T_StoreMnd where itmNo = @ItmNo and storeNo =@StoreNo and CusVenNo = @CusVenNo;
																	                      if(@ItemCountCust > 0)
																	                      begin
																		                       Update T_StoreMnd SET stkQty = stkQty + abs(@RealQty) WHERE itmNo = @ItmNo and storeNo = @StoreNo and CusVenNo = @CusVenNo;
																	                      end
																	                      if(@ItemCountCust = 0)
																	                      begin 
																		                       INSERT INTO T_StoreMnd(itmNo,storeNo,stkQty,stkInt,CusVenNo) VALUES(@ItmNo,@StoreNo,abs(@RealQty),0,@CusVenNo);
																	                      END
															                    END
				                                                          END	
			                                                          if(@InvTyp = 20)
				                                                          begin
				                                                              select @MndID = MndNo from T_INVHED where InvHed_ID = @InvId;
														                      select @CusVenNo = CusVenNo from T_INVHED where InvHed_ID = @InvId;
														                        if(@MndID > 0 )
																                    begin
																	                     select @ItemCountMnd = Count(*) from T_StoreMnd where itmNo = @ItmNo and storeNo =@StoreNo and MndNo = @MndID;
																	                      if(@ItemCountMnd > 0)
																	                      begin
																		                       Update T_StoreMnd SET stkQty = stkQty + (-@RealQty) WHERE itmNo = @ItmNo and storeNo = @StoreNo and MndNo = @MndID;
																	                      end
																	                      if(@ItemCountMnd = 0)
																	                      begin 
																		                       INSERT INTO T_StoreMnd(itmNo,storeNo,stkQty,stkInt,MndNo) VALUES(@ItmNo,@StoreNo,-@RealQty,0,@MndID);
																	                      END
																                     END
							                                                     else
							                                                         begin
																	                     select @ItemCountCust = Count(*) from T_StoreMnd where itmNo = @ItmNo and storeNo =@StoreNo and CusVenNo = @CusVenNo;
																	                      if(@ItemCountCust > 0)
																	                      begin
																		                       Update T_StoreMnd SET stkQty = stkQty + (-@RealQty) WHERE itmNo = @ItmNo and storeNo = @StoreNo and CusVenNo = @CusVenNo;
																	                      end
																	                      if(@ItemCountCust = 0)
																	                      begin 
																		                       INSERT INTO T_StoreMnd(itmNo,storeNo,stkQty,stkInt,CusVenNo) VALUES(@ItmNo,@StoreNo,-@RealQty,0,@CusVenNo);
																	                      END
																                     END
				                                                          end
                                                            end
                                                          RETURN @InvDet_ID
                                                          END
";
        public static string s3 = @"
  ALTER PROCEDURE [dbo].[S_T_INVDET_INSERT](   
                                                                 @InvDet_ID INT OUTPUT,
                                                                 @InvNo VARCHAR (10)=NULL,
                                                                 @InvId INT =NULL,
                                                                 @InvSer INT =NULL,
                                                                 @ItmNo VARCHAR (50)=NULL,
                                                                 @Cost FLOAT =NULL,
                                                                 @Qty FLOAT =NULL,
                                                                 @ItmDes VARCHAR (50)=NULL,
                                                                 @ItmUnt VARCHAR (100)=NULL,
                                                                 @ItmDesE VARCHAR (50)=NULL,
                                                                 @ItmUntE VARCHAR (100)=NULL,
                                                                 @ItmUntPak FLOAT =NULL,
                                                                 @StoreNo INT=NULL,
                                                                 @Price FLOAT =NULL,
                                                                 @Amount FLOAT =NULL,
                                                                 @RealQty FLOAT =NULL,
                                                                 @itmInvDsc FLOAT =NULL,
                                                                 @DatExper VARCHAR (11)=NULL,
                                                                 @ItmDis FLOAT =NULL,
                                                                 @ItmTyp INT =NULL,
                                                                 @ItmIndex INT =NULL,
                                                                 @ItmWight FLOAT =NULL,
                                                                 @ItmWight_T FLOAT =NULL,
                                                                 @ItmAddCost FLOAT =NULL,
                                                                 @RunCod VARCHAR (100)=NULL,
                                                                 @LineDetails VARCHAR (250)=NULL,
                                                                 @Serial_Key VARCHAR (100)=NULL,
                                                                 @ItmTax FLOAT =NULL,
                                                                 @OfferTyp INT =NULL                                              
                                                          )
                                                          AS
                                                          BEGIN
                                                          INSERT INTO T_INVDET(
                                                                 InvNo,
                                                                 InvId,
                                                                 InvSer,
                                                                 ItmNo,
                                                                 Cost,
                                                                 Qty,
                                                                 ItmDes,
                                                                 ItmUnt,
                                                                 ItmDesE,
                                                                 ItmUntE,
                                                                 ItmUntPak,
                                                                 StoreNo,
                                                                 Price,
                                                                 Amount,
                                                                 RealQty,
                                                                 itmInvDsc,
                                                                 DatExper,
                                                                 ItmDis,
                                                                 ItmTyp,
                                                                 ItmIndex,
                                                                 ItmWight,
                                                                 ItmWight_T,
                                                                 ItmAddCost,
                                                                 RunCod,
                                                                 LineDetails,
                                                                 Serial_Key,
                                                                 ItmTax,
                                                                OfferTyp  
                                                          )
                                                          VALUES
                                                          (
                                                                 
                                                                @InvNo,
                                                                @InvId,
                                                                @InvSer,
                                                                @ItmNo,
                                                                @Cost,
                                                                @Qty,
                                                                @ItmDes,
                                                                @ItmUnt,
                                                                @ItmDesE,
                                                                @ItmUntE,
                                                                @ItmUntPak,
                                                                @StoreNo,
                                                                @Price,
                                                                @Amount,
                                                                @RealQty,
                                                                @itmInvDsc,
                                                                @DatExper,
                                                                @ItmDis,
                                                                @ItmTyp,
                                                                @ItmIndex,
                                                                @ItmWight,
                                                                @ItmWight_T,
                                                                @ItmAddCost,
                                                                @RunCod,
                                                                @LineDetails,
                                                                @Serial_Key,
                                                                @ItmTax,
                                                                @OfferTyp
                                                          )
                                                          SELECT @InvDet_ID = SCOPE_IDENTITY()
                                                            declare @ItemCount int  
                                                            declare @InvTyp int
                                                            declare @MndID int
                                                            declare @CusVenNo varchar(30)
                                                            declare @ItemCountMnd int 
                                                            declare @ItemCountCust int 
		                                                    select @ItemCount = Count(*) from T_STKSQTY where itmNo = @ItmNo and storeNo =@StoreNo;
                                                            select @InvTyp = InvTyp from T_INVHED where InvHed_ID = @InvId;
                                                            if((@InvTyp != 7 and @InvTyp != 8 and @InvTyp != 9 and @InvTyp != 21) and @ItmTyp <> 3)
                                                            begin
			                                                          if(@ItmTyp <> 2)
			                                                          begin
		                                                                    Update T_Items SET OpenQty = OpenQty+@RealQty WHERE Itm_No = @ItmNo;
			                                                                if(@ItemCount > 0)
			                                                                begin
			                                                                Update T_STKSQTY SET stkQty = stkQty+@RealQty WHERE itmNo = @ItmNo and storeNo = @StoreNo;
			                                                                end
			                                                                if(@ItemCount = 0)
			                                                                begin 
			                                                                INSERT INTO T_STKSQTY(itmNo,storeNo,stkQty,stkInt) VALUES(@ItmNo,@StoreNo,@RealQty,0);
			                                                                END
                                                                            if(@InvTyp = 14)
                                                                            begin
				                                                                Update T_STKSQTY SET stkInt = stkInt+@RealQty WHERE itmNo = @ItmNo and storeNo = @StoreNo;
                                                                            end
			                                                                select @ItemCount = Count(*) from T_QTYEXP where itmNo = @ItmNo and storeNo =@StoreNo and (DatExper = @DatExper and RunCod = @RunCod);
			                                                                if(@ItemCount > 0 and (@DatExper <> '' or @RunCod <> ''))
			                                                                begin
			                                                                Update T_QTYEXP SET stkQty = stkQty+@RealQty WHERE itmNo = @ItmNo and storeNo = @StoreNo and (DatExper = @DatExper and RunCod = @RunCod);
			                                                                end
			                                                                if(@ItemCount = 0 and (@DatExper <> '' or @RunCod <> ''))
			                                                                begin 
			                                                                INSERT INTO T_QTYEXP(itmNo,storeNo,DatExper,stkQty,RunCod) VALUES(@ItmNo,@StoreNo,@DatExper,@RealQty,@RunCod);
			                                                                END
                                                                END
			                                                          if(@InvTyp = 17)
				                                                          begin
														                       select @MndID = MndNo from T_INVHED where InvHed_ID = @InvId;
														                       select @CusVenNo = CusVenNo from T_INVHED where InvHed_ID = @InvId;
														                       if(@MndID > 0 )
															                    begin
															                              select @ItemCountMnd = Count(*) from T_StoreMnd where itmNo = @ItmNo and storeNo =@StoreNo and MndNo = @MndID;
																	                      if(@ItemCountMnd > 0)
																	                      begin
																		                       Update T_StoreMnd SET stkQty = stkQty + abs(@RealQty) WHERE itmNo = @ItmNo and storeNo = @StoreNo and MndNo = @MndID;
																	                      end
																	                      if(@ItemCountMnd = 0)
																	                      begin 
																		                       INSERT INTO T_StoreMnd(itmNo,storeNo,stkQty,stkInt,MndNo) VALUES(@ItmNo,@StoreNo,abs(@RealQty),0,@MndID);
																	                      END
															                    END
														                      else
									                                            begin
															                             select @ItemCountCust = Count(*) from T_StoreMnd where itmNo = @ItmNo and storeNo =@StoreNo and CusVenNo = @CusVenNo;
																	                      if(@ItemCountCust > 0)
																	                      begin
																		                       Update T_StoreMnd SET stkQty = stkQty + abs(@RealQty) WHERE itmNo = @ItmNo and storeNo = @StoreNo and CusVenNo = @CusVenNo;
																	                      end
																	                      if(@ItemCountCust = 0)
																	                      begin 
																		                       INSERT INTO T_StoreMnd(itmNo,storeNo,stkQty,stkInt,CusVenNo) VALUES(@ItmNo,@StoreNo,abs(@RealQty),0,@CusVenNo);
																	                      END
															                    END
				                                                          END	
			                                                          if(@InvTyp = 20)
				                                                          begin
				                                                              select @MndID = MndNo from T_INVHED where InvHed_ID = @InvId;
														                      select @CusVenNo = CusVenNo from T_INVHED where InvHed_ID = @InvId;
														                        if(@MndID > 0 )
																                    begin
																	                     select @ItemCountMnd = Count(*) from T_StoreMnd where itmNo = @ItmNo and storeNo =@StoreNo and MndNo = @MndID;
																	                      if(@ItemCountMnd > 0)
																	                      begin
																		                       Update T_StoreMnd SET stkQty = stkQty + (-@RealQty) WHERE itmNo = @ItmNo and storeNo = @StoreNo and MndNo = @MndID;
																	                      end
																	                      if(@ItemCountMnd = 0)
																	                      begin 
																		                       INSERT INTO T_StoreMnd(itmNo,storeNo,stkQty,stkInt,MndNo) VALUES(@ItmNo,@StoreNo,-@RealQty,0,@MndID);
																	                      END
																                     END
							                                                     else
							                                                         begin
																	                     select @ItemCountCust = Count(*) from T_StoreMnd where itmNo = @ItmNo and storeNo =@StoreNo and CusVenNo = @CusVenNo;
																	                      if(@ItemCountCust > 0)
																	                      begin
																		                       Update T_StoreMnd SET stkQty = stkQty + (-@RealQty) WHERE itmNo = @ItmNo and storeNo = @StoreNo and CusVenNo = @CusVenNo;
																	                      end
																	                      if(@ItemCountCust = 0)
																	                      begin 
																		                       INSERT INTO T_StoreMnd(itmNo,storeNo,stkQty,stkInt,CusVenNo) VALUES(@ItmNo,@StoreNo,-@RealQty,0,@CusVenNo);
																	                      END
																                     END
				                                                          end
                                                            end
                                                          RETURN @InvDet_ID
                                                          END
";
        public static string prit = @"IF NOT EXISTS (
  SELECT  * FROM INFORMATION_SCHEMA.Columns
  where TABLE_SCHEMA='dbo'
  AND
  TABLE_NAME='T_INVSETTING'
  AND
  COLUMN_NAME='UserNo'
)
BEGIN
ALTER TABLE dbo.T_INVSETTING ADD
	UserNo int NULL
END;";
        public static string addcheseNumber = @"IF NOT EXISTS (
  SELECT  * FROM INFORMATION_SCHEMA.Columns
  where TABLE_SCHEMA='dbo'
  AND
  TABLE_NAME='T_INVHED'
  AND
  COLUMN_NAME='VehiclechassisNumber'
)
BEGIN
ALTER TABLE dbo.T_INVHED ADD
	VehiclechassisNumber varchar(100) NULL

END;";


        string addstatusoforder = @"
IF NOT EXISTS (
  SELECT  * FROM INFORMATION_SCHEMA.Columns
  where TABLE_SCHEMA='dbo'
  AND
  TABLE_NAME='T_INVHED'
  AND
  COLUMN_NAME='OrderStatus'
)
BEGIN
ALTER TABLE dbo.T_INVHED ADD
	OrderStatus int NULL
END;";

        public static string addscolor = @"
IF NOT EXISTS (
  SELECT  * FROM INFORMATION_SCHEMA.Columns
  where TABLE_SCHEMA='dbo'
  AND
  TABLE_NAME='T_Colors'
  AND
  COLUMN_NAME='Color_NameE'
)
BEGIN
ALTER TABLE dbo.T_Colors ADD
	Color_NameE varchar(MAX) NULL
END;";
        public static string MessagTemplates = @"BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.T_MTemplates
	(
	ID int NOT NULL,
	TemplateNo varchar(50) NULL,
	Tamplate_Name varchar(50) NULL,
	Message varchar(MAX) NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.T_MTemplates ADD CONSTRAINT
	PK_T_MTemplates PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.T_MTemplates SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.T_MTemplates', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.T_MTemplates', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.T_MTemplates', 'Object', 'CONTROL') as Contr_Per ";

        public static string ss = @"ALTER PROCEDURE [dbo].[S_T_INVDET_INSERT](   
                                                                 @InvDet_ID INT OUTPUT,
                                                                 @InvNo VARCHAR (10)=NULL,
                                                                 @InvId INT =NULL,
                                                                 @InvSer INT =NULL,
                                                                 @ItmNo VARCHAR (50)=NULL,
                                                                 @Cost FLOAT =NULL,
                                                                 @Qty FLOAT =NULL,
                                                                 @ItmDes VARCHAR (50)=NULL,
                                                                 @ItmUnt VARCHAR (100)=NULL,
                                                                 @ItmDesE VARCHAR (50)=NULL,
                                                                 @ItmUntE VARCHAR (100)=NULL,
                                                                 @ItmUntPak FLOAT =NULL,
                                                                 @StoreNo INT=NULL,
                                                                 @Price FLOAT =NULL,
                                                                 @Amount FLOAT =NULL,
                                                                 @RealQty FLOAT =NULL,
                                                                 @itmInvDsc FLOAT =NULL,
                                                                 @DatExper VARCHAR (11)=NULL,
                                                                 @ItmDis FLOAT =NULL,
                                                                 @ItmTyp INT =NULL,
                                                                 @ItmIndex INT =NULL,
                                                                 @ItmWight FLOAT =NULL,
                                                                 @ItmWight_T FLOAT =NULL,
                                                                 @ItmAddCost FLOAT =NULL,
                                                                 @RunCod VARCHAR (100)=NULL,
                                                                 @LineDetails VARCHAR (250)=NULL,
                                                                 @Serial_Key VARCHAR (100)=NULL,
                                                                 @ItmTax FLOAT =NULL,
                                                                 @OfferTyp INT =NULL  ,
																 @CaExState INT =0
,@Branch_No INT =1
                                                          )
                                                          AS
                                                          BEGIN
                                                          INSERT INTO T_INVDET(
                                                                 InvNo,
                                                                 InvId,
                                                                 InvSer,
                                                                 ItmNo,
                                                                 Cost,
                                                                 Qty,
                                                                 ItmDes,
                                                                 ItmUnt,
                                                                 ItmDesE,
                                                                 ItmUntE,
                                                                 ItmUntPak,
                                                                 StoreNo,
                                                                 Price,
                                                                 Amount,
                                                                 RealQty,
                                                                 itmInvDsc,
                                                                 DatExper,
                                                                 ItmDis,
                                                                 ItmTyp,
                                                                 ItmIndex,
                                                                 ItmWight,
                                                                 ItmWight_T,
                                                                 ItmAddCost,
                                                                 RunCod,
                                                                 LineDetails,
                                                                 Serial_Key,
                                                                 ItmTax,
                                                                OfferTyp  ,CaExState
,Branch_No
                                                          )
                                                          VALUES
                                                          (
                                                                 
                                                                @InvNo,
                                                                @InvId,
                                                                @InvSer,
                                                                @ItmNo,
                                                                @Cost,
                                                                @Qty,
                                                                @ItmDes,
                                                                @ItmUnt,
                                                                @ItmDesE,
                                                                @ItmUntE,
                                                                @ItmUntPak,
                                                                @StoreNo,
                                                                @Price,
                                                                @Amount,
                                                                @RealQty,
                                                                @itmInvDsc,
                                                                @DatExper,
                                                                @ItmDis,
                                                                @ItmTyp,
                                                                @ItmIndex,
                                                                @ItmWight,
                                                                @ItmWight_T,
                                                                @ItmAddCost,
                                                                @RunCod,
                                                                @LineDetails,
                                                                @Serial_Key,
                                                                @ItmTax,
                                                                @OfferTyp
																,@CaExState
,@Branch_No
                                                          )
                                                          SELECT @InvDet_ID = SCOPE_IDENTITY()
                                                            declare @ItemCount int  
                                                            declare @InvTyp int
                                                            declare @MndID int
                                                            declare @CusVenNo varchar(30)
                                                            declare @ItemCountMnd int 
                                                            declare @ItemCountCust int 
		                                                    select @ItemCount = Count(*) from T_STKSQTY where itmNo = @ItmNo and storeNo =@StoreNo;
                                                            select @InvTyp = InvTyp from T_INVHED where InvHed_ID = @InvId;
                                                            if((@InvTyp != 7 and @InvTyp != 8 and @InvTyp != 9 and @InvTyp != 21) and @ItmTyp <> 3)
                                                            begin
			                                                          if(@ItmTyp <> 2)
			                                                          begin
		                                                                    Update T_Items SET OpenQty = OpenQty+@RealQty WHERE Itm_No = @ItmNo;
			                                                                if(@ItemCount > 0)
			                                                                begin
			                                                                Update T_STKSQTY SET stkQty = stkQty+@RealQty WHERE itmNo = @ItmNo and storeNo = @StoreNo;
			                                                                end
			                                                                if(@ItemCount = 0)
			                                                                begin 
			                                                                INSERT INTO T_STKSQTY(itmNo,storeNo,stkQty,stkInt) VALUES(@ItmNo,@StoreNo,@RealQty,0);
			                                                                END
                                                                            if(@InvTyp = 14)
                                                                            begin
				                                                                Update T_STKSQTY SET stkInt = stkInt+@RealQty WHERE itmNo = @ItmNo and storeNo = @StoreNo;
                                                                            end
			                                                                select @ItemCount = Count(*) from T_QTYEXP where itmNo = @ItmNo and storeNo =@StoreNo and (DatExper = @DatExper and RunCod = @RunCod);
			                                                                if(@ItemCount > 0 and (@DatExper <> '' or @RunCod <> ''))
			                                                                begin
			                                                                Update T_QTYEXP SET stkQty = stkQty+@RealQty WHERE itmNo = @ItmNo and storeNo = @StoreNo and (DatExper = @DatExper and RunCod = @RunCod);
			                                                                end
			                                                                if(@ItemCount = 0 and (@DatExper <> '' or @RunCod <> ''))
			                                                                begin 
			                                                                INSERT INTO T_QTYEXP(itmNo,storeNo,DatExper,stkQty,RunCod) VALUES(@ItmNo,@StoreNo,@DatExper,@RealQty,@RunCod);
			                                                                END
                                                                END
			                                                          if(@InvTyp = 17)
				                                                          begin
														                       select @MndID = MndNo from T_INVHED where InvHed_ID = @InvId;
														                       select @CusVenNo = CusVenNo from T_INVHED where InvHed_ID = @InvId;
														                       if(@MndID > 0 )
															                    begin
															                              select @ItemCountMnd = Count(*) from T_StoreMnd where itmNo = @ItmNo and storeNo =@StoreNo and MndNo = @MndID;
																	                      if(@ItemCountMnd > 0)
																	                      begin
																		                       Update T_StoreMnd SET stkQty = stkQty + abs(@RealQty) WHERE itmNo = @ItmNo and storeNo = @StoreNo and MndNo = @MndID;
																	                      end
																	                      if(@ItemCountMnd = 0)
																	                      begin 
																		                       INSERT INTO T_StoreMnd(itmNo,storeNo,stkQty,stkInt,MndNo) VALUES(@ItmNo,@StoreNo,abs(@RealQty),0,@MndID);
																	                      END
															                    END
														                      else
									                                            begin
															                             select @ItemCountCust = Count(*) from T_StoreMnd where itmNo = @ItmNo and storeNo =@StoreNo and CusVenNo = @CusVenNo;
																	                      if(@ItemCountCust > 0)
																	                      begin
																		                       Update T_StoreMnd SET stkQty = stkQty + abs(@RealQty) WHERE itmNo = @ItmNo and storeNo = @StoreNo and CusVenNo = @CusVenNo;
																	                      end
																	                      if(@ItemCountCust = 0)
																	                      begin 
																		                       INSERT INTO T_StoreMnd(itmNo,storeNo,stkQty,stkInt,CusVenNo) VALUES(@ItmNo,@StoreNo,abs(@RealQty),0,@CusVenNo);
																	                      END
															                    END
				                                                          END	
			                                                          if(@InvTyp = 20)
				                                                          begin
				                                                              select @MndID = MndNo from T_INVHED where InvHed_ID = @InvId;
														                      select @CusVenNo = CusVenNo from T_INVHED where InvHed_ID = @InvId;
														                        if(@MndID > 0 )
																                    begin
																	                     select @ItemCountMnd = Count(*) from T_StoreMnd where itmNo = @ItmNo and storeNo =@StoreNo and MndNo = @MndID;
																	                      if(@ItemCountMnd > 0)
																	                      begin
																		                       Update T_StoreMnd SET stkQty = stkQty + (-@RealQty) WHERE itmNo = @ItmNo and storeNo = @StoreNo and MndNo = @MndID;
																	                      end
																	                      if(@ItemCountMnd = 0)
																	                      begin 
																		                       INSERT INTO T_StoreMnd(itmNo,storeNo,stkQty,stkInt,MndNo) VALUES(@ItmNo,@StoreNo,-@RealQty,0,@MndID);
																	                      END
																                     END
							                                                     else
							                                                         begin
																	                     select @ItemCountCust = Count(*) from T_StoreMnd where itmNo = @ItmNo and storeNo =@StoreNo and CusVenNo = @CusVenNo;
																	                      if(@ItemCountCust > 0)
																	                      begin
																		                       Update T_StoreMnd SET stkQty = stkQty + (-@RealQty) WHERE itmNo = @ItmNo and storeNo = @StoreNo and CusVenNo = @CusVenNo;
																	                      end
																	                      if(@ItemCountCust = 0)
																	                      begin 
																		                       INSERT INTO T_StoreMnd(itmNo,storeNo,stkQty,stkInt,CusVenNo) VALUES(@ItmNo,@StoreNo,-@RealQty,0,@CusVenNo);
																	                      END
																                     END
				                                                          end
                                                            end
                                                          RETURN @InvDet_ID
                                                          END
";
        public static string updteBranchProcedures = @"/****** Object:  StoredProcedure [dbo].[UpdateBalance]    Script Date: 09/06/2021 11:39:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[UpdateBalance]
	-- Add the parameters for the stored procedure here
	@NewCredit decimal,
	@NewDebit decimal,
	@AccountNumber VARCHAR(50),@Branch_Number INT =1
AS
BEGIN
	DECLARE @Amount1 decimal, @Amount2 decimal, @Amount3 decimal;

select @Amount1 = Debit, @Amount2 = Credit, @Amount3 = Balance from T_AccDef where AccDef_No = @AccountNumber and Branch_Number=@Branch_Number;

update T_AccDef SET Credit = Credit+@NewCredit, 
					Debit = Debit + @NewDebit,
					Balance = Balance+@NewCredit-@NewDebit
				WHERE AccDef_No = @AccountNumber and Branch_Number=@Branch_Number;;

END

GO
/****** Object:  StoredProcedure [dbo].[S_T_SINVDET_INSERT]    Script Date: 09/06/2021 11:35:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 ALTER PROCEDURE [dbo].[S_T_SINVDET_INSERT](   
                                                 @SInvDet_ID INT OUTPUT,
                                                 @SInvNo VARCHAR (10)=NULL,
                                                 @SInvId INT =NULL,
                                                 @SInvSer INT =NULL,
                                                 @SItmNo VARCHAR (50)=NULL,
                                                 @SCost FLOAT =NULL,
                                                 @SQty FLOAT =NULL,
                                                 @SItmDes VARCHAR (50)=NULL,
                                                 @SItmUnt VARCHAR (100)=NULL,
                                                 @SItmDesE VARCHAR (50)=NULL,
                                                 @SItmUntE VARCHAR (100)=NULL,
                                                 @SItmUntPak FLOAT =NULL,
                                                 @SStoreNo INT=NULL,
                                                 @SPrice FLOAT =NULL,
                                                 @SAmount FLOAT =NULL,
                                                 @SRealQty FLOAT =NULL,
                                                 @SitmInvDsc FLOAT =NULL,
                                                 @SDatExper VARCHAR (11)=NULL,
                                                 @SItmDis FLOAT =NULL,
                                                 @SItmTyp INT =NULL,
                                                 @SItmIndex INT =NULL,
                                                 @SItmWight FLOAT =NULL,
                                                 @SItmWight_T FLOAT =NULL,
                                                 @SQtyDef FLOAT =NULL,
                                                 @SPriceDef FLOAT =NULL,
                                                 @SInvIdHEAD INT =NULL,
                                                 @SItmTax FLOAT =NULL  ,
												 @Branch_Number INT=1
                                                 
                                          )
                                          AS
                                          BEGIN
                                          INSERT INTO T_SINVDET(
                                                 SInvNo,
                                                 SInvId,
                                                 SInvSer,
                                                 SItmNo,
                                                 SCost,
                                                 SQty,
                                                 SItmDes,
                                                 SItmUnt,
                                                 SItmDesE,
                                                 SItmUntE,
                                                 SItmUntPak,
                                                 SStoreNo,
                                                 SPrice,
                                                 SAmount,
                                                 SRealQty,
                                                 SitmInvDsc,
                                                 SDatExper,
                                                 SItmDis,
                                                 SItmTyp,
                                                 SItmIndex,
                                                 SItmWight,
                                                 SItmWight_T,
                                                 SQtyDef,
                                                 SPriceDef,
                                                 SInvIdHEAD,
                                                 SItmTax,Branch_Number
                                          )
                                          VALUES
                                          (
                                                @SInvNo,
                                                @SInvId,
                                                @SInvSer,
                                                @SItmNo,
                                                @SCost,
                                                @SQty,
                                                @SItmDes,
                                                @SItmUnt,
                                                @SItmDesE,
                                                @SItmUntE,
                                                @SItmUntPak,
                                                @SStoreNo,
                                                @SPrice,
                                                @SAmount,
                                                @SRealQty,
                                                @SitmInvDsc,
                                                @SDatExper,
                                                @SItmDis,
                                                @SItmTyp,
                                                @SItmIndex,
                                                @SItmWight,
                                                @SItmWight_T,
                                                @SQtyDef,
                                                @SPriceDef,
                                                @SInvIdHEAD,
                                                @SItmTax,@Branch_Number
                                          )
                                          SELECT @SInvDet_ID = SCOPE_IDENTITY()
                                                declare @SItemCount int  
                                                declare @SInvTyp int
                                                declare @SMndID int
                                                declare @SItemCountMnd int 
                                                declare @SRelation int
                                                   
                                                select @SRelation = InvId from T_INVDET where InvDet_ID = @SInvId ;
                                                select @SItemCount = Count(*) from T_STKSQTY where itmNo = @SItmNo and storeNo =@SStoreNo and Branch_Number=@Branch_Number;
                                                select @SInvTyp = InvTyp from T_INVHED where InvHed_ID = @SRelation and Branch_Number=@Branch_Number;
                                                if((@SInvTyp != 7 and @SInvTyp != 8 and @SInvTyp != 9 and @SInvTyp != 21) and @SItmTyp <> 3 and @SItmTyp <> 2)
                                                begin
                                                    Update T_Items SET OpenQty = OpenQty+@SRealQty WHERE Itm_No = @SItmNo;
                                                    if(@SItemCount > 0)
                                                    begin
                                                    Update T_STKSQTY SET stkQty = stkQty+@SRealQty WHERE itmNo = @SItmNo and storeNo = @SStoreNo and Branch_Number=@Branch_Number;;
                                                    end
                                                    if(@SItemCount = 0)
                                                    begin 
                                                    INSERT INTO T_STKSQTY(itmNo,storeNo,stkQty,stkInt,Branch_Number) VALUES(@SItmNo,@SStoreNo,@SRealQty,0,@Branch_Number);
                                                    END
                                                    if(@SInvTyp = 14)
                                                    begin
                                                        Update T_STKSQTY SET stkInt = stkInt+@SRealQty WHERE itmNo = @SItmNo and storeNo = @SStoreNo and Branch_Number=@Branch_Number;;
                                                    end
                                                    select @SItemCount = Count(*) from T_QTYEXP where itmNo = @SItmNo and storeNo =@SStoreNo and DatExper = @SDatExper and Branch_Number=@Branch_Number;;
                                                    if(@SItemCount > 0 and @SDatExper <> '')
                                                    begin
                                                    Update T_QTYEXP SET stkQty = stkQty+@SRealQty WHERE itmNo = @SItmNo and storeNo = @SStoreNo and DatExper = @SDatExper and Branch_Number=@Branch_Number;;
                                                    end
                                                    if(@SItemCount = 0 and @SDatExper <> '')
                                                    begin 
                                                    INSERT INTO T_QTYEXP(itmNo,storeNo,DatExper,stkQty,Branch_Number) VALUES(@SItmNo,@SStoreNo,@SDatExper,@SRealQty,@Branch_Number);
													END
--                                                    if(@SInvTyp = 17)
--                                                        begin
--                                                         select @SMndID = MndNo from T_INVHED where InvHed_ID = @SRelation;
--                                                            select @SItemCountMnd = Count(*) from T_StoreMnd where itmNo = @SItmNo and storeNo =@SStoreNo and MndNo = @SMndID and Branch_Number=@Branch_Number;;
--                                                                    if(@SItemCountMnd > 0)
--                                                                    begin
--                                                                         Update T_StoreMnd SET stkQty = stkQty + abs(@SRealQty) WHERE itmNo = @SItmNo and storeNo = @SStoreNo and MndNo = @SMndID and Branch_Number=@Branch_Number;;
--                                                                    end
--
--                                                                    if(@SItemCountMnd = 0)
--                                                                    begin 
--                                                                         INSERT INTO T_StoreMnd(itmNo,storeNo,stkQty,stkInt,MndNo,Branch_Number) VALUES(@SItmNo,@SStoreNo,abs(@SRealQty),0,@SMndID,@Branch_Number);
--                                                                    END
--                                                        end	
--                                                    if(@SInvTyp = 20)
--                                                        begin
--                                                         select @SMndID = MndNo from T_INVHED where InvHed_ID = @SRelation;
--                                                            select @SItemCountMnd = Count(*) from T_StoreMnd where itmNo = @SItmNo and storeNo =@SStoreNo and MndNo = @SMndID and Branch_Number=@Branch_Number;;
--                                                                    if(@SItemCountMnd > 0)
--                                                                    begin
--                                                                         Update T_StoreMnd SET stkQty = stkQty + (-@SRealQty) WHERE itmNo = @SItmNo and storeNo = @SStoreNo and MndNo = @SMndID and Branch_Number=@Branch_Number;;
--                                                                    end
--
--                                                                    if(@SItemCountMnd = 0)
--                                                                    begin 
--                                                                         INSERT INTO T_StoreMnd(itmNo,storeNo,stkQty,stkInt,MndNo,Branch_Number) VALUES(@SItmNo,@SStoreNo,-@SRealQty,0,@SMndID,@Branch_Number);
--                                                                    END
--                                                        end
                                                end
                                              RETURN
                                              END

GO
/****** Object:  StoredProcedure [dbo].[S_T_INVHED_UPDATE]    Script Date: 09/06/2021 11:31:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[S_T_INVHED_UPDATE](
                                                                                 @InvHed_ID INT ,
                                                                                 @InvId FLOAT =NULL,
                                                                                 @InvNo VARCHAR (10),
                                                                                 @InvTyp INT =NULL,
                                                                                 @InvCashPay INT =NULL,
                                                                                 @CusVenNo VARCHAR (20)=NULL,
                                                                                 @CusVenNm VARCHAR (50)=NULL,
                                                                                 @CusVenAdd VARCHAR (100)=NULL,
                                                                                 @CusVenTel VARCHAR (30)=NULL,
                                                                                 @Remark VARCHAR (MAX)=NULL,
                                                                                 @HDat VARCHAR (10)=NULL,
                                                                                 @GDat VARCHAR (10)=NULL,
                                                                                 @MndNo INT =NULL,
                                                                                 @SalsManNo VARCHAR (3)=NULL,
                                                                                 @SalsManNam VARCHAR (50)=NULL,
                                                                                 @InvTot FLOAT =NULL,
                                                                                 @InvTotLocCur FLOAT =NULL,
                                                                                 @InvDisPrs FLOAT =NULL,
                                                                                 @InvDisVal FLOAT =NULL,
                                                                                 @InvDisValLocCur FLOAT =NULL,
                                                                                 @InvNet FLOAT =NULL,
                                                                                 @InvNetLocCur FLOAT =NULL,
                                                                                 @CashPay FLOAT =NULL,
                                                                                 @CashPayLocCur FLOAT =NULL,
                                                                                 @IfRet INT =NULL,
                                                                                 @GadeNo FLOAT =NULL,
                                                                                 @GadeId FLOAT =NULL,
                                                                                 @IfDel INT =NULL,
                                                                                 @RetNo VARCHAR (10)=NULL,
                                                                                 @RetId FLOAT =NULL,
                                                                                 @InvCstNo INT =NULL,
                                                                                 @InvCashPayNm VARCHAR (100)=NULL,
                                                                                 @RefNo VARCHAR (20)=NULL,
                                                                                 @InvCost FLOAT =NULL,
                                                                                 @EstDat VARCHAR (10)=NULL,
                                                                                 @CustPri INT =NULL,
                                                                                 @ArbTaf VARCHAR (150)=NULL,
                                                                                 @CurTyp INT =NULL,
                                                                                 @InvCash VARCHAR (20)=NULL,
                                                                                 @ToStore VARCHAR (3)=NULL,
                                                                                 @ToStoreNm VARCHAR (50)=NULL,
                                                                                 @InvQty FLOAT =NULL,
                                                                                 @EngTaf VARCHAR (150)=NULL,
                                                                                 @IfTrans INT =NULL,
                                                                                 @CustRep FLOAT =NULL,
                                                                                 @CustNet FLOAT =NULL,
                                                                                 @InvWight_T FLOAT =NULL,
                                                                                 @IfPrint INT =NULL,
                                                                                 @LTim VARCHAR (10)=NULL,
                                                                                 @CREATED_BY VARCHAR(100) =NULL,
                                                                                 @DATE_CREATED datetime =NULL,
                                                                                 @MODIFIED_BY VARCHAR (100)=NULL,
                                                                                 @DATE_MODIFIED datetime=NULL,
                                                                                 @CreditPay float=NULL,
                                                                                 @CreditPayLocCur float=NULL,
                                                                                 @NetworkPay float=NULL,
                                                                                 @NetworkPayLocCur float=NULL,
                                                                                 @CommMnd_Inv float=NULL,
                                                                                 @MndExtrnal bit=NULL,
                                                                                 @CompanyID int=NULL,
                                                                                 @InvAddCost float=NULL,
                                                                                 @InvAddCostLoc float=NULL,
                                                                                 @InvAddCostExtrnal float=NULL,
                                                                                 @InvAddCostExtrnalLoc float=NULL,
                                                                                 @IsExtrnalGaid bit=NULL,
                                                                                 @ExtrnalCostGaidID float=NULL,
                                                                                 @Puyaid float=NULL,
                                                                                 @Remming float=NULL,
                                                                                 @RoomNo int=NULL,
                                                                                 @OrderTyp int=NULL,
                                                                                 @RoomSts bit=NULL,
                                                                                 @chauffeurNo int=NULL,
                                                                                 @RoomPerson int=NULL,
                                                                                 @ServiceValue float=NULL,
                                                                                 @Sts bit=NULL,
                                                                                 @PaymentOrderTyp int=NULL,
                                                                                 @AdminLock bit=NULL,
                                                                                 @DeleteDate VARCHAR (10)=NULL,
                                                                                 @DeleteTime VARCHAR (10)=NULL,
                                                                                 @UserNew VARCHAR (3)=NULL,
                                                                                 @IfEnter int=NULL,
                                                                                 @InvAddTax float=NULL,
                                                                                 @InvAddTaxlLoc float=NULL,
                                                                                 @IsTaxGaid bit=NULL,
                                                                                 @TaxGaidID float=NULL,
                                                                                 @IsTaxUse bit=NULL,
                                                                                 @InvValGaidDis float=NULL,
                                                                                 @InvValGaidDislLoc float=NULL,
                                                                                 @IsDisGaid bit=NULL,
                                                                                 @DisGaidID1 float=NULL,
                                                                                 @IsDisUse1 bit=NULL,
                                                                                 @InvComm float=NULL,
                                                                                 @InvCommLoc float=NULL,
                                                                                 @IsCommGaid bit=NULL,
                                                                                 @CommGaidID float=NULL,
                                                                                 @IsCommUse bit=NULL,
                                                                                 @IsTaxLines bit=NULL,
                                                                                 @IsTaxByTotal bit=NULL,
                                                                                 @IsTaxByNet bit=NULL,
                                                                                 @TaxByNetValue float=NULL,
                                                                                 @DesPointsValue float=NULL,
																			     @DesPointsValueLocCur float=NULL,
																			     @PointsCount float=NULL,
                                                                                 @IsPoints bit=NULL,
                                                                                 @tailor1 VARCHAR (100)=NULL,
                                                                                 @tailor2 VARCHAR (100)=NULL,
                                                                                 @tailor3 VARCHAR (100)=NULL,
                                                                                 @tailor4 VARCHAR (100)=NULL,
                                                                                 @tailor5 VARCHAR (100)=NULL,
                                                                                 @tailor6 VARCHAR (100)=NULL,
                                                                                 @tailor7 VARCHAR (100)=NULL,
                                                                                 @tailor8 VARCHAR (100)=NULL,
                                                                                 @tailor9 VARCHAR (100)=NULL,
                                                                                 @tailor10 VARCHAR (100)=NULL,
                                                                                 @tailor11 VARCHAR (100)=NULL,
                                                                                 @tailor12 VARCHAR (100)=NULL,
                                                                                 @tailor13 VARCHAR (100)=NULL,
                                                                                 @tailor14 VARCHAR (100)=NULL,
                                                                                 @tailor15 VARCHAR (100)=NULL,
                                                                                 @tailor16 VARCHAR (100)=NULL,
                                                                                 @tailor17 VARCHAR (100)=NULL,
                                                                                 @tailor18 VARCHAR (100)=NULL,
                                                                                 @tailor19 VARCHAR (100)=NULL,
                                                                                 @tailor20 VARCHAR (100)=NULL,
                                                                                 @InvImg VARBINARY(max) =NULL,
                                                                                 @CusVenMob VARCHAR(50) =NULL,
                                                                                 @PriceIncludeTax BIT = NULL,
																				 													 @CInvType INT =NULL,
																	 @Car_ID int =NULL,
	@Car_TypeNameA varchar(50) =NULL,
	@Car_TypeNameE varchar(50) =NULL,
	@Car_NameA varchar(50) =NULL,
	@Car_NameE varchar(50) =NULL,
	@PlateNo varchar(50) =NULL,
	@Color varchar(50) =NULL,
	@ModelNo varchar(50) =NULL,
	@Delevery_Date date =NULL,
	@VehiclechassisNumber Varchar(100) =Null,
	@OrderStatus INT =NULL
                                                                 
                              ,@Branch_Number int =1    )
                                  AS
                                  BEGIN
                                  UPDATE T_INVHED
                                  SET    InvId = @InvId,
                                         InvNo = @InvNo,
                                         InvTyp = @InvTyp,
                                         InvCashPay = @InvCashPay,
                                         CusVenNo = @CusVenNo,
                                         CusVenNm = @CusVenNm,
                                         CusVenAdd = @CusVenAdd,
                                         CusVenTel = @CusVenTel,
                                         Remark = @Remark,
                                         HDat = @HDat,
                                         GDat = @GDat,
                                         MndNo = @MndNo,
                                         SalsManNo = @SalsManNo,
                                         SalsManNam = @SalsManNam,
                                         InvTot = @InvTot,
                                         InvTotLocCur = @InvTotLocCur,
                                         InvDisPrs = @InvDisPrs,
                                         InvDisVal = @InvDisVal,
                                         InvDisValLocCur = @InvDisValLocCur,
                                         InvNet = @InvNet,
                                         InvNetLocCur = @InvNetLocCur,
                                         CashPay = @CashPay,
                                         CashPayLocCur = @CashPayLocCur,
                                         IfRet = @IfRet,
                                         GadeNo = @GadeNo,
                                         GadeId = @GadeId,
                                         IfDel = @IfDel,
                                         RetNo = @RetNo,
                                         RetId = @RetId,
                                         InvCstNo = @InvCstNo,
                                         InvCashPayNm = @InvCashPayNm,
                                         RefNo = @RefNo,
                                         InvCost = @InvCost,
                                         EstDat = @EstDat,
                                         CustPri = @CustPri,
                                         ArbTaf = @ArbTaf,
                                         CurTyp = @CurTyp,
                                         InvCash = @InvCash,
                                         ToStore = @ToStore,
                                         ToStoreNm = @ToStoreNm,
                                         InvQty = @InvQty,
                                         EngTaf = @EngTaf,
                                         IfTrans = @IfTrans,
                                         CustRep = @CustRep,
                                         CustNet = @CustNet,
                                         InvWight_T = @InvWight_T,
                                         IfPrint = @IfPrint,
                                         LTim = @LTim,
                                         MODIFIED_BY = @MODIFIED_BY,
                                         DATE_MODIFIED = @DATE_MODIFIED,
                                                                                 CreditPay = @CreditPay,
                                                                                 CreditPayLocCur = @CreditPayLocCur,
                                                                                 NetworkPay = @NetworkPay,
                                                                                 NetworkPayLocCur = @NetworkPayLocCur,
                                                                                 CommMnd_Inv = @CommMnd_Inv,
                                                                                 MndExtrnal = @MndExtrnal,
                                                                                 CompanyID = @CompanyID,
                                                                                 InvAddCost = @InvAddCost,
                                                                                 InvAddCostLoc = @InvAddCostLoc,
                                                                                 InvAddCostExtrnal = @InvAddCostExtrnal,
                                                                                 InvAddCostExtrnalLoc = @InvAddCostExtrnalLoc,
                                                                                 IsExtrnalGaid = @IsExtrnalGaid,
                                                                                 ExtrnalCostGaidID = @ExtrnalCostGaidID,
                                                                                 Puyaid = @Puyaid,
                                                                                 Remming = @Remming,
                                                                                 RoomNo = @RoomNo,
                                                                                 OrderTyp = @OrderTyp,
                                                                                 RoomSts = @RoomSts,
                                                                                 chauffeurNo = @chauffeurNo,
                                                                                 RoomPerson = @RoomPerson,
                                                                                 ServiceValue = @ServiceValue,
                                                                                 Sts = @Sts,
                                                                                 PaymentOrderTyp = @PaymentOrderTyp,
                                                                                 AdminLock = @AdminLock,
                                                                                 DeleteDate = @DeleteDate,
                                                                                 DeleteTime = @DeleteTime,
                                                                                 UserNew = @UserNew,
                                                                                 IfEnter = @IfEnter,
                                                                                 InvAddTax = @InvAddTax,
                                                                                 InvAddTaxlLoc = @InvAddTaxlLoc,
                                                                                 IsTaxGaid = @IsTaxGaid,
                                                                                 TaxGaidID = @TaxGaidID,
                                                                                 IsTaxUse = @IsTaxUse,
                                                                                 InvValGaidDis = @InvValGaidDis,
                                                                                 InvValGaidDislLoc = @InvValGaidDislLoc,
                                                                                 IsDisGaid = @IsDisGaid,
                                                                                 DisGaidID1 = @DisGaidID1,
                                                                                 IsDisUse1 = @IsDisUse1,
                                                                                 InvComm = @InvComm,
                                                                                 InvCommLoc = @InvCommLoc,
                                                                                 IsCommGaid = @IsCommGaid,
                                                                                 CommGaidID = @CommGaidID,
                                                                                 IsCommUse = @IsCommUse,
                                                                                 IsTaxLines = @IsTaxLines,
                                                                                 IsTaxByTotal = @IsTaxByTotal,
                                                                                 IsTaxByNet = @IsTaxByNet,
                                                                                 TaxByNetValue = @TaxByNetValue,
                                                                                 DesPointsValue = @DesPointsValue ,
																				 DesPointsValueLocCur = @DesPointsValueLocCur ,
																				 PointsCount = @PointsCount,
                                                                                 IsPoints = @IsPoints,
                                                                                 tailor1 = @tailor1 ,
																				 tailor2 = @tailor2,
																				 tailor3 = @tailor3,
																				 tailor4 = @tailor4,
																				 tailor5 = @tailor5,
																				 tailor6 = @tailor6,
																				 tailor7 = @tailor7,
																				 tailor8 = @tailor8,
																				 tailor9 = @tailor9,
																				 tailor10 = @tailor10,
																				 tailor11 = @tailor11,
																				 tailor12 = @tailor12,
																				 tailor13 = @tailor13,
																				 tailor14 = @tailor14,
																				 tailor15 = @tailor15,
																				 tailor16 = @tailor16,
																				 tailor17 = @tailor17,
																				 tailor18 = @tailor18,
																				 tailor19 = @tailor19,
																				 tailor20 = @tailor20,
                                                                                 InvImg   = @InvImg,
                                                                                 CusVenMob = @CusVenMob,
                                                                                 PriceIncludTax =@PriceIncludeTax,
																				 Car_ID=@Car_ID,
																				 Car_TypeNameA=@Car_TypeNameA,
																				 Car_TypeNameE=@Car_TypeNameE,
																				 Car_NameA=@Car_NameA,
																				 Car_NameE=@Car_NameE,
																				 PlateNo=@PlateNo,
																				 color=@Color,
																				 ModelNo=@ModelNo,
																				 Delevery_Date=@Delevery_Date
                                                                                ,VehiclechassisNumber=@VehiclechassisNumber,
																				OrderStatus=@OrderStatus,Branch_Number=@Branch_Number
							 							 WHERE  @InvHed_ID = InvHed_ID
                                  RETURN
                                  END;

GO
/****** Object:  StoredProcedure [dbo].[S_T_INVHED_INSERT]    Script Date: 09/06/2021 11:30:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE[dbo].[S_T_INVHED_INSERT]
        (
                                                                    @InvHed_ID INT OUTPUT,
                                                                    @InvId FLOAT =NULL,
                                                                     @InvNo VARCHAR(10),
                                                                     @InvTyp INT = NULL,
                                                                     @InvCashPay INT =NULL,
                                                                     @CusVenNo VARCHAR(20)=NULL,
                                                                     @CusVenNm VARCHAR(50)=NULL,
                                                                     @CusVenAdd VARCHAR(100)=NULL,
                                                                     @CusVenTel VARCHAR(30)=NULL,
                                                                     @Remark VARCHAR(MAX)=NULL,
                                                                     @HDat VARCHAR(10)=NULL,
                                                                     @GDat VARCHAR(10)=NULL,
                                                                     @MndNo INT = NULL,
                                                                     @SalsManNo VARCHAR(3)=NULL,
                                                                     @SalsManNam VARCHAR(50)=NULL,
                                                                     @InvTot FLOAT = NULL,
                                                                     @InvTotLocCur FLOAT =NULL,
                                                                     @InvDisPrs FLOAT = NULL,
                                                                     @InvDisVal FLOAT =NULL,
                                                                     @InvDisValLocCur FLOAT = NULL,
                                                                     @InvNet FLOAT =NULL,
                                                                     @InvNetLocCur FLOAT = NULL,
                                                                     @CashPay FLOAT =NULL,
                                                                     @CashPayLocCur FLOAT = NULL,
                                                                     @IfRet INT =NULL,
                                                                     @GadeNo FLOAT = NULL,
                                                                     @GadeId FLOAT =NULL,
                                                                     @IfDel INT = NULL,
                                                                     @RetNo VARCHAR(10)=NULL,
                                                                     @RetId FLOAT = NULL,
                                                                     @InvCstNo INT =NULL,
                                                                     @InvCashPayNm VARCHAR(100)=NULL,
                                                                     @RefNo VARCHAR(20)=NULL,
                                                                     @InvCost FLOAT = NULL,
                                                                     @EstDat VARCHAR(10)=NULL,
                                                                     @CustPri INT = NULL,
                                                                     @ArbTaf VARCHAR(150)=NULL,
                                                                     @CurTyp INT = NULL,
                                                                     @InvCash VARCHAR(20)=NULL,
                                                                     @ToStore VARCHAR(3)=NULL,
                                                                     @ToStoreNm VARCHAR(50)=NULL,
                                                                     @InvQty FLOAT = NULL,
                                                                     @EngTaf VARCHAR(150)=NULL,
                                                                     @IfTrans INT = NULL,
                                                                     @CustRep FLOAT =NULL,
                                                                     @CustNet FLOAT = NULL,
                                                                     @InvWight_T FLOAT =NULL,
                                                                     @IfPrint INT = NULL,
                                                                     @LTim VARCHAR(10)=NULL,
                                                                     @CREATED_BY VARCHAR(100) =NULL,
                                                                     @DATE_CREATED datetime = NULL,
                                                                     @MODIFIED_BY VARCHAR(100)=NULL,
                                                                     @DATE_MODIFIED datetime = NULL,
                                                                     @CreditPay float=NULL,
                                                                     @CreditPayLocCur float=NULL,
                                                                     @NetworkPay float=NULL,
                                                                     @NetworkPayLocCur float=NULL,
                                                                     @CommMnd_Inv float=NULL,
                                                                     @MndExtrnal bit = NULL,
                                                                     @CompanyID int=NULL,
                                                                     @InvAddCost float=NULL,
                                                                     @InvAddCostLoc float=NULL,
                                                                     @InvAddCostExtrnal float=NULL,
                                                                     @InvAddCostExtrnalLoc float=NULL,
                                                                     @IsExtrnalGaid bit = NULL,
                                                                     @ExtrnalCostGaidID float=NULL,
                                                                     @Puyaid float=NULL,
                                                                     @Remming float=NULL,
                                                                     @RoomNo int=NULL,
                                                                     @OrderTyp int=NULL,
                                                                     @RoomSts bit = NULL,
                                                                     @chauffeurNo int=NULL,
                                                                     @RoomPerson int=NULL,
                                                                     @ServiceValue float=NULL,
                                                                     @Sts bit = NULL,
                                                                     @PaymentOrderTyp int=NULL,
                                                                     @AdminLock bit = NULL,
                                                                     @DeleteDate VARCHAR(10)=NULL,
                                                                     @DeleteTime VARCHAR(10)=NULL,
                                                                     @UserNew VARCHAR(3)=NULL,
                                                                     @IfEnter int=NULL,
                                                                     @InvAddTax float=NULL,
                                                                     @InvAddTaxlLoc float=NULL,
                                                                     @IsTaxGaid bit = NULL,
                                                                     @TaxGaidID float=NULL,
                                                                     @IsTaxUse bit = NULL,
                                                                     @InvValGaidDis float=NULL,
                                                                     @InvValGaidDislLoc float=NULL,
                                                                     @IsDisGaid bit = NULL,
                                                                     @DisGaidID1 float=NULL,
                                                                     @IsDisUse1 bit = NULL,
                                                                     @InvComm float=NULL,
                                                                     @InvCommLoc float=NULL,
                                                                     @IsCommGaid bit = NULL,
                                                                     @CommGaidID float=NULL,
                                                                     @IsCommUse bit = NULL,
                                                                     @IsTaxLines bit=NULL,
                                                                     @IsTaxByTotal bit = NULL,
                                                                     @IsTaxByNet bit=NULL,
                                                                     @TaxByNetValue float=NULL,
                                                                     @DesPointsValue float=NULL,
                                                                     @DesPointsValueLocCur float=NULL,
                                                                     @PointsCount float=NULL,
                                                                     @IsPoints bit = NULL,
                                                                     @tailor1 VARCHAR(100)=NULL,
                                                                     @tailor2 VARCHAR(100)=NULL,
                                                                     @tailor3 VARCHAR(100)=NULL,
                                                                     @tailor4 VARCHAR(100)=NULL,
                                                                     @tailor5 VARCHAR(100)=NULL,
                                                                     @tailor6 VARCHAR(100)=NULL,
                                                                     @tailor7 VARCHAR(100)=NULL,
                                                                     @tailor8 VARCHAR(100)=NULL,
                                                                     @tailor9 VARCHAR(100)=NULL,
                                                                     @tailor10 VARCHAR(100)=NULL,
                                                                     @tailor11 VARCHAR(100)=NULL,
                                                                     @tailor12 VARCHAR(100)=NULL,
                                                                     @tailor13 VARCHAR(100)=NULL,
                                                                     @tailor14 VARCHAR(100)=NULL,
                                                                     @tailor15 VARCHAR(100)=NULL,
                                                                     @tailor16 VARCHAR(100)=NULL,
                                                                     @tailor17 VARCHAR(100)=NULL,
                                                                     @tailor18 VARCHAR(100)=NULL,
                                                                     @tailor19 VARCHAR(100)=NULL,
                                                                     @tailor20 VARCHAR(100)=NULL,
                                                                     @InvImg[varbinary] (max) =NULL,
                                                                     @CusVenMob VARCHAR(50) =NULL,
                                                                     @PriceIncludeTax BIT = NULL,
																	 @CInvType INT =NULL,
																	 @Car_ID int =NULL,
	@Car_TypeNameA varchar(50) =NULL,
	@Car_TypeNameE varchar(50) =NULL,
	@Car_NameA varchar(50) =NULL,
	@Car_NameE varchar(50) =NULL,
	@PlateNo varchar(50) =NULL,
	@Color varchar(50) =NULL,
	@ModelNo varchar(50) =NULL,
	@Delevery_Date date =NULL,
	@VehiclechassisNumber varchar(100) =NULL,
	@OrderStatus INT =NULL,@Branch_Number INT=1
                                                              )
                                                              AS
                                                              BEGIN
                                                              INSERT INTO T_INVHED(
                                                                     InvId,
                                                                     InvNo,
                                                                     InvTyp,
                                                                     InvCashPay,
                                                                     CusVenNo,
                                                                     CusVenNm,
                                                                     HDat,
                                                                     CusVenAdd,
                                                                     CusVenTel,
                                                                     Remark,
                                                                     GDat,
                                                                     MndNo,
                                                                     SalsManNo,
                                                                     SalsManNam,
                                                                     InvTot,
                                                                     InvTotLocCur,
                                                                     InvDisPrs,
                                                                     InvDisVal,
                                                                     InvDisValLocCur,
                                                                     InvNet,
                                                                     InvNetLocCur,
                                                                     CashPay,
                                                                     CashPayLocCur,
                                                                     IfRet,
                                                                     GadeNo,
                                                                     GadeId,
                                                                     IfDel,
                                                                     RetNo,
                                                                     RetId,
                                                                     InvCstNo,
                                                                     InvCashPayNm,
                                                                     RefNo,
                                                                     InvCost,
                                                                     EstDat,
                                                                     CustPri,
                                                                     ArbTaf,
                                                                     CurTyp,
                                                                     InvCash,
                                                                     ToStore,
                                                                     ToStoreNm,
                                                                     InvQty,
                                                                     EngTaf,
                                                                     IfTrans,
                                                                     CustRep,
                                                                     CustNet,
                                                                     InvWight_T,
                                                                     IfPrint,
                                                                     LTim,
                                                                     CREATED_BY,
                                                                     DATE_CREATED,
                                                                     MODIFIED_BY ,
                                                                     DATE_MODIFIED ,
                                                                     CreditPay ,
                                                                     CreditPayLocCur ,
                                                                     NetworkPay ,
                                                                     NetworkPayLocCur ,
                                                                     CommMnd_Inv ,
                                                                     MndExtrnal ,
                                                                     CompanyID ,
                                                                     InvAddCost ,
                                                                     InvAddCostLoc ,
                                                                     InvAddCostExtrnal ,
                                                                     InvAddCostExtrnalLoc ,
                                                                     IsExtrnalGaid ,
                                                                     ExtrnalCostGaidID ,
                                                                     Puyaid ,
                                                                     Remming ,
                                                                     RoomNo ,
                                                                     OrderTyp ,
                                                                     RoomSts ,
                                                                     chauffeurNo ,
                                                                     RoomPerson ,
                                                                     ServiceValue ,
                                                                     Sts ,
                                                                     PaymentOrderTyp ,
                                                                     AdminLock ,
                                                                     DeleteDate ,
                                                                     DeleteTime ,
                                                                     UserNew ,
                                                                     IfEnter ,
                                                                     InvAddTax ,
                                                                     InvAddTaxlLoc ,
                                                                     IsTaxGaid ,
                                                                     TaxGaidID ,
                                                                     IsTaxUse ,
                                                                     InvValGaidDis ,
                                                                     InvValGaidDislLoc ,
                                                                     IsDisGaid ,
                                                                     DisGaidID1 ,
                                                                     IsDisUse1 ,
                                                                     InvComm ,
                                                                     InvCommLoc ,
                                                                     IsCommGaid ,
                                                                     CommGaidID ,
                                                                     IsCommUse ,
                                                                     IsTaxLines ,
                                                                     IsTaxByTotal ,
                                                                     IsTaxByNet ,
                                                                     TaxByNetValue ,
                                                                     DesPointsValue ,
                                                                     DesPointsValueLocCur ,
                                                                     PointsCount,
                                                                     IsPoints,
                                                                     tailor1 ,
                                                                     tailor2 ,
                                                                     tailor3 ,
                                                                     tailor4 ,
                                                                     tailor5 ,
                                                                     tailor6 ,
                                                                     tailor7 ,
                                                                     tailor8 ,
                                                                     tailor9 ,
                                                                     tailor10 ,
                                                                     tailor11 ,
                                                                     tailor12 ,
                                                                     tailor13 ,
                                                                     tailor14 ,
                                                                     tailor15 ,
                                                                     tailor16 ,
                                                                     tailor17 ,
                                                                     tailor18 ,
                                                                     tailor19 ,
                                                                     tailor20,
                                                                     InvImg,
                                                                     CusVenMob,
                                                                     PriceIncludTax,
																	 CInvType,
																	 Car_ID,
																	 Car_TypeNameA,
																	 Car_TypeNameE,
																	 Car_NameA,
																	 Car_NameE,
																	 PlateNo,
																	 Color,
																	 ModelNo,
																	 Delevery_Date
																	 ,VehiclechassisNumber,
																	 OrderStatus,Branch_Number
                                                              )
                                                              VALUES
                                                              (
                                                                    @InvId,
                                                                    @InvNo,
                                                                    @InvTyp,
                                                                    @InvCashPay,
                                                                    @CusVenNo,
                                                                    @CusVenNm,
                                                                    @HDat,
                                                                    @CusVenAdd,
                                                                    @CusVenTel,
                                                                    @Remark,
                                                                    @GDat,
                                                                    @MndNo,
                                                                    @SalsManNo,
                                                                    @SalsManNam,
                                                                    @InvTot,
                                                                    @InvTotLocCur,
                                                                    @InvDisPrs,
                                                                    @InvDisVal,
                                                                    @InvDisValLocCur,
                                                                    @InvNet,
                                                                    @InvNetLocCur,
                                                                    @CashPay,
                                                                    @CashPayLocCur,
                                                                    @IfRet,
                                                                    @GadeNo,
                                                                    @GadeId,
                                                                    @IfDel,
                                                                    @RetNo,
                                                                    @RetId,
                                                                    @InvCstNo,
                                                                    @InvCashPayNm,
                                                                    @RefNo,
                                                                    @InvCost,
                                                                    @EstDat,
                                                                    @CustPri,
                                                                    @ArbTaf,
                                                                    @CurTyp,
                                                                    @InvCash,
                                                                    @ToStore,
                                                                    @ToStoreNm,
                                                                    @InvQty,
                                                                    @EngTaf,
                                                                    @IfTrans,
                                                                    @CustRep,
                                                                    @CustNet,
                                                                    @InvWight_T,
                                                                    @IfPrint,
                                                                    @LTim,
                                                                    @CREATED_BY,
                                                                    @DATE_CREATED,
                                                                    @MODIFIED_BY ,
                                                                    @DATE_MODIFIED ,
                                                                    @CreditPay ,
                                                                    @CreditPayLocCur ,
                                                                    @NetworkPay ,
                                                                    @NetworkPayLocCur ,
                                                                    @CommMnd_Inv ,
                                                                    @MndExtrnal ,
                                                                    @CompanyID ,
                                                                    @InvAddCost ,
                                                                    @InvAddCostLoc ,
                                                                    @InvAddCostExtrnal ,
                                                                    @InvAddCostExtrnalLoc ,
                                                                    @IsExtrnalGaid ,
                                                                    @ExtrnalCostGaidID ,
                                                                    @Puyaid ,
                                                                    @Remming ,
                                                                    @RoomNo ,
                                                                    @OrderTyp ,
                                                                    @RoomSts ,
                                                                    @chauffeurNo ,
                                                                    @RoomPerson ,
                                                                    @ServiceValue ,
                                                                    @Sts ,
                                                                    @PaymentOrderTyp ,
                                                                    @AdminLock ,
                                                                    @DeleteDate ,
                                                                    @DeleteTime ,
                                                                    @UserNew ,
                                                                    @IfEnter ,
                                                                    @InvAddTax ,
                                                                    @InvAddTaxlLoc ,
                                                                    @IsTaxGaid ,
                                                                    @TaxGaidID ,
                                                                    @IsTaxUse ,
                                                                    @InvValGaidDis ,
                                                                    @InvValGaidDislLoc ,
                                                                    @IsDisGaid ,
                                                                    @DisGaidID1 ,
                                                                    @IsDisUse1 ,
                                                                    @InvComm ,
                                                                    @InvCommLoc ,
                                                                    @IsCommGaid ,
                                                                    @CommGaidID ,
                                                                    @IsCommUse ,
                                                                    @IsTaxLines ,
                                                                    @IsTaxByTotal ,
                                                                    @IsTaxByNet ,
                                                                    @TaxByNetValue ,
                                                                    @DesPointsValue ,
                                                                    @DesPointsValueLocCur ,
                                                                    @PointsCount,
                                                                    @IsPoints,
                                                                    @tailor1 ,
                                                                    @tailor2 ,
                                                                    @tailor3 ,
                                                                    @tailor4 ,
                                                                    @tailor5 ,
                                                                    @tailor6 ,
                                                                    @tailor7 ,
                                                                    @tailor8 ,
                                                                    @tailor9 ,
                                                                    @tailor10 ,
                                                                    @tailor11 ,
                                                                    @tailor12 ,
                                                                    @tailor13 ,
                                                                    @tailor14 ,
                                                                    @tailor15 ,
                                                                    @tailor16 ,
                                                                    @tailor17 ,
                                                                    @tailor18 ,
                                                                    @tailor19 ,
                                                                    @tailor20,
                                                                    @InvImg,
                                                                    @CusVenMob,
                                                                    @PriceIncludeTax,
																	@CInvType,
																	@Car_ID,
																	@Car_TypeNameA,
																	@Car_TypeNameE,
																	@Car_NameA,
																	@Car_NameE,
																	@PlateNo,
																	@Color,
																@ModelNo,
																@Delevery_Date,
																@VehiclechassisNumber,
																@OrderStatus,@Branch_Number
                                                              )
                                                              SELECT @InvHed_ID = SCOPE_IDENTITY()
                                                              RETURN 
                                                              END; 


GO
/****** Object:  StoredProcedure [dbo].[S_T_INVDET_INSERT]    Script Date: 09/06/2021 11:24:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[S_T_INVDET_INSERT](   
                                                                 @InvDet_ID INT OUTPUT,
                                                                 @InvNo VARCHAR (10)=NULL,
                                                                 @InvId INT =NULL,
                                                                 @InvSer INT =NULL,
                                                                 @ItmNo VARCHAR (50)=NULL,
                                                                 @Cost FLOAT =NULL,
                                                                 @Qty FLOAT =NULL,
                                                                 @ItmDes VARCHAR (50)=NULL,
                                                                 @ItmUnt VARCHAR (100)=NULL,
                                                                 @ItmDesE VARCHAR (50)=NULL,
                                                                 @ItmUntE VARCHAR (100)=NULL,
                                                                 @ItmUntPak FLOAT =NULL,
                                                                 @StoreNo INT=NULL,
                                                                 @Price FLOAT =NULL,
                                                                 @Amount FLOAT =NULL,
                                                                 @RealQty FLOAT =NULL,
                                                                 @itmInvDsc FLOAT =NULL,
                                                                 @DatExper VARCHAR (11)=NULL,
                                                                 @ItmDis FLOAT =NULL,
                                                                 @ItmTyp INT =NULL,
                                                                 @ItmIndex INT =NULL,
                                                                 @ItmWight FLOAT =NULL,
                                                                 @ItmWight_T FLOAT =NULL,
                                                                 @ItmAddCost FLOAT =NULL,
                                                                 @RunCod VARCHAR (100)=NULL,
                                                                 @LineDetails VARCHAR (250)=NULL,
                                                                 @Serial_Key VARCHAR (100)=NULL,
                                                                 @ItmTax FLOAT =NULL,
                                                                 @OfferTyp INT =NULL,
																 @CInvType INT =NULL,
@CaExState INT =0
                                                   , @Branch_Number INT=1       )
                                                          AS
                                                          BEGIN
                                                          INSERT INTO T_INVDET(
                                                                 InvNo,
                                                                 InvId,
                                                                 InvSer,
                                                                 ItmNo,
                                                                 Cost,
                                                                 Qty,
                                                                 ItmDes,
                                                                 ItmUnt,
                                                                 ItmDesE,
                                                                 ItmUntE,
                                                                 ItmUntPak,
                                                                 StoreNo,
                                                                 Price,
                                                                 Amount,
                                                                 RealQty,
                                                                 itmInvDsc,
                                                                 DatExper,
                                                                 ItmDis,
                                                                 ItmTyp,
                                                                 ItmIndex,
                                                                 ItmWight,
                                                                 ItmWight_T,
                                                                 ItmAddCost,
                                                                 RunCod,
                                                                 LineDetails,
                                                                 Serial_Key,
                                                                 ItmTax,
                                                                OfferTyp ,
																CInvType,
CaExState
                                                   ,Branch_Number       )
                                                          VALUES
                                                          (
                                                                 
                                                                @InvNo,
                                                                @InvId,
                                                                @InvSer,
                                                                @ItmNo,
                                                                @Cost,
                                                                @Qty,
                                                                @ItmDes,
                                                                @ItmUnt,
                                                                @ItmDesE,
                                                                @ItmUntE,
                                                                @ItmUntPak,
                                                                @StoreNo,
                                                                @Price,
                                                                @Amount,
                                                                @RealQty,
                                                                @itmInvDsc,
                                                                @DatExper,
                                                                @ItmDis,
                                                                @ItmTyp,
                                                                @ItmIndex,
                                                                @ItmWight,
                                                                @ItmWight_T,
                                                                @ItmAddCost,
                                                                @RunCod,
                                                                @LineDetails,
                                                                @Serial_Key,
                                                                @ItmTax,
                                                                @OfferTyp,
																@CInvType
,@CaExState
                                                 ,@Branch_Number         )
                                                          SELECT @InvDet_ID = SCOPE_IDENTITY()
                                                            declare @ItemCount int  
                                                            declare @InvTyp int
                                                            declare @MndID int
                                                            declare @CusVenNo varchar(30)
                                                            declare @ItemCountMnd int 
                                                            declare @ItemCountCust int 
		                                                    select @ItemCount = Count(*) from T_STKSQTY where itmNo = @ItmNo and storeNo =@StoreNo and Branch_Number=@Branch_Number;
                                                            select @InvTyp = InvTyp from T_INVHED where InvHed_ID = @InvId and Branch_Number=@Branch_Number;
                                                            if((@InvTyp !=-101
AND @InvTyp != 7 and @InvTyp != 8 and @InvTyp != 9 and @InvTyp != 21) and @ItmTyp <> 3)
                                                            begin
			                                                          if(@ItmTyp <> 2)
			                                                          begin
		                                                                    Update T_Items SET OpenQty = OpenQty+@RealQty WHERE Itm_No = @ItmNo and Branch_Number=@Branch_Number;
			                                                                if(@ItemCount > 0)
			                                                                begin
			                                                                Update T_STKSQTY SET stkQty = stkQty+@RealQty WHERE itmNo = @ItmNo and storeNo = @StoreNo and Branch_Number=@Branch_Number;
			                                                                end
			                                                                if(@ItemCount = 0)
			                                                                begin 
			                                                                INSERT INTO T_STKSQTY(itmNo,storeNo,stkQty,stkInt,Branch_Number) VALUES(@ItmNo,@StoreNo,@RealQty,0,@Branch_Number);
			                                                                END
                                                                            if(@InvTyp = 14)
                                                                            begin
				                                                                Update T_STKSQTY SET stkInt = stkInt+@RealQty WHERE itmNo = @ItmNo and storeNo = @StoreNo and Branch_Number=@Branch_Number;
                                                                            end
			                                                                select @ItemCount = Count(*) from T_QTYEXP where itmNo = @ItmNo and storeNo =@StoreNo and (DatExper = @DatExper and RunCod = @RunCod)  and Branch_Number=@Branch_Number;
			                                                                if(@ItemCount > 0 and (@DatExper <> '' or @RunCod <> ''))
			                                                                begin
			                                                                Update T_QTYEXP SET stkQty = stkQty+@RealQty WHERE itmNo = @ItmNo and storeNo = @StoreNo and (DatExper = @DatExper and RunCod = @RunCod)and Branch_Number=@Branch_Number;
			                                                                end
			                                                                if(@ItemCount = 0 and (@DatExper <> '' or @RunCod <> ''))
			                                                                begin 
			                                                                INSERT INTO T_QTYEXP(itmNo,storeNo,DatExper,stkQty,RunCod,Branch_Number) VALUES(@ItmNo,@StoreNo,@DatExper,@RealQty,@RunCod,@Branch_Number);
			                                                                END
                                                                END
			                                                          if(@InvTyp = 17)
				                                                          begin
														                       select @MndID = MndNo from T_INVHED where InvHed_ID = @InvId and Branch_Number=@Branch_Number;
														                       select @CusVenNo = CusVenNo from T_INVHED where InvHed_ID = @InvId and Branch_Number=@Branch_Number;
														                       if(@MndID > 0 )
															                    begin
															                              select @ItemCountMnd = Count(*) from T_StoreMnd where itmNo = @ItmNo and storeNo =@StoreNo and MndNo = @MndID and Branch_Number=@Branch_Number;
																	                      if(@ItemCountMnd > 0)
																	                      begin
																		                       Update T_StoreMnd SET stkQty = stkQty + abs(@RealQty) WHERE itmNo = @ItmNo and storeNo = @StoreNo and MndNo = @MndID and Branch_Number=@Branch_Number;
																	                      end
																	                      if(@ItemCountMnd = 0)
																	                      begin 
																		                       INSERT INTO T_StoreMnd(itmNo,storeNo,stkQty,stkInt,MndNo,Branch_Number) VALUES(@ItmNo,@StoreNo,abs(@RealQty),0,@MndID,@Branch_Number);
																	                      END
															                    END
														                      else
									                                            begin
															                             select @ItemCountCust = Count(*) from T_StoreMnd where itmNo = @ItmNo and storeNo =@StoreNo and CusVenNo = @CusVenNo and Branch_Number=@Branch_Number;
																	                      if(@ItemCountCust > 0)
																	                      begin
																		                       Update T_StoreMnd SET stkQty = stkQty + abs(@RealQty) WHERE itmNo = @ItmNo and storeNo = @StoreNo and CusVenNo = @CusVenNo and Branch_Number=@Branch_Number;
																	                      end
																	                      if(@ItemCountCust = 0)
																	                      begin 
																		                       INSERT INTO T_StoreMnd(itmNo,storeNo,stkQty,stkInt,CusVenNo,Branch_Number) VALUES(@ItmNo,@StoreNo,abs(@RealQty),0,@CusVenNo ,@Branch_Number);
																	                      END
															                    END
				                                                          END	
			                                                          if(@InvTyp = 20)
				                                                          begin
				                                                              select @MndID = MndNo from T_INVHED where InvHed_ID = @InvId and Branch_Number=@Branch_Number;
														                      select @CusVenNo = CusVenNo from T_INVHED where InvHed_ID = @InvId and Branch_Number=@Branch_Number;
														                        if(@MndID > 0 )
																                    begin
																	                     select @ItemCountMnd = Count(*) from T_StoreMnd where itmNo = @ItmNo and storeNo =@StoreNo and MndNo = @MndID and Branch_Number=@Branch_Number;
																	                      if(@ItemCountMnd > 0)
																	                      begin
																		                       Update T_StoreMnd SET stkQty = stkQty + (-@RealQty) WHERE itmNo = @ItmNo and storeNo = @StoreNo and MndNo = @MndID and Branch_Number=@Branch_Number;
																	                      end
																	                      if(@ItemCountMnd = 0)
																	                      begin 
																		                       INSERT INTO T_StoreMnd(itmNo,storeNo,stkQty,stkInt,MndNo,Branch_Number) VALUES(@ItmNo,@StoreNo,-@RealQty,0,@MndID,@Branch_Number);
																	                      END
																                     END
							                                                     else
							                                                         begin
																	                     select @ItemCountCust = Count(*) from T_StoreMnd where itmNo = @ItmNo and storeNo =@StoreNo and CusVenNo = @CusVenNo and Branch_Number=@Branch_Number;
																	                      if(@ItemCountCust > 0)
																	                      begin
																		                       Update T_StoreMnd SET stkQty = stkQty + (-@RealQty) WHERE itmNo = @ItmNo and storeNo = @StoreNo and CusVenNo = @CusVenNo and Branch_Number=@Branch_Number;
																	                      end
																	                      if(@ItemCountCust = 0)
																	                      begin 
																		                       INSERT INTO T_StoreMnd(itmNo,storeNo,stkQty,stkInt,CusVenNo,Branch_Number) VALUES(@ItmNo,@StoreNo,-@RealQty,0,@CusVenNo,@Branch_Number);
																	                      END
																                     END
				                                                          end
                                                            end
                                                          RETURN @InvDet_ID
                                                          END

GO
/****** Object:  StoredProcedure [dbo].[S_T_INVDET_DELETE]    Script Date: 09/06/2021 11:20:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  ALTER PROCEDURE [dbo].[S_T_INVDET_DELETE](
                                                      @InvDet_ID INT 
                                          ,@Branch_Number INT =1)
                                          AS
                                          BEGIN
                                        declare @InvTyp int 
                                        declare @InvId int
                                        declare @MndID int
                                        declare @CusVenNo varchar(30)
                                        declare @PaymentOrderTyp int
                                        declare @ItemCountMnd int 
                                        declare @MndKind int 
                                         
                                        select @InvId = InvId from T_INVDET where InvDet_ID = @InvDet_ID and Branch_Number=@Branch_Number;
                                        select @InvTyp = InvTyp from T_INVHED where InvHed_ID = @InvId and Branch_Number=@Branch_Number;
                                        select @MndID = MndNo from T_INVHED where InvHed_ID = @InvId and Branch_Number=@Branch_Number;
                                        
                                        select @PaymentOrderTyp = PaymentOrderTyp from T_INVHED where InvHed_ID = @InvId and Branch_Number=@Branch_Number;
                                        select @CusVenNo = CusVenNo from T_INVHED where InvHed_ID = @InvId and Branch_Number=@Branch_Number;
                                        
                                        select @MndKind = Mnd_Typ from T_Mndob where Mnd_ID = @MndID and Branch_Number=@Branch_Number;
                                        
                                        if(@InvTyp != 7 and @InvTyp != 8 and @InvTyp != 9 and @InvTyp != 21)
                                        begin
                                             if((@PaymentOrderTyp <= 0 or @PaymentOrderTyp is null) or  ((@PaymentOrderTyp = 1 or @PaymentOrderTyp = 2) and (@InvTyp = 17 or @InvTyp = 20) ))
		                                      begin
			                                      UPDATE T_Items SET T_Items.OpenQty = T_Items.OpenQty - T_INVDET.RealQty 
			                                      From T_INVDET Left Join T_Items ON (T_INVDET.ItmNo = T_Items.Itm_No) 
			                                      where (InvDet_ID = @InvDet_ID) and (T_INVDET.ItmTyp <> 3) and (T_INVDET.ItmTyp <> 2) and T_INVDET.Branch_Number=@Branch_Number;
			                                      UPDATE T_STKSQTY SET T_STKSQTY.stkQty = T_STKSQTY.stkQty - T_INVDET.RealQty 
			                                      From T_INVDET Left Join T_STKSQTY ON (T_INVDET.ItmNo = T_STKSQTY.itmNo) AND (T_INVDET.StoreNo = T_STKSQTY.storeNo)  
			                                      where @InvDet_ID = InvDet_ID and T_INVDET.ItmTyp <> 3 and (T_INVDET.ItmTyp <> 2)and T_INVDET.Branch_Number=@Branch_Number;
                                    			  
			                                      UPDATE T_QTYEXP SET T_QTYEXP.stkQty = T_QTYEXP.stkQty - T_INVDET.RealQty 
			                                      From  T_INVDET Left Join T_QTYEXP ON (T_INVDET.ItmNo = T_QTYEXP.itmNo) AND (T_INVDET.StoreNo = T_QTYEXP.storeNo) AND (T_INVDET.DatExper = T_QTYEXP.DatExper and T_INVDET.RunCod = T_QTYEXP.RunCod )
			                                      where @InvDet_ID = InvDet_ID and T_INVDET.ItmTyp <> 3 and (T_INVDET.ItmTyp <> 2) and T_INVDET.Branch_Number=@Branch_Number;
                                             end
                                             if(@InvTyp = 14)
		                                      begin
			                                      UPDATE T_STKSQTY SET T_STKSQTY.stkInt = T_STKSQTY.stkInt - T_INVDET.RealQty 
			                                      From T_INVDET Left Join T_STKSQTY ON (T_INVDET.ItmNo = T_STKSQTY.itmNo) AND (T_INVDET.StoreNo = T_STKSQTY.storeNo)  
			                                      where @InvDet_ID = InvDet_ID and T_INVDET.ItmTyp <> 3 and (T_INVDET.ItmTyp <> 2)and T_INVDET.Branch_Number=@Branch_Number;
		                                      end
                                         if(@InvTyp = 17)
	                                     begin
                                    				  
													  select @MndID = MndNo from T_INVHED where InvHed_ID = @InvId and Branch_Number=@Branch_Number;
													  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty - abs(T_INVDET.RealQty)
													  From T_INVDET Left Join T_StoreMnd ON (T_INVDET.ItmNo = T_StoreMnd.itmNo) AND (T_INVDET.StoreNo = T_StoreMnd.storeNo)  
													  where @InvDet_ID = InvDet_ID and T_INVDET.ItmTyp <> 3 and T_StoreMnd.MndNo = @MndID and T_INVDET.Branch_Number=@Branch_Number ;
				                                      
													  select @CusVenNo = CusVenNo from T_INVHED where InvHed_ID = @InvId and Branch_Number=@Branch_Number;
													  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty - abs(T_INVDET.RealQty)
													  From T_INVDET Left Join T_StoreMnd ON (T_INVDET.ItmNo = T_StoreMnd.itmNo) AND (T_INVDET.StoreNo = T_StoreMnd.storeNo)  
													  where @InvDet_ID = InvDet_ID and T_INVDET.ItmTyp <> 3 and T_StoreMnd.CusVenNo = @CusVenNo  and T_INVDET.Branch_Number=@Branch_Number;
                                         end
                                         
                                         if(@InvTyp = 20)
	                                     begin
                                    				   
														  select @MndID = MndNo from T_INVHED where InvHed_ID = @InvId and Branch_Number=@Branch_Number;
														  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty + T_INVDET.RealQty 
														  From T_INVDET Left Join T_StoreMnd ON (T_INVDET.ItmNo = T_StoreMnd.itmNo) AND (T_INVDET.StoreNo = T_StoreMnd.storeNo)  
														  where @InvDet_ID = InvDet_ID and T_INVDET.ItmTyp <> 3 and T_StoreMnd.MndNo = @MndID and T_INVDET.Branch_Number=@Branch_Number ;
					                                      
														  select @CusVenNo = CusVenNo from T_INVHED where InvHed_ID = @InvId and Branch_Number=@Branch_Number;
														  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty + T_INVDET.RealQty 
														  From T_INVDET Left Join T_StoreMnd ON (T_INVDET.ItmNo = T_StoreMnd.itmNo) AND (T_INVDET.StoreNo = T_StoreMnd.storeNo)  
														  where @InvDet_ID = InvDet_ID and T_INVDET.ItmTyp <> 3 and T_StoreMnd.CusVenNo = @CusVenNo  and T_INVDET.Branch_Number=@Branch_Number;
                                         end
                                        end
                                         
                                          DELETE FROM T_INVDET
                                          WHERE      @InvDet_ID = InvDet_ID    
                                          RETURN
                                          END

GO
/****** Object:  StoredProcedure [dbo].[S_T_GDHEAD_DELETE]    Script Date: 09/06/2021 11:19:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  ALTER PROCEDURE [dbo].[S_T_GDHEAD_DELETE](
                                          @gdhead_ID INT 
                                          ,@Branch_Number INT =1)
                                          AS
                                          BEGIN
                                          
                                          UPDATE T_GDHEAD SET T_GDHEAD.gdLok = 'True',T_GDHEAD.gdTp = null,T_GDHEAD.gdRcptID = null 
                                          From T_GDHEAD
                                          where @gdhead_ID = gdhead_ID and @Branch_Number=Branch_Number
                                          
                                          RETURN
                                          END

GO
/****** Object:  StoredProcedure [dbo].[S_T_GDDET_INSERT]    Script Date: 09/06/2021 11:15:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  ALTER PROCEDURE [dbo].[S_T_GDDET_INSERT](   
                                                 @GDDET_ID INT OUTPUT,
                                                 @gdID INT =NULL,
                                                 @gdNo VARCHAR (10)=NULL,
                                                 @gdDes VARCHAR (100)=NULL,
                                                 @gdDesE VARCHAR (100)=NULL,
                                                 @recptTyp VARCHAR (20)=NULL,
                                                 @AccNo VARCHAR (30)=NULL,
                                                 @AccName VARCHAR (50)=NULL,
                                                 @gdValue FLOAT =NULL,
                                                 @recptNo VARCHAR (20)=NULL,
                                                 @Lin INT =NULL,
                                                 @AccNoDestruction VARCHAR (30)=NULL,
												 @Branch_Number INT =1
                                                 
                                          )
                                          AS
                                          BEGIN
                                          INSERT INTO T_GDDET(
                                                 gdID,
                                                 gdNo,
                                                 gdDes,
                                                 gdDesE,
                                                 recptTyp,
                                                 AccNo,
                                                 AccName,
                                                 gdValue,
                                                 recptNo,
                                                 Lin,
                                                 AccNoDestruction,Branch_Number
                                          )
                                          VALUES
                                          (
                                                 
                                                @gdID,
                                                @gdNo,
                                                @gdDes,
                                                @gdDesE,
                                                @recptTyp,
                                                @AccNo,
                                                @AccName,
                                                @gdValue,
                                                @recptNo,
                                                @Lin,
                                                @AccNoDestruction,@Branch_Number
                                          )
                                          SELECT @GDDET_ID = SCOPE_IDENTITY()
                                          UPDATE T_AccDef SET T_AccDef.Debit = T_AccDef.Debit + ROUND( T_GDDET.gdValue, case when Substring((select MAX(T_SYSSETTING.Seting) from T_SYSSETTING),49,1) = 0 then 2 else 3 end)
                                          From T_AccDef Left Join T_GDDET ON (T_AccDef.AccDef_No = T_GDDET.AccNo and T_AccDef.Branch_Number=T_GDDET.Branch_Number) 
                                          where @GDDET_ID = GDDET_ID and  T_GDDET.gdValue > 0 
                                          UPDATE T_AccDef SET T_AccDef.Credit = T_AccDef.Credit + ABS(ROUND( T_GDDET.gdValue, case when Substring((select MAX(T_SYSSETTING.Seting) from T_SYSSETTING),49,1) = 0 then 2 else 3 end))
                                          From T_AccDef Left Join T_GDDET ON (T_AccDef.AccDef_No = T_GDDET.AccNo and T_AccDef.Branch_Number=T_GDDET.Branch_Number) 
                                          where @GDDET_ID = GDDET_ID and  T_GDDET.gdValue < 0 ;
                                          UPDATE T_AccDef SET T_AccDef.Balance = T_AccDef.Debit - T_AccDef.Credit
                                          From T_AccDef Left Join T_GDDET ON (T_AccDef.AccDef_No = T_GDDET.AccNo and T_AccDef.Branch_Number=T_GDDET.Branch_Number) 
                                          where @GDDET_ID = GDDET_ID ;
                                          RETURN
                                          END
/****** Object:  StoredProcedure [dbo].[UpdateBalance]    Script Date: 09/06/2021 11:39:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[UpdateBalance]
	-- Add the parameters for the stored procedure here
	@NewCredit decimal,
	@NewDebit decimal,
	@AccountNumber VARCHAR(50),@Branch_Number INT =1
AS
BEGIN
	DECLARE @Amount1 decimal, @Amount2 decimal, @Amount3 decimal;

select @Amount1 = Debit, @Amount2 = Credit, @Amount3 = Balance from T_AccDef where AccDef_No = @AccountNumber and Branch_Number=@Branch_Number;

update T_AccDef SET Credit = Credit+@NewCredit, 
					Debit = Debit + @NewDebit,
					Balance = Balance+@NewCredit-@NewDebit
				WHERE AccDef_No = @AccountNumber and Branch_Number=@Branch_Number;;

END



GO
/****** Object:  StoredProcedure [dbo].[S_T_GDDET_DELETE]    Script Date: 09/06/2021 11:15:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[S_T_GDDET_DELETE](
                  @GDDET_ID INT ,@Branch_Number INT =1
      )
      AS
      BEGIN
     
      --UPDATE T_AccDef SET T_AccDef.Debit = T_AccDef.Debit - T_GDDET.gdValue
      --From T_AccDef Left Join T_GDDET ON (T_AccDef.AccDef_No = T_GDDET.AccNo) 
      --where @GDDET_ID = GDDET_ID and  T_GDDET.gdValue > 0 ;

      --UPDATE T_AccDef SET T_AccDef.Credit = T_AccDef.Credit - ABS(T_GDDET.gdValue)
      --From T_AccDef Left Join T_GDDET ON (T_AccDef.AccDef_No = T_GDDET.AccNo) 
      --where @GDDET_ID = GDDET_ID and  T_GDDET.gdValue < 0 ;

      --UPDATE T_AccDef SET T_AccDef.Balance = T_AccDef.Debit - T_AccDef.Credit 
      --From T_AccDef Left Join T_GDDET ON (T_AccDef.AccDef_No = T_GDDET.AccNo) 
      --where @GDDET_ID = GDDET_ID ;

      DELETE FROM T_GDDET
      WHERE      @GDDET_ID = GDDET_ID and Branch_Number =@Branch_Number

      RETURN
      END





";
        public DbUpdates()
        {
            scripts = new List<string>();
            scripts.Add(s3);
            scripts.Add(Addimagecat);
            scripts.Add(update001);
            scripts.Add(Uptate3);
            scripts.Add(hashadd);
            scripts.Add(addbuyer);
            scripts.Add(addsellerer);
            draftbillup = draftbillup.Replace("101", VarGeneral.DraftBillId.ToString());
            s3 = S_T_INVDET_INSERT_ALTER_DRAFT;
            s10 = S_T_INVHED_INSERT_DRAFT;

            scripts.Add(Uptate4);
            scripts.Add(Uptate5);
            scripts.Add(colortable);
            //     scripts.Add(colorstableUpdate);
            scripts.Add(addscolor);
            scripts.Add(pinestable);

            scripts.Add(ITmes_update);
            scripts.Add(s1);
            scripts.Add(s2);
            scripts.Add(CreateCarCheckTable);
            scripts.Add(s3);
            scripts.Add(s4)
           ;
            scripts.Add(s5);
            scripts.Add(s6);
            scripts.Add(s7);
            scripts.Add(s8);
            scripts.Add(s9);
            scripts.Add(s10);
      
            //   if(Program.iscarversion())
            {
                scripts.Add(addstatusoforder);
                scripts.Add(CarNames);

                scripts.Add(addcheseNumber);
                scripts.Add(invalter);
                scripts.Add(invinsertcars);
                invupdatecars = carupdateinsert;
                scripts.Add(invupdatecars);

                scripts.Add(MessagTemplates);
                scripts.Add(ExecutionTable);
                scripts.Add(s3);
                scripts.Add(altinvdet);
            }

        }
        public static void  insertexecution(int inv_Id,int ity)
        { Stock_DataDataContext db = new Stock_DataDataContext(VarGeneral.BranchCS);
            List<T_INVDET> Quary =
                   ( from er in db.T_INVDETs
              where er.InvDet_ID==inv_Id&& er.CInvType==ity
                    select er).ToList<T_INVDET>();
  
            foreach(T_INVDET i in Quary )
            {
               
                
              

            }


        }
        public static string carupdateinsert = @"ALTER PROCEDURE [dbo].[S_T_INVHED_UPDATE](
                                                                                 @InvHed_ID INT ,
                                                                                 @InvId FLOAT =NULL,
                                                                                 @InvNo VARCHAR (10),
                                                                                 @InvTyp INT =NULL,
                                                                                 @InvCashPay INT =NULL,
                                                                                 @CusVenNo VARCHAR (20)=NULL,
                                                                                 @CusVenNm VARCHAR (50)=NULL,
                                                                                 @CusVenAdd VARCHAR (100)=NULL,
                                                                                 @CusVenTel VARCHAR (30)=NULL,
                                                                                 @Remark VARCHAR (MAX)=NULL,
                                                                                 @HDat VARCHAR (10)=NULL,
                                                                                 @GDat VARCHAR (10)=NULL,
                                                                                 @MndNo INT =NULL,
                                                                                 @SalsManNo VARCHAR (3)=NULL,
                                                                                 @SalsManNam VARCHAR (50)=NULL,
                                                                                 @InvTot FLOAT =NULL,
                                                                                 @InvTotLocCur FLOAT =NULL,
                                                                                 @InvDisPrs FLOAT =NULL,
                                                                                 @InvDisVal FLOAT =NULL,
                                                                                 @InvDisValLocCur FLOAT =NULL,
                                                                                 @InvNet FLOAT =NULL,
                                                                                 @InvNetLocCur FLOAT =NULL,
                                                                                 @CashPay FLOAT =NULL,
                                                                                 @CashPayLocCur FLOAT =NULL,
                                                                                 @IfRet INT =NULL,
                                                                                 @GadeNo FLOAT =NULL,
                                                                                 @GadeId FLOAT =NULL,
                                                                                 @IfDel INT =NULL,
                                                                                 @RetNo VARCHAR (10)=NULL,
                                                                                 @RetId FLOAT =NULL,
                                                                                 @InvCstNo INT =NULL,
                                                                                 @InvCashPayNm VARCHAR (100)=NULL,
                                                                                 @RefNo VARCHAR (20)=NULL,
                                                                                 @InvCost FLOAT =NULL,
                                                                                 @EstDat VARCHAR (10)=NULL,
                                                                                 @CustPri INT =NULL,
                                                                                 @ArbTaf VARCHAR (150)=NULL,
                                                                                 @CurTyp INT =NULL,
                                                                                 @InvCash VARCHAR (20)=NULL,
                                                                                 @ToStore VARCHAR (3)=NULL,
                                                                                 @ToStoreNm VARCHAR (50)=NULL,
                                                                                 @InvQty FLOAT =NULL,
                                                                                 @EngTaf VARCHAR (150)=NULL,
                                                                                 @IfTrans INT =NULL,
                                                                                 @CustRep FLOAT =NULL,
                                                                                 @CustNet FLOAT =NULL,
                                                                                 @InvWight_T FLOAT =NULL,
                                                                                 @IfPrint INT =NULL,
                                                                                 @LTim VARCHAR (10)=NULL,
                                                                                 @CREATED_BY VARCHAR(100) =NULL,
                                                                                 @DATE_CREATED datetime =NULL,
                                                                                 @MODIFIED_BY VARCHAR (100)=NULL,
                                                                                 @DATE_MODIFIED datetime=NULL,
                                                                                 @CreditPay float=NULL,
                                                                                 @CreditPayLocCur float=NULL,
                                                                                 @NetworkPay float=NULL,
                                                                                 @NetworkPayLocCur float=NULL,
                                                                                 @CommMnd_Inv float=NULL,
                                                                                 @MndExtrnal bit=NULL,
                                                                                 @CompanyID int=NULL,
                                                                                 @InvAddCost float=NULL,
                                                                                 @InvAddCostLoc float=NULL,
                                                                                 @InvAddCostExtrnal float=NULL,
                                                                                 @InvAddCostExtrnalLoc float=NULL,
                                                                                 @IsExtrnalGaid bit=NULL,
                                                                                 @ExtrnalCostGaidID float=NULL,
                                                                                 @Puyaid float=NULL,
                                                                                 @Remming float=NULL,
                                                                                 @RoomNo int=NULL,
                                                                                 @OrderTyp int=NULL,
                                                                                 @RoomSts bit=NULL,
                                                                                 @chauffeurNo int=NULL,
                                                                                 @RoomPerson int=NULL,
                                                                                 @ServiceValue float=NULL,
                                                                                 @Sts bit=NULL,
                                                                                 @PaymentOrderTyp int=NULL,
                                                                                 @AdminLock bit=NULL,
                                                                                 @DeleteDate VARCHAR (10)=NULL,
                                                                                 @DeleteTime VARCHAR (10)=NULL,
                                                                                 @UserNew VARCHAR (3)=NULL,
                                                                                 @IfEnter int=NULL,
                                                                                 @InvAddTax float=NULL,
                                                                                 @InvAddTaxlLoc float=NULL,
                                                                                 @IsTaxGaid bit=NULL,
                                                                                 @TaxGaidID float=NULL,
                                                                                 @IsTaxUse bit=NULL,
                                                                                 @InvValGaidDis float=NULL,
                                                                                 @InvValGaidDislLoc float=NULL,
                                                                                 @IsDisGaid bit=NULL,
                                                                                 @DisGaidID1 float=NULL,
                                                                                 @IsDisUse1 bit=NULL,
                                                                                 @InvComm float=NULL,
                                                                                 @InvCommLoc float=NULL,
                                                                                 @IsCommGaid bit=NULL,
                                                                                 @CommGaidID float=NULL,
                                                                                 @IsCommUse bit=NULL,
                                                                                 @IsTaxLines bit=NULL,
                                                                                 @IsTaxByTotal bit=NULL,
                                                                                 @IsTaxByNet bit=NULL,
                                                                                 @TaxByNetValue float=NULL,
                                                                                 @DesPointsValue float=NULL,
																			     @DesPointsValueLocCur float=NULL,
																			     @PointsCount float=NULL,
                                                                                 @IsPoints bit=NULL,
                                                                                 @tailor1 VARCHAR (100)=NULL,
                                                                                 @tailor2 VARCHAR (100)=NULL,
                                                                                 @tailor3 VARCHAR (100)=NULL,
                                                                                 @tailor4 VARCHAR (100)=NULL,
                                                                                 @tailor5 VARCHAR (100)=NULL,
                                                                                 @tailor6 VARCHAR (100)=NULL,
                                                                                 @tailor7 VARCHAR (100)=NULL,
                                                                                 @tailor8 VARCHAR (100)=NULL,
                                                                                 @tailor9 VARCHAR (100)=NULL,
                                                                                 @tailor10 VARCHAR (100)=NULL,
                                                                                 @tailor11 VARCHAR (100)=NULL,
                                                                                 @tailor12 VARCHAR (100)=NULL,
                                                                                 @tailor13 VARCHAR (100)=NULL,
                                                                                 @tailor14 VARCHAR (100)=NULL,
                                                                                 @tailor15 VARCHAR (100)=NULL,
                                                                                 @tailor16 VARCHAR (100)=NULL,
                                                                                 @tailor17 VARCHAR (100)=NULL,
                                                                                 @tailor18 VARCHAR (100)=NULL,
                                                                                 @tailor19 VARCHAR (100)=NULL,
                                                                                 @tailor20 VARCHAR (100)=NULL,
                                                                                 @InvImg VARBINARY(max) =NULL,
                                                                                 @CusVenMob VARCHAR(50) =NULL,
                                                                                 @PriceIncludeTax BIT = NULL,
																				 													 @CInvType INT =NULL,
																	 @Car_ID int =NULL,
	@Car_TypeNameA varchar(50) =NULL,
	@Car_TypeNameE varchar(50) =NULL,
	@Car_NameA varchar(50) =NULL,
	@Car_NameE varchar(50) =NULL,
	@PlateNo varchar(50) =NULL,
	@Color varchar(50) =NULL,
	@ModelNo varchar(50) =NULL,
	@Delevery_Date date =NULL,
	@VehiclechassisNumber Varchar(100) =Null,
	@OrderStatus INT =NULL
                                                                 
                                  )
                                  AS
                                  BEGIN
                                  UPDATE T_INVHED
                                  SET    InvId = @InvId,
                                         InvNo = @InvNo,
                                         InvTyp = @InvTyp,
                                         InvCashPay = @InvCashPay,
                                         CusVenNo = @CusVenNo,
                                         CusVenNm = @CusVenNm,
                                         CusVenAdd = @CusVenAdd,
                                         CusVenTel = @CusVenTel,
                                         Remark = @Remark,
                                         HDat = @HDat,
                                         GDat = @GDat,
                                         MndNo = @MndNo,
                                         SalsManNo = @SalsManNo,
                                         SalsManNam = @SalsManNam,
                                         InvTot = @InvTot,
                                         InvTotLocCur = @InvTotLocCur,
                                         InvDisPrs = @InvDisPrs,
                                         InvDisVal = @InvDisVal,
                                         InvDisValLocCur = @InvDisValLocCur,
                                         InvNet = @InvNet,
                                         InvNetLocCur = @InvNetLocCur,
                                         CashPay = @CashPay,
                                         CashPayLocCur = @CashPayLocCur,
                                         IfRet = @IfRet,
                                         GadeNo = @GadeNo,
                                         GadeId = @GadeId,
                                         IfDel = @IfDel,
                                         RetNo = @RetNo,
                                         RetId = @RetId,
                                         InvCstNo = @InvCstNo,
                                         InvCashPayNm = @InvCashPayNm,
                                         RefNo = @RefNo,
                                         InvCost = @InvCost,
                                         EstDat = @EstDat,
                                         CustPri = @CustPri,
                                         ArbTaf = @ArbTaf,
                                         CurTyp = @CurTyp,
                                         InvCash = @InvCash,
                                         ToStore = @ToStore,
                                         ToStoreNm = @ToStoreNm,
                                         InvQty = @InvQty,
                                         EngTaf = @EngTaf,
                                         IfTrans = @IfTrans,
                                         CustRep = @CustRep,
                                         CustNet = @CustNet,
                                         InvWight_T = @InvWight_T,
                                         IfPrint = @IfPrint,
                                         LTim = @LTim,
                                         MODIFIED_BY = @MODIFIED_BY,
                                         DATE_MODIFIED = @DATE_MODIFIED,
                                                                                 CreditPay = @CreditPay,
                                                                                 CreditPayLocCur = @CreditPayLocCur,
                                                                                 NetworkPay = @NetworkPay,
                                                                                 NetworkPayLocCur = @NetworkPayLocCur,
                                                                                 CommMnd_Inv = @CommMnd_Inv,
                                                                                 MndExtrnal = @MndExtrnal,
                                                                                 CompanyID = @CompanyID,
                                                                                 InvAddCost = @InvAddCost,
                                                                                 InvAddCostLoc = @InvAddCostLoc,
                                                                                 InvAddCostExtrnal = @InvAddCostExtrnal,
                                                                                 InvAddCostExtrnalLoc = @InvAddCostExtrnalLoc,
                                                                                 IsExtrnalGaid = @IsExtrnalGaid,
                                                                                 ExtrnalCostGaidID = @ExtrnalCostGaidID,
                                                                                 Puyaid = @Puyaid,
                                                                                 Remming = @Remming,
                                                                                 RoomNo = @RoomNo,
                                                                                 OrderTyp = @OrderTyp,
                                                                                 RoomSts = @RoomSts,
                                                                                 chauffeurNo = @chauffeurNo,
                                                                                 RoomPerson = @RoomPerson,
                                                                                 ServiceValue = @ServiceValue,
                                                                                 Sts = @Sts,
                                                                                 PaymentOrderTyp = @PaymentOrderTyp,
                                                                                 AdminLock = @AdminLock,
                                                                                 DeleteDate = @DeleteDate,
                                                                                 DeleteTime = @DeleteTime,
                                                                                 UserNew = @UserNew,
                                                                                 IfEnter = @IfEnter,
                                                                                 InvAddTax = @InvAddTax,
                                                                                 InvAddTaxlLoc = @InvAddTaxlLoc,
                                                                                 IsTaxGaid = @IsTaxGaid,
                                                                                 TaxGaidID = @TaxGaidID,
                                                                                 IsTaxUse = @IsTaxUse,
                                                                                 InvValGaidDis = @InvValGaidDis,
                                                                                 InvValGaidDislLoc = @InvValGaidDislLoc,
                                                                                 IsDisGaid = @IsDisGaid,
                                                                                 DisGaidID1 = @DisGaidID1,
                                                                                 IsDisUse1 = @IsDisUse1,
                                                                                 InvComm = @InvComm,
                                                                                 InvCommLoc = @InvCommLoc,
                                                                                 IsCommGaid = @IsCommGaid,
                                                                                 CommGaidID = @CommGaidID,
                                                                                 IsCommUse = @IsCommUse,
                                                                                 IsTaxLines = @IsTaxLines,
                                                                                 IsTaxByTotal = @IsTaxByTotal,
                                                                                 IsTaxByNet = @IsTaxByNet,
                                                                                 TaxByNetValue = @TaxByNetValue,
                                                                                 DesPointsValue = @DesPointsValue ,
																				 DesPointsValueLocCur = @DesPointsValueLocCur ,
																				 PointsCount = @PointsCount,
                                                                                 IsPoints = @IsPoints,
                                                                                 tailor1 = @tailor1 ,
																				 tailor2 = @tailor2,
																				 tailor3 = @tailor3,
																				 tailor4 = @tailor4,
																				 tailor5 = @tailor5,
																				 tailor6 = @tailor6,
																				 tailor7 = @tailor7,
																				 tailor8 = @tailor8,
																				 tailor9 = @tailor9,
																				 tailor10 = @tailor10,
																				 tailor11 = @tailor11,
																				 tailor12 = @tailor12,
																				 tailor13 = @tailor13,
																				 tailor14 = @tailor14,
																				 tailor15 = @tailor15,
																				 tailor16 = @tailor16,
																				 tailor17 = @tailor17,
																				 tailor18 = @tailor18,
																				 tailor19 = @tailor19,
																				 tailor20 = @tailor20,
                                                                                 InvImg   = @InvImg,
                                                                                 CusVenMob = @CusVenMob,
                                                                                 PriceIncludTax =@PriceIncludeTax,
																				 Car_ID=@Car_ID,
																				 Car_TypeNameA=@Car_TypeNameA,
																				 Car_TypeNameE=@Car_TypeNameE,
																				 Car_NameA=@Car_NameA,
																				 Car_NameE=@Car_NameE,
																				 PlateNo=@PlateNo,
																				 color=@Color,
																				 ModelNo=@ModelNo,
																				 Delevery_Date=@Delevery_Date
                                                                                ,VehiclechassisNumber=@VehiclechassisNumber,
																				OrderStatus=@OrderStatus
							 							 WHERE  @InvHed_ID = InvHed_ID
                                  RETURN
                                  END;";
      
        public static void updatenewBranch(int i, string id, int DBv, int da)
        {

            VarGeneral.BranchNumber = i.ToString();
            VarGeneral.ChangBr_ = true;
            new FrmMain(null, null, VarGeneral.BranchNumber, 0);
            Stock_DataDataContext db = new Stock_DataDataContext(VarGeneral.BranchCS);
            for (int ia = DBv; ia < scripts.Count; ia++)
            {
                try
                {

                    db.ExecuteCommand(scripts[ia]);

                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (SqlException ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {


                }
            }
            SqlConnection conn = new SqlConnection(VarGeneral.BranchCS);
            Server server = new Server(new ServerConnection(conn));
            if (da == 1)
            {
                if (File.Exists(Application.StartupPath + "\\periodicupdate"))
                {
                    string sa = File.ReadAllText(Application.StartupPath + "\\periodicupdate");
                    // File.Delete(Application.StartupPath + "\\dbupdate");
                    try
                    {
                        server.ConnectionContext.ExecuteNonQuery(sa);

                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (SqlException ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    {

                    }
                }

            }

            try
            {
                server.ConnectionContext.ExecuteNonQuery(DbUpdates.s1);
                // server.ConnectionContext.ExecuteNonQuery(VarGeneral.InvCreateInsertScript);
            }
            catch
            {

            }
            try
            {
                server.ConnectionContext.ExecuteNonQuery(DbUpdates.s2);
                //   server.ConnectionContext.ExecuteNonQuery(VarGeneral.InvCreateUpdateScript);
            }
            catch
            {
            }
            try
            {
                server.ConnectionContext.ExecuteNonQuery(DbUpdates.s3);
                //server.ConnectionContext.ExecuteNonQuery("  CREATE PROCEDURE [dbo].[S_T_INVDET_INSERT](   \r\n                                                                 @InvDet_ID INT OUTPUT,\r\n                                                                 @InvNo VARCHAR (10)=NULL,\r\n                                                                 @InvId INT =NULL,\r\n                                                                 @InvSer INT =NULL,\r\n                                                                 @ItmNo VARCHAR (50)=NULL,\r\n                                                                 @Cost FLOAT =NULL,\r\n                                                                 @Qty FLOAT =NULL,\r\n                                                                 @ItmDes VARCHAR (50)=NULL,\r\n                                                                 @ItmUnt VARCHAR (100)=NULL,\r\n                                                                 @ItmDesE VARCHAR (50)=NULL,\r\n                                                                 @ItmUntE VARCHAR (100)=NULL,\r\n                                                                 @ItmUntPak FLOAT =NULL,\r\n                                                                 @StoreNo INT=NULL,\r\n                                                                 @Price FLOAT =NULL,\r\n                                                                 @Amount FLOAT =NULL,\r\n                                                                 @RealQty FLOAT =NULL,\r\n                                                                 @itmInvDsc FLOAT =NULL,\r\n                                                                 @DatExper VARCHAR (11)=NULL,\r\n                                                                 @ItmDis FLOAT =NULL,\r\n                                                                 @ItmTyp INT =NULL,\r\n                                                                 @ItmIndex INT =NULL,\r\n                                                                 @ItmWight FLOAT =NULL,\r\n                                                                 @ItmWight_T FLOAT =NULL,\r\n                                                                 @ItmAddCost FLOAT =NULL,\r\n                                                                 @RunCod VARCHAR (100)=NULL,\r\n                                                                 @LineDetails VARCHAR (250)=NULL,\r\n                                                                 @Serial_Key VARCHAR (100)=NULL,\r\n                                                                 @ItmTax FLOAT =NULL,\r\n                                                                 @OfferTyp INT =NULL                                              \r\n                                                          )\r\n                                                          AS\r\n                                                          BEGIN\r\n                                                          INSERT INTO T_INVDET(\r\n                                                                 InvNo,\r\n                                                                 InvId,\r\n                                                                 InvSer,\r\n                                                                 ItmNo,\r\n                                                                 Cost,\r\n                                                                 Qty,\r\n                                                                 ItmDes,\r\n                                                                 ItmUnt,\r\n                                                                 ItmDesE,\r\n                                                                 ItmUntE,\r\n                                                                 ItmUntPak,\r\n                                                                 StoreNo,\r\n                                                                 Price,\r\n                                                                 Amount,\r\n                                                                 RealQty,\r\n                                                                 itmInvDsc,\r\n                                                                 DatExper,\r\n                                                                 ItmDis,\r\n                                                                 ItmTyp,\r\n                                                                 ItmIndex,\r\n                                                                 ItmWight,\r\n                                                                 ItmWight_T,\r\n                                                                 ItmAddCost,\r\n                                                                 RunCod,\r\n                                                                 LineDetails,\r\n                                                                 Serial_Key,\r\n                                                                 ItmTax,\r\n                                                                OfferTyp  \r\n                                                          )\r\n                                                          VALUES\r\n                                                          (\r\n                                                                 \r\n                                                                @InvNo,\r\n                                                                @InvId,\r\n                                                                @InvSer,\r\n                                                                @ItmNo,\r\n                                                                @Cost,\r\n                                                                @Qty,\r\n                                                                @ItmDes,\r\n                                                                @ItmUnt,\r\n                                                                @ItmDesE,\r\n                                                                @ItmUntE,\r\n                                                                @ItmUntPak,\r\n                                                                @StoreNo,\r\n                                                                @Price,\r\n                                                                @Amount,\r\n                                                                @RealQty,\r\n                                                                @itmInvDsc,\r\n                                                                @DatExper,\r\n                                                                @ItmDis,\r\n                                                                @ItmTyp,\r\n                                                                @ItmIndex,\r\n                                                                @ItmWight,\r\n                                                                @ItmWight_T,\r\n                                                                @ItmAddCost,\r\n                                                                @RunCod,\r\n                                                                @LineDetails,\r\n                                                                @Serial_Key,\r\n                                                                @ItmTax,\r\n                                                                @OfferTyp\r\n                                                          )\r\n                                                          SELECT @InvDet_ID = SCOPE_IDENTITY()\r\n                                                            declare @ItemCount int  \r\n                                                            declare @InvTyp int\r\n                                                            declare @MndID int\r\n                                                            declare @CusVenNo varchar(30)\r\n                                                            declare @ItemCountMnd int \r\n                                                            declare @ItemCountCust int \r\n\t\t                                                    select @ItemCount = Count(*) from T_STKSQTY where itmNo = @ItmNo and storeNo =@StoreNo;\r\n                                                            select @InvTyp = InvTyp from T_INVHED where InvHed_ID = @InvId;\r\n                                                            if((@InvTyp != 7 and @InvTyp != 8 and @InvTyp != 9 and @InvTyp != 21) and @ItmTyp <> 3)\r\n                                                            begin\r\n\t\t\t                                                          if(@ItmTyp <> 2)\r\n\t\t\t                                                          begin\r\n\t\t                                                                    Update T_Items SET OpenQty = OpenQty+@RealQty WHERE Itm_No = @ItmNo;\r\n\t\t\t                                                                if(@ItemCount > 0)\r\n\t\t\t                                                                begin\r\n\t\t\t                                                                Update T_STKSQTY SET stkQty = stkQty+@RealQty WHERE itmNo = @ItmNo and storeNo = @StoreNo;\r\n\t\t\t                                                                end\r\n\r\n\t\t\t                                                                if(@ItemCount = 0)\r\n\t\t\t                                                                begin \r\n\t\t\t                                                                INSERT INTO T_STKSQTY(itmNo,storeNo,stkQty,stkInt) VALUES(@ItmNo,@StoreNo,@RealQty,0);\r\n\t\t\t                                                                END\r\n                                                                            if(@InvTyp = 14)\r\n                                                                            begin\r\n\t\t\t\t                                                                Update T_STKSQTY SET stkInt = stkInt+@RealQty WHERE itmNo = @ItmNo and storeNo = @StoreNo;\r\n                                                                            end\r\n\r\n\t\t\t                                                                select @ItemCount = Count(*) from T_QTYEXP where itmNo = @ItmNo and storeNo =@StoreNo and (DatExper = @DatExper and RunCod = @RunCod);\r\n\r\n\t\t\t                                                                if(@ItemCount > 0 and (@DatExper <> '' or @RunCod <> ''))\r\n\t\t\t                                                                begin\r\n\t\t\t                                                                Update T_QTYEXP SET stkQty = stkQty+@RealQty WHERE itmNo = @ItmNo and storeNo = @StoreNo and (DatExper = @DatExper and RunCod = @RunCod);\r\n\t\t\t                                                                end\r\n\r\n\t\t\t                                                                if(@ItemCount = 0 and (@DatExper <> '' or @RunCod <> ''))\r\n\t\t\t                                                                begin \r\n\t\t\t                                                                INSERT INTO T_QTYEXP(itmNo,storeNo,DatExper,stkQty,RunCod) VALUES(@ItmNo,@StoreNo,@DatExper,@RealQty,@RunCod);\r\n\t\t\t                                                                END\r\n                                                                END\r\n\t\t\t                                                          if(@InvTyp = 17)\r\n\t\t\t\t                                                          begin\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t                       select @MndID = MndNo from T_INVHED where InvHed_ID = @InvId;\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t                       select @CusVenNo = CusVenNo from T_INVHED where InvHed_ID = @InvId;\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t                       if(@MndID > 0 )\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                    begin\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                              select @ItemCountMnd = Count(*) from T_StoreMnd where itmNo = @ItmNo and storeNo =@StoreNo and MndNo = @MndID;\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                      if(@ItemCountMnd > 0)\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                      begin\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                       Update T_StoreMnd SET stkQty = stkQty + abs(@RealQty) WHERE itmNo = @ItmNo and storeNo = @StoreNo and MndNo = @MndID;\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                      end\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                      if(@ItemCountMnd = 0)\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                      begin \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                       INSERT INTO T_StoreMnd(itmNo,storeNo,stkQty,stkInt,MndNo) VALUES(@ItmNo,@StoreNo,abs(@RealQty),0,@MndID);\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                      END\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                    END\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t                      else\r\n\t\t\t\t\t\t\t\t\t                                            begin\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                             select @ItemCountCust = Count(*) from T_StoreMnd where itmNo = @ItmNo and storeNo =@StoreNo and CusVenNo = @CusVenNo;\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                      if(@ItemCountCust > 0)\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                      begin\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                       Update T_StoreMnd SET stkQty = stkQty + abs(@RealQty) WHERE itmNo = @ItmNo and storeNo = @StoreNo and CusVenNo = @CusVenNo;\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                      end\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                      if(@ItemCountCust = 0)\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                      begin \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                       INSERT INTO T_StoreMnd(itmNo,storeNo,stkQty,stkInt,CusVenNo) VALUES(@ItmNo,@StoreNo,abs(@RealQty),0,@CusVenNo);\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                      END\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                    END\r\n\t\t\t\t                                                          END\t\r\n\t\t\t                                                          if(@InvTyp = 20)\r\n\t\t\t\t                                                          begin\r\n\t\t\t\t                                                              select @MndID = MndNo from T_INVHED where InvHed_ID = @InvId;\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t                      select @CusVenNo = CusVenNo from T_INVHED where InvHed_ID = @InvId;\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t                        if(@MndID > 0 )\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                    begin\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                     select @ItemCountMnd = Count(*) from T_StoreMnd where itmNo = @ItmNo and storeNo =@StoreNo and MndNo = @MndID;\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                      if(@ItemCountMnd > 0)\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                      begin\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                       Update T_StoreMnd SET stkQty = stkQty + (-@RealQty) WHERE itmNo = @ItmNo and storeNo = @StoreNo and MndNo = @MndID;\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                      end\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                      if(@ItemCountMnd = 0)\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                      begin \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                       INSERT INTO T_StoreMnd(itmNo,storeNo,stkQty,stkInt,MndNo) VALUES(@ItmNo,@StoreNo,-@RealQty,0,@MndID);\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                      END\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                     END\r\n\t\t\t\t\t\t\t                                                     else\r\n\t\t\t\t\t\t\t                                                         begin\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                     select @ItemCountCust = Count(*) from T_StoreMnd where itmNo = @ItmNo and storeNo =@StoreNo and CusVenNo = @CusVenNo;\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                      if(@ItemCountCust > 0)\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                      begin\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                       Update T_StoreMnd SET stkQty = stkQty + (-@RealQty) WHERE itmNo = @ItmNo and storeNo = @StoreNo and CusVenNo = @CusVenNo;\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                      end\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                      if(@ItemCountCust = 0)\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                      begin \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                       INSERT INTO T_StoreMnd(itmNo,storeNo,stkQty,stkInt,CusVenNo) VALUES(@ItmNo,@StoreNo,-@RealQty,0,@CusVenNo);\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                      END\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                     END\r\n\t\t\t\t                                                          end\r\n                                                            end\r\n                                                          RETURN @InvDet_ID\r\n                                                          END");
            }
            catch
            {

                db.ExecuteCommand(DbUpdates.s4);

                //  MessageBox.Show(EX.Message);
            }
            try
            {
                server.ConnectionContext.ExecuteNonQuery(DbUpdates.s5);
                //  server.ConnectionContext.ExecuteNonQuery("      ALTER PROCEDURE [dbo].[S_T_INVDET_DELETE](\r\n                                                      @InvDet_ID INT \r\n                                          )\r\n                                          AS\r\n                                          BEGIN\r\n                                        declare @InvTyp int \r\n                                        declare @InvId int\r\n                                        declare @MndID int\r\n                                        declare @CusVenNo varchar(30)\r\n                                        declare @PaymentOrderTyp int\r\n                                        declare @ItemCountMnd int \r\n                                        declare @MndKind int \r\n                                         \r\n                                        select @InvId = InvId from T_INVDET where InvDet_ID = @InvDet_ID;\r\n\r\n                                        select @InvTyp = InvTyp from T_INVHED where InvHed_ID = @InvId;\r\n\r\n                                        select @MndID = MndNo from T_INVHED where InvHed_ID = @InvId;\r\n                                        \r\n                                        select @PaymentOrderTyp = PaymentOrderTyp from T_INVHED where InvHed_ID = @InvId;\r\n\r\n                                        select @CusVenNo = CusVenNo from T_INVHED where InvHed_ID = @InvId;\r\n                                        \r\n                                        select @MndKind = Mnd_Typ from T_Mndob where Mnd_ID = @MndID;\r\n                                        \r\n                                        if(@InvTyp != 7 and @InvTyp != 8 and @InvTyp != 9 and @InvTyp != 21)\r\n                                        begin\r\n                                             if((@PaymentOrderTyp <= 0 or @PaymentOrderTyp is null) or  ((@PaymentOrderTyp = 1 or @PaymentOrderTyp = 2) and (@InvTyp = 17 or @InvTyp = 20) ))\r\n\t\t                                      begin\r\n\t\t\t                                      UPDATE T_Items SET T_Items.OpenQty = T_Items.OpenQty - T_INVDET.RealQty \r\n\t\t\t                                      From T_INVDET Left Join T_Items ON (T_INVDET.ItmNo = T_Items.Itm_No) \r\n\t\t\t                                      where (InvDet_ID = @InvDet_ID) and (T_INVDET.ItmTyp <> 3) and (T_INVDET.ItmTyp <> 2);\r\n\r\n\t\t\t                                      UPDATE T_STKSQTY SET T_STKSQTY.stkQty = T_STKSQTY.stkQty - T_INVDET.RealQty \r\n\t\t\t                                      From T_INVDET Left Join T_STKSQTY ON (T_INVDET.ItmNo = T_STKSQTY.itmNo) AND (T_INVDET.StoreNo = T_STKSQTY.storeNo)  \r\n\t\t\t                                      where @InvDet_ID = InvDet_ID and T_INVDET.ItmTyp <> 3 and (T_INVDET.ItmTyp <> 2);\r\n                                    \t\t\t  \r\n\t\t\t                                      UPDATE T_QTYEXP SET T_QTYEXP.stkQty = T_QTYEXP.stkQty - T_INVDET.RealQty \r\n\t\t\t                                      From  T_INVDET Left Join T_QTYEXP ON (T_INVDET.ItmNo = T_QTYEXP.itmNo) AND (T_INVDET.StoreNo = T_QTYEXP.storeNo) AND (T_INVDET.DatExper = T_QTYEXP.DatExper and T_INVDET.RunCod = T_QTYEXP.RunCod )\r\n\t\t\t                                      where @InvDet_ID = InvDet_ID and T_INVDET.ItmTyp <> 3 and (T_INVDET.ItmTyp <> 2);\r\n                                             end\r\n                                             if(@InvTyp = 14)\r\n\t\t                                      begin\r\n\t\t\t                                      UPDATE T_STKSQTY SET T_STKSQTY.stkInt = T_STKSQTY.stkInt - T_INVDET.RealQty \r\n\t\t\t                                      From T_INVDET Left Join T_STKSQTY ON (T_INVDET.ItmNo = T_STKSQTY.itmNo) AND (T_INVDET.StoreNo = T_STKSQTY.storeNo)  \r\n\t\t\t                                      where @InvDet_ID = InvDet_ID and T_INVDET.ItmTyp <> 3 and (T_INVDET.ItmTyp <> 2);\r\n\t\t                                      end\r\n                                         if(@InvTyp = 17)\r\n\t                                     begin\r\n\r\n                                    \t\t\t\t  \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t  select @MndID = MndNo from T_INVHED where InvHed_ID = @InvId;\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty - abs(T_INVDET.RealQty)\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t  From T_INVDET Left Join T_StoreMnd ON (T_INVDET.ItmNo = T_StoreMnd.itmNo) AND (T_INVDET.StoreNo = T_StoreMnd.storeNo)  \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t  where @InvDet_ID = InvDet_ID and T_INVDET.ItmTyp <> 3 and T_StoreMnd.MndNo = @MndID ;\r\n\t\t\t\t                                      \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t  select @CusVenNo = CusVenNo from T_INVHED where InvHed_ID = @InvId;\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty - abs(T_INVDET.RealQty)\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t  From T_INVDET Left Join T_StoreMnd ON (T_INVDET.ItmNo = T_StoreMnd.itmNo) AND (T_INVDET.StoreNo = T_StoreMnd.storeNo)  \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t  where @InvDet_ID = InvDet_ID and T_INVDET.ItmTyp <> 3 and T_StoreMnd.CusVenNo = @CusVenNo ;\r\n                                         end\r\n                                         \r\n                                         if(@InvTyp = 20)\r\n\t                                     begin\r\n                                    \t\t\t\t   \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t  select @MndID = MndNo from T_INVHED where InvHed_ID = @InvId;\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty + T_INVDET.RealQty \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t  From T_INVDET Left Join T_StoreMnd ON (T_INVDET.ItmNo = T_StoreMnd.itmNo) AND (T_INVDET.StoreNo = T_StoreMnd.storeNo)  \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t  where @InvDet_ID = InvDet_ID and T_INVDET.ItmTyp <> 3 and T_StoreMnd.MndNo = @MndID ;\r\n\t\t\t\t\t                                      \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t  select @CusVenNo = CusVenNo from T_INVHED where InvHed_ID = @InvId;\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty + T_INVDET.RealQty \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t  From T_INVDET Left Join T_StoreMnd ON (T_INVDET.ItmNo = T_StoreMnd.itmNo) AND (T_INVDET.StoreNo = T_StoreMnd.storeNo)  \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t  where @InvDet_ID = InvDet_ID and T_INVDET.ItmTyp <> 3 and T_StoreMnd.CusVenNo = @CusVenNo ;\r\n                                         end\r\n                                        end\r\n                                         \r\n                                          DELETE FROM T_INVDET\r\n                                          WHERE      @InvDet_ID = InvDet_ID    \r\n\r\n                                          RETURN\r\n                                          END");
            }
            catch
            {
            }
            try
            {
                server.ConnectionContext.ExecuteNonQuery(DbUpdates.s6);
                // server.ConnectionContext.ExecuteNonQuery(" ALTER PROCEDURE [dbo].[S_T_INVHED_DELETE](\r\n                                              @InvHed_ID INT \r\n                                  )\r\n                                  AS\r\n                                  BEGIN\r\n                                  declare @InvTyp int\r\n                                  declare @MndID int\r\n                                  declare @CusVenNo varchar(30)\r\n                                  declare @PaymentOrderTyp int\r\n                                  declare @MndKind int \r\n                                       \r\n                                  select @InvTyp = InvTyp from T_INVHED where InvHed_ID = @InvHed_ID;\r\n\r\n                                select @MndID = MndNo from T_INVHED where InvHed_ID = @InvHed_ID;\r\n                                \r\n                                select @PaymentOrderTyp = PaymentOrderTyp from T_INVHED where InvHed_ID = @InvHed_ID;\r\n\r\n                                select @CusVenNo = CusVenNo from T_INVHED where InvHed_ID = @InvHed_ID;\r\n\r\n                                select @MndKind = Mnd_Typ from T_Mndob where Mnd_ID = @MndID;\r\n                                \r\n                                  if(@InvTyp != 7 and @InvTyp != 8 and @InvTyp != 9 and @InvTyp != 21)\r\n                                begin\r\n                                  if(@PaymentOrderTyp <= 0 or @PaymentOrderTyp is null)\r\n\t                              begin\r\n\t\t                              UPDATE T_Items SET T_Items.OpenQty = T_Items.OpenQty - T_INVDET.RealQty \r\n\t\t                              From T_INVDET Left Join T_Items ON (T_INVDET.ItmNo = T_Items.Itm_No) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID) \r\n\t\t                              where (InvHed_ID = @InvHed_ID) and (T_INVDET.ItmTyp <> 3) and (T_INVDET.ItmTyp <> 2);\r\n\r\n\t\t                              UPDATE T_STKSQTY SET T_STKSQTY.stkQty = T_STKSQTY.stkQty - T_INVDET.RealQty \r\n\t\t                              From T_INVDET Left Join T_STKSQTY ON (T_INVDET.ItmNo = T_STKSQTY.itmNo) AND (T_INVDET.StoreNo = T_STKSQTY.storeNo) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)  \r\n\t\t                              where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and (T_INVDET.ItmTyp <> 2);\r\n                            \t\t  \r\n\t\t                              UPDATE T_QTYEXP SET T_QTYEXP.stkQty = T_QTYEXP.stkQty - T_INVDET.RealQty \r\n\t\t                              From  T_INVDET Left Join T_QTYEXP ON (T_INVDET.ItmNo = T_QTYEXP.itmNo) AND (T_INVDET.StoreNo = T_QTYEXP.storeNo) AND (T_INVDET.DatExper = T_QTYEXP.DatExper and T_INVDET.RunCod = T_QTYEXP.RunCod ) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)\r\n\t\t                              where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and (T_INVDET.ItmTyp <> 2);\r\n                                  end\r\n                                 if(@InvTyp = 17)\r\n\t                             begin\r\n                                         if(@PaymentOrderTyp > 0)\r\n\t                                      begin\r\n \t\t\t\t\t\t\t\t\t\t      UPDATE T_Items SET T_Items.OpenQty = T_Items.OpenQty - T_INVDET.RealQty \r\n\t\t\t\t\t\t\t\t\t\t      From T_INVDET Left Join T_Items ON (T_INVDET.ItmNo = T_Items.Itm_No) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID) \r\n\t\t\t\t\t\t\t\t\t\t      where (InvHed_ID = @InvHed_ID) and (T_INVDET.ItmTyp <> 3) and (T_INVDET.ItmTyp <> 2);\r\n\r\n\t\t\t\t\t\t\t\t\t\t      UPDATE T_STKSQTY SET T_STKSQTY.stkQty = T_STKSQTY.stkQty - T_INVDET.RealQty \r\n\t\t\t\t\t\t\t\t\t\t      From T_INVDET Left Join T_STKSQTY ON (T_INVDET.ItmNo = T_STKSQTY.itmNo) AND (T_INVDET.StoreNo = T_STKSQTY.storeNo) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)  \r\n\t\t\t\t\t\t\t\t\t\t      where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and (T_INVDET.ItmTyp <> 2);\r\n                                \t\t\t  \r\n\t\t\t\t\t\t\t\t\t\t      UPDATE T_QTYEXP SET T_QTYEXP.stkQty = T_QTYEXP.stkQty - T_INVDET.RealQty \r\n\t\t\t\t\t\t\t\t\t\t      From  T_INVDET Left Join T_QTYEXP ON (T_INVDET.ItmNo = T_QTYEXP.itmNo) AND (T_INVDET.StoreNo = T_QTYEXP.storeNo) AND (T_INVDET.DatExper = T_QTYEXP.DatExper and T_INVDET.RunCod = T_QTYEXP.RunCod ) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)\r\n\t\t\t\t\t\t\t\t\t\t      where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and (T_INVDET.ItmTyp <> 2);\r\n                                          end\r\n\t\t\t\t\t\t\t\t\t\t  select @MndID = MndNo from T_INVHED where InvHed_ID = @InvHed_ID;  \t  \r\n\t\t\t\t\t\t\t\t\t\t  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty - abs(T_INVDET.RealQty)\r\n\t\t\t\t\t\t\t\t\t\t  From T_INVDET Left Join T_StoreMnd ON (T_INVDET.ItmNo = T_StoreMnd.itmNo) AND (T_INVDET.StoreNo = T_StoreMnd.storeNo) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)  \r\n\t\t\t\t\t\t\t\t\t\t  where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and T_StoreMnd.MndNo = @MndID ;\r\n\t\t\t\t\t\t\t\t\t\t  \r\n\t\t\t\t\t\t\t\t\t\t  select @CusVenNo = CusVenNo from T_INVHED where InvHed_ID = @InvHed_ID;  \t  \r\n\t\t\t\t\t\t\t\t\t\t  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty - abs(T_INVDET.RealQty)\r\n\t\t\t\t\t\t\t\t\t\t  From T_INVDET Left Join T_StoreMnd ON (T_INVDET.ItmNo = T_StoreMnd.itmNo) AND (T_INVDET.StoreNo = T_StoreMnd.storeNo) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)  \r\n\t\t\t\t\t\t\t\t\t\t  where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and T_StoreMnd.CusVenNo = @CusVenNo ;\r\n                                 end\r\n                                 \r\n                                 if(@InvTyp = 20)\r\n\t                             begin\r\n                                         if(@PaymentOrderTyp > 0)\r\n\t                                      begin\r\n \t\t\t\t\t\t\t\t\t\t      UPDATE T_Items SET T_Items.OpenQty = T_Items.OpenQty - T_INVDET.RealQty \r\n\t\t\t\t\t\t\t\t\t\t      From T_INVDET Left Join T_Items ON (T_INVDET.ItmNo = T_Items.Itm_No) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID) \r\n\t\t\t\t\t\t\t\t\t\t      where (InvHed_ID = @InvHed_ID) and (T_INVDET.ItmTyp <> 3) and (T_INVDET.ItmTyp <> 2);\r\n\r\n\t\t\t\t\t\t\t\t\t\t      UPDATE T_STKSQTY SET T_STKSQTY.stkQty = T_STKSQTY.stkQty - T_INVDET.RealQty \r\n\t\t\t\t\t\t\t\t\t\t      From T_INVDET Left Join T_STKSQTY ON (T_INVDET.ItmNo = T_STKSQTY.itmNo) AND (T_INVDET.StoreNo = T_STKSQTY.storeNo) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)  \r\n\t\t\t\t\t\t\t\t\t\t      where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and (T_INVDET.ItmTyp <> 2);\r\n                                \t\t\t  \r\n\t\t\t\t\t\t\t\t\t\t      UPDATE T_QTYEXP SET T_QTYEXP.stkQty = T_QTYEXP.stkQty - T_INVDET.RealQty \r\n\t\t\t\t\t\t\t\t\t\t      From  T_INVDET Left Join T_QTYEXP ON (T_INVDET.ItmNo = T_QTYEXP.itmNo) AND (T_INVDET.StoreNo = T_QTYEXP.storeNo) AND (T_INVDET.DatExper = T_QTYEXP.DatExper and T_INVDET.RunCod = T_QTYEXP.RunCod ) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)\r\n\t\t\t\t\t\t\t\t\t\t      where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and (T_INVDET.ItmTyp <> 2);\r\n                                          end\r\n\t\t\t\t\t\t\t\t\t\t\t\t  select @MndID = MndNo from T_INVHED where InvHed_ID = @InvHed_ID;  \t  \r\n\t\t\t\t\t\t\t\t\t\t\t\t  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty + T_INVDET.RealQty \r\n\t\t\t\t\t\t\t\t\t\t\t\t  From T_INVDET Left Join T_StoreMnd ON (T_INVDET.ItmNo = T_StoreMnd.itmNo) AND (T_INVDET.StoreNo = T_StoreMnd.storeNo) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)  \r\n\t\t\t\t\t\t\t\t\t\t\t\t  where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and T_StoreMnd.MndNo = @MndID ;\r\n\t\t\t\t\t\t\t\t\t\t\t\t  \r\n\t\t\t\t\t\t\t\t\t\t\t\t  select @CusVenNo = CusVenNo from T_INVHED where InvHed_ID = @InvHed_ID;  \t  \r\n\t\t\t\t\t\t\t\t\t\t\t\t  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty + T_INVDET.RealQty \r\n\t\t\t\t\t\t\t\t\t\t\t\t  From T_INVDET Left Join T_StoreMnd ON (T_INVDET.ItmNo = T_StoreMnd.itmNo) AND (T_INVDET.StoreNo = T_StoreMnd.storeNo) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)  \r\n\t\t\t\t\t\t\t\t\t\t\t\t  where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and T_StoreMnd.CusVenNo = @CusVenNo ;\r\n                                 end\r\n                             \r\n                                  if(@InvTyp = 14)\r\n                                  begin\r\n\t\t                              UPDATE T_STKSQTY SET T_STKSQTY.stkInt = T_STKSQTY.stkInt - T_INVDET.RealQty \r\n\t\t                              From T_INVDET Left Join T_STKSQTY ON (T_INVDET.ItmNo = T_STKSQTY.itmNo) AND (T_INVDET.StoreNo = T_STKSQTY.storeNo) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)  \r\n\t\t                              where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and (T_INVDET.ItmTyp <> 2);\r\n                                  end       \r\n                                  \r\n                                end\r\n                                  UPDATE T_INVHED SET T_INVHED.IfDel = 1 \r\n                                  FROM  T_INVHED\r\n                                  WHERE  @InvHed_ID = InvHed_ID\r\n\r\n                                  RETURN\r\n                                  END");
            }
            catch
            {
            }
            try
            {
                server.ConnectionContext.ExecuteNonQuery(DbUpdates.s7);
                //   server.ConnectionContext.ExecuteNonQuery("/****** Object:  StoredProcedure [dbo].[S_T_GDDET_INSERT]    Script Date: 12/23/2016 17:51:49 ******/\r\n                                    ALTER PROCEDURE [dbo].[S_T_GDDET_INSERT](   \r\n                                                 @GDDET_ID INT OUTPUT,\r\n                                                 @gdID INT =NULL,\r\n                                                 @gdNo VARCHAR (10)=NULL,\r\n                                                 @gdDes VARCHAR (100)=NULL,\r\n                                                 @gdDesE VARCHAR (100)=NULL,\r\n                                                 @recptTyp VARCHAR (20)=NULL,\r\n                                                 @AccNo VARCHAR (30)=NULL,\r\n                                                 @AccName VARCHAR (50)=NULL,\r\n                                                 @gdValue FLOAT =NULL,\r\n                                                 @recptNo VARCHAR (20)=NULL,\r\n                                                 @Lin INT =NULL,\r\n                                                 @AccNoDestruction VARCHAR (30)=NULL\r\n                                                 \r\n                                          )\r\n                                          AS\r\n                                          BEGIN\r\n\r\n                                          INSERT INTO T_GDDET(\r\n                                                 gdID,\r\n                                                 gdNo,\r\n                                                 gdDes,\r\n                                                 gdDesE,\r\n                                                 recptTyp,\r\n                                                 AccNo,\r\n                                                 AccName,\r\n                                                 gdValue,\r\n                                                 recptNo,\r\n                                                 Lin,\r\n                                                 AccNoDestruction\r\n                                          )\r\n                                          VALUES\r\n                                          (\r\n                                                 \r\n                                                @gdID,\r\n                                                @gdNo,\r\n                                                @gdDes,\r\n                                                @gdDesE,\r\n                                                @recptTyp,\r\n                                                @AccNo,\r\n                                                @AccName,\r\n                                                @gdValue,\r\n                                                @recptNo,\r\n                                                @Lin,\r\n                                                @AccNoDestruction\r\n                                          )\r\n                                          SELECT @GDDET_ID = SCOPE_IDENTITY()\r\n                                          UPDATE T_AccDef SET T_AccDef.Debit = T_AccDef.Debit + ROUND( T_GDDET.gdValue, case when Substring((select MAX(T_SYSSETTING.Seting) from T_SYSSETTING),49,1) = 0 then 2 else 3 end)\r\n                                          From T_AccDef Left Join T_GDDET ON (T_AccDef.AccDef_No = T_GDDET.AccNo) \r\n                                          where @GDDET_ID = GDDET_ID and  T_GDDET.gdValue > 0 ;\r\n                                          UPDATE T_AccDef SET T_AccDef.Credit = T_AccDef.Credit + ABS(ROUND( T_GDDET.gdValue, case when Substring((select MAX(T_SYSSETTING.Seting) from T_SYSSETTING),49,1) = 0 then 2 else 3 end))\r\n                                          From T_AccDef Left Join T_GDDET ON (T_AccDef.AccDef_No = T_GDDET.AccNo) \r\n                                          where @GDDET_ID = GDDET_ID and  T_GDDET.gdValue < 0 ;\r\n                                          UPDATE T_AccDef SET T_AccDef.Balance = T_AccDef.Debit - T_AccDef.Credit\r\n                                          From T_AccDef Left Join T_GDDET ON (T_AccDef.AccDef_No = T_GDDET.AccNo) \r\n                                          where @GDDET_ID = GDDET_ID ;\r\n                                          RETURN\r\n                                          END");
            }
            catch
            {
            }
            try
            {
                server.ConnectionContext.ExecuteNonQuery(DbUpdates.s8);
                //server.ConnectionContext.ExecuteNonQuery(" ALTER PROCEDURE [dbo].[S_T_SINVDET_DELETE](\r\n                                                                @SInvDet_ID INT \r\n                                          )\r\n                                          AS\r\n                                          BEGIN\r\n\r\n                                            declare @SInvTyp int \r\n                                            declare @SInvId int\r\n                                            declare @SMndID int\r\n                                            declare @SItemCountMnd int \r\n                                            declare @SMndKind int \r\n                                            declare @SRelation int\r\n                                                   \r\n                                            select @SInvId = SInvId from T_SINVDET where SInvDet_ID = @SInvDet_ID;\r\n\r\n                                            select @SRelation = InvId from T_INVDET where InvDet_ID = @SInvId;\r\n\r\n                                            select @SInvTyp = InvTyp from T_INVHED where InvHed_ID = @SRelation;\r\n\r\n                                            select @SMndID = MndNo from T_INVHED where InvHed_ID = @SRelation;\r\n                                            \r\n                                            select @SMndKind = Mnd_Typ from T_Mndob where Mnd_ID = @SMndID;\r\n                                            \r\n                                            if(@SInvTyp != 7 and @SInvTyp != 8 and @SInvTyp != 9 and @SInvTyp != 21)\r\n                                            begin\r\n                                              if(@SMndKind != 1 or @SMndKind is null)\r\n\t\t                                          begin\r\n\t\t\t                                          UPDATE T_Items SET T_Items.OpenQty = T_Items.OpenQty - T_SINVDET.SRealQty \r\n\t\t\t                                          From T_SINVDET Left Join T_Items ON (T_SINVDET.SItmNo = T_Items.Itm_No) \r\n\t\t\t                                          where (SInvDet_ID = @SInvDet_ID) and (T_SINVDET.SItmTyp <> 3) and (T_SINVDET.SItmTyp <> 2);\r\n\r\n\t\t\t                                          UPDATE T_STKSQTY SET T_STKSQTY.stkQty = T_STKSQTY.stkQty - T_SINVDET.SRealQty \r\n\t\t\t                                          From T_SINVDET Left Join T_STKSQTY ON (T_SINVDET.SItmNo = T_STKSQTY.itmNo) AND (T_SINVDET.SStoreNo = T_STKSQTY.storeNo)  \r\n\t\t\t                                          where @SInvDet_ID = SInvDet_ID and T_SINVDET.SItmTyp <> 3 and (T_SINVDET.SItmTyp <> 2);\r\n                                        \t\t\t  \r\n\t\t\t                                          UPDATE T_QTYEXP SET T_QTYEXP.stkQty = T_QTYEXP.stkQty - T_SINVDET.SRealQty \r\n\t\t\t                                          From  T_SINVDET Left Join T_QTYEXP ON (T_SINVDET.SItmNo = T_QTYEXP.itmNo) AND (T_SINVDET.SStoreNo = T_QTYEXP.storeNo) AND (T_SINVDET.SDatExper = T_QTYEXP.DatExper)\r\n\t\t\t                                          where @SInvDet_ID = SInvDet_ID and T_SINVDET.SItmTyp <> 3 and (T_SINVDET.SItmTyp <> 2);\r\n\t\t                                          end\r\n                                              if(@SInvTyp = 14)\r\n\t\t                                          begin\r\n\t\t\t                                          UPDATE T_STKSQTY SET T_STKSQTY.stkInt = T_STKSQTY.stkInt - T_SINVDET.SRealQty \r\n\t\t\t                                          From T_SINVDET Left Join T_STKSQTY ON (T_SINVDET.SItmNo = T_STKSQTY.itmNo) AND (T_SINVDET.SStoreNo = T_STKSQTY.storeNo)  \r\n\t\t\t                                          where @SInvDet_ID = SInvDet_ID and T_SINVDET.SItmTyp <> 3 and (T_SINVDET.SItmTyp <> 2);\r\n\t\t                                          end\r\n                                             if(@SInvTyp = 17)\r\n\t                                         begin\r\n\t \t\t                                          UPDATE T_Items SET T_Items.OpenQty = T_Items.OpenQty - T_SINVDET.SRealQty \r\n\t\t\t                                          From T_SINVDET Left Join T_Items ON (T_SINVDET.SItmNo = T_Items.Itm_No) \r\n\t\t\t                                          where (SInvDet_ID = @SInvDet_ID) and (T_SINVDET.SItmTyp <> 3) and (T_SINVDET.SItmTyp <> 2);\r\n\r\n\t\t\t                                          UPDATE T_STKSQTY SET T_STKSQTY.stkQty = T_STKSQTY.stkQty - T_SINVDET.SRealQty \r\n\t\t\t                                          From T_SINVDET Left Join T_STKSQTY ON (T_SINVDET.SItmNo = T_STKSQTY.itmNo) AND (T_SINVDET.SStoreNo = T_STKSQTY.storeNo)  \r\n\t\t\t                                          where @SInvDet_ID = SInvDet_ID and T_SINVDET.SItmTyp <> 3 and (T_SINVDET.SItmTyp <> 2);\r\n                                        \t\t\t  \r\n\t\t\t                                          UPDATE T_QTYEXP SET T_QTYEXP.stkQty = T_QTYEXP.stkQty - T_SINVDET.SRealQty \r\n\t\t\t                                          From  T_SINVDET Left Join T_QTYEXP ON (T_SINVDET.SItmNo = T_QTYEXP.itmNo) AND (T_SINVDET.SStoreNo = T_QTYEXP.storeNo) AND (T_SINVDET.SDatExper = T_QTYEXP.DatExper)\r\n\t\t\t                                          where @SInvDet_ID = SInvDet_ID and T_SINVDET.SItmTyp <> 3 ;\r\n                                        \t\t\t  \r\n\t                                             -- select @SMndID = MndNo from T_INVHED where InvHed_ID = @SRelation;\r\n\t\t                                         -- UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty - abs(T_SINVDET.SRealQty)\r\n\t\t                                         -- From T_SINVDET Left Join T_StoreMnd ON (T_SINVDET.SItmNo = T_StoreMnd.itmNo) AND (T_SINVDET.SStoreNo = T_StoreMnd.storeNo)  \r\n\t\t                                         -- where @SInvDet_ID = SInvDet_ID and T_SINVDET.SItmTyp <> 3 and (T_SINVDET.SItmTyp <> 2) and T_StoreMnd.MndNo = @SMndID ;\r\n                                             end\r\n                                             \r\n                                             if(@SInvTyp = 20)\r\n\t                                         begin\r\n\t       \t                                          UPDATE T_Items SET T_Items.OpenQty = T_Items.OpenQty - T_SINVDET.SRealQty \r\n\t\t\t                                          From T_SINVDET Left Join T_Items ON (T_SINVDET.SItmNo = T_Items.Itm_No) \r\n\t\t\t                                          where (SInvDet_ID = @SInvDet_ID) and (T_SINVDET.SItmTyp <> 3) and (T_SINVDET.SItmTyp <> 2);\r\n\r\n\t\t\t                                          UPDATE T_STKSQTY SET T_STKSQTY.stkQty = T_STKSQTY.stkQty - T_SINVDET.SRealQty \r\n\t\t\t                                          From T_SINVDET Left Join T_STKSQTY ON (T_SINVDET.SItmNo = T_STKSQTY.itmNo) AND (T_SINVDET.SStoreNo = T_STKSQTY.storeNo)  \r\n\t\t\t                                          where @SInvDet_ID = SInvDet_ID and T_SINVDET.SItmTyp <> 3 and (T_SINVDET.SItmTyp <> 2);\r\n                                        \t\t\t  \r\n\t\t\t                                          UPDATE T_QTYEXP SET T_QTYEXP.stkQty = T_QTYEXP.stkQty - T_SINVDET.SRealQty \r\n\t\t\t                                          From  T_SINVDET Left Join T_QTYEXP ON (T_SINVDET.SItmNo = T_QTYEXP.itmNo) AND (T_SINVDET.SStoreNo = T_QTYEXP.storeNo) AND (T_SINVDET.SDatExper = T_QTYEXP.DatExper)\r\n\t\t\t                                          where @SInvDet_ID = SInvDet_ID and T_SINVDET.SItmTyp <> 3 and (T_SINVDET.SItmTyp <> 2);\r\n                                        \t\t\t  \r\n\t                                            --  select @SMndID = MndNo from T_INVHED where InvHed_ID = @SRelation;\r\n\t\t                                        --  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty + T_SINVDET.SRealQty \r\n\t\t                                        --  From T_SINVDET Left Join T_StoreMnd ON (T_SINVDET.SItmNo = T_StoreMnd.itmNo) AND (T_SINVDET.SStoreNo = T_StoreMnd.storeNo)  \r\n\t\t                                        --  where @SInvDet_ID = SInvDet_ID and T_SINVDET.SItmTyp <> 3 and (T_SINVDET.SItmTyp <> 2) and T_StoreMnd.MndNo = @SMndID ;\r\n                                             end\r\n                                            end\r\n\r\n                                        \r\n\r\n                                          DELETE FROM T_SINVDET\r\n                                          WHERE      @SInvDet_ID = SInvDet_ID   \r\n\r\n                                          RETURN\r\n                                          END");
            }
            catch
            {
            }
            try
            {
                server.ConnectionContext.ExecuteNonQuery(DbUpdates.s9);
                //server.ConnectionContext.ExecuteNonQuery("         ALTER PROCEDURE [dbo].[S_T_SINVDET_INSERT](   \r\n                                                 @SInvDet_ID INT OUTPUT,\r\n                                                 @SInvNo VARCHAR (10)=NULL,\r\n                                                 @SInvId INT =NULL,\r\n                                                 @SInvSer INT =NULL,\r\n                                                 @SItmNo VARCHAR (50)=NULL,\r\n                                                 @SCost FLOAT =NULL,\r\n                                                 @SQty FLOAT =NULL,\r\n                                                 @SItmDes VARCHAR (50)=NULL,\r\n                                                 @SItmUnt VARCHAR (100)=NULL,\r\n                                                 @SItmDesE VARCHAR (50)=NULL,\r\n                                                 @SItmUntE VARCHAR (100)=NULL,\r\n                                                 @SItmUntPak FLOAT =NULL,\r\n                                                 @SStoreNo INT=NULL,\r\n                                                 @SPrice FLOAT =NULL,\r\n                                                 @SAmount FLOAT =NULL,\r\n                                                 @SRealQty FLOAT =NULL,\r\n                                                 @SitmInvDsc FLOAT =NULL,\r\n                                                 @SDatExper VARCHAR (11)=NULL,\r\n                                                 @SItmDis FLOAT =NULL,\r\n                                                 @SItmTyp INT =NULL,\r\n                                                 @SItmIndex INT =NULL,\r\n                                                 @SItmWight FLOAT =NULL,\r\n                                                 @SItmWight_T FLOAT =NULL,\r\n                                                 @SQtyDef FLOAT =NULL,\r\n                                                 @SPriceDef FLOAT =NULL,\r\n                                                 @SInvIdHEAD INT =NULL,\r\n                                                 @SItmTax FLOAT =NULL  \r\n                                                 \r\n                                          )\r\n                                          AS\r\n                                          BEGIN\r\n\r\n                                          INSERT INTO T_SINVDET(\r\n                                                 SInvNo,\r\n                                                 SInvId,\r\n                                                 SInvSer,\r\n                                                 SItmNo,\r\n                                                 SCost,\r\n                                                 SQty,\r\n                                                 SItmDes,\r\n                                                 SItmUnt,\r\n                                                 SItmDesE,\r\n                                                 SItmUntE,\r\n                                                 SItmUntPak,\r\n                                                 SStoreNo,\r\n                                                 SPrice,\r\n                                                 SAmount,\r\n                                                 SRealQty,\r\n                                                 SitmInvDsc,\r\n                                                 SDatExper,\r\n                                                 SItmDis,\r\n                                                 SItmTyp,\r\n                                                 SItmIndex,\r\n                                                 SItmWight,\r\n                                                 SItmWight_T,\r\n                                                 SQtyDef,\r\n                                                 SPriceDef,\r\n                                                 SInvIdHEAD,\r\n                                                 SItmTax\r\n                                          )\r\n                                          VALUES\r\n                                          (\r\n                                                @SInvNo,\r\n                                                @SInvId,\r\n                                                @SInvSer,\r\n                                                @SItmNo,\r\n                                                @SCost,\r\n                                                @SQty,\r\n                                                @SItmDes,\r\n                                                @SItmUnt,\r\n                                                @SItmDesE,\r\n                                                @SItmUntE,\r\n                                                @SItmUntPak,\r\n                                                @SStoreNo,\r\n                                                @SPrice,\r\n                                                @SAmount,\r\n                                                @SRealQty,\r\n                                                @SitmInvDsc,\r\n                                                @SDatExper,\r\n                                                @SItmDis,\r\n                                                @SItmTyp,\r\n                                                @SItmIndex,\r\n                                                @SItmWight,\r\n                                                @SItmWight_T,\r\n                                                @SQtyDef,\r\n                                                @SPriceDef,\r\n                                                @SInvIdHEAD,\r\n                                                @SItmTax\r\n                                          )\r\n                                          SELECT @SInvDet_ID = SCOPE_IDENTITY()\r\n\r\n                                                declare @SItemCount int  \r\n                                                declare @SInvTyp int\r\n                                                declare @SMndID int\r\n                                                declare @SItemCountMnd int \r\n                                                declare @SRelation int\r\n                                                   \r\n                                                select @SRelation = InvId from T_INVDET where InvDet_ID = @SInvId;\r\n                                                select @SItemCount = Count(*) from T_STKSQTY where itmNo = @SItmNo and storeNo =@SStoreNo;\r\n                                                select @SInvTyp = InvTyp from T_INVHED where InvHed_ID = @SRelation;\r\n                                                if((@SInvTyp != 7 and @SInvTyp != 8 and @SInvTyp != 9 and @SInvTyp != 21) and @SItmTyp <> 3 and @SItmTyp <> 2)\r\n                                                begin\r\n\r\n                                                    Update T_Items SET OpenQty = OpenQty+@SRealQty WHERE Itm_No = @SItmNo;\r\n                                                    if(@SItemCount > 0)\r\n                                                    begin\r\n                                                    Update T_STKSQTY SET stkQty = stkQty+@SRealQty WHERE itmNo = @SItmNo and storeNo = @SStoreNo;\r\n                                                    end\r\n\r\n                                                    if(@SItemCount = 0)\r\n                                                    begin \r\n                                                    INSERT INTO T_STKSQTY(itmNo,storeNo,stkQty,stkInt) VALUES(@SItmNo,@SStoreNo,@SRealQty,0);\r\n                                                    END\r\n\r\n                                                    if(@SInvTyp = 14)\r\n                                                    begin\r\n                                                        Update T_STKSQTY SET stkInt = stkInt+@SRealQty WHERE itmNo = @SItmNo and storeNo = @SStoreNo;\r\n                                                    end\r\n\r\n                                                    select @SItemCount = Count(*) from T_QTYEXP where itmNo = @SItmNo and storeNo =@SStoreNo and DatExper = @SDatExper;\r\n\r\n                                                    if(@SItemCount > 0 and @SDatExper <> '')\r\n                                                    begin\r\n                                                    Update T_QTYEXP SET stkQty = stkQty+@SRealQty WHERE itmNo = @SItmNo and storeNo = @SStoreNo and DatExper = @SDatExper;\r\n                                                    end\r\n\r\n                                                    if(@SItemCount = 0 and @SDatExper <> '')\r\n                                                    begin \r\n                                                    INSERT INTO T_QTYEXP(itmNo,storeNo,DatExper,stkQty) VALUES(@SItmNo,@SStoreNo,@SDatExper,@SRealQty);\r\n                                                    END\r\n--                                                    if(@SInvTyp = 17)\r\n--                                                        begin\r\n--                                                         select @SMndID = MndNo from T_INVHED where InvHed_ID = @SRelation;\r\n--                                                            select @SItemCountMnd = Count(*) from T_StoreMnd where itmNo = @SItmNo and storeNo =@SStoreNo and MndNo = @SMndID;\r\n--                                                                    if(@SItemCountMnd > 0)\r\n--                                                                    begin\r\n--                                                                         Update T_StoreMnd SET stkQty = stkQty + abs(@SRealQty) WHERE itmNo = @SItmNo and storeNo = @SStoreNo and MndNo = @SMndID;\r\n--                                                                    end\r\n--\r\n--                                                                    if(@SItemCountMnd = 0)\r\n--                                                                    begin \r\n--                                                                         INSERT INTO T_StoreMnd(itmNo,storeNo,stkQty,stkInt,MndNo) VALUES(@SItmNo,@SStoreNo,abs(@SRealQty),0,@SMndID);\r\n--                                                                    END\r\n--                                                        end\t\r\n--                                                    if(@SInvTyp = 20)\r\n--                                                        begin\r\n--                                                         select @SMndID = MndNo from T_INVHED where InvHed_ID = @SRelation;\r\n--                                                            select @SItemCountMnd = Count(*) from T_StoreMnd where itmNo = @SItmNo and storeNo =@SStoreNo and MndNo = @SMndID;\r\n--                                                                    if(@SItemCountMnd > 0)\r\n--                                                                    begin\r\n--                                                                         Update T_StoreMnd SET stkQty = stkQty + (-@SRealQty) WHERE itmNo = @SItmNo and storeNo = @SStoreNo and MndNo = @SMndID;\r\n--                                                                    end\r\n--\r\n--                                                                    if(@SItemCountMnd = 0)\r\n--                                                                    begin \r\n--                                                                         INSERT INTO T_StoreMnd(itmNo,storeNo,stkQty,stkInt,MndNo) VALUES(@SItmNo,@SStoreNo,-@SRealQty,0,@SMndID);\r\n--                                                                    END\r\n--                                                        end\r\n                                                end\r\n\r\n\r\n                                              RETURN\r\n                                              END");
            }
            catch
            {
            }
            try
            {
                db.ExecuteCommand(DBUdate.DbUpdates.s10);
                // db.ExecuteCommand("ALTER PROCEDURE [dbo].[S_T_INVHED_INSERT](   \r\n                                                                     @InvHed_ID INT OUTPUT,\r\n                                                                     @InvId FLOAT =NULL,\r\n                                                                     @InvNo VARCHAR (10),\r\n                                                                     @InvTyp INT =NULL,\r\n                                                                     @InvCashPay INT =NULL,\r\n                                                                     @CusVenNo VARCHAR (20)=NULL,\r\n                                                                    @CusVenNm VARCHAR (50)=NULL,\r\n                                                     @CusVenMob VARCHAR (50)=NULL,\r\n                                                                     @CusVenAdd VARCHAR (100)=NULL,\r\n                                                                     @CusVenTel VARCHAR (30)=NULL,\r\n                                                                     @Remark VARCHAR (MAX)=NULL,\r\n                                                                     @HDat VARCHAR (10)=NULL,\r\n                                                                     @GDat VARCHAR (10)=NULL,\r\n                                                                     @MndNo INT =NULL,\r\n                                                                     @SalsManNo VARCHAR (3)=NULL,\r\n                                                                     @SalsManNam VARCHAR (50)=NULL,\r\n                                                                     @InvTot FLOAT =NULL,\r\n                                                                     @InvTotLocCur FLOAT =NULL,\r\n                                                                     @InvDisPrs FLOAT =NULL,\r\n                                                                     @InvDisVal FLOAT =NULL,\r\n                                                                     @InvDisValLocCur FLOAT =NULL,\r\n                                                                     @InvNet FLOAT =NULL,\r\n                                                                     @InvNetLocCur FLOAT =NULL,\r\n                                                                     @CashPay FLOAT =NULL,\r\n                                                                     @CashPayLocCur FLOAT =NULL,\r\n                                                                     @IfRet INT =NULL,\r\n                                                                     @GadeNo FLOAT =NULL,\r\n                                                                     @GadeId FLOAT =NULL,\r\n                                                                     @IfDel INT =NULL,\r\n                                                                     @RetNo VARCHAR (10)=NULL,\r\n                                                                     @RetId FLOAT =NULL,\r\n                                                                     @InvCstNo INT =NULL,\r\n                                                                     @InvCashPayNm VARCHAR (100)=NULL,\r\n                                                                     @RefNo VARCHAR (20)=NULL,\r\n                                                                     @InvCost FLOAT =NULL,\r\n                                                                     @EstDat VARCHAR (10)=NULL,\r\n                                                                     @CustPri INT =NULL,\r\n                                                                     @ArbTaf VARCHAR (150)=NULL,\r\n                                                                     @CurTyp INT =NULL,\r\n                                                                     @InvCash VARCHAR (20)=NULL,\r\n                                                                     @ToStore VARCHAR (3)=NULL,\r\n                                                                     @ToStoreNm VARCHAR (50)=NULL,\r\n                                                                     @InvQty FLOAT =NULL,\r\n                                                                     @EngTaf VARCHAR (150)=NULL,\r\n                                                                     @IfTrans INT =NULL,\r\n                                                                     @CustRep FLOAT =NULL,\r\n                                                                     @CustNet FLOAT =NULL,\r\n                                                                     @InvWight_T FLOAT =NULL,\r\n                                                                     @IfPrint INT =NULL,\r\n                                                                     @LTim VARCHAR (10)=NULL,\r\n                                                                     @CREATED_BY VARCHAR(100) =NULL,\r\n                                                                     @DATE_CREATED datetime =NULL,\r\n                                                                     @MODIFIED_BY VARCHAR (100)=NULL,\r\n                                                                     @DATE_MODIFIED datetime=NULL,\r\n                                                                     @CreditPay float=NULL,\r\n                                                                     @CreditPayLocCur float=NULL,\r\n                                                                     @NetworkPay float=NULL,\r\n                                                                     @NetworkPayLocCur float=NULL,\r\n                                                                     @CommMnd_Inv float=NULL,\r\n                                                                     @MndExtrnal bit=NULL,\r\n                                                                     @CompanyID int=NULL,\r\n                                                                     @InvAddCost float=NULL,\r\n                                                                     @InvAddCostLoc float=NULL,\r\n                                                                     @InvAddCostExtrnal float=NULL,\r\n                                                                     @InvAddCostExtrnalLoc float=NULL,\r\n                                                                     @IsExtrnalGaid bit=NULL,\r\n                                                                     @ExtrnalCostGaidID float=NULL,\r\n                                                                     @Puyaid float=NULL,\r\n                                                                     @Remming float=NULL,\r\n                                                                     @RoomNo int=NULL,\r\n                                                                     @OrderTyp int=NULL,\r\n                                                                     @RoomSts bit=NULL,\r\n                                                                     @chauffeurNo int=NULL,\r\n                                                                     @RoomPerson int=NULL,\r\n                                                                     @ServiceValue float=NULL,\r\n                                                                     @Sts bit=NULL,\r\n                                                                     @PaymentOrderTyp int=NULL,\r\n                                                                     @AdminLock bit=NULL,\r\n                                                                     @DeleteDate VARCHAR (10)=NULL,\r\n                                                                     @DeleteTime VARCHAR (10)=NULL,\r\n                                                                     @UserNew VARCHAR (3)=NULL,\r\n                                                                     @IfEnter int=NULL,\r\n                                                                     @InvAddTax float=NULL,\r\n                                                                     @InvAddTaxlLoc float=NULL,\r\n                                                                     @IsTaxGaid bit=NULL,\r\n                                                                     @TaxGaidID float=NULL,\r\n                                                                     @IsTaxUse bit=NULL,\r\n                                                                     @InvValGaidDis float=NULL,\r\n                                                                     @InvValGaidDislLoc float=NULL,\r\n                                                                     @IsDisGaid bit=NULL,\r\n                                                                     @DisGaidID1 float=NULL,\r\n                                                                     @IsDisUse1 bit=NULL,\r\n                                                                     @InvComm float=NULL,\r\n                                                                     @InvCommLoc float=NULL,\r\n                                                                     @IsCommGaid bit=NULL,\r\n                                                                     @CommGaidID float=NULL,\r\n                                                                     @IsCommUse bit=NULL,\r\n                                                                     @IsTaxLines bit=NULL,\r\n                                                                     @IsTaxByTotal bit=NULL,\r\n                                                                     @IsTaxByNet bit=NULL,\r\n                                                                     @TaxByNetValue float=NULL,\r\n                                                                     @DesPointsValue float=NULL,\r\n                                                                     @DesPointsValueLocCur float=NULL,\r\n                                                                     @PointsCount float=NULL,\r\n                                                                     @IsPoints bit=NULL,\r\n                                                                     @tailor1 VARCHAR (100)=NULL,\r\n                                                                     @tailor2 VARCHAR (100)=NULL,\r\n                                                                     @tailor3 VARCHAR (100)=NULL,\r\n                                                                     @tailor4 VARCHAR (100)=NULL,\r\n                                                                     @tailor5 VARCHAR (100)=NULL,\r\n                                                                     @tailor6 VARCHAR (100)=NULL,\r\n                                                                     @tailor7 VARCHAR (100)=NULL,\r\n                                                                     @tailor8 VARCHAR (100)=NULL,\r\n                                                                     @tailor9 VARCHAR (100)=NULL,\r\n                                                                     @tailor10 VARCHAR (100)=NULL,\r\n                                                                     @tailor11 VARCHAR (100)=NULL,\r\n                                                                     @tailor12 VARCHAR (100)=NULL,\r\n                                                                     @tailor13 VARCHAR (100)=NULL,\r\n                                                                     @tailor14 VARCHAR (100)=NULL,\r\n                                                                     @tailor15 VARCHAR (100)=NULL,\r\n                                                                     @tailor16 VARCHAR (100)=NULL,\r\n                                                                     @tailor17 VARCHAR (100)=NULL,\r\n                                                                     @tailor18 VARCHAR (100)=NULL,\r\n                                                                     @tailor19 VARCHAR (100)=NULL,\r\n                                                                     @tailor20 VARCHAR (100)=NULL,\r\n                                                                     @InvImg [varbinary](max) =NULL\r\n                                                              )\r\n                                                              AS\r\n                                                              BEGIN\r\n\r\n                                                              INSERT INTO T_INVHED(\r\n                                                                     InvId,\r\n                                                                     InvNo,\r\n                                                                     InvTyp,\r\n                                                                     InvCashPay,\r\n                                                                     CusVenNo,\r\n                                                                     CusVenNm,\r\n                                                                     HDat,\r\n                                                                     CusVenAdd,\r\n                                                                     CusVenTel,\r\n                                                                     Remark,\r\n                                                                     GDat,\r\n                                                                     MndNo,\r\n                                                                     SalsManNo,\r\n                                                                     SalsManNam,\r\n                                                                     InvTot,\r\n                                                                     InvTotLocCur,\r\n                                                                     InvDisPrs,\r\n                                                                     InvDisVal,\r\n                                                                     InvDisValLocCur,\r\n                                                                     InvNet,\r\n                                                                     InvNetLocCur,\r\n                                                                     CashPay,\r\n                                                                     CashPayLocCur,\r\n                                                                     IfRet,\r\n                                                                     GadeNo,\r\n                                                                     GadeId,\r\n                                                                     IfDel,\r\n                                                                     RetNo,\r\n                                                                     RetId,\r\n                                                                     InvCstNo,\r\n                                                                     InvCashPayNm,\r\n                                                                     RefNo,\r\n                                                                     InvCost,\r\n                                                                     EstDat,\r\n                                                                     CustPri,\r\n                                                                     ArbTaf,\r\n                                                                     CurTyp,\r\n                                                                     InvCash,\r\n                                                                     ToStore,\r\n                                                                     ToStoreNm,\r\n                                                                     InvQty,\r\n                                                                     EngTaf,\r\n                                                                     IfTrans,\r\n                                                                     CustRep,\r\n                                                                     CustNet,\r\n                                                                     InvWight_T,\r\n                                                                     IfPrint,\r\n                                                                     LTim,\r\n                                                                     CREATED_BY,\r\n                                                                     DATE_CREATED,\r\n                                                                     MODIFIED_BY ,\r\n                                                                     DATE_MODIFIED ,\r\n                                                                     CreditPay ,\r\n                                                                     CreditPayLocCur ,\r\n                                                                     NetworkPay ,\r\n                                                                     NetworkPayLocCur ,\r\n                                                                     CommMnd_Inv ,\r\n                                                                     MndExtrnal ,\r\n                                                                     CompanyID ,\r\n                                                                     InvAddCost ,\r\n                                                                     InvAddCostLoc ,\r\n                                                                     InvAddCostExtrnal ,\r\n                                                                     InvAddCostExtrnalLoc ,\r\n                                                                     IsExtrnalGaid ,\r\n                                                                     ExtrnalCostGaidID ,\r\n                                                                     Puyaid ,\r\n                                                                     Remming ,\r\n                                                                     RoomNo ,\r\n                                                                     OrderTyp ,\r\n                                                                     RoomSts ,\r\n                                                                     chauffeurNo ,\r\n                                                                     RoomPerson ,\r\n                                                                     ServiceValue ,\r\n                                                                     Sts ,\r\n                                                                     PaymentOrderTyp ,\r\n                                                                     AdminLock ,\r\n                                                                     DeleteDate ,\r\n                                                                     DeleteTime ,\r\n                                                                     UserNew ,\r\n                                                                     IfEnter ,\r\n                                                                     InvAddTax ,\r\n                                                                     InvAddTaxlLoc ,\r\n                                                                     IsTaxGaid ,\r\n                                                                     TaxGaidID ,\r\n                                                                     IsTaxUse ,\r\n                                                                     InvValGaidDis ,\r\n                                                                     InvValGaidDislLoc ,\r\n                                                                     IsDisGaid ,\r\n                                                                     DisGaidID1 ,\r\n                                                                     IsDisUse1 ,\r\n                                                                     InvComm ,\r\n                                                                     InvCommLoc ,\r\n                                                                     IsCommGaid ,\r\n                                                                     CommGaidID ,\r\n                                                                     IsCommUse ,\r\n                                                                     IsTaxLines ,\r\n                                                                     IsTaxByTotal ,\r\n                                                                     IsTaxByNet ,\r\n                                                                     TaxByNetValue ,\r\n                                                                     DesPointsValue ,\r\n                                                                     DesPointsValueLocCur ,\r\n                                                                     PointsCount,\r\n                                                                     IsPoints,\r\n                                                                     tailor1 ,\r\n                                                                     tailor2 ,\r\n                                                                     tailor3 ,\r\n                                                                     tailor4 ,\r\n                                                                     tailor5 ,\r\n                                                                     tailor6 ,\r\n                                                                     tailor7 ,\r\n                                                                     tailor8 ,\r\n                                                                     tailor9 ,\r\n                                                                     tailor10 ,\r\n                                                                     tailor11 ,\r\n                                                                     tailor12 ,\r\n                                                                     tailor13 ,\r\n                                                                     tailor14 ,\r\n                                                                     tailor15 ,\r\n                                                                     tailor16 ,\r\n                                                                     tailor17 ,\r\n                                                                     tailor18 ,\r\n                                                                     tailor19 ,\r\n                                                                     tailor20,\r\n                                                                     InvImg\r\n                                                              )\r\n                                                              VALUES\r\n                                                              (\r\n                                                                     \r\n                                                                    @InvId,\r\n                                                                    @InvNo,\r\n                                                                    @InvTyp,\r\n                                                                    @InvCashPay,\r\n                                                                    @CusVenNo,\r\n                                                                    @CusVenNm,\r\n                                                                    @HDat,\r\n                                                                    @CusVenAdd,\r\n                                                                    @CusVenTel,\r\n                                                                    @Remark,\r\n                                                                    @GDat,\r\n                                                                    @MndNo,\r\n                                                                    @SalsManNo,\r\n                                                                    @SalsManNam,\r\n                                                                    @InvTot,\r\n                                                                    @InvTotLocCur,\r\n                                                                    @InvDisPrs,\r\n                                                                    @InvDisVal,\r\n                                                                    @InvDisValLocCur,\r\n                                                                    @InvNet,\r\n                                                                    @InvNetLocCur,\r\n                                                                    @CashPay,\r\n                                                                    @CashPayLocCur,\r\n                                                                    @IfRet,\r\n                                                                    @GadeNo,\r\n                                                                    @GadeId,\r\n                                                                    @IfDel,\r\n                                                                    @RetNo,\r\n                                                                    @RetId,\r\n                                                                    @InvCstNo,\r\n                                                                    @InvCashPayNm,\r\n                                                                    @RefNo,\r\n                                                                    @InvCost,\r\n                                                                    @EstDat,\r\n                                                                    @CustPri,\r\n                                                                    @ArbTaf,\r\n                                                                    @CurTyp,\r\n                                                                    @InvCash,\r\n                                                                    @ToStore,\r\n                                                                    @ToStoreNm,\r\n                                                                    @InvQty,\r\n                                                                    @EngTaf,\r\n                                                                    @IfTrans,\r\n                                                                    @CustRep,\r\n                                                                    @CustNet,\r\n                                                                    @InvWight_T,\r\n                                                                    @IfPrint,\r\n                                                                    @LTim,\r\n                                                                    @CREATED_BY,\r\n                                                                    @DATE_CREATED,\r\n                                                                    @MODIFIED_BY ,\r\n                                                                    @DATE_MODIFIED ,\r\n                                                                    @CreditPay ,\r\n                                                                    @CreditPayLocCur ,\r\n                                                                    @NetworkPay ,\r\n                                                                    @NetworkPayLocCur ,\r\n                                                                    @CommMnd_Inv ,\r\n                                                                    @MndExtrnal ,\r\n                                                                    @CompanyID ,\r\n                                                                    @InvAddCost ,\r\n                                                                    @InvAddCostLoc ,\r\n                                                                    @InvAddCostExtrnal ,\r\n                                                                    @InvAddCostExtrnalLoc ,\r\n                                                                    @IsExtrnalGaid ,\r\n                                                                    @ExtrnalCostGaidID ,\r\n                                                                    @Puyaid ,\r\n                                                                    @Remming ,\r\n                                                                    @RoomNo ,\r\n                                                                    @OrderTyp ,\r\n                                                                    @RoomSts ,\r\n                                                                    @chauffeurNo ,\r\n                                                                    @RoomPerson ,\r\n                                                                    @ServiceValue ,\r\n                                                                    @Sts ,\r\n                                                                    @PaymentOrderTyp ,\r\n                                                                    @AdminLock ,\r\n                                                                    @DeleteDate ,\r\n                                                                    @DeleteTime ,\r\n                                                                    @UserNew ,\r\n                                                                    @IfEnter ,\r\n                                                                    @InvAddTax ,\r\n                                                                    @InvAddTaxlLoc ,\r\n                                                                    @IsTaxGaid ,\r\n                                                                    @TaxGaidID ,\r\n                                                                    @IsTaxUse ,\r\n                                                                    @InvValGaidDis ,\r\n                                                                    @InvValGaidDislLoc ,\r\n                                                                    @IsDisGaid ,\r\n                                                                    @DisGaidID1 ,\r\n                                                                    @IsDisUse1 ,\r\n                                                                    @InvComm ,\r\n                                                                    @InvCommLoc ,\r\n                                                                    @IsCommGaid ,\r\n                                                                    @CommGaidID ,\r\n                                                                    @IsCommUse ,\r\n                                                                    @IsTaxLines ,\r\n                                                                    @IsTaxByTotal ,\r\n                                                                    @IsTaxByNet ,\r\n                                                                    @TaxByNetValue ,\r\n                                                                    @DesPointsValue ,\r\n                                                                    @DesPointsValueLocCur ,\r\n                                                                    @PointsCount,\r\n                                                                    @IsPoints,\r\n                                                                    @tailor1 ,\r\n                                                                    @tailor2 ,\r\n                                                                    @tailor3 ,\r\n                                                                    @tailor4 ,\r\n                                                                    @tailor5 ,\r\n                                                                    @tailor6 ,\r\n                                                                    @tailor7 ,\r\n                                                                    @tailor8 ,\r\n                                                                    @tailor9 ,\r\n                                                                    @tailor10 ,\r\n                                                                    @tailor11 ,\r\n                                                                    @tailor12 ,\r\n                                                                    @tailor13 ,\r\n                                                                    @tailor14 ,\r\n                                                                    @tailor15 ,\r\n                                                                    @tailor16 ,\r\n                                                                    @tailor17 ,\r\n                                                                    @tailor18 ,\r\n                                                                    @tailor19 ,\r\n                                                                    @tailor20,\r\n                                                                    @InvImg\r\n                                                              )\r\n\r\n\r\n                                                              SELECT @InvHed_ID = SCOPE_IDENTITY()\r\n                                                                      \r\n\r\n                                                              RETURN\r\n                                                              END");
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (SqlException ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                // MessageBox.Show(ex.Message);
            }

            try
            {
                db.ExecuteCommand("update T_Items set T_Items.OpenQty = 0 where T_Items.Itm_No not in (select itmNo from T_STKSQTY) and T_Items.OpenQty > 0");
            }
            catch
            {
            }
            VarGeneral.BranchNumber = id;
            VarGeneral.ChangBr_ = true;
            new FrmMain(null, null, VarGeneral.BranchNumber, 0);
        }
        public static void CreateRegKey(string mainkey, string key, string defaultvalue)
        {
            RegistryKey hKeyNeew1 = Registry.CurrentUser.OpenSubKey(mainkey, writable: true);

            try
            {
                hKeyNeew1.CreateSubKey(key);
                hKeyNeew1.SetValue(key, defaultvalue);
            }
            catch
            {
                return;
            }

        }

        public static void setkeyvalue(string mainkey, string key, string defaultvalue)
        {
            RegistryKey hKeyNeew1 = Registry.CurrentUser.OpenSubKey(mainkey, writable: true);
            try
            {

                hKeyNeew1.SetValue(key, defaultvalue);
            }
            catch
            {
                return;
            }
        }
        public static string ReadRegKey(string mainkey, string value)
        {
            RegistryKey hKeyNeew1 = Registry.CurrentUser.OpenSubKey(mainkey, writable: true);
            string bno = "";
            try
            {
                object q = hKeyNeew1.GetValue(value);
                bno = q.ToString();
            }
            catch
            {
                return "NA";
            }
            return bno;
        }
        public void ExecuteNonQueryBatch(string connectionString, string sqlStatements)
        {
            if (sqlStatements == null) throw new ArgumentNullException("sqlStatements");
            if (connectionString == null) throw new ArgumentNullException("connectionString");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                ServerConnection srvCon = new ServerConnection(connection);
                Server srv = new Server(srvCon);
                Database db = srv.Databases[connection.Database];
                StoredProcedure sp = new StoredProcedure(db, "S_T_INVHED_INSERT");
                sp.TextMode = false;
                sp.AnsiNullsStatus = false;
                sp.QuotedIdentifierStatus = true;
                sp.ImplementationType = ImplementationType.TransactSql;
                sp.Schema = "dbo";
                sp.Refresh();
                //sp.TextBody = billinsertbodypro;
                // sp.Alter();
            }
        }
        void alterprocedure()
        {
            SqlConnection sqlCon = new SqlConnection(VarGeneral.BranchCS);
            ServerConnection srvCon = new ServerConnection(sqlCon);
            sqlCon.Open();
            Server srv = new Server(srvCon);
            Database db = srv.Databases[sqlCon.Database];
            StoredProcedure sp = new StoredProcedure(db, "S_T_INVHED_INSERT");
            sp.TextMode = false;
            sp.AnsiNullsStatus = false;
            sp.QuotedIdentifierStatus = false;
            //Add two parameters.   
            StoredProcedureParameter param;
            param = new StoredProcedureParameter(sp, "@CustVenMob", DataType.Int);
            sp.Parameters.Add(param);

            //Set the TextBody property to define the stored procedure.   
#pragma warning disable CS0219 // The variable 'stmt' is assigned but its value is never used
            string stmt;
#pragma warning restore CS0219 // The variable 'stmt' is assigned but its value is never used
            stmt = " SELECT @retval = (SELECT LastName FROM Person.Person,HumanResources.Employee WHERE Person.Person.BusinessEntityID = HumanResources.Employee.BusinessentityID AND HumanResources.Employee.BusinessEntityID = @empval )";
            //  sp.TextBody = billinsertbodypro;
            //Create the stored procedure on the instance of SQL Server.   
            sp.Create();
            //Modify a property and run the Alter method to make the change on the instance of SQL Server.   
            sp.QuotedIdentifierStatus = true;
            sp.Alter();
        }
        void createpr()
        {
            SqlConnection conn = new SqlConnection(VarGeneral.BranchCS);
            Server server = new Server(new ServerConnection(conn));
            try
            {
                server.ConnectionContext.ExecuteNonQuery(DbUpdates.s1);
            }
            catch
            {
            }
        }
        public int getvertionnumber(string con)
        {
            SqlConnection connection = new SqlConnection(con);
            SqlCommand cmd = new SqlCommand(VScript, connection);
            SqlCommand cmd2 = new SqlCommand("select DAVersion From T_DAVersion;", connection)
                ;
            DataTable d = new DataTable();
            try
            {
                connection.Open();
            }
            catch { return -1; }
            { cmd.ExecuteNonQuery(); }

            d.Load(cmd2.ExecuteReader());

            connection.Close();
            try
            {
                return int.Parse(d.Rows[0][0].ToString());
            }
            catch { return 0; }
        }
        public static void setdataBaseVersion(int i, string con)
        {
            SqlConnection connection = new SqlConnection(con);
            SqlCommand cmd = new SqlCommand("Update T_DAVersion SET DAVersion =@id", connection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = i;
            try
            {
                connection.Open();
            }
            catch { }
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch { }
            connection.Close();
        }
        string VScript = @"IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[T_DAVersion]') AND type in (N'U'))
BEGIN
 CREATE TABLE[dbo].[T_DAVersion]
        (

   [DAVersion][int] NULL
) ON[PRIMARY]
insert into dbo.T_DAVersion(DAVersion) Values(0);
        END";
        public static string alterusersettings = @"BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.T_INVHED
	DROP CONSTRAINT FK_T_INVHED_T_INVSETTING
GO
ALTER TABLE dbo.T_BankPeaper
	DROP CONSTRAINT FK_T_BankPeaper_T_INVSETTING
GO

GO
ALTER TABLE dbo.T_INVSETTING
	DROP CONSTRAINT PK_T_INVSETTING
GO
ALTER TABLE dbo.T_INVSETTING SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.T_BankPeaper SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.T_INVHED SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
";
        public static string draftbillup = @"INSERT INTO [T_INVSETTING]
           ([InvID]
           ,[InvNamA]
           ,[InvNamE]
         ) Values (101,'فاتورة معلقة','SaveOverBill') ;";
        public static string S_T_INVHED_INSERT_DRAFT = @"ALTER PROCEDURE[dbo].[S_T_INVHED_INSERT]
        (
                                                                    @InvHed_ID INT OUTPUT,
                                                                    @InvId FLOAT =NULL,
                                                                     @InvNo VARCHAR(10),
                                                                     @InvTyp INT = NULL,
                                                                     @InvCashPay INT =NULL,
                                                                     @CusVenNo VARCHAR(20)=NULL,
                                                                     @CusVenNm VARCHAR(50)=NULL,
                                                                     @CusVenAdd VARCHAR(100)=NULL,
                                                                     @CusVenTel VARCHAR(30)=NULL,
                                                                     @Remark VARCHAR(MAX)=NULL,
                                                                     @HDat VARCHAR(10)=NULL,
                                                                     @GDat VARCHAR(10)=NULL,
                                                                     @MndNo INT = NULL,
                                                                     @SalsManNo VARCHAR(3)=NULL,
                                                                     @SalsManNam VARCHAR(50)=NULL,
                                                                     @InvTot FLOAT = NULL,
                                                                     @InvTotLocCur FLOAT =NULL,
                                                                     @InvDisPrs FLOAT = NULL,
                                                                     @InvDisVal FLOAT =NULL,
                                                                     @InvDisValLocCur FLOAT = NULL,
                                                                     @InvNet FLOAT =NULL,
                                                                     @InvNetLocCur FLOAT = NULL,
                                                                     @CashPay FLOAT =NULL,
                                                                     @CashPayLocCur FLOAT = NULL,
                                                                     @IfRet INT =NULL,
                                                                     @GadeNo FLOAT = NULL,
                                                                     @GadeId FLOAT =NULL,
                                                                     @IfDel INT = NULL,
                                                                     @RetNo VARCHAR(10)=NULL,
                                                                     @RetId FLOAT = NULL,
                                                                     @InvCstNo INT =NULL,
                                                                     @InvCashPayNm VARCHAR(100)=NULL,
                                                                     @RefNo VARCHAR(20)=NULL,
                                                                     @InvCost FLOAT = NULL,
                                                                     @EstDat VARCHAR(10)=NULL,
                                                                     @CustPri INT = NULL,
                                                                     @ArbTaf VARCHAR(150)=NULL,
                                                                     @CurTyp INT = NULL,
                                                                     @InvCash VARCHAR(20)=NULL,
                                                                     @ToStore VARCHAR(3)=NULL,
                                                                     @ToStoreNm VARCHAR(50)=NULL,
                                                                     @InvQty FLOAT = NULL,
                                                                     @EngTaf VARCHAR(150)=NULL,
                                                                     @IfTrans INT = NULL,
                                                                     @CustRep FLOAT =NULL,
                                                                     @CustNet FLOAT = NULL,
                                                                     @InvWight_T FLOAT =NULL,
                                                                     @IfPrint INT = NULL,
                                                                     @LTim VARCHAR(10)=NULL,
                                                                     @CREATED_BY VARCHAR(100) =NULL,
                                                                     @DATE_CREATED datetime = NULL,
                                                                     @MODIFIED_BY VARCHAR(100)=NULL,
                                                                     @DATE_MODIFIED datetime = NULL,
                                                                     @CreditPay float=NULL,
                                                                     @CreditPayLocCur float=NULL,
                                                                     @NetworkPay float=NULL,
                                                                     @NetworkPayLocCur float=NULL,
                                                                     @CommMnd_Inv float=NULL,
                                                                     @MndExtrnal bit = NULL,
                                                                     @CompanyID int=NULL,
                                                                     @InvAddCost float=NULL,
                                                                     @InvAddCostLoc float=NULL,
                                                                     @InvAddCostExtrnal float=NULL,
                                                                     @InvAddCostExtrnalLoc float=NULL,
                                                                     @IsExtrnalGaid bit = NULL,
                                                                     @ExtrnalCostGaidID float=NULL,
                                                                     @Puyaid float=NULL,
                                                                     @Remming float=NULL,
                                                                     @RoomNo int=NULL,
                                                                     @OrderTyp int=NULL,
                                                                     @RoomSts bit = NULL,
                                                                     @chauffeurNo int=NULL,
                                                                     @RoomPerson int=NULL,
                                                                     @ServiceValue float=NULL,
                                                                     @Sts bit = NULL,
                                                                     @PaymentOrderTyp int=NULL,
                                                                     @AdminLock bit = NULL,
                                                                     @DeleteDate VARCHAR(10)=NULL,
                                                                     @DeleteTime VARCHAR(10)=NULL,
                                                                     @UserNew VARCHAR(3)=NULL,
                                                                     @IfEnter int=NULL,
                                                                     @InvAddTax float=NULL,
                                                                     @InvAddTaxlLoc float=NULL,
                                                                     @IsTaxGaid bit = NULL,
                                                                     @TaxGaidID float=NULL,
                                                                     @IsTaxUse bit = NULL,
                                                                     @InvValGaidDis float=NULL,
                                                                     @InvValGaidDislLoc float=NULL,
                                                                     @IsDisGaid bit = NULL,
                                                                     @DisGaidID1 float=NULL,
                                                                     @IsDisUse1 bit = NULL,
                                                                     @InvComm float=NULL,
                                                                     @InvCommLoc float=NULL,
                                                                     @IsCommGaid bit = NULL,
                                                                     @CommGaidID float=NULL,
                                                                     @IsCommUse bit = NULL,
                                                                     @IsTaxLines bit=NULL,
                                                                     @IsTaxByTotal bit = NULL,
                                                                     @IsTaxByNet bit=NULL,
                                                                     @TaxByNetValue float=NULL,
                                                                     @DesPointsValue float=NULL,
                                                                     @DesPointsValueLocCur float=NULL,
                                                                     @PointsCount float=NULL,
                                                                     @IsPoints bit = NULL,
                                                                     @tailor1 VARCHAR(100)=NULL,
                                                                     @tailor2 VARCHAR(100)=NULL,
                                                                     @tailor3 VARCHAR(100)=NULL,
                                                                     @tailor4 VARCHAR(100)=NULL,
                                                                     @tailor5 VARCHAR(100)=NULL,
                                                                     @tailor6 VARCHAR(100)=NULL,
                                                                     @tailor7 VARCHAR(100)=NULL,
                                                                     @tailor8 VARCHAR(100)=NULL,
                                                                     @tailor9 VARCHAR(100)=NULL,
                                                                     @tailor10 VARCHAR(100)=NULL,
                                                                     @tailor11 VARCHAR(100)=NULL,
                                                                     @tailor12 VARCHAR(100)=NULL,
                                                                     @tailor13 VARCHAR(100)=NULL,
                                                                     @tailor14 VARCHAR(100)=NULL,
                                                                     @tailor15 VARCHAR(100)=NULL,
                                                                     @tailor16 VARCHAR(100)=NULL,
                                                                     @tailor17 VARCHAR(100)=NULL,
                                                                     @tailor18 VARCHAR(100)=NULL,
                                                                     @tailor19 VARCHAR(100)=NULL,
                                                                     @tailor20 VARCHAR(100)=NULL,
                                                                     @InvImg[varbinary] (max) =NULL,
                                                                     @CusVenMob VARCHAR(50) =NULL,
                                                                     @PriceIncludeTax BIT = NULL,
																	 @CInvType INT =NULL
                                                              )
                                                              AS
                                                              BEGIN
                                                              INSERT INTO T_INVHED(
                                                                     InvId,
                                                                     InvNo,
                                                                     InvTyp,
                                                                     InvCashPay,
                                                                     CusVenNo,
                                                                     CusVenNm,
                                                                     HDat,
                                                                     CusVenAdd,
                                                                     CusVenTel,
                                                                     Remark,
                                                                     GDat,
                                                                     MndNo,
                                                                     SalsManNo,
                                                                     SalsManNam,
                                                                     InvTot,
                                                                     InvTotLocCur,
                                                                     InvDisPrs,
                                                                     InvDisVal,
                                                                     InvDisValLocCur,
                                                                     InvNet,
                                                                     InvNetLocCur,
                                                                     CashPay,
                                                                     CashPayLocCur,
                                                                     IfRet,
                                                                     GadeNo,
                                                                     GadeId,
                                                                     IfDel,
                                                                     RetNo,
                                                                     RetId,
                                                                     InvCstNo,
                                                                     InvCashPayNm,
                                                                     RefNo,
                                                                     InvCost,
                                                                     EstDat,
                                                                     CustPri,
                                                                     ArbTaf,
                                                                     CurTyp,
                                                                     InvCash,
                                                                     ToStore,
                                                                     ToStoreNm,
                                                                     InvQty,
                                                                     EngTaf,
                                                                     IfTrans,
                                                                     CustRep,
                                                                     CustNet,
                                                                     InvWight_T,
                                                                     IfPrint,
                                                                     LTim,
                                                                     CREATED_BY,
                                                                     DATE_CREATED,
                                                                     MODIFIED_BY ,
                                                                     DATE_MODIFIED ,
                                                                     CreditPay ,
                                                                     CreditPayLocCur ,
                                                                     NetworkPay ,
                                                                     NetworkPayLocCur ,
                                                                     CommMnd_Inv ,
                                                                     MndExtrnal ,
                                                                     CompanyID ,
                                                                     InvAddCost ,
                                                                     InvAddCostLoc ,
                                                                     InvAddCostExtrnal ,
                                                                     InvAddCostExtrnalLoc ,
                                                                     IsExtrnalGaid ,
                                                                     ExtrnalCostGaidID ,
                                                                     Puyaid ,
                                                                     Remming ,
                                                                     RoomNo ,
                                                                     OrderTyp ,
                                                                     RoomSts ,
                                                                     chauffeurNo ,
                                                                     RoomPerson ,
                                                                     ServiceValue ,
                                                                     Sts ,
                                                                     PaymentOrderTyp ,
                                                                     AdminLock ,
                                                                     DeleteDate ,
                                                                     DeleteTime ,
                                                                     UserNew ,
                                                                     IfEnter ,
                                                                     InvAddTax ,
                                                                     InvAddTaxlLoc ,
                                                                     IsTaxGaid ,
                                                                     TaxGaidID ,
                                                                     IsTaxUse ,
                                                                     InvValGaidDis ,
                                                                     InvValGaidDislLoc ,
                                                                     IsDisGaid ,
                                                                     DisGaidID1 ,
                                                                     IsDisUse1 ,
                                                                     InvComm ,
                                                                     InvCommLoc ,
                                                                     IsCommGaid ,
                                                                     CommGaidID ,
                                                                     IsCommUse ,
                                                                     IsTaxLines ,
                                                                     IsTaxByTotal ,
                                                                     IsTaxByNet ,
                                                                     TaxByNetValue ,
                                                                     DesPointsValue ,
                                                                     DesPointsValueLocCur ,
                                                                     PointsCount,
                                                                     IsPoints,
                                                                     tailor1 ,
                                                                     tailor2 ,
                                                                     tailor3 ,
                                                                     tailor4 ,
                                                                     tailor5 ,
                                                                     tailor6 ,
                                                                     tailor7 ,
                                                                     tailor8 ,
                                                                     tailor9 ,
                                                                     tailor10 ,
                                                                     tailor11 ,
                                                                     tailor12 ,
                                                                     tailor13 ,
                                                                     tailor14 ,
                                                                     tailor15 ,
                                                                     tailor16 ,
                                                                     tailor17 ,
                                                                     tailor18 ,
                                                                     tailor19 ,
                                                                     tailor20,
                                                                     InvImg,
                                                                     CusVenMob,
                                                                     PriceIncludTax,
																	 CInvType
                                                              )
                                                              VALUES
                                                              (
                                                                    @InvId,
                                                                    @InvNo,
                                                                    @InvTyp,
                                                                    @InvCashPay,
                                                                    @CusVenNo,
                                                                    @CusVenNm,
                                                                    @HDat,
                                                                    @CusVenAdd,
                                                                    @CusVenTel,
                                                                    @Remark,
                                                                    @GDat,
                                                                    @MndNo,
                                                                    @SalsManNo,
                                                                    @SalsManNam,
                                                                    @InvTot,
                                                                    @InvTotLocCur,
                                                                    @InvDisPrs,
                                                                    @InvDisVal,
                                                                    @InvDisValLocCur,
                                                                    @InvNet,
                                                                    @InvNetLocCur,
                                                                    @CashPay,
                                                                    @CashPayLocCur,
                                                                    @IfRet,
                                                                    @GadeNo,
                                                                    @GadeId,
                                                                    @IfDel,
                                                                    @RetNo,
                                                                    @RetId,
                                                                    @InvCstNo,
                                                                    @InvCashPayNm,
                                                                    @RefNo,
                                                                    @InvCost,
                                                                    @EstDat,
                                                                    @CustPri,
                                                                    @ArbTaf,
                                                                    @CurTyp,
                                                                    @InvCash,
                                                                    @ToStore,
                                                                    @ToStoreNm,
                                                                    @InvQty,
                                                                    @EngTaf,
                                                                    @IfTrans,
                                                                    @CustRep,
                                                                    @CustNet,
                                                                    @InvWight_T,
                                                                    @IfPrint,
                                                                    @LTim,
                                                                    @CREATED_BY,
                                                                    @DATE_CREATED,
                                                                    @MODIFIED_BY ,
                                                                    @DATE_MODIFIED ,
                                                                    @CreditPay ,
                                                                    @CreditPayLocCur ,
                                                                    @NetworkPay ,
                                                                    @NetworkPayLocCur ,
                                                                    @CommMnd_Inv ,
                                                                    @MndExtrnal ,
                                                                    @CompanyID ,
                                                                    @InvAddCost ,
                                                                    @InvAddCostLoc ,
                                                                    @InvAddCostExtrnal ,
                                                                    @InvAddCostExtrnalLoc ,
                                                                    @IsExtrnalGaid ,
                                                                    @ExtrnalCostGaidID ,
                                                                    @Puyaid ,
                                                                    @Remming ,
                                                                    @RoomNo ,
                                                                    @OrderTyp ,
                                                                    @RoomSts ,
                                                                    @chauffeurNo ,
                                                                    @RoomPerson ,
                                                                    @ServiceValue ,
                                                                    @Sts ,
                                                                    @PaymentOrderTyp ,
                                                                    @AdminLock ,
                                                                    @DeleteDate ,
                                                                    @DeleteTime ,
                                                                    @UserNew ,
                                                                    @IfEnter ,
                                                                    @InvAddTax ,
                                                                    @InvAddTaxlLoc ,
                                                                    @IsTaxGaid ,
                                                                    @TaxGaidID ,
                                                                    @IsTaxUse ,
                                                                    @InvValGaidDis ,
                                                                    @InvValGaidDislLoc ,
                                                                    @IsDisGaid ,
                                                                    @DisGaidID1 ,
                                                                    @IsDisUse1 ,
                                                                    @InvComm ,
                                                                    @InvCommLoc ,
                                                                    @IsCommGaid ,
                                                                    @CommGaidID ,
                                                                    @IsCommUse ,
                                                                    @IsTaxLines ,
                                                                    @IsTaxByTotal ,
                                                                    @IsTaxByNet ,
                                                                    @TaxByNetValue ,
                                                                    @DesPointsValue ,
                                                                    @DesPointsValueLocCur ,
                                                                    @PointsCount,
                                                                    @IsPoints,
                                                                    @tailor1 ,
                                                                    @tailor2 ,
                                                                    @tailor3 ,
                                                                    @tailor4 ,
                                                                    @tailor5 ,
                                                                    @tailor6 ,
                                                                    @tailor7 ,
                                                                    @tailor8 ,
                                                                    @tailor9 ,
                                                                    @tailor10 ,
                                                                    @tailor11 ,
                                                                    @tailor12 ,
                                                                    @tailor13 ,
                                                                    @tailor14 ,
                                                                    @tailor15 ,
                                                                    @tailor16 ,
                                                                    @tailor17 ,
                                                                    @tailor18 ,
                                                                    @tailor19 ,
                                                                    @tailor20,
                                                                    @InvImg,
                                                                    @CusVenMob,
                                                                    @PriceIncludeTax,
																	@CInvType
                                                              )
                                                              SELECT @InvHed_ID = SCOPE_IDENTITY()
                                                              RETURN 
                                                              END;";
        public static string S_T_INVDET_INSERT_ALTER_DRAFT = @"ALTER PROCEDURE [dbo].[S_T_INVDET_INSERT](   
                                                                 @InvDet_ID INT OUTPUT,
                                                                 @InvNo VARCHAR (10)=NULL,
                                                                 @InvId INT =NULL,
                                                                 @InvSer INT =NULL,
                                                                 @ItmNo VARCHAR (50)=NULL,
                                                                 @Cost FLOAT =NULL,
                                                                 @Qty FLOAT =NULL,
                                                                 @ItmDes VARCHAR (50)=NULL,
                                                                 @ItmUnt VARCHAR (100)=NULL,
                                                                 @ItmDesE VARCHAR (50)=NULL,
                                                                 @ItmUntE VARCHAR (100)=NULL,
                                                                 @ItmUntPak FLOAT =NULL,
                                                                 @StoreNo INT=NULL,
                                                                 @Price FLOAT =NULL,
                                                                 @Amount FLOAT =NULL,
                                                                 @RealQty FLOAT =NULL,
                                                                 @itmInvDsc FLOAT =NULL,
                                                                 @DatExper VARCHAR (11)=NULL,
                                                                 @ItmDis FLOAT =NULL,
                                                                 @ItmTyp INT =NULL,
                                                                 @ItmIndex INT =NULL,
                                                                 @ItmWight FLOAT =NULL,
                                                                 @ItmWight_T FLOAT =NULL,
                                                                 @ItmAddCost FLOAT =NULL,
                                                                 @RunCod VARCHAR (100)=NULL,
                                                                 @LineDetails VARCHAR (250)=NULL,
                                                                 @Serial_Key VARCHAR (100)=NULL,
                                                                 @ItmTax FLOAT =NULL,
                                                                 @OfferTyp INT =NULL,
																 @CInvType INT =NULL,
@CaExState INT =0
                                                          )
                                                          AS
                                                          BEGIN
                                                          INSERT INTO T_INVDET(
                                                                 InvNo,
                                                                 InvId,
                                                                 InvSer,
                                                                 ItmNo,
                                                                 Cost,
                                                                 Qty,
                                                                 ItmDes,
                                                                 ItmUnt,
                                                                 ItmDesE,
                                                                 ItmUntE,
                                                                 ItmUntPak,
                                                                 StoreNo,
                                                                 Price,
                                                                 Amount,
                                                                 RealQty,
                                                                 itmInvDsc,
                                                                 DatExper,
                                                                 ItmDis,
                                                                 ItmTyp,
                                                                 ItmIndex,
                                                                 ItmWight,
                                                                 ItmWight_T,
                                                                 ItmAddCost,
                                                                 RunCod,
                                                                 LineDetails,
                                                                 Serial_Key,
                                                                 ItmTax,
                                                                OfferTyp ,
																CInvType,
CaExState
                                                          )
                                                          VALUES
                                                          (
                                                                 
                                                                @InvNo,
                                                                @InvId,
                                                                @InvSer,
                                                                @ItmNo,
                                                                @Cost,
                                                                @Qty,
                                                                @ItmDes,
                                                                @ItmUnt,
                                                                @ItmDesE,
                                                                @ItmUntE,
                                                                @ItmUntPak,
                                                                @StoreNo,
                                                                @Price,
                                                                @Amount,
                                                                @RealQty,
                                                                @itmInvDsc,
                                                                @DatExper,
                                                                @ItmDis,
                                                                @ItmTyp,
                                                                @ItmIndex,
                                                                @ItmWight,
                                                                @ItmWight_T,
                                                                @ItmAddCost,
                                                                @RunCod,
                                                                @LineDetails,
                                                                @Serial_Key,
                                                                @ItmTax,
                                                                @OfferTyp,
																@CInvType
,@CaExState
                                                          )
                                                          SELECT @InvDet_ID = SCOPE_IDENTITY()
                                                            declare @ItemCount int  
                                                            declare @InvTyp int
                                                            declare @MndID int
                                                            declare @CusVenNo varchar(30)
                                                            declare @ItemCountMnd int 
                                                            declare @ItemCountCust int 
		                                                    select @ItemCount = Count(*) from T_STKSQTY where itmNo = @ItmNo and storeNo =@StoreNo;
                                                            select @InvTyp = InvTyp from T_INVHED where InvHed_ID = @InvId;
                                                            if((@InvTyp !=-101
AND @InvTyp != 7 and @InvTyp != 8 and @InvTyp != 9 and @InvTyp != 21) and @ItmTyp <> 3)
                                                            begin
			                                                          if(@ItmTyp <> 2)
			                                                          begin
		                                                                    Update T_Items SET OpenQty = OpenQty+@RealQty WHERE Itm_No = @ItmNo;
			                                                                if(@ItemCount > 0)
			                                                                begin
			                                                                Update T_STKSQTY SET stkQty = stkQty+@RealQty WHERE itmNo = @ItmNo and storeNo = @StoreNo;
			                                                                end
			                                                                if(@ItemCount = 0)
			                                                                begin 
			                                                                INSERT INTO T_STKSQTY(itmNo,storeNo,stkQty,stkInt) VALUES(@ItmNo,@StoreNo,@RealQty,0);
			                                                                END
                                                                            if(@InvTyp = 14)
                                                                            begin
				                                                                Update T_STKSQTY SET stkInt = stkInt+@RealQty WHERE itmNo = @ItmNo and storeNo = @StoreNo;
                                                                            end
			                                                                select @ItemCount = Count(*) from T_QTYEXP where itmNo = @ItmNo and storeNo =@StoreNo and (DatExper = @DatExper and RunCod = @RunCod);
			                                                                if(@ItemCount > 0 and (@DatExper <> '' or @RunCod <> ''))
			                                                                begin
			                                                                Update T_QTYEXP SET stkQty = stkQty+@RealQty WHERE itmNo = @ItmNo and storeNo = @StoreNo and (DatExper = @DatExper and RunCod = @RunCod);
			                                                                end
			                                                                if(@ItemCount = 0 and (@DatExper <> '' or @RunCod <> ''))
			                                                                begin 
			                                                                INSERT INTO T_QTYEXP(itmNo,storeNo,DatExper,stkQty,RunCod) VALUES(@ItmNo,@StoreNo,@DatExper,@RealQty,@RunCod);
			                                                                END
                                                                END
			                                                          if(@InvTyp = 17)
				                                                          begin
														                       select @MndID = MndNo from T_INVHED where InvHed_ID = @InvId;
														                       select @CusVenNo = CusVenNo from T_INVHED where InvHed_ID = @InvId;
														                       if(@MndID > 0 )
															                    begin
															                              select @ItemCountMnd = Count(*) from T_StoreMnd where itmNo = @ItmNo and storeNo =@StoreNo and MndNo = @MndID;
																	                      if(@ItemCountMnd > 0)
																	                      begin
																		                       Update T_StoreMnd SET stkQty = stkQty + abs(@RealQty) WHERE itmNo = @ItmNo and storeNo = @StoreNo and MndNo = @MndID;
																	                      end
																	                      if(@ItemCountMnd = 0)
																	                      begin 
																		                       INSERT INTO T_StoreMnd(itmNo,storeNo,stkQty,stkInt,MndNo) VALUES(@ItmNo,@StoreNo,abs(@RealQty),0,@MndID);
																	                      END
															                    END
														                      else
									                                            begin
															                             select @ItemCountCust = Count(*) from T_StoreMnd where itmNo = @ItmNo and storeNo =@StoreNo and CusVenNo = @CusVenNo;
																	                      if(@ItemCountCust > 0)
																	                      begin
																		                       Update T_StoreMnd SET stkQty = stkQty + abs(@RealQty) WHERE itmNo = @ItmNo and storeNo = @StoreNo and CusVenNo = @CusVenNo;
																	                      end
																	                      if(@ItemCountCust = 0)
																	                      begin 
																		                       INSERT INTO T_StoreMnd(itmNo,storeNo,stkQty,stkInt,CusVenNo) VALUES(@ItmNo,@StoreNo,abs(@RealQty),0,@CusVenNo);
																	                      END
															                    END
				                                                          END	
			                                                          if(@InvTyp = 20)
				                                                          begin
				                                                              select @MndID = MndNo from T_INVHED where InvHed_ID = @InvId;
														                      select @CusVenNo = CusVenNo from T_INVHED where InvHed_ID = @InvId;
														                        if(@MndID > 0 )
																                    begin
																	                     select @ItemCountMnd = Count(*) from T_StoreMnd where itmNo = @ItmNo and storeNo =@StoreNo and MndNo = @MndID;
																	                      if(@ItemCountMnd > 0)
																	                      begin
																		                       Update T_StoreMnd SET stkQty = stkQty + (-@RealQty) WHERE itmNo = @ItmNo and storeNo = @StoreNo and MndNo = @MndID;
																	                      end
																	                      if(@ItemCountMnd = 0)
																	                      begin 
																		                       INSERT INTO T_StoreMnd(itmNo,storeNo,stkQty,stkInt,MndNo) VALUES(@ItmNo,@StoreNo,-@RealQty,0,@MndID);
																	                      END
																                     END
							                                                     else
							                                                         begin
																	                     select @ItemCountCust = Count(*) from T_StoreMnd where itmNo = @ItmNo and storeNo =@StoreNo and CusVenNo = @CusVenNo;
																	                      if(@ItemCountCust > 0)
																	                      begin
																		                       Update T_StoreMnd SET stkQty = stkQty + (-@RealQty) WHERE itmNo = @ItmNo and storeNo = @StoreNo and CusVenNo = @CusVenNo;
																	                      end
																	                      if(@ItemCountCust = 0)
																	                      begin 
																		                       INSERT INTO T_StoreMnd(itmNo,storeNo,stkQty,stkInt,CusVenNo) VALUES(@ItmNo,@StoreNo,-@RealQty,0,@CusVenNo);
																	                      END
																                     END
				                                                          end
                                                            end
                                                          RETURN @InvDet_ID
                                                          END";
        public static void adddraft()
        {
            SqlConnection connection = new SqlConnection(VarGeneral.BranchCS);
            SqlCommand cmd = new SqlCommand(draftbillup, connection);

            try
            {
                connection.Open();
            }
            catch { }
            try
            {

                cmd.ExecuteNonQuery();

            }

            catch { }
            connection.Close();


        }
        public static string getResourceDbFileVersion(string sa)
        {
            string ver = "";
            int sf = sa.LastIndexOf("(dbv) values ('db");
            try
            {
                if (sf != -1)
                {
                    for (int i = sf + 17; i < sa.Length; i++)
                        if (sa[i] == '\'')
                            break;
                        else
                            ver += sa[i];
                    return ver.Replace(".", "");
                }
                return "-1";
            }
            catch { return "-1"; }

        }
        public static void executes(string s, string con)
        {
            SqlConnection connection = new SqlConnection(con);
            SqlCommand cmd = new SqlCommand(s, connection);
            try
            {
                connection.Open();
            }
            catch { }
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch { }
            connection.Close();

        }
        public bool gettest(string s, string con)
        {
            SqlConnection connection = new SqlConnection(con);
            SqlCommand cmd = new SqlCommand(s, connection);
            //  cmd.Parameters.Add("@id", SqlDbType.Int).Value = i;
            try
            {
                connection.Open();
            }
            catch { }
            DataTable t = new DataTable();
            try
            {
                t.Load(cmd.ExecuteReader());
            }
            catch { return false; }
            connection.Close();

            if (t.Rows.Count == 0)
                return false;
            else
                return true;
        }
        public static DataTable execute(string s, string con)
        {
            DataTable ta = new DataTable();
            SqlConnection connection = new SqlConnection(con);
            SqlCommand cmd = new SqlCommand(s, connection);

            //  cmd.Parameters.Add("@id", SqlDbType.Int).Value = i;
            try
            {
                connection.Open();
            }
            catch { }
            try
            {
                ta.Load(cmd.ExecuteReader());
            }
            catch { return null; }
            connection.Close();

            return ta;
        }
        public static string sf = @"CREATE TABLE [dbo].[T_USERSINVSETTING](
	[InvSet_ID] [int] IDENTITY(1,1) NOT NULL,
	[InvID] [int] NOT NULL,
	[InvNamA] [varchar](50) NULL,
	[InvNamE] [varchar](50) NULL,
	[InvSetting] [varchar](50) NULL,
	[InvStartNo] [varchar](10) NULL,
	[InvTypA0] [varchar](50) NULL,
	[InvTypA1] [varchar](10) NULL,
	[InvTypA2] [varchar](10) NULL,
	[InvTypA3] [varchar](10) NULL,
	[InvTypA4] [varchar](10) NULL,
	[InvTypE0] [varchar](10) NULL,
	[InvTypE1] [varchar](10) NULL,
	[InvTypE2] [varchar](10) NULL,
	[InvTypE3] [varchar](10) NULL,
	[InvTypE4] [varchar](10) NULL,
	[InvColorH] [float] NULL,
	[InvColorD] [float] NULL,
	[InvPrice] [int] NULL,
	[FldA1] [varchar](20) NULL,
	[FldA2] [varchar](20) NULL,
	[FldA3] [varchar](20) NULL,
	[FldA4] [varchar](20) NULL,
	[FldA5] [varchar](20) NULL,
	[FldE1] [varchar](20) NULL,
	[FldE2] [varchar](20) NULL,
	[FldE3] [varchar](20) NULL,
	[FldE4] [varchar](20) NULL,
	[FldE5] [varchar](20) NULL,
	[AccCredit0] [varchar](15) NULL,
	[AccDebit0] [varchar](15) NULL,
	[invALogo] [varchar](20) NULL,
	[invELogo] [varchar](20) NULL,
	[invGdADesc] [varchar](max) NULL,
	[invGdEDesc] [varchar](max) NULL,
	[invGdStng] [varchar](10) NULL,
	[hAl] [float] NULL,
	[hAs] [float] NULL,
	[hYm] [float] NULL,
	[hYs] [float] NULL,
	[lnPg] [float] NULL,
	[lnSpc] [float] NULL,
	[defPrn] [varchar](100) NULL,
	[nTyp] [varchar](3) NULL,
	[ItmTyp] [varchar](10) NULL,
	[InvNum] [int] NULL,
	[InvNum1] [int] NULL,
	[DefLines] [int] NULL,
	[defSizePaper] [varchar](100) NULL,
	[Orientation] [int] NULL,
	[CatID] [int] NULL,
	[PrintCat] [bit] NULL,
	[UserNo] [int] null,
);
ALTER TABLE [dbo].[T_USERSINVSETTING] ADD  CONSTRAINT [DF_T_USERINVSETTING_PrintCat]  DEFAULT ((0)) FOR [PrintCat]

";
        void Fixprinting(string cname, string tname)
        {
            string sa = @" SELECT  * FROM INFORMATION_SCHEMA.Columns
  where TABLE_SCHEMA='dbo'
  AND
  TABLE_NAME='" + tname + @"'
  AND
  COLUMN_NAME='" + cname + "'";
            DataTable fdsa = execute(sa, VarGeneral.BranchCS);
            if (fdsa.Rows.Count == 0)
            {
                executes(sf, VarGeneral.BranchCS);


            }

            {
                DataTable faff = execute("select UsrNo from T_Users", VarGeneral.BranchRt);

                foreach (DataRow r in faff.Rows)
                {
                    string un = r["UsrNo"].ToString();
                    fdsa = execute("select *from T_INVSETTING where UserNo=" + un, VarGeneral.BranchCS);

                    if (fdsa.Rows.Count == 0)
                    {
                        string saf;
                        saf = newusersettings.Replace("4352395", un);
                        executes(saf, VarGeneral.BranchCS);
                    }
                }
            }


        }
        public string newusersettings = @"INSERT [dbo].[T_INVSETTING] ( [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit], [UserNo]) VALUES ( -101, N'������ �����', N'SaveOverBill', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4352395)
INSERT [dbo].[T_INVSETTING] ( [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit], [UserNo]) VALUES ( 1, N'������ ������                                     ', N'Sales Invoice                                     ', N'212', N'1         ', N'����                          ', N'���       ', NULL, NULL, NULL, N'Cash      ', N'Credit    ', NULL, NULL, NULL, -2147483633, 12640511, 0, N'������              ', NULL, NULL, NULL, NULL, N'Customer            ', NULL, NULL, NULL, NULL, N'3021001        ', N'1020001        ', NULL, NULL, N'', N'', NULL, N'3021005        ', N'***', N'3021005', N'1022001', N'3021001', N'1020001', N'3021005', N'***', 1, 1, 1, 1, 0, 10, N'Microsoft Print to PDF', N'010', N'1011 ', 1, 1, 1, N'', 1, NULL, 0, N'11011011', 0, N'1020001        ', N'4011026', 0, N'3021003', N'3021001', N'10', 0, N'***', N'4011012', N'***', N'4011026', 4352395)
INSERT [dbo].[T_INVSETTING] ( [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit], [UserNo]) VALUES ( 2, N'������ �������                                    ', N'Purchase Receipt                                  ', N'111', N'1         ', N'����                          ', N'���       ', NULL, NULL, NULL, N'Cash      ', N'Credit    ', NULL, NULL, NULL, -2147483633, 14737632, 8, N'������              ', NULL, NULL, NULL, NULL, N'Supplyer            ', NULL, NULL, NULL, NULL, N'1020001', N'3041001', NULL, NULL, NULL, NULL, NULL, N'***', N'3041005', N'1022001', N'3041005', N'1020001', N'3041001', N'***', N'3041005', 1, 1, 1, 1, 0, 6, NULL, N'111', N'1100 ', 1, 1, 1, N'', 1, NULL, 0, N'11101011', 0, N'4011027', N'1020001', 0, N'3041001', N'3041003', N'10', 0, N'4011012', N'***', N'4011027', N'***', 4352395)
INSERT [dbo].[T_INVSETTING] ( [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit], [UserNo]) VALUES ( 3, N' ����� ������                                     ', N'Sales Return                                      ', N'111', N'1         ', N'����                          ', N'���       ', NULL, NULL, NULL, N'Cash      ', N'Credit    ', NULL, NULL, NULL, -2147483633, 12640511, 0, N'������              ', NULL, NULL, NULL, NULL, N'Customer            ', NULL, NULL, NULL, NULL, N'1020001', N'3021002', NULL, NULL, NULL, NULL, NULL, N'***', N'3021006', N'1022001', N'3021006', N'1020001', N'3021002', N'***', N'3021006', 1, 1, 1, 1, 0, 6, NULL, N'111', N'1011 ', 1, 1, 1, N'', 1, NULL, 0, N'11011011', 0, N'4011026', N'1020001', 0, N'3021002', N'3021004', N'10', 0, N'***', N'***', N'4011026', N'***', 4352395)
INSERT [dbo].[T_INVSETTING] ( [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit], [UserNo]) VALUES ( 4, N'����� �������                                     ', N'Purchase Return                                   ', N'212', N'1         ', N'����                          ', N'���       ', NULL, NULL, NULL, N'Cash      ', N'Credit    ', NULL, NULL, NULL, -2147483633, 14737632, 8, N'������              ', NULL, NULL, NULL, NULL, N'Supplyer            ', NULL, NULL, NULL, NULL, N'3041002', N'1020001', NULL, NULL, NULL, NULL, NULL, N'3041006', N'***', N'3041006', N'1022001', N'3041002', N'1020001', N'3041006', N'***', 1, 1, 1, 1, 0, 6, NULL, N'111', N'1100 ', 1, 1, 1, N'', 1, NULL, 0, N'11101011', 0, N'1020001', N'4011027', 0, N'3041004', N'3041002', N'10', 0, N'***', N'***', N'***', N'4011027', 4352395)
INSERT [dbo].[T_INVSETTING] ( [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit], [UserNo]) VALUES ( 5, N'��� ����� �����                                   ', N'Transfer In                                       ', N'101', N'1         ', N'�����                         ', NULL, NULL, NULL, NULL, N'Entry     ', NULL, NULL, NULL, NULL, -2147483633, 16777152, 6, N'�� ������           ', NULL, NULL, NULL, NULL, N'Store               ', NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, NULL, N'111', N'1110 ', 1, 1, 1, N'', 1, NULL, 0, N'11101011', 0, N'***', N'***', 0, N'***', N'***', N'10', 0, N'***', N'***', N'***', N'***', 4352395)
INSERT [dbo].[T_INVSETTING] ( [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit], [UserNo]) VALUES ( 6, N'��� ����� �����                                   ', N'Transfer Out                                      ', N'202', N'1         ', N'�����                         ', NULL, NULL, NULL, NULL, N'Out       ', NULL, NULL, NULL, NULL, -2147483633, 16777152, 6, N'�� ������           ', NULL, NULL, NULL, NULL, N'Store               ', NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, NULL, N'111', N'1110 ', 1, 1, 1, N'', 1, NULL, 0, N'11101011', 0, N'***', N'***', 0, N'***', N'***', N'10', 0, N'***', N'***', N'***', N'***', 4352395)
INSERT [dbo].[T_INVSETTING] ( [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit], [UserNo]) VALUES ( 7, N'��� ��� �������                                   ', N'Sales Qutation                                    ', N'000', N'1         ', N'���                           ', NULL, NULL, NULL, NULL, N'Qutation  ', NULL, NULL, NULL, NULL, -2147483633, 12640511, 0, N'������              ', NULL, NULL, NULL, NULL, N'Customer            ', NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, NULL, N'111', N'1011 ', 1, 1, 1, N'', 1, NULL, 0, N'11011011', 0, N'***', N'***', 0, N'***', N'***', N'10', 0, N'***', N'***', N'***', N'***', 4352395)
INSERT [dbo].[T_INVSETTING] ( [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit], [UserNo]) VALUES ( 8, N'��� ��� ��������                                  ', N'Goods Receipt                                     ', N'101', N'1         ', N'���                           ', NULL, NULL, NULL, NULL, N'Receipt   ', NULL, NULL, NULL, NULL, -2147483633, 14737632, 6, N'������              ', NULL, NULL, NULL, NULL, N'Supplyer            ', NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, NULL, N'111', N'1100 ', 1, 1, 1, N'', 1, NULL, 0, N'11011011', 0, N'***', N'***', 0, N'***', N'***', N'10', 0, N'***', N'***', N'***', N'***', 4352395)
INSERT [dbo].[T_INVSETTING] ( [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit], [UserNo]) VALUES ( 9, N'��� ����                                          ', N'Purchase Order                                    ', N'000', N'1         ', N'���                           ', NULL, NULL, NULL, NULL, N'Order     ', NULL, NULL, NULL, NULL, -2147483633, 16771816, 7, N'������              ', NULL, NULL, NULL, NULL, N'Supplyer            ', NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, NULL, N'111', N'1100 ', 1, 1, 1, N'', 1, NULL, 0, N'11101011', 0, N'***', N'***', 0, N'***', N'***', N'10', 0, N'***', N'***', N'***', N'***', 4352395)
INSERT [dbo].[T_INVSETTING] ( [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit], [UserNo]) VALUES ( 10, N'��� �����                                         ', N'Stock Adjustment', N'101', N'1         ', N'���                           ', NULL, NULL, NULL, NULL, N'Snad      ', NULL, NULL, NULL, NULL, -2147483633, 16771816, 6, N'��������            ', NULL, NULL, NULL, NULL, N'Store               ', NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, NULL, N'111', N'1110 ', 1, 1, 1, N'', 1, NULL, 0, N'11101011', 0, N'***', N'***', 0, N'***', N'***', N'10', 0, N'***', N'***', N'***', N'***', 4352395)
INSERT [dbo].[T_INVSETTING] ( [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit], [UserNo]) VALUES ( 11, N'��� ���                                           ', N'Journal Voucher                                   ', N'1', N'1         ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, -2147483633, 12640511, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 10, N'Microsoft Print to PDF', N'111', NULL, 1, 1, 1, N'', 1, NULL, 0, NULL, 0, N'***', N'***', 0, N'***', N'***', NULL, 0, N'***', N'***', N'***', N'***', 4352395)
INSERT [dbo].[T_INVSETTING] ( [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit], [UserNo]) VALUES ( 12, N'��� ���                                           ', N'Receipt Voucher                                   ', N'1', N'1         ', N'������� �� ������             ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, -2147483633, 16706518, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 10, N'', N'111', NULL, 1, 1, 1, N'', 1, NULL, 0, NULL, 0, N'***', N'***', 0, N'***', N'***', NULL, 0, N'***', N'***', N'***', N'***', 4352395)
INSERT [dbo].[T_INVSETTING] ( [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit], [UserNo]) VALUES ( 13, N'��� ���                                           ', N'Payment Voucher                                   ', N'1', N'1         ', N'������ �� ������              ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, -2147483633, 14737632, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, N'', N'101', NULL, 1, 1, 1, N'', 1, NULL, 0, NULL, 0, N'***', N'***', 0, N'***', N'***', NULL, 0, N'***', N'***', N'***', N'***', 4352395)
INSERT [dbo].[T_INVSETTING] ( [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit], [UserNo]) VALUES ( 14, N'����� ��� �����', N'Open Quantities                                   ', N'303', N'1         ', N'���                           ', NULL, NULL, NULL, NULL, N'Snad      ', NULL, NULL, NULL, NULL, -2147483633, 16706518, 6, N'��������            ', NULL, NULL, NULL, NULL, N'Store               ', NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, NULL, N'111', N'1110 ', 1, 1, 1, N'', 1, NULL, 0, N'11101011', 0, N'***', N'***', 0, N'***', N'***', N'10', 0, N'***', N'***', N'***', N'***', 4352395)
INSERT [dbo].[T_INVSETTING] ( [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit], [UserNo]) VALUES ( 15, N'����� �������', N'Guests Services', N'414', N'1         ', N'���                           ', NULL, NULL, NULL, NULL, N'Snad      ', NULL, NULL, NULL, NULL, -2147483633, 16706518, 6, N'��������            ', NULL, NULL, NULL, NULL, N'Store               ', NULL, NULL, NULL, NULL, N'4011002        ', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, NULL, N'111', N'1110 ', 1, 1, 1, N'', 1, NULL, 0, NULL, 0, N'***', N'***', 0, N'***', N'***', NULL, 0, N'***', N'***', N'***', N'***', 4352395)
INSERT [dbo].[T_INVSETTING] ( [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit], [UserNo]) VALUES ( 16, N'���� ��������', N'HR', N'1', N'1         ', N'��� �����                     ', NULL, NULL, NULL, NULL, N'Snad      ', NULL, NULL, NULL, NULL, -2147483633, 16706518, 8, N'��� �����           ', NULL, NULL, NULL, NULL, N'Store               ', NULL, NULL, NULL, NULL, N'3051002        ', N'3051001        ', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, N'', N'101', NULL, 1, 1, 1, N'', 1, NULL, 0, N'11101011', 0, N'***', N'***', 0, N'***', N'***', N'10', 0, N'***', N'***', N'***', N'***', 4352395)
INSERT [dbo].[T_INVSETTING] ( [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit], [UserNo]) VALUES ( 17, N'��� ��� �����                                     ', N'Payment Order                                     ', N'212', N'1         ', N'���                           ', NULL, NULL, NULL, NULL, N'Snad      ', NULL, NULL, NULL, NULL, -2147483633, 12641511, 0, N'������              ', NULL, NULL, NULL, NULL, N'Account             ', NULL, NULL, NULL, NULL, N'3021001        ', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, NULL, N'111', N'1011 ', 1, 1, 1, N'', 1, NULL, 0, N'11011011', 0, N'***', N'***', 0, N'***', N'***', N'10', 0, N'***', N'***', N'***', N'***', 4352395)
INSERT [dbo].[T_INVSETTING] ( [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit], [UserNo]) VALUES ( 18, N'��� ���                                           ', N'Receipt Voucher                                   ', N'418', N'1         ', N'������� �� ������             ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, -2147483633, 16706518, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 10, NULL, N'101', NULL, 1, 1, 1, N'', 1, NULL, 0, NULL, 0, N'***', N'***', 0, N'***', N'***', NULL, 0, N'***', N'***', N'***', N'***', 4352395)
INSERT [dbo].[T_INVSETTING] ( [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit], [UserNo]) VALUES ( 19, N'��� ���                                           ', N'Payment Voucher                                   ', N'419', N'1         ', N'������ �� ������              ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, -2147483633, 14737632, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, N'', N'101', NULL, 1, 1, 1, N'', 1, NULL, 0, NULL, 0, N'***', N'***', 0, N'***', N'***', NULL, 0, N'***', N'***', N'***', N'***', 4352395)
INSERT [dbo].[T_INVSETTING] ( [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit], [UserNo]) VALUES ( 20, N'����� ��� �����                                   ', N'Payment Order Return                              ', N'111', N'1         ', N'���                           ', NULL, NULL, NULL, NULL, N'Snad      ', NULL, NULL, NULL, NULL, -2147483633, 12641511, 8, N'������              ', NULL, NULL, NULL, NULL, N'Account             ', NULL, NULL, NULL, NULL, N'3021001        ', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, NULL, N'111', N'1011 ', 1, 1, 1, N'', 1, NULL, 0, N'11011011', 0, N'***', N'***', 0, N'***', N'***', N'10', 0, N'***', N'***', N'***', N'***', 4352395)
INSERT [dbo].[T_INVSETTING] ( [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit], [UserNo]) VALUES ( 21, N'������� �������', N'Local Orders', N'910', N'1         ', N'���                           ', NULL, NULL, NULL, NULL, N'Snad      ', NULL, NULL, NULL, NULL, -2147483633, 12641511, 8, N'������              ', NULL, NULL, NULL, NULL, N'Account             ', NULL, NULL, NULL, NULL, N'3021005        ', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, NULL, N'111', N'1011      ', 1, 1, 1, N'', 1, NULL, 0, NULL, 0, N'***', N'***', 0, N'***', N'***', NULL, 0, N'***', N'***', N'***', N'***', 4352395)
INSERT [dbo].[T_INVSETTING] ( [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit], [UserNo]) VALUES ( 22, N'����� ��������', N'Print BarCode', N'2', N'1', NULL, NULL, NULL, NULL, N'0', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 1, N'Microsoft Print to PDF', N'101', NULL, 1, 1, 1, N'', 1, NULL, 0, NULL, 0, N'***', N'***', 0, N'***', N'***', NULL, 0, N'***', N'***', N'***', N'***', 4352395)
INSERT [dbo].[T_INVSETTING] ( [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit], [UserNo]) VALUES ( 23, N'���� ���                                          ', N'Receipt Peaper                                   ', N'1', N'1         ', N'������� �� ������             ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, -2147483633, 16706518, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 10, N'', N'111', NULL, 1, 1, 1, N'', 1, NULL, 0, NULL, 0, N'***', N'***', 0, N'***', N'***', NULL, 0, N'***', N'***', N'***', N'***', 4352395)
INSERT [dbo].[T_INVSETTING] ( [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit], [UserNo]) VALUES ( 24, N'���� ���                                          ', N'Payment Peaper                                   ', N'1', N'1         ', N'������ �� ������              ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, -2147483633, 14737632, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, N'', N'101', NULL, 1, 1, 1, N'', 1, NULL, 0, NULL, 0, N'***', N'***', 0, N'***', N'***', NULL, 0, N'***', N'***', N'***', N'***', 4352395)
INSERT [dbo].[T_INVSETTING] ( [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit], [UserNo]) VALUES ( 25, N'����� ����                                        ', N'Receipt Peaper                                   ', N'1', N'1         ', N'������� �� ������             ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, -2147483633, 16706518, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 10, N'', N'111', NULL, 1, 1, 1, N'', 1, NULL, 0, NULL, 0, N'***', N'***', 0, N'***', N'***', NULL, 0, N'***', N'***', N'***', N'***', 4352395)
INSERT [dbo].[T_INVSETTING] ( [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit], [UserNo]) VALUES ( 26, N'��� ����                                          ', N'Payment Peaper                                   ', N'1', N'1         ', N'������ �� ������              ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, -2147483633, 14737632, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, N'', N'101', NULL, 1, 1, 1, N'', 1, NULL, 0, NULL, 0, N'***', N'***', 0, N'***', N'***', NULL, 0, N'***', N'***', N'***', N'***', 4352395)
INSERT [dbo].[T_INVSETTING] ( [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit], [UserNo]) VALUES ( 27, N'��� ��� ����', N'Catch Receipt Guest', N'1', N'1         ', N'������� �� ������             ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, -2147483633, 16706518, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 10, N'', N'111', NULL, 1, 1, 1, N'', 1, NULL, 0, NULL, 0, N'***', N'***', 0, N'***', N'***', NULL, 0, N'***', N'***', N'***', N'***', 4352395)
INSERT [dbo].[T_INVSETTING] ( [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit], [UserNo]) VALUES ( 28, N'��� ��� ����', N'receipt Guest', N'1', N'1         ', N'������ �� ������              ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, -2147483633, 16706518, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 10, N'', N'111', NULL, 1, 1, 1, N'', 1, NULL, 0, NULL, 0, N'***', N'***', 0, N'***', N'***', NULL, 0, N'***', N'***', N'***', N'***', 4352395)
INSERT [dbo].[T_INVSETTING] ( [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit], [UserNo]) VALUES ( 29, N'��� ��� ������', N'Catch Receipt Tenant', N'1', N'1         ', N'������� �� ������             ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, -2147483633, 16706518, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 10, N'', N'111', NULL, 1, 1, 1, N'', 1, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4352395)
INSERT [dbo].[T_INVSETTING] ( [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit], [UserNo]) VALUES ( 30, N'��� ��� ������', N'receipt Tenant', N'1', N'1         ', N'������ �� ������              ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, -2147483633, 16706518, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 10, N'', N'111', NULL, 1, 1, 1, N'', 1, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4352395)
INSERT [dbo].[T_INVSETTING] ( [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit], [UserNo]) VALUES ( 100, N'������', N'Public', N'212', N'1         ', N'����                          ', N'���       ', NULL, NULL, NULL, N'Cash      ', N'Credit    ', NULL, NULL, NULL, -2147483633, 12640511, 0, N'������              ', NULL, NULL, NULL, NULL, N'Customer            ', NULL, NULL, NULL, NULL, N'3021001        ', N'1020001        ', NULL, NULL, NULL, NULL, NULL, N'3021005        ', N'***', N'3021005', N'1022001', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, N'Microsoft XPS Document Writer', N'110', N'1011 ', 1, 1, 1, NULL, NULL, 1, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4352395)
";
        public static void updateeverything()
        {

            checkAndUpdate();
            periodicupdate();
            //internalupdate();



        }
       
        public static void createnewupdatefiles()
        {

            SqlConnection con = new SqlConnection(VarGeneral.BranchCS);
            string sa = @"
Select
'if not exists(select * from dbo.sysobjects so left outer join dbo.syscolumns sc on (so.id=sc.id)
  where(so.id = object_id(N''[dbo].['+t.name+']'')) and(OBJECTPROPERTY(so.id, N''IsUserTable'') = 1) and(sc.Name = N'''+c.name+''') )
    ALTER TABLE '+t.name+' ADD[' + c.name + '] ' + ty.name + (CASE WHEN ty.name like ' % char % ' THEN '('+(CASE WHEN c.max_length<0 THEN 'MAX' ELSE CAST(c.max_length/(CASE WHEN ty.system_type_id in (231,239) THEN 2 ELSE 1 END) as nvarchar) END)+')' ELSE '' END) + (CASE WHEN c.is_nullable=1 THEN ' NULL' ELSE ' NOT NULL' END)+'


if exists(select * from dbo.sysobjects so left outer join dbo.syscolumns sc on(so.id = sc.id)
  where(so.id = object_id(N''[dbo].['+t.name+']'')) and(OBJECTPROPERTY(so.id, N''IsUserTable'') = 1) and(sc.Name = N'''+c.name+''') and((sc.xusertype <> '''+CAST(ty.user_type_id as varchar)+''') or(sc.length <> '''+CAST(c.max_length as varchar)+''')))
                ALTER TABLE '+t.name+' ALTER COLUMN[' + c.name + '] ' + ty.name + (CASE WHEN ty.name like ' % char % ' THEN '('+(CASE WHEN c.max_length<0 THEN 'MAX' ELSE CAST(c.max_length/(CASE WHEN ty.system_type_id in (231,239) THEN 2 ELSE 1 END) as nvarchar) END)+')' ELSE '' END) + (CASE WHEN c.is_nullable=1 THEN ' NULL' ELSE ' NOT NULL' END)+'


'
from sys.tables t
LEFT JOIN sys.all_columns c on t.object_id = c.object_id
LEFT JOIN sys.types ty on ty.user_type_id = c.user_type_id
Order by t.name, c.column_id
";
            SqlCommand md = new SqlCommand(sa, con);

            DataTable t = new DataTable();
            try
            {
                con.Open();
                t.Load(md.ExecuteReader());

                con.Close();
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (SqlException ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

            }
            string sad = "";
            foreach (DataRow r in t.Rows)
            {
                sad += r[0].ToString() + Environment.NewLine;
            }
            string tables = File.ReadAllText(Application.StartupPath + "\\tables.txt");
            string procedures = File.ReadAllText(Application.StartupPath + "\\procedures.txt");
          //  string saf = v.Replace("version001", VarGeneral.dbversion);
         ///   File.WriteAllText(newupdpath + "\\dbupdate", tables + Environment.NewLine + sad + Environment.NewLine + procedures + Environment.NewLine + saf);
#pragma warning disable CS0219 // The variable 'cs' is assigned but its value is never used
            string cs = @"D:\InvAccProsoft\New folder\ProSoft G-2-181\InvAcc\InvAcc\Resources\pro.sql";
#pragma warning restore CS0219 // The variable 'cs' is assigned but its value is never used
          //  File.WriteAllText(cs, tables + Environment.NewLine + sad + Environment.NewLine + procedures + Environment.NewLine + saf);

            if (File.Exists(newupdpath + "\\InvAcc.exe"))
                File.Delete(newupdpath + "\\InvAcc.exe");
            if (File.Exists(newupdpath + "\\InvAcc.exe.config"))
                File.Delete(newupdpath + "\\InvAcc.exe.config");
            if (File.Exists(newupdpath + "\\InvAcc.pdb"))
                File.Delete(newupdpath + "\\InvAcc.pdb");
            File.Copy(Application.StartupPath + "\\InvAcc.exe", newupdpath + "\\InvAcc.exe", true);

            File.Copy(Application.StartupPath + "\\InvAcc.pdb", newupdpath + "\\InvAcc.pdb", true);

            File.Copy(Application.StartupPath + "\\InvAcc.exe.config", newupdpath + "\\InvAcc.exe.config", true);
        }
        public static string ITmes_update = @" IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[T_Items]') 
         AND name = 'ProductionDate'
)
BEGIN ALTER TABLE dbo.T_Items ADD

    ProductionDate varchar(MAX) NULL,
	ExpirationDate varchar(MAX) NULL
	End";
        void addDates()
        {

        }
        public static string perfilepath = Application.StartupPath + "\\periodicupdate";
        public static string newupdpath = Application.StartupPath + "\\dbupdate";
        public static string perfered = "R";
  
        public static string GetDatabaseVersion()
        {
            DataTable ta = execute("select dbv from tb_version;", VarGeneral.BranchCS);
            if (ta == null)
            {
                return "ERROR";


            }
            else

            {
                if (ta.Rows.Count == 0)
                {
                    return "ERROR";

                }
                else
                    if (ta.Rows[0]["dbv"].ToString() != VarGeneral.dbversion)
                    return "old";

                return VarGeneral.ProdectNo;

            }

#pragma warning disable CS0162 // Unreachable code detected
            return "ERROR";
#pragma warning restore CS0162 // Unreachable code detected

        }
        public static void periodicupdate()
        {
            //checkAndUpdate();
            //if (File.Exists(perfilepath))
            //{
            //    string sa = File.ReadAllText(perfilepath);

            //    Rate_DataDataContext dbc = new Rate_DataDataContext(VarGeneral.BranchRt);
            //    int bs = dbc.MaxBranchNo;
            //    for (int k = 1; k < bs; k++)
            //    {

            //        if (k != 1)
            //            sa = sa.Replace("PROSOFT_default_1", "PROSOFT_default_" + k.ToString());
            //        string vs =  v.Replace("version001", VarGeneral.dbversion);
            //        SqlConnection con = new SqlConnection(VarGeneral.BranchCS.Replace("PROSOFT_default_1", "PROSOFT_default_" + k.ToString()));

            //        ServerConnection ssa = new ServerConnection(con);
            //        Server server = new Server(ssa);
            //        try
            //        {
            //            ssa.Connect();

            //            server.ConnectionContext.ExecuteNonQuery(sa);
            //            server.ConnectionContext.ExecuteNonQuery(vs);
            //            ssa.Disconnect();


            //        }
            //        catch (SqlException s)
            //        {
            //            MessageBox.Show("Updatenot done ! press ok to continiue" + s.Message);
            //        }
            //    }

            //}
        }
        public static void checkAndUpdate()
        {
            if (File.Exists(newupdpath))
            {
                string sa = File.ReadAllText(newupdpath);
                Rate_DataDataContext dbc = new Rate_DataDataContext(VarGeneral.BranchRt);
                int bs = dbc.MaxBranchNo;
                for (int k = 1; k < bs; k++)
                {

                    if (k != 1)
                        sa = sa.Replace("PROSOFT_default_1", "PROSOFT_default_" + k.ToString());
                    //string vs = v.Replace("version001", VarGeneral.dbversion);
                    SqlConnection con = new SqlConnection(VarGeneral.BranchCS.Replace("PROSOFT_default_1", "PROSOFT_default_" + k.ToString()));

                    ServerConnection ssa = new ServerConnection(con);
                    Server server = new Server(ssa);
                    try
                    {
                        ssa.Connect();

                        server.ConnectionContext.ExecuteNonQuery(sa);
                      

                        if (k == 1)

                            File.WriteAllText(perfilepath, sa);

                        ssa.Disconnect();

                    }
                    catch (SqlException s)
                    {
                        MessageBox.Show("Updatenot done ! press ok to continiue" + s.Message);
                    }
                    File.Delete(newupdpath);
                }



            }
        }
        public void checkAndUpdate1()
        {
            if (!gettest("Select * From T_INVSETTING WHERE INVID=" + VarGeneral.DraftBillId.ToString(), VarGeneral.BranchCS))




            {
                adddraft();
            }
            if (!gettest("Select ProductionDate From  T_Items  ;", VarGeneral.BranchCS))




            {
                updateeverything();
            }


            s3 = S_T_INVDET_INSERT_ALTER_DRAFT;
            s10 = S_T_INVHED_INSERT_DRAFT;

            string c = VarGeneral.BranchCS;

            if (true)
            {
                int j = scripts.Count;
                Rate_DataDataContext dbc = new Rate_DataDataContext(VarGeneral.BranchRt);
                int bs = dbc.MaxBranchNo;
                for (int k = 1; k < bs; k++)
                {

                    int i = getvertionnumber(c.Replace("PROSOFT_default_1", "PROSOFT_default_" + k.ToString()));
                    if (i != -1)
                    {
                        updatenewBranch(k, 1.ToString(), i, 0);
                        setdataBaseVersion(j, c.Replace("PROSOFT_default_1", "PROSOFT_default_" + k.ToString()));
                    }
                }

            }

        }
    }
}
