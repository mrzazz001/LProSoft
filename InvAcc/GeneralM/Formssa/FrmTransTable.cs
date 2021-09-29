using DevComponents.DotNetBar;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using SSSDateTime.Date;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmTransTable : Form
    {
        private IContainer components = null;
        private ExpandablePanel expandablePanel_TablesMove;
        private ComboBox comboBox_ToTable;
        private ComboBox combobox_FromTable;
        private ButtonX ButExit;
        private ButtonX Button_Move;
        private Label label3;
        private Label label1;
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private int LangArEn = 0;
        private Stock_DataDataContext dbInstance;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmTransTable));
            expandablePanel_TablesMove = new DevComponents.DotNetBar.ExpandablePanel();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            Button_Move = new DevComponents.DotNetBar.ButtonX();
            ButExit = new DevComponents.DotNetBar.ButtonX();
            comboBox_ToTable = new System.Windows.Forms.ComboBox();
            combobox_FromTable = new System.Windows.Forms.ComboBox();
            expandablePanel_TablesMove.SuspendLayout();
            SuspendLayout();
            expandablePanel_TablesMove.CanvasColor = System.Drawing.SystemColors.GradientActiveCaption;
            expandablePanel_TablesMove.Controls.Add(label1);
            expandablePanel_TablesMove.Controls.Add(label3);
            expandablePanel_TablesMove.Controls.Add(Button_Move);
            expandablePanel_TablesMove.Controls.Add(ButExit);
            expandablePanel_TablesMove.Controls.Add(comboBox_ToTable);
            expandablePanel_TablesMove.Controls.Add(combobox_FromTable);
            resources.ApplyResources(expandablePanel_TablesMove, "expandablePanel_TablesMove");
            expandablePanel_TablesMove.ExpandButtonVisible = false;
            expandablePanel_TablesMove.Name = "expandablePanel_TablesMove";
            expandablePanel_TablesMove.Style.Alignment = System.Drawing.StringAlignment.Center;
            expandablePanel_TablesMove.Style.BackColor1.Color = System.Drawing.Color.AliceBlue;
            expandablePanel_TablesMove.Style.BackColor2.Color = System.Drawing.SystemColors.GradientActiveCaption;
            expandablePanel_TablesMove.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile;
            expandablePanel_TablesMove.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            expandablePanel_TablesMove.Style.GradientAngle = 90;
            expandablePanel_TablesMove.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            expandablePanel_TablesMove.TitleStyle.BackColor1.Color = System.Drawing.Color.FromArgb(255, 128, 0);
            expandablePanel_TablesMove.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            expandablePanel_TablesMove.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            expandablePanel_TablesMove.TitleStyle.ForeColor.Color = System.Drawing.Color.White;
            expandablePanel_TablesMove.TitleStyle.GradientAngle = 90;
            label1.BackColor = System.Drawing.Color.White;
            label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            label3.BackColor = System.Drawing.Color.White;
            label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            Button_Move.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            Button_Move.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            resources.ApplyResources(Button_Move, "Button_Move");
            Button_Move.Name = "Button_Move";
            Button_Move.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            Button_Move.Symbol = "\uf00c";
            Button_Move.SymbolSize = 16f;
            Button_Move.TextColor = System.Drawing.Color.White;
            Button_Move.Click += new System.EventHandler(Button_Move_Click);
            ButExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            ButExit.Checked = true;
            ButExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(ButExit, "ButExit");
            ButExit.Name = "ButExit";
            ButExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButExit.Symbol = "\uf011";
            ButExit.SymbolSize = 16f;
            ButExit.TextColor = System.Drawing.Color.Black;
            ButExit.Click += new System.EventHandler(ButExit_Click);
            comboBox_ToTable.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            comboBox_ToTable.BackColor = System.Drawing.Color.Gainsboro;
            comboBox_ToTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(comboBox_ToTable, "comboBox_ToTable");
            comboBox_ToTable.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            comboBox_ToTable.FormattingEnabled = true;
            comboBox_ToTable.Name = "comboBox_ToTable";
            combobox_FromTable.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            combobox_FromTable.BackColor = System.Drawing.Color.Gainsboro;
            combobox_FromTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(combobox_FromTable, "combobox_FromTable");
            combobox_FromTable.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            combobox_FromTable.FormattingEnabled = true;
            combobox_FromTable.Name = "combobox_FromTable";
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            base.Controls.Add(expandablePanel_TablesMove);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            base.KeyPreview = true;
            base.Name = "FrmTransTable";
            base.Load += new System.EventHandler(FrmTransTable_Load);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(FrmTransTable_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(FrmTransTable_KeyDown);
            expandablePanel_TablesMove.ResumeLayout(false);
            ResumeLayout(false);
        }
        public FrmTransTable()
        {
            InitializeComponent();
        }
        private void ButExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void FrmTransTable_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmTransTable));
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    Language.ChangeLanguage("ar-SA", this, resources);
                    LangArEn = 0;
                }
                else
                {
                    Language.ChangeLanguage("en", this, resources);
                    LangArEn = 1;
                    expandablePanel_TablesMove.TitleText = "Transfer Orders Between Tables";
                    Button_Move.Text = "OK";
                    ButExit.Text = "Exit";
                }
                FillCombo();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void FillCombo()
        {
            combobox_FromTable.Items.Clear();
            comboBox_ToTable.Items.Clear();
            combobox_FromTable.Items.Add(string.Empty);
            comboBox_ToTable.Items.Add(string.Empty);
            List<T_INVHED> q = (from t in db.T_INVHEDs
                                orderby t.T_Room.Type
                                orderby t.RoomNo
                                where t.RoomSts.Value
                                where t.T_Room.RomeStatus.Value
                                where t.RoomNo.Value > 0
                                select t).ToList();
            for (int i = 0; i < q.Count; i++)
            {
                combobox_FromTable.Items.Add((LangArEn == 0) ? (" [ " + ((q[i].T_Room.Type.Value == 1) ? "طاولات عوائـــل" : ((q[i].T_Room.Type.Value == 2) ? "طاولات الشباب" : ((q[i].T_Room.Type.Value == 3) ? "طاولات خارجية" : "طاولات آخـــرى"))) + " ]  طاولة رقم = " + q[i].T_Room.RomeNo) : (" [ " + ((q[i].T_Room.Type.Value == 1) ? "Family Table" : ((q[i].T_Room.Type.Value == 2) ? "Boys Table" : ((q[i].T_Room.Type.Value == 3) ? "Extrnal Table" : "Other Table"))) + " ]  Table No =" + q[i].T_Room.RomeNo));
            }
            List<T_Room> vTable = (from t in db.T_Rooms
                                   orderby t.RomeNo
                                   orderby t.Type
                                   where !t.RomeStatus.Value
                                   where t.RomeNo != 0
                                   select t).ToList();
            for (int i = 0; i < vTable.Count; i++)
            {
                comboBox_ToTable.Items.Add((LangArEn == 0) ? (" [ " + ((vTable[i].Type.Value == 1) ? "طاولات عوائـــل" : ((vTable[i].Type.Value == 2) ? "طاولات الشباب" : ((vTable[i].Type.Value == 3) ? "طاولات خارجية" : "طاولات آخـــرى"))) + " ]  طاولة رقم = " + vTable[i].RomeNo) : (" [ " + ((vTable[i].Type.Value == 1) ? "Family Table" : ((vTable[i].Type.Value == 2) ? "Boys Table" : ((vTable[i].Type.Value == 3) ? "Extrnal Table" : "Other Table"))) + " ]  Table No =" + vTable[i].RomeNo));
            }
            comboBox_ToTable.SelectedIndex = 0;
            combobox_FromTable.SelectedIndex = 0;
        }
        private void FrmTransTable_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void FrmTransTable_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void Button_Move_Click(object sender, EventArgs e)
        {
            try
            {
                if (combobox_FromTable.SelectedIndex <= 0 || comboBox_ToTable.SelectedIndex <= 0)
                {
                    return;
                }
                int vLen1 = 0;
                int vLen2 = 0;
                for (vLen1 = 0; vLen1 < combobox_FromTable.Text.Length && !(combobox_FromTable.Text.Substring(0, vLen1) == "="); vLen1++)
                {
                }
                for (vLen2 = 0; vLen2 < comboBox_ToTable.Text.Length && !(comboBox_ToTable.Text.Substring(0, vLen2) == "="); vLen2++)
                {
                }
                int From_typ = 0;
                int To_typ = 0;
                if (combobox_FromTable.Text.Contains("عوائـــل") || combobox_FromTable.Text.Contains("Family"))
                {
                    From_typ = 1;
                }
                else if (combobox_FromTable.Text.Contains("الشباب") || combobox_FromTable.Text.Contains("Boys"))
                {
                    From_typ = 2;
                }
                else if (combobox_FromTable.Text.Contains("خارجية") || combobox_FromTable.Text.Contains("Extrnal"))
                {
                    From_typ = 3;
                }
                else
                {
                    From_typ = 4;
                }
                if (comboBox_ToTable.Text.Contains("عوائـــل") || comboBox_ToTable.Text.Contains("Family"))
                {
                    To_typ = 1;
                }
                else if (comboBox_ToTable.Text.Contains("الشباب") || comboBox_ToTable.Text.Contains("Boys"))
                {
                    To_typ = 2;
                }
                else if (comboBox_ToTable.Text.Contains("خارجية") || comboBox_ToTable.Text.Contains("Extrnal"))
                {
                    To_typ = 3;
                }
                else
                {
                    To_typ = 4;
                }
                int RoomID_From = 0;
                int RoomID_To = 0;
                List<T_Room> RoomTo = (from t in db.T_Rooms
                                       where t.RomeNo == int.Parse(comboBox_ToTable.Text.Substring(vLen2 - 1))
                                       where t.Type == (int?)To_typ
                                       select t).ToList();
                if (RoomTo.Count > 0)
                {
                    RoomID_To = RoomTo.FirstOrDefault().ID;
                }
                List<T_Room> RoomFrom = (from t in db.T_Rooms
                                         where t.RomeNo == int.Parse(combobox_FromTable.Text.Substring(vLen1 - 1))
                                         where t.Type == (int?)From_typ
                                         select t).ToList();
                if (RoomFrom.Count > 0)
                {
                    RoomID_From = RoomFrom.FirstOrDefault().ID;
                }
                if (RoomID_From == 0 || RoomID_To == 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "لم يتم العملية بنجاح" : "Operation not successful", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                int WaiterNo_ = 0;
                try
                {
                    WaiterNo_ = db.T_Rooms.Where((T_Room t) => t.RomeStatus.Value && t.ID == RoomID_From).ToList().FirstOrDefault()
                        .waiterNo.Value;
                }
                catch
                {
                    WaiterNo_ = 0;
                }
                db.ExecuteCommand("UPDATE T_INVHED SET RoomNo =" + RoomID_To + " where T_INVHED.RoomSts = 1 and RoomNo =" + RoomID_From);
                db.ExecuteCommand("UPDATE [T_Rooms] SET [RomeStatus] = 0, [waiterNo] = NULL where ID =" + RoomID_From);
                db.ExecuteCommand("UPDATE [T_Rooms] SET [RomeStatus] = 1, [waiterNo] = " + ((WaiterNo_ <= 0) ? "NULL" : WaiterNo_.ToString()) + " where ID =" + RoomID_To);
                MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                VarGeneral.IsTablesTrans = true;
                Close();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Button_Move_Click:", error, enable: true);
                MessageBox.Show(error.Message);
                MessageBox.Show((LangArEn == 0) ? "لم يتم العملية بنجاح" : "Operation not successful", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Close();
            }
        }
    }
}
