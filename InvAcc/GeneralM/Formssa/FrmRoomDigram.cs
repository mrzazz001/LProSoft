using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
using InvAcc.GeneralM;
using InvAcc.Properties;
using InvAcc.Stock_Data;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmRoomDigram : Form
    {
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
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private T_AccDef _AccDefBind = new T_AccDef();
        private int LangArEn = 0;
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
        private string FlagUpdate = string.Empty;
        public ViewState ViewState = ViewState.Deiles;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private bool canUpdate = true;
        private List<string> pkeys = new List<string>();
        private Stock_DataDataContext dbInstance;
        private IContainer components = null;
        private SuperGridControl SuperGrid_RoomDiagram;
        private SuperTabControl superTabControl_Main1;
        protected ButtonItem Button_Close;
        protected ButtonItem Button_Save;
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
        private void Frm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode != Keys.F2 || !Button_Save.Enabled || !Button_Save.Visible || State == FormState.Saved) && e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        public FrmRoomDigram()
        {
            InitializeComponent();
        }
        private int _ReturnRoomFloor(int id)
        {
            Stock_DataDataContext DBx = new Stock_DataDataContext(VarGeneral.BranchCS);
            List<T_RomChart> q = DBx.T_RomCharts.Where((T_RomChart t) => t.ID == id).ToList();
            List<int> c = new List<int>();
            if (q.FirstOrDefault().col1.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col2.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col3.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col4.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col5.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col6.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col7.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col8.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col9.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col10.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col11.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col12.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col13.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col14.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col15.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col16.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col17.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col18.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col19.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col20.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col21.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col22.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col23.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col24.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col25.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col26.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col27.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col28.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col29.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col30.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col31.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col32.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col33.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col34.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col35.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col36.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col37.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col38.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col39.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col40.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col41.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col42.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col43.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col44.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col45.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col46.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col47.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col48.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col49.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col50.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col51.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col52.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col53.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col54.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col55.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col56.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col57.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col58.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col59.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col60.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col61.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col62.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col63.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col64.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col65.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col66.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col67.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col68.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col69.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col70.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col71.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col72.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col73.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col74.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col75.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col76.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col77.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col78.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col79.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col80.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col81.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col82.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col83.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col84.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col85.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col86.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col87.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col88.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col89.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col90.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col91.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col92.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col93.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col94.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col95.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col96.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col97.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col98.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col99.Value > 0)
            {
                c.Add(1);
            }
            if (q.FirstOrDefault().col100.Value > 0)
            {
                c.Add(1);
            }
            return c.Count;
        }
        private void FrmRoomDigram_Load(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    LangArEn = 0;
                }
                else
                {
                    LangArEn = 1;
                    Button_Close.Text = "Close";
                    Button_Save.Text = "Save";
                }
                SuperGrid_RoomDiagram.PrimaryGrid.Caption.Text = ((LangArEn == 0) ? "تعيين مسمي\u0651ات أرقام الغرف / الشقق" : "Appointment of room / apartment number names");
                List<T_Rom> _RoomSts = db.FillRoomWCondition();
                if (_RoomSts.Count > 0)
                {
                    Button_Save.Visible = false;
                }
                List<T_RomChart> vRoomChart = db.T_RomCharts.OrderBy((T_RomChart t) => t.ID).ToList();
                for (int i = 0; i < vRoomChart.Count; i++)
                {
                    GridRow c = new GridRow();
                    c.RowHeight = VarGeneral.Settings_Sys.Fld_H.Value;
                    c.RowHeaderText = ((LangArEn == 0) ? vRoomChart[i].FName : vRoomChart[i].FNameE);
                    int _RoomOfFloor = _ReturnRoomFloor(vRoomChart[i].ID);
                    for (int j = 0; j < _RoomOfFloor; j++)
                    {
                        c.Cells.Add(new GridCell(string.Empty));
                        switch (j)
                        {
                            case 0:
                                c.Cells[j].Value = vRoomChart[i].col1;
                                c.Cells[j].Tag = vRoomChart[i].col1;
                                break;
                            case 1:
                                c.Cells[j].Value = vRoomChart[i].col2;
                                c.Cells[j].Tag = vRoomChart[i].col2;
                                break;
                            case 2:
                                c.Cells[j].Value = vRoomChart[i].col3;
                                c.Cells[j].Tag = vRoomChart[i].col3;
                                break;
                            case 3:
                                c.Cells[j].Value = vRoomChart[i].col4;
                                c.Cells[j].Tag = vRoomChart[i].col4;
                                break;
                            case 4:
                                c.Cells[j].Value = vRoomChart[i].col5;
                                c.Cells[j].Tag = vRoomChart[i].col5;
                                break;
                            case 5:
                                c.Cells[j].Value = vRoomChart[i].col6;
                                c.Cells[j].Tag = vRoomChart[i].col6;
                                break;
                            case 6:
                                c.Cells[j].Value = vRoomChart[i].col7;
                                c.Cells[j].Tag = vRoomChart[i].col7;
                                break;
                            case 7:
                                c.Cells[j].Value = vRoomChart[i].col8;
                                c.Cells[j].Tag = vRoomChart[i].col8;
                                break;
                            case 8:
                                c.Cells[j].Value = vRoomChart[i].col9;
                                c.Cells[j].Tag = vRoomChart[i].col9;
                                break;
                            case 9:
                                c.Cells[j].Value = vRoomChart[i].col10;
                                c.Cells[j].Tag = vRoomChart[i].col10;
                                break;
                            case 10:
                                c.Cells[j].Value = vRoomChart[i].col11;
                                c.Cells[j].Tag = vRoomChart[i].col11;
                                break;
                            case 11:
                                c.Cells[j].Value = vRoomChart[i].col12;
                                c.Cells[j].Tag = vRoomChart[i].col12;
                                break;
                            case 12:
                                c.Cells[j].Value = vRoomChart[i].col13;
                                c.Cells[j].Tag = vRoomChart[i].col13;
                                break;
                            case 13:
                                c.Cells[j].Value = vRoomChart[i].col14;
                                c.Cells[j].Tag = vRoomChart[i].col14;
                                break;
                            case 14:
                                c.Cells[j].Value = vRoomChart[i].col15;
                                c.Cells[j].Tag = vRoomChart[i].col15;
                                break;
                            case 15:
                                c.Cells[j].Value = vRoomChart[i].col16;
                                c.Cells[j].Tag = vRoomChart[i].col16;
                                break;
                            case 16:
                                c.Cells[j].Value = vRoomChart[i].col17;
                                c.Cells[j].Tag = vRoomChart[i].col17;
                                break;
                            case 17:
                                c.Cells[j].Value = vRoomChart[i].col18;
                                c.Cells[j].Tag = vRoomChart[i].col18;
                                break;
                            case 18:
                                c.Cells[j].Value = vRoomChart[i].col19;
                                c.Cells[j].Tag = vRoomChart[i].col19;
                                break;
                            case 19:
                                c.Cells[j].Value = vRoomChart[i].col20;
                                c.Cells[j].Tag = vRoomChart[i].col20;
                                break;
                            case 20:
                                c.Cells[j].Value = vRoomChart[i].col21;
                                c.Cells[j].Tag = vRoomChart[i].col21;
                                break;
                            case 21:
                                c.Cells[j].Value = vRoomChart[i].col22;
                                c.Cells[j].Tag = vRoomChart[i].col22;
                                break;
                            case 22:
                                c.Cells[j].Value = vRoomChart[i].col23;
                                c.Cells[j].Tag = vRoomChart[i].col23;
                                break;
                            case 23:
                                c.Cells[j].Value = vRoomChart[i].col24;
                                c.Cells[j].Tag = vRoomChart[i].col24;
                                break;
                            case 24:
                                c.Cells[j].Value = vRoomChart[i].col25;
                                c.Cells[j].Tag = vRoomChart[i].col25;
                                break;
                            case 25:
                                c.Cells[j].Value = vRoomChart[i].col26;
                                c.Cells[j].Tag = vRoomChart[i].col26;
                                break;
                            case 26:
                                c.Cells[j].Value = vRoomChart[i].col27;
                                c.Cells[j].Tag = vRoomChart[i].col27;
                                break;
                            case 27:
                                c.Cells[j].Value = vRoomChart[i].col28;
                                c.Cells[j].Tag = vRoomChart[i].col28;
                                break;
                            case 28:
                                c.Cells[j].Value = vRoomChart[i].col29;
                                c.Cells[j].Tag = vRoomChart[i].col29;
                                break;
                            case 29:
                                c.Cells[j].Value = vRoomChart[i].col30;
                                c.Cells[j].Tag = vRoomChart[i].col30;
                                break;
                            case 30:
                                c.Cells[j].Value = vRoomChart[i].col31;
                                c.Cells[j].Tag = vRoomChart[i].col31;
                                break;
                            case 31:
                                c.Cells[j].Value = vRoomChart[i].col32;
                                c.Cells[j].Tag = vRoomChart[i].col32;
                                break;
                            case 32:
                                c.Cells[j].Value = vRoomChart[i].col33;
                                c.Cells[j].Tag = vRoomChart[i].col33;
                                break;
                            case 33:
                                c.Cells[j].Value = vRoomChart[i].col34;
                                c.Cells[j].Tag = vRoomChart[i].col34;
                                break;
                            case 34:
                                c.Cells[j].Value = vRoomChart[i].col35;
                                c.Cells[j].Tag = vRoomChart[i].col35;
                                break;
                            case 35:
                                c.Cells[j].Value = vRoomChart[i].col36;
                                c.Cells[j].Tag = vRoomChart[i].col36;
                                break;
                            case 36:
                                c.Cells[j].Value = vRoomChart[i].col37;
                                c.Cells[j].Tag = vRoomChart[i].col37;
                                break;
                            case 37:
                                c.Cells[j].Value = vRoomChart[i].col38;
                                c.Cells[j].Tag = vRoomChart[i].col38;
                                break;
                            case 38:
                                c.Cells[j].Value = vRoomChart[i].col39;
                                c.Cells[j].Tag = vRoomChart[i].col39;
                                break;
                            case 39:
                                c.Cells[j].Value = vRoomChart[i].col40;
                                c.Cells[j].Tag = vRoomChart[i].col40;
                                break;
                            case 40:
                                c.Cells[j].Value = vRoomChart[i].col41;
                                c.Cells[j].Tag = vRoomChart[i].col41;
                                break;
                            case 41:
                                c.Cells[j].Value = vRoomChart[i].col42;
                                c.Cells[j].Tag = vRoomChart[i].col42;
                                break;
                            case 42:
                                c.Cells[j].Value = vRoomChart[i].col43;
                                c.Cells[j].Tag = vRoomChart[i].col43;
                                break;
                            case 43:
                                c.Cells[j].Value = vRoomChart[i].col44;
                                c.Cells[j].Tag = vRoomChart[i].col44;
                                break;
                            case 44:
                                c.Cells[j].Value = vRoomChart[i].col45;
                                c.Cells[j].Tag = vRoomChart[i].col45;
                                break;
                            case 45:
                                c.Cells[j].Value = vRoomChart[i].col46;
                                c.Cells[j].Tag = vRoomChart[i].col46;
                                break;
                            case 46:
                                c.Cells[j].Value = vRoomChart[i].col47;
                                c.Cells[j].Tag = vRoomChart[i].col47;
                                break;
                            case 47:
                                c.Cells[j].Value = vRoomChart[i].col48;
                                c.Cells[j].Tag = vRoomChart[i].col48;
                                break;
                            case 48:
                                c.Cells[j].Value = vRoomChart[i].col49;
                                c.Cells[j].Tag = vRoomChart[i].col49;
                                break;
                            case 49:
                                c.Cells[j].Value = vRoomChart[i].col50;
                                c.Cells[j].Tag = vRoomChart[i].col50;
                                break;
                            case 50:
                                c.Cells[j].Value = vRoomChart[i].col51;
                                c.Cells[j].Tag = vRoomChart[i].col51;
                                break;
                            case 51:
                                c.Cells[j].Value = vRoomChart[i].col52;
                                c.Cells[j].Tag = vRoomChart[i].col52;
                                break;
                            case 52:
                                c.Cells[j].Value = vRoomChart[i].col53;
                                c.Cells[j].Tag = vRoomChart[i].col53;
                                break;
                            case 53:
                                c.Cells[j].Value = vRoomChart[i].col54;
                                c.Cells[j].Tag = vRoomChart[i].col54;
                                break;
                            case 54:
                                c.Cells[j].Value = vRoomChart[i].col55;
                                c.Cells[j].Tag = vRoomChart[i].col55;
                                break;
                            case 55:
                                c.Cells[j].Value = vRoomChart[i].col56;
                                c.Cells[j].Tag = vRoomChart[i].col56;
                                break;
                            case 56:
                                c.Cells[j].Value = vRoomChart[i].col57;
                                c.Cells[j].Tag = vRoomChart[i].col57;
                                break;
                            case 57:
                                c.Cells[j].Value = vRoomChart[i].col58;
                                c.Cells[j].Tag = vRoomChart[i].col58;
                                break;
                            case 58:
                                c.Cells[j].Value = vRoomChart[i].col59;
                                c.Cells[j].Tag = vRoomChart[i].col59;
                                break;
                            case 59:
                                c.Cells[j].Value = vRoomChart[i].col60;
                                c.Cells[j].Tag = vRoomChart[i].col60;
                                break;
                            case 60:
                                c.Cells[j].Value = vRoomChart[i].col61;
                                c.Cells[j].Tag = vRoomChart[i].col61;
                                break;
                            case 61:
                                c.Cells[j].Value = vRoomChart[i].col62;
                                c.Cells[j].Tag = vRoomChart[i].col62;
                                break;
                            case 62:
                                c.Cells[j].Value = vRoomChart[i].col63;
                                c.Cells[j].Tag = vRoomChart[i].col63;
                                break;
                            case 63:
                                c.Cells[j].Value = vRoomChart[i].col64;
                                c.Cells[j].Tag = vRoomChart[i].col64;
                                break;
                            case 64:
                                c.Cells[j].Value = vRoomChart[i].col65;
                                c.Cells[j].Tag = vRoomChart[i].col65;
                                break;
                            case 65:
                                c.Cells[j].Value = vRoomChart[i].col66;
                                c.Cells[j].Tag = vRoomChart[i].col66;
                                break;
                            case 66:
                                c.Cells[j].Value = vRoomChart[i].col67;
                                c.Cells[j].Tag = vRoomChart[i].col67;
                                break;
                            case 67:
                                c.Cells[j].Value = vRoomChart[i].col68;
                                c.Cells[j].Tag = vRoomChart[i].col68;
                                break;
                            case 68:
                                c.Cells[j].Value = vRoomChart[i].col69;
                                c.Cells[j].Tag = vRoomChart[i].col69;
                                break;
                            case 69:
                                c.Cells[j].Value = vRoomChart[i].col70;
                                c.Cells[j].Tag = vRoomChart[i].col70;
                                break;
                            case 70:
                                c.Cells[j].Value = vRoomChart[i].col71;
                                c.Cells[j].Tag = vRoomChart[i].col71;
                                break;
                            case 71:
                                c.Cells[j].Value = vRoomChart[i].col72;
                                c.Cells[j].Tag = vRoomChart[i].col72;
                                break;
                            case 72:
                                c.Cells[j].Value = vRoomChart[i].col73;
                                c.Cells[j].Tag = vRoomChart[i].col73;
                                break;
                            case 73:
                                c.Cells[j].Value = vRoomChart[i].col74;
                                c.Cells[j].Tag = vRoomChart[i].col74;
                                break;
                            case 74:
                                c.Cells[j].Value = vRoomChart[i].col75;
                                c.Cells[j].Tag = vRoomChart[i].col75;
                                break;
                            case 75:
                                c.Cells[j].Value = vRoomChart[i].col76;
                                c.Cells[j].Tag = vRoomChart[i].col76;
                                break;
                            case 76:
                                c.Cells[j].Value = vRoomChart[i].col77;
                                c.Cells[j].Tag = vRoomChart[i].col77;
                                break;
                            case 77:
                                c.Cells[j].Value = vRoomChart[i].col78;
                                c.Cells[j].Tag = vRoomChart[i].col78;
                                break;
                            case 78:
                                c.Cells[j].Value = vRoomChart[i].col79;
                                c.Cells[j].Tag = vRoomChart[i].col79;
                                break;
                            case 79:
                                c.Cells[j].Value = vRoomChart[i].col80;
                                c.Cells[j].Tag = vRoomChart[i].col80;
                                break;
                            case 80:
                                c.Cells[j].Value = vRoomChart[i].col81;
                                c.Cells[j].Tag = vRoomChart[i].col81;
                                break;
                            case 81:
                                c.Cells[j].Value = vRoomChart[i].col82;
                                c.Cells[j].Tag = vRoomChart[i].col82;
                                break;
                            case 82:
                                c.Cells[j].Value = vRoomChart[i].col83;
                                c.Cells[j].Tag = vRoomChart[i].col83;
                                break;
                            case 83:
                                c.Cells[j].Value = vRoomChart[i].col84;
                                c.Cells[j].Tag = vRoomChart[i].col84;
                                break;
                            case 84:
                                c.Cells[j].Value = vRoomChart[i].col85;
                                c.Cells[j].Tag = vRoomChart[i].col85;
                                break;
                            case 85:
                                c.Cells[j].Value = vRoomChart[i].col86;
                                c.Cells[j].Tag = vRoomChart[i].col86;
                                break;
                            case 86:
                                c.Cells[j].Value = vRoomChart[i].col87;
                                c.Cells[j].Tag = vRoomChart[i].col87;
                                break;
                            case 87:
                                c.Cells[j].Value = vRoomChart[i].col88;
                                c.Cells[j].Tag = vRoomChart[i].col88;
                                break;
                            case 88:
                                c.Cells[j].Value = vRoomChart[i].col89;
                                c.Cells[j].Tag = vRoomChart[i].col89;
                                break;
                            case 89:
                                c.Cells[j].Value = vRoomChart[i].col90;
                                c.Cells[j].Tag = vRoomChart[i].col90;
                                break;
                            case 90:
                                c.Cells[j].Value = vRoomChart[i].col91;
                                c.Cells[j].Tag = vRoomChart[i].col91;
                                break;
                            case 91:
                                c.Cells[j].Value = vRoomChart[i].col92;
                                c.Cells[j].Tag = vRoomChart[i].col92;
                                break;
                            case 92:
                                c.Cells[j].Value = vRoomChart[i].col93;
                                c.Cells[j].Tag = vRoomChart[i].col93;
                                break;
                            case 93:
                                c.Cells[j].Value = vRoomChart[i].col94;
                                c.Cells[j].Tag = vRoomChart[i].col94;
                                break;
                            case 94:
                                c.Cells[j].Value = vRoomChart[i].col95;
                                c.Cells[j].Tag = vRoomChart[i].col95;
                                break;
                            case 95:
                                c.Cells[j].Value = vRoomChart[i].col96;
                                c.Cells[j].Tag = vRoomChart[i].col96;
                                break;
                            case 96:
                                c.Cells[j].Value = vRoomChart[i].col97;
                                c.Cells[j].Tag = vRoomChart[i].col97;
                                break;
                            case 97:
                                c.Cells[j].Value = vRoomChart[i].col98;
                                c.Cells[j].Tag = vRoomChart[i].col98;
                                break;
                            case 98:
                                c.Cells[j].Value = vRoomChart[i].col99;
                                c.Cells[j].Tag = vRoomChart[i].col99;
                                break;
                            case 99:
                                c.Cells[j].Value = vRoomChart[i].col100;
                                c.Cells[j].Tag = vRoomChart[i].col100;
                                break;
                        }
                        if (SuperGrid_RoomDiagram.PrimaryGrid.Columns.Count < _RoomOfFloor)
                        {
                            SuperGrid_RoomDiagram.PrimaryGrid.Columns.Add(new GridColumn());
                            SuperGrid_RoomDiagram.PrimaryGrid.Columns[j].Width = VarGeneral.Settings_Sys.Fld_w.Value;
                            SuperGrid_RoomDiagram.PrimaryGrid.Columns[j].CellStyles.Default.Background.Color1 = Color.Silver;
                            SuperGrid_RoomDiagram.PrimaryGrid.Columns[j].CellStyles.Default.Image = Resources._104_128;
                            SuperGrid_RoomDiagram.PrimaryGrid.Columns[j].EditorType = typeof(GridIntegerInputEditControl);
                        }
                    }
                    SuperGrid_RoomDiagram.PrimaryGrid.Rows.Add(c);
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        public void SplashStart()
        {
            Application.Run(new FrmImports());
        }
        private void Button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> items = new List<int>();
                foreach (GridRow dr in SuperGrid_RoomDiagram.PrimaryGrid.Rows)
                {
                    foreach (GridCell dc in dr.Cells)
                    {
                        try
                        {
                            items.Add(int.Parse(dc.Value.ToString()));
                        }
                        catch
                        {
                        }
                    }
                }
                if (items.Count <= 0)
                {
                    goto IL_01bb;
                }
                List<int> q = items.Where((int c) => c <= 0).ToList();
                if (q.Count > 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "تأكد من صحة أرقام الغرف .. ثم حاول مرة اخرى" : "Make sure the room numbers are correct .. then try again", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                List<int> duplicates = (from s in items
                                        group s by s).SelectMany((IGrouping<int, int> grp) => grp.Skip(1)).ToList();
                if (duplicates.Count <= 0)
                {
                    goto IL_01bb;
                }
                MessageBox.Show((LangArEn == 0) ? "تأكد من صحة أرقام الغرف .. ثم حاول مرة اخرى" : "Make sure the room numbers are correct .. then try again", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                goto end_IL_0001;
                IL_01bb:
                foreach (GridRow rowCell in SuperGrid_RoomDiagram.PrimaryGrid.Rows)
                {
                    foreach (GridCell cell in rowCell.Cells)
                    {
                        if (string.IsNullOrEmpty(cell.Value.ToString()) || string.IsNullOrEmpty(cell.Tag.ToString()))
                        {
                            continue;
                        }
                        db.ExecuteCommand(string.Concat(" UPDATE [T_Rom] SET [romno] = ", cell.Value, " WHERE [romno] =", int.Parse(cell.Tag.ToString())));
                        T_RomChart q2 = db.StockRoomChart(int.Parse(cell.Tag.ToString()));
                        if (q2 == null || q2.ID == 0)
                        {
                            continue;
                        }
                        if (q2.col1.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col1 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col2.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col2 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col3.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col3 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col4.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col4 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col5.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col5 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col6.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col6 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col7.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col7 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col8.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col8 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col9.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col9 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col10.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col10 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col11.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col11 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col12.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col12 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col13.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col13 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col14.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col14 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col15.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col15 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col16.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col16 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col17.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col17 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col18.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col18 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col19.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col19 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col20.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col20 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col21.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col21 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col22.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col22 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col23.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col23 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col24.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col24 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col25.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col25 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col26.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col26 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col27.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col27 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col28.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col28 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col29.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col29 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col30.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col30 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col31.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col31 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col32.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col32 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col33.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col33 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col34.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col34 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col35.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col35 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col36.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col36 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col37.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col37 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col38.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col38 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col39.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col39 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col40.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col40 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col41.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col41 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col42.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col42 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col43.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col43 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col44.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col44 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col45.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col45 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col46.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col46 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col47.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col47 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col48.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col48 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col49.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col49 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col50.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col50 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col51.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col51 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col52.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col52 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col53.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col54 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col55.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col55 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col56.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col56 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col57.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col57 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col58.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col58 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col59.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col59 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col60.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col60 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col61.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col61 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col62.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col62 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col63.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col64 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col65.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col65 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col66.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col66 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col67.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col67 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col68.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col68 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col69.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col69 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col70.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col70 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col71.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col71 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col72.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col72 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col73.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col73 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col74.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col74 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col75.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col75 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col76.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col76 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col77.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col77 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col78.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col78 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col79.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col79 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col80.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col80 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col81.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col81 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col82.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col82 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col83.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col83 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col84.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col84 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col85.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col85 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col86.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col86 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col87.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col87 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col88.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col88 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col89.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col89 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col90.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col90 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col91.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col91 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col92.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col92 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col93.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col93 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col94.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col94 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col95.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col95 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col96.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col96 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col97.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col97 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col98.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col98 = int.Parse(cell.Value.ToString());
                        }
                        else if (q2.col99.Value == int.Parse(cell.Tag.ToString()))
                        {
                            q2.col99 = int.Parse(cell.Value.ToString());
                        }
                        else
                        {
                            if (q2.col100.Value != int.Parse(cell.Tag.ToString()))
                            {
                                continue;
                            }
                            q2.col100 = int.Parse(cell.Value.ToString());
                        }
                        db.Log = VarGeneral.DebugLog;
                        db.SubmitChanges(ConflictMode.ContinueOnConflict);
                        Button_Close_Click(sender, e);
                    }
                }
                end_IL_0001:;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Save:", error, enable: true);
                MessageBox.Show(error.Message);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmRoomDigram));
            SuperGrid_RoomDiagram = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            superTabControl_Main1 = new DevComponents.DotNetBar.SuperTabControl();
            Button_Close = new DevComponents.DotNetBar.ButtonItem();
            Button_Save = new DevComponents.DotNetBar.ButtonItem();
            ((System.ComponentModel.ISupportInitialize)superTabControl_Main1).BeginInit();
            SuspendLayout();
            SuperGrid_RoomDiagram.Dock = System.Windows.Forms.DockStyle.Fill;
            SuperGrid_RoomDiagram.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            SuperGrid_RoomDiagram.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            SuperGrid_RoomDiagram.Location = new System.Drawing.Point(0, 0);
            SuperGrid_RoomDiagram.Name = "SuperGrid_RoomDiagram";
            SuperGrid_RoomDiagram.PrimaryGrid.ColumnHeader.Visible = false;
            SuperGrid_RoomDiagram.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            SuperGrid_RoomDiagram.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            SuperGrid_RoomDiagram.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            SuperGrid_RoomDiagram.PrimaryGrid.DefaultVisualStyles.ColumnHeaderRowStyles.Default.RowHeader.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            SuperGrid_RoomDiagram.PrimaryGrid.DefaultVisualStyles.RowStyles.Default.RowHeaderStyle.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            SuperGrid_RoomDiagram.PrimaryGrid.DefaultVisualStyles.RowStyles.Default.RowHeaderStyle.TextColor = System.Drawing.Color.FromArgb(192, 0, 0);
            SuperGrid_RoomDiagram.PrimaryGrid.InitialActiveRow = DevComponents.DotNetBar.SuperGrid.RelativeRow.None;
            SuperGrid_RoomDiagram.PrimaryGrid.InitialSelection = DevComponents.DotNetBar.SuperGrid.RelativeSelection.None;
            SuperGrid_RoomDiagram.PrimaryGrid.MaxRowHeight = 1000;
            SuperGrid_RoomDiagram.PrimaryGrid.MinRowHeight = 50;
            SuperGrid_RoomDiagram.PrimaryGrid.MultiSelect = false;
            SuperGrid_RoomDiagram.PrimaryGrid.RowHeaderWidth = 100;
            SuperGrid_RoomDiagram.PrimaryGrid.ShowColumnHeader = false;
            SuperGrid_RoomDiagram.Size = new System.Drawing.Size(709, 409);
            SuperGrid_RoomDiagram.TabIndex = 1197;
            superTabControl_Main1.BackColor = System.Drawing.Color.White;
            superTabControl_Main1.CausesValidation = false;
            superTabControl_Main1.ControlBox.CloseBox.Name = string.Empty;
            superTabControl_Main1.ControlBox.MenuBox.Name = string.Empty;
            superTabControl_Main1.ControlBox.Name = string.Empty;
            superTabControl_Main1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[2]
            {
                superTabControl_Main1.ControlBox.MenuBox,
                superTabControl_Main1.ControlBox.CloseBox
            });
            superTabControl_Main1.ControlBox.Visible = false;
            superTabControl_Main1.Dock = System.Windows.Forms.DockStyle.Bottom;
            superTabControl_Main1.ForeColor = System.Drawing.Color.Black;
            superTabControl_Main1.ItemPadding.Bottom = 4;
            superTabControl_Main1.ItemPadding.Left = 2;
            superTabControl_Main1.ItemPadding.Top = 4;
            superTabControl_Main1.Location = new System.Drawing.Point(0, 409);
            superTabControl_Main1.Name = "superTabControl_Main1";
            superTabControl_Main1.ReorderTabsEnabled = true;
            superTabControl_Main1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            superTabControl_Main1.SelectedTabFont = new System.Drawing.Font("Tahoma", 8f, System.Drawing.FontStyle.Bold);
            superTabControl_Main1.SelectedTabIndex = -1;
            superTabControl_Main1.Size = new System.Drawing.Size(709, 51);
            superTabControl_Main1.TabFont = new System.Drawing.Font("Tahoma", 8f);
            superTabControl_Main1.TabIndex = 1198;
            superTabControl_Main1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[2]
            {
                Button_Close,
                Button_Save
            });
            superTabControl_Main1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            superTabControl_Main1.Text = "superTabControl3";
            superTabControl_Main1.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            Button_Close.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            Button_Close.Checked = true;
            Button_Close.FontBold = true;
            Button_Close.FontItalic = true;
            Button_Close.ForeColor = System.Drawing.Color.Black;
            Button_Close.Image = (System.Drawing.Image)resources.GetObject("Button_Close.Image");
            Button_Close.ImageFixedSize = new System.Drawing.Size(28, 28);
            Button_Close.ImagePaddingHorizontal = 15;
            Button_Close.ImagePaddingVertical = 11;
            Button_Close.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            Button_Close.Name = "Button_Close";
            Button_Close.Stretch = true;
            Button_Close.SubItemsExpandWidth = 14;
            Button_Close.Symbol = "\uf057";
            Button_Close.SymbolSize = 15f;
            Button_Close.Text = "إغلاق";
            Button_Close.Tooltip = "إغلاق النافذة الحالية";
            Button_Close.Click += new System.EventHandler(Button_Close_Click);
            Button_Save.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            Button_Save.FontBold = true;
            Button_Save.FontItalic = true;
            Button_Save.ForeColor = System.Drawing.Color.FromArgb(192, 64, 0);
            Button_Save.Image = (System.Drawing.Image)resources.GetObject("Button_Save.Image");
            Button_Save.ImageFixedSize = new System.Drawing.Size(28, 28);
            Button_Save.ImagePaddingHorizontal = 15;
            Button_Save.ImagePaddingVertical = 11;
            Button_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            Button_Save.Name = "Button_Save";
            Button_Save.Stretch = true;
            Button_Save.SubItemsExpandWidth = 14;
            Button_Save.Symbol = "\uf0c7";
            Button_Save.SymbolSize = 15f;
            Button_Save.Text = "حفظ";
            Button_Save.Tooltip = "حفظ التغييرات";
            Button_Save.Click += new System.EventHandler(Button_Save_Click);
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            base.ClientSize = new System.Drawing.Size(709, 460);
            base.ControlBox = false;
            base.Controls.Add(SuperGrid_RoomDiagram);
            base.Controls.Add(superTabControl_Main1);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            base.KeyPreview = true;
            base.Name = "FrmRoomDigram";
            RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            RightToLeftLayout = true;
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            base.Load += new System.EventHandler(FrmRoomDigram_Load);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Frm_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(Frm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)superTabControl_Main1).EndInit();
            ResumeLayout(false);
        }
    }
}
