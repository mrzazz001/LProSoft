using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ProShared.Stock_Data;
using DevExpress.XtraBars.Navigation;
using ProShared.GeneralM;

namespace InvAcc.Controls.POS
{
    public partial class Xfrm : DevExpress.XtraEditors.XtraForm
    {
        public Xfrm()
        {
            InitializeComponent();
        }

        internal void init()
        {
        //    throw new NotImplementedException();
        }
        List<T_Unit> list = new List<T_Unit>();
        private void metroItemControl1_Load(object sender, EventArgs e)
        {

        }
        List<T_Unit> units=new List<T_Unit>();
        private void Xfrm_Load(object sender, EventArgs e)
        { 
            units.AddRange(VarGeneral.dbshared.T_Units.ToList());
            foreach (T_Unit i in units)
            {
                TileBarItem k = new TileBarItem();
                k.TextAlignment = TileItemContentAlignment.MiddleCenter;
                k.AppearanceItem.Normal.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
                k.AppearanceItem.Selected.BackColor = Color.Yellow;
                k.Text = i.Arb_Des;
                k.Tag = i.Unit_ID;
                tileBarGroup2.Items.Add(k);
            }
        }

        private void tileBar2_Click(object sender, EventArgs e)
        {

        }

        private void UntPri1TextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void labelControl4_Click(object sender, EventArgs e)
        {

        }

        private void Pack1TextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void TextBarCode_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void tileBar1_Click(object sender, EventArgs e)
        {

        }

        private void tileBar2_ItemClick(object sender, TileItemEventArgs e)
        {
            TileItem k = e.Item;
            int i = int.Parse(k.Tag.ToString()) - 1;
            navigationFrame1.SelectedPageIndex = i;
        }

        private void tileBar3_ItemClick(object sender, TileItemEventArgs e)
        {
            TileItem k = e.Item;
            int i = int.Parse(k.Tag.ToString());
            T_Unit kks = units.Where(s => s.Unit_ID == i).FirstOrDefault();
            units.Remove(kks);
            tileBarGroup1.Items[navigationFrame1.SelectedPageIndex].Text = (tileBarGroup1.Items[navigationFrame1.SelectedPageIndex].Text + "( " + kks.Arb_Des + " )");


        }

        private void tileBar5_MouseLeave(object sender, EventArgs e)
        {

        }

        private void navigationPage1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tileBar1_DoubleClick(object sender, EventArgs e)
        {
            
          
        }

        private void tileBar1_ItemDoubleClick(object sender, TileItemEventArgs e)
        {
            TileItem ks = e.Item;
            int ie = int.Parse(ks.Tag.ToString());
            T_Unit kks = units.Where(s => s.Unit_ID == ie).FirstOrDefault();
            units.Remove(kks);
            tileBarGroup1.Items[navigationFrame1.SelectedPageIndex].Text = (tileBarGroup1.Items[navigationFrame1.SelectedPageIndex].Text + "( " + kks.Arb_Des + " )");
            tileBarGroup2.Items.Clear();
            foreach (T_Unit i in units)
            {
                TileBarItem k = new TileBarItem();
                k.TextAlignment = TileItemContentAlignment.MiddleCenter;
                k.AppearanceItem.Normal.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
                k.AppearanceItem.Selected.BackColor = Color.Yellow;
                k.Text = i.Arb_Des;
                k.Tag = i.Unit_ID;
                tileBarGroup2.Items.Add(k);
            }
        }
    }
}