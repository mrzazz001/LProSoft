using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmShowReserv : Form
    { void avs(int arln)

{ 
}
        private void langloads(object sender, EventArgs e)
        {
              avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
        }
   
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
       // private IContainer components = null;
        private PanelEx Frame1;
        private Label label8;
        private Label label5;
        private Label label6;
        private Label label3;
        private Label label4;
        private Label label2;
        private Label label1;
        private Label Label2_6;
        private Label Label2_5;
        private Label Label2_4;
        private Label Label2_3;
        private Label Label2_2;
        private Label Label2_1;
        private Label Label2_0;
        private ButtonX Option1_0;
        private ButtonX Option1_2;
        private ButtonX Option1_1;
        private ButtonX button_Close;
        private ButtonX button_Save;
        public C1FlexGrid VS;
        private ButtonX buttonExt;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem sdfaToolStripMenuItem_Option0;
        private ToolStripMenuItem sdfaToolStripMenuItem_Option2;
        private ToolStripMenuItem sdfaToolStripMenuItem_Option1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private int LangArEn = 0;
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
#pragma warning disable CS0414 // The field 'FrmShowReserv.FlagUpdate' is assigned but its value is never used
        private string FlagUpdate = "";
#pragma warning restore CS0414 // The field 'FrmShowReserv.FlagUpdate' is assigned but its value is never used
        public ViewState ViewState = ViewState.Deiles;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private bool canUpdate = true;
#pragma warning disable CS0414 // The field 'FrmShowReserv.ControlNo' is assigned but its value is never used
        private int ControlNo = 0;
#pragma warning restore CS0414 // The field 'FrmShowReserv.ControlNo' is assigned but its value is never used
        private List<string> pkeys = new List<string>();
        private Stock_DataDataContext dbInstance;
        private T_INVHED data_this;
#pragma warning disable CS0414 // The field 'FrmShowReserv.vRow' is assigned but its value is never used
        private int vRow = 0;
#pragma warning restore CS0414 // The field 'FrmShowReserv.vRow' is assigned but its value is never used
        private int bb = 0;
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
        public T_INVHED DataThis
        {
            get
            {
                return data_this;
            }
            set
            {
                data_this = value;
            }
        }
        public FrmShowReserv()
        {
            InitializeComponent();this.Load += langloads;
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                sdfaToolStripMenuItem_Option0.Text = "إستخدام حجز";
                sdfaToolStripMenuItem_Option1.Text = "إلغــاء حجـــز";
                sdfaToolStripMenuItem_Option2.Text = "تعديل حجـــز";
                Text = "الحجوزات";
                return;
            }
            VS.Cols[0].Caption = "*";
            VS.Cols[1].Caption = "Reserv No";
            VS.Cols[2].Caption = "Date";
            VS.Cols[3].Caption = "Name";
            VS.Cols[4].Caption = "Nationality";
            VS.Cols[5].Caption = "ID No";
            VS.Cols[6].Caption = "Room No";
            VS.Cols[7].Caption = "Status";
            VS.Cols[9].Caption = "Leave Date";
            sdfaToolStripMenuItem_Option0.Text = "Reservation Use";
            sdfaToolStripMenuItem_Option1.Text = "Reservation Cancel";
            sdfaToolStripMenuItem_Option2.Text = "Reservation Edit";
            buttonExt.Text = "Close";
            Text = "Reservations";
        }
        private void FrmShowReserv_Load(object sender, EventArgs e)
        {
            Frame1.Visible = false;
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                LangArEn = 0;
            }
            else
            {
                LangArEn = 1;
            }
            RibunButtons();
        }
        private void button_Close_Click(object sender, EventArgs e)
        {
            VS.RowSel = 0;
            VS.Enabled = true;
            Frame1.Visible = false;
        }
        private void FrmShowReserv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (Frame1.Visible)
                {
                    button_Close_Click(sender, e);
                }
                else
                {
                    Close();
                }
            }
        }
        private void Option1_0_Click(object sender, EventArgs e)
        {
            if (!Option1_0.Checked)
            {
                Option1_0.Checked = true;
                return;
            }
            Option1_0.Checked = true;
            Option1_1.Checked = false;
            Option1_2.Checked = false;
        }
        private void Option1_1_Click(object sender, EventArgs e)
        {
            if (!Option1_1.Checked)
            {
                Option1_1.Checked = true;
                return;
            }
            Option1_0.Checked = false;
            Option1_1.Checked = true;
            Option1_2.Checked = false;
        }
        private void Option1_2_Click(object sender, EventArgs e)
        {
            if (!Option1_2.Checked)
            {
                Option1_2.Checked = true;
                return;
            }
            Option1_0.Checked = false;
            Option1_1.Checked = false;
            Option1_2.Checked = true;
        }
        private void button_Save_Click(object sender, EventArgs e)
        {
            if (Option1_0.Checked)
            {
                VarGeneral.SndTyp = 2;
                List<T_Reserv> rsTmp = db.ExecuteQuery<T_Reserv>("select * from T_Reserv where ResrvNo=" + Label2_0.Text, new object[0]).ToList();
                VarGeneral.FormSend = int.Parse(Label2_0.Text);
                if (rsTmp.FirstOrDefault().Nat.HasValue)
                {
                    VarGeneral.Tmp1 = rsTmp.FirstOrDefault().Nat.Value.ToString();
                }
                else
                {
                    VarGeneral.Tmp1 = "";
                }
                VarGeneral.Tmp2 = Label2_2.Text;
                VarGeneral.Tmp3 = Label2_4.Text;
                VarGeneral.Tmp4 = int.Parse(Label2_5.Text);
                VarGeneral.Tmp6 = Label2_0.Text;
                VarGeneral.Tmp7 = rsTmp.FirstOrDefault().DayImport.Value.ToString();
                bb = 1;
                VarGeneral._hotelrom = rsTmp.FirstOrDefault().Rom.Value;
                VarGeneral._hotelper = 0;
                if (!string.IsNullOrEmpty(VarGeneral.Tmp4.ToString()) && db.StockRoom(VarGeneral.Tmp4).state.Value != 1)
                {
                    MessageBox.Show((LangArEn == 0) ? ("رقم : " + VarGeneral.Tmp4 + " مشغولة الآن .. يرجى المحاولة مرة اخرى") : ("Eye number: " + VarGeneral.Tmp4 + " busy now .. please try again"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    bb = 0;
                }
                else
                {
                    Close();
                }
            }
            else if (Option1_1.Checked)
            {
                if (MessageBox.Show("هل أنت متاكد من إلغاء الحجز رقم [" + Label2_0.Text + "]؟ \n Are you sure that you want to cancel reservation No [" + Label2_0.Text + "]?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
                {
                    List<T_Reserv> q = db.T_Reservs.Where((T_Reserv t) => t.ResrvNo == int.Parse(Label2_0.Text)).ToList();
                    if (q.Count > 0)
                    {
                        q[0].Sts = 2;
                        db.Log = VarGeneral.DebugLog;
                        db.SubmitChanges(ConflictMode.ContinueOnConflict);
                        bb = 2;
                        Close();
                    }
                }
            }
            else if (Option1_2.Checked)
            {
                VarGeneral.SndTyp = 2;
                VarGeneral.FormSend = int.Parse(Label2_0.Text);
                bb = 3;
                Close();
            }
        }
        private void FrmShowReserv_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
        private void FrmShowReserv_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (bb == 1)
            {
                VarGeneral.vGuestData = 1;
                VarGeneral._hotelper = 0;
                FrmGuests frm2 = new FrmGuests();
                frm2.Tag = LangArEn;
                frm2.TopMost = true;
                frm2.ShowDialog();
            }
            else if (bb == 3)
            {
                FrmResv frm = new FrmResv();
                frm.Tag = LangArEn;
                frm.TopMost = true;
                frm.ShowDialog();
            }
        }
        private void Frame1_VisibleChanged(object sender, EventArgs e)
        {
            if (Frame1.Visible)
            {
                bb = 0;
            }
        }
        private void buttonExt_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void contextMenuStrip1_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            button_Close_Click(sender, e);
        }
        private void sdfaToolStripMenuItem_Option0_Click(object sender, EventArgs e)
        {
            Option1_0.Checked = true;
            Option1_1.Checked = false;
            Option1_2.Checked = false;
            button_Save_Click(sender, e);
        }
        private void sdfaToolStripMenuItem_Option1_Click(object sender, EventArgs e)
        {
            Option1_0.Checked = false;
            Option1_1.Checked = true;
            Option1_2.Checked = false;
            button_Save_Click(sender, e);
        }
        private void sdfaToolStripMenuItem_Option2_Click(object sender, EventArgs e)
        {
            Option1_0.Checked = false;
            Option1_1.Checked = false;
            Option1_2.Checked = true;
            button_Save_Click(sender, e);
        }
        private void VS_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(VS.GetData(VS.RowSel, 1).ToString()) > 0)
                {
                    Label2_0.Text = VS.GetData(VS.RowSel, 1).ToString();
                    Label2_1.Text = VS.GetData(VS.RowSel, 2).ToString();
                    Label2_2.Text = VS.GetData(VS.RowSel, 3).ToString();
                    Label2_3.Text = VS.GetData(VS.RowSel, 4).ToString();
                    Label2_4.Text = VS.GetData(VS.RowSel, 5).ToString();
                    Label2_5.Text = VS.GetData(VS.RowSel, 6).ToString();
                    Label2_6.Text = VS.GetData(VS.RowSel, 7).ToString();
                    if (VS.GetData(VS.RowSel, 8).ToString() == "0")
                    {
                        Label2_0.Enabled = true;
                        Option1_1.Enabled = true;
                        Option1_2.Enabled = true;
                        button_Save.Enabled = true;
                    }
                    else
                    {
                        Option1_0.Enabled = false;
                        Option1_1.Enabled = false;
                        Option1_2.Enabled = false;
                        button_Save.Enabled = false;
                    }
                    Frame1.Visible = true;
                    VS.Enabled = false;
                    contextMenuStrip1.Show(Control.MousePosition);
                }
            }
            catch
            {
            }
            VS.RowSel = 0;
        }
    }
}
