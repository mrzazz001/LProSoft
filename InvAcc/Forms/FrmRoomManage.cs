using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
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
    public partial  class FrmRoomManage : Form
    { void avs(int arln)

{ 
 Text = "superTabControl3";this.Text=   (arln == 0 ? "  superTabControl3  " : "  superTabControl3") ; Text = "إغلاق";this.Text=   (arln == 0 ? "  إغلاق  " : "  Close") ; Text = "حفظ";this.Text=   (arln == 0 ? "  حفظ  " : "  save") ;}
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
        private SuperGridControl SuperGrid_RoomDiagram;
        private SuperTabControl superTabControl_Main1;
        protected ButtonItem Button_Close;
        protected ButtonItem Button_Save;
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private T_AccDef _AccDefBind = new T_AccDef();
        private int LangArEn = 0;
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
#pragma warning disable CS0414 // The field 'FrmRoomManage.FlagUpdate' is assigned but its value is never used
        private string FlagUpdate = "";
#pragma warning restore CS0414 // The field 'FrmRoomManage.FlagUpdate' is assigned but its value is never used
        public ViewState ViewState = ViewState.Deiles;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private bool canUpdate = true;
        private List<string> pkeys = new List<string>();
        private Stock_DataDataContext dbInstance;
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
        public FrmRoomManage()
        {
            InitializeComponent();this.Load += langloads;
        }
        private void FrmRoomManage_Load(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    LangArEn = 0;
                }
                else
                {
                    LangArEn = 1;
                    Button_Close.Text = "Close";
                    Button_Save.Text = "Save";
                }
                SuperGrid_RoomDiagram.PrimaryGrid.Caption.Text = ((LangArEn == 0) ? "عدد الغرف / الشقق في الطابق" : "Number of rooms / apartments on the floor");
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
                    c.RowHeaderText = ((LangArEn == 0) ? "الطابق | " : "Floor | ") + (i + 1);
                    c.Cells.Add(new GridCell(""));
                    c.Cells.Add(new GridCell(""));
                    c.Cells.Add(new GridCell(""));
                    c.Cells[0].Value = _ReturnRoomFloor(vRoomChart[i].ID);
                    c.Cells[0].Tag = vRoomChart[i].ID;
                    SuperGrid_RoomDiagram.PrimaryGrid.Columns.Add(new GridColumn());
                    SuperGrid_RoomDiagram.PrimaryGrid.Columns[0].Width = 200;
                    SuperGrid_RoomDiagram.PrimaryGrid.Columns[0].HeaderText = ((LangArEn == 0) ? "عدد الغرف / الشقق" : "Number of Rooms / Flats");
                    SuperGrid_RoomDiagram.PrimaryGrid.Columns[0].CellStyles.Default.Background.Color1 = Color.Silver;
                    SuperGrid_RoomDiagram.PrimaryGrid.Columns[0].EditorType = typeof(GridIntegerInputEditControl);
                    c.Cells[1].Value = vRoomChart[i].FName;
                    c.Cells[1].Tag = "";
                    SuperGrid_RoomDiagram.PrimaryGrid.Columns.Add(new GridColumn());
                    SuperGrid_RoomDiagram.PrimaryGrid.Columns[1].Width = 200;
                    SuperGrid_RoomDiagram.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "إسم الطابق العربي" : "Arabic Floor Name");
                    SuperGrid_RoomDiagram.PrimaryGrid.Columns[1].CellStyles.Default.Background.Color1 = Color.Silver;
                    SuperGrid_RoomDiagram.PrimaryGrid.Columns[1].EditorType = typeof(GridTextBoxXEditControl);
                    c.Cells[2].Value = vRoomChart[i].FNameE;
                    c.Cells[2].Tag = "";
                    SuperGrid_RoomDiagram.PrimaryGrid.Columns.Add(new GridColumn());
                    SuperGrid_RoomDiagram.PrimaryGrid.Columns[2].Width = 200;
                    SuperGrid_RoomDiagram.PrimaryGrid.Columns[2].HeaderText = ((LangArEn == 0) ? "إسم الطابق الإنجليزي" : "English Floor Name");
                    SuperGrid_RoomDiagram.PrimaryGrid.Columns[2].CellStyles.Default.Background.Color1 = Color.Silver;
                    SuperGrid_RoomDiagram.PrimaryGrid.Columns[2].EditorType = typeof(GridTextBoxXEditControl);
                    SuperGrid_RoomDiagram.PrimaryGrid.Rows.Add(c);
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private int _ReturnRoomFloor(int id)
        {
            List<T_RomChart> q = db.T_RomCharts.Where((T_RomChart t) => t.ID == id).ToList();
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
                    goto IL_012d;
                }
                List<int> q = items.Where((int c) => c <= 0 || c > 100).ToList();
                if (q.Count <= 0)
                {
                    goto IL_012d;
                }
                MessageBox.Show((LangArEn == 0) ? "تأكد من صحة أرقام الغرف .. ثم حاول مرة اخرى" : "Make sure the room numbers are correct .. then try again", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                goto end_IL_0001;
            IL_012d:
                List<T_Rom> _RoomSts = db.FillRoomWCondition();
                if (_RoomSts.Count > 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "هناك غرف / شقق عليها حركات معلقة يرجى افراغها .. ثم حاول مرة اخرى" : "There are rooms / apartments with suspended movements please empty it .. Then try again", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                List<T_Reserv> _ReservChk = db.ExecuteQuery<T_Reserv>("SELECT T_Reserv.ResrvNo, T_Reserv.Dat, T_Reserv.Rom, T_Reserv.Sts, T_Reserv.PerNm, T_Reserv.IdNo, T_Reserv.Nat , T_Reserv.Dat2 FROM T_Reserv where T_Reserv.sts=0 ", new object[0]).ToList();
                if (_ReservChk.Count > 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "هناك غرف / شقق عليها حركات معلقة يرجى افراغها .. ثم حاول مرة اخرى" : "There are rooms / apartments with suspended movements please empty it .. Then try again", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                int vRm = 0;
                db.ExecuteCommand("DELETE FROM [T_Rom]");
                foreach (GridRow rowCell in SuperGrid_RoomDiagram.PrimaryGrid.Rows)
                {
                    vRm++;
                    foreach (GridCell cell in rowCell.Cells)
                    {
                        if (string.IsNullOrEmpty(cell.Value.ToString()) || string.IsNullOrEmpty(cell.Tag.ToString()))
                        {
                            continue;
                        }
                        T_RomChart q2 = db.T_RomCharts.Where((T_RomChart t) => t.ID == int.Parse(cell.Tag.ToString())).ToList().FirstOrDefault();
                        if (q2 != null && q2.ID != 0)
                        {
                            if (int.Parse(cell.Value.ToString()) >= 1)
                            {
                                q2.col1 = int.Parse(vRm + "01");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "01, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col1 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 2)
                            {
                                q2.col2 = int.Parse(vRm + "02");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "02, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col2 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 3)
                            {
                                q2.col3 = int.Parse(vRm + "03");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "03, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col3 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 4)
                            {
                                q2.col4 = int.Parse(vRm + "04");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "04, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col4 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 5)
                            {
                                q2.col5 = int.Parse(vRm + "05");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "05, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col5 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 6)
                            {
                                q2.col6 = int.Parse(vRm + "06");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "06, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col6 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 7)
                            {
                                q2.col7 = int.Parse(vRm + "07");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "07, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col7 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 8)
                            {
                                q2.col8 = int.Parse(vRm + "08");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "08, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col8 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 9)
                            {
                                q2.col9 = int.Parse(vRm + "09");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "09, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col9 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 10)
                            {
                                q2.col10 = int.Parse(vRm + "010");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "010, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col10 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 11)
                            {
                                q2.col11 = int.Parse(vRm + "011");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "011, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col11 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 12)
                            {
                                q2.col12 = int.Parse(vRm + "012");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "012, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col12 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 13)
                            {
                                q2.col13 = int.Parse(vRm + "013");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "013, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col13 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 14)
                            {
                                q2.col14 = int.Parse(vRm + "014");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "014, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col14 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 15)
                            {
                                q2.col15 = int.Parse(vRm + "015");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "015, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col15 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 16)
                            {
                                q2.col16 = int.Parse(vRm + "016");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "016, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col16 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 17)
                            {
                                q2.col17 = int.Parse(vRm + "017");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "017, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col17 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 18)
                            {
                                q2.col18 = int.Parse(vRm + "018");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "018, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col18 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 19)
                            {
                                q2.col19 = int.Parse(vRm + "019");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "019, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col19 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 20)
                            {
                                q2.col20 = int.Parse(vRm + "020");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "020, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col20 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 21)
                            {
                                q2.col21 = int.Parse(vRm + "021");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "021, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col21 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 22)
                            {
                                q2.col22 = int.Parse(vRm + "022");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "022, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col22 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 23)
                            {
                                q2.col23 = int.Parse(vRm + "023");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "023, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col23 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 24)
                            {
                                q2.col24 = int.Parse(vRm + "024");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "024, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col24 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 25)
                            {
                                q2.col25 = int.Parse(vRm + "025");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "025, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col25 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 26)
                            {
                                q2.col26 = int.Parse(vRm + "026");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "026, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col26 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 27)
                            {
                                q2.col27 = int.Parse(vRm + "027");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "027, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col27 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 28)
                            {
                                q2.col28 = int.Parse(vRm + "028");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "028, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col28 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 29)
                            {
                                q2.col29 = int.Parse(vRm + "029");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "029, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col29 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 30)
                            {
                                q2.col30 = int.Parse(vRm + "030");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "030, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col30 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 31)
                            {
                                q2.col31 = int.Parse(vRm + "031");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "031, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col31 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 32)
                            {
                                q2.col32 = int.Parse(vRm + "032");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "032, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col32 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 33)
                            {
                                q2.col33 = int.Parse(vRm + "033");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "033, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col33 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 34)
                            {
                                q2.col34 = int.Parse(vRm + "034");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "034, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col34 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 35)
                            {
                                q2.col35 = int.Parse(vRm + "035");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "035, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col35 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 36)
                            {
                                q2.col36 = int.Parse(vRm + "036");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "036, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col36 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 37)
                            {
                                q2.col37 = int.Parse(vRm + "037");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "037, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col37 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 38)
                            {
                                q2.col38 = int.Parse(vRm + "038");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "038, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col38 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 39)
                            {
                                q2.col39 = int.Parse(vRm + "039");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "039, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col39 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 40)
                            {
                                q2.col40 = int.Parse(vRm + "040");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "040, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col40 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 41)
                            {
                                q2.col41 = int.Parse(vRm + "041");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "041, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col41 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 42)
                            {
                                q2.col42 = int.Parse(vRm + "042");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "042, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col42 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 43)
                            {
                                q2.col43 = int.Parse(vRm + "043");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "043, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col43 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 44)
                            {
                                q2.col44 = int.Parse(vRm + "044");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "044, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col44 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 45)
                            {
                                q2.col45 = int.Parse(vRm + "045");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "045, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col45 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 46)
                            {
                                q2.col46 = int.Parse(vRm + "046");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "046, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col46 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 47)
                            {
                                q2.col47 = int.Parse(vRm + "047");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "047, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col47 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 48)
                            {
                                q2.col48 = int.Parse(vRm + "048");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "048, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col48 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 49)
                            {
                                q2.col49 = int.Parse(vRm + "049");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "049, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col49 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 50)
                            {
                                q2.col50 = int.Parse(vRm + "050");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "050, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col50 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 51)
                            {
                                q2.col51 = int.Parse(vRm + "051");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "051, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col51 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 52)
                            {
                                q2.col52 = int.Parse(vRm + "052");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "052, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col52 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 53)
                            {
                                q2.col53 = int.Parse(vRm + "053");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "053, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col53 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 54)
                            {
                                q2.col54 = int.Parse(vRm + "054");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "054, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col54 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 55)
                            {
                                q2.col55 = int.Parse(vRm + "055");
                                q2.col56 = int.Parse(vRm + "056");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "055, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col55 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 56)
                            {
                                q2.col56 = int.Parse(vRm + "056");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "056, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col56 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 57)
                            {
                                q2.col57 = int.Parse(vRm + "057");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "057, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col57 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 58)
                            {
                                q2.col58 = int.Parse(vRm + "058");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "058, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col58 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 59)
                            {
                                q2.col59 = int.Parse(vRm + "059");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "059, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col59 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 60)
                            {
                                q2.col60 = int.Parse(vRm + "060");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "060, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col60 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 61)
                            {
                                q2.col61 = int.Parse(vRm + "061");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "061, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col61 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 62)
                            {
                                q2.col62 = int.Parse(vRm + "062");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "062, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col62 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 63)
                            {
                                q2.col63 = int.Parse(vRm + "063");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "063, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col63 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 64)
                            {
                                q2.col64 = int.Parse(vRm + "064");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "064, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col64 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 65)
                            {
                                q2.col65 = int.Parse(vRm + "065");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "065, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col65 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 66)
                            {
                                q2.col66 = int.Parse(vRm + "066");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "066, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col66 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 67)
                            {
                                q2.col67 = int.Parse(vRm + "067");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "067, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col67 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 68)
                            {
                                q2.col68 = int.Parse(vRm + "068");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "068, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col68 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 69)
                            {
                                q2.col69 = int.Parse(vRm + "069");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "069, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col69 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 70)
                            {
                                q2.col70 = int.Parse(vRm + "070");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "070, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col70 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 71)
                            {
                                q2.col71 = int.Parse(vRm + "071");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "071, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col71 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 72)
                            {
                                q2.col72 = int.Parse(vRm + "072");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "072, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col72 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 73)
                            {
                                q2.col73 = int.Parse(vRm + "073");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "073, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col73 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 74)
                            {
                                q2.col74 = int.Parse(vRm + "074");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "074, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col74 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 75)
                            {
                                q2.col75 = int.Parse(vRm + "075");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "075, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col75 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 76)
                            {
                                q2.col76 = int.Parse(vRm + "076");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "076, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col76 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 77)
                            {
                                q2.col77 = int.Parse(vRm + "077");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "077, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col77 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 78)
                            {
                                q2.col78 = int.Parse(vRm + "078");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "078, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col78 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 79)
                            {
                                q2.col79 = int.Parse(vRm + "079");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "079, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col79 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 80)
                            {
                                q2.col80 = int.Parse(vRm + "080");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "080, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col80 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 81)
                            {
                                q2.col81 = int.Parse(vRm + "081");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "081, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col81 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 82)
                            {
                                q2.col82 = int.Parse(vRm + "082");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "082, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col82 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 83)
                            {
                                q2.col83 = int.Parse(vRm + "083");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "083, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col83 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 84)
                            {
                                q2.col84 = int.Parse(vRm + "084");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "084, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col84 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 85)
                            {
                                q2.col85 = int.Parse(vRm + "085");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "085, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col85 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 86)
                            {
                                q2.col86 = int.Parse(vRm + "086");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "086, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col86 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 87)
                            {
                                q2.col87 = int.Parse(vRm + "087");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "087, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col87 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 88)
                            {
                                q2.col88 = int.Parse(vRm + "088");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "088, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col88 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 89)
                            {
                                q2.col89 = int.Parse(vRm + "089");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "089, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col89 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 90)
                            {
                                q2.col90 = int.Parse(vRm + "090");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "090, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col90 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 91)
                            {
                                q2.col91 = int.Parse(vRm + "091");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "091, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col91 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 92)
                            {
                                q2.col92 = int.Parse(vRm + "092");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "092, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col92 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 93)
                            {
                                q2.col93 = int.Parse(vRm + "093");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "093, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col93 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 94)
                            {
                                q2.col94 = int.Parse(vRm + "094");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "094, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col94 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 95)
                            {
                                q2.col95 = int.Parse(vRm + "095");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "095, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col95 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 96)
                            {
                                q2.col96 = int.Parse(vRm + "096");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "096, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col96 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 97)
                            {
                                q2.col97 = int.Parse(vRm + "097");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "097, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col97 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 98)
                            {
                                q2.col98 = int.Parse(vRm + "098");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "098, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col98 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 99)
                            {
                                q2.col99 = int.Parse(vRm + "099");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "099, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col99 = 0;
                            }
                            if (int.Parse(cell.Value.ToString()) >= 100)
                            {
                                q2.col100 = int.Parse(vRm + "0100");
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + vRm.ToString() + "0100, " + q2.ID + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            }
                            else
                            {
                                q2.col100 = 0;
                            }
                            db.Log = VarGeneral.DebugLog;
                            db.SubmitChanges(ConflictMode.ContinueOnConflict);
                        }
                    }
                }
                for (int i = 0; i < SuperGrid_RoomDiagram.PrimaryGrid.Rows.Count; i++)
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(SuperGrid_RoomDiagram.GetCell(i, 1).Value.ToString()) && !string.IsNullOrEmpty(SuperGrid_RoomDiagram.GetCell(i, 2).Value.ToString()) && !string.IsNullOrEmpty(SuperGrid_RoomDiagram.GetCell(i, 0).Tag.ToString()))
                        {
                            db.ExecuteCommand("UPDATE [dbo].[T_RomChart] SET [FName] = '" + SuperGrid_RoomDiagram.GetCell(i, 1).Value.ToString() + "' ,[FNameE] = '" + SuperGrid_RoomDiagram.GetCell(i, 2).Value.ToString() + "' Where ID = " + SuperGrid_RoomDiagram.GetCell(i, 0).Tag.ToString());
                        }
                    }
                    catch
                    {
                    }
                }
                Button_Close_Click(sender, e);
            end_IL_0001:;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Save:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
    }
}
