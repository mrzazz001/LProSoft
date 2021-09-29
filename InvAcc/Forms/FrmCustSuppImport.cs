using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using DevComponents.Editors.DateTimeAdv;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Microsoft.Office.Interop.Excel;
using SSSDateTime.Date;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
namespace InvAcc.Forms
{
    public partial  class FrmCustSuppImport : Form
    { void avs(int arln)

{ 
 buttonX_ImportFile.Text=   (arln == 0 ? "  الإستيراد من ملف أكسيل  " : "  Import from excel file") ; groupBox1.Text=   (arln == 0 ? "  تخصيص  " : "  Customize") ; label2.Text=   (arln == 0 ? "  رقم الجوال :  " : "  Mobile number :") ; label1.Text=   (arln == 0 ? "  حساب الأب :  " : "  Father's account:") ; label5.Text=   (arln == 0 ? "  الإسم الانجليزي :  " : "  English name:") ; label4.Text=   (arln == 0 ? "  الإسم العربي :  " : "  Arabic name:") ; Button_Cancel.Text=   (arln == 0 ? "  خـــروج  " : "  Close") ; button_OK.Text=   (arln == 0 ? "  موافق  " : "  OK") ; Text = "استيراد بيانات الأصناف";this.Text=   (arln == 0 ? "  استيراد بيانات الأصناف  " : "  Import item data") ;}
        private void langloads(object sender, EventArgs e)
        {
             avs(GeneralM.VarGeneral.currentintlanguage);
        }
   
