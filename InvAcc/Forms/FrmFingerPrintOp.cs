using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using DevComponents.Editors.DateTimeAdv;
using InvAcc;
using ProShared.GeneralM;using ProShared;
using InvAcc.Properties;
using ProShared.Stock_Data;
using Microsoft.Office.Interop.Excel;
using SSSDateTime.Date;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
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
	public class FrmFingerPrintOp : Form
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

		private DataGridView ExcelGridView;

		private System.Windows.Forms.GroupBox groupBox1;

		private System.Windows.Forms.Label label1;

		private System.Windows.Forms.TextBox textBox_ItmNo;

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

		private System.Windows.Forms.Label label2;

		private System.Windows.Forms.TextBox txtUnit1;

		private System.Windows.Forms.Label label3;

		private System.Windows.Forms.TextBox txtPack1;

		private System.Windows.Forms.Label label6;

		private System.Windows.Forms.TextBox txtPrice1;

		private System.Windows.Forms.Label label7;

		private System.Windows.Forms.TextBox txtBarcod1;

		private System.Windows.Forms.Label label20;

		private System.Windows.Forms.TextBox txtBarcod5;

		private System.Windows.Forms.Label label21;

		private System.Windows.Forms.TextBox txtPrice5;

		private System.Windows.Forms.Label label22;

		private System.Windows.Forms.TextBox txtPack5;

		private System.Windows.Forms.Label label23;

		private System.Windows.Forms.TextBox txtUnit5;

		private System.Windows.Forms.Label label16;

		private System.Windows.Forms.TextBox txtBarcod4;

		private System.Windows.Forms.Label label17;

		private System.Windows.Forms.TextBox txtPrice4;

		private System.Windows.Forms.Label label18;

		private System.Windows.Forms.TextBox txtPack4;

		private System.Windows.Forms.Label label19;

		private System.Windows.Forms.TextBox txtUnit4;

		private System.Windows.Forms.Label label12;

		private System.Windows.Forms.TextBox txtBarcod3;

		private System.Windows.Forms.Label label13;

		private System.Windows.Forms.TextBox txtPrice3;

		private System.Windows.Forms.Label label14;

		private System.Windows.Forms.TextBox txtPack3;

		private System.Windows.Forms.Label label15;

		private System.Windows.Forms.TextBox txtUnit3;

		private System.Windows.Forms.Label label8;

		private System.Windows.Forms.TextBox txtBarcod2;

		private System.Windows.Forms.Label label9;

		private System.Windows.Forms.TextBox txtPrice2;

		private System.Windows.Forms.Label label10;

		private System.Windows.Forms.TextBox txtPack2;

		private System.Windows.Forms.Label label11;

		private System.Windows.Forms.TextBox txtUnit2;

		private System.Windows.Forms.TextBox txtLegates;

		private System.Windows.Forms.TextBox txtDistributors;

		private System.Windows.Forms.TextBox txtSentence;

		private System.Windows.Forms.TextBox txtSectorial;

		private System.Windows.Forms.TextBox textBox_VIP;

		private System.Windows.Forms.Label label28;

		private System.Windows.Forms.Label label24;

		private System.Windows.Forms.Label label27;

		private System.Windows.Forms.Label label26;

		private System.Windows.Forms.Label label25;

		private System.Windows.Forms.TextBox textBox_Cat;

		private BackgroundWorker backgroundWorker1;

		private System.Windows.Forms.Label label29;

		private Stock_DataDataContext dbs = new Stock_DataDataContext(VarGeneral.BranchCS);
        private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox checkBox2;
#pragma warning disable CS0414 // The field 'FrmFingerPrintOp.tx' is assigned but its value is never used
		private string tx = "SELECT   [tbl_Items].[ItemID] ,[ItemDisplayID],[Arb_Des]\r\n      ,[Eng_Des]\r\n ,[Unit]\r\n      ,[UnitPrice]\r\n      ,[UnitBaracod]\r\n      FROM[tbl_Items]\r\ninner join[tbl_ItemUnits] on[tbl_ItemUnits].[ItemID]=[tbl_Items].[ItemID]\r\n        inner join[tbl_ItemsPricessAndCosts] on[tbl_ItemsPricessAndCosts].[ItemID]=[tbl_Items].[ItemID]\r\n        WHERE[TyppeName]='التكلفة'";
