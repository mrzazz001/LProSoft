using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;
using ProShared.GeneralM;using ProShared;
using InvAcc.Properties;
using ProShared.Stock_Data;
using Library.RepShow;
using SSSDateTime.Date;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmTables : Form
    { void avs(int arln)

{ 
}
        private void langloads(object sender, EventArgs e)
        {
              avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
        }
   
       // private IContainer components = null;
        protected ContextMenuStrip contextMenuStrip2;
        protected ToolStripMenuItem ToolStripMenuItem_Det;
        protected ToolStripMenuItem ToolStripMenuItem_Rep;
        protected ContextMenuStrip contextMenuStrip1;
        private SuperTabControl superTabControl_Tables;
        private SuperTabControlPanel superTabControlPanel1;
        private MetroTilePanel metroTilePanel_Family;
        private ItemContainer itemContainer_Family;
        private SuperTabItem superTabItem_Family;
        private SuperTabControlPanel superTabControlPanel4;
        private SuperTabItem superTabItem_Other;
        private SuperTabControlPanel superTabControlPanel3;
        private SuperTabItem superTabItem_Extnal;
        private SuperTabControlPanel superTabControlPanel2;
        private SuperTabItem superTabItem_Boys;
        private MetroTilePanel metroTilePanel_Other;
        private ItemContainer itemContainer_Other;
        private MetroTilePanel metroTilePanel_Extnal;
        private ItemContainer itemContainer_Extrnal;
        private MetroTilePanel metroTilePanel_Boys;
        private ItemContainer itemContainer_Boys;
        private ExpandablePanel expandablePanel_Table;
        private ItemPanel itemPanel2;
        private LabelItem labelItem_ReseTables;
        private LabelItem labelItem_EmptyTable;
        private ItemPanel itemPanel1;
        private LabelItem labelItem_Tables;
        private LabelItem labelItem_Note;
        private LabelItem labelItem_BussyTable;
        private LabelItem labelItem_Time;
        private LabelItem labelItem_Nadel;
        private LabelItem labelItem_StopTable;
        private Panel panel_TableColor;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private MetroTilePanel metroTilePanel1;
        private MetroTileItem metroTileItem1;
        private MetroTileItem metroTileItem2;
        private MetroTileItem metroTileItem3;
        private MetroTileItem metroTileItem5;
        private Panel panel_ButSave;
        private ButtonX ButOk;
        private LabelItem labelItem_Type;
        private LabelItem labelItem_SumTable;
        private ToolStripMenuItem ToolStripMenuItem_Op;
        public int Serach_No = 0;
        public string sts_ = "";
        private string vNo = "";
        private int vTyp = 0;
        private bool frmSts_ = false;
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private int LangArEn = 0;
        private Stock_DataDataContext dbInstance;
        private MetroTileItem vItemSelect = new MetroTileItem();
        private T_INVSETTING _InvSetting = new T_INVSETTING();
        public int SerachNo
        {
            get
            {
                return Serach_No;
            }
            set
            {
                Serach_No = value;
            }
        }
        public string RomeStatus
        {
            get
            {
                return sts_;
            }
            set
            {
                sts_ = value;
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
        public bool VisibleSts
        {
            set
            {
                if (!frmSts_)
                {
                    panel_ButSave.Visible = !value;
                }
                else
                {
                    panel_ButSave.Visible = false;
                }
            }
        }
        public FrmTables(string vno, int vType, bool frmSts)
        {
            InitializeComponent();this.Load += langloads;
            vNo = vno;
            vTyp = vType;
            frmSts_ = frmSts;
        }
        private void FrmTables_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmTables));
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    Language.ChangeLanguage("ar-SA", this, resources);
                    LangArEn = 0;
                }
                else
                {
                    Language.ChangeLanguage("en", this, resources);
                    LangArEn = 1;
                    superTabItem_Family.Text = "Family Tables";
                    superTabItem_Boys.Text = "Boys Tables";
                    superTabItem_Extnal.Text = "Extrnal Tables";
                    superTabItem_Other.Text = "Other Tables";
                    ButOk.Text = "Selected Table";
                }
                GetInvSetting();
                _processFrm();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void _processFrm()
        {
            if (vTyp > 0)
            {
                expandablePanel_Table.Visible = false;
                if (vTyp == 1)
                {
                    superTabItem_Boys.Visible = false;
                    superTabItem_Extnal.Visible = false;
                    superTabItem_Other.Visible = false;
                }
                else if (vTyp == 2)
                {
                    superTabItem_Family.Visible = false;
                    superTabItem_Extnal.Visible = false;
                    superTabItem_Other.Visible = false;
                }
                else if (vTyp == 3)
                {
                    superTabItem_Boys.Visible = false;
                    superTabItem_Family.Visible = false;
                    superTabItem_Other.Visible = false;
                }
                else
                {
                    superTabItem_Boys.Visible = false;
                    superTabItem_Extnal.Visible = false;
                    superTabItem_Family.Visible = false;
                }
            }
            FillTable();
            TableInfo(1);
            VisibleSts = true;
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
        private void TableInfo(int vTableNo)
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                if (vTableNo > 0)
                {
                    List<T_Room> q = db.T_Rooms.Where((T_Room t) => t.ID == vTableNo).ToList();
                    try
                    {
                        labelItem_Tables.Text = "رقم الطاولة : " + q.FirstOrDefault().RomeNo + "    |     عدد الكراسي : " + q.FirstOrDefault().chair.Value;
                    }
                    catch (Exception error2)
                    {
                        VarGeneral.DebLog.writeLog("DTime:", error2, enable: true);
                    }
                    try
                    {
                        labelItem_Note.Text = "ملاحظة : " + q.FirstOrDefault().Note;
                    }
                    catch (Exception error2)
                    {
                        VarGeneral.DebLog.writeLog("DTime:", error2, enable: true);
                    }
                    try
                    {
                        int vtm = 0;
                        try
                        {
                            vtm = DTime(q.FirstOrDefault().T_INVHEDs.First().LTim, DateTime.Now.ToString("HH:mm"));
                        }
                        catch
                        {
                        }
                        labelItem_Time.Text = "حالة الطاولة :   " + (q.FirstOrDefault().Stop.Value ? "معطل\u0651ة" : (q.FirstOrDefault().reserved.Value ? "محجوزة" : (q.FirstOrDefault().RomeStatus.Value ? ("مشغولة منذ " + vtm + " دقيقة ") : "فارغة")));
                    }
                    catch (Exception error2)
                    {
                        VarGeneral.DebLog.writeLog("DTime:", error2, enable: true);
                    }
                    try
                    {
                        labelItem_Nadel.Text = "النادل : " + (q.FirstOrDefault().waiterNo.HasValue ? q.FirstOrDefault().T_Waiter.Arb_Des : " لا يوجد");
                    }
                    catch (Exception error2)
                    {
                        VarGeneral.DebLog.writeLog("DTime:", error2, enable: true);
                    }
                    try
                    {
                        labelItem_Type.Text = ((q.FirstOrDefault().Type.Value == 1) ? "طاولة عوائـل" : ((q.FirstOrDefault().Type.Value == 2) ? "طاولة شباب" : ((q.FirstOrDefault().Type.Value == 3) ? "طاولة خارجية" : ((q.FirstOrDefault().Type.Value == 4) ? "طاولة آخرى" : "لم يتم تحديد طاولة"))));
                    }
                    catch (Exception error2)
                    {
                        VarGeneral.DebLog.writeLog("DTime:", error2, enable: true);
                    }
                    try
                    {
                        if (q.FirstOrDefault().RomeStatus.Value)
                        {
                            labelItem_Note.Text = "صافي الفاتورة = " + q.FirstOrDefault().T_INVHEDs.Sum((T_INVHED g) => g.InvNetLocCur.Value);
                        }
                    }
                    catch (Exception error2)
                    {
                        VarGeneral.DebLog.writeLog("DTime:", error2, enable: true);
                    }
                }
                else
                {
                    labelItem_Tables.Text = "رقم الطاولة : لم يتم تحديد طاولة ";
                    labelItem_Note.Text = "ملاحظة : لا يوجد ";
                    labelItem_Time.Text = "حالة الطاولة : لم يتم تحديد طاولة ";
                    labelItem_Nadel.Text = "النادل : لا يوجد";
                    labelItem_Type.Text = "لم يتم تحديد طاولة ";
                }
                try
                {
                    labelItem_EmptyTable.Text = "عدد الطاولات الفارغة : " + db.T_Rooms.Where((T_Room t) => t.Type != (int?)0 && !t.RomeStatus.Value && !t.Stop.Value && !t.reserved.Value).ToList().Count + " طاولة ";
                    labelItem_BussyTable.Text = "عدد الطاولات المشغولة : " + db.T_Rooms.Where((T_Room t) => t.RomeStatus.Value && !t.Stop.Value && !t.reserved.Value).ToList().Count + " طاولة ";
                    labelItem_StopTable.Text = "عدد الطاولات المعط\u0651لة : " + db.T_Rooms.Where((T_Room t) => !t.RomeStatus.Value && t.Stop.Value && !t.reserved.Value).ToList().Count + " طاولة ";
                    labelItem_ReseTables.Text = "عدد الطاولات المحجوزة : " + db.T_Rooms.Where((T_Room t) => !t.RomeStatus.Value && !t.Stop.Value && t.reserved.Value).ToList().Count + " طاولة ";
                    labelItem_SumTable.Text = "إجمالي طاولات المطعم : " + db.T_Rooms.Where((T_Room t) => t.Type != (int?)0).ToList().Count + " طاولة ";
                }
                catch (Exception error2)
                {
                    VarGeneral.DebLog.writeLog("DTime:", error2, enable: true);
                }
                return;
            }
            if (vTableNo > 0)
            {
                List<T_Room> q = db.T_Rooms.Where((T_Room t) => t.ID == vTableNo).ToList();
                try
                {
                    labelItem_Tables.Text = "Table No : " + q.FirstOrDefault().RomeNo + "    |     Chair Acount : " + q.FirstOrDefault().chair.Value;
                }
                catch (Exception error2)
                {
                    VarGeneral.DebLog.writeLog("DTime:", error2, enable: true);
                }
                try
                {
                    labelItem_Note.Text = "Note : " + q.FirstOrDefault().Note;
                }
                catch (Exception error2)
                {
                    VarGeneral.DebLog.writeLog("DTime:", error2, enable: true);
                }
                try
                {
                    int vtm = 0;
                    try
                    {
                        vtm = DTime(q.FirstOrDefault().T_INVHEDs.First().LTim, DateTime.Now.ToString("HH:mm"));
                    }
                    catch
                    {
                    }
                    labelItem_Time.Text = "Table State :   " + (q.FirstOrDefault().Stop.Value ? "OFF" : (q.FirstOrDefault().reserved.Value ? "reserved" : (q.FirstOrDefault().RomeStatus.Value ? ("Busy since  " + vtm + " minute ") : "Empty")));
                }
                catch (Exception error2)
                {
                    VarGeneral.DebLog.writeLog("DTime:", error2, enable: true);
                }
                try
                {
                    labelItem_Nadel.Text = "Waiter : " + (q.FirstOrDefault().waiterNo.HasValue ? q.FirstOrDefault().T_Waiter.Eng_Des : " No");
                }
                catch (Exception error2)
                {
                    VarGeneral.DebLog.writeLog("DTime:", error2, enable: true);
                }
                try
                {
                    labelItem_Type.Text = ((q.FirstOrDefault().Type.Value == 1) ? "Family Table" : ((q.FirstOrDefault().Type.Value == 2) ? "Boys Table" : ((q.FirstOrDefault().Type.Value == 3) ? "Extrnal Table" : ((q.FirstOrDefault().Type.Value == 4) ? "Other Table" : "No Selected Table"))));
                }
                catch (Exception error2)
                {
                    VarGeneral.DebLog.writeLog("DTime:", error2, enable: true);
                }
                try
                {
                    if (q.FirstOrDefault().RomeStatus.Value)
                    {
                        labelItem_Note.Text = "Invoice Net = " + q.FirstOrDefault().T_INVHEDs.Sum((T_INVHED g) => g.InvNetLocCur.Value);
                    }
                }
                catch
                {
                }
            }
            else
            {
                labelItem_Tables.Text = "Table No : No Selected Table ";
                labelItem_Note.Text = "Note : No Note ";
                labelItem_Time.Text = "Table State : No Selected Table ";
                labelItem_Nadel.Text = "waiter : No ";
                labelItem_Type.Text = "No Selected Table ";
            }
            try
            {
                labelItem_EmptyTable.Text = "Empty Tables : " + db.T_Rooms.Where((T_Room t) => !t.RomeStatus.Value && !t.Stop.Value && !t.reserved.Value).ToList().Count + " Table ";
                labelItem_BussyTable.Text = "Bussy Tables : " + db.T_Rooms.Where((T_Room t) => t.RomeStatus.Value && !t.Stop.Value && !t.reserved.Value).ToList().Count + " Table ";
                labelItem_StopTable.Text = "OFF Tables : " + db.T_Rooms.Where((T_Room t) => !t.RomeStatus.Value && t.Stop.Value && !t.reserved.Value).ToList().Count + " Table ";
                labelItem_ReseTables.Text = "Reserved Table : " + db.T_Rooms.Where((T_Room t) => !t.RomeStatus.Value && !t.Stop.Value && t.reserved.Value).ToList().Count + " Table ";
                labelItem_SumTable.Text = "Total Tables : " + db.T_Rooms.Where((T_Room t) => t.Type != (int?)0).ToList().Count + " Table ";
            }
            catch (Exception error2)
            {
                VarGeneral.DebLog.writeLog("DTime:", error2, enable: true);
            }
        }
        private void FillComboReserve()
        {
        }
        private void FillTable()
        {
            try
            {
                itemContainer_Family.SubItems.Clear();
                itemContainer_Boys.SubItems.Clear();
                itemContainer_Extrnal.SubItems.Clear();
                itemContainer_Other.SubItems.Clear();
                List<T_Room> q = new List<T_Room>();
                q = ((vTyp > 0) ? db.FillTableSts_2(1).ToList() : ((VarGeneral.SFrmTyp == "AddToTable") ? db.FillTable_2Bussy(1).ToList() : db.FillTable_2(1).ToList()));
                for (int i = 0; i < q.Count; i++)
                {
                    MetroTileItem vTable = new MetroTileItem();
                    vTable.Image = (q[i].Stop.Value ? Resources.vStop : (q[i].reserved.Value ? Resources.reserved_64 : (q[i].RomeStatus.Value ? Resources.Bussy : Resources.Empty)));
                    vTable.ImageTextAlignment = ContentAlignment.MiddleCenter;
                    vTable.SymbolColor = Color.Empty;
                    vTable.TileColor = (q[i].Stop.Value ? eMetroTileColor.Yellow : (q[i].reserved.Value ? eMetroTileColor.Gray : (q[i].RomeStatus.Value ? eMetroTileColor.Orange : eMetroTileColor.Azure)));
                    vTable.TileSize = new Size(160, 140);
                    vTable.TileStyle.CornerType = eCornerType.Diagonal;
                    vTable.TitleText = ((LangArEn == 0) ? "طاولة | " : "Table | ") + q[i].RomeNo;
                    vTable.Tag = q[i].ID.ToString();
                    vTable.TitleTextAlignment = ContentAlignment.BottomCenter;
                    vTable.TitleTextFont = new Font("Tahoma", 11f, FontStyle.Regular, GraphicsUnit.Point, 0);
                    itemContainer_Family.SubItems.AddRange(new BaseItem[1]
                    {
                        vTable
                    });
                }
                q = ((vTyp > 0) ? db.FillTableSts_2(2).ToList() : ((VarGeneral.SFrmTyp == "AddToTable") ? db.FillTable_2Bussy(2).ToList() : db.FillTable_2(2).ToList()));
                for (int i = 0; i < q.Count; i++)
                {
                    MetroTileItem vTable = new MetroTileItem();
                    vTable.Image = (q[i].Stop.Value ? Resources.vStop : (q[i].reserved.Value ? Resources.reserved_64 : (q[i].RomeStatus.Value ? Resources.Bussy : Resources.Empty)));
                    vTable.ImageTextAlignment = ContentAlignment.MiddleCenter;
                    vTable.SymbolColor = Color.Empty;
                    vTable.TileColor = (q[i].Stop.Value ? eMetroTileColor.Yellow : (q[i].reserved.Value ? eMetroTileColor.Gray : (q[i].RomeStatus.Value ? eMetroTileColor.Orange : eMetroTileColor.Azure)));
                    vTable.TileSize = new Size(160, 140);
                    vTable.TileStyle.CornerType = eCornerType.Diagonal;
                    vTable.TitleText = ((LangArEn == 0) ? "طاولة | " : "Table | ") + q[i].RomeNo;
                    vTable.Tag = q[i].ID.ToString();
                    vTable.TitleTextAlignment = ContentAlignment.BottomCenter;
                    vTable.TitleTextFont = new Font("Tahoma", 11f, FontStyle.Regular, GraphicsUnit.Point, 0);
                    itemContainer_Boys.SubItems.AddRange(new BaseItem[1]
                    {
                        vTable
                    });
                }
                q = ((vTyp > 0) ? db.FillTableSts_2(3).ToList() : ((VarGeneral.SFrmTyp == "AddToTable") ? db.FillTable_2Bussy(3).ToList() : db.FillTable_2(3).ToList()));
                for (int i = 0; i < q.Count; i++)
                {
                    MetroTileItem vTable = new MetroTileItem();
                    vTable.Image = (q[i].Stop.Value ? Resources.vStop : (q[i].reserved.Value ? Resources.reserved_64 : (q[i].RomeStatus.Value ? Resources.Bussy : Resources.Empty)));
                    vTable.ImageTextAlignment = ContentAlignment.MiddleCenter;
                    vTable.SymbolColor = Color.Empty;
                    vTable.TileColor = (q[i].Stop.Value ? eMetroTileColor.Yellow : (q[i].reserved.Value ? eMetroTileColor.Gray : (q[i].RomeStatus.Value ? eMetroTileColor.Orange : eMetroTileColor.Azure)));
                    vTable.TileSize = new Size(160, 140);
                    vTable.TileStyle.CornerType = eCornerType.Diagonal;
                    vTable.TitleText = ((LangArEn == 0) ? "طاولة | " : "Table | ") + q[i].RomeNo;
                    vTable.Tag = q[i].ID.ToString();
                    vTable.TitleTextAlignment = ContentAlignment.BottomCenter;
                    vTable.TitleTextFont = new Font("Tahoma", 11f, FontStyle.Regular, GraphicsUnit.Point, 0);
                    itemContainer_Extrnal.SubItems.AddRange(new BaseItem[1]
                    {
                        vTable
                    });
                }
                q = ((vTyp > 0) ? db.FillTableSts_2(4).ToList() : ((VarGeneral.SFrmTyp == "AddToTable") ? db.FillTable_2Bussy(4).ToList() : db.FillTable_2(4).ToList()));
                for (int i = 0; i < q.Count; i++)
                {
                    MetroTileItem vTable = new MetroTileItem();
                    vTable.Image = (q[i].Stop.Value ? Resources.vStop : (q[i].reserved.Value ? Resources.reserved_64 : (q[i].RomeStatus.Value ? Resources.Bussy : Resources.Empty)));
                    vTable.ImageTextAlignment = ContentAlignment.MiddleCenter;
                    vTable.SymbolColor = Color.Empty;
                    vTable.TileColor = (q[i].Stop.Value ? eMetroTileColor.Yellow : (q[i].reserved.Value ? eMetroTileColor.Gray : (q[i].RomeStatus.Value ? eMetroTileColor.Orange : eMetroTileColor.Azure)));
                    vTable.TileSize = new Size(160, 140);
                    vTable.TileStyle.CornerType = eCornerType.Diagonal;
                    vTable.TitleText = ((LangArEn == 0) ? "طاولة | " : "Table | ") + q[i].RomeNo;
                    vTable.Tag = q[i].ID.ToString();
                    vTable.TitleTextAlignment = ContentAlignment.BottomCenter;
                    vTable.TitleTextFont = new Font("Tahoma", 11f, FontStyle.Regular, GraphicsUnit.Point, 0);
                    itemContainer_Other.SubItems.AddRange(new BaseItem[1]
                    {
                        vTable
                    });
                }
                Refresh();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("FillTable:", error, enable: true);
                itemContainer_Family.SubItems.Clear();
                itemContainer_Boys.SubItems.Clear();
                itemContainer_Extrnal.SubItems.Clear();
                itemContainer_Other.SubItems.Clear();
                Refresh();
            }
        }
        private void FrmTables_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void FrmTables_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void metroTilePanel_Family_ItemClick(object sender, EventArgs e)
        {
            try
            {
                MetroTileItem q = (vItemSelect = sender as MetroTileItem);
                if (q != null)
                {
                    TableInfo(int.Parse(q.Tag.ToString()));
                    VisibleSts = false;
                }
                else
                {
                    TableInfo(1);
                    VisibleSts = true;
                }
                if (vTyp > 0)
                {
                    ButOk_Click(sender, e);
                }
            }
            catch
            {
                vItemSelect = null;
                VisibleSts = true;
            }
        }
        private void ButOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (vItemSelect == null)
                {
                    MessageBox.Show((LangArEn == 0) ? "لم تقم باختيار طاولة .. يرجى تحديد الطاولة ثم المحاولة مرة آخرى" : "You do not choose a table .. Please identify the table and then try again", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else if (vItemSelect.TileColor == eMetroTileColor.Orange)
                {
                    if (VarGeneral.SFrmTyp != "AddToTable")
                    {
                        if (!string.IsNullOrEmpty(vItemSelect.TitleText) && !string.IsNullOrEmpty(vItemSelect.Tag.ToString()))
                        {
                            if (MessageBox.Show((LangArEn == 0) ? "عفوا\u064c ..لقد قمت باختيار طاولة مشغولة حاليا .. \n هل تريد القيام بإفراغ هذه الطاولة؟" : "do you want Clear This Table ?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                            {
                                return;
                            }
                            if (db.StockRommID(int.Parse(vItemSelect.Tag.ToString())).T_INVHEDs.FirstOrDefault().InvTyp == 21)
                            {
                                MessageBox.Show((LangArEn == 0) ? "لا يمكن استخدام هذه الطاولة  .. لقد تم ربطه بطلب محلي غير مستخدم \n يرجى استخدام الطلب أولا او ازالته من قائمة الطلبات" : "You do not choose a table .. Please identify the table and then try again", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return;
                            }
                            db.ExecuteCommand("UPDATE T_INVHED SET RoomNo = 1 ,RoomSts = 0,RoomPerson = 1 where RoomNo =" + int.Parse(vItemSelect.Tag.ToString()));
                            db.ExecuteCommand("UPDATE [T_Rooms] SET [RomeStatus] = 0, [waiterNo] = NULL Where ID =" + int.Parse(vItemSelect.Tag.ToString()));
                            try
                            {
                                Serach_No = int.Parse(vItemSelect.Tag.ToString());
                                Close();
                            }
                            catch (SqlException)
                            {
                            }
                            catch (Exception)
                            {
                            }
                            return;
                        }
                        MessageBox.Show((LangArEn == 0) ? "عفوا\u064c ..لقد قمت باختيار طاولة مشغولة حاليا.. يرجى تغيير الطاولة" : "Sorry .. you choose currently busy table .. please change the table", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else
                    {
                        Serach_No = int.Parse(vItemSelect.Tag.ToString());
                        Close();
                    }
                }
                else if (vItemSelect.TileColor == eMetroTileColor.Yellow)
                {
                    if (!string.IsNullOrEmpty(vItemSelect.TitleText) && !string.IsNullOrEmpty(vItemSelect.Tag.ToString()))
                    {
                        if (MessageBox.Show((LangArEn == 0) ? "عفوا\u064c ..لقد قمت باختيار طاولة معط\u0651لة حاليا .. \n هل تريد إلغاء تعطيل هذه الطاولة؟" : "Do you want to cancel disable this table ?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            T_Room DataThis = db.StockRommID(int.Parse(vItemSelect.Tag.ToString()));
                            DataThis.Stop = false;
                            try
                            {
                                db.Log = VarGeneral.DebugLog;
                                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                                Serach_No = int.Parse(vItemSelect.Tag.ToString());
                                Close();
                            }
                            catch (SqlException)
                            {
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show((LangArEn == 0) ? "عفوا\u064c ..لقد قمت باختيار طاولة معط\u0651لة حاليا.. يرجى تغيير الطاولة" : "Sorry .. you choose currently OFF table .. please change the table", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                else if (vItemSelect.TileColor == eMetroTileColor.Gray)
                {
                    if (!string.IsNullOrEmpty(vItemSelect.TitleText) && !string.IsNullOrEmpty(vItemSelect.Tag.ToString()))
                    {
                        if (MessageBox.Show((LangArEn == 0) ? "عفوا\u064c ..لقد قمت باختيار طاولة محجوزة حاليا .. \n هل تريد إزالة حجز هذه الطاولة؟" : "Do you want to cancel a reservation at this table ?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            T_Room DataThis = db.StockRommID(int.Parse(vItemSelect.Tag.ToString()));
                            DataThis.reserved = false;
                            try
                            {
                                db.Log = VarGeneral.DebugLog;
                                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                                Serach_No = int.Parse(vItemSelect.Tag.ToString());
                                Close();
                            }
                            catch (SqlException)
                            {
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show((LangArEn == 0) ? "عفوا\u064c ..لقد قمت باختيار طاولة محجوزة حاليا.. يرجى تغيير الطاولة" : "Sorry .. you choose currently reserved table .. please change the table", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                else if (!string.IsNullOrEmpty(vItemSelect.TitleText) && !string.IsNullOrEmpty(vItemSelect.Tag.ToString()))
                {
                    Serach_No = int.Parse(vItemSelect.Tag.ToString());
                    Close();
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("ButOk_Click:", error, enable: true);
                MessageBox.Show((LangArEn == 0) ? "لم تقم باختيار طاولة .. يرجى تحديد الطاولة ثم المحاولة مرة آخرى" : "You do not choose a table .. Please identify the table and then try again", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void metroTilePanel_Family_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                ToolStripMenuItem_Rep.Visible = false;
                if (VarGeneral._IsWaiter || e.Button != MouseButtons.Right)
                {
                    return;
                }
                metroTilePanel_Family_ItemClick(sender, e);
                if (!ButOk.Visible || vItemSelect == null)
                {
                    return;
                }
                if (vItemSelect.TileColor == eMetroTileColor.Orange)
                {
                    if (!string.IsNullOrEmpty(vItemSelect.TitleText) && !string.IsNullOrEmpty(vItemSelect.Tag.ToString()))
                    {
                        ToolStripMenuItem_Rep.Visible = true;
                        ToolStripMenuItem_Rep.Text = ((LangArEn == 0) ? "طبــاعـــة" : "Print");
                        ToolStripMenuItem_Op.Text = ((LangArEn == 0) ? "إفـراغ الطاولة" : "Clear");
                        if (db.StockRommID(int.Parse(vItemSelect.Tag.ToString())).T_INVHEDs.FirstOrDefault().InvTyp != 21)
                        {
                            goto IL_0240;
                        }
                    }
                }
                else if (vItemSelect.TileColor == eMetroTileColor.Yellow)
                {
                    if (!string.IsNullOrEmpty(vItemSelect.TitleText) && !string.IsNullOrEmpty(vItemSelect.Tag.ToString()))
                    {
                        ToolStripMenuItem_Op.Text = ((LangArEn == 0) ? "إلغاء تعطيل الطاولة" : "Clear");
                        goto IL_0240;
                    }
                }
                else if (vItemSelect.TileColor == eMetroTileColor.Gray && !string.IsNullOrEmpty(vItemSelect.TitleText) && !string.IsNullOrEmpty(vItemSelect.Tag.ToString()))
                {
                    ToolStripMenuItem_Op.Text = ((LangArEn == 0) ? "إلغاء حجز الطاولة" : "Clear");
                    goto IL_0240;
                }
                goto end_IL_0001;
            IL_0240:
                contextMenuStrip2.Show(Control.MousePosition);
            end_IL_0001:;
            }
            catch
            {
            }
        }
        private void ToolStripMenuItem_Op_Click(object sender, EventArgs e)
        {
            try
            {
                if (vItemSelect == null)
                {
                    return;
                }
                if (vItemSelect.TileColor == eMetroTileColor.Orange)
                {
                    if (!string.IsNullOrEmpty(vItemSelect.TitleText) && !string.IsNullOrEmpty(vItemSelect.Tag.ToString()))
                    {
                        if (db.StockRommID(int.Parse(vItemSelect.Tag.ToString())).T_INVHEDs.FirstOrDefault().InvTyp == 21)
                        {
                            return;
                        }
                        db.ExecuteCommand("UPDATE T_INVHED SET RoomNo = 1 ,RoomSts = 0,RoomPerson = 1 where RoomNo =" + int.Parse(vItemSelect.Tag.ToString()));
                        db.ExecuteCommand("UPDATE [T_Rooms] SET [RomeStatus] = 0, [waiterNo] = NULL Where ID =" + int.Parse(vItemSelect.Tag.ToString()));
                    }
                }
                else if (vItemSelect.TileColor == eMetroTileColor.Yellow)
                {
                    if (!string.IsNullOrEmpty(vItemSelect.TitleText) && !string.IsNullOrEmpty(vItemSelect.Tag.ToString()))
                    {
                        db.ExecuteCommand("UPDATE [T_Rooms] SET [Stop] = 0 Where ID =" + int.Parse(vItemSelect.Tag.ToString()));
                    }
                }
                else if (vItemSelect.TileColor == eMetroTileColor.Gray && !string.IsNullOrEmpty(vItemSelect.TitleText) && !string.IsNullOrEmpty(vItemSelect.Tag.ToString()))
                {
                    db.ExecuteCommand("UPDATE [T_Rooms] SET [reserved] = 0 Where ID =" + int.Parse(vItemSelect.Tag.ToString()));
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("ToolStripMenuItem_Op_Click:", error, enable: true);
                return;
            }
            VarGeneral.Tb_Return = true;
            Close();
        }
        private void GetInvSetting()
        {
            _InvSetting = new T_INVSETTING();
            _InvSetting = db.StockInvSetting( VarGeneral.InvTyp);
        }
        private int vStr(int vTy)
        {
            if (VarGeneral.InvTyp == 1)
            {
                if (VarGeneral._IsPOS)
                {
                    return 27;
                }
                return 1;
            }
            if (VarGeneral.InvTyp == 1)
            {
                return 1;
            }
            if (VarGeneral.InvTyp == 2)
            {
                return 5;
            }
            if (VarGeneral.InvTyp == 3)
            {
                return 3;
            }
            if (VarGeneral.InvTyp == 4)
            {
                return 7;
            }
            if (VarGeneral.InvTyp == 7)
            {
                return 9;
            }
            if (VarGeneral.InvTyp == 8)
            {
                return 11;
            }
            if (VarGeneral.InvTyp == 9)
            {
                return 13;
            }
            if (VarGeneral.InvTyp == 14)
            {
                return 15;
            }
            if (VarGeneral.InvTyp == 5)
            {
                return 17;
            }
            if (VarGeneral.InvTyp == 6)
            {
                return 19;
            }
            if (VarGeneral.InvTyp == 17)
            {
                return 21;
            }
            if (VarGeneral.InvTyp == 20)
            {
                return 23;
            }
            return 25;
        }
        private void ToolStripMenuItem_Rep_Click(object sender, EventArgs e)
        {
            VarGeneral.EmptyTablePrint = false;
            if (_InvSetting.InvpRINTERInfo.nTyp.Substring(0, 1) == "1")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = "T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID LEFT OUTER JOIN T_Rooms ON T_INVHED.RoomNo = T_Rooms.ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_INVHED.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_INVHED.InvCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_INVHED.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                string vInvH = " T_INVHED.InvHed_ID, T_INVHED.InvId as vID, T_INVHED.InvNo, T_INVHED.InvTyp, T_INVHED.InvCashPay, T_INVHED.CusVenNo,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Arb_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNm,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Eng_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNmE, T_INVHED.CusVenAdd, T_INVHED.CusVenTel, T_INVHED.Remark, T_INVHED.HDat, T_INVHED.GDat, T_INVHED.MndNo, T_INVHED.SalsManNo, T_INVHED.SalsManNam, T_INVHED.InvTot, T_INVHED.InvDisPrs, ((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.InvDisVal as InvDisValOnly,T_INVHED.DesPointsValue,T_INVHED.DesPointsValueLocCur,T_INVHED.PointsCount,T_INVHED.IsPoints, T_INVHED.InvNet, T_INVHED.InvNetLocCur, T_INVHED.CashPayLocCur, T_INVHED.IfRet, T_INVHED.CashPay, T_INVHED.InvTotLocCur, T_INVHED.InvDisValLocCur, T_INVHED.GadeNo, T_INVHED.GadeId, T_INVHED.RetNo, T_INVHED.RetId, T_INVHED.InvCashPayNm, T_INVHED.InvCost, T_INVHED.CustPri, T_INVHED.ArbTaf, T_INVHED.ToStore, T_INVHED.InvCash, T_INVHED.CurTyp, T_INVHED.EstDat,case when DATEDIFF(day, GETDATE(), EstDat) > 0 Then DATEDIFF(day, GETDATE(), EstDat) WHEN DATEDIFF(day, GETDATE(), InvCashPayNm) > 0 THEN DATEDIFF(day, GETDATE(), InvCashPayNm) Else '0' END as EstDatNote, T_INVHED.InvCstNo, T_INVHED.IfDel, T_INVHED.RefNo, T_INVHED.ToStoreNm, T_INVHED.EngTaf, T_INVHED.IfTrans, T_INVHED.InvQty, T_INVHED.CustNet, T_INVHED.CustRep, T_INVHED.InvWight_T, T_INVHED.IfPrint, T_INVHED.LTim, T_INVHED.DATE_CREATED, T_INVHED.MODIFIED_BY, T_INVHED.CreditPay, T_INVHED.DATE_MODIFIED, T_INVHED.CREATED_BY, T_INVHED.CreditPayLocCur, T_INVHED.NetworkPay, T_INVHED.NetworkPayLocCur, T_INVHED.MndExtrnal, T_INVHED.CompanyID, T_INVHED.InvAddCost, T_INVHED.InvAddCostExtrnal, T_INVHED.InvAddCostExtrnalLoc, T_INVHED.IsExtrnalGaid, T_INVHED.ExtrnalCostGaidID, T_INVHED.InvAddCostLoc, T_INVHED.CommMnd_Inv, T_INVHED.Puyaid, T_INVHED.Remming,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.PersonalNm from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as PersonalNm,T_SYSSETTING.LineGiftlNameA,T_SYSSETTING.LineGiftlNameE,T_Rooms.RomeNo";
                string Fields = " Abs(T_INVDET.Qty) as QtyAbs , T_INVDET.InvDet_ID, T_INVDET.InvNo, T_INVDET.InvId, T_INVDET.InvSer, T_INVDET.ItmNo, T_INVDET.Cost, T_INVDET.Qty, T_INVDET.ItmUnt, T_INVDET.ItmDes,T_INVDET.ItmDesE , T_INVDET.ItmUntE, T_INVDET.ItmUntPak, T_INVDET.StoreNo, T_INVDET.Price, T_INVDET.Amount, T_INVDET.RealQty, T_INVDET.ItmTyp,T_INVDET.ItmDis, (Abs(T_INVDET.Qty) *  T_INVDET.Price) * (T_INVDET.ItmDis / 100) as ItmDisVal, T_INVDET.DatExper, T_INVDET.itmInvDsc,ItmIndex ," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.LineGiftSts, vStr(VarGeneral.InvTyp)) ? " T_INVDET.ItmWight " : " 0 as ItmWight") + ", T_INVDET.ItmWight_T, T_INVDET.ItmAddCost, T_INVDET.RunCod, T_INVDET.LineDetails ,T_INVDET.Serial_Key, " + vInvH + ", T_Items.* , T_CstTbl.Arb_Des as CstTbl_Arb_Des , T_CstTbl.Eng_Des as CstTbl_Eng_Des , T_Mndob.Arb_Des as Mndob_Arb_Des , T_Mndob.Eng_Des as Mndob_Eng_Des,T_SYSSETTING.LogImg,(select max(T_AccDef.TaxNo) from T_AccDef where T_AccDef.AccDef_No = T_SYSSETTING.TaxAcc) as TaxAcc,T_SYSSETTING.TaxNoteInv,case when T_INVHED.IsTaxLines = 1 then (case when T_INVHED.IsTaxByTotal = 1 then (case when (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) > 0 then ((Abs(T_INVDET.Qty) *  T_INVDET.Price) - case when (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) > 0 then (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) else 0 end )* T_INVDET.ItmTax / 100   else 0 end) else (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) end) else 0 end as TaxValue ,(select InvNamA from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as InvNamA,(select InvNamE from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as InvNamE,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Mobile from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Mobile,(select T_Store.Arb_Des from T_Store where T_Store.Stor_ID = T_INVDET.StoreNo) as StoreNmA,(select T_Store.Eng_Des from T_Store where T_Store.Stor_ID = T_INVDET.StoreNo) as StoreNmE,(select defPrn from T_INVSETTING where CatID = (select ItmCat from T_Items where Itm_No = T_INVDET.ItmNo) ) as defPrn,case when T_INVHED.CusVenNo = '' THEN '0' ELSE (SELECT Sum(T_GDDET.gdValue) FROM T_GDHEAD INNER JOIN  T_GDDET ON T_GDHEAD.gdhead_ID = T_GDDET.gdID where T_GDDET.AccNo = T_INVHED.CusVenNo and T_GDHEAD.gdLok = 0 and (select T_AccDef.AccCat from T_AccDef where T_AccDef.AccDef_No = T_INVHED.CusVenNo) = '4') END as Balanc,T_INVDET.ItmTax,T_INVHED.InvAddTax,T_INVHED.InvAddTaxlLoc,T_INVHED.TaxGaidID,T_INVHED.IsTaxUse,T_INVHED.IsTaxLines,IsTaxByTotal,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.TaxNo from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as TaxCustNo";
                VarGeneral.HeaderRep[0] = Text;
                VarGeneral.HeaderRep[1] = "";
                VarGeneral.HeaderRep[2] = "";
                _RepShow.Rule = " where (T_INVHED.InvTyp = 21 or T_INVHED.InvTyp = 1) and T_INVHED.RoomNo > 1 and T_Rooms.RomeStatus = 1 and T_INVHED.RoomSts = 1 and T_INVHED.RoomNo = " + int.Parse(vItemSelect.Tag.ToString());
                if (!string.IsNullOrEmpty(Fields))
                {
                    _RepShow.Fields = Fields;
                    try
                    {
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                        _RepShow = new RepShow();
                        _RepShow.Rule = " WHERE T_Users.UsrNo = '" + VarGeneral.RepData.Tables[0].Rows[0]["SalsManNo"].ToString() + "'";
                        _RepShow.Tables = " T_Branch INNER JOIN T_Users ON T_Branch.Branch_no = T_Users.Brn ";
                        _RepShow.Fields = " T_Users.UsrNamA ,T_Branch.Branch_Name ,T_Users.UsrNamE ,T_Branch.Branch_NameE ,T_Users.UsrImg ";
                        try
                        {
                            VarGeneral.RepShowStock_Rat = "Rate";
                            _RepShow = _RepShow.Save();
                            VarGeneral.RepShowStock_Rat = "";
                        }
                        catch (Exception ex2)
                        {
                            VarGeneral.RepShowStock_Rat = "";
                            MessageBox.Show(ex2.Message);
                        }
                        _RepShow.RepData.Tables[0].Merge(VarGeneral.RepData.Tables[0]);
                        VarGeneral.RepData = _RepShow.RepData;
                        try
                        {
                            for (int j = 0; j < VarGeneral.RepData.Tables[0].Rows.Count; j++)
                            {
                                if (string.IsNullOrEmpty(VarGeneral.RepData.Tables[0].Rows[j]["LogImg"].ToString()))
                                {
                                    VarGeneral.RepData.Tables[0].Rows[j]["LogImg"] = VarGeneral.RepData.Tables[0].Rows[VarGeneral.RepData.Tables[0].Rows.Count - 1]["LogImg"];
                                    VarGeneral.RepData.Tables[0].Rows[j]["LTim"] = VarGeneral.RepData.Tables[0].Rows[VarGeneral.RepData.Tables[0].Rows.Count - 1]["LTim"];
                                }
                            }
                        }
                        catch
                        {
                        }
                        try
                        {
                            for (int j = 0; j < VarGeneral.RepData.Tables[0].Rows.Count; j++)
                            {
                                if (string.IsNullOrEmpty(VarGeneral.RepData.Tables[0].Rows[j]["UsrImg"].ToString()))
                                {
                                    try
                                    {
                                        VarGeneral.RepData.Tables[0].Rows[j]["UsrImg"] = VarGeneral.RepData.Tables[0].Rows[0]["UsrImg"];
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                        }
                        catch
                        {
                        }
                        try
                        {
                            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 15))
                            {
                                _RepShow = new RepShow();
                                _RepShow.Tables = "T_SINVDET LEFT OUTER JOIN T_INVHED ON T_SINVDET.SInvIdHEAD = T_INVHED.InvHed_ID LEFT OUTER JOIN T_Rooms ON T_INVHED.RoomNo = T_Rooms.ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_INVHED.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_INVHED.InvCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_INVHED.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_Items ON T_SINVDET.SItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                                _RepShow.Fields = " Abs(T_SINVDET.SQty) as QtyAbs , SInvDet_ID as InvId , SInvNo as InvNo, SInvId as InvDet_ID, SInvSer as InvSer,SItmNo as ItmNo, SCost as Cost, SQty as Qty, SItmDes as ItmDes, SItmUnt as ItmUnt, SItmDesE as ItmDesE, SItmUntE as ItmUntE, SItmUntPak as ItmUntPak, SStoreNo as StoreNo, (SPrice * 0) as Price, (SAmount * 0) as Amount, SRealQty as RealQty, SitmInvDsc as itmInvDsc, SDatExper as DatExper, SItmDis as ItmDis, SItmTyp as ItmTyp,SItmIndex as ItmIndex, SItmWight_T as ItmWight_T, SItmWight as ItmWight , T_INVHED.* , T_Items.* , T_CstTbl.Arb_Des as CstTbl_Arb_Des , T_CstTbl.Eng_Des as CstTbl_Eng_Des , T_Mndob.Arb_Des as Mndob_Arb_Des , T_Mndob.Eng_Des as Mndob_Eng_Des,T_SYSSETTING.LogImg,(select max(T_AccDef.TaxNo) from T_AccDef where T_AccDef.AccDef_No = T_SYSSETTING.TaxAcc) as TaxAcc,T_SYSSETTING.TaxNoteInv";
                                _RepShow.Rule = " where (T_INVHED.InvTyp = 21 or T_INVHED.InvTyp = 1) and T_INVHED.RoomNo > 1 and T_Rooms.RomeStatus = 1 and T_INVHED.RoomSts = 1 and T_INVHED.RoomNo = " + int.Parse(vItemSelect.Tag.ToString());
                                _RepShow = _RepShow.Save();
                                VarGeneral.RepData.Tables[0].Merge(_RepShow.RepData.Tables[0]);
                            }
                        }
                        catch
                        {
                        }
                    }
                    catch (Exception ex2)
                    {
                        MessageBox.Show(ex2.Message);
                    }
                    if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                    {
                        double sum1 = 0.0;
                        double sum11 = 0.0;
                        double sum12 = 0.0;
                        double sum13 = 0.0;
                        double sum14 = 0.0;
                        double sum15 = 0.0;
                        double sum16 = 0.0;
                        double sum17 = 0.0;
                        double sum18 = 0.0;
                        double sum2 = 0.0;
                        double sum3 = 0.0;
                        double sum4 = 0.0;
                        double sum5 = 0.0;
                        double sum6 = 0.0;
                        double sum7 = 0.0;
                        double sum8 = 0.0;
                        double sum9 = 0.0;
                        double sum10 = 0.0;
                        try
                        {
                            List<string> _list = new List<string>();
                            int i;
                            for (i = 0; i < VarGeneral.RepData.Tables[0].Rows.Count; i++)
                            {
                                try
                                {
                                    if (!string.IsNullOrEmpty(VarGeneral.RepData.Tables[0].Rows[i]["InvHed_ID"].ToString()) && string.IsNullOrEmpty(_list.Find((string x) => x == VarGeneral.RepData.Tables[0].Rows[i]["InvHed_ID"].ToString())))
                                    {
                                        _list.Add(VarGeneral.RepData.Tables[0].Rows[i]["InvHed_ID"].ToString());
                                        try
                                        {
                                            sum1 += double.Parse(VarGeneral.RepData.Tables[0].Rows[i]["InvTot"].ToString());
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            sum11 += double.Parse(VarGeneral.RepData.Tables[0].Rows[i]["InvTotLocCur"].ToString());
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            sum12 += double.Parse(VarGeneral.RepData.Tables[0].Rows[i]["InvDisVal"].ToString());
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            sum13 += double.Parse(VarGeneral.RepData.Tables[0].Rows[i]["InvDisValLocCur"].ToString());
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            sum14 += double.Parse(VarGeneral.RepData.Tables[0].Rows[i]["InvNet"].ToString());
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            sum15 += double.Parse(VarGeneral.RepData.Tables[0].Rows[i]["InvNetLocCur"].ToString());
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            sum16 += double.Parse(VarGeneral.RepData.Tables[0].Rows[i]["CashPay"].ToString());
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            sum17 += double.Parse(VarGeneral.RepData.Tables[0].Rows[i]["CashPayLocCur"].ToString());
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            sum18 += double.Parse(VarGeneral.RepData.Tables[0].Rows[i]["CreditPay"].ToString());
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            sum2 += double.Parse(VarGeneral.RepData.Tables[0].Rows[i]["CreditPayLocCur"].ToString());
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            sum3 += double.Parse(VarGeneral.RepData.Tables[0].Rows[i]["NetworkPay"].ToString());
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            sum4 += double.Parse(VarGeneral.RepData.Tables[0].Rows[i]["NetworkPayLocCur"].ToString());
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            sum5 += double.Parse(VarGeneral.RepData.Tables[0].Rows[i]["Puyaid"].ToString());
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            sum6 += double.Parse(VarGeneral.RepData.Tables[0].Rows[i]["Remming"].ToString());
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            sum7 += double.Parse(VarGeneral.RepData.Tables[0].Rows[i]["InvAddTax"].ToString());
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            sum8 += double.Parse(VarGeneral.RepData.Tables[0].Rows[i]["InvAddTaxlLoc"].ToString());
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            sum9 += double.Parse(VarGeneral.RepData.Tables[0].Rows[i]["InvDisPrs"].ToString());
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            sum10 += double.Parse(VarGeneral.RepData.Tables[0].Rows[i]["Puyaid"].ToString());
                                        }
                                        catch
                                        {
                                        }
                                    }
                                }
                                catch
                                {
                                }
                            }
                            for (int j = 0; j < VarGeneral.RepData.Tables[0].Rows.Count; j++)
                            {
                                foreach (DataRow dr in VarGeneral.RepData.Tables[0].Rows)
                                {
                                    VarGeneral.RepData.Tables[0].Rows[j]["InvTot"] = sum1;
                                    VarGeneral.RepData.Tables[0].Rows[j]["InvTotLocCur"] = sum11;
                                    VarGeneral.RepData.Tables[0].Rows[j]["InvDisVal"] = sum12;
                                    VarGeneral.RepData.Tables[0].Rows[j]["InvDisValLocCur"] = sum13;
                                    VarGeneral.RepData.Tables[0].Rows[j]["InvNet"] = sum14;
                                    VarGeneral.RepData.Tables[0].Rows[j]["InvNetLocCur"] = sum15;
                                    VarGeneral.RepData.Tables[0].Rows[j]["CashPay"] = sum16;
                                    VarGeneral.RepData.Tables[0].Rows[j]["CashPayLocCur"] = sum17;
                                    VarGeneral.RepData.Tables[0].Rows[j]["CreditPay"] = sum18;
                                    VarGeneral.RepData.Tables[0].Rows[j]["CreditPayLocCur"] = sum2;
                                    VarGeneral.RepData.Tables[0].Rows[j]["NetworkPay"] = sum3;
                                    VarGeneral.RepData.Tables[0].Rows[j]["NetworkPayLocCur"] = sum4;
                                    VarGeneral.RepData.Tables[0].Rows[j]["Puyaid"] = sum5;
                                    VarGeneral.RepData.Tables[0].Rows[j]["Remming"] = sum6;
                                    VarGeneral.RepData.Tables[0].Rows[j]["InvAddTax"] = sum7;
                                    VarGeneral.RepData.Tables[0].Rows[j]["InvAddTaxlLoc"] = sum8;
                                    VarGeneral.RepData.Tables[0].Rows[j]["InvDisPrs"] = sum9;
                                    VarGeneral.RepData.Tables[0].Rows[j]["Puyaid"] = sum10;
                                    if (double.Parse(VarGeneral.TString.TEmpty(VarGeneral.RepData.Tables[0].Rows[j]["Puyaid"].ToString())) > 0.0)
                                    {
                                        VarGeneral.RepData.Tables[0].Rows[j]["Remming"] = double.Parse(VarGeneral.TString.TEmpty(VarGeneral.RepData.Tables[0].Rows[j]["Puyaid"].ToString())) - double.Parse(VarGeneral.TString.TEmpty(VarGeneral.RepData.Tables[0].Rows[j]["InvNetLocCur"].ToString()));
                                    }
                                    else
                                    {
                                        VarGeneral.RepData.Tables[0].Rows[j]["Remming"] = 0;
                                    }
                                }
                            }
                            FrmReportsViewer frm = new FrmReportsViewer();
                            frm.Tag = LangArEn;
                            frm.BarcodSts = false;
                            VarGeneral.EmptyTablePrint = true;
                            if (_InvSetting.InvpRINTERInfo.nTyp.Substring(1, 1) == "1")
                            {
                                frm.Repvalue = "InvSal";
                            }
                            else
                            {
                                frm.RepCashier = "InvoiceCachier";
                            }
                            VarGeneral.vTitle = Text;
                            if (_InvSetting.InvpRINTERInfo.nTyp.Substring(2, 1) == "1")
                            {
                                frm._Proceess();
                            }
                            else
                            {
                                frm.TopMost = true;
                                frm.ShowDialog();
                            }
                        }
                        catch (Exception error)
                        {
                            VarGeneral.DebLog.writeLog("buttonItem_Print_Click:", error, enable: true);
                            MessageBox.Show(error.Message);
                        }
                    }
                }
            }
            VarGeneral.EmptyTablePrint = false;
        }
    }
}