        public class ColumnDictinary
        {
            public string AText = string.Empty;
            public string EText = string.Empty;
            public bool IfDefault = false;
            public string Format = string.Empty;
            public ColumnDictinary(string aText, string eText, bool ifDefault, string format)
            {
                AText = aText;
                EText = eText;
                IfDefault = ifDefault;
                Format = format;
            }
        }
        private List<string> ColumnsFinger = new List<string>();
        private int LangArEn = 0;
        public List<Control> controls;
        public Control codeControl = new Control();
        private FormState statex;
        public bool CanEdit = true;
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private List<string> pkeys = new List<string>();
        private T_AccDef Data_this_AccDef;
        private Stock_DataDataContext dbInstance;
        private T_AccDef _AccDefBind = new T_AccDef();
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
       // private IContainer components = null;
        private void netResize1_AfterControlResize(object sender, Softgroup.NetResize.AfterControlResizeEventArgs e)
        {
            if (e.Control.GetType() == typeof(System.Windows.Forms.Label))
            {
                System.Windows.Forms.Label c = (e.Control as System.Windows.Forms.Label); if ((c.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))))) && (c.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))))) && (c.BackColor != System.Drawing.Color.SteelBlue))
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
        private Panel panel2;
        protected Panel panel5;
        private DataGridView ExcelGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_AccNo;
        private System.Windows.Forms.TextBox textBox_NameE;
        private System.Windows.Forms.TextBox textBox_NameA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private ButtonX buttonX_ImportFile;
        private System.Windows.Forms.TextBox textBox_SearchFilePath;
        protected Panel panel4;
        private System.Windows.Forms.Button Button_Cancel;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.TextBox textBox1;
        private ButtonX buttonX_SerchAccNo;
        private System.Windows.Forms.TextBox textBox_Mobile;
        private System.Windows.Forms.Label label2;
        public FormState State
        {
            get
            {
                return statex;
            }
            set
            {
                statex = value;
            }
        }
        public List<string> PKeys
        {
            get
            {
                return pkeys;
            }
            set
            {
                pkeys = value;
            }
        }
        public T_AccDef Datathis_AccDef
        {
            get
            {
                return Data_this_AccDef;
            }
            set
            {
                Data_this_AccDef = value;
            }
        }
        private Stock_DataDataContext db
        {
            get
            {
                if (dbInstance == null)
                {
                    dbInstance = new Stock_DataDataContext(VarGeneral.BranchCS);
                }
                return dbInstance;
            }
        }
        public FrmCustSuppImport()
        {
            InitializeComponent();this.Load += langloads;
            SetColumns();
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmCustSuppImport));
                if (base.Parent.RightToLeft == RightToLeft.Yes)
                {
                    Language.ChangeLanguage("ar-SA", this, resources);
                    LangArEn = 0;
                }
                else
                {
                    Language.ChangeLanguage("en", this, resources);
                    LangArEn = 1;
                }
            }
            FillGrid();
        }
        private void FrmCustSuppImport_Load(object sender, EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmCustSuppImport));
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                LangArEn = 0;
            }
            else
            {
                LangArEn = 1;
            }
            try
            {
                buttonX_ImportFile.Checked = true;
                ADD_Controls();
                Clear();
                Clear();
                if (!string.IsNullOrEmpty(textBox_SearchFilePath.Text))
                {
                    FillGrid();
                }
                if (VarGeneral.ImportDataType == 4)
                {
                    try
                    {
                        T_AccDef q = db.StockAccDefWithOutBalance("1022");
                        if (q != null && !string.IsNullOrEmpty(q.AccDef_No))
                        {
                            textBox_AccNo.Text = "1022";
                        }
                    }
                    catch
                    {
                    }
                    return;
                }
                try
                {
                    T_AccDef q = db.StockAccDefWithOutBalance("2021");
                    if (q != null && !string.IsNullOrEmpty(q.AccDef_No))
                    {
                        textBox_AccNo.Text = "2021";
                    }
                }
                catch
                {
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("FrmSystem_Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        public void SplashStart()
        {
            System.Windows.Forms.Application.Run(new FrmImports());
        }
        public void Clear()
        {
            if (State == FormState.New)
            {
                return;
            }
            State = FormState.New;
            State = FormState.New;
            for (int i = 0; i < controls.Count; i++)
            {
                if (controls[i].GetType() == typeof(DateTimePicker))
                {
                    (controls[i] as DateTimePicker).Value = DateTime.Now;
                }
                else if (controls[i].GetType() == typeof(DateTimeInput))
                {
                    (controls[i] as DateTimeInput).Value = DateTime.Now;
                }
                else if (controls[i].GetType() == typeof(ComboBox) && (controls[i] as ComboBox).Items.Count > 0)
                {
                    try
                    {
                        if ((controls[i] as ComboBox).Items.Count > 0)
                        {
                            (controls[i] as ComboBox).SelectedIndex = 0;
                        }
                    }
                    catch
                    {
                        (controls[i] as ComboBox).SelectedIndex = -1;
                    }
                }
                else if (controls[i].GetType() == typeof(System.Windows.Forms.CheckBox))
                {
                    (controls[i] as System.Windows.Forms.CheckBox).Checked = false;
                }
                else if (controls[i].GetType() == typeof(PictureBox))
                {
                    (controls[i] as PictureBox).Image = null;
                }
                else if (!(controls[i].Name == codeControl.Name))
                {
                    if (controls[i].GetType() == typeof(DoubleInput))
                    {
                        (controls[i] as DoubleInput).Value = 0.0;
                    }
                    else if (controls[i].GetType() == typeof(IntegerInput))
                    {
                        (controls[i] as IntegerInput).Value = 0;
                    }
                    else if (controls[i].GetType() == typeof(VisualStyleElement.TextBox) || controls[i].GetType() == typeof(TextBoxX) || controls[i].GetType() == typeof(MaskedTextBox))
                    {
                        controls[i].Text = string.Empty;
                    }
                    else if (controls[i].GetType() == typeof(System.Windows.Forms.CheckBox))
                    {
                        (controls[i] as System.Windows.Forms.CheckBox).Checked = false;
                    }
                    else if (controls[i].GetType() == typeof(RadioButton))
                    {
                        (controls[i] as RadioButton).Checked = false;
                    }
                }
            }
        }
        private void ADD_Controls()
        {
            try
            {
                controls = new List<Control>();
                controls.Add(textBox_AccNo);
                controls.Add(textBox_SearchFilePath);
                controls.Add(textBox_NameA);
                controls.Add(textBox_NameE);
                controls.Add(textBox_Mobile);
                controls.Add(button_OK);
                controls.Add(Button_Cancel);
                controls.Add(buttonX_ImportFile);
                controls.Add(ExcelGridView);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("ADD_Controls:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void button_OK_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox_AccNo.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "لابد من تحديد حساب الأب" : "Must customize column employee number ?", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_AccNo.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(textBox_NameA.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "لابد من تخصيص عمود الإسم العربي" : "Must customize column Time Attendance ?", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_NameA.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(textBox_NameE.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "لابد من تخصيص عمود الإسم الانجليزي" : "Must customize column Leaver Time ?", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_NameE.Focus();
                    return;
                }
                List<int> iRows = new List<int>();
                List<T_AccDef> ListAccDef = new List<T_AccDef>();
                bool vLoop = false;
                for (int i = 0; i < ExcelGridView.Rows.Count; i++)
                {
                    try
                    {
                        if (vLoop)
                        {
                            i = 0;
                            vLoop = false;
                        }
                        State = FormState.New;
                        if (string.IsNullOrEmpty(ExcelGridView.Rows[i].Cells[textBox_NameA.Text].Value.ToString().Trim()) || string.IsNullOrEmpty(ExcelGridView.Rows[i].Cells[textBox_NameE.Text].Value.ToString().Trim()))
                        {
                            continue;
                        }
                        Stock_DataDataContext dbx = new Stock_DataDataContext(VarGeneral.BranchCS);
                        Data_this_AccDef = new T_AccDef();
                        State = FormState.New;
                        int Value = 0;
                        List<T_AccDef> q = (from t in dbx.T_AccDefs
                                            where t.ParAcc == textBox_AccNo.Text
                                            orderby t.AccDef_ID
                                            select t).ToList();
                        if (q.Count == 0)
                        {
                            Data_this_AccDef.AccDef_No = textBox_AccNo.Text + "001";
                        }
                        else
                        {
                            _AccDefBind = q[q.Count - 1];
                            string _Zero = string.Empty;
                            for (int iiCnt = 0; iiCnt < _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Length && _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Substring(iiCnt, 1) == "0"; iiCnt++)
                            {
                                _Zero += _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Substring(iiCnt, 1);
                            }
                            Value = int.Parse(_AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length)) + 1;
                            if (!string.IsNullOrEmpty(_Zero))
                            {
                                Data_this_AccDef.AccDef_No = _AccDefBind.ParAcc + _Zero + Value;
                            }
                            else
                            {
                                Data_this_AccDef.AccDef_No = _AccDefBind.ParAcc + Value;
                            }
                        }
                        Data_this_AccDef.Arb_Des = ExcelGridView.Rows[i].Cells[textBox_NameA.Text].Value.ToString().Trim();
                        Data_this_AccDef.Eng_Des = ExcelGridView.Rows[i].Cells[textBox_NameE.Text].Value.ToString().Trim();
                        try
                        {
                            if (!string.IsNullOrEmpty(textBox_Mobile.Text))
                            {
                                if (!string.IsNullOrEmpty(ExcelGridView.Rows[i].Cells[textBox_Mobile.Text].Value.ToString().Trim()) && ExcelGridView.Rows[i].Cells[textBox_Mobile.Text].Value.ToString().Trim() != ".")
                                {
                                    Data_this_AccDef.Mobile = ExcelGridView.Rows[i].Cells[textBox_Mobile.Text].Value.ToString().Trim();
                                }
                                else
                                {
                                    Data_this_AccDef.Mobile = string.Empty;
                                }
                            }
                            else
                            {
                                Data_this_AccDef.Mobile = string.Empty;
                            }
                        }
                        catch
                        {
                            Data_this_AccDef.Mobile = string.Empty;
                        }
                        Data_this_AccDef.PersonalNm = string.Empty;
                        Data_this_AccDef.zipCod = string.Empty;
                        Data_this_AccDef.RessonStoped = string.Empty;
                        Data_this_AccDef.StopedState = false;
                        Data_this_AccDef.Lev = 4;
                        Data_this_AccDef.ParAcc = textBox_AccNo.Text;
                        Data_this_AccDef.AccCat = VarGeneral.ImportDataType;
                        if (VarGeneral.ImportDataType == 4)
                        {
                            Data_this_AccDef.DC = 0;
                        }
                        else
                        {
                            Data_this_AccDef.DC = 1;
                        }
                        Data_this_AccDef.Trn = 3;
                        Data_this_AccDef.Sts = 0;
                        Data_this_AccDef.MaxLemt = 0.0;
                        Data_this_AccDef.Typ = string.Empty;
                        Data_this_AccDef.City = string.Empty;
                        Data_this_AccDef.Email = string.Empty;
                        Data_this_AccDef.Telphone1 = string.Empty;
                        Data_this_AccDef.Telphone2 = string.Empty;
                        Data_this_AccDef.Fax = string.Empty;
                        Data_this_AccDef.DesPers = string.Empty;
                        Data_this_AccDef.StrAm = 0;
                        Data_this_AccDef.Adders = string.Empty;
                        Data_this_AccDef.Price = 0;
                        Data_this_AccDef.Mnd = null;
                        Data_this_AccDef.StopInvTyp = 0;
                        Data_this_AccDef.CompanyID = 1;
                        Data_this_AccDef.BankComm = 0.0;
                        Data_this_AccDef.TotPoints = 0.0;
                        Data_this_AccDef.Debit = 0.0;
                        Data_this_AccDef.Credit = 0.0;
                        Data_this_AccDef.Balance = 0.0;
                        Data_this_AccDef.DateAppointment = string.Empty;
                        Data_this_AccDef.ID_Date = string.Empty;
                        Data_this_AccDef.ID_DateEnd = string.Empty;
                        Data_this_AccDef.Passport_Date = string.Empty;
                        Data_this_AccDef.Insurance_Date = string.Empty;
                        Data_this_AccDef.Passport_DateEnd = string.Empty;
                        Data_this_AccDef.Insurance_DateEnd = string.Empty;
                        Data_this_AccDef.ID_No = string.Empty;
                        Data_this_AccDef.Passport_No = string.Empty;
                        Data_this_AccDef.Insurance_No = string.Empty;
                        Data_this_AccDef.ID_From = string.Empty;
                        Data_this_AccDef.Passport_From = string.Empty;
                        Data_this_AccDef.Insurance_From = string.Empty;
                        Data_this_AccDef.TaxNo = string.Empty;
                        Data_this_AccDef.DepreciationPercent = 0.0;
                        Data_this_AccDef.MaxDisCust = 0.0;
                        Data_this_AccDef.vColNum1 = 0.0;
                        Data_this_AccDef.vColNum2 = 0.0;
                        Data_this_AccDef.vColStr1 = string.Empty;
                        Data_this_AccDef.vColStr2 = string.Empty;
                        Data_this_AccDef.vColStr3 = string.Empty;
                        Data_this_AccDef.ProofAcc = string.Empty;
                        Data_this_AccDef.RelayAcc = string.Empty;
                        Data_this_AccDef.MainSal = 0.0;
                        dbx.T_AccDefs.InsertOnSubmit(Data_this_AccDef);
                        dbx.SubmitChanges();
                        try
                        {
                            ExcelGridView.Rows.RemoveAt(i);
                            i = 0;
                        }
                        catch
                        {
                        }
                        vLoop = true;
                    }
                    catch
                    {
                    }
                }
                MessageBox.Show((LangArEn == 0) ? "تم استيراد البيانات بنجاح " : "Data were imported attendance successfully", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                GridStyle();
                State = FormState.Saved;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_OK_Click:", error, enable: true);
                MessageBox.Show(error.Message);
                GridStyle();
                State = FormState.Saved;
            }
        }
        private int DTime(string BTime, string Etime)
        {
            try
            {
                if (string.IsNullOrEmpty(BTime) || string.IsNullOrEmpty(Etime))
                {
                    return 0;
                }
                if (!VarGeneral.CheckDate(BTime) || !VarGeneral.CheckDate(Etime))
                {
                    return 0;
                }
                int LAmount = 0;
                if (TimeSpan.Parse(Etime) > TimeSpan.Parse(BTime))
                {
                    LAmount = int.Parse(Etime.Substring(3, 2)) - int.Parse(BTime.Substring(3, 2));
                    LAmount += 60 * (int.Parse(Etime.Substring(0, 2)) - int.Parse(BTime.Substring(0, 2)));
                }
                return LAmount;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("DTime:", error, enable: true);
                MessageBox.Show(error.Message);
                return 0;
            }
        }
        private void releaseObject(object obj)
        {
            try
            {
                Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        private void GridStyle()
        {
            try
            {
                for (int i = 0; i < ExcelGridView.Rows.Count; i += 2)
                {
                    ExcelGridView.Rows[i].DefaultCellStyle.BackColor = Color.PapayaWhip;
                }
            }
            catch
            {
            }
        }
        private void FrmCustSuppImport_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void FrmCustSuppImport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private bool IsInteger(string num)
        {
#pragma warning disable CS0219 // The variable 'vState' is assigned but its value is never used
            bool vState = false;
#pragma warning restore CS0219 // The variable 'vState' is assigned but its value is never used
            try
            {
                double.Parse(num);
                return true;
            }
            catch
            {
                vState = false;
            }
            try
            {
                TimeSpan dt = TimeSpan.Parse(num);
                return true;
            }
            catch
            {
                vState = false;
            }
            try
            {
                if (n.IsGreg(num) || n.IsHijri(num))
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        private void FillGrid()
        {
            Thread t = new Thread(SplashStart);
            t.Start();
            Thread.Sleep(10);
            if (buttonX_ImportFile.Checked)
            {
                if (string.IsNullOrEmpty(textBox_SearchFilePath.Text))
                {
                    return;
                }
                if (File.Exists(textBox_SearchFilePath.Text))
                {
                    try
                    {
                        ExcelGridView.DataSource = null;
                        ExcelGridView.Rows.Clear();
                        ExcelGridView.Columns.Clear();
                    }
                    catch
                    {
                    }
                    ExcelGridView.DataSource = ConvertExcelToDataTable(textBox_SearchFilePath.Text);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(textBox_SearchFilePath.Text))
                {
                    return;
                }
                if (File.Exists(textBox_SearchFilePath.Text))
                {
                    try
                    {
                        ExcelGridView.DataSource = null;
                        ExcelGridView.Rows.Clear();
                        ExcelGridView.Columns.Clear();
                    }
                    catch
                    {
                    }
                    StreamReader file = new StreamReader(textBox_SearchFilePath.Text, Encoding.Default, detectEncodingFromByteOrderMarks: true);
                    textBox1.Text = file.ReadToEnd();
                    int iicnt = 0;
                    for (int c = 0; c < ColumnsFinger.Count; c++)
                    {
                        ExcelGridView.Columns.Add(ColumnsFinger[c], ColumnsFinger[c]);
                    }
                    for (int i = 0; i < textBox1.Lines.Count(); i++)
                    {
                        ExcelGridView.Rows.Add();
                        if (!string.IsNullOrEmpty(textBox1.Lines[i]))
                        {
                            string newline = textBox1.Lines[i];
                            string[] values = newline.TrimStart().Split(' ');
                            for (int q = 0; q < values.Count(); q++)
                            {
                                if (IsInteger(values[q]) || string.IsNullOrEmpty(values[q]))
                                {
                                    ExcelGridView.Rows[i].Cells[iicnt].Value = values[q].ToString();
                                    iicnt++;
                                }
                            }
                        }
                        iicnt = 0;
                    }
                    try
                    {
                        ExcelGridView.Rows.RemoveAt(0);
                    }
                    catch
                    {
                    }
                    try
                    {
                        bool Empty = true;
                        for (int i = 0; i < ExcelGridView.Rows.Count; i++)
                        {
                            Empty = true;
                            for (int j = 0; j < ExcelGridView.Columns.Count; j++)
                            {
                                if (ExcelGridView.Rows[i].Cells[j].Value != null && ExcelGridView.Rows[i].Cells[j].Value.ToString() != string.Empty)
                                {
                                    Empty = false;
                                    break;
                                }
                            }
                            if (Empty)
                            {
                                ExcelGridView.Rows.RemoveAt(i);
                            }
                        }
                    }
                    catch
                    {
                    }
                }
            }
            t.Abort();
            GridStyle();
        }
        private void textBox_EmpNo_Click(object sender, EventArgs e)
        {
            textBox_AccNo.SelectAll();
        }
        private void textBox_Time1_Click(object sender, EventArgs e)
        {
            textBox_NameA.SelectAll();
        }
        private void textBox_TimeLeave1_Click(object sender, EventArgs e)
        {
            textBox_NameE.SelectAll();
        }
        private void ExcelGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int col = e.ColumnIndex;
            try
            {
                if (!string.IsNullOrEmpty(textBox_NameA.Text) && ExcelGridView.Columns[col].Name == textBox_NameA.Text)
                {
                    if (!VarGeneral.CheckTime(ExcelGridView.Rows[row].Cells[col].Value.ToString()))
                    {
                        ExcelGridView.Rows[row].Cells[col].Value = string.Empty;
                    }
                    else
                    {
                        ExcelGridView.Rows[row].Cells[col].Value = Convert.ToDateTime(ExcelGridView.Rows[row].Cells[col].Value.ToString()).ToString("HH:mm");
                    }
                }
                if (!string.IsNullOrEmpty(textBox_NameE.Text) && ExcelGridView.Columns[col].Name == textBox_NameE.Text)
                {
                    if (!VarGeneral.CheckTime(ExcelGridView.Rows[row].Cells[col].Value.ToString()))
                    {
                        ExcelGridView.Rows[row].Cells[col].Value = string.Empty;
                    }
                    else
                    {
                        ExcelGridView.Rows[row].Cells[col].Value = Convert.ToDateTime(ExcelGridView.Rows[row].Cells[col].Value.ToString()).ToString("HH:mm");
                    }
                }
            }
            catch
            {
                ExcelGridView.Rows[row].Cells[col].Value = string.Empty;
            }
        }
        System.Data.DataTable ConvertExcelToDataTable(string FileName)
        {
            Worksheet worksheet = (Worksheet)new ApplicationClass().Workbooks.Open(this.textBox_SearchFilePath.Text, 0, true, 5, string.Empty, string.Empty, true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0).Worksheets.get_Item(1);
            Range used_range = worksheet.UsedRange;
            int max_row = used_range.Rows.Count;
            int max_col = used_range.Columns.Count;
            System.Data.DataTable td = new System.Data.DataTable();
            // Get the sheet's values.d
            object[,] values = (object[,])used_range.Value2;
            for (int i = 0; i < max_col; i++)
            {
                td.Columns.Add(ColumnsFinger[i]);
                //       td.Columns[i].ColumnName = ColumnsFinger[i];
            }
            // Copy the values into the grid.
            for (int row = 2; row <= max_row; row++)
            {
                object[] row_values = new object[max_col];
                for (int col = 1; col <= max_col; col++)
                    row_values[col - 1] = values[row, col];
                td.Rows.Add(row_values);
            }
            return
                td;
        }
        private void buttonX_ImportFile_Click(object sender, EventArgs e)
        {
            try
            {
                buttonX_ImportFile.Checked = true;
           System.Windows.Forms. OpenFileDialog  openFileDialog1 = new System.Windows.Forms. OpenFileDialog (); 
                openFileDialog1.Filter = "Excel Files(.xls)|*.xls|Excel Files(.xlsx)|*.xlsx| Excel Files(*.xlsm)|*.xlsm";
                try
                {
                    if (VarGeneral.gUserName == "runsetting")
                    {
                        openFileDialog1.InitialDirectory = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
                    }
                }
                catch
                {
                }
                openFileDialog1.Title = "اختيار ملف الأصناف";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    textBox_SearchFilePath.Text = openFileDialog1.FileName;
                    FillGrid();
                    return;
                }
                textBox_SearchFilePath.Text = string.Empty;
                try
                {
                    ExcelGridView.DataSource = null;
                    ExcelGridView.Rows.Clear();
                    ExcelGridView.Columns.Clear();
                }
                catch
                {
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_SelectPath_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void SetColumns()
        {
            ColumnsFinger.Clear();
            ColumnsFinger.Add("A");
            ColumnsFinger.Add("B");
            ColumnsFinger.Add("C");
            ColumnsFinger.Add("D");
            ColumnsFinger.Add("E");
            ColumnsFinger.Add("F");
            ColumnsFinger.Add("G");
            ColumnsFinger.Add("H");
            ColumnsFinger.Add("I");
            ColumnsFinger.Add("J");
            ColumnsFinger.Add("K");
            ColumnsFinger.Add("L");
            ColumnsFinger.Add("M");
            ColumnsFinger.Add("N");
            ColumnsFinger.Add("O");
            ColumnsFinger.Add("P");
            ColumnsFinger.Add("Q");
            ColumnsFinger.Add("S");
            ColumnsFinger.Add("T");
            ColumnsFinger.Add("U");
            ColumnsFinger.Add("V");
            ColumnsFinger.Add("W");
            ColumnsFinger.Add("Y");
            ColumnsFinger.Add("Z");
            ColumnsFinger.Add("AA");
            ColumnsFinger.Add("AB");
            ColumnsFinger.Add("AC");
            ColumnsFinger.Add("AD");
            ColumnsFinger.Add("AE");
            ColumnsFinger.Add("AF");
            ColumnsFinger.Add("AG");
            ColumnsFinger.Add("AH");
            ColumnsFinger.Add("AI");
            ColumnsFinger.Add("AJ");
            ColumnsFinger.Add("AK");
            ColumnsFinger.Add("AL");
            ColumnsFinger.Add("AM");
            ColumnsFinger.Add("AN");
            ColumnsFinger.Add("AO");
            ColumnsFinger.Add("AP");
            ColumnsFinger.Add("AQ");
            ColumnsFinger.Add("AS");
            ColumnsFinger.Add("AT");
            ColumnsFinger.Add("AU");
            ColumnsFinger.Add("AV");
            ColumnsFinger.Add("AW");
            ColumnsFinger.Add("AY");
            ColumnsFinger.Add("AZ");
            ColumnsFinger.Add("BA");
            ColumnsFinger.Add("BB");
            ColumnsFinger.Add("BC");
            ColumnsFinger.Add("BD");
            ColumnsFinger.Add("BE");
            ColumnsFinger.Add("BF");
            ColumnsFinger.Add("BG");
            ColumnsFinger.Add("BH");
            ColumnsFinger.Add("BI");
            ColumnsFinger.Add("BJ");
            ColumnsFinger.Add("BK");
            ColumnsFinger.Add("BL");
            ColumnsFinger.Add("BM");
            ColumnsFinger.Add("BN");
            ColumnsFinger.Add("BO");
            ColumnsFinger.Add("BP");
            ColumnsFinger.Add("BQ");
            ColumnsFinger.Add("BS");
            ColumnsFinger.Add("BT");
            ColumnsFinger.Add("BU");
            ColumnsFinger.Add("BV");
            ColumnsFinger.Add("BW");
            ColumnsFinger.Add("BY");
            ColumnsFinger.Add("BZ");
            ColumnsFinger.Add("CA");
            ColumnsFinger.Add("CB");
            ColumnsFinger.Add("CC");
            ColumnsFinger.Add("CD");
            ColumnsFinger.Add("CE");
            ColumnsFinger.Add("CF");
            ColumnsFinger.Add("CG");
            ColumnsFinger.Add("CH");
            ColumnsFinger.Add("CI");
            ColumnsFinger.Add("CJ");
            ColumnsFinger.Add("CK");
            ColumnsFinger.Add("CL");
            ColumnsFinger.Add("CM");
            ColumnsFinger.Add("CN");
            ColumnsFinger.Add("CO");
            ColumnsFinger.Add("CP");
            ColumnsFinger.Add("CQ");
            ColumnsFinger.Add("CS");
            ColumnsFinger.Add("CT");
            ColumnsFinger.Add("CU");
            ColumnsFinger.Add("CV");
            ColumnsFinger.Add("CW");
            ColumnsFinger.Add("CY");
            ColumnsFinger.Add("CZ");
            ColumnsFinger.Add("DA");
            ColumnsFinger.Add("DB");
            ColumnsFinger.Add("DC");
            ColumnsFinger.Add("DE");
            ColumnsFinger.Add("DD");
            ColumnsFinger.Add("DF");
            ColumnsFinger.Add("DG");
            ColumnsFinger.Add("DH");
            ColumnsFinger.Add("DI");
            ColumnsFinger.Add("DJ");
            ColumnsFinger.Add("DK");
            ColumnsFinger.Add("DL");
            ColumnsFinger.Add("DM");
            ColumnsFinger.Add("DN");
            ColumnsFinger.Add("DO");
            ColumnsFinger.Add("DP");
            ColumnsFinger.Add("DQ");
            ColumnsFinger.Add("DS");
            ColumnsFinger.Add("DT");
            ColumnsFinger.Add("DU");
            ColumnsFinger.Add("DV");
            ColumnsFinger.Add("DW");
            ColumnsFinger.Add("DY");
            ColumnsFinger.Add("DZ");
            ColumnsFinger.Add("EA");
            ColumnsFinger.Add("EB");
            ColumnsFinger.Add("EC");
            ColumnsFinger.Add("ED");
            ColumnsFinger.Add("EE");
            ColumnsFinger.Add("EF");
            ColumnsFinger.Add("EG");
            ColumnsFinger.Add("EH");
            ColumnsFinger.Add("EI");
            ColumnsFinger.Add("EJ");
            ColumnsFinger.Add("EK");
            ColumnsFinger.Add("EL");
            ColumnsFinger.Add("EM");
            ColumnsFinger.Add("EN");
            ColumnsFinger.Add("EO");
            ColumnsFinger.Add("EP");
            ColumnsFinger.Add("EQ");
            ColumnsFinger.Add("ES");
            ColumnsFinger.Add("ET");
            ColumnsFinger.Add("EU");
            ColumnsFinger.Add("EV");
            ColumnsFinger.Add("EW");
            ColumnsFinger.Add("EY");
            ColumnsFinger.Add("EZ");
            ColumnsFinger.Add("FA");
            ColumnsFinger.Add("FB");
            ColumnsFinger.Add("FC");
            ColumnsFinger.Add("FD");
            ColumnsFinger.Add("FE");
            ColumnsFinger.Add("FF");
            ColumnsFinger.Add("FG");
            ColumnsFinger.Add("FH");
            ColumnsFinger.Add("FI");
            ColumnsFinger.Add("FJ");
            ColumnsFinger.Add("FK");
            ColumnsFinger.Add("FL");
            ColumnsFinger.Add("FM");
            ColumnsFinger.Add("FN");
            ColumnsFinger.Add("FO");
            ColumnsFinger.Add("FP");
            ColumnsFinger.Add("FQ");
            ColumnsFinger.Add("FS");
            ColumnsFinger.Add("FT");
            ColumnsFinger.Add("FU");
            ColumnsFinger.Add("FV");
            ColumnsFinger.Add("FW");
            ColumnsFinger.Add("FY");
            ColumnsFinger.Add("FZ");
            ColumnsFinger.Add("GA");
            ColumnsFinger.Add("GB");
            ColumnsFinger.Add("GC");
            ColumnsFinger.Add("GD");
            ColumnsFinger.Add("GE");
            ColumnsFinger.Add("GF");
            ColumnsFinger.Add("GG");
            ColumnsFinger.Add("GH");
            ColumnsFinger.Add("GI");
            ColumnsFinger.Add("GJ");
            ColumnsFinger.Add("GK");
            ColumnsFinger.Add("GL");
            ColumnsFinger.Add("GM");
            ColumnsFinger.Add("GN");
            ColumnsFinger.Add("GO");
            ColumnsFinger.Add("GP");
            ColumnsFinger.Add("GQ");
            ColumnsFinger.Add("GS");
            ColumnsFinger.Add("GT");
            ColumnsFinger.Add("GU");
            ColumnsFinger.Add("GV");
            ColumnsFinger.Add("GW");
            ColumnsFinger.Add("GY");
            ColumnsFinger.Add("GZ");
        }
        private void ExcelGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void buttonX_SerchAccNo_Click(object sender, EventArgs e)
        {
            FrmSearch frm;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection;
            if (VarGeneral.ImportDataType == 4)
            {
                columns_Names_visible.Clear();
                columns_Names_visible.Clear();
                columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
                columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
                columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
                columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
                frm = new FrmSearch();
                frm.Tag = LangArEn;
                animalsAsCollection = columns_Names_visible;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "AccDefID_Customer";
                VarGeneral.AccTyp = 4;
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != string.Empty)
                {
                    textBox_AccNo.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                }
                else
                {
                    textBox_AccNo.Text = string.Empty;
                }
                return;
            }
            columns_Names_visible.Clear();
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            frm = new FrmSearch();
            frm.Tag = LangArEn;
            animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Customer";
            VarGeneral.AccTyp = 5;
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                textBox_AccNo.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
            }
            else
            {
                textBox_AccNo.Text = string.Empty;
            }
        }
        private void textBox_Mobile_Click(object sender, EventArgs e)
        {
            textBox_Mobile.SelectAll();
        }
    }
}