#pragma warning restore CS0414 // The field 'FrmFingerPrintOp.tx' is assigned but its value is never used

		public T_Item Datathis_Itm
		{
			get
			{
				return this.Data_this_Itm;
			}
			set
			{
				this.Data_this_Itm = value;
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

		public FrmFingerPrintOp()
		{
			this.InitializeComponent();
			this.SetColumns();
		}

		private void ADD_Controls()
		{
			try
			{
				this.controls = new List<Control>()
				{
					this.textBox_ItmNo,
					this.textBox_SearchFilePath,
					this.textBox_NameA,
					this.textBox_NameE,
					this.button_OK,
					this.Button_Cancel,
					this.buttonX_ImportFile,
					this.ExcelGridView
				};
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				VarGeneral.DebLog.writeLog("ADD_Controls:", exception, true);
				MessageBox.Show(exception.Message);
			}
		}

		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
		}

		private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
		}

		private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
		}

		private void Button_Cancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		void clearemptyrows()
			 
		{
			for (int i = ExcelGridView.Rows.Count - 1; i > -1; i--)
			{
				DataGridViewRow row = ExcelGridView.Rows[i];

				
				bool f = false;
				for (int j=0;j<row.Cells.Count;j++)
				{	
				if(row.Cells[j].Value!=null)
					{
						if (row.Cells[j].Value != "")
						{
							f = true;
							break;
						}
					}
				}
				if(!f)
					ExcelGridView.Rows.RemoveAt(i);

			}
		}
		private void button_OK_Click(object sender, EventArgs e)
		{
			try
			{
				if (string.IsNullOrEmpty(this.textBox_ItmNo.Text))
				{
					MessageBox.Show((this.LangArEn == 0 ? "لابد من تخصيص عمود رقم الصنف" : "Must customize column employee number ?"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					this.textBox_ItmNo.Focus();
				}
				else if (string.IsNullOrEmpty(this.textBox_NameA.Text))
				{
					MessageBox.Show((this.LangArEn == 0 ? "لابد من تخصيص عمود إسم الصنف العربي" : "Must customize column Time Attendance ?"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					this.textBox_NameA.Focus();
				}
				else if (!string.IsNullOrEmpty(this.textBox_NameE.Text))
				{
					List<int> nums = new List<int>();
					List<T_Item> tItems = new List<T_Item>();
					bool flag = false;
					int num = db.MaxItemNo;
					int kk = (checkBox1.Checked == true ? 1 : 0);
				 
					for (int i =kk; i < this.ExcelGridView.Rows.Count; i++)
					{
						try
						{
							if (flag)
							{
								i = 0;
								flag = false;
							}
							this.State = FormState.New;
							this.Data_this_Itm = new T_Item()
							{
								ItmCat = new int?(1),
								Itm_ID =db.MaxItemNo,
								Itm_No = db.MaxItemNo.ToString()
							};
							int? nullable = null;
							this.Data_this_Itm.DefultVendor = nullable;
							this.Data_this_Itm.SerialKey = "";
							this.Data_this_Itm.FirstCost = new double?(0);
							this.Data_this_Itm.StartCost = new double?(0);
							this.Data_this_Itm.AvrageCost = new double?(0);
							this.Data_this_Itm.LastCost = new double?(0);
							this.Data_this_Itm.OpenQty = new double?(0);
							this.Data_this_Itm.ItmLoc = "";
							this.Data_this_Itm.ItmTyp = new int?(0);
							this.Data_this_Itm.QtyMax = new double?(0);
							this.Data_this_Itm.QtyLvl = new double?(0);
							this.Data_this_Itm.Lot = new int?(0);
							this.Data_this_Itm.DMY = new int?(1);
							this.Data_this_Itm.Price1 = new double?(0);
							this.Data_this_Itm.Price2 = new double?(0);
							this.Data_this_Itm.Price3 = new double?(0);
							this.Data_this_Itm.Price4 = new double?(0);
							this.Data_this_Itm.Price5 = new double?(0);
							this.Data_this_Itm.Price6 = new double?(0);
							this.Data_this_Itm.LrnExp = new int?(0);
							this.Data_this_Itm.ItemComm = new double?(0);
							this.Data_this_Itm.ItemDis = new double?(0);
							this.Data_this_Itm.TaxSales = new double?(0);
							this.Data_this_Itm.TaxPurchas = new double?(0);
							this.Data_this_Itm.Unit1 = new int?(1);
							this.Data_this_Itm.UntPri1 = new double?(1);
							this.Data_this_Itm.Pack1 = new double?(1);
							nullable = null;
							this.Data_this_Itm.Unit2 = nullable;
							this.Data_this_Itm.UntPri2 = new double?(0);
							this.Data_this_Itm.Pack2 = new double?(0);
							nullable = null;
							this.Data_this_Itm.Unit3 = nullable;
							this.Data_this_Itm.UntPri3 = new double?(0);
							this.Data_this_Itm.Pack3 = new double?(0);
							nullable = null;
							this.Data_this_Itm.Unit4 = nullable;
							this.Data_this_Itm.UntPri4 = new double?(0);
							this.Data_this_Itm.Pack4 = new double?(0);
							nullable = null;
							this.Data_this_Itm.Unit5 = nullable;
							this.Data_this_Itm.UntPri5 = new double?(0);
							this.Data_this_Itm.Pack5 = new double?(0);
							this.Data_this_Itm.DefultUnit = new int?(1);
							this.Data_this_Itm.DefPack = new double?(1);
							this.Data_this_Itm.BarCod1 = "";
							this.Data_this_Itm.BarCod2 = "";
							this.Data_this_Itm.BarCod3 = "";
							this.Data_this_Itm.BarCod4 = "";
							this.Data_this_Itm.BarCod5 = "";
							this.State = FormState.New;
							this.Data_this_Itm.Arb_Des = this.ExcelGridView.Rows[i].Cells[this.textBox_NameA.Text].Value.ToString().Trim();
							this.Data_this_Itm.Eng_Des = this.ExcelGridView.Rows[i].Cells[this.textBox_NameE.Text].Value.ToString().Trim();
							if (Data_this_Itm.Arb_Des == "" && Data_this_Itm.Eng_Des == "") continue;
							string s=this.ExcelGridView.Rows[i].Cells[this.txtUnit1.Text].Value.ToString().Trim();
							if (s == "")
							{
								this.Data_this_Itm.Unit1 = 1;
							}
							else
							this.Data_this_Itm.Unit1 = this.getunitid(this.ExcelGridView.Rows[i].Cells[this.txtUnit1.Text].Value.ToString().Trim());
							this.Data_this_Itm.DefultUnit = new int?(1);
							try
							{
								this.Data_this_Itm.ItmCat = this.getcategory(this.ExcelGridView.Rows[i].Cells[this.textBox_Cat.Text].Value.ToString().Trim());
							}
							catch
							{
								this.Data_this_Itm.ItmCat = new int?(1);
							}
							try
							{
								if (this.textBox_ItmNo.Text.Trim() != "")
								{
									this.Data_this_Itm.Itm_No = this.ExcelGridView.Rows[i].Cells[this.textBox_ItmNo.Text].Value.ToString().Trim();
								}
								else
								{
									this.Data_this_Itm.Itm_No = db.MaxItemNo.ToString();
									num++;

								}
							}
							catch
							{
								this.Data_this_Itm.Itm_No = db.MaxItemNo.ToString();
								num++;
							}
							try
							{
								if (this.txtPrice1.Text.Trim() != "")
								{
									this.Data_this_Itm.UntPri1 = new double?(double.Parse(this.ExcelGridView.Rows[i].Cells[this.txtPrice1.Text].Value.ToString().Trim()));
								}
							}
							catch
							{
								this.Data_this_Itm.UntPri1 = new double?(0);
							}
							if (this.txtBarcod1.Text.Trim() != "")
							{
								this.Data_this_Itm.BarCod1 = this.ExcelGridView.Rows[i].Cells[this.txtBarcod1.Text].Value.ToString().ToString();
							}

							if (txtUnit2.Text.Trim() != "")
							{
								try
								{
									if (this.ExcelGridView.Rows[i].Cells[this.txtUnit2.Text].Value.ToString().Trim() != "")
									{

										this.Data_this_Itm.Unit2 = this.getunitid(this.ExcelGridView.Rows[i].Cells[this.txtUnit2.Text].Value.ToString().Trim());
										try
										{
											if (this.txtPrice2.Text.Trim() != "")
											{
												this.Data_this_Itm.UntPri2 = new double?(double.Parse(this.ExcelGridView.Rows[i].Cells[this.txtPrice2.Text].Value.ToString().Trim()));
											}
										}
										catch
										{
											this.Data_this_Itm.UntPri2 = new double?(0);
										}
										try
										{
											if (this.txtBarcod2.Text.Trim() != "")
											{
												this.Data_this_Itm.BarCod2 = this.ExcelGridView.Rows[i].Cells[this.txtBarcod2.Text].Value.ToString().ToString();
											}
										}
										catch
										{
											this.Data_this_Itm.BarCod2 = "";


										}
										try
										{
											if (this.txtPack2.Text.Trim() != "")
											{
												this.Data_this_Itm.Pack2 = int.Parse(this.ExcelGridView.Rows[i].Cells[this.txtPack2.Text].Value.ToString().ToString());
											}

										}
										catch
										{
											this.Data_this_Itm.Pack2 = 1;

										}
									}
								}
                                catch
                                {

                                }
							}

							if (txtUnit3.Text.Trim() != "")
							{
								try
								{
									if (this.ExcelGridView.Rows[i].Cells[this.txtUnit3.Text].Value.ToString().Trim() != "")
									{

										this.Data_this_Itm.Unit3 = this.getunitid(this.ExcelGridView.Rows[i].Cells[this.txtUnit3.Text].Value.ToString().Trim());
										try
										{
											if (this.txtPrice3.Text.Trim() != "")
											{
												this.Data_this_Itm.UntPri3 = new double?(double.Parse(this.ExcelGridView.Rows[i].Cells[this.txtPrice3.Text].Value.ToString().Trim()));
											}
										}
										catch
										{
											this.Data_this_Itm.UntPri3 = new double?(0);
										}
										try
										{
											if (this.txtBarcod3.Text.Trim() != "")
											{
												this.Data_this_Itm.BarCod3 = this.ExcelGridView.Rows[i].Cells[this.txtBarcod3.Text].Value.ToString().ToString();
											}
										}
										catch
										{
											this.Data_this_Itm.BarCod3 = "";

										}

										try
										{
											if (this.txtPack3.Text.Trim() != "")
											{
												this.Data_this_Itm.Pack3 = int.Parse(this.ExcelGridView.Rows[i].Cells[this.txtPack3.Text].Value.ToString().ToString());
											}

										}
										catch
										{
											this.Data_this_Itm.Pack3 = 1;

										}
									}
								}
								catch
								{

								}
							}
							this.Data_this_Itm.Price1 = new double?(0);
							this.Data_this_Itm.Price2 = new double?(0);
							this.Data_this_Itm.Price3 = new double?(0);
							this.Data_this_Itm.Price4 = new double?(0);
							this.Data_this_Itm.Price5 = new double?(0);
							if (txtUnit4.Text.Trim() != "")
							{
                                try
                                {
									if (this.ExcelGridView.Rows[i].Cells[this.txtUnit4.Text].Value.ToString().Trim() != "")
									{

										this.Data_this_Itm.Unit4 = this.getunitid(this.ExcelGridView.Rows[i].Cells[this.txtUnit4.Text].Value.ToString().Trim());
										try
										{
											if (this.txtPrice4.Text.Trim() != "")
											{
												this.Data_this_Itm.UntPri4 = new double?(double.Parse(this.ExcelGridView.Rows[i].Cells[this.txtPrice4.Text].Value.ToString().Trim()));
											}
										}
										catch
										{
											this.Data_this_Itm.UntPri4 = new double?(0);
										}
										try
										{
											if (this.txtBarcod4.Text.Trim() != "")
											{
												this.Data_this_Itm.BarCod4 = this.ExcelGridView.Rows[i].Cells[this.txtBarcod4.Text].Value.ToString().ToString();
											}

										}
										catch
										{
											this.Data_this_Itm.BarCod4 = "";

										}

										try
										{
											if (this.txtPack4.Text.Trim() != "")
											{
												this.Data_this_Itm.Pack4 = int.Parse(this.ExcelGridView.Rows[i].Cells[this.txtPack4.Text].Value.ToString().ToString());
											}

										}
										catch
										{
											this.Data_this_Itm.Pack4 = 1;

										}

									}
                                    
								
								}

                                catch
                                {

								}
							
							}
							if (txtUnit5.Text.Trim() != "")
							{
								try
								{
									if (this.ExcelGridView.Rows[i].Cells[this.txtUnit5.Text].Value.ToString().Trim() != "")
									{

										this.Data_this_Itm.Unit5 = this.getunitid(this.ExcelGridView.Rows[i].Cells[this.txtUnit5.Text].Value.ToString().Trim());
										try
										{
											if (this.txtPrice5.Text.Trim() != "")
											{
												this.Data_this_Itm.UntPri5 = new double?(double.Parse(this.ExcelGridView.Rows[i].Cells[this.txtPrice5.Text].Value.ToString().Trim()));
											}
										}
										catch
										{
											this.Data_this_Itm.UntPri5 = new double?(0);
										}
										try
										{
											if (this.txtBarcod5.Text.Trim() != "")
											{
												this.Data_this_Itm.BarCod5 = this.ExcelGridView.Rows[i].Cells[this.txtBarcod5.Text].Value.ToString().ToString();
											}

										}
										catch
										{
											this.Data_this_Itm.BarCod5 = "";

										}

										try
										{
											if (this.txtPack5.Text.Trim() != "")
											{
												this.Data_this_Itm.Pack5 = int.Parse(this.ExcelGridView.Rows[i].Cells[this.txtPack5.Text].Value.ToString().ToString());
											}

										}
										catch
										{
											this.Data_this_Itm.Pack5 = 1;

										}
									}
								}
								catch
								{

								}
							}
							if (!string.IsNullOrEmpty(this.txtLegates.Text))
							{
								try
								{
									if (!string.IsNullOrEmpty(this.ExcelGridView.Rows[i].Cells[this.txtLegates.Text].Value.ToString().Trim()))
									{
										this.Data_this_Itm.Price3 = new double?(double.Parse(this.ExcelGridView.Rows[i].Cells[this.txtLegates.Text].Value.ToString().Trim()));
									}
								}
								catch
								{
									this.Data_this_Itm.Price3 = new double?(0);
								}
							}
							if (!string.IsNullOrEmpty(this.txtSectorial.Text))
							{
								try
								{
									if (!string.IsNullOrEmpty(this.ExcelGridView.Rows[i].Cells[this.txtSectorial.Text].Value.ToString().Trim()))
									{
										this.Data_this_Itm.Price4 = new double?(double.Parse(this.ExcelGridView.Rows[i].Cells[this.txtSectorial.Text].Value.ToString().Trim()));
									}
								}
								catch
								{
									this.Data_this_Itm.Price4 = new double?(0);
								}
							}
							if (!string.IsNullOrEmpty(this.textBox_VIP.Text))
							{
								try
								{
									if (!string.IsNullOrEmpty(this.ExcelGridView.Rows[i].Cells[this.textBox_VIP.Text].Value.ToString().Trim()))
									{
										this.Data_this_Itm.Price5 = new double?(double.Parse(this.ExcelGridView.Rows[i].Cells[this.textBox_VIP.Text].Value.ToString().Trim()));
									}
								}
								catch
								{
									this.Data_this_Itm.Price5 = new double?(0);
								}
							}

						if(checkBox2.Checked)

								this.Data_this_Itm.Lot = new int?(1);

							this.Data_this_Itm.CompanyID = new int?(1);
							this.Data_this_Itm.ItmImg = null;
							this.Data_this_Itm.IsPoints = new bool?(true);
							this.Data_this_Itm.IsBalance = new bool?(false);
							this.Data_this_Itm.InvSaleStoped = new bool?(false);
							this.Data_this_Itm.InvSaleReturnStoped = new bool?(false);
							this.Data_this_Itm.InvPaymentStoped = new bool?(false);
							this.Data_this_Itm.InvPaymentReturnStoped = new bool?(false);
							this.Data_this_Itm.InvEnterStoped = new bool?(false);
							this.Data_this_Itm.InvOutStoped = new bool?(false);
							if (this.State != FormState.New)
							{
								this.dbs.Log = VarGeneral.DebugLog;
								this.dbs.SubmitChanges(ConflictMode.ContinueOnConflict);
							}
							else
							{
								try
								{
									this.dbs.T_Items.InsertOnSubmit(this.Data_this_Itm);
									this.dbs.Log = VarGeneral.DebugLog;
									this.dbs.SubmitChanges(ConflictMode.ContinueOnConflict);
								}
								catch
								{
									//MessageBox.Show("Test");
								}
							}
							try
							{
								this.ExcelGridView.Rows.RemoveAt(i);
								i = 0;
								this.dbInstance = null;
							}
							catch
							{
							}
							flag = true;
							kks++;
							if(kks%100==0)
								this.dbs.SubmitChanges(ConflictMode.ContinueOnConflict);
						}
#pragma warning disable CS0168 // The variable 'ec' is declared but never used
						catch(Exception ec)
#pragma warning restore CS0168 // The variable 'ec' is declared but never used
						{
						}
					}
					MessageBox.Show((this.LangArEn == 0 ? "تم استيراد بيانات الأًصناف بنجاح " : "Data were imported attendance successfully"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					this.GridStyle();
					this.State = FormState.Saved;
					this.dbs.SubmitChanges(ConflictMode.ContinueOnConflict);
				}
				else
				{
					MessageBox.Show((this.LangArEn == 0 ? "لابد من تخصيص عمود اسم الصنف الانجليزي" : "Must customize column Leaver Time ?"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					this.textBox_NameE.Focus();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				VarGeneral.DebLog.writeLog("button_OK_Click:", exception, true);
				MessageBox.Show(exception.Message);
				this.GridStyle();
				this.State = FormState.Saved;
			}
		}
		int kks = 1;
		private void buttonX_ImportFile_Click(object sender, EventArgs e)
		{
			try
			{
				this.buttonX_ImportFile.Checked = true;
				OpenFileDialog openFileDialog = new OpenFileDialog()
				{
					Filter = "Excel Files(.xls)|*.xls|Excel Files(.xlsx)|*.xlsx| Excel Files(*.xlsm)|*.xlsm"
				};
				try
				{
					if (VarGeneral.gUserName == "runsetting")
					{
						openFileDialog.InitialDirectory = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
					}
				}
				catch
				{
				}
				openFileDialog.Title = "اختيار ملف الأصناف";
				if (openFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
				{
					this.textBox_SearchFilePath.Text = "";
					try
					{
						this.ExcelGridView.DataSource = null;
						this.ExcelGridView.Rows.Clear();
						this.ExcelGridView.Columns.Clear();
					}
					catch
					{
					}
				}
				else
				{
					this.textBox_SearchFilePath.Text = openFileDialog.FileName;
					this.FillGrid();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				VarGeneral.DebLog.writeLog("button_SelectPath_Click:", exception, true);
				MessageBox.Show(exception.Message);
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
						(this.controls[i] as DateTimePicker).Value = DateTime.Now;
					}
					else if (this.controls[i].GetType() == typeof(DateTimeInput))
					{
						(this.controls[i] as DateTimeInput).Value = DateTime.Now;
					}
					else if ((this.controls[i].GetType() != typeof(ComboBox) ? false : (this.controls[i] as ComboBox).Items.Count > 0))
					{
						try
						{
							if ((this.controls[i] as ComboBox).Items.Count > 0)
							{
								(this.controls[i] as ComboBox).SelectedIndex = 0;
							}
						}
						catch
						{
							(this.controls[i] as ComboBox).SelectedIndex = -1;
						}
					}
					else if (this.controls[i].GetType() == typeof(System.Windows.Forms.CheckBox))
					{
						(this.controls[i] as System.Windows.Forms.CheckBox).Checked = false;
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
						else if ((this.controls[i].GetType() == typeof(VisualStyleElement.TextBox) || this.controls[i].GetType() == typeof(TextBoxX) ? true : this.controls[i].GetType() == typeof(MaskedTextBox)))
						{
							this.controls[i].Text = "";
						}
						else if (this.controls[i].GetType() == typeof(System.Windows.Forms.CheckBox))
						{
							(this.controls[i] as System.Windows.Forms.CheckBox).Checked = false;
						}
						else if (this.controls[i].GetType() == typeof(RadioButton))
						{
							(this.controls[i] as RadioButton).Checked = false;
						}
					}
				}
			}
		}

		private System.Data.DataTable ConvertExcelToDataTable(string FileName)
		{
			Worksheet item = (Worksheet)(new Microsoft.Office.Interop.Excel.Application()).Workbooks.Open(this.textBox_SearchFilePath.Text, 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0).Worksheets[1];
			Microsoft.Office.Interop.Excel.Range usedRange = item.UsedRange;
			int count = usedRange.Rows.Count;
			int num = usedRange.Columns.Count;
			System.Data.DataTable dataTable = new System.Data.DataTable();
			object[,] value2 = (object[,])usedRange.Value2;
			for (int i = 0; i < num; i++)
			{
				dataTable.Columns.Add(this.ColumnsFinger[i]);
			}
			for (int j = 2; j <= count; j++)
			{
				object[] objArray = new object[num];
				for (int k = 1; k <= num; k++)
				{
					objArray[k - 1] = value2[j, k];
				}
				dataTable.Rows.Add(objArray);
			}
			return dataTable;
		}

		protected override void Dispose(bool disposing)
		{
			if ((!disposing ? false : this.components != null))
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private int DTime(string BTime, string Etime)
		{
			int num;
			try
			{
				if ((string.IsNullOrEmpty(BTime) ? true : string.IsNullOrEmpty(Etime)))
				{
					num = 0;
				}
				else if ((!VarGeneral.CheckDate(BTime) ? false : VarGeneral.CheckDate(Etime)))
				{
					int num1 = 0;
					if (TimeSpan.Parse(Etime) > TimeSpan.Parse(BTime))
					{
						num1 = int.Parse(Etime.Substring(3, 2)) - int.Parse(BTime.Substring(3, 2));
						num1 = num1 + 60 * (int.Parse(Etime.Substring(0, 2)) - int.Parse(BTime.Substring(0, 2)));
					}
					num = num1;
				}
				else
				{
					num = 0;
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				VarGeneral.DebLog.writeLog("DTime:", exception, true);
				MessageBox.Show(exception.Message);
				num = 0;
			}
			return num;
		}

		private void ExcelGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				Activcontrol.Text = ExcelGridView.Columns[e.ColumnIndex].Name.ToString();
				Activcontrol.Focus();
				SendKeys.Send("{Tab}");
			}
			catch { }

		}

		private void ExcelGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			DateTime dateTime;
			int rowIndex = e.RowIndex;
			int columnIndex = e.ColumnIndex;
			try
			{
				if ((string.IsNullOrEmpty(this.textBox_NameA.Text) ? false : this.ExcelGridView.Columns[columnIndex].Name == this.textBox_NameA.Text))
				{
					if (VarGeneral.CheckTime(this.ExcelGridView.Rows[rowIndex].Cells[columnIndex].Value.ToString()))
					{
						DataGridViewCell item = this.ExcelGridView.Rows[rowIndex].Cells[columnIndex];
						dateTime = Convert.ToDateTime(this.ExcelGridView.Rows[rowIndex].Cells[columnIndex].Value.ToString());
						item.Value = dateTime.ToString("HH:mm");
					}
					else
					{
						this.ExcelGridView.Rows[rowIndex].Cells[columnIndex].Value = "";
					}
				}
				if ((string.IsNullOrEmpty(this.textBox_NameE.Text) ? false : this.ExcelGridView.Columns[columnIndex].Name == this.textBox_NameE.Text))
				{
					if (VarGeneral.CheckTime(this.ExcelGridView.Rows[rowIndex].Cells[columnIndex].Value.ToString()))
					{
						DataGridViewCell str = this.ExcelGridView.Rows[rowIndex].Cells[columnIndex];
						dateTime = Convert.ToDateTime(this.ExcelGridView.Rows[rowIndex].Cells[columnIndex].Value.ToString());
						str.Value = dateTime.ToString("HH:mm");
					}
					else
					{
						this.ExcelGridView.Rows[rowIndex].Cells[columnIndex].Value = "";
					}
				}
			}
			catch
			{
				this.ExcelGridView.Rows[rowIndex].Cells[columnIndex].Value = "";
			}
		}
		void FillGrid()
        {
			 
	
			String ssFile = textBox_SearchFilePath.Text;
			SpreadsheetGear.IWorkbook workbook = SpreadsheetGear.Factory.GetWorkbook(ssFile);

			// Get a DataSet from an existing defined name
			DataSet dataSet = workbook.GetDataSet( SpreadsheetGear.Data.GetDataFlags.FormattedText);

			// Bind a DataGrid to the DataSet
			ExcelGridView.DataSource = dataSet.Tables[0];
			ExcelGridView.Refresh();

		}

		private void FillGrid2()
		{
			Thread thread = new Thread(new ThreadStart(this.SplashStart));
			thread.Start();
			Thread.Sleep(10);
			if (!this.buttonX_ImportFile.Checked)
			{
				if (string.IsNullOrEmpty(this.textBox_SearchFilePath.Text))
				{
					return;
				}
				if (File.Exists(this.textBox_SearchFilePath.Text))
				{
					try
					{
						this.ExcelGridView.DataSource = null;
						this.ExcelGridView.Rows.Clear();
						this.ExcelGridView.Columns.Clear();
					}
					catch
					{
					}
					StreamReader streamReader = new StreamReader(this.textBox_SearchFilePath.Text, Encoding.Default, true);
					this.textBox1.Text = streamReader.ReadToEnd();
					int str = 0;
					for (int i = 0; i < this.ColumnsFinger.Count; i++)
					{
						this.ExcelGridView.Columns.Add(this.ColumnsFinger[i], this.ColumnsFinger[i]);
					}
					for (int j = 0; j < this.textBox1.Lines.Count<string>(); j++)
					{
						this.ExcelGridView.Rows.Add();
						if (!string.IsNullOrEmpty(this.textBox1.Lines[j]))
						{
							string lines = this.textBox1.Lines[j];
							string[] strArrays = lines.TrimStart(new char[0]).Split(new char[] { ' ' });
							for (int k = 0; k < strArrays.Count<string>(); k++)
							{
								if ((this.IsInteger(strArrays[k]) ? true : string.IsNullOrEmpty(strArrays[k])))
								{
									this.ExcelGridView.Rows[j].Cells[str].Value = strArrays[k].ToString();
									str++;
								}
							}
						}
						str = 0;
					}
					try
					{
						this.ExcelGridView.Rows.RemoveAt(0);
					}
					catch
					{
					}
					try
					{
						bool flag = true;
						for (int l = 0; l < this.ExcelGridView.Rows.Count; l++)
						{
							flag = true;
							int num = 0;
							while (num < this.ExcelGridView.Columns.Count)
							{
								if ((this.ExcelGridView.Rows[l].Cells[num].Value == null ? true : this.ExcelGridView.Rows[l].Cells[num].Value.ToString() == ""))
								{
									num++;
								}
								else
								{
									flag = false;
									break;
								}
							}
							if (flag)
							{
								this.ExcelGridView.Rows.RemoveAt(l);
							}
						}
					}
					catch
					{
					}
				}
			}
			else
			{
				if (string.IsNullOrEmpty(this.textBox_SearchFilePath.Text))
				{
					return;
				}
				if (File.Exists(this.textBox_SearchFilePath.Text))
				{
					try
					{
						this.ExcelGridView.DataSource = null;
						this.ExcelGridView.Rows.Clear();
						this.ExcelGridView.Columns.Clear();
					}
					catch
					{
					}
					this.ExcelGridView.DataSource = this.ConvertExcelToDataTable(this.textBox_SearchFilePath.Text);
				}
			}
			thread.Abort();
			this.GridStyle();
		}

		private void FrmFingerPrintOp_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				base.Close();
			}
		}

		private void FrmFingerPrintOp_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				SendKeys.Send("{Tab}");
			}
		}

		private void FrmFingerPrintOp_Load(object sender, EventArgs e)
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FrmFingerPrintOp));
			if (VarGeneral.CurrentLang != null)
			{
				if ((VarGeneral.CurrentLang.ToString() == "0" ? false : VarGeneral.CurrentLang.ToString() != ""))
				{
					this.LangArEn = 1;
				}
				else
				{
					this.LangArEn = 0;
				}
			}
			try
			{
				this.buttonX_ImportFile.Checked = true;
				this.ADD_Controls();
				this.Clear();
				this.Clear();
				if (!string.IsNullOrEmpty(this.textBox_SearchFilePath.Text))
				{
					this.FillGrid();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				VarGeneral.DebLog.writeLog("FrmSystem_Load:", exception, true);
				MessageBox.Show(exception.Message);
			}
		}

		private void FrmInvSale_Shown(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
			base.WindowState = FormWindowState.Maximized;
		}

		private void FrmInvSale_SizeChanged(object sender, EventArgs e)
		{
		}

		private int? getcategory(string v)
		{
			T_CATEGORY tCATEGORY = this.dbs.StockCatbyname(v);
			int cATID = 0;
			if (tCATEGORY.Arb_Des != null)
			{
				cATID = tCATEGORY.CAT_ID;
			}
			else
			{
				tCATEGORY = new T_CATEGORY()
				{
					CAT_No = this.dbs.MaxCatNo.ToString(),
					Arb_Des = v
				};
				cATID = this.dbs.MaxCatNo;
				tCATEGORY.CAT_ID = cATID;
				tCATEGORY.Eng_Des = string.Concat("Cat ", cATID.ToString());
				this.dbs.T_CATEGORies.InsertOnSubmit(tCATEGORY);
				this.dbs.SubmitChanges();
			}
			return new int?(cATID);
		}

		private void getda()
		{
			Worksheet item = (Worksheet)(new Microsoft.Office.Interop.Excel. Application()).Workbooks.Open(this.textBox_SearchFilePath.Text, 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0).Worksheets[1];
			Microsoft.Office.Interop.Excel.Range usedRange = item.UsedRange;
			int count = usedRange.Rows.Count;
			int num = usedRange.Columns.Count;
			System.Data.DataTable dataTable = new System.Data.DataTable();
			object[,] value2 = (object[,])usedRange.Value2;
			for (int i = 0; i < num; i++)
			{
				dataTable.Columns.Add(this.ColumnsFinger[i]);
			}
			for (int j = 2; j <= count; j++)
			{
				object[] objArray = new object[num];
				for (int k = 1; k <= num; k++)
				{
					objArray[k - 1] = value2[j, k];
				}
				dataTable.Rows.Add(objArray);
			}
			this.ExcelGridView.DataSource = dataTable;
		}

		private int? getunitid(string v)
		{
			T_Unit tUnit = this.dbs.StockUnitid(v);
			if (tUnit.Arb_Des == null)
			{
				tUnit = new T_Unit();
				int maxUnitNo = this.dbs.MaxUnitNo;
				tUnit.Unit_No = maxUnitNo.ToString();
				tUnit.Arb_Des = v;
				tUnit.Unit_ID = this.dbs.MaxUnitNo;
				maxUnitNo = tUnit.Unit_ID;
				tUnit.Eng_Des = string.Concat("Unit ", maxUnitNo.ToString());
				this.dbs.T_Units.InsertOnSubmit(tUnit);
				this.dbs.SubmitChanges();
			}
			return new int?(tUnit.Unit_ID);
		}

		private void GridStyle()
		{
			try
			{
				for (int i = 0; i < this.ExcelGridView.Rows.Count; i += 2)
				{
					this.ExcelGridView.Rows[i].DefaultCellStyle.BackColor = Color.PapayaWhip;
				}
			}
			catch
			{
			}
		}

		private void InitializeComponent()
		{
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonX_ImportFile = new DevComponents.DotNetBar.ButtonX();
            this.textBox_SearchFilePath = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox_Cat = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.txtDistributors = new System.Windows.Forms.TextBox();
            this.txtSentence = new System.Windows.Forms.TextBox();
            this.txtSectorial = new System.Windows.Forms.TextBox();
            this.textBox_VIP = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.txtLegates = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtBarcod5 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtPrice5 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtPack5 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtUnit5 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtBarcod4 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtPrice4 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtPack4 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtUnit4 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBarcod3 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPrice3 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtPack3 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtUnit3 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBarcod2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPrice2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPack2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtUnit2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBarcod1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrice1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPack1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUnit1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_ItmNo = new System.Windows.Forms.TextBox();
            this.textBox_NameE = new System.Windows.Forms.TextBox();
            this.textBox_NameA = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ExcelGridView = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Button_Cancel = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExcelGridView)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.buttonX_ImportFile);
            this.panel2.Controls.Add(this.textBox_SearchFilePath);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.ExcelGridView);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(756, 506);
            this.panel2.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 6F);
            this.textBox1.Location = new System.Drawing.Point(3, 555);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(1659, 168);
            this.textBox1.TabIndex = 873;
            this.textBox1.WordWrap = false;
            // 
            // buttonX_ImportFile
            // 
            this.buttonX_ImportFile.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_ImportFile.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_ImportFile.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.buttonX_ImportFile.Location = new System.Drawing.Point(4, 27);
            this.buttonX_ImportFile.Name = "buttonX_ImportFile";
            this.buttonX_ImportFile.Size = new System.Drawing.Size(162, 57);
            this.buttonX_ImportFile.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.buttonX_ImportFile.TabIndex = 870;
            this.buttonX_ImportFile.Text = "الإستيراد من ملف أكسيل";
            this.buttonX_ImportFile.Click += new System.EventHandler(this.buttonX_ImportFile_Click);
            // 
            // textBox_SearchFilePath
            // 
            this.textBox_SearchFilePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox_SearchFilePath.Enabled = false;
            this.textBox_SearchFilePath.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox_SearchFilePath.ForeColor = System.Drawing.Color.Red;
            this.textBox_SearchFilePath.Location = new System.Drawing.Point(22, -4);
            this.textBox_SearchFilePath.Name = "textBox_SearchFilePath";
            this.textBox_SearchFilePath.ReadOnly = true;
            this.textBox_SearchFilePath.Size = new System.Drawing.Size(447, 21);
            this.textBox_SearchFilePath.TabIndex = 868;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.textBox_Cat);
            this.groupBox1.Controls.Add(this.label29);
            this.groupBox1.Controls.Add(this.txtDistributors);
            this.groupBox1.Controls.Add(this.txtSentence);
            this.groupBox1.Controls.Add(this.txtSectorial);
            this.groupBox1.Controls.Add(this.textBox_VIP);
            this.groupBox1.Controls.Add(this.label28);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.txtLegates);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.txtBarcod5);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.txtPrice5);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.txtPack5);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.txtUnit5);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txtBarcod4);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.txtPrice4);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.txtPack4);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.txtUnit4);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtBarcod3);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtPrice3);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtPack3);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txtUnit3);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtBarcod2);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtPrice2);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtPack2);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtUnit2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtBarcod1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtPrice1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtPack1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtUnit1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_ItmNo);
            this.groupBox1.Controls.Add(this.textBox_NameE);
            this.groupBox1.Controls.Add(this.textBox_NameA);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(172, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(576, 272);
            this.groupBox1.TabIndex = 867;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "تخصيص";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(7, 220);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(41, 17);
            this.checkBox1.TabIndex = 920;
            this.checkBox1.Text = "R1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox_Cat
            // 
            this.textBox_Cat.BackColor = System.Drawing.Color.Yellow;
            this.textBox_Cat.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBox_Cat.ForeColor = System.Drawing.Color.Red;
            this.textBox_Cat.Location = new System.Drawing.Point(21, 23);
            this.textBox_Cat.MaxLength = 2;
            this.textBox_Cat.Name = "textBox_Cat";
            this.textBox_Cat.Size = new System.Drawing.Size(61, 22);
            this.textBox_Cat.TabIndex = 3;
            this.textBox_Cat.Text = "C";
            this.textBox_Cat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Cat.Click += new System.EventHandler(this.textBox_ItmNo_Click);
            this.textBox_Cat.Enter += new System.EventHandler(this.textBox_ItmNo_Enter);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label29.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label29.Location = new System.Drawing.Point(86, 28);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(44, 13);
            this.label29.TabIndex = 919;
            this.label29.Text = "التصنيف";
            // 
            // txtDistributors
            // 
            this.txtDistributors.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtDistributors.ForeColor = System.Drawing.Color.Red;
            this.txtDistributors.Location = new System.Drawing.Point(364, 216);
            this.txtDistributors.MaxLength = 2;
            this.txtDistributors.Name = "txtDistributors";
            this.txtDistributors.Size = new System.Drawing.Size(61, 22);
            this.txtDistributors.TabIndex = 25;
            this.txtDistributors.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDistributors.Enter += new System.EventHandler(this.textBox_ItmNo_Enter);
            // 
            // txtSentence
            // 
            this.txtSentence.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtSentence.ForeColor = System.Drawing.Color.Red;
            this.txtSentence.Location = new System.Drawing.Point(250, 216);
            this.txtSentence.MaxLength = 2;
            this.txtSentence.Name = "txtSentence";
            this.txtSentence.Size = new System.Drawing.Size(61, 22);
            this.txtSentence.TabIndex = 26;
            this.txtSentence.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSentence.Enter += new System.EventHandler(this.textBox_ItmNo_Enter);
            // 
            // txtSectorial
            // 
            this.txtSectorial.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtSectorial.ForeColor = System.Drawing.Color.Red;
            this.txtSectorial.Location = new System.Drawing.Point(134, 216);
            this.txtSectorial.MaxLength = 2;
            this.txtSectorial.Name = "txtSectorial";
            this.txtSectorial.Size = new System.Drawing.Size(61, 22);
            this.txtSectorial.TabIndex = 27;
            this.txtSectorial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSectorial.Enter += new System.EventHandler(this.textBox_ItmNo_Enter);
            // 
            // textBox_VIP
            // 
            this.textBox_VIP.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBox_VIP.ForeColor = System.Drawing.Color.Red;
            this.textBox_VIP.Location = new System.Drawing.Point(67, 215);
            this.textBox_VIP.MaxLength = 2;
            this.textBox_VIP.Name = "textBox_VIP";
            this.textBox_VIP.Size = new System.Drawing.Size(61, 22);
            this.textBox_VIP.TabIndex = 28;
            this.textBox_VIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_VIP.Enter += new System.EventHandler(this.textBox_ItmNo_Enter);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.label28.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic);
            this.label28.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label28.Location = new System.Drawing.Point(244, 193);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(72, 16);
            this.label28.TabIndex = 910;
            this.label28.Text = "سعر الجملة";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic);
            this.label24.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label24.Location = new System.Drawing.Point(472, 193);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(79, 16);
            this.label24.TabIndex = 909;
            this.label24.Text = "سعر المندوب";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic);
            this.label27.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label27.Location = new System.Drawing.Point(359, 193);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(70, 16);
            this.label27.TabIndex = 908;
            this.label27.Text = "سعر الموزع";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic);
            this.label26.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label26.Location = new System.Drawing.Point(69, 193);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(53, 16);
            this.label26.TabIndex = 912;
            this.label26.Text = "سعر آخر";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic);
            this.label25.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label25.Location = new System.Drawing.Point(128, 193);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(73, 16);
            this.label25.TabIndex = 911;
            this.label25.Text = "سعر التجزئة";
            // 
            // txtLegates
            // 
            this.txtLegates.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtLegates.ForeColor = System.Drawing.Color.Red;
            this.txtLegates.Location = new System.Drawing.Point(481, 216);
            this.txtLegates.MaxLength = 2;
            this.txtLegates.Name = "txtLegates";
            this.txtLegates.Size = new System.Drawing.Size(61, 22);
            this.txtLegates.TabIndex = 24;
            this.txtLegates.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtLegates.Enter += new System.EventHandler(this.textBox_ItmNo_Enter);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label20.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label20.Location = new System.Drawing.Point(88, 165);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(66, 13);
            this.label20.TabIndex = 906;
            this.label20.Text = "رقم الباركود :";
            // 
            // txtBarcod5
            // 
            this.txtBarcod5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtBarcod5.ForeColor = System.Drawing.Color.Red;
            this.txtBarcod5.Location = new System.Drawing.Point(21, 161);
            this.txtBarcod5.MaxLength = 2;
            this.txtBarcod5.Name = "txtBarcod5";
            this.txtBarcod5.Size = new System.Drawing.Size(61, 22);
            this.txtBarcod5.TabIndex = 23;
            this.txtBarcod5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBarcod5.Click += new System.EventHandler(this.textBox_ItmNo_Click);
            this.txtBarcod5.Enter += new System.EventHandler(this.textBox_ItmNo_Enter);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label21.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label21.Location = new System.Drawing.Point(231, 165);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(59, 13);
            this.label21.TabIndex = 904;
            this.label21.Text = "سعر البيع :";
            // 
            // txtPrice5
            // 
            this.txtPrice5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtPrice5.ForeColor = System.Drawing.Color.Red;
            this.txtPrice5.Location = new System.Drawing.Point(165, 161);
            this.txtPrice5.MaxLength = 2;
            this.txtPrice5.Name = "txtPrice5";
            this.txtPrice5.Size = new System.Drawing.Size(61, 22);
            this.txtPrice5.TabIndex = 22;
            this.txtPrice5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPrice5.Click += new System.EventHandler(this.textBox_ItmNo_Click);
            this.txtPrice5.Enter += new System.EventHandler(this.textBox_ItmNo_Enter);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label22.Location = new System.Drawing.Point(368, 165);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(44, 13);
            this.label22.TabIndex = 902;
            this.label22.Text = "التعبئة :";
            // 
            // txtPack5
            // 
            this.txtPack5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtPack5.ForeColor = System.Drawing.Color.Red;
            this.txtPack5.Location = new System.Drawing.Point(301, 161);
            this.txtPack5.MaxLength = 2;
            this.txtPack5.Name = "txtPack5";
            this.txtPack5.Size = new System.Drawing.Size(61, 22);
            this.txtPack5.TabIndex = 21;
            this.txtPack5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPack5.Click += new System.EventHandler(this.textBox_ItmNo_Click);
            this.txtPack5.Enter += new System.EventHandler(this.textBox_ItmNo_Enter);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label23.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label23.Location = new System.Drawing.Point(503, 165);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(52, 13);
            this.label23.TabIndex = 900;
            this.label23.Text = "الوحدة 5 :";
            // 
            // txtUnit5
            // 
            this.txtUnit5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtUnit5.ForeColor = System.Drawing.Color.Red;
            this.txtUnit5.Location = new System.Drawing.Point(434, 161);
            this.txtUnit5.MaxLength = 2;
            this.txtUnit5.Name = "txtUnit5";
            this.txtUnit5.Size = new System.Drawing.Size(61, 22);
            this.txtUnit5.TabIndex = 20;
            this.txtUnit5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUnit5.Click += new System.EventHandler(this.textBox_ItmNo_Click);
            this.txtUnit5.Enter += new System.EventHandler(this.textBox_ItmNo_Enter);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(88, 138);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(66, 13);
            this.label16.TabIndex = 898;
            this.label16.Text = "رقم الباركود :";
            // 
            // txtBarcod4
            // 
            this.txtBarcod4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtBarcod4.ForeColor = System.Drawing.Color.Red;
            this.txtBarcod4.Location = new System.Drawing.Point(21, 134);
            this.txtBarcod4.MaxLength = 2;
            this.txtBarcod4.Name = "txtBarcod4";
            this.txtBarcod4.Size = new System.Drawing.Size(61, 22);
            this.txtBarcod4.TabIndex = 19;
            this.txtBarcod4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBarcod4.Click += new System.EventHandler(this.textBox_ItmNo_Click);
            this.txtBarcod4.Enter += new System.EventHandler(this.textBox_ItmNo_Enter);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(231, 138);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(59, 13);
            this.label17.TabIndex = 896;
            this.label17.Text = "سعر البيع :";
            // 
            // txtPrice4
            // 
            this.txtPrice4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtPrice4.ForeColor = System.Drawing.Color.Red;
            this.txtPrice4.Location = new System.Drawing.Point(165, 134);
            this.txtPrice4.MaxLength = 2;
            this.txtPrice4.Name = "txtPrice4";
            this.txtPrice4.Size = new System.Drawing.Size(61, 22);
            this.txtPrice4.TabIndex = 18;
            this.txtPrice4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPrice4.Click += new System.EventHandler(this.textBox_ItmNo_Click);
            this.txtPrice4.Enter += new System.EventHandler(this.textBox_ItmNo_Enter);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(368, 138);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(44, 13);
            this.label18.TabIndex = 894;
            this.label18.Text = "التعبئة :";
            // 
            // txtPack4
            // 
            this.txtPack4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtPack4.ForeColor = System.Drawing.Color.Red;
            this.txtPack4.Location = new System.Drawing.Point(301, 134);
            this.txtPack4.MaxLength = 2;
            this.txtPack4.Name = "txtPack4";
            this.txtPack4.Size = new System.Drawing.Size(61, 22);
            this.txtPack4.TabIndex = 17;
            this.txtPack4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPack4.Click += new System.EventHandler(this.textBox_ItmNo_Click);
            this.txtPack4.Enter += new System.EventHandler(this.textBox_ItmNo_Enter);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label19.Location = new System.Drawing.Point(503, 138);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(52, 13);
            this.label19.TabIndex = 892;
            this.label19.Text = "الوحدة 4 :";
            // 
            // txtUnit4
            // 
            this.txtUnit4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtUnit4.ForeColor = System.Drawing.Color.Red;
            this.txtUnit4.Location = new System.Drawing.Point(434, 134);
            this.txtUnit4.MaxLength = 2;
            this.txtUnit4.Name = "txtUnit4";
            this.txtUnit4.Size = new System.Drawing.Size(61, 22);
            this.txtUnit4.TabIndex = 16;
            this.txtUnit4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUnit4.Click += new System.EventHandler(this.textBox_ItmNo_Click);
            this.txtUnit4.Enter += new System.EventHandler(this.textBox_ItmNo_Enter);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(88, 111);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 13);
            this.label12.TabIndex = 890;
            this.label12.Text = "رقم الباركود :";
            // 
            // txtBarcod3
            // 
            this.txtBarcod3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtBarcod3.ForeColor = System.Drawing.Color.Red;
            this.txtBarcod3.Location = new System.Drawing.Point(21, 107);
            this.txtBarcod3.MaxLength = 2;
            this.txtBarcod3.Name = "txtBarcod3";
            this.txtBarcod3.Size = new System.Drawing.Size(61, 22);
            this.txtBarcod3.TabIndex = 15;
            this.txtBarcod3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBarcod3.Click += new System.EventHandler(this.textBox_ItmNo_Click);
            this.txtBarcod3.Enter += new System.EventHandler(this.textBox_ItmNo_Enter);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(231, 111);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 13);
            this.label13.TabIndex = 888;
            this.label13.Text = "سعر البيع :";
            // 
            // txtPrice3
            // 
            this.txtPrice3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtPrice3.ForeColor = System.Drawing.Color.Red;
            this.txtPrice3.Location = new System.Drawing.Point(165, 107);
            this.txtPrice3.MaxLength = 2;
            this.txtPrice3.Name = "txtPrice3";
            this.txtPrice3.Size = new System.Drawing.Size(61, 22);
            this.txtPrice3.TabIndex = 14;
            this.txtPrice3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPrice3.Click += new System.EventHandler(this.textBox_ItmNo_Click);
            this.txtPrice3.Enter += new System.EventHandler(this.textBox_ItmNo_Enter);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(368, 111);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 13);
            this.label14.TabIndex = 886;
            this.label14.Text = "التعبئة :";
            // 
            // txtPack3
            // 
            this.txtPack3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtPack3.ForeColor = System.Drawing.Color.Red;
            this.txtPack3.Location = new System.Drawing.Point(301, 107);
            this.txtPack3.MaxLength = 2;
            this.txtPack3.Name = "txtPack3";
            this.txtPack3.Size = new System.Drawing.Size(61, 22);
            this.txtPack3.TabIndex = 13;
            this.txtPack3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPack3.Click += new System.EventHandler(this.textBox_ItmNo_Click);
            this.txtPack3.Enter += new System.EventHandler(this.textBox_ItmNo_Enter);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(503, 111);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 13);
            this.label15.TabIndex = 884;
            this.label15.Text = "الوحدة 3 :";
            // 
            // txtUnit3
            // 
            this.txtUnit3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtUnit3.ForeColor = System.Drawing.Color.Red;
            this.txtUnit3.Location = new System.Drawing.Point(434, 107);
            this.txtUnit3.MaxLength = 2;
            this.txtUnit3.Name = "txtUnit3";
            this.txtUnit3.Size = new System.Drawing.Size(61, 22);
            this.txtUnit3.TabIndex = 12;
            this.txtUnit3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUnit3.Click += new System.EventHandler(this.textBox_ItmNo_Click);
            this.txtUnit3.Enter += new System.EventHandler(this.textBox_ItmNo_Enter);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(88, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 882;
            this.label8.Text = "رقم الباركود :";
            // 
            // txtBarcod2
            // 
            this.txtBarcod2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtBarcod2.ForeColor = System.Drawing.Color.Red;
            this.txtBarcod2.Location = new System.Drawing.Point(21, 80);
            this.txtBarcod2.MaxLength = 2;
            this.txtBarcod2.Name = "txtBarcod2";
            this.txtBarcod2.Size = new System.Drawing.Size(61, 22);
            this.txtBarcod2.TabIndex = 11;
            this.txtBarcod2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBarcod2.Click += new System.EventHandler(this.textBox_ItmNo_Click);
            this.txtBarcod2.Enter += new System.EventHandler(this.textBox_ItmNo_Enter);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(231, 84);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 880;
            this.label9.Text = "سعر البيع :";
            // 
            // txtPrice2
            // 
            this.txtPrice2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtPrice2.ForeColor = System.Drawing.Color.Red;
            this.txtPrice2.Location = new System.Drawing.Point(165, 80);
            this.txtPrice2.MaxLength = 2;
            this.txtPrice2.Name = "txtPrice2";
            this.txtPrice2.Size = new System.Drawing.Size(61, 22);
            this.txtPrice2.TabIndex = 10;
            this.txtPrice2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPrice2.Click += new System.EventHandler(this.textBox_ItmNo_Click);
            this.txtPrice2.Enter += new System.EventHandler(this.textBox_ItmNo_Enter);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(368, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 878;
            this.label10.Text = "التعبئة :";
            // 
            // txtPack2
            // 
            this.txtPack2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtPack2.ForeColor = System.Drawing.Color.Red;
            this.txtPack2.Location = new System.Drawing.Point(301, 80);
            this.txtPack2.MaxLength = 2;
            this.txtPack2.Name = "txtPack2";
            this.txtPack2.Size = new System.Drawing.Size(61, 22);
            this.txtPack2.TabIndex = 9;
            this.txtPack2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPack2.Click += new System.EventHandler(this.textBox_ItmNo_Click);
            this.txtPack2.Enter += new System.EventHandler(this.textBox_ItmNo_Enter);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(503, 84);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 876;
            this.label11.Text = "الوحدة 2 :";
            // 
            // txtUnit2
            // 
            this.txtUnit2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtUnit2.ForeColor = System.Drawing.Color.Red;
            this.txtUnit2.Location = new System.Drawing.Point(434, 80);
            this.txtUnit2.MaxLength = 2;
            this.txtUnit2.Name = "txtUnit2";
            this.txtUnit2.Size = new System.Drawing.Size(61, 22);
            this.txtUnit2.TabIndex = 8;
            this.txtUnit2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUnit2.Click += new System.EventHandler(this.textBox_ItmNo_Click);
            this.txtUnit2.Enter += new System.EventHandler(this.textBox_ItmNo_Enter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(86, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 874;
            this.label7.Text = "رقم الباركود :";
            // 
            // txtBarcod1
            // 
            this.txtBarcod1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtBarcod1.ForeColor = System.Drawing.Color.Red;
            this.txtBarcod1.Location = new System.Drawing.Point(21, 53);
            this.txtBarcod1.MaxLength = 2;
            this.txtBarcod1.Name = "txtBarcod1";
            this.txtBarcod1.Size = new System.Drawing.Size(61, 22);
            this.txtBarcod1.TabIndex = 7;
            this.txtBarcod1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBarcod1.Click += new System.EventHandler(this.textBox_ItmNo_Click);
            this.txtBarcod1.Enter += new System.EventHandler(this.textBox_ItmNo_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(229, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 872;
            this.label6.Text = "سعر البيع :";
            // 
            // txtPrice1
            // 
            this.txtPrice1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtPrice1.ForeColor = System.Drawing.Color.Red;
            this.txtPrice1.Location = new System.Drawing.Point(165, 53);
            this.txtPrice1.MaxLength = 2;
            this.txtPrice1.Name = "txtPrice1";
            this.txtPrice1.Size = new System.Drawing.Size(61, 22);
            this.txtPrice1.TabIndex = 6;
            this.txtPrice1.Text = "E";
            this.txtPrice1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPrice1.Click += new System.EventHandler(this.textBox_ItmNo_Click);
            this.txtPrice1.Enter += new System.EventHandler(this.textBox_ItmNo_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(366, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 870;
            this.label3.Text = "التعبئة :";
            // 
            // txtPack1
            // 
            this.txtPack1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtPack1.ForeColor = System.Drawing.Color.Red;
            this.txtPack1.Location = new System.Drawing.Point(301, 53);
            this.txtPack1.MaxLength = 2;
            this.txtPack1.Name = "txtPack1";
            this.txtPack1.Size = new System.Drawing.Size(61, 22);
            this.txtPack1.TabIndex = 5;
            this.txtPack1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPack1.Click += new System.EventHandler(this.textBox_ItmNo_Click);
            this.txtPack1.Enter += new System.EventHandler(this.textBox_ItmNo_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(501, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 868;
            this.label2.Text = "الوحدة 1 :";
            // 
            // txtUnit1
            // 
            this.txtUnit1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtUnit1.ForeColor = System.Drawing.Color.Red;
            this.txtUnit1.Location = new System.Drawing.Point(434, 53);
            this.txtUnit1.MaxLength = 2;
            this.txtUnit1.Name = "txtUnit1";
            this.txtUnit1.Size = new System.Drawing.Size(61, 22);
            this.txtUnit1.TabIndex = 4;
            this.txtUnit1.Text = "D";
            this.txtUnit1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUnit1.Click += new System.EventHandler(this.textBox_ItmNo_Click);
            this.txtUnit1.Enter += new System.EventHandler(this.textBox_ItmNo_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(501, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 866;
            this.label1.Text = "رقم الصنف";
            // 
            // textBox_ItmNo
            // 
            this.textBox_ItmNo.BackColor = System.Drawing.Color.Yellow;
            this.textBox_ItmNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBox_ItmNo.ForeColor = System.Drawing.Color.Red;
            this.textBox_ItmNo.Location = new System.Drawing.Point(434, 23);
            this.textBox_ItmNo.MaxLength = 2;
            this.textBox_ItmNo.Name = "textBox_ItmNo";
            this.textBox_ItmNo.Size = new System.Drawing.Size(61, 22);
            this.textBox_ItmNo.TabIndex = 0;
            this.textBox_ItmNo.Text = "A";
            this.textBox_ItmNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_ItmNo.Click += new System.EventHandler(this.textBox_ItmNo_Click);
            this.textBox_ItmNo.Enter += new System.EventHandler(this.textBox_ItmNo_Enter);
            // 
            // textBox_NameE
            // 
            this.textBox_NameE.BackColor = System.Drawing.Color.Yellow;
            this.textBox_NameE.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBox_NameE.ForeColor = System.Drawing.Color.Red;
            this.textBox_NameE.Location = new System.Drawing.Point(165, 23);
            this.textBox_NameE.MaxLength = 2;
            this.textBox_NameE.Name = "textBox_NameE";
            this.textBox_NameE.Size = new System.Drawing.Size(61, 22);
            this.textBox_NameE.TabIndex = 2;
            this.textBox_NameE.Text = "B";
            this.textBox_NameE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_NameE.Click += new System.EventHandler(this.textBox_ItmNo_Click);
            this.textBox_NameE.Enter += new System.EventHandler(this.textBox_ItmNo_Enter);
            // 
            // textBox_NameA
            // 
            this.textBox_NameA.BackColor = System.Drawing.Color.Yellow;
            this.textBox_NameA.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBox_NameA.ForeColor = System.Drawing.Color.Red;
            this.textBox_NameA.Location = new System.Drawing.Point(301, 23);
            this.textBox_NameA.MaxLength = 2;
            this.textBox_NameA.Name = "textBox_NameA";
            this.textBox_NameA.Size = new System.Drawing.Size(61, 22);
            this.textBox_NameA.TabIndex = 1;
            this.textBox_NameA.Text = "B";
            this.textBox_NameA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_NameA.Click += new System.EventHandler(this.textBox_ItmNo_Click);
            this.textBox_NameA.Enter += new System.EventHandler(this.textBox_ItmNo_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(229, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 106;
            this.label5.Text = "إسم انجليزي";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(366, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "إسم عربي";
            // 
            // ExcelGridView
            // 
            this.ExcelGridView.AllowUserToAddRows = false;
            this.ExcelGridView.AllowUserToDeleteRows = false;
            this.ExcelGridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.ExcelGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ExcelGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.ExcelGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ExcelGridView.DefaultCellStyle = dataGridViewCellStyle5;
            this.ExcelGridView.Location = new System.Drawing.Point(4, 301);
            this.ExcelGridView.MultiSelect = false;
            this.ExcelGridView.Name = "ExcelGridView";
            this.ExcelGridView.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ExcelGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.ExcelGridView.RowHeadersVisible = false;
            this.ExcelGridView.Size = new System.Drawing.Size(747, 200);
            this.ExcelGridView.TabIndex = 854;
            this.ExcelGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ExcelGridView_CellContentClick);
            this.ExcelGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ExcelGridView_CellContentDoubleClick);
            this.ExcelGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.ExcelGridView_CellEndEdit);
            this.ExcelGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ExcelGridView_ColumnHeaderMouseClick);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.Button_Cancel);
            this.panel4.Controls.Add(this.button_OK);
            this.panel4.Location = new System.Drawing.Point(4, 86);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(162, 185);
            this.panel4.TabIndex = 872;
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Button_Cancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Button_Cancel.Location = new System.Drawing.Point(5, 91);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(150, 89);
            this.Button_Cancel.TabIndex = 13;
            this.Button_Cancel.Text = "خـــروج";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            this.Button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // button_OK
            // 
            this.button_OK.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.button_OK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_OK.Location = new System.Drawing.Point(5, 2);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(150, 89);
            this.button_OK.TabIndex = 11;
            this.button_OK.Text = "موافق";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.CadetBlue;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(756, 18);
            this.panel5.TabIndex = 843;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(342, 244);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(210, 17);
            this.checkBox2.TabIndex = 921;
            this.checkBox2.Text = "تفعيل تاريخ الصلاحية لجميع الاصناف";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // FrmFingerPrintOp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(756, 506);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Icon = global::InvAcc.Properties.Resources.favicon;
            this.KeyPreview = true;
            this.Name = "FrmFingerPrintOp";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "استيراد بيانات الأصناف";
            this.Load += new System.EventHandler(this.FrmFingerPrintOp_Load);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmFingerPrintOp_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmFingerPrintOp_KeyPress);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExcelGridView)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		private bool IsInteger(string num)
		{
			bool flag;
#pragma warning disable CS0219 // The variable 'flag1' is assigned but its value is never used
			bool flag1 = false;
#pragma warning restore CS0219 // The variable 'flag1' is assigned but its value is never used
			try
			{
				double.Parse(num);
				flag = true;
				return flag;
			}
			catch
			{
				flag1 = false;
			}
			try
			{
				TimeSpan.Parse(num);
				flag = true;
				return flag;
			}
			catch
			{
				flag1 = false;
			}
			try
			{
				flag = ((this.n.IsGreg(num) ? false : !this.n.IsHijri(num)) ? false : true);
			}
			catch
			{
				flag = false;
			}
			return flag;
		}

		protected override void OnParentRightToLeftChanged(EventArgs e)
		{
			if ((VarGeneral.CurrentLang.ToString() == "0" ? true : VarGeneral.CurrentLang.ToString() == ""))
			{
				ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FrmFingerPrintOp));
				if (base.Parent.RightToLeft != System.Windows.Forms.RightToLeft.Yes)
				{
					Language.ChangeLanguage("en", this, componentResourceManager);
					this.LangArEn = 1;
				}
				else
				{
					Language.ChangeLanguage("ar-SA", this, componentResourceManager);
					this.LangArEn = 0;
				}
			}
			this.FillGrid();
		}

		private void releaseObject(object obj)
		{
			try
			{
				try
				{
					Marshal.ReleaseComObject(obj);
					obj = null;
				}
				catch (Exception exception1)
				{
					Exception exception = exception1;
					obj = null;
					MessageBox.Show(string.Concat("Unable to release the Object ", exception.ToString()));
				}
			}
			finally
			{
				GC.Collect();
			}
		}

		private void SetColumns()
		{
			this.ColumnsFinger.Clear();
			this.ColumnsFinger.Add("A");
			this.ColumnsFinger.Add("B");
			this.ColumnsFinger.Add("C");
			this.ColumnsFinger.Add("D");
			this.ColumnsFinger.Add("E");
			this.ColumnsFinger.Add("F");
			this.ColumnsFinger.Add("G");
			this.ColumnsFinger.Add("H");
			this.ColumnsFinger.Add("I");
			this.ColumnsFinger.Add("J");
			this.ColumnsFinger.Add("K");
			this.ColumnsFinger.Add("L");
			this.ColumnsFinger.Add("M");
			this.ColumnsFinger.Add("N");
			this.ColumnsFinger.Add("O");
			this.ColumnsFinger.Add("P");
			this.ColumnsFinger.Add("Q");
			this.ColumnsFinger.Add("S");
			this.ColumnsFinger.Add("T");
			this.ColumnsFinger.Add("U");
			this.ColumnsFinger.Add("V");
			this.ColumnsFinger.Add("W");
			this.ColumnsFinger.Add("Y");
			this.ColumnsFinger.Add("Z");
			this.ColumnsFinger.Add("AA");
			this.ColumnsFinger.Add("AB");
			this.ColumnsFinger.Add("AC");
			this.ColumnsFinger.Add("AD");
			this.ColumnsFinger.Add("AE");
			this.ColumnsFinger.Add("AF");
			this.ColumnsFinger.Add("AG");
			this.ColumnsFinger.Add("AH");
			this.ColumnsFinger.Add("AI");
			this.ColumnsFinger.Add("AJ");
			this.ColumnsFinger.Add("AK");
			this.ColumnsFinger.Add("AL");
			this.ColumnsFinger.Add("AM");
			this.ColumnsFinger.Add("AN");
			this.ColumnsFinger.Add("AO");
			this.ColumnsFinger.Add("AP");
			this.ColumnsFinger.Add("AQ");
			this.ColumnsFinger.Add("AS");
			this.ColumnsFinger.Add("AT");
			this.ColumnsFinger.Add("AU");
			this.ColumnsFinger.Add("AV");
			this.ColumnsFinger.Add("AW");
			this.ColumnsFinger.Add("AY");
			this.ColumnsFinger.Add("AZ");
			this.ColumnsFinger.Add("BA");
			this.ColumnsFinger.Add("BB");
			this.ColumnsFinger.Add("BC");
			this.ColumnsFinger.Add("BD");
			this.ColumnsFinger.Add("BE");
			this.ColumnsFinger.Add("BF");
			this.ColumnsFinger.Add("BG");
			this.ColumnsFinger.Add("BH");
			this.ColumnsFinger.Add("BI");
			this.ColumnsFinger.Add("BJ");
			this.ColumnsFinger.Add("BK");
			this.ColumnsFinger.Add("BL");
			this.ColumnsFinger.Add("BM");
			this.ColumnsFinger.Add("BN");
			this.ColumnsFinger.Add("BO");
			this.ColumnsFinger.Add("BP");
			this.ColumnsFinger.Add("BQ");
			this.ColumnsFinger.Add("BS");
			this.ColumnsFinger.Add("BT");
			this.ColumnsFinger.Add("BU");
			this.ColumnsFinger.Add("BV");
			this.ColumnsFinger.Add("BW");
			this.ColumnsFinger.Add("BY");
			this.ColumnsFinger.Add("BZ");
			this.ColumnsFinger.Add("CA");
			this.ColumnsFinger.Add("CB");
			this.ColumnsFinger.Add("CC");
			this.ColumnsFinger.Add("CD");
			this.ColumnsFinger.Add("CE");
			this.ColumnsFinger.Add("CF");
			this.ColumnsFinger.Add("CG");
			this.ColumnsFinger.Add("CH");
			this.ColumnsFinger.Add("CI");
			this.ColumnsFinger.Add("CJ");
			this.ColumnsFinger.Add("CK");
			this.ColumnsFinger.Add("CL");
			this.ColumnsFinger.Add("CM");
			this.ColumnsFinger.Add("CN");
			this.ColumnsFinger.Add("CO");
			this.ColumnsFinger.Add("CP");
			this.ColumnsFinger.Add("CQ");
			this.ColumnsFinger.Add("CS");
			this.ColumnsFinger.Add("CT");
			this.ColumnsFinger.Add("CU");
			this.ColumnsFinger.Add("CV");
			this.ColumnsFinger.Add("CW");
			this.ColumnsFinger.Add("CY");
			this.ColumnsFinger.Add("CZ");
			this.ColumnsFinger.Add("DA");
			this.ColumnsFinger.Add("DB");
			this.ColumnsFinger.Add("DC");
			this.ColumnsFinger.Add("DE");
			this.ColumnsFinger.Add("DD");
			this.ColumnsFinger.Add("DF");
			this.ColumnsFinger.Add("DG");
			this.ColumnsFinger.Add("DH");
			this.ColumnsFinger.Add("DI");
			this.ColumnsFinger.Add("DJ");
			this.ColumnsFinger.Add("DK");
			this.ColumnsFinger.Add("DL");
			this.ColumnsFinger.Add("DM");
			this.ColumnsFinger.Add("DN");
			this.ColumnsFinger.Add("DO");
			this.ColumnsFinger.Add("DP");
			this.ColumnsFinger.Add("DQ");
			this.ColumnsFinger.Add("DS");
			this.ColumnsFinger.Add("DT");
			this.ColumnsFinger.Add("DU");
			this.ColumnsFinger.Add("DV");
			this.ColumnsFinger.Add("DW");
			this.ColumnsFinger.Add("DY");
			this.ColumnsFinger.Add("DZ");
			this.ColumnsFinger.Add("EA");
			this.ColumnsFinger.Add("EB");
			this.ColumnsFinger.Add("EC");
			this.ColumnsFinger.Add("ED");
			this.ColumnsFinger.Add("EE");
			this.ColumnsFinger.Add("EF");
			this.ColumnsFinger.Add("EG");
			this.ColumnsFinger.Add("EH");
			this.ColumnsFinger.Add("EI");
			this.ColumnsFinger.Add("EJ");
			this.ColumnsFinger.Add("EK");
			this.ColumnsFinger.Add("EL");
			this.ColumnsFinger.Add("EM");
			this.ColumnsFinger.Add("EN");
			this.ColumnsFinger.Add("EO");
			this.ColumnsFinger.Add("EP");
			this.ColumnsFinger.Add("EQ");
			this.ColumnsFinger.Add("ES");
			this.ColumnsFinger.Add("ET");
			this.ColumnsFinger.Add("EU");
			this.ColumnsFinger.Add("EV");
			this.ColumnsFinger.Add("EW");
			this.ColumnsFinger.Add("EY");
			this.ColumnsFinger.Add("EZ");
			this.ColumnsFinger.Add("FA");
			this.ColumnsFinger.Add("FB");
			this.ColumnsFinger.Add("FC");
			this.ColumnsFinger.Add("FD");
			this.ColumnsFinger.Add("FE");
			this.ColumnsFinger.Add("FF");
			this.ColumnsFinger.Add("FG");
			this.ColumnsFinger.Add("FH");
			this.ColumnsFinger.Add("FI");
			this.ColumnsFinger.Add("FJ");
			this.ColumnsFinger.Add("FK");
			this.ColumnsFinger.Add("FL");
			this.ColumnsFinger.Add("FM");
			this.ColumnsFinger.Add("FN");
			this.ColumnsFinger.Add("FO");
			this.ColumnsFinger.Add("FP");
			this.ColumnsFinger.Add("FQ");
			this.ColumnsFinger.Add("FS");
			this.ColumnsFinger.Add("FT");
			this.ColumnsFinger.Add("FU");
			this.ColumnsFinger.Add("FV");
			this.ColumnsFinger.Add("FW");
			this.ColumnsFinger.Add("FY");
			this.ColumnsFinger.Add("FZ");
			this.ColumnsFinger.Add("GA");
			this.ColumnsFinger.Add("GB");
			this.ColumnsFinger.Add("GC");
			this.ColumnsFinger.Add("GD");
			this.ColumnsFinger.Add("GE");
			this.ColumnsFinger.Add("GF");
			this.ColumnsFinger.Add("GG");
			this.ColumnsFinger.Add("GH");
			this.ColumnsFinger.Add("GI");
			this.ColumnsFinger.Add("GJ");
			this.ColumnsFinger.Add("GK");
			this.ColumnsFinger.Add("GL");
			this.ColumnsFinger.Add("GM");
			this.ColumnsFinger.Add("GN");
			this.ColumnsFinger.Add("GO");
			this.ColumnsFinger.Add("GP");
			this.ColumnsFinger.Add("GQ");
			this.ColumnsFinger.Add("GS");
			this.ColumnsFinger.Add("GT");
			this.ColumnsFinger.Add("GU");
			this.ColumnsFinger.Add("GV");
			this.ColumnsFinger.Add("GW");
			this.ColumnsFinger.Add("GY");
			this.ColumnsFinger.Add("GZ");
		}

		public void SplashStart()
		{
			System.Windows.Forms.Application.Run(new FrmImports());
		}

		private void textBox_EmpNo_Click(object sender, EventArgs e)
		{
			this.textBox_ItmNo.SelectAll();
		}

		private void textBox_Time1_Click(object sender, EventArgs e)
		{
			this.textBox_NameA.SelectAll();
		}

		private void textBox_TimeLeave1_Click(object sender, EventArgs e)
		{
			this.textBox_NameE.SelectAll();
		}

        private void ExcelGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
			

		}
	System.Windows.Forms.TextBox Activcontrol = null;
        private void textBox_ItmNo_Click(object sender, EventArgs e)
        {
			Activcontrol = (sender as System.Windows.Forms.TextBox);


		}

        private void ExcelGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
			
		}

        private void textBox_ItmNo_Enter(object sender, EventArgs e)
        {
			Activcontrol = (sender as System.Windows.Forms.TextBox);

		}
	}
}