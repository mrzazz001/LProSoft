using DevComponents.DotNetBar;
using DevComponents.Editors.DateTimeAdv;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Microsoft.Win32;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmBackupElectDate : Form
    {
        private IContainer components = null;
        private RibbonBar ribbonBar1;
        private Panel panel1;
        private Label label1;
        private DateTimeInput dateTimeInput_DT;
        private LabelX labelX1;
        private ButtonX buttonX_Close;
        private ButtonX buttonX_Ok;
        private DateTimeInput dateTimeInput_DTEnd;
        private int vTyp = 0;
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private Stock_DataDataContext dbInstance;
        private List<T_SYSSETTING> listSysSetting = new List<T_SYSSETTING>();
        private T_SYSSETTING _SysSetting = new T_SYSSETTING();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBackupElectDate));
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimeInput_DTEnd = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimeInput_DT = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.buttonX_Close = new DevComponents.DotNetBar.ButtonX();
            this.buttonX_Ok = new DevComponents.DotNetBar.ButtonX();
            this.ribbonBar1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput_DTEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput_DT)).BeginInit();
            this.SuspendLayout();
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
            this.ribbonBar1.Controls.Add(this.panel1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(504, 223);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 870;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.BackColor = System.Drawing.Color.Black;
            this.ribbonBar1.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dateTimeInput_DTEnd);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dateTimeInput_DT);
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Controls.Add(this.buttonX_Close);
            this.panel1.Controls.Add(this.buttonX_Ok);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(507, 208);
            this.panel1.TabIndex = 858;
            // 
            // dateTimeInput_DTEnd
            // 
            // 
            // 
            // 
            this.dateTimeInput_DTEnd.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateTimeInput_DTEnd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput_DTEnd.ButtonClear.Checked = true;
            this.dateTimeInput_DTEnd.ButtonCustom.Text = "?????????? ??????????????";
            this.dateTimeInput_DTEnd.ButtonCustom.Visible = true;
            this.dateTimeInput_DTEnd.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateTimeInput_DTEnd.CustomFormat = "yyyy/MM/dd";
            this.dateTimeInput_DTEnd.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dateTimeInput_DTEnd.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dateTimeInput_DTEnd.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.dateTimeInput_DTEnd.IsPopupCalendarOpen = false;
            this.dateTimeInput_DTEnd.Location = new System.Drawing.Point(115, 120);
            // 
            // 
            // 
            this.dateTimeInput_DTEnd.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTimeInput_DTEnd.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput_DTEnd.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dateTimeInput_DTEnd.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateTimeInput_DTEnd.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateTimeInput_DTEnd.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput_DTEnd.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateTimeInput_DTEnd.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateTimeInput_DTEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateTimeInput_DTEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateTimeInput_DTEnd.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput_DTEnd.MonthCalendar.DisplayMonth = new System.DateTime(2015, 9, 1, 0, 0, 0, 0);
            this.dateTimeInput_DTEnd.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Saturday;
            this.dateTimeInput_DTEnd.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dateTimeInput_DTEnd.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTimeInput_DTEnd.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateTimeInput_DTEnd.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput_DTEnd.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateTimeInput_DTEnd.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput_DTEnd.MonthCalendar.TodayButtonVisible = true;
            this.dateTimeInput_DTEnd.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dateTimeInput_DTEnd.Name = "dateTimeInput_DTEnd";
            this.dateTimeInput_DTEnd.ShowUpDown = true;
            this.dateTimeInput_DTEnd.Size = new System.Drawing.Size(260, 24);
            this.dateTimeInput_DTEnd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTimeInput_DTEnd.TabIndex = 91;
            this.dateTimeInput_DTEnd.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            this.dateTimeInput_DTEnd.Click += new System.EventHandler(this.dateTimeInput_DTEnd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(72, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(345, 13);
            this.label1.TabIndex = 90;
            this.label1.Text = "???????? ?????????? ?????????? ?????????? ?????????? ?? ?????????? ?????????????????? ???????????????????? ,\"";
            // 
            // dateTimeInput_DT
            // 
            // 
            // 
            // 
            this.dateTimeInput_DT.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateTimeInput_DT.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput_DT.ButtonClear.Checked = true;
            this.dateTimeInput_DT.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateTimeInput_DT.ButtonDropDown.Visible = true;
            this.dateTimeInput_DT.CustomFormat = "yyyy/MM/dd";
            this.dateTimeInput_DT.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dateTimeInput_DT.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dateTimeInput_DT.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.dateTimeInput_DT.IsPopupCalendarOpen = false;
            this.dateTimeInput_DT.Location = new System.Drawing.Point(115, 90);
            // 
            // 
            // 
            this.dateTimeInput_DT.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTimeInput_DT.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput_DT.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dateTimeInput_DT.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateTimeInput_DT.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateTimeInput_DT.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput_DT.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateTimeInput_DT.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateTimeInput_DT.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateTimeInput_DT.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateTimeInput_DT.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput_DT.MonthCalendar.DisplayMonth = new System.DateTime(2015, 9, 1, 0, 0, 0, 0);
            this.dateTimeInput_DT.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Saturday;
            this.dateTimeInput_DT.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dateTimeInput_DT.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTimeInput_DT.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateTimeInput_DT.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput_DT.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateTimeInput_DT.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput_DT.MonthCalendar.TodayButtonVisible = true;
            this.dateTimeInput_DT.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dateTimeInput_DT.Name = "dateTimeInput_DT";
            this.dateTimeInput_DT.ShowUpDown = true;
            this.dateTimeInput_DT.Size = new System.Drawing.Size(260, 24);
            this.dateTimeInput_DT.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTimeInput_DT.TabIndex = 89;
            this.dateTimeInput_DT.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            this.dateTimeInput_DT.WatermarkText = "?????????? ?????????? ?????????????? - ???????? ??????";
            this.dateTimeInput_DT.TextChanged += new System.EventHandler(this.dateTimeInput_DT_TextChanged);
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.DimGray;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX1.Font = new System.Drawing.Font("Tahoma", 8F, ((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)));
            this.labelX1.ForeColor = System.Drawing.Color.White;
            this.labelX1.Location = new System.Drawing.Point(0, 0);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(505, 26);
            this.labelX1.TabIndex = 88;
            this.labelX1.Text = "?????????? ?????????? ?????????? ?? ?????????? ?????????????????? ????????????????????";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelX1.Click += new System.EventHandler(this.labelX1_Click);
            // 
            // buttonX_Close
            // 
            this.buttonX_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_Close.Checked = true;
            this.buttonX_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_Close.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buttonX_Close.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.buttonX_Close.Location = new System.Drawing.Point(115, 151);
            this.buttonX_Close.Name = "buttonX_Close";
            this.buttonX_Close.Size = new System.Drawing.Size(129, 38);
            this.buttonX_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_Close.Symbol = "???";
            this.buttonX_Close.TabIndex = 3;
            this.buttonX_Close.Text = "??????????";
            this.buttonX_Close.TextColor = System.Drawing.Color.Black;
            this.buttonX_Close.Click += new System.EventHandler(this.buttonX_Close_Click);
            // 
            // buttonX_Ok
            // 
            this.buttonX_Ok.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_Ok.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX_Ok.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buttonX_Ok.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.buttonX_Ok.Location = new System.Drawing.Point(246, 151);
            this.buttonX_Ok.Name = "buttonX_Ok";
            this.buttonX_Ok.Size = new System.Drawing.Size(129, 38);
            this.buttonX_Ok.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_Ok.Symbol = "???";
            this.buttonX_Ok.TabIndex = 2;
            this.buttonX_Ok.Text = "??????????????????";
            this.buttonX_Ok.TextColor = System.Drawing.Color.White;
            this.buttonX_Ok.Click += new System.EventHandler(this.buttonX_Ok_Click);
            // 
            // FrmBackupElectDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(504, 223);
            this.ControlBox = false;
            this.Controls.Add(this.ribbonBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = (InvAcc.Properties.Resources.favicon);
            this.KeyPreview = true;
            this.Name = "FrmBackupElectDate";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmBackupElectDate_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmBackupElectDate_KeyDown);
            this.ribbonBar1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput_DTEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput_DT)).EndInit();
            this.Icon = (InvAcc.Properties.Resources.favicon);
            this.ResumeLayout(false);
        }
        public FrmBackupElectDate(int typ)
        {
            InitializeComponent();
            vTyp = typ;
        }
        private void FrmBackupElectDate_Load(object sender, EventArgs e)
        {
            CultureInfo sa = new CultureInfo("en-US", useUserOverride: false);
            sa.DateTimeFormat.Calendar = new GregorianCalendar();
            Thread.CurrentThread.CurrentCulture = sa;
            Thread.CurrentThread.CurrentUICulture = sa;
            if (vTyp == 1)
            {
                labelX1.Text = "?????????? ?????????? ??????????????";
                label1.Text = "???????? ?????????? ?????????? ?????????????? ???????????? ,???????? ?????????? ?????????? ?????????????? ???????????? ??????????????";
                dateTimeInput_DT.WatermarkText = "???????????? ?????????? ?????????? ?????????? ?????????????? - ???????? ??????";
                dateTimeInput_DTEnd.WatermarkText = "???????????? ?????????? ?????????? ?????????? ?????????????? - ???????? ??????";
                dateTimeInput_DTEnd.Visible = true;
                _SysSetting = db.SystemSettingStock();
                if (VarGeneral.CheckDate(_SysSetting.AccSupDes.Trim()))
                {
                    dateTimeInput_DT.Text = Convert.ToDateTime(_SysSetting.AccSupDes.Trim()).ToString("yyyy/MM/dd");
                }
                if (VarGeneral.CheckDate(_SysSetting.AccCusDes.Trim()))
                {
                    dateTimeInput_DTEnd.Text = Convert.ToDateTime(_SysSetting.AccCusDes.Trim()).ToString("yyyy/MM/dd");
                }
                return;
            }
            RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\MrdSoft\\Register", writable: true);
            string regval = string.Empty;
            string DT_H = string.Empty;
            try
            {
                regval = n.FormatGreg(hKey.GetValue("DTBackup").ToString(), "yyyy/MM/dd");
                DT_H = n.GregToHijri(regval);
            }
            catch
            {
                regval = string.Empty;
                DT_H = string.Empty;
            }
            if (VarGeneral.CheckDate(regval))
            {
                dateTimeInput_DTEnd.Text = regval;
                dateTimeInput_DT.Text = Convert.ToDateTime(dateTimeInput_DTEnd.Text).AddYears(-1).ToString("yyyy/MM/dd");
            }
            else
            {
                dateTimeInput_DTEnd.Text = string.Empty;
                dateTimeInput_DT.Text = string.Empty;
            }
            RegistryKey hKeyElec = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", writable: true);
            try
            {
                object q = hKeyElec.GetValue("vBackupELEC");
                if (string.IsNullOrEmpty(q.ToString()))
                {
                    hKeyElec.CreateSubKey("vBackupELEC");
                    hKeyElec.SetValue("vBackupELEC", "0");
                }
            }
            catch
            {
                hKeyElec.CreateSubKey("vBackupELEC");
                hKeyElec.SetValue("vBackupELEC", "0");
            }
            RegistryKey hKeyNew = Registry.CurrentUser.OpenSubKey("Software\\MrdHrdw\\ItIntel", writable: true);
            try
            {
                object q = hKeyNew.GetValue("vBackup_New");
                if (string.IsNullOrEmpty(q.ToString()))
                {
                    hKeyNew.CreateSubKey("vBackup_New");
                    hKeyNew.SetValue("vBackup_New", "0");
                }
            }
            catch
            {
                hKeyNew.CreateSubKey("vBackup_New");
                hKeyNew.SetValue("vBackup_New", "0");
            }
        }
        private void buttonX_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void buttonX_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                string vDT = string.Empty;
                string vDTEnd = string.Empty;
                if (vTyp == 0)
                {
                    if (VarGeneral.CheckDate(dateTimeInput_DTEnd.Text))
                    {
                        vDT = Convert.ToDateTime(dateTimeInput_DTEnd.Text).ToString("yyyy/MM/dd");
                    }
                    RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\MrdSoft\\Register", writable: true);
                    hKey.SetValue("DTBackup", vDT);
                    RegistryKey hKeyElec = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", writable: true);
                    hKeyElec.SetValue("vBackupELEC", vDT);
                    RegistryKey hKeyNew = Registry.CurrentUser.OpenSubKey("Software\\MrdHrdw\\ItIntel", writable: true);
                    hKeyNew.SetValue("vBackup_New", vDT);
                    try
                    {
                        hKeyNew.DeleteSubKey("TurnOff");
                        hKeyNew.DeleteValue("TurnOff");
                    }
                    catch
                    {
                    }
                    try
                    {
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        File.Delete(Application.StartupPath + "\\flxgridD.txt");
                    }
                    catch
                    {
                    }
                    MessageBox.Show("?????????????? .. ?????? ???? ?????????? ???????????????????? ?????????? .. \n ?????????? ???????? ?????????? ???????????? ?????????? ???? ???? ???????? ?????????? ????????????", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Close();
                }
                else
                {
                    if (VarGeneral.CheckDate(dateTimeInput_DT.Text))
                    {
                        vDT = Convert.ToDateTime(dateTimeInput_DT.Text).ToString("yyyy/MM/dd");
                    }
                    if (VarGeneral.CheckDate(dateTimeInput_DTEnd.Text))
                    {
                        vDTEnd = Convert.ToDateTime(dateTimeInput_DTEnd.Text).ToString("yyyy/MM/dd");
                    }
                    if (!VarGeneral.CheckDate(vDTEnd))
                    {
                        vDT = string.Empty;
                    }
                    if (!VarGeneral.CheckDate(vDT))
                    {
                        vDTEnd = string.Empty;
                    }
                    _SysSetting.AccCusDes = vDTEnd;
                    _SysSetting.AccSupDes = vDT;
                    db.Log = VarGeneral.DebugLog;
                    db.SubmitChanges(ConflictMode.ContinueOnConflict);
                    MessageBox.Show(".. ?????? ???? ?????????? ?????????? ?????????????? ??????????", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Close();
                }
            }
            catch
            {
                MessageBox.Show("?????? ?????? ???????????? ?????????? ?????? ???????? ,???????? ???? ?????? ?????????????? ???? ???????? ????????????", VarGeneral.ProdectNam, MessageBoxButtons.OK);
            }
        }
        private void FrmBackupElectDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && buttonX_Ok.Enabled && buttonX_Ok.Visible)
            {
                buttonX_Ok_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void labelX1_Click(object sender, EventArgs e)
        {
        }
        private void dateTimeInput_DT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string vDT = string.Empty;
                if (VarGeneral.CheckDate(dateTimeInput_DT.Text))
                {
                    if (VarGeneral.CheckDate(dateTimeInput_DT.Text))
                    {
                        vDT = Convert.ToDateTime(dateTimeInput_DT.Text).ToString("yyyy/MM/dd");
                        dateTimeInput_DTEnd.Text = Convert.ToDateTime(vDT).AddYears(1).ToString("yyyy/MM/dd");
                    }
                }
                else
                {
                    dateTimeInput_DTEnd.Text = string.Empty;
                }
            }
            catch
            {
                dateTimeInput_DTEnd.Text = string.Empty;
            }
        }
        private void dateTimeInput_DTEnd_Click(object sender, EventArgs e)
        {

        }
    }
}
