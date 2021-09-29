using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using C1.Win.C1BarCode;
using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.Metro;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.Editors;
using Framework.Data;
using Framework.Keyboard;
using InvAcc.GeneralM;
using InvAcc;
using Library.RepShow;
using Microsoft.VisualBasic;
using SSSDateTime.Date;
using SSSLanguage;
using InvAcc.Stock_Data;
namespace InvAcc. Forms
{
	public class FrmItems : Form
	{
		public class ColumnDictinary
		{
			public string AText = "";
			public string EText = "";
			public bool IfDefault = false;
			public string Format = "";
			public ColumnDictinary(string aText, string eText, bool ifDefault, string format)
			{
				AText = aText;
				EText = eText;
				IfDefault = ifDefault;
				Format = format;
			}
		}
		private T_Company _Company = new T_Company();
		private T_SYSSETTING _SysSetting = new T_SYSSETTING();
		private T_INVSETTING _InvSetting = new T_INVSETTING();
		private T_Curency _Curency = new T_Curency();
		private Stock_DataDataContext dbInstance;
		private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
		private Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
		private Dictionary<string, ColumnDictinary> Dir_ButSearch = new Dictionary<string, ColumnDictinary>();
		private int LangArEn = 0;
		protected bool ifOkDelete;
		public bool CanEdit = true;
		protected bool CanInsert = true;
		public ViewState ViewState = ViewState.Deiles;
		private FormState statex;
		public List<Control> controls;
		public Control codeControl = new Control();
		private bool canUpdate = true;
		private T_Item data_this;
		private List<string> pkeys = new List<string>();
		private Rate_DataDataContext dbInstanceRate;
		private T_User permission = new T_User();
		private List<T_ItemDet> LData_This;
		private PrintDialog pdi = new PrintDialog();
		private int CountPage = 0;
		public Dictionary<string, ColumnDictinary> columns_Names_visible2 = new Dictionary<string, ColumnDictinary>();
		private string oldUnit = "";
		private T_Unit _Unit = new T_Unit();
		private List<T_Unit> listUnit = new List<T_Unit>();
		private T_Item _Items = new T_Item();
		private List<T_Item> listItems = new List<T_Item>();
		private T_Store _Store = new T_Store();
		private List<T_Store> listStore = new List<T_Store>();
		private List<T_Curency> listCurency = new List<T_Curency>();
		private T_STKSQTY _StksQty = new T_STKSQTY();
		private List<T_STKSQTY> listStkQty = new List<T_STKSQTY>();
		private double RateValue = 1.0;
		private int DefPack = 0;
		private double Pack = 0.0;
		private double PriceLoc = 0.0;
		private int RowSel = 0;
		private IContainer components = null;
		private TabItem tabItem1;
		protected ButtonItem buttonItem6;
		protected ButtonItem buttonItem5;
		private ButtonItem buttonItem2;
		protected ButtonItem buttonItem4;
		protected ButtonItem buttonItem3;
		protected ButtonItem buttonItem1;
		protected ToolStripMenuItem ToolStripMenuItem_Rep;
		private RibbonBar ribbonBar_Units;
		private ImageList imageList1;
		protected ContextMenuStrip contextMenuStrip1;
		protected ContextMenuStrip contextMenuStrip2;
		protected ToolStripMenuItem ToolStripMenuItem_Det;
		private OpenFileDialog openFileDialog1;
		private SaveFileDialog saveFileDialog1;
		private PanelEx panelEx3;
		private PanelEx panelEx2;
		private ExpandableSplitter expandableSplitter1;
		private Panel panel1;
		private SideBar sideBar_Units;
		private SideBarPanelItem sideBarPanelItem_Unit1;
		private SideBarPanelItem sideBarPanelItem_Unit2;
		private SideBarPanelItem sideBarPanelItem_Unit3;
		private SideBarPanelItem sideBarPanelItem_Unit4;
		private SideBarPanelItem sideBarPanelItem_Unit5;
		private LabelItem labelItem4;
		private ComboBoxItem comboboxItems_Unit1;
		private LabelItem labelItem5;
		private TextBoxItem textbox_Pack1;
		private LabelItem labelItem6;
		private TextBoxItem textbox_Qty1;
		private LabelItem labelItem7;
		private TextBoxItem textbox_Cost1;
		private LabelItem labelItem8;
		private TextBoxItem txtBarCode1;
		private CheckBoxItem radiobutton_RButDef1;
		private LabelItem labelItem9;
		private ComboBoxItem comboboxItems_Unit2;
		private LabelItem labelItem10;
		private TextBoxItem txtBarCode2;
		private LabelItem labelItem11;
		private TextBoxItem textbox_Pack2;
		private LabelItem labelItem12;
		private TextBoxItem textbox_Qty2;
		private LabelItem labelItem13;
		private TextBoxItem textbox_Cost2;
		private CheckBoxItem radiobutton_RButDef2;
		private LabelItem labelItem14;
		private ComboBoxItem comboboxItems_Unit3;
		private LabelItem labelItem15;
		private TextBoxItem txtBarCode3;
		private LabelItem labelItem16;
		private TextBoxItem textbox_Pack3;
		private LabelItem labelItem17;
		private TextBoxItem textbox_Qty3;
		private LabelItem labelItem18;
		private TextBoxItem textbox_Cost3;
		private CheckBoxItem radiobutton_RButDef3;
		private LabelItem labelItem19;
		private ComboBoxItem comboboxItems_Unit4;
		private LabelItem labelItem20;
		private TextBoxItem txtBarCode4;
		private LabelItem labelItem21;
		private TextBoxItem textbox_Pack4;
		private LabelItem labelItem22;
		private TextBoxItem textbox_Qty4;
		private LabelItem labelItem23;
		private TextBoxItem textbox_Cost4;
		private CheckBoxItem radiobutton_RButDef4;
		private LabelItem labelItem24;
		private ComboBoxItem comboboxItems_Unit5;
		private LabelItem labelItem25;
		private TextBoxItem txtBarCode5;
		private LabelItem labelItem26;
		private TextBoxItem textbox_Pack5;
		private LabelItem labelItem27;
		private TextBoxItem textbox_Qty5;
		private LabelItem labelItem28;
		private TextBoxItem textbox_Cost5;
		private CheckBoxItem radiobutton_RButDef5;
		private SuperTabItem superTabItem1;
		private IntegerInput textbox_DateNo;
		private Label label1;
		private ExpandablePanel expandablePanel_AnotherPrice;
		private ComboBoxEx combobox_DateTyp;
		private DoubleInput textbox_Legates;
		private DoubleInput textbox_Distributors;
		private Label label24;
		private Label label27;
		private DoubleInput textbox_Sentence;
		private Label label28;
		private DoubleInput textbox_Sectorial;
		private Label label25;
		private DoubleInput textbox_VIP;
		private Label label26;
		private C1BarCode c1BarCode1;
		private LabelItem labelItem30;
		private TextBoxItem textbox_SelPri1;
		private LabelItem labelItem31;
		private TextBoxItem textbox_SelPri2;
		private LabelItem labelItem32;
		private TextBoxItem textbox_SelPri3;
		private LabelItem labelItem33;
		private TextBoxItem textbox_SelPri4;
		private LabelItem labelItem34;
		private TextBoxItem textbox_SelPri5;
		private TextBox txtCurr;
		private ComboBox combobox_Unit5;
		private ComboBox combobox_Unit4;
		private ComboBox combobox_Unit3;
		private ComboBox combobox_Unit2;
		private ComboBox combobox_Unit1;
		protected SuperGridControl DGV_Main;
		private RibbonBar ribbonBar_DGV;
		private SuperTabControl superTabControl_DGV;
		protected TextBoxItem textBox_search;
		protected ButtonItem Button_ExportTable2;
		protected ButtonItem Button_PrintTable;
		protected LabelItem labelItem3;
		private RibbonBar ribbonBar_Tasks;
		private PrintDialog printDialog1;
		internal PrintPreviewDialog prnt_prev;
		private OpenFileDialog openFileDialog2;
		internal PrintDocument prnt_doc;
		private FileSystemWatcher fileSystemWatcher1;
		private SuperTabControl superTabControl_Main1;
		protected ButtonItem Button_Close;
		protected ButtonItem Button_Search;
		protected ButtonItem Button_Delete;
		protected ButtonItem Button_Save;
		protected ButtonItem Button_Add;
		private SuperTabControl superTabControl_Main2;
		protected LabelItem labelItem1;
		protected ButtonItem Button_First;
		protected ButtonItem Button_Prev;
		protected TextBoxItem TextBox_Index;
		protected LabelItem Label_Count;
		protected ButtonItem Button_Next;
		protected ButtonItem Button_Last;
		private SuperTabControl superTabControl1;
		private SuperTabControlPanel superTabControlPanel1;
		private SuperTabItem superTabItem_General;
		private SuperTabControlPanel superTabControlPanel2;
		private SuperTabItem superTabItem_Details;
		private LabelX labelX1;
		private ButtonX button_SrchCustNo;
		private TextBox txtCustNo;
		private ReflectionImage pictureBox_PicItem;
		private ComboBoxEx combobox_ItmeGroup;
		private DoubleInput textbox_MaxQty;
		private Label label23;
		private DoubleInput textbox_Supreme;
		private Label label3;
		private ButtonX button_ClearPic;
		private ButtonX button_AddNewCat;
		private ButtonX button_SrchItemGroup;
		private TextBox textbox_Eng_Des;
		private Label label12;
		private Label label4;
		private Label label2;
		private TextBox textbox_Arb_Des;
		private Label label6;
		private TextBox textBox_ID;
		private ButtonX button_EnterImg;
		private GroupPanel groupPanel_Inv;
		private CheckBoxX checkBoxX_InvPaymentReturn;
		private CheckBoxX checkBoxX_InvPayment;
		private CheckBoxX checkBoxX_ReturnInvSale;
		private CheckBoxX checkBoxX_InvSale;
		internal TextBox txtCustName;
		private C1FlexGrid FlxInv;
		private LabelItem lable_Records;
		private C1FlexGrid c1FlexGrid_Items;
		private TextBox textBox_SerialKey;
		private Label label7;
		protected LabelItem labelItem2;
		public ButtonItem buttonItem_Serials;
		private Label label10;
		private DoubleInput textBox_CommItm;
		private Label label14;
		private DoubleInput textBox_TaxPurchase;
		protected Label label15;
		private Label label9;
		private DoubleInput textBox_TaxSales;
		protected Label label13;
		protected Label label8;
		private CheckBoxX checkBoxX_InvOut;
		private CheckBoxX checkBoxX_InvEnter;
		protected Label label11;
		protected Label label5;
		private Label label16;
		private DoubleInput textBox_DisItem;
		private ButtonX button_DeleteFromSystem;
		private TextBox doubleInput_DefPack;
		private ComboBoxEx comboBox_DefPack;
		protected ButtonItem buttonItem_x;
		private ButtonItem buttonItem_EditPriceAll;
		private ButtonItem buttonItem_EditPrice;
		private CheckBoxX checkBoxX_BarcodeBalance;
		private CheckBoxX checkBoxX_Points;
		private ButtonItem buttonItem_AddDisProcess;
		private PanelEx panelEx_Size;
		private Label labelFiled6;
		private Label labelFiled3;
		private Label labelFiled1;
		private Label labelFiled2;
		private Label labelFiled5;
		private Label labelFiled4;
		private TextBox txtFiled1;
		private TextBox txtFiled2;
		private TextBox txtFiled3;
		private TextBox txtFiled6;
		private TextBox txtFiled5;
		private TextBox txtFiled4;
		private Label label17;
        private ButtonItem buttonItem7;
        protected ButtonItem buttonItem8;
        private Panel panel2;
        private MetroStatusBar metroStatusBar_itemsType;
        private LabelItem labelItem29;
        private CheckBoxItem radioButton_Goods;
        private CheckBoxItem radioButton_RawMaterial;
        private CheckBoxItem radioButton_Service;
        private CheckBoxItem radioButton_Product;
        private SuperTabControl superTabControl_Info;
        private SuperTabControlPanel superTabControlPanel3;
        private TextBoxX textBoxX1;
        private RadioButton radioButton1;
        private Label label30;
        private TextBox textBox3;
        private Label label22;
        private TextBox textBox4;
        private Label label29;
        private TextBox textBox2;
        private Label label21;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private Label label20;
        private Label label19;
        private SuperTabItem superTabItem_items;
        private SuperTabControlPanel superTabControlPanel7;
        private TextBoxX textBoxX6;
        private Label label53;
        private TextBox textBox17;
        private Label label54;
        private TextBox textBox18;
        private Label label55;
        private TextBox textBox19;
        private Label label56;
        private TextBox textBox20;
        private ComboBox comboBox5;
        private Label label57;
        private Label label58;
        private SuperTabItem superTabItem5;
        private SuperTabControlPanel superTabControlPanel6;
        private TextBoxX textBoxX5;
        private Label label43;
        private TextBox textBox13;
        private Label label48;
        private TextBox textBox14;
        private Label label49;
        private TextBox textBox15;
        private Label label50;
        private TextBox textBox16;
        private ComboBox comboBox4;
        private Label label51;
        private Label label52;
        private SuperTabItem superTabItem4;
        private SuperTabControlPanel superTabControlPanel5;
        private TextBoxX textBoxX3;
        private Label label37;
        private TextBox textBox9;
        private Label label38;
        private TextBox textBox10;
        private Label label39;
        private TextBox textBox11;
        private Label label40;
        private TextBox textBox12;
        private ComboBox comboBox3;
        private Label label41;
        private Label label42;
        private SuperTabItem superTabItem3;
        private SuperTabControlPanel superTabControlPanel4;
        private TextBoxX textBoxX2;
        private Label label31;
        private TextBox textBox5;
        private Label label32;
        private TextBox textBox6;
        private Label label33;
        private TextBox textBox7;
        private Label label34;
        private TextBox textBox8;
        private ComboBox comboBox2;
        private Label label35;
        private Label label36;
        private SuperTabItem superTabItem2;
        private SuperTabControlPanel superTabControlPanel12;
        private Label label18;
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
		public bool IfAdd
		{
			set
			{
				Button_Add.Visible = value;
			}
		}
		public bool IfDelete
		{
			set
			{
				Button_Delete.Visible = value;
				superTabControl_Main1.Refresh();
			}
		}
		public bool IfSave
		{
			set
			{
				Button_Save.Visible = value;
			}
		}
		protected bool CanUpdate
		{
			get
			{
				return canUpdate;
			}
			set
			{
				canUpdate = value;
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
		public bool SetReadOnly
		{
			set
			{
				if (value)
				{
					State = FormState.Saved;
				}
				Button_Save.Enabled = !value;
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
		public T_User Permmission
		{
			get
			{
				return permission;
			}
			set
			{
				if (value != null && value.UsrNo != "")
				{
					permission = value;
					if (!VarGeneral.TString.ChkStatShow(value.FilStr, 5))
					{
						IfAdd = false;
					}
					else
					{
						IfAdd = true;
					}
					if (!VarGeneral.TString.ChkStatShow(value.FilStr, 6))
					{
						CanEdit = false;
					}
					else
					{
						CanEdit = true;
					}
					if (!VarGeneral.TString.ChkStatShow(value.FilStr, 7))
					{
						IfDelete = false;
					}
					else
					{
						IfDelete = true;
					}
					if (!VarGeneral.TString.ChkStatShow(value.SetStr, 5))
					{
						buttonItem_EditPrice.Visible = false;
					}
					else
					{
						buttonItem_EditPrice.Visible = true;
					}
				}
			}
		}
		public List<T_ItemDet> LDataThis
		{
			get
			{
				return LData_This;
			}
			set
			{
				LData_This = value;
			}
		}
		public void RefreshPKeys()
		{
			PKeys.Clear();
			try
			{
				PKeys = db.ExecuteQuery<string>("select Itm_No from T_Items order by Itm_No ", new object[0]).ToList();
			}
			catch
			{
				PKeys.Clear();
			}
			int count = 0;
			count = PKeys.Count;
			try
			{
				PKeys = PKeys.OrderBy((string c) => int.Parse(c)).ToList();
			}
			catch
			{
			}
			Label_Count.Text = string.Concat(count);
			UpdateVcr();
		}
		private void Frm_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				SendKeys.Send("{Tab}");
			}
		}
		protected bool ContinueIfEditOrNew()
		{
			if (State == FormState.Edit || State == FormState.New)
			{
				if (MessageBox.Show((LangArEn == 0) ? "تم تعديل السجل الحالي دون حفظ التغييرات .. هل تريد المتابعة؟" : "Not saved the changes, do you really want to continue?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
				{
					return false;
				}
				return true;
			}
			return true;
		}
		public FrmItems()
		{
			InitializeComponent();
			try
			{
				txtBarCode1.ButtonCustom.Visible = true;
				txtBarCode2.ButtonCustom.Visible = true;
				txtBarCode3.ButtonCustom.Visible = true;
				txtBarCode4.ButtonCustom.Visible = true;
				txtBarCode5.ButtonCustom.Visible = true;
			}
			catch
			{
				txtBarCode1.ButtonCustom.Visible = false;
				txtBarCode2.ButtonCustom.Visible = false;
				txtBarCode3.ButtonCustom.Visible = false;
				txtBarCode4.ButtonCustom.Visible = false;
				txtBarCode5.ButtonCustom.Visible = false;
			}
			checkBoxX_Points.Click += Button_Edit_Click;
			checkBoxX_BarcodeBalance.Click += Button_Edit_Click;
			checkBoxX_InvSale.Click += Button_Edit_Click;
			checkBoxX_InvPayment.Click += Button_Edit_Click;
			checkBoxX_ReturnInvSale.Click += Button_Edit_Click;
			checkBoxX_InvPaymentReturn.Click += Button_Edit_Click;
			checkBoxX_InvEnter.Click += Button_Edit_Click;
			checkBoxX_InvOut.Click += Button_Edit_Click;
			doubleInput_DefPack.Click += Button_Edit_Click;
			textbox_Arb_Des.Click += Button_Edit_Click;
			textBox_CommItm.Click += Button_Edit_Click;
			textBox_DisItem.Click += Button_Edit_Click;
			textBox_TaxSales.Click += Button_Edit_Click;
			textBox_TaxPurchase.Click += Button_Edit_Click;
			textBox_SerialKey.Click += Button_Edit_Click;
			textbox_Cost1.Click += Button_Edit_Click;
			textbox_Cost2.Click += Button_Edit_Click;
			textbox_Cost3.Click += Button_Edit_Click;
			textbox_Cost4.Click += Button_Edit_Click;
			textbox_Cost5.Click += Button_Edit_Click;
			textbox_DateNo.Click += Button_Edit_Click;
			textbox_Distributors.Click += Button_Edit_Click;
			textbox_Eng_Des.Click += Button_Edit_Click;
			button_AddNewCat.Click += Button_Edit_Click;
			textbox_Legates.Click += Button_Edit_Click;
			textbox_MaxQty.Click += Button_Edit_Click;
			textbox_Pack1.Click += Button_Edit_Click;
			textbox_Pack2.Click += Button_Edit_Click;
			textbox_Pack3.Click += Button_Edit_Click;
			textbox_Pack4.Click += Button_Edit_Click;
			textbox_Pack5.Click += Button_Edit_Click;
			textbox_Qty1.Click += Button_Edit_Click;
			textbox_Qty2.Click += Button_Edit_Click;
			textbox_Qty3.Click += Button_Edit_Click;
			textbox_Qty4.Click += Button_Edit_Click;
			textbox_Qty5.Click += Button_Edit_Click;
			textbox_Sectorial.Click += Button_Edit_Click;
			textbox_SelPri1.Click += Button_Edit_Click;
			textbox_SelPri2.Click += Button_Edit_Click;
			textbox_SelPri3.Click += Button_Edit_Click;
			textbox_SelPri4.Click += Button_Edit_Click;
			textbox_SelPri5.Click += Button_Edit_Click;
			textbox_Sentence.Click += Button_Edit_Click;
			textbox_Supreme.Click += Button_Edit_Click;
			textbox_VIP.Click += Button_Edit_Click;
			radiobutton_RButDef1.Click += Button_Edit_Click;
			radiobutton_RButDef2.Click += Button_Edit_Click;
			radiobutton_RButDef3.Click += Button_Edit_Click;
			radiobutton_RButDef4.Click += Button_Edit_Click;
			radiobutton_RButDef5.Click += Button_Edit_Click;
			button_EnterImg.Click += Button_Edit_Click;
			combobox_DateTyp.Click += Button_Edit_Click;
			radioButton_Goods.Click += Button_Edit_Click;
			radioButton_Product.Click += Button_Edit_Click;
			radioButton_RawMaterial.Click += Button_Edit_Click;
			radioButton_Service.Click += Button_Edit_Click;
			combobox_ItmeGroup.Click += Button_Edit_Click;
			comboBox_DefPack.Click += Button_Edit_Click;
			comboboxItems_Unit1.Click += Button_Edit_Click;
			comboboxItems_Unit2.Click += Button_Edit_Click;
			comboboxItems_Unit3.Click += Button_Edit_Click;
			comboboxItems_Unit4.Click += Button_Edit_Click;
			comboboxItems_Unit5.Click += Button_Edit_Click;
			txtBarCode1.Click += Button_Edit_Click;
			txtBarCode2.Click += Button_Edit_Click;
			txtBarCode3.Click += Button_Edit_Click;
			txtBarCode4.Click += Button_Edit_Click;
			txtBarCode5.Click += Button_Edit_Click;
			txtFiled1.Click += Button_Edit_Click;
			txtFiled2.Click += Button_Edit_Click;
			txtFiled3.Click += Button_Edit_Click;
			txtFiled4.Click += Button_Edit_Click;
			txtFiled5.Click += Button_Edit_Click;
			txtFiled6.Click += Button_Edit_Click;
			DGV_Main.PrimaryGrid.CheckBoxes = false;
			DGV_Main.PrimaryGrid.ShowCheckBox = false;
			DGV_Main.PrimaryGrid.ShowTreeButton = false;
			DGV_Main.PrimaryGrid.ShowTreeButtons = false;
			DGV_Main.PrimaryGrid.ShowTreeLines = false;
			DGV_Main.PrimaryGrid.RowHeaderWidth = 25;
			DGV_Main.DataBindingComplete += DGV_Main_DataBindingComplete;
			expandableSplitter1.Click += expandableSplitter1_Click;
			ToolStripMenuItem_Det.Click += ToolStripMenuItem_Det_Click;
			Button_ExportTable2.Click += Button_ExportTable2_Click;
			textBox_search.InputTextChanged += TextBox_Search_InputTextChanged;
			textBox_search.ButtonCustomClick += TextBox_Search_ButtonCustomClick;
			TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
			TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
			Button_First.Click += Button_First_Click;
			Button_Prev.Click += Button_Prev_Click;
			Button_Next.Click += Button_Next_Click;
			Button_Last.Click += Button_Last_Click;
			Button_Add.Click += Button_Add_Click;
			Button_Search.Click += Button_Search_Click;
			Button_Delete.Click += Button_Delete_Click;
			Button_Save.Click += Button_Save_Click;
			Button_Close.Click += Button_Close_Click;
			Button_PrintTable.Click += Button_Print_Click;
			DGV_Main.DataBindingComplete += DGV_Main_DataBindingComplete;
			DGV_Main.MouseDown += DGV_Main_MouseDown;
			DGV_Main.CellDoubleClick += DGV_Main_CellDoubleClick;
			DGV_Main.CellClick += DGV_Main_CellClick;
			txtCustName.Click += Button_Edit_Click;
			txtCustNo.Click += Button_Edit_Click;
			FlxInv.KeyDown += FlxInv_KeyDown;
			FlxInv.MouseDown += FlxInv_MouseDown;
			FlxInv.RowColChange += FlxInv_RowColChange;
			FlxInv.SelChange += FlxInv_SelChange;
			GetInvSetting();
			if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49))
			{
				c1FlexGrid_Items.Cols[1].Format = "N3";
				c1FlexGrid_Items.Cols[2].Format = "N3";
				c1FlexGrid_Items.Cols[3].Format = "N3";
				c1FlexGrid_Items.Cols[4].Format = "N3";
				FlxInv.Cols[8].Format = "N3";
				FlxInv.Cols[9].Format = "N3";
				FlxInv.Cols[10].Format = "N3";
				FlxInv.Cols[11].Format = "N3";
				FlxInv.Cols[12].Format = "N3";
				FlxInv.Cols[31].Format = "N3";
				textBox_TaxPurchase.DisplayFormat = VarGeneral.DicemalMask;
				textBox_TaxSales.DisplayFormat = VarGeneral.DicemalMask;
				textbox_Legates.DisplayFormat = VarGeneral.DicemalMask;
				textbox_Distributors.DisplayFormat = VarGeneral.DicemalMask;
				textbox_Sentence.DisplayFormat = VarGeneral.DicemalMask;
				textbox_Sectorial.DisplayFormat = VarGeneral.DicemalMask;
				textbox_VIP.DisplayFormat = VarGeneral.DicemalMask;
			}
			if (VarGeneral.SSSLev == "F")
			{
				checkBoxX_Points.Visible = false;
			}
		}
		private void GetInvSetting()
		{
			_InvSetting = db.StockInvSetting(22);
			_SysSetting = db.SystemSettingStock();
			_Company = db.StockCompanyList().FirstOrDefault();
			_Curency = db.Fillcurency_2("").FirstOrDefault();
			txtCurr.Text = _Curency.Symbol;
		}
		public void Button_Search_Click(object sender, EventArgs e)
		{
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_Items";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                textBox_ID.Text = frm.SerachNo.ToString();
            }
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmItems));
			if (base.Tag.ToString() == "0")
			{
				SSSLanguage.Language.ChangeLanguage("ar-SA", this, resources);
				LangArEn = 0;
			}
			else
			{
				SSSLanguage.Language.ChangeLanguage("en", this, resources);
				LangArEn = 1;
			}
			RibunButtons();
			FillCombo();
			try
			{
				if (data_this != null)
				{
					SetData(data_this);
				}
			}
			catch
			{
			}
		}
		private void RibunButtons()
		{
			if (LangArEn == 0)
			{
				Button_First.Text = "الأول";
				Button_Last.Text = "الأخير";
				Button_Next.Text = "التالي";
				Button_Prev.Text = "السابق";
				Button_Add.Text = "جديد";
				Button_Close.Text = "اغلاق";
				Button_Delete.Text = "حذف";
				Button_Save.Text = "حفظ";
				Button_Search.Text = "بحث";
				Button_First.Tooltip = "السجل الاول";
				Button_Last.Tooltip = "السجل الاخير";
				Button_Next.Tooltip = "السجل التالي";
				Button_Prev.Tooltip = "السجل السابق";
				Button_Add.Tooltip = "F1";
				Button_Close.Tooltip = "Esc";
				Button_Delete.Tooltip = "F3";
				Button_Save.Tooltip = "F2";
				Button_Search.Tooltip = "F4";
				groupPanel_Inv.Text = "منع الصنف في فاتورة";
				Button_PrintTable.Text = ((VarGeneral.Settings_Sys.nTyp_Setting.Substring(0, 1) == "0") ? "طباعة" : "عــرض");
				Button_PrintTable.Tooltip = "F5";
				Button_ExportTable2.Text = "تصدير";
				Button_ExportTable2.Tooltip = "F10";
				DGV_Main.PrimaryGrid.GroupByRow.Text = "جميع السجلات";
				button_EnterImg.Tooltip = "إضافة صورة للصنف";
				button_ClearPic.Tooltip = "إزالة الصورة";
				radioButton_RawMaterial.Text = VarGeneral.Settings_Sys.ItemTyp2;
				radioButton_Product.Text = "مجمع\u0651ة";
				radioButton_Service.Text = "خدمة";
				radioButton_Goods.Text = VarGeneral.Settings_Sys.ItemTyp1;
				buttonItem_EditPrice.Text = "تعديل سعر وتكاليف هذا الصنف";
				buttonItem_EditPriceAll.Text = "تعديل أسعــار جميــع الأصنــاف";
				buttonItem_AddDisProcess.Text = "عمليات الزيادة والنقصان";
				sideBarPanelItem_Unit1.Text = "الوحدة الأولى";
				sideBarPanelItem_Unit2.Text = "الوحدة الثانية";
				sideBarPanelItem_Unit3.Text = "الوحدة الثالثة";
				sideBarPanelItem_Unit4.Text = "الوحدة الرابعة";
				sideBarPanelItem_Unit5.Text = "الوحدة الخامسة";
				labelItem4.Text = "الوحدة";
				labelItem5.Text = "التعبئة";
				labelItem30.Text = "سعر البيع";
				labelItem6.Text = "الكمية";
				labelItem7.Text = "التكلفة";
				labelItem8.Text = "رقم الباركود";
				radiobutton_RButDef1.Text = "الوحدة الإفتراضية";
				labelItem9.Text = "الوحدة";
				labelItem11.Text = "التعبئة";
				labelItem31.Text = "سعر البيع";
				labelItem12.Text = "الكمية";
				labelItem13.Text = "التكلفة";
				labelItem10.Text = "رقم الباركود";
				radiobutton_RButDef2.Text = "الوحدة الإفتراضية";
				labelItem14.Text = "الوحدة";
				labelItem16.Text = "التعبئة";
				labelItem32.Text = "سعر البيع";
				labelItem17.Text = "الكمية";
				labelItem18.Text = "التكلفة";
				labelItem15.Text = "رقم الباركود";
				radiobutton_RButDef3.Text = "الوحدة الإفتراضية";
				labelItem19.Text = "الوحدة";
				labelItem21.Text = "التعبئة";
				labelItem33.Text = "سعر البيع";
				labelItem22.Text = "الكمية";
				labelItem23.Text = "التكلفة";
				labelItem20.Text = "رقم الباركود";
				radiobutton_RButDef4.Text = "الوحدة الإفتراضية";
				labelItem24.Text = "الوحدة";
				labelItem26.Text = "التعبئة";
				labelItem34.Text = "سعر البيع";
				labelItem27.Text = "الكمية";
				labelItem28.Text = "التكلفة";
				labelItem25.Text = "رقم الباركود";
				radiobutton_RButDef2.Text = "الوحدة الإفتراضية";
				buttonItem_Serials.Text = "السيريال";
				c1FlexGrid_Items.Cols[0].Caption = "الكمية المتوفرة";
				c1FlexGrid_Items.Cols[1].Caption = "متوسط التكلفة";
				c1FlexGrid_Items.Cols[2].Caption = "آخر التكلفة";
				c1FlexGrid_Items.Cols[3].Caption = "تكلفة اول المدة";
				c1FlexGrid_Items.Cols[4].Caption = "أول تكلفة";
				c1FlexGrid_Items.Cols[5].Caption = "الرف";
				c1FlexGrid_Items.Cols[6].Caption = "تاريخ صلاحية";
				superTabItem_Details.Text = "المحتويــــات";
				Text = "الأصناف";
				labelX1.Text = "صورة الصنف";
				FlxInv.Cols[1].Caption = "رمز الصنف";
				FlxInv.Cols[2].Visible = true;
				FlxInv.Cols[3].Visible = true;
				FlxInv.Cols[4].Visible = false;
				FlxInv.Cols[5].Visible = false;
				FlxInv.Cols[6].Caption = "مستودع";
				FlxInv.Cols[7].Caption = "الكمية";
				FlxInv.Cols[8].Caption = "السعر";
				FlxInv.Cols[27].Caption = "الصلاحية";
				FlxInv.Cols[31].Caption = "الأجمالي";
				button_DeleteFromSystem.Text = "إزالة الصنف من النظام";
			}
			else
			{
				Button_First.Text = "First";
				Button_Last.Text = "Last";
				Button_Next.Text = "Next";
				Button_Prev.Text = "Previous";
				Button_Add.Text = "New";
				Button_Close.Text = "Close";
				Button_Delete.Text = "Delete";
				Button_Save.Text = "Save";
				Button_Search.Text = "Search";
				Button_First.Tooltip = "First Record";
				Button_Last.Tooltip = "Last Record";
				Button_Next.Tooltip = "Next Record";
				Button_Prev.Tooltip = "Previous Record";
				Button_Add.Tooltip = "F1";
				Button_Close.Tooltip = "Esc";
				Button_Delete.Tooltip = "F3";
				Button_Save.Tooltip = "F2";
				Button_Search.Tooltip = "F4";
				groupPanel_Inv.Text = "Prevent product in the Invoice";
				Button_PrintTable.Text = ((VarGeneral.Settings_Sys.nTyp_Setting.Substring(0, 1) == "0") ? "Print" : "Show");
				Button_PrintTable.Tooltip = "F5";
				Button_ExportTable2.Text = "Export";
				Button_ExportTable2.Tooltip = "F10";
				DGV_Main.PrimaryGrid.GroupByRow.Text = "All Records";
				button_EnterImg.Tooltip = "Add Image For Item";
				button_ClearPic.Tooltip = "Image Removed";
				radioButton_RawMaterial.Text = VarGeneral.Settings_Sys.ItemTyp2E;
				radioButton_Product.Text = "Gusset";
				radioButton_Service.Text = "Service";
				radioButton_Goods.Text = VarGeneral.Settings_Sys.ItemTyp1E;
				buttonItem_EditPrice.Text = "Price Edite This Item";
				buttonItem_EditPriceAll.Text = "Price Edite All Items";
				buttonItem_AddDisProcess.Text = "Increases and decreases";
				sideBarPanelItem_Unit1.Text = "First Unit";
				sideBarPanelItem_Unit2.Text = "Second Unit";
				sideBarPanelItem_Unit3.Text = "Third Unit";
				sideBarPanelItem_Unit4.Text = "Fourth Unit";
				sideBarPanelItem_Unit5.Text = "Fifth Unit";
				labelItem4.Text = "Unit";
				labelItem5.Text = "Fill";
				labelItem30.Text = "Sale Price";
				labelItem6.Text = "Quantity";
				labelItem7.Text = "Cost";
				labelItem8.Text = "Barcode No";
				radiobutton_RButDef1.Text = "Default Unit";
				labelItem9.Text = "Unit";
				labelItem11.Text = "Fill";
				labelItem31.Text = "Sale Price";
				labelItem12.Text = "Quantity";
				labelItem13.Text = "Cost";
				labelItem10.Text = "Barcode No";
				radiobutton_RButDef2.Text = "Default Unit";
				buttonItem_Serials.Text = "Serial";
				labelItem14.Text = "Unit";
				labelItem16.Text = "Fill";
				labelItem32.Text = "Sale Price";
				labelItem17.Text = "Quantity";
				labelItem18.Text = "Cost";
				labelItem15.Text = "Barcode No";
				radiobutton_RButDef3.Text = "Default Unit";
				labelItem19.Text = "Unit";
				labelItem21.Text = "Fill";
				labelItem33.Text = "Sale Price";
				labelItem22.Text = "Quantity";
				labelItem23.Text = "Cost";
				labelItem20.Text = "Barcode No";
				radiobutton_RButDef4.Text = "Default Unit";
				labelItem24.Text = "Unit";
				labelItem26.Text = "Fill";
				labelItem34.Text = "Sale Price";
				labelItem27.Text = "Quantity";
				labelItem28.Text = "Cost";
				labelItem25.Text = "Barcode No";
				radiobutton_RButDef2.Text = "Default Unit";
				c1FlexGrid_Items.Cols[0].Caption = "Quantity";
				c1FlexGrid_Items.Cols[1].Caption = "Avrg Cost";
				c1FlexGrid_Items.Cols[2].Caption = "Last Cost";
				c1FlexGrid_Items.Cols[3].Caption = "cost open";
				c1FlexGrid_Items.Cols[4].Caption = "First Cost";
				c1FlexGrid_Items.Cols[5].Caption = "Rack";
				c1FlexGrid_Items.Cols[6].Caption = "Expir date";
				superTabItem_Details.Text = "Containts";
				Text = "Items";
				labelX1.Text = "Item Image";
				FlxInv.Cols[1].Caption = "Item Code";
				FlxInv.Cols[2].Visible = false;
				FlxInv.Cols[3].Visible = false;
				FlxInv.Cols[4].Visible = true;
				FlxInv.Cols[5].Visible = true;
				FlxInv.Cols[6].Caption = "Store";
				FlxInv.Cols[7].Caption = "Quantity";
				FlxInv.Cols[8].Caption = "Price";
				FlxInv.Cols[27].Caption = "Validity";
				FlxInv.Cols[31].Caption = "Totel";
				button_DeleteFromSystem.Text = "Remove Item from System";
			}
		}
		private void FrmItems_Load(object sender, EventArgs e)
		{
			try
			{
                this.Location = new Point(42, 175);
                buttonItem7.ButtonStyle = eButtonStyle.ImageAndText;
                   ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmItems));
				if (base.Tag.ToString() == "0")
				{
					SSSLanguage.Language.ChangeLanguage("ar-SA", this, resources);
					LangArEn = 0;
				}
				else
				{
					SSSLanguage.Language.ChangeLanguage("en", this, resources);
					LangArEn = 1;
				}
				ADD_Controls();
				Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
				if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 75))
				{
					checkBoxX_Points.Visible = false;
				}
				if (columns_Names_visible.Count == 0)
				{
					columns_Names_visible.Add("Itm_No", new ColumnDictinary("رقم الصنف", "Item No", ifDefault: true, ""));
					columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
					columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
					if (!File.Exists(Application.StartupPath + "\\\\Script\\\\SecriptInvitationCards.dll"))
					{
						columns_Names_visible.Add("Itm_ID", new ColumnDictinary("الرقم التسلسلي", "Seq No", ifDefault: false, ""));
						columns_Names_visible.Add("AvrageCost", new ColumnDictinary("متوسط التكلفة", "Average Cost", ifDefault: true, ""));
						columns_Names_visible.Add("UntPri1", new ColumnDictinary("سعر البيع 1", "Sale Price 1", ifDefault: true, ""));
						columns_Names_visible.Add("Arb_Des_Cat", new ColumnDictinary("الاسم العربي لمجموعة الصنف", "CATEGORY Arabic Name", ifDefault: false, ""));
						columns_Names_visible.Add("Eng_Des_Cat", new ColumnDictinary("الاسم الانجليزي لمجموعة الصنف", "CATEGORY English Name", ifDefault: false, ""));
					}
					columns_Names_visible.Add("BarCod1", new ColumnDictinary("رقم الباركود 1", "Barcode No 1", ifDefault: false, ""));
					columns_Names_visible.Add("BarCod2", new ColumnDictinary("رقم الباركود 2", "Barcode No 2", ifDefault: false, ""));
					columns_Names_visible.Add("BarCod3", new ColumnDictinary("رقم الباركود 3", "Barcode No 3", ifDefault: false, ""));
					columns_Names_visible.Add("BarCod4", new ColumnDictinary("رقم الباركود 4", "Barcode No 4", ifDefault: false, ""));
				}
				else
				{
					Clear();
					textBox_ID.Text = "";
					TextBox_Index.TextBox.Text = "";
				}
				FillCombo();
				RibunButtons();
				RefreshPKeys();
				c1FlexGrid_Items.SetData(1, 0, 0);
				c1FlexGrid_Items.SetData(1, 1, 0);
				c1FlexGrid_Items.SetData(1, 2, 0);
				c1FlexGrid_Items.SetData(1, 3, 0);
				c1FlexGrid_Items.SetData(1, 4, 0);
				c1FlexGrid_Items.SetData(1, 5, "");
				c1FlexGrid_Items.SetData(1, 6, false);
				textBox_ID.Text = PKeys.FirstOrDefault();
				UnitTabs();
				radioButton_Product_CheckedChanged(null, null);
				if (!string.IsNullOrEmpty(VarGeneral.itmDes))
				{
					Button_Add_Click(sender, e);
					if (VarGeneral.itmDesIndex == 1)
					{
						textBox_ID.Text = VarGeneral.ItmDes;
					}
					else if (VarGeneral.itmDesIndex == 2)
					{
						textbox_Arb_Des.Text = VarGeneral.ItmDes;
					}
					else
					{
						textbox_Eng_Des.Text = VarGeneral.ItmDes;
					}
				}
				listUnit = new List<T_Unit>();
				listStore = new List<T_Store>();
				listUnit = db.FillUnit_2("").ToList();
				listStore = db.FillStore_2("").ToList();
				string Co = "";
				for (int iiCnt = 0; iiCnt < listStore.Count; iiCnt++)
				{
					_Store = listStore[iiCnt];
					Co = ((!(Co != "")) ? _Store.Stor_ID.ToString() : (Co + "|" + _Store.Stor_ID));
				}
				FlxInv.Cols[6].ComboList = Co;
				UpdateVcr();
				int Comm_ = 0;
				try
				{
					Comm_ = int.Parse(VarGeneral.Settings_Sys.Seting.Substring(50, 1));
				}
				catch
				{
				}
				if (Comm_ == 0)
				{
					label10.Visible = true;
				}
				else
				{
					label10.Visible = false;
				}
				if (File.Exists(Application.StartupPath + "\\\\Script\\\\SecriptInvitationCards.dll"))
				{
					Script_InvitationCards();
				}
				if (File.Exists(Application.StartupPath + "\\\\Script\\\\SecriptSchool.dll"))
				{
					Script_School();
				}
				if (File.Exists(Application.StartupPath + "\\\\Script\\\\SecriptCeramic.dll"))
				{
					textBox_DisItem.Visible = false;
					label16.Visible = false;
					textBox_CommItm.Visible = false;
					label10.Visible = false;
					doubleInput_DefPack.Visible = true;
					label5.Text = ((LangArEn == 0) ? "تعبئة الكراتين :" : "Carton Pack :");
					comboBox_DefPack.Visible = true;
					label8.Text = ((LangArEn == 0) ? "وحدة الكراتين :" : "Carton Unit :");
				}
				if (File.Exists(Application.StartupPath + "\\\\Script\\\\SecriptMaintenanceCars.dll"))
				{
					labelItem5.Visible = false;
					labelItem11.Visible = false;
					labelItem16.Visible = false;
					labelItem21.Visible = false;
					labelItem26.Visible = false;
					textbox_Pack1.Visible = false;
					textbox_Pack2.Visible = false;
					textbox_Pack3.Visible = false;
					textbox_Pack4.Visible = false;
					textbox_Pack5.Visible = false;
				}
				if (File.Exists(Application.StartupPath + "\\\\Script\\\\SecriptTegnicalCollage.dll"))
				{
					TegnicalCollage();
				}
				if (File.Exists(Application.StartupPath + "\\\\Script\\\\SecriptWaterPackages.dll"))
				{
					checkBoxX_Points.Visible = false;
					buttonItem_Serials.Visible = false;
				}
				if (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", "").Trim() + "\\khalijwatania.dll") && VarGeneral.InvType == 1)
				{
					checkBoxX_InvSale.Text = ((LangArEn == 0) ? "خــدمـــة" : "Service");
				}
				if (File.Exists(Application.StartupPath + "\\\\Script\\\\SecriptGlasses.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", "").Trim() + "\\SecriptGlasses.dll")))
				{
					panelEx_Size.Visible = true;
					panelEx_Size.Location = new Point(5, panelEx_Size.Location.Y);
					expandablePanel_AnotherPrice.TitleText = ((LangArEn == 0) ? "المقـــاسات" : "Sizes");
				}
				if (File.Exists(Application.StartupPath + "\\\\Script\\\\Secriptjustlight.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", "").Trim() + "\\Secriptjustlight.dll")))
				{
					labelItem30.Text = ((LangArEn == 0) ? "سعر الإيجار" : "rent price");
					labelItem31.Text = ((LangArEn == 0) ? "سعر الإيجار" : "rent price");
					labelItem32.Text = ((LangArEn == 0) ? "سعر الإيجار" : "rent price");
					labelItem33.Text = ((LangArEn == 0) ? "سعر الإيجار" : "rent price");
					labelItem34.Text = ((LangArEn == 0) ? "سعر الإيجار" : "rent price");
				}
			}
			catch (Exception error)
			{
				VarGeneral.DebLog.writeLog("Load:", error, enable: true);
				MessageBox.Show(error.Message);
			}
		}
		private void TegnicalCollage()
		{
			checkBoxX_BarcodeBalance.Visible = false;
			checkBoxX_Points.Visible = false;
			label11.Visible = false;
			textbox_Supreme.Visible = false;
			label13.Visible = false;
			textBox_TaxSales.Visible = false;
			label14.Visible = false;
			label8.Visible = false;
			textBox_CommItm.Visible = false;
			label10.Visible = false;
			c1FlexGrid_Items.Cols[6].Visible = false;
			radioButton_Product.Visible = false;
			radioButton_Service.Visible = false;
			buttonItem_Serials.Visible = false;
			buttonItem_EditPriceAll.Visible = false;
			buttonItem_AddDisProcess.Visible = false;
			buttonItem_Serials.Visible = false;
			labelItem30.Visible = false;
			labelItem31.Visible = false;
			labelItem32.Visible = false;
			labelItem33.Visible = false;
			labelItem34.Visible = false;
			checkBoxX_InvEnter.Text = ((LangArEn == 0) ? "إصدار عهـدة" : "Issuance Custody");
			expandablePanel_AnotherPrice.TitleText = "";
			expandablePanel_AnotherPrice.ExpandButtonVisible = false;
			expandablePanel_AnotherPrice.Enabled = false;
			label15.Location = label13.Location;
			textBox_TaxPurchase.Location = textBox_TaxSales.Location;
			checkBoxX_InvEnter.Location = checkBoxX_ReturnInvSale.Location;
			checkBoxX_InvOut.Visible = false;
			checkBoxX_InvSale.Visible = false;
			checkBoxX_ReturnInvSale.Visible = false;
			textbox_SelPri1.Visible = false;
			textbox_SelPri2.Visible = false;
			textbox_SelPri3.Visible = false;
			textbox_SelPri4.Visible = false;
			textbox_SelPri5.Visible = false;
		}
		private void Script_InvitationCards()
		{
			c1FlexGrid_Items.Visible = false;
			label11.Visible = false;
			textbox_Supreme.Visible = false;
			groupPanel_Inv.Visible = false;
			superTabItem_Details.Visible = false;
			sideBarPanelItem_Unit2.Visible = false;
			sideBarPanelItem_Unit3.Visible = false;
			sideBarPanelItem_Unit4.Visible = false;
			sideBarPanelItem_Unit5.Visible = false;
			buttonItem_Serials.Visible = false;
			metroStatusBar_itemsType.Visible = false;
			expandablePanel_AnotherPrice.ExpandButtonVisible = false;
			label13.Visible = false;
			textBox_TaxSales.Visible = false;
			label9.Visible = false;
			label15.Visible = false;
			textBox_TaxPurchase.Visible = false;
			label14.Visible = false;
			label8.Visible = false;
			textBox_CommItm.Visible = false;
			textBox_DisItem.Visible = false;
			label16.Visible = false;
			label5.Visible = false;
			label10.Visible = false;
			if (VarGeneral.UserID != 1)
			{
				buttonItem_EditPrice.Visible = false;
			}
			labelItem6.Visible = false;
			textbox_Qty1.Visible = false;
			labelItem7.Visible = false;
			textbox_Cost1.Visible = false;
			label3.Location = new Point(label3.Location.X, label3.Location.Y - 50);
			txtCustName.Location = new Point(txtCustName.Location.X, txtCustName.Location.Y - 50);
			button_SrchCustNo.Location = new Point(button_SrchCustNo.Location.X, button_SrchCustNo.Location.Y - 50);
			pictureBox_PicItem.Location = new Point(pictureBox_PicItem.Location.X, pictureBox_PicItem.Location.Y - 50);
			button_ClearPic.Location = new Point(button_ClearPic.Location.X, button_ClearPic.Location.Y - 50);
			button_EnterImg.Location = new Point(button_EnterImg.Location.X, button_EnterImg.Location.Y - 50);
			labelX1.Location = new Point(labelX1.Location.X, labelX1.Location.Y - 50);
			panelEx2.MinimumSize = new Size(0, 0);
			panelEx2.Height = 360;
			base.Height = 401;
			label3.Text = ((LangArEn == 0) ? "حساب العميل :" : "Customer Account :");
			expandablePanel_AnotherPrice.TitleText = "";
		}
		private void Script_School()
		{
			label11.Visible = false;
			textbox_Supreme.Visible = false;
			checkBoxX_InvEnter.Visible = false;
			checkBoxX_InvOut.Visible = false;
			superTabItem_Details.Visible = false;
			buttonItem_Serials.Visible = false;
			radioButton_RawMaterial.Visible = false;
			radioButton_Product.Visible = false;
			label13.Visible = false;
			textBox_TaxSales.Visible = false;
			label9.Visible = false;
			label15.Visible = false;
			textBox_TaxPurchase.Visible = false;
			label14.Visible = false;
			label8.Visible = false;
			textBox_CommItm.Visible = false;
			textBox_DisItem.Visible = false;
			label16.Visible = false;
			label5.Visible = false;
			label10.Visible = false;
			if (VarGeneral.UserID != 1)
			{
				buttonItem_EditPrice.Visible = false;
			}
		}
		private void textBox_ID_TextChanged(object sender, EventArgs e)
		{
			button_DeleteFromSystem.Visible = false;
			string no = "";
			try
			{
				no = textBox_ID.Text;
			}
			catch
			{
			}
			try
			{
				T_Item newData = db.StockItem(no);
				if (newData == null || string.IsNullOrEmpty(newData.Itm_No))
				{
					if (!Button_Add.Visible || !Button_Add.Enabled)
					{
						MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						textBox_ID.TextChanged -= textBox_ID_TextChanged;
						try
						{
							textBox_ID.Text = data_this.Itm_No;
						}
						catch
						{
						}
						textBox_ID.TextChanged += textBox_ID_TextChanged;
						return;
					}
					Clear();
					try
					{
						if (comboboxItems_Unit1.Items.Count > 0)
						{
							comboboxItems_Unit1.SelectedIndex = 1;
						}
					}
					catch
					{
						comboboxItems_Unit1.SelectedIndex = 0;
					}
					TextBox_Index.InputTextChanged -= TextBox_Index_InputTextChanged;
					TextBox_Index.TextBox.Text = string.Concat(PKeys.Count + 1);
					TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
				}
				else
				{
					DataThis = newData;
					int indexA = PKeys.IndexOf(newData.Itm_No ?? "");
					indexA++;
					TextBox_Index.InputTextChanged -= TextBox_Index_InputTextChanged;
					TextBox_Index.TextBox.Text = string.Concat(indexA);
					TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
				}
			}
			catch
			{
			}
			UpdateVcr();
			if (File.Exists(Application.StartupPath + "\\\\Script\\\\SecriptMaintenanceCars.dll"))
			{
				comboboxItems_Unit1.Enabled = false;
				comboboxItems_Unit2.Enabled = false;
				comboboxItems_Unit3.Enabled = false;
				comboboxItems_Unit4.Enabled = false;
				comboboxItems_Unit5.Enabled = false;
			}
		}
		private void FillCombo()
		{
			int _CmbIndex = combobox_DateTyp.SelectedIndex;
			combobox_DateTyp.Items.Clear();
			if (LangArEn == 0)
			{
				combobox_DateTyp.Items.Clear();
				combobox_DateTyp.Items.Add("يوم");
				combobox_DateTyp.Items.Add("شهر");
				combobox_DateTyp.Items.Add("سنة");
				comboBox_DefPack.Items.Clear();
				comboBox_DefPack.Items.Add("الوحدة الأولى");
				comboBox_DefPack.Items.Add("الوحدة الثانية");
				comboBox_DefPack.Items.Add("الوحدة الثالثة");
				comboBox_DefPack.Items.Add("الوحدة الرابعة");
				comboBox_DefPack.Items.Add("الوحدة الخامسة");
				comboBox_DefPack.SelectedIndex = 0;
				_CmbIndex = combobox_ItmeGroup.SelectedIndex;
				List<T_CATEGORY> listAccCat = new List<T_CATEGORY>(db.T_CATEGORies.Select((T_CATEGORY item) => item).ToList());
				combobox_ItmeGroup.DataSource = listAccCat;
				combobox_ItmeGroup.DisplayMember = "Arb_Des";
				combobox_ItmeGroup.ValueMember = "CAT_ID";
				combobox_ItmeGroup.SelectedIndex = 0;
				_CmbIndex = combobox_Unit1.SelectedIndex;
				combobox_Unit1.DataSource = null;
				List<T_Unit> listUnit1 = new List<T_Unit>(db.T_Units.Select((T_Unit item) => item).ToList());
				listUnit1.Insert(0, new T_Unit());
				combobox_Unit1.DataSource = listUnit1;
				combobox_Unit1.DisplayMember = "Arb_Des";
				combobox_Unit1.ValueMember = "Unit_ID";
				comboboxItems_Unit1.Items.Add(" ");
				for (int i = 1; i < combobox_Unit1.Items.Count; i++)
				{
					combobox_Unit1.SelectedIndex = i;
					comboboxItems_Unit1.Items.Add(combobox_Unit1.Text);
				}
				comboboxItems_Unit1.SelectedIndex = _CmbIndex;
				combobox_Unit1.SelectedIndex = _CmbIndex;
				_CmbIndex = combobox_Unit2.SelectedIndex;
				combobox_Unit2.DataSource = null;
				List<T_Unit> listUnit2 = new List<T_Unit>(db.T_Units.Select((T_Unit item) => item).ToList());
				listUnit2.Insert(0, new T_Unit());
				combobox_Unit2.DataSource = listUnit2;
				combobox_Unit2.DisplayMember = "Arb_Des";
				combobox_Unit2.ValueMember = "Unit_ID";
				combobox_Unit2.SelectedIndex = _CmbIndex;
				comboboxItems_Unit2.Items.Add(" ");
				for (int i = 1; i < combobox_Unit2.Items.Count; i++)
				{
					combobox_Unit2.SelectedIndex = i;
					comboboxItems_Unit2.Items.Add(combobox_Unit2.Text);
				}
				comboboxItems_Unit2.SelectedIndex = _CmbIndex;
				combobox_Unit2.SelectedIndex = _CmbIndex;
				_CmbIndex = combobox_Unit3.SelectedIndex;
				combobox_Unit3.DataSource = null;
				List<T_Unit> listUnit3 = new List<T_Unit>(db.T_Units.Select((T_Unit item) => item).ToList());
				listUnit3.Insert(0, new T_Unit());
				combobox_Unit3.DataSource = listUnit3;
				combobox_Unit3.DisplayMember = "Arb_Des";
				combobox_Unit3.ValueMember = "Unit_ID";
				combobox_Unit3.SelectedIndex = _CmbIndex;
				comboboxItems_Unit3.Items.Add(" ");
				for (int i = 1; i < combobox_Unit3.Items.Count; i++)
				{
					combobox_Unit3.SelectedIndex = i;
					comboboxItems_Unit3.Items.Add(combobox_Unit3.Text);
				}
				comboboxItems_Unit3.SelectedIndex = _CmbIndex;
				combobox_Unit3.SelectedIndex = _CmbIndex;
				_CmbIndex = combobox_Unit4.SelectedIndex;
				combobox_Unit4.DataSource = null;
				List<T_Unit> listUnit4 = new List<T_Unit>(db.T_Units.Select((T_Unit item) => item).ToList());
				listUnit4.Insert(0, new T_Unit());
				combobox_Unit4.DataSource = listUnit4;
				combobox_Unit4.DisplayMember = "Arb_Des";
				combobox_Unit4.ValueMember = "Unit_ID";
				combobox_Unit4.SelectedIndex = _CmbIndex;
				comboboxItems_Unit4.Items.Add(" ");
				for (int i = 1; i < combobox_Unit4.Items.Count; i++)
				{
					combobox_Unit4.SelectedIndex = i;
					comboboxItems_Unit4.Items.Add(combobox_Unit4.Text);
				}
				comboboxItems_Unit4.SelectedIndex = _CmbIndex;
				combobox_Unit4.SelectedIndex = _CmbIndex;
				_CmbIndex = combobox_Unit5.SelectedIndex;
				combobox_Unit5.DataSource = null;
				List<T_Unit> listUnit5 = new List<T_Unit>(db.T_Units.Select((T_Unit item) => item).ToList());
				listUnit5.Insert(0, new T_Unit());
				combobox_Unit5.DataSource = listUnit5;
				combobox_Unit5.DisplayMember = "Arb_Des";
				combobox_Unit5.ValueMember = "Unit_ID";
				combobox_Unit5.SelectedIndex = _CmbIndex;
				comboboxItems_Unit5.Items.Add(" ");
				for (int i = 1; i < combobox_Unit5.Items.Count; i++)
				{
					combobox_Unit5.SelectedIndex = i;
					comboboxItems_Unit5.Items.Add(combobox_Unit5.Text);
				}
				comboboxItems_Unit5.SelectedIndex = _CmbIndex;
				combobox_Unit5.SelectedIndex = _CmbIndex;
			}
			else
			{
				combobox_DateTyp.Items.Add("Day");
				combobox_DateTyp.Items.Add("Month");
				combobox_DateTyp.Items.Add("Year");
				comboBox_DefPack.Items.Clear();
				comboBox_DefPack.Items.Add("Unit 1");
				comboBox_DefPack.Items.Add("Unit 2");
				comboBox_DefPack.Items.Add("Unit 3");
				comboBox_DefPack.Items.Add("Unit 4");
				comboBox_DefPack.Items.Add("Unit 5");
				comboBox_DefPack.SelectedIndex = 0;
				List<T_CATEGORY> listAccCat = new List<T_CATEGORY>(db.T_CATEGORies.Select((T_CATEGORY item) => item).ToList());
				combobox_ItmeGroup.DataSource = listAccCat;
				combobox_ItmeGroup.DisplayMember = "Eng_Des";
				combobox_ItmeGroup.ValueMember = "CAT_ID";
				combobox_ItmeGroup.SelectedIndex = 0;
				combobox_Unit1.DataSource = null;
				List<T_Unit> listUnit1 = new List<T_Unit>(db.T_Units.Select((T_Unit item) => item).ToList());
				listUnit1.Insert(0, new T_Unit());
				combobox_Unit1.DataSource = listUnit1;
				combobox_Unit1.DisplayMember = "Eng_Des";
				combobox_Unit1.ValueMember = "Unit_ID";
				comboboxItems_Unit1.Items.Add(" ");
				for (int i = 1; i < combobox_Unit1.Items.Count; i++)
				{
					combobox_Unit1.SelectedIndex = i;
					comboboxItems_Unit1.Items.Add(combobox_Unit1.Text);
				}
				comboboxItems_Unit1.SelectedIndex = _CmbIndex;
				combobox_Unit1.SelectedIndex = _CmbIndex;
				combobox_Unit2.DataSource = null;
				List<T_Unit> listUnit2 = new List<T_Unit>(db.T_Units.Select((T_Unit item) => item).ToList());
				listUnit2.Insert(0, new T_Unit());
				combobox_Unit2.DataSource = listUnit2;
				combobox_Unit2.DisplayMember = "Eng_Des";
				combobox_Unit2.ValueMember = "Unit_ID";
				comboboxItems_Unit2.Items.Add(" ");
				for (int i = 1; i < combobox_Unit2.Items.Count; i++)
				{
					combobox_Unit2.SelectedIndex = i;
					comboboxItems_Unit2.Items.Add(combobox_Unit2.Text);
				}
				comboboxItems_Unit2.SelectedIndex = _CmbIndex;
				combobox_Unit2.SelectedIndex = _CmbIndex;
				combobox_Unit3.DataSource = null;
				List<T_Unit> listUnit3 = new List<T_Unit>(db.T_Units.Select((T_Unit item) => item).ToList());
				listUnit3.Insert(0, new T_Unit());
				combobox_Unit3.DataSource = listUnit3;
				combobox_Unit3.DisplayMember = "Eng_Des";
				combobox_Unit3.ValueMember = "Unit_ID";
				comboboxItems_Unit3.Items.Add(" ");
				for (int i = 1; i < combobox_Unit3.Items.Count; i++)
				{
					combobox_Unit3.SelectedIndex = i;
					comboboxItems_Unit3.Items.Add(combobox_Unit3.Text);
				}
				comboboxItems_Unit3.SelectedIndex = _CmbIndex;
				combobox_Unit3.SelectedIndex = _CmbIndex;
				combobox_Unit4.DataSource = null;
				List<T_Unit> listUnit4 = new List<T_Unit>(db.T_Units.Select((T_Unit item) => item).ToList());
				listUnit4.Insert(0, new T_Unit());
				combobox_Unit4.DataSource = listUnit4;
				combobox_Unit4.DisplayMember = "Eng_Des";
				combobox_Unit4.ValueMember = "Unit_ID";
				comboboxItems_Unit4.Items.Add(" ");
				for (int i = 1; i < combobox_Unit4.Items.Count; i++)
				{
					combobox_Unit4.SelectedIndex = i;
					comboboxItems_Unit4.Items.Add(combobox_Unit4.Text);
				}
				comboboxItems_Unit4.SelectedIndex = _CmbIndex;
				combobox_Unit4.SelectedIndex = _CmbIndex;
				combobox_Unit5.DataSource = null;
				List<T_Unit> listUnit5 = new List<T_Unit>(db.T_Units.Select((T_Unit item) => item).ToList());
				listUnit5.Insert(0, new T_Unit());
				combobox_Unit5.DataSource = listUnit5;
				combobox_Unit5.DisplayMember = "Eng_Des";
				combobox_Unit5.ValueMember = "Unit_ID";
				comboboxItems_Unit5.Items.Add(" ");
				for (int i = 1; i < combobox_Unit5.Items.Count; i++)
				{
					combobox_Unit5.SelectedIndex = i;
					comboboxItems_Unit5.Items.Add(combobox_Unit5.Text);
				}
				comboboxItems_Unit5.SelectedIndex = _CmbIndex;
				combobox_Unit5.SelectedIndex = _CmbIndex;
			}
		}
		public void Clear()
		{
			if (State == FormState.New)
			{
				return;
			}
			State = FormState.New;
			data_this = new T_Item();
			State = FormState.New;
			for (int i = 0; i < controls.Count; i++)
			{
				if (controls[i].GetType() == typeof(DateTimePicker))
				{
					int? calendr = VarGeneral.Settings_Sys.Calendr;
					if (calendr.GetValueOrDefault() == 0 && calendr.HasValue)
					{
						(controls[i] as DateTimePicker).Value = Convert.ToDateTime(n.GDateNow());
					}
					else
					{
						(controls[i] as DateTimePicker).Text = n.HDateNow();
					}
				}
				else if (controls[i].GetType() == typeof(CheckBox))
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
						controls[i].Text = "";
					}
					else if (controls[i].GetType() == typeof(CheckBox))
					{
						(controls[i] as CheckBox).Checked = false;
					}
					else if (controls[i].GetType() == typeof(RadioButton))
					{
						(controls[i] as RadioButton).Checked = false;
					}
				}
			}
			try
			{
				comboboxItems_Unit1.SelectedIndex = 0;
				comboboxItems_Unit2.SelectedIndex = 0;
				comboboxItems_Unit3.SelectedIndex = 0;
				comboboxItems_Unit4.SelectedIndex = 0;
				comboboxItems_Unit5.SelectedIndex = 0;
			}
			catch
			{
			}
			try
			{
				doubleInput_DefPack.Text = "";
			}
			catch
			{
			}
			try
			{
				comboBox_DefPack.SelectedIndex = 0;
			}
			catch
			{
			}
			c1FlexGrid_Items.SetData(1, 0, 0);
			c1FlexGrid_Items.SetData(1, 1, 0);
			c1FlexGrid_Items.SetData(1, 2, 0);
			c1FlexGrid_Items.SetData(1, 3, 0);
			c1FlexGrid_Items.SetData(1, 4, 0);
			c1FlexGrid_Items.SetData(1, 5, "");
			c1FlexGrid_Items.SetData(1, 6, false);
			textbox_Cost1.Text = "";
			textbox_Cost2.Text = "";
			textbox_Cost3.Text = "";
			textbox_Cost4.Text = "";
			textbox_Cost5.Text = "";
			textbox_Pack1.Text = "1";
			textbox_Pack2.Text = "";
			textbox_Pack3.Text = "";
			textbox_Pack4.Text = "";
			textbox_Pack5.Text = "";
			textbox_Qty1.Text = "";
			textbox_Qty2.Text = "";
			textbox_Qty3.Text = "";
			textbox_Qty4.Text = "";
			textbox_Qty5.Text = "";
			textbox_SelPri1.Text = "";
			textbox_SelPri2.Text = "";
			textbox_SelPri3.Text = "";
			textbox_SelPri4.Text = "";
			textbox_SelPri5.Text = "";
			txtBarCode1.Text = "";
			txtBarCode2.Text = "";
			txtBarCode3.Text = "";
			txtBarCode4.Text = "";
			txtBarCode5.Text = "";
			radiobutton_RButDef1.Checked = true;
			radiobutton_RButDef2.Checked = false;
			radiobutton_RButDef3.Checked = false;
			radiobutton_RButDef4.Checked = false;
			radiobutton_RButDef5.Checked = false;
			radioButton_Goods.Checked = true;
			radioButton_Product.Checked = false;
			radioButton_RawMaterial.Checked = false;
			radioButton_Service.Checked = false;
			checkBoxX_BarcodeBalance.Checked = false;
			checkBoxX_Points.Checked = true;
			checkBoxX_ReturnInvSale.Checked = false;
			checkBoxX_InvSale.Checked = false;
			checkBoxX_InvPaymentReturn.Checked = false;
			checkBoxX_InvPayment.Checked = false;
			checkBoxX_InvEnter.Checked = false;
			checkBoxX_InvOut.Checked = false;
			comboboxItems_Unit1.Enabled = true;
			textbox_SelPri1.Enabled = true;
			textbox_Pack1.Enabled = true;
			comboboxItems_Unit2.Enabled = true;
			textbox_SelPri2.Enabled = true;
			textbox_Pack2.Enabled = true;
			comboboxItems_Unit3.Enabled = true;
			textbox_SelPri3.Enabled = true;
			textbox_Pack3.Enabled = true;
			comboboxItems_Unit4.Enabled = true;
			textbox_SelPri4.Enabled = true;
			textbox_Pack4.Enabled = true;
			comboboxItems_Unit5.Enabled = true;
			textbox_SelPri5.Enabled = true;
			textbox_Pack5.Enabled = true;
			textbox_Legates.IsInputReadOnly = false;
			textbox_Distributors.IsInputReadOnly = false;
			textbox_Sentence.IsInputReadOnly = false;
			textbox_Sectorial.IsInputReadOnly = false;
			textbox_VIP.IsInputReadOnly = false;
			metroStatusBar_itemsType.Enabled = true;
			if (FlxInv.Rows.Count <= 1)
			{
				FlxInv.Rows.Count = 100;
			}
			else
			{
				FlxInv.Clear(ClearFlags.Content, 1, 1, FlxInv.Rows.Count - 1, 34);
			}
			pictureBox_PicItem.Image = null;
			button_DeleteFromSystem.Visible = false;
			textBox_TaxSales.Value = VarGeneral.Settings_Sys.DefSalesTax.Value;
			textBox_TaxPurchase.Value = VarGeneral.Settings_Sys.DefPurchaesTax.Value;
			if (File.Exists(Application.StartupPath + "\\\\Script\\\\SecriptInvitationCards.dll"))
			{
				radioButton_Service.Checked = true;
			}
			SetReadOnly = false;
		}
		public void SetData(T_Item value)
		{
			State = FormState.Saved;
			Button_Save.Enabled = false;
			txtBarCode1.GotFocus -= txtBarCode1_GotFocus;
			try
			{
				if (FlxInv.Rows.Count <= 1)
				{
					FlxInv.Rows.Count = 100;
				}
				else
				{
					FlxInv.Clear(ClearFlags.Content, 1, 1, FlxInv.Rows.Count - 1, 34);
				}
			}
			catch
			{
			}
			bool returned = db.StockCheckInvDet(DataThis.Itm_No);
			try
			{
				if (returned)
				{
					buttonItem_EditPrice.Enabled = true;
				}
				else
				{
					buttonItem_EditPrice.Enabled = false;
				}
			}
			catch
			{
				buttonItem_EditPrice.Enabled = false;
			}
			if (!returned)
			{
				returned = db.StockCheckInvOffer(DataThis.Itm_No);
			}
			try
			{
				textBox_ID.Tag = value.Itm_ID;
				for (int iiCnt = 0; iiCnt < combobox_ItmeGroup.Items.Count; iiCnt++)
				{
					if (!value.ItmCat.HasValue)
					{
						break;
					}
					combobox_ItmeGroup.SelectedIndex = iiCnt;
					if (combobox_ItmeGroup.SelectedValue.ToString() == value.ItmCat.ToString())
					{
						break;
					}
				}
				try
				{
					doubleInput_DefPack.Text = value.SecriptCeramic;
				}
				catch
				{
					doubleInput_DefPack.Text = "";
				}
				try
				{
					comboBox_DefPack.SelectedIndex = int.Parse(value.SecriptCeramicCombo);
				}
				catch
				{
					comboBox_DefPack.SelectedIndex = 0;
				}
				textbox_Arb_Des.Text = value.Arb_Des;
				textbox_Eng_Des.Text = value.Eng_Des;
				textBox_SerialKey.Text = value.SerialKey;
				textBox_CommItm.Value = value.ItemComm.Value;
				textBox_DisItem.Value = value.ItemDis.Value;
				textBox_TaxSales.Value = value.TaxSales.Value;
				textBox_TaxPurchase.Value = value.TaxPurchas.Value;
				if (value.DefultVendor.HasValue)
				{
					if (LangArEn == 0)
					{
						txtCustNo.Text = value.DefultVendor.ToString();
						txtCustName.Text = db.StockAccDefWithOutBalance(value.DefultVendor.Value.ToString()).Arb_Des;
					}
					else
					{
						txtCustNo.Text = value.DefultVendor.ToString();
						txtCustName.Text = db.StockAccDefWithOutBalance(value.DefultVendor.Value.ToString()).Eng_Des;
					}
				}
				else
				{
					txtCustNo.Text = "";
					txtCustName.Text = "";
				}
				c1FlexGrid_Items.SetData(1, 0, value.OpenQty.Value);
				c1FlexGrid_Items.SetData(1, 1, value.AvrageCost.Value);
				c1FlexGrid_Items.SetData(1, 2, value.LastCost.Value);
				c1FlexGrid_Items.SetData(1, 3, value.StartCost.Value);
				c1FlexGrid_Items.SetData(1, 4, value.FirstCost.Value);
				c1FlexGrid_Items.SetData(1, 5, value.ItmLoc);
				int? lot = value.Lot;
				if (lot.GetValueOrDefault() == 0 && lot.HasValue)
				{
					c1FlexGrid_Items.SetData(1, 6, false);
				}
				else
				{
					c1FlexGrid_Items.SetData(1, 6, true);
					textbox_DateNo.Value = value.DMY.Value;
					combobox_DateTyp.SelectedIndex = value.LrnExp.Value;
				}
				if (value.ItmTyp.HasValue)
				{
					lot = value.ItmTyp;
					if (lot.GetValueOrDefault() == 0 && lot.HasValue)
					{
						radioButton_Goods.Checked = true;
					}
					else if (value.ItmTyp == 1)
					{
						radioButton_RawMaterial.Checked = true;
					}
					else if (value.ItmTyp == 2)
					{
						radioButton_Product.Checked = true;
					}
					else
					{
						radioButton_Service.Checked = true;
					}
				}
				textbox_MaxQty.Value = value.QtyMax.Value;
				textbox_Supreme.Value = value.QtyLvl.Value;
				try
				{
					if (value.Unit1.HasValue)
					{
						for (int iiCnt = 0; iiCnt < combobox_Unit1.Items.Count; iiCnt++)
						{
							combobox_Unit1.SelectedIndex = iiCnt;
							if (combobox_Unit1.SelectedValue != null && combobox_Unit1.SelectedValue.ToString() == value.Unit1.ToString())
							{
								comboboxItems_Unit1.SelectedIndex = combobox_Unit1.SelectedIndex;
								break;
							}
							if (combobox_Unit1.SelectedIndex == iiCnt)
							{
								combobox_Unit1.SelectedIndex = 0;
							}
						}
						if (returned)
						{
							comboboxItems_Unit1.Enabled = false;
							textbox_SelPri1.Enabled = false;
							textbox_Pack1.Enabled = false;
						}
						else
						{
							comboboxItems_Unit1.Enabled = true;
							textbox_SelPri1.Enabled = true;
							textbox_Pack1.Enabled = true;
						}
					}
					else
					{
						combobox_Unit1.SelectedIndex = -1;
						comboboxItems_Unit1.SelectedIndex = -1;
						comboboxItems_Unit1.Enabled = true;
						textbox_SelPri1.Enabled = true;
						textbox_Pack1.Enabled = true;
					}
				}
				catch
				{
					combobox_Unit1.SelectedIndex = -1;
					comboboxItems_Unit1.SelectedIndex = -1;
				}
				textbox_SelPri1.Text = value.UntPri1.Value.ToString();
				textbox_Pack1.Text = value.Pack1.Value.ToString();
				try
				{
					if (value.Unit2.HasValue)
					{
						for (int iiCnt = 0; iiCnt < combobox_Unit2.Items.Count; iiCnt++)
						{
							combobox_Unit2.SelectedIndex = iiCnt;
							if (combobox_Unit2.SelectedValue != null && combobox_Unit2.SelectedValue.ToString() == value.Unit2.ToString())
							{
								comboboxItems_Unit2.SelectedIndex = combobox_Unit2.SelectedIndex;
								break;
							}
							if (combobox_Unit2.SelectedIndex == iiCnt)
							{
								combobox_Unit2.SelectedIndex = 0;
							}
						}
						if (returned)
						{
							comboboxItems_Unit2.Enabled = false;
							textbox_SelPri2.Enabled = false;
							textbox_Pack2.Enabled = false;
						}
						else
						{
							comboboxItems_Unit2.Enabled = true;
							textbox_SelPri2.Enabled = true;
							textbox_Pack2.Enabled = true;
						}
					}
					else
					{
						combobox_Unit2.SelectedIndex = -1;
						comboboxItems_Unit2.SelectedIndex = -1;
						comboboxItems_Unit2.Enabled = true;
						textbox_SelPri2.Enabled = true;
						textbox_Pack2.Enabled = true;
					}
				}
				catch
				{
					combobox_Unit2.SelectedIndex = -1;
					comboboxItems_Unit2.SelectedIndex = -1;
				}
				textbox_SelPri2.Text = value.UntPri2.Value.ToString();
				textbox_Pack2.Text = value.Pack2.Value.ToString();
				try
				{
					if (value.Unit3.HasValue)
					{
						for (int iiCnt = 0; iiCnt < combobox_Unit3.Items.Count; iiCnt++)
						{
							combobox_Unit3.SelectedIndex = iiCnt;
							if (combobox_Unit3.SelectedValue != null && combobox_Unit3.SelectedValue.ToString() == value.Unit3.ToString())
							{
								comboboxItems_Unit3.SelectedIndex = combobox_Unit3.SelectedIndex;
								break;
							}
							if (combobox_Unit3.SelectedIndex == iiCnt)
							{
								combobox_Unit3.SelectedIndex = 0;
							}
						}
						if (returned)
						{
							comboboxItems_Unit3.Enabled = false;
							textbox_SelPri3.Enabled = false;
							textbox_Pack3.Enabled = false;
						}
						else
						{
							comboboxItems_Unit3.Enabled = true;
							textbox_SelPri3.Enabled = true;
							textbox_Pack3.Enabled = true;
						}
					}
					else
					{
						combobox_Unit3.SelectedIndex = -1;
						comboboxItems_Unit3.SelectedIndex = -1;
						comboboxItems_Unit3.Enabled = true;
						textbox_SelPri3.Enabled = true;
						textbox_Pack3.Enabled = true;
					}
				}
				catch
				{
					combobox_Unit3.SelectedIndex = -1;
					comboboxItems_Unit3.SelectedIndex = -1;
				}
				textbox_SelPri3.Text = value.UntPri3.Value.ToString();
				textbox_Pack3.Text = value.Pack3.Value.ToString();
				try
				{
					if (value.Unit4.HasValue)
					{
						for (int iiCnt = 0; iiCnt < combobox_Unit4.Items.Count; iiCnt++)
						{
							combobox_Unit4.SelectedIndex = iiCnt;
							if (combobox_Unit4.SelectedValue != null && combobox_Unit4.SelectedValue.ToString() == value.Unit4.ToString())
							{
								comboboxItems_Unit4.SelectedIndex = combobox_Unit4.SelectedIndex;
								break;
							}
							if (combobox_Unit4.SelectedIndex == iiCnt)
							{
								combobox_Unit4.SelectedIndex = 0;
							}
						}
						if (returned)
						{
							comboboxItems_Unit4.Enabled = false;
							textbox_SelPri4.Enabled = false;
							textbox_Pack4.Enabled = false;
						}
						else
						{
							comboboxItems_Unit4.Enabled = true;
							textbox_SelPri4.Enabled = true;
							textbox_Pack4.Enabled = true;
						}
					}
					else
					{
						combobox_Unit4.SelectedIndex = -1;
						comboboxItems_Unit4.SelectedIndex = -1;
						comboboxItems_Unit4.Enabled = true;
						textbox_SelPri4.Enabled = true;
						textbox_Pack4.Enabled = true;
					}
				}
				catch
				{
					combobox_Unit4.SelectedIndex = -1;
					comboboxItems_Unit4.SelectedIndex = -1;
				}
				textbox_SelPri4.Text = value.UntPri4.Value.ToString();
				textbox_Pack4.Text = value.Pack4.Value.ToString();
				try
				{
					if (value.Unit5.HasValue)
					{
						for (int iiCnt = 0; iiCnt < combobox_Unit5.Items.Count; iiCnt++)
						{
							combobox_Unit5.SelectedIndex = iiCnt;
							if (combobox_Unit5.SelectedValue != null && combobox_Unit5.SelectedValue.ToString() == value.Unit5.ToString())
							{
								comboboxItems_Unit5.SelectedIndex = combobox_Unit5.SelectedIndex;
								break;
							}
							if (combobox_Unit5.SelectedIndex == iiCnt)
							{
								combobox_Unit5.SelectedIndex = 0;
							}
						}
						if (returned)
						{
							comboboxItems_Unit5.Enabled = false;
							textbox_SelPri5.Enabled = false;
							textbox_Pack5.Enabled = false;
						}
						else
						{
							comboboxItems_Unit5.Enabled = true;
							textbox_SelPri5.Enabled = true;
							textbox_Pack5.Enabled = true;
						}
					}
					else
					{
						combobox_Unit5.SelectedIndex = -1;
						comboboxItems_Unit5.SelectedIndex = -1;
						comboboxItems_Unit5.Enabled = true;
						textbox_SelPri5.Enabled = true;
						textbox_Pack5.Enabled = true;
					}
				}
				catch
				{
					combobox_Unit5.SelectedIndex = -1;
					comboboxItems_Unit5.SelectedIndex = -1;
				}
				textbox_SelPri5.Text = value.UntPri5.Value.ToString();
				textbox_Pack5.Text = value.Pack5.Value.ToString();
				if (value.DefultUnit == 1)
				{
					radiobutton_RButDef1.Checked = true;
				}
				else if (value.DefultUnit == 2)
				{
					radiobutton_RButDef2.Checked = true;
				}
				else if (value.DefultUnit == 3)
				{
					radiobutton_RButDef3.Checked = true;
				}
				else if (value.DefultUnit == 4)
				{
					radiobutton_RButDef4.Checked = true;
				}
				else if (value.DefultUnit == 5)
				{
					radiobutton_RButDef5.Checked = true;
				}
				if (double.Parse(textbox_Pack1.Text) != 0.0)
				{
					try
					{
						textbox_Cost1.Text = Math.Round(double.Parse(string.Concat(c1FlexGrid_Items.GetData(1, 1))) * double.Parse(textbox_Pack1.Text ?? ""), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? 3 : 2).ToString();
					}
					catch
					{
						textbox_Cost1.Text = "0";
					}
					try
					{
						textbox_Qty1.Text = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(c1FlexGrid_Items.GetData(1, 0)))) / double.Parse(VarGeneral.TString.TEmpty(textbox_Pack1.Text)), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? 3 : 2).ToString();
					}
					catch
					{
						textbox_Qty1.Text = "0";
					}
				}
				if (double.Parse(textbox_Pack2.Text) != 0.0)
				{
					try
					{
						textbox_Cost2.Text = Math.Round(double.Parse(string.Concat(c1FlexGrid_Items.GetData(1, 1))) * double.Parse(textbox_Pack2.Text), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? 3 : 2).ToString();
					}
					catch
					{
						textbox_Cost2.Text = "0";
					}
					try
					{
						textbox_Qty2.Text = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(c1FlexGrid_Items.GetData(1, 0)))) / double.Parse(VarGeneral.TString.TEmpty(textbox_Pack2.Text)), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? 3 : 2).ToString();
					}
					catch
					{
						textbox_Qty2.Text = "0";
					}
				}
				if (double.Parse(textbox_Pack3.Text) != 0.0)
				{
					try
					{
						textbox_Cost3.Text = Math.Round(double.Parse(string.Concat(c1FlexGrid_Items.GetData(1, 1))) * double.Parse(textbox_Pack3.Text), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? 3 : 2).ToString();
					}
					catch
					{
						textbox_Cost3.Text = "0";
					}
					try
					{
						textbox_Qty3.Text = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(c1FlexGrid_Items.GetData(1, 0)))) / double.Parse(VarGeneral.TString.TEmpty(textbox_Pack3.Text)), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? 3 : 2).ToString();
					}
					catch
					{
						textbox_Qty3.Text = "0";
					}
				}
				if (double.Parse(textbox_Pack4.Text) != 0.0)
				{
					try
					{
						textbox_Cost4.Text = Math.Round(double.Parse(string.Concat(c1FlexGrid_Items.GetData(1, 1))) * double.Parse(textbox_Pack4.Text), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? 3 : 2).ToString();
					}
					catch
					{
						textbox_Cost4.Text = "0";
					}
					try
					{
						textbox_Qty4.Text = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(c1FlexGrid_Items.GetData(1, 0)))) / double.Parse(VarGeneral.TString.TEmpty(textbox_Pack4.Text)), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? 3 : 2).ToString();
					}
					catch
					{
						textbox_Qty4.Text = "0";
					}
				}
				if (double.Parse(textbox_Pack5.Text) != 0.0)
				{
					try
					{
						textbox_Cost5.Text = Math.Round(double.Parse(string.Concat(c1FlexGrid_Items.GetData(1, 1))) * double.Parse(textbox_Pack5.Text), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? 3 : 2).ToString();
					}
					catch
					{
						textbox_Cost5.Text = "0";
					}
					try
					{
						textbox_Qty5.Text = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(c1FlexGrid_Items.GetData(1, 0)))) / double.Parse(VarGeneral.TString.TEmpty(textbox_Pack5.Text)), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? 3 : 2).ToString();
					}
					catch
					{
						textbox_Qty5.Text = "0";
					}
				}
				txtBarCode1.Text = value.BarCod1;
				txtBarCode2.Text = value.BarCod2;
				txtBarCode3.Text = value.BarCod3;
				txtBarCode4.Text = value.BarCod4;
				txtBarCode5.Text = value.BarCod5;
				textbox_Sentence.Value = data_this.Price1.Value;
				textbox_Distributors.Value = data_this.Price2.Value;
				textbox_Legates.Value = data_this.Price3.Value;
				textbox_Sectorial.Value = data_this.Price4.Value;
				textbox_VIP.Value = data_this.Price5.Value;
				if (value.IsBalance.HasValue)
				{
					if (value.IsBalance.Value)
					{
						checkBoxX_BarcodeBalance.Checked = true;
					}
					else
					{
						checkBoxX_BarcodeBalance.Checked = false;
					}
				}
				else
				{
					checkBoxX_BarcodeBalance.Checked = false;
				}
				if (value.IsPoints.HasValue)
				{
					checkBoxX_Points.Checked = value.IsPoints.Value;
				}
				else
				{
					checkBoxX_Points.Checked = false;
				}
				if (value.InvSaleStoped.HasValue)
				{
					if (value.InvSaleStoped.Value)
					{
						checkBoxX_InvSale.Checked = true;
					}
					else
					{
						checkBoxX_InvSale.Checked = false;
					}
				}
				else
				{
					checkBoxX_InvSale.Checked = false;
				}
				if (value.InvSaleReturnStoped.HasValue)
				{
					if (value.InvSaleReturnStoped.Value)
					{
						checkBoxX_ReturnInvSale.Checked = true;
					}
					else
					{
						checkBoxX_ReturnInvSale.Checked = false;
					}
				}
				else
				{
					checkBoxX_ReturnInvSale.Checked = false;
				}
				if (value.InvPaymentStoped.HasValue)
				{
					if (value.InvPaymentStoped.Value)
					{
						checkBoxX_InvPayment.Checked = true;
					}
					else
					{
						checkBoxX_InvPayment.Checked = false;
					}
				}
				else
				{
					checkBoxX_InvPayment.Checked = false;
				}
				if (value.InvPaymentReturnStoped.HasValue)
				{
					if (value.InvPaymentReturnStoped.Value)
					{
						checkBoxX_InvPaymentReturn.Checked = true;
					}
					else
					{
						checkBoxX_InvPaymentReturn.Checked = false;
					}
				}
				else
				{
					checkBoxX_InvPaymentReturn.Checked = false;
				}
				if (value.InvEnterStoped.HasValue)
				{
					if (value.InvEnterStoped.Value)
					{
						checkBoxX_InvEnter.Checked = true;
					}
					else
					{
						checkBoxX_InvEnter.Checked = false;
					}
				}
				else
				{
					checkBoxX_InvEnter.Checked = false;
				}
				if (value.InvOutStoped.HasValue)
				{
					if (value.InvOutStoped.Value)
					{
						checkBoxX_InvOut.Checked = true;
					}
					else
					{
						checkBoxX_InvOut.Checked = false;
					}
				}
				else
				{
					checkBoxX_InvOut.Checked = false;
				}
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
				try
				{
					txtFiled1.Text = value.vSize1;
					txtFiled2.Text = value.vSize2;
					txtFiled3.Text = value.vSize3;
					txtFiled4.Text = value.vSize4;
					txtFiled5.Text = value.vSize5;
					txtFiled6.Text = value.vSize6;
				}
				catch
				{
				}
				IDatabase Accdb = Database.GetDatabase(VarGeneral.BranchCS);
				SetReadOnly = true;
				try
				{
					if (value.ItmTyp == 2)
					{
						using (new Stock_DataDataContext(VarGeneral.BranchCS))
						{
							LData_This = db.T_ItemDets.Where((T_ItemDet t) => t.ItmNo == value.Itm_No).ToList();
							SetLines(LDataThis);
						}
					}
				}
				catch
				{
				}
				try
				{
					if (returned)
					{
						textbox_Legates.IsInputReadOnly = true;
						textbox_Distributors.IsInputReadOnly = true;
						textbox_Sentence.IsInputReadOnly = true;
						textbox_Sectorial.IsInputReadOnly = true;
						textbox_VIP.IsInputReadOnly = true;
						metroStatusBar_itemsType.Enabled = false;
						List<T_INVDET> Quary = (from er in db.T_INVDETs
							where er.ItmNo == data_this.Itm_No
							where er.T_INVHED.IfDel == (int?)0
							select er).ToList();
						List<T_ItemDet> Quary2 = db.T_ItemDets.Where((T_ItemDet er) => er.GItmNo == data_this.Itm_No).ToList();
						if (Quary.Count <= 0 && Quary2.Count <= 0 && VarGeneral.UserID == 1)
						{
							button_DeleteFromSystem.Visible = true;
						}
					}
					else
					{
						textbox_Legates.IsInputReadOnly = false;
						textbox_Distributors.IsInputReadOnly = false;
						textbox_Sentence.IsInputReadOnly = false;
						textbox_Sectorial.IsInputReadOnly = false;
						textbox_VIP.IsInputReadOnly = false;
						metroStatusBar_itemsType.Enabled = true;
						List<T_INVDET> Quary = (from er in db.T_INVDETs
							where er.ItmNo == data_this.Itm_No
							where er.T_INVHED.IfDel == (int?)0
							select er).ToList();
						List<T_ItemDet> Quary2 = db.T_ItemDets.Where((T_ItemDet er) => er.GItmNo == data_this.Itm_No).ToList();
						if (Quary.Count() <= 0 && Quary2.Count <= 0 && VarGeneral.UserID == 1)
						{
							button_DeleteFromSystem.Visible = true;
						}
					}
				}
				catch
				{
					textbox_Legates.IsInputReadOnly = true;
					textbox_Distributors.IsInputReadOnly = true;
					textbox_Sentence.IsInputReadOnly = true;
					textbox_Sectorial.IsInputReadOnly = true;
					textbox_VIP.IsInputReadOnly = true;
					metroStatusBar_itemsType.Enabled = false;
				}
			}
			catch (Exception error)
			{
				VarGeneral.DebLog.writeLog("SetData:", error, enable: true);
				MessageBox.Show(error.Message);
			}
			txtBarCode1.GotFocus += txtBarCode1_GotFocus;
		}
		public void SetLines(List<T_ItemDet> listDet)
		{
			try
			{
				FlxInv.Rows.Count = listDet.Count + 1;
				FlxInv.Cols[27].Visible = false;
				for (int iiCnt = 1; iiCnt <= listDet.Count; iiCnt++)
				{
					T_ItemDet _ItemsDet = listDet[iiCnt - 1];
					_Items = db.StockItem(_ItemsDet.GItmNo);
					FillItemDet(_Items, Barcod: false, iiCnt, _ItemsDet.Unit_.Value, _ItemsDet.StoreNo.Value, Math.Abs(_ItemsDet.Qty.Value), _ItemsDet.Price.Value);
				}
				GetInvTot();
			}
			catch
			{
				MessageBox.Show((LangArEn == 0) ? "حدث خطأ أثناء تعبئة الأسطر .." : "An error occurred while filling lines ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		private void TextBox_Index_InputTextChanged(object sender)
		{
			int index = 0;
			try
			{
				index = Convert.ToInt32(TextBox_Index.TextBox.Text);
			}
			catch
			{
			}
			if (index <= PKeys.Count && index > 0)
			{
				textBox_ID.Text = PKeys[index - 1];
			}
		}
		private T_Item GetData()
		{
			textBox_ID.Focus();
			try
			{
				data_this.Itm_No = textBox_ID.Text.Trim();
				data_this.ItmCat = int.Parse(combobox_ItmeGroup.SelectedValue.ToString());
				try
				{
					data_this.SecriptCeramic = doubleInput_DefPack.Text;
				}
				catch
				{
					data_this.SecriptCeramic = "";
				}
				try
				{
					data_this.SecriptCeramicCombo = comboBox_DefPack.SelectedIndex.ToString();
				}
				catch
				{
					data_this.SecriptCeramicCombo = "0";
				}
				data_this.Arb_Des = textbox_Arb_Des.Text;
				data_this.Eng_Des = textbox_Eng_Des.Text;
				data_this.SerialKey = textBox_SerialKey.Text;
				data_this.ItemComm = textBox_CommItm.Value;
				data_this.ItemDis = textBox_DisItem.Value;
				data_this.TaxSales = textBox_TaxSales.Value;
				data_this.TaxPurchas = textBox_TaxPurchase.Value;
				try
				{
					if (!string.IsNullOrEmpty(txtCustNo.Text))
					{
						data_this.DefultVendor = int.Parse(txtCustNo.Text);
					}
					else
					{
						data_this.DefultVendor = null;
					}
				}
				catch
				{
					data_this.DefultVendor = null;
				}
				if (double.TryParse(c1FlexGrid_Items.GetData(1, 4).ToString(), out var value))
				{
					data_this.FirstCost = value;
				}
				else
				{
					data_this.FirstCost = 0.0;
				}
				if (double.TryParse(c1FlexGrid_Items.GetData(1, 3).ToString(), out value))
				{
					data_this.StartCost = value;
				}
				else
				{
					data_this.StartCost = 0.0;
				}
				if (double.TryParse(c1FlexGrid_Items.GetData(1, 1).ToString(), out value))
				{
					data_this.AvrageCost = value;
				}
				else
				{
					data_this.AvrageCost = 0.0;
				}
				if (double.TryParse(c1FlexGrid_Items.GetData(1, 2).ToString(), out value))
				{
					data_this.LastCost = value;
				}
				else
				{
					data_this.LastCost = 0.0;
				}
				if (double.TryParse(c1FlexGrid_Items.GetData(1, 0).ToString(), out value))
				{
					data_this.OpenQty = value;
				}
				else
				{
					data_this.OpenQty = 0.0;
				}
				data_this.ItmLoc = string.Concat(c1FlexGrid_Items.GetData(1, 5));
				if (radioButton_Goods.Checked)
				{
					data_this.ItmTyp = 0;
				}
				else if (radioButton_RawMaterial.Checked)
				{
					data_this.ItmTyp = 1;
				}
				else if (radioButton_Product.Checked)
				{
					data_this.ItmTyp = 2;
				}
				else
				{
					data_this.ItmTyp = 3;
				}
				data_this.QtyMax = textbox_MaxQty.Value;
				if (data_this.ItmTyp == 2)
				{
					data_this.QtyLvl = 0.0;
				}
				else
				{
					data_this.QtyLvl = textbox_Supreme.Value;
				}
				if ((bool)c1FlexGrid_Items.GetData(1, 6))
				{
					data_this.Lot = 1;
				}
				else
				{
					data_this.Lot = 0;
				}
				data_this.DMY = textbox_DateNo.Value;
				if (combobox_DateTyp.Enabled)
				{
					data_this.LrnExp = combobox_DateTyp.SelectedIndex;
				}
				else
				{
					data_this.LrnExp = 0;
				}
				try
				{
					if (combobox_Unit1.SelectedValue != null && combobox_Unit1.SelectedValue.ToString() != "0")
					{
						data_this.Unit1 = int.Parse(combobox_Unit1.SelectedValue.ToString());
					}
					else
					{
						data_this.Unit1 = null;
					}
				}
				catch
				{
					data_this.Unit1 = null;
				}
				if (double.TryParse(textbox_SelPri1.Text, out value))
				{
					data_this.UntPri1 = value;
				}
				else
				{
					data_this.UntPri1 = 0.0;
				}
				data_this.Pack1 = 1.0;
				try
				{
					if (combobox_Unit2.SelectedValue != null && combobox_Unit2.SelectedValue.ToString() != "0" && sideBarPanelItem_Unit2.Visible)
					{
						data_this.Unit2 = int.Parse(combobox_Unit2.SelectedValue.ToString());
						if (double.TryParse(textbox_SelPri2.Text, out value))
						{
							data_this.UntPri2 = value;
						}
						else
						{
							data_this.UntPri2 = 0.0;
						}
						if (double.TryParse(textbox_Pack2.Text, out value))
						{
							data_this.Pack2 = value;
						}
						else
						{
							data_this.Pack2 = 0.0;
						}
					}
					else
					{
						data_this.Unit2 = null;
						data_this.UntPri2 = 0.0;
						data_this.Pack2 = 0.0;
					}
				}
				catch
				{
					data_this.Unit2 = null;
					data_this.UntPri2 = 0.0;
					data_this.Pack2 = 0.0;
				}
				try
				{
					if (combobox_Unit3.SelectedValue != null && combobox_Unit3.SelectedValue.ToString() != "0" && sideBarPanelItem_Unit3.Visible)
					{
						data_this.Unit3 = int.Parse(combobox_Unit3.SelectedValue.ToString());
						if (double.TryParse(textbox_SelPri3.Text, out value))
						{
							data_this.UntPri3 = value;
						}
						else
						{
							data_this.UntPri3 = 0.0;
						}
						if (double.TryParse(textbox_Pack3.Text, out value))
						{
							data_this.Pack3 = value;
						}
						else
						{
							data_this.Pack3 = 0.0;
						}
					}
					else
					{
						data_this.Unit3 = null;
						data_this.UntPri3 = 0.0;
						data_this.Pack3 = 0.0;
					}
				}
				catch
				{
					data_this.Unit3 = null;
					data_this.UntPri3 = 0.0;
					data_this.Pack3 = 0.0;
				}
				try
				{
					if (combobox_Unit4.SelectedValue != null && combobox_Unit4.SelectedValue.ToString() != "0" && sideBarPanelItem_Unit4.Visible)
					{
						data_this.Unit4 = int.Parse(combobox_Unit4.SelectedValue.ToString());
						if (double.TryParse(textbox_SelPri4.Text, out value))
						{
							data_this.UntPri4 = value;
						}
						else
						{
							data_this.UntPri4 = 0.0;
						}
						if (double.TryParse(textbox_Pack4.Text, out value))
						{
							data_this.Pack4 = value;
						}
						else
						{
							data_this.Pack4 = 0.0;
						}
					}
					else
					{
						data_this.Unit4 = null;
						data_this.UntPri4 = 0.0;
						data_this.Pack4 = 0.0;
					}
				}
				catch
				{
					data_this.Unit4 = null;
					data_this.UntPri4 = 0.0;
					data_this.Pack4 = 0.0;
				}
				try
				{
					if (combobox_Unit5.SelectedValue != null && combobox_Unit5.SelectedValue.ToString() != "0" && sideBarPanelItem_Unit5.Visible)
					{
						data_this.Unit5 = int.Parse(combobox_Unit5.SelectedValue.ToString());
						if (double.TryParse(textbox_SelPri5.Text, out value))
						{
							data_this.UntPri5 = value;
						}
						else
						{
							data_this.UntPri5 = 0.0;
						}
						if (double.TryParse(textbox_Pack5.Text, out value))
						{
							data_this.Pack5 = value;
						}
						else
						{
							data_this.Pack5 = 0.0;
						}
					}
					else
					{
						data_this.Unit5 = null;
						data_this.UntPri5 = 0.0;
						data_this.Pack5 = 0.0;
					}
				}
				catch
				{
					data_this.Unit5 = null;
					data_this.UntPri5 = 0.0;
					data_this.Pack5 = 0.0;
				}
				if (radiobutton_RButDef1.Checked)
				{
					data_this.DefultUnit = 1;
					if (double.TryParse(textbox_Pack1.Text, out value))
					{
						data_this.DefPack = value;
					}
					else
					{
						data_this.DefPack = 0.0;
					}
				}
				else if (radiobutton_RButDef2.Checked)
				{
					data_this.DefultUnit = 2;
					if (double.TryParse(textbox_Pack2.Text, out value))
					{
						data_this.DefPack = value;
					}
					else
					{
						data_this.DefPack = 0.0;
					}
				}
				else if (radiobutton_RButDef3.Checked)
				{
					data_this.DefultUnit = 3;
					if (double.TryParse(textbox_Pack3.Text, out value))
					{
						data_this.DefPack = value;
					}
					else
					{
						data_this.DefPack = 0.0;
					}
				}
				else if (radiobutton_RButDef4.Checked)
				{
					data_this.DefultUnit = 4;
					if (double.TryParse(textbox_Pack4.Text, out value))
					{
						data_this.DefPack = value;
					}
					else
					{
						data_this.DefPack = 0.0;
					}
				}
				else if (radiobutton_RButDef5.Checked)
				{
					data_this.DefultUnit = 5;
					if (double.TryParse(textbox_Pack5.Text, out value))
					{
						data_this.DefPack = value;
					}
					else
					{
						data_this.DefPack = 0.0;
					}
				}
				data_this.Price1 = textbox_Sentence.Value;
				data_this.Price2 = textbox_Distributors.Value;
				data_this.Price3 = textbox_Legates.Value;
				data_this.Price4 = textbox_Sectorial.Value;
				data_this.Price5 = textbox_VIP.Value;
				data_this.BarCod1 = txtBarCode1.Text ?? "";
				data_this.BarCod2 = txtBarCode2.Text ?? "";
				data_this.BarCod3 = txtBarCode3.Text ?? "";
				data_this.BarCod4 = txtBarCode4.Text ?? "";
				data_this.BarCod5 = txtBarCode5.Text ?? "";
				data_this.IsBalance = checkBoxX_BarcodeBalance.Checked;
				data_this.IsPoints = checkBoxX_Points.Checked;
				data_this.InvSaleStoped = checkBoxX_InvSale.Checked;
				data_this.InvSaleReturnStoped = checkBoxX_ReturnInvSale.Checked;
				data_this.InvPaymentStoped = checkBoxX_InvPayment.Checked;
				data_this.InvPaymentReturnStoped = checkBoxX_InvPaymentReturn.Checked;
				data_this.InvEnterStoped = checkBoxX_InvEnter.Checked;
				data_this.InvOutStoped = checkBoxX_InvOut.Checked;
				data_this.CompanyID = 1;
				if (pictureBox_PicItem.Image != null)
				{
					MemoryStream stream = new MemoryStream();
					pictureBox_PicItem.Image.Save(stream, ImageFormat.Jpeg);
					byte[] arr = stream.GetBuffer();
					data_this.ItmImg = arr;
				}
				else
				{
					data_this.ItmImg = null;
				}
				if (File.Exists(Application.StartupPath + "\\\\Script\\\\SecriptInvitationCards.dll") && VarGeneral.UserID != 1)
				{
					data_this.BarCod1 = textBox_ID.Text;
				}
				try
				{
					data_this.vSize1 = txtFiled1.Text;
					data_this.vSize2 = txtFiled2.Text;
					data_this.vSize3 = txtFiled3.Text;
					data_this.vSize4 = txtFiled4.Text;
					data_this.vSize5 = txtFiled5.Text;
					data_this.vSize6 = txtFiled6.Text;
				}
				catch
				{
					data_this.vSize1 = "";
					data_this.vSize2 = "";
					data_this.vSize3 = "";
					data_this.vSize4 = "";
					data_this.vSize5 = "";
					data_this.vSize6 = "";
				}
				return data_this;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			return data_this;
		}
		private void Button_Edit_Click(object sender, EventArgs e)
		{
			if (CanEdit && State != FormState.Edit && State != FormState.New && !string.IsNullOrEmpty(textBox_ID.Text))
			{
				if (State != FormState.New)
				{
					State = FormState.Edit;
				}
				FlxInv.Rows.Count = FlxInv.Rows.Count + 100;
				SetReadOnly = false;
			}
		}
		private void Button_Add_Click(object sender, EventArgs e)
		{
			if (!Button_Add.Visible || !Button_Add.Enabled)
			{
				MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				if (State == FormState.Edit && MessageBox.Show((LangArEn == 0) ? "تم تعديل السجل الحالي دون حفظ التغييرات .. هل تريد المتابعة؟" : "Not saved the changes, do you really want to continue?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
				{
					return;
				}
				Clear();
				if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 0))
				{
					T_Item itemSer = new T_Item();
					double itemNo = 0.0;
					string _symbol = "";
					try
					{
						_symbol = db.StockCatID(int.Parse(combobox_ItmeGroup.SelectedValue.ToString())).CAT_Symbol.Trim();
					}
					catch
					{
						_symbol = "";
					}
					if (pkeys.Count == 0)
					{
						if (_symbol == "")
						{
							textBox_ID.Text = VarGeneral.Settings_Sys.AutoItm.ToString();
						}
						else
						{
							textBox_ID.Text = _symbol + VarGeneral.Settings_Sys.AutoItm;
						}
					}
					else if (_symbol == "")
					{
						for (int i = 0; i < pkeys.Count; i++)
						{
							itemSer.Itm_No = PKeys[i];
							if (Program.sIsNumeric(itemSer.Itm_No) && double.Parse(itemSer.Itm_No) > itemNo)
							{
								itemNo = double.Parse(itemSer.Itm_No);
							}
						}
						textBox_ID.Text = (itemNo + 1.0).ToString();
					}
					else
					{
						List<string> newPkeys = pkeys.Where((string g) => g.StartsWith(_symbol)).ToList();
						if (newPkeys.Count == 0)
						{
							textBox_ID.Text = _symbol + VarGeneral.Settings_Sys.AutoItm;
						}
						else
						{
							for (int i = 0; i < newPkeys.Count; i++)
							{
								itemSer.Itm_No = newPkeys[i].Replace(_symbol, "").Trim();
								if (Program.sIsNumeric(itemSer.Itm_No) && double.Parse(itemSer.Itm_No) > itemNo)
								{
									itemNo = double.Parse(itemSer.Itm_No);
								}
							}
							textBox_ID.Text = _symbol + (itemNo + 1.0);
						}
					}
					combobox_ItmeGroup.Focus();
				}
				else
				{
					textBox_ID.Focus();
				}
				FlxInv.Rows.Count = 100;
				try
				{
					if (comboboxItems_Unit1.Items.Count > 0)
					{
						comboboxItems_Unit1.SelectedIndex = 1;
					}
				}
				catch
				{
					comboboxItems_Unit1.SelectedIndex = 0;
				}
				State = FormState.New;
				if (File.Exists(Application.StartupPath + "\\\\Script\\\\SecriptMaintenanceCars.dll") || File.Exists(Application.StartupPath + "\\\\Script\\\\SecriptTegnicalCollage.dll"))
				{
					MaintenanceCarsAdd();
				}
			}
		}
		private void MaintenanceCarsAdd()
		{
			if (!File.Exists(Application.StartupPath + "\\\\Script\\\\SecriptTegnicalCollage.dll"))
			{
				comboboxItems_Unit1.SelectedIndex = 1;
				comboboxItems_Unit2.SelectedIndex = 2;
				comboboxItems_Unit3.SelectedIndex = 3;
				comboboxItems_Unit4.SelectedIndex = 4;
				comboboxItems_Unit5.SelectedIndex = 5;
				textbox_Pack2.Text = "1";
				textbox_Pack3.Text = "1";
				textbox_Pack4.Text = "1";
				textbox_Pack5.Text = "1";
				radioButton_Service.Checked = true;
			}
			textbox_SelPri1.Text = "1";
			textbox_SelPri2.Text = "1";
			textbox_SelPri3.Text = "1";
			textbox_SelPri4.Text = "1";
			textbox_SelPri5.Text = "1";
		}
		private bool ValidData()
		{
			if (!Button_Save.Enabled)
			{
				return false;
			}
			if (State == FormState.Edit && !CanEdit)
			{
				MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return false;
			}
			if (State == FormState.New && !Button_Add.Enabled)
			{
				MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return false;
			}
			if (textBox_ID.Text == "" || textbox_Arb_Des.Text == "" || textbox_Eng_Des.Text == "")
			{
				MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون الرمز او الإسم فارغا\u0651" : "Can not be a number or name is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return false;
			}
			try
			{
				if (!string.IsNullOrEmpty(c1FlexGrid_Items.GetData(1, 5).ToString()) && c1FlexGrid_Items.GetData(1, 5).ToString().Length > 40)
				{
					MessageBox.Show((LangArEn == 0) ? "يجب ان يكون عدد حروف بيانات الرف لا يتجاوز 40 حرف" : "The number of site characters must not exceed 40 characters", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return false;
				}
			}
			catch
			{
			}
			try
			{
				if (combobox_ItmeGroup.SelectedIndex == -1)
				{
					MessageBox.Show((LangArEn == 0) ? "يجب تحديد التصنيف" : "You must select Category", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return false;
				}
			}
			catch
			{
				MessageBox.Show((LangArEn == 0) ? "يجب تحديد التصنيف" : "You must select Category", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return false;
			}
			if (radioButton_Product.Checked)
			{
				if (FlxInv.Rows.Count > 0)
				{
					for (int iiCnt = 1; iiCnt <= FlxInv.Rows.Count; iiCnt++)
					{
						if (string.Concat(FlxInv.GetData(iiCnt, 1)) != "")
						{
							goto IL_02b8;
						}
					}
				}
				MessageBox.Show((LangArEn == 0) ? "يجب ادراج صنف واحد على الأقل لهذا الصنف التجميعي" : "Can not be a number or name is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return false;
			}
			goto IL_02b8;
			IL_02b8:
			try
			{
				if (combobox_Unit1.SelectedIndex <= 0 || combobox_Unit1.SelectedValue.ToString() == null)
				{
					MessageBox.Show((LangArEn == 0) ? "يجب تحديد أصغر وحدة" : "You must select the smallest unit", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return false;
				}
			}
			catch
			{
				MessageBox.Show((LangArEn == 0) ? "يجب تحديد أصغر وحدة" : "You must select the smallest unit", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return false;
			}
			if (double.Parse(VarGeneral.TString.TEmpty(textbox_Pack1.Text ?? "")) <= 0.0)
			{
				MessageBox.Show((LangArEn == 0) ? "يجب تحديد تعبئة الوحدة" : "You must select the mobilization of the unit", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				textbox_Pack1.Focus();
				return false;
			}
			if (double.Parse(VarGeneral.TString.TEmpty(textbox_SelPri1.Text ?? "")) <= 0.0 && !radioButton_Service.Checked)
			{
				MessageBox.Show((LangArEn == 0) ? "يجب تحديد سعر التعبئة" : "You must specify the price of packing", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				textbox_SelPri1.Focus();
				return false;
			}
			try
			{
				if (combobox_Unit2.SelectedIndex > 0)
				{
					if (double.Parse(VarGeneral.TString.TEmpty(textbox_Pack2.Text ?? "")) <= 0.0)
					{
						MessageBox.Show((LangArEn == 0) ? "يجب تحديد تعبئة الوحدة" : "You must select the mobilization of the unit", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						textbox_Pack2.Focus();
						return false;
					}
					if (double.Parse(VarGeneral.TString.TEmpty(textbox_SelPri2.Text ?? "")) <= 0.0 && !radioButton_Service.Checked)
					{
						MessageBox.Show((LangArEn == 0) ? "يجب تحديد سعر التعبئة" : "You must specify the price of packing", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						textbox_SelPri2.Focus();
						return false;
					}
					if (combobox_Unit2.SelectedIndex == combobox_Unit1.SelectedIndex)
					{
						MessageBox.Show((LangArEn == 0) ? "يجب عدم تكرار إسم الوحدة بين الوحدات الخمسة .. تاكد من إسم الوحدة الثانية" : "We should not repeat the unity among the five units name ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						combobox_Unit2.Focus();
						return false;
					}
				}
				else
				{
					textbox_Pack2.Text = "";
					textbox_SelPri2.Text = "";
				}
			}
			catch
			{
			}
			try
			{
				if (combobox_Unit3.SelectedIndex > 0)
				{
					if (double.Parse(VarGeneral.TString.TEmpty(textbox_Pack3.Text ?? "")) <= 0.0)
					{
						MessageBox.Show((LangArEn == 0) ? "يجب تحديد تعبئة الوحدة" : "You must select the mobilization of the unit", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						textbox_Pack3.Focus();
						return false;
					}
					if (double.Parse(VarGeneral.TString.TEmpty(textbox_SelPri3.Text ?? "")) <= 0.0 && !radioButton_Service.Checked)
					{
						MessageBox.Show((LangArEn == 0) ? "يجب تحديد سعر التعبئة" : "You must specify the price of packing", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						textbox_SelPri3.Focus();
						return false;
					}
					if (combobox_Unit3.SelectedIndex == combobox_Unit1.SelectedIndex || combobox_Unit3.SelectedIndex == combobox_Unit2.SelectedIndex)
					{
						MessageBox.Show((LangArEn == 0) ? "يجب عدم تكرار إسم الوحدة بين الوحدات الخمسة .. تاكد من إسم الوحدة الثالثة" : "We should not repeat the unity among the five units name ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						combobox_Unit3.Focus();
						return false;
					}
				}
				else
				{
					textbox_Pack3.Text = "";
					textbox_SelPri3.Text = "";
				}
			}
			catch
			{
			}
			try
			{
				if (combobox_Unit4.SelectedIndex > 0)
				{
					if (double.Parse(VarGeneral.TString.TEmpty(textbox_Pack4.Text ?? "")) <= 0.0)
					{
						MessageBox.Show((LangArEn == 0) ? "يجب تحديد تعبئة الوحدة" : "You must select the mobilization of the unit", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						textbox_Pack4.Focus();
						return false;
					}
					if (double.Parse(VarGeneral.TString.TEmpty(textbox_SelPri4.Text ?? "")) <= 0.0 && !radioButton_Service.Checked)
					{
						MessageBox.Show((LangArEn == 0) ? "يجب تحديد سعر التعبئة" : "You must specify the price of packing", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						textbox_SelPri4.Focus();
						return false;
					}
					if (combobox_Unit4.SelectedIndex == combobox_Unit1.SelectedIndex || combobox_Unit4.SelectedIndex == combobox_Unit2.SelectedIndex || combobox_Unit4.SelectedIndex == combobox_Unit3.SelectedIndex)
					{
						MessageBox.Show((LangArEn == 0) ? "يجب عدم تكرار إسم الوحدة بين الوحدات الخمسة .. تاكد من إسم الوحدة الرابعة" : "We should not repeat the unity among the five units name ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						combobox_Unit4.Focus();
						return false;
					}
				}
				else
				{
					textbox_Pack4.Text = "";
					textbox_SelPri4.Text = "";
				}
			}
			catch
			{
			}
			try
			{
				if (combobox_Unit5.SelectedIndex > 0)
				{
					if (double.Parse(VarGeneral.TString.TEmpty(textbox_Pack5.Text ?? "")) <= 0.0)
					{
						MessageBox.Show((LangArEn == 0) ? "يجب تحديد تعبئة الوحدة" : "You must select the mobilization of the unit", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						textbox_Pack5.Focus();
						return false;
					}
					if (double.Parse(VarGeneral.TString.TEmpty(textbox_SelPri5.Text ?? "")) <= 0.0 && !radioButton_Service.Checked)
					{
						MessageBox.Show((LangArEn == 0) ? "يجب تحديد سعر التعبئة" : "You must specify the price of packing", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						textbox_SelPri5.Focus();
						return false;
					}
					if (combobox_Unit5.SelectedIndex == combobox_Unit1.SelectedIndex || combobox_Unit5.SelectedIndex == combobox_Unit2.SelectedIndex || combobox_Unit5.SelectedIndex == combobox_Unit3.SelectedIndex || combobox_Unit5.SelectedIndex == combobox_Unit4.SelectedIndex)
					{
						MessageBox.Show((LangArEn == 0) ? "يجب عدم تكرار إسم الوحدة بين الوحدات الخمسة .. تاكد من إسم الوحدة الخامسة" : "We should not repeat the unity among the five units name ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						combobox_Unit5.Focus();
						return false;
					}
				}
				else
				{
					textbox_Pack5.Text = "";
					textbox_SelPri5.Text = "";
				}
			}
			catch
			{
			}
			if (File.Exists(Application.StartupPath + "\\\\Script\\\\SecriptCeramic.dll"))
			{
				if (!string.IsNullOrEmpty(doubleInput_DefPack.Text))
				{
					try
					{
						double c = double.Parse(doubleInput_DefPack.Text);
					}
					catch
					{
						MessageBox.Show((LangArEn == 0) ? "يرجى التأكد من تعبئة الكراتين" : "Please be sure to fill the balls", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return false;
					}
					if (!doubleInput_DefPack.Text.Contains("."))
					{
						MessageBox.Show((LangArEn == 0) ? "يرجى التأكد من تعبئة الكراتين" : "Please be sure to fill the balls", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return false;
					}
					int z = -1;
					for (int i = 0; i < doubleInput_DefPack.Text.Length; i++)
					{
						if (doubleInput_DefPack.Text.Substring(i, 1) == ".")
						{
							z = i;
							break;
						}
					}
					if (z < 0)
					{
						MessageBox.Show((LangArEn == 0) ? "يرجى التأكد من تعبئة الكراتين" : "Please be sure to fill the balls", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return false;
					}
					try
					{
						string cc = doubleInput_DefPack.Text.Substring(z + 1, 1);
					}
					catch
					{
						MessageBox.Show((LangArEn == 0) ? "يرجى التأكد من تعبئة الكراتين" : "Please be sure to fill the balls", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return false;
					}
				}
				if (comboBox_DefPack.SelectedIndex == 1 && string.IsNullOrEmpty(textbox_Pack2.Text))
				{
					MessageBox.Show((LangArEn == 0) ? "يرجى التأكد من تعبئة الكراتين" : "Please be sure to fill the balls", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return false;
				}
				if (comboBox_DefPack.SelectedIndex == 2 && string.IsNullOrEmpty(textbox_Pack3.Text))
				{
					MessageBox.Show((LangArEn == 0) ? "يرجى التأكد من تعبئة الكراتين" : "Please be sure to fill the balls", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return false;
				}
				if (comboBox_DefPack.SelectedIndex == 3 && string.IsNullOrEmpty(textbox_Pack4.Text))
				{
					MessageBox.Show((LangArEn == 0) ? "يرجى التأكد من تعبئة الكراتين" : "Please be sure to fill the balls", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return false;
				}
				if (comboBox_DefPack.SelectedIndex == 4 && string.IsNullOrEmpty(textbox_Pack5.Text))
				{
					MessageBox.Show((LangArEn == 0) ? "يرجى التأكد من تعبئة الكراتين" : "Please be sure to fill the balls", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return false;
				}
			}
			if (txtBarCode1.Text != "")
			{
				List<T_Item> returned = db.SelectBarcodNoByReturnNoList(txtBarCode1.Text);
				try
				{
					if (returned.Count > 1)
					{
						MessageBox.Show((LangArEn == 0) ? "الرقم الذي قمت بإدخاله موجود من قبل - مكرر .. يرجى المحاولة مرة اخرى" : "The number you have entered already exists - bis .. Please try again.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						txtBarCode1.Text = "";
						txtBarCode1.Focus();
						return false;
					}
				}
				catch
				{
				}
			}
			if (txtBarCode2.Text != "")
			{
				List<T_Item> returned = db.SelectBarcodNoByReturnNoList(txtBarCode2.Text);
				try
				{
					if (returned.Count > 1)
					{
						MessageBox.Show((LangArEn == 0) ? "الرقم الذي قمت بإدخاله موجود من قبل - مكرر .. يرجى المحاولة مرة اخرى" : "The number you have entered already exists - bis .. Please try again.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						txtBarCode2.Text = "";
						txtBarCode2.Focus();
						return false;
					}
				}
				catch
				{
				}
			}
			if (txtBarCode3.Text != "")
			{
				List<T_Item> returned = db.SelectBarcodNoByReturnNoList(txtBarCode3.Text);
				try
				{
					if (returned.Count > 1)
					{
						MessageBox.Show((LangArEn == 0) ? "الرقم الذي قمت بإدخاله موجود من قبل - مكرر .. يرجى المحاولة مرة اخرى" : "The number you have entered already exists - bis .. Please try again.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						txtBarCode3.Text = "";
						txtBarCode3.Focus();
						return false;
					}
				}
				catch
				{
				}
			}
			if (txtBarCode4.Text != "")
			{
				List<T_Item> returned = db.SelectBarcodNoByReturnNoList(txtBarCode4.Text);
				try
				{
					if (returned.Count > 1)
					{
						MessageBox.Show((LangArEn == 0) ? "الرقم الذي قمت بإدخاله موجود من قبل - مكرر .. يرجى المحاولة مرة اخرى" : "The number you have entered already exists - bis .. Please try again.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						txtBarCode4.Text = "";
						txtBarCode4.Focus();
						return false;
					}
				}
				catch
				{
				}
			}
			if (txtBarCode5.Text != "")
			{
				List<T_Item> returned = db.SelectBarcodNoByReturnNoList(txtBarCode5.Text);
				try
				{
					if (returned.Count > 1)
					{
						MessageBox.Show((LangArEn == 0) ? "الرقم الذي قمت بإدخاله موجود من قبل - مكرر .. يرجى المحاولة مرة اخرى" : "The number you have entered already exists - bis .. Please try again.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						txtBarCode5.Text = "";
						txtBarCode5.Focus();
						return false;
					}
				}
				catch
				{
				}
			}
			return true;
		}
		private void Button_Save_Click(object sender, EventArgs e)
		{
			try
			{
				textBox_ID.Focus();
				if (!Button_Save.Enabled || !ValidData())
				{
					return;
				}
				try
				{
					if (DataThis.T_ItemDets.Count > 0)
					{
						for (int i = 0; i < LData_This.Count; i++)
						{
							db.T_ItemDets.DeleteOnSubmit(LData_This[i]);
							db.SubmitChanges();
						}
					}
				}
				catch
				{
				}
				if (State == FormState.New)
				{
					textBox_ID.TextChanged -= textBox_ID_TextChanged;
					if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 0))
					{
						T_Item itemSer = new T_Item();
						double itemNo = 0.0;
						string _symbol = "";
						try
						{
							_symbol = db.StockCatID(int.Parse(combobox_ItmeGroup.SelectedValue.ToString())).CAT_Symbol.Trim();
						}
						catch
						{
							_symbol = "";
						}
						if (pkeys.Count == 0)
						{
							if (_symbol == "")
							{
								textBox_ID.Text = VarGeneral.Settings_Sys.AutoItm.ToString();
							}
							else
							{
								textBox_ID.Text = _symbol + VarGeneral.Settings_Sys.AutoItm;
							}
						}
						else if (_symbol == "")
						{
							for (int i = 0; i < pkeys.Count; i++)
							{
								itemSer.Itm_No = PKeys[i];
								if (Program.sIsNumeric(itemSer.Itm_No) && double.Parse(itemSer.Itm_No) > itemNo)
								{
									itemNo = double.Parse(itemSer.Itm_No);
								}
							}
							textBox_ID.Text = (itemNo + 1.0).ToString();
						}
						else
						{
							List<string> newPkeys = pkeys.Where((string g) => g.StartsWith(_symbol)).ToList();
							if (newPkeys.Count == 0)
							{
								textBox_ID.Text = _symbol + VarGeneral.Settings_Sys.AutoItm;
							}
							else
							{
								for (int i = 0; i < newPkeys.Count; i++)
								{
									itemSer.Itm_No = newPkeys[i].Replace(_symbol, "").Trim();
									if (Program.sIsNumeric(itemSer.Itm_No) && double.Parse(itemSer.Itm_No) > itemNo)
									{
										itemNo = double.Parse(itemSer.Itm_No);
									}
								}
								textBox_ID.Text = _symbol + (itemNo + 1.0);
							}
						}
						combobox_ItmeGroup.Focus();
					}
					else
					{
						textBox_ID.Focus();
					}
					textBox_ID.TextChanged += textBox_ID_TextChanged;
					GetData();
					try
					{
						db.T_Items.InsertOnSubmit(data_this);
						db.SubmitChanges();
					}
					catch (SqlException ex)
					{
						int max = 0;
						max = db.MaxItemNo;
						if (ex.Number == 2627)
						{
							MessageBox.Show("رقم الصنف مستخدم من قبل.\n سيتم الحفظ برقم جديد [" + max + "]", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							textBox_ID.Text = string.Concat(max);
							data_this.Itm_No = max.ToString();
							Button_Save_Click(sender, e);
						}
					}
				}
				else if (State == FormState.Edit)
				{
					GetData();
					db.Log = VarGeneral.DebugLog;
					db.SubmitChanges(ConflictMode.ContinueOnConflict);
				}
				if (data_this.ItmTyp == 2)
				{
					saveDet();
				}
				State = FormState.Saved;
				RefreshPKeys();
				TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(data_this.Itm_No ?? "") + 1);
				SetReadOnly = true;
				dbInstance = null;
				textBox_ID_TextChanged(sender, e);
			}
			catch (Exception error)
			{
				VarGeneral.DebLog.writeLog("Save:", error, enable: true);
				MessageBox.Show(error.Message);
			}
		}
		private void saveDet()
		{
			if (string.IsNullOrEmpty(data_this.Itm_No))
			{
				return;
			}
			string[] Items;
			int ii;
			for (int i = 1; i < FlxInv.Rows.Count; i++)
			{
				FlxInv.Row = i;
				try
				{
					if (string.IsNullOrEmpty(FlxInv.GetData(i, 1).ToString() ?? ""))
					{
						continue;
					}
					T_ItemDet newData = new T_ItemDet();
					newData.ItmNo = data_this.Itm_No;
					newData.GItmNo = FlxInv.GetData(i, 1).ToString();
					newData.Qty = double.Parse(FlxInv.GetData(i, 7).ToString());
					newData.Price = double.Parse(FlxInv.GetData(i, 8).ToString());
					newData.StoreNo = int.Parse(FlxInv.GetData(i, 6).ToString());
					Items = FlxInv.Cols[3].ComboList.Split('|');
					ii = 0;
					while (true)
					{
						if (ii >= Items.Length)
						{
							break;
						}
						if (Items[ii] == FlxInv.GetData(i, 3).ToString())
						{
							List<T_Unit> vUnt = db.T_Units.Where((T_Unit t) => t.Arb_Des == Items[ii]).ToList();
							if (vUnt.Count > 0)
							{
								newData.Unit_ = vUnt.First().Unit_ID;
								T_Item q = db.StockItem(newData.GItmNo);
								if (q.Unit2 == vUnt.First().Unit_ID)
								{
									newData.Unit_ = 2;
								}
								else if (q.Unit3 == vUnt.First().Unit_ID)
								{
									newData.Unit_ = 3;
								}
								else if (q.Unit4 == vUnt.First().Unit_ID)
								{
									newData.Unit_ = 4;
								}
								else if (q.Unit5 == vUnt.First().Unit_ID)
								{
									newData.Unit_ = 5;
								}
								else
								{
									newData.Unit_ = 1;
								}
							}
							else
							{
								newData.Unit_ = 1;
							}
						}
						ii++;
					}
					db.T_ItemDets.InsertOnSubmit(newData);
					db.SubmitChanges();
				}
				catch
				{
				}
			}
		}
		private void Button_Delete_Click(object sender, EventArgs e)
		{
			if ((!Button_Delete.Enabled || !Button_Delete.Visible || State != 0) && !button_DeleteFromSystem.Visible)
			{
				ifOkDelete = false;
				return;
			}
			string Code = "";
			Code = textBox_ID.Text;
			if (Code == "")
			{
				ifOkDelete = false;
				return;
			}
			if (!button_DeleteFromSystem.Visible)
			{
				if (MessageBox.Show("هل أنت متاكد من حذف السجل [" + Code + "]؟ \n Are you sure that you want to delete the record [" + Code + "]?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					ifOkDelete = true;
				}
				else
				{
					ifOkDelete = false;
				}
			}
			if (data_this == null || string.IsNullOrEmpty(data_this.Itm_No) || !ifOkDelete)
			{
				return;
			}
			bool returned = db.StockCheckInvDet(DataThis.Itm_No);
			if (!returned)
			{
				returned = db.StockCheckInvOffer(DataThis.Itm_No);
			}
			if (returned)
			{
				MessageBox.Show((LangArEn == 0) ? "لايمكن حذف الصنف .. لانه مرتبط باحد الفواتير" : "You can not delete Item .. because it is tied to a Bills", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			List<T_StoreMnd> vStorMnd = db.T_StoreMnds.Where((T_StoreMnd t) => t.itmNo == data_this.Itm_No).ToList();
			if (vStorMnd.Count > 0)
			{
				MessageBox.Show((LangArEn == 0) ? "لايمكن حذف المستودع .. لانه مرتبط باحد فواتير صرف البضاعة" : "You can not delete the warehouse .. because it is tied to Item", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			data_this = db.StockItem(DataThis.Itm_No);
			if (data_this.ItmTyp == 2)
			{
				 Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
				LData_This = dbc.T_ItemDets.Where((T_ItemDet t) => t.ItmNo == data_this.Itm_No).ToList();
				for (int i = 0; i < LData_This.Count; i++)
				{
					if (dbc.StockCheckInvDet(LData_This[i].GItmNo))
					{
						MessageBox.Show((LangArEn == 0) ? "لايمكن حذف الصنف .. لانه يحوي\u064b صنف عليه حركة" : "You can not delete Item .. because it Contains item is tied to a Bills", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return;
					}
					dbc.T_ItemDets.DeleteOnSubmit(LData_This[i]);
					dbc.SubmitChanges();
				}
			}
			else if (db.StockItemDet(DataThis.Itm_No))
			{
				MessageBox.Show((LangArEn == 0) ? "لايمكن حذف الصنف .. لانه مرتبط بصنف تجميعي " : "You can not delete Item .. because it is tied to a Bills", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			try
			{
				try
				{
					db.T_EditItemPrices.DeleteAllOnSubmit(data_this.T_EditItemPrices);
					db.SubmitChanges();
				}
				catch
				{
				}
				try
				{
					db.T_ItemSerials.DeleteAllOnSubmit(data_this.T_ItemSerials);
					db.SubmitChanges();
				}
				catch
				{
				}
				List<T_STKSQTY> StkQty_ = (from t in db.T_STKSQTies
					where t.itmNo == data_this.Itm_No
					where Math.Abs(t.stkQty.Value) > 0.0
					select t).ToList();
				if (StkQty_.Count > 0)
				{
					return;
				}
				db.ExecuteCommand("DELETE FROM [dbo].[T_STKSQTY] WHERE itmNo = '" + data_this.Itm_No + "' and stkQty = 0");
				List<T_QTYEXP> QtyExp = (from t in db.T_QTYEXPs
					where t.itmNo == data_this.Itm_No
					where Math.Abs(t.stkQty.Value) > 0.0
					select t).ToList();
				if (QtyExp.Count > 0)
				{
					return;
				}
				db.ExecuteCommand("DELETE FROM [dbo].[T_QTYEXP] WHERE itmNo = '" + data_this.Itm_No + "' and stkQty = 0");
				List<T_StoreMnd> StorMnd_ = (from t in db.T_StoreMnds
					where t.itmNo == data_this.Itm_No
					where Math.Abs(t.stkQty.Value) > 0.0
					select t).ToList();
				if (StorMnd_.Count > 0)
				{
					return;
				}
				db.ExecuteCommand("DELETE FROM [dbo].[T_StoreMnd] WHERE itmNo = '" + data_this.Itm_No + "' and stkQty = 0");
				db.T_Items.DeleteOnSubmit(DataThis);
				db.SubmitChanges();
			}
			catch (SqlException)
			{
				data_this = db.StockItem(DataThis.Itm_No);
				return;
			}
			catch (Exception)
			{
				data_this = db.StockItem(DataThis.Itm_No);
				return;
			}
			Clear();
			RefreshPKeys();
			textBox_ID.Text = PKeys.LastOrDefault();
		}
		private void Button_Close_Click(object sender, EventArgs e)
		{
			Close();
		}
		private void ADD_Controls()
		{
			try
			{
				controls = new List<Control>();
				controls.Add(textbox_Arb_Des);
				codeControl = textBox_ID;
				controls.Add(doubleInput_DefPack);
				controls.Add(txtCustName);
				controls.Add(txtCustNo);
				controls.Add(textBox_SerialKey);
				controls.Add(button_AddNewCat);
				controls.Add(c1FlexGrid_Items);
				controls.Add(textbox_DateNo);
				controls.Add(textbox_Eng_Des);
				controls.Add(textBox_ID);
				controls.Add(textbox_Supreme);
				controls.Add(combobox_DateTyp);
				controls.Add(combobox_ItmeGroup);
				controls.Add(comboBox_DefPack);
				controls.Add(combobox_Unit1);
				controls.Add(combobox_Unit2);
				controls.Add(combobox_Unit3);
				controls.Add(combobox_Unit4);
				controls.Add(combobox_Unit5);
				controls.Add(pictureBox_PicItem);
				controls.Add(button_EnterImg);
				controls.Add(textbox_Legates);
				controls.Add(textbox_VIP);
				controls.Add(textbox_Sentence);
				controls.Add(textbox_Sectorial);
				controls.Add(textbox_Distributors);
				controls.Add(textbox_MaxQty);
				controls.Add(checkBoxX_BarcodeBalance);
				controls.Add(checkBoxX_Points);
				controls.Add(checkBoxX_InvPayment);
				controls.Add(checkBoxX_InvPaymentReturn);
				controls.Add(checkBoxX_InvSale);
				controls.Add(checkBoxX_ReturnInvSale);
				controls.Add(textBox_CommItm);
				controls.Add(textBox_DisItem);
				controls.Add(textBox_TaxSales);
				controls.Add(textBox_TaxPurchase);
				controls.Add(checkBoxX_InvEnter);
				controls.Add(checkBoxX_InvOut);
				controls.Add(txtFiled1);
				controls.Add(txtFiled2);
				controls.Add(txtFiled3);
				controls.Add(txtFiled4);
				controls.Add(txtFiled5);
				controls.Add(txtFiled6);
			}
			catch (SqlException)
			{
			}
		}
		private void textBox_ID_No_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
			{
				e.Handled = true;
			}
		}
		private void textBox_ID_KeyPress(object sender, KeyPressEventArgs e)
		{
		}
		public void Button_First_Click(object sender, EventArgs e)
		{
			if (ContinueIfEditOrNew())
			{
				TextBox_Index.TextBox.Text = string.Concat(1);
				UpdateVcr();
				UpdateVcr();
				textBox_ID.Focus();
			}
		}
		public void Button_Prev_Click(object sender, EventArgs e)
		{
			if (ContinueIfEditOrNew())
			{
				int index = 0;
				try
				{
					index = Convert.ToInt32(TextBox_Index.TextBox.Text);
				}
				catch
				{
				}
				if (index > 1)
				{
					TextBox_Index.TextBox.Text = string.Concat(index - 1);
				}
				UpdateVcr();
				textBox_ID.Focus();
			}
		}
		public void Button_Next_Click(object sender, EventArgs e)
		{
			if (ContinueIfEditOrNew())
			{
				int index = 0;
				int count = 0;
				try
				{
					index = Convert.ToInt32(TextBox_Index.TextBox.Text);
				}
				catch
				{
				}
				try
				{
					count = Convert.ToInt32(Label_Count.Text);
				}
				catch
				{
				}
				if (index < count)
				{
					TextBox_Index.TextBox.Text = string.Concat(index + 1);
				}
				UpdateVcr();
				textBox_ID.Focus();
			}
		}
		public void Button_Last_Click(object sender, EventArgs e)
		{
			if (ContinueIfEditOrNew())
			{
				TextBox_Index.TextBox.Text = Label_Count.Text;
				UpdateVcr();
				UpdateVcr();
			}
		}
		private void UpdateVcr()
		{
			int vCount = 0;
			int vPosition = 0;
			try
			{
				vCount = int.Parse(Label_Count.Text);
			}
			catch
			{
				vCount = 0;
			}
			try
			{
				vPosition = int.Parse(TextBox_Index.Text);
			}
			catch
			{
				vPosition = 0;
			}
			if (vCount <= 1)
			{
				Button_First.Enabled = false;
				Button_Prev.Enabled = false;
				Button_Next.Enabled = false;
				Button_Last.Enabled = false;
				if (LangArEn == 0)
				{
					lable_Records.Text = ((vCount == 0) ? "لايوجد سجلات" : "سجل واحد فقط");
				}
				else
				{
					lable_Records.Text = ((vCount == 0) ? "No records" : "Only Record");
				}
				return;
			}
			if (vPosition == 1)
			{
				ButtonItem button_First = Button_First;
				bool enabled = (Button_Prev.Enabled = false);
				button_First.Enabled = enabled;
				ButtonItem button_Last = Button_Last;
				enabled = (Button_Next.Enabled = vCount > 1);
				button_Last.Enabled = enabled;
				if (LangArEn == 0)
				{
					lable_Records.Text = "الأول من " + vCount + " سجلات";
				}
				else
				{
					lable_Records.Text = "First of " + vCount + " records";
				}
				return;
			}
			if (vPosition == vCount)
			{
				Button_Last.Enabled = false;
				Button_Next.Enabled = false;
				ButtonItem button_First2 = Button_First;
				bool enabled = (Button_Prev.Enabled = vCount > 1);
				button_First2.Enabled = enabled;
				if (LangArEn == 0)
				{
					lable_Records.Text = "الأخير من " + vCount + " سجلات";
				}
				else
				{
					lable_Records.Text = "Last of " + vCount + " records";
				}
				return;
			}
			Button_First.Enabled = true;
			Button_Prev.Enabled = true;
			Button_Next.Enabled = true;
			Button_Last.Enabled = true;
			if (LangArEn == 0)
			{
				lable_Records.Text = "السجل " + vPosition + " من " + vCount;
			}
			else
			{
				lable_Records.Text = "Record " + vPosition + " of " + vCount;
			}
		}
		private void textbox_Pack1_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (int.Parse(combobox_Unit1.SelectedValue.ToString()) < 1)
				{
					e.Handled = true;
				}
				else if ((!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b')) && e.KeyChar != '.')
				{
					e.Handled = true;
				}
			}
			catch
			{
				e.Handled = true;
			}
		}
		private void textbox_Pack2_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (int.Parse(combobox_Unit2.SelectedValue.ToString()) < 1)
				{
					e.Handled = true;
				}
				else if ((!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b')) && e.KeyChar != '.')
				{
					e.Handled = true;
				}
			}
			catch
			{
				e.Handled = true;
			}
		}
		private void textbox_Pack3_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (int.Parse(combobox_Unit3.SelectedValue.ToString()) < 1)
				{
					e.Handled = true;
				}
				else if ((!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b')) && e.KeyChar != '.')
				{
					e.Handled = true;
				}
			}
			catch
			{
				e.Handled = true;
			}
		}
		private void textbox_Pack4_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (int.Parse(combobox_Unit4.SelectedValue.ToString()) < 1)
				{
					e.Handled = true;
				}
				else if ((!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b')) && e.KeyChar != '.')
				{
					e.Handled = true;
				}
			}
			catch
			{
				e.Handled = true;
			}
		}
		private void textbox_Pack5_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (int.Parse(combobox_Unit5.SelectedValue.ToString()) < 1)
				{
					e.Handled = true;
				}
				else if ((!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b')) && e.KeyChar != '.')
				{
					e.Handled = true;
				}
			}
			catch
			{
				e.Handled = true;
			}
		}
		private void button_EnterImg_Click(object sender, EventArgs e)
		{
			try
			{
				openFileDialog1.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|TIFF Files (*.tiff)|*.tiff|BMP Files (*.bmp)|*.bmp";
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
				openFileDialog1.ShowDialog();
				string mypic_path = openFileDialog1.FileName;
				if (File.Exists(mypic_path))
				{
					pictureBox_PicItem.Image = Image.FromFile(mypic_path);
					Bitmap OriginalBM = new Bitmap(newSize: new Size(88, 100), original: pictureBox_PicItem.Image);
					pictureBox_PicItem.Image = OriginalBM;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		private void txtBarCode2_Leave(object sender, EventArgs e)
		{
			if (txtBarCode2.Text != "" && State != 0)
			{
				T_Item returned = db.SelectBarcodNoByReturnNo(txtBarCode2.Text);
				if (returned != null && returned.Itm_ID != 0 && returned.Itm_No != textBox_ID.Text)
				{
					MessageBox.Show((LangArEn == 0) ? "الرقم الذي قمت بإدخاله موجود من قبل - مكرر .. يرجى المحاولة مرة اخرى" : "The number you have entered already exists - bis .. Please try again.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					txtBarCode2.Text = "";
					txtBarCode2.Focus();
				}
			}
		}
		private void txtBarCode3_Leave(object sender, EventArgs e)
		{
			if (txtBarCode3.Text != "" && State != 0)
			{
				T_Item returned = db.SelectBarcodNoByReturnNo(txtBarCode3.Text);
				if (returned != null && returned.Itm_ID != 0 && returned.Itm_No != textBox_ID.Text)
				{
					MessageBox.Show((LangArEn == 0) ? "الرقم الذي قمت بإدخاله موجود من قبل - مكرر .. يرجى المحاولة مرة اخرى" : "The number you have entered already exists - bis .. Please try again.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					txtBarCode3.Text = "";
					txtBarCode3.Focus();
				}
			}
		}
		private void txtBarCode4_Leave(object sender, EventArgs e)
		{
			if (txtBarCode4.Text != "" && State != 0)
			{
				T_Item returned = db.SelectBarcodNoByReturnNo(txtBarCode4.Text);
				if (returned != null && returned.Itm_ID != 0 && returned.Itm_No != textBox_ID.Text)
				{
					MessageBox.Show((LangArEn == 0) ? "الرقم الذي قمت بإدخاله موجود من قبل - مكرر .. يرجى المحاولة مرة اخرى" : "The number you have entered already exists - bis .. Please try again.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					txtBarCode4.Text = "";
					txtBarCode4.Focus();
				}
			}
		}
		private void txtBarCode5_Leave(object sender, EventArgs e)
		{
			if (txtBarCode5.Text != "" && State != 0)
			{
				T_Item returned = db.SelectBarcodNoByReturnNo(txtBarCode5.Text);
				if (returned != null && returned.Itm_ID != 0 && returned.Itm_No != textBox_ID.Text)
				{
					MessageBox.Show((LangArEn == 0) ? "الرقم الذي قمت بإدخاله موجود من قبل - مكرر .. يرجى المحاولة مرة اخرى" : "The number you have entered already exists - bis .. Please try again.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					txtBarCode5.Text = "";
					txtBarCode5.Focus();
				}
			}
		}
		private void textbox_Arb_Des_Enter(object sender, EventArgs e)
		{
			SSSLanguage.Language.Switch("AR");
		}
		private void textbox_Eng_Des_Enter(object sender, EventArgs e)
		{
			SSSLanguage.Language.Switch("EN");
		}
		private void button_AddNewCat_Click(object sender, EventArgs e)
		{
            FrmItmGroup frm = new FrmItmGroup();
            frm.Tag = LangArEn;
            string vList = "";
            if (combobox_ItmeGroup.SelectedIndex != -1)
            {
                vList = combobox_ItmeGroup.SelectedValue.ToString();
            }
            frm.TopMost = true;
            frm.ShowDialog();
            using (new Stock_DataDataContext(VarGeneral.BranchCS))
            {
                List<T_CATEGORY> listAccCat = new List<T_CATEGORY>(db.T_CATEGORies.Select((T_CATEGORY item) => item).ToList());
                combobox_ItmeGroup.DataSource = null;
                combobox_ItmeGroup.DataSource = listAccCat;
                combobox_ItmeGroup.DisplayMember = ((LangArEn == 0) ? "Arb_Des" : "Eng_Des");
                combobox_ItmeGroup.ValueMember = "CAT_No";
                if (vList != "")
                {
                    for (int i = 0; i < combobox_ItmeGroup.Items.Count; i++)
                    {
                        combobox_ItmeGroup.SelectedIndex = i;
                        if (combobox_ItmeGroup.SelectedValue.ToString() == vList)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    combobox_ItmeGroup.SelectedIndex = -1;
                }
            }
        }
        private void FrmItems_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F1 && Button_Add.Enabled && Button_Add.Visible)
			{
				Button_Add_Click(sender, e);
			}
			else if (e.KeyCode == Keys.F2 && Button_Save.Enabled && Button_Save.Visible && State != 0)
			{
				Button_Save_Click(sender, e);
			}
			else if (e.KeyCode == Keys.F3 && Button_Delete.Enabled && Button_Delete.Visible && State == FormState.Saved)
			{
				Button_Delete_Click(sender, e);
			}
			else if (e.KeyCode == Keys.F4 && Button_Search.Enabled && Button_Search.Visible)
			{
				Button_Search_Click(sender, e);
			}
			else if (e.KeyCode == Keys.F5 && Button_PrintTable.Enabled && Button_PrintTable.Visible && !expandableSplitter1.Expanded)
			{
				Button_Print_Click(sender, e);
			}
			else if (e.KeyCode == Keys.F10 && Button_ExportTable2.Enabled && Button_ExportTable2.Visible && !expandableSplitter1.Expanded)
			{
				Button_ExportTable2_Click(sender, e);
			}
			else
			{
				if (e.KeyCode != Keys.Escape)
				{
					return;
				}
				if (State == FormState.Saved)
				{
					Close();
					return;
				}
				if (State != FormState.New)
				{
					textBox_ID_TextChanged(sender, e);
					return;
				}
				try
				{
					if (int.Parse(Label_Count.Text) > 0)
					{
						Button_Last_Click(sender, e);
					}
					else
					{
						Close();
					}
				}
				catch
				{
					Close();
				}
			}
		}
		private void FrmItems_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				SendKeys.Send("{Tab}");
			}
		}
		private void comboboxItems_Unit1_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				combobox_Unit1.SelectedIndex = comboboxItems_Unit1.SelectedIndex;
				UnitTabs();
			}
			catch
			{
			}
			try
			{
				labelItem11.Text = ((LangArEn == 0) ? "التعبئة بـ = " : "Fill = ") + combobox_Unit1.Text;
				labelItem16.Text = ((LangArEn == 0) ? "التعبئة بـ = " : "Fill = ") + combobox_Unit1.Text;
				labelItem21.Text = ((LangArEn == 0) ? "التعبئة بـ = " : "Fill = ") + combobox_Unit1.Text;
				labelItem26.Text = ((LangArEn == 0) ? "التعبئة بـ = " : "Fill = ") + combobox_Unit1.Text;
			}
			catch
			{
				labelItem11.Text = ((LangArEn == 0) ? "التعبئة" : "Fill");
				labelItem16.Text = ((LangArEn == 0) ? "التعبئة" : "Fill");
				labelItem21.Text = ((LangArEn == 0) ? "التعبئة" : "Fill");
				labelItem26.Text = ((LangArEn == 0) ? "التعبئة" : "Fill");
			}
		}
		private void comboboxItems_Unit2_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				combobox_Unit2.SelectedIndex = comboboxItems_Unit2.SelectedIndex;
				UnitTabs();
			}
			catch
			{
			}
		}
		private void comboboxItems_Unit3_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				combobox_Unit3.SelectedIndex = comboboxItems_Unit3.SelectedIndex;
				UnitTabs();
			}
			catch
			{
			}
		}
		private void comboboxItems_Unit4_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				combobox_Unit4.SelectedIndex = comboboxItems_Unit4.SelectedIndex;
				UnitTabs();
			}
			catch
			{
			}
		}
		private void comboboxItems_Unit5_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				combobox_Unit5.SelectedIndex = comboboxItems_Unit5.SelectedIndex;
				UnitTabs();
			}
			catch
			{
			}
		}
		private void c1FlexGrid_Items_AfterEdit(object sender, RowColEventArgs e)
		{
			try
			{
				Button_Edit_Click(sender, e);
				if (e.Col == 5)
				{
					if ((bool)c1FlexGrid_Items.GetData(e.Row, e.Col))
					{
						combobox_DateTyp.Items.Clear();
						textbox_DateNo.Enabled = true;
						combobox_DateTyp.Enabled = true;
						combobox_DateTyp.Items.Add("يوم");
						combobox_DateTyp.Items.Add("شهر");
						combobox_DateTyp.Items.Add("سنة");
						combobox_DateTyp.SelectedIndex = 0;
					}
					else
					{
						textbox_DateNo.Enabled = false;
						textbox_DateNo.Value = 0;
						combobox_DateTyp.Enabled = false;
						combobox_DateTyp.SelectedIndex = -1;
					}
				}
			}
			catch
			{
				textbox_DateNo.Enabled = false;
				textbox_DateNo.Value = 0;
				combobox_DateTyp.Enabled = false;
				combobox_DateTyp.SelectedIndex = -1;
			}
		}
		private void button_SrchItemGroup_Click(object sender, EventArgs e)
		{
			try
			{
				Dir_ButSearch.Add("CAT_No", new ColumnDictinary("الرمـــز", "CATEGORY No", ifDefault: true, ""));
				Dir_ButSearch.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
				Dir_ButSearch.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
                }
                VarGeneral.SFrmTyp = "T_CATEGORY";
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != "")
                {
                    combobox_ItmeGroup.SelectedValue = db.StockCat(frm.SerachNo.ToString()).CAT_ID;
                    Button_Edit_Click(sender, e);
                }
                Dir_ButSearch.Clear();
            }
			catch
			{
			}
		}
		private void CheckedCahngState()
		{
			if (radiobutton_RButDef1.Checked)
			{
				radiobutton_RButDef1.Checked = true;
				radiobutton_RButDef2.Checked = false;
				radiobutton_RButDef3.Checked = false;
				radiobutton_RButDef4.Checked = false;
				radiobutton_RButDef5.Checked = false;
			}
			else if (radiobutton_RButDef2.Checked)
			{
				radiobutton_RButDef1.Checked = false;
				radiobutton_RButDef2.Checked = true;
				radiobutton_RButDef3.Checked = false;
				radiobutton_RButDef4.Checked = false;
				radiobutton_RButDef5.Checked = false;
			}
			else if (radiobutton_RButDef3.Checked)
			{
				radiobutton_RButDef1.Checked = false;
				radiobutton_RButDef2.Checked = false;
				radiobutton_RButDef3.Checked = true;
				radiobutton_RButDef4.Checked = false;
				radiobutton_RButDef5.Checked = false;
			}
			else if (radiobutton_RButDef4.Checked)
			{
				radiobutton_RButDef1.Checked = false;
				radiobutton_RButDef2.Checked = false;
				radiobutton_RButDef3.Checked = false;
				radiobutton_RButDef4.Checked = true;
				radiobutton_RButDef5.Checked = false;
			}
			else if (radiobutton_RButDef5.Checked)
			{
				radiobutton_RButDef1.Checked = false;
				radiobutton_RButDef2.Checked = false;
				radiobutton_RButDef3.Checked = false;
				radiobutton_RButDef4.Checked = false;
				radiobutton_RButDef5.Checked = true;
			}
		}
		private void button_ClearPic_Click(object sender, EventArgs e)
		{
			try
			{
				Button_Edit_Click(sender, e);
				pictureBox_PicItem.Image = null;
			}
			catch
			{
			}
		}
		private void radiobutton_RButDef1_CheckedChanged(object sender, CheckBoxChangeEventArgs e)
		{
			if (radiobutton_RButDef1.Checked)
			{
				radiobutton_RButDef1.Checked = true;
				radiobutton_RButDef2.Checked = false;
				radiobutton_RButDef3.Checked = false;
				radiobutton_RButDef4.Checked = false;
				radiobutton_RButDef5.Checked = false;
			}
		}
		private void radiobutton_RButDef2_CheckedChanged(object sender, CheckBoxChangeEventArgs e)
		{
			if (radiobutton_RButDef2.Checked)
			{
				radiobutton_RButDef1.Checked = false;
				radiobutton_RButDef2.Checked = true;
				radiobutton_RButDef3.Checked = false;
				radiobutton_RButDef4.Checked = false;
				radiobutton_RButDef5.Checked = false;
			}
		}
		private void radiobutton_RButDef3_CheckedChanged(object sender, CheckBoxChangeEventArgs e)
		{
			if (radiobutton_RButDef3.Checked)
			{
				radiobutton_RButDef1.Checked = false;
				radiobutton_RButDef2.Checked = false;
				radiobutton_RButDef3.Checked = true;
				radiobutton_RButDef4.Checked = false;
				radiobutton_RButDef5.Checked = false;
			}
		}
		private void radiobutton_RButDef4_CheckedChanged(object sender, CheckBoxChangeEventArgs e)
		{
			if (radiobutton_RButDef4.Checked)
			{
				radiobutton_RButDef1.Checked = false;
				radiobutton_RButDef2.Checked = false;
				radiobutton_RButDef3.Checked = false;
				radiobutton_RButDef4.Checked = true;
				radiobutton_RButDef5.Checked = false;
			}
		}
		private void radiobutton_RButDef5_CheckedChanged(object sender, CheckBoxChangeEventArgs e)
		{
			if (radiobutton_RButDef5.Checked)
			{
				radiobutton_RButDef1.Checked = false;
				radiobutton_RButDef2.Checked = false;
				radiobutton_RButDef3.Checked = false;
				radiobutton_RButDef4.Checked = false;
				radiobutton_RButDef5.Checked = true;
			}
		}
		private void UnitTabs()
		{
			if (comboboxItems_Unit1.SelectedIndex > 0)
			{
				if (State == FormState.New && !textbox_SelPri1.Visible)
				{
					textbox_SelPri1.Text = "1";
				}
				comboboxItems_Unit2.Enabled = true;
				radiobutton_RButDef2.Enabled = true;
			}
			else
			{
				if (State == FormState.New)
				{
					textbox_SelPri1.Text = "";
				}
				comboboxItems_Unit2.Enabled = false;
				comboboxItems_Unit2.SelectedIndex = -1;
				textbox_Cost2.Text = "";
				textbox_Pack2.Text = "";
				textbox_Qty2.Text = "";
				textbox_SelPri2.Text = "";
				txtBarCode2.Text = "";
				radiobutton_RButDef2.Enabled = false;
			}
			if (comboboxItems_Unit2.SelectedIndex > 0)
			{
				if (State == FormState.New && !textbox_SelPri2.Visible)
				{
					textbox_SelPri2.Text = "1";
				}
				comboboxItems_Unit3.Enabled = true;
				radiobutton_RButDef3.Enabled = true;
			}
			else
			{
				if (State == FormState.New)
				{
					textbox_SelPri2.Text = "";
				}
				comboboxItems_Unit3.Enabled = false;
				comboboxItems_Unit3.SelectedIndex = -1;
				textbox_Cost3.Text = "";
				textbox_Pack3.Text = "";
				textbox_Qty3.Text = "";
				textbox_SelPri3.Text = "";
				txtBarCode3.Text = "";
				radiobutton_RButDef3.Enabled = false;
			}
			if (comboboxItems_Unit3.SelectedIndex > 0)
			{
				if (State == FormState.New && !textbox_SelPri3.Visible)
				{
					textbox_SelPri3.Text = "1";
				}
				comboboxItems_Unit4.Enabled = true;
				radiobutton_RButDef4.Enabled = true;
			}
			else
			{
				if (State == FormState.New)
				{
					textbox_SelPri3.Text = "";
				}
				comboboxItems_Unit4.Enabled = false;
				comboboxItems_Unit4.SelectedIndex = -1;
				textbox_Cost4.Text = "";
				textbox_Pack4.Text = "";
				textbox_Qty4.Text = "";
				textbox_SelPri4.Text = "";
				txtBarCode4.Text = "";
				radiobutton_RButDef4.Enabled = false;
			}
			if (comboboxItems_Unit4.SelectedIndex > 0)
			{
				if (State == FormState.New && !textbox_SelPri4.Visible)
				{
					textbox_SelPri4.Text = "1";
				}
				comboboxItems_Unit5.Enabled = true;
				radiobutton_RButDef5.Enabled = true;
			}
			else
			{
				if (State == FormState.New)
				{
					textbox_SelPri4.Text = "";
				}
				comboboxItems_Unit5.Enabled = false;
				comboboxItems_Unit5.SelectedIndex = -1;
				textbox_Cost5.Text = "";
				textbox_Pack5.Text = "";
				textbox_Qty5.Text = "";
				textbox_SelPri5.Text = "";
				txtBarCode5.Text = "";
				radiobutton_RButDef5.Enabled = false;
			}
			if (comboboxItems_Unit5.SelectedIndex > 0)
			{
				if (State == FormState.New && !textbox_SelPri5.Visible)
				{
					textbox_SelPri5.Text = "1";
				}
			}
			else if (State == FormState.New)
			{
				textbox_SelPri5.Text = "";
			}
			if (File.Exists(Application.StartupPath + "\\\\Script\\\\SecriptMaintenanceCars.dll"))
			{
				comboboxItems_Unit1.Enabled = false;
				comboboxItems_Unit2.Enabled = false;
				comboboxItems_Unit3.Enabled = false;
				comboboxItems_Unit4.Enabled = false;
				comboboxItems_Unit5.Enabled = false;
			}
		}
		private void expandableSplitter1_Click(object sender, EventArgs e)
		{
			if (expandableSplitter1.Expanded)
			{
				ViewTable_Click(sender, e);
			}
			else
			{
				ViewDetails_Click(sender, e);
			}
		}
		private void TextBox_Search_InputTextChanged(object sender)
		{
			Fill_DGV_Main();
		}
		private void TextBox_Search_ButtonCustomClick(object sender, EventArgs e)
		{
			textBox_search.Text = "";
		}
		private void ToolStripMenuItem_Det_Click(object sender, EventArgs e)
		{
			int rowIndex = Convert.ToInt32(DGV_Main.PrimaryGrid.Tag);
			TextBox_Index.TextBox.Text = string.Concat(rowIndex + 1);
			expandableSplitter1.Expanded = true;
			ViewDetails_Click(sender, e);
		}
		public void ViewDetails_Click(object sender, EventArgs e)
		{
			try
			{
				if (int.Parse(Label_Count.Text ?? "") <= 0 || (Label_Count.Text ?? "") == "")
				{
					expandableSplitter1.Expandable = false;
					return;
				}
				expandableSplitter1.Expandable = true;
				DGV_Main.PrimaryGrid.DataSource = null;
				DGV_Main.PrimaryGrid.VirtualMode = false;
				ViewState = ViewState.Deiles;
			}
			catch
			{
			}
		}
		public void ViewTable_Click(object sender, EventArgs e)
		{
			try
			{
				if (int.Parse(Label_Count.Text ?? "") <= 0 || (Label_Count.Text ?? "") == "")
				{
					expandableSplitter1.Expandable = false;
					//return;
				}
				expandableSplitter1.Expandable = true;
				ViewState = ViewState.Table;
			}
			catch
			{
			}
			Fill_DGV_Main();
			int index = -1;
			try
			{
				index = Convert.ToInt32(TextBox_Index.TextBox.Text);
			}
			catch
			{
				index = -1;
			}
			index--;
			if (index < DGV_Main.PrimaryGrid.Rows.Count && index >= 0)
			{
				DGV_Main.PrimaryGrid.Rows[index].EnsureVisible();
			}
		}
		private void DGV_Main_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				GridElement item = DGV_Main.GetElementAt(e.Location);
				if (item is GridColumnHeader)
				{
					GridColumnHeader gch = (GridColumnHeader)item;
					GridColumn column = null;
					HeaderArea area = gch.GetHitArea(e.Location, ref column);
					contextMenuStrip1.Show(Control.MousePosition);
				}
				else
				{
					contextMenuStrip2.Show(Control.MousePosition);
				}
			}
		}
		public void Fill_DGV_Main()
		{
			DGV_Main.PrimaryGrid.VirtualMode = false;
			List<T_Item> list = db.FillItem_2(textBox_search.TextBox.Text).ToList();
			try
			{
				list = list.OrderBy((T_Item c) => int.Parse(c.Itm_No)).ToList();
			}
			catch
			{
			}
			if (DGV_Main.PrimaryGrid.Columns.Count == 0)
			{
				foreach (KeyValuePair<string, ColumnDictinary> item in columns_Names_visible)
				{
					if (item.Key != "Arb_Des_Cat" && item.Key != "Eng_Des_Cat")
					{
						DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(item.Key));
					}
				}
			}
			FillHDGV(list);
		}
		public void FillHDGV(IEnumerable<T_Item> new_data_enum)
		{
			bool contextMenuSet = false;
			if (contextMenuStrip1.Items.Count > 0)
			{
				contextMenuSet = true;
			}
			for (int i = 0; i < DGV_Main.PrimaryGrid.Columns.Count; i++)
			{
				if (columns_Names_visible.ContainsKey(DGV_Main.PrimaryGrid.Columns[i].Name))
				{
					DGV_Main.PrimaryGrid.Columns[i].AutoSizeMode = ColumnAutoSizeMode.None;
					DGV_Main.PrimaryGrid.Columns[i].MinimumWidth = 50;
					DGV_Main.PrimaryGrid.Columns[i].Visible = columns_Names_visible[DGV_Main.PrimaryGrid.Columns[i].Name].IfDefault;
					DGV_Main.PrimaryGrid.Columns[i].HeaderText = ((LangArEn == 0) ? columns_Names_visible[DGV_Main.PrimaryGrid.Columns[i].Name].AText : columns_Names_visible[DGV_Main.PrimaryGrid.Columns[i].Name].EText);
					if (!contextMenuSet)
					{
						ToolStripMenuItem item = new ToolStripMenuItem();
						item.Checked = columns_Names_visible[DGV_Main.PrimaryGrid.Columns[i].Name].IfDefault;
						item.CheckOnClick = true;
						item.Name = DGV_Main.PrimaryGrid.Columns[i].Name;
						item.Text = DGV_Main.PrimaryGrid.Columns[i].HeaderText;
						item.CheckedChanged += item_Click;
						contextMenuStrip1.Items.Add(item);
					}
					else
					{
						DGV_Main.PrimaryGrid.Columns[i].Visible = (contextMenuStrip1.Items[DGV_Main.PrimaryGrid.Columns[i].Name] as ToolStripMenuItem).Checked;
					}
				}
				else
				{
					DGV_Main.PrimaryGrid.Columns[i].Visible = false;
				}
			}
			DGV_Main.PrimaryGrid.DataSource = new_data_enum.ToList();
			DGV_Main.PrimaryGrid.DataMember = "T_Item";
			DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background.Color2 = Color.LightBlue;
		}
		private void item_Click(object sender, EventArgs e)
		{
			string name = (sender as ToolStripMenuItem).Name;
			try
			{
				string NameExsist = DGV_Main.PrimaryGrid.Columns[name].Name;
			}
			catch
			{
				DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(name));
				DGV_Main.PrimaryGrid.Columns[name].AutoSizeMode = ColumnAutoSizeMode.None;
				DGV_Main.PrimaryGrid.Columns[name].MinimumWidth = 90;
				DGV_Main.PrimaryGrid.Columns[name].HeaderText = columns_Names_visible[name].AText;
			}
			DGV_Main.PrimaryGrid.Columns[name].Visible = (sender as ToolStripMenuItem).Checked;
		}
		private void DGV_Main_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
		{
			GridPanel panel = e.GridPanel;
			string dataMember = panel.DataMember;
			if (dataMember != null && dataMember == "T_Item")
			{
				PropBranchPanel(panel);
			}
		}
		private void PropBranchPanel(GridPanel panel)
		{
			DGV_Main.PrimaryGrid.UseAlternateRowStyle = true;
			DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background.Color1 = Color.SkyBlue;
			panel.FrozenColumnCount = 1;
			panel.Columns[0].GroupBoxEffects = GroupBoxEffects.None;
			foreach (GridColumn column in panel.Columns)
			{
				column.ColumnSortMode = ColumnSortMode.Multiple;
			}
			panel.ColumnHeader.RowHeight = 30;
			for (int i = 0; i < panel.Columns.Count; i++)
			{
				DGV_Main.PrimaryGrid.Columns[i].CellStyles.Default.Alignment = Alignment.MiddleCenter;
				DGV_Main.PrimaryGrid.Columns[i].Visible = false;
			}
			panel.Columns["Itm_No"].Width = 120;
			panel.Columns["Itm_No"].Visible = columns_Names_visible["Itm_No"].IfDefault;
			panel.Columns["Arb_Des"].Width = 180;
			panel.Columns["Arb_Des"].Visible = columns_Names_visible["Arb_Des"].IfDefault;
			panel.Columns["Eng_Des"].Width = 180;
			panel.Columns["Eng_Des"].Visible = columns_Names_visible["Eng_Des"].IfDefault;
			if (!File.Exists(Application.StartupPath + "\\\\Script\\\\SecriptInvitationCards.dll"))
			{
				panel.Columns["Itm_ID"].Width = 120;
				panel.Columns["Itm_ID"].Visible = columns_Names_visible["Itm_ID"].IfDefault;
				panel.Columns["AvrageCost"].Width = 120;
				panel.Columns["AvrageCost"].Visible = columns_Names_visible["AvrageCost"].IfDefault;
				panel.Columns["UntPri1"].Width = 120;
				panel.Columns["UntPri1"].Visible = columns_Names_visible["UntPri1"].IfDefault;
			}
			panel.Columns["BarCod1"].Width = 150;
			panel.Columns["BarCod1"].Visible = columns_Names_visible["BarCod1"].IfDefault;
			panel.Columns["BarCod2"].Width = 150;
			panel.Columns["BarCod2"].Visible = columns_Names_visible["BarCod2"].IfDefault;
			panel.Columns["BarCod3"].Width = 150;
			panel.Columns["BarCod3"].Visible = columns_Names_visible["BarCod3"].IfDefault;
			panel.Columns["BarCod4"].Width = 150;
			panel.Columns["BarCod4"].Visible = columns_Names_visible["BarCod4"].IfDefault;
		}
		private void DGV_Main_CellClick(object sender, GridCellClickEventArgs e)
		{
			DGV_Main.PrimaryGrid.Tag = e.GridCell.RowIndex;
		}
		private void DGV_Main_CellDoubleClick(object sender, GridCellDoubleClickEventArgs e)
		{
			ToolStripMenuItem_Det_Click(sender, e);
		}
		private void Button_ExportTable2_Click(object sender, EventArgs e)
		{
			try
			{
				ExportExcel.ExportToExcel(DGV_Main, "تقرير الأصناف");
			}
			catch
			{
			}
		}
		public void Button_Print_Click(object sender, EventArgs e)
		{
			if (ViewState != 0)
			{
				return;
			}
			try
			{
				RepShow _RepShow = new RepShow();
				_RepShow.Tables = " T_CATEGORY Inner Join T_Items on T_CATEGORY.CAT_ID = T_Items.ItmCat left join T_SYSSETTING on T_SYSSETTING.SYSSETTING_ID = T_Items.CompanyID ";
				string Fields = "";
				Fields = " T_Items.Itm_No as No, T_Items.Arb_Des as NmA, T_Items.Eng_Des as NmE,T_SYSSETTING.LogImg";
				_RepShow.Rule = "";
				if (!string.IsNullOrEmpty(Fields))
				{
					_RepShow.Fields = Fields;
					try
					{
						_RepShow = _RepShow.Save();
						VarGeneral.RepData = _RepShow.RepData;
					}
					catch (Exception ex2)
					{
						MessageBox.Show(ex2.Message);
					}
					if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
					{
						MessageBox.Show((LangArEn == 0) ? "عفوا .. لا يوجد بيانات لعرضها في التقرير " : "Sorry .. there is no data to display in the report ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						return;
					}
					try
					{
                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Tag = LangArEn;
                        frm.Repvalue = "RepGeneral";
                        VarGeneral.vTitle = Text;
                        frm.TopMost = true;
                        frm.ShowDialog();
                    }
					catch (Exception error)
					{
						VarGeneral.DebLog.writeLog("button_ShowRep_Click:", error, enable: true);
						MessageBox.Show(error.Message);
					}
				}
				else
				{
					MessageBox.Show((LangArEn == 0) ? " يجب تحديد حقل واحد على الأقل للطباعة" : "You must select one field or more", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			catch (Exception ex2)
			{
				MessageBox.Show(ex2.Message);
			}
		}
		private void txtBarCode1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
			{
				e.Handled = true;
			}
		}
		private void txtBarCode2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
			{
				e.Handled = true;
			}
		}
		private void txtBarCode3_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
			{
				e.Handled = true;
			}
		}
		private void txtBarCode4_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
			{
				e.Handled = true;
			}
		}
		private void txtBarCode5_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
			{
				e.Handled = true;
			}
		}
		private void PrintSet()
		{
			string _PrinterName = prnt_doc.PrinterSettings.PrinterName;
			prnt_doc.PrinterSettings.PrinterName = _InvSetting.defPrn;
			if (!prnt_doc.PrinterSettings.IsValid)
			{
				prnt_doc.PrinterSettings.PrinterName = _PrinterName;
			}
		}
		private void PrintForm_Click(object sender, EventArgs e)
		{
			PrintDialog PrintDialog1 = new PrintDialog();
			printDialog1.Document = prnt_doc;
			if (printDialog1.ShowDialog() == DialogResult.OK)
			{
				prnt_doc.Print();
			}
		}
		private void txtBarCode1_ButtonCustomClick(object sender, EventArgs e)
		{
			if (!(txtBarCode1.Text != ""))
			{
				return;
			}
			VarGeneral.BarcodCopies = 0;
			c1BarCode1.Text = txtBarCode1.Text;
			c1BarCode1.Tag = textbox_SelPri1.Text + " " + txtCurr.Text;
			try
			{
				if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 60) && textBox_TaxSales.Value > 0.0 && !string.IsNullOrEmpty(textbox_SelPri1.Text))
				{
					c1BarCode1.Tag = Math.Round(double.Parse(VarGeneral.TString.TEmpty(textbox_SelPri1.Text)) + double.Parse(textbox_SelPri1.Text) * (textBox_TaxSales.Value / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? 3 : 2);
					if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 78))
					{
						c1BarCode1.Tag = Math.Round(double.Parse(c1BarCode1.Tag.ToString()), 0).ToString();
					}
					C1BarCode c1BarCode = c1BarCode1;
					c1BarCode.Tag = string.Concat(c1BarCode.Tag, " ", txtCurr.Text);
				}
			}
			catch
			{
				c1BarCode1.Tag = textbox_SelPri1.Text + " " + txtCurr.Text;
			}
			PrintSet();
			prnt_prev = new PrintPreviewDialog();
			ToolStrip toollstr = (ToolStrip)prnt_prev.Controls["toolStrip1"];
			toollstr.Items.RemoveAt(0);
			toollstr.Items.Add("Print", null, PrintForm_Click);
			prnt_prev.Controls.Add(toollstr);
			prnt_prev.Document = prnt_doc;
			prnt_prev.ShowIcon = false;
			prnt_prev.AllowTransparency = true;
			prnt_prev.MdiParent = base.MdiParent;
			PrintDialog PrintDialog1 = new PrintDialog();
			printDialog1.Document = prnt_doc;
			T_INVSETTING _InvSetting = new T_INVSETTING();
			_InvSetting = db.StockInvSetting(22);
			try
			{
				if (_InvSetting.DefLines.Value > 0)
				{
					if (_InvSetting.InvTypA4 == "1")
					{
						prnt_doc.PrinterSettings.Collate = true;
					}
					else
					{
						prnt_doc.PrinterSettings.Collate = false;
					}
				}
				else
				{
					prnt_doc.PrinterSettings.Collate = false;
				}
			}
			catch
			{
				prnt_doc.PrinterSettings.Collate = false;
			}
			try
			{
				if (_InvSetting.nTyp.Substring(2, 1) == "0")
				{
					if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 55))
					{
						pdi.Document = new PrintDocument();
						if (pdi.ShowDialog() == DialogResult.OK)
						{
							prnt_doc.PrinterSettings = pdi.PrinterSettings;
							prnt_doc.Print();
						}
					}
					else
					{
						prnt_doc.Print();
					}
				}
				else
				{
					prnt_prev.TopMost = true;
					prnt_prev.ShowDialog();
				}
			}
			catch
			{
			}
		}
		private void prnt_prev_FormClosed(object sender, FormClosedEventArgs e)
		{
		}
		private void prnt_doc_BeginPrint(object sender, PrintEventArgs e)
		{
			CountPage = 0;
		}
		private void prnt_doc_PrintPage(object sender, PrintPageEventArgs e)
		{
			try
			{
				e.PageSettings.Margins.Bottom = 0;
				e.PageSettings.Margins.Top = Convert.ToInt32(_InvSetting.hAl);
				e.PageSettings.Margins.Left = Convert.ToInt32(_InvSetting.hYs);
				e.PageSettings.Margins.Right = 0;
				try
				{
					if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 55))
					{
						e.PageSettings.PrinterSettings.Copies = short.Parse(_InvSetting.DefLines.Value.ToString());
					}
				}
				catch
				{
					e.PageSettings.PrinterSettings.Copies = 1;
				}
				List<T_mInvPrint> listmInvPrint = new List<T_mInvPrint>();
				T_mInvPrint _mInvPrint = new T_mInvPrint();
				listmInvPrint = (from item in db.T_mInvPrints
					where item.repTyp == (int?)22
					where item.repNum == (int?)4
					where item.IsPrint == (int?)1
					where item.BarcodeTyp == (int?)0
					select item).ToList();
				if (listmInvPrint.Count == 0)
				{
					return;
				}
				double _isRows = 0.0;
				double _isCols = 0.0;
				float _Row = 0f;
				float _Col = 0f;
				double _PageLine = _InvSetting.lnPg.Value;
				double _LineSp = _InvSetting.lnSpc.Value;
				StringFormat strformat = new StringFormat((StringFormatFlags)0, 1);
				for (int iiRnt = 0; (double)iiRnt < _PageLine; iiRnt++)
				{
					_isCols = 0.0;
					for (int iiCol = 0; (double)iiCol < _LineSp; iiCol++)
					{
						for (int iiCnt = 0; iiCnt < listmInvPrint.Count; iiCnt++)
						{
							_mInvPrint = listmInvPrint[iiCnt];
							if (!(_mInvPrint.vFont != "0") || _mInvPrint.vSize.Value == 0)
							{
								continue;
							}
							strformat.FormatFlags = StringFormatFlags.DirectionRightToLeft;
							if (_mInvPrint.vEt.Value == 0)
							{
								strformat.Alignment = StringAlignment.Near;
							}
							else if (_mInvPrint.vEt.Value == 1)
							{
								strformat.Alignment = StringAlignment.Far;
							}
							else if (_mInvPrint.vEt.Value == 2)
							{
								strformat.Alignment = StringAlignment.Center;
							}
							if (_mInvPrint.uChr == "mm")
							{
								e.Graphics.PageUnit = GraphicsUnit.Millimeter;
							}
							else if (_mInvPrint.uChr == "doc")
							{
								e.Graphics.PageUnit = GraphicsUnit.Document;
							}
							else if (_mInvPrint.uChr == "in")
							{
								e.Graphics.PageUnit = GraphicsUnit.Inch;
							}
							else if (_mInvPrint.uChr == "point")
							{
								e.Graphics.PageUnit = GraphicsUnit.Point;
							}
							else if (_mInvPrint.uChr == "pixel")
							{
								e.Graphics.PageUnit = GraphicsUnit.Pixel;
							}
							Font _font = new Font(_mInvPrint.vFont, float.Parse(_mInvPrint.vSize.Value.ToString()), e.Graphics.PageUnit);
							if (_mInvPrint.vBold.Value == 1)
							{
								_font = new Font(_mInvPrint.vFont, float.Parse(_mInvPrint.vSize.Value.ToString()), FontStyle.Bold, e.Graphics.PageUnit);
							}
							_Row = (float)_mInvPrint.vRow.Value + (float)_isRows;
							_Col = (float)_mInvPrint.vCol.Value + (float)_isCols;
							if (_mInvPrint.pField == "BarCode")
							{
								e.Graphics.DrawImage(c1BarCode1.Image, _Col, _Row, float.Parse(_mInvPrint.MaxW.Value.ToString()), float.Parse(_mInvPrint.vSize.Value.ToString()));
							}
							else if (_mInvPrint.pField == "ItemNumber")
							{
								e.Graphics.DrawString(textBox_ID.Text, _font, Brushes.Black, _Col, _Row, strformat);
							}
							else if (_mInvPrint.pField == "ItemName")
							{
								if (LangArEn == 0)
								{
									e.Graphics.DrawString(textbox_Arb_Des.Text, _font, Brushes.Black, _Col, _Row, strformat);
								}
								else
								{
									e.Graphics.DrawString(textbox_Eng_Des.Text, _font, Brushes.Black, _Col, _Row, strformat);
								}
							}
							else if (_mInvPrint.pField == "Price")
							{
								e.Graphics.DrawString(c1BarCode1.Tag.ToString(), _font, Brushes.Black, _Col, _Row, strformat);
							}
							else if (_mInvPrint.pField == "CompanyName")
							{
								e.Graphics.DrawString(_Company.CopNam, _font, Brushes.Black, _Col, _Row, strformat);
							}
							else if (_mInvPrint.pField == "TaxNoteInv")
							{
								try
								{
									e.Graphics.DrawString(VarGeneral.Settings_Sys.TaxNoteInv, _font, Brushes.Black, _Col, _Row, strformat);
								}
								catch
								{
								}
							}
						}
						_isCols = _isCols + (double)_InvSetting.InvNum1.Value + _InvSetting.hYm.Value;
					}
					_isRows = _isRows + (double)_InvSetting.InvNum.Value + _InvSetting.hAs.Value;
				}
				CountPage++;
				if (CountPage == e.PageSettings.PrinterSettings.Copies)
				{
					e.HasMorePages = false;
				}
				else
				{
					e.HasMorePages = true;
				}
			}
			catch (Exception er)
			{
				MessageBox.Show(er.Message);
				MessageBox.Show("عفوا\u064b ... لا توجد حقول للطباعة راجع إعدادات الطباعة  \n Sorry , Not Found Fields for Printing", Application.ProductName);
			}
		}
		private void prnt_doc_QueryPageSettings(object sender, QueryPageSettingsEventArgs e)
		{
		}
		private void txtBarCode1_Leave(object sender, EventArgs e)
		{
			if (txtBarCode1.Text != "" && State != 0)
			{
				T_Item returned = db.SelectBarcodNoByReturnNo(txtBarCode1.Text);
				if (returned != null && returned.Itm_ID != 0 && returned.Itm_No != textBox_ID.Text)
				{
					MessageBox.Show((LangArEn == 0) ? "الرقم الذي قمت بإدخاله موجود من قبل - مكرر .. يرجى المحاولة مرة اخرى" : "The number you have entered already exists - bis .. Please try again.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					txtBarCode1.Text = "";
					txtBarCode1.Focus();
				}
			}
		}
		private void txtBarCode2_ButtonCustomClick(object sender, EventArgs e)
		{
			if (!(txtBarCode2.Text != ""))
			{
				return;
			}
			VarGeneral.BarcodCopies = 0;
			c1BarCode1.Text = txtBarCode2.Text;
			c1BarCode1.Tag = textbox_SelPri2.Text + " " + txtCurr.Text;
			try
			{
				if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 60) && textBox_TaxSales.Value > 0.0 && !string.IsNullOrEmpty(textbox_SelPri2.Text))
				{
					c1BarCode1.Tag = Math.Round(double.Parse(VarGeneral.TString.TEmpty(textbox_SelPri2.Text)) + double.Parse(textbox_SelPri2.Text) * (textBox_TaxSales.Value / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? 3 : 2);
					if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 78))
					{
						c1BarCode1.Tag = Math.Round(double.Parse(c1BarCode1.Tag.ToString()), 0).ToString();
					}
					C1BarCode c1BarCode = c1BarCode1;
					c1BarCode.Tag = string.Concat(c1BarCode.Tag, " ", txtCurr.Text);
				}
			}
			catch
			{
				c1BarCode1.Tag = textbox_SelPri2.Text + " " + txtCurr.Text;
			}
			PrintSet();
			prnt_prev = new PrintPreviewDialog();
			ToolStrip toollstr = (ToolStrip)prnt_prev.Controls["toolStrip1"];
			toollstr.Items.RemoveAt(0);
			toollstr.Items.Add("Print", null, PrintForm_Click);
			prnt_prev.Controls.Add(toollstr);
			prnt_prev.Document = prnt_doc;
			prnt_prev.AllowTransparency = true;
			prnt_prev.ShowIcon = false;
			prnt_prev.MdiParent = base.MdiParent;
			PrintDialog PrintDialog1 = new PrintDialog();
			printDialog1.Document = prnt_doc;
			T_INVSETTING _InvSetting = new T_INVSETTING();
			_InvSetting = db.StockInvSetting(22);
			try
			{
				if (_InvSetting.DefLines.Value > 0)
				{
					if (_InvSetting.InvTypA4 == "1")
					{
						prnt_doc.PrinterSettings.Collate = true;
					}
					else
					{
						prnt_doc.PrinterSettings.Collate = false;
					}
				}
				else
				{
					prnt_doc.PrinterSettings.Collate = false;
				}
			}
			catch
			{
				prnt_doc.PrinterSettings.Collate = false;
			}
			try
			{
				if (_InvSetting.nTyp.Substring(2, 1) == "0")
				{
					if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 55))
					{
						pdi.Document = new PrintDocument();
						if (pdi.ShowDialog() == DialogResult.OK)
						{
							prnt_doc.PrinterSettings = pdi.PrinterSettings;
							prnt_doc.Print();
						}
					}
					else
					{
						prnt_doc.Print();
					}
				}
				else
				{
					prnt_prev.TopMost = true;
					prnt_prev.ShowDialog();
				}
			}
			catch
			{
			}
		}
		private void txtBarCode3_ButtonCustomClick(object sender, EventArgs e)
		{
			if (!(txtBarCode3.Text != ""))
			{
				return;
			}
			VarGeneral.BarcodCopies = 0;
			c1BarCode1.Text = txtBarCode3.Text;
			c1BarCode1.Tag = textbox_SelPri3.Text + " " + txtCurr.Text;
			try
			{
				if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 60) && textBox_TaxSales.Value > 0.0 && !string.IsNullOrEmpty(textbox_SelPri3.Text))
				{
					c1BarCode1.Tag = Math.Round(double.Parse(VarGeneral.TString.TEmpty(textbox_SelPri3.Text)) + double.Parse(textbox_SelPri3.Text) * (textBox_TaxSales.Value / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? 3 : 2);
					if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 78))
					{
						c1BarCode1.Tag = Math.Round(double.Parse(c1BarCode1.Tag.ToString()), 0).ToString();
					}
					C1BarCode c1BarCode = c1BarCode1;
					c1BarCode.Tag = string.Concat(c1BarCode.Tag, " ", txtCurr.Text);
				}
			}
			catch
			{
				c1BarCode1.Tag = textbox_SelPri3.Text + " " + txtCurr.Text;
			}
			PrintSet();
			prnt_prev = new PrintPreviewDialog();
			ToolStrip toollstr = (ToolStrip)prnt_prev.Controls["toolStrip1"];
			toollstr.Items.RemoveAt(0);
			toollstr.Items.Add("Print", null, PrintForm_Click);
			prnt_prev.Controls.Add(toollstr);
			prnt_prev.Document = prnt_doc;
			prnt_prev.AllowTransparency = true;
			prnt_prev.ShowIcon = false;
			prnt_prev.MdiParent = base.MdiParent;
			PrintDialog PrintDialog1 = new PrintDialog();
			printDialog1.Document = prnt_doc;
			T_INVSETTING _InvSetting = new T_INVSETTING();
			_InvSetting = db.StockInvSetting(22);
			try
			{
				if (_InvSetting.DefLines.Value > 0)
				{
					if (_InvSetting.InvTypA4 == "1")
					{
						prnt_doc.PrinterSettings.Collate = true;
					}
					else
					{
						prnt_doc.PrinterSettings.Collate = false;
					}
				}
				else
				{
					prnt_doc.PrinterSettings.Collate = false;
				}
			}
			catch
			{
				prnt_doc.PrinterSettings.Collate = false;
			}
			try
			{
				if (_InvSetting.nTyp.Substring(2, 1) == "0")
				{
					if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 55))
					{
						pdi.Document = new PrintDocument();
						if (pdi.ShowDialog() == DialogResult.OK)
						{
							prnt_doc.PrinterSettings = pdi.PrinterSettings;
							prnt_doc.Print();
						}
					}
					else
					{
						prnt_doc.Print();
					}
				}
				else
				{
					prnt_prev.TopMost = true;
					prnt_prev.ShowDialog();
				}
			}
			catch
			{
			}
		}
		private void txtBarCode4_ButtonCustomClick(object sender, EventArgs e)
		{
			if (!(txtBarCode4.Text != ""))
			{
				return;
			}
			VarGeneral.BarcodCopies = 0;
			c1BarCode1.Text = txtBarCode4.Text;
			c1BarCode1.Tag = textbox_SelPri4.Text + " " + txtCurr.Text;
			try
			{
				if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 60) && textBox_TaxSales.Value > 0.0 && !string.IsNullOrEmpty(textbox_SelPri4.Text))
				{
					c1BarCode1.Tag = Math.Round(double.Parse(VarGeneral.TString.TEmpty(textbox_SelPri4.Text)) + double.Parse(textbox_SelPri4.Text) * (textBox_TaxSales.Value / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? 3 : 2);
					if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 78))
					{
						c1BarCode1.Tag = Math.Round(double.Parse(c1BarCode1.Tag.ToString()), 0).ToString();
					}
					C1BarCode c1BarCode = c1BarCode1;
					c1BarCode.Tag = string.Concat(c1BarCode.Tag, " ", txtCurr.Text);
				}
			}
			catch
			{
				c1BarCode1.Tag = textbox_SelPri4.Text + " " + txtCurr.Text;
			}
			PrintSet();
			prnt_prev = new PrintPreviewDialog();
			ToolStrip toollstr = (ToolStrip)prnt_prev.Controls["toolStrip1"];
			toollstr.Items.RemoveAt(0);
			toollstr.Items.Add("Print", null, PrintForm_Click);
			prnt_prev.Controls.Add(toollstr);
			prnt_prev.Document = prnt_doc;
			prnt_prev.AllowTransparency = true;
			prnt_prev.ShowIcon = false;
			prnt_prev.MdiParent = base.MdiParent;
			PrintDialog PrintDialog1 = new PrintDialog();
			printDialog1.Document = prnt_doc;
			T_INVSETTING _InvSetting = new T_INVSETTING();
			_InvSetting = db.StockInvSetting(22);
			try
			{
				if (_InvSetting.DefLines.Value > 0)
				{
					if (_InvSetting.InvTypA4 == "1")
					{
						prnt_doc.PrinterSettings.Collate = true;
					}
					else
					{
						prnt_doc.PrinterSettings.Collate = false;
					}
				}
				else
				{
					prnt_doc.PrinterSettings.Collate = false;
				}
			}
			catch
			{
				prnt_doc.PrinterSettings.Collate = false;
			}
			try
			{
				if (_InvSetting.nTyp.Substring(2, 1) == "0")
				{
					if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 55))
					{
						pdi.Document = new PrintDocument();
						if (pdi.ShowDialog() == DialogResult.OK)
						{
							prnt_doc.PrinterSettings = pdi.PrinterSettings;
							prnt_doc.Print();
						}
					}
					else
					{
						prnt_doc.Print();
					}
				}
				else
				{
					prnt_prev.TopMost = true;
					prnt_prev.ShowDialog();
				}
			}
			catch
			{
			}
		}
		private void txtBarCode5_ButtonCustomClick(object sender, EventArgs e)
		{
			if (!(txtBarCode5.Text != ""))
			{
				return;
			}
			VarGeneral.BarcodCopies = 0;
			c1BarCode1.Text = txtBarCode5.Text;
			c1BarCode1.Tag = textbox_SelPri5.Text + " " + txtCurr.Text;
			try
			{
				if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 60) && textBox_TaxSales.Value > 0.0 && !string.IsNullOrEmpty(textbox_SelPri5.Text))
				{
					c1BarCode1.Tag = Math.Round(double.Parse(VarGeneral.TString.TEmpty(textbox_SelPri5.Text)) + double.Parse(textbox_SelPri5.Text) * (textBox_TaxSales.Value / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? 3 : 2);
					if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 78))
					{
						c1BarCode1.Tag = Math.Round(double.Parse(c1BarCode1.Tag.ToString()), 0).ToString();
					}
					C1BarCode c1BarCode = c1BarCode1;
					c1BarCode.Tag = string.Concat(c1BarCode.Tag, " ", txtCurr.Text);
				}
			}
			catch
			{
				c1BarCode1.Tag = textbox_SelPri5.Text + " " + txtCurr.Text;
			}
			PrintSet();
			prnt_prev = new PrintPreviewDialog();
			ToolStrip toollstr = (ToolStrip)prnt_prev.Controls["toolStrip1"];
			toollstr.Items.RemoveAt(0);
			toollstr.Items.Add("Print", null, PrintForm_Click);
			prnt_prev.Controls.Add(toollstr);
			prnt_prev.Document = prnt_doc;
			prnt_prev.AllowTransparency = true;
			prnt_prev.ShowIcon = false;
			prnt_prev.MdiParent = base.MdiParent;
			PrintDialog PrintDialog1 = new PrintDialog();
			printDialog1.Document = prnt_doc;
			T_INVSETTING _InvSetting = new T_INVSETTING();
			_InvSetting = db.StockInvSetting(22);
			try
			{
				if (_InvSetting.DefLines.Value > 0)
				{
					if (_InvSetting.InvTypA4 == "1")
					{
						prnt_doc.PrinterSettings.Collate = true;
					}
					else
					{
						prnt_doc.PrinterSettings.Collate = false;
					}
				}
				else
				{
					prnt_doc.PrinterSettings.Collate = false;
				}
			}
			catch
			{
				prnt_doc.PrinterSettings.Collate = false;
			}
			try
			{
				if (_InvSetting.nTyp.Substring(2, 1) == "0")
				{
					if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 55))
					{
						pdi.Document = new PrintDocument();
						if (pdi.ShowDialog() == DialogResult.OK)
						{
							prnt_doc.PrinterSettings = pdi.PrinterSettings;
							prnt_doc.Print();
						}
					}
					else
					{
						prnt_doc.Print();
					}
				}
				else
				{
					prnt_prev.TopMost = true;
					prnt_prev.ShowDialog();
				}
			}
			catch
			{
			}
		}
		private void button_SrchCustNo_Click(object sender, EventArgs e)
		{
			Button_Edit_Click(sender, e);
			if (State == FormState.Saved)
			{
				return;
			}
			columns_Names_visible2.Clear();
			columns_Names_visible2.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
			columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
			columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
			columns_Names_visible2.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, ""));
			columns_Names_visible2.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_AccDef_Suppliers";
            VarGeneral.AccTyp = 5;
            if (File.Exists(Application.StartupPath + "\\\\Script\\\\SecriptInvitationCards.dll"))
            {
                VarGeneral.AccTyp = 4;
            }
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtCustNo.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                if (LangArEn == 0)
                {
                    txtCustName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des;
                }
                else
                {
                    txtCustName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des;
                }
            }
            else
            {
                txtCustNo.Text = "";
                txtCustName.Text = "";
            }
        }
		private void buttonItem_EditPrice_Click(object sender, EventArgs e)
		{
			try
			{
				if (!VarGeneral.TString.ChkStatShow(permission.SetStr, 5))
				{
					MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					if (State != 0)
					{
						return;
					}
					try
					{
						if (string.IsNullOrEmpty(textBox_ID.Text))
						{
							return;
						}
					}
					catch
					{
						return;
					}
					try
					{
						if (db.StockCheckInvDet(DataThis.Itm_No))
						{
							buttonItem_EditPrice.Enabled = true;
						}
						else
						{
							buttonItem_EditPrice.Enabled = false;
						}
					}
					catch
					{
						return;
					}
					//FrmEditItemsPrices form1 = new FrmEditItemsPrices(textBox_ID.Text);
					//form1.Tag = LangArEn.ToString();
					//form1.StartPosition = FormStartPosition.CenterScreen;
					//try
					//{
					//	if ((data_this.AvrageCost.Value == 0.0 || data_this.AvrageCost.Value == 0.0) && (data_this.FirstCost.Value == 0.0 || data_this.FirstCost.Value == 0.0) && VarGeneral.UserID != 1)
					//	{
					//		form1.doubleInput_SelCostNew.Visible = false;
					//		form1.doubleInput_SelCostNow.Visible = false;
					//		form1.label4.Visible = false;
					//	}
					//}
					//catch
					//{
					//	return;
					//}
					//form1.TopMost = true;
					//form1.ShowDialog();
					//dbInstance = null;
					//textBox_ID_TextChanged(sender, e);
					return;
				}
			}
			catch (Exception error)
			{
				VarGeneral.DebLog.writeLog("buttonItem_EditPrice_Click:", error, enable: true);
				MessageBox.Show(error.Message);
			}
		}
		private void radioButton_Product_CheckedChanged(object sender, CheckBoxChangeEventArgs e)
		{
			if (radioButton_Product.Checked)
			{
				superTabItem_Details.Enabled = true;
				sideBarPanelItem_Unit2.Visible = false;
				sideBarPanelItem_Unit3.Visible = false;
				sideBarPanelItem_Unit4.Visible = false;
				sideBarPanelItem_Unit5.Visible = false;
				label11.Visible = false;
				textbox_Supreme.Visible = false;
			}
			else
			{
				superTabItem_Details.Enabled = false;
				sideBarPanelItem_Unit2.Visible = true;
				sideBarPanelItem_Unit3.Visible = true;
				sideBarPanelItem_Unit4.Visible = true;
				sideBarPanelItem_Unit5.Visible = true;
				label11.Visible = true;
				textbox_Supreme.Visible = true;
			}
			Refresh();
		}
		private void FlxInv_AfterEdit(object sender, RowColEventArgs e)
		{
			try
			{
				double ItmDis = 0.0;
				ItmDis = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 9)))) / 100.0);
				if (e.Col == 1)
				{
					BindDataOfItem();
				}
				else if (((e.Col == 2 || e.Col == 4) && (string)FlxInv.GetData(e.Row, 1) == "") || FlxInv.GetData(e.Row, 1) == null)
				{
					BindDataOfItem();
				}
				else if ((e.Col == 3 || e.Col == 5) && FlxInv.GetData(e.Row, e.Col).ToString() != oldUnit)
				{
					int ItemIndex = -1;
					if (e.Col == 3)
					{
						string[] Items = FlxInv.Cols[e.Col].ComboList.Split('|');
						for (int i = 0; i < Items.Length; i++)
						{
							if (Items[i] == FlxInv.GetData(e.Row, e.Col).ToString())
							{
								ItemIndex = i + 1;
							}
						}
						string[] Items2 = FlxInv.Cols[5].ComboList.Split('|');
						if (Items2.Length > 1 && ItemIndex > -1)
						{
							FlxInv.SetData(e.Row, 5, Items2[ItemIndex - 1]);
						}
					}
					else if (e.Col == 5)
					{
						string[] Items = FlxInv.Cols[e.Col].ComboList.Split('|');
						for (int i = 0; i < Items.Length; i++)
						{
							if (Items[i] == FlxInv.GetData(e.Row, e.Col).ToString())
							{
								ItemIndex = i + 1;
							}
						}
						string[] Items2 = FlxInv.Cols[3].ComboList.Split('|');
						if (Items2.Length > 1 && ItemIndex > -1)
						{
							FlxInv.SetData(e.Row, 3, Items2[ItemIndex - 1]);
						}
					}
					switch (ItemIndex)
					{
					case 1:
						FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri1 / RateValue);
						FlxInv.SetData(FlxInv.Row, 11, _Items.Pack1);
						break;
					case 2:
						FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri2 / RateValue);
						FlxInv.SetData(FlxInv.Row, 11, _Items.Pack2);
						break;
					case 3:
						FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri3 / RateValue);
						FlxInv.SetData(FlxInv.Row, 11, _Items.Pack3);
						break;
					case 4:
						FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri4 / RateValue);
						FlxInv.SetData(FlxInv.Row, 11, _Items.Pack4);
						break;
					case 5:
						FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri5 / RateValue);
						FlxInv.SetData(FlxInv.Row, 11, _Items.Pack5);
						break;
					}
					Pack = ItemIndex;
					FlxInv.SetData(e.Row, 12, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 11)))));
					FlxInv.SetData(e.Row, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis);
					PriceLoc = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8))));
					FlxInv.SetData(e.Row, 26, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) / 1.0);
				}
				else if (e.Col == 6)
				{
					listStkQty = (from t in db.T_STKSQTies
						where t.itmNo == FlxInv.GetData(e.Row, 1).ToString()
						where t.storeNo == (int?)int.Parse(FlxInv.GetData(e.Row, 6).ToString())
						select t).ToList();
					if (listStkQty.Count != 0)
					{
						_StksQty = listStkQty[0];
						FlxInv.SetData(e.Row, 24, _StksQty.stkQty.ToString());
					}
					else
					{
						FlxInv.SetData(e.Row, 24, 0);
					}
				}
				else if (e.Col == 7 || e.Col == 8)
				{
					double RealQ = 0.0;
					RealQ = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 11))));
					if (e.Col == 8 && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 10)))) != 0.0 && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 10)))) > double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) && !VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 2))
					{
						MessageBox.Show((LangArEn == 0) ? "لا يمكن البيع بأقل من سعر التكلفة .. راجع صلاحيات المستخدمين" : "Can't Sale Less Then Cost Price ... Check the Users Authorizations", VarGeneral.ProdectNam);
						FlxInv.SetData(e.Row, 8, PriceLoc);
					}
					FlxInv.SetData(e.Row, 12, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 11)))));
					FlxInv.SetData(e.Row, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis);
					chekReptItem(Col_1: false);
				}
				else if (e.Col == 9)
				{
					FlxInv.SetData(e.Row, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis);
				}
				else if (e.Col == 31)
				{
					if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) != double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis)
					{
						if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) == 0.0)
						{
							MessageBox.Show((LangArEn == 0) ? "يجب تحديد الكمية" : "Must Enter The Quantity", VarGeneral.ProdectNam);
							FlxInv.SetData(e.Row, 31, 0);
							FlxInv.Col = 7;
							FlxInv.Row = e.Row;
							FlxInv.Focus();
						}
						else
						{
							FlxInv.SetData(e.Row, 8, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) / double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))));
							FlxInv.SetData(e.Row, 9, 0);
						}
					}
					if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 10)))) != 0.0 && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 10)))) > double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) && !VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 2))
					{
						MessageBox.Show((LangArEn == 0) ? "لا يمكن البيع بأقل من سعر التكلفة .. راجع صلاحيات المستخدمين" : "Can't Sale Less Then Cost Price ... Check the Users Authorizations", VarGeneral.ProdectNam);
						FlxInv.SetData(e.Row, 8, PriceLoc);
					}
					chekReptItem(Col_1: false);
				}
				VarGeneral.Flush();
				GetInvTot();
			}
			catch
			{
			}
		}
		private void GetInvTot()
		{
			try
			{
				double InvTot = 0.0;
				double InvCost = 0.0;
				double InvQty = 0.0;
				List<double> vQty = new List<double>();
				for (int iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
				{
					try
					{
						InvTot += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 31))));
						InvCost += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 10)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 12))));
						InvQty += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7))));
						vQty.Add(db.StockItem(FlxInv.GetData(iiCnt, 1).ToString()).OpenQty.Value / double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 12)))));
					}
					catch
					{
					}
				}
				textbox_Cost1.Text = VarGeneral.TString.TEmpty(Math.Round(InvCost, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? 3 : 2).ToString());
				c1FlexGrid_Items.SetData(1, 1, VarGeneral.TString.TEmpty(Math.Round(InvCost, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? 3 : 2).ToString()));
				if (vQty.Count > 0)
				{
					c1FlexGrid_Items.SetData(1, 0, (vQty.Min() < 0.0) ? 0.0 : vQty.Min());
				}
				else
				{
					c1FlexGrid_Items.SetData(1, 0, 0);
				}
			}
			catch
			{
			}
		}
		private void FlxInv_BeforeEdit(object sender, RowColEventArgs e)
		{
			if ((e.Col == 3 || e.Col == 5) && FlxInv.GetData(e.Row, e.Col) != null)
			{
				oldUnit = FlxInv.GetData(e.Row, 3).ToString() ?? "";
			}
		}
		private void FlxInv_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
			{
				FlxInv.RemoveItem(FlxInv.Row);
				GetInvTot();
			}
		}
		private void FlxInv_MouseDown(object sender, MouseEventArgs e)
		{
			try
			{
				if (!(string.Concat(FlxInv.GetData(FlxInv.RowSel, 1)) != ""))
				{
					return;
				}
				_Items = db.StockItem(string.Concat(FlxInv.GetData(FlxInv.RowSel, 1)));
				string CoA = "";
				string CoE = "";
				for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
				{
					_Unit = listUnit[iiCnt];
					if (_Items.Unit1 == _Unit.Unit_ID)
					{
						if (CoA != "")
						{
							CoA += "|";
							CoE += "|";
						}
						CoA += _Unit.Arb_Des;
						CoE += _Unit.Eng_Des;
						break;
					}
				}
				for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
				{
					_Unit = listUnit[iiCnt];
					if (_Items.Unit2 == _Unit.Unit_ID)
					{
						if (CoA != "")
						{
							CoA += "|";
							CoE += "|";
						}
						CoA += _Unit.Arb_Des;
						CoE += _Unit.Eng_Des;
						break;
					}
				}
				for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
				{
					_Unit = listUnit[iiCnt];
					if (_Items.Unit3 == _Unit.Unit_ID)
					{
						if (CoA != "")
						{
							CoA += "|";
							CoE += "|";
						}
						CoA += _Unit.Arb_Des;
						CoE += _Unit.Eng_Des;
						break;
					}
				}
				for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
				{
					_Unit = listUnit[iiCnt];
					if (_Items.Unit4 == _Unit.Unit_ID)
					{
						if (CoA != "")
						{
							CoA += "|";
							CoE += "|";
						}
						CoA += _Unit.Arb_Des;
						CoE += _Unit.Eng_Des;
						break;
					}
				}
				for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
				{
					_Unit = listUnit[iiCnt];
					if (_Items.Unit5 == _Unit.Unit_ID)
					{
						if (CoA != "")
						{
							CoA += "|";
							CoE += "|";
						}
						CoA += _Unit.Arb_Des;
						CoE += _Unit.Eng_Des;
						break;
					}
				}
				FlxInv.Cols[3].ComboList = CoA;
				FlxInv.Cols[5].ComboList = CoE;
			}
			catch
			{
			}
		}
		private void FlxInv_RowColChange(object sender, EventArgs e)
		{
			if (FlxInv.Col == 1)
			{
				Framework.Keyboard.Language.Switch("English");
			}
			if (FlxInv.Col == 2)
			{
				Framework.Keyboard.Language.Switch("Arabic");
			}
			if (FlxInv.Col == 4)
			{
				Framework.Keyboard.Language.Switch("English");
			}
		}
		private void FlxInv_SelChange(object sender, EventArgs e)
		{
			if (RowSel == FlxInv.Row || FlxInv.Row <= 0 || !(string.Concat(FlxInv.GetData(FlxInv.Row, 1)) != ""))
			{
				return;
			}
			List<T_Item> listSer = new List<T_Item>();
			listSer = db.StockItemList(string.Concat(FlxInv.GetData(FlxInv.RowSel, 1)));
			if (listSer.Count != 0)
			{
				_Items = listSer[0];
				string CoA = "";
				string CoE = "";
				for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
				{
					_Unit = listUnit[iiCnt];
					if (_Items.Unit1 == _Unit.Unit_ID)
					{
						if (CoA != "")
						{
							CoA += "|";
							CoE += "|";
						}
						CoA += _Unit.Arb_Des;
						CoE += _Unit.Eng_Des;
						break;
					}
				}
				for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
				{
					_Unit = listUnit[iiCnt];
					if (_Items.Unit2 == _Unit.Unit_ID)
					{
						if (CoA != "")
						{
							CoA += "|";
							CoE += "|";
						}
						CoA += _Unit.Arb_Des;
						CoE += _Unit.Eng_Des;
						break;
					}
				}
				for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
				{
					_Unit = listUnit[iiCnt];
					if (_Items.Unit3 == _Unit.Unit_ID)
					{
						if (CoA != "")
						{
							CoA += "|";
							CoE += "|";
						}
						CoA += _Unit.Arb_Des;
						CoE += _Unit.Eng_Des;
						break;
					}
				}
				for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
				{
					_Unit = listUnit[iiCnt];
					if (_Items.Unit4 == _Unit.Unit_ID)
					{
						if (CoA != "")
						{
							CoA += "|";
							CoE += "|";
						}
						CoA += _Unit.Arb_Des;
						CoE += _Unit.Eng_Des;
						break;
					}
				}
				for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
				{
					_Unit = listUnit[iiCnt];
					if (_Items.Unit5 == _Unit.Unit_ID)
					{
						if (CoA != "")
						{
							CoA += "|";
							CoE += "|";
						}
						CoA += _Unit.Arb_Des;
						CoE += _Unit.Eng_Des;
						break;
					}
				}
				FlxInv.Cols[3].ComboList = CoA;
				FlxInv.Cols[5].ComboList = CoE;
			}
			else
			{
				FlxInv.SetData(FlxInv.Row, 1, "");
			}
		}
		private bool ChkBarCod(string BarCod)
		{
			DefPack = 0;
			T_Item _ItmBarCod = new T_Item();
			listItems = db.FillItemBarCode_2(BarCod).ToList();
			for (int iiCnt = 0; iiCnt < listItems.Count; iiCnt++)
			{
				_ItmBarCod = listItems[iiCnt];
				if (BarCod == _ItmBarCod.BarCod1)
				{
					_Items = _ItmBarCod;
					DefPack = 1;
					return true;
				}
				if (BarCod == _ItmBarCod.BarCod2)
				{
					_Items = _ItmBarCod;
					DefPack = 2;
					return true;
				}
				if (BarCod == _ItmBarCod.BarCod3)
				{
					_Items = _ItmBarCod;
					DefPack = 3;
					return true;
				}
				if (BarCod == _ItmBarCod.BarCod4)
				{
					_Items = _ItmBarCod;
					DefPack = 4;
					return true;
				}
				if (BarCod == _ItmBarCod.BarCod5)
				{
					_Items = _ItmBarCod;
					DefPack = 5;
					return true;
				}
			}
			return false;
		}
		private void BindDataOfItem()
		{
			columns_Names_visible2.Clear();
			columns_Names_visible2.Add("Itm_No", new ColumnDictinary("رقم الصنف", "Item No", ifDefault: true, ""));
			columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
			columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, ""));
			columns_Names_visible2.Add("StartCost", new ColumnDictinary("التكلفةالافتتاحية", "Start Cost", ifDefault: false, ""));
			columns_Names_visible2.Add("AvrageCost", new ColumnDictinary("متوسط التكلفة", "Average Cost", ifDefault: false, ""));
			columns_Names_visible2.Add("LastCost", new ColumnDictinary("آخر تكلفة", "Last Cost", ifDefault: false, ""));
			columns_Names_visible2.Add("Arb_Des_Cat", new ColumnDictinary("الاسم العربي لمجموعة الصنف", "CATEGORY Arabic Name", ifDefault: false, ""));
			columns_Names_visible2.Add("Eng_Des_Cat", new ColumnDictinary("الاسم الانجليزي لمجموعة الصنف", "CATEGORY English Name", ifDefault: false, ""));
			List<T_Item> listSer = new List<T_Item>();
			bool Barcod = false;
			List<T_Item> q;
            FrmSearch FmSerch;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection;
            if ((string)FlxInv.GetData(FlxInv.Row, 1) != "" && FlxInv.GetData(FlxInv.Row, 1) != null)
            {
                Barcod = ChkBarCod((string)FlxInv.GetData(FlxInv.Row, 1));
                if (!Barcod || (VarGeneral.SSSLev != "D" && VarGeneral.SSSLev != "G" && VarGeneral.SSSLev != "S" && VarGeneral.SSSLev != "B" && VarGeneral.SSSLev != "F" && VarGeneral.SSSLev != "C" && VarGeneral.SSSLev != "R" && VarGeneral.SSSLev != "H" && VarGeneral.SSSLev != "M"))
                {
                    listSer = db.StockItemList(FlxInv.GetData(FlxInv.Row, 1).ToString());
                    if (listSer.Count != 0)
                    {
                        FillItemDet(_Items = listSer[0], Barcod, FlxInv.Row, 0, 0, 0.0, 0.0);
                    }
                }
            }
            else
            {
                q = (from t in db.T_Items
                     where ((!string.IsNullOrEmpty(data_this.Itm_No)) ? (t.Itm_No != data_this.Itm_No) : true) && !t.InvSaleStoped.Value
                     orderby t.Itm_No
                     select t).ToList();
                if (q.Count == 0)
                {
                    return;
                }
                FmSerch = new FrmSearch();
                VarGeneral.SFrmTyp = "T_Items_Sum";
                FmSerch.Tag = LangArEn;
                VarGeneral.itmDes = data_this.Itm_No;
                animalsAsCollection = columns_Names_visible2;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    FmSerch.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
                }
                FmSerch.TopMost = true;
                FmSerch.ShowDialog();
                VarGeneral.itmDesIndex = 0;
                VarGeneral.itmDes = "";
                if (!(FmSerch.SerachNo != ""))
                {
                    try
                    {
                        FlxInv.RemoveItem(FlxInv.Row);
                        try
                        {
                            FlxInv.Rows.Add();
                        }
                        catch
                        {
                        }
                        FlxInv.Row = FlxInv.RowSel;
                        FlxInv.Col = 1;
                    }
                    catch
                    {
                    }
                    return;
                }
                listSer = db.StockItemList(FmSerch.SerachNo);
                FillItemDet(_Items = listSer[0], Barcod, FlxInv.Row, 0, 0, 0.0, 0.0);
            }
            if ((Barcod && (!(VarGeneral.SSSLev != "D") || !(VarGeneral.SSSLev != "G") || !(VarGeneral.SSSLev != "S") || !(VarGeneral.SSSLev != "B") || !(VarGeneral.SSSLev != "F") || !(VarGeneral.SSSLev != "C") || !(VarGeneral.SSSLev != "R") || !(VarGeneral.SSSLev != "H") || !(VarGeneral.SSSLev != "M"))) || listSer.Count != 0)
            {
                return;
            }
            q = (from t in db.T_Items
                 where t.ItmTyp == (int?)0 && ((!string.IsNullOrEmpty(data_this.Itm_No)) ? (t.Itm_No != data_this.Itm_No) : true) && !t.InvSaleStoped.Value
                 orderby t.Itm_No
                 select t).ToList();
            if (q.Count == 0)
            {
                return;
            }
            FmSerch = new FrmSearch();
            VarGeneral.SFrmTyp = "T_Items_Sum";
            FmSerch.Tag = LangArEn;
            VarGeneral.itmDes = data_this.Itm_No;
            animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                FmSerch.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            FmSerch.TopMost = true;
            FmSerch.ShowDialog();
            VarGeneral.itmDesIndex = 0;
            VarGeneral.itmDes = "";
            if (FmSerch.SerachNo != "")
            {
                listSer = db.StockItemList(FmSerch.SerachNo);
                FillItemDet(_Items = listSer[0], Barcod, FlxInv.Row, 0, 0, 0.0, 0.0);
                return;
            }
            try
            {
                FlxInv.RemoveItem(FlxInv.Row);
                try
                {
                    FlxInv.Rows.Add();
                }
                catch
                {
                }
                FlxInv.Row = FlxInv.RowSel;
                FlxInv.Col = 1;
            }
            catch
            {
            }
        }
        private void FillItemDet(T_Item _Itm, bool Barcod, int vRow, int vUntID, int vStoreNo, double vQty, double vPrice)
		{
			FlxInv.SetData(vRow, 1, _Itm.Itm_No.Trim());
			FlxInv.SetData(vRow, 2, _Itm.Arb_Des.Trim());
			FlxInv.SetData(vRow, 4, _Itm.Eng_Des.Trim());
			FlxInv.SetData(vRow, 6, (vUntID == 0) ? 1 : vStoreNo);
			string CoA = "";
			string CoE = "";
			string DefUnitA = "";
			string DefUnitE = "";
			for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
			{
				_Unit = listUnit[iiCnt];
				if (!((vUntID != 0) ? (vUntID == 1) : (_Itm.Unit1 == _Unit.Unit_ID)))
				{
					continue;
				}
				if (CoA != "")
				{
					CoA += "|";
					CoE += "|";
				}
				CoA += _Unit.Arb_Des;
				CoE += _Unit.Eng_Des;
				if (_Itm.DefultUnit == 1 && DefPack == 0)
				{
					Pack = _Itm.Pack1.Value;
					if (vUntID == 0)
					{
						DefUnitA = _Unit.Arb_Des;
						DefUnitE = _Unit.Eng_Des;
					}
					else
					{
						DefUnitA = _Itm.T_Unit.Arb_Des;
						DefUnitE = _Itm.T_Unit.Eng_Des;
					}
					FlxInv.SetData(vRow, 8, (vUntID == 0) ? _Itm.UntPri1.Value : vPrice);
					FlxInv.SetData(vRow, 11, _Itm.Pack1.Value);
				}
				else if (vUntID != 0 || DefPack == 1)
				{
					Pack = _Itm.Pack1.Value;
					if (vUntID == 0)
					{
						DefUnitA = _Unit.Arb_Des;
						DefUnitE = _Unit.Eng_Des;
					}
					else
					{
						DefUnitA = _Itm.T_Unit.Arb_Des;
						DefUnitE = _Itm.T_Unit.Eng_Des;
					}
					FlxInv.SetData(vRow, 8, (vUntID == 0) ? _Itm.UntPri1.Value : vPrice);
					FlxInv.SetData(vRow, 11, _Itm.Pack1);
				}
				if (vUntID == 0)
				{
				}
				break;
			}
			for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
			{
				_Unit = listUnit[iiCnt];
				if (!((vUntID != 0) ? (vUntID == 2) : (_Itm.Unit2 == _Unit.Unit_ID)))
				{
					continue;
				}
				if (CoA != "")
				{
					CoA += "|";
					CoE += "|";
				}
				CoA += _Unit.Arb_Des;
				CoE += _Unit.Arb_Des;
				if (_Itm.DefultUnit == 2 && DefPack == 0)
				{
					Pack = _Itm.Pack2.Value;
					if (vUntID == 0)
					{
						DefUnitA = _Unit.Arb_Des;
						DefUnitE = _Unit.Eng_Des;
					}
					else
					{
						DefUnitA = _Itm.T_Unit1.Arb_Des;
						DefUnitE = _Itm.T_Unit1.Eng_Des;
					}
					FlxInv.SetData(vRow, 8, (vUntID == 0) ? _Itm.UntPri2.Value : vPrice);
					FlxInv.SetData(vRow, 11, _Itm.Pack2);
				}
				else if (vUntID != 0 || DefPack == 2)
				{
					Pack = _Itm.Pack2.Value;
					if (vUntID == 0)
					{
						DefUnitA = _Unit.Arb_Des;
						DefUnitE = _Unit.Eng_Des;
					}
					else
					{
						DefUnitA = _Itm.T_Unit1.Arb_Des;
						DefUnitE = _Itm.T_Unit1.Eng_Des;
					}
					FlxInv.SetData(vRow, 8, (vUntID == 0) ? _Itm.UntPri2.Value : vPrice);
					FlxInv.SetData(vRow, 11, _Itm.Pack2);
				}
				if (vUntID == 0)
				{
				}
				break;
			}
			for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
			{
				_Unit = listUnit[iiCnt];
				if (!((vUntID != 0) ? (vUntID == 3) : (_Itm.Unit3 == _Unit.Unit_ID)))
				{
					continue;
				}
				if (CoA != "")
				{
					CoA += "|";
					CoE += "|";
				}
				CoA += _Unit.Arb_Des;
				CoE += _Unit.Eng_Des;
				if (_Itm.DefultUnit == 3 && DefPack == 0)
				{
					Pack = _Itm.Pack3.Value;
					if (vUntID == 0)
					{
						DefUnitA = _Unit.Arb_Des;
						DefUnitE = _Unit.Eng_Des;
					}
					else
					{
						DefUnitA = _Itm.T_Unit2.Arb_Des;
						DefUnitE = _Itm.T_Unit2.Eng_Des;
					}
					FlxInv.SetData(vRow, 8, (vUntID == 0) ? _Itm.UntPri3.Value : vPrice);
					FlxInv.SetData(vRow, 11, _Itm.Pack3);
				}
				else if (vUntID != 0 || DefPack == 3)
				{
					Pack = _Itm.Pack3.Value;
					if (vUntID == 0)
					{
						DefUnitA = _Unit.Arb_Des;
						DefUnitE = _Unit.Eng_Des;
					}
					else
					{
						DefUnitA = _Itm.T_Unit2.Arb_Des;
						DefUnitE = _Itm.T_Unit2.Eng_Des;
					}
					FlxInv.SetData(vRow, 8, (vUntID == 0) ? _Itm.UntPri3.Value : vPrice);
					FlxInv.SetData(vRow, 11, _Itm.Pack3);
				}
				if (vUntID == 0)
				{
				}
				break;
			}
			for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
			{
				_Unit = listUnit[iiCnt];
				if (!((vUntID != 0) ? (vUntID == 4) : (_Itm.Unit4 == _Unit.Unit_ID)))
				{
					continue;
				}
				if (CoA != "")
				{
					CoA += "|";
					CoE += "|";
				}
				CoA += _Unit.Arb_Des;
				CoE += _Unit.Eng_Des;
				if (_Itm.DefultUnit == 4 && DefPack == 0)
				{
					Pack = _Itm.Pack4.Value;
					if (vUntID == 0)
					{
						DefUnitA = _Unit.Arb_Des;
						DefUnitE = _Unit.Eng_Des;
					}
					else
					{
						DefUnitA = _Itm.T_Unit3.Arb_Des;
						DefUnitE = _Itm.T_Unit3.Eng_Des;
					}
					FlxInv.SetData(vRow, 8, (vUntID == 0) ? _Itm.UntPri4.Value : vPrice);
					FlxInv.SetData(vRow, 11, _Itm.Pack4);
				}
				else if (vUntID != 0 || DefPack == 4)
				{
					Pack = _Itm.Pack4.Value;
					if (vUntID == 0)
					{
						DefUnitA = _Unit.Arb_Des;
						DefUnitE = _Unit.Eng_Des;
					}
					else
					{
						DefUnitA = _Itm.T_Unit3.Arb_Des;
						DefUnitE = _Itm.T_Unit3.Eng_Des;
					}
					FlxInv.SetData(vRow, 8, (vUntID == 0) ? _Itm.UntPri4.Value : vPrice);
					FlxInv.SetData(vRow, 11, _Itm.Pack4);
				}
				if (vUntID == 0)
				{
				}
				break;
			}
			for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
			{
				_Unit = listUnit[iiCnt];
				if (!((vUntID != 0) ? (vUntID == 5) : (_Itm.Unit5 == _Unit.Unit_ID)))
				{
					continue;
				}
				if (CoA != "")
				{
					CoA += "|";
					CoE += "|";
				}
				CoA += _Unit.Arb_Des;
				CoE += _Unit.Eng_Des;
				if (_Itm.DefultUnit == 5 && DefPack == 0)
				{
					Pack = _Itm.Pack5.Value;
					if (vUntID == 0)
					{
						DefUnitA = _Unit.Arb_Des;
						DefUnitE = _Unit.Eng_Des;
					}
					else
					{
						DefUnitA = _Itm.T_Unit4.Arb_Des;
						DefUnitE = _Itm.T_Unit4.Eng_Des;
					}
					FlxInv.SetData(vRow, 8, (vUntID == 0) ? _Itm.UntPri5.Value : vPrice);
					FlxInv.SetData(vRow, 11, _Itm.Pack5);
				}
				else if (vUntID != 0 || DefPack == 5)
				{
					Pack = _Itm.Pack5.Value;
					if (vUntID == 0)
					{
						DefUnitA = _Unit.Arb_Des;
						DefUnitE = _Unit.Eng_Des;
					}
					else
					{
						DefUnitA = _Itm.T_Unit4.Arb_Des;
						DefUnitE = _Itm.T_Unit4.Eng_Des;
					}
					FlxInv.SetData(vRow, 8, (vUntID == 0) ? _Itm.UntPri5.Value : vPrice);
					FlxInv.SetData(vRow, 11, _Itm.Pack5);
				}
				if (vUntID == 0)
				{
				}
				break;
			}
			FlxInv.Cols[3].ComboList = CoA;
			FlxInv.Cols[5].ComboList = CoE;
			double ItmPri = 0.0;
			FlxInv.SetData(vRow, 3, DefUnitA);
			FlxInv.SetData(vRow, 5, DefUnitE);
			FlxInv.SetData(vRow, 10, _Itm.AvrageCost * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(vRow, 11)))) / RateValue);
			FlxInv.SetData(vRow, 30, _Itm.LastCost * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(vRow, 11)))) / RateValue);
			FlxInv.SetData(vRow, 28, _Itm.Lot);
			FlxInv.SetData(vRow, 32, _Itm.ItmTyp);
			FlxInv.SetData(vRow, 33, _Itm.ItmLoc);
			FlxInv.SetData(vRow, 18, _Itm.DefPack);
			FlxInv.SetData(vRow, 19, _Itm.Price1);
			FlxInv.SetData(vRow, 20, _Itm.Price2);
			FlxInv.SetData(vRow, 21, _Itm.Price3);
			FlxInv.SetData(vRow, 22, _Itm.Price4);
			FlxInv.SetData(vRow, 23, _Itm.Price5);
			FlxInv.SetData(vRow, 8, 1);
			PriceLoc = 1.0;
			FlxInv.SetData(vRow, 7, (vUntID == 0) ? 0.0 : vQty);
			FlxInv.SetData(vRow, 12, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(vRow, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(vRow, 11)))));
			FlxInv.SetData(vRow, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(vRow, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(vRow, 8)))));
			GetInvTot();
			chekRept();
			VarGeneral.Flush();
		}
		private void chekRept()
		{
			if (State == FormState.Saved || FlxInv.ColSel != 1)
			{
				return;
			}
			for (int iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
			{
				if (!string.IsNullOrEmpty(string.Concat(FlxInv.GetData(iiCnt, 1))) && iiCnt != FlxInv.RowSel && FlxInv.GetData(iiCnt, 1).ToString() == FlxInv.GetData(FlxInv.RowSel, 1).ToString())
				{
					MessageBox.Show((LangArEn == 0) ? "تنبيه .. لقد قمت بأدخال هذا الصنف مسبقا\u064b في هذه الفاتورة" : "Alert .. You have entered already this product in this bill", VarGeneral.ProdectNam);
					break;
				}
			}
		}
		private bool chekReptItem(bool Col_1)
		{
			if (State != 0 && (FlxInv.ColSel == 31 || FlxInv.ColSel == 7 || FlxInv.ColSel == 8 || Col_1) && VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 17))
			{
				double vQty = 0.0;
				try
				{
					vQty = double.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(FlxInv.RowSel, 7).ToString()));
				}
				catch
				{
					vQty = 0.0;
				}
				for (int iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
				{
					if (!string.IsNullOrEmpty(string.Concat(FlxInv.GetData(iiCnt, 1))) && iiCnt != FlxInv.RowSel && FlxInv.GetData(iiCnt, 1).ToString() == FlxInv.GetData(FlxInv.RowSel, 1).ToString() && FlxInv.GetData(iiCnt, 11).ToString() == FlxInv.GetData(FlxInv.RowSel, 11).ToString() && FlxInv.GetData(iiCnt, 6).ToString() == FlxInv.GetData(FlxInv.RowSel, 6).ToString())
					{
						try
						{
							FlxInv.SetData(FlxInv.RowSel, 7, double.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 7).ToString() ?? "")) + vQty);
						}
						catch
						{
							FlxInv.SetData(FlxInv.RowSel, 7, 0);
							FlxInv.SetData(FlxInv.RowSel, 12, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 11)))));
							FlxInv.SetData(FlxInv.RowSel, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 8)))));
							goto IL_042b;
						}
						FlxInv.SetData(iiCnt, 7, double.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 7).ToString() ?? "")) + vQty);
						if (FlxInv.RowSel > 0)
						{
							FlxInv.RemoveItem(FlxInv.Row);
							FlxInv.SetData(iiCnt, 12, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 11)))));
							FlxInv.SetData(iiCnt, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))));
							GetInvTot();
							FlxInv.Row = FlxInv.RowSel;
							FlxInv.Col = 0;
						}
						return true;
					}
				}
			}
			goto IL_042b;
			IL_042b:
			return false;
		}
		private void c1FlexGrid_Items_Click(object sender, EventArgs e)
		{
			Button_Edit_Click(sender, e);
		}
		private void txtBarCode1_GotFocus(object sender, EventArgs e)
		{
			Button_Edit_Click(sender, e);
		}
		private void buttonItem_Serials_Click(object sender, EventArgs e)
		{
			if (State != 0)
			{
				return;
			}
			try
			{
				if (string.IsNullOrEmpty(textBox_ID.Text))
				{
					return;
				}
			}
			catch
			{
				return;
			}
			if (!VarGeneral.TString.ChkStatShow(permission.SetStr, 39))
			{
				MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
            FrmSerials form1 = new FrmSerials();
            form1.vitemNo = textBox_ID.Text;
            form1.Tag = LangArEn.ToString();
            form1.TopMost = true;
            form1.ShowDialog();
        }
		private void button_DeleteFromSystem_Click(object sender, EventArgs e)
		{
			if (VarGeneral.UserID != 1)
			{
				MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				if (State != 0)
				{
					return;
				}
				try
				{
					if (string.IsNullOrEmpty(textBox_ID.Text))
					{
						return;
					}
				}
				catch
				{
					return;
				}
				if (MessageBox.Show("سيتم إزالة هذا الصنف بشكل نهائي من النظام .. هل تريد المتابعة؟ \n This Item will be permanently removed from the system .. Continue ?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
				{
					return;
				}
				var Query = (from p in db.T_INVHEDs
					join c in db.T_INVDETs on p.InvHed_ID equals c.InvId into j1
					from j2 in j1.DefaultIfEmpty()
					where p.IfDel.Value == 1 && j2.ItmNo == data_this.Itm_No
					group new
					{
						j2,
						j1
					} by new
					{
						p.InvHed_ID,
						p.InvNo,
						p.InvTyp,
						j2.ItmNo,
						j2.InvDet_ID,
						j2.InvId,
						p.GadeId
					} into grouped
					orderby grouped.Key.InvHed_ID
					select new
					{
						grouped.Key.InvHed_ID,
						grouped.Key.GadeId
					}).Distinct().ToList();
				if (Query.Count > 0)
				{
					for (int i = 0; i < Query.Count; i++)
					{
						db.ExecuteCommand("DELETE FROM [dbo].[T_SINVDET] WHERE SInvIdHEAD = " + Query[i].InvHed_ID);
						db.ExecuteCommand("DELETE FROM [dbo].[T_INVDET] WHERE InvId = " + Query[i].InvHed_ID);
						db.ExecuteCommand("DELETE FROM [dbo].[T_INVHED] WHERE InvHed_ID = " + Query[i].InvHed_ID);
						try
						{
							if (Query[i].GadeId.HasValue)
							{
								db.ExecuteCommand("DELETE FROM [dbo].[T_GDDET] WHERE gdID = " + Query[i].GadeId.Value);
								db.ExecuteCommand("DELETE FROM [dbo].[T_GDHEAD] WHERE gdhead_ID = " + Query[i].GadeId.Value);
							}
						}
						catch
						{
						}
					}
					db.ExecuteCommand("DELETE FROM [dbo].[T_STKSQTY] WHERE itmNo = '" + data_this.Itm_No + "'");
					db.ExecuteCommand("DELETE FROM [dbo].[T_QTYEXP] WHERE itmNo = '" + data_this.Itm_No + "'");
					db.ExecuteCommand("DELETE FROM [dbo].[T_StoreMnd] WHERE itmNo = '" + data_this.Itm_No + "'");
					ifOkDelete = true;
					Button_Delete_Click(sender, e);
				}
				else
				{
					button_DeleteFromSystem.Visible = false;
					Button_Delete_Click(sender, e);
					button_DeleteFromSystem.Visible = true;
				}
			}
		}
		private void button_DeleteFromSystem_VisibleChanged(object sender, EventArgs e)
		{
			if (button_DeleteFromSystem.Visible)
			{
				Button_Delete.Visible = false;
			}
			superTabControl_Main1.Refresh();
		}
		private void doubleInput_DefPack_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
			{
				e.Handled = true;
			}
		}
		private void doubleInput_DefPack_Click(object sender, EventArgs e)
		{
			doubleInput_DefPack.SelectAll();
		}
		private void buttonItem_EditPriceAll_Click(object sender, EventArgs e)
		{
			try
			{
				if (!VarGeneral.TString.ChkStatShow(permission.SetStr, 5))
				{
					MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else if (State == FormState.Saved)
				{
					//FrmEditItemsPricesAll form1 = new FrmEditItemsPricesAll();
					//form1.Tag = LangArEn.ToString();
					//form1.TopMost = true;
					//form1.ShowDialog();
					//dbInstance = null;
					//textBox_ID_TextChanged(sender, e);
				}
			}
			catch (Exception error)
			{
				VarGeneral.DebLog.writeLog("buttonItem_EditPriceAll_Click:", error, enable: true);
				MessageBox.Show(error.Message);
			}
		}
		private void buttonItem_AddDisProcess_Click(object sender, EventArgs e)
		{
			try
			{
				if (!VarGeneral.TString.ChkStatShow(permission.SetStr, 47))
				{
					MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					if (State != 0)
					{
						return;
					}
					try
					{
						if (string.IsNullOrEmpty(textBox_ID.Text))
						{
							return;
						}
					}
					catch
					{
						return;
					}
					//FrmGeneralPriceAddation form1 = new FrmGeneralPriceAddation();
					//form1.Tag = LangArEn.ToString();
					//form1.StartPosition = FormStartPosition.CenterScreen;
					//form1.TopMost = true;
					//form1.ShowDialog();
					//dbInstance = null;
					//textBox_ID_TextChanged(sender, e);
					return;
				}
			}
			catch (Exception error)
			{
				VarGeneral.DebLog.writeLog("buttonItem_EditPrice_Click:", error, enable: true);
				MessageBox.Show(error.Message);
			}
		}
		private void txtFiled1_Click(object sender, EventArgs e)
		{
			txtFiled1.SelectAll();
		}
		private void txtFiled2_Click(object sender, EventArgs e)
		{
			txtFiled2.SelectAll();
		}
		private void txtFiled3_Click(object sender, EventArgs e)
		{
			txtFiled3.SelectAll();
		}
		private void txtFiled4_Click(object sender, EventArgs e)
		{
			txtFiled4.SelectAll();
		}
		private void txtFiled5_Click(object sender, EventArgs e)
		{
			txtFiled5.SelectAll();
		}
		private void txtFiled6_Click(object sender, EventArgs e)
		{
			txtFiled6.SelectAll();
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmItems));
            DevComponents.DotNetBar.Rendering.SuperTabPanelColorTable superTabPanelColorTable2 = new DevComponents.DotNetBar.Rendering.SuperTabPanelColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabPanelItemColorTable superTabPanelItemColorTable2 = new DevComponents.DotNetBar.Rendering.SuperTabPanelItemColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabItemColorTable superTabItemColorTable2 = new DevComponents.DotNetBar.Rendering.SuperTabItemColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabColorStates superTabColorStates2 = new DevComponents.DotNetBar.Rendering.SuperTabColorStates();
            DevComponents.DotNetBar.Rendering.SuperTabItemStateColorTable superTabItemStateColorTable2 = new DevComponents.DotNetBar.Rendering.SuperTabItemStateColorTable();
            DevComponents.DotNetBar.SuperGrid.Style.Background background1 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background2 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background3 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.BorderColor borderColor1 = new DevComponents.DotNetBar.SuperGrid.Style.BorderColor();
            DevComponents.DotNetBar.SuperGrid.Style.BorderColor borderColor2 = new DevComponents.DotNetBar.SuperGrid.Style.BorderColor();
            DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle baseTreeButtonVisualStyle1 = new DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle();
            DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle baseTreeButtonVisualStyle2 = new DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle();
            DevComponents.DotNetBar.SuperGrid.Style.Background background4 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.Rendering.SuperTabPanelColorTable superTabPanelColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabPanelColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabPanelItemColorTable superTabPanelItemColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabPanelItemColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable superTabLinearGradientColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabItemColorTable superTabItemColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabItemColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabColorStates superTabColorStates1 = new DevComponents.DotNetBar.Rendering.SuperTabColorStates();
            DevComponents.DotNetBar.Rendering.SuperTabItemStateColorTable superTabItemStateColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabItemStateColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable superTabLinearGradientColorTable2 = new DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable();
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.buttonItem6 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem5 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem4 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.ToolStripMenuItem_Rep = new System.Windows.Forms.ToolStripMenuItem();
            this.ribbonBar_Units = new DevComponents.DotNetBar.RibbonBar();
            this.c1BarCode1 = new C1.Win.C1BarCode.C1BarCode();
            this.superTabControl1 = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.checkBoxX_Points = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxX_BarcodeBalance = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label5 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox_DisItem = new DevComponents.Editors.DoubleInput();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox_TaxPurchase = new DevComponents.Editors.DoubleInput();
            this.label15 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_TaxSales = new DevComponents.Editors.DoubleInput();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_CommItm = new DevComponents.Editors.DoubleInput();
            this.textBox_SerialKey = new System.Windows.Forms.TextBox();
            this.c1FlexGrid_Items = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.button_SrchCustNo = new DevComponents.DotNetBar.ButtonX();
            this.txtCustNo = new System.Windows.Forms.TextBox();
            this.pictureBox_PicItem = new DevComponents.DotNetBar.Controls.ReflectionImage();
            this.combobox_ItmeGroup = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.textbox_MaxQty = new DevComponents.Editors.DoubleInput();
            this.label23 = new System.Windows.Forms.Label();
            this.textbox_Supreme = new DevComponents.Editors.DoubleInput();
            this.label3 = new System.Windows.Forms.Label();
            this.button_ClearPic = new DevComponents.DotNetBar.ButtonX();
            this.button_AddNewCat = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchItemGroup = new DevComponents.DotNetBar.ButtonX();
            this.textbox_Eng_Des = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textbox_Arb_Des = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.button_EnterImg = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel_Inv = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.button_DeleteFromSystem = new DevComponents.DotNetBar.ButtonX();
            this.checkBoxX_InvOut = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxX_InvEnter = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxX_InvPaymentReturn = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxX_InvPayment = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxX_ReturnInvSale = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxX_InvSale = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.doubleInput_DefPack = new System.Windows.Forms.TextBox();
            this.comboBox_DefPack = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.superTabItem_General = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.FlxInv = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.superTabItem_Details = new DevComponents.DotNetBar.SuperTabItem();
            this.expandablePanel_AnotherPrice = new DevComponents.DotNetBar.ExpandablePanel();
            this.panelEx_Size = new DevComponents.DotNetBar.PanelEx();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtFiled2 = new System.Windows.Forms.TextBox();
            this.txtFiled3 = new System.Windows.Forms.TextBox();
            this.txtFiled6 = new System.Windows.Forms.TextBox();
            this.txtFiled5 = new System.Windows.Forms.TextBox();
            this.txtFiled4 = new System.Windows.Forms.TextBox();
            this.txtFiled1 = new System.Windows.Forms.TextBox();
            this.labelFiled6 = new System.Windows.Forms.Label();
            this.labelFiled3 = new System.Windows.Forms.Label();
            this.labelFiled1 = new System.Windows.Forms.Label();
            this.labelFiled2 = new System.Windows.Forms.Label();
            this.labelFiled5 = new System.Windows.Forms.Label();
            this.labelFiled4 = new System.Windows.Forms.Label();
            this.textbox_Sentence = new DevComponents.Editors.DoubleInput();
            this.label28 = new System.Windows.Forms.Label();
            this.textbox_Legates = new DevComponents.Editors.DoubleInput();
            this.textbox_Distributors = new DevComponents.Editors.DoubleInput();
            this.label24 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.textbox_VIP = new DevComponents.Editors.DoubleInput();
            this.label26 = new System.Windows.Forms.Label();
            this.textbox_Sectorial = new DevComponents.Editors.DoubleInput();
            this.label25 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textbox_DateNo = new DevComponents.Editors.IntegerInput();
            this.combobox_DateTyp = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.sideBar_Units = new DevComponents.DotNetBar.SideBar();
            this.sideBarPanelItem_Unit1 = new DevComponents.DotNetBar.SideBarPanelItem();
            this.labelItem4 = new DevComponents.DotNetBar.LabelItem();
            this.comboboxItems_Unit1 = new DevComponents.DotNetBar.ComboBoxItem();
            this.labelItem5 = new DevComponents.DotNetBar.LabelItem();
            this.textbox_Pack1 = new DevComponents.DotNetBar.TextBoxItem();
            this.labelItem30 = new DevComponents.DotNetBar.LabelItem();
            this.textbox_SelPri1 = new DevComponents.DotNetBar.TextBoxItem();
            this.labelItem6 = new DevComponents.DotNetBar.LabelItem();
            this.textbox_Qty1 = new DevComponents.DotNetBar.TextBoxItem();
            this.labelItem7 = new DevComponents.DotNetBar.LabelItem();
            this.textbox_Cost1 = new DevComponents.DotNetBar.TextBoxItem();
            this.labelItem8 = new DevComponents.DotNetBar.LabelItem();
            this.txtBarCode1 = new DevComponents.DotNetBar.TextBoxItem();
            this.radiobutton_RButDef1 = new DevComponents.DotNetBar.CheckBoxItem();
            this.sideBarPanelItem_Unit2 = new DevComponents.DotNetBar.SideBarPanelItem();
            this.labelItem9 = new DevComponents.DotNetBar.LabelItem();
            this.comboboxItems_Unit2 = new DevComponents.DotNetBar.ComboBoxItem();
            this.labelItem11 = new DevComponents.DotNetBar.LabelItem();
            this.textbox_Pack2 = new DevComponents.DotNetBar.TextBoxItem();
            this.labelItem31 = new DevComponents.DotNetBar.LabelItem();
            this.textbox_SelPri2 = new DevComponents.DotNetBar.TextBoxItem();
            this.labelItem12 = new DevComponents.DotNetBar.LabelItem();
            this.textbox_Qty2 = new DevComponents.DotNetBar.TextBoxItem();
            this.labelItem13 = new DevComponents.DotNetBar.LabelItem();
            this.textbox_Cost2 = new DevComponents.DotNetBar.TextBoxItem();
            this.labelItem10 = new DevComponents.DotNetBar.LabelItem();
            this.txtBarCode2 = new DevComponents.DotNetBar.TextBoxItem();
            this.radiobutton_RButDef2 = new DevComponents.DotNetBar.CheckBoxItem();
            this.sideBarPanelItem_Unit3 = new DevComponents.DotNetBar.SideBarPanelItem();
            this.labelItem14 = new DevComponents.DotNetBar.LabelItem();
            this.comboboxItems_Unit3 = new DevComponents.DotNetBar.ComboBoxItem();
            this.labelItem16 = new DevComponents.DotNetBar.LabelItem();
            this.textbox_Pack3 = new DevComponents.DotNetBar.TextBoxItem();
            this.labelItem32 = new DevComponents.DotNetBar.LabelItem();
            this.textbox_SelPri3 = new DevComponents.DotNetBar.TextBoxItem();
            this.labelItem17 = new DevComponents.DotNetBar.LabelItem();
            this.textbox_Qty3 = new DevComponents.DotNetBar.TextBoxItem();
            this.labelItem18 = new DevComponents.DotNetBar.LabelItem();
            this.textbox_Cost3 = new DevComponents.DotNetBar.TextBoxItem();
            this.labelItem15 = new DevComponents.DotNetBar.LabelItem();
            this.txtBarCode3 = new DevComponents.DotNetBar.TextBoxItem();
            this.radiobutton_RButDef3 = new DevComponents.DotNetBar.CheckBoxItem();
            this.sideBarPanelItem_Unit4 = new DevComponents.DotNetBar.SideBarPanelItem();
            this.labelItem19 = new DevComponents.DotNetBar.LabelItem();
            this.comboboxItems_Unit4 = new DevComponents.DotNetBar.ComboBoxItem();
            this.labelItem21 = new DevComponents.DotNetBar.LabelItem();
            this.textbox_Pack4 = new DevComponents.DotNetBar.TextBoxItem();
            this.labelItem33 = new DevComponents.DotNetBar.LabelItem();
            this.textbox_SelPri4 = new DevComponents.DotNetBar.TextBoxItem();
            this.labelItem22 = new DevComponents.DotNetBar.LabelItem();
            this.textbox_Qty4 = new DevComponents.DotNetBar.TextBoxItem();
            this.labelItem23 = new DevComponents.DotNetBar.LabelItem();
            this.textbox_Cost4 = new DevComponents.DotNetBar.TextBoxItem();
            this.labelItem20 = new DevComponents.DotNetBar.LabelItem();
            this.txtBarCode4 = new DevComponents.DotNetBar.TextBoxItem();
            this.radiobutton_RButDef4 = new DevComponents.DotNetBar.CheckBoxItem();
            this.sideBarPanelItem_Unit5 = new DevComponents.DotNetBar.SideBarPanelItem();
            this.labelItem24 = new DevComponents.DotNetBar.LabelItem();
            this.comboboxItems_Unit5 = new DevComponents.DotNetBar.ComboBoxItem();
            this.labelItem26 = new DevComponents.DotNetBar.LabelItem();
            this.textbox_Pack5 = new DevComponents.DotNetBar.TextBoxItem();
            this.labelItem34 = new DevComponents.DotNetBar.LabelItem();
            this.textbox_SelPri5 = new DevComponents.DotNetBar.TextBoxItem();
            this.labelItem27 = new DevComponents.DotNetBar.LabelItem();
            this.textbox_Qty5 = new DevComponents.DotNetBar.TextBoxItem();
            this.labelItem28 = new DevComponents.DotNetBar.LabelItem();
            this.textbox_Cost5 = new DevComponents.DotNetBar.TextBoxItem();
            this.labelItem25 = new DevComponents.DotNetBar.LabelItem();
            this.txtBarCode5 = new DevComponents.DotNetBar.TextBoxItem();
            this.radiobutton_RButDef5 = new DevComponents.DotNetBar.CheckBoxItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_Det = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.DGV_Main = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.ribbonBar_DGV = new DevComponents.DotNetBar.RibbonBar();
            this.superTabControl_DGV = new DevComponents.DotNetBar.SuperTabControl();
            this.textBox_search = new DevComponents.DotNetBar.TextBoxItem();
            this.Button_ExportTable2 = new DevComponents.DotNetBar.ButtonItem();
            this.Button_PrintTable = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem3 = new DevComponents.DotNetBar.LabelItem();
            this.buttonItem7 = new DevComponents.DotNetBar.ButtonItem();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.ribbonBar_Tasks = new DevComponents.DotNetBar.RibbonBar();
            this.superTabControl_Main1 = new DevComponents.DotNetBar.SuperTabControl();
            this.buttonItem_x = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem_EditPriceAll = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem_EditPrice = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem_AddDisProcess = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Close = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Search = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Delete = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Save = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Add = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem2 = new DevComponents.DotNetBar.LabelItem();
            this.buttonItem_Serials = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem8 = new DevComponents.DotNetBar.ButtonItem();
            this.superTabControl_Main2 = new DevComponents.DotNetBar.SuperTabControl();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.Button_First = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Prev = new DevComponents.DotNetBar.ButtonItem();
            this.TextBox_Index = new DevComponents.DotNetBar.TextBoxItem();
            this.Label_Count = new DevComponents.DotNetBar.LabelItem();
            this.lable_Records = new DevComponents.DotNetBar.LabelItem();
            this.Button_Next = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Last = new DevComponents.DotNetBar.ButtonItem();
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.superTabItem1 = new DevComponents.DotNetBar.SuperTabItem();
            this.txtCurr = new System.Windows.Forms.TextBox();
            this.combobox_Unit5 = new System.Windows.Forms.ComboBox();
            this.combobox_Unit4 = new System.Windows.Forms.ComboBox();
            this.combobox_Unit3 = new System.Windows.Forms.ComboBox();
            this.combobox_Unit2 = new System.Windows.Forms.ComboBox();
            this.combobox_Unit1 = new System.Windows.Forms.ComboBox();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.prnt_doc = new System.Drawing.Printing.PrintDocument();
            this.prnt_prev = new System.Windows.Forms.PrintPreviewDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.panel2 = new System.Windows.Forms.Panel();
            this.metroStatusBar_itemsType = new DevComponents.DotNetBar.Metro.MetroStatusBar();
            this.labelItem29 = new DevComponents.DotNetBar.LabelItem();
            this.radioButton_Goods = new DevComponents.DotNetBar.CheckBoxItem();
            this.radioButton_RawMaterial = new DevComponents.DotNetBar.CheckBoxItem();
            this.radioButton_Service = new DevComponents.DotNetBar.CheckBoxItem();
            this.radioButton_Product = new DevComponents.DotNetBar.CheckBoxItem();
            this.superTabControl_Info = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel3 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label30 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.superTabItem_items = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel7 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.textBoxX6 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label53 = new System.Windows.Forms.Label();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.label56 = new System.Windows.Forms.Label();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.superTabItem5 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel6 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.textBoxX5 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label43 = new System.Windows.Forms.Label();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label51 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.superTabItem4 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel5 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.textBoxX3 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label37 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.superTabItem3 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel4 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.textBoxX2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label31 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.superTabItem2 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel12 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.ribbonBar_Units.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_DisItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_TaxPurchase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_TaxSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_CommItm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid_Items)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textbox_MaxQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textbox_Supreme)).BeginInit();
            this.groupPanel_Inv.SuspendLayout();
            this.superTabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlxInv)).BeginInit();
            this.expandablePanel_AnotherPrice.SuspendLayout();
            this.panelEx_Size.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textbox_Sentence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textbox_Legates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textbox_Distributors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textbox_VIP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textbox_Sectorial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textbox_DateNo)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.panelEx3.SuspendLayout();
            this.ribbonBar_DGV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_DGV)).BeginInit();
            this.panelEx2.SuspendLayout();
            this.ribbonBar_Tasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Info)).BeginInit();
            this.superTabControl_Info.SuspendLayout();
            this.superTabControlPanel3.SuspendLayout();
            this.superTabControlPanel7.SuspendLayout();
            this.superTabControlPanel6.SuspendLayout();
            this.superTabControlPanel5.SuspendLayout();
            this.superTabControlPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabItem1
            // 
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "البيانات الوظيفيـــة";
            // 
            // buttonItem6
            // 
            this.buttonItem6.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem6.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem6.Image")));
            this.buttonItem6.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.buttonItem6.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem6.Name = "buttonItem6";
            this.buttonItem6.Stretch = true;
            this.buttonItem6.SubItemsExpandWidth = 14;
            this.buttonItem6.Text = "إغلاق";
            this.buttonItem6.Tooltip = "إغلاق النافذة الحالية";
            // 
            // buttonItem5
            // 
            this.buttonItem5.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem5.Image")));
            this.buttonItem5.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.buttonItem5.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem5.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.buttonItem5.Name = "buttonItem5";
            this.buttonItem5.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem2});
            this.buttonItem5.SubItemsExpandWidth = 14;
            this.buttonItem5.Text = "بحـــث";
            this.buttonItem5.Tooltip = "البحث عن سجل";
            // 
            // buttonItem2
            // 
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.Text = "buttonItem2";
            // 
            // buttonItem4
            // 
            this.buttonItem4.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem4.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem4.Image")));
            this.buttonItem4.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.buttonItem4.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem4.Name = "buttonItem4";
            this.buttonItem4.Stretch = true;
            this.buttonItem4.SubItemsExpandWidth = 14;
            this.buttonItem4.Text = "حذف";
            this.buttonItem4.Tooltip = "حذف السجل الحالي";
            // 
            // buttonItem3
            // 
            this.buttonItem3.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem3.HotForeColor = System.Drawing.Color.Firebrick;
            this.buttonItem3.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem3.Image")));
            this.buttonItem3.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.buttonItem3.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem3.Name = "buttonItem3";
            this.buttonItem3.Stretch = true;
            this.buttonItem3.SubItemsExpandWidth = 14;
            this.buttonItem3.Text = "حفظ";
            this.buttonItem3.Tooltip = "حفظ التغييرات";
            // 
            // buttonItem1
            // 
            this.buttonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem1.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem1.Image")));
            this.buttonItem1.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.buttonItem1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Stretch = true;
            this.buttonItem1.SubItemsExpandWidth = 14;
            this.buttonItem1.Text = "جديد";
            this.buttonItem1.Tooltip = " سجل جديد";
            // 
            // ToolStripMenuItem_Rep
            // 
            this.ToolStripMenuItem_Rep.Checked = true;
            this.ToolStripMenuItem_Rep.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToolStripMenuItem_Rep.Name = "ToolStripMenuItem_Rep";
            this.ToolStripMenuItem_Rep.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItem_Rep.Text = "إظهار التقرير";
            // 
            // ribbonBar_Units
            // 
            this.ribbonBar_Units.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar_Units.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar_Units.BackgroundStyle.BackColor = System.Drawing.Color.Silver;
            this.ribbonBar_Units.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            this.ribbonBar_Units.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar_Units.ContainerControlProcessDialogKey = true;
            this.ribbonBar_Units.Controls.Add(this.expandablePanel_AnotherPrice);
            this.ribbonBar_Units.Controls.Add(this.c1BarCode1);
            this.ribbonBar_Units.Controls.Add(this.superTabControl1);
            this.ribbonBar_Units.Controls.Add(this.label1);
            this.ribbonBar_Units.Controls.Add(this.textbox_DateNo);
            this.ribbonBar_Units.Controls.Add(this.combobox_DateTyp);
            this.ribbonBar_Units.Controls.Add(this.sideBar_Units);
            this.ribbonBar_Units.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar_Units.Location = new System.Drawing.Point(0, 79);
            this.ribbonBar_Units.Name = "ribbonBar_Units";
            this.ribbonBar_Units.Size = new System.Drawing.Size(1282, 448);
            this.ribbonBar_Units.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar_Units.TabIndex = 867;
            // 
            // 
            // 
            this.ribbonBar_Units.TitleStyle.BackColor = System.Drawing.Color.Black;
            this.ribbonBar_Units.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.ribbonBar_Units.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar_Units.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // c1BarCode1
            // 
            this.c1BarCode1.BarWide = 1;
            this.c1BarCode1.CodeType = C1.Win.C1BarCode.CodeTypeEnum.Code128;
            this.c1BarCode1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.c1BarCode1.Location = new System.Drawing.Point(1371, -1);
            this.c1BarCode1.Name = "c1BarCode1";
            this.c1BarCode1.ShowText = true;
            this.c1BarCode1.Size = new System.Drawing.Size(142, 40);
            this.c1BarCode1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.c1BarCode1.TabIndex = 922;
            this.c1BarCode1.Text = "1225";
            // 
            // superTabControl1
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl1.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl1.ControlBox.MenuBox.Name = "";
            this.superTabControl1.ControlBox.MenuBox.Visible = false;
            this.superTabControl1.ControlBox.Name = "";
            this.superTabControl1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl1.ControlBox.MenuBox,
            this.superTabControl1.ControlBox.CloseBox});
            this.superTabControl1.Controls.Add(this.superTabControlPanel1);
            this.superTabControl1.Controls.Add(this.superTabControlPanel2);
            this.superTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl1.Location = new System.Drawing.Point(308, 0);
            this.superTabControl1.Name = "superTabControl1";
            this.superTabControl1.ReorderTabsEnabled = true;
            this.superTabControl1.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabControl1.SelectedTabIndex = 0;
            this.superTabControl1.Size = new System.Drawing.Size(974, 431);
            this.superTabControl1.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl1.TabIndex = 1569;
            this.superTabControl1.TabLayoutType = DevComponents.DotNetBar.eSuperTabLayoutType.MultiLineFit;
            this.superTabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem_General,
            this.superTabItem_Details});
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.panel2);
            this.superTabControlPanel1.Controls.Add(this.checkBoxX_Points);
            this.superTabControlPanel1.Controls.Add(this.checkBoxX_BarcodeBalance);
            this.superTabControlPanel1.Controls.Add(this.label5);
            this.superTabControlPanel1.Controls.Add(this.label16);
            this.superTabControlPanel1.Controls.Add(this.textBox_DisItem);
            this.superTabControlPanel1.Controls.Add(this.label11);
            this.superTabControlPanel1.Controls.Add(this.label8);
            this.superTabControlPanel1.Controls.Add(this.label14);
            this.superTabControlPanel1.Controls.Add(this.textBox_TaxPurchase);
            this.superTabControlPanel1.Controls.Add(this.label15);
            this.superTabControlPanel1.Controls.Add(this.label9);
            this.superTabControlPanel1.Controls.Add(this.textBox_TaxSales);
            this.superTabControlPanel1.Controls.Add(this.label13);
            this.superTabControlPanel1.Controls.Add(this.label10);
            this.superTabControlPanel1.Controls.Add(this.textBox_CommItm);
            this.superTabControlPanel1.Controls.Add(this.textBox_SerialKey);
            this.superTabControlPanel1.Controls.Add(this.c1FlexGrid_Items);
            this.superTabControlPanel1.Controls.Add(this.labelX1);
            this.superTabControlPanel1.Controls.Add(this.button_SrchCustNo);
            this.superTabControlPanel1.Controls.Add(this.txtCustNo);
            this.superTabControlPanel1.Controls.Add(this.pictureBox_PicItem);
            this.superTabControlPanel1.Controls.Add(this.combobox_ItmeGroup);
            this.superTabControlPanel1.Controls.Add(this.textbox_MaxQty);
            this.superTabControlPanel1.Controls.Add(this.label23);
            this.superTabControlPanel1.Controls.Add(this.textbox_Supreme);
            this.superTabControlPanel1.Controls.Add(this.label3);
            this.superTabControlPanel1.Controls.Add(this.button_ClearPic);
            this.superTabControlPanel1.Controls.Add(this.button_AddNewCat);
            this.superTabControlPanel1.Controls.Add(this.button_SrchItemGroup);
            this.superTabControlPanel1.Controls.Add(this.textbox_Eng_Des);
            this.superTabControlPanel1.Controls.Add(this.label12);
            this.superTabControlPanel1.Controls.Add(this.label4);
            this.superTabControlPanel1.Controls.Add(this.label2);
            this.superTabControlPanel1.Controls.Add(this.textbox_Arb_Des);
            this.superTabControlPanel1.Controls.Add(this.label6);
            this.superTabControlPanel1.Controls.Add(this.textBox_ID);
            this.superTabControlPanel1.Controls.Add(this.button_EnterImg);
            this.superTabControlPanel1.Controls.Add(this.groupPanel_Inv);
            this.superTabControlPanel1.Controls.Add(this.txtCustName);
            this.superTabControlPanel1.Controls.Add(this.label7);
            this.superTabControlPanel1.Controls.Add(this.doubleInput_DefPack);
            this.superTabControlPanel1.Controls.Add(this.comboBox_DefPack);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 25);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            superTabPanelItemColorTable2.InnerBorder = System.Drawing.Color.Silver;
            superTabPanelColorTable2.Bottom = superTabPanelItemColorTable2;
            this.superTabControlPanel1.PanelColor = superTabPanelColorTable2;
            this.superTabControlPanel1.Size = new System.Drawing.Size(974, 406);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.superTabItem_General;
            this.superTabControlPanel1.Click += new System.EventHandler(this.superTabControlPanel1_Click);
            // 
            // checkBoxX_Points
            // 
            this.checkBoxX_Points.AutoSize = true;
            this.checkBoxX_Points.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxX_Points.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX_Points.Location = new System.Drawing.Point(13, 34);
            this.checkBoxX_Points.Name = "checkBoxX_Points";
            this.checkBoxX_Points.Size = new System.Drawing.Size(95, 15);
            this.checkBoxX_Points.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX_Points.TabIndex = 1617;
            this.checkBoxX_Points.Text = "تفعيــل النقـــــاط";
            this.checkBoxX_Points.TextColor = System.Drawing.Color.Black;
            // 
            // checkBoxX_BarcodeBalance
            // 
            this.checkBoxX_BarcodeBalance.AutoSize = true;
            this.checkBoxX_BarcodeBalance.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxX_BarcodeBalance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX_BarcodeBalance.Location = new System.Drawing.Point(6, 58);
            this.checkBoxX_BarcodeBalance.Name = "checkBoxX_BarcodeBalance";
            this.checkBoxX_BarcodeBalance.Size = new System.Drawing.Size(102, 15);
            this.checkBoxX_BarcodeBalance.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX_BarcodeBalance.TabIndex = 1616;
            this.checkBoxX_BarcodeBalance.Text = "ربط بميزان الباركود";
            this.checkBoxX_BarcodeBalance.TextColor = System.Drawing.Color.Black;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(881, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 1612;
            this.label5.Text = "خصــم الصنف :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(298, 166);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(18, 13);
            this.label16.TabIndex = 1611;
            this.label16.Text = "%";
            // 
            // textBox_DisItem
            // 
            this.textBox_DisItem.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_DisItem.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBox_DisItem.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_DisItem.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_DisItem.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_DisItem.DisplayFormat = "0.00";
            this.textBox_DisItem.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox_DisItem.ForeColor = System.Drawing.Color.White;
            this.textBox_DisItem.Increment = 1D;
            this.textBox_DisItem.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_DisItem.Location = new System.Drawing.Point(319, 162);
            this.textBox_DisItem.MinValue = 0D;
            this.textBox_DisItem.Name = "textBox_DisItem";
            this.textBox_DisItem.Size = new System.Drawing.Size(556, 20);
            this.textBox_DisItem.TabIndex = 1610;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(786, 222);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 20);
            this.label11.TabIndex = 1609;
            this.label11.Text = "حد إعادة الطلب";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(879, 196);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 1607;
            this.label8.Text = "عمولة الصنف :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(292, 228);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(18, 13);
            this.label14.TabIndex = 1606;
            this.label14.Text = "%";
            // 
            // textBox_TaxPurchase
            // 
            this.textBox_TaxPurchase.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_TaxPurchase.BackgroundStyle.BackColor = System.Drawing.Color.Gainsboro;
            this.textBox_TaxPurchase.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_TaxPurchase.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_TaxPurchase.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_TaxPurchase.DisplayFormat = "0.00";
            this.textBox_TaxPurchase.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox_TaxPurchase.Increment = 1D;
            this.textBox_TaxPurchase.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_TaxPurchase.Location = new System.Drawing.Point(316, 224);
            this.textBox_TaxPurchase.MinValue = 0D;
            this.textBox_TaxPurchase.Name = "textBox_TaxPurchase";
            this.textBox_TaxPurchase.Size = new System.Drawing.Size(62, 20);
            this.textBox_TaxPurchase.TabIndex = 1604;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(382, 224);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(112, 20);
            this.label15.TabIndex = 1605;
            this.label15.Text = "ضريبة المشتريات";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(508, 226);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 13);
            this.label9.TabIndex = 1603;
            this.label9.Text = "%";
            // 
            // textBox_TaxSales
            // 
            this.textBox_TaxSales.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_TaxSales.BackgroundStyle.BackColor = System.Drawing.Color.Gainsboro;
            this.textBox_TaxSales.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_TaxSales.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_TaxSales.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_TaxSales.DisplayFormat = "0.00";
            this.textBox_TaxSales.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox_TaxSales.Increment = 1D;
            this.textBox_TaxSales.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_TaxSales.Location = new System.Drawing.Point(532, 222);
            this.textBox_TaxSales.MinValue = 0D;
            this.textBox_TaxSales.Name = "textBox_TaxSales";
            this.textBox_TaxSales.Size = new System.Drawing.Size(62, 20);
            this.textBox_TaxSales.TabIndex = 1601;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(598, 222);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 20);
            this.label13.TabIndex = 1602;
            this.label13.Text = "ضريبة المبيعـــات";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(298, 193);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 13);
            this.label10.TabIndex = 1600;
            this.label10.Text = "%";
            // 
            // textBox_CommItm
            // 
            this.textBox_CommItm.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_CommItm.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBox_CommItm.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_CommItm.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_CommItm.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_CommItm.DisplayFormat = "0.00";
            this.textBox_CommItm.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox_CommItm.Increment = 1D;
            this.textBox_CommItm.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_CommItm.Location = new System.Drawing.Point(319, 189);
            this.textBox_CommItm.MinValue = 0D;
            this.textBox_CommItm.Name = "textBox_CommItm";
            this.textBox_CommItm.Size = new System.Drawing.Size(556, 20);
            this.textBox_CommItm.TabIndex = 1598;
            // 
            // textBox_SerialKey
            // 
            this.textBox_SerialKey.BackColor = System.Drawing.Color.White;
            this.textBox_SerialKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_SerialKey.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox_SerialKey.ForeColor = System.Drawing.Color.Maroon;
            this.textBox_SerialKey.Location = new System.Drawing.Point(1143, 134);
            this.textBox_SerialKey.Name = "textBox_SerialKey";
            this.textBox_SerialKey.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_SerialKey.Size = new System.Drawing.Size(349, 20);
            this.textBox_SerialKey.TabIndex = 1595;
            this.textBox_SerialKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // c1FlexGrid_Items
            // 
            this.c1FlexGrid_Items.ColumnInfo = resources.GetString("c1FlexGrid_Items.ColumnInfo");
            this.c1FlexGrid_Items.Location = new System.Drawing.Point(0, 79);
            this.c1FlexGrid_Items.Name = "c1FlexGrid_Items";
            this.c1FlexGrid_Items.Rows.Count = 2;
            this.c1FlexGrid_Items.Rows.DefaultSize = 19;
            this.c1FlexGrid_Items.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.c1FlexGrid_Items.Size = new System.Drawing.Size(971, 42);
            this.c1FlexGrid_Items.TabIndex = 1594;
            this.c1FlexGrid_Items.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue;
            this.c1FlexGrid_Items.Click += new System.EventHandler(this.c1FlexGrid_Items_Click);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.labelX1.BackgroundStyle.BorderBottomColor = System.Drawing.Color.SteelBlue;
            this.labelX1.BackgroundStyle.BorderBottomWidth = 1;
            this.labelX1.BackgroundStyle.BorderColor = System.Drawing.Color.SteelBlue;
            this.labelX1.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.labelX1.BackgroundStyle.BorderLeftColor = System.Drawing.Color.SteelBlue;
            this.labelX1.BackgroundStyle.BorderLeftWidth = 1;
            this.labelX1.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.labelX1.BackgroundStyle.BorderRightColor = System.Drawing.Color.SteelBlue;
            this.labelX1.BackgroundStyle.BorderRightWidth = 1;
            this.labelX1.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.labelX1.BackgroundStyle.BorderTopColor = System.Drawing.Color.SteelBlue;
            this.labelX1.BackgroundStyle.BorderTopWidth = 1;
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.ForeColor = System.Drawing.Color.Red;
            this.labelX1.Location = new System.Drawing.Point(61, 338);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(129, 19);
            this.labelX1.Symbol = "";
            this.labelX1.SymbolColor = System.Drawing.Color.SteelBlue;
            this.labelX1.SymbolSize = 12F;
            this.labelX1.TabIndex = 1590;
            this.labelX1.Text = "صورة الصنف";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // button_SrchCustNo
            // 
            this.button_SrchCustNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchCustNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchCustNo.Location = new System.Drawing.Point(293, 140);
            this.button_SrchCustNo.Name = "button_SrchCustNo";
            this.button_SrchCustNo.Size = new System.Drawing.Size(26, 19);
            this.button_SrchCustNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchCustNo.Symbol = "";
            this.button_SrchCustNo.SymbolSize = 12F;
            this.button_SrchCustNo.TabIndex = 5;
            this.button_SrchCustNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchCustNo.Click += new System.EventHandler(this.button_SrchCustNo_Click);
            // 
            // txtCustNo
            // 
            this.txtCustNo.BackColor = System.Drawing.Color.White;
            this.txtCustNo.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtCustNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtCustNo.Location = new System.Drawing.Point(422, 96);
            this.txtCustNo.MaxLength = 30;
            this.txtCustNo.Name = "txtCustNo";
            this.txtCustNo.ReadOnly = true;
            this.txtCustNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCustNo.Size = new System.Drawing.Size(87, 22);
            this.txtCustNo.TabIndex = 1573;
            this.txtCustNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCustNo.Visible = false;
            // 
            // pictureBox_PicItem
            // 
            // 
            // 
            // 
            this.pictureBox_PicItem.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.pictureBox_PicItem.BackgroundStyle.BorderBottomColor = System.Drawing.Color.SteelBlue;
            this.pictureBox_PicItem.BackgroundStyle.BorderBottomWidth = 1;
            this.pictureBox_PicItem.BackgroundStyle.BorderColor = System.Drawing.Color.SteelBlue;
            this.pictureBox_PicItem.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.pictureBox_PicItem.BackgroundStyle.BorderLeftColor = System.Drawing.Color.SteelBlue;
            this.pictureBox_PicItem.BackgroundStyle.BorderLeftWidth = 1;
            this.pictureBox_PicItem.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.pictureBox_PicItem.BackgroundStyle.BorderRightWidth = 1;
            this.pictureBox_PicItem.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.pictureBox_PicItem.BackgroundStyle.BorderTopColor = System.Drawing.Color.SteelBlue;
            this.pictureBox_PicItem.BackgroundStyle.BorderTopWidth = 1;
            this.pictureBox_PicItem.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.pictureBox_PicItem.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.pictureBox_PicItem.Location = new System.Drawing.Point(10, 133);
            this.pictureBox_PicItem.Name = "pictureBox_PicItem";
            this.pictureBox_PicItem.Size = new System.Drawing.Size(275, 170);
            this.pictureBox_PicItem.TabIndex = 1591;
            // 
            // combobox_ItmeGroup
            // 
            this.combobox_ItmeGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combobox_ItmeGroup.DisplayMember = "Text";
            this.combobox_ItmeGroup.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combobox_ItmeGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_ItmeGroup.FormattingEnabled = true;
            this.combobox_ItmeGroup.ItemHeight = 14;
            this.combobox_ItmeGroup.Location = new System.Drawing.Point(120, 6);
            this.combobox_ItmeGroup.Name = "combobox_ItmeGroup";
            this.combobox_ItmeGroup.Size = new System.Drawing.Size(361, 20);
            this.combobox_ItmeGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.combobox_ItmeGroup.TabIndex = 2;
            // 
            // textbox_MaxQty
            // 
            this.textbox_MaxQty.AllowEmptyState = false;
            // 
            // 
            // 
            this.textbox_MaxQty.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textbox_MaxQty.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textbox_MaxQty.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textbox_MaxQty.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textbox_MaxQty.Increment = 1D;
            this.textbox_MaxQty.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textbox_MaxQty.Location = new System.Drawing.Point(31, 222);
            this.textbox_MaxQty.MinValue = 0D;
            this.textbox_MaxQty.Name = "textbox_MaxQty";
            this.textbox_MaxQty.ShowUpDown = true;
            this.textbox_MaxQty.Size = new System.Drawing.Size(80, 20);
            this.textbox_MaxQty.TabIndex = 7;
            this.textbox_MaxQty.Visible = false;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label23.Location = new System.Drawing.Point(37, 229);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(68, 13);
            this.label23.TabIndex = 1588;
            this.label23.Text = "الحد الأعلى :";
            this.label23.Visible = false;
            // 
            // textbox_Supreme
            // 
            this.textbox_Supreme.AllowEmptyState = false;
            // 
            // 
            // 
            this.textbox_Supreme.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textbox_Supreme.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textbox_Supreme.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textbox_Supreme.DisplayFormat = "0";
            this.textbox_Supreme.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textbox_Supreme.Increment = 1D;
            this.textbox_Supreme.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textbox_Supreme.Location = new System.Drawing.Point(720, 222);
            this.textbox_Supreme.MinValue = 0D;
            this.textbox_Supreme.Name = "textbox_Supreme";
            this.textbox_Supreme.Size = new System.Drawing.Size(62, 22);
            this.textbox_Supreme.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(881, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 1586;
            this.label3.Text = "حساب المورد :";
            // 
            // button_ClearPic
            // 
            this.button_ClearPic.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_ClearPic.Checked = true;
            this.button_ClearPic.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_ClearPic.Location = new System.Drawing.Point(291, 255);
            this.button_ClearPic.Name = "button_ClearPic";
            this.button_ClearPic.Size = new System.Drawing.Size(19, 20);
            this.button_ClearPic.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_ClearPic.Symbol = "";
            this.button_ClearPic.SymbolSize = 11F;
            this.button_ClearPic.TabIndex = 1584;
            this.button_ClearPic.TextColor = System.Drawing.Color.SteelBlue;
            this.button_ClearPic.Tooltip = "إزالة الصورة";
            this.button_ClearPic.Click += new System.EventHandler(this.button_ClearPic_Click);
            // 
            // button_AddNewCat
            // 
            this.button_AddNewCat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_AddNewCat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_AddNewCat.Location = new System.Drawing.Point(6, 6);
            this.button_AddNewCat.Name = "button_AddNewCat";
            this.button_AddNewCat.Size = new System.Drawing.Size(26, 20);
            this.button_AddNewCat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_AddNewCat.Symbol = "";
            this.button_AddNewCat.SymbolSize = 11F;
            this.button_AddNewCat.TabIndex = 1578;
            this.button_AddNewCat.TextColor = System.Drawing.Color.SteelBlue;
            this.button_AddNewCat.Click += new System.EventHandler(this.button_AddNewCat_Click);
            // 
            // button_SrchItemGroup
            // 
            this.button_SrchItemGroup.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchItemGroup.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchItemGroup.Location = new System.Drawing.Point(33, 6);
            this.button_SrchItemGroup.Name = "button_SrchItemGroup";
            this.button_SrchItemGroup.Size = new System.Drawing.Size(26, 20);
            this.button_SrchItemGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchItemGroup.Symbol = "";
            this.button_SrchItemGroup.SymbolSize = 12F;
            this.button_SrchItemGroup.TabIndex = 1577;
            this.button_SrchItemGroup.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchItemGroup.Click += new System.EventHandler(this.button_SrchItemGroup_Click);
            // 
            // textbox_Eng_Des
            // 
            this.textbox_Eng_Des.BackColor = System.Drawing.Color.White;
            this.textbox_Eng_Des.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textbox_Eng_Des.Location = new System.Drawing.Point(120, 56);
            this.textbox_Eng_Des.Name = "textbox_Eng_Des";
            this.textbox_Eng_Des.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textbox_Eng_Des.Size = new System.Drawing.Size(746, 20);
            this.textbox_Eng_Des.TabIndex = 4;
            this.textbox_Eng_Des.Enter += new System.EventHandler(this.textbox_Eng_Des_Enter);
            this.textbox_Eng_Des.Leave += new System.EventHandler(this.textbox_Arb_Des_Enter);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(481, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 13);
            this.label12.TabIndex = 1582;
            this.label12.Text = "التصنيف :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(879, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 1581;
            this.label4.Text = "رقم الصنف :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(879, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 1580;
            this.label2.Text = "الإسم الإنجليزي :";
            // 
            // textbox_Arb_Des
            // 
            this.textbox_Arb_Des.BackColor = System.Drawing.Color.White;
            this.textbox_Arb_Des.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textbox_Arb_Des.Location = new System.Drawing.Point(120, 32);
            this.textbox_Arb_Des.Name = "textbox_Arb_Des";
            this.textbox_Arb_Des.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textbox_Arb_Des.Size = new System.Drawing.Size(746, 20);
            this.textbox_Arb_Des.TabIndex = 3;
            this.textbox_Arb_Des.Enter += new System.EventHandler(this.textbox_Arb_Des_Enter);
            this.textbox_Arb_Des.Leave += new System.EventHandler(this.textbox_Arb_Des_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(879, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 1579;
            this.label6.Text = "الإسم العربي :";
            // 
            // textBox_ID
            // 
            this.textBox_ID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.textBox_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_ID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox_ID.Location = new System.Drawing.Point(538, 6);
            this.textBox_ID.MaxLength = 15;
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.Size = new System.Drawing.Size(328, 21);
            this.textBox_ID.TabIndex = 1;
            this.textBox_ID.TextChanged += new System.EventHandler(this.textBox_ID_TextChanged);
            // 
            // button_EnterImg
            // 
            this.button_EnterImg.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_EnterImg.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_EnterImg.Location = new System.Drawing.Point(291, 283);
            this.button_EnterImg.Name = "button_EnterImg";
            this.button_EnterImg.Size = new System.Drawing.Size(19, 20);
            this.button_EnterImg.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_EnterImg.Symbol = "";
            this.button_EnterImg.SymbolSize = 11F;
            this.button_EnterImg.TabIndex = 1585;
            this.button_EnterImg.TextColor = System.Drawing.Color.SteelBlue;
            this.button_EnterImg.Tooltip = "إضافة صورة للصنف";
            this.button_EnterImg.Click += new System.EventHandler(this.button_EnterImg_Click);
            // 
            // groupPanel_Inv
            // 
            this.groupPanel_Inv.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel_Inv.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel_Inv.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel_Inv.Controls.Add(this.button_DeleteFromSystem);
            this.groupPanel_Inv.Controls.Add(this.checkBoxX_InvOut);
            this.groupPanel_Inv.Controls.Add(this.checkBoxX_InvEnter);
            this.groupPanel_Inv.Controls.Add(this.checkBoxX_InvPaymentReturn);
            this.groupPanel_Inv.Controls.Add(this.checkBoxX_InvPayment);
            this.groupPanel_Inv.Controls.Add(this.checkBoxX_ReturnInvSale);
            this.groupPanel_Inv.Controls.Add(this.checkBoxX_InvSale);
            this.groupPanel_Inv.Location = new System.Drawing.Point(315, 248);
            this.groupPanel_Inv.Name = "groupPanel_Inv";
            this.groupPanel_Inv.Size = new System.Drawing.Size(618, 55);
            // 
            // 
            // 
            this.groupPanel_Inv.Style.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel_Inv.Style.BackColor2 = System.Drawing.Color.Transparent;
            this.groupPanel_Inv.Style.BackColorGradientAngle = 90;
            this.groupPanel_Inv.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Inv.Style.BorderBottomWidth = 1;
            this.groupPanel_Inv.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel_Inv.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Inv.Style.BorderLeftWidth = 1;
            this.groupPanel_Inv.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Inv.Style.BorderRightWidth = 1;
            this.groupPanel_Inv.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Inv.Style.BorderTopWidth = 1;
            this.groupPanel_Inv.Style.CornerDiameter = 4;
            this.groupPanel_Inv.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel_Inv.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel_Inv.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel_Inv.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel_Inv.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel_Inv.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel_Inv.TabIndex = 1576;
            this.groupPanel_Inv.Text = "منع الصنف في فاتورة";
            this.groupPanel_Inv.TitleImagePosition = DevComponents.DotNetBar.eTitleImagePosition.Center;
            // 
            // button_DeleteFromSystem
            // 
            this.button_DeleteFromSystem.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_DeleteFromSystem.Checked = true;
            this.button_DeleteFromSystem.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.button_DeleteFromSystem.Font = new System.Drawing.Font("Tahoma", 8F);
            this.button_DeleteFromSystem.Location = new System.Drawing.Point(0, 8);
            this.button_DeleteFromSystem.Name = "button_DeleteFromSystem";
            this.button_DeleteFromSystem.Size = new System.Drawing.Size(133, 16);
            this.button_DeleteFromSystem.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_DeleteFromSystem.Symbol = "";
            this.button_DeleteFromSystem.SymbolSize = 15F;
            this.button_DeleteFromSystem.TabIndex = 1610;
            this.button_DeleteFromSystem.Text = "إزالة الصنف من النظام";
            this.button_DeleteFromSystem.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button_DeleteFromSystem.Visible = false;
            this.button_DeleteFromSystem.Click += new System.EventHandler(this.button_DeleteFromSystem_Click);
            // 
            // checkBoxX_InvOut
            // 
            this.checkBoxX_InvOut.AutoSize = true;
            this.checkBoxX_InvOut.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxX_InvOut.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX_InvOut.Location = new System.Drawing.Point(133, 9);
            this.checkBoxX_InvOut.Name = "checkBoxX_InvOut";
            this.checkBoxX_InvOut.Size = new System.Drawing.Size(76, 15);
            this.checkBoxX_InvOut.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX_InvOut.TabIndex = 16;
            this.checkBoxX_InvOut.Text = "إخراج بضاعة";
            // 
            // checkBoxX_InvEnter
            // 
            this.checkBoxX_InvEnter.AutoSize = true;
            this.checkBoxX_InvEnter.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxX_InvEnter.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX_InvEnter.Location = new System.Drawing.Point(207, 9);
            this.checkBoxX_InvEnter.Name = "checkBoxX_InvEnter";
            this.checkBoxX_InvEnter.Size = new System.Drawing.Size(77, 15);
            this.checkBoxX_InvEnter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX_InvEnter.TabIndex = 15;
            this.checkBoxX_InvEnter.Text = "إدخال بضاعة";
            // 
            // checkBoxX_InvPaymentReturn
            // 
            this.checkBoxX_InvPaymentReturn.AutoSize = true;
            this.checkBoxX_InvPaymentReturn.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxX_InvPaymentReturn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX_InvPaymentReturn.Location = new System.Drawing.Point(286, 9);
            this.checkBoxX_InvPaymentReturn.Name = "checkBoxX_InvPaymentReturn";
            this.checkBoxX_InvPaymentReturn.Size = new System.Drawing.Size(99, 15);
            this.checkBoxX_InvPaymentReturn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX_InvPaymentReturn.TabIndex = 14;
            this.checkBoxX_InvPaymentReturn.Text = "مرتجع المشتريات";
            // 
            // checkBoxX_InvPayment
            // 
            this.checkBoxX_InvPayment.AutoSize = true;
            this.checkBoxX_InvPayment.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxX_InvPayment.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX_InvPayment.Location = new System.Drawing.Point(388, 9);
            this.checkBoxX_InvPayment.Name = "checkBoxX_InvPayment";
            this.checkBoxX_InvPayment.Size = new System.Drawing.Size(69, 15);
            this.checkBoxX_InvPayment.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX_InvPayment.TabIndex = 13;
            this.checkBoxX_InvPayment.Text = "المشتريات";
            // 
            // checkBoxX_ReturnInvSale
            // 
            this.checkBoxX_ReturnInvSale.AutoSize = true;
            this.checkBoxX_ReturnInvSale.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxX_ReturnInvSale.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX_ReturnInvSale.Location = new System.Drawing.Point(455, 9);
            this.checkBoxX_ReturnInvSale.Name = "checkBoxX_ReturnInvSale";
            this.checkBoxX_ReturnInvSale.Size = new System.Drawing.Size(89, 15);
            this.checkBoxX_ReturnInvSale.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX_ReturnInvSale.TabIndex = 12;
            this.checkBoxX_ReturnInvSale.Text = "مرتجع المبيعات";
            // 
            // checkBoxX_InvSale
            // 
            this.checkBoxX_InvSale.AutoSize = true;
            this.checkBoxX_InvSale.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxX_InvSale.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX_InvSale.Location = new System.Drawing.Point(547, 9);
            this.checkBoxX_InvSale.Name = "checkBoxX_InvSale";
            this.checkBoxX_InvSale.Size = new System.Drawing.Size(59, 15);
            this.checkBoxX_InvSale.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX_InvSale.TabIndex = 11;
            this.checkBoxX_InvSale.Text = "المبيعات";
            // 
            // txtCustName
            // 
            this.txtCustName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtCustName.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtCustName.Location = new System.Drawing.Point(323, 138);
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCustName.Size = new System.Drawing.Size(550, 20);
            this.txtCustName.TabIndex = 1574;
            this.txtCustName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(1095, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 1596;
            this.label7.Text = "رقم السيريال :";
            // 
            // doubleInput_DefPack
            // 
            this.doubleInput_DefPack.BackColor = System.Drawing.Color.White;
            this.doubleInput_DefPack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.doubleInput_DefPack.Location = new System.Drawing.Point(293, 162);
            this.doubleInput_DefPack.Name = "doubleInput_DefPack";
            this.doubleInput_DefPack.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.doubleInput_DefPack.Size = new System.Drawing.Size(159, 20);
            this.doubleInput_DefPack.TabIndex = 1614;
            this.doubleInput_DefPack.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.doubleInput_DefPack.Visible = false;
            this.doubleInput_DefPack.Click += new System.EventHandler(this.doubleInput_DefPack_Click);
            this.doubleInput_DefPack.Enter += new System.EventHandler(this.textbox_Eng_Des_Enter);
            this.doubleInput_DefPack.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.doubleInput_DefPack_KeyPress);
            this.doubleInput_DefPack.Leave += new System.EventHandler(this.textbox_Arb_Des_Enter);
            // 
            // comboBox_DefPack
            // 
            this.comboBox_DefPack.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_DefPack.DisplayMember = "Text";
            this.comboBox_DefPack.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_DefPack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DefPack.FormattingEnabled = true;
            this.comboBox_DefPack.ItemHeight = 14;
            this.comboBox_DefPack.Location = new System.Drawing.Point(293, 189);
            this.comboBox_DefPack.Name = "comboBox_DefPack";
            this.comboBox_DefPack.Size = new System.Drawing.Size(159, 20);
            this.comboBox_DefPack.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_DefPack.TabIndex = 1615;
            this.comboBox_DefPack.Visible = false;
            // 
            // superTabItem_General
            // 
            this.superTabItem_General.AttachedControl = this.superTabControlPanel1;
            this.superTabItem_General.GlobalItem = false;
            this.superTabItem_General.Name = "superTabItem_General";
            superTabItemStateColorTable2.CloseMarker = System.Drawing.Color.Gainsboro;
            superTabColorStates2.Disabled = superTabItemStateColorTable2;
            superTabItemColorTable2.Bottom = superTabColorStates2;
            this.superTabItem_General.TabColor = superTabItemColorTable2;
            this.superTabItem_General.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.Controls.Add(this.FlxInv);
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(974, 431);
            this.superTabControlPanel2.TabIndex = 0;
            this.superTabControlPanel2.TabItem = this.superTabItem_Details;
            // 
            // FlxInv
            // 
            this.FlxInv.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.FlxInv.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.FlxInv.ColumnInfo = resources.GetString("FlxInv.ColumnInfo");
            this.FlxInv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlxInv.ExtendLastCol = true;
            this.FlxInv.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FlxInv.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.FlxInv.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.FlxInv.Location = new System.Drawing.Point(0, 0);
            this.FlxInv.Name = "FlxInv";
            this.FlxInv.Rows.Count = 14;
            this.FlxInv.Rows.DefaultSize = 19;
            this.FlxInv.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None;
            this.FlxInv.Size = new System.Drawing.Size(974, 431);
            this.FlxInv.StyleInfo = resources.GetString("FlxInv.StyleInfo");
            this.FlxInv.TabIndex = 887;
            this.FlxInv.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System;
            this.FlxInv.BeforeEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.FlxInv_BeforeEdit);
            this.FlxInv.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.FlxInv_AfterEdit);
            // 
            // superTabItem_Details
            // 
            this.superTabItem_Details.AttachedControl = this.superTabControlPanel2;
            this.superTabItem_Details.GlobalItem = false;
            this.superTabItem_Details.Name = "superTabItem_Details";
            this.superTabItem_Details.Text = "المحتويات";
            this.superTabItem_Details.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            // 
            // expandablePanel_AnotherPrice
            // 
            this.expandablePanel_AnotherPrice.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel_AnotherPrice.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.expandablePanel_AnotherPrice.Controls.Add(this.panelEx_Size);
            this.expandablePanel_AnotherPrice.Controls.Add(this.textbox_Sentence);
            this.expandablePanel_AnotherPrice.Controls.Add(this.label28);
            this.expandablePanel_AnotherPrice.Controls.Add(this.textbox_Legates);
            this.expandablePanel_AnotherPrice.Controls.Add(this.textbox_Distributors);
            this.expandablePanel_AnotherPrice.Controls.Add(this.label24);
            this.expandablePanel_AnotherPrice.Controls.Add(this.label27);
            this.expandablePanel_AnotherPrice.Controls.Add(this.textbox_VIP);
            this.expandablePanel_AnotherPrice.Controls.Add(this.label26);
            this.expandablePanel_AnotherPrice.Controls.Add(this.textbox_Sectorial);
            this.expandablePanel_AnotherPrice.Controls.Add(this.label25);
            this.expandablePanel_AnotherPrice.ExpandButtonVisible = false;
            this.expandablePanel_AnotherPrice.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.expandablePanel_AnotherPrice.Location = new System.Drawing.Point(308, 206);
            this.expandablePanel_AnotherPrice.Name = "expandablePanel_AnotherPrice";
            this.expandablePanel_AnotherPrice.Size = new System.Drawing.Size(974, 62);
            this.expandablePanel_AnotherPrice.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_AnotherPrice.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandablePanel_AnotherPrice.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile;
            this.expandablePanel_AnotherPrice.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel_AnotherPrice.Style.GradientAngle = 90;
            this.expandablePanel_AnotherPrice.TabIndex = 918;
            this.expandablePanel_AnotherPrice.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_AnotherPrice.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel_AnotherPrice.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel_AnotherPrice.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel_AnotherPrice.TitleStyle.ForeColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.expandablePanel_AnotherPrice.TitleStyle.GradientAngle = 90;
            this.expandablePanel_AnotherPrice.TitleText = "أسعار إضافية";
            // 
            // panelEx_Size
            // 
            this.panelEx_Size.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx_Size.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx_Size.Controls.Add(this.label18);
            this.panelEx_Size.Controls.Add(this.label17);
            this.panelEx_Size.Controls.Add(this.txtFiled2);
            this.panelEx_Size.Controls.Add(this.txtFiled3);
            this.panelEx_Size.Controls.Add(this.txtFiled6);
            this.panelEx_Size.Controls.Add(this.txtFiled5);
            this.panelEx_Size.Controls.Add(this.txtFiled4);
            this.panelEx_Size.Controls.Add(this.txtFiled1);
            this.panelEx_Size.Controls.Add(this.labelFiled6);
            this.panelEx_Size.Controls.Add(this.labelFiled3);
            this.panelEx_Size.Controls.Add(this.labelFiled1);
            this.panelEx_Size.Controls.Add(this.labelFiled2);
            this.panelEx_Size.Controls.Add(this.labelFiled5);
            this.panelEx_Size.Controls.Add(this.labelFiled4);
            this.panelEx_Size.Location = new System.Drawing.Point(-822, 27);
            this.panelEx_Size.Name = "panelEx_Size";
            this.panelEx_Size.Size = new System.Drawing.Size(592, 58);
            this.panelEx_Size.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx_Size.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx_Size.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx_Size.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx_Size.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx_Size.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx_Size.Style.GradientAngle = 90;
            this.panelEx_Size.TabIndex = 138;
            this.panelEx_Size.Visible = false;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Gainsboro;
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label18.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(11, 3);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(274, 15);
            this.label18.TabIndex = 149;
            this.label18.Text = "RE";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Gainsboro;
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label17.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(307, 3);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(274, 15);
            this.label17.TabIndex = 148;
            this.label17.Text = "LE";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtFiled2
            // 
            this.txtFiled2.BackColor = System.Drawing.Color.White;
            this.txtFiled2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiled2.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtFiled2.ForeColor = System.Drawing.Color.Maroon;
            this.txtFiled2.Location = new System.Drawing.Point(399, 37);
            this.txtFiled2.MaxLength = 25;
            this.txtFiled2.Name = "txtFiled2";
            this.txtFiled2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFiled2.Size = new System.Drawing.Size(90, 20);
            this.txtFiled2.TabIndex = 147;
            this.txtFiled2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFiled2.Click += new System.EventHandler(this.txtFiled2_Click);
            // 
            // txtFiled3
            // 
            this.txtFiled3.BackColor = System.Drawing.Color.White;
            this.txtFiled3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiled3.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtFiled3.ForeColor = System.Drawing.Color.Maroon;
            this.txtFiled3.Location = new System.Drawing.Point(307, 37);
            this.txtFiled3.MaxLength = 25;
            this.txtFiled3.Name = "txtFiled3";
            this.txtFiled3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFiled3.Size = new System.Drawing.Size(90, 20);
            this.txtFiled3.TabIndex = 146;
            this.txtFiled3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFiled3.Click += new System.EventHandler(this.txtFiled3_Click);
            // 
            // txtFiled6
            // 
            this.txtFiled6.BackColor = System.Drawing.Color.White;
            this.txtFiled6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiled6.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtFiled6.ForeColor = System.Drawing.Color.Maroon;
            this.txtFiled6.Location = new System.Drawing.Point(11, 37);
            this.txtFiled6.MaxLength = 25;
            this.txtFiled6.Name = "txtFiled6";
            this.txtFiled6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFiled6.Size = new System.Drawing.Size(90, 20);
            this.txtFiled6.TabIndex = 145;
            this.txtFiled6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFiled6.Click += new System.EventHandler(this.txtFiled6_Click);
            // 
            // txtFiled5
            // 
            this.txtFiled5.BackColor = System.Drawing.Color.White;
            this.txtFiled5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiled5.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtFiled5.ForeColor = System.Drawing.Color.Maroon;
            this.txtFiled5.Location = new System.Drawing.Point(103, 37);
            this.txtFiled5.MaxLength = 25;
            this.txtFiled5.Name = "txtFiled5";
            this.txtFiled5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFiled5.Size = new System.Drawing.Size(90, 20);
            this.txtFiled5.TabIndex = 144;
            this.txtFiled5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFiled5.Click += new System.EventHandler(this.txtFiled5_Click);
            // 
            // txtFiled4
            // 
            this.txtFiled4.BackColor = System.Drawing.Color.White;
            this.txtFiled4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiled4.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtFiled4.ForeColor = System.Drawing.Color.Maroon;
            this.txtFiled4.Location = new System.Drawing.Point(195, 37);
            this.txtFiled4.MaxLength = 25;
            this.txtFiled4.Name = "txtFiled4";
            this.txtFiled4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFiled4.Size = new System.Drawing.Size(90, 20);
            this.txtFiled4.TabIndex = 143;
            this.txtFiled4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFiled4.Click += new System.EventHandler(this.txtFiled4_Click);
            // 
            // txtFiled1
            // 
            this.txtFiled1.BackColor = System.Drawing.Color.White;
            this.txtFiled1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiled1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtFiled1.ForeColor = System.Drawing.Color.Maroon;
            this.txtFiled1.Location = new System.Drawing.Point(491, 37);
            this.txtFiled1.MaxLength = 25;
            this.txtFiled1.Name = "txtFiled1";
            this.txtFiled1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFiled1.Size = new System.Drawing.Size(90, 20);
            this.txtFiled1.TabIndex = 142;
            this.txtFiled1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFiled1.Click += new System.EventHandler(this.txtFiled1_Click);
            // 
            // labelFiled6
            // 
            this.labelFiled6.BackColor = System.Drawing.Color.Transparent;
            this.labelFiled6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelFiled6.Font = new System.Drawing.Font("Tahoma", 8F);
            this.labelFiled6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelFiled6.Location = new System.Drawing.Point(11, 19);
            this.labelFiled6.Name = "labelFiled6";
            this.labelFiled6.Size = new System.Drawing.Size(90, 17);
            this.labelFiled6.TabIndex = 141;
            this.labelFiled6.Text = "SPH";
            this.labelFiled6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFiled3
            // 
            this.labelFiled3.BackColor = System.Drawing.Color.Transparent;
            this.labelFiled3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelFiled3.Font = new System.Drawing.Font("Tahoma", 8F);
            this.labelFiled3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelFiled3.Location = new System.Drawing.Point(307, 19);
            this.labelFiled3.Name = "labelFiled3";
            this.labelFiled3.Size = new System.Drawing.Size(90, 17);
            this.labelFiled3.TabIndex = 138;
            this.labelFiled3.Text = "SPH";
            this.labelFiled3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFiled1
            // 
            this.labelFiled1.BackColor = System.Drawing.Color.Transparent;
            this.labelFiled1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelFiled1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.labelFiled1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelFiled1.Location = new System.Drawing.Point(491, 19);
            this.labelFiled1.Name = "labelFiled1";
            this.labelFiled1.Size = new System.Drawing.Size(90, 17);
            this.labelFiled1.TabIndex = 137;
            this.labelFiled1.Text = "AYIS";
            this.labelFiled1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFiled2
            // 
            this.labelFiled2.BackColor = System.Drawing.Color.Transparent;
            this.labelFiled2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelFiled2.Font = new System.Drawing.Font("Tahoma", 8F);
            this.labelFiled2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelFiled2.Location = new System.Drawing.Point(399, 19);
            this.labelFiled2.Name = "labelFiled2";
            this.labelFiled2.Size = new System.Drawing.Size(90, 17);
            this.labelFiled2.TabIndex = 136;
            this.labelFiled2.Text = "CYL";
            this.labelFiled2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFiled5
            // 
            this.labelFiled5.BackColor = System.Drawing.Color.Transparent;
            this.labelFiled5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelFiled5.Font = new System.Drawing.Font("Tahoma", 8F);
            this.labelFiled5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelFiled5.Location = new System.Drawing.Point(103, 19);
            this.labelFiled5.Name = "labelFiled5";
            this.labelFiled5.Size = new System.Drawing.Size(90, 17);
            this.labelFiled5.TabIndex = 140;
            this.labelFiled5.Text = "CYL";
            this.labelFiled5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFiled4
            // 
            this.labelFiled4.BackColor = System.Drawing.Color.Transparent;
            this.labelFiled4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelFiled4.Font = new System.Drawing.Font("Tahoma", 8F);
            this.labelFiled4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelFiled4.Location = new System.Drawing.Point(195, 19);
            this.labelFiled4.Name = "labelFiled4";
            this.labelFiled4.Size = new System.Drawing.Size(90, 17);
            this.labelFiled4.TabIndex = 139;
            this.labelFiled4.Text = "AYIS";
            this.labelFiled4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textbox_Sentence
            // 
            this.textbox_Sentence.AllowEmptyState = false;
            // 
            // 
            // 
            this.textbox_Sentence.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textbox_Sentence.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textbox_Sentence.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textbox_Sentence.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textbox_Sentence.Increment = 1D;
            this.textbox_Sentence.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textbox_Sentence.Location = new System.Drawing.Point(460, 31);
            this.textbox_Sentence.Name = "textbox_Sentence";
            this.textbox_Sentence.Size = new System.Drawing.Size(85, 20);
            this.textbox_Sentence.TabIndex = 132;
            this.textbox_Sentence.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.label28.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic);
            this.label28.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label28.Location = new System.Drawing.Point(554, 32);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(72, 16);
            this.label28.TabIndex = 131;
            this.label28.Text = "سعر الجملة";
            // 
            // textbox_Legates
            // 
            this.textbox_Legates.AllowEmptyState = false;
            // 
            // 
            // 
            this.textbox_Legates.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textbox_Legates.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textbox_Legates.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textbox_Legates.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textbox_Legates.Increment = 1D;
            this.textbox_Legates.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textbox_Legates.Location = new System.Drawing.Point(793, 30);
            this.textbox_Legates.Name = "textbox_Legates";
            this.textbox_Legates.Size = new System.Drawing.Size(85, 20);
            this.textbox_Legates.TabIndex = 130;
            this.textbox_Legates.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            this.textbox_Legates.ValueChanged += new System.EventHandler(this.textbox_Legates_ValueChanged);
            // 
            // textbox_Distributors
            // 
            this.textbox_Distributors.AllowEmptyState = false;
            // 
            // 
            // 
            this.textbox_Distributors.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textbox_Distributors.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textbox_Distributors.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textbox_Distributors.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textbox_Distributors.Increment = 1D;
            this.textbox_Distributors.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textbox_Distributors.Location = new System.Drawing.Point(632, 30);
            this.textbox_Distributors.Name = "textbox_Distributors";
            this.textbox_Distributors.Size = new System.Drawing.Size(85, 20);
            this.textbox_Distributors.TabIndex = 129;
            this.textbox_Distributors.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic);
            this.label24.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label24.Location = new System.Drawing.Point(883, 31);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(79, 16);
            this.label24.TabIndex = 128;
            this.label24.Text = "سعر المندوب";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic);
            this.label27.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label27.Location = new System.Drawing.Point(717, 31);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(70, 16);
            this.label27.TabIndex = 127;
            this.label27.Text = "سعر الموزع";
            // 
            // textbox_VIP
            // 
            this.textbox_VIP.AllowEmptyState = false;
            // 
            // 
            // 
            this.textbox_VIP.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textbox_VIP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textbox_VIP.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textbox_VIP.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textbox_VIP.Increment = 1D;
            this.textbox_VIP.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textbox_VIP.Location = new System.Drawing.Point(115, 29);
            this.textbox_VIP.Name = "textbox_VIP";
            this.textbox_VIP.Size = new System.Drawing.Size(85, 20);
            this.textbox_VIP.TabIndex = 136;
            this.textbox_VIP.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic);
            this.label26.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label26.Location = new System.Drawing.Point(209, 31);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(53, 16);
            this.label26.TabIndex = 135;
            this.label26.Text = "سعر آخر";
            // 
            // textbox_Sectorial
            // 
            this.textbox_Sectorial.AllowEmptyState = false;
            // 
            // 
            // 
            this.textbox_Sectorial.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textbox_Sectorial.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textbox_Sectorial.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textbox_Sectorial.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textbox_Sectorial.Increment = 1D;
            this.textbox_Sectorial.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textbox_Sectorial.Location = new System.Drawing.Point(276, 31);
            this.textbox_Sectorial.Name = "textbox_Sectorial";
            this.textbox_Sectorial.Size = new System.Drawing.Size(85, 20);
            this.textbox_Sectorial.TabIndex = 134;
            this.textbox_Sectorial.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic);
            this.label25.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label25.Location = new System.Drawing.Point(371, 31);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(73, 16);
            this.label25.TabIndex = 133;
            this.label25.Text = "سعر التجزئة";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(846, 469);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 13);
            this.label1.TabIndex = 907;
            this.label1.Text = "التنبية بتاريخ إنتهاء الصلاحية قبل :";
            // 
            // textbox_DateNo
            // 
            this.textbox_DateNo.AllowEmptyState = false;
            // 
            // 
            // 
            this.textbox_DateNo.BackgroundStyle.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.textbox_DateNo.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textbox_DateNo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textbox_DateNo.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textbox_DateNo.Enabled = false;
            this.textbox_DateNo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textbox_DateNo.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textbox_DateNo.IsInputReadOnly = true;
            this.textbox_DateNo.Location = new System.Drawing.Point(762, 447);
            this.textbox_DateNo.MinValue = 1;
            this.textbox_DateNo.Name = "textbox_DateNo";
            this.textbox_DateNo.ShowUpDown = true;
            this.textbox_DateNo.Size = new System.Drawing.Size(78, 21);
            this.textbox_DateNo.TabIndex = 905;
            this.textbox_DateNo.Value = 1;
            // 
            // combobox_DateTyp
            // 
            this.combobox_DateTyp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combobox_DateTyp.DisplayMember = "Text";
            this.combobox_DateTyp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combobox_DateTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_DateTyp.Enabled = false;
            this.combobox_DateTyp.FormattingEnabled = true;
            this.combobox_DateTyp.ItemHeight = 14;
            this.combobox_DateTyp.Location = new System.Drawing.Point(616, 453);
            this.combobox_DateTyp.Name = "combobox_DateTyp";
            this.combobox_DateTyp.Size = new System.Drawing.Size(141, 20);
            this.combobox_DateTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.combobox_DateTyp.TabIndex = 920;
            // 
            // sideBar_Units
            // 
            this.sideBar_Units.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.sideBar_Units.BackColor = System.Drawing.Color.White;
            this.sideBar_Units.BorderStyle = DevComponents.DotNetBar.eBorderType.None;
            this.sideBar_Units.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideBar_Units.ExpandedPanel = this.sideBarPanelItem_Unit1;
            this.sideBar_Units.ForeColor = System.Drawing.Color.Black;
            this.sideBar_Units.Location = new System.Drawing.Point(0, 0);
            this.sideBar_Units.Name = "sideBar_Units";
            this.sideBar_Units.Panels.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.sideBarPanelItem_Unit1,
            this.sideBarPanelItem_Unit2,
            this.sideBarPanelItem_Unit3,
            this.sideBarPanelItem_Unit4,
            this.sideBarPanelItem_Unit5});
            this.sideBar_Units.Size = new System.Drawing.Size(308, 431);
            this.sideBar_Units.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.sideBar_Units.TabIndex = 901;
            // 
            // sideBarPanelItem_Unit1
            // 
            this.sideBarPanelItem_Unit1.FontBold = true;
            this.sideBarPanelItem_Unit1.Name = "sideBarPanelItem_Unit1";
            this.sideBarPanelItem_Unit1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem4,
            this.comboboxItems_Unit1,
            this.labelItem5,
            this.textbox_Pack1,
            this.labelItem30,
            this.textbox_SelPri1,
            this.labelItem6,
            this.textbox_Qty1,
            this.labelItem7,
            this.textbox_Cost1,
            this.labelItem8,
            this.txtBarCode1,
            this.radiobutton_RButDef1});
            this.sideBarPanelItem_Unit1.Text = "الوحدة الأولى";
            this.sideBarPanelItem_Unit1.WordWrap = true;
            // 
            // labelItem4
            // 
            this.labelItem4.BackColor = System.Drawing.Color.AliceBlue;
            this.labelItem4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem4.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelItem4.Name = "labelItem4";
            this.labelItem4.Text = "الوحدة";
            this.labelItem4.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // comboboxItems_Unit1
            // 
            this.comboboxItems_Unit1.ComboWidth = 217;
            this.comboboxItems_Unit1.DropDownHeight = 106;
            this.comboboxItems_Unit1.ItemHeight = 14;
            this.comboboxItems_Unit1.Name = "comboboxItems_Unit1";
            this.comboboxItems_Unit1.Text = "comboBoxItem1";
            this.comboboxItems_Unit1.SelectedIndexChanged += new System.EventHandler(this.comboboxItems_Unit1_SelectedIndexChanged);
            this.comboboxItems_Unit1.Click += new System.EventHandler(this.Button_Edit_Click);
            // 
            // labelItem5
            // 
            this.labelItem5.BackColor = System.Drawing.Color.AliceBlue;
            this.labelItem5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem5.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelItem5.Name = "labelItem5";
            this.labelItem5.Text = "التعبئة";
            this.labelItem5.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelItem5.Visible = false;
            // 
            // textbox_Pack1
            // 
            this.textbox_Pack1.Enabled = false;
            this.textbox_Pack1.MaxLength = 8;
            this.textbox_Pack1.Name = "textbox_Pack1";
            this.textbox_Pack1.Text = "1";
            this.textbox_Pack1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textbox_Pack1.TextBoxWidth = 217;
            this.textbox_Pack1.Visible = false;
            this.textbox_Pack1.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.textbox_Pack1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_Pack1_KeyPress);
            this.textbox_Pack1.Click += new System.EventHandler(this.Button_Edit_Click);
            // 
            // labelItem30
            // 
            this.labelItem30.BackColor = System.Drawing.Color.AliceBlue;
            this.labelItem30.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem30.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelItem30.Name = "labelItem30";
            this.labelItem30.Text = "سعر البيع";
            this.labelItem30.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // textbox_SelPri1
            // 
            this.textbox_SelPri1.MaxLength = 8;
            this.textbox_SelPri1.Name = "textbox_SelPri1";
            this.textbox_SelPri1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textbox_SelPri1.TextBoxWidth = 218;
            this.textbox_SelPri1.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.textbox_SelPri1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_Pack1_KeyPress);
            this.textbox_SelPri1.Click += new System.EventHandler(this.Button_Edit_Click);
            this.textbox_SelPri1.GotFocus += new System.EventHandler(this.txtBarCode1_GotFocus);
            // 
            // labelItem6
            // 
            this.labelItem6.BackColor = System.Drawing.Color.AliceBlue;
            this.labelItem6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem6.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelItem6.Name = "labelItem6";
            this.labelItem6.Text = "الكمية";
            this.labelItem6.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelItem6.Click += new System.EventHandler(this.labelItem6_Click);
            // 
            // textbox_Qty1
            // 
            this.textbox_Qty1.Enabled = false;
            this.textbox_Qty1.MaxLength = 8;
            this.textbox_Qty1.Name = "textbox_Qty1";
            this.textbox_Qty1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textbox_Qty1.TextBoxWidth = 217;
            this.textbox_Qty1.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.textbox_Qty1.Click += new System.EventHandler(this.Button_Edit_Click);
            // 
            // labelItem7
            // 
            this.labelItem7.BackColor = System.Drawing.Color.AliceBlue;
            this.labelItem7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem7.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelItem7.Name = "labelItem7";
            this.labelItem7.Text = "التكلفة";
            this.labelItem7.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // textbox_Cost1
            // 
            this.textbox_Cost1.Enabled = false;
            this.textbox_Cost1.MaxLength = 8;
            this.textbox_Cost1.Name = "textbox_Cost1";
            this.textbox_Cost1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textbox_Cost1.TextBoxWidth = 217;
            this.textbox_Cost1.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.textbox_Cost1.Click += new System.EventHandler(this.Button_Edit_Click);
            // 
            // labelItem8
            // 
            this.labelItem8.BackColor = System.Drawing.Color.AliceBlue;
            this.labelItem8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem8.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelItem8.Name = "labelItem8";
            this.labelItem8.Text = "رقم الباركود";
            this.labelItem8.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // txtBarCode1
            // 
            this.txtBarCode1.ButtonCustom.Checked = true;
            this.txtBarCode1.ButtonCustom.Visible = true;
            this.txtBarCode1.CanCustomize = false;
            this.txtBarCode1.MaxLength = 250;
            this.txtBarCode1.Name = "txtBarCode1";
            this.txtBarCode1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBarCode1.TextBoxWidth = 217;
            this.txtBarCode1.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.txtBarCode1.ButtonCustomClick += new System.EventHandler(this.txtBarCode1_ButtonCustomClick);
            this.txtBarCode1.Click += new System.EventHandler(this.Button_Edit_Click);
            this.txtBarCode1.LostFocus += new System.EventHandler(this.txtBarCode1_Leave);
            this.txtBarCode1.GotFocus += new System.EventHandler(this.txtBarCode1_GotFocus);
            // 
            // radiobutton_RButDef1
            // 
            this.radiobutton_RButDef1.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.radiobutton_RButDef1.Checked = true;
            this.radiobutton_RButDef1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.radiobutton_RButDef1.Name = "radiobutton_RButDef1";
            this.radiobutton_RButDef1.Text = "الوحدة الإفتراضية";
            this.radiobutton_RButDef1.CheckedChanged += new DevComponents.DotNetBar.CheckBoxChangeEventHandler(this.radiobutton_RButDef1_CheckedChanged);
            // 
            // sideBarPanelItem_Unit2
            // 
            this.sideBarPanelItem_Unit2.FontBold = true;
            this.sideBarPanelItem_Unit2.Name = "sideBarPanelItem_Unit2";
            this.sideBarPanelItem_Unit2.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem9,
            this.comboboxItems_Unit2,
            this.labelItem11,
            this.textbox_Pack2,
            this.labelItem31,
            this.textbox_SelPri2,
            this.labelItem12,
            this.textbox_Qty2,
            this.labelItem13,
            this.textbox_Cost2,
            this.labelItem10,
            this.txtBarCode2,
            this.radiobutton_RButDef2});
            this.sideBarPanelItem_Unit2.Text = "الوحدة الثانية";
            // 
            // labelItem9
            // 
            this.labelItem9.BackColor = System.Drawing.Color.AliceBlue;
            this.labelItem9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem9.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelItem9.Name = "labelItem9";
            this.labelItem9.Text = "الوحدة";
            this.labelItem9.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // comboboxItems_Unit2
            // 
            this.comboboxItems_Unit2.ComboWidth = 217;
            this.comboboxItems_Unit2.DropDownHeight = 106;
            this.comboboxItems_Unit2.ItemHeight = 14;
            this.comboboxItems_Unit2.Name = "comboboxItems_Unit2";
            this.comboboxItems_Unit2.Text = "comboBoxItem1";
            this.comboboxItems_Unit2.SelectedIndexChanged += new System.EventHandler(this.comboboxItems_Unit2_SelectedIndexChanged);
            this.comboboxItems_Unit2.Click += new System.EventHandler(this.Button_Edit_Click);
            // 
            // labelItem11
            // 
            this.labelItem11.BackColor = System.Drawing.Color.AliceBlue;
            this.labelItem11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem11.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelItem11.Name = "labelItem11";
            this.labelItem11.Text = "التعبئة";
            this.labelItem11.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // textbox_Pack2
            // 
            this.textbox_Pack2.MaxLength = 8;
            this.textbox_Pack2.Name = "textbox_Pack2";
            this.textbox_Pack2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textbox_Pack2.TextBoxWidth = 217;
            this.textbox_Pack2.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.textbox_Pack2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_Pack2_KeyPress);
            this.textbox_Pack2.Click += new System.EventHandler(this.Button_Edit_Click);
            this.textbox_Pack2.GotFocus += new System.EventHandler(this.txtBarCode1_GotFocus);
            // 
            // labelItem31
            // 
            this.labelItem31.BackColor = System.Drawing.Color.AliceBlue;
            this.labelItem31.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem31.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelItem31.Name = "labelItem31";
            this.labelItem31.Text = "سعر البيع";
            this.labelItem31.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // textbox_SelPri2
            // 
            this.textbox_SelPri2.MaxLength = 8;
            this.textbox_SelPri2.Name = "textbox_SelPri2";
            this.textbox_SelPri2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textbox_SelPri2.TextBoxWidth = 218;
            this.textbox_SelPri2.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.textbox_SelPri2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_Pack2_KeyPress);
            this.textbox_SelPri2.Click += new System.EventHandler(this.Button_Edit_Click);
            this.textbox_SelPri2.GotFocus += new System.EventHandler(this.txtBarCode1_GotFocus);
            // 
            // labelItem12
            // 
            this.labelItem12.BackColor = System.Drawing.Color.AliceBlue;
            this.labelItem12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem12.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelItem12.Name = "labelItem12";
            this.labelItem12.Text = "الكمية";
            this.labelItem12.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // textbox_Qty2
            // 
            this.textbox_Qty2.Enabled = false;
            this.textbox_Qty2.MaxLength = 8;
            this.textbox_Qty2.Name = "textbox_Qty2";
            this.textbox_Qty2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textbox_Qty2.TextBoxWidth = 217;
            this.textbox_Qty2.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.textbox_Qty2.Click += new System.EventHandler(this.Button_Edit_Click);
            // 
            // labelItem13
            // 
            this.labelItem13.BackColor = System.Drawing.Color.AliceBlue;
            this.labelItem13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem13.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelItem13.Name = "labelItem13";
            this.labelItem13.Text = "التكلفة";
            this.labelItem13.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // textbox_Cost2
            // 
            this.textbox_Cost2.Enabled = false;
            this.textbox_Cost2.MaxLength = 8;
            this.textbox_Cost2.Name = "textbox_Cost2";
            this.textbox_Cost2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textbox_Cost2.TextBoxWidth = 217;
            this.textbox_Cost2.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.textbox_Cost2.Click += new System.EventHandler(this.Button_Edit_Click);
            // 
            // labelItem10
            // 
            this.labelItem10.BackColor = System.Drawing.Color.AliceBlue;
            this.labelItem10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem10.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelItem10.Name = "labelItem10";
            this.labelItem10.Text = "رقم الباركود";
            this.labelItem10.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // txtBarCode2
            // 
            this.txtBarCode2.ButtonCustom.Checked = true;
            this.txtBarCode2.ButtonCustom.Visible = true;
            this.txtBarCode2.CanCustomize = false;
            this.txtBarCode2.MaxLength = 250;
            this.txtBarCode2.Name = "txtBarCode2";
            this.txtBarCode2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBarCode2.TextBoxWidth = 217;
            this.txtBarCode2.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.txtBarCode2.ButtonCustomClick += new System.EventHandler(this.txtBarCode2_ButtonCustomClick);
            this.txtBarCode2.Click += new System.EventHandler(this.Button_Edit_Click);
            this.txtBarCode2.LostFocus += new System.EventHandler(this.txtBarCode2_Leave);
            this.txtBarCode2.GotFocus += new System.EventHandler(this.txtBarCode1_GotFocus);
            // 
            // radiobutton_RButDef2
            // 
            this.radiobutton_RButDef2.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.radiobutton_RButDef2.Enabled = false;
            this.radiobutton_RButDef2.Name = "radiobutton_RButDef2";
            this.radiobutton_RButDef2.Text = "الوحدة الإفتراضية";
            this.radiobutton_RButDef2.CheckedChanged += new DevComponents.DotNetBar.CheckBoxChangeEventHandler(this.radiobutton_RButDef2_CheckedChanged);
            this.radiobutton_RButDef2.Click += new System.EventHandler(this.Button_Edit_Click);
            // 
            // sideBarPanelItem_Unit3
            // 
            this.sideBarPanelItem_Unit3.FontBold = true;
            this.sideBarPanelItem_Unit3.Name = "sideBarPanelItem_Unit3";
            this.sideBarPanelItem_Unit3.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem14,
            this.comboboxItems_Unit3,
            this.labelItem16,
            this.textbox_Pack3,
            this.labelItem32,
            this.textbox_SelPri3,
            this.labelItem17,
            this.textbox_Qty3,
            this.labelItem18,
            this.textbox_Cost3,
            this.labelItem15,
            this.txtBarCode3,
            this.radiobutton_RButDef3});
            this.sideBarPanelItem_Unit3.Text = "الوحدة الثالثة";
            // 
            // labelItem14
            // 
            this.labelItem14.BackColor = System.Drawing.Color.AliceBlue;
            this.labelItem14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem14.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelItem14.Name = "labelItem14";
            this.labelItem14.Text = "الوحدة";
            this.labelItem14.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // comboboxItems_Unit3
            // 
            this.comboboxItems_Unit3.ComboWidth = 217;
            this.comboboxItems_Unit3.DropDownHeight = 106;
            this.comboboxItems_Unit3.ItemHeight = 14;
            this.comboboxItems_Unit3.Name = "comboboxItems_Unit3";
            this.comboboxItems_Unit3.Text = "comboBoxItem1";
            this.comboboxItems_Unit3.SelectedIndexChanged += new System.EventHandler(this.comboboxItems_Unit3_SelectedIndexChanged);
            this.comboboxItems_Unit3.Click += new System.EventHandler(this.Button_Edit_Click);
            // 
            // labelItem16
            // 
            this.labelItem16.BackColor = System.Drawing.Color.AliceBlue;
            this.labelItem16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem16.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelItem16.Name = "labelItem16";
            this.labelItem16.Text = "التعبئة";
            this.labelItem16.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // textbox_Pack3
            // 
            this.textbox_Pack3.MaxLength = 8;
            this.textbox_Pack3.Name = "textbox_Pack3";
            this.textbox_Pack3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textbox_Pack3.TextBoxWidth = 217;
            this.textbox_Pack3.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.textbox_Pack3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_Pack3_KeyPress);
            this.textbox_Pack3.Click += new System.EventHandler(this.Button_Edit_Click);
            this.textbox_Pack3.GotFocus += new System.EventHandler(this.txtBarCode1_GotFocus);
            // 
            // labelItem32
            // 
            this.labelItem32.BackColor = System.Drawing.Color.AliceBlue;
            this.labelItem32.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem32.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelItem32.Name = "labelItem32";
            this.labelItem32.Text = "سعر البيع";
            this.labelItem32.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // textbox_SelPri3
            // 
            this.textbox_SelPri3.MaxLength = 8;
            this.textbox_SelPri3.Name = "textbox_SelPri3";
            this.textbox_SelPri3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textbox_SelPri3.TextBoxWidth = 218;
            this.textbox_SelPri3.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.textbox_SelPri3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_Pack3_KeyPress);
            this.textbox_SelPri3.Click += new System.EventHandler(this.Button_Edit_Click);
            this.textbox_SelPri3.GotFocus += new System.EventHandler(this.txtBarCode1_GotFocus);
            // 
            // labelItem17
            // 
            this.labelItem17.BackColor = System.Drawing.Color.AliceBlue;
            this.labelItem17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem17.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelItem17.Name = "labelItem17";
            this.labelItem17.Text = "الكمية";
            this.labelItem17.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // textbox_Qty3
            // 
            this.textbox_Qty3.Enabled = false;
            this.textbox_Qty3.MaxLength = 8;
            this.textbox_Qty3.Name = "textbox_Qty3";
            this.textbox_Qty3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textbox_Qty3.TextBoxWidth = 217;
            this.textbox_Qty3.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.textbox_Qty3.Click += new System.EventHandler(this.Button_Edit_Click);
            // 
            // labelItem18
            // 
            this.labelItem18.BackColor = System.Drawing.Color.AliceBlue;
            this.labelItem18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem18.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelItem18.Name = "labelItem18";
            this.labelItem18.Text = "التكلفة";
            this.labelItem18.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // textbox_Cost3
            // 
            this.textbox_Cost3.Enabled = false;
            this.textbox_Cost3.MaxLength = 8;
            this.textbox_Cost3.Name = "textbox_Cost3";
            this.textbox_Cost3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textbox_Cost3.TextBoxWidth = 217;
            this.textbox_Cost3.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.textbox_Cost3.Click += new System.EventHandler(this.Button_Edit_Click);
            // 
            // labelItem15
            // 
            this.labelItem15.BackColor = System.Drawing.Color.AliceBlue;
            this.labelItem15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem15.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelItem15.Name = "labelItem15";
            this.labelItem15.Text = "رقم الباركود";
            this.labelItem15.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // txtBarCode3
            // 
            this.txtBarCode3.ButtonCustom.Checked = true;
            this.txtBarCode3.ButtonCustom.Visible = true;
            this.txtBarCode3.CanCustomize = false;
            this.txtBarCode3.MaxLength = 250;
            this.txtBarCode3.Name = "txtBarCode3";
            this.txtBarCode3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBarCode3.TextBoxWidth = 217;
            this.txtBarCode3.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.txtBarCode3.ButtonCustomClick += new System.EventHandler(this.txtBarCode3_ButtonCustomClick);
            this.txtBarCode3.Click += new System.EventHandler(this.Button_Edit_Click);
            this.txtBarCode3.LostFocus += new System.EventHandler(this.txtBarCode3_Leave);
            this.txtBarCode3.GotFocus += new System.EventHandler(this.txtBarCode1_GotFocus);
            // 
            // radiobutton_RButDef3
            // 
            this.radiobutton_RButDef3.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.radiobutton_RButDef3.Enabled = false;
            this.radiobutton_RButDef3.Name = "radiobutton_RButDef3";
            this.radiobutton_RButDef3.Text = "الوحدة الإفتراضية";
            this.radiobutton_RButDef3.CheckedChanged += new DevComponents.DotNetBar.CheckBoxChangeEventHandler(this.radiobutton_RButDef3_CheckedChanged);
            this.radiobutton_RButDef3.Click += new System.EventHandler(this.Button_Edit_Click);
            // 
            // sideBarPanelItem_Unit4
            // 
            this.sideBarPanelItem_Unit4.FontBold = true;
            this.sideBarPanelItem_Unit4.Name = "sideBarPanelItem_Unit4";
            this.sideBarPanelItem_Unit4.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem19,
            this.comboboxItems_Unit4,
            this.labelItem21,
            this.textbox_Pack4,
            this.labelItem33,
            this.textbox_SelPri4,
            this.labelItem22,
            this.textbox_Qty4,
            this.labelItem23,
            this.textbox_Cost4,
            this.labelItem20,
            this.txtBarCode4,
            this.radiobutton_RButDef4});
            this.sideBarPanelItem_Unit4.Text = "الوحدة الرابعة";
            // 
            // labelItem19
            // 
            this.labelItem19.BackColor = System.Drawing.Color.AliceBlue;
            this.labelItem19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem19.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelItem19.Name = "labelItem19";
            this.labelItem19.Text = "الوحدة";
            this.labelItem19.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // comboboxItems_Unit4
            // 
            this.comboboxItems_Unit4.ComboWidth = 217;
            this.comboboxItems_Unit4.DropDownHeight = 106;
            this.comboboxItems_Unit4.ItemHeight = 14;
            this.comboboxItems_Unit4.Name = "comboboxItems_Unit4";
            this.comboboxItems_Unit4.Text = "comboBoxItem1";
            this.comboboxItems_Unit4.SelectedIndexChanged += new System.EventHandler(this.comboboxItems_Unit4_SelectedIndexChanged);
            this.comboboxItems_Unit4.Click += new System.EventHandler(this.Button_Edit_Click);
            // 
            // labelItem21
            // 
            this.labelItem21.BackColor = System.Drawing.Color.AliceBlue;
            this.labelItem21.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem21.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelItem21.Name = "labelItem21";
            this.labelItem21.Text = "التعبئة";
            this.labelItem21.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // textbox_Pack4
            // 
            this.textbox_Pack4.MaxLength = 8;
            this.textbox_Pack4.Name = "textbox_Pack4";
            this.textbox_Pack4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textbox_Pack4.TextBoxWidth = 217;
            this.textbox_Pack4.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.textbox_Pack4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_Pack4_KeyPress);
            this.textbox_Pack4.Click += new System.EventHandler(this.Button_Edit_Click);
            this.textbox_Pack4.GotFocus += new System.EventHandler(this.txtBarCode1_GotFocus);
            // 
            // labelItem33
            // 
            this.labelItem33.BackColor = System.Drawing.Color.AliceBlue;
            this.labelItem33.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem33.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelItem33.Name = "labelItem33";
            this.labelItem33.Text = "سعر البيع";
            this.labelItem33.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // textbox_SelPri4
            // 
            this.textbox_SelPri4.MaxLength = 8;
            this.textbox_SelPri4.Name = "textbox_SelPri4";
            this.textbox_SelPri4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textbox_SelPri4.TextBoxWidth = 218;
            this.textbox_SelPri4.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.textbox_SelPri4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_Pack4_KeyPress);
            this.textbox_SelPri4.Click += new System.EventHandler(this.Button_Edit_Click);
            this.textbox_SelPri4.GotFocus += new System.EventHandler(this.txtBarCode1_GotFocus);
            // 
            // labelItem22
            // 
            this.labelItem22.BackColor = System.Drawing.Color.AliceBlue;
            this.labelItem22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem22.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelItem22.Name = "labelItem22";
            this.labelItem22.Text = "الكمية";
            this.labelItem22.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // textbox_Qty4
            // 
            this.textbox_Qty4.Enabled = false;
            this.textbox_Qty4.MaxLength = 8;
            this.textbox_Qty4.Name = "textbox_Qty4";
            this.textbox_Qty4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textbox_Qty4.TextBoxWidth = 217;
            this.textbox_Qty4.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.textbox_Qty4.Click += new System.EventHandler(this.Button_Edit_Click);
            // 
            // labelItem23
            // 
            this.labelItem23.BackColor = System.Drawing.Color.AliceBlue;
            this.labelItem23.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem23.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelItem23.Name = "labelItem23";
            this.labelItem23.Text = "التكلفة";
            this.labelItem23.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // textbox_Cost4
            // 
            this.textbox_Cost4.Enabled = false;
            this.textbox_Cost4.MaxLength = 8;
            this.textbox_Cost4.Name = "textbox_Cost4";
            this.textbox_Cost4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textbox_Cost4.TextBoxWidth = 217;
            this.textbox_Cost4.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.textbox_Cost4.Click += new System.EventHandler(this.Button_Edit_Click);
            // 
            // labelItem20
            // 
            this.labelItem20.BackColor = System.Drawing.Color.AliceBlue;
            this.labelItem20.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem20.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelItem20.Name = "labelItem20";
            this.labelItem20.Text = "رقم الباركود";
            this.labelItem20.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // txtBarCode4
            // 
            this.txtBarCode4.ButtonCustom.Checked = true;
            this.txtBarCode4.ButtonCustom.Visible = true;
            this.txtBarCode4.CanCustomize = false;
            this.txtBarCode4.MaxLength = 250;
            this.txtBarCode4.Name = "txtBarCode4";
            this.txtBarCode4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBarCode4.TextBoxWidth = 217;
            this.txtBarCode4.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.txtBarCode4.ButtonCustomClick += new System.EventHandler(this.txtBarCode4_ButtonCustomClick);
            this.txtBarCode4.Click += new System.EventHandler(this.Button_Edit_Click);
            this.txtBarCode4.LostFocus += new System.EventHandler(this.txtBarCode4_Leave);
            this.txtBarCode4.GotFocus += new System.EventHandler(this.txtBarCode1_GotFocus);
            // 
            // radiobutton_RButDef4
            // 
            this.radiobutton_RButDef4.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.radiobutton_RButDef4.Enabled = false;
            this.radiobutton_RButDef4.Name = "radiobutton_RButDef4";
            this.radiobutton_RButDef4.Text = "الوحدة الإفتراضية";
            this.radiobutton_RButDef4.CheckedChanged += new DevComponents.DotNetBar.CheckBoxChangeEventHandler(this.radiobutton_RButDef4_CheckedChanged);
            // 
            // sideBarPanelItem_Unit5
            // 
            this.sideBarPanelItem_Unit5.FontBold = true;
            this.sideBarPanelItem_Unit5.Name = "sideBarPanelItem_Unit5";
            this.sideBarPanelItem_Unit5.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem24,
            this.comboboxItems_Unit5,
            this.labelItem26,
            this.textbox_Pack5,
            this.labelItem34,
            this.textbox_SelPri5,
            this.labelItem27,
            this.textbox_Qty5,
            this.labelItem28,
            this.textbox_Cost5,
            this.labelItem25,
            this.txtBarCode5,
            this.radiobutton_RButDef5});
            this.sideBarPanelItem_Unit5.Text = "الوحدة الخامسة";
            // 
            // labelItem24
            // 
            this.labelItem24.BackColor = System.Drawing.Color.AliceBlue;
            this.labelItem24.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem24.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelItem24.Name = "labelItem24";
            this.labelItem24.Text = "الوحدة";
            this.labelItem24.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // comboboxItems_Unit5
            // 
            this.comboboxItems_Unit5.ComboWidth = 217;
            this.comboboxItems_Unit5.DropDownHeight = 106;
            this.comboboxItems_Unit5.ItemHeight = 14;
            this.comboboxItems_Unit5.Name = "comboboxItems_Unit5";
            this.comboboxItems_Unit5.Text = "comboBoxItem1";
            this.comboboxItems_Unit5.SelectedIndexChanged += new System.EventHandler(this.comboboxItems_Unit5_SelectedIndexChanged);
            this.comboboxItems_Unit5.Click += new System.EventHandler(this.Button_Edit_Click);
            // 
            // labelItem26
            // 
            this.labelItem26.BackColor = System.Drawing.Color.AliceBlue;
            this.labelItem26.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem26.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelItem26.Name = "labelItem26";
            this.labelItem26.Text = "التعبئة";
            this.labelItem26.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // textbox_Pack5
            // 
            this.textbox_Pack5.MaxLength = 8;
            this.textbox_Pack5.Name = "textbox_Pack5";
            this.textbox_Pack5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textbox_Pack5.TextBoxWidth = 217;
            this.textbox_Pack5.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.textbox_Pack5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_Pack5_KeyPress);
            this.textbox_Pack5.Click += new System.EventHandler(this.Button_Edit_Click);
            this.textbox_Pack5.GotFocus += new System.EventHandler(this.txtBarCode1_GotFocus);
            // 
            // labelItem34
            // 
            this.labelItem34.BackColor = System.Drawing.Color.AliceBlue;
            this.labelItem34.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem34.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelItem34.Name = "labelItem34";
            this.labelItem34.Text = "سعر البيع";
            this.labelItem34.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // textbox_SelPri5
            // 
            this.textbox_SelPri5.MaxLength = 8;
            this.textbox_SelPri5.Name = "textbox_SelPri5";
            this.textbox_SelPri5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textbox_SelPri5.TextBoxWidth = 218;
            this.textbox_SelPri5.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.textbox_SelPri5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_Pack5_KeyPress);
            this.textbox_SelPri5.Click += new System.EventHandler(this.Button_Edit_Click);
            this.textbox_SelPri5.GotFocus += new System.EventHandler(this.txtBarCode1_GotFocus);
            // 
            // labelItem27
            // 
            this.labelItem27.BackColor = System.Drawing.Color.AliceBlue;
            this.labelItem27.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem27.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelItem27.Name = "labelItem27";
            this.labelItem27.Text = "الكمية";
            this.labelItem27.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // textbox_Qty5
            // 
            this.textbox_Qty5.Enabled = false;
            this.textbox_Qty5.MaxLength = 8;
            this.textbox_Qty5.Name = "textbox_Qty5";
            this.textbox_Qty5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textbox_Qty5.TextBoxWidth = 217;
            this.textbox_Qty5.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.textbox_Qty5.Click += new System.EventHandler(this.Button_Edit_Click);
            // 
            // labelItem28
            // 
            this.labelItem28.BackColor = System.Drawing.Color.AliceBlue;
            this.labelItem28.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem28.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelItem28.Name = "labelItem28";
            this.labelItem28.Text = "التكلفة";
            this.labelItem28.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // textbox_Cost5
            // 
            this.textbox_Cost5.Enabled = false;
            this.textbox_Cost5.MaxLength = 8;
            this.textbox_Cost5.Name = "textbox_Cost5";
            this.textbox_Cost5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textbox_Cost5.TextBoxWidth = 217;
            this.textbox_Cost5.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.textbox_Cost5.Click += new System.EventHandler(this.Button_Edit_Click);
            // 
            // labelItem25
            // 
            this.labelItem25.BackColor = System.Drawing.Color.AliceBlue;
            this.labelItem25.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem25.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelItem25.Name = "labelItem25";
            this.labelItem25.Text = "رقم الباركود";
            this.labelItem25.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // txtBarCode5
            // 
            this.txtBarCode5.ButtonCustom.Checked = true;
            this.txtBarCode5.ButtonCustom.Visible = true;
            this.txtBarCode5.CanCustomize = false;
            this.txtBarCode5.MaxLength = 250;
            this.txtBarCode5.Name = "txtBarCode5";
            this.txtBarCode5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBarCode5.TextBoxWidth = 217;
            this.txtBarCode5.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.txtBarCode5.ButtonCustomClick += new System.EventHandler(this.txtBarCode5_ButtonCustomClick);
            this.txtBarCode5.Click += new System.EventHandler(this.Button_Edit_Click);
            this.txtBarCode5.LostFocus += new System.EventHandler(this.txtBarCode5_Leave);
            this.txtBarCode5.GotFocus += new System.EventHandler(this.txtBarCode1_GotFocus);
            // 
            // radiobutton_RButDef5
            // 
            this.radiobutton_RButDef5.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.radiobutton_RButDef5.Enabled = false;
            this.radiobutton_RButDef5.Name = "radiobutton_RButDef5";
            this.radiobutton_RButDef5.Text = "الوحدة الإفتراضية";
            this.radiobutton_RButDef5.CheckedChanged += new DevComponents.DotNetBar.CheckBoxChangeEventHandler(this.radiobutton_RButDef5_CheckedChanged);
            this.radiobutton_RButDef5.Click += new System.EventHandler(this.Button_Edit_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            this.imageList1.Images.SetKeyName(10, "");
            this.imageList1.Images.SetKeyName(11, "");
            this.imageList1.Images.SetKeyName(12, "");
            this.imageList1.Images.SetKeyName(13, "");
            this.imageList1.Images.SetKeyName(14, "");
            this.imageList1.Images.SetKeyName(15, "");
            this.imageList1.Images.SetKeyName(16, "");
            this.imageList1.Images.SetKeyName(17, "");
            this.imageList1.Images.SetKeyName(18, "");
            this.imageList1.Images.SetKeyName(19, "");
            this.imageList1.Images.SetKeyName(20, "");
            this.imageList1.Images.SetKeyName(21, "");
            this.imageList1.Images.SetKeyName(22, "");
            this.imageList1.Images.SetKeyName(23, "");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Det,
            this.ToolStripMenuItem_Rep});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip2.Size = new System.Drawing.Size(149, 48);
            // 
            // ToolStripMenuItem_Det
            // 
            this.ToolStripMenuItem_Det.Name = "ToolStripMenuItem_Det";
            this.ToolStripMenuItem_Det.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItem_Det.Text = "إظهار التفاصيل";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "*.rtf";
            this.openFileDialog1.Filter = "*.bmp|*.dip|*.gif|*.jpg|*.wmf|*.emf";
            this.openFileDialog1.FilterIndex = 2;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "*.rtf";
            this.saveFileDialog1.FileName = "doc1";
            this.saveFileDialog1.Filter = "Text Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf|All Files(*.*)|*.*";
            this.saveFileDialog1.FilterIndex = 2;
            this.saveFileDialog1.Title = "Save File";
            // 
            // panelEx3
            // 
            this.panelEx3.Controls.Add(this.DGV_Main);
            this.panelEx3.Controls.Add(this.ribbonBar_DGV);
            this.panelEx3.Location = new System.Drawing.Point(0, -12);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(923, 10);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.panelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.panelEx3.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile;
            this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 2;
            this.panelEx3.Text = "Fill Panel";
            // 
            // DGV_Main
            // 
            this.DGV_Main.BackColor = System.Drawing.Color.Transparent;
            background1.BackFillType = DevComponents.DotNetBar.SuperGrid.Style.BackFillType.VerticalCenter;
            background1.Color1 = System.Drawing.Color.Silver;
            background1.Color2 = System.Drawing.Color.White;
            this.DGV_Main.DefaultVisualStyles.GroupByStyles.Default.Background = background1;
            background2.BackFillType = DevComponents.DotNetBar.SuperGrid.Style.BackFillType.Center;
            background2.Color1 = System.Drawing.Color.LightSteelBlue;
            this.DGV_Main.DefaultVisualStyles.RowStyles.Default.Background = background2;
            background3.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.DGV_Main.DefaultVisualStyles.RowStyles.MouseOver.Background = background3;
            this.DGV_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Main.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.DGV_Main.Font = new System.Drawing.Font("Tahoma", 9F);
            this.DGV_Main.ForeColor = System.Drawing.Color.Black;
            this.DGV_Main.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.DGV_Main.Location = new System.Drawing.Point(0, 0);
            this.DGV_Main.Name = "DGV_Main";
            this.DGV_Main.PrimaryGrid.ActiveRowIndicatorStyle = DevComponents.DotNetBar.SuperGrid.ActiveRowIndicatorStyle.Both;
            this.DGV_Main.PrimaryGrid.AllowEdit = false;
            this.DGV_Main.PrimaryGrid.Caption.BackgroundImageLayout = DevComponents.DotNetBar.SuperGrid.GridBackgroundImageLayout.Center;
            this.DGV_Main.PrimaryGrid.Caption.Text = "";
            this.DGV_Main.PrimaryGrid.Caption.Visible = false;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.False;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.TextColor = System.Drawing.Color.Black;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.False;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.TextColor = System.Drawing.Color.Black;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.CaptionStyles.Default.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.CaptionStyles.Default.TextColor = System.Drawing.Color.White;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.CaptionStyles.ReadOnly.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.CellStyles.Selected.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.ColumnHeaderRowStyles.Default.RowHeader.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            borderColor1.Bottom = System.Drawing.Color.Black;
            borderColor1.Left = System.Drawing.Color.Black;
            borderColor1.Right = System.Drawing.Color.Black;
            borderColor1.Top = System.Drawing.Color.Black;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.BorderColor = borderColor1;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.TextColor = System.Drawing.Color.SteelBlue;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.TextColor = System.Drawing.Color.White;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.FooterStyles.Default.TextColor = System.Drawing.Color.White;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.False;
            borderColor2.Bottom = System.Drawing.Color.Black;
            borderColor2.Left = System.Drawing.Color.Black;
            borderColor2.Right = System.Drawing.Color.Black;
            borderColor2.Top = System.Drawing.Color.Black;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.BorderColor = borderColor2;
            baseTreeButtonVisualStyle1.BorderColor = System.Drawing.Color.White;
            baseTreeButtonVisualStyle1.LineColor = System.Drawing.Color.White;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.CircleTreeButtonStyle.ExpandButton = baseTreeButtonVisualStyle1;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.HeaderHLinePattern = DevComponents.DotNetBar.SuperGrid.Style.LinePattern.None;
            background4.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            baseTreeButtonVisualStyle2.Background = background4;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.SquareTreeButtonStyle.ExpandButton = baseTreeButtonVisualStyle2;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.TextColor = System.Drawing.Color.White;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.TitleStyles.Default.RowHeaderStyle.TextAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.DGV_Main.PrimaryGrid.GroupByRow.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.Never;
            this.DGV_Main.PrimaryGrid.GroupByRow.Text = "جميــع السجــــلات";
            this.DGV_Main.PrimaryGrid.GroupByRow.Visible = true;
            this.DGV_Main.PrimaryGrid.GroupByRow.WatermarkText = "";
            this.DGV_Main.PrimaryGrid.InitialActiveRow = DevComponents.DotNetBar.SuperGrid.RelativeRow.None;
            this.DGV_Main.PrimaryGrid.InitialSelection = DevComponents.DotNetBar.SuperGrid.RelativeSelection.None;
            this.DGV_Main.PrimaryGrid.MultiSelect = false;
            this.DGV_Main.PrimaryGrid.ShowRowGridIndex = true;
            this.DGV_Main.PrimaryGrid.Title.AllowSelection = false;
            this.DGV_Main.PrimaryGrid.Title.Text = "";
            this.DGV_Main.PrimaryGrid.Title.Visible = false;
            this.DGV_Main.PrimaryGrid.Visible = false;
            this.DGV_Main.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DGV_Main.Size = new System.Drawing.Size(923, 0);
            this.DGV_Main.TabIndex = 870;
            // 
            // ribbonBar_DGV
            // 
            this.ribbonBar_DGV.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar_DGV.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar_DGV.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar_DGV.ContainerControlProcessDialogKey = true;
            this.ribbonBar_DGV.Controls.Add(this.superTabControl_DGV);
            this.ribbonBar_DGV.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ribbonBar_DGV.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar_DGV.Location = new System.Drawing.Point(0, -41);
            this.ribbonBar_DGV.Name = "ribbonBar_DGV";
            this.ribbonBar_DGV.Size = new System.Drawing.Size(923, 51);
            this.ribbonBar_DGV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar_DGV.TabIndex = 871;
            // 
            // 
            // 
            this.ribbonBar_DGV.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar_DGV.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar_DGV.TitleVisible = false;
            // 
            // superTabControl_DGV
            // 
            this.superTabControl_DGV.BackColor = System.Drawing.Color.White;
            this.superTabControl_DGV.CausesValidation = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl_DGV.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl_DGV.ControlBox.MenuBox.Name = "";
            this.superTabControl_DGV.ControlBox.Name = "";
            this.superTabControl_DGV.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl_DGV.ControlBox.MenuBox,
            this.superTabControl_DGV.ControlBox.CloseBox});
            this.superTabControl_DGV.ControlBox.Visible = false;
            this.superTabControl_DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl_DGV.ForeColor = System.Drawing.Color.Black;
            this.superTabControl_DGV.ItemPadding.Bottom = 4;
            this.superTabControl_DGV.ItemPadding.Left = 4;
            this.superTabControl_DGV.ItemPadding.Right = 4;
            this.superTabControl_DGV.ItemPadding.Top = 4;
            this.superTabControl_DGV.Location = new System.Drawing.Point(0, 0);
            this.superTabControl_DGV.Name = "superTabControl_DGV";
            this.superTabControl_DGV.ReorderTabsEnabled = true;
            this.superTabControl_DGV.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.superTabControl_DGV.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabControl_DGV.SelectedTabIndex = -1;
            this.superTabControl_DGV.Size = new System.Drawing.Size(923, 51);
            this.superTabControl_DGV.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl_DGV.TabIndex = 12;
            this.superTabControl_DGV.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.textBox_search,
            this.Button_ExportTable2,
            this.Button_PrintTable,
            this.labelItem3,
            this.buttonItem7});
            this.superTabControl_DGV.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            this.superTabControl_DGV.Text = "superTabControl1";
            this.superTabControl_DGV.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            // 
            // textBox_search
            // 
            this.textBox_search.ButtonCustom.Text = "...";
            this.textBox_search.ButtonCustom.Visible = true;
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.TextBoxHeight = 44;
            this.textBox_search.TextBoxWidth = 150;
            this.textBox_search.WatermarkColor = System.Drawing.SystemColors.GrayText;
            // 
            // Button_ExportTable2
            // 
            this.Button_ExportTable2.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_ExportTable2.FontBold = true;
            this.Button_ExportTable2.FontItalic = true;
            this.Button_ExportTable2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Button_ExportTable2.Image = ((System.Drawing.Image)(resources.GetObject("Button_ExportTable2.Image")));
            this.Button_ExportTable2.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.Button_ExportTable2.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_ExportTable2.Name = "Button_ExportTable2";
            this.Button_ExportTable2.SubItemsExpandWidth = 14;
            this.Button_ExportTable2.Symbol = "";
            this.Button_ExportTable2.SymbolSize = 15F;
            this.Button_ExportTable2.Text = "تصدير";
            this.Button_ExportTable2.Tooltip = "تصدير الى الأكسيل";
            // 
            // Button_PrintTable
            // 
            this.Button_PrintTable.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_PrintTable.Checked = true;
            this.Button_PrintTable.FontBold = true;
            this.Button_PrintTable.FontItalic = true;
            this.Button_PrintTable.Image = ((System.Drawing.Image)(resources.GetObject("Button_PrintTable.Image")));
            this.Button_PrintTable.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.Button_PrintTable.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_PrintTable.Name = "Button_PrintTable";
            this.Button_PrintTable.SubItemsExpandWidth = 14;
            this.Button_PrintTable.Symbol = "";
            this.Button_PrintTable.SymbolSize = 15F;
            this.Button_PrintTable.Text = "طباعة";
            this.Button_PrintTable.Tooltip = "طباعة";
            // 
            // labelItem3
            // 
            this.labelItem3.Name = "labelItem3";
            this.labelItem3.Width = 40;
            // 
            // buttonItem7
            // 
            this.buttonItem7.Name = "buttonItem7";
            this.buttonItem7.Symbol = "";
            this.buttonItem7.Text = "عودة";
            this.buttonItem7.Click += new System.EventHandler(this.buttonItem7_Click);
            // 
            // panelEx2
            // 
            this.panelEx2.Controls.Add(this.ribbonBar_Units);
            this.panelEx2.Controls.Add(this.ribbonBar_Tasks);
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx2.Location = new System.Drawing.Point(0, -72);
            this.panelEx2.MinimumSize = new System.Drawing.Size(823, 445);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(1282, 578);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 0;
            this.panelEx2.Text = "Click to collapse";
            // 
            // ribbonBar_Tasks
            // 
            this.ribbonBar_Tasks.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar_Tasks.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar_Tasks.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar_Tasks.ContainerControlProcessDialogKey = true;
            this.ribbonBar_Tasks.Controls.Add(this.superTabControl_Main1);
            this.ribbonBar_Tasks.Controls.Add(this.superTabControl_Main2);
            this.ribbonBar_Tasks.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ribbonBar_Tasks.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar_Tasks.Location = new System.Drawing.Point(0, 527);
            this.ribbonBar_Tasks.Name = "ribbonBar_Tasks";
            this.ribbonBar_Tasks.Size = new System.Drawing.Size(1282, 51);
            this.ribbonBar_Tasks.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar_Tasks.TabIndex = 887;
            // 
            // 
            // 
            this.ribbonBar_Tasks.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar_Tasks.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar_Tasks.TitleVisible = false;
            // 
            // superTabControl_Main1
            // 
            this.superTabControl_Main1.BackColor = System.Drawing.Color.White;
            this.superTabControl_Main1.CausesValidation = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl_Main1.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl_Main1.ControlBox.MenuBox.Name = "";
            this.superTabControl_Main1.ControlBox.Name = "";
            this.superTabControl_Main1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl_Main1.ControlBox.MenuBox,
            this.superTabControl_Main1.ControlBox.CloseBox});
            this.superTabControl_Main1.ControlBox.Visible = false;
            this.superTabControl_Main1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl_Main1.ForeColor = System.Drawing.Color.Black;
            this.superTabControl_Main1.ItemPadding.Bottom = 4;
            this.superTabControl_Main1.ItemPadding.Left = 2;
            this.superTabControl_Main1.ItemPadding.Top = 4;
            this.superTabControl_Main1.Location = new System.Drawing.Point(0, 0);
            this.superTabControl_Main1.Name = "superTabControl_Main1";
            this.superTabControl_Main1.ReorderTabsEnabled = true;
            this.superTabControl_Main1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.superTabControl_Main1.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabControl_Main1.SelectedTabIndex = -1;
            this.superTabControl_Main1.Size = new System.Drawing.Size(889, 51);
            this.superTabControl_Main1.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl_Main1.TabIndex = 12;
            this.superTabControl_Main1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem_x,
            this.Button_Close,
            this.Button_Search,
            this.Button_Delete,
            this.Button_Save,
            this.Button_Add,
            this.labelItem2,
            this.buttonItem_Serials,
            this.buttonItem8});
            this.superTabControl_Main1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            this.superTabControl_Main1.Text = "superTabControl3";
            this.superTabControl_Main1.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            // 
            // buttonItem_x
            // 
            this.buttonItem_x.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem_x.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonItem_x.FontBold = true;
            this.buttonItem_x.ForeColor = System.Drawing.Color.White;
            this.buttonItem_x.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem_x.Image")));
            this.buttonItem_x.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.buttonItem_x.ImagePaddingHorizontal = 15;
            this.buttonItem_x.ImagePaddingVertical = 11;
            this.buttonItem_x.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem_x.Name = "buttonItem_x";
            this.buttonItem_x.Stretch = true;
            this.buttonItem_x.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem_EditPriceAll,
            this.buttonItem_EditPrice,
            this.buttonItem_AddDisProcess});
            this.buttonItem_x.Symbol = "";
            this.buttonItem_x.SymbolSize = 15F;
            this.buttonItem_x.Tooltip = "تعديل اسعار بيع وتكلفة الصنف";
            // 
            // buttonItem_EditPriceAll
            // 
            this.buttonItem_EditPriceAll.Checked = true;
            this.buttonItem_EditPriceAll.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.buttonItem_EditPriceAll.Name = "buttonItem_EditPriceAll";
            this.buttonItem_EditPriceAll.Symbol = "";
            this.buttonItem_EditPriceAll.Text = "تعديل أسعــار جميــع الأصنــاف";
            this.buttonItem_EditPriceAll.Click += new System.EventHandler(this.buttonItem_EditPriceAll_Click);
            // 
            // buttonItem_EditPrice
            // 
            this.buttonItem_EditPrice.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.buttonItem_EditPrice.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem_EditPrice.Image")));
            this.buttonItem_EditPrice.Name = "buttonItem_EditPrice";
            this.buttonItem_EditPrice.Symbol = "";
            this.buttonItem_EditPrice.Text = "تعديل سعر وتكاليف هذا الصنف";
            this.buttonItem_EditPrice.Click += new System.EventHandler(this.buttonItem_EditPrice_Click);
            // 
            // buttonItem_AddDisProcess
            // 
            this.buttonItem_AddDisProcess.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.buttonItem_AddDisProcess.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem_AddDisProcess.Image")));
            this.buttonItem_AddDisProcess.Name = "buttonItem_AddDisProcess";
            this.buttonItem_AddDisProcess.Symbol = "";
            this.buttonItem_AddDisProcess.Text = "عمليات الزيادة والنقصان";
            this.buttonItem_AddDisProcess.Click += new System.EventHandler(this.buttonItem_AddDisProcess_Click);
            // 
            // Button_Close
            // 
            this.Button_Close.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Close.Checked = true;
            this.Button_Close.FontBold = true;
            this.Button_Close.ForeColor = System.Drawing.Color.Black;
            this.Button_Close.Image = ((System.Drawing.Image)(resources.GetObject("Button_Close.Image")));
            this.Button_Close.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_Close.ImagePaddingHorizontal = 15;
            this.Button_Close.ImagePaddingVertical = 11;
            this.Button_Close.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_Close.Name = "Button_Close";
            this.Button_Close.Stretch = true;
            this.Button_Close.SubItemsExpandWidth = 14;
            this.Button_Close.Symbol = "";
            this.Button_Close.SymbolSize = 15F;
            this.Button_Close.Text = "إغلاق";
            this.Button_Close.Tooltip = "إغلاق النافذة الحالية";
            // 
            // Button_Search
            // 
            this.Button_Search.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Search.FontBold = true;
            this.Button_Search.FontItalic = true;
            this.Button_Search.ForeColor = System.Drawing.Color.Green;
            this.Button_Search.Image = ((System.Drawing.Image)(resources.GetObject("Button_Search.Image")));
            this.Button_Search.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_Search.ImagePaddingHorizontal = 15;
            this.Button_Search.ImagePaddingVertical = 11;
            this.Button_Search.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_Search.Name = "Button_Search";
            this.Button_Search.Stretch = true;
            this.Button_Search.SubItemsExpandWidth = 14;
            this.Button_Search.Symbol = "";
            this.Button_Search.SymbolSize = 15F;
            this.Button_Search.Text = "بحث";
            this.Button_Search.Tooltip = "البحث عن سجل ما";
            // 
            // Button_Delete
            // 
            this.Button_Delete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Delete.FontBold = true;
            this.Button_Delete.FontItalic = true;
            this.Button_Delete.ForeColor = System.Drawing.Color.SteelBlue;
            this.Button_Delete.Image = ((System.Drawing.Image)(resources.GetObject("Button_Delete.Image")));
            this.Button_Delete.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_Delete.ImagePaddingHorizontal = 15;
            this.Button_Delete.ImagePaddingVertical = 11;
            this.Button_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_Delete.Name = "Button_Delete";
            this.Button_Delete.Stretch = true;
            this.Button_Delete.SubItemsExpandWidth = 14;
            this.Button_Delete.Symbol = "";
            this.Button_Delete.SymbolSize = 15F;
            this.Button_Delete.Text = "حذف";
            this.Button_Delete.Tooltip = "حذف السجل الحالي";
            // 
            // Button_Save
            // 
            this.Button_Save.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Save.FontBold = true;
            this.Button_Save.FontItalic = true;
            this.Button_Save.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Button_Save.Image = ((System.Drawing.Image)(resources.GetObject("Button_Save.Image")));
            this.Button_Save.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_Save.ImagePaddingHorizontal = 15;
            this.Button_Save.ImagePaddingVertical = 11;
            this.Button_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_Save.Name = "Button_Save";
            this.Button_Save.Stretch = true;
            this.Button_Save.SubItemsExpandWidth = 14;
            this.Button_Save.Symbol = "";
            this.Button_Save.SymbolSize = 15F;
            this.Button_Save.Text = "حفظ";
            this.Button_Save.Tooltip = "حفظ التغييرات";
            // 
            // Button_Add
            // 
            this.Button_Add.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Add.FontBold = true;
            this.Button_Add.FontItalic = true;
            this.Button_Add.ForeColor = System.Drawing.Color.Blue;
            this.Button_Add.Image = ((System.Drawing.Image)(resources.GetObject("Button_Add.Image")));
            this.Button_Add.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_Add.ImagePaddingHorizontal = 15;
            this.Button_Add.ImagePaddingVertical = 11;
            this.Button_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_Add.Name = "Button_Add";
            this.Button_Add.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.Button_Add.Stretch = true;
            this.Button_Add.SubItemsExpandWidth = 14;
            this.Button_Add.Symbol = "";
            this.Button_Add.SymbolSize = 15F;
            this.Button_Add.Text = "إضافة";
            this.Button_Add.Tooltip = "إضافة سجل جديد";
            // 
            // labelItem2
            // 
            this.labelItem2.Name = "labelItem2";
            this.labelItem2.Visible = false;
            this.labelItem2.Width = 20;
            // 
            // buttonItem_Serials
            // 
            this.buttonItem_Serials.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem_Serials.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.buttonItem_Serials.FontBold = true;
            this.buttonItem_Serials.ForeColor = System.Drawing.Color.Black;
            this.buttonItem_Serials.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem_Serials.Image")));
            this.buttonItem_Serials.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.buttonItem_Serials.ImagePaddingHorizontal = 15;
            this.buttonItem_Serials.ImagePaddingVertical = 11;
            this.buttonItem_Serials.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem_Serials.Name = "buttonItem_Serials";
            this.buttonItem_Serials.Stretch = true;
            this.buttonItem_Serials.SubItemsExpandWidth = 14;
            this.buttonItem_Serials.Symbol = "";
            this.buttonItem_Serials.SymbolSize = 15F;
            this.buttonItem_Serials.Text = "السيريال";
            this.buttonItem_Serials.Click += new System.EventHandler(this.buttonItem_Serials_Click);
            // 
            // buttonItem8
            // 
            this.buttonItem8.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem8.ImagePaddingHorizontal = 15;
            this.buttonItem8.ImagePaddingVertical = 11;
            this.buttonItem8.Name = "buttonItem8";
            this.buttonItem8.Stretch = true;
            this.buttonItem8.Symbol = "";
            this.buttonItem8.SymbolSize = 15F;
            this.buttonItem8.Tag = "تصدير";
            this.buttonItem8.Text = "تصدير";
            this.buttonItem8.Tooltip = "تصدير";
            this.buttonItem8.Click += new System.EventHandler(this.buttonItem8_Click);
            // 
            // superTabControl_Main2
            // 
            this.superTabControl_Main2.BackColor = System.Drawing.Color.White;
            this.superTabControl_Main2.CausesValidation = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl_Main2.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl_Main2.ControlBox.MenuBox.Name = "";
            this.superTabControl_Main2.ControlBox.Name = "";
            this.superTabControl_Main2.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl_Main2.ControlBox.MenuBox,
            this.superTabControl_Main2.ControlBox.CloseBox});
            this.superTabControl_Main2.ControlBox.Visible = false;
            this.superTabControl_Main2.Dock = System.Windows.Forms.DockStyle.Right;
            this.superTabControl_Main2.ForeColor = System.Drawing.Color.Black;
            this.superTabControl_Main2.ItemPadding.Bottom = 4;
            this.superTabControl_Main2.ItemPadding.Left = 4;
            this.superTabControl_Main2.ItemPadding.Right = 4;
            this.superTabControl_Main2.ItemPadding.Top = 4;
            this.superTabControl_Main2.Location = new System.Drawing.Point(889, 0);
            this.superTabControl_Main2.Name = "superTabControl_Main2";
            this.superTabControl_Main2.ReorderTabsEnabled = true;
            this.superTabControl_Main2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.superTabControl_Main2.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabControl_Main2.SelectedTabIndex = -1;
            this.superTabControl_Main2.Size = new System.Drawing.Size(393, 51);
            this.superTabControl_Main2.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl_Main2.TabIndex = 13;
            this.superTabControl_Main2.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem1,
            this.Button_First,
            this.Button_Prev,
            this.TextBox_Index,
            this.Label_Count,
            this.lable_Records,
            this.Button_Next,
            this.Button_Last});
            this.superTabControl_Main2.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            this.superTabControl_Main2.Text = "superTabControl1";
            this.superTabControl_Main2.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            // 
            // labelItem1
            // 
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Width = 2;
            // 
            // Button_First
            // 
            this.Button_First.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_First.FontBold = true;
            this.Button_First.FontItalic = true;
            this.Button_First.ForeColor = System.Drawing.Color.SteelBlue;
            this.Button_First.Image = ((System.Drawing.Image)(resources.GetObject("Button_First.Image")));
            this.Button_First.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_First.ImagePaddingHorizontal = 15;
            this.Button_First.ImagePaddingVertical = 11;
            this.Button_First.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_First.Name = "Button_First";
            this.Button_First.SplitButton = true;
            this.Button_First.Stretch = true;
            this.Button_First.SubItemsExpandWidth = 14;
            this.Button_First.Symbol = "";
            this.Button_First.SymbolSize = 15F;
            this.Button_First.Text = "الأول";
            this.Button_First.Tooltip = "السجل الاول";
            // 
            // Button_Prev
            // 
            this.Button_Prev.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Prev.FontBold = true;
            this.Button_Prev.FontItalic = true;
            this.Button_Prev.ForeColor = System.Drawing.Color.SteelBlue;
            this.Button_Prev.Image = ((System.Drawing.Image)(resources.GetObject("Button_Prev.Image")));
            this.Button_Prev.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_Prev.ImagePaddingHorizontal = 15;
            this.Button_Prev.ImagePaddingVertical = 11;
            this.Button_Prev.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_Prev.Name = "Button_Prev";
            this.Button_Prev.SplitButton = true;
            this.Button_Prev.Stretch = true;
            this.Button_Prev.SubItemsExpandWidth = 14;
            this.Button_Prev.Symbol = "";
            this.Button_Prev.SymbolSize = 15F;
            this.Button_Prev.Text = "السابق";
            this.Button_Prev.Tooltip = "السجل السابق";
            // 
            // TextBox_Index
            // 
            this.TextBox_Index.Name = "TextBox_Index";
            this.TextBox_Index.TextBoxWidth = 50;
            this.TextBox_Index.Visible = false;
            this.TextBox_Index.WatermarkColor = System.Drawing.SystemColors.GrayText;
            // 
            // Label_Count
            // 
            this.Label_Count.Name = "Label_Count";
            this.Label_Count.Visible = false;
            this.Label_Count.Width = 40;
            // 
            // lable_Records
            // 
            this.lable_Records.BackColor = System.Drawing.Color.SteelBlue;
            this.lable_Records.ForeColor = System.Drawing.Color.White;
            this.lable_Records.Name = "lable_Records";
            this.lable_Records.Text = "---";
            // 
            // Button_Next
            // 
            this.Button_Next.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Next.FontBold = true;
            this.Button_Next.FontItalic = true;
            this.Button_Next.ForeColor = System.Drawing.Color.SteelBlue;
            this.Button_Next.Image = ((System.Drawing.Image)(resources.GetObject("Button_Next.Image")));
            this.Button_Next.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_Next.ImagePaddingHorizontal = 15;
            this.Button_Next.ImagePaddingVertical = 11;
            this.Button_Next.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_Next.Name = "Button_Next";
            this.Button_Next.SplitButton = true;
            this.Button_Next.Stretch = true;
            this.Button_Next.SubItemsExpandWidth = 14;
            this.Button_Next.Symbol = "";
            this.Button_Next.SymbolSize = 15F;
            this.Button_Next.Text = "التالي";
            this.Button_Next.Tooltip = " السجل التالي";
            // 
            // Button_Last
            // 
            this.Button_Last.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Last.FontBold = true;
            this.Button_Last.FontItalic = true;
            this.Button_Last.ForeColor = System.Drawing.Color.SteelBlue;
            this.Button_Last.Image = ((System.Drawing.Image)(resources.GetObject("Button_Last.Image")));
            this.Button_Last.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_Last.ImagePaddingHorizontal = 15;
            this.Button_Last.ImagePaddingVertical = 11;
            this.Button_Last.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_Last.Name = "Button_Last";
            this.Button_Last.SplitButton = true;
            this.Button_Last.Stretch = true;
            this.Button_Last.SubItemsExpandWidth = 14;
            this.Button_Last.Symbol = "";
            this.Button_Last.SymbolSize = 15F;
            this.Button_Last.Text = "الأخير";
            this.Button_Last.Tooltip = " السجل الاخير";
            // 
            // expandableSplitter1
            // 
            this.expandableSplitter1.BackColor = System.Drawing.Color.Black;
            this.expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.None;
            this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.None;
            this.expandableSplitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.expandableSplitter1.ExpandableControl = this.panelEx2;
            this.expandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.expandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.ExpandLineColor = System.Drawing.SystemColors.ControlText;
            this.expandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.ForeColor = System.Drawing.Color.Black;
            this.expandableSplitter1.GripDarkColor = System.Drawing.SystemColors.ControlText;
            this.expandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.expandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(142)))), ((int)(((byte)(75)))));
            this.expandableSplitter1.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(139)))));
            this.expandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.expandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.expandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotExpandLineColor = System.Drawing.SystemColors.ControlText;
            this.expandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.expandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.expandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.Location = new System.Drawing.Point(1268, 0);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(14, 0);
            this.expandableSplitter1.TabIndex = 1;
            this.expandableSplitter1.TabStop = false;
            this.expandableSplitter1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelEx3);
            this.panel1.Controls.Add(this.expandableSplitter1);
            this.panel1.Controls.Add(this.panelEx2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1282, 506);
            this.panel1.TabIndex = 877;
            // 
            // superTabItem1
            // 
            this.superTabItem1.GlobalItem = false;
            this.superTabItem1.Name = "superTabItem1";
            this.superTabItem1.Text = "superTabItem1";
            // 
            // txtCurr
            // 
            this.txtCurr.Location = new System.Drawing.Point(-75, 20);
            this.txtCurr.Name = "txtCurr";
            this.txtCurr.Size = new System.Drawing.Size(100, 20);
            this.txtCurr.TabIndex = 880;
            this.txtCurr.Visible = false;
            // 
            // combobox_Unit5
            // 
            this.combobox_Unit5.FormattingEnabled = true;
            this.combobox_Unit5.Location = new System.Drawing.Point(-233, 644);
            this.combobox_Unit5.Name = "combobox_Unit5";
            this.combobox_Unit5.Size = new System.Drawing.Size(106, 21);
            this.combobox_Unit5.TabIndex = 885;
            // 
            // combobox_Unit4
            // 
            this.combobox_Unit4.FormattingEnabled = true;
            this.combobox_Unit4.Location = new System.Drawing.Point(-233, 617);
            this.combobox_Unit4.Name = "combobox_Unit4";
            this.combobox_Unit4.Size = new System.Drawing.Size(106, 21);
            this.combobox_Unit4.TabIndex = 884;
            // 
            // combobox_Unit3
            // 
            this.combobox_Unit3.FormattingEnabled = true;
            this.combobox_Unit3.Location = new System.Drawing.Point(-233, 590);
            this.combobox_Unit3.Name = "combobox_Unit3";
            this.combobox_Unit3.Size = new System.Drawing.Size(106, 21);
            this.combobox_Unit3.TabIndex = 883;
            // 
            // combobox_Unit2
            // 
            this.combobox_Unit2.FormattingEnabled = true;
            this.combobox_Unit2.Location = new System.Drawing.Point(-233, 563);
            this.combobox_Unit2.Name = "combobox_Unit2";
            this.combobox_Unit2.Size = new System.Drawing.Size(106, 21);
            this.combobox_Unit2.TabIndex = 882;
            // 
            // combobox_Unit1
            // 
            this.combobox_Unit1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.combobox_Unit1.FormattingEnabled = true;
            this.combobox_Unit1.Location = new System.Drawing.Point(-233, 536);
            this.combobox_Unit1.Name = "combobox_Unit1";
            this.combobox_Unit1.Size = new System.Drawing.Size(106, 21);
            this.combobox_Unit1.TabIndex = 881;
            // 
            // printDialog1
            // 
            this.printDialog1.AllowSelection = true;
            this.printDialog1.AllowSomePages = true;
            this.printDialog1.Document = this.prnt_doc;
            this.printDialog1.UseEXDialog = true;
            // 
            // prnt_doc
            // 
            this.prnt_doc.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.prnt_doc_BeginPrint);
            this.prnt_doc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.prnt_doc_PrintPage);
            this.prnt_doc.QueryPageSettings += new System.Drawing.Printing.QueryPageSettingsEventHandler(this.prnt_doc_QueryPageSettings);
            // 
            // prnt_prev
            // 
            this.prnt_prev.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.prnt_prev.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.prnt_prev.ClientSize = new System.Drawing.Size(400, 300);
            this.prnt_prev.Document = this.prnt_doc;
            this.prnt_prev.Enabled = true;
            this.prnt_prev.Icon = ((System.Drawing.Icon)(resources.GetObject("prnt_prev.Icon")));
            this.prnt_prev.Name = "prnt_prev";
            this.prnt_prev.ShowIcon = false;
            this.prnt_prev.Visible = false;
            this.prnt_prev.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.prnt_prev_FormClosed);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.Filter = "*.bmp|*.dip|*.gif|*.jpg|*.wmf|*.emf";
            this.openFileDialog2.SupportMultiDottedExtensions = true;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.metroStatusBar_itemsType);
            this.panel2.Controls.Add(this.superTabControl_Info);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 273);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(974, 133);
            this.panel2.TabIndex = 1618;
            // 
            // metroStatusBar_itemsType
            // 
            this.metroStatusBar_itemsType.BackColor = System.Drawing.Color.LightCyan;
            // 
            // 
            // 
            this.metroStatusBar_itemsType.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroStatusBar_itemsType.BackgroundStyle.BackgroundImagePosition = DevComponents.DotNetBar.eStyleBackgroundImage.Center;
            this.metroStatusBar_itemsType.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.metroStatusBar_itemsType.BackgroundStyle.BorderBottomColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.metroStatusBar_itemsType.BackgroundStyle.BorderBottomWidth = 2;
            this.metroStatusBar_itemsType.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.metroStatusBar_itemsType.BackgroundStyle.BorderLeftWidth = 2;
            this.metroStatusBar_itemsType.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.metroStatusBar_itemsType.BackgroundStyle.BorderRightWidth = 2;
            this.metroStatusBar_itemsType.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.metroStatusBar_itemsType.BackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.metroStatusBar_itemsType.BackgroundStyle.BorderTopWidth = 2;
            this.metroStatusBar_itemsType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroStatusBar_itemsType.ContainerControlProcessDialogKey = true;
            this.metroStatusBar_itemsType.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroStatusBar_itemsType.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.metroStatusBar_itemsType.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem29,
            this.radioButton_Goods,
            this.radioButton_RawMaterial,
            this.radioButton_Service,
            this.radioButton_Product});
            this.metroStatusBar_itemsType.ItemSpacing = 15;
            this.metroStatusBar_itemsType.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.metroStatusBar_itemsType.Location = new System.Drawing.Point(0, 0);
            this.metroStatusBar_itemsType.Name = "metroStatusBar_itemsType";
            this.metroStatusBar_itemsType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.metroStatusBar_itemsType.Size = new System.Drawing.Size(974, 35);
            this.metroStatusBar_itemsType.TabIndex = 902;
            // 
            // labelItem29
            // 
            this.labelItem29.Name = "labelItem29";
            // 
            // radioButton_Goods
            // 
            this.radioButton_Goods.BeginGroup = true;
            this.radioButton_Goods.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.radioButton_Goods.Checked = true;
            this.radioButton_Goods.CheckState = System.Windows.Forms.CheckState.Checked;
            this.radioButton_Goods.Name = "radioButton_Goods";
            this.radioButton_Goods.Stretch = true;
            this.radioButton_Goods.Text = "سلعة";
            this.radioButton_Goods.TextColor = System.Drawing.Color.SteelBlue;
            // 
            // radioButton_RawMaterial
            // 
            this.radioButton_RawMaterial.BeginGroup = true;
            this.radioButton_RawMaterial.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.radioButton_RawMaterial.Name = "radioButton_RawMaterial";
            this.radioButton_RawMaterial.Stretch = true;
            this.radioButton_RawMaterial.Text = "مواد خامة";
            this.radioButton_RawMaterial.TextColor = System.Drawing.Color.SteelBlue;
            // 
            // radioButton_Service
            // 
            this.radioButton_Service.BeginGroup = true;
            this.radioButton_Service.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.radioButton_Service.Name = "radioButton_Service";
            this.radioButton_Service.Stretch = true;
            this.radioButton_Service.Text = "خدمة";
            this.radioButton_Service.TextColor = System.Drawing.Color.SteelBlue;
            // 
            // radioButton_Product
            // 
            this.radioButton_Product.BeginGroup = true;
            this.radioButton_Product.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.radioButton_Product.Name = "radioButton_Product";
            this.radioButton_Product.Stretch = true;
            this.radioButton_Product.Text = "مجمعّة";
            this.radioButton_Product.TextColor = System.Drawing.Color.SteelBlue;
            // 
            // superTabControl_Info
            // 
            this.superTabControl_Info.BackColor = System.Drawing.Color.Red;
            // 
            // 
            // 
            this.superTabControl_Info.ControlBox.Category = null;
            // 
            // 
            // 
            this.superTabControl_Info.ControlBox.CloseBox.Category = null;
            this.superTabControl_Info.ControlBox.CloseBox.Description = null;
            this.superTabControl_Info.ControlBox.CloseBox.Name = "";
            this.superTabControl_Info.ControlBox.CloseBox.Tag = null;
            this.superTabControl_Info.ControlBox.Description = null;
            // 
            // 
            // 
            this.superTabControl_Info.ControlBox.MenuBox.Category = null;
            this.superTabControl_Info.ControlBox.MenuBox.Description = null;
            this.superTabControl_Info.ControlBox.MenuBox.Name = "";
            this.superTabControl_Info.ControlBox.MenuBox.Tag = null;
            this.superTabControl_Info.ControlBox.Name = "";
            this.superTabControl_Info.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl_Info.ControlBox.MenuBox,
            this.superTabControl_Info.ControlBox.CloseBox});
            this.superTabControl_Info.ControlBox.Tag = null;
            this.superTabControl_Info.Controls.Add(this.superTabControlPanel3);
            this.superTabControl_Info.Controls.Add(this.superTabControlPanel7);
            this.superTabControl_Info.Controls.Add(this.superTabControlPanel6);
            this.superTabControl_Info.Controls.Add(this.superTabControlPanel5);
            this.superTabControl_Info.Controls.Add(this.superTabControlPanel4);
            this.superTabControl_Info.Controls.Add(this.superTabControlPanel12);
            this.superTabControl_Info.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.superTabControl_Info.ForeColor = System.Drawing.Color.Black;
            this.superTabControl_Info.Location = new System.Drawing.Point(0, 36);
            this.superTabControl_Info.Name = "superTabControl_Info";
            this.superTabControl_Info.ReorderTabsEnabled = true;
            this.superTabControl_Info.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.superTabControl_Info.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabControl_Info.SelectedTabIndex = 0;
            this.superTabControl_Info.Size = new System.Drawing.Size(974, 97);
            this.superTabControl_Info.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Bottom;
            this.superTabControl_Info.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl_Info.TabHorizontalSpacing = 11;
            this.superTabControl_Info.TabIndex = 1570;
            this.superTabControl_Info.TabLayoutType = DevComponents.DotNetBar.eSuperTabLayoutType.SingleLineFit;
            this.superTabControl_Info.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem_items,
            this.superTabItem2,
            this.superTabItem3,
            this.superTabItem4,
            this.superTabItem5});
            this.superTabControl_Info.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.OneNote2007;
            this.superTabControl_Info.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            // 
            // superTabControlPanel3
            // 
            this.superTabControlPanel3.Controls.Add(this.textBoxX1);
            this.superTabControlPanel3.Controls.Add(this.radioButton1);
            this.superTabControlPanel3.Controls.Add(this.label30);
            this.superTabControlPanel3.Controls.Add(this.textBox3);
            this.superTabControlPanel3.Controls.Add(this.label22);
            this.superTabControlPanel3.Controls.Add(this.textBox4);
            this.superTabControlPanel3.Controls.Add(this.label29);
            this.superTabControlPanel3.Controls.Add(this.textBox2);
            this.superTabControlPanel3.Controls.Add(this.label21);
            this.superTabControlPanel3.Controls.Add(this.textBox1);
            this.superTabControlPanel3.Controls.Add(this.comboBox1);
            this.superTabControlPanel3.Controls.Add(this.label20);
            this.superTabControlPanel3.Controls.Add(this.label19);
            this.superTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel3.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel3.Name = "superTabControlPanel3";
            superTabLinearGradientColorTable1.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.Gray,
        System.Drawing.Color.White};
            superTabLinearGradientColorTable1.GradientAngle = 80;
            superTabPanelItemColorTable1.Background = superTabLinearGradientColorTable1;
            superTabPanelColorTable1.Bottom = superTabPanelItemColorTable1;
            this.superTabControlPanel3.PanelColor = superTabPanelColorTable1;
            this.superTabControlPanel3.Size = new System.Drawing.Size(974, 74);
            this.superTabControlPanel3.TabIndex = 0;
            this.superTabControlPanel3.TabItem = this.superTabItem_items;
            // 
            // textBoxX1
            // 
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX1.ButtonCustom.Visible = true;
            this.textBoxX1.Location = new System.Drawing.Point(190, 50);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.Size = new System.Drawing.Size(287, 20);
            this.textBoxX1.TabIndex = 1207;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.BackColor = System.Drawing.Color.Transparent;
            this.radioButton1.Location = new System.Drawing.Point(77, 32);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(103, 17);
            this.radioButton1.TabIndex = 11;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "الوحدة الإفتراضية";
            this.radioButton1.UseVisualStyleBackColor = false;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.BackColor = System.Drawing.Color.Transparent;
            this.label30.Location = new System.Drawing.Point(485, 54);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(66, 13);
            this.label30.TabIndex = 9;
            this.label30.Text = "رقم الباركود :";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(190, 29);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(287, 20);
            this.textBox3.TabIndex = 8;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Location = new System.Drawing.Point(484, 32);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(46, 13);
            this.label22.TabIndex = 7;
            this.label22.Text = "التكلفة :";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(190, 8);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(287, 20);
            this.textBox4.TabIndex = 6;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.Location = new System.Drawing.Point(483, 11);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(43, 13);
            this.label29.TabIndex = 5;
            this.label29.Text = "الكمية :";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(557, 50);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(346, 20);
            this.textBox2.TabIndex = 4;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Location = new System.Drawing.Point(910, 53);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 13);
            this.label21.TabIndex = 3;
            this.label21.Text = "سعر البيع:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(557, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(346, 20);
            this.textBox1.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(557, 7);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(346, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Location = new System.Drawing.Point(909, 32);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(47, 13);
            this.label20.TabIndex = 0;
            this.label20.Text = " التعبئة :";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Location = new System.Drawing.Point(909, 15);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(43, 13);
            this.label19.TabIndex = 0;
            this.label19.Text = "الوحدة :";
            // 
            // superTabItem_items
            // 
            this.superTabItem_items.AttachedControl = this.superTabControlPanel3;
            this.superTabItem_items.GlobalItem = false;
            this.superTabItem_items.Name = "superTabItem_items";
            superTabLinearGradientColorTable2.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.White};
            superTabItemStateColorTable1.Background = superTabLinearGradientColorTable2;
            superTabColorStates1.Normal = superTabItemStateColorTable1;
            superTabItemColorTable1.Bottom = superTabColorStates1;
            this.superTabItem_items.TabColor = superTabItemColorTable1;
            this.superTabItem_items.Text = "الوحدة الاولى";
            // 
            // superTabControlPanel7
            // 
            this.superTabControlPanel7.Controls.Add(this.textBoxX6);
            this.superTabControlPanel7.Controls.Add(this.label53);
            this.superTabControlPanel7.Controls.Add(this.textBox17);
            this.superTabControlPanel7.Controls.Add(this.label54);
            this.superTabControlPanel7.Controls.Add(this.textBox18);
            this.superTabControlPanel7.Controls.Add(this.label55);
            this.superTabControlPanel7.Controls.Add(this.textBox19);
            this.superTabControlPanel7.Controls.Add(this.label56);
            this.superTabControlPanel7.Controls.Add(this.textBox20);
            this.superTabControlPanel7.Controls.Add(this.comboBox5);
            this.superTabControlPanel7.Controls.Add(this.label57);
            this.superTabControlPanel7.Controls.Add(this.label58);
            this.superTabControlPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel7.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel7.Name = "superTabControlPanel7";
            this.superTabControlPanel7.Size = new System.Drawing.Size(974, 74);
            this.superTabControlPanel7.TabIndex = 0;
            this.superTabControlPanel7.TabItem = this.superTabItem5;
            // 
            // textBoxX6
            // 
            // 
            // 
            // 
            this.textBoxX6.Border.Class = "TextBoxBorder";
            this.textBoxX6.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX6.ButtonCustom.Visible = true;
            this.textBoxX6.Location = new System.Drawing.Point(99, 49);
            this.textBoxX6.Name = "textBoxX6";
            this.textBoxX6.Size = new System.Drawing.Size(287, 20);
            this.textBoxX6.TabIndex = 1219;
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.BackColor = System.Drawing.Color.Transparent;
            this.label53.Location = new System.Drawing.Point(394, 53);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(66, 13);
            this.label53.TabIndex = 1218;
            this.label53.Text = "رقم الباركود :";
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(99, 28);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(287, 20);
            this.textBox17.TabIndex = 1217;
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.BackColor = System.Drawing.Color.Transparent;
            this.label54.Location = new System.Drawing.Point(393, 31);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(46, 13);
            this.label54.TabIndex = 1216;
            this.label54.Text = "التكلفة :";
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(99, 7);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(287, 20);
            this.textBox18.TabIndex = 1215;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.BackColor = System.Drawing.Color.Transparent;
            this.label55.Location = new System.Drawing.Point(392, 10);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(43, 13);
            this.label55.TabIndex = 1214;
            this.label55.Text = "الكمية :";
            // 
            // textBox19
            // 
            this.textBox19.Location = new System.Drawing.Point(466, 49);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(346, 20);
            this.textBox19.TabIndex = 1213;
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.BackColor = System.Drawing.Color.Transparent;
            this.label56.Location = new System.Drawing.Point(819, 52);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(56, 13);
            this.label56.TabIndex = 1212;
            this.label56.Text = "سعر البيع:";
            // 
            // textBox20
            // 
            this.textBox20.Location = new System.Drawing.Point(466, 28);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(346, 20);
            this.textBox20.TabIndex = 1211;
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(466, 6);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(346, 21);
            this.comboBox5.TabIndex = 1210;
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.BackColor = System.Drawing.Color.Transparent;
            this.label57.Location = new System.Drawing.Point(818, 31);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(47, 13);
            this.label57.TabIndex = 1208;
            this.label57.Text = " التعبئة :";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.BackColor = System.Drawing.Color.Transparent;
            this.label58.Location = new System.Drawing.Point(818, 14);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(43, 13);
            this.label58.TabIndex = 1209;
            this.label58.Text = "الوحدة :";
            // 
            // superTabItem5
            // 
            this.superTabItem5.AttachedControl = this.superTabControlPanel7;
            this.superTabItem5.GlobalItem = false;
            this.superTabItem5.Name = "superTabItem5";
            this.superTabItem5.Text = "الوحدة الخامسة";
            // 
            // superTabControlPanel6
            // 
            this.superTabControlPanel6.Controls.Add(this.textBoxX5);
            this.superTabControlPanel6.Controls.Add(this.label43);
            this.superTabControlPanel6.Controls.Add(this.textBox13);
            this.superTabControlPanel6.Controls.Add(this.label48);
            this.superTabControlPanel6.Controls.Add(this.textBox14);
            this.superTabControlPanel6.Controls.Add(this.label49);
            this.superTabControlPanel6.Controls.Add(this.textBox15);
            this.superTabControlPanel6.Controls.Add(this.label50);
            this.superTabControlPanel6.Controls.Add(this.textBox16);
            this.superTabControlPanel6.Controls.Add(this.comboBox4);
            this.superTabControlPanel6.Controls.Add(this.label51);
            this.superTabControlPanel6.Controls.Add(this.label52);
            this.superTabControlPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel6.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel6.Name = "superTabControlPanel6";
            this.superTabControlPanel6.Size = new System.Drawing.Size(974, 74);
            this.superTabControlPanel6.TabIndex = 0;
            this.superTabControlPanel6.TabItem = this.superTabItem4;
            // 
            // textBoxX5
            // 
            // 
            // 
            // 
            this.textBoxX5.Border.Class = "TextBoxBorder";
            this.textBoxX5.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX5.ButtonCustom.Visible = true;
            this.textBoxX5.Location = new System.Drawing.Point(99, 49);
            this.textBoxX5.Name = "textBoxX5";
            this.textBoxX5.Size = new System.Drawing.Size(287, 20);
            this.textBoxX5.TabIndex = 1219;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.BackColor = System.Drawing.Color.Transparent;
            this.label43.Location = new System.Drawing.Point(394, 53);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(66, 13);
            this.label43.TabIndex = 1218;
            this.label43.Text = "رقم الباركود :";
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(99, 28);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(287, 20);
            this.textBox13.TabIndex = 1217;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.BackColor = System.Drawing.Color.Transparent;
            this.label48.Location = new System.Drawing.Point(393, 31);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(46, 13);
            this.label48.TabIndex = 1216;
            this.label48.Text = "التكلفة :";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(99, 7);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(287, 20);
            this.textBox14.TabIndex = 1215;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.BackColor = System.Drawing.Color.Transparent;
            this.label49.Location = new System.Drawing.Point(392, 10);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(43, 13);
            this.label49.TabIndex = 1214;
            this.label49.Text = "الكمية :";
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(466, 49);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(346, 20);
            this.textBox15.TabIndex = 1213;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.BackColor = System.Drawing.Color.Transparent;
            this.label50.Location = new System.Drawing.Point(819, 52);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(56, 13);
            this.label50.TabIndex = 1212;
            this.label50.Text = "سعر البيع:";
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(466, 28);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(346, 20);
            this.textBox16.TabIndex = 1211;
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(466, 6);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(346, 21);
            this.comboBox4.TabIndex = 1210;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.BackColor = System.Drawing.Color.Transparent;
            this.label51.Location = new System.Drawing.Point(818, 31);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(47, 13);
            this.label51.TabIndex = 1208;
            this.label51.Text = " التعبئة :";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.BackColor = System.Drawing.Color.Transparent;
            this.label52.Location = new System.Drawing.Point(818, 14);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(43, 13);
            this.label52.TabIndex = 1209;
            this.label52.Text = "الوحدة :";
            // 
            // superTabItem4
            // 
            this.superTabItem4.AttachedControl = this.superTabControlPanel6;
            this.superTabItem4.GlobalItem = false;
            this.superTabItem4.Name = "superTabItem4";
            this.superTabItem4.Text = "الوحدة الرابعة";
            // 
            // superTabControlPanel5
            // 
            this.superTabControlPanel5.Controls.Add(this.textBoxX3);
            this.superTabControlPanel5.Controls.Add(this.label37);
            this.superTabControlPanel5.Controls.Add(this.textBox9);
            this.superTabControlPanel5.Controls.Add(this.label38);
            this.superTabControlPanel5.Controls.Add(this.textBox10);
            this.superTabControlPanel5.Controls.Add(this.label39);
            this.superTabControlPanel5.Controls.Add(this.textBox11);
            this.superTabControlPanel5.Controls.Add(this.label40);
            this.superTabControlPanel5.Controls.Add(this.textBox12);
            this.superTabControlPanel5.Controls.Add(this.comboBox3);
            this.superTabControlPanel5.Controls.Add(this.label41);
            this.superTabControlPanel5.Controls.Add(this.label42);
            this.superTabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel5.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel5.Name = "superTabControlPanel5";
            this.superTabControlPanel5.Size = new System.Drawing.Size(974, 74);
            this.superTabControlPanel5.TabIndex = 0;
            this.superTabControlPanel5.TabItem = this.superTabItem3;
            // 
            // textBoxX3
            // 
            // 
            // 
            // 
            this.textBoxX3.Border.Class = "TextBoxBorder";
            this.textBoxX3.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX3.ButtonCustom.Visible = true;
            this.textBoxX3.Location = new System.Drawing.Point(99, 49);
            this.textBoxX3.Name = "textBoxX3";
            this.textBoxX3.Size = new System.Drawing.Size(287, 20);
            this.textBoxX3.TabIndex = 1219;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.BackColor = System.Drawing.Color.Transparent;
            this.label37.Location = new System.Drawing.Point(394, 53);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(66, 13);
            this.label37.TabIndex = 1218;
            this.label37.Text = "رقم الباركود :";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(99, 28);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(287, 20);
            this.textBox9.TabIndex = 1217;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.BackColor = System.Drawing.Color.Transparent;
            this.label38.Location = new System.Drawing.Point(393, 31);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(46, 13);
            this.label38.TabIndex = 1216;
            this.label38.Text = "التكلفة :";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(99, 7);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(287, 20);
            this.textBox10.TabIndex = 1215;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.BackColor = System.Drawing.Color.Transparent;
            this.label39.Location = new System.Drawing.Point(392, 10);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(43, 13);
            this.label39.TabIndex = 1214;
            this.label39.Text = "الكمية :";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(466, 49);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(346, 20);
            this.textBox11.TabIndex = 1213;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.BackColor = System.Drawing.Color.Transparent;
            this.label40.Location = new System.Drawing.Point(819, 52);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(56, 13);
            this.label40.TabIndex = 1212;
            this.label40.Text = "سعر البيع:";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(466, 28);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(346, 20);
            this.textBox12.TabIndex = 1211;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(466, 6);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(346, 21);
            this.comboBox3.TabIndex = 1210;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.BackColor = System.Drawing.Color.Transparent;
            this.label41.Location = new System.Drawing.Point(818, 31);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(47, 13);
            this.label41.TabIndex = 1208;
            this.label41.Text = " التعبئة :";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.BackColor = System.Drawing.Color.Transparent;
            this.label42.Location = new System.Drawing.Point(818, 14);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(43, 13);
            this.label42.TabIndex = 1209;
            this.label42.Text = "الوحدة :";
            // 
            // superTabItem3
            // 
            this.superTabItem3.AttachedControl = this.superTabControlPanel5;
            this.superTabItem3.GlobalItem = false;
            this.superTabItem3.Name = "superTabItem3";
            this.superTabItem3.Text = "الوحدة الثالثة";
            // 
            // superTabControlPanel4
            // 
            this.superTabControlPanel4.Controls.Add(this.textBoxX2);
            this.superTabControlPanel4.Controls.Add(this.label31);
            this.superTabControlPanel4.Controls.Add(this.textBox5);
            this.superTabControlPanel4.Controls.Add(this.label32);
            this.superTabControlPanel4.Controls.Add(this.textBox6);
            this.superTabControlPanel4.Controls.Add(this.label33);
            this.superTabControlPanel4.Controls.Add(this.textBox7);
            this.superTabControlPanel4.Controls.Add(this.label34);
            this.superTabControlPanel4.Controls.Add(this.textBox8);
            this.superTabControlPanel4.Controls.Add(this.comboBox2);
            this.superTabControlPanel4.Controls.Add(this.label35);
            this.superTabControlPanel4.Controls.Add(this.label36);
            this.superTabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel4.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel4.Name = "superTabControlPanel4";
            this.superTabControlPanel4.Size = new System.Drawing.Size(974, 74);
            this.superTabControlPanel4.TabIndex = 0;
            this.superTabControlPanel4.TabItem = this.superTabItem2;
            // 
            // textBoxX2
            // 
            // 
            // 
            // 
            this.textBoxX2.Border.Class = "TextBoxBorder";
            this.textBoxX2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX2.ButtonCustom.Visible = true;
            this.textBoxX2.Location = new System.Drawing.Point(124, 49);
            this.textBoxX2.Name = "textBoxX2";
            this.textBoxX2.Size = new System.Drawing.Size(287, 20);
            this.textBoxX2.TabIndex = 1219;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.BackColor = System.Drawing.Color.Transparent;
            this.label31.Location = new System.Drawing.Point(419, 53);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(66, 13);
            this.label31.TabIndex = 1218;
            this.label31.Text = "رقم الباركود :";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(124, 28);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(287, 20);
            this.textBox5.TabIndex = 1217;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.BackColor = System.Drawing.Color.Transparent;
            this.label32.Location = new System.Drawing.Point(418, 31);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(46, 13);
            this.label32.TabIndex = 1216;
            this.label32.Text = "التكلفة :";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(124, 7);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(287, 20);
            this.textBox6.TabIndex = 1215;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.BackColor = System.Drawing.Color.Transparent;
            this.label33.Location = new System.Drawing.Point(417, 10);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(43, 13);
            this.label33.TabIndex = 1214;
            this.label33.Text = "الكمية :";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(491, 49);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(346, 20);
            this.textBox7.TabIndex = 1213;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BackColor = System.Drawing.Color.Transparent;
            this.label34.Location = new System.Drawing.Point(844, 52);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(56, 13);
            this.label34.TabIndex = 1212;
            this.label34.Text = "سعر البيع:";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(491, 28);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(346, 20);
            this.textBox8.TabIndex = 1211;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(491, 6);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(346, 21);
            this.comboBox2.TabIndex = 1210;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BackColor = System.Drawing.Color.Transparent;
            this.label35.Location = new System.Drawing.Point(843, 31);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(47, 13);
            this.label35.TabIndex = 1208;
            this.label35.Text = " التعبئة :";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.BackColor = System.Drawing.Color.Transparent;
            this.label36.Location = new System.Drawing.Point(843, 14);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(43, 13);
            this.label36.TabIndex = 1209;
            this.label36.Text = "الوحدة :";
            // 
            // superTabItem2
            // 
            this.superTabItem2.AttachedControl = this.superTabControlPanel4;
            this.superTabItem2.GlobalItem = false;
            this.superTabItem2.Name = "superTabItem2";
            this.superTabItem2.Text = "الوحدة الثانية";
            // 
            // superTabControlPanel12
            // 
            this.superTabControlPanel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel12.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel12.Name = "superTabControlPanel12";
            this.superTabControlPanel12.Size = new System.Drawing.Size(974, 74);
            this.superTabControlPanel12.TabIndex = 4;
            // 
            // FrmItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 506);
            this.Controls.Add(this.combobox_Unit5);
            this.Controls.Add(this.combobox_Unit4);
            this.Controls.Add(this.combobox_Unit3);
            this.Controls.Add(this.combobox_Unit2);
            this.Controls.Add(this.combobox_Unit1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtCurr);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmItems";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الأصناف";
            this.Load += new System.EventHandler(this.FrmItems_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmItems_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmItems_KeyPress);
            this.Move += new System.EventHandler(this.FrmItems_Move);
            this.ribbonBar_Units.ResumeLayout(false);
            this.ribbonBar_Units.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            this.superTabControlPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_DisItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_TaxPurchase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_TaxSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_CommItm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid_Items)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textbox_MaxQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textbox_Supreme)).EndInit();
            this.groupPanel_Inv.ResumeLayout(false);
            this.groupPanel_Inv.PerformLayout();
            this.superTabControlPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FlxInv)).EndInit();
            this.expandablePanel_AnotherPrice.ResumeLayout(false);
            this.expandablePanel_AnotherPrice.PerformLayout();
            this.panelEx_Size.ResumeLayout(false);
            this.panelEx_Size.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textbox_Sentence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textbox_Legates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textbox_Distributors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textbox_VIP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textbox_Sectorial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textbox_DateNo)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.panelEx3.ResumeLayout(false);
            this.ribbonBar_DGV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_DGV)).EndInit();
            this.panelEx2.ResumeLayout(false);
            this.ribbonBar_Tasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main2)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Info)).EndInit();
            this.superTabControl_Info.ResumeLayout(false);
            this.superTabControlPanel3.ResumeLayout(false);
            this.superTabControlPanel3.PerformLayout();
            this.superTabControlPanel7.ResumeLayout(false);
            this.superTabControlPanel7.PerformLayout();
            this.superTabControlPanel6.ResumeLayout(false);
            this.superTabControlPanel6.PerformLayout();
            this.superTabControlPanel5.ResumeLayout(false);
            this.superTabControlPanel5.PerformLayout();
            this.superTabControlPanel4.ResumeLayout(false);
            this.superTabControlPanel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
		}
        int flagsho = 0;
        private void c1Button1_Click(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
        }
        private void c1Button2_Click(object sender, EventArgs e)
        {
          
        }
        private void buttonItem7_Click(object sender, EventArgs e)
        {
            ViewDetails_Click(sender, e);
            panelEx3.Visible = false;
        }
        private void c1Button2_Click_1(object sender, EventArgs e)
        {
            ViewTable_Click(sender, e);
            panelEx3.Visible = true;
            this.Controls.Add(panelEx3);
            panelEx3.Dock = DockStyle.Fill;
            panelEx3.BringToFront();
        }
        private void buttonItem8_Click(object sender, EventArgs e)
        {
            ViewTable_Click(sender, e);
            panelEx3.Visible = true;
            this.Controls.Add(panelEx3);
            panelEx3.Dock = DockStyle.Fill;
            panelEx3.BringToFront();
        }
        private void labelItem6_Click(object sender, EventArgs e)
        {
        }
        private void superTabControlPanel1_Click(object sender, EventArgs e)
        {
        }
        private void FrmItems_Move(object sender, EventArgs e)
        {
            this.Text = this.Location.X + "          y=" + this.Location.Y;
        }
        private void textbox_Legates_ValueChanged(object sender, EventArgs e)
        {
        }
    }
}
