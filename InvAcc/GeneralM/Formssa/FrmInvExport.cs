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
    public partial class FrmInvExport : Form
    {
        private List<string> ColumnsFinger = new List<string>();
        private int LangArEn = 0;
        public List<Control> controls;
        public Control codeControl = new Control();
        private FormState statex;
        public bool CanEdit = true;
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private List<string> pkeys = new List<string>();
        private T_Item Data_this_Itm;
        private Stock_DataDataContext dbInstance;
        private IContainer components = null;
        private Panel panel2;
        protected Panel panel5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private ButtonX buttonX_ImportFile;
        private System.Windows.Forms.TextBox textBox_SearchFilePath;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label29;
        public DataGridView ExcelGridView;
        public System.Windows.Forms.TextBox textBox_ItmNo;
        public System.Windows.Forms.TextBox textBox_NameE;
        public System.Windows.Forms.TextBox textBox_NameA;
        public System.Windows.Forms.TextBox textBox_Store;
        public System.Windows.Forms.TextBox textBox_Qty;
        public System.Windows.Forms.TextBox textBox_Price;
        public System.Windows.Forms.TextBox textBox_Discount;
        public System.Windows.Forms.TextBox textBox_DateExpir;
        public System.Windows.Forms.TextBox textBox_RunNo;
        public System.Windows.Forms.TextBox textBox_Tax;
        public System.Windows.Forms.TextBox textBox_Unt;
        private ButtonX Button_Cancel;
        private ButtonX button_OK;
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
        public T_Item Datathis_Itm
        {
            get
            {
                return Data_this_Itm;
            }
            set
            {
                Data_this_Itm = value;
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
        public FrmInvExport()
        {
            InitializeComponent();
            SetColumns();
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmInvExport));
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
        private void FrmInvExport_Load(object sender, EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmInvExport));
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                Language.ChangeLanguage("ar-SA", this, resources);
                LangArEn = 0;
                Text = "إستيراد بيانات الأصناف الى الفاتورة";
            }
            else
            {
                Language.ChangeLanguage("en", this, resources);
                LangArEn = 1;
                button_OK.Text = "OK";
                Button_Cancel.Text = "Exit";
                Text = "Import items data to invoice";
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
                        controls[i].Text = "";
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
                controls.Add(textBox_ItmNo);
                controls.Add(textBox_SearchFilePath);
                controls.Add(textBox_NameA);
                controls.Add(textBox_NameE);
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
            if (string.IsNullOrEmpty(textBox_ItmNo.Text))
            {
                MessageBox.Show((LangArEn == 0) ? "لابد من تخصيص عمود رقم الصنف" : "Must customize column employee number ?", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBox_ItmNo.Focus();
            }
            else
            {
                Close();
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
        private void FrmInvExport_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void FrmInvExport_KeyDown(object sender, KeyEventArgs e)
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
            bool vState = false;
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
                                if (ExcelGridView.Rows[i].Cells[j].Value != null && ExcelGridView.Rows[i].Cells[j].Value.ToString() != "")
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
        private object ConvertExcelToDataTable(string text)
        {
            Worksheet worksheet = (Worksheet)new ApplicationClass().Workbooks.Open(this.textBox_SearchFilePath.Text, 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0).Worksheets.get_Item(1);
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
        private void textBox_EmpNo_Click(object sender, EventArgs e)
        {
            textBox_ItmNo.SelectAll();
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
                        ExcelGridView.Rows[row].Cells[col].Value = "";
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
                        ExcelGridView.Rows[row].Cells[col].Value = "";
                    }
                    else
                    {
                        ExcelGridView.Rows[row].Cells[col].Value = Convert.ToDateTime(ExcelGridView.Rows[row].Cells[col].Value.ToString()).ToString("HH:mm");
                    }
                }
            }
            catch
            {
                ExcelGridView.Rows[row].Cells[col].Value = "";
            }
        }
        private void buttonX_ImportFile_Click(object sender, EventArgs e)
        {
            try
            {
                buttonX_ImportFile.Checked = true;
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
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
                textBox_SearchFilePath.Text = "";
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmInvExport));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            panel2 = new System.Windows.Forms.Panel();
            Button_Cancel = new DevComponents.DotNetBar.ButtonX();
            button_OK = new DevComponents.DotNetBar.ButtonX();
            textBox1 = new System.Windows.Forms.TextBox();
            buttonX_ImportFile = new DevComponents.DotNetBar.ButtonX();
            textBox_SearchFilePath = new System.Windows.Forms.TextBox();
            groupBox1 = new System.Windows.Forms.GroupBox();
            textBox_Unt = new System.Windows.Forms.TextBox();
            label29 = new System.Windows.Forms.Label();
            textBox_RunNo = new System.Windows.Forms.TextBox();
            textBox_Tax = new System.Windows.Forms.TextBox();
            textBox_DateExpir = new System.Windows.Forms.TextBox();
            label9 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            textBox_Discount = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            textBox_Price = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            textBox_Qty = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            textBox_Store = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            textBox_ItmNo = new System.Windows.Forms.TextBox();
            textBox_NameE = new System.Windows.Forms.TextBox();
            textBox_NameA = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            ExcelGridView = new System.Windows.Forms.DataGridView();
            panel5 = new System.Windows.Forms.Panel();
            panel2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ExcelGridView).BeginInit();
            SuspendLayout();
            panel2.AccessibleDescription = null;
            panel2.AccessibleName = null;
            resources.ApplyResources(panel2, "panel2");
            panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            panel2.BackgroundImage = null;
            panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel2.Controls.Add(Button_Cancel);
            panel2.Controls.Add(button_OK);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(buttonX_ImportFile);
            panel2.Controls.Add(textBox_SearchFilePath);
            panel2.Controls.Add(groupBox1);
            panel2.Controls.Add(ExcelGridView);
            panel2.Font = null;
            panel2.Name = "panel2";
            Button_Cancel.AccessibleDescription = null;
            Button_Cancel.AccessibleName = null;
            Button_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(Button_Cancel, "Button_Cancel");
            Button_Cancel.BackgroundImage = null;
            Button_Cancel.Checked = true;
            Button_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            Button_Cancel.CommandParameter = null;
            Button_Cancel.Name = "Button_Cancel";
            Button_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            Button_Cancel.Symbol = "\uf011";
            Button_Cancel.SymbolSize = 16f;
            Button_Cancel.TextColor = System.Drawing.Color.Black;
            Button_Cancel.Click += new System.EventHandler(Button_Cancel_Click);
            button_OK.AccessibleDescription = null;
            button_OK.AccessibleName = null;
            button_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(button_OK, "button_OK");
            button_OK.BackgroundImage = null;
            button_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            button_OK.CommandParameter = null;
            button_OK.Name = "button_OK";
            button_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_OK.Symbol = "\uf0c5";
            button_OK.SymbolSize = 16f;
            button_OK.TextColor = System.Drawing.Color.White;
            button_OK.Click += new System.EventHandler(button_OK_Click);
            textBox1.AccessibleDescription = null;
            textBox1.AccessibleName = null;
            resources.ApplyResources(textBox1, "textBox1");
            textBox1.BackgroundImage = null;
            textBox1.Name = "textBox1";
            buttonX_ImportFile.AccessibleDescription = null;
            buttonX_ImportFile.AccessibleName = null;
            buttonX_ImportFile.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(buttonX_ImportFile, "buttonX_ImportFile");
            buttonX_ImportFile.BackgroundImage = null;
            buttonX_ImportFile.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
            buttonX_ImportFile.CommandParameter = null;
            buttonX_ImportFile.Name = "buttonX_ImportFile";
            buttonX_ImportFile.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            buttonX_ImportFile.Click += new System.EventHandler(buttonX_ImportFile_Click);
            textBox_SearchFilePath.AccessibleDescription = null;
            textBox_SearchFilePath.AccessibleName = null;
            resources.ApplyResources(textBox_SearchFilePath, "textBox_SearchFilePath");
            textBox_SearchFilePath.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
            textBox_SearchFilePath.BackgroundImage = null;
            textBox_SearchFilePath.ForeColor = System.Drawing.Color.Red;
            textBox_SearchFilePath.Name = "textBox_SearchFilePath";
            textBox_SearchFilePath.ReadOnly = true;
            groupBox1.AccessibleDescription = null;
            groupBox1.AccessibleName = null;
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.BackColor = System.Drawing.Color.Transparent;
            groupBox1.BackgroundImage = null;
            groupBox1.Controls.Add(textBox_Unt);
            groupBox1.Controls.Add(label29);
            groupBox1.Controls.Add(textBox_RunNo);
            groupBox1.Controls.Add(textBox_Tax);
            groupBox1.Controls.Add(textBox_DateExpir);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(textBox_Discount);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(textBox_Price);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBox_Qty);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBox_Store);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox_ItmNo);
            groupBox1.Controls.Add(textBox_NameE);
            groupBox1.Controls.Add(textBox_NameA);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            textBox_Unt.AccessibleDescription = null;
            textBox_Unt.AccessibleName = null;
            resources.ApplyResources(textBox_Unt, "textBox_Unt");
            textBox_Unt.BackColor = System.Drawing.Color.White;
            textBox_Unt.BackgroundImage = null;
            textBox_Unt.ForeColor = System.Drawing.Color.Red;
            textBox_Unt.Name = "textBox_Unt";
            label29.AccessibleDescription = null;
            label29.AccessibleName = null;
            resources.ApplyResources(label29, "label29");
            label29.BackColor = System.Drawing.Color.Transparent;
            label29.Name = "label29";
            textBox_RunNo.AccessibleDescription = null;
            textBox_RunNo.AccessibleName = null;
            resources.ApplyResources(textBox_RunNo, "textBox_RunNo");
            textBox_RunNo.BackgroundImage = null;
            textBox_RunNo.ForeColor = System.Drawing.Color.Red;
            textBox_RunNo.Name = "textBox_RunNo";
            textBox_Tax.AccessibleDescription = null;
            textBox_Tax.AccessibleName = null;
            resources.ApplyResources(textBox_Tax, "textBox_Tax");
            textBox_Tax.BackgroundImage = null;
            textBox_Tax.ForeColor = System.Drawing.Color.Red;
            textBox_Tax.Name = "textBox_Tax";
            textBox_DateExpir.AccessibleDescription = null;
            textBox_DateExpir.AccessibleName = null;
            resources.ApplyResources(textBox_DateExpir, "textBox_DateExpir");
            textBox_DateExpir.BackgroundImage = null;
            textBox_DateExpir.ForeColor = System.Drawing.Color.Red;
            textBox_DateExpir.Name = "textBox_DateExpir";
            label9.AccessibleDescription = null;
            label9.AccessibleName = null;
            resources.ApplyResources(label9, "label9");
            label9.BackColor = System.Drawing.Color.Transparent;
            label9.Name = "label9";
            label10.AccessibleDescription = null;
            label10.AccessibleName = null;
            resources.ApplyResources(label10, "label10");
            label10.BackColor = System.Drawing.Color.Transparent;
            label10.Name = "label10";
            label11.AccessibleDescription = null;
            label11.AccessibleName = null;
            resources.ApplyResources(label11, "label11");
            label11.BackColor = System.Drawing.Color.Transparent;
            label11.Name = "label11";
            label7.AccessibleDescription = null;
            label7.AccessibleName = null;
            resources.ApplyResources(label7, "label7");
            label7.BackColor = System.Drawing.Color.Transparent;
            label7.Name = "label7";
            textBox_Discount.AccessibleDescription = null;
            textBox_Discount.AccessibleName = null;
            resources.ApplyResources(textBox_Discount, "textBox_Discount");
            textBox_Discount.BackgroundImage = null;
            textBox_Discount.ForeColor = System.Drawing.Color.Red;
            textBox_Discount.Name = "textBox_Discount";
            label6.AccessibleDescription = null;
            label6.AccessibleName = null;
            resources.ApplyResources(label6, "label6");
            label6.BackColor = System.Drawing.Color.Transparent;
            label6.Name = "label6";
            textBox_Price.AccessibleDescription = null;
            textBox_Price.AccessibleName = null;
            resources.ApplyResources(textBox_Price, "textBox_Price");
            textBox_Price.BackgroundImage = null;
            textBox_Price.ForeColor = System.Drawing.Color.Red;
            textBox_Price.Name = "textBox_Price";
            label3.AccessibleDescription = null;
            label3.AccessibleName = null;
            resources.ApplyResources(label3, "label3");
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Name = "label3";
            textBox_Qty.AccessibleDescription = null;
            textBox_Qty.AccessibleName = null;
            resources.ApplyResources(textBox_Qty, "textBox_Qty");
            textBox_Qty.BackgroundImage = null;
            textBox_Qty.ForeColor = System.Drawing.Color.Red;
            textBox_Qty.Name = "textBox_Qty";
            label2.AccessibleDescription = null;
            label2.AccessibleName = null;
            resources.ApplyResources(label2, "label2");
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Name = "label2";
            textBox_Store.AccessibleDescription = null;
            textBox_Store.AccessibleName = null;
            resources.ApplyResources(textBox_Store, "textBox_Store");
            textBox_Store.BackgroundImage = null;
            textBox_Store.ForeColor = System.Drawing.Color.Red;
            textBox_Store.Name = "textBox_Store";
            label1.AccessibleDescription = null;
            label1.AccessibleName = null;
            resources.ApplyResources(label1, "label1");
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Name = "label1";
            textBox_ItmNo.AccessibleDescription = null;
            textBox_ItmNo.AccessibleName = null;
            resources.ApplyResources(textBox_ItmNo, "textBox_ItmNo");
            textBox_ItmNo.BackColor = System.Drawing.Color.Yellow;
            textBox_ItmNo.BackgroundImage = null;
            textBox_ItmNo.ForeColor = System.Drawing.Color.Red;
            textBox_ItmNo.Name = "textBox_ItmNo";
            textBox_ItmNo.Click += new System.EventHandler(textBox_EmpNo_Click);
            textBox_NameE.AccessibleDescription = null;
            textBox_NameE.AccessibleName = null;
            resources.ApplyResources(textBox_NameE, "textBox_NameE");
            textBox_NameE.BackColor = System.Drawing.Color.White;
            textBox_NameE.BackgroundImage = null;
            textBox_NameE.ForeColor = System.Drawing.Color.Red;
            textBox_NameE.Name = "textBox_NameE";
            textBox_NameE.Click += new System.EventHandler(textBox_TimeLeave1_Click);
            textBox_NameA.AccessibleDescription = null;
            textBox_NameA.AccessibleName = null;
            resources.ApplyResources(textBox_NameA, "textBox_NameA");
            textBox_NameA.BackColor = System.Drawing.Color.White;
            textBox_NameA.BackgroundImage = null;
            textBox_NameA.ForeColor = System.Drawing.Color.Red;
            textBox_NameA.Name = "textBox_NameA";
            textBox_NameA.Click += new System.EventHandler(textBox_Time1_Click);
            label5.AccessibleDescription = null;
            label5.AccessibleName = null;
            resources.ApplyResources(label5, "label5");
            label5.BackColor = System.Drawing.Color.Transparent;
            label5.Name = "label5";
            label4.AccessibleDescription = null;
            label4.AccessibleName = null;
            resources.ApplyResources(label4, "label4");
            label4.BackColor = System.Drawing.Color.Transparent;
            label4.Name = "label4";
            ExcelGridView.AccessibleDescription = null;
            ExcelGridView.AccessibleName = null;
            ExcelGridView.AllowUserToAddRows = false;
            ExcelGridView.AllowUserToDeleteRows = false;
            resources.ApplyResources(ExcelGridView, "ExcelGridView");
            ExcelGridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            ExcelGridView.BackgroundImage = null;
            ExcelGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            ExcelGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            ExcelGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            ExcelGridView.DefaultCellStyle = dataGridViewCellStyle2;
            ExcelGridView.Font = null;
            ExcelGridView.MultiSelect = false;
            ExcelGridView.Name = "ExcelGridView";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            ExcelGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            ExcelGridView.RowHeadersVisible = false;
            ExcelGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(ExcelGridView_CellEndEdit);
            panel5.AccessibleDescription = null;
            panel5.AccessibleName = null;
            resources.ApplyResources(panel5, "panel5");
            panel5.BackColor = System.Drawing.Color.SteelBlue;
            panel5.BackgroundImage = null;
            panel5.Font = null;
            panel5.Name = "panel5";
            base.AccessibleDescription = null;
            base.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            BackgroundImage = null;
            base.Controls.Add(panel5);
            base.Controls.Add(panel2);
            Font = null;
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.KeyPreview = true;
            base.MaximizeBox = false;
            base.Name = "FrmInvExport";
            base.Load += new System.EventHandler(FrmInvExport_Load);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(FrmInvExport_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(FrmInvExport_KeyDown);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ExcelGridView).EndInit();
            ResumeLayout(false);
        }
    }
}
