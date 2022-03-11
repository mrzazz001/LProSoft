﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ProShared.Stock_Data;
using ProShared.GeneralM;
using System.Drawing.Printing;
using ProShared.DBUdate;

namespace ProRealEstate.Utilties
{
    public partial class xXPrinterSetting : DevExpress.XtraEditors.XtraUserControl
    {
      public   Stock_DataDataContext dbInstance1;
        private Stock_DataDataContext db
        {
            get
            {
                if (dbInstance1 == null)
                {
                    if (DesignMode == false) dbInstance1 =(VarGeneral.dbshared);
                }
                return dbInstance1;
            }
        }
        int kk = 0;
        public xXPrinterSetting()
        {
            InitializeComponent();
            User_ID = VarGeneral.UserID;
            try
            {
                t_UsersBindingSource.DataSource = new ProShared.Stock_Data.Rate_DataDataContext(VarGeneral.BranchRt).T_Users;
                init();
                lookUpEditWithDataSource1.EditValue = User_ID;
            }
            catch
            {

            }
        }
        public T_Printer CurrentSetting
        {
            get
            {
                return (t_PrintersBindingSource.Current as T_Printer);
            }
        }
        int User_ID = 0;
       public void init()
        {

            try
            {
       
                Deflines.DataBindings.Clear();

                this.Deflines.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "DefLines", true));
                // This line of code is generated by Data Source Configuration Wizard
                dbc = new Rate_DataDataContext(VarGeneral.BranchRt
                    );
                defPrnTextEdit.Properties.Items.Clear();
                PrinterSettings PrintS = new PrinterSettings();
                if (PrinterSettings.InstalledPrinters.Count != 0)
                {
                    for (int iiCnt = 0; iiCnt < PrinterSettings.InstalledPrinters.Count; iiCnt++)
                    {
                        defPrnTextEdit.Properties.Items.Add(PrinterSettings.InstalledPrinters[iiCnt]);
                    }
                    if (!string.IsNullOrEmpty(VarGeneral.PrintNam))
                    {
                        defPrnTextEdit.Text = VarGeneral.PrintNam;
                    }
                    else
                    {
                        defPrnTextEdit.EditValue = PrintS.DefaultPageSettings.PrinterSettings.PrinterName;
                    }
                }

                t_PrintersBindingSource = new BindingSource();
                t_PrintersBindingSource.DataSource = (from o in db.T_Printers where o.User_ID == User_ID select o).ToList();
                t_PrintersBindingSource.Position = 0;
                // This line of code is generated by Data Source Configuration Wizard
                T_Printer t = t_PrintersBindingSource.Current as T_Printer;
                invGdADesctext.EditValue = t.invGdADesc;
                invGdEDesctext.EditValue = t.invGdEDesc;

                    if (t.Orientation.HasValue)
                    {
                        if (t.Orientation == 1)
                        {
                            toggleSwitch1.IsOn = true;
                        }
                        else
                            toggleSwitch1.IsOn = false;
                    }

