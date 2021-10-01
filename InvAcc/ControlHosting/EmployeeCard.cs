using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using DevComponents.Tree;
using Framework.Data;
using InvAcc.Forms;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace ControlHosting
{
    public class EmployeeCard : UserControl
    {
        private LinkLabel labelName;
        private PictureBox pictureBox1;
        private Label labelChair;
        private Label labelSts;
        private Label labelWaiter;
        private bool m_Expanded = false;
        private int m_ExpandedHeight = 0;
        private Label labelNote;
        private CheckBoxX checkBox_Clear;
        private CheckBoxX checkBox_Reseve;
        private CheckBoxX checkBox_OFF;
        private IntegerInput TextBox_Chair;
        private TextBox TextBox_Note;
        private TextBox textBox_Waiter;
        private TextBox textBox_Sts;
        private ButtonX buttonX_Save;
        private ButtonX buttonX_Transfer;
        private Container components = null;
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private int LangArEn = 0;
        private Stock_DataDataContext dbInstance;
        public string EmployeeName
        {
            get
            {
                return labelName.Text;
            }
            set
            {
                labelName.Text = value;
            }
        }
        public string EmployeeTitle
        {
            get
            {
                return labelChair.Text;
            }
            set
            {
                labelChair.Text = value;
            }
        }
        public string EmployeePhone
        {
            get
            {
                return labelSts.Text;
            }
            set
            {
                labelSts.Text = value;
            }
        }
        public string EmployeeBlog
        {
            get
            {
                return labelWaiter.Text;
            }
            set
            {
                labelWaiter.Text = value;
            }
        }
        public bool Expanded
        {
            get
            {
                return m_Expanded;
            }
            set
            {
                m_Expanded = value;
                Size size = base.Size;
                if (base.Parent is TreeGX)
                {
                    size = ((TreeGX)base.Parent).GetLayoutRectangle(base.Bounds).Size;
                }
                if (m_Expanded)
                {
                    size.Height = m_ExpandedHeight;
                }
                else
                {
                    size.Height = labelChair.Height + 12;
                }
                base.Size = size;
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
        public EmployeeCard()
        {
            InitializeComponent();//this.Load += langloads;
            m_ExpandedHeight = base.Height;
            base.Height = labelChair.Height;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlHosting.EmployeeCard));
            labelName = new System.Windows.Forms.LinkLabel();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            labelChair = new System.Windows.Forms.Label();
            labelSts = new System.Windows.Forms.Label();
            labelWaiter = new System.Windows.Forms.Label();
            labelNote = new System.Windows.Forms.Label();
            checkBox_Clear = new DevComponents.DotNetBar.Controls.CheckBoxX();
            checkBox_Reseve = new DevComponents.DotNetBar.Controls.CheckBoxX();
            checkBox_OFF = new DevComponents.DotNetBar.Controls.CheckBoxX();
            TextBox_Chair = new DevComponents.Editors.IntegerInput();
            TextBox_Note = new System.Windows.Forms.TextBox();
            textBox_Waiter = new System.Windows.Forms.TextBox();
            textBox_Sts = new System.Windows.Forms.TextBox();
            buttonX_Save = new DevComponents.DotNetBar.ButtonX();
            buttonX_Transfer = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TextBox_Chair).BeginInit();
            SuspendLayout();
            labelName.AccessibleDescription = null;
            labelName.AccessibleName = null;
            resources.ApplyResources(labelName, "labelName");
            labelName.BackColor = System.Drawing.Color.WhiteSmoke;
            labelName.Name = "labelName";
            labelName.TabStop = true;
            labelName.Click += new System.EventHandler(labelName_Click);
            pictureBox1.AccessibleDescription = null;
            pictureBox1.AccessibleName = null;
            resources.ApplyResources(pictureBox1, "pictureBox1");
            pictureBox1.BackgroundImage = null;
            pictureBox1.Font = null;
            pictureBox1.ImageLocation = null;
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabStop = false;
            labelChair.AccessibleDescription = null;
            labelChair.AccessibleName = null;
            resources.ApplyResources(labelChair, "labelChair");
            labelChair.Font = null;
            labelChair.Name = "labelChair";
            labelSts.AccessibleDescription = null;
            labelSts.AccessibleName = null;
            resources.ApplyResources(labelSts, "labelSts");
            labelSts.Font = null;
            labelSts.Name = "labelSts";
            labelWaiter.AccessibleDescription = null;
            labelWaiter.AccessibleName = null;
            resources.ApplyResources(labelWaiter, "labelWaiter");
            labelWaiter.Font = null;
            labelWaiter.Name = "labelWaiter";
            labelNote.AccessibleDescription = null;
            labelNote.AccessibleName = null;
            resources.ApplyResources(labelNote, "labelNote");
            labelNote.Font = null;
            labelNote.Name = "labelNote";
            checkBox_Clear.AccessibleDescription = null;
            checkBox_Clear.AccessibleName = null;
            resources.ApplyResources(checkBox_Clear, "checkBox_Clear");
            checkBox_Clear.BackgroundImage = null;
            checkBox_Clear.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            checkBox_Clear.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Top;
            checkBox_Clear.CheckSignSize = new System.Drawing.Size(27, 27);
            checkBox_Clear.CommandParameter = null;
            checkBox_Clear.Name = "checkBox_Clear";
            checkBox_Clear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            checkBox_Clear.CheckValueChanged += new System.EventHandler(checkBox_Clear_CheckValueChanged);
            checkBox_Reseve.AccessibleDescription = null;
            checkBox_Reseve.AccessibleName = null;
            resources.ApplyResources(checkBox_Reseve, "checkBox_Reseve");
            checkBox_Reseve.BackgroundImage = null;
            checkBox_Reseve.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            checkBox_Reseve.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Top;
            checkBox_Reseve.CheckSignSize = new System.Drawing.Size(27, 27);
            checkBox_Reseve.CommandParameter = null;
            checkBox_Reseve.Name = "checkBox_Reseve";
            checkBox_Reseve.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            checkBox_Reseve.CheckValueChanged += new System.EventHandler(checkBox_Reseve_CheckValueChanged);
            checkBox_OFF.AccessibleDescription = null;
            checkBox_OFF.AccessibleName = null;
            resources.ApplyResources(checkBox_OFF, "checkBox_OFF");
            checkBox_OFF.BackgroundImage = null;
            checkBox_OFF.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            checkBox_OFF.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Top;
            checkBox_OFF.CheckSignSize = new System.Drawing.Size(27, 27);
            checkBox_OFF.CommandParameter = null;
            checkBox_OFF.Name = "checkBox_OFF";
            checkBox_OFF.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            checkBox_OFF.CheckValueChanged += new System.EventHandler(checkBox_OFF_CheckValueChanged);
            TextBox_Chair.AccessibleDescription = null;
            TextBox_Chair.AccessibleName = null;
            TextBox_Chair.AllowEmptyState = false;
            resources.ApplyResources(TextBox_Chair, "TextBox_Chair");
            TextBox_Chair.BackgroundImage = null;
            TextBox_Chair.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 198);
            TextBox_Chair.BackgroundStyle.Class = "DateTimeInputBackground";
            TextBox_Chair.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            TextBox_Chair.ButtonCalculator.DisplayPosition = (int)resources.GetObject("TextBox_Chair.ButtonCalculator.DisplayPosition");
            TextBox_Chair.ButtonCalculator.Image = null;
            TextBox_Chair.ButtonCalculator.Text = resources.GetString("TextBox_Chair.ButtonCalculator.Text");
            TextBox_Chair.ButtonClear.DisplayPosition = (int)resources.GetObject("TextBox_Chair.ButtonClear.DisplayPosition");
            TextBox_Chair.ButtonClear.Image = null;
            TextBox_Chair.ButtonClear.Text = resources.GetString("TextBox_Chair.ButtonClear.Text");
            TextBox_Chair.ButtonCustom.DisplayPosition = (int)resources.GetObject("TextBox_Chair.ButtonCustom.DisplayPosition");
            TextBox_Chair.ButtonCustom.Image = null;
            TextBox_Chair.ButtonCustom.Text = resources.GetString("TextBox_Chair.ButtonCustom.Text");
            TextBox_Chair.ButtonCustom2.DisplayPosition = (int)resources.GetObject("TextBox_Chair.ButtonCustom2.DisplayPosition");
            TextBox_Chair.ButtonCustom2.Image = null;
            TextBox_Chair.ButtonCustom2.Text = resources.GetString("TextBox_Chair.ButtonCustom2.Text");
            TextBox_Chair.ButtonDropDown.DisplayPosition = (int)resources.GetObject("TextBox_Chair.ButtonDropDown.DisplayPosition");
            TextBox_Chair.ButtonDropDown.Image = null;
            TextBox_Chair.ButtonDropDown.Text = resources.GetString("TextBox_Chair.ButtonDropDown.Text");
            TextBox_Chair.ButtonFreeText.DisplayPosition = (int)resources.GetObject("TextBox_Chair.ButtonFreeText.DisplayPosition");
            TextBox_Chair.ButtonFreeText.Image = null;
            TextBox_Chair.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            TextBox_Chair.ButtonFreeText.Text = resources.GetString("TextBox_Chair.ButtonFreeText.Text");
            TextBox_Chair.CommandParameter = null;
            TextBox_Chair.DisplayFormat = "0";
            TextBox_Chair.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            TextBox_Chair.MinValue = 0;
            TextBox_Chair.Name = "TextBox_Chair";
            TextBox_Chair.ShowUpDown = true;
            TextBox_Note.AccessibleDescription = null;
            TextBox_Note.AccessibleName = null;
            resources.ApplyResources(TextBox_Note, "TextBox_Note");
            TextBox_Note.BackgroundImage = null;
            TextBox_Note.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            TextBox_Note.Font = null;
            TextBox_Note.Name = "TextBox_Note";
            textBox_Waiter.AccessibleDescription = null;
            textBox_Waiter.AccessibleName = null;
            resources.ApplyResources(textBox_Waiter, "textBox_Waiter");
            textBox_Waiter.BackColor = System.Drawing.Color.White;
            textBox_Waiter.BackgroundImage = null;
            textBox_Waiter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Waiter.Font = null;
            textBox_Waiter.ForeColor = System.Drawing.Color.Black;
            textBox_Waiter.Name = "textBox_Waiter";
            textBox_Waiter.ReadOnly = true;
            textBox_Sts.AccessibleDescription = null;
            textBox_Sts.AccessibleName = null;
            resources.ApplyResources(textBox_Sts, "textBox_Sts");
            textBox_Sts.BackColor = System.Drawing.Color.White;
            textBox_Sts.BackgroundImage = null;
            textBox_Sts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Sts.Font = null;
            textBox_Sts.ForeColor = System.Drawing.Color.Red;
            textBox_Sts.Name = "textBox_Sts";
            textBox_Sts.ReadOnly = true;
            buttonX_Save.AccessibleDescription = null;
            buttonX_Save.AccessibleName = null;
            buttonX_Save.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(buttonX_Save, "buttonX_Save");
            buttonX_Save.BackgroundImage = null;
            buttonX_Save.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            buttonX_Save.CommandParameter = null;
            buttonX_Save.Name = "buttonX_Save";
            buttonX_Save.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            buttonX_Save.TextColor = System.Drawing.Color.White;
            buttonX_Save.Click += new System.EventHandler(buttonX_Save_Click);
            buttonX_Transfer.AccessibleDescription = null;
            buttonX_Transfer.AccessibleName = null;
            buttonX_Transfer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(buttonX_Transfer, "buttonX_Transfer");
            buttonX_Transfer.BackgroundImage = null;
            buttonX_Transfer.Checked = true;
            buttonX_Transfer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            buttonX_Transfer.CommandParameter = null;
            buttonX_Transfer.Name = "buttonX_Transfer";
            buttonX_Transfer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            buttonX_Transfer.Symbol = "\uf074";
            buttonX_Transfer.TextColor = System.Drawing.Color.Black;
            buttonX_Transfer.Click += new System.EventHandler(buttonX_Transfer_Click);
            base.AccessibleDescription = null;
            base.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            BackColor = System.Drawing.Color.White;
            BackgroundImage = null;
            base.Controls.Add(buttonX_Transfer);
            base.Controls.Add(buttonX_Save);
            base.Controls.Add(textBox_Sts);
            base.Controls.Add(textBox_Waiter);
            base.Controls.Add(TextBox_Note);
            base.Controls.Add(TextBox_Chair);
            base.Controls.Add(checkBox_OFF);
            base.Controls.Add(checkBox_Reseve);
            base.Controls.Add(checkBox_Clear);
            base.Controls.Add(labelNote);
            base.Controls.Add(labelWaiter);
            base.Controls.Add(labelSts);
            base.Controls.Add(labelChair);
            base.Controls.Add(pictureBox1);
            base.Controls.Add(labelName);
            Font = null;
            base.Name = "EmployeeCard";
            base.Load += new System.EventHandler(EmployeeCard_Load);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)TextBox_Chair).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private void labelName_Click(object sender, EventArgs e)
        {
            Expanded = !Expanded;
        }
        private void checkBox_OFF_CheckValueChanged(object sender, EventArgs e)
        {
            checkBox_OFF.CheckValueChanged -= checkBox_OFF_CheckValueChanged;
            checkBox_Reseve.CheckValueChanged -= checkBox_Reseve_CheckValueChanged;
            checkBox_Clear.CheckValueChanged -= checkBox_Clear_CheckValueChanged;
            if (checkBox_OFF.Checked)
            {
                checkBox_Clear.Checked = false;
                checkBox_Reseve.Checked = false;
            }
            checkBox_Reseve.CheckValueChanged += checkBox_Reseve_CheckValueChanged;
            checkBox_Clear.CheckValueChanged += checkBox_Clear_CheckValueChanged;
            checkBox_OFF.CheckValueChanged += checkBox_OFF_CheckValueChanged;
        }
        private void checkBox_Reseve_CheckValueChanged(object sender, EventArgs e)
        {
            checkBox_OFF.CheckValueChanged -= checkBox_OFF_CheckValueChanged;
            checkBox_Reseve.CheckValueChanged -= checkBox_Reseve_CheckValueChanged;
            checkBox_Clear.CheckValueChanged -= checkBox_Clear_CheckValueChanged;
            if (checkBox_Reseve.Checked)
            {
                checkBox_Clear.Checked = false;
                checkBox_OFF.Checked = false;
            }
            checkBox_Reseve.CheckValueChanged += checkBox_Reseve_CheckValueChanged;
            checkBox_Clear.CheckValueChanged += checkBox_Clear_CheckValueChanged;
            checkBox_OFF.CheckValueChanged += checkBox_OFF_CheckValueChanged;
        }
        private void checkBox_Clear_CheckValueChanged(object sender, EventArgs e)
        {
            checkBox_OFF.CheckValueChanged -= checkBox_OFF_CheckValueChanged;
            checkBox_Reseve.CheckValueChanged -= checkBox_Reseve_CheckValueChanged;
            checkBox_Clear.CheckValueChanged -= checkBox_Clear_CheckValueChanged;
            if (checkBox_Clear.Checked)
            {
                checkBox_OFF.Checked = false;
                checkBox_Reseve.Checked = false;
            }
            checkBox_Reseve.CheckValueChanged += checkBox_Reseve_CheckValueChanged;
            checkBox_Clear.CheckValueChanged += checkBox_Clear_CheckValueChanged;
            checkBox_OFF.CheckValueChanged += checkBox_OFF_CheckValueChanged;
        }
        private void RemoveOrder(T_INVHED WiterOrder)
        {
            if (WiterOrder.RoomSts.Value)
            {
                db.ExecuteCommand("UPDATE [T_Rooms] SET [RomeStatus] = 0, [waiterNo] = NULL Where [RomeStatus] = 1 and ID =" + WiterOrder.RoomNo.Value);
            }
            if (WiterOrder == null || WiterOrder.InvNo == 0.ToString())
            {
                return;
            }
            WiterOrder = db.StockInvHead(21, WiterOrder.InvNo);
            IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
            try
            {
                db_ = Database.GetDatabase(VarGeneral.BranchCS);
                for (int i = 0; i < WiterOrder.T_INVDETs.Count; i++)
                {
                    if (WiterOrder.T_INVDETs[i].ItmTyp.Value == 2)
                    {
                        for (int iicnt = 0; iicnt < WiterOrder.T_INVDETs[i].T_SINVDETs.Count; iicnt++)
                        {
                            db_.ClearParameters();
                            db_.AddParameter("SInvDet_ID", DbType.Int32, WiterOrder.T_INVDETs[i].T_SINVDETs[iicnt].SInvDet_ID);
                            db_.ExecuteNonQuery(storedProcedure: true, "S_T_SINVDET_DELETE");
                        }
                    }
                    db_.ClearParameters();
                    db_.AddParameter("InvDet_ID", DbType.Int32, WiterOrder.T_INVDETs[i].InvDet_ID);
                    db_.ExecuteNonQuery(storedProcedure: true, "S_T_INVDET_DELETE");
                }
                try
                {
                    db.ExecuteCommand("DELETE FROM [T_INVHED] WHERE InvHed_ID=" + WiterOrder.InvHed_ID);
                }
                catch
                {
                }
            }
            catch (SqlException)
            {
                WiterOrder = db.StockInvHead(21, WiterOrder.InvNo);
            }
            catch (Exception)
            {
                WiterOrder = db.StockInvHead(21, WiterOrder.InvNo);
            }
        }
        private void buttonX_Save_Click(object sender, EventArgs e)
        {
            checkBox_OFF.CheckValueChanged -= checkBox_OFF_CheckValueChanged;
            checkBox_Reseve.CheckValueChanged -= checkBox_Reseve_CheckValueChanged;
            checkBox_Clear.CheckValueChanged -= checkBox_Clear_CheckValueChanged;
            T_Room DataThis = new T_Room();
            try
            {
                DataThis = db.StockRommID(int.Parse(buttonX_Save.Tag.ToString()));
                DataThis.chair = TextBox_Chair.Value;
                DataThis.Note = TextBox_Note.Text;
                if (textBox_Sts.Text.Trim() == "مشغولة" || textBox_Sts.Text.Trim() == "Busy")
                {
                    if (checkBox_Clear.Checked && MessageBox.Show((LangArEn == 0) ? "هل تريد افراغ هذه الطاولة؟" : "do you want Clear This Table ?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            List<T_INVHED> q = (from t in db.T_INVHEDs
                                                where t.IfDel == (int?)0
                                                where t.InvTyp == (int?)21
                                                where t.RoomNo == (int?)int.Parse(buttonX_Save.Tag.ToString())
                                                orderby t.InvNo
                                                select t).ToList();
                            for (int i = 0; i < q.Count; i++)
                            {
                                RemoveOrder(q[i]);
                            }
                        }
                        catch
                        {
                        }
                        db.ExecuteCommand("UPDATE T_INVHED SET RoomNo = 1 ,RoomSts = 0,RoomPerson = 1 where RoomNo =" + int.Parse(buttonX_Save.Tag.ToString()));
                        DataThis.waiterNo = null;
                        DataThis.RomeStatus = false;
                        db.ExecuteCommand("UPDATE [T_Rooms] SET [RomeStatus] = 0, [waiterNo] = NULL Where ID =" + DataThis.ID);
                    }
                }
                else if (textBox_Sts.Text.Trim() == "محجوزة" || textBox_Sts.Text.Trim() == "reserved")
                {
                    if (!checkBox_Reseve.Checked)
                    {
                        if (MessageBox.Show((LangArEn == 0) ? "هل تريد إزالة حجز هذه الطاولة؟" : "Do you want to cancel a reservation at this table?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            DataThis.reserved = false;
                            db.ExecuteCommand("UPDATE [T_Rooms] SET [reserved] = 0 Where ID =" + DataThis.ID);
                        }
                        else
                        {
                            checkBox_Reseve.Checked = true;
                        }
                    }
                }
                else if (textBox_Sts.Text.Trim() == "معطل\u0651ة" || textBox_Sts.Text.Trim() == "OFF")
                {
                    if (!checkBox_OFF.Checked)
                    {
                        if (MessageBox.Show((LangArEn == 0) ? "هل تريد إلغاء تعطيل هذه الطاولة؟" : "Do you want to cancel disable this table ?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            DataThis.Stop = false;
                            db.ExecuteCommand("UPDATE [T_Rooms] SET [Stop] = 0 Where ID =" + DataThis.ID);
                        }
                        else
                        {
                            checkBox_OFF.Checked = true;
                        }
                    }
                }
                else if (checkBox_Reseve.Checked)
                {
                    if (MessageBox.Show((LangArEn == 0) ? "هل تريد حجز هذه الطاولة؟" : "Do you want reservation at this table?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DataThis.reserved = true;
                        db.ExecuteCommand("UPDATE [T_Rooms] SET [reserved] = 1 Where ID =" + DataThis.ID);
                    }
                    else
                    {
                        checkBox_Reseve.Checked = false;
                    }
                }
                else if (checkBox_OFF.Checked)
                {
                    if (MessageBox.Show((LangArEn == 0) ? "هل تريد تعطيل هذه الطاولة؟" : "Do you want disable this table ?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DataThis.Stop = true;
                        db.ExecuteCommand("UPDATE [T_Rooms] SET [Stop] = 1 Where ID =" + DataThis.ID);
                    }
                    else
                    {
                        checkBox_OFF.Checked = false;
                    }
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Save:", error, enable: true);
                MessageBox.Show(error.Message);
            }
            dbInstance = null;
            checkBox_Clear.Checked = false;
            checkBox_OFF.Checked = false;
            checkBox_Reseve.Checked = false;
            buttonX_Transfer.Visible = false;
            checkBox_OFF.CheckValueChanged += checkBox_OFF_CheckValueChanged;
            checkBox_Reseve.CheckValueChanged += checkBox_Reseve_CheckValueChanged;
            checkBox_Clear.CheckValueChanged += checkBox_Clear_CheckValueChanged;
            DataThis.chair = TextBox_Chair.Value;
            DataThis.Note = TextBox_Note.Text;
            textBox_Sts.Text = ((LangArEn != 0) ? (DataThis.Stop.Value ? "OFF" : (DataThis.reserved.Value ? "reserved" : (DataThis.RomeStatus.Value ? "Busy" : "Empty"))) : (DataThis.Stop.Value ? "معطل\u0651ة" : (DataThis.reserved.Value ? "محجوزة" : (DataThis.RomeStatus.Value ? "مشغولة" : "فارغة"))));
            if (textBox_Sts.Text.Trim() == "مشغولة" || textBox_Sts.Text.Trim() == "Busy")
            {
                checkBox_OFF.Enabled = false;
                checkBox_Reseve.Enabled = false;
                buttonX_Transfer.Visible = true;
            }
            else if (textBox_Sts.Text.Trim() == "محجوزة" || textBox_Sts.Text.Trim() == "reserved")
            {
                checkBox_OFF.Enabled = false;
                checkBox_Clear.Enabled = false;
                checkBox_Reseve.Checked = true;
            }
            else if (textBox_Sts.Text.Trim() == "معطل\u0651ة" || textBox_Sts.Text.Trim() == "OFF")
            {
                checkBox_Reseve.Enabled = false;
                checkBox_Clear.Enabled = false;
                checkBox_OFF.Checked = true;
            }
            else
            {
                checkBox_Clear.Enabled = false;
                checkBox_OFF.Enabled = true;
                checkBox_Reseve.Enabled = true;
            }
            labelName_Click(sender, e);
        }
        private void buttonX_Transfer_Click(object sender, EventArgs e)
        {
            FrmTableType frm = new FrmTableType();
            frm.Tag = LangArEn;
            frm.TopMost = true;
            frm.ShowDialog();
            if (!frm.vSts_Op)
            {
                return;
            }
            FrmTables frm2 = new FrmTables(db.StockRommID(int.Parse(buttonX_Save.Tag.ToString())).T_INVHEDs.FirstOrDefault().InvNo, frm.vSize_, frmSts: false);
            frm2.Tag = LangArEn;
            frm2.ShowDialog();
            try
            {
                if (frm2.Serach_No > 1)
                {
                    db.ExecuteCommand("UPDATE T_INVHED SET RoomNo =" + frm2.Serach_No + " where RoomNo =" + int.Parse(buttonX_Save.Tag.ToString()));
                    db.ExecuteCommand("UPDATE T_Rooms SET RomeStatus = 0,waiterNo = null where ID =" + int.Parse(buttonX_Save.Tag.ToString()));
                    db.ExecuteCommand("UPDATE T_Rooms SET RomeStatus = 1 where ID =" + frm2.Serach_No);
                    MessageBox.Show((LangArEn == 0) ? "تمت عملية نقل الخدمة بنجاح" : "The service was successfully transferred", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    labelName_Click(sender, e);
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Button_Move_Click:", error, enable: true);
                MessageBox.Show(error.Message);
                MessageBox.Show((LangArEn == 0) ? "لم يتم عملية نقل الخدمة بنجاح" : "The service was Unsuccessfully transferred", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                labelName_Click(sender, e);
            }
        }
        private void EmployeeCard_Load(object sender, EventArgs e)
        {
        }
    }
}
