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
    public partial  class FrmTransTable : Form
    { void avs(int arln)

{ 
}
        private void langloads(object sender, EventArgs e)
        {
             avs(GeneralM.VarGeneral.currentintlanguage);
        }
   
       // private IContainer components = null;
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
        public FrmTransTable()
        {
            InitializeComponent();this.Load += langloads;
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