                    defPrnTextEdit.EditValue = t.defPrn;
                 
           
            }
            catch
            {
                int temp = VarGeneral.UserID;
                VarGeneral.UserID = User_ID;
                DbUpdates.copysetting2();
                VarGeneral.UserID = temp;
                            dbInstance1 = null;
                if (rep == 0) { rep = 1; init(); }

            }
            T_Printer tr = t_PrintersBindingSource.Current as T_Printer;
            if (tr == null) return;
            if (tr.InvInfo.PrintCat.HasValue)
                chk_Stoped.IsOn = (bool)tr.InvInfo.PrintCat;
            currentuser = (T_User)t_UsersBindingSource.Current;
            lookUpEditWithDataSource2.EditValue = tr.InvID;
        }
        T_User currentuser;
        int idd = 0;
        int rep = 0;
        public void init(int id,int user_id)
        {
            idd = id;
            if (id == 1091)
            {


                this.defPrnTextEdit.DataBindings.Clear();//Add(new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "defPrn_Setting", true));
               // this.Paper_SizeTextEdit.DataBindings.Clear();//;new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "Paper_Size_Setting", true));
                this.lnSpcTextEdit.DataBindings.Clear();//new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "lnSpc_Setting", true));
                this.lnPgTextEdit.DataBindings.Clear();//new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "lnPg_Setting", true));
                this.hAlTextEdit.DataBindings.Clear();//new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "hAl_Setting", true));
                this.hAsTextEdit.DataBindings.Clear();//new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "hAs_Setting", true));
                this.hYmTextEdit.DataBindings.Clear();//new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "hYm_Setting", true));

                this.hYsTextEdit.DataBindings.Clear();//new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "hYs_Setting", true));

                this.lnSpcTextEdit.DataBindings.Clear();//new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "lnSpc_Setting", true));

                this.lnPgTextEdit.DataBindings.Clear();//new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "lnPg_Setting", true));

                this.lnSpcTextEdit.DataBindings.Clear();//.Add(new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "lnSpc_Setting", true));

                this.lnPgTextEdit.DataBindings.Clear();//Add(new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "lnPg_Setting", true));

                invGdADesctext.DataBindings.Clear();
                invGdADesctext.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, " invGdADesc", true));
                invGdEDesctext.DataBindings.Clear();
                invGdEDesctext.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, " invGdEDesc", true));

                this.defPrnTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "defPrn_Setting", true));
               // this.Paper_SizeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "Paper_Size_Setting", true));
                this.lnSpcTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "lnSpc_Setting", true));
                this.lnPgTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "lnPg_Setting", true));
                this.hAlTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "hAl_Setting", true));
                this.hAsTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "hAs_Setting", true));
                this.hYmTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "hYm_Setting", true));

                this.hYsTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "hYs_Setting", true));

                  }
           
            defPrnTextEdit.Properties.Items.Clear();
            PrinterSettings PrintS = new PrinterSettings();
            if (PrinterSettings.InstalledPrinters.Count != 0)
            {
                for (int iiCnt = 0; iiCnt < PrinterSettings.InstalledPrinters.Count; iiCnt++)
                {
                    defPrnTextEdit.Properties.Items.Add(PrinterSettings.InstalledPrinters[iiCnt]);
                }
                if (!string.IsNullOrEmpty(VarGeneral.PrintNam))
                {
                    defPrnTextEdit.Text = VarGeneral.PrintNam;
                }
                else
                {
                    defPrnTextEdit.EditValue = PrintS.DefaultPageSettings.PrinterSettings.PrinterName;
                }
            }
            
            t_PrintersBindingSource.DataSource = (from o in db.T_Printers where o.User_ID == User_ID && o.InvID == id select o).ToList();
            T_Printer t = t_PrintersBindingSource.Current as T_Printer;
            if (t.Orientation.HasValue)
            {
                if (t.Orientation == 1)
                {
                    toggleSwitch1.IsOn = true;
                }
                else
                    toggleSwitch1.IsOn = false;
            }
            defPrnTextEdit.EditValue = t.defPrn;

        }
        private void Default_OperationTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void InvNamATextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void Paper_SizeTextEdit_MouseClick(object sender, MouseEventArgs e)
        {
          

        }

        private void defPrnTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Paper_SizeTextEdit.Properties.Items.Clear();
                Paper_SizeTextEdit.Properties.Items.Add(("الإفتراضي:: Default"));
                PrintDocument pd = new PrintDocument();
                pd.PrinterSettings.PrinterName = defPrnTextEdit.Text;
                foreach (PaperSize item in pd.PrinterSettings.PaperSizes)
                {
                    Paper_SizeTextEdit.Properties.Items.Add(item.PaperName);
                }
            }
            catch
            {
                Paper_SizeTextEdit.Properties.Items.Clear();
            }
        }
        public delegate void customMessageHandler(System.Object sender,
                                     EventArgs e);
        public event customMessageHandler Button_SaveDone;

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                enableusers = true;

             
                T_Printer t = t_PrintersBindingSource.Current as T_Printer;
                t.ISA4PaperType = ISA4PaperTypeCheckEdit.Checked;
                t.ISCashierType = ISCashierTypeCheckEdit.Checked;
                if (t.InvID != 1091)
                {
                    t.lnPg = double.Parse(lnPgTextEdit.EditValue.ToString());
                    t.lnSpc = double.Parse(lnSpcTextEdit.EditValue.ToString());
                    t.hAl = double.Parse(hAlTextEdit.EditValue.ToString());
                    t.hAs = double.Parse(hAsTextEdit.EditValue.ToString());
                    t.hYm = double.Parse(hYmTextEdit.EditValue.ToString());
                    t.hYs = double.Parse(hYsTextEdit.EditValue.ToString());
                    t.DefLines =(int) double.Parse(Deflines.Text);
                    t.defPrn = defPrnTextEdit.Text;
                    if (toggleSwitch1.IsOn)
                    {
                        t.Orientation = 1;
                    }
                    else
                        t.Orientation = 2;
                }
                else
                {
                    t.lnPg_Setting = double.Parse(lnPgTextEdit.EditValue.ToString());
                    ;
                    t.lnSpc_Setting = double.Parse(lnSpcTextEdit.EditValue.ToString());
                    t.hAl_Setting = double.Parse(hAlTextEdit.EditValue.ToString()); ;
                    t.hAs_Setting = double.Parse(hAsTextEdit.EditValue.ToString()); ;
                    t.hYm_Setting = double.Parse(hYmTextEdit.EditValue.ToString()); ;
                    t.hYs_Setting = double.Parse(hYsTextEdit.EditValue.ToString()); ;
                    t.DefLines_Setting = (int)(Deflines.Value);
                    t.defPrn_Setting = defPrnTextEdit.Text;
                    if (toggleSwitch1.IsOn)
                    {
                        t.Orientation_Setting = 1;
                    }
                    else
                        t.Orientation_Setting = 2;

                }
                t.InvInfo.PrintCat = (chk_Stoped.IsOn);
                try
                {
                    t.Paper_Size = Paper_SizeTextEdit.EditValue.ToString();
                }
                catch
                {
                    t.Paper_Size = "";
                }
                t.defPrn = defPrnTextEdit.Text.ToString();
                t.ISPOINTERType = ISPOINTERTypeCheckEdit.Checked;
                t.ISdirectPrinting = ISdirectPrintingCheckEdit.IsOn;
                if(invGdEDesctext.EditValue==null)
                {
                    invGdEDesctext.EditValue = "";
                }
                if(invGdADesctext.EditValue==null)
                    invGdADesctext.EditValue = "";
                t.invGdEDesc = invGdEDesctext.EditValue.ToString();
                t.invGdADesc = invGdADesctext.EditValue.ToString();
                if (t.InvInfo.CatID.HasValue) t.ISdirectPrinting = true;
                if (t.InvID == 21)
                {
                    t.InvInfo.autoCommGaid = checkedit_all.IsOn;
                }
                t_PrintersBindingSource.EndEdit();

                db.SubmitChanges();
            }catch(Exception ex)
            {
                MessageBox.Show(" هناك مشكله في الاعدادات " + ex.Message);
                return;           }
            MessageBox.Show("تم حفظ اعدادات " + lookUpEditWithDataSource2.Text + " للمستخدم " + lookUpEditWithDataSource1.Text + " بنجاح  ");
            if (Button_SaveDone != null) Button_SaveDone(null, null);
     

        }
     

        private void defPrnTextEdit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ISCashierTypeCheckEdit_Click(object sender, EventArgs e)
        {

        }

        private void ISCashierTypeCheckEdit_EditValueChanged(object sender, EventArgs e)
        {
            t_PrintersBindingSource.EndEdit();
            T_Printer c = t_PrintersBindingSource.Current as T_Printer;
            ISA4PaperTypeCheckEdit.EditValueChanged -= ISCashierTypeCheckEdit_EditValueChanged;
            ISCashierTypeCheckEdit.EditValueChanged -= ISCashierTypeCheckEdit_EditValueChanged;
            ISPOINTERTypeCheckEdit.EditValueChanged -= ISCashierTypeCheckEdit_EditValueChanged;
            if (sender as CheckEdit == ISA4PaperTypeCheckEdit)
            {
                ISA4PaperTypeCheckEdit.EditValue = true;
                ISCashierTypeCheckEdit.EditValue = false;
                ISPOINTERTypeCheckEdit.EditValue = false;

            }
            if (sender as CheckEdit == ISCashierTypeCheckEdit)
            {
                ISA4PaperTypeCheckEdit.EditValue = false;
                ISCashierTypeCheckEdit.EditValue = true;
                ISPOINTERTypeCheckEdit.EditValue = false;

            }
            if (sender as CheckEdit == ISPOINTERTypeCheckEdit)
            {
                ISA4PaperTypeCheckEdit.EditValue = false;
                ISCashierTypeCheckEdit.EditValue = false;
                ISPOINTERTypeCheckEdit.EditValue = true;

            }

            ISA4PaperTypeCheckEdit.EditValueChanged += ISCashierTypeCheckEdit_EditValueChanged;
            ISCashierTypeCheckEdit.EditValueChanged += ISCashierTypeCheckEdit_EditValueChanged;
            ISPOINTERTypeCheckEdit.EditValueChanged += ISCashierTypeCheckEdit_EditValueChanged;
        }

        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
            T_Printer c = t_PrintersBindingSource.Current as T_Printer;
            if (toggleSwitch1.IsOn) c.Orientation = 1;
            else
                c.Orientation = 2;
        }

        private void ISCashierTypeCheckEdit_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ISdirectPrintingCheckEdit_CheckedChanged(object sender, EventArgs e)
        {
        }
        bool enableusers
        {
            get
            {
                return lookUpEditWithDataSource1.Enabled;
            }

            set
            {
                lookUpEditWithDataSource1.Enabled = value;
            }
        }
        Rate_DataDataContext dbc;
        private void lookUpEditWithDataSource1_EditValueChanged(object sender, EventArgs e)
        {

            LookUpEdit d = sender as LookUpEdit;
           k = (int)d.EditValue;
            User_ID= k;
           
            init(); currentuser = dbc.StockUser(k.ToString());
   
            lookUpEditWithDataSource2.Properties.DataSource = t_PrintersBindingSource;
           
            t_PrintersBindingSource.Position = 0;
            lookUpEditWithDataSource2_EditValueChanged(lookUpEditWithDataSource2, null);

            if (!afterload) enableusers = false; else afterload = false;
        }
        int k = 1;
        private void lookUpEditWithDataSource2_EditValueChanged(object sender, EventArgs e)
        { T_Printer c = (t_PrintersBindingSource.Current as T_Printer);
            if (c == null) return;
      
            int k = (t_PrintersBindingSource.Current as T_Printer).InvID;
            LookUpEdit d = sender as LookUpEdit;
            ISA4PaperTypeCheckEdit.Checked = c.ISA4PaperType;
            ISCashierTypeCheckEdit.Checked = c.ISCashierType;
            ISPOINTERTypeCheckEdit.Checked = c.ISPOINTERType;
            ISdirectPrintingCheckEdit.IsOn = c.ISdirectPrinting;
           
            if ((t_PrintersBindingSource.Current as T_Printer).InvInfo.PrintCat.HasValue)
                chk_Stoped.IsOn = (bool)(t_PrintersBindingSource.Current as T_Printer).InvInfo.PrintCat;
            try
            {
                int ks = int.Parse(d.EditValue.ToString());
                if (ks == 1091)
                {

                    {

                        Deflines.DataBindings.Clear();
                        this.defPrnTextEdit.DataBindings.Clear();//Add(new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "defPrn_Setting", true));
                                                                 // this.Paper_SizeTextEdit.DataBindings.Clear();//;new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "Paper_Size_Setting", true));
                        this.lnSpcTextEdit.DataBindings.Clear();//new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "lnSpc_Setting", true));
                        this.lnPgTextEdit.DataBindings.Clear();//new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "lnPg_Setting", true));
                        this.hAlTextEdit.DataBindings.Clear();//new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "hAl_Setting", true));
                        this.hAsTextEdit.DataBindings.Clear();//new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "hAs_Setting", true));
                        this.hYmTextEdit.DataBindings.Clear();//new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "hYm_Setting", true));

                        this.hYsTextEdit.DataBindings.Clear();//new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "hYs_Setting", true));

                        this.lnSpcTextEdit.DataBindings.Clear();//new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "lnSpc_Setting", true));

                        this.lnPgTextEdit.DataBindings.Clear();//new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "lnPg_Setting", true));

                        this.lnSpcTextEdit.DataBindings.Clear();//.Add(new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "lnSpc_Setting", true));

                        this.lnPgTextEdit.DataBindings.Clear();//Add(new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "lnPg_Setting", true));


                        this.defPrnTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "defPrn_Setting", true));
                        // this.Paper_SizeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "Paper_Size_Setting", true));
                        this.lnSpcTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "lnSpc_Setting", true));
                        this.lnPgTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "lnPg_Setting", true));
                        this.hAlTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "hAl_Setting", true));
                        this.hAsTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "hAs_Setting", true));
                        this.hYmTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "hYm_Setting", true));
                        this.Deflines.DataBindings.Clear();

                        this.Deflines.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "DefLines_Setting", true));

                        this.hYsTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "hYs_Setting", true));
                    }

                }
                else
                {
                    Deflines.DataBindings.Clear();
                    this.defPrnTextEdit.DataBindings.Clear();//Add(new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "defPrn_Setting", true));
                                                             // this.Paper_SizeTextEdit.DataBindings.Clear();//;new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "Paper_Size_Setting", true));
                    this.lnSpcTextEdit.DataBindings.Clear();//new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "lnSpc_Setting", true));
                    this.lnPgTextEdit.DataBindings.Clear();//new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "lnPg_Setting", true));
                    this.hAlTextEdit.DataBindings.Clear();//new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "hAl_Setting", true));
                    this.hAsTextEdit.DataBindings.Clear();//new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "hAs_Setting", true));
                    this.hYmTextEdit.DataBindings.Clear();//new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "hYm_Setting", true));

                    this.hYsTextEdit.DataBindings.Clear();//new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "hYs_Setting", true));

                    this.lnSpcTextEdit.DataBindings.Clear();//new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "lnSpc_Setting", true));

                    this.lnPgTextEdit.DataBindings.Clear();//new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "lnPg_Setting", true));

                    this.lnSpcTextEdit.DataBindings.Clear();//.Add(new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "lnSpc_Setting", true));

                    this.lnPgTextEdit.DataBindings.Clear();//Add(new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "lnPg_Setting", true));


                    this.defPrnTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "defPrn", true));
                    // this.Paper_SizeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "Paper_Size_Setting", true));
                    this.lnSpcTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "lnSpc", true));
                    this.lnPgTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "lnPg", true));
                    this.hAlTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "hAl", true));
                    this.hAsTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "hAs", true));
                    this.hYmTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "hYm", true));

                    this.Deflines.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "DefLines", true));
                    this.hYsTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_PrintersBindingSource, "hYs", true));
                }
            }
            catch 
            
            { }
            if (d.Text.Contains("بارك"))
            {
                ItemForhAs.Text = "البعد العرضي بين الكروت";
                ItemForhAl.Text = "الهامش الاعلى";
                ItemForhYs.Text = "الهامش الايسر";
                ItemForlnPg.Text = "عدد الكروت عرضيا";
                ItemForhYm.Text = "الارتفاع بين الكروت";
                ItemForhAl.Text = "البعد العرضي بين الكروت";
                ItemForlnSpc.Text = "عدد الكروت طوليا";
                ItemForISCashierType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                ItemForISA4PaperType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                ItemForISPOINTERType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        
                layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem7.Text = "العرض";
                layoutControlItem6.Text = "الطول";

     

                layoutControlItem8.Text = "عدد النسخ";
            }
            else

            {
                layoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                this.ItemForhAl.Text = "الهامش الاعلى";

                this.ItemForhYm.Text = "الهامش الايمن";

                this.ItemForlnPg.Text = "عدد السطور في الصفحة";

                this.ItemForhAs.Text = "الهامش الاسفل";

                this.ItemForhYs.Text = "الهامش الايسر";

                this.ItemForlnSpc.Text = "المسافة بين السطور";
 
                ItemForISCashierType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                ItemForISA4PaperType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                ItemForISPOINTERType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                layoutControlItem7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                ISA4PaperTypeCheckEdit.Visible = true;
                ISCashierTypeCheckEdit.Visible = true;
                ISPOINTERTypeCheckEdit.Visible = true;
            }
           
            ItemForInvNamA.Text = "الاعدادات المستخدم ( " +currentuser.UsrNamA+ ") لــــ";

            t_PrintersBindingSource.Position = d.ItemIndex;

            T_Printer t = t_PrintersBindingSource.Current as T_Printer;
            invGdADesctext.EditValue = t.invGdADesc;
            invGdEDesctext.EditValue = t.invGdEDesc;
            ISA4PaperTypeCheckEdit.Checked = (bool)t.ISA4PaperType;
            ISCashierTypeCheckEdit.Checked = (bool)t.ISCashierType;
            ISPOINTERTypeCheckEdit.Checked = (bool)t.ISPOINTERType;
            ISdirectPrintingCheckEdit.IsOn = (bool)t.ISdirectPrinting;
            if (t.InvID == 21)
            {
                checkedit_all.Visible = true;
            }
            else
                checkedit_all.Visible = false;
            if (t.Orientation.HasValue)
            {
                if (t.Orientation == 1)
                {
                    toggleSwitch1.IsOn = true;
                }
                else
                    toggleSwitch1.IsOn = false;
            }
            defPrnTextEdit.EditValue = t.defPrn;
        }

        private void spinEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void ISPOINTERTypeCheckEdit_CheckedChanged(object sender, EventArgs e)
        {

        }
        bool afterload = true;
        private void XPrinterSetting_Load(object sender, EventArgs e)
        {
           
        }
    }
}
