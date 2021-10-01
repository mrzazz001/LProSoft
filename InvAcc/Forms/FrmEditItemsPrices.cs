using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using SSSDateTime.Date;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmEditItemsPrices : Form
    { void avs(int arln)

{ 
 toolStripMenuItem1.Text=   (arln == 0 ? "  إظهار التفاصيل  " : "  Show details") ; toolStripMenuItem2.Text=   (arln == 0 ? "  إظهار التقرير  " : "  Show report") ; label4.Text=   (arln == 0 ? "  سعر التكلفة  :  " : "  Cost price  :") ; label28.Text=   (arln == 0 ? "  سعر الجملة  " : "  Wholesale price") ; label24.Text=   (arln == 0 ? "  سعر المندوب  " : "  delegate price") ; label27.Text=   (arln == 0 ? "  سعر الموزع  " : "  distributor price") ; label26.Text=   (arln == 0 ? "  سعر اخر  " : "  another price") ; label25.Text=   (arln == 0 ? "  سعر التجزئة  " : "  retail price") ; label12.Text=   (arln == 0 ? "  رقم الصنــــف :  " : "  Item No.:") ; label7.Text=   (arln == 0 ? "  الوحـــــدة :  " : "  Unity:") ; label6.Text=   (arln == 0 ? "  سعر البيع 5 :  " : "  Selling price 5:") ; label5.Text=   (arln == 0 ? "  سعر البيع 4 :  " : "  Selling price 4:") ; label3.Text=   (arln == 0 ? "  سعر البيع 3 :  " : "  Selling Price 3:") ; label2.Text=   (arln == 0 ? "  سعر البيع 2 :  " : "  Selling price 2:") ; label1.Text=   (arln == 0 ? "  سعر البيع 1 :  " : "  Selling price 1:") ; superTabControl_Main1.Text=   (arln == 0 ? "  superTabControl3  " : "  superTabControl3") ; Button_Close.Text=   (arln == 0 ? "  إغلاق  " : "  Close") ; Button_Save.Text=   (arln == 0 ? "  حفظ  " : "  save") ; Text = "شاشة تعديل اسعار الصنف";this.Text=   (arln == 0 ? "  شاشة تعديل اسعار الصنف  " : "  Item price adjustment screen") ;}
        private void langloads(object sender, EventArgs e)
        {
              avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
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
       // private IContainer components = null;
        private DockSite dockSite5;
        protected ContextMenuStrip contextMenuStrip3;
        protected ToolStripMenuItem toolStripMenuItem1;
        private DockSite dockSite6;
        protected ToolStripMenuItem toolStripMenuItem2;
        private DockSite dockSite7;
        private System.Windows.Forms. SaveFileDialog saveFileDialog2;
        private DockSite dockSite8;
        private DockSite dockSite9;
        private DockSite dockSite10;
        private DockSite dockSite11;
        private DockSite dockSite12;
        protected ContextMenuStrip contextMenuStrip4;
        public DotNetBarManager dotNetBarManager2;
        private ImageList imageList2;
        private RibbonBar ribbonBar1;
        private RibbonBar ribbonBar_Tasks;
        private SuperTabControl superTabControl_Main1;
        protected ButtonItem Button_Close;
        protected ButtonItem Button_Save;
        protected LabelItem labelItem2;
        private GroupBox groupBox1;
        private Label label12;
        private DoubleInput doubleInput_SelPriceNew1;
        private DoubleInput doubleInput_SelPriceNow1;
        private Label label1;
        private GroupBox groupBox2;
        private GroupBox groupBoxUnit;
        private ReflectionImage pictureBox_PicItem;
        private DoubleInput doubleInput_SelPriceNew5;
        private DoubleInput doubleInput_SelPriceNow5;
        private Label label6;
        private DoubleInput doubleInput_SelPriceNew4;
        private DoubleInput doubleInput_SelPriceNow4;
        private Label label5;
        private DoubleInput doubleInput_SelPriceNew3;
        private DoubleInput doubleInput_SelPriceNow3;
        private Label label3;
        private DoubleInput doubleInput_SelPriceNew2;
        private DoubleInput doubleInput_SelPriceNow2;
        private Label label2;
        private ComboBoxEx comboBoxUnit;
        private DoubleInput textbox_LegatesNew;
        private DoubleInput textbox_DistributorsNew;
        private DoubleInput textbox_VIPNew;
        private DoubleInput textbox_SectorialNew;
        private DoubleInput textbox_Sentence;
        private Label label28;
        private DoubleInput textbox_Legates;
        private DoubleInput textbox_Distributors;
        private Label label24;
        private Label label27;
        private DoubleInput textbox_VIP;
        private Label label26;
        private DoubleInput textbox_Sectorial;
        private Label label25;
        private TextBox textBox_ID;
        private DataGridViewX dataGridViewX_Data;
        private DataGridViewTextBoxColumn Co1;
        private DataGridViewTextBoxColumn Col2;
        private DataGridViewTextBoxColumn Col3;
        private DataGridViewTextBoxColumn Col4;
        private DataGridViewTextBoxColumn Col5;
        private DataGridViewTextBoxColumn Col6;
        private DataGridViewTextBoxColumn Col7;
        private DataGridViewTextBoxColumn Col8;
        private DataGridViewTextBoxColumn Col9;
        private DataGridViewTextBoxColumn Col10;
        private DataGridViewTextBoxColumn Col11;
        private DataGridViewTextBoxColumn Col12;
        private DataGridViewTextBoxColumn Col13;
        private DataGridViewTextBoxColumn Col14;
        private DataGridViewTextBoxColumn Col15;
        private DataGridViewTextBoxColumn Col16;
        private DataGridViewTextBoxColumn Col17;
        private DataGridViewTextBoxColumn Col18;
        private DataGridViewTextBoxColumn Col19;
        private DataGridViewTextBoxColumn Col20;
        private DataGridViewTextBoxColumn Col21;
        private DataGridViewTextBoxColumn Col22;
        private DataGridViewTextBoxColumn Col23;
        private DataGridViewTextBoxColumn Col24;
        private DataGridViewTextBoxColumn Col25;
        private DataGridViewTextBoxColumn Col26;
        private DataGridViewTextBoxColumn Col27;
        private DataGridViewTextBoxColumn Col28;
        public DoubleInput doubleInput_SelCostNew;
        public Label label4;
        public DoubleInput doubleInput_SelCostNow;
        private Label label7;
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private int LangArEn = 0;
        public List<Control> controls;
        public Control codeControl = new Control();
        private string vItmNo = string.Empty;
        private List<string> pkeys = new List<string>();
        private Stock_DataDataContext dbInstance;
        private T_Item data_this;
        private DoubleInput textbox_SentenceNew;
        private T_EditItemPrice data_this_EditPrice;
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
        public T_Item DataThis
        {
            get
            {
                return data_this;
            }
            set
            {
                data_this = value;
                SetData(data_this);
            }
        }
        public T_EditItemPrice DataThis_EditPrice
        {
            get
            {
                return data_this_EditPrice;
            }
            set
            {
                data_this_EditPrice = value;
            }
        }
        public FrmEditItemsPrices(string itmNo)
        {
            InitializeComponent();this.Load += langloads;
            vItmNo = itmNo;
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49))
            {
                doubleInput_SelCostNew.DisplayFormat = VarGeneral.DicemalMask;
                doubleInput_SelPriceNew1.DisplayFormat = VarGeneral.DicemalMask;
                doubleInput_SelPriceNew2.DisplayFormat = VarGeneral.DicemalMask;
                doubleInput_SelPriceNew3.DisplayFormat = VarGeneral.DicemalMask;
                doubleInput_SelPriceNew4.DisplayFormat = VarGeneral.DicemalMask;
                doubleInput_SelPriceNew5.DisplayFormat = VarGeneral.DicemalMask;
                textbox_LegatesNew.DisplayFormat = VarGeneral.DicemalMask;
                textbox_DistributorsNew.DisplayFormat = VarGeneral.DicemalMask;
                textbox_SentenceNew.DisplayFormat = VarGeneral.DicemalMask;
                textbox_SectorialNew.DisplayFormat = VarGeneral.DicemalMask;
                textbox_VIPNew.DisplayFormat = VarGeneral.DicemalMask;
            }
        }
        public void Clear()
        {
            data_this = new T_Item();
            for (int i = 0; i < controls.Count; i++)
            {
                if (controls[i].GetType() == typeof(CheckBox))
                {
                    (controls[i] as CheckBox).Checked = false;
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
                    else if (controls[i].GetType() == typeof(TextBox) || controls[i].GetType() == typeof(TextBoxX) || controls[i].GetType() == typeof(MaskedTextBox))
                    {
                        controls[i].Text = string.Empty;
                    }
                    else if (controls[i].GetType() == typeof(CheckBox))
                    {
                        (controls[i] as CheckBox).Checked = false;
                    }
                    else if (controls[i].GetType() == typeof(RadioButton))
                    {
                        (controls[i] as RadioButton).Checked = false;
                    }
                    else if (controls[i].GetType() == typeof(ComboBox))
                    {
                        (controls[i] as ComboBox).SelectedIndex = 0;
                    }
                    else if (controls[i].GetType() == typeof(ComboBoxEx))
                    {
                        (controls[i] as ComboBoxEx).SelectedIndex = 0;
                    }
                }
            }
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmEditItemsPrices));
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                Language.ChangeLanguage("ar-SA", this, resources);
                LangArEn = 0;
            }
            else if (VarGeneral.CurrentLang.ToString() == "1")
            {
                Language.ChangeLanguage("en", this, resources);
                LangArEn = 1;
            }
            FillCombo();
            ChangLang();
        }
        private void FrmEditItemsPrices_Load(object sender, EventArgs e)
        {
            ADD_Controls();
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmEditItemsPrices));
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    Language.ChangeLanguage("ar-SA", this, resources);
                    LangArEn = 0;
                }
                else
                {
                    Language.ChangeLanguage("en", this, resources);
                    LangArEn = 1;
                }
                Clear();
                FillCombo();
                textBox_ID.Text = vItmNo;
                comboBoxUnit_SelectedIndexChanged(sender, e);
                ChangLang();
                try
                {
                    List<T_EditItemPrice> q = (from t in db.T_EditItemPrices
                                               orderby t.ID
                                               where t.ItmNo == vItmNo
                                               select t).ToList();
                    if (q.Count > 0)
                    {
                        for (int i = 0; i < q.Count; i++)
                        {
                            dataGridViewX_Data.Rows.Add();
                            dataGridViewX_Data.Rows[i].Cells[0].Value = q[i].ItmNo;
                            dataGridViewX_Data.Rows[i].Cells[1].Value = ((LangArEn == 0) ? q[i].T_Item.Arb_Des : q[i].T_Item.Eng_Des);
                            dataGridViewX_Data.Rows[i].Cells[2].Value = q[i].SelCostNow.Value;
                            dataGridViewX_Data.Rows[i].Cells[3].Value = q[i].SelCostNew.Value;
                            dataGridViewX_Data.Rows[i].Cells[4].Value = n.FormatHijri(q[i].HDate, "yyyy/MM/dd");
                            dataGridViewX_Data.Rows[i].Cells[5].Value = n.FormatHijri(q[i].GDate, "yyyy/MM/dd");
                            dataGridViewX_Data.Rows[i].Cells[6].Value = (VarGeneral.CheckTime(q[i].LTim) ? q[i].LTim : string.Empty);
                            dataGridViewX_Data.Rows[i].Cells[7].Value = q[i].UsrNm;
                            dataGridViewX_Data.Rows[i].Cells[8].Value = q[i].SelPriceNow1;
                            dataGridViewX_Data.Rows[i].Cells[9].Value = q[i].SelPriceNew1;
                            dataGridViewX_Data.Rows[i].Cells[10].Value = q[i].SelPriceNow2;
                            dataGridViewX_Data.Rows[i].Cells[11].Value = q[i].SelPriceNew2;
                            dataGridViewX_Data.Rows[i].Cells[12].Value = q[i].SelPriceNow3;
                            dataGridViewX_Data.Rows[i].Cells[13].Value = q[i].SelPriceNew3;
                            dataGridViewX_Data.Rows[i].Cells[14].Value = q[i].SelPriceNow4;
                            dataGridViewX_Data.Rows[i].Cells[15].Value = q[i].SelPriceNew4;
                            dataGridViewX_Data.Rows[i].Cells[16].Value = q[i].SelPriceNow5;
                            dataGridViewX_Data.Rows[i].Cells[17].Value = q[i].SelPriceNew5;
                            dataGridViewX_Data.Rows[i].Cells[18].Value = q[i].Legates;
                            dataGridViewX_Data.Rows[i].Cells[19].Value = q[i].LegatesNew;
                            dataGridViewX_Data.Rows[i].Cells[20].Value = q[i].Distributors;
                            dataGridViewX_Data.Rows[i].Cells[21].Value = q[i].DistributorsNew;
                            dataGridViewX_Data.Rows[i].Cells[22].Value = q[i].Sentence;
                            dataGridViewX_Data.Rows[i].Cells[23].Value = q[i].SentenceNew;
                            dataGridViewX_Data.Rows[i].Cells[24].Value = q[i].Sectorial;
                            dataGridViewX_Data.Rows[i].Cells[25].Value = q[i].SectorialNew;
                            dataGridViewX_Data.Rows[i].Cells[26].Value = q[i].VIP;
                            dataGridViewX_Data.Rows[i].Cells[27].Value = q[i].VIPNew;
                        }
                    }
                    else
                    {
                        dataGridViewX_Data.Rows.Clear();
                    }
                }
                catch
                {
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void ChangLang()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                dataGridViewX_Data.Columns[0].HeaderText = "رقم الصنف";
                dataGridViewX_Data.Columns[1].HeaderText = "إسم الصنف";
                dataGridViewX_Data.Columns[2].HeaderText = "سعر التكلفة قبل";
                dataGridViewX_Data.Columns[3].HeaderText = "سعر التكلفة بعد";
                dataGridViewX_Data.Columns[4].HeaderText = "التاريخ هـ";
                dataGridViewX_Data.Columns[5].HeaderText = "التاريخ م";
                dataGridViewX_Data.Columns[6].HeaderText = "الوقت";
                dataGridViewX_Data.Columns[7].HeaderText = "المستخدم";
                dataGridViewX_Data.Columns[8].HeaderText = "سعر البيع 1 قبل";
                dataGridViewX_Data.Columns[9].HeaderText = "سعر البيع 1 بعد";
                dataGridViewX_Data.Columns[10].HeaderText = "سعر البيع 2 قبل";
                dataGridViewX_Data.Columns[11].HeaderText = "سعر البيع 2 بعد";
                dataGridViewX_Data.Columns[12].HeaderText = "سعر البيع 3 قبل";
                dataGridViewX_Data.Columns[13].HeaderText = "سعر البيع 3 بعد";
                dataGridViewX_Data.Columns[14].HeaderText = "سعر البيع 4 قبل";
                dataGridViewX_Data.Columns[15].HeaderText = "سعر البيع 4 بعد";
                dataGridViewX_Data.Columns[16].HeaderText = "سعر البيع 5 قبل";
                dataGridViewX_Data.Columns[17].HeaderText = "سعر البيع 5 بعد";
                dataGridViewX_Data.Columns[18].HeaderText = "سعر المندوب قبل";
                dataGridViewX_Data.Columns[19].HeaderText = "سعر المندوب بعد";
                dataGridViewX_Data.Columns[20].HeaderText = "سعر الموزع قبل";
                dataGridViewX_Data.Columns[21].HeaderText = "سعر الموزع بعد";
                dataGridViewX_Data.Columns[22].HeaderText = "سعر الجملة قبل";
                dataGridViewX_Data.Columns[23].HeaderText = "سعر الجملة بعد";
                dataGridViewX_Data.Columns[24].HeaderText = "سعر التجزئة قبل";
                dataGridViewX_Data.Columns[25].HeaderText = "سعر التجزئة بعد";
                dataGridViewX_Data.Columns[26].HeaderText = "سعر اخر قبل";
                dataGridViewX_Data.Columns[27].HeaderText = "سعر آخر بعد";
                Button_Close.Text = "خروج";
                Button_Save.Text = "حفظ";
                Text = "شاشة تعديل الأسعار";
            }
            else
            {
                dataGridViewX_Data.Columns[0].HeaderText = "Item No";
                dataGridViewX_Data.Columns[1].HeaderText = "Item Name";
                dataGridViewX_Data.Columns[2].HeaderText = "Cost Value Before";
                dataGridViewX_Data.Columns[3].HeaderText = "Cost Value After";
                dataGridViewX_Data.Columns[4].HeaderText = "Date H";
                dataGridViewX_Data.Columns[5].HeaderText = "Date G";
                dataGridViewX_Data.Columns[6].HeaderText = "Time";
                dataGridViewX_Data.Columns[7].HeaderText = "User";
                dataGridViewX_Data.Columns[8].HeaderText = "Price Sel 1 Befor";
                dataGridViewX_Data.Columns[9].HeaderText = "Price Sel 1 after";
                dataGridViewX_Data.Columns[10].HeaderText = "Price Sel 1 Befor";
                dataGridViewX_Data.Columns[11].HeaderText = "Price Sel 1 after";
                dataGridViewX_Data.Columns[12].HeaderText = "Price Sel 1 Befor";
                dataGridViewX_Data.Columns[13].HeaderText = "Price Sel 1 after";
                dataGridViewX_Data.Columns[14].HeaderText = "Price Sel 1 Befor";
                dataGridViewX_Data.Columns[15].HeaderText = "Price Sel 1 after";
                dataGridViewX_Data.Columns[16].HeaderText = "Price Sel 1 Befor";
                dataGridViewX_Data.Columns[17].HeaderText = "Price Sel 1 after";
                dataGridViewX_Data.Columns[18].HeaderText = "Price Delegate before";
                dataGridViewX_Data.Columns[19].HeaderText = "Price Delegate after";
                dataGridViewX_Data.Columns[20].HeaderText = "Price Distributor Befor";
                dataGridViewX_Data.Columns[21].HeaderText = "Price Distributor After";
                dataGridViewX_Data.Columns[22].HeaderText = "Price Sentence Befor";
                dataGridViewX_Data.Columns[23].HeaderText = "Price Sentence After";
                dataGridViewX_Data.Columns[24].HeaderText = "Price Retail Befor";
                dataGridViewX_Data.Columns[25].HeaderText = "Price Retail After";
                dataGridViewX_Data.Columns[26].HeaderText = "Price Other Befor";
                dataGridViewX_Data.Columns[27].HeaderText = "Price Other After";
                Button_Close.Text = "Close";
                Button_Save.Text = "Save";
                Text = "Price Edite Form";
            }
        }
        private void ADD_Controls()
        {
            try
            {
                controls = new List<Control>();
                controls.Add(doubleInput_SelCostNew);
                controls.Add(doubleInput_SelCostNow);
                controls.Add(doubleInput_SelPriceNew1);
                controls.Add(doubleInput_SelPriceNow1);
                controls.Add(doubleInput_SelPriceNew2);
                controls.Add(doubleInput_SelPriceNow2);
                controls.Add(doubleInput_SelPriceNew3);
                controls.Add(doubleInput_SelPriceNow3);
                controls.Add(doubleInput_SelPriceNew4);
                controls.Add(doubleInput_SelPriceNow4);
                controls.Add(doubleInput_SelPriceNew5);
                controls.Add(doubleInput_SelPriceNow5);
                controls.Add(textbox_Distributors);
                controls.Add(textbox_DistributorsNew);
                controls.Add(textbox_Legates);
                controls.Add(textbox_LegatesNew);
                controls.Add(textbox_Sectorial);
                controls.Add(textbox_SectorialNew);
                controls.Add(textbox_Sentence);
                controls.Add(textbox_SentenceNew);
                controls.Add(textbox_VIP);
                controls.Add(textbox_VIPNew);
                controls.Add(pictureBox_PicItem);
            }
            catch
            {
            }
        }
        private void FillCombo()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                comboBoxUnit.DataSource = null;
                List<T_Unit> listUnit1 = new List<T_Unit>(db.T_Units.Select((T_Unit item) => item).ToList());
                listUnit1.Insert(0, new T_Unit());
                comboBoxUnit.DataSource = listUnit1;
                comboBoxUnit.DisplayMember = "Arb_Des";
                comboBoxUnit.ValueMember = "Unit_ID";
                comboBoxUnit.SelectedIndex = 0;
            }
            else
            {
                comboBoxUnit.DataSource = null;
                List<T_Unit> listUnit1 = new List<T_Unit>(db.T_Units.Select((T_Unit item) => item).ToList());
                listUnit1.Insert(0, new T_Unit());
                comboBoxUnit.DataSource = listUnit1;
                comboBoxUnit.DisplayMember = "Eng_Des";
                comboBoxUnit.ValueMember = "Unit_ID";
                comboBoxUnit.SelectedIndex = 0;
            }
        }
        public void SetData(T_Item value)
        {
            try
            {
                textbox_Distributors.Value = value.Price2.Value;
                textbox_Legates.Value = value.Price3.Value;
                textbox_Sectorial.Value = value.Price4.Value;
                textbox_Sentence.Value = value.Price1.Value;
                textbox_VIP.Value = value.Price5.Value;
                textbox_DistributorsNew.Value = value.Price2.Value;
                textbox_LegatesNew.Value = value.Price3.Value;
                textbox_SectorialNew.Value = value.Price4.Value;
                textbox_SentenceNew.Value = value.Price1.Value;
                textbox_VIPNew.Value = value.Price5.Value;
                doubleInput_SelCostNow.Value = value.AvrageCost.Value;
                doubleInput_SelCostNew.Value = value.AvrageCost.Value;
                doubleInput_SelPriceNow1.Value = value.UntPri1.Value;
                doubleInput_SelPriceNow2.Value = value.UntPri2.Value;
                doubleInput_SelPriceNow3.Value = value.UntPri3.Value;
                doubleInput_SelPriceNow4.Value = value.UntPri4.Value;
                doubleInput_SelPriceNow5.Value = value.UntPri5.Value;
                doubleInput_SelPriceNew1.Value = value.UntPri1.Value;
                doubleInput_SelPriceNew2.Value = value.UntPri2.Value;
                doubleInput_SelPriceNew3.Value = value.UntPri3.Value;
                doubleInput_SelPriceNew4.Value = value.UntPri4.Value;
                doubleInput_SelPriceNew5.Value = value.UntPri5.Value;
                if (value.ItmImg != null)
                {
                    byte[] arr = value.ItmImg.ToArray();
                    MemoryStream stream = new MemoryStream(arr);
                    pictureBox_PicItem.Image = Image.FromStream(stream);
                }
                else
                {
                    pictureBox_PicItem.Image = null;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("SetData:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void comboBoxUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                doubleInput_SelPriceNew1.Enabled = false;
                doubleInput_SelPriceNew2.Enabled = false;
                doubleInput_SelPriceNew3.Enabled = false;
                doubleInput_SelPriceNew4.Enabled = false;
                doubleInput_SelPriceNew5.Enabled = false;
                if (comboBoxUnit.SelectedIndex <= 0)
                {
                    return;
                }
                List<T_Item> q = db.T_Items.Where((T_Item t) => t.Itm_No == textBox_ID.Text && (t.Unit1.Value == int.Parse(comboBoxUnit.SelectedValue.ToString()) || t.Unit2.Value == int.Parse(comboBoxUnit.SelectedValue.ToString()) || t.Unit3.Value == int.Parse(comboBoxUnit.SelectedValue.ToString()) || t.Unit4.Value == int.Parse(comboBoxUnit.SelectedValue.ToString()) || t.Unit5.Value == int.Parse(comboBoxUnit.SelectedValue.ToString()))).ToList();
                if (q != null && !string.IsNullOrEmpty(q.First().Itm_No))
                {
                    if (q.First().Unit1 == int.Parse(comboBoxUnit.SelectedValue.ToString()))
                    {
                        doubleInput_SelPriceNew1.Enabled = true;
                        doubleInput_SelPriceNew2.Enabled = false;
                        doubleInput_SelPriceNew3.Enabled = false;
                        doubleInput_SelPriceNew4.Enabled = false;
                        doubleInput_SelPriceNew5.Enabled = false;
                    }
                    else if (q.First().Unit2 == int.Parse(comboBoxUnit.SelectedValue.ToString()))
                    {
                        doubleInput_SelPriceNew1.Enabled = false;
                        doubleInput_SelPriceNew2.Enabled = true;
                        doubleInput_SelPriceNew3.Enabled = false;
                        doubleInput_SelPriceNew4.Enabled = false;
                        doubleInput_SelPriceNew5.Enabled = false;
                    }
                    else if (q.First().Unit3 == int.Parse(comboBoxUnit.SelectedValue.ToString()))
                    {
                        doubleInput_SelPriceNew1.Enabled = false;
                        doubleInput_SelPriceNew2.Enabled = false;
                        doubleInput_SelPriceNew3.Enabled = true;
                        doubleInput_SelPriceNew4.Enabled = false;
                        doubleInput_SelPriceNew5.Enabled = false;
                    }
                    else if (q.First().Unit4 == int.Parse(comboBoxUnit.SelectedValue.ToString()))
                    {
                        doubleInput_SelPriceNew1.Enabled = false;
                        doubleInput_SelPriceNew2.Enabled = false;
                        doubleInput_SelPriceNew3.Enabled = false;
                        doubleInput_SelPriceNew4.Enabled = true;
                        doubleInput_SelPriceNew5.Enabled = false;
                    }
                    else if (q.First().Unit5 == int.Parse(comboBoxUnit.SelectedValue.ToString()))
                    {
                        doubleInput_SelPriceNew1.Enabled = false;
                        doubleInput_SelPriceNew2.Enabled = false;
                        doubleInput_SelPriceNew3.Enabled = false;
                        doubleInput_SelPriceNew4.Enabled = false;
                        doubleInput_SelPriceNew5.Enabled = true;
                    }
                }
            }
            catch
            {
                doubleInput_SelPriceNew1.Enabled = false;
                doubleInput_SelPriceNew2.Enabled = false;
                doubleInput_SelPriceNew3.Enabled = false;
                doubleInput_SelPriceNew4.Enabled = false;
                doubleInput_SelPriceNow5.Enabled = false;
            }
        }
        private void Button_Close_Click(object sender, EventArgs e)
        {
            Close();
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
            if (e.KeyCode == Keys.F2 && Button_Save.Enabled && Button_Save.Visible)
            {
                Button_Save_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private bool CheckUpdate()
        {
            try
            {
                if (doubleInput_SelCostNew.Value != data_this.AvrageCost.Value)
                {
                    return true;
                }
                if (data_this.Unit1.HasValue && doubleInput_SelPriceNew1.Value != data_this.UntPri1.Value)
                {
                    return true;
                }
                if (data_this.Unit2.HasValue && doubleInput_SelPriceNew2.Value != data_this.UntPri2.Value)
                {
                    return true;
                }
                if (data_this.Unit3.HasValue && doubleInput_SelPriceNew3.Value != data_this.UntPri3.Value)
                {
                    return true;
                }
                if (data_this.Unit4.HasValue && doubleInput_SelPriceNew4.Value != data_this.UntPri4.Value)
                {
                    return true;
                }
                if (data_this.Unit5.HasValue && doubleInput_SelPriceNew5.Value != data_this.UntPri5.Value)
                {
                    return true;
                }
                if (data_this.Price1 != textbox_SentenceNew.Value)
                {
                    return true;
                }
                if (data_this.Price2 != textbox_DistributorsNew.Value)
                {
                    return true;
                }
                if (data_this.Price3 != textbox_LegatesNew.Value)
                {
                    return true;
                }
                if (data_this.Price4 != textbox_SectorialNew.Value)
                {
                    return true;
                }
                if (data_this.Price5 != textbox_VIPNew.Value)
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
        private void Button_Save_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_ID.Text) && CheckUpdate())
            {
                GetData();
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                data_this_EditPrice = new T_EditItemPrice();
                data_this_EditPrice.ItmNo = textBox_ID.Text;
                data_this_EditPrice.SelCostNow = doubleInput_SelCostNow.Value;
                data_this_EditPrice.SelCostNew = doubleInput_SelCostNew.Value;
                if (data_this.Unit1.HasValue)
                {
                    data_this_EditPrice.SelPriceNow1 = doubleInput_SelPriceNow1.Value;
                    data_this_EditPrice.SelPriceNew1 = doubleInput_SelPriceNew1.Value;
                }
                else
                {
                    data_this_EditPrice.SelPriceNow1 = null;
                    data_this_EditPrice.SelPriceNew1 = null;
                }
                if (data_this.Unit2.HasValue)
                {
                    data_this_EditPrice.SelPriceNow2 = doubleInput_SelPriceNow2.Value;
                    data_this_EditPrice.SelPriceNew2 = doubleInput_SelPriceNew2.Value;
                }
                else
                {
                    data_this_EditPrice.SelPriceNow2 = null;
                    data_this_EditPrice.SelPriceNew2 = null;
                }
                if (data_this.Unit3.HasValue)
                {
                    data_this_EditPrice.SelPriceNow3 = doubleInput_SelPriceNow3.Value;
                    data_this_EditPrice.SelPriceNew3 = doubleInput_SelPriceNew3.Value;
                }
                else
                {
                    data_this_EditPrice.SelPriceNow3 = null;
                    data_this_EditPrice.SelPriceNew3 = null;
                }
                if (data_this.Unit4.HasValue)
                {
                    data_this_EditPrice.SelPriceNow4 = doubleInput_SelPriceNow4.Value;
                    data_this_EditPrice.SelPriceNew4 = doubleInput_SelPriceNew4.Value;
                }
                else
                {
                    data_this_EditPrice.SelPriceNow4 = null;
                    data_this_EditPrice.SelPriceNew4 = null;
                }
                if (data_this.Unit5.HasValue)
                {
                    data_this_EditPrice.SelPriceNow5 = doubleInput_SelPriceNow5.Value;
                    data_this_EditPrice.SelPriceNew5 = doubleInput_SelPriceNew5.Value;
                }
                else
                {
                    data_this_EditPrice.SelPriceNow5 = null;
                    data_this_EditPrice.SelPriceNew5 = null;
                }
                data_this_EditPrice.Distributors = textbox_Distributors.Value;
                data_this_EditPrice.DistributorsNew = textbox_DistributorsNew.Value;
                data_this_EditPrice.Legates = textbox_Legates.Value;
                data_this_EditPrice.LegatesNew = textbox_LegatesNew.Value;
                data_this_EditPrice.Sectorial = textbox_Sectorial.Value;
                data_this_EditPrice.SectorialNew = textbox_SectorialNew.Value;
                data_this_EditPrice.Sentence = textbox_Sentence.Value;
                data_this_EditPrice.SentenceNew = textbox_SentenceNew.Value;
                data_this_EditPrice.VIP = textbox_VIP.Value;
                data_this_EditPrice.VIPNew = textbox_VIPNew.Value;
                data_this_EditPrice.HDate = VarGeneral.Hdate;
                data_this_EditPrice.GDate = VarGeneral.Gdate;
                data_this_EditPrice.UsrNm = VarGeneral.UserNameA;
                data_this_EditPrice.LTim = DateTime.Now.ToString("HH:mm");
                try
                {
                    db.T_EditItemPrices.InsertOnSubmit(data_this_EditPrice);
                    db.SubmitChanges();
                    MessageBox.Show((LangArEn == 0) ? "تم عملية التعديل بنجاح" : "Operation accomplished successfully", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Close();
                }
                catch (SqlException ex)
                {
                    VarGeneral.DebLog.writeLog("Butto_Save_Click:", ex, enable: true);
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private T_Item GetData()
        {
            try
            {
                if (double.TryParse(doubleInput_SelCostNew.Text, out var value))
                {
                    data_this.AvrageCost = value;
                    data_this.LastCost = value;
                }
                else
                {
                    data_this.AvrageCost = 0.0;
                }
                if (data_this.Unit1.HasValue)
                {
                    if (double.TryParse(doubleInput_SelPriceNew1.Text, out value))
                    {
                        data_this.UntPri1 = value;
                    }
                    else
                    {
                        data_this.UntPri1 = 0.0;
                    }
                }
                if (data_this.Unit2.HasValue)
                {
                    if (double.TryParse(doubleInput_SelPriceNew2.Text, out value))
                    {
                        data_this.UntPri2 = value;
                    }
                    else
                    {
                        data_this.UntPri2 = 0.0;
                    }
                }
                if (data_this.Unit3.HasValue)
                {
                    if (double.TryParse(doubleInput_SelPriceNew3.Text, out value))
                    {
                        data_this.UntPri3 = value;
                    }
                    else
                    {
                        data_this.UntPri3 = 0.0;
                    }
                }
                if (data_this.Unit4.HasValue)
                {
                    if (double.TryParse(doubleInput_SelPriceNew4.Text, out value))
                    {
                        data_this.UntPri4 = value;
                    }
                    else
                    {
                        data_this.UntPri4 = 0.0;
                    }
                }
                if (data_this.Unit5.HasValue)
                {
                    if (double.TryParse(doubleInput_SelPriceNew5.Text, out value))
                    {
                        data_this.UntPri5 = value;
                    }
                    else
                    {
                        data_this.UntPri5 = 0.0;
                    }
                }
                data_this.Price1 = textbox_SentenceNew.Value;
                data_this.Price2 = textbox_DistributorsNew.Value;
                data_this.Price3 = textbox_LegatesNew.Value;
                data_this.Price4 = textbox_SectorialNew.Value;
                data_this.Price5 = textbox_VIPNew.Value;
                return data_this;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return data_this;
        }
        private void textBox_ID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                T_Item newData = db.StockItem(textBox_ID.Text);
                if (newData == null || string.IsNullOrEmpty(newData.Itm_No))
                {
                    Clear();
                }
                else
                {
                    DataThis = newData;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("textBox_ID_TextChanged:", error, enable: true);
                MessageBox.Show(error.Message);
                Close();
            }
        }
        private void superTabControl_Main1_SelectedTabChanged(object sender, SuperTabStripSelectedTabChangedEventArgs e)
        {
        }
        private void doubleInput_SelPriceNew1_ValueChanged(object sender, EventArgs e)
        {
        }
        private void doubleInput_SelPriceNew4_ValueChanged(object sender, EventArgs e)
        {
        }
    }
}
