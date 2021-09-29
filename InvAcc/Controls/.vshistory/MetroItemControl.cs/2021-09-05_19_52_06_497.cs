using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;
using InvAcc.GeneralM;
using InvAcc.Properties;
using InvAcc.Stock_Data;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace InvAcc.Controls
{
    public partial class MetroItemControl : UserControl
    {
        public MetroItemControl()
        {
            InitializeComponent();//

        }
        public void init()
        {
            db = new Stock_DataDataContext(VarGeneral.BranchCS);
            listUnit = db.T_Units.ToList<T_Unit>();
            List<T_CATEGORY> cats = db.T_CATEGORies.ToList<T_CATEGORY>();
            int k = 0;
            foreach (T_CATEGORY i in cats)
            {

                if (k == 0)
                {
                    k++;

                    superTabItem_Customer.Text = i.Arb_Des;
                    FillItems(i.CAT_ID, itemContainer_Customer);
                }
                else
                {
                    ItemContainer itc = new ItemContainer();
                    itc.TitleStyle.BackColor = System.Drawing.Color.AliceBlue;
                    itc.TitleStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
                    itc.TitleStyle.BorderBottomWidth = 1;
                    itc.TitleStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                    itc.TitleStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
                    itc.TitleStyle.BorderLeftWidth = 1;
                    itc.TitleStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
                    itc.TitleStyle.BorderRightWidth = 1;
                    itc.TitleStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
                    itc.TitleStyle.BorderTopWidth = 1;
                    itc.TitleStyle.Class = "MetroTileGroupTitle";
                    itc.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
                    itc.TitleStyle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
                    itc.TitleStyle.MarginBottom = 5;
                    itc.TitleStyle.MarginLeft = 5;
                    itc.TitleStyle.MarginRight = 5;
                    itc.TitleStyle.MarginTop = 5;
                    itc.TitleStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
                    itc.TitleStyle.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                    itc.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;

                    MetroTilePanel me = new MetroTilePanel();

                    me.BackColor = System.Drawing.Color.PowderBlue;
                    // 
                    // 
                    // 
                    me.BackgroundStyle.Class = "RibbonFileMenuTwoColumnContainer";
                    me.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
                    me.ContainerControlProcessDialogKey = true;
                    me.Dock = System.Windows.Forms.DockStyle.Fill;
                    me.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Right;
                    me.ImageSize = DevComponents.DotNetBar.eBarImageSize.Medium;
                    me.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
           itc});
                    me.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
                    me.Tag= "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
                    me.Location = new System.Drawing.Point(0, 0);
                    me.MultiLine = true;

                    me.Size = new System.Drawing.Size(798, 359);
                    me.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
                    me.TabIndex = 1132;
                    me.BackColor = metroTilePanel_Customer.BackColor;
                    me.BackgroundImage = metroTilePanel_Customer.BackgroundImage;
                    SuperTabControlPanel tab = new SuperTabControlPanel();

                    tab.Dock = System.Windows.Forms.DockStyle.Fill;
                    tab.Location = new System.Drawing.Point(0, 61);

                    tab.Size = new System.Drawing.Size(798, 359);
                    tab.TabIndex = 1;

                    tab.Text = ".";


                    tab.Controls.Add(me);


                    SuperTabItem it = new SuperTabItem();


                    tab.TabItem = it;
                    it.Text = i.Arb_Des;
                    it.AttachedControl = tab;

                    it.GlobalItem = false;
                    superTabControl_Tables.Controls.Add(tab);



                    this.superTabControl_Tables.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
          it });


                    FillItems(i.CAT_ID, itc);
                }

            }


        }
        public int vTy_ = 0;
        public string Serach_No = string.Empty;
        public string sts_ = string.Empty;
        private string vNo = string.Empty;
        private int vTyp = 0;
        private bool frmSts_ = false;
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private int LangArEn = 0;
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRt;
        private MetroTileItem vItemSelect = new MetroTileItem();
        private Stock_DataDataContext db
        ;

        List<T_Unit> listUnit;
        private void FillItems(int Cat_ID, ItemContainer itmcontainer)
        {
            try
            {
                itmcontainer.SubItems.Clear();

                {
                    List<T_Item> LAccDef = new List<T_Item>();
                    if (true)
                    {
                        LAccDef = (from item in db.T_Items
                                   where item.ItmCat.Value == Cat_ID
                                   select item).ToList();
                    }
                    else
                    {
                    }
                    for (int i = 0; i < LAccDef.Count; i++)
                    {
                        T_Item _Items = LAccDef[i];

                        MetroTileItem vTable = new MetroTileItem();
                        vTable.Image = Resources.Customer;
                        vTable.ImageTextAlignment = ContentAlignment.MiddleCenter;
                        vTable.SymbolColor = Color.Empty;
                        vTable.TileColor = eMetroTileColor.Azure;
                        vTable.TileSize = new Size(160, 140);
                        vTable.TileStyle.CornerType = eCornerType.Diagonal;
                        vTable.TitleText = LAccDef[i].Arb_Des.ToString();
                        vTable.Tag = LAccDef[i].Itm_No.ToString();
                        vTable.TitleTextAlignment = ContentAlignment.BottomCenter;
                        vTable.TitleTextFont = new Font("Tahoma", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
                        DevComponents.DotNetBar.ComboBoxItem cmbunit = new ComboBoxItem();
                        T_Unit _Unit;
                        List<T_Unit> ITmunits = new List<T_Unit>();
                        for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                        {
                            _Unit = listUnit[iiCnt];
                            if (_Items.Unit1 == _Unit.Unit_ID)
                            {
                                ITmunits.Add(_Unit);

                            }
                            if (_Items.Unit2 == _Unit.Unit_ID)
                            {
                                ITmunits.Add(_Unit);//   cmbunit.Items.Add(_Unit.Arb_Des);

                            }
                            if (_Items.T_Unit3.Unit_ID == _Unit.Unit_ID)
                            {
                                ITmunits.Add(_Unit); //cmbunit.Items.Add(_Unit.Arb_Des);

                            }
                            if (_Items.Unit4 == _Unit.Unit_ID)
                            {
                                ITmunits.Add(_Unit); //cmbunit.Items.Add(_Unit.Arb_Des);

                            }
                            if (_Items.Unit5 == _Unit.Unit_ID)
                            {
                                ITmunits.Add(_Unit);// cmbunit.Items.Add(_Unit.Arb_Des);

                            }


                        }
                        if (ITmunits.Count > 0)
                        {
                            cmbunit.ComboBoxEx.DataSource = ITmunits;
                            cmbunit.ComboBoxEx.DisplayMember = "Arb_Des";
                            cmbunit.ComboBoxEx.ValueMember = "Unit_No";
                            cmbunit.Tag = _Items.Itm_ID.ToString();
                            cmbunit.SelectedIndexChanged += Unit_SelectedChanged;
                            vTable.SubItems.Add(cmbunit);
                            vTable.ShowSubItems = true;
                        }

                        DevComponents.Editors.DoubleInput TxtPrice = new DevComponents.Editors.DoubleInput();

                        TxtPrice.ValueChanged += value_changed;

                        TxtPrice.Tag = _Items.Itm_ID.ToString();
                        PanelEx it = new PanelEx();
                        it.Controls.Add(TxtPrice);
                        vTable.Click += itemclick;
                        itmcontainer.SubItems.AddRange(new BaseItem[1]
                        {
                            vTable
                        });
                    }

                }

                Refresh();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("FillItems:", error, enable: true);
                itmcontainer.SubItems.Clear();
                Refresh();
            }
        }

        private void itemclick(object sender, EventArgs e)
        {

        }

        private void value_changed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TextPriceInput(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Price_Keydown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Unit_SelectedChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MetroItemControl_Load(object sender, EventArgs e)
        {

        }

        private void checkBox_ByName_Click(object sender, EventArgs e)
        {

        }

        private void superTabControl_Tables_SelectedTabChanged(object sender, SuperTabStripSelectedTabChangedEventArgs e)
        {

        }

        private void metroTilePanel_Customer_ItemClick(object sender, EventArgs e)
        {

        }
    }
}
