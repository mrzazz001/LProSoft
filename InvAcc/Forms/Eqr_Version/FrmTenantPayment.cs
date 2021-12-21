using C1.Win.C1BarCode;
using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Primitives;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.Editors;
using Framework.Keyboard;
using InvAcc;
using ProShared.GeneralM;
using ProShared.Stock_Data;
using SSSDateTime.Date;
using SSSLanguage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace InvAcc.Forms
{
	public class FrmTenantPayment : Form
	{
		private IContainer components = null;

		protected IntegerInput Rep_RecCount;

		protected ToolStripMenuItem ToolStripMenuItem_Rep;

		private RibbonBar ribbonBar1;

		private DockSite barTopDockSite;

		private DockSite barBottomDockSite;

		private DockSite barLeftDockSite;

		private DockSite barRightDockSite;

		private DockSite dockSite1;

		private DockSite dockSite2;

		public DotNetBarManager dotNetBarManager1;

		private DockSite dockSite4;

		private DockSite dockSite3;

		protected System.Windows.Forms.ContextMenuStrip contextMenuStrip1;

		protected System.Windows.Forms.ContextMenuStrip contextMenuStrip2;

		protected ToolStripMenuItem ToolStripMenuItem_Det;

		private OpenFileDialog openFileDialog1;

		private SaveFileDialog saveFileDialog1;

		private PanelEx panelEx3;

		private PanelEx panelEx2;

		private ExpandableSplitter expandableSplitter1;

		private Panel panel1;

		private RibbonBar ribbonBar_Tasks;

		private SuperTabControl superTabControl_Main2;

		protected LabelItem labelItem1;

		protected ButtonItem Button_First;

		protected ButtonItem Button_Prev;

		protected TextBoxItem TextBox_Index;

		protected LabelItem Label_Count;

		protected ButtonItem Button_Next;

		protected ButtonItem Button_Last;

		protected SuperGridControl DGV_Main;

		private RibbonBar ribbonBar_DGV;

		private SuperTabControl superTabControl_DGV;

		protected TextBoxItem textBox_search;

		protected ButtonItem Button_ExportTable2;

		protected ButtonItem Button_PrintTable;

		protected LabelItem labelItem3;

		private Label label19;

		private Label label4;

		private C1BarCode c1BarCode1;

		private DoubleInput txtRentOfYear;

		private LabelItem lable_Records;

		internal Label label22;

		private Label label3;

		private Label label7;

		public TextBox txtTenantName;

		public TextBox txtTenantNo;

		public TextBox textBox_ID;

		private Label label18;

		private ComboBox CmbTenanPayMethod;

		private C1FlexGrid FlxPayment;

		public MaskedTextBox txtContractStart;

		public MaskedTextBox txtContractEnd;

		private SuperTabControl superTabControl_Main1;

		protected ButtonItem Button_Close;

		protected ButtonItem Button_Search;

		protected ButtonItem Button_Delete;

		protected ButtonItem Button_Save;

		protected ButtonItem Button_Add;

		protected LabelItem labelItem2;

		public Dictionary<string, FrmTenantPayment.ColumnDictinary> columns_Names_visible = new Dictionary<string, FrmTenantPayment.ColumnDictinary>();

		public Dictionary<string, FrmTenantPayment.ColumnDictinary> columns_Names_visible2 = new Dictionary<string, FrmTenantPayment.ColumnDictinary>();

		private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();

		private T_AccDef _AccDefBind = new T_AccDef();

		private int LangArEn = 0;

		public int ProcessTyp = 0;

		protected bool ifOkDelete;

		public bool CanEdit = true;

		protected bool CanInsert = true;

		private string FlagUpdate = "";

		public ViewState ViewState = ViewState.Deiles;

		private FormState statex;

		public List<Control> controls;

		public Control codeControl = new Control();

		private T_INVSETTING _InvSetting = new T_INVSETTING();

		private T_Company _Company = new T_Company();

		private T_TenantPayment _TenantPayment = new T_TenantPayment();

		private bool canUpdate = true;

		public T_TenantContract data_this;

		private List<T_TenantPayment> LData_This;

		private Stock_DataDataContext dbInstance;

		private List<string> pkeys = new List<string>();

		private Rate_DataDataContext dbInstanceRate;

		private T_User permission = new T_User();

		public bool FrmTyp = false;

		public bool SelectPayment = false;

		public int _ContractNo;

		public int Payment_No = 0;

		protected bool CanUpdate
		{
			get
			{
				return this.canUpdate;
			}
			set
			{
				this.canUpdate = value;
			}
		}

		private Stock_DataDataContext db
		{
			get
			{
				if (this.dbInstance == null)
				{
					this.dbInstance = new Stock_DataDataContext(VarGeneral.BranchCS);
				}
				return this.dbInstance;
			}
		}

		private Rate_DataDataContext dbc
		{
			get
			{
				if (this.dbInstanceRate == null)
				{
					this.dbInstanceRate = new Rate_DataDataContext(VarGeneral.BranchRt);
				}
				return this.dbInstanceRate;
			}
		}

		public bool IfDelete
		{
			set
			{
				this.Button_Delete.Visible = value;
				this.superTabControl_Main1.Refresh();
			}
		}

		public bool IfSave
		{
			set
			{
				this.Button_Save.Visible = value;
			}
		}

		public List<T_TenantPayment> LDataThis
		{
			get
			{
				return this.LData_This;
			}
			set
			{
				this.LData_This = value;
			}
		}

		public int PaymentNo
		{
			get
			{
				return this.Payment_No;
			}
			set
			{
				this.Payment_No = value;
			}
		}

		public T_User Permmission
		{
			get
			{
				return this.permission;
			}
			set
			{
				if ((value == null ? false : value.UsrNo != ""))
				{
					this.permission = value;
				}
			}
		}

		public List<string> PKeys
		{
			get
			{
				return this.pkeys;
			}
			set
			{
				this.pkeys = value;
			}
		}

		public bool SetReadOnly
		{
			set
			{
				if (value)
				{
					this.State = FormState.Saved;
				}
				this.Button_Save.Enabled = !value;
			}
		}

		public FormState State
		{
			get
			{
				return this.statex;
			}
			set
			{
				this.statex = value;
			}
		}

		public FrmTenantPayment()
		{
			this.InitializeComponent();
			this.txtContractEnd.Click += new EventHandler(this.Button_Edit_Click);
			this.txtContractStart.Click += new EventHandler(this.Button_Edit_Click);
			this.txtRentOfYear.Click += new EventHandler(this.Button_Edit_Click);
			this.txtTenantName.Click += new EventHandler(this.Button_Edit_Click);
			this.txtTenantNo.Click += new EventHandler(this.Button_Edit_Click);
			this.CmbTenanPayMethod.Click += new EventHandler(this.Button_Edit_Click);
			this.FlxPayment.Click += new EventHandler(this.Button_Edit_Click);
			this.DGV_Main.PrimaryGrid.CheckBoxes = false;
			this.DGV_Main.PrimaryGrid.ShowCheckBox = false;
			this.DGV_Main.PrimaryGrid.ShowTreeButton = false;
			this.DGV_Main.PrimaryGrid.ShowTreeButtons = false;
			this.DGV_Main.PrimaryGrid.ShowTreeLines = false;
			this.DGV_Main.PrimaryGrid.RowHeaderWidth = 25;
			this.DGV_Main.PrimaryGrid.VirtualMode = true;
			this.DGV_Main.MouseDown += new MouseEventHandler(this.DGV_Main_MouseDown);
			this.expandableSplitter1.Click += new EventHandler(this.expandableSplitter1_Click);
			this.DGV_Main.CellDoubleClick += new EventHandler<GridCellDoubleClickEventArgs>(this.DGV_Main_CellDoubleClick);
			this.DGV_Main.CellClick += new EventHandler<GridCellClickEventArgs>(this.DGV_Main_CellClick);
			this.ToolStripMenuItem_Det.Click += new EventHandler(this.ToolStripMenuItem_Det_Click);
			this.Button_ExportTable2.Click += new EventHandler(this.Button_ExportTable2_Click);
			this.DGV_Main.CellDoubleClick += new EventHandler<GridCellDoubleClickEventArgs>(this.DGV_Main_CellDoubleClick);
			this.textBox_search.InputTextChanged += new TextBoxItem.TextChangedEventHandler(this.TextBox_Search_InputTextChanged);
			this.textBox_search.ButtonCustomClick += new EventHandler(this.TextBox_Search_ButtonCustomClick);
			this.TextBox_Index.InputTextChanged += new TextBoxItem.TextChangedEventHandler(this.TextBox_Index_InputTextChanged);
			this.DGV_Main.DataBindingComplete += new EventHandler<GridDataBindingCompleteEventArgs>(this.DGV_Main_DataBindingComplete);
			this.Button_Close.Click += new EventHandler(this.Button_Close_Click);
			this.Button_First.Click += new EventHandler(this.Button_First_Click);
			this.Button_Prev.Click += new EventHandler(this.Button_Prev_Click);
			this.Button_Next.Click += new EventHandler(this.Button_Next_Click);
			this.Button_Last.Click += new EventHandler(this.Button_Last_Click);
			this.Button_Add.Click += new EventHandler(this.Button_Add_Click);
			this.Button_Save.Click += new EventHandler(this.Button_Save_Click);
			this.TextBox_Index.InputTextChanged += new TextBoxItem.TextChangedEventHandler(this.TextBox_Index_InputTextChanged);
			this.Button_PrintTable.Click += new EventHandler(this.Button_Print_Click);
		}

		private void _ownerDraw(object sender, OwnerDrawCellEventArgs e)
		{
			if ((e.Col != 0 ? false : e.Row > 0))
			{
				e.Text = e.Row.ToString();
			}
		}

		private void ADD_Controls()
		{
			try
			{
				this.controls = new List<Control>()
				{
					this.textBox_ID,
					this.txtContractEnd,
					this.txtContractStart,
					this.txtRentOfYear,
					this.txtTenantName,
					this.txtTenantNo,
					this.CmbTenanPayMethod
				};
			}
			catch (SqlException sqlException)
			{
			}
		}

		private void ArbEng()
		{
			if ((VarGeneral.CurrentLang.ToString() == "0" ? false : VarGeneral.CurrentLang.ToString() != ""))
			{
				this.LangArEn = 1;
				this.FlxPayment.Cols[1].Caption = "Amount";
				this.FlxPayment.Cols[2].Caption = "Month repayment";
				this.FlxPayment.Cols[3].Caption = "Status";
				this.FlxPayment.Cols[4].Caption = "Residual";
				this.FlxPayment.Cols[5].Caption = "Bond";
				this.FlxPayment.Cols[6].Caption = "Sequence";
				this.FlxPayment.Cols[7].Caption = (this.SelectPayment ? "Select" : "Delete line");
			}
			else
			{
				this.LangArEn = 0;
				this.FlxPayment.Cols[1].Caption = "المبلــغ";
				this.FlxPayment.Cols[2].Caption = "شهر السداد";
				this.FlxPayment.Cols[3].Caption = "حالة السداد";
				this.FlxPayment.Cols[4].Caption = "المتبقي";
				this.FlxPayment.Cols[5].Caption = "السند";
				this.FlxPayment.Cols[6].Caption = "التسلسل";
				this.FlxPayment.Cols[7].Caption = (this.SelectPayment ? "إختيار الدفعة" : "حذف الدفعة");
			}
		}

		private void Button_Add_Click(object sender, EventArgs e)
		{
			if ((this.State != FormState.Edit ? true : MessageBox.Show((this.LangArEn == 0 ? "تم تعديل السجل الحالي دون حفظ التغييرات .. هل تريد المتابعة؟" : "Not saved the changes, do you really want to continue?"), VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes))
			{
				this.Clear();
				this.State = FormState.New;
			}
		}

		private void Button_Close_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void Button_Delete_Click(object sender, EventArgs e)
		{
			if ((!this.Button_Delete.Enabled || !this.Button_Delete.Visible ? false : this.State == FormState.Saved))
			{
				string text = "";
				text = this.textBox_ID.Text;
				if (text != "")
				{
					if (MessageBox.Show(string.Concat(new string[] { "هل أنت متاكد من حذف السجل [", text, "]؟ \n Are you sure that you want to delete the record [", text, "]?" }), VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
					{
						this.ifOkDelete = false;
					}
					else
					{
						this.ifOkDelete = true;
					}
					if ((this.data_this == null || this.data_this.ContractID == 0 ? false : this.ifOkDelete))
					{
						try
						{
							this.db.T_TenantPayments.DeleteAllOnSubmit<T_TenantPayment>(this.data_this.T_TenantPayments);
							this.db.SubmitChanges();
						}
						catch (SqlException sqlException)
						{
						}
						catch (Exception exception)
						{
						}
						base.Close();
					}
				}
				else
				{
					this.ifOkDelete = false;
				}
			}
			else
			{
				this.ifOkDelete = false;
			}
		}

		private void Button_Edit_Click(object sender, EventArgs e)
		{
			if ((!this.CanEdit || this.State == FormState.Edit || this.State == FormState.New ? false : !string.IsNullOrEmpty(this.textBox_ID.Text)))
			{
				if (this.State != FormState.New)
				{
					this.State = FormState.Edit;
				}
				this.SetReadOnly = false;
			}
		}

		private void Button_ExportTable2_Click(object sender, EventArgs e)
		{
			try
			{
				ExportExcel.ExportToExcel(this.DGV_Main, "تقرير العقــود");
			}
			catch
			{
			}
		}

		public void Button_First_Click(object sender, EventArgs e)
		{
			if (this.ContinueIfEditOrNew())
			{
				this.TextBox_Index.TextBox.Text = string.Concat(1);
				this.UpdateVcr();
				this.textBox_ID.Focus();
			}
		}

		public void Button_Last_Click(object sender, EventArgs e)
		{
			if (this.ContinueIfEditOrNew())
			{
				this.TextBox_Index.TextBox.Text = this.Label_Count.Text;
				this.UpdateVcr();
			}
		}

		public void Button_Next_Click(object sender, EventArgs e)
		{
			if (this.ContinueIfEditOrNew())
			{
				int num = 0;
				int num1 = 0;
				try
				{
					num = Convert.ToInt32(this.TextBox_Index.TextBox.Text);
				}
				catch
				{
				}
				try
				{
					num1 = Convert.ToInt32(this.Label_Count.Text);
				}
				catch
				{
				}
				if (num < num1)
				{
					this.TextBox_Index.TextBox.Text = string.Concat(num + 1);
				}
				this.UpdateVcr();
				this.textBox_ID.Focus();
			}
		}

		public void Button_Prev_Click(object sender, EventArgs e)
		{
			if (this.ContinueIfEditOrNew())
			{
				int num = 0;
				try
				{
					num = Convert.ToInt32(this.TextBox_Index.TextBox.Text);
				}
				catch
				{
				}
				if (num > 1)
				{
					this.TextBox_Index.TextBox.Text = string.Concat(num - 1);
				}
				this.UpdateVcr();
				this.textBox_ID.Focus();
			}
		}

		public void Button_Print_Click(object sender, EventArgs e)
		{
			if (this.ViewState != ViewState.Table)
			{
			}
		}

		private void Button_Save_Click(object sender, EventArgs e)
		{
			int? sndNo;
			try
			{ 
				if (this.ValidData())
				{
					if (this.State == FormState.Edit)
					{
						for (int i = 0; i < this.LData_This.ToList<T_TenantPayment>().Count; i++)
						{
							sndNo = this.LDataThis[i].SndNo;
							if (!sndNo.HasValue)
							{
								this.db.T_TenantPayments.DeleteOnSubmit(this.LData_This[i]);
								this.db.SubmitChanges();
							}
						}
					}
					this.GetData();
					try
					{
						this.db.Log = VarGeneral.DebugLog;
						this.db.SubmitChanges(ConflictMode.ContinueOnConflict);
					}
					catch (Exception exception)
					{
						return;
					}
					int j = 0;
					int num = 0;
					for (j = 1; j < this.FlxPayment.Rows.Count; j++)
					{
						try
						{
							if ((double.Parse(this.FlxPayment.GetData(j, 1).ToString()) <= 0 ? false : VarGeneral.CheckDate(this.FlxPayment.GetData(j, 2).ToString())))
							{
								try
								{
									if (!Convert.ToBoolean(this.FlxPayment.GetData(j, 3).ToString()))
									{
										this._TenantPayment = new T_TenantPayment();
									}
									else
									{
										this._TenantPayment = new T_TenantPayment();
										this._TenantPayment = (
											from g in this.LData_This
											where g.PaymentID == int.Parse(this.FlxPayment.GetData(j, 6).ToString())
											select g).FirstOrDefault<T_TenantPayment>();
										if ((this._TenantPayment == null ? true : this._TenantPayment.PaymentID <= 0))
										{
											// Label1;
										}
										else
										{
											// Label2;
										}
									}
								}
								catch
								{
									this._TenantPayment = new T_TenantPayment();
								}
								num++;
								this._TenantPayment.Statue = new bool?(false);
								this._TenantPayment.tenantContract_ID = this.data_this.ContractID;
								this._TenantPayment.PayMonth = this.FlxPayment.GetData(j, 2).ToString();
								sndNo = null;
								this._TenantPayment.SndNo = sndNo;
								try
								{
									this._TenantPayment.Value = new double?(double.Parse(this.FlxPayment.GetData(j, 1).ToString()));
								}
								catch
								{
									this._TenantPayment.Value = new double?(0);
								}
								this._TenantPayment.Remining = this._TenantPayment.Value;
								Label2:
								this._TenantPayment.PaymentNo = num;
								this.db.T_TenantPayments.InsertOnSubmit(this._TenantPayment);
								this.db.SubmitChanges();
							}
							else
							{
								// Label1;
							}
						}
						catch
						{
						}
					 
					}
					MessageBox.Show((this.LangArEn == 0 ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					this.State = FormState.Saved;
					this.SetReadOnly = true;
					base.Close();
				}
			}
			catch (Exception exception2)
			{
				Exception exception1 = exception2;
				VarGeneral.DebLog.writeLog("Save:", exception1, true);
				MessageBox.Show(exception1.Message);
			}
		}

		private void CheckAqsat()
		{
			int num;
			try
			{
				if ((this.txtRentOfYear.Value < 1 || !VarGeneral.CheckDate(this.txtContractStart.Text) ? false : VarGeneral.CheckDate(this.txtContractEnd.Text)))
				{
					int num1 = 0;
					int num2 = 0;
					int num3 = 0;
					int num4 = 0;
					Convert.ToDateTime(this.txtContractStart.Text);
					Convert.ToDateTime(this.txtContractEnd.Text);
					DateTime dateTime = Convert.ToDateTime(this.txtContractStart.Text);
					DateTime dateTime1 = Convert.ToDateTime(this.txtContractEnd.Text);
					while (dateTime < dateTime1)
					{
						dateTime = dateTime.AddMonths(1);
						num1++;
					}
					num1++;
					switch (this.CmbTenanPayMethod.SelectedIndex)
					{
						case 0:
							{
								num2 = 1;
								num = num1 / 1;
								num1 = int.Parse(num.ToString());
								break;
							}
						case 1:
							{
								num2 = 2;
								num = num1 / 2;
								num1 = int.Parse(num.ToString());
								break;
							}
						case 2:
							{
								num2 = 3;
								num = num1 / 3;
								num1 = int.Parse(num.ToString());
								break;
							}
						case 3:
							{
								num2 = 4;
								num = num1 / 4;
								num1 = int.Parse(num.ToString());
								break;
							}
						case 4:
							{
								num2 = 6;
								num = num1 / 6;
								num1 = int.Parse(num.ToString());
								break;
							}
						case 5:
							{
								num2 = 12;
								num = num1 / 12;
								num1 = int.Parse(num.ToString());
								break;
							}
					}
					double value = this.txtRentOfYear.Value % (double)num1;
					double num5 = Math.Truncate(this.txtRentOfYear.Value / (double)num1);
					this.FlxPayment.Clear(ClearFlags.Content, 1, 1, this.FlxPayment.Rows.Count, 7);
					this.FlxPayment.Rows.Count = int.Parse(num1.ToString()) + 50;
					for (int i = 1; i <= num1; i++)
					{
						num3++;
						this.FlxPayment.SetData(num3, 1, (i == num1 ? num5 + value : num5));
						C1FlexGrid flxPayment = this.FlxPayment;
						DateTime dateTime2 = Convert.ToDateTime(this.txtContractStart.Text);
						dateTime2 = dateTime2.AddMonths(num4);
						flxPayment.SetData(num3, 2, dateTime2.ToString("yyyy/MM"));
						this.FlxPayment.SetData(num3, 4, 0);
						num4 += num2;
					}
				}
			}
			catch
			{
			}
		}

		public void Clear()
		{
			if (this.State != FormState.New)
			{
				this.State = FormState.New;
				this.State = FormState.New;
				for (int i = 0; i < this.controls.Count; i++)
				{
					if (this.controls[i].GetType() == typeof(DateTimePicker))
					{
						int? calendr = VarGeneral.Settings_Sys.Calendr;
						if ((calendr.Value != 0 ? true : !calendr.HasValue))
						{
							(this.controls[i] as DateTimePicker).Text = this.n.HDateNow();
						}
						else
						{
							(this.controls[i] as DateTimePicker).Value = Convert.ToDateTime(this.n.GDateNow());
						}
					}
					else if (this.controls[i].GetType() == typeof(CheckBox))
					{
						(this.controls[i] as CheckBox).Checked = false;
					}
					else if (this.controls[i].GetType() == typeof(PictureBox))
					{
						(this.controls[i] as PictureBox).Image = null;
					}
					else if (this.controls[i].Name != this.codeControl.Name)
					{
						if (this.controls[i].GetType() == typeof(DoubleInput))
						{
							(this.controls[i] as DoubleInput).Value = 0;
						}
						else if (this.controls[i].GetType() == typeof(IntegerInput))
						{
							(this.controls[i] as IntegerInput).Value = 0;
						}
						else if ((this.controls[i].GetType() == typeof(TextBox) || this.controls[i].GetType() == typeof(TextBoxX) ? true : this.controls[i].GetType() == typeof(MaskedTextBox)))
						{
							this.controls[i].Text = "";
						}
						else if (this.controls[i].GetType() == typeof(CheckBox))
						{
							(this.controls[i] as CheckBox).Checked = false;
						}
						else if (this.controls[i].GetType() == typeof(RadioButton))
						{
							(this.controls[i] as RadioButton).Checked = false;
						}
						else if (this.controls[i].GetType() == typeof(ComboBox))
						{
							(this.controls[i] as ComboBox).SelectedIndex = -1;
						}
					}
				}
				this.textBox_ID.Focus();
				this.FlxPayment.Clear(ClearFlags.Content, 1, 1, this.FlxPayment.Rows.Count, 7);
				this.FlxPayment.Rows.Count = 50;
				this.SetReadOnly = false;
			}
		}

		private void CmbTenanPayMethod_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.CheckAqsat();
		}

		protected bool ContinueIfEditOrNew()
		{
			bool flag;
			if ((this.State == FormState.Edit ? false : this.State != FormState.New))
			{
				flag = true;
			}
			else
			{
				flag = (MessageBox.Show((this.LangArEn == 0 ? "تم تعديل السجل الحالي دون حفظ التغييرات .. هل تريد المتابعة؟" : "Not saved the changes, do you really want to continue?"), VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes ? true : false);
			}
			return flag;
		}

		private void DGV_Main_CellClick(object sender, GridCellClickEventArgs e)
		{
			this.DGV_Main.PrimaryGrid.Tag = e.GridCell.RowIndex;
		}

		private void DGV_Main_CellDoubleClick(object sender, GridCellDoubleClickEventArgs e)
		{
			this.ToolStripMenuItem_Det_Click(sender, e);
		}

		private void DGV_Main_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
		{
			GridPanel gridPanel = e.GridPanel;
			string dataMember = gridPanel.DataMember;
			if ((dataMember == null ? false : dataMember == "T_TenantContract"))
			{
				this.PropBranchPanel(gridPanel);
			}
		}

		private void DGV_Main_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Right)
			{
				GridElement elementAt = this.DGV_Main.GetElementAt(e.Location);
				if (!(elementAt is GridColumnHeader))
				{
					this.contextMenuStrip2.Show(Control.MousePosition);
				}
				else
				{
					GridColumnHeader gridColumnHeader = (GridColumnHeader)elementAt;
					GridColumn gridColumn = null;
					gridColumnHeader.GetHitArea(e.Location, ref gridColumn);
					this.contextMenuStrip1.Show(Control.MousePosition);
				}
			}
		}

		protected override void Dispose(bool disposing)
		{
			if ((!disposing ? false : this.components != null))
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void expandableSplitter1_Click(object sender, EventArgs e)
		{
			if (!this.expandableSplitter1.Expanded)
			{
				this.ViewDetails_Click(sender, e);
			}
			else
			{
				this.ViewTable_Click(sender, e);
			}
		}

		public void Fill_DGV_Main()
		{
			this.DGV_Main.PrimaryGrid.VirtualMode = false;
			List<T_TenantContract> list = this.db.FillTenantContractData_2(this.textBox_search.TextBox.Text).ToList<T_TenantContract>();
			if (this.DGV_Main.PrimaryGrid.Columns.Count == 0)
			{
				foreach (KeyValuePair<string, FrmTenantPayment.ColumnDictinary> columnsNamesVisible in this.columns_Names_visible)
				{
					this.DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(columnsNamesVisible.Key));
				}
			}
			this.FillHDGV(list);
		}

		private void FillCombo()
		{
			if ((VarGeneral.CurrentLang.ToString() == "0" ? false : VarGeneral.CurrentLang.ToString() != ""))
			{
				this.CmbTenanPayMethod.Items.Add("Every month");
				this.CmbTenanPayMethod.Items.Add("Every 2 months");
				this.CmbTenanPayMethod.Items.Add("Every 3 months");
				this.CmbTenanPayMethod.Items.Add("Every 4 months");
				this.CmbTenanPayMethod.Items.Add("Every 6 months");
				this.CmbTenanPayMethod.Items.Add("Every years");
			}
			else
			{
				this.CmbTenanPayMethod.Items.Add("كل شهر");
				this.CmbTenanPayMethod.Items.Add("كل 2 شهر");
				this.CmbTenanPayMethod.Items.Add("كل 3 شهور");
				this.CmbTenanPayMethod.Items.Add("كل 4 شهور");
				this.CmbTenanPayMethod.Items.Add("كل 6 شهور");
				this.CmbTenanPayMethod.Items.Add("كل سنة");
			}
			this.CmbTenanPayMethod.SelectedIndex = 0;
		}

		public void FillHDGV(IEnumerable<T_TenantContract> new_data_enum)
		{
			bool flag = false;
			if (this.contextMenuStrip1.Items.Count > 0)
			{
				flag = true;
			}
			for (int i = 0; i < this.DGV_Main.PrimaryGrid.Columns.Count; i++)
			{
				if (!this.columns_Names_visible.ContainsKey(this.DGV_Main.PrimaryGrid.Columns[i].Name))
				{
					this.DGV_Main.PrimaryGrid.Columns[i].Visible = false;
				}
				else
				{
					this.DGV_Main.PrimaryGrid.Columns[i].AutoSizeMode = ColumnAutoSizeMode.None;
					this.DGV_Main.PrimaryGrid.Columns[i].MinimumWidth = 50;
					this.DGV_Main.PrimaryGrid.Columns[i].Visible = this.columns_Names_visible[this.DGV_Main.PrimaryGrid.Columns[i].Name].IfDefault;
					this.DGV_Main.PrimaryGrid.Columns[i].HeaderText = (this.LangArEn == 0 ? this.columns_Names_visible[this.DGV_Main.PrimaryGrid.Columns[i].Name].AText : this.columns_Names_visible[this.DGV_Main.PrimaryGrid.Columns[i].Name].EText);
					if (flag)
					{
						this.DGV_Main.PrimaryGrid.Columns[i].Visible = (this.contextMenuStrip1.Items[this.DGV_Main.PrimaryGrid.Columns[i].Name] as ToolStripMenuItem).Checked;
					}
					else
					{
						ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem()
						{
							Checked = this.columns_Names_visible[this.DGV_Main.PrimaryGrid.Columns[i].Name].IfDefault,
							CheckOnClick = true,
							Name = this.DGV_Main.PrimaryGrid.Columns[i].Name,
							Text = this.DGV_Main.PrimaryGrid.Columns[i].HeaderText
						};
						toolStripMenuItem.CheckedChanged += new EventHandler(this.item_Click);
						this.contextMenuStrip1.Items.Add(toolStripMenuItem);
					}
				}
			}
			this.DGV_Main.PrimaryGrid.DataSource = new_data_enum.ToList<T_TenantContract>();
			this.DGV_Main.PrimaryGrid.DataMember = "T_TenantContract";
			this.DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background.Color2 = Color.LightBlue;
		}

		private void FlxPayment_AfterEdit(object sender, RowColEventArgs e)
		{
			if (e.Col == 7)
			{
				if (this.SelectPayment)
				{
					this.PaymentNo = 0;
					if (Convert.ToBoolean(this.FlxPayment.GetData(e.Row, e.Col).ToString()))
					{
						try
						{
							if ((double.Parse(this.FlxPayment.GetData(e.Row, 1).ToString()) <= 0 ? false : VarGeneral.CheckDate(this.FlxPayment.GetData(e.Row, 2).ToString())))
							{
								if (MessageBox.Show(string.Concat(new string[] { "هل تريد دفع الدفعة للسطر رقم [", e.Row.ToString(), "]؟ \n Are you sure that you want to delete the line [", e.Row.ToString(), "]?" }), VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
								{
									this.FlxPayment.SetData(e.Row, e.Col, false);
								}
								else if (!Convert.ToBoolean(this.FlxPayment.GetData(e.Row, 3).ToString()))
								{
									this.PaymentNo = int.Parse(this.FlxPayment.GetData(e.Row, 6).ToString());
									base.Close();
								}
							}
						}
						catch
						{
						}
					}
				}
				else if (Convert.ToBoolean(this.FlxPayment.GetData(e.Row, e.Col).ToString()))
				{
					try
					{
						if ((double.Parse(this.FlxPayment.GetData(e.Row, 1).ToString()) <= 0 ? true : !VarGeneral.CheckDate(this.FlxPayment.GetData(e.Row, 2).ToString())))
						{
							this.FlxPayment.RemoveItem(e.Row);
							if (!this.FrmTyp)
							{
								this.FlxPayment.Rows.Add();
							}
						}
						else if (MessageBox.Show(string.Concat(new string[] { "هل أنت متاكد من حذف السطر [", e.Row.ToString(), "]؟ \n Are you sure that you want to delete the line [", e.Row.ToString(), "]?" }), VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
						{
							this.FlxPayment.SetData(e.Row, e.Col, false);
						}
						else if (!Convert.ToBoolean(this.FlxPayment.GetData(e.Row, 3).ToString()))
						{
							if (this.State == FormState.Saved)
							{
								this.Button_Edit_Click(sender, e);
							}
							this.FlxPayment.RemoveItem(e.Row);
							if (!this.FrmTyp)
							{
								this.FlxPayment.Rows.Add();
							}
						}
					}
					catch
					{
						this.FlxPayment.RemoveItem(e.Row);
						if (!this.FrmTyp)
						{
							this.FlxPayment.Rows.Add();
						}
					}
				}
			}
		}

		private void FlxPayment_BeforeEdit(object sender, RowColEventArgs e)
		{
			bool flag;
			try
			{
				if (Convert.ToBoolean(this.FlxPayment.GetData(e.Row, 3).ToString()))
				{
					flag = true;
				}
				else
				{
					flag = (!this.FrmTyp ? false : e.Col != 7);
				}
				if (flag)
				{
					e.Cancel = true;
				}
			}
			catch
			{
			}
		}

		private void FlxPayment_KeyDown(object sender, KeyEventArgs e)
		{
			bool flag;
			try
			{
				if (!this.FrmTyp && e.KeyCode == Keys.Delete)
				{
					if (double.Parse(this.FlxPayment.GetData(this.FlxPayment.Row, 1).ToString()) > 0 && VarGeneral.CheckDate(this.FlxPayment.GetData(this.FlxPayment.Row, 2).ToString()))
					{
						string[] str = new string[] { "هل أنت متاكد من حذف السطر [", null, null, null, null };
						int row = this.FlxPayment.Row;
						str[1] = row.ToString();
						str[2] = "]؟ \n Are you sure that you want to delete the line [";
						row = this.FlxPayment.Row;
						str[3] = row.ToString();
						str[4] = "]?";
						if (MessageBox.Show(string.Concat(str), VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
						{
							// Label1;
						}
					}
					flag = !Convert.ToBoolean(this.FlxPayment.GetData(this.FlxPayment.Row, 3).ToString());
					// Label0;
				}
				Label1:
				flag = false;
				Label0:
				if (flag)
				{
					this.FlxPayment.RemoveItem(this.FlxPayment.Row);
					this.FlxPayment.Rows.Add();
				}
			}
			catch
			{
				this.FlxPayment.RemoveItem(this.FlxPayment.Row);
				this.FlxPayment.Rows.Add();
			}
		}

		private void Frm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				if (this.State == FormState.Saved)
				{
					base.Close();
				}
				else if (this.State == FormState.New)
				{
					try
					{
						if (int.Parse(this.Label_Count.Text) <= 0)
						{
							base.Close();
						}
						else
						{
							this.Button_Last_Click(sender, e);
						}
					}
					catch
					{
						base.Close();
					}
				}
				else
				{
					this.textBox_ID_TextChanged(sender, e);
				}
			}
		}

		private void Frm_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				SendKeys.Send("{Tab}");
			}
		}

		private void FrmTenantPayment_Load(object sender, EventArgs e)
		{
			try
			{
				ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FrmTenantPayment));
				if ((VarGeneral.CurrentLang.ToString() == "0" ? false : VarGeneral.CurrentLang.ToString() != ""))
				{
					SSSLanguage.Language.ChangeLanguage("en", this, componentResourceManager);
					this.LangArEn = 1;
				}
				else
				{
					SSSLanguage.Language.ChangeLanguage("ar-SA", this, componentResourceManager);
					this.LangArEn = 0;
				}
				this.ADD_Controls();
				this.Permmission = this.dbc.Get_PermissionID(VarGeneral.UserID);
				if (this.columns_Names_visible.Count != 0)
				{
					this.Clear();
					this.textBox_ID.Text = "";
					this.TextBox_Index.TextBox.Text = "";
				}
				else
				{
					this.columns_Names_visible.Add("PaymentNo", new FrmTenantPayment.ColumnDictinary("الرقم ", " No", true, ""));
				}
				this.RibunButtons();
				this.FillCombo();
				this.ViewDetails_Click(sender, e);
				this.FlxPayment.DrawMode = DrawModeEnum.OwnerDraw;
				this.FlxPayment.OwnerDrawCell += new OwnerDrawCellEventHandler(this._ownerDraw);
				this.LDataThis = (
					from g in new BindingList<T_TenantPayment>(this.data_this.T_TenantPayments)
					orderby g.PaymentNo
					select g).ToList<T_TenantPayment>();
				if (this.LDataThis.Count > 0)
				{
					int contractID = this.data_this.ContractID;
					this.Clear();
					this.data_this = new T_TenantContract();
					this.data_this = this.db.StockTenantContractDataID(contractID);
					this.SetData(this.data_this);
					this.Button_Add.Visible = false;
					this.CmbTenanPayMethod.Enabled = false;
				}
				else
				{
					this.Button_Add_Click(sender, e);
					TextBox textBoxID = this.textBox_ID;
					int contractNo = this.data_this.ContractNo;
					textBoxID.Text = contractNo.ToString();
					this.txtRentOfYear.Value = this.data_this.RentOfYear.Value;
					try
					{
						if (!VarGeneral.CheckDate(this.data_this.ContractEnd))
						{
							this.txtContractEnd.Text = "";
						}
						else
						{
							this.txtContractEnd.Text = this.data_this.ContractEnd;
						}
					}
					catch
					{
						this.txtContractEnd.Text = "";
					}
					try
					{
						if (!VarGeneral.CheckDate(this.data_this.ContractStart))
						{
							this.txtContractStart.Text = "";
						}
						else
						{
							this.txtContractStart.Text = this.data_this.ContractStart;
						}
					}
					catch
					{
						this.txtContractStart.Text = "";
					}
					this.txtTenantName.Text = (this.LangArEn == 0 ? this.data_this.T_Tenant.NameA : this.data_this.T_Tenant.NameE);
					TextBox str = this.txtTenantNo;
					contractNo = this.data_this.T_Tenant.tenantNo;
					str.Text = contractNo.ToString();
					this.txtTenantNo.Tag = this.data_this.T_Tenant.tenantID;
					this.CmbTenanPayMethod.SelectedIndex = 0;
				}
				if (this.FrmTyp)
				{
					this.FlxPayment.Dock = DockStyle.Fill;
					this.Button_Delete.Visible = false;
					this.Button_Save.Visible = false;
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				VarGeneral.DebLog.writeLog("Load:", exception, true);
				MessageBox.Show(exception.Message);
			}
		}

		private T_TenantContract GetData()
		{
			this.textBox_ID.Focus();
			this.data_this.RentOfYearPayment = new double?(this.txtRentOfYear.Value);
			this.data_this.PayMethod = new int?(this.CmbTenanPayMethod.SelectedIndex);
			return this.data_this;
		}

		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTenantPayment));
            DevComponents.DotNetBar.SuperGrid.Style.Background background1 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background2 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background3 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.BorderColor borderColor1 = new DevComponents.DotNetBar.SuperGrid.Style.BorderColor();
            DevComponents.DotNetBar.SuperGrid.Style.BorderColor borderColor2 = new DevComponents.DotNetBar.SuperGrid.Style.BorderColor();
            DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle baseTreeButtonVisualStyle1 = new DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle();
            DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle baseTreeButtonVisualStyle2 = new DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle();
            DevComponents.DotNetBar.SuperGrid.Style.Background background4 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            this.Rep_RecCount = new DevComponents.Editors.IntegerInput();
            this.ToolStripMenuItem_Rep = new System.Windows.Forms.ToolStripMenuItem();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.FlxPayment = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.label18 = new System.Windows.Forms.Label();
            this.CmbTenanPayMethod = new System.Windows.Forms.ComboBox();
            this.txtTenantNo = new System.Windows.Forms.TextBox();
            this.txtContractEnd = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtContractStart = new System.Windows.Forms.MaskedTextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRentOfYear = new DevComponents.Editors.DoubleInput();
            this.c1BarCode1 = new C1.Win.C1BarCode.C1BarCode();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.txtTenantName = new System.Windows.Forms.TextBox();
            this.barTopDockSite = new DevComponents.DotNetBar.DockSite();
            this.barBottomDockSite = new DevComponents.DotNetBar.DockSite();
            this.barLeftDockSite = new DevComponents.DotNetBar.DockSite();
            this.barRightDockSite = new DevComponents.DotNetBar.DockSite();
            this.dockSite1 = new DevComponents.DotNetBar.DockSite();
            this.dockSite2 = new DevComponents.DotNetBar.DockSite();
            this.dotNetBarManager1 = new DevComponents.DotNetBar.DotNetBarManager(this.components);
            this.dockSite4 = new DevComponents.DotNetBar.DockSite();
            this.dockSite3 = new DevComponents.DotNetBar.DockSite();
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
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.ribbonBar_Tasks = new DevComponents.DotNetBar.RibbonBar();
            this.superTabControl_Main1 = new DevComponents.DotNetBar.SuperTabControl();
            this.Button_Close = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Search = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Delete = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Save = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Add = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem2 = new DevComponents.DotNetBar.LabelItem();
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
            ((System.ComponentModel.ISupportInitialize)(this.Rep_RecCount)).BeginInit();
            this.ribbonBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlxPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRentOfYear)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.panelEx3.SuspendLayout();
            this.ribbonBar_DGV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_DGV)).BeginInit();
            this.panelEx2.SuspendLayout();
            this.ribbonBar_Tasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Rep_RecCount
            // 
            this.Rep_RecCount.AllowEmptyState = false;
            // 
            // 
            // 
            this.Rep_RecCount.BackgroundStyle.Class = "DateTimeInputBackground";
            this.Rep_RecCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Rep_RecCount.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.Rep_RecCount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Rep_RecCount.Increment = 0;
            this.Rep_RecCount.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.Rep_RecCount.IsInputReadOnly = true;
            this.Rep_RecCount.Location = new System.Drawing.Point(816, 446);
            this.Rep_RecCount.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Rep_RecCount.Name = "Rep_RecCount";
            this.Rep_RecCount.Size = new System.Drawing.Size(73, 21);
            this.Rep_RecCount.TabIndex = 852;
            this.Rep_RecCount.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // ToolStripMenuItem_Rep
            // 
            this.ToolStripMenuItem_Rep.Checked = true;
            this.ToolStripMenuItem_Rep.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToolStripMenuItem_Rep.Name = "ToolStripMenuItem_Rep";
            this.ToolStripMenuItem_Rep.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItem_Rep.Text = "إظهار التقرير";
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Controls.Add(this.FlxPayment);
            this.ribbonBar1.Controls.Add(this.label18);
            this.ribbonBar1.Controls.Add(this.CmbTenanPayMethod);
            this.ribbonBar1.Controls.Add(this.txtTenantNo);
            this.ribbonBar1.Controls.Add(this.txtContractEnd);
            this.ribbonBar1.Controls.Add(this.label7);
            this.ribbonBar1.Controls.Add(this.label3);
            this.ribbonBar1.Controls.Add(this.txtContractStart);
            this.ribbonBar1.Controls.Add(this.label22);
            this.ribbonBar1.Controls.Add(this.label19);
            this.ribbonBar1.Controls.Add(this.label4);
            this.ribbonBar1.Controls.Add(this.txtRentOfYear);
            this.ribbonBar1.Controls.Add(this.c1BarCode1);
            this.ribbonBar1.Controls.Add(this.textBox_ID);
            this.ribbonBar1.Controls.Add(this.txtTenantName);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.DragDropSupport = true;
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(734, 295);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar1.TabIndex = 867;
            this.ribbonBar1.Tag = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ribbonBar1.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(7)))), ((int)(((byte)(48)))));
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // FlxPayment
            // 
            this.FlxPayment.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.FlxPayment.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
            this.FlxPayment.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.FlxPayment.ColumnInfo = resources.GetString("FlxPayment.ColumnInfo");
            this.FlxPayment.ExtendLastCol = true;
            this.FlxPayment.Font = new System.Drawing.Font("Tahoma", 7.5F, System.Drawing.FontStyle.Bold);
            this.FlxPayment.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.FlxPayment.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.FlxPayment.Location = new System.Drawing.Point(4, 90);
            this.FlxPayment.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.FlxPayment.Name = "FlxPayment";
            this.FlxPayment.Rows.DefaultSize = 19;
            this.FlxPayment.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None;
            this.FlxPayment.Size = new System.Drawing.Size(514, 181);
            this.FlxPayment.StyleInfo = resources.GetString("FlxPayment.StyleInfo");
            this.FlxPayment.TabIndex = 1320;
            this.FlxPayment.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue;
            this.FlxPayment.BeforeEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.FlxPayment_BeforeEdit);
            this.FlxPayment.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.FlxPayment_AfterEdit);
            this.FlxPayment.Click += new System.EventHandler(this.FlxPayment_Click);
            this.FlxPayment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FlxPayment_KeyDown);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(632, 94);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(82, 13);
            this.label18.TabIndex = 1319;
            this.label18.Text = "طريقة الـــدفــع :";
            // 
            // CmbTenanPayMethod
            // 
            this.CmbTenanPayMethod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbTenanPayMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTenanPayMethod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbTenanPayMethod.FormattingEnabled = true;
            this.CmbTenanPayMethod.ItemHeight = 13;
            this.CmbTenanPayMethod.Location = new System.Drawing.Point(524, 90);
            this.CmbTenanPayMethod.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.CmbTenanPayMethod.Name = "CmbTenanPayMethod";
            this.CmbTenanPayMethod.Size = new System.Drawing.Size(106, 21);
            this.CmbTenanPayMethod.TabIndex = 1318;
            this.CmbTenanPayMethod.SelectedIndexChanged += new System.EventHandler(this.CmbTenanPayMethod_SelectedIndexChanged);
            // 
            // txtTenantNo
            // 
            this.txtTenantNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTenantNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtTenantNo.Location = new System.Drawing.Point(320, 22);
            this.txtTenantNo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txtTenantNo.MaxLength = 50;
            this.txtTenantNo.Name = "txtTenantNo";
            this.txtTenantNo.ReadOnly = true;
            this.txtTenantNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTenantNo.Size = new System.Drawing.Size(106, 20);
            this.txtTenantNo.TabIndex = 1317;
            this.txtTenantNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtContractEnd
            // 
            this.txtContractEnd.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtContractEnd.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtContractEnd.Location = new System.Drawing.Point(320, 56);
            this.txtContractEnd.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txtContractEnd.Mask = "0000/00/00";
            this.txtContractEnd.Name = "txtContractEnd";
            this.txtContractEnd.ReadOnly = true;
            this.txtContractEnd.Size = new System.Drawing.Size(106, 21);
            this.txtContractEnd.TabIndex = 1315;
            this.txtContractEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtContractEnd.Click += new System.EventHandler(this.txtContractEnd_Click);
            this.txtContractEnd.Leave += new System.EventHandler(this.txtContractEnd_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(220, 60);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 1316;
            this.label7.Text = "الإيجار السنــوي :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(426, 60);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 1314;
            this.label3.Text = "تاريخ نهاية العقــد :";
            // 
            // txtContractStart
            // 
            this.txtContractStart.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtContractStart.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtContractStart.Location = new System.Drawing.Point(524, 56);
            this.txtContractStart.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txtContractStart.Mask = "0000/00/00";
            this.txtContractStart.Name = "txtContractStart";
            this.txtContractStart.ReadOnly = true;
            this.txtContractStart.Size = new System.Drawing.Size(106, 21);
            this.txtContractStart.TabIndex = 11;
            this.txtContractStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtContractStart.Click += new System.EventHandler(this.txtContractStart_Click);
            this.txtContractStart.Leave += new System.EventHandler(this.txtContractStart_Leave);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label22.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label22.Location = new System.Drawing.Point(430, 26);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(88, 13);
            this.label22.TabIndex = 1301;
            this.label22.Text = "المستأجــــــــــر :";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label19.Location = new System.Drawing.Point(632, 60);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(89, 13);
            this.label19.TabIndex = 96;
            this.label19.Text = "تاريخ بداية العقـد :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(632, 26);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 88;
            this.label4.Text = "رقم العقـــــــــد :";
            // 
            // txtRentOfYear
            // 
            this.txtRentOfYear.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtRentOfYear.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtRentOfYear.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRentOfYear.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtRentOfYear.DisplayFormat = "0.00";
            this.txtRentOfYear.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtRentOfYear.Increment = 1D;
            this.txtRentOfYear.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtRentOfYear.Location = new System.Drawing.Point(4, 56);
            this.txtRentOfYear.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txtRentOfYear.Name = "txtRentOfYear";
            this.txtRentOfYear.ShowUpDown = true;
            this.txtRentOfYear.Size = new System.Drawing.Size(213, 20);
            this.txtRentOfYear.TabIndex = 7;
            this.txtRentOfYear.Leave += new System.EventHandler(this.txtRentOfYear_Leave);
            // 
            // c1BarCode1
            // 
            this.c1BarCode1.BarWide = 1;
            this.c1BarCode1.CodeType = C1.Win.C1BarCode.CodeTypeEnum.Code128;
            this.c1BarCode1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.c1BarCode1.Location = new System.Drawing.Point(990, 135);
            this.c1BarCode1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.c1BarCode1.Name = "c1BarCode1";
            this.c1BarCode1.ShowText = true;
            this.c1BarCode1.Size = new System.Drawing.Size(142, 40);
            this.c1BarCode1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.c1BarCode1.TabIndex = 923;
            this.c1BarCode1.Text = "1225";
            // 
            // textBox_ID
            // 
            this.textBox_ID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.textBox_ID.Location = new System.Drawing.Point(524, 22);
            this.textBox_ID.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.ReadOnly = true;
            this.textBox_ID.Size = new System.Drawing.Size(106, 20);
            this.textBox_ID.TabIndex = 19;
            this.textBox_ID.Tag = "";
            this.textBox_ID.Click += new System.EventHandler(this.textBox_ID_Click);
            this.textBox_ID.TextChanged += new System.EventHandler(this.textBox_ID_TextChanged);
            this.textBox_ID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ID_KeyPress);
            // 
            // txtTenantName
            // 
            this.txtTenantName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTenantName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtTenantName.Location = new System.Drawing.Point(4, 22);
            this.txtTenantName.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txtTenantName.MaxLength = 50;
            this.txtTenantName.Name = "txtTenantName";
            this.txtTenantName.ReadOnly = true;
            this.txtTenantName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTenantName.Size = new System.Drawing.Size(317, 20);
            this.txtTenantName.TabIndex = 20;
            this.txtTenantName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // barTopDockSite
            // 
            this.barTopDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barTopDockSite.Dock = System.Windows.Forms.DockStyle.Top;
            this.barTopDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barTopDockSite.Location = new System.Drawing.Point(0, 0);
            this.barTopDockSite.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.barTopDockSite.Name = "barTopDockSite";
            this.barTopDockSite.Size = new System.Drawing.Size(734, 0);
            this.barTopDockSite.TabIndex = 869;
            this.barTopDockSite.TabStop = false;
            // 
            // barBottomDockSite
            // 
            this.barBottomDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barBottomDockSite.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barBottomDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barBottomDockSite.Location = new System.Drawing.Point(0, 360);
            this.barBottomDockSite.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.barBottomDockSite.Name = "barBottomDockSite";
            this.barBottomDockSite.Size = new System.Drawing.Size(734, 0);
            this.barBottomDockSite.TabIndex = 870;
            this.barBottomDockSite.TabStop = false;
            // 
            // barLeftDockSite
            // 
            this.barLeftDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barLeftDockSite.Dock = System.Windows.Forms.DockStyle.Left;
            this.barLeftDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barLeftDockSite.Location = new System.Drawing.Point(0, 0);
            this.barLeftDockSite.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.barLeftDockSite.Name = "barLeftDockSite";
            this.barLeftDockSite.Size = new System.Drawing.Size(0, 360);
            this.barLeftDockSite.TabIndex = 871;
            this.barLeftDockSite.TabStop = false;
            // 
            // barRightDockSite
            // 
            this.barRightDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barRightDockSite.Dock = System.Windows.Forms.DockStyle.Right;
            this.barRightDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barRightDockSite.Location = new System.Drawing.Point(734, 0);
            this.barRightDockSite.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.barRightDockSite.Name = "barRightDockSite";
            this.barRightDockSite.Size = new System.Drawing.Size(0, 360);
            this.barRightDockSite.TabIndex = 872;
            this.barRightDockSite.TabStop = false;
            // 
            // dockSite1
            // 
            this.dockSite1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dockSite1.Location = new System.Drawing.Point(0, 0);
            this.dockSite1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.dockSite1.Name = "dockSite1";
            this.dockSite1.Size = new System.Drawing.Size(0, 360);
            this.dockSite1.TabIndex = 873;
            this.dockSite1.TabStop = false;
            // 
            // dockSite2
            // 
            this.dockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite2.Dock = System.Windows.Forms.DockStyle.Right;
            this.dockSite2.Location = new System.Drawing.Point(734, 0);
            this.dockSite2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.dockSite2.Name = "dockSite2";
            this.dockSite2.Size = new System.Drawing.Size(0, 360);
            this.dockSite2.TabIndex = 874;
            this.dockSite2.TabStop = false;
            // 
            // dotNetBarManager1
            // 
            this.dotNetBarManager1.BottomDockSite = this.barBottomDockSite;
            this.dotNetBarManager1.LeftDockSite = this.barLeftDockSite;
            this.dotNetBarManager1.MdiSystemItemVisible = false;
            this.dotNetBarManager1.ParentForm = null;
            this.dotNetBarManager1.RightDockSite = this.barRightDockSite;
            this.dotNetBarManager1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2000;
            this.dotNetBarManager1.ToolbarBottomDockSite = this.dockSite4;
            this.dotNetBarManager1.ToolbarLeftDockSite = this.dockSite1;
            this.dotNetBarManager1.ToolbarRightDockSite = this.dockSite2;
            this.dotNetBarManager1.ToolbarTopDockSite = this.dockSite3;
            this.dotNetBarManager1.TopDockSite = this.barTopDockSite;
            // 
            // dockSite4
            // 
            this.dockSite4.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dockSite4.Location = new System.Drawing.Point(0, 360);
            this.dockSite4.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.dockSite4.Name = "dockSite4";
            this.dockSite4.Size = new System.Drawing.Size(734, 0);
            this.dockSite4.TabIndex = 876;
            this.dockSite4.TabStop = false;
            // 
            // dockSite3
            // 
            this.dockSite3.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite3.Dock = System.Windows.Forms.DockStyle.Top;
            this.dockSite3.Location = new System.Drawing.Point(0, 0);
            this.dockSite3.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.dockSite3.Name = "dockSite3";
            this.dockSite3.Size = new System.Drawing.Size(734, 0);
            this.dockSite3.TabIndex = 875;
            this.dockSite3.TabStop = false;
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
            this.openFileDialog1.Filter = "Text Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf|All Files(*.*)|*.*";
            this.openFileDialog1.FilterIndex = 2;
            this.openFileDialog1.Title = "Open File";
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
            this.panelEx3.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx3.Location = new System.Drawing.Point(0, 0);
            this.panelEx3.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(734, 0);
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
            this.DGV_Main.Location = new System.Drawing.Point(0, 0);
            this.DGV_Main.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.DGV_Main.Name = "DGV_Main";
            // 
            // 
            // 
            this.DGV_Main.PrimaryGrid.ActiveRowIndicatorStyle = DevComponents.DotNetBar.SuperGrid.ActiveRowIndicatorStyle.Both;
            this.DGV_Main.PrimaryGrid.AllowEdit = false;
            // 
            // 
            // 
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
            // 
            // 
            // 
            this.DGV_Main.PrimaryGrid.GroupByRow.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.Never;
            this.DGV_Main.PrimaryGrid.GroupByRow.Text = "جميــع السجــــلات";
            this.DGV_Main.PrimaryGrid.GroupByRow.Visible = true;
            this.DGV_Main.PrimaryGrid.GroupByRow.WatermarkText = "";
            this.DGV_Main.PrimaryGrid.InitialActiveRow = DevComponents.DotNetBar.SuperGrid.RelativeRow.None;
            this.DGV_Main.PrimaryGrid.InitialSelection = DevComponents.DotNetBar.SuperGrid.RelativeSelection.None;
            this.DGV_Main.PrimaryGrid.MultiSelect = false;
            this.DGV_Main.PrimaryGrid.ShowRowGridIndex = true;
            // 
            // 
            // 
            this.DGV_Main.PrimaryGrid.Title.AllowSelection = false;
            this.DGV_Main.PrimaryGrid.Title.Text = "";
            this.DGV_Main.PrimaryGrid.Title.Visible = false;
            this.DGV_Main.PrimaryGrid.Visible = false;
            this.DGV_Main.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DGV_Main.Size = new System.Drawing.Size(734, 0);
            this.DGV_Main.TabIndex = 876;
            this.DGV_Main.Tag = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
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
            this.ribbonBar_DGV.DragDropSupport = true;
            this.ribbonBar_DGV.Location = new System.Drawing.Point(0, -51);
            this.ribbonBar_DGV.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.ribbonBar_DGV.Name = "ribbonBar_DGV";
            this.ribbonBar_DGV.Size = new System.Drawing.Size(734, 51);
            this.ribbonBar_DGV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar_DGV.TabIndex = 877;
            this.ribbonBar_DGV.Tag = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
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
            this.superTabControl_DGV.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.superTabControl_DGV.Name = "superTabControl_DGV";
            this.superTabControl_DGV.ReorderTabsEnabled = true;
            this.superTabControl_DGV.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.superTabControl_DGV.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabControl_DGV.SelectedTabIndex = -1;
            this.superTabControl_DGV.Size = new System.Drawing.Size(734, 51);
            this.superTabControl_DGV.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl_DGV.TabIndex = 12;
            this.superTabControl_DGV.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.textBox_search,
            this.Button_ExportTable2,
            this.Button_PrintTable,
            this.labelItem3});
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
            // panelEx2
            // 
            this.panelEx2.Controls.Add(this.ribbonBar1);
            this.panelEx2.Controls.Add(this.ribbonBar_Tasks);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx2.Location = new System.Drawing.Point(0, 14);
            this.panelEx2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.panelEx2.MinimumSize = new System.Drawing.Size(734, 346);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(734, 346);
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
            this.ribbonBar_Tasks.DragDropSupport = true;
            this.ribbonBar_Tasks.Location = new System.Drawing.Point(0, 295);
            this.ribbonBar_Tasks.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.ribbonBar_Tasks.Name = "ribbonBar_Tasks";
            this.ribbonBar_Tasks.Size = new System.Drawing.Size(734, 51);
            this.ribbonBar_Tasks.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar_Tasks.TabIndex = 870;
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
            this.superTabControl_Main1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.superTabControl_Main1.Name = "superTabControl_Main1";
            this.superTabControl_Main1.ReorderTabsEnabled = true;
            this.superTabControl_Main1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.superTabControl_Main1.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabControl_Main1.SelectedTabIndex = -1;
            this.superTabControl_Main1.Size = new System.Drawing.Size(348, 51);
            this.superTabControl_Main1.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl_Main1.TabIndex = 12;
            this.superTabControl_Main1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.Button_Close,
            this.Button_Search,
            this.Button_Delete,
            this.Button_Save,
            this.Button_Add,
            this.labelItem2});
            this.superTabControl_Main1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            this.superTabControl_Main1.Text = "superTabControl3";
            this.superTabControl_Main1.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            // 
            // Button_Close
            // 
            this.Button_Close.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Close.Checked = true;
            this.Button_Close.FontBold = true;
            this.Button_Close.FontItalic = true;
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
            this.Button_Search.Visible = false;
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
            this.Button_Delete.Click += new System.EventHandler(this.Button_Delete_Click);
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
            this.Button_Add.Stretch = true;
            this.Button_Add.SubItemsExpandWidth = 14;
            this.Button_Add.Symbol = "";
            this.Button_Add.SymbolSize = 15F;
            this.Button_Add.Text = "إضافة";
            this.Button_Add.Tooltip = "إضافة سجل جديد";
            this.Button_Add.Visible = false;
            // 
            // labelItem2
            // 
            this.labelItem2.Name = "labelItem2";
            this.labelItem2.Width = 40;
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
            this.superTabControl_Main2.Location = new System.Drawing.Point(348, 0);
            this.superTabControl_Main2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.superTabControl_Main2.Name = "superTabControl_Main2";
            this.superTabControl_Main2.ReorderTabsEnabled = true;
            this.superTabControl_Main2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.superTabControl_Main2.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabControl_Main2.SelectedTabIndex = -1;
            this.superTabControl_Main2.Size = new System.Drawing.Size(386, 51);
            this.superTabControl_Main2.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl_Main2.TabIndex = 11;
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
            this.superTabControl_Main2.Visible = false;
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
            this.expandableSplitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.None;
            this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.None;
            this.expandableSplitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.expandableSplitter1.Enabled = false;
            this.expandableSplitter1.Expandable = false;
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
            this.expandableSplitter1.Location = new System.Drawing.Point(0, 0);
            this.expandableSplitter1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(734, 14);
            this.expandableSplitter1.TabIndex = 1;
            this.expandableSplitter1.TabStop = false;
            this.expandableSplitter1.ExpandedChanged += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.expandableSplitter1_ExpandedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelEx3);
            this.panel1.Controls.Add(this.expandableSplitter1);
            this.panel1.Controls.Add(this.panelEx2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(734, 360);
            this.panel1.TabIndex = 877;
            // 
            // FrmTenantPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 360);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Rep_RecCount);
            this.Controls.Add(this.barTopDockSite);
            this.Controls.Add(this.barBottomDockSite);
            this.Controls.Add(this.barLeftDockSite);
            this.Controls.Add(this.barRightDockSite);
            this.Controls.Add(this.dockSite1);
            this.Controls.Add(this.dockSite2);
            this.Controls.Add(this.dockSite3);
            this.Controls.Add(this.dockSite4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.MaximizeBox = false;
            this.Name = "FrmTenantPayment";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الدفعـــــــات";
            this.Load += new System.EventHandler(this.FrmTenantPayment_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.Rep_RecCount)).EndInit();
            this.ribbonBar1.ResumeLayout(false);
            this.ribbonBar1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlxPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRentOfYear)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.panelEx3.ResumeLayout(false);
            this.ribbonBar_DGV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_DGV)).EndInit();
            this.panelEx2.ResumeLayout(false);
            this.ribbonBar_Tasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		private void item_Click(object sender, EventArgs e)
		{
			string name = (sender as ToolStripMenuItem).Name;
			try
			{
				string str = this.DGV_Main.PrimaryGrid.Columns[name].Name;
			}
			catch
			{
				this.DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(name));
				this.DGV_Main.PrimaryGrid.Columns[name].AutoSizeMode = ColumnAutoSizeMode.None;
				this.DGV_Main.PrimaryGrid.Columns[name].MinimumWidth = 90;
				this.DGV_Main.PrimaryGrid.Columns[name].HeaderText = this.columns_Names_visible[name].AText;
			}
			this.DGV_Main.PrimaryGrid.Columns[name].Visible = (sender as ToolStripMenuItem).Checked;
		}

		protected override void OnParentRightToLeftChanged(EventArgs e)
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FrmTenantPayment));
			if ((VarGeneral.CurrentLang.ToString() == "0" ? false : VarGeneral.CurrentLang.ToString() != ""))
			{
				SSSLanguage.Language.ChangeLanguage("en", this, componentResourceManager);
				this.LangArEn = 1;
			}
			else
			{
				SSSLanguage.Language.ChangeLanguage("ar-SA", this, componentResourceManager);
				this.LangArEn = 0;
			}
			this.RibunButtons();
			try
			{
				if (this.data_this != null)
				{
					this.SetData(this.data_this);
				}
			}
			catch
			{
			}
		}

		private void PropBranchPanel(GridPanel panel)
		{
			this.DGV_Main.PrimaryGrid.UseAlternateRowStyle = true;
			this.DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background.Color1 = Color.SkyBlue;
			panel.FrozenColumnCount = 1;
			panel.Columns[0].GroupBoxEffects = GroupBoxEffects.None;
			foreach (GridColumn column in panel.Columns)
			{
				column.ColumnSortMode = ColumnSortMode.Multiple;
			}
			panel.ColumnHeader.RowHeight = 30;
			for (int i = 0; i < panel.Columns.Count; i++)
			{
				this.DGV_Main.PrimaryGrid.Columns[i].CellStyles.Default.Alignment = Alignment.MiddleCenter;
				this.DGV_Main.PrimaryGrid.Columns[i].Visible = false;
			}
			panel.Columns["PaymentNo"].Width = 120;
			panel.Columns["PaymentNo"].Visible = this.columns_Names_visible["PaymentNo"].IfDefault;
		}

		private void RibunButtons()
		{
			if ((VarGeneral.CurrentLang.ToString() == "0" ? false : VarGeneral.CurrentLang.ToString() != ""))
			{
				this.Button_First.Text = "First";
				this.Button_Last.Text = "Last";
				this.Button_Next.Text = "Next";
				this.Button_Prev.Text = "Previous";
				this.Button_Add.Text = "New";
				this.Button_Close.Text = "Close";
				this.Button_Delete.Text = "Delete";
				this.Button_Save.Text = "Save";
				this.Button_Search.Text = "Search";
				this.Button_First.Tooltip = "First Record";
				this.Button_Last.Tooltip = "Last Record";
				this.Button_Next.Tooltip = "Next Record";
				this.Button_Prev.Tooltip = "Previous Record";
				this.Button_Add.Tooltip = "F1";
				this.Button_Close.Tooltip = "Esc";
				this.Button_Delete.Tooltip = "F3";
				this.Button_Save.Tooltip = "F2";
				this.Button_Search.Tooltip = "F4";
				this.Button_PrintTable.Text = (VarGeneral.Settings_Sys.nTyp_Setting.Substring(0, 1) == "0" ? "Print" : "Show");
				this.Button_PrintTable.Tooltip = "F5";
				this.Button_ExportTable2.Text = "Export";
				this.Button_ExportTable2.Tooltip = "F10";
				this.DGV_Main.PrimaryGrid.GroupByRow.Text = "All Records";
				this.Text = "Payments Card";
			}
			else
			{
				this.Button_First.Text = "الأول";
				this.Button_Last.Text = "الأخير";
				this.Button_Next.Text = "التالي";
				this.Button_Prev.Text = "السابق";
				this.Button_Add.Text = "جديد";
				this.Button_Close.Text = "اغلاق";
				this.Button_Delete.Text = "حذف";
				this.Button_Save.Text = "حفظ";
				this.Button_Search.Text = "بحث";
				this.Button_First.Tooltip = "السجل الاول";
				this.Button_Last.Tooltip = "السجل الاخير";
				this.Button_Next.Tooltip = "السجل التالي";
				this.Button_Prev.Tooltip = "السجل السابق";
				this.Button_Add.Tooltip = "F1";
				this.Button_Close.Tooltip = "Esc";
				this.Button_Delete.Tooltip = "F3";
				this.Button_Save.Tooltip = "F2";
				this.Button_Search.Tooltip = "F4";
				this.Button_PrintTable.Text = (VarGeneral.Settings_Sys.nTyp_Setting.Substring(0, 1) == "0" ? "طباعة" : "عــرض");
				this.Button_PrintTable.Tooltip = "F5";
				this.Button_ExportTable2.Text = "تصدير";
				this.Button_ExportTable2.Tooltip = "F10";
				this.DGV_Main.PrimaryGrid.GroupByRow.Text = "جميع السجلات";
				this.Text = "الدفعـــــــات";
			}
			this.ArbEng();
		}

		public void SetData(T_TenantContract value)
		{
			try
			{
				this.State = FormState.Saved;
				this.Button_Save.Enabled = false;
				this.textBox_ID.Text = value.ContractNo.ToString();
				this.textBox_ID.Tag = value.ContractID.ToString();
				try
				{
					if (!VarGeneral.CheckDate(value.ContractEnd))
					{
						this.txtContractEnd.Text = "";
					}
					else
					{
						this.txtContractEnd.Text = value.ContractEnd;
					}
				}
				catch
				{
					this.txtContractEnd.Text = "";
				}
				try
				{
					if (!VarGeneral.CheckDate(value.ContractStart))
					{
						this.txtContractStart.Text = "";
					}
					else
					{
						this.txtContractStart.Text = value.ContractStart;
					}
				}
				catch
				{
					this.txtContractStart.Text = "";
				}
				this.txtRentOfYear.Value = value.RentOfYearPayment.Value;
				this.txtTenantName.Text = (this.LangArEn == 0 ? value.T_Tenant.NameA : value.T_Tenant.NameE);
				this.txtTenantNo.Text = value.T_Tenant.tenantNo.ToString();
				this.txtTenantNo.Tag = value.T_Tenant.tenantID;
				this.CmbTenanPayMethod.SelectedIndex = value.PayMethod.Value;
				this.LDataThis = (
					from g in new BindingList<T_TenantPayment>(this.data_this.T_TenantPayments)
					orderby g.PaymentNo
					select g).ToList<T_TenantPayment>();
				if (this.LData_This.Count <= 0)
				{
					this.txtRentOfYear.Value = value.RentOfYear.Value;
				}
				else
				{
					this.SetLines(this.LDataThis);
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				VarGeneral.DebLog.writeLog("SetData:", exception, true);
				MessageBox.Show(exception.Message);
			}
		}

		public void SetLines(List<T_TenantPayment> listDet)
		{
			try
			{
				this.FlxPayment.Rows.Count = listDet.Count + 1;
				for (int i = 1; i <= listDet.Count; i++)
				{
					this._TenantPayment = listDet[i - 1];
					this.FlxPayment.SetData(i, 0, this._TenantPayment.PaymentNo);
					this.FlxPayment.SetData(i, 1, this._TenantPayment.Value);
					this.FlxPayment.SetData(i, 2, this._TenantPayment.PayMonth);
					C1FlexGrid flxPayment = this.FlxPayment;
					double? remining = this._TenantPayment.Remining;
					flxPayment.SetData(i, 4, remining.GetValueOrDefault());
					if (!this._TenantPayment.SndNo.HasValue)
					{
						this.FlxPayment.SetData(i, 5, 0);
						this.FlxPayment.SetData(i, 3, false);
					}
					else
					{
						this.FlxPayment.SetData(i, 5, this._TenantPayment.T_GDHEAD.gdNo);
						this.FlxPayment.SetData(i, 3, true);
					}
					this.FlxPayment.SetData(i, 6, this._TenantPayment.PaymentID);
				}
				if ((
					from g in this.LDataThis
					where g.SndNo.HasValue
					select g).ToList<T_TenantPayment>().Count > 0)
				{
					this.IfDelete = false;
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show((this.LangArEn == 0 ? "حدث خطأ أثناء تعبئة الأسطر .." : "An error occurred while filling lines .."), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void textBox_ID_Click(object sender, EventArgs e)
		{
			this.textBox_ID.SelectAll();
		}

		private void textBox_ID_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsNumber(e.KeyChar) & e.KeyChar != '\b')
			{
				e.Handled = true;
			}
		}

		private void textBox_ID_TextChanged(object sender, EventArgs e)
		{
		}

		private void TextBox_Index_InputTextChanged(object sender)
		{
			int num = 0;
			try
			{
				num = Convert.ToInt32(this.TextBox_Index.TextBox.Text);
			}
			catch
			{
			}
			if ((num > this.PKeys.Count ? false : num > 0))
			{
				this.textBox_ID.Text = this.PKeys[num - 1];
			}
		}

		private void TextBox_Search_ButtonCustomClick(object sender, EventArgs e)
		{
			this.textBox_search.Text = "";
		}

		private void TextBox_Search_InputTextChanged(object sender)
		{
			this.Fill_DGV_Main();
		}

		private void ToolStripMenuItem_Det_Click(object sender, EventArgs e)
		{
			int num = Convert.ToInt32(this.DGV_Main.PrimaryGrid.Tag);
			this.TextBox_Index.TextBox.Text = string.Concat(num + 1);
			this.expandableSplitter1.Expanded = true;
			this.ViewDetails_Click(sender, e);
		}

		private void txtArbDes_Enter(object sender, EventArgs e)
		{
			Framework.Keyboard.Language.Switch("Arabic");
		}

		private void txtContractEnd_Click(object sender, EventArgs e)
		{
			this.txtContractEnd.SelectAll();
		}

		private void txtContractEnd_Leave(object sender, EventArgs e)
		{
			try
			{
				if (!VarGeneral.CheckDate(this.txtContractEnd.Text))
				{
					this.txtContractEnd.Text = "";
				}
				else
				{
					MaskedTextBox str = this.txtContractEnd;
					DateTime dateTime = Convert.ToDateTime(this.txtContractEnd.Text);
					str.Text = dateTime.ToString("yyyy/MM/dd");
				}
			}
			catch
			{
				this.txtContractEnd.Text = "";
			}
		}

		private void txtContractStart_Click(object sender, EventArgs e)
		{
			this.txtContractStart.SelectAll();
		}

		private void txtContractStart_Leave(object sender, EventArgs e)
		{
			try
			{
				if (!VarGeneral.CheckDate(this.txtContractStart.Text))
				{
					this.txtContractStart.Text = "";
				}
				else
				{
					MaskedTextBox str = this.txtContractStart;
					DateTime dateTime = Convert.ToDateTime(this.txtContractStart.Text);
					str.Text = dateTime.ToString("yyyy/MM/dd");
				}
			}
			catch
			{
				this.txtContractStart.Text = "";
			}
		}

		private void txtEngDes_Enter(object sender, EventArgs e)
		{
			Framework.Keyboard.Language.Switch("English");
		}

		private void txtRentOfYear_Leave(object sender, EventArgs e)
		{
			try
			{
				if (this.CmbTenanPayMethod.Enabled)
				{
					this.CheckAqsat();
				}
			}
			catch
			{
			}
		}

		private void UpdateVcr()
		{
			bool flag;
			int num = 0;
			int num1 = 0;
			try
			{
				num = int.Parse(this.Label_Count.Text);
			}
			catch
			{
				num = 0;
			}
			try
			{
				num1 = int.Parse(this.TextBox_Index.Text);
			}
			catch
			{
				num1 = 0;
			}
			if (num <= 1)
			{
				this.Button_First.Enabled = false;
				this.Button_Prev.Enabled = false;
				this.Button_Next.Enabled = false;
				this.Button_Last.Enabled = false;
				if ((VarGeneral.CurrentLang.ToString() == "0" ? false : VarGeneral.CurrentLang.ToString() != ""))
				{
					this.lable_Records.Text = (num == 0 ? "No records" : "Only Record");
				}
				else
				{
					this.lable_Records.Text = (num == 0 ? "لايوجد سجلات" : "سجل واحد فقط");
				}
			}
			else if (num1 == 1)
			{
				ButtonItem buttonFirst = this.Button_First;
				int num2 = 0;
				flag =(num2==0?false:true);
				this.Button_Prev.Enabled =(num2==0?false:true);
				buttonFirst.Enabled = flag;
				ButtonItem buttonLast = this.Button_Last;
				bool flag1 = num > 1;
				flag = flag1;
				this.Button_Next.Enabled = flag1;
				buttonLast.Enabled = flag;
				if ((VarGeneral.CurrentLang.ToString() == "0" ? false : VarGeneral.CurrentLang.ToString() != ""))
				{
					this.lable_Records.Text = string.Concat("First of ", num.ToString(), " records");
				}
				else
				{
					this.lable_Records.Text = string.Concat("الأول من ", num.ToString(), " سجلات");
				}
			}
			else if (num1 != num)
			{
				this.Button_First.Enabled = true;
				this.Button_Prev.Enabled = true;
				this.Button_Next.Enabled = true;
				this.Button_Last.Enabled = true;
				if ((VarGeneral.CurrentLang.ToString() == "0" ? false : VarGeneral.CurrentLang.ToString() != ""))
				{
					this.lable_Records.Text = string.Concat("Record ", num1.ToString(), " of ", num.ToString());
				}
				else
				{
					this.lable_Records.Text = string.Concat("السجل ", num1.ToString(), " من ", num.ToString());
				}
			}
			else
			{
				this.Button_Last.Enabled = false;
				this.Button_Next.Enabled = false;
				ButtonItem buttonItem = this.Button_First;
				bool flag2 = num > 1;
				flag = flag2;
				this.Button_Prev.Enabled = flag2;
				buttonItem.Enabled = flag;
				if ((VarGeneral.CurrentLang.ToString() == "0" ? false : VarGeneral.CurrentLang.ToString() != ""))
				{
					this.lable_Records.Text = string.Concat("Last of ", num.ToString(), " records");
				}
				else
				{
					this.lable_Records.Text = string.Concat("الأخير من ", num.ToString(), " سجلات");
				}
			}
		}

		private bool ValidData()
		{
			bool flag;
			if (!this.Button_Save.Visible)
			{
				flag = false;
			}
			else if ((this.State != FormState.Edit ? false : !this.CanEdit))
			{
				MessageBox.Show((this.LangArEn == 0 ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				flag = false;
			}
			else if ((this.textBox_ID.Text == "0" ? true : this.textBox_ID.Text == ""))
			{
				MessageBox.Show((this.LangArEn == 0 ? "لا يمكن الحفظ بدون رقم العقد" : "Can not save without the Contract No"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				this.textBox_ID.Focus();
				flag = false;
			}
			else if (!VarGeneral.CheckDate(this.txtContractStart.Text))
			{
				MessageBox.Show((this.LangArEn == 0 ? "لايمكن ان يكون التاريخ فارغاّ" : "Can not be Date is empty"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				this.txtContractStart.Focus();
				flag = false;
			}
			else if (VarGeneral.CheckDate(this.txtContractEnd.Text))
			{
				flag = true;
			}
			else
			{
				MessageBox.Show((this.LangArEn == 0 ? "لايمكن ان يكون التاريخ فارغاّ" : "Can not be Date is empty"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				this.txtContractEnd.Focus();
				flag = false;
			}
			return flag;
		}

		public void ViewDetails_Click(object sender, EventArgs e)
		{
			try
			{
				if ((int.Parse(this.Label_Count.Text ?? "") <= 0 ? false : (this.Label_Count.Text ?? "") != ""))
				{
					this.expandableSplitter1.Expandable = true;
					this.DGV_Main.PrimaryGrid.DataSource = null;
					this.DGV_Main.PrimaryGrid.VirtualMode = false;
					this.ViewState =ViewState.Deiles;
				}
				else
				{
					this.expandableSplitter1.Expandable = false;
				}
			}
			catch
			{
			}
		}

		public void ViewTable_Click(object sender, EventArgs e)
		{
			try
			{
				if ((int.Parse(this.Label_Count.Text ?? "") <= 0 ? false : (this.Label_Count.Text ?? "") != ""))
				{
					this.expandableSplitter1.Expandable = true;
					this.ViewState = ViewState.Table;
				}
				else
				{
					this.expandableSplitter1.Expandable = false;
					return;
				}
			}
			catch
			{
			}
			this.Fill_DGV_Main();
			int num = -1;
			try
			{
				num = Convert.ToInt32(this.TextBox_Index.TextBox.Text);
			}
			catch
			{
				num = -1;
			}
			num--;
			if ((num >= this.DGV_Main.PrimaryGrid.Rows.Count ? false : num >= 0))
			{
				this.DGV_Main.PrimaryGrid.Rows[num].EnsureVisible();
			}
		}

		public class ColumnDictinary
		{
			public string AText;

			public string EText;

			public bool IfDefault;

			public string Format;

			public ColumnDictinary(string aText, string eText, bool ifDefault, string format)
			{
				this.AText = aText;
				this.EText = eText;
				this.IfDefault = ifDefault;
				this.Format = format;
			}
		}

		private void expandableSplitter1_ExpandedChanged(object sender, ExpandedChangeEventArgs e)
		{

		}

		private void FlxPayment_Click(object sender, EventArgs e)
		{

		}
	}
}