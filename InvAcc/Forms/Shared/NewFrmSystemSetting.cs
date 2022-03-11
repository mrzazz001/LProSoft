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
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using SSSDateTime.Date;
using C1.Util.Localization;
using System.IO;
using System.Threading;
using System.Globalization;
using Microsoft.Win32;
using C1.Win.C1FlexGrid;
using System.IO.Ports;
using SSSLanguage;
using SSSDateTime.Date;
using System.Globalization;
using Language = SSSLanguage.Language;
using System.Data.Linq;
using InvAcc.Properties;
using System.Drawing.Imaging;
using DevComponents.DotNetBar;

namespace InvAcc.Forms.Shared
{
    public partial class NewFrmSystemSetting : DevExpress.XtraEditors.XtraForm
    {
        private void textBox_BackupElectronic_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHeadingR1_TextChanged(object sender, EventArgs e)
        {
        }

        private void splitContainer4_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void button_EnterImg_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|TIFF Files (*.tiff)|*.tiff|BMP Files (*.bmp)|*.bmp";
                try
                {
                    if (VarGeneral.gUserName == "runsetting")
                    {
                        openFileDialog1.InitialDirectory = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
                    }
                }
                catch
                {
                }
                openFileDialog1.ShowDialog();
                string mypic_path = openFileDialog1.FileName;
                if (File.Exists(mypic_path))
                {
                    PicItemImg.Image = Image.FromFile(mypic_path);
                    Bitmap OriginalBM = new Bitmap(PicItemImg.Image);
                    PicItemImg.Image = OriginalBM;
                }
                Button_Edit_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button_ClearPic_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            PicItemImg.Image = null;
        }
        private void superTabControlPanel1_Click(object sender, EventArgs e)
        {

        }

        private void CmbDateTyp_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void groupPanel17_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtAct_TextChanged(object sender, EventArgs e)
        {
            Button_Edit_Click(null, null);
        }
        private void txtHeadingL1_Click(object sender, EventArgs e)
        {
            txtHeadingL1.SelectAll();
        }
        private void txtHeadingL2_Click(object sender, EventArgs e)
        {
            txtHeadingL2.SelectAll();
        }
        private void txtHeadingL3_Click(object sender, EventArgs e)
        {
            txtHeadingL3.SelectAll();
        }
        private void txtHeadingL4_Click(object sender, EventArgs e)
        {
            txtHeadingL4.SelectAll();
        }
        private void c1FlexGrid1_BeforeEdit(object sender, RowColEventArgs e)
        {
            if (e.Col != 3 || !(c1FlexGrid1.GetData(e.Row, 7).ToString() != "3"))
            {
                return;
            }
            for (int iiCnt = 1; iiCnt < c1FlexGrid1.Rows.Count; iiCnt++)
            {
                if (iiCnt != e.Row && c1FlexGrid1.GetData(iiCnt, 6).ToString() == c1FlexGrid1.GetData(e.Row, 6).ToString() && c1FlexGrid1.GetData(iiCnt, 7).ToString() != "3")
                {
                    c1FlexGrid1.SetData(iiCnt, 3, c1FlexGrid1.GetData(e.Row, 3));
                }
            }
        }
        private void c1FlexGrid1_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
        }
        private void c1FlexGrid1_DoubleClick(object sender, EventArgs e)
        {
            if ((c1FlexGrid1.Col != 4 && c1FlexGrid1.Col != 5) || c1FlexGrid1.Row <= 0)
            {
                return;
            }
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    c1FlexGrid1.SetData(c1FlexGrid1.Row, c1FlexGrid1.Col, _AccDef.AccDef_No.ToString());
                }
                else
                {
                    c1FlexGrid1.SetData(c1FlexGrid1.Row, c1FlexGrid1.Col, "***");
                }
            }
            catch
            {
                c1FlexGrid1.SetData(c1FlexGrid1.Row, c1FlexGrid1.Col, "***");
            }
            VarGeneral.Flush();
        }
        private void button_Background_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|TIFF Files (*.tiff)|*.tiff|BMP Files (*.bmp)|*.bmp";
                try
                {
                    if (VarGeneral.gUserName == "runsetting")
                    {
                        openFileDialog1.InitialDirectory = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
                    }
                }
                catch
                {
                }
                openFileDialog1.ShowDialog();
                string mypic_path = openFileDialog1.FileName;
                if (File.Exists(mypic_path))
                {
                    pictureBox_EnterPic.Image = Image.FromFile(mypic_path);
                    Bitmap OriginalBM = new Bitmap(pictureBox_EnterPic.Image);
                    pictureBox_EnterPic.Image = OriginalBM;
                    Button_Edit_Click(sender, e);
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_Background_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        public static string[] GetFilesFrom(string searchFolder, string[] filters, bool isRecursive)
        {
            List<string> filesFound = new List<string>();
            SearchOption searchOption = (isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
            foreach (string filter in filters)
            {
                filesFound.AddRange(Directory.GetFiles(searchFolder, $"*.{filter}", searchOption));
            }
            return filesFound.ToArray();
        }

        private void txtEmailBoss_Click(object sender, EventArgs e)
        {
            txtEmailBoss.SelectAll();
        }
        private void txtEmailPass_Click(object sender, EventArgs e)
        {
            txtEmailPass.SelectAll();
        }
        private void txtEmailBoss_Enter(object sender, EventArgs e)
        {
            Framework.Keyboard.Language.Switch("English");
        }
        private void txtEmailBoss_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                Framework.Keyboard.Language.Switch("Arabic");
            }
        }
        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void CmbPrintTyp_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.SSSLev == "R" || VarGeneral.SSSLev == "C" || VarGeneral.SSSLev == "H")
                {
                    chk39.Visible = true;
                    label75.Visible = true;
                }
                else
                {
                    chk39.Visible = false;
                    label75.Visible = false;
                }
                if ((CmbPrintTyp.SelectedIndex == 0 || CmbPrintTyp.SelectedIndex == 2) && (VarGeneral.SSSLev == "R" || VarGeneral.SSSLev == "C" || VarGeneral.SSSLev == "H"))
                {
                  //  chk50.Visible = true;
                }
                else
                {
                    //chk50.Visible = false;
                }
            }
            catch
            {
                chk39.Visible = false;
                label75.Visible = false;
                //chk50.Visible = false;
            }
        }
        private void button_B1_Click(object sender, EventArgs e)
        {
            _BackColor(0);
        }
        private void button_B2_Click(object sender, EventArgs e)
        {
            _BackColor(1);
        }
        private void button_B3_Click(object sender, EventArgs e)
        {
            _BackColor(2);
        }
        private void button_B4_Click(object sender, EventArgs e)
        {
            _BackColor(3);
        }
        private void button_B5_Click(object sender, EventArgs e)
        {
            _BackColor(4);
        }
        private void button_B6_Click(object sender, EventArgs e)
        {
            _BackColor(5);
        }
        private void button_B7_Click(object sender, EventArgs e)
        {
            _BackColor(6);
        }
        private void button_B8_Click(object sender, EventArgs e)
        {
            _BackColor(7);
        }
        private void button_F1_Click(object sender, EventArgs e)
        {
            _ForeColor(0);
        }
        private void button_F2_Click(object sender, EventArgs e)
        {
            _ForeColor(1);
        }
        private void button_F3_Click(object sender, EventArgs e)
        {
            _ForeColor(2);
        }
        private void button_F4_Click(object sender, EventArgs e)
        {
            _ForeColor(3);
        }
        private void button_F5_Click(object sender, EventArgs e)
        {
            _ForeColor(4);
        }
        private void button_F6_Click(object sender, EventArgs e)
        {
            _ForeColor(5);
        }
        private void button_F7_Click(object sender, EventArgs e)
        {
            _ForeColor(6);
        }
        private void button_F8_Click(object sender, EventArgs e)
        {
            _ForeColor(7);
        }
        private void _BackColor(int i)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                switch (i)
                {
                    case 0:
                        txtREmpty.BackColor = dlg.Color;
                        break;
                    case 1:
                        txtRAvailable.BackColor = dlg.Color;
                        break;
                    case 2:
                        txtRBussyDaily.BackColor = dlg.Color;
                        break;
                    case 3:
                        txtRBussyAppendix.BackColor = dlg.Color;
                        break;
                    case 4:
                        txtRClean.BackColor = dlg.Color;
                        break;
                    case 5:
                        txtRRepair.BackColor = dlg.Color;
                        break;
                    case 6:
                        txtRBussyMonthly.BackColor = dlg.Color;
                        break;
                    case 7:
                        txtRLeave.BackColor = dlg.Color;
                        break;
                }
            }
        }
        private void _ForeColor(int i)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                switch (i)
                {
                    case 0:
                        txtREmpty.ForeColor = dlg.Color;
                        break;
                    case 1:
                        txtRAvailable.ForeColor = dlg.Color;
                        break;
                    case 2:
                        txtRBussyDaily.ForeColor = dlg.Color;
                        break;
                    case 3:
                        txtRBussyAppendix.ForeColor = dlg.Color;
                        break;
                    case 4:
                        txtRClean.ForeColor = dlg.Color;
                        break;
                    case 5:
                        txtRRepair.ForeColor = dlg.Color;
                        break;
                    case 6:
                        txtRBussyMonthly.ForeColor = dlg.Color;
                        break;
                    case 7:
                        txtRLeave.ForeColor = dlg.Color;
                        break;
                }
            }
        }
        private void txtAllowPeriod_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckTime(txtAllowPeriod.Text))
                {
                    txtAllowPeriod.Text = TimeSpan.Parse(txtAllowPeriod.Text).ToString();
                }
                else
                {
                    txtAllowPeriod.Text = "05:00:00";
                }
            }
            catch
            {
                txtAllowPeriod.Text = "05:00:00";
            }
            try
            {
                if (int.Parse(txtAllowPeriod.Text.Substring(0, 2)) > 12 || txtAllowPeriod.Text.Substring(0, 2) == "00")
                {
                    if (txtAllowPeriod.Text.Substring(0, 2) == "13")
                    {
                        txtAllowPeriod.Text = "01" + txtAllowPeriod.Text.Remove(0, 2);
                    }
                    else if (txtAllowPeriod.Text.Substring(0, 2) == "14")
                    {
                        txtAllowPeriod.Text = "02" + txtAllowPeriod.Text.Remove(0, 2);
                    }
                    else if (txtAllowPeriod.Text.Substring(0, 2) == "15")
                    {
                        txtAllowPeriod.Text = "03" + txtAllowPeriod.Text.Remove(0, 2);
                    }
                    else if (txtAllowPeriod.Text.Substring(0, 2) == "16")
                    {
                        txtAllowPeriod.Text = "04" + txtAllowPeriod.Text.Remove(0, 2);
                    }
                    else if (txtAllowPeriod.Text.Substring(0, 2) == "17")
                    {
                        txtAllowPeriod.Text = "05" + txtAllowPeriod.Text.Remove(0, 2);
                    }
                    else if (txtAllowPeriod.Text.Substring(0, 2) == "18")
                    {
                        txtAllowPeriod.Text = "06" + txtAllowPeriod.Text.Remove(0, 2);
                    }
                    else if (txtAllowPeriod.Text.Substring(0, 2) == "19")
                    {
                        txtAllowPeriod.Text = "07" + txtAllowPeriod.Text.Remove(0, 2);
                    }
                    else if (txtAllowPeriod.Text.Substring(0, 2) == "20")
                    {
                        txtAllowPeriod.Text = "08" + txtAllowPeriod.Text.Remove(0, 2);
                    }
                    else if (txtAllowPeriod.Text.Substring(0, 2) == "21")
                    {
                        txtAllowPeriod.Text = "09" + txtAllowPeriod.Text.Remove(0, 2);
                    }
                    else if (txtAllowPeriod.Text.Substring(0, 2) == "22")
                    {
                        txtAllowPeriod.Text = "10" + txtAllowPeriod.Text.Remove(0, 2);
                    }
                    else if (txtAllowPeriod.Text.Substring(0, 2) == "23")
                    {
                        txtAllowPeriod.Text = "11" + txtAllowPeriod.Text.Remove(0, 2);
                    }
                    else if (txtAllowPeriod.Text.Substring(0, 2) == "00")
                    {
                        txtAllowPeriod.Text = "12" + txtAllowPeriod.Text.Remove(0, 2);
                    }
                }
            }
            catch
            {
            }
        }
        private void txtLeavePeriod_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckTime(txtLeavePeriod.Text))
                {
                    txtLeavePeriod.Text = TimeSpan.Parse(txtLeavePeriod.Text).ToString();
                }
                else
                {
                    txtLeavePeriod.Text = "06:00:00";
                }
            }
            catch
            {
                txtLeavePeriod.Text = "06:00:00";
            }
            try
            {
                if (int.Parse(txtLeavePeriod.Text.Substring(0, 2)) > 12 || txtLeavePeriod.Text.Substring(0, 2) == "00")
                {
                    if (txtLeavePeriod.Text.Substring(0, 2) == "13")
                    {
                        txtLeavePeriod.Text = "01" + txtLeavePeriod.Text.Remove(0, 2);
                    }
                    else if (txtLeavePeriod.Text.Substring(0, 2) == "14")
                    {
                        txtLeavePeriod.Text = "02" + txtLeavePeriod.Text.Remove(0, 2);
                    }
                    else if (txtLeavePeriod.Text.Substring(0, 2) == "15")
                    {
                        txtLeavePeriod.Text = "03" + txtLeavePeriod.Text.Remove(0, 2);
                    }
                    else if (txtLeavePeriod.Text.Substring(0, 2) == "16")
                    {
                        txtLeavePeriod.Text = "04" + txtLeavePeriod.Text.Remove(0, 2);
                    }
                    else if (txtLeavePeriod.Text.Substring(0, 2) == "17")
                    {
                        txtLeavePeriod.Text = "05" + txtLeavePeriod.Text.Remove(0, 2);
                    }
                    else if (txtLeavePeriod.Text.Substring(0, 2) == "18")
                    {
                        txtLeavePeriod.Text = "06" + txtLeavePeriod.Text.Remove(0, 2);
                    }
                    else if (txtLeavePeriod.Text.Substring(0, 2) == "19")
                    {
                        txtLeavePeriod.Text = "07" + txtLeavePeriod.Text.Remove(0, 2);
                    }
                    else if (txtLeavePeriod.Text.Substring(0, 2) == "20")
                    {
                        txtLeavePeriod.Text = "08" + txtLeavePeriod.Text.Remove(0, 2);
                    }
                    else if (txtLeavePeriod.Text.Substring(0, 2) == "21")
                    {
                        txtLeavePeriod.Text = "09" + txtLeavePeriod.Text.Remove(0, 2);
                    }
                    else if (txtLeavePeriod.Text.Substring(0, 2) == "22")
                    {
                        txtLeavePeriod.Text = "10" + txtLeavePeriod.Text.Remove(0, 2);
                    }
                    else if (txtLeavePeriod.Text.Substring(0, 2) == "23")
                    {
                        txtLeavePeriod.Text = "11" + txtLeavePeriod.Text.Remove(0, 2);
                    }
                    else if (txtLeavePeriod.Text.Substring(0, 2) == "00")
                    {
                        txtLeavePeriod.Text = "12" + txtLeavePeriod.Text.Remove(0, 2);
                    }
                }
            }
            catch
            {
            }
        }
        private void txtLeavePeriod_Click(object sender, EventArgs e)
        {
            txtLeavePeriod.SelectAll();
        }
        private void txtAllowPeriod_Click(object sender, EventArgs e)
        {
            txtAllowPeriod.SelectAll();
        }
        private void txtGuestsFatherAcc_ButtonCustomClick(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "T_AccDef_Banks";
            VarGeneral.AccTyp = 11;
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                txtGuestsFatherAcc.Text = _AccDef.AccDef_No.ToString();
                txtGuestsFatherAccName.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(txtGuestsFatherAcc.Text).Arb_Des : db.StockAccDefWithOutBalance(txtGuestsFatherAcc.Text).Eng_Des);
            }
            else
            {
                txtGuestsFatherAcc.Text = string.Empty;
                txtGuestsFatherAccName.Text = string.Empty;
            }
            VarGeneral.Flush();
        }
        private void txtGuestsFatherAcc_Click(object sender, EventArgs e)
        {
            txtGuestsFatherAcc.SelectAll();
        }
        private void c1FlexGriadTax_Click(object sender, EventArgs e)
        {
            if ((c1FlexGriadTax.Col != 9 && c1FlexGriadTax.Col != 10 && c1FlexGriadTax.Col != 16 && c1FlexGriadTax.Col != 17) || c1FlexGriadTax.Row <= 0)
            {
                return;
            }
            columns_Names_visibleTax.Clear();
            columns_Names_visibleTax.Add("AccDef_No", new ColumnDictinaryTax("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visibleTax.Add("Arb_Des", new ColumnDictinaryTax("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visibleTax.Add("Eng_Des", new ColumnDictinaryTax("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visibleTax.Add("AccDef_ID", new ColumnDictinaryTax(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visibleTax.Add("Mobile", new ColumnDictinaryTax("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinaryTax>> animalsAsCollection = columns_Names_visibleTax;
            foreach (KeyValuePair<string, ColumnDictinaryTax> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    c1FlexGriadTax.SetData(c1FlexGriadTax.Row, c1FlexGriadTax.Col, _AccDef.AccDef_No.ToString());
                }
                else
                {
                    c1FlexGriadTax.SetData(c1FlexGriadTax.Row, c1FlexGriadTax.Col, "***");
                }
            }
            catch
            {
                c1FlexGriadTax.SetData(c1FlexGriadTax.Row, c1FlexGriadTax.Col, "***");
            }
            VarGeneral.Flush();
        }
        private void c1FlexGriadTax_CellChecked(object sender, RowColEventArgs e)
        {
            if (e.Col != 4 && e.Col != 5)
            {
                return;
            }
            if (e.Col == 4)
            {
                if (Convert.ToBoolean(c1FlexGriadTax.Rows[e.Row][4]))
                {
                    c1FlexGriadTax.Rows[e.Row][5] = false;
                }
                else
                {
                    c1FlexGriadTax.Rows[e.Row][5] = true;
                }
            }
            else if (Convert.ToBoolean(c1FlexGriadTax.Rows[e.Row][5]))
            {
                c1FlexGriadTax.Rows[e.Row][4] = false;
            }
            else
            {
                c1FlexGriadTax.Rows[e.Row][4] = true;
            }
        }
        private void c1FlexGriadTax_DoubleClick(object sender, EventArgs e)
        {
            if ((c1FlexGriadTax.Col != 9 && c1FlexGriadTax.Col != 10 && c1FlexGriadTax.Col != 16 && c1FlexGriadTax.Col != 17) || c1FlexGriadTax.Row <= 0)
            {
                return;
            }
            columns_Names_visibleTax.Clear();
            columns_Names_visibleTax.Add("AccDef_No", new ColumnDictinaryTax("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visibleTax.Add("Arb_Des", new ColumnDictinaryTax("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visibleTax.Add("Eng_Des", new ColumnDictinaryTax("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visibleTax.Add("AccDef_ID", new ColumnDictinaryTax(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visibleTax.Add("Mobile", new ColumnDictinaryTax("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinaryTax>> animalsAsCollection = columns_Names_visibleTax;
            foreach (KeyValuePair<string, ColumnDictinaryTax> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    c1FlexGriadTax.SetData(c1FlexGriadTax.Row, c1FlexGriadTax.Col, _AccDef.AccDef_No.ToString());
                }
                else
                {
                    c1FlexGriadTax.SetData(c1FlexGriadTax.Row, c1FlexGriadTax.Col, "***");
                }
            }
            catch
            {
                c1FlexGriadTax.SetData(c1FlexGriadTax.Row, c1FlexGriadTax.Col, "***");
            }
            VarGeneral.Flush();
        }

        private void txtGuestBoxAcc_ButtonCustomClick(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                txtGuestBoxAcc.Text = _AccDef.AccDef_No.ToString();
                txtGuestBoxAccName.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(txtGuestBoxAcc.Text).Arb_Des : db.StockAccDefWithOutBalance(txtGuestBoxAcc.Text).Eng_Des);
            }
            else
            {
                txtGuestBoxAcc.Text = string.Empty;
                txtGuestBoxAccName.Text = string.Empty;
            }
        }
        private void txtGuestBoxAcc_Click(object sender, EventArgs e)
        {
            txtGuestBoxAcc.SelectAll();
        }
        private void txtGuestsFatherAccName_Click(object sender, EventArgs e)
        {
            txtGuestsFatherAccName.SelectAll();
        }
        private void txtGuestBoxAccName_Click(object sender, EventArgs e)
        {
            txtGuestBoxAccName.SelectAll();
        }
        private void txtTel2_Click(object sender, EventArgs e)
        {
            txtTel2.SelectAll();
        }
        private void txtPOBox_Click(object sender, EventArgs e)
        {
            txtPOBox.SelectAll();
        }
        private void txtMailCode_Click(object sender, EventArgs e)
        {
            txtMailCode.SelectAll();
        }
        private void txtRemark_Click(object sender, EventArgs e)
        {
            txtRemark.SelectAll();
        }
        private void txtHeadingR1_Click(object sender, EventArgs e)
        {
            txtHeadingR1.SelectAll();
        }
        private void txtHeadingR2_Click(object sender, EventArgs e)
        {
            txtHeadingR2.SelectAll();
        }

        private void button_RemoveBackgroud_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            Image image2 = (pictureBox_EnterPic.Image = (BackgroundImage = Resources.sssBackground));
        }
        private void CmbPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void checkBox_previewPrint_CheckedChanged(object sender, CheckBoxChangeEventArgs e)
        {
        }
        private void txtHijriDate_Click(object sender, EventArgs e)
        {
            txtHijriDate.SelectAll();
        }
        private void txtCompany_Click(object sender, EventArgs e)
        {
            txtCompany.SelectAll();
        }
        private void txtTel1_Click(object sender, EventArgs e)
        {
            txtTel1.SelectAll();
        }
        private void txtFax_Click(object sender, EventArgs e)
        {
            txtFax.SelectAll();
        }
        private void txtMobile_Click(object sender, EventArgs e)
        {
            txtMobile.SelectAll();
        }
        private void txtHeadingR3_Click(object sender, EventArgs e)
        {
            txtHeadingR3.SelectAll();
        }
    private void txtHeadingR4_Click(object sender, EventArgs e)
    {
        txtHeadingR4.SelectAll();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            c1FlexGrid2.AllowFiltering = true;
            var filter = new ConditionFilter();
            // configure filter to select items that start with "C"
            filter.Condition1.Operator = ConditionOperator.Contains;
            filter.Condition1.Parameter = textBox1.Text;
            // assign new filter to column "ProductName"
            c1FlexGrid2.Cols[1].Filter = filter;
        }
        private void c1FlexGrid2_SelChange(object sender, EventArgs e)
        {
            if (Environment.MachineName.Contains("DESKTOP-320H5U2"))
            {
             //   this.Text = nn[c1FlexGrid2.RowSel - 1].ToString();
            }
        }
        private void switchButton_NewColumnName_ValueChanged(object sender, EventArgs e)
        {
            NewColumnData();
        }
        private void button_ManageRoom_Click(object sender, EventArgs e)
        {
            if (txtFloors.IsInputReadOnly)
            {
                return;
            }
            if (_SysSetting.flore.Value != txtFloors.Value)
            {
                MessageBox.Show((LangArEn == 0) ? "لقد تم تغيير عدد الطوابق .. يرجى اتمام عملية الحفظ قبل القيام بعملية التحكم في غرف / شقق الطوابق ثم المحاولة مرة اخرى" : "The number of floors has been changed. Please complete the process of conservation before controlling the rooms / apartments of the floors and then try again", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            try
            {
                FrmRoomManage frm = new FrmRoomManage();
                frm.Tag = LangArEn;
                frm.TopMost = true;
                frm.ShowDialog();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_ManageRoom_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                FrmPointsCalc frm = new FrmPointsCalc();
                frm.Tag = LangArEn;
                frm.TopMost = true;
                frm.ShowDialog();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_PointOfCust_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }

        private void button_DocPath_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(VarGeneral.gUserName == "runsetting") || VarGeneral.UserID == 1)
                {
                    FolderBrowserDialog fbd = new FolderBrowserDialog();
                    DialogResult result = fbd.ShowDialog();
                    textBox_DocPath.Text = fbd.SelectedPath;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_Pic_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void button_DayofMonth_Click(object sender, EventArgs e)
        {
            FrmDaysOfMonth frm = new FrmDaysOfMonth();
            frm.Tag = LangArEn;
            frm.TopMost = true;
            frm.ShowDialog();
        }
        private void FlxInv_DoubleClick(object sender, EventArgs e)
        {
            if (FlxInv.Row <= 0 || FlxInv.Row == 1)
            {
                return;
            }
            if (FlxInv.Col == 3)
            {
                columns_Names_visible.Clear();
                columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
                columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
                columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
                columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "T_AccDef";
                VarGeneral.AccTyp = 8;
                frm.TopMost = true;
                frm.ShowDialog();
                try
                {
                    if (frm.SerachNo != string.Empty)
                    {
                        T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                        FlxInv.SetData(FlxInv.Row, FlxInv.Col, _AccDef.AccDef_No.ToString());
                    }
                    else
                    {
                        FlxInv.SetData(FlxInv.Row, FlxInv.Col, string.Empty);
                    }
                }
                catch
                {
                    FlxInv.SetData(FlxInv.Row, FlxInv.Col, string.Empty);
                }
                VarGeneral.Flush();
            }
            else
            {
                if (FlxInv.Col != 4)
                {
                    return;
                }
                columns_Names_visible.Clear();
                columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
                columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
                columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
                columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "T_AccDef3";
                frm.TopMost = true;
                frm.ShowDialog();
                try
                {
                    if (frm.SerachNo != string.Empty)
                    {
                        T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                        FlxInv.SetData(FlxInv.Row, FlxInv.Col, _AccDef.AccDef_No.ToString());
                    }
                    else
                    {
                        FlxInv.SetData(FlxInv.Row, FlxInv.Col, string.Empty);
                    }
                }
                catch
                {
                    FlxInv.SetData(FlxInv.Row, FlxInv.Col, string.Empty);
                }
                VarGeneral.Flush();
            }
        }
        private void Frm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
            FrmTaxOpiton_KeyPress(sender, e);
        }
        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && ButWithSave.Enabled && ButWithSave.Visible)
            {
                ButWithSave_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
            FrmTaxOpiton_KeyDown(sender, e);
        }

        public NewFrmSystemSetting()
        {
            InitializeComponent();
        //    textBox_BackupPath.ButtonCustomClick += textBox_BackupPath_ButtonCustomClick;
            textBox_LineDetailNameA.Click += Button_Edit_Click;
            textBox_LineDetailNameE.Click += Button_Edit_Click;
            txtAct.Click += Button_Edit_Click;
            txtAddr.Click += Button_Edit_Click;
            txtAutoNumber.Click += Button_Edit_Click;
            txtBoxAccount.Click += Button_Edit_Click;
            txtCompany.Click += Button_Edit_Click;
            txtDateAlarm.Click += Button_Edit_Click;
            txtDateofInv.Click += Button_Edit_Click;
            txtAlarmDeuDateBefor.Click += Button_Edit_Click;
            txtKeyNational.Click += Button_Edit_Click;
            txtDateAlarmEmps.Click += Button_Edit_Click;
            txtLinesInv.Click += Button_Edit_Click;
            //	txtDistance.Click += Button_Edit_Click;
            txtFax.Click += Button_Edit_Click;
            txtFirstInventory.Click += Button_Edit_Click;
            txtGuestsFatherAcc.Click += Button_Edit_Click;
            txtGuestBoxAcc.Click += Button_Edit_Click;
            radioButton_IsNotBackground.Click += Button_Edit_Click;
            txtGregDate.Click += Button_Edit_Click;
            txtEmailBoss.Click += Button_Edit_Click;
            txtEmailPass.Click += Button_Edit_Click;
            txtHeadingL1.Click += Button_Edit_Click;
            txtHeadingL2.Click += Button_Edit_Click;
            txtHeadingL3.Click += Button_Edit_Click;
            txtHeadingL4.Click += Button_Edit_Click;
            txtHeadingR1.Click += Button_Edit_Click;
            txtHeadingR2.Click += Button_Edit_Click;
            txtHeadingR3.Click += Button_Edit_Click;
            txtHeadingR4.Click += Button_Edit_Click;
            txtHijriDate.Click += Button_Edit_Click;
            txtLastInventory.Click += Button_Edit_Click;
            txtMailCode.Click += Button_Edit_Click;
            txtMobile.Click += Button_Edit_Click;
            txtPOBox.Click += Button_Edit_Click;
            txtProfits.Click += Button_Edit_Click;
            txtRemark.Click += Button_Edit_Click;
            txtTel1.Click += Button_Edit_Click;
            txtTel2.Click += Button_Edit_Click;
            ChkPageNumber.Click += Button_Edit_Click;
            ChkGreg.Click += Button_Edit_Click;
            ChkHijri.Click += Button_Edit_Click;
            ChkHead.Click += Button_Edit_Click;
            textBox_SyncPath.ButtonCustomClick += Button_Edit_Click;
            textBox_BackupPath.ButtonCustomClick += Button_Edit_Click;
            textBox_BackupElectronic.ButtonCustomClick += Button_Edit_Click;
            checkBox_AutoBackup.Click += Button_Edit_Click;
            CmbCalendar.Click += Button_Edit_Click;
            //CmbCost.Click += Button_Edit_Click;
            CmbDateTyp.Click += Button_Edit_Click;
            CmbCurr.Click += Button_Edit_Click;
          //  CmbInvMode.Click += Button_Edit_Click;
            CmbMail.Click += Button_Edit_Click;
            chk1.Click += Button_Edit_Click;
            chk2.Click += Button_Edit_Click;
            chk3.Click += Button_Edit_Click;
            //chk4.Click += Button_Edit_Click;
            //chk5.Click += Button_Edit_Click;
            //chk6.Click += Button_Edit_Click;
            //chk7.Click += Button_Edit_Click;
            //chk8.Click += Button_Edit_Click;
            //chk9.Click += Button_Edit_Click;
            //chk10.Click += Button_Edit_Click;
            //chk11.Click += Button_Edit_Click;
            //chk12.Click += Button_Edit_Click;
            //chk13.Click += Button_Edit_Click;
            //chk14.Click += Button_Edit_Click;
            //chk15.Click += Button_Edit_Click;
            //chk16.Click += Button_Edit_Click;
            //chk17.Click += Button_Edit_Click;
            //chk18.Click += Button_Edit_Click;
            //chk19.Click += Button_Edit_Click;
            //chk20.Click += Button_Edit_Click;
            //chk21.Click += Button_Edit_Click;
            //chk22.Click += Button_Edit_Click;
            //chk23.Click += Button_Edit_Click;
            //chk24.Click += Button_Edit_Click;
            //chk25.Click += Button_Edit_Click;
            //chk26.Click += Button_Edit_Click;
            //chk27.Click += Button_Edit_Click;
            //chk28.Click += Button_Edit_Click;
            //chk29.Click += Button_Edit_Click;
            //chk31.Click += Button_Edit_Click;
            //chk32.Click += Button_Edit_Click;
            //chk33.Click += Button_Edit_Click;
            //chk34.Click += Button_Edit_Click;
            //chk35.Click += Button_Edit_Click;
            //chk36.Click += Button_Edit_Click;
            //chk37.Click += Button_Edit_Click;
            //chk38.Click += Button_Edit_Click;
            //chk39.Click += Button_Edit_Click;
            //chk40.Click += Button_Edit_Click;
            //chk41.Click += Button_Edit_Click;
            chk42.Click += Button_Edit_Click;
            chk43.Click += Button_Edit_Click;
            chk44.Click += Button_Edit_Click;
            chk45.Click += Button_Edit_Click;
            chk46.Click += Button_Edit_Click;
            //chk47.Click += Button_Edit_Click;
            //chk48.Click += Button_Edit_Click;
            //chk49.Click += Button_Edit_Click;
            //chk50.Click += Button_Edit_Click;
            //chk51.Click += Button_Edit_Click;
            //chk52.Click += Button_Edit_Click;
            //chk53.Click += Button_Edit_Click;
            //chk54.Click += Button_Edit_Click;
            //chk55.Click += Button_Edit_Click;
            //chk56.Click += Button_Edit_Click;
            //chk57.Click += Button_Edit_Click;
            //chk58.Click += Button_Edit_Click;
            //chk59.Click += Button_Edit_Click;
            //chk60.Click += Button_Edit_Click;
            //chk61.Click += Button_Edit_Click;
            //chk62.Click += Button_Edit_Click;
            //chk63.Click += Button_Edit_Click;
            //chk64.Click += Button_Edit_Click;
            //chk65.Click += Button_Edit_Click;
            //chk66.Click += Button_Edit_Click;
            //chk67.Click += Button_Edit_Click;
            //chk68.Click += Button_Edit_Click;
            //chk69.Click += Button_Edit_Click;
            //chk70.Click += Button_Edit_Click;
            //chk71.Click += Button_Edit_Click;
            //chk72.Click += Button_Edit_Click;
            //chk73.Click += Button_Edit_Click;
            //chk74.Click += Button_Edit_Click;
            //chk75.Click += Button_Edit_Click;
            chk76.Click += Button_Edit_Click;
            chk77.Click += Button_Edit_Click;
            Tree_NewCol.Click += Button_Edit_Click;
            CmbPrintTyp.Click += Button_Edit_Click;
            CmbPointImages.Click += Button_Edit_Click;
            CmbOrderTyp.Click += Button_Edit_Click;
            txtFloors.Click += Button_Edit_Click;
            txtRoom.Click += Button_Edit_Click;
            txtAllowPeriod.Click += Button_Edit_Click;
            txtLeavePeriod.Click += Button_Edit_Click;
            txtDayofMonth.Click += Button_Edit_Click;
            txtLongitudinal.Click += Button_Edit_Click;
            txtWidthitudinal.Click += Button_Edit_Click;
            button_B1.Click += Button_Edit_Click;
            button_B2.Click += Button_Edit_Click;
            button_B3.Click += Button_Edit_Click;
            button_B4.Click += Button_Edit_Click;
            button_B5.Click += Button_Edit_Click;
            button_B6.Click += Button_Edit_Click;
            button_B7.Click += Button_Edit_Click;
            button_B8.Click += Button_Edit_Click;
            button_F1.Click += Button_Edit_Click;
            button_F2.Click += Button_Edit_Click;
            button_F3.Click += Button_Edit_Click;
            button_F4.Click += Button_Edit_Click;
            button_F5.Click += Button_Edit_Click;
            button_F6.Click += Button_Edit_Click;
            button_F7.Click += Button_Edit_Click;
            button_F8.Click += Button_Edit_Click;
            RadioBox_AllowAM.Click += Button_Edit_Click;
            RadioBox_AllowPM.Click += Button_Edit_Click;
            RadioBox_LeaveAM.Click += Button_Edit_Click;
            RadioBox_LeavePM.Click += Button_Edit_Click;
            txtEqarContractEndAlarm.Click += Button_Edit_Click;
            txtEqarDayOfPayAlarm.Click += Button_Edit_Click;
            txtEqarsFatherAcc.Click += Button_Edit_Click;
            txtEqarsFatherAccName.Click += Button_Edit_Click;
            txtTenantFatherAcc.Click += Button_Edit_Click;
            txttenantFatherAccName.Click += Button_Edit_Click;
            ChkEmp1.Click += Button_Edit_Click;
        //    this.ribbonBar1.ItemClick += new System.EventHandler(this.ribbonBar1_ItemClick);
            this.textBox_BackupPath.ButtonCustomClick += new System.EventHandler(this.textBox_BackupPath_ButtonCustomClick);
            this.textBox_BackupPath.Click += new System.EventHandler(this.textBox_BackupPath_Click);
            this.txtHijriDate.Click += new System.EventHandler(this.txtHijriDate_Click);
            this.chk19.CheckedChanged += new System.EventHandler(this.chk19_CheckedChanged);
            this.chk1.CheckedChanged += new System.EventHandler(this.chk1_CheckedChanged);
            this.chk3.CheckedChanged += new System.EventHandler(this.chk3_CheckedChanged);
            this.CmbDateTyp.SelectedIndexChanged += new System.EventHandler(this.CmbDateTyp_SelectedIndexChanged);
            this.TXtVatNumbber.TextChanged += new System.EventHandler(this.txtAct_TextChanged);
            this.txtAddr.TextChanged += new System.EventHandler(this.txtAct_TextChanged);
            this.CountryCode.TextChanged += new System.EventHandler(this.txtAct_TextChanged);
            this.label32.Click += new System.EventHandler(this.label32_Click);
            this.button_RemoveBackgroud.Click += new System.EventHandler(this.button_RemoveBackgroud_Click);
            this.button_Background.Click += new System.EventHandler(this.button_Background_Click);
            this.ProviesionState.TextChanged += new System.EventHandler(this.txtAct_TextChanged);
            this.label33.Click += new System.EventHandler(this.label33_Click);
            this.txtEmailPass.Click += new System.EventHandler(this.txtEmailPass_Click);
            this.TxtGroupVatNumb.TextChanged += new System.EventHandler(this.txtAct_TextChanged);
            this.label28.Click += new System.EventHandler(this.label28_Click);
            this.AddationalNumber.TextChanged += new System.EventHandler(this.txtAct_TextChanged);
            this.txtEmailBoss.Click += new System.EventHandler(this.txtEmailBoss_Click);
            this.txtEmailBoss.Enter += new System.EventHandler(this.txtEmailBoss_Enter);
            this.txtEmailBoss.Leave += new System.EventHandler(this.txtEmailBoss_Leave);
            this.streetline2.TextChanged += new System.EventHandler(this.txtAct_TextChanged);
            this.txtCompany.Click += new System.EventHandler(this.txtCompany_Click);
            this.label31.Click += new System.EventHandler(this.label31_Click);
            this.label29.Click += new System.EventHandler(this.label29_Click);
            this.BuildingNumber.TextChanged += new System.EventHandler(this.txtAct_TextChanged);
            this.txtAct.Click += new System.EventHandler(this.txtAct_Click);
            this.txtAct.TextChanged += new System.EventHandler(this.txtAct_TextChanged);
            this.streetline1.TextChanged += new System.EventHandler(this.txtAct_TextChanged);
            this.label30.Click += new System.EventHandler(this.label30_Click);
            this.txtRemark.Click += new System.EventHandler(this.txtRemark_Click);
            this.label27.Click += new System.EventHandler(this.label27_Click);
            this.txtTel2.Click += new System.EventHandler(this.txtTel2_Click);
            this.txtTel2.Enter += new System.EventHandler(this.txtEmailBoss_Enter);
            this.txtTel2.Leave += new System.EventHandler(this.txtEmailBoss_Leave);
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.label26.Click += new System.EventHandler(this.label26_Click);
            this.Byer_IDTExt.TextChanged += new System.EventHandler(this.txtAct_TextChanged);
            this.txtTel1.Click += new System.EventHandler(this.txtTel1_Click);
            this.txtTel1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHeadingR3_KeyPress);
            this.txtMailCode.Click += new System.EventHandler(this.txtMailCode_Click);
            this.txtMobile.Click += new System.EventHandler(this.txtMobile_Click);
            this.txtMobile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMobile_KeyPress);
            this.txtPOBox.Click += new System.EventHandler(this.txtPOBox_Click);
            this.txtFax.Click += new System.EventHandler(this.txtFax_Click);
            this.txtFax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHeadingR3_KeyPress);
            this.txtHeadingL1.Click += new System.EventHandler(this.txtHeadingL1_Click);
            this.txtHeadingL1.Enter += new System.EventHandler(this.textbox_Eng_Des_Enter);
            this.txtHeadingL1.Leave += new System.EventHandler(this.textbox_Arb_Des_Enter);
            this.txtHeadingL2.Click += new System.EventHandler(this.txtHeadingL2_Click);
            this.txtHeadingL2.Enter += new System.EventHandler(this.textbox_Eng_Des_Enter);
            this.txtHeadingL2.Leave += new System.EventHandler(this.textbox_Arb_Des_Enter);
            this.txtHeadingL3.Click += new System.EventHandler(this.txtHeadingL3_Click);
            this.txtHeadingL4.Click += new System.EventHandler(this.txtHeadingL4_Click);
            this.button_ClearPic.Click += new System.EventHandler(this.button_ClearPic_Click);
            this.button_EnterImg.Click += new System.EventHandler(this.button_EnterImg_Click);
            this.txtHeadingR2.Click += new System.EventHandler(this.txtHeadingR2_Click);
            this.txtHeadingR2.Enter += new System.EventHandler(this.textbox_Arb_Des_Enter);
            this.txtHeadingR2.Leave += new System.EventHandler(this.textbox_Arb_Des_Enter);
            this.txtHeadingR1.Click += new System.EventHandler(this.txtHeadingR1_Click);
            this.txtHeadingR1.TextChanged += new System.EventHandler(this.txtHeadingR1_TextChanged);
            this.txtHeadingR1.Enter += new System.EventHandler(this.textbox_Arb_Des_Enter);
            this.txtHeadingR1.Leave += new System.EventHandler(this.textbox_Arb_Des_Enter);
            this.txtHeadingR4.Click += new System.EventHandler(this.txtHeadingR4_Click);
            this.txtHeadingR3.Click += new System.EventHandler(this.txtHeadingR3_Click);
            this.c1FlexGrid1Bankopp.Click += new System.EventHandler(this.Button_Edit_Click);
           // this.splitContainer3.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer3_Panel1_Paint);
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
           // this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.c1FlexGrid2.SelChange += new System.EventHandler(this.c1FlexGrid2_SelChange);
            this.c1FlexGrid2.Click += new System.EventHandler(this.c1FlexGrid2_Click);
            this.chk69.CheckedChanged += new System.EventHandler(this.chk69_CheckedChanged);
            this.chk58.CheckedChanged += new System.EventHandler(this.chk58_CheckedChanged);
           // this.label48.Click += new System.EventHandler(this.label48_Click);
            this.CmbPrintTyp.SelectedIndexChanged += new System.EventHandler(this.CmbPrintTyp_SelectedIndexChanged);
            this.switchButton_NewColumnName.ValueChanged += new System.EventHandler(this.switchButton_NewColumnName_ValueChanged);
            this.button_B7.Click += new System.EventHandler(this.button_B7_Click);
            this.button_F7.Click += new System.EventHandler(this.button_F7_Click);
            this.button_B5.Click += new System.EventHandler(this.button_B5_Click);
            this.button_F5.Click += new System.EventHandler(this.button_F5_Click);
            this.button_B3.Click += new System.EventHandler(this.button_B3_Click);
            this.button_F3.Click += new System.EventHandler(this.button_F3_Click);
            this.button_B1.Click += new System.EventHandler(this.button_B1_Click);
            this.button_F1.Click += new System.EventHandler(this.button_F1_Click);
            this.button_F8.Click += new System.EventHandler(this.button_F8_Click);
            this.button_F6.Click += new System.EventHandler(this.button_F6_Click);
            this.button_F4.Click += new System.EventHandler(this.button_F4_Click);
            this.button_F2.Click += new System.EventHandler(this.button_F2_Click);
            this.button_B8.Click += new System.EventHandler(this.button_B8_Click);
            this.button_B6.Click += new System.EventHandler(this.button_B6_Click);
            this.button_B4.Click += new System.EventHandler(this.button_B4_Click);
            this.button_B2.Click += new System.EventHandler(this.button_B2_Click);
            this.button_ManageRoom.Click += new System.EventHandler(this.button_ManageRoom_Click);
            this.txtGuestBoxAccName.Click += new System.EventHandler(this.txtGuestBoxAccName_Click);
            this.txtGuestsFatherAccName.Click += new System.EventHandler(this.txtGuestsFatherAccName_Click);
            this.txtGuestBoxAcc.ButtonCustomClick += new System.EventHandler(this.txtGuestBoxAcc_ButtonCustomClick);
            this.txtGuestBoxAcc.Click += new System.EventHandler(this.txtGuestBoxAcc_Click);
            this.txtGuestsFatherAcc.ButtonCustomClick += new System.EventHandler(this.txtGuestsFatherAcc_ButtonCustomClick);
            this.txtGuestsFatherAcc.Click += new System.EventHandler(this.txtGuestsFatherAcc_Click);
            this.txtLeavePeriod.Click += new System.EventHandler(this.txtLeavePeriod_Click);
            this.txtLeavePeriod.Leave += new System.EventHandler(this.txtLeavePeriod_Leave);
            this.txtAllowPeriod.Click += new System.EventHandler(this.txtAllowPeriod_Click);
            this.txtAllowPeriod.Leave += new System.EventHandler(this.txtAllowPeriod_Leave);
            this.txtTenantFatherAcc.ButtonCustomClick += new System.EventHandler(this.txtTenantFatherAcc_ButtonCustomClick);
            this.txtTenantFatherAcc.Click += new System.EventHandler(this.txtTenantFatherAcc_Click);
            this.txtEqarsFatherAcc.ButtonCustomClick += new System.EventHandler(this.txtEqarsFatherAcc_ButtonCustomClick);
            this.txtEqarsFatherAcc.Click += new System.EventHandler(this.txtEqarsFatherAcc_Click);
            this.button_RestoreDefContract.Click += new System.EventHandler(this.button_RestoreDefContract_Click);
            this.button_PointOfCust.Click += new System.EventHandler(this.buttonX1_Click);
            this.label3Tax.Click += new System.EventHandler(this.label3Tax_Click);
            this.c1FlexGriadTax.CellChecked += new C1.Win.C1FlexGrid.RowColEventHandler(this.c1FlexGriadTax_CellChecked);
            this.c1FlexGriadTax.Click += new System.EventHandler(this.c1FlexGriadTax_Click);
            this.c1FlexGriadTax.DoubleClick += new System.EventHandler(this.c1FlexGriadTax_DoubleClick);
            this.checkBox_IsAlarmEndVaction.CheckedChanged += new System.EventHandler(this.checkBox_IsAlarmEndVaction_CheckedChanged);
            this.checkBox_IsAlarmVisaGoBack.CheckedChanged += new System.EventHandler(this.checkBox_IsAlarmVisaGoBack_CheckedChanged);
            this.checkBox_IsAlarmCarDoc.CheckedChanged += new System.EventHandler(this.checkBox_IsAlarmCarDoc_CheckedChanged);
            this.checkBox_IsAlarmSecretariatsDoc.CheckedChanged += new System.EventHandler(this.checkBox_IsAlarmSecretariatsDoc_CheckedChanged);
            this.checkBox_IsAlarmFamilyPassport.CheckedChanged += new System.EventHandler(this.checkBox_IsAlarmFamilyPassport_CheckedChanged);
            this.checkBox_IsAlarmEmpContract.CheckedChanged += new System.EventHandler(this.checkBox_IsAlarmEmpContract_CheckedChanged);
            this.checkBox_IsAlarmEmpDoc.CheckedChanged += new System.EventHandler(this.checkBox_IsAlarmEmpDoc_CheckedChanged);
            this.checkBox_IsAlarmGuarantorDoc.CheckedChanged += new System.EventHandler(this.checkBox_IsAlarmGuarantorDoc_CheckedChanged);
            this.checkBox_IsAlarmDepts.CheckedChanged += new System.EventHandler(this.checkBox_IsAlarmDepts_CheckedChanged);
            this.button_DocPath.Click += new System.EventHandler(this.button_DocPath_Click);
            this.checkBox_AutoLeave.CheckedChanged += new System.EventHandler(this.checkBox_AutoLeave_CheckedChanged);
            this.button_DayofMonth.Click += new System.EventHandler(this.button_DayofMonth_Click);
            this.FlxInv.Click += new System.EventHandler(this.c1FlexGrid1_Click);
            this.FlxInv.DoubleClick += new System.EventHandler(this.FlxInv_DoubleClick);
            this.c1FlexGrid1.BeforeEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.c1FlexGrid1_BeforeEdit);
            this.c1FlexGrid1.Click += new System.EventHandler(this.c1FlexGrid1_Click);
            this.c1FlexGrid1.DoubleClick += new System.EventHandler(this.c1FlexGrid1_DoubleClick);
        //    this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);

            textBox_AutoEmpLeaveAfter.Click += Button_Edit_Click;
            integerInput_AlarmEmpContractBefore.Click += Button_Edit_Click;
            integerInput_AlarmEmpDocBefore.Click += Button_Edit_Click;
            integerInput_AlarmEndVactionBefore.Click += Button_Edit_Click;
            integerInput_AlarmFamilyPassportBefore.Click += Button_Edit_Click;
            integerInput_AlarmGuarantorDocBefore.Click += Button_Edit_Click;
            integerInput_AlarmCarDocBefore.Click += Button_Edit_Click;
            integerInput_AlarmSecretariatsBefore.Click += Button_Edit_Click;
            integerInput_AlarmVisaGoBack.Click += Button_Edit_Click;
            integerInput_AlarmDeptsBefore.Click += Button_Edit_Click;
            checkBox_IsAlarmEmpContract.Click += Button_Edit_Click;
            checkBox_IsAlarmEmpDoc.Click += Button_Edit_Click;
            checkBox_IsAlarmEndVaction.Click += Button_Edit_Click;
            checkBox_IsAlarmFamilyPassport.Click += Button_Edit_Click;
            checkBox_IsAlarmGuarantorDoc.Click += Button_Edit_Click;
            checkBox_IsAlarmCarDoc.Click += Button_Edit_Click;
            checkBox_IsAlarmSecretariatsDoc.Click += Button_Edit_Click;
            checkBox_IsAlarmVisaGoBack.Click += Button_Edit_Click;
            checkBox_IsAlarmDepts.Click += Button_Edit_Click;
            radioButton_IsNotBackground.Click += Button_Edit_Click;
            checkBox_AttendanceManually.Click += Button_Edit_Click;
            checkBox_AutoLeave.Click += Button_Edit_Click;
            checkBox_VacationManually.Click += Button_Edit_Click;
            checkBox_Sponer.Click += Button_Edit_Click;
            comboBox_CalculateNo.Click += Button_Edit_Click;
            comboBox_DisVacationType.Click += Button_Edit_Click;
            comboBox_CalculatliquidNo.Click += Button_Edit_Click;
            button_DocPath.Click += Button_Edit_Click;
            comboBox_AutoBackup.Click += Button_Edit_Click;
            if (VarGeneral.SSSLev == "S")
            {
            //    chk10.Visible = false;
            }
            else
            {
               // chk10.Visible = true;
                if (VarGeneral.SSSLev == "D" || VarGeneral.SSSLev == "E")
                {
                    superTabItem_Employee.Visible = true;
                    chk19.Visible = false;
                    txtDateAlarmEmps.Visible = false;
                    if (VarGeneral.SSSLev == "E")
                    {
                        //chk20.Visible = false;
                        //chk21.Visible = false;
                        //chk22.Visible = false;
                        //chk23.Visible = false;
                        //chk29.Visible = false;
                        label51.Visible = false;
                        CmbPointImages.Visible = false;
                    }
                    label47.Visible = false;
                }
            }
            if (VarGeneral.gUserName == "runsetting" && VarGeneral.UserID != 1)
            {
                chk37.IsReadOnly = true;
                checkBox_AutoBackup.Enabled = false;
                comboBox_AutoBackup.Enabled = false;
            }
            if (VarGeneral.gUserName == "runsetting" && VarGeneral.UserID == 1)
            {
                textBox_BackupElectronic.ButtonCustom2.Visible = true;
            }
            if (!VarGeneral.EmpSystem)
            {
                superTabItem_Employee.Visible = false;
            }
            if (VarGeneral.UserID != 1)
            {
                textBox_SyncPath.ReadOnly = true;
                textBox_SyncPath.ForeColor = Color.White;
            }
        }
        public bool CanEdit = true;
        FormState statex;
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

        public bool SetReadOnly
        {
            set
            {
                if (value)
                {
                    State = FormState.Saved;
                }
                ButWithSave.Enabled = !value;
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
        private void Button_Edit_Click(object sender, EventArgs e)
        {
            if (CanEdit && State != FormState.Edit && State != FormState.New)
            {
                if (State != FormState.New)
                {
                    State = FormState.Edit;
                }
                SetReadOnly = false;
            }
        }
        private void tileBar_SelectedItemChanged(object sender, TileItemEventArgs e)
        {
            try
            {
                navigationFrame.SelectedPageIndex = tileBarGroupTables.Items.IndexOf(e.Item);
            }
            catch { }
        }

        private void GeneralSettings_ItemClick(object sender, TileItemEventArgs e)
        {

        }

        private void groupPanel_Acc_Click(object sender, EventArgs e)
        {

        }
        private void chk69_CheckedChanged(object sender, EventArgs e)
        {
            if (chk69.Checked)
            {
                txtAlarmDeuDateBefor.Enabled = true;
            }
            else
            {
                txtAlarmDeuDateBefor.Enabled = false;
            }
        }
        private void textBox_SyncPath_ButtonCustomClick(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.UserID == 1)
                {
                    FolderBrowserDialog fbd = new FolderBrowserDialog();
                    DialogResult result = fbd.ShowDialog();
                    textBox_SyncPath.Text = fbd.SelectedPath;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("textBox_SyncPath_ButtonCustomClick:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void textBox_SyncPath_Click(object sender, EventArgs e)
        {
            textBox_SyncPath.SelectAll();
        }
        private void txtKeyNational_Click(object sender, EventArgs e)
        {
            txtKeyNational.SelectAll();
        }
        private void textBox_BackupElectronic_ButtonCustomClick(object sender, EventArgs e)
        {
            if (VarGeneral.UserID != 1 || !VarGeneral.CheckDate(dateTimeInput_DT.Text))
            {
                return;
            }
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                DialogResult result = fbd.ShowDialog();
                textBox_BackupElectronic.Tag = fbd.SelectedPath;
                if (string.IsNullOrEmpty(textBox_BackupElectronic.Tag.ToString()))
                {
                    textBox_BackupElectronic.Text = ((LangArEn == 0) ? "لم يتم تحديد مسار النسخ الالكتروني" : "It not been determined path");
                }
                else
                {
                    textBox_BackupElectronic.Text = ((LangArEn == 0) ? "لقد تم تحديد مسار النسخ الالكتروني" : "It has been determined path");
                }
            }
            catch (Exception error)
            {
                textBox_BackupElectronic.Tag = string.Empty;
                textBox_BackupElectronic.Text = ((LangArEn == 0) ? "لم يتم تحديد مسار النسخ الالكتروني" : "It not been determined path");
                VarGeneral.DebLog.writeLog("textBox_BackupElectronic_ButtonCustomClick:", error, enable: true);
            }
        }
        private void textBox_BackupElectronic_ButtonCustom2Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBox_BackupElectronic.Tag.ToString()) && Directory.Exists(VarGeneral.Settings_Sys.SysDir))
                {
                    MessageBox.Show(VarGeneral.Settings_Sys.SysDir);
                }
                else
                {
                    MessageBox.Show((LangArEn == 0) ? "يتعذر الوصول الى مسار النسخ الإحتياطي" : "It not been determined path");
                }
            }
            catch
            {
            }
        }
         
        private void txtEqarsFatherAcc_Click(object sender, EventArgs e)
        {
            txtEqarsFatherAcc.SelectAll();
        }
        private void txtEqarsFatherAcc_ButtonCustomClick(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "T_AccDef_Banks";
            VarGeneral.AccTyp = 1;
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                txtEqarsFatherAcc.Text = _AccDef.AccDef_No.ToString();
                txtEqarsFatherAccName.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(txtEqarsFatherAcc.Text).Arb_Des : db.StockAccDefWithOutBalance(txtEqarsFatherAcc.Text).Eng_Des);
            }
            else
            {
                txtEqarsFatherAcc.Text = string.Empty;
                txtEqarsFatherAccName.Text = string.Empty;
            }
            VarGeneral.Flush();
        }
        private void txtTenantFatherAcc_Click(object sender, EventArgs e)
        {
            txtTenantFatherAcc.SelectAll();
        }
        private void txtTenantFatherAcc_ButtonCustomClick(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "T_AccDef_Banks";
            VarGeneral.AccTyp = 12;
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                txtTenantFatherAcc.Text = _AccDef.AccDef_No.ToString();
                txttenantFatherAccName.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(txtTenantFatherAcc.Text).Arb_Des : db.StockAccDefWithOutBalance(txtTenantFatherAcc.Text).Eng_Des);
            }
            else
            {
                txtTenantFatherAcc.Text = string.Empty;
                txttenantFatherAccName.Text = string.Empty;
            }
            VarGeneral.Flush();
        }
        private void button_RestoreDefContract_Click(object sender, EventArgs e)
        {
            try
            {
                string DefPath = Application.StartupPath + "\\ContractMain.doc";
                File.Copy(DefPath, Application.StartupPath + "\\Contract.doc", overwrite: true);
                MessageBox.Show((LangArEn == 0) ? "لقد تم إستعادة التصميم الإفتراضي بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_RestoreDefContract_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }

        private void ButAddDay_Click(object sender, EventArgs e)
        {
            txtHijriDate.Tag = int.Parse(txtHijriDate.Tag.ToString()) + 1;
            txtGregDate.Text = n.GDateNow();
            txtHijriDate.Text = n.FormatHijri(n.GDateAdd2(n.GregToHijri(txtGregDate.Text, "yyyy/MM/dd"), double.Parse(txtHijriDate.Tag.ToString())), "yyyy/MM/dd");
            Button_Edit_Click(sender, e);
        }
        private void ButDayMinus_Click(object sender, EventArgs e)
        {
            txtHijriDate.Tag = int.Parse(txtHijriDate.Tag.ToString()) - 1;
            txtGregDate.Text = n.GDateNow();
            txtHijriDate.Text = n.FormatHijri(n.GDateAdd2(n.GregToHijri(txtGregDate.Text, "yyyy/MM/dd"), double.Parse(txtHijriDate.Tag.ToString())), "yyyy/MM/dd");
            Button_Edit_Click(sender, e);
        }
        private void textBox_BackupPath_ButtonCustomClick(object sender, EventArgs e)
        {
            try
            {
                if (!(VarGeneral.gUserName == "runsetting") || VarGeneral.UserID == 1)
                {
                    FolderBrowserDialog fbd = new FolderBrowserDialog();
                    DialogResult result = fbd.ShowDialog();
                    textBox_BackupPath.Text = fbd.SelectedPath;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("textBox_BackupPath_ButtonCustomClick:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void checkBox_AutoBackup_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_AutoBackup.Checked)
            {
                comboBox_AutoBackup.Enabled = true;
            }
            else
            {
                comboBox_AutoBackup.Enabled = false;
            }
        }

        private void employeesLabelControl_Click(object sender, EventArgs e)
        {

        }

        private void TXtVatNumbber_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGroupVatNumb_TextChanged(object sender, EventArgs e)
        {

        }

      
        private void splitContainer3_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void c1FlexGrid2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void FillCombo()
        {
            int _CmbIndex = 0;
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                try
                {
                }
                catch
                {
                }
                string s = "2aabbcbbbadef";
                for (int k = 1; k <7; k++)
                {

                    
                }
                List<T_Curency> listCurr = new List<T_Curency>(db.T_Curencies.Select((T_Curency item) => item).ToList());
                CmbCurr.DataSource = listCurr;
                CmbCurr.DisplayMember = "Arb_Des";
                CmbCurr.ValueMember = "Curency_ID";
                CmbCurr.SelectedIndex = 0;
                _CmbIndex = CmbDateTyp.SelectedIndex;
                CmbDateTyp.Items.Clear();
                CmbDateTyp.Items.Add("يوم");
                CmbDateTyp.Items.Add("شهر");
                CmbDateTyp.Items.Add("سنة");
                CmbDateTyp.SelectedIndex = 0;
                CmbPrintTyp.Items.Clear();
                CmbPrintTyp.Items.Add("فاتورة المبيعات فقط");
                CmbPrintTyp.Items.Add("اعدادات التصنيفات فقط");
                CmbPrintTyp.Items.Add("الكــــل");
                try
                {
                    CmbPointImages.Items.Clear();
                    CmbPointImages.Items.Add("عشـــوائــي");
                    CmbPointImages.Items.Add("حسب صورة الصنف");
                    CmbPointImages.Items.Add("بدون صور");
                    CmbPointImages.SelectedIndex = 0;
                }
                catch
                {
                }
                try
                {
                    CmbOrderTyp.Items.Clear();
                    CmbOrderTyp.Items.Add("محلي");
                    CmbOrderTyp.Items.Add("سفري");
                    CmbOrderTyp.SelectedIndex = 0;
                }
                catch
                {
                }
                _CmbIndex = CmbCost.SelectedIndex;
                CmbCost.Items.Clear();
                CmbCost.Items.Add("آخر تكلفة");
                CmbCost.Items.Add("متوسط التكلفة");
                CmbCost.SelectedIndex = 0;
                _CmbIndex = CmbInvMode.SelectedIndex;
                CmbInvMode.Items.Clear();
                CmbInvMode.Items.Add("نقدي");
                CmbInvMode.Items.Add("آجل");
                CmbInvMode.SelectedIndex = 0;
                try
                {
                    FlxInv.SetData(0, 1, "الحساب");
                    FlxInv.SetData(0, 2, "% الإهلاك");
                    FlxInv.SetData(0, 3, "قيـد الإثبـــات");
                    FlxInv.SetData(0, 4, "قيـد الترحيــل");
                }
                catch
                {
                }
                chk36.Items.Clear();
                chk36.Items.Add("القالب الأول");
                chk36.Items.Add("القالب الثاني");
                chk36.Items.Add("القالب الثالث");
                chk36.Items.Add("القالب الرابع");
                chk36.SelectedIndex = 0;
                chk39.Items.Clear();
                chk39.Items.Add("-------");
                chk39.Items.Add("إخفاء الشعار");
                chk39.Items.Add("إخفاء الأسعار");
                chk39.Items.Add("إخفاء الكل");
                chk39.SelectedIndex = 0;
                chk46.Items.Clear();
                chk46.Items.Add("العمولة : نسبـة من الإجمالـي");
                chk46.Items.Add("العمولة : مبلغ ثابت في الكمية");
                chk46.Items.Add("العمولة : مبــــلغ مقطـــــــــوع");
                chk46.SelectedIndex = 0;
                try
                {
                    c1FlexGrid1.SetData(0, 1, "السند");
                    c1FlexGrid1.SetData(0, 2, "طريقة السند");
                    c1FlexGrid1.SetData(0, 3, "إصدار قيد");
                    c1FlexGrid1.SetData(0, 4, "حساب مدين");
                    c1FlexGrid1.SetData(0, 5, "حساب دائن");
                    c1FlexGrid1.SetData(1, 1, "فاتورة مبيعات");
                    c1FlexGrid1.SetData(1, 2, "نقدي");
                    c1FlexGrid1.SetData(1, 6, 1);
                    c1FlexGrid1.SetData(1, 7, 0);
                    c1FlexGrid1.SetData(2, 1, "فاتورة مبيعات");
                    c1FlexGrid1.SetData(2, 2, "آجل");
                    c1FlexGrid1.SetData(2, 6, 1);
                    c1FlexGrid1.SetData(2, 7, 1);
                    c1FlexGrid1.SetData(3, 1, "فاتورة مبيعات");
                    c1FlexGrid1.SetData(3, 2, "شيك");
                    c1FlexGrid1.SetData(3, 6, 1);
                    c1FlexGrid1.SetData(3, 7, 2);
                    c1FlexGrid1.SetData(4, 1, "الخصــــم");
                    c1FlexGrid1.SetData(4, 2, "سند");
                    c1FlexGrid1.SetData(4, 6, 1);
                    c1FlexGrid1.SetData(4, 7, 3);
                    c1FlexGrid1.SetData(5, 1, "فاتورة مشتريات");
                    c1FlexGrid1.SetData(5, 2, "نقدي");
                    c1FlexGrid1.SetData(5, 6, 2);
                    c1FlexGrid1.SetData(5, 7, 0);
                    c1FlexGrid1.SetData(6, 1, "فاتورة مشتريات");
                    c1FlexGrid1.SetData(6, 2, "آجل");
                    c1FlexGrid1.SetData(6, 6, 2);
                    c1FlexGrid1.SetData(6, 7, 1);
                    c1FlexGrid1.SetData(7, 1, "فاتورة مشتريات");
                    c1FlexGrid1.SetData(7, 2, "شيك");
                    c1FlexGrid1.SetData(7, 6, 2);
                    c1FlexGrid1.SetData(7, 7, 2);
                    c1FlexGrid1.SetData(8, 1, "الخصــــم");
                    c1FlexGrid1.SetData(8, 2, "سند");
                    c1FlexGrid1.SetData(8, 6, 2);
                    c1FlexGrid1.SetData(8, 7, 3);
                    c1FlexGrid1.SetData(9, 1, "مرتجع مبيعات");
                    c1FlexGrid1.SetData(9, 2, "نقدي");
                    c1FlexGrid1.SetData(9, 6, 3);
                    c1FlexGrid1.SetData(9, 7, 0);
                    c1FlexGrid1.SetData(10, 1, "مرتجع مبيعات");
                    c1FlexGrid1.SetData(10, 2, "آجل");
                    c1FlexGrid1.SetData(10, 6, 3);
                    c1FlexGrid1.SetData(10, 7, 1);
                    c1FlexGrid1.SetData(11, 1, "مرتجع مبيعات");
                    c1FlexGrid1.SetData(11, 2, "شيك");
                    c1FlexGrid1.SetData(11, 6, 3);
                    c1FlexGrid1.SetData(11, 7, 2);
                    c1FlexGrid1.SetData(12, 1, "الخصــــم");
                    c1FlexGrid1.SetData(12, 2, "سند");
                    c1FlexGrid1.SetData(12, 6, 3);
                    c1FlexGrid1.SetData(12, 7, 3);
                    c1FlexGrid1.SetData(13, 1, "مرتجع مشتريات");
                    c1FlexGrid1.SetData(13, 2, "نقدي");
                    c1FlexGrid1.SetData(13, 6, 4);
                    c1FlexGrid1.SetData(13, 7, 0);
                    c1FlexGrid1.SetData(14, 1, "مرتجع مشتريات");
                    c1FlexGrid1.SetData(14, 2, "آجل");
                    c1FlexGrid1.SetData(14, 6, 4);
                    c1FlexGrid1.SetData(14, 7, 1);
                    c1FlexGrid1.SetData(15, 1, "مرتجع مشتريات");
                    c1FlexGrid1.SetData(15, 2, "شيك");
                    c1FlexGrid1.SetData(15, 6, 4);
                    c1FlexGrid1.SetData(15, 7, 2);
                    c1FlexGrid1.SetData(16, 1, "الخصــــم");
                    c1FlexGrid1.SetData(16, 2, "سند");
                    c1FlexGrid1.SetData(16, 6, 4);
                    c1FlexGrid1.SetData(16, 7, 3);
                    c1FlexGrid1.SetData(17, 1, "سند أدخال بضاعة");
                    c1FlexGrid1.SetData(17, 2, "سند");
                    c1FlexGrid1.SetData(17, 6, 5);
                    c1FlexGrid1.SetData(17, 7, 0);
                    c1FlexGrid1.SetData(18, 1, "الخصــــم");
                    c1FlexGrid1.SetData(18, 2, "سند");
                    c1FlexGrid1.SetData(18, 6, 5);
                    c1FlexGrid1.SetData(18, 7, 3);
                    c1FlexGrid1.SetData(19, 1, "سند أخراج بضاعة");
                    c1FlexGrid1.SetData(19, 2, "سند");
                    c1FlexGrid1.SetData(19, 6, 6);
                    c1FlexGrid1.SetData(19, 7, 0);
                    c1FlexGrid1.SetData(20, 1, "الخصــــم");
                    c1FlexGrid1.SetData(20, 2, "سند");
                    c1FlexGrid1.SetData(20, 6, 6);
                    c1FlexGrid1.SetData(20, 7, 3);
                    c1FlexGrid1.SetData(21, 1, "عرض سعر عملاء");
                    c1FlexGrid1.SetData(21, 2, "سند");
                    c1FlexGrid1.SetData(21, 6, 7);
                    c1FlexGrid1.SetData(21, 7, 0);
                    c1FlexGrid1.SetData(22, 1, "الخصــــم");
                    c1FlexGrid1.SetData(22, 2, "سند");
                    c1FlexGrid1.SetData(22, 6, 7);
                    c1FlexGrid1.SetData(22, 7, 3);
                    c1FlexGrid1.SetData(23, 1, "عرض سعر مورد");
                    c1FlexGrid1.SetData(23, 2, "سند");
                    c1FlexGrid1.SetData(23, 6, 8);
                    c1FlexGrid1.SetData(23, 7, 0);
                    c1FlexGrid1.SetData(24, 1, "الخصــــم");
                    c1FlexGrid1.SetData(24, 2, "سند");
                    c1FlexGrid1.SetData(24, 6, 8);
                    c1FlexGrid1.SetData(24, 7, 3);
                    c1FlexGrid1.SetData(25, 1, "طلب شراء");
                    c1FlexGrid1.SetData(25, 2, "سند");
                    c1FlexGrid1.SetData(25, 6, 9);
                    c1FlexGrid1.SetData(25, 7, 0);
                    c1FlexGrid1.SetData(26, 1, "الخصــــم");
                    c1FlexGrid1.SetData(26, 2, "سند");
                    c1FlexGrid1.SetData(26, 6, 9);
                    c1FlexGrid1.SetData(26, 7, 3);
                    c1FlexGrid1.SetData(27, 1, "سند تسوية بضاعة");
                    c1FlexGrid1.SetData(27, 2, "سند");
                    c1FlexGrid1.SetData(27, 6, 10);
                    c1FlexGrid1.SetData(27, 7, 0);
                    c1FlexGrid1.SetData(28, 1, "الخصــــم");
                    c1FlexGrid1.SetData(28, 2, "سند");
                    c1FlexGrid1.SetData(28, 6, 10);
                    c1FlexGrid1.SetData(28, 7, 3);
                    c1FlexGrid1.SetData(29, 1, "بضاعة اول المدة");
                    c1FlexGrid1.SetData(29, 2, "سند");
                    c1FlexGrid1.SetData(29, 6, 14);
                    c1FlexGrid1.SetData(29, 7, 0);
                    c1FlexGrid1.SetData(30, 1, "الخصــــم");
                    c1FlexGrid1.SetData(30, 2, "سند");
                    c1FlexGrid1.SetData(30, 6, 14);
                    c1FlexGrid1.SetData(30, 7, 3);
                    c1FlexGrid1.SetData(31, 1, "أمر صرف بضاعة");
                    c1FlexGrid1.SetData(31, 2, "سند");
                    c1FlexGrid1.SetData(31, 6, 17);
                    c1FlexGrid1.SetData(31, 7, 0);
                    c1FlexGrid1.SetData(32, 1, "الخصــــم");
                    c1FlexGrid1.SetData(32, 2, "سند");
                    c1FlexGrid1.SetData(32, 6, 17);
                    c1FlexGrid1.SetData(32, 7, 3);
                    c1FlexGrid1.SetData(33, 1, "مرتجع صرف بضاعة");
                    c1FlexGrid1.SetData(33, 2, "سند");
                    c1FlexGrid1.SetData(33, 6, 20);
                    c1FlexGrid1.SetData(33, 7, 0);
                    c1FlexGrid1.SetData(34, 1, "الخصــــم");
                    c1FlexGrid1.SetData(34, 2, "سند");
                    c1FlexGrid1.SetData(34, 6, 20);
                    c1FlexGrid1.SetData(34, 7, 3);
                    c1FlexGrid1.SetData(35, 1, "إنتاج الأصناف - تصنيع");
                    c1FlexGrid1.SetData(35, 2, "سند");
                    c1FlexGrid1.SetData(35, 6, 16);
                    c1FlexGrid1.SetData(35, 7, 0);
                    c1FlexGrid1.SetData(36, 1, "الخصــــم");
                    c1FlexGrid1.SetData(36, 2, "سند");
                    c1FlexGrid1.SetData(36, 6, 16);
                    c1FlexGrid1.SetData(36, 7, 3);
                }
                catch
                {
                }
            }
            else
            {
                List<T_Curency> listCurr = new List<T_Curency>(db.T_Curencies.Select((T_Curency item) => item).ToList());
                CmbCurr.DataSource = listCurr;
                CmbCurr.DisplayMember = "Eng_Des";
                CmbCurr.ValueMember = "Curency_ID";
                CmbCurr.SelectedIndex = 0;
                _CmbIndex = CmbDateTyp.SelectedIndex;
                CmbDateTyp.Items.Clear();
                CmbDateTyp.Items.Add("Day");
                CmbDateTyp.Items.Add("Month");
                CmbDateTyp.Items.Add("Year");
                CmbDateTyp.SelectedIndex = 0;
                _CmbIndex = CmbCost.SelectedIndex;
                CmbCost.Items.Clear();
                CmbCost.Items.Add("Last Cost");
                CmbCost.Items.Add("Average Cost");
                CmbCost.SelectedIndex = 0;
                CmbPrintTyp.Items.Clear();
                CmbPrintTyp.Items.Add("Sales only");
                CmbPrintTyp.Items.Add("Categories only");
                CmbPrintTyp.Items.Add("ALL");
                CmbPrintTyp.SelectedIndex = 0;
                try
                {
                    CmbPointImages.Items.Clear();
                    CmbPointImages.Items.Add("Random");
                    CmbPointImages.Items.Add("By Image Item");
                    CmbPointImages.Items.Add("WithOut Images");
                    CmbPointImages.SelectedIndex = 0;
                }
                catch
                {
                }
                try
                {
                    CmbOrderTyp.Items.Clear();
                    CmbOrderTyp.Items.Add("Localy");
                    CmbOrderTyp.Items.Add("Out");
                    CmbOrderTyp.SelectedIndex = 0;
                }
                catch
                {
                }
                _CmbIndex = CmbInvMode.SelectedIndex;
                CmbInvMode.Items.Clear();
                CmbInvMode.Items.Add("Cash");
                CmbInvMode.Items.Add("Credit");
                CmbInvMode.SelectedIndex = 0;
                try
                {
                    FlxInv.SetData(0, 1, "Account Name");
                    FlxInv.SetData(0, 2, "destruction %");
                    FlxInv.SetData(0, 3, "Proof");
                    FlxInv.SetData(0, 4, "Relay");
                }
                catch
                {
                }
                chk36.Items.Clear();
                chk36.Items.Add("First Template");
                chk36.Items.Add("Second Template");
                chk36.Items.Add("Third Template");
                chk36.Items.Add("Four Template");
                chk36.SelectedIndex = 0;
                chk39.Items.Clear();
                chk39.Items.Add("-------");
                chk39.Items.Add("Logo Hide");
                chk39.Items.Add("Prices Hide");
                chk39.Items.Add("ALL Hide");
                chk39.SelectedIndex = 0;
                chk46.Items.Clear();
                chk46.Items.Add("Comm %");
                chk46.Items.Add("Comm Amount * Quantity");
                chk46.Items.Add("Comm Static Value");
                chk46.SelectedIndex = 0;
                try
                {
                    c1FlexGrid1.SetData(0, 1, "Receipt");
                    c1FlexGrid1.SetData(0, 2, "Type");
                    c1FlexGrid1.SetData(0, 3, "Launch");
                    c1FlexGrid1.SetData(0, 4, "Debit Account");
                    c1FlexGrid1.SetData(0, 5, "Credit Account");
                    c1FlexGrid1.SetData(1, 1, "Sales Invoice");
                    c1FlexGrid1.SetData(1, 2, "Cash");
                    c1FlexGrid1.SetData(1, 6, 1);
                    c1FlexGrid1.SetData(1, 7, 0);
                    c1FlexGrid1.SetData(2, 1, "Sales Invoice");
                    c1FlexGrid1.SetData(2, 2, "Credit");
                    c1FlexGrid1.SetData(2, 6, 1);
                    c1FlexGrid1.SetData(2, 7, 1);
                    c1FlexGrid1.SetData(3, 1, "Sales Invoice");
                    c1FlexGrid1.SetData(3, 2, "Check");
                    c1FlexGrid1.SetData(3, 6, 1);
                    c1FlexGrid1.SetData(3, 7, 2);
                    c1FlexGrid1.SetData(4, 1, "Discount");
                    c1FlexGrid1.SetData(4, 2, "Receipt");
                    c1FlexGrid1.SetData(4, 6, 1);
                    c1FlexGrid1.SetData(4, 7, 3);
                    c1FlexGrid1.SetData(5, 1, "Purchase Receipt");
                    c1FlexGrid1.SetData(5, 2, "Cash");
                    c1FlexGrid1.SetData(5, 6, 2);
                    c1FlexGrid1.SetData(5, 7, 0);
                    c1FlexGrid1.SetData(6, 1, "Purchase Receipt");
                    c1FlexGrid1.SetData(6, 2, "Credit");
                    c1FlexGrid1.SetData(6, 6, 2);
                    c1FlexGrid1.SetData(6, 7, 1);
                    c1FlexGrid1.SetData(7, 1, "Purchase Receipt");
                    c1FlexGrid1.SetData(7, 2, "Check");
                    c1FlexGrid1.SetData(7, 6, 2);
                    c1FlexGrid1.SetData(7, 7, 2);
                    c1FlexGrid1.SetData(8, 1, "Discount");
                    c1FlexGrid1.SetData(8, 2, "Receipt");
                    c1FlexGrid1.SetData(8, 6, 2);
                    c1FlexGrid1.SetData(8, 7, 3);
                    c1FlexGrid1.SetData(9, 1, "Sales Return");
                    c1FlexGrid1.SetData(9, 2, "Cash");
                    c1FlexGrid1.SetData(9, 6, 3);
                    c1FlexGrid1.SetData(9, 7, 0);
                    c1FlexGrid1.SetData(10, 1, "Sales Return");
                    c1FlexGrid1.SetData(10, 2, "Credit");
                    c1FlexGrid1.SetData(10, 6, 3);
                    c1FlexGrid1.SetData(10, 7, 1);
                    c1FlexGrid1.SetData(11, 1, "Sales Return");
                    c1FlexGrid1.SetData(11, 2, "Check");
                    c1FlexGrid1.SetData(11, 6, 3);
                    c1FlexGrid1.SetData(11, 7, 2);
                    c1FlexGrid1.SetData(12, 1, "Discount");
                    c1FlexGrid1.SetData(12, 2, "Receipt");
                    c1FlexGrid1.SetData(12, 6, 3);
                    c1FlexGrid1.SetData(12, 7, 3);
                    c1FlexGrid1.SetData(13, 1, "Purchase Return");
                    c1FlexGrid1.SetData(13, 2, "Cash");
                    c1FlexGrid1.SetData(13, 6, 4);
                    c1FlexGrid1.SetData(13, 7, 0);
                    c1FlexGrid1.SetData(14, 1, "Purchase Return");
                    c1FlexGrid1.SetData(14, 2, "Credit");
                    c1FlexGrid1.SetData(14, 6, 4);
                    c1FlexGrid1.SetData(14, 7, 1);
                    c1FlexGrid1.SetData(15, 1, "Purchase Return");
                    c1FlexGrid1.SetData(15, 2, "Check");
                    c1FlexGrid1.SetData(15, 6, 4);
                    c1FlexGrid1.SetData(15, 7, 2);
                    c1FlexGrid1.SetData(16, 1, "Discount");
                    c1FlexGrid1.SetData(16, 2, "Receipt");
                    c1FlexGrid1.SetData(16, 6, 4);
                    c1FlexGrid1.SetData(16, 7, 3);
                    c1FlexGrid1.SetData(17, 1, "Transfer In");
                    c1FlexGrid1.SetData(17, 2, "Receipt");
                    c1FlexGrid1.SetData(17, 6, 5);
                    c1FlexGrid1.SetData(17, 7, 0);
                    c1FlexGrid1.SetData(18, 1, "Discount");
                    c1FlexGrid1.SetData(18, 2, "Receipt");
                    c1FlexGrid1.SetData(18, 6, 5);
                    c1FlexGrid1.SetData(18, 7, 3);
                    c1FlexGrid1.SetData(19, 1, "Transfer Out");
                    c1FlexGrid1.SetData(19, 2, "Receipt");
                    c1FlexGrid1.SetData(19, 6, 6);
                    c1FlexGrid1.SetData(19, 7, 0);
                    c1FlexGrid1.SetData(20, 1, "Discount");
                    c1FlexGrid1.SetData(20, 2, "Receipt");
                    c1FlexGrid1.SetData(20, 6, 6);
                    c1FlexGrid1.SetData(20, 7, 3);
                    c1FlexGrid1.SetData(21, 1, "Customer Qutation");
                    c1FlexGrid1.SetData(21, 2, "Receipt");
                    c1FlexGrid1.SetData(21, 6, 7);
                    c1FlexGrid1.SetData(21, 7, 0);
                    c1FlexGrid1.SetData(22, 1, "Discount");
                    c1FlexGrid1.SetData(22, 2, "Receipt");
                    c1FlexGrid1.SetData(22, 6, 7);
                    c1FlexGrid1.SetData(22, 7, 3);
                    c1FlexGrid1.SetData(23, 1, "Supplier Qutation");
                    c1FlexGrid1.SetData(23, 2, "Receipt");
                    c1FlexGrid1.SetData(23, 6, 8);
                    c1FlexGrid1.SetData(23, 7, 0);
                    c1FlexGrid1.SetData(24, 1, "Discount");
                    c1FlexGrid1.SetData(24, 2, "Receipt");
                    c1FlexGrid1.SetData(24, 6, 8);
                    c1FlexGrid1.SetData(24, 7, 3);
                    c1FlexGrid1.SetData(25, 1, "Purchase Order");
                    c1FlexGrid1.SetData(25, 2, "Receipt");
                    c1FlexGrid1.SetData(25, 6, 9);
                    c1FlexGrid1.SetData(25, 7, 0);
                    c1FlexGrid1.SetData(26, 1, "Discount");
                    c1FlexGrid1.SetData(26, 2, "Receipt");
                    c1FlexGrid1.SetData(26, 6, 9);
                    c1FlexGrid1.SetData(26, 7, 3);
                    c1FlexGrid1.SetData(27, 1, "Stock Adjustment");
                    c1FlexGrid1.SetData(27, 2, "Receipt");
                    c1FlexGrid1.SetData(27, 6, 10);
                    c1FlexGrid1.SetData(27, 7, 0);
                    c1FlexGrid1.SetData(28, 1, "Discount");
                    c1FlexGrid1.SetData(28, 2, "Receipt");
                    c1FlexGrid1.SetData(28, 6, 10);
                    c1FlexGrid1.SetData(28, 7, 3);
                    c1FlexGrid1.SetData(29, 1, "Open Quantities");
                    c1FlexGrid1.SetData(29, 2, "Receipt");
                    c1FlexGrid1.SetData(29, 6, 14);
                    c1FlexGrid1.SetData(29, 7, 0);
                    c1FlexGrid1.SetData(30, 1, "Discount");
                    c1FlexGrid1.SetData(30, 2, "Receipt");
                    c1FlexGrid1.SetData(30, 6, 14);
                    c1FlexGrid1.SetData(30, 7, 3);
                    c1FlexGrid1.SetData(31, 1, "Payment Order");
                    c1FlexGrid1.SetData(31, 2, "Receipt");
                    c1FlexGrid1.SetData(31, 6, 17);
                    c1FlexGrid1.SetData(31, 7, 0);
                    c1FlexGrid1.SetData(32, 1, "Discount");
                    c1FlexGrid1.SetData(32, 2, "Receipt");
                    c1FlexGrid1.SetData(32, 6, 17);
                    c1FlexGrid1.SetData(32, 7, 3);
                    c1FlexGrid1.SetData(33, 1, "Payment Order Return");
                    c1FlexGrid1.SetData(33, 2, "Receipt");
                    c1FlexGrid1.SetData(33, 6, 20);
                    c1FlexGrid1.SetData(33, 7, 0);
                    c1FlexGrid1.SetData(34, 1, "Discount");
                    c1FlexGrid1.SetData(34, 2, "Receipt");
                    c1FlexGrid1.SetData(34, 6, 20);
                    c1FlexGrid1.SetData(34, 7, 3);
                    c1FlexGrid1.SetData(35, 1, "Production of varieties - Manufacture");
                    c1FlexGrid1.SetData(35, 2, "Receipt");
                    c1FlexGrid1.SetData(35, 6, 16);
                    c1FlexGrid1.SetData(35, 7, 0);
                    c1FlexGrid1.SetData(36, 1, "Discount");
                    c1FlexGrid1.SetData(36, 2, "Receipt");
                    c1FlexGrid1.SetData(36, 6, 16);
                    c1FlexGrid1.SetData(36, 7, 3);
                }
                catch
                {
                }
            }
            CmbCalendar.Items.Clear();
            CmbCalendar.Items.Add((LangArEn == 0) ? "التقويم الميــلادي" : "Gregoian");
            CmbCalendar.Items.Add((LangArEn == 0) ? "التقويم الهجري" : "Hijri");
            CmbCalendar.SelectedIndex = 0;
            comboBox_AutoBackup.Items.Clear();
            comboBox_AutoBackup.Items.Add((LangArEn == 0) ? "كل ربع ساعة" : "Every quarter of an hour");
            comboBox_AutoBackup.Items.Add((LangArEn == 0) ? "كل نصف ساعة" : "Every half-hour");
            comboBox_AutoBackup.Items.Add((LangArEn == 0) ? "كل ساعة" : "Every hour");
            comboBox_AutoBackup.Items.Add((LangArEn == 0) ? "كل يوم" : "Every Day");
            comboBox_AutoBackup.Items.Add((LangArEn == 0) ? "كل يومين" : "Every Tow Day");
            comboBox_AutoBackup.Items.Add((LangArEn == 0) ? "كل ثلاث أيام" : "Every Three Day");
            comboBox_AutoBackup.Items.Add((LangArEn == 0) ? "كل أسبوع" : "Every Week");
            comboBox_AutoBackup.Items.Add((LangArEn == 0) ? "كل أسبوعين" : "Every Tow Week");
            comboBox_AutoBackup.Items.Add((LangArEn == 0) ? "كل شهر" : "Every Month");
            comboBox_AutoBackup.SelectedIndex = 0;
            CmbMail.Items.Clear();
            CmbMail.Items.Add("Hotmail");
            CmbMail.Items.Add("Gmail");
            CmbMail.Items.Add("Yahoo");
            CmbMail.SelectedIndex = 0;
            try
            {
                if (superTabItem_Employee.Visible)
                {
                    List<T_OpMethod> listCalculateNo = new List<T_OpMethod>((from item in db.T_OpMethods
                                                                             orderby item.Method_No
                                                                             where item.Method_No != 1 && item.Method_No != 5 && item.Method_No != 6 && item.Method_No != 7 && item.Method_No != 9 && item.Method_No != 10 && item.Method_No != 10 && item.Method_No != 11 && item.Method_No != 12 && item.Method_No != 13
                                                                             select item).ToList());
                    comboBox_CalculateNo.DataSource = listCalculateNo;
                    comboBox_CalculateNo.DisplayMember = ((LangArEn == 0) ? "Name" : "NameE");
                    comboBox_CalculateNo.ValueMember = "Method_No";
                    List<T_OpMethod> listCalculatliquidNo = new List<T_OpMethod>((from item in db.T_OpMethods
                                                                                  orderby item.Method_No
                                                                                  where item.Method_No != 1 && item.Method_No != 5 && item.Method_No != 6 && item.Method_No != 7 && item.Method_No != 8 && item.Method_No != 9 && item.Method_No != 10 && item.Method_No != 10 && item.Method_No != 11 && item.Method_No != 12 && item.Method_No != 13
                                                                                  select item).ToList());
                    comboBox_CalculatliquidNo.DataSource = listCalculatliquidNo;
                    comboBox_CalculatliquidNo.DisplayMember = ((LangArEn == 0) ? "Name" : "NameE");
                    comboBox_CalculatliquidNo.ValueMember = "Method_No";
                    List<T_OpMethod> listVacTypeNo = new List<T_OpMethod>((from item in db.T_OpMethods
                                                                           orderby item.Method_No
                                                                           where item.Method_No == 3 || item.Method_No == 4 || item.Method_No == 7
                                                                           select item).ToList());
                    comboBox_DisVacationType.DataSource = listVacTypeNo;
                    comboBox_DisVacationType.DisplayMember = ((LangArEn == 0) ? "Name" : "NameE");
                    comboBox_DisVacationType.ValueMember = "Method_No";
                }
            }
            catch
            {
            }
            CmbCurr.SelectedIndex = _CmbIndex;
            RibunButtons();
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                ButWithSave.Text = "حفظ";
             
                ButWithoutSave.Text = "خروج";
        
                label1.Text = "الإسم العربي :";
                label2.Text = "العنوان العربي :";
                label3.Text = "الإسم الإنجليزي :";
                label4.Text = "العنوان الإنجليزي :";
                label5.Text = "تقويم النظام :";
                label6.Text = "التاريخ / ميلادي :";
                label7.Text = "التاريخ / هجري :";
                label8.Text = "سعر التكلفة المعتمدة :";
                label9.Text = "طريقة الدفع المعتمدة :";
                label10.Text = "حساب بضاعة أول المدة";
                label11.Text = "حساب بضاعة أخر المدة";
                label12.Text = "حساب الصنـــــــــدوق";
                label13.Text = "حساب الأرباح والخسائر";
                superTabItem_Banner.Text = "بيانات الشركة";
                //superTabItem_Company.Text = "المنشأة";
                Bar_Accounts.Text = "اعدادات الحسابات";
                Bar_Invsale.Text = "الفواتير";
                superTabItem_General.Text = "عــــام";
                //groupPanel_Banner.Text = "الشعــار";
                label25.Text = "مسار النسخ الإحتياطــــــي :";
                label24.Text = "خدمة النسخ الإحتياطي الألكتروني :";
                dateTimeInput_DT.ButtonCustom.Text = "تاريخ إنتهاء إشتراكك في الخدمة";
                button_Background.Tooltip = "صورة خلفية النظام";
                button_RemoveBackgroud.Tooltip = "ازالة صورة خلفية النظام";
               // groupbox_AutoAcc.Text = "الحسابات التلقائيــة";
                expandablePanel_AutoAcc.TitleText = string.Empty;
                //checkBox_previewPrintRep.Text = "تعيين الإعدادات الإفتراضية";
                //RedButCasherRep.Text = "ورق كاشيير";
                //superTabItem1.Text = "الطابعات";
                superTabItem_Employee.Text = "شؤون الموظفين";
                checkBox_AttendanceManually.Text = "السماح بإدخال وقت الحضور يدويا\u064e";
                checkBox_AutoLeave.Text = "صـــرف الموظفــــين تلقــــائيا بعد ";
                button_DayofMonth.Text = "شهـــــور السنـــة";
                button_DocPath.Tooltip = "إستعراض";
                expandablePanel_Alarm.TitleText = "التنبيهــــــات";
                expandablePanel_NewColumn.TitleText = "خيارات إضافة عمود للفواتير";
                node1.Text = "فاتورة مبيعات";
                chk1Show.Text = "شاشة العرض";
                chk1Print.Text = "طباعة التقرير";
                node2.Text = "مرتجع مبيعات";
                chk2Show.Text = "شاشة العرض";
                chk2Print.Text = "طباعة التقرير";
                node3.Text = "فاتورة مشتريات";
                chk3Show.Text = "شاشة العرض";
                chk3Print.Text = "طباعة التقرير";
                node4.Text = "مرتجع مشتريات";
                chk4Show.Text = "شاشة العرض";
                chk4Print.Text = "طباعة التقرير";
                node5.Text = "عرض سعر للعملاء";
                chk5Show.Text = "شاشة العرض";
                chk5Print.Text = "طباعة التقرير";
                node6.Text = "عرض سعر للموردين";
                chk6Show.Text = "شاشة العرض";
                chk6Print.Text = "طباعة التقرير";
                node7.Text = "طلب شراء";
                chk7Show.Text = "شاشة العرض";
                chk7Print.Text = "طباعة التقرير";
                node8.Text = "بضاعة أول المدة";
                chk8Show.Text = "شاشة العرض";
                chk8Print.Text = "طباعة التقرير";
                node9.Text = "إدخال بضاعة";
                chk9Show.Text = "شاشة العرض";
                chk9Print.Text = "طباعة التقرير";
                node10.Text = "إخراج بضاعة";
                chk10Show.Text = "شاشة العرض";
                chk10Print.Text = "طباعة التقرير";
                node11.Text = "صرف بضاعة";
                chk11Show.Text = "شاشة العرض";
                chk11Print.Text = "طباعة التقرير";
                node12.Text = "مرتجع صرف بضاعة";
                chk12Show.Text = "شاشة العرض";
                chk12Print.Text = "طباعة التقرير";
                node13.Text = "تسوية البضاعة";
                chk13Show.Text = "شاشة العرض";
                chk13Print.Text = "طباعة التقرير";
                node14.Text = "شاشة نقـاط البيـع";
                chk14Show.Text = "شاشة العرض";
                chk14Print.Text = "طباعة التقرير";
                chk37.OffText = "المزامنة بشكل تلقائي";
                chk37.OnText = "المزامنة بشكل تلقائي";
                button_ManageRoom.Text = "إدارة الغرف / الشقق في الطوابق";
                Bar_Eqarat.Text = "خيارات العقار";
                Text = "تهيئة النظام";
            }
            else
            {
                ButWithSave.Text = "Save";
                ButWithoutSave.Text = "Exit";
                
                label1.Text = "Arabic Name :";
                label2.Text = "Arabic Address :";
                label3.Text = "English Name :";
                label4.Text = "English Address :";
                label5.Text = "Calendar system :";
                label6.Text = "Date / Gregorian :";
                label7.Text = "Date / Hijri :";
                label8.Text = "Approved cost price :";
                label9.Text = "Approved payment method :";
                label10.Text = "first-term stock account";
                label11.Text = "last-term stock account";
                label12.Text = "Box Account";
                label13.Text = "Profit and loss account";
                superTabItem_Banner.Text = "Banner Data";
                //superTabItem_Company.Text = "Company";
                Bar_Accounts.Text = "Accounting";
                Bar_Invsale.Text = "Invoices";
                superTabItem_General.Text = "General";
               // groupPanel_Banner.Text = "Banner";
                label25.Text = "Backup Path :";
                label24.Text = "Electronic Backup Service:";
                dateTimeInput_DT.ButtonCustom.Text = "Service End Date";
                button_Background.Tooltip = "Backgroud Image";
                button_RemoveBackgroud.Tooltip = "Remove Background Image";
                //groupbox_AutoAcc.Text = "Auto Accounts";
                expandablePanel_AutoAcc.TitleText = string.Empty;
                //checkBox_previewPrintRep.Text = "Defualt Setting";
                //RedButPaperA4Rep.Text = "A4 Peaper";
                //RedButCasherRep.Text = "Cashier Peaper";
                //superTabItem1.Text = "Printers";
                superTabItem_Employee.Text = "Employee";
                checkBox_AttendanceManually.Text = "Allow the introduction of time attendance manually";
                checkBox_AutoLeave.Text = "Staff exchange automatically after";
                button_DayofMonth.Text = "Months of the year";
                button_DocPath.Tooltip = "Browser";
                expandablePanel_Alarm.TitleText = "Alerts";
                expandablePanel_NewColumn.TitleText = "New Column In Invoices Options";
                node1.Text = "Sales invoice";
                chk1Show.Text = "Show Form";
                chk1Print.Text = "Print Report";
                node2.Text = "Returned sales invoice";
                chk2Show.Text = "Show Form";
                chk2Print.Text = "Print Report";
                node3.Text = "Purchases invoice";
                chk3Show.Text = "Show Form";
                chk3Print.Text = "Print Report";
                node4.Text = "Returned Purchases invoice";
                chk4Show.Text = "Show Form";
                chk4Print.Text = "Print Report";
                node5.Text = "Quote clients";
                chk5Show.Text = "Show Form";
                chk5Print.Text = "Print Report";
                node6.Text = "Quote suppliers";
                chk6Show.Text = "Show Form";
                chk6Print.Text = "Print Report";
                node7.Text = "Purchase Order";
                chk7Show.Text = "Show Form";
                chk7Print.Text = "Print Report";
                node8.Text = "Quantitative opening";
                chk8Show.Text = "Show Form";
                chk8Print.Text = "Print Report";
                node9.Text = "The introduction of goods";
                chk9Show.Text = "Show Form";
                chk9Print.Text = "Print Report";
                node10.Text = "Directed by goods";
                chk10Show.Text = "Show Form";
                chk10Print.Text = "Print Report";
                node11.Text = "Exchange of goods";
                chk11Show.Text = "Show Form";
                chk11Print.Text = "Print Report";
                node12.Text = "Returned Exchange of goods";
                chk12Show.Text = "Show Form";
                chk12Print.Text = "Print Report";
                node13.Text = "Settlement goods";
                chk13Show.Text = "Show Form";
                chk13Print.Text = "Print Report";
                node14.Text = "POS Form";
                chk14Show.Text = "Show Form";
                chk14Print.Text = "Print Report";
                chk37.OffText = "Synchronize data Automatically";
                chk37.OnText = "Synchronize data Automatically";
                Bar_Eqarat.Text = "Real Estate";
              Bar_Hotil.Text = "Hotel Options";
                label60.Text = "Number of floors in the hotel";
                label59.Text = "Floor";
                label61.Text = "Number of rooms in the floor";
                label62.Text = "Room";
                label63.Text = "Grace period";
                label64.Text = "Departure Period";
                label65.Text = "Days Of Month";
                label66.Text = "Day";
                label67.Text = "Distance the area of the boxes of rooms";
                label68.Text = "linear";
                label69.Text = "Point";
                label70.Text = "accidental";
                label71.Text = "Point";
                label80.Text = "Color Options Boxes Rooms";
                txtREmpty.Text = "Empty";
                txtRAvailable.Text = "Available";
                txtRBussyDaily.Text = "Bussy Daily";
                txtRBussyAppendix.Text = "Bussy Appendix";
                txtRClean.Text = "Cleaning";
                txtRRepair.Text = "Maintenance";
                txtRBussyMonthly.Text = "Bussy Monthly";
                txtRLeave.Text = "Departure";
                button_F1.Tooltip = "Font Color";
                button_F2.Tooltip = "Font Color";
                button_F3.Tooltip = "Font Color";
                button_F4.Tooltip = "Font Color";
                button_F5.Tooltip = "Font Color";
                button_F6.Tooltip = "Font Color";
                button_F7.Tooltip = "Font Color";
                button_F8.Tooltip = "Font Color";
                button_B1.Tooltip = "Background Color";
                button_B2.Tooltip = "Background Color";
                button_B3.Tooltip = "Background Color";
                button_B4.Tooltip = "Background Color";
                button_B5.Tooltip = "Background Color";
                button_B6.Tooltip = "Background Color";
                button_B7.Tooltip = "Background Color";
                button_B8.Tooltip = "Background Color";
                button_ManageRoom.Text = "Management of rooms / apartments on floors";
                Text = "System Settings";
            }
        }
        void setbilloption(int r, bool t)
        {
            c1FlexGrid2.SetData(r, 2, t);
        }
        char getbool(int i)
        {
            bool c = (bool)c1FlexGrid2.GetData(i, 2);
            if (c == true)
                return '1';
            else
                return '0';
        }
        void filloptions()
        {
            // c1FlexGrid2.SetData(1, 0, "ظهور الخصم عند اصدار الفاتورة");
            c1FlexGrid2.SetData(1, 1, "ظهور الخصم عند اصدار الفاتورة");
            c1FlexGrid2.SetData(2, 1, "اختيار المندوب في فاتورة المبيعات");
            c1FlexGrid2.SetData(3, 1, "إضهار تاريخ صلاحية الصنف عند طباعة الفواتير ");
            c1FlexGrid2.SetData(4, 1, "إضهار رقم تصنيع الصنف عند طباعة الفواتير");
            c1FlexGrid2.SetData(5, 1, "تحويل تكلفة الصنف الى سعر العملة الإفتراضيه");
            c1FlexGrid2.SetData(6, 1, "إظهار الوصف العكسي عرب / انج لفواتير الكاشير");
            c1FlexGrid2.SetData(7, 1, "دمج الإصناف المكرره تلقائيا في الفاتورة");
            c1FlexGrid2.SetData(8, 1, "إضهار اعدادات الطباعه عند طباعه الباركود");
            c1FlexGrid2.SetData(9, 1, "إيقاف مزامنه التاريخ للويندوز");
            c1FlexGrid2.SetData(10, 1, "طباعة الباركود في الفاتورة حسب الكمية");
            c1FlexGrid2.SetData(11, 1, "إختيار العميل في فاتورة المبيعات");
            c1FlexGrid2.SetData(12, 1, "تمكين نوع الفاتورة الآجلة لنقاط البيع");
            c1FlexGrid2.SetData(13, 1, "رسالة بإعادة تسلسل الفواتير عند ترحيل الصندوق");
            c1FlexGrid2.SetData(14, 1, "إعتماد تصميم الشاشه المكبرة للفاتورة المبيعات");
            c1FlexGrid2.SetData(15, 1, "إظهار جميع الحسابات المالية في الفواتير ");
            c1FlexGrid2.SetData(16, 1, "ظهور العملاء في فواتير الشراء");
            c1FlexGrid2.SetData(17, 1, "ظهور الموردين في فواتير البيع");
            c1FlexGrid2.SetData(18, 1, "السماح بالكميات الغير صحيحة (الكسرية ) في الفواتير");
            c1FlexGrid2.SetData(19, 1, "إظهار رقم سيريال الصنف في الفواتير");
            c1FlexGrid2.SetData(20, 1, "ظهور محتويات الصنف التجميعي في التقرير");
            c1FlexGrid2.SetData(21, 1, "ظهور رقم المستودع في تقرير الفواتير");
            c1FlexGrid2.SetData(22, 1, "إعتماد شاشه البحث السريع في الفواتير");
            c1FlexGrid2.SetData(23, 1, "إظهار ازرار إدراج الأصناف في فواتير الجرد");
            c1FlexGrid2.SetData(24, 1, "إظهار شاشة المدفوعات في المبيعات");
            c1FlexGrid2.SetData(25, 1, "رسالة نصية للعميل بعد البيع");
            c1FlexGrid2.SetData(26, 1, "اصدار فاتورة ادخال بضاعة بعد اخراج البضاعة تلقائيا");
            c1FlexGrid2.SetData(27, 1, "إظهار رسالة الطباعة عند حفظ فاتورة المشتريات");
            c1FlexGrid2.SetData(28, 1, "سعر اخر صرف للمندوب من الوحدة 1 للصنف");
            c1FlexGrid2.SetData(29, 1, "إخفاء كامل لجميع خيارات نقاط العملاء");
            c1FlexGrid2.SetData(30, 1, "إعتماد الحجم القياسي لشاشه نقاط البيع");
            c1FlexGrid2.SetData(31, 1, "تمكين الإضافة التلقائية لفاتورة المبيعات - الباركود");
            c1FlexGrid2.SetData(32, 1, "إظهار التكلفة الإضافيه عند اصدار فاتورة مشتريات");
            c1FlexGrid2.SetData(33, 1, "إعتماد شاشه نقاط البيع لفاتورة اللمبيعات");
            c1FlexGrid2.SetData(34, 1, "طباعة التصنيفات حسب اسم الطابعة");
            c1FlexGrid2.SetData(35, 1, "السماح باصدار فاتورة محلية بدون طاولة");
            c1FlexGrid2.SetData(36, 1, "إفراغ الطاولة عند استخدام طلب محلي");
            c1FlexGrid2.SetData(37, 1, "جبر إجمالي الفواتير الكسرية");
            c1FlexGrid2.SetData(38, 1, "جمع خصم السطور وقيمة خصم الفاتورة");
            c1FlexGrid2.SetData(39, 1, "إعتماد سعر اخر بيع حسب العميل في المبيعات");
            c1FlexGrid2.SetData(40, 1, "إعتماد سعر البيع مع الضريبة عند طباعة الباركود");
            c1FlexGrid2.SetData(41, 1, "جبر سعر البيع بعد إضافة الضريبه عند طباعة الباركود");
            c1FlexGrid2.SetData(42, 1, "احتساب الربح في المبيعات مع الضريبة");
            c1FlexGrid2.SetData(43, 1, "إخفاء سطور قيمة الضريبة في الفواتير");
            c1FlexGrid2.SetData(44, 1, "إظهار اجمالي الفاتوره مع الضريبة عند الطباعة");
            c1FlexGrid2.SetData(45, 1, "إظهار شاشة الضافات الخاصة تلقائيا");
            c1FlexGrid2.SetData(46, 1, "إضهار زر الاضافات الخاصه مع ملاحظات الفاتوره");
            c1FlexGrid2.SetData(47, 1, "منع إدخال المدفوع بمبلغ اقل من المدفوع نقدا");
            c1FlexGrid2.SetData(48, 1, "إخفاء قائمة الأسعار في البيعات والمشتريات");
            c1FlexGrid2.SetData(49, 1, "إخفاء ايقونات الاصناف والتصنيفات في نقاط البيع");
            c1FlexGrid2.SetData(50, 1, "تشغيل الشاشات الفرعية لقراءة باركود الأصناف");
            c1FlexGrid2.SetData(51, 1, "إعتماد شاشة المبيعات الداخلية لنقاط البيع ");
            c1FlexGrid2.SetData(52, 1, "تفعيل خيار النقاط في المبيعات");
            c1FlexGrid2.SetData(53, 1, "تحكم يدوي للتواريخ الهجرية والميلادية في الفواتير");
            c1FlexGrid2.SetData(54, 1, "عرض قائمة بتواريخ الصلاحية للصنف عند قراءة الباركود");
            c1FlexGrid2.SetData(55, 1, "طباعة رقم الطلب");
            c1FlexGrid2.SetData(56, 1, "ايقاف طباعة التصنيفات للطلب المحلي في شاشة نقاط البيع ");
            c1FlexGrid2.SetData(57, 1, "الافتراضي السعر شامل الضريبه ");
            c1FlexGrid2.SetData(58, 1, "تصفير الكميات في فاتورة مرتجع مبيعات عند ارجاع فاتورة مبيعات  ");
            c1FlexGrid2.SetData(59, 1, "اخفاء تمت الموافقة  ");
            c1FlexGrid2.SetData(60, 1, "عدم السماح بارجاع بضاعة بدون تحديد فاتورة المبيعات  ");
            c1FlexGrid2.SetData(61, 1, "استخدام حقل البار كود لفلترة الاصناف في نقاط البيع  ");
            c1FlexGrid2.SetData(62, 1, "اضهار مفاتيح التنقل بين الاصناف  والتصنيفات في نقاط البيع  ");
            c1FlexGrid2.SetData(63, 1, "الافتراضي عند اضافة فاتورة مشتريات جديده الفاتورة الخدمية  ");
            c1FlexGrid2.SetData(64, 1, "اضهار الرصيد في فواتير الاجل في الفاتورة ");

        //   c1FlexGrid2.SetData(65, 1, " السج ");



            //c1FlexGrid2.SetData(59, 1, "");
            //c1FlexGrid2.SetData(60, 1, "");
            //c1FlexGrid2.SetData(61, 1, "");
            //c1FlexGrid2.SetData(62, 1, "");
            if (nn.Count == 0) optionflag = 1;
            setbilloption(1, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 8));
            setbilloption(2, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 7));
            setbilloption(3, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 19));
            setbilloption(4, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 21));
            setbilloption(5, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 45));
            setbilloption(6, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 29));
            setbilloption(7, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 17));
            setbilloption(8, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 55));
            setbilloption(9, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 53));
            setbilloption(10, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 32));
            setbilloption(11, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 38));
            setbilloption(12, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 25));
            setbilloption(13, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 35));
            setbilloption(14, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 37));
            setbilloption(15, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 6));
            setbilloption(16, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 5));
            setbilloption(17, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 4));
            setbilloption(18, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 3));
            setbilloption(19, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 20));
            setbilloption(20, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 15));
            setbilloption(21, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 16));
            setbilloption(22, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 30));
            setbilloption(23, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 24));
            setbilloption(24, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 42));
            setbilloption(25, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 39));
            setbilloption(26, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 52));
            setbilloption(27, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 51));
            setbilloption(28, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 61));
            setbilloption(29, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 75));
            setbilloption(30, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 27));
            setbilloption(31, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 14));
            setbilloption(32, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 18));
            setbilloption(33, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 26));
            setbilloption(34, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 33));
            setbilloption(35, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 36));
            setbilloption(36, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 44));
            setbilloption(37, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 56));
            setbilloption(38, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 57));
            setbilloption(39, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 58));
            setbilloption(40, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 60));
            setbilloption(41, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 78));
            setbilloption(42, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 62));
            setbilloption(43, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 64));
            setbilloption(44, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 65));
            setbilloption(45, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 66));
            setbilloption(46, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 67));
            setbilloption(47, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 68));
            setbilloption(48, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 71));
            setbilloption(49, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 72));
            setbilloption(50, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 73));
            setbilloption(51, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 22));
            setbilloption(52, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 69));
            setbilloption(53, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 77));
            setbilloption(54, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 80));
            setbilloption(55, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 54));
            setbilloption(56, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 79));
            setbilloption(57, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 83));
            setbilloption(58, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 84));
            setbilloption(59, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 85));
            setbilloption(60, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 86));
            setbilloption(61, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 87));
            setbilloption(62, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 88));
            setbilloption(63, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 89));

            setbilloption(64, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 90));
            if (init)
            {
                setbilloption(57, true);
                setbilloption(31, true);
                setbilloption(24, true);
                setbilloption(7, true);
            }

            optionflag = 0;
        }
        public class ColumnDictinaryBankopp
        {
            public string AText = string.Empty;
            public string EText = string.Empty;
            public bool IfDefault = false;
            public string Format = string.Empty;
            public ColumnDictinaryBankopp(string aText, string eText, bool ifDefault, string format)
            {
                AText = aText;
                EText = eText;
                IfDefault = ifDefault;
                Format = format;
            }
        }
     
        void loadBankop()
        {
            try
            {
                //   ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmCommOpiton));
                //if (VarGeneral.CurrentLang.ToString() == "0"||VarGeneral.CurrentLang.ToString() == "")
                //   {
                //       Language.ChangeLanguage("ar-SA", this, resources);
                //       LangArEn = 0;
                //   }
                //   else
                //   {
                //       Language.ChangeLanguage("en", this, resources);
                //       LangArEn = 1;
                //   }
                //  RibunButtonsBankopp();
                listInvSettingBankopp = db.StockInvSettingList(VarGeneral.UserID);
                _InvSettingBankopp = listInvSettingBankopp[0];
                _SysSettingBankopp = db.SystemSettingStock();
                listCompanyBankopp = db.StockCompanyList();
                _CompanyBankopp = listCompanyBankopp[0];
                _GdAutoBankopp = db.GdAutoStock();
                listInfotbBankopp = db.StockInfoList();
                _InfotbBankopp = listInfotbBankopp[0];
                listAccDefBankopp = db.FillAccDef_2(string.Empty).ToList();
                listAccDefBankopp = listAccDefBankopp.Where((T_AccDef q) => q.Trn == 3 && q.Lev == 4 && q.AccDef_No.StartsWith("1") && q.AccCat != 2 && q.AccCat != 3).ToList();
                try
                {
                    FillComboBankopp();
                }
                catch
                {
                }
                try
                {
                    BindDataBankopp();
                }
                catch
                {
                }
                if (VarGeneral.SSSTyp == 0)
                {
                    c1FlexGrid1Bankopp.Cols[9].Visible = false;
                    c1FlexGrid1Bankopp.Cols[10].Visible = false;
                    c1FlexGrid1Bankopp.Cols[11].Visible = false;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void RibunButtonsBankopp()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                ButWithSave.Text = "حفظ";
              
                ButWithoutSave.Text = "خروج";
       
                Text = "خيارات العمولات البنكية";
            }
            else
            {
                ButWithSave.Text = "Save";
                ButWithoutSave.Text = "Exit";
                
                Text = "Taxes Options";
            }
        }
        private void FillComboBankopp()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                try
                {
                    c1FlexGrid1Bankopp.SetData(0, 1, "الفاتورة");
                    c1FlexGrid1Bankopp.SetData(0, 2, "إحتســــاب");
                    c1FlexGrid1Bankopp.SetData(0, 9, "حساب المدين");
                    c1FlexGrid1Bankopp.SetData(0, 10, "حساب الدائن");
                    c1FlexGrid1Bankopp.SetData(0, 11, "قيد محاسبي");
                    c1FlexGrid1Bankopp.SetData(1, 1, "فاتورة مبيعات");
                    c1FlexGrid1Bankopp.SetData(1, 6, 1);
                    c1FlexGrid1Bankopp.SetData(1, 7, 0);
                    c1FlexGrid1Bankopp.SetData(2, 1, "فاتورة مشتريات");
                    c1FlexGrid1Bankopp.SetData(2, 6, 2);
                    c1FlexGrid1Bankopp.SetData(2, 7, 0);
                    c1FlexGrid1Bankopp.SetData(3, 1, "مرتجع مبيعات");
                    c1FlexGrid1Bankopp.SetData(3, 6, 3);
                    c1FlexGrid1Bankopp.SetData(3, 7, 0);
                    c1FlexGrid1Bankopp.Rows[3].Visible = false;
                    c1FlexGrid1Bankopp.SetData(4, 1, "مرتجع مشتريات");
                    c1FlexGrid1Bankopp.SetData(4, 6, 4);
                    c1FlexGrid1Bankopp.SetData(4, 7, 0);
                    c1FlexGrid1Bankopp.Rows[4].Visible = false;
                    c1FlexGrid1Bankopp.SetData(5, 1, "سند أدخال بضاعة");
                    c1FlexGrid1Bankopp.SetData(5, 6, 5);
                    c1FlexGrid1Bankopp.SetData(5, 7, 0);
                    c1FlexGrid1Bankopp.Rows[5].Visible = false;
                    c1FlexGrid1Bankopp.SetData(6, 1, "سند أخراج بضاعة");
                    c1FlexGrid1Bankopp.SetData(6, 6, 6);
                    c1FlexGrid1Bankopp.SetData(6, 7, 0);
                    c1FlexGrid1Bankopp.Rows[6].Visible = false;
                    c1FlexGrid1Bankopp.SetData(7, 1, "عرض سعر عملاء");
                    c1FlexGrid1Bankopp.SetData(7, 6, 7);
                    c1FlexGrid1Bankopp.SetData(7, 7, 0);
                    c1FlexGrid1Bankopp.Rows[7].Visible = false;
                    c1FlexGrid1Bankopp.SetData(8, 1, "عرض سعر مورد");
                    c1FlexGrid1Bankopp.SetData(8, 6, 8);
                    c1FlexGrid1Bankopp.SetData(8, 7, 0);
                    c1FlexGrid1Bankopp.Rows[8].Visible = false;
                    c1FlexGrid1Bankopp.SetData(9, 1, "طلب شراء");
                    c1FlexGrid1Bankopp.SetData(9, 6, 9);
                    c1FlexGrid1Bankopp.SetData(9, 7, 0);
                    c1FlexGrid1Bankopp.Rows[9].Visible = false;
                    c1FlexGrid1Bankopp.SetData(10, 1, "سند تسوية بضاعة");
                    c1FlexGrid1Bankopp.SetData(10, 6, 10);
                    c1FlexGrid1Bankopp.SetData(10, 7, 0);
                    c1FlexGrid1Bankopp.Rows[10].Visible = false;
                    c1FlexGrid1Bankopp.SetData(11, 1, "بضاعة اول المدة");
                    c1FlexGrid1Bankopp.SetData(11, 6, 14);
                    c1FlexGrid1Bankopp.SetData(11, 7, 0);
                    c1FlexGrid1Bankopp.Rows[11].Visible = false;
                    c1FlexGrid1Bankopp.SetData(12, 1, "أمر صرف بضاعة");
                    c1FlexGrid1Bankopp.SetData(12, 6, 17);
                    c1FlexGrid1Bankopp.SetData(12, 7, 0);
                    c1FlexGrid1Bankopp.Rows[12].Visible = false;
                    c1FlexGrid1Bankopp.SetData(13, 1, "مرتجع صرف بضاعة");
                    c1FlexGrid1Bankopp.SetData(13, 6, 20);
                    c1FlexGrid1Bankopp.SetData(13, 7, 0);
                    c1FlexGrid1Bankopp.Rows[13].Visible = false;
                    c1FlexGrid1Bankopp.SetData(14, 1, "إنتاج الأصناف - تصنيع");
                    c1FlexGrid1Bankopp.SetData(14, 6, 16);
                    c1FlexGrid1Bankopp.SetData(14, 7, 0);
                    c1FlexGrid1Bankopp.Rows[14].Visible = false;
                }
                catch
                {
                }
                return;
            }
            try
            {
                c1FlexGrid1Bankopp.SetData(0, 1, "Invoice");
                c1FlexGrid1Bankopp.SetData(0, 2, "Issuance");
                c1FlexGrid1Bankopp.SetData(0, 3, "Print");
                c1FlexGrid1Bankopp.SetData(0, 4, "Sales Tax");
                c1FlexGrid1Bankopp.SetData(0, 5, "Purchaes Tax");
                c1FlexGrid1Bankopp.SetData(0, 9, "Debitor Acc");
                c1FlexGrid1Bankopp.SetData(0, 10, "Creditor Acc");
                c1FlexGrid1Bankopp.SetData(0, 11, "Create Gaid");
                c1FlexGrid1Bankopp.SetData(1, 1, "Sales Invoice");
                c1FlexGrid1Bankopp.SetData(1, 6, 1);
                c1FlexGrid1Bankopp.SetData(1, 7, 0);
                c1FlexGrid1Bankopp.SetData(2, 1, "Purchase Receipt");
                c1FlexGrid1Bankopp.SetData(2, 6, 2);
                c1FlexGrid1Bankopp.SetData(2, 7, 0);
                c1FlexGrid1Bankopp.SetData(3, 1, "Sales Return");
                c1FlexGrid1Bankopp.SetData(3, 6, 3);
                c1FlexGrid1Bankopp.SetData(3, 7, 0);
                c1FlexGrid1Bankopp.Rows[3].Visible = false;
                c1FlexGrid1Bankopp.SetData(4, 1, "Purchase Return");
                c1FlexGrid1Bankopp.SetData(4, 6, 4);
                c1FlexGrid1Bankopp.SetData(4, 7, 0);
                c1FlexGrid1Bankopp.Rows[4].Visible = false;
                c1FlexGrid1Bankopp.SetData(5, 1, "Transfer In");
                c1FlexGrid1Bankopp.SetData(5, 6, 5);
                c1FlexGrid1Bankopp.SetData(5, 7, 0);
                c1FlexGrid1Bankopp.Rows[5].Visible = false;
                c1FlexGrid1Bankopp.SetData(6, 1, "Transfer Out");
                c1FlexGrid1Bankopp.SetData(6, 6, 6);
                c1FlexGrid1Bankopp.SetData(6, 7, 0);
                c1FlexGrid1Bankopp.Rows[6].Visible = false;
                c1FlexGrid1Bankopp.SetData(7, 1, "Customer Qutation");
                c1FlexGrid1Bankopp.SetData(7, 6, 7);
                c1FlexGrid1Bankopp.SetData(7, 7, 0);
                c1FlexGrid1Bankopp.Rows[7].Visible = false;
                c1FlexGrid1Bankopp.SetData(8, 1, "Supplier Qutation");
                c1FlexGrid1Bankopp.SetData(8, 6, 8);
                c1FlexGrid1Bankopp.SetData(8, 7, 0);
                c1FlexGrid1Bankopp.Rows[8].Visible = false;
                c1FlexGrid1Bankopp.SetData(9, 1, "Purchase Order");
                c1FlexGrid1Bankopp.SetData(9, 6, 9);
                c1FlexGrid1Bankopp.SetData(9, 7, 0);
                c1FlexGrid1Bankopp.Rows[9].Visible = false;
                c1FlexGrid1Bankopp.SetData(10, 1, "Stock Adjustment");
                c1FlexGrid1Bankopp.SetData(10, 6, 10);
                c1FlexGrid1Bankopp.SetData(10, 7, 0);
                c1FlexGrid1Bankopp.Rows[10].Visible = false;
                c1FlexGrid1Bankopp.SetData(11, 1, "Open Quantities");
                c1FlexGrid1Bankopp.SetData(11, 6, 14);
                c1FlexGrid1Bankopp.SetData(11, 7, 0);
                c1FlexGrid1Bankopp.Rows[11].Visible = false;
                c1FlexGrid1Bankopp.SetData(12, 1, "Payment Order");
                c1FlexGrid1Bankopp.SetData(12, 6, 17);
                c1FlexGrid1Bankopp.SetData(12, 7, 0);
                c1FlexGrid1Bankopp.Rows[12].Visible = false;
                c1FlexGrid1Bankopp.SetData(13, 1, "Payment Order Return");
                c1FlexGrid1Bankopp.SetData(13, 6, 20);
                c1FlexGrid1Bankopp.SetData(13, 7, 0);
                c1FlexGrid1Bankopp.Rows[13].Visible = false;
                c1FlexGrid1Bankopp.SetData(14, 1, "Production of varieties - Manufacture");
                c1FlexGrid1Bankopp.SetData(14, 6, 16);
                c1FlexGrid1Bankopp.SetData(14, 7, 0);
                c1FlexGrid1Bankopp.Rows[14].Visible = false;
            }
            catch
            {
            }
        }
        private void SaveDataBankopp()
        {
            try
            {
                for (int iiCnt = 1; iiCnt < c1FlexGrid1Bankopp.Rows.Count; iiCnt++)
                {
                    for (int i = 0; i < listInvSettingBankopp.Count; i++)
                    {
                        _InvSettingBankopp = listInvSettingBankopp[i];
                        if (_InvSettingBankopp.InvID == int.Parse(c1FlexGrid1Bankopp.GetData(iiCnt, 6).ToString()))
                        {
                            _InvSettingBankopp.CommOptions = VarGeneral.TString.ChkStatSave((bool)c1FlexGrid1Bankopp.GetData(iiCnt, 2)) + VarGeneral.TString.ChkStatSave((bool)c1FlexGrid1Bankopp.GetData(iiCnt, 3));
                            try
                            {
                                _InvSettingBankopp.CommDebit = c1FlexGrid1Bankopp.GetData(iiCnt, 9).ToString();
                            }
                            catch
                            {
                                _InvSettingBankopp.CommDebit = "***";
                            }
                            try
                            {
                                _InvSettingBankopp.CommCredit = c1FlexGrid1Bankopp.GetData(iiCnt, 10).ToString();
                            }
                            catch
                            {
                                _InvSettingBankopp.CommCredit = "***";
                            }
                            _InvSettingBankopp.autoCommGaid = Convert.ToBoolean(c1FlexGrid1Bankopp.GetData(iiCnt, 11));
                            db.Log = VarGeneral.DebugLog;
                            db.SubmitChanges(ConflictMode.ContinueOnConflict);
                            break;
                        }
                    }
                }
                //MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Close();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Save:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void BindDataBankopp()
        {
            try
            {
                State = FormState.Saved;
                ButWithSave.Enabled = false;
                for (int iiCnt = 1; iiCnt < c1FlexGrid1Bankopp.Rows.Count; iiCnt++)
                {
                    for (int i = 0; i < listInvSettingBankopp.Count; i++)
                    {
                        _InvSettingBankopp = listInvSettingBankopp[i];
                        if (_InvSettingBankopp.InvID == int.Parse(c1FlexGrid1Bankopp.GetData(iiCnt, 6).ToString()))
                        {
                            c1FlexGrid1Bankopp.SetData(iiCnt, 2, VarGeneral.TString.ChkStatShow(_InvSettingBankopp.CommOptions, 0));
                            c1FlexGrid1Bankopp.SetData(iiCnt, 3, VarGeneral.TString.ChkStatShow(_InvSettingBankopp.CommOptions, 1));
                            c1FlexGrid1Bankopp.SetData(iiCnt, 9, _InvSettingBankopp.CommDebit);
                            c1FlexGrid1Bankopp.SetData(iiCnt, 10, _InvSettingBankopp.CommCredit);
                            c1FlexGrid1Bankopp.SetData(iiCnt, 11, _InvSettingBankopp.autoCommGaid);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public class ColumnDictinaryCusDis
        {
            public string AText = string.Empty;
            public string EText = string.Empty;
            public bool IfDefault = false;
            public string Format = string.Empty;
            public ColumnDictinaryCusDis(string aText, string eText, bool ifDefault, string format)
            {
                AText = aText;
                EText = eText;
                IfDefault = ifDefault;
                Format = format;
            }
        }
        public Dictionary<string, ColumnDictinaryBankopp> columns_Names_visibleBankopp = new Dictionary<string, ColumnDictinaryBankopp>();
        private List<T_INVSETTING> listInvSettingBankopp = new List<T_INVSETTING>();
        private T_INVSETTING _InvSettingBankopp = new T_INVSETTING();
        private List<T_SYSSETTING> listSysSettingBankopp = new List<T_SYSSETTING>();
        private T_SYSSETTING _SysSettingBankopp = new T_SYSSETTING();
        private List<T_AccDef> listAccDefBankopp = new List<T_AccDef>();
        private T_AccDef _AccDefBankopp = new T_AccDef();
        private List<T_Company> listCompanyBankopp = new List<T_Company>();
        private T_Company _CompanyBankopp = new T_Company();
        private List<T_GdAuto> listGdAutoBankopp = new List<T_GdAuto>();
        private T_GdAuto _GdAutoBankopp = new T_GdAuto();
        private List<T_InfoTb> listInfotbBankopp = new List<T_InfoTb>();
        private T_InfoTb _InfotbBankopp = new T_InfoTb();
        public Dictionary<string, ColumnDictinaryCusDis> columns_Names_visibleCustDis = new Dictionary<string, ColumnDictinaryCusDis>();
        private List<T_INVSETTING> listInvSettingCustDis = new List<T_INVSETTING>();
        private T_INVSETTING _InvSettingCustDis = new T_INVSETTING();
        private List<T_SYSSETTING> listSysSettingCustDis = new List<T_SYSSETTING>();
        private T_SYSSETTING _SysSettingCustDis = new T_SYSSETTING();

        private void XtraForm1_Load(object sender, EventArgs e)
        {
            Bar_Hotil.Visible = false;
            Bar_Eqarat.Visible = false;
            superTabItem_Employee.Visible = false;

            //   filloptions();
            try
            {
                loadcustdis();
                load(); loadBankop(); LoadBalance();
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmSystemSetting));
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    SSSLanguage.Language.ChangeLanguage("ar-SA", this, resources);
                    LangArEn = 0;
                }
                else
                {
                    SSSLanguage.Language.ChangeLanguage("en", this, resources);
                    LangArEn = 1;
                }
                expandablePanel_NewColumn.Expanded = false;
                if (VarGeneral.SSSTyp == 0)
                {
                    //chk5.Visible = false;
                    //chk6.Visible = false;
                    //chk7.Visible = false;
                    Bar_Accounts.Visible = false;
                    label54.Visible = false;
                    txtEmailPass.Visible = false;
                    CmbMail.Visible = false;
                    label56.Visible = false;
                    chk19.Visible = false;
                    txtDateAlarmEmps.Visible = false;
                    label47.Visible = false;
                    if (VarGeneral.SSSLev == "M")
                    {
                        //chk21.Visible = false;
                        //chk22.Visible = false;
                        //chk23.Visible = false;
                        //chk29.Visible = false;
                        label51.Visible = false;
                        CmbPointImages.Visible = false;
                        groupPanel_Acc.Visible = false;
                        groupPanel2.Location = new Point(groupPanel2.Location.X, groupPanel2.Location.Y - 17);
                    }
                }
                else if (VarGeneral.SSSTyp == 1)
                {
                    Bar_Accounts.Visible = false;
                    Bar_Invsale.Visible = false;
                    groupPanel4.Visible = false;
                    picture_SSS.Visible = true;
                    chk19.Visible = false;
                    
                    txtDateAlarmEmps.Visible = false;
                    label47.Visible = false;
                    label51.Visible = false;
                    CmbPointImages.Visible = false;
                }
                if (VarGeneral.SSSLev != "R" && VarGeneral.SSSLev != "C" && VarGeneral.SSSLev != "H")
                {
                    if (VarGeneral.SSSLev != "B" && VarGeneral.SSSLev != "G" && VarGeneral.SSSLev != "S")
                    {
//chk22.Visible = false;
                    }
                   // chk29.Visible = false;
                    label48.Visible = false;
                    CmbPrintTyp.Visible = false;
                    chk39.Visible = false;
                    label75.Visible = false;
                    //chk32.Visible = false;
                    //chk40.Visible = false;
                    //chk50.Visible = false;
                    //chk74.Visible = false;
                    CmbOrderTyp.Visible = false;
                    label74.Visible = false;
                    if (VarGeneral.SSSLev == "X")
                    {
                        Bar_Hotil.Visible = true;
                    }
                    if (VarGeneral.SSSLev == "Q")
                    {
                        Bar_Eqarat.Visible = true;
                    }
                }
                else
                {
                    //chk22.Visible = true;
                    //chk29.Visible = true;
                    label48.Visible = true;
                    CmbPrintTyp.Visible = true;
                    if (VarGeneral.SSSLev == "H")
                    {
                  
                        Bar_Hotil.Visible = true;
                    }
                }
                listInvSetting = db.StockInvSettingList(VarGeneral.UserID);
                _InvSetting = listInvSetting[0];
                _SysSetting = db.SystemSettingStock();
                listCompany = db.StockCompanyList();
                _Company = listCompany[0];
                _GdAuto = db.GdAutoStock();
                listInfotb = db.StockInfoList();
                _Infotb = listInfotb[0];
                listAccDef = db.FillAccDef_2(string.Empty).ToList();
                listAccDef = listAccDef.Where((T_AccDef q) => q.Trn == 3 && q.Lev == 4 && q.AccDef_No.StartsWith("1") && q.AccCat != 2 && q.AccCat != 3).ToList();
                try
                {
                    FillCombo();
                }
                catch
                {
                }
                try
                {
                    BindData();
                    if (ProShared.Properties.Settings.Default.B3 == "32") init = true;
                        filloptions();
                }
                catch
                {
                }
                try
                {
                    listTableFamily = db.FillTable_2(1).ToList();
                }
                catch
                {
                }
                try
                {
                    listTableBoys = db.FillTable_2(2).ToList();
                }
                catch
                {
                }
                try
                {
                    listTableOut = db.FillTable_2(3).ToList();
                }
                catch
                {
                }
                try
                {
                    listTableOther = db.FillTable_2(4).ToList();
                }
                catch
                {
                }
                try
                {
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
                    try
                    {
                        if (VarGeneral.gUserName == "runsetting")
                        {
                            DT_H = Convert.ToDateTime(VarGeneral.Hdate).AddYears(1).ToString("yyyy/MM/dd");
                            regval = Convert.ToDateTime(VarGeneral.Gdate).AddYears(1).ToString("yyyy/MM/dd");
                        }
                    }
                    catch
                    {
                    }
                   
                    if (Convert.ToDateTime(VarGeneral.Hdate) >Convert.ToDateTime(n.FormatHijri(DT_H, "yyyy/MM/dd")))
                    {
                        dateTimeInput_DT.Text = ((LangArEn == 0) ? "الخدمة موقوفة حاليا" : "Service is Stoped");
                    }
                    else
                    {
                        CultureInfo sa = new CultureInfo("en-US", useUserOverride: false);
                        sa.DateTimeFormat.Calendar = new GregorianCalendar();
                        Thread.CurrentThread.CurrentCulture = sa;
                        Thread.CurrentThread.CurrentUICulture = sa;
                        dateTimeInput_DT.Text = regval;
                        if (VarGeneral.Settings_Sys.Calendr.Value != 0)
                        {
                            sa = new CultureInfo("ar-SA", useUserOverride: false);
                            sa.DateTimeFormat.Calendar = new HijriCalendar();
                            Thread.CurrentThread.CurrentCulture = sa;
                            Thread.CurrentThread.CurrentUICulture = sa;
                        }
                    }
                }
                catch
                {
                    dateTimeInput_DT.Text = ((LangArEn == 0) ? "الخدمة موقوفة حاليا" : "Service is Stoped");
                    if (VarGeneral.Settings_Sys.Calendr.Value != 0)
                    {
                        CultureInfo sa = new CultureInfo("ar-SA", useUserOverride: false);
                        sa.DateTimeFormat.Calendar = new HijriCalendar();
                        Thread.CurrentThread.CurrentCulture = sa;
                        Thread.CurrentThread.CurrentUICulture = sa;
                    }
                }
                switchButton_NewColumnName.OnText = ((LangArEn == 0) ? ("عمود " + VarGeneral.Settings_Sys.LineDetailNameA) : ("Column " + VarGeneral.Settings_Sys.LineDetailNameE));
                switchButton_NewColumnName.OffText = ((LangArEn == 0) ? ("عمود " + VarGeneral.Settings_Sys.LineGiftlNameA) : ("Column " + VarGeneral.Settings_Sys.LineGiftlNameE));
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptInvitationCards.dll"))
            {
                Script_InvitationCards();
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptTegnicalCollage.dll"))
            {
                TegnicalCollage();
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptWaterPackages.dll"))
            {
                button_PointOfCust.Visible = false;
                //chk64.Enabled = false;
            }
            try
            {
                txtHeadingR1.TextChanged -= txtHeadingR1_TextChanged;
                string s = txtHeadingR1.Text;
                txtHeadingR1.Text = txtHeadingR1.Text.Replace("مؤسسة آب سوفت", "مؤسسة           ");
                txtHeadingL1.Text = txtHeadingL1.Text.Replace("Application Software Solutions", "           ");
                txtHeadingR1.Text = txtHeadingR1.Text.Replace("مؤسسة برو سوفت", "مؤسسة           ");

                if (ProShared.Properties.Settings.Default.B3 == "32")
                {

                    txtCompany.Text = "مؤسسة ";
                    ProShared.Properties.Settings.Default.B3 = "";
                    ProShared.Properties.Settings.Default.Save();
                    for (int i = 1; i < c1FlexGriadTax.Rows.Count; i++)
                        c1FlexGriadTax.SetData(i, 14, false);
                    c1FlexGrid1.SetData(3, 4, 1031001);
                    c1FlexGrid1.SetData(7, 5, 1031001);
                    c1FlexGrid1.SetData(11, 5, 1031001);
                    c1FlexGrid1.SetData(15, 4, 1031001);
                    
                    // c1FlexGrid1.SetData(3, 3, 1031001);
                    ksa = 1;// pictureBox_EnterPic.Image = InvAcc.Properties.Resources.appbackground;
                    Button_Edit_Click(null, null);
                    ButWithSave_Click(null, null);
                }

                txtHeadingR1.TextChanged += txtHeadingR1_TextChanged;

            }
            catch { }

        }
        bool init = false;
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return new Bitmap(imgToResize, size);
        }
        private void chk45_CheckedChanged(object sender, EventArgs e)
        {
            numbersafterdecimal.Enabled = chk45.Checked;
        }
        private void SaveData()
        {
            string setting = string.Empty;
            string Empsetting = string.Empty;
            string settingNewLine = string.Empty;
            try
            {
                _SysSetting.IsBackground = true;
                _SysSetting.IsNotBackground = false;
                if (pictureBox_EnterPic.Image != null)
                {
                    MemoryStream stream = new MemoryStream();
                    pictureBox_EnterPic.Image.Save(stream, ImageFormat.Jpeg);
                    byte[] arr = stream.GetBuffer();
                    _SysSetting.BackgroundPic = arr;
                }
                else
                {
                    _SysSetting.BackgroundPic = null;
                }
                try
                {
                    _SysSetting.IsNotBackground = radioButton_IsNotBackground.Checked;
                    if (radioButton_IsNotBackground.Checked)
                    {
                        _SysSetting.IsBackground = false;
                    }
                    else
                    {
                        _SysSetting.IsBackground = true;
                    }
                }
                catch
                {
                    _SysSetting.IsNotBackground = false;
                    _SysSetting.IsBackground = true;
                }
                _SysSetting.HDat = int.Parse(txtHijriDate.Tag.ToString());
                _SysSetting.Calendr = CmbCalendar.SelectedIndex;
                _SysSetting.AutoItm = txtAutoNumber.Value;
                _SysSetting.DMY = CmbDateTyp.SelectedIndex;
                _SysSetting.ImportIp = int.Parse(CmbCurr.SelectedValue.ToString()).ToString();
                _SysSetting.DataBaseNm = CmbMail.SelectedIndex.ToString();
                _SysSetting.InvMod = CmbInvMode.SelectedIndex;
                _SysSetting.LrnExp = int.Parse(txtDateAlarm.Text);
                _SysSetting.AccCus = txtDateofInv.Value.ToString();
                _SysSetting.AlarmDueoBefore = txtAlarmDeuDateBefor.Value;
                try
                {
                    if (int.TryParse(txtKeyNational.Text, out var _) && !string.IsNullOrEmpty(txtKeyNational.Text.Trim()) && txtKeyNational.Text != "966")
                    {
                        _SysSetting.AccSup = txtKeyNational.Text.Trim();
                    }
                    else
                    {
                        _SysSetting.AccSup = string.Empty;
                    }
                }
                catch
                {
                    _SysSetting.AccSup = string.Empty;
                }
                setting = VarGeneral.TString.ChkStatSave(chk1.Checked);
                setting += VarGeneral.TString.ChkStatSave(chk2.Checked);
                setting += VarGeneral.TString.ChkStatSave(chk3.Checked);
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(18, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(17, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(16, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(15, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(2, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(1, 2));
                setting += VarGeneral.TString.ChkStatSave(ChkHead.Checked);
                setting += VarGeneral.TString.ChkStatSave(ChkGreg.Checked);
                setting += VarGeneral.TString.ChkStatSave(ChkHijri.Checked);
                setting += VarGeneral.TString.ChkStatSave(ChkPageNumber.Checked);
                setting += CmbCost.SelectedIndex;
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(31, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(20, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(21, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(7, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(32, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(3, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(19, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(4, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(51, 2));
                setting += VarGeneral.TString.ChkStatSave(chk19.Checked);
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(23, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(12, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(33, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(30, 2)); ;
                setting += VarGeneral.TString.ChkStatSave(chk24.Checked);
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(6, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(22, 2));
                setting += VarGeneral.TString.ChkStatSave(chk27.Checked);
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(10, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(34, 2));
                if (chk39.SelectedIndex == 0 || chk39.SelectedIndex == 2)
                {
                    setting += "1";
                }
                else if ((chk39.SelectedIndex == 1) | (chk39.SelectedIndex == 3))
                {
                    setting += "0";
                }
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(13, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(35, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(14, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(11, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(25, 2));
                setting += chk36.SelectedIndex;
                setting += VarGeneral.TString.ChkStatSave(chk37.Value);
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(24, 2));
                if (chk39.SelectedIndex == 0 || chk39.SelectedIndex == 1)
                {
                    setting += "1";
                }
                else if ((chk39.SelectedIndex == 2) | (chk39.SelectedIndex == 3))
                {
                    setting += "0";
                }
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(36, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(5, 2));
                setting += VarGeneral.TString.ChkStatSave(chk42.Checked);
                setting += VarGeneral.TString.ChkStatSave(chk43.Checked);
                setting += VarGeneral.TString.ChkStatSave(chk44.Checked);
                setting += VarGeneral.TString.ChkStatSave(chk45.Checked);
                _SysSetting.AfterDotNum = numbersafterdecimal.Value;
                VarGeneral.setDecimalPointSettings((int)_SysSetting.AfterDotNum);
                chk45_CheckedChanged(null, null);
                setting += chk46.SelectedIndex;
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(27, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(26, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(9, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(55, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(8, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(37, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(38, 2));
                try
                {
                    setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(39, 2));
                }
                catch
                { setting += "0"; }
                setting += CmbOrderTyp.SelectedIndex;
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(40, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(28, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(42, 2));
                setting += VarGeneral.TString.ChkStatSave(chk58.Checked);
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(43, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(44, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(45, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(46, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(47, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(52, 2));
                setting += VarGeneral.TString.ChkStatSave(chk65.Checked);
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(48, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(49, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(50, 2));
                setting += VarGeneral.TString.ChkStatSave(chk69.Checked);
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(29, 2));
                setting += VarGeneral.TString.ChkStatSave(chk71.Checked);
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(53, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(41, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(56, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(54, 2));
                setting += VarGeneral.TString.ChkStatSave(chk76.Checked);
                setting += VarGeneral.TString.ChkStatSave(chk77.Checked);
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(57, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(58, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(59, 2));
                if (c1FlexGrid2.GetData(60, 2) == null) c1FlexGrid2.SetData(60, 2, false);


                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(60, 2));

                if (c1FlexGrid2.GetData(61, 2) == null) c1FlexGrid2.SetData(61, 2, false);


                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(61, 2));

                if (c1FlexGrid2.GetData(62, 2) == null) c1FlexGrid2.SetData(62, 2, false);


                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(62, 2));
                if (c1FlexGrid2.GetData(63, 2) == null) c1FlexGrid2.SetData(63, 2, false);


                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(63, 2));
                if (c1FlexGrid2.GetData(64, 2) == null) c1FlexGrid2.SetData(64, 2, false);


               setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(64, 2));

                _SysSetting.Seting = setting;
                _SysSetting.LineOfInvoices = txtLinesInv.Value;
                VarGeneral.Settings_Sys.LineOfInvoices = txtLinesInv.Value;
                VarGeneral.Settings_Sys.Seting = setting;
                if (PicItemImg.Image != null)
                {
                    MemoryStream stream = new MemoryStream();
                    PicItemImg.Image = resizeImage(PicItemImg.Image, new Size(140, 140));
                    PicItemImg.Image.Save(stream, ImageFormat.Jpeg);
                    byte[] arr = stream.GetBuffer();
                    _SysSetting.LogImg = arr;
                }
                else
                {
                    _SysSetting.LogImg = null;
                }
                try
                {
                    _SysSetting.SyncPath = textBox_SyncPath.Text;
                }
                catch
                {
                    _SysSetting.SyncPath = string.Empty;
                }
                try
                {
                    _SysSetting.BackPath = textBox_BackupPath.Text;
                }
                catch
                {
                    _SysSetting.BackPath = string.Empty;
                }
                try
                {
                    _SysSetting.SysDir = textBox_BackupElectronic.Tag.ToString();
                }
                catch
                {
                    _SysSetting.SysDir = string.Empty;
                }
                try
                {
                    _SysSetting.IsAutoBackup = checkBox_AutoBackup.Checked;
                }
                catch
                {
                    _SysSetting.IsAutoBackup = false;
                }
                try
                {
                    _SysSetting.AutoBackup = comboBox_AutoBackup.SelectedIndex;
                }
                catch
                {
                    _SysSetting.AutoBackup = 0;
                }
                if (switchButton_NewColumnName.Value)
                {
                    _SysSetting.LineDetailNameA = textBox_LineDetailNameA.Text;
                    _SysSetting.LineDetailNameE = textBox_LineDetailNameE.Text;
                }
                else
                {
                    _SysSetting.LineGiftlNameA = textBox_LineDetailNameA.Text;
                    _SysSetting.LineGiftlNameE = textBox_LineDetailNameE.Text;
                }
                _SysSetting.AutoEmp = CmbPrintTyp.SelectedIndex;
                _SysSetting.Path_Kind = CmbPointImages.SelectedIndex;
                _SysSetting.ServerNm = txtEmailBoss.Text.Trim();
                _SysSetting.Sa_Pass = txtEmailPass.Text;
                _SysSetting.EqarAlarmDayPay = txtEqarDayOfPayAlarm.Value;
                _SysSetting.EqarAlarmContractEnd = txtEqarContractEndAlarm.Value;
                _SysSetting.EqarAcc = txtEqarsFatherAcc.Text;
                _SysSetting.tenantAcc = txtTenantFatherAcc.Text;
                if (_SysSetting.rom.Value != txtRoom.Value || _SysSetting.flore.Value != txtFloors.Value)
                {
                    db.ExecuteCommand("DELETE FROM [T_RomChart]");
                    db.ExecuteCommand("DELETE FROM [T_Rom]");
                    string _format = "1";
                    int _ID = 1;
                    int iicnt;
                    for (iicnt = 1; iicnt <= txtFloors.Value; iicnt++)
                    {
                        _format = iicnt + "0";
                        for (int i = 1; i <= txtRoom.Value; i++)
                        {
                            db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + _format + i.ToString() + ", " + iicnt + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            List<T_RomChart> q = db.T_RomCharts.Where((T_RomChart t) => t.FName == "الطابق " + iicnt).ToList();
                            if (q.Count <= 0)
                            {
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                    SET IDENTITY_INSERT [dbo].[T_RomChart] ON\r\n                                                    INSERT [dbo].[T_RomChart] ([ID], [FName], [FNameE],[col1], [col2], [col3], [col4], [col5], [col6], [col7], [col8], [col9], [col10], [col11], [col12], [col13], [col14], [col15], [col16], [col17], [col18], [col19], [col20], [col21], [col22], [col23], [col24], [col25], [col26], [col27], [col28], [col29], [col30], [col31], [col32], [col33], [col34], [col35], [col36], [col37], [col38], [col39], [col40], [col41], [col42], [col43], [col44], [col45], [col46], [col47], [col48], [col49], [col50], [col51], [col52], [col53], [col54], [col55], [col56], [col57], [col58], [col59], [col60], [col61], [col62], [col63], [col64], [col65], [col66], [col67], [col68], [col69], [col70], [col71], [col72], [col73], [col74], [col75], [col76], [col77], [col78], [col79], [col80], [col81], [col82], [col83], [col84], [col85], [col86], [col87], [col88], [col89], [col90], [col91], [col92], [col93], [col94], [col95], [col96], [col97], [col98], [col99], [col100]) VALUES (" + _ID + ", N'الطابق " + iicnt + "', N'floor " + iicnt + "', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)\r\n                                                    SET IDENTITY_INSERT [dbo].[T_RomChart] OFF");
                                db.ExecuteCommand("UPDATE [T_RomChart] SET col" + i + " = " + _format + i.ToString() + " where FName = 'الطابق " + iicnt + "'");
                                _ID++;
                            }
                            else
                            {
                                db.ExecuteCommand("UPDATE [T_RomChart] SET col" + i + " = " + _format + i.ToString() + " where FName = 'الطابق " + iicnt + "'");
                            }
                        }
                    }
                }
                _SysSetting.flore = txtFloors.Value;
                _SysSetting.rom = txtRoom.Value;
                _SysSetting.vStart = txtAllowPeriod.Text;
                _SysSetting.vEnd = txtLeavePeriod.Text;
                _SysSetting.DayOfM = txtDayofMonth.Value;
                _SysSetting.Fld_H = txtLongitudinal.Value;
                _SysSetting.Fld_w = txtWidthitudinal.Value;
                if (RadioBox_AllowAM.Checked)
                {
                    _SysSetting.vStartTyp = "AM";
                }
                else
                {
                    _SysSetting.vStartTyp = "PM";
                }
                if (RadioBox_LeaveAM.Checked)
                {
                    _SysSetting.vEndTyp = "AM";
                }
                else
                {
                    _SysSetting.vEndTyp = "PM";
                }
                _SysSetting.BColor0 = txtREmpty.BackColor.R + "," + txtREmpty.BackColor.G + "," + txtREmpty.BackColor.B;
                _SysSetting.BColor1 = txtRAvailable.BackColor.R + "," + txtRAvailable.BackColor.G + "," + txtRAvailable.BackColor.B;
                _SysSetting.BColor2 = txtRBussyDaily.BackColor.R + "," + txtRBussyDaily.BackColor.G + "," + txtRBussyDaily.BackColor.B;
                _SysSetting.BColor3 = txtRBussyAppendix.BackColor.R + "," + txtRBussyAppendix.BackColor.G + "," + txtRBussyAppendix.BackColor.B;
                _SysSetting.BColor4 = txtRClean.BackColor.R + "," + txtRClean.BackColor.G + "," + txtRClean.BackColor.B;
                _SysSetting.BColor5 = txtRRepair.BackColor.R + "," + txtRRepair.BackColor.G + "," + txtRRepair.BackColor.B;
                _SysSetting.BColor6 = txtRBussyMonthly.BackColor.R + "," + txtRBussyMonthly.BackColor.G + "," + txtRBussyMonthly.BackColor.B;
                _SysSetting.BColor7 = txtRLeave.BackColor.R + "," + txtRLeave.BackColor.G + "," + txtRLeave.BackColor.B;
                _SysSetting.FColor0 = txtREmpty.ForeColor.R + "," + txtREmpty.ForeColor.G + "," + txtREmpty.ForeColor.B;
                _SysSetting.FColor1 = txtRAvailable.ForeColor.R + "," + txtRAvailable.ForeColor.G + "," + txtRAvailable.ForeColor.B;
                _SysSetting.FColor2 = txtRBussyDaily.ForeColor.R + "," + txtRBussyDaily.ForeColor.G + "," + txtRBussyDaily.ForeColor.B;
                _SysSetting.FColor3 = txtRBussyAppendix.ForeColor.R + "," + txtRBussyAppendix.ForeColor.G + "," + txtRBussyAppendix.ForeColor.B;
                _SysSetting.FColor4 = txtRClean.ForeColor.R + "," + txtRClean.ForeColor.G + "," + txtRClean.ForeColor.B;
                _SysSetting.FColor5 = txtRRepair.ForeColor.R + "," + txtRRepair.ForeColor.G + "," + txtRRepair.ForeColor.B;
                _SysSetting.FColor6 = txtRBussyMonthly.ForeColor.R + "," + txtRBussyMonthly.ForeColor.G + "," + txtRBussyMonthly.ForeColor.B;
                _SysSetting.FColor7 = txtRLeave.ForeColor.R + "," + txtRLeave.ForeColor.G + "," + txtRLeave.ForeColor.B;
                if (superTabItem_Employee.Visible)
                {
                    Empsetting = VarGeneral.TString.ChkStatSave(ChkEmp1.Checked);
                    _SysSetting.EmpSeting = Empsetting;
                    try
                    {
                        _SysSetting.DocumentPath = textBox_DocPath.Text;
                    }
                    catch
                    {
                        _SysSetting.DocumentPath = string.Empty;
                    }
                    try
                    {
                        _SysSetting.AccUsrNo = null;
                    }
                    catch
                    {
                        _SysSetting.AccUsrNo = null;
                    }
                    try
                    {
                        _SysSetting.AttendanceManually = checkBox_AttendanceManually.Checked;
                    }
                    catch
                    {
                        _SysSetting.AttendanceManually = false;
                    }
                    try
                    {
                        _SysSetting.AutoLeave = checkBox_AutoLeave.Checked;
                    }
                    catch
                    {
                        _SysSetting.AutoLeave = false;
                    }
                    try
                    {
                        _SysSetting.CalculateNo = int.Parse(comboBox_CalculateNo.SelectedValue.ToString());
                    }
                    catch
                    {
                        _SysSetting.CalculateNo = 0;
                    }
                    try
                    {
                        _SysSetting.CalculatliquidNo = int.Parse(comboBox_CalculatliquidNo.SelectedValue.ToString());
                    }
                    catch
                    {
                        _SysSetting.CalculatliquidNo = 0;
                    }
                    try
                    {
                        _SysSetting.DisVacationType = comboBox_DisVacationType.SelectedIndex;
                    }
                    catch
                    {
                        _SysSetting.DisVacationType = 0;
                    }
                    try
                    {
                        _SysSetting.EmpLeaveAfter = textBox_AutoEmpLeaveAfter.Value;
                    }
                    catch
                    {
                        _SysSetting.EmpLeaveAfter = 0;
                    }
                    try
                    {
                        _SysSetting.AlarmEmpContractBefore = integerInput_AlarmEmpContractBefore.Value;
                    }
                    catch
                    {
                        _SysSetting.AlarmEmpContractBefore = 0;
                    }
                    try
                    {
                        _SysSetting.AlarmEmpDocBefore = integerInput_AlarmEmpDocBefore.Value;
                    }
                    catch
                    {
                        _SysSetting.AlarmEmpDocBefore = 0;
                    }
                    try
                    {
                        _SysSetting.AlarmEndVactionBefore = integerInput_AlarmEndVactionBefore.Value;
                    }
                    catch
                    {
                        _SysSetting.AlarmEndVactionBefore = 0;
                    }
                    try
                    {
                        _SysSetting.AlarmFamilyPassportBefore = integerInput_AlarmFamilyPassportBefore.Value;
                    }
                    catch
                    {
                        _SysSetting.AlarmFamilyPassportBefore = 0;
                    }
                    try
                    {
                        _SysSetting.AlarmGuarantorDocBefore = integerInput_AlarmGuarantorDocBefore.Value;
                    }
                    catch
                    {
                        _SysSetting.AlarmGuarantorDocBefore = 0;
                    }
                    try
                    {
                        _SysSetting.AlarmBranchDocBefore = 0;
                    }
                    catch
                    {
                        _SysSetting.AlarmBranchDocBefore = 0;
                    }
                    try
                    {
                        _SysSetting.AlarmCarDocBefore = integerInput_AlarmCarDocBefore.Value;
                    }
                    catch
                    {
                        _SysSetting.AlarmCarDocBefore = 0;
                    }
                    try
                    {
                        _SysSetting.AlarmCarDocBefore = integerInput_AlarmCarDocBefore.Value;
                    }
                    catch
                    {
                        _SysSetting.AlarmCarDocBefore = 0;
                    }
                    try
                    {
                        _SysSetting.AlarmSecretariatsBefore = integerInput_AlarmSecretariatsBefore.Value;
                    }
                    catch
                    {
                        _SysSetting.AlarmSecretariatsBefore = 0;
                    }
                    try
                    {
                        _SysSetting.IsAlarmEmpContract = checkBox_IsAlarmEmpContract.Checked;
                    }
                    catch
                    {
                        _SysSetting.IsAlarmEmpContract = false;
                    }
                    try
                    {
                        _SysSetting.IsAlarmEmpDoc = checkBox_IsAlarmEmpDoc.Checked;
                    }
                    catch
                    {
                        _SysSetting.IsAlarmEmpDoc = false;
                    }
                    try
                    {
                        _SysSetting.IsAlarmSecretariatsDoc = checkBox_IsAlarmSecretariatsDoc.Checked;
                    }
                    catch
                    {
                        _SysSetting.IsAlarmSecretariatsDoc = false;
                    }
                    try
                    {
                        _SysSetting.IsAlarmVisaGoBack = checkBox_IsAlarmVisaGoBack.Checked;
                    }
                    catch
                    {
                        _SysSetting.IsAlarmVisaGoBack = false;
                    }
                    try
                    {
                        _SysSetting.IsAlarmVisaIntro = false;
                    }
                    catch
                    {
                        _SysSetting.IsAlarmVisaIntro = false;
                    }
                    try
                    {
                        _SysSetting.IsAlarmDepts = checkBox_IsAlarmDepts.Checked;
                    }
                    catch
                    {
                        _SysSetting.IsAlarmDepts = false;
                    }
                    try
                    {
                        _SysSetting.IsAlarmEndVaction = checkBox_IsAlarmEndVaction.Checked;
                    }
                    catch
                    {
                        _SysSetting.IsAlarmEndVaction = false;
                    }
                    try
                    {
                        _SysSetting.IsAlarmBranchDoc = false;
                    }
                    catch
                    {
                        _SysSetting.IsAlarmBranchDoc = false;
                    }
                    try
                    {
                        _SysSetting.IsAlarmFamilyPassport = checkBox_IsAlarmFamilyPassport.Checked;
                    }
                    catch
                    {
                        _SysSetting.IsAlarmFamilyPassport = false;
                    }
                    try
                    {
                        _SysSetting.IsAlarmGuarantorDoc = checkBox_IsAlarmGuarantorDoc.Checked;
                    }
                    catch
                    {
                        _SysSetting.IsAlarmGuarantorDoc = false;
                    }
                    try
                    {
                        _SysSetting.IsAlarmCarDoc = checkBox_IsAlarmCarDoc.Checked;
                    }
                    catch
                    {
                        _SysSetting.IsAlarmCarDoc = false;
                    }
                    try
                    {
                        _SysSetting.AttendanceManually = checkBox_AttendanceManually.Checked;
                    }
                    catch
                    {
                        _SysSetting.AttendanceManually = false;
                    }
                    try
                    {
                        _SysSetting.AutoLeave = checkBox_AutoLeave.Checked;
                    }
                    catch
                    {
                        _SysSetting.AutoLeave = false;
                    }
                    try
                    {
                        _SysSetting.VacationManually = checkBox_VacationManually.Checked;
                    }
                    catch
                    {
                        _SysSetting.VacationManually = false;
                    }
                    try
                    {
                        _SysSetting.AutoChangSalStatus = false;
                    }
                    catch
                    {
                        _SysSetting.AutoChangSalStatus = false;
                    }
                    try
                    {
                        _SysSetting.Sponer = checkBox_Sponer.Checked;
                    }
                    catch
                    {
                        _SysSetting.Sponer = false;
                    }
                    try
                    {
                        _SysSetting.IsAutoBackup = checkBox_AutoBackup.Checked;
                    }
                    catch
                    {
                        _SysSetting.IsAutoBackup = false;
                    }
                    try
                    {
                        _SysSetting.AutoBackup = comboBox_AutoBackup.SelectedIndex;
                    }
                    catch
                    {
                        _SysSetting.AutoBackup = 0;
                    }
                }
                settingNewLine = VarGeneral.TString.ChkStatSave(chk1Show.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk1Print.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk2Show.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk2Print.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk3Show.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk3Print.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk4Show.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk4Print.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk5Show.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk5Print.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk6Show.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk6Print.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk7Show.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk7Print.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk8Show.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk8Print.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk9Show.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk9Print.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk10Show.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk10Print.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk11Show.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk11Print.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk12Show.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk12Print.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk13Show.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk13Print.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk14Show.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk14Print.Checked);
                if (switchButton_NewColumnName.Value)
                {
                    _SysSetting.LineDetailSts = settingNewLine;
                    VarGeneral.Settings_Sys.LineDetailSts = settingNewLine;
                }
                else
                {
                    _SysSetting.LineGiftSts = settingNewLine;
                    VarGeneral.Settings_Sys.LineGiftSts = settingNewLine;
                }
                _SysSetting.GuestAcc = txtGuestsFatherAcc.Text;
                _SysSetting.GuestBoxAcc = txtGuestBoxAcc.Text;
                //    _SysSetting.DefLines_Setting = txtpageCountRep.Value;
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                _Company.Active = txtAct.Text;
                _Company.Adder = txtAddr.Text;
                _Company.CopNam = txtCompany.Text;
                _Company.Eamil = txtRemark.Text;
                _Company.Fax = txtFax.Text;
                _Company.Mobl = txtMobile.Text;
                _Company.Pox = txtPOBox.Text;
                _Company.Symbl = txtMailCode.Text;
                _Company.Tel1 = txtTel1.Text;
                _Company.Tel2 = txtTel2.Text;
                _Company.Seller_VAT_Number = TXtVatNumbber.Text;
                _Company.Group_VAT_Number = TxtGroupVatNumb.Text;
                _Company.Seller_Other_ID = comboBox1.SelectedIndex.ToString();
                _Company.Seller_City = Byer_IDTExt.Text;
                _Company.Seller_Name = Byer_IDTExt.Text;
                _Company.Street_Line1 = streetline1.Text;
                _Company.Street_Line2 = streetline2.Text;
                _Company.City_Provision_District = ProviesionState.Text;
                _Company.Country_Code = CountryCode.Text;
                _Company.Building_Number = BuildingNumber.Text;
                _Company.Addational_Address_Number = AddationalNumber.Text;
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                _GdAuto.Acc0 = int.Parse(txtBoxAccount.Text);
                _GdAuto.Acc1 = int.Parse(txtProfits.Text);
                _GdAuto.Acc2 = int.Parse(txtFirstInventory.Text);
                _GdAuto.Acc3 = int.Parse(txtLastInventory.Text);
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                for (int iiCnt = 1; iiCnt < c1FlexGrid1.Rows.Count; iiCnt++)
                {
                    for (int i = 0; i < listInvSetting.Count; i++)
                    {
                        _InvSetting = listInvSetting[i];
                        if (_InvSetting.InvID == int.Parse(c1FlexGrid1.GetData(iiCnt, 6).ToString()))
                        {
                            if (c1FlexGrid1.GetData(iiCnt, 7).ToString() == "0")
                            {
                                _InvSetting.AccDebit0 = c1FlexGrid1.GetData(iiCnt, 4).ToString();
                                _InvSetting.AccCredit0 = c1FlexGrid1.GetData(iiCnt, 5).ToString();
                                _InvSetting.InvSetting = _InvSetting.InvSetting.Substring(0, 1) + VarGeneral.TString.ChkStatSave((bool)c1FlexGrid1.GetData(iiCnt, 3)) + _InvSetting.InvSetting.Substring(0, 1);
                            }
                            else if (c1FlexGrid1.GetData(iiCnt, 7).ToString() == "1")
                            {
                                _InvSetting.AccDebit1 = c1FlexGrid1.GetData(iiCnt, 4).ToString();
                                _InvSetting.AccCredit1 = c1FlexGrid1.GetData(iiCnt, 5).ToString();
                                _InvSetting.InvSetting = _InvSetting.InvSetting.Substring(0, 1) + VarGeneral.TString.ChkStatSave((bool)c1FlexGrid1.GetData(iiCnt, 3)) + _InvSetting.InvSetting.Substring(0, 1);
                            }
                            else if (c1FlexGrid1.GetData(iiCnt, 7).ToString() == "2")
                            {
                                _InvSetting.AccDebit2 = c1FlexGrid1.GetData(iiCnt, 4).ToString();
                                _InvSetting.AccCredit2 = c1FlexGrid1.GetData(iiCnt, 5).ToString();
                                _InvSetting.InvSetting = _InvSetting.InvSetting.Substring(0, 1) + VarGeneral.TString.ChkStatSave((bool)c1FlexGrid1.GetData(iiCnt, 3)) + _InvSetting.InvSetting.Substring(0, 1);
                            }
                            else if (c1FlexGrid1.GetData(iiCnt, 7).ToString() == "3")
                            {
                                _InvSetting.DisDebit = c1FlexGrid1.GetData(iiCnt, 4).ToString();
                                _InvSetting.DisCredit = c1FlexGrid1.GetData(iiCnt, 5).ToString();
                                _InvSetting.autoDisGaid = Convert.ToBoolean(c1FlexGrid1.GetData(iiCnt, 3));
                            }
                            db.Log = VarGeneral.DebugLog;
                            db.SubmitChanges(ConflictMode.ContinueOnConflict);
                            break;
                        }
                    }
                }
                db.ExecuteCommand(string.Concat("update T_InfoTb set fldValue = '", txtHeadingR1.Text, "' where fldFlag = '", txtHeadingR1.Tag, "'"));
                db.ExecuteCommand(string.Concat("update T_InfoTb set fldValue = '", txtHeadingR2.Text, "' where fldFlag = '", txtHeadingR2.Tag, "'"));
                db.ExecuteCommand(string.Concat("update T_InfoTb set fldValue = '", txtHeadingR3.Text, "' where fldFlag = '", txtHeadingR3.Tag, "'"));
                db.ExecuteCommand(string.Concat("update T_InfoTb set fldValue = '", txtHeadingR4.Text, "' where fldFlag = '", txtHeadingR4.Tag, "'"));
                db.ExecuteCommand(string.Concat("update T_InfoTb set fldValue = '", txtHeadingL1.Text, "' where fldFlag = '", txtHeadingL1.Tag, "'"));
                db.ExecuteCommand(string.Concat("update T_InfoTb set fldValue = '", txtHeadingL2.Text, "' where fldFlag = '", txtHeadingL2.Tag, "'"));
                db.ExecuteCommand(string.Concat("update T_InfoTb set fldValue = '", txtHeadingL3.Text, "' where fldFlag = '", txtHeadingL3.Tag, "'"));
                db.ExecuteCommand(string.Concat("update T_InfoTb set fldValue = '", txtHeadingL4.Text, "' where fldFlag = '", txtHeadingL4.Tag, "'"));
                for (int i = 2; i < FlxInv.Rows.Count; i++)
                {
                    db.ExecuteCommand(string.Concat("update T_AccDef set DepreciationPercent = ", FlxInv.GetData(i, 2), ", ProofAcc = '", FlxInv.GetData(i, 3), "',RelayAcc = '", FlxInv.GetData(i, 4), "' where AccDef_No = '", FlxInv.GetData(i, 5), "'"));
                }
                db.ExecuteCommand("update T_Curency set Rate = 1 where Curency_ID = " + int.Parse(_SysSetting.ImportIp));
                if (ksa != 1) MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                try
                {
                    Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
                    VarGeneral.Settings_Sys = new T_SYSSETTING();
                    VarGeneral.Settings_Sys = dbc.SystemSettingStock();
                    VarGeneral._SysDirPath = VarGeneral.Settings_Sys.SysDir;
                    VarGeneral._BackPath = VarGeneral.Settings_Sys.BackPath;
                    try
                    {
                        VarGeneral._AutoSync = VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 41);
                    }
                    catch
                    {
                        VarGeneral._AutoSync = false;
                    }
                    dbc.getdate = string.Empty;
                }
                catch
                {
                    Application.Exit();
                }
                if (VarGeneral.Settings_Sys.Calendr.Value == 0)
                {
                    CultureInfo sa = new CultureInfo("en-US", useUserOverride: false);
                    sa.DateTimeFormat.Calendar = new GregorianCalendar();
                    Thread.CurrentThread.CurrentCulture = sa;
                    Thread.CurrentThread.CurrentUICulture = sa;
                }
                else
                {
                    CultureInfo sa = new CultureInfo("ar-SA", useUserOverride: false);
                    sa.DateTimeFormat.Calendar = new HijriCalendar();
                    Thread.CurrentThread.CurrentCulture = sa;
                    Thread.CurrentThread.CurrentUICulture = sa;
                }
                if (ksa != 1) Close();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Save:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void SaveDataBalance()
        {
            try
            {
                if (txtWieghtQ.Value > txtWightTo.Value)
                {
                    MessageBox.Show((LangArEn == 0) ? "تأكد من صحة رقم الفاصلة العشرية للوزن" : "Make sure the decimal point number is correct", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (txtPriceQ.Value > txtPriceTo.Value)
                {
                    MessageBox.Show((LangArEn == 0) ? "تأكد من صحة رقم الفاصلة العشرية للسعر" : "Make sure the decimal point number is correct", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                db.ExecuteCommand("update T_SYSSETTING set IsActiveBalance = " + (checkBox_BalanceActivated.Checked ? 1 : 0));
                db.ExecuteCommand("update T_SYSSETTING set BalanceType = " + ((!RedButWight.Checked) ? (RedButPrice.Checked ? 1 : 2) : 0));
                db.ExecuteCommand("update T_SYSSETTING set BarcodFrom = " + txtBarcodFrom.Value);
                db.ExecuteCommand("update T_SYSSETTING set BarcodTo = " + txtBarcodTo.Value);
                db.ExecuteCommand("update T_SYSSETTING set WightFrom = " + txtWightFrom.Value);
                db.ExecuteCommand("update T_SYSSETTING set WightTo = " + txtWightTo.Value);
                db.ExecuteCommand("update T_SYSSETTING set PriceFrom = " + txtPriceFrom.Value);
                db.ExecuteCommand("update T_SYSSETTING set PriceTo = " + txtPriceTo.Value);
                db.ExecuteCommand("update T_SYSSETTING set WightQ = " + txtWieghtQ.Value);
                db.ExecuteCommand("update T_SYSSETTING set PriceQ = " + txtPriceQ.Value);
                using (Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS))
                {
                    VarGeneral.Settings_Sys = new T_SYSSETTING();
                    VarGeneral.Settings_Sys = dbc.SystemSettingStock();
                    VarGeneral._SysDirPath = VarGeneral.Settings_Sys.SysDir;
                    VarGeneral._BackPath = VarGeneral.Settings_Sys.BackPath;
                    try
                    {
                        VarGeneral._AutoSync = VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 41);
                    }
                    catch
                    {
                        VarGeneral._AutoSync = false;
                    }
                }
                //	MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Close();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Save:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }

        private void ButWithSave_Click(object sender, EventArgs e)
        {
            SaveData();
            State = FormState.Saved;
            SetReadOnly = true;
            SaveDataTax();
            State = FormState.Saved;
            SaveDataBankopp();
            SetReadOnly = true; SaveDataBalance();
            SaveDataCustDis();
        }
        private void ButWithoutSave_Click(object sender, EventArgs e)
        {
            Close();
        }

        int ksa = 0;
        private void txtFirstInventory_ButtonCustomClick(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                txtFirstInventory.Text = _AccDef.AccDef_No.ToString();
            }
            VarGeneral.Flush();
        }
        private void txtLastInventory_ButtonCustomClick(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                txtLastInventory.Text = _AccDef.AccDef_No.ToString();
            }
            VarGeneral.Flush();
        }
        private void txtBoxAccount_ButtonCustomClick(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                txtBoxAccount.Text = _AccDef.AccDef_No.ToString();
            }
            VarGeneral.Flush();
        }
        private void txtProfits_ButtonCustomClick(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                txtProfits.Text = _AccDef.AccDef_No.ToString();
            }
            VarGeneral.Flush();
        }
      private void chk19_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chk1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void chk58_CheckedChanged(object sender, EventArgs e)
        {
            if (chk58.Checked)
            {
                txtDateofInv.Enabled = true;
            }
            else
            {
                txtDateofInv.Enabled = false;
            }
        }
        private void chk3_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void textbox_Arb_Des_Enter(object sender, EventArgs e)
        {
            SSSLanguage.Language.Switch("AR");
        }
        private void textbox_Eng_Des_Enter(object sender, EventArgs e)
        {
            SSSLanguage.Language.Switch("EN");
        }
        private void txtHeadingR3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b')) && e.KeyChar != '-' && e.KeyChar != '\\')
            {
                e.Handled = true;
            }
        }
        private void textBox_BackupPath_Click(object sender, EventArgs e)
        {
            textBox_BackupPath.SelectAll();
        }
        private void txtGregDate_Click(object sender, EventArgs e)
        {
            txtGregDate.SelectAll();
        }

        private void TegnicalCollage()
        {
            node1.Visible = false;
            node2.Visible = false;
            node5.Visible = false;
            node6.Visible = false;
            node9.Visible = false;
            node10.Visible = false;
            node14.Visible = false;
            labelAlarmDueo.Visible = false;
            txtAlarmDeuDateBefor.Visible = false;
            chk69.Enabled = false;
            //chk68.Enabled = false;
            //chk67.Enabled = false;
            //chk66.Enabled = false;
            //chk64.Enabled = false;
            //chk63.Enabled = false;
            //chk62.Enabled = false;
            //chk61.Enabled = false;
            chk58.Enabled = false;
            txtDateofInv.Visible = false;
            label76.Visible = false;
            //chk34.Enabled = false;
            //chk21.Enabled = false;
            //chk31.Enabled = false;
            //chk33.Enabled = false;
            //chk7.Enabled = false;
            //chk6.Enabled = false;
            //chk5.Enabled = false;
            //chk56.Enabled = false;
            //chk23.Enabled = false;
            //chk10.Enabled = false;
            //chk22.Enabled = false;
            //chk16.Enabled = false;
            //chk38.Enabled = false;
            //chk48.Enabled = false;
            //chk8.Enabled = false;
            //chk15.Enabled = false;
            //chk17.Enabled = false;
            //chk18.Enabled = false;
            //chk55.Enabled = false;
            //chk54.Enabled = false;
            groupPanel_Acc.Visible = false;
            chk3.Enabled = false;
            txtDateAlarm.Enabled = false;
            CmbDateTyp.Enabled = false;
            chk2.Enabled = false;
            //button_CustomerDisplay.Visible = false;
            //button_Balance.Visible = false;
            button_PointOfCust.Visible = false;
            //button_CommOption.Visible = false;
            //button_TaxOption.Location = button_CommOption.Location;
            label51.Visible = false;
            CmbPointImages.Visible = false;
            label58.Visible = false;
            //chk35.Text = ((LangArEn == 0) ? "رسالة نصية بعد صرف العهدة" : "Message after discharge of custody");
        }
        private T_SYSSETTING _SysSettingBalance = new T_SYSSETTING();
        private void BindDataBalance()
        {
            try
            {
                State = FormState.Saved;
                ButWithSave.Enabled = false;
                checkBox_BalanceActivated.Checked = _SysSettingBalance.IsActiveBalance.Value;
                if (_SysSettingBalance.BalanceType.Value == 0)
                {
                    RedButWight.Checked = true;
                }
                else if (_SysSettingBalance.BalanceType.Value == 1)
                {
                    RedButPrice.Checked = true;
                }
                else
                {
                    RedButWightPrice.Checked = true;
                }
                txtBarcodFrom.Value = _SysSettingBalance.BarcodFrom.Value;
                txtBarcodTo.Value = _SysSettingBalance.BarcodTo.Value;
                txtWightFrom.Value = _SysSettingBalance.WightFrom.Value;
                txtWightTo.Value = _SysSettingBalance.WightTo.Value;
                txtPriceFrom.Value = _SysSettingBalance.PriceFrom.Value;
                txtPriceTo.Value = _SysSettingBalance.PriceTo.Value;
                txtWieghtQ.Value = _SysSettingBalance.WightQ.Value;
                txtPriceQ.Value = _SysSettingBalance.PriceQ.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private List<T_AccDef> listAccDefCustDis = new List<T_AccDef>();
        private T_AccDef _AccDefCustDis = new T_AccDef();
        private List<T_Company> listCompanyCustDis = new List<T_Company>();
        private T_Company _CompanyCustDis = new T_Company();
        private List<T_GdAuto> listGdAutoCustDis = new List<T_GdAuto>();
        private T_GdAuto _GdAutoCustDis = new T_GdAuto();
        private List<T_InfoTb> listInfotbCustDis = new List<T_InfoTb>();
        private T_InfoTb _InfotbCustDis = new T_InfoTb();
             private void txtHello_Click(object sender, EventArgs e)
        {
            txtHello.SelectAll();
        }
        private void button_CheckConn_Click(object sender, EventArgs e)
        {
            CustomerDisplayData(0.0, 0.0);
        }
        private void CustomerDisplayData(double _vTot, double _price)
        {
            try
            {
                SerialPort sport = new SerialPort(VarGeneral.Settings_Sys.Port, VarGeneral.Settings_Sys.Fast.Value, (VarGeneral.Settings_Sys.Parity.Value == 1) ? Parity.Even : ((VarGeneral.Settings_Sys.Parity.Value == 2) ? Parity.Mark : ((VarGeneral.Settings_Sys.Parity.Value != 3) ? ((VarGeneral.Settings_Sys.Parity.Value == 4) ? Parity.Odd : Parity.Space) : Parity.None)), VarGeneral.Settings_Sys.BitData.Value, (VarGeneral.Settings_Sys.BitStop.Value == 1) ? StopBits.One : ((VarGeneral.Settings_Sys.BitStop.Value == 2) ? StopBits.OnePointFive : StopBits.Two));
                sport.Open();
                sport.Write(new byte[1]
                {
                    12
                }, 0, 1);
                sport.Write(txtHello.Text);
                sport.Write(new byte[2]
                {
                    10,
                    13
                }, 0, 2);
                if (cmbShowState.SelectedIndex == 0)
                {
                    sport.Write("Price:" + _price + " Total:" + _vTot);
                }
                else if (cmbShowState.SelectedIndex == 1)
                {
                    sport.Write("Price:" + _price);
                }
                else
                {
                    sport.Write(" Total:" + _vTot);
                }
                sport.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show((LangArEn == 0) ? "توجد هناك مشكلة في الإتصال بالجهاز الآخر يرجى التأكد من الإعدادات .. ثم المحاولة مرة اخرى " : "There is a problem connecting to the other device Please make sure the settings .. then try again", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                VarGeneral.DebLog.writeLog("CustomerDisplayData :", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void checkBox_IsAlarmVisaGoBack_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_IsAlarmVisaGoBack.Checked)
            {
                integerInput_AlarmVisaGoBack.Enabled = true;
                return;
            }
            integerInput_AlarmVisaGoBack.Enabled = false;
            integerInput_AlarmVisaGoBack.Value = 0;
        }
        private void checkBox_IsAlarmDepts_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_IsAlarmDepts.Checked)
            {
                integerInput_AlarmDeptsBefore.Enabled = true;
                return;
            }
            integerInput_AlarmDeptsBefore.Enabled = false;
            integerInput_AlarmDeptsBefore.Value = 0;
        }
        private void checkBox_IsAlarmEmpDoc_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_IsAlarmEmpDoc.Checked)
            {
                integerInput_AlarmEmpDocBefore.Enabled = true;
                return;
            }
            integerInput_AlarmEmpDocBefore.Enabled = false;
            integerInput_AlarmEmpDocBefore.Value = 0;
        }
        private void checkBox_IsAlarmEmpContract_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_IsAlarmEmpContract.Checked)
            {
                integerInput_AlarmEmpContractBefore.Enabled = true;
                return;
            }
            integerInput_AlarmEmpContractBefore.Enabled = false;
            integerInput_AlarmEmpContractBefore.Value = 0;
        }
        private void checkBox_IsAlarmFamilyPassport_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_IsAlarmFamilyPassport.Checked)
            {
                integerInput_AlarmFamilyPassportBefore.Enabled = true;
                return;
            }
            integerInput_AlarmFamilyPassportBefore.Enabled = false;
            integerInput_AlarmFamilyPassportBefore.Value = 0;
        }
        private void checkBox_IsAlarmGuarantorDoc_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_IsAlarmGuarantorDoc.Checked)
            {
                integerInput_AlarmGuarantorDocBefore.Enabled = true;
                return;
            }
            integerInput_AlarmGuarantorDocBefore.Enabled = false;
            integerInput_AlarmGuarantorDocBefore.Value = 0;
        }
        private void checkBox_IsAlarmEndVaction_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_IsAlarmEndVaction.Checked)
            {
                integerInput_AlarmEndVactionBefore.Enabled = true;
                return;
            }
            integerInput_AlarmEndVactionBefore.Enabled = false;
            integerInput_AlarmEndVactionBefore.Value = 0;
        }
        private void checkBox_IsAlarmCarDoc_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_IsAlarmCarDoc.Checked)
            {
                integerInput_AlarmCarDocBefore.Enabled = true;
                return;
            }
            integerInput_AlarmCarDocBefore.Enabled = false;
            integerInput_AlarmCarDocBefore.Value = 0;
        }
        private void checkBox_IsAlarmSecretariatsDoc_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_IsAlarmSecretariatsDoc.Checked)
            {
                integerInput_AlarmSecretariatsBefore.Enabled = true;
                return;
            }
            integerInput_AlarmSecretariatsBefore.Enabled = false;
            integerInput_AlarmSecretariatsBefore.Value = 0;
        }
        private void checkBox_AutoLeave_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_AutoLeave.Checked)
            {
                textBox_AutoEmpLeaveAfter.Enabled = true;
                return;
            }
            textBox_AutoEmpLeaveAfter.Enabled = false;
            textBox_AutoEmpLeaveAfter.Value = 0;
        }
        public static string getbno()
        {
            RegistryKey hKeyNeew1 = Registry.CurrentUser.OpenSubKey("Software\\MrdHrdw\\ItIntel", writable: true);
            string bno = "0";
            try
            {
                object q = hKeyNeew1.GetValue("vAutoSync");
                bno = q.ToString();
            }
            catch
            {
                hKeyNeew1.CreateSubKey("vAutoSync");
                hKeyNeew1.SetValue("vAutoSync", 0);
                return bno;
            }
            return bno;
        }
        private void NewColumnData()
        {
            textBox_LineDetailNameA.Text = (switchButton_NewColumnName.Value ? _SysSetting.LineDetailNameA : _SysSetting.LineGiftlNameA);
            textBox_LineDetailNameE.Text = (switchButton_NewColumnName.Value ? _SysSetting.LineDetailNameE : _SysSetting.LineGiftlNameE);
            chk1Show.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 0) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 0));
            chk1Print.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 1) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 1));
            chk2Show.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 2) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 2));
            chk2Print.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 3) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 3));
            chk3Show.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 4) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 4));
            chk3Print.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 5) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 5));
            chk4Show.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 6) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 6));
            chk4Print.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 7) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 7));
            chk5Show.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 8) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 8));
            chk5Print.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 9) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 9));
            chk6Show.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 10) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 10));
            chk6Print.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 11) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 11));
            chk7Show.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 12) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 12));
            chk7Print.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 13) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 13));
            chk8Show.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 14) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 14));
            chk8Print.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 15) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 15));
            chk9Show.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 16) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 16));
            chk9Print.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 17) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 17));
            chk10Show.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 18) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 18));
            chk10Print.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 19) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 19));
            chk11Show.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 20) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 20));
            chk11Print.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 21) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 21));
            chk12Show.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 22) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 22));
            chk12Print.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 23) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 23));
            chk13Show.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 24) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 24));
            chk13Print.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 25) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 25));
            chk14Show.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 26) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 26));
            chk14Print.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 27) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 27));
        }

        private void BindData()
        {
            try
            {
                State = FormState.Saved;
                ButWithSave.Enabled = false;
                txtHijriDate.Tag = _SysSetting.HDat;
                txtGregDate.Text = VarGeneral.Gdate;
                txtHijriDate.Text = VarGeneral.Hdate;
                CmbCalendar.SelectedIndex = _SysSetting.Calendr.Value;
                txtAutoNumber.Text = _SysSetting.AutoItm.ToString();
                CmbDateTyp.SelectedIndex = int.Parse(_SysSetting.DMY.ToString());
                CmbMail.SelectedIndex = int.Parse(_SysSetting.DataBaseNm.ToString());
                if (!string.IsNullOrEmpty(_SysSetting.ImportIp))
                {
                    CmbCurr.SelectedValue = int.Parse(_SysSetting.ImportIp);
                }
                txtDateAlarm.Text = _SysSetting.LrnExp.ToString();
                try
                {
                    txtKeyNational.Text = _SysSetting.AccSup.Trim();
                }
                catch
                {
                    txtKeyNational.Text = string.Empty;
                }
                try
                {
                    if (!string.IsNullOrEmpty(_SysSetting.AccCus))
                    {
                        txtDateofInv.Value = int.Parse(_SysSetting.AccCus);
                    }
                    else
                    {
                        txtDateofInv.Value = 0;
                    }
                }
                catch
                {
                    txtDateofInv.Value = 0;
                }
                try
                {
                    if (_SysSetting.AlarmDueoBefore.HasValue)
                    {
                        txtAlarmDeuDateBefor.Value = _SysSetting.AlarmDueoBefore.Value;
                    }
                    else
                    {
                        txtAlarmDeuDateBefor.Value = 0;
                    }
                }
                catch
                {
                    txtAlarmDeuDateBefor.Value = 0;
                }
                txtDateAlarmEmps.Value = _SysSetting.AlarmEmployee.Value;
                try
                {
                    txtLinesInv.Value = _SysSetting.LineOfInvoices.Value;
                }
                catch
                {
                    txtLinesInv.Value = 100;
                }
                chk1.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 0);
                chk2.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 1);
                chk3.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 2);
                ChkHead.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 9);
                ChkGreg.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 10);
                ChkHijri.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 11);
                ChkPageNumber.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 12);
                CmbCost.SelectedIndex = int.Parse(_SysSetting.Seting.Substring(13, 1));
                chk19.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 23);
                chk27.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 31);
                 try
                {
                    chk36.SelectedIndex = int.Parse(_SysSetting.Seting.Substring(40, 1));
                }
                catch
                {
                    chk36.SelectedIndex = 0;
                }
                string g = getbno();
                if (g == "1")
                    chk37.Value = true;
                else
                    chk37.Value = false;
                 if (VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 34) && VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 43))
                {
                    chk39.SelectedIndex = 0;
                }
                else if (!VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 34) && !VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 43))
                {
                    chk39.SelectedIndex = 3;
                }
                else if (!VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 34))
                {
                    chk39.SelectedIndex = 1;
                }
                else
                {
                    chk39.SelectedIndex = 2;
                }
                chk42.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 46);
                chk43.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 47);
                chk44.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 48);
                chk45.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 49);
                if (_SysSetting.AfterDotNum == null)
                    _SysSetting.AfterDotNum = 3;
                numbersafterdecimal.Value = (int)_SysSetting.AfterDotNum;
                if (_SysSetting.AfterDotNum == null)
                    VarGeneral.setDecimalPointSettings(3);
                else
                    VarGeneral.setDecimalPointSettings((int)_SysSetting.AfterDotNum);
                 try
                {
                    chk46.SelectedIndex = int.Parse(_SysSetting.Seting.Substring(50, 1));
                }
                catch
                {
                    chk46.SelectedIndex = 0;
                }
                 if (!VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 59))
                {
                    CmbOrderTyp.SelectedIndex = 0;
                }
                else
                {
                    CmbOrderTyp.SelectedIndex = 1;
                }
                chk58.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 63);
                chk65.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 70);
                
                chk69.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 74);
               
                chk71.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 76);
              
                chk76.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 81);
                chk77.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 82);
                if (_SysSetting.LogImg != null)
                {
                    byte[] arr = _SysSetting.LogImg.ToArray();
                    MemoryStream stream = new MemoryStream(arr);
                    PicItemImg.Image = Image.FromStream(stream);
                }
                radioButton_IsNotBackground.Checked = _SysSetting.IsNotBackground.Value;
                textBox_BackupPath.Text = _SysSetting.BackPath;
                textBox_BackupElectronic.Tag = _SysSetting.SysDir;
                textBox_SyncPath.Text = _SysSetting.SyncPath;
                checkBox_AutoBackup.Checked = _SysSetting.IsAutoBackup.Value;
                comboBox_AutoBackup.SelectedIndex = _SysSetting.AutoBackup.Value;
                if (CmbCost.SelectedIndex < 0)
                {
                    CmbCost.SelectedIndex = 0;
                }
                if (CmbCalendar.SelectedIndex < 0)
                {
                    CmbCalendar.SelectedIndex = 0;
                }
                if (CmbDateTyp.SelectedIndex < 0)
                {
                    CmbDateTyp.SelectedIndex = 0;
                }
                CmbInvMode.SelectedIndex = int.Parse(_SysSetting.InvMod.ToString());
                if (CmbInvMode.SelectedIndex < 0)
                {
                    CmbInvMode.SelectedIndex = 0;
                }
                CmbPrintTyp.SelectedIndex = _SysSetting.AutoEmp.Value;
                CmbPointImages.SelectedIndex = _SysSetting.Path_Kind.Value;
                txtEmailBoss.Text = _SysSetting.ServerNm.Trim();
                txtEmailPass.Text = _SysSetting.Sa_Pass;
                NewColumnData();
                if (string.IsNullOrEmpty(textBox_BackupElectronic.Tag.ToString()) || !Directory.Exists(VarGeneral.Settings_Sys.SysDir))
                {
                    textBox_BackupElectronic.Text = ((LangArEn == 0) ? "يتعذر الوصول الى مسار النسخ الإحتياطي" : "It not been determined path");
                }
                else
                {
                    textBox_BackupElectronic.Text = ((LangArEn == 0) ? "لقد تم تحديد مسار النسخ الالكتروني" : "It has been determined path");
                }
                txtEqarContractEndAlarm.Value = _SysSetting.EqarAlarmContractEnd.Value;
                txtEqarDayOfPayAlarm.Value = _SysSetting.EqarAlarmDayPay.Value;
                if (!string.IsNullOrEmpty(_SysSetting.EqarAcc))
                {
                    txtEqarsFatherAcc.Text = _SysSetting.EqarAcc.ToString();
                    txtEqarsFatherAccName.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(_SysSetting.EqarAcc.ToString()).Arb_Des : db.StockAccDefWithOutBalance(_SysSetting.EqarAcc.ToString()).Eng_Des);
                }
                if (!string.IsNullOrEmpty(_SysSetting.tenantAcc))
                {
                    txtTenantFatherAcc.Text = _SysSetting.tenantAcc.ToString();
                    txttenantFatherAccName.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(_SysSetting.tenantAcc.ToString()).Arb_Des : db.StockAccDefWithOutBalance(_SysSetting.tenantAcc.ToString()).Eng_Des);
                }
                List<T_Rom> _RoomSts = db.FillRoomWCondition();
                if (_RoomSts.Count > 0)
                {
                    txtFloors.IsInputReadOnly = true;
                }
                else
                {
                    List<T_Reserv> _ReservChk = db.ExecuteQuery<T_Reserv>("SELECT T_Reserv.ResrvNo, T_Reserv.Dat, T_Reserv.Rom, T_Reserv.Sts, T_Reserv.PerNm, T_Reserv.IdNo, T_Reserv.Nat , T_Reserv.Dat2 FROM T_Reserv where T_Reserv.sts=0 ", new object[0]).ToList();
                    if (_ReservChk.Count > 0)
                    {
                        txtFloors.IsInputReadOnly = true;
                    }
                }
                txtFloors.Value = _SysSetting.flore.Value;
                txtRoom.Value = _SysSetting.rom.Value;
                txtAllowPeriod.Text = _SysSetting.vStart;
                txtLeavePeriod.Text = _SysSetting.vEnd;
                txtDayofMonth.Value = _SysSetting.DayOfM.Value;
                txtLongitudinal.Value = _SysSetting.Fld_H.Value;
                txtWidthitudinal.Value = _SysSetting.Fld_w.Value;
                if (!string.IsNullOrEmpty(_SysSetting.GuestAcc))
                {
                    txtGuestsFatherAcc.Text = _SysSetting.GuestAcc.ToString();
                    txtGuestsFatherAccName.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(_SysSetting.GuestAcc.ToString()).Arb_Des : db.StockAccDefWithOutBalance(_SysSetting.GuestAcc.ToString()).Eng_Des);
                }
                if (!string.IsNullOrEmpty(_SysSetting.GuestBoxAcc))
                {
                    txtGuestBoxAcc.Text = _SysSetting.GuestBoxAcc.ToString();
                    txtGuestBoxAccName.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(_SysSetting.GuestBoxAcc.ToString()).Arb_Des : db.StockAccDefWithOutBalance(_SysSetting.GuestBoxAcc.ToString()).Eng_Des);
                }
                if (_SysSetting.vStartTyp.Trim() == "AM")
                {
                    RadioBox_AllowAM.Checked = true;
                }
                else
                {
                    RadioBox_AllowPM.Checked = true;
                }
                if (_SysSetting.vEndTyp.Trim() == "AM")
                {
                    RadioBox_LeaveAM.Checked = true;
                }
                else
                {
                    RadioBox_LeavePM.Checked = true;
                }
                try
                {
                    txtREmpty.BackColor = Color.FromArgb(int.Parse(_SysSetting.BColor0.Split(',').ToList()[0].Trim()), int.Parse(_SysSetting.BColor0.Split(',').ToList()[1].Trim()), int.Parse(_SysSetting.BColor0.Split(',').ToList()[2].Trim()));
                }
                catch
                {
                }
                try
                {
                    txtRAvailable.BackColor = Color.FromArgb(int.Parse(_SysSetting.BColor1.Split(',').ToList()[0].Trim()), int.Parse(_SysSetting.BColor1.Split(',').ToList()[1].Trim()), int.Parse(_SysSetting.BColor1.Split(',').ToList()[2].Trim()));
                }
                catch
                {
                }
                try
                {
                    txtRBussyDaily.BackColor = Color.FromArgb(int.Parse(_SysSetting.BColor2.Split(',').ToList()[0].Trim()), int.Parse(_SysSetting.BColor2.Split(',').ToList()[1].Trim()), int.Parse(_SysSetting.BColor2.Split(',').ToList()[2].Trim()));
                }
                catch
                {
                }
                try
                {
                    txtRBussyAppendix.BackColor = Color.FromArgb(int.Parse(_SysSetting.BColor3.Split(',').ToList()[0].Trim()), int.Parse(_SysSetting.BColor3.Split(',').ToList()[1].Trim()), int.Parse(_SysSetting.BColor3.Split(',').ToList()[2].Trim()));
                }
                catch
                {
                }
                try
                {
                    txtRClean.BackColor = Color.FromArgb(int.Parse(_SysSetting.BColor4.Split(',').ToList()[0].Trim()), int.Parse(_SysSetting.BColor4.Split(',').ToList()[1].Trim()), int.Parse(_SysSetting.BColor4.Split(',').ToList()[2].Trim()));
                }
                catch
                {
                }
                try
                {
                    txtRRepair.BackColor = Color.FromArgb(int.Parse(_SysSetting.BColor5.Split(',').ToList()[0].Trim()), int.Parse(_SysSetting.BColor5.Split(',').ToList()[1].Trim()), int.Parse(_SysSetting.BColor5.Split(',').ToList()[2].Trim()));
                }
                catch
                {
                }
                try
                {
                    txtRBussyMonthly.BackColor = Color.FromArgb(int.Parse(_SysSetting.BColor6.Split(',').ToList()[0].Trim()), int.Parse(_SysSetting.BColor6.Split(',').ToList()[1].Trim()), int.Parse(_SysSetting.BColor6.Split(',').ToList()[2].Trim()));
                }
                catch
                {
                }
                try
                {
                    txtRLeave.BackColor = Color.FromArgb(int.Parse(_SysSetting.BColor7.Split(',').ToList()[0].Trim()), int.Parse(_SysSetting.BColor7.Split(',').ToList()[1].Trim()), int.Parse(_SysSetting.BColor7.Split(',').ToList()[2].Trim()));
                }
                catch
                {
                }
                try
                {
                    txtREmpty.ForeColor = Color.FromArgb(int.Parse(_SysSetting.FColor0.Split(',').ToList()[0].Trim()), int.Parse(_SysSetting.FColor0.Split(',').ToList()[1].Trim()), int.Parse(_SysSetting.FColor0.Split(',').ToList()[2].Trim()));
                }
                catch
                {
                }
                try
                {
                    txtRAvailable.ForeColor = Color.FromArgb(int.Parse(_SysSetting.FColor1.Split(',').ToList()[0].Trim()), int.Parse(_SysSetting.FColor1.Split(',').ToList()[1].Trim()), int.Parse(_SysSetting.FColor1.Split(',').ToList()[2].Trim()));
                }
                catch
                {
                }
                try
                {
                    txtRBussyDaily.ForeColor = Color.FromArgb(int.Parse(_SysSetting.FColor2.Split(',').ToList()[0].Trim()), int.Parse(_SysSetting.FColor2.Split(',').ToList()[1].Trim()), int.Parse(_SysSetting.FColor2.Split(',').ToList()[2].Trim()));
                }
                catch
                {
                }
                try
                {
                    txtRBussyAppendix.ForeColor = Color.FromArgb(int.Parse(_SysSetting.FColor3.Split(',').ToList()[0].Trim()), int.Parse(_SysSetting.FColor3.Split(',').ToList()[1].Trim()), int.Parse(_SysSetting.FColor3.Split(',').ToList()[2].Trim()));
                }
                catch
                {
                }
                try
                {
                    txtRClean.ForeColor = Color.FromArgb(int.Parse(_SysSetting.FColor4.Split(',').ToList()[0].Trim()), int.Parse(_SysSetting.FColor4.Split(',').ToList()[1].Trim()), int.Parse(_SysSetting.FColor4.Split(',').ToList()[2].Trim()));
                }
                catch
                {
                }
                try
                {
                    txtRRepair.ForeColor = Color.FromArgb(int.Parse(_SysSetting.FColor5.Split(',').ToList()[0].Trim()), int.Parse(_SysSetting.FColor5.Split(',').ToList()[1].Trim()), int.Parse(_SysSetting.FColor5.Split(',').ToList()[2].Trim()));
                }
                catch
                {
                }
                try
                {
                    txtRBussyMonthly.ForeColor = Color.FromArgb(int.Parse(_SysSetting.FColor6.Split(',').ToList()[0].Trim()), int.Parse(_SysSetting.FColor6.Split(',').ToList()[1].Trim()), int.Parse(_SysSetting.FColor6.Split(',').ToList()[2].Trim()));
                }
                catch
                {
                }
                try
                {
                    txtRLeave.ForeColor = Color.FromArgb(int.Parse(_SysSetting.FColor7.Split(',').ToList()[0].Trim()), int.Parse(_SysSetting.FColor7.Split(',').ToList()[1].Trim()), int.Parse(_SysSetting.FColor7.Split(',').ToList()[2].Trim()));
                }
                catch
                {
                }
                try
                {
                    TxtGroupVatNumb.Text = _Company.Group_VAT_Number;

                }
                catch { }

                try
                {
                    comboBox1.SelectedIndex = int.Parse(_Company.Seller_Other_ID.ToString());
                }
                catch
                {
                    comboBox1.SelectedIndex = 0;

                }
                try
                {
                    TXtVatNumbber.Text = _Company.Seller_VAT_Number;

                }
                catch

                {
                    TXtVatNumbber.Text = "";
                }
                try
                {
                    Byer_IDTExt.Text = _Company.Seller_Name;
                }
                catch
                {
                    Byer_IDTExt.Text = "";
                }
                try
                {
                    streetline1.Text = _Company.Street_Line1;
                }
                catch
                { streetline1.Text = ""; }
                try
                {
                    streetline2.Text = _Company.Street_Line2;
                }
                catch
                {
                    streetline2.Text = "";
                }
                try
                {
                    ProviesionState.Text = _Company.City_Provision_District;
                }
                catch
                {
                    ProviesionState.Text = "";


                }
                try
                {
                    CountryCode.Text = _Company.Country_Code;
                }
                catch
                {
                    CountryCode.Text = "";


                }
                try
                {
                    BuildingNumber.Text = _Company.Building_Number;
                }
                catch { BuildingNumber.Text = ""; }
                try
                {
                    AddationalNumber.Text = _Company.Addational_Address_Number;
                }
                catch
                {
                    AddationalNumber.Text = "";

                }

                txtAct.Text = _Company.Active;
                txtAddr.Text = _Company.Adder;
                txtCompany.Text = _Company.CopNam;
                txtFax.Text = _Company.Fax;
                txtMailCode.Text = _Company.Symbl;
                txtMobile.Text = _Company.Mobl;
                txtPOBox.Text = _Company.Pox;
                txtRemark.Text = _Company.Eamil;
                txtTel1.Text = _Company.Tel1;
                txtTel2.Text = _Company.Tel2;
                txtBoxAccount.Text = _GdAuto.Acc0.ToString();
                txtFirstInventory.Text = _GdAuto.Acc2.ToString();
                txtLastInventory.Text = _GdAuto.Acc3.ToString();
                txtProfits.Text = _GdAuto.Acc1.ToString();
                for (int iiCnt = 1; iiCnt < c1FlexGrid1.Rows.Count; iiCnt++)
                {
                    for (int i = 0; i < listInvSetting.Count; i++)
                    {
                        _InvSetting = listInvSetting[i];
                        if (_InvSetting.InvID == int.Parse(c1FlexGrid1.GetData(iiCnt, 6).ToString()))
                        {
                            if (c1FlexGrid1.GetData(iiCnt, 7).ToString() == "0")
                            {
                                c1FlexGrid1.SetData(iiCnt, 4, (VarGeneral.TString.TEmpty(_InvSetting.AccDebit0) != "0") ? VarGeneral.TString.TEmpty(_InvSetting.AccDebit0) : string.Empty);
                                c1FlexGrid1.SetData(iiCnt, 5, (VarGeneral.TString.TEmpty(_InvSetting.AccCredit0) != "0") ? VarGeneral.TString.TEmpty(_InvSetting.AccCredit0) : string.Empty);
                                c1FlexGrid1.SetData(iiCnt, 3, VarGeneral.TString.ChkStatShow(_InvSetting.InvSetting, 1));
                            }
                            else if (c1FlexGrid1.GetData(iiCnt, 7).ToString() == "1")
                            {
                                c1FlexGrid1.SetData(iiCnt, 4, (VarGeneral.TString.TEmpty(_InvSetting.AccDebit1) != "0") ? VarGeneral.TString.TEmpty(_InvSetting.AccDebit1) : string.Empty);
                                c1FlexGrid1.SetData(iiCnt, 5, (VarGeneral.TString.TEmpty(_InvSetting.AccCredit1) != "0") ? VarGeneral.TString.TEmpty(_InvSetting.AccCredit1) : string.Empty);
                                c1FlexGrid1.SetData(iiCnt, 3, VarGeneral.TString.ChkStatShow(_InvSetting.InvSetting, 1));
                            }
                            else if (c1FlexGrid1.GetData(iiCnt, 7).ToString() == "2")
                            {
                                c1FlexGrid1.SetData(iiCnt, 4, (VarGeneral.TString.TEmpty(_InvSetting.AccDebit2) != "0") ? VarGeneral.TString.TEmpty(_InvSetting.AccDebit2) : string.Empty);
                                c1FlexGrid1.SetData(iiCnt, 5, (VarGeneral.TString.TEmpty(_InvSetting.AccCredit2) != "0") ? VarGeneral.TString.TEmpty(_InvSetting.AccCredit2) : string.Empty);
                                c1FlexGrid1.SetData(iiCnt, 3, VarGeneral.TString.ChkStatShow(_InvSetting.InvSetting, 1));
                            }
                            else if (c1FlexGrid1.GetData(iiCnt, 7).ToString() == "3")
                            {
                                c1FlexGrid1.SetData(iiCnt, 4, VarGeneral.TString.TEmpty(_InvSetting.DisDebit));
                                c1FlexGrid1.SetData(iiCnt, 5, VarGeneral.TString.TEmpty(_InvSetting.DisCredit));
                                c1FlexGrid1.SetData(iiCnt, 3, _InvSetting.autoDisGaid.Value);
                            }
                            break;
                        }
                    }
                }
                for (int iiCnt = 0; iiCnt < listInfotb.Count; iiCnt++)
                {
                    _Infotb = listInfotb[iiCnt];
                    if (txtHeadingL1.Tag.ToString() == _Infotb.fldFlag.ToString())
                    {
                        txtHeadingL1.Text = _Infotb.fldValue;
                    }
                    else if (txtHeadingL2.Tag.ToString() == _Infotb.fldFlag.ToString())
                    {
                        txtHeadingL2.Text = _Infotb.fldValue;
                    }
                    else if (txtHeadingL3.Tag.ToString() == _Infotb.fldFlag.ToString())
                    {
                        txtHeadingL3.Text = _Infotb.fldValue;
                    }
                    else if (txtHeadingL4.Tag.ToString() == _Infotb.fldFlag.ToString())
                    {
                        txtHeadingL4.Text = _Infotb.fldValue;
                    }
                    else if (txtHeadingR1.Tag.ToString() == _Infotb.fldFlag.ToString())
                    {
                        txtHeadingR1.Text = _Infotb.fldValue;
                    }
                    else if (txtHeadingR2.Tag.ToString() == _Infotb.fldFlag.ToString())
                    {
                        txtHeadingR2.Text = _Infotb.fldValue;
                    }
                    else if (txtHeadingR3.Tag.ToString() == _Infotb.fldFlag.ToString())
                    {
                        txtHeadingR3.Text = _Infotb.fldValue;
                    }
                    else if (txtHeadingR4.Tag.ToString() == _Infotb.fldFlag.ToString())
                    {
                        txtHeadingR4.Text = _Infotb.fldValue;
                    }
                }
                checkBox_AutoBackup_CheckedChanged(null, null);
                chk1_CheckedChanged(null, null);
                chk3_CheckedChanged(null, null);
                chk58_CheckedChanged(null, null);
                chk19_CheckedChanged(null, null);
                chk69_CheckedChanged(null, null);
                try
                {
                    if (_SysSetting.BackgroundPic != null)
                    {
                        byte[] arr = _SysSetting.BackgroundPic.ToArray();
                        MemoryStream stream = new MemoryStream(arr);
                        pictureBox_EnterPic.Image = Image.FromStream(stream);
                    }
                    else
                    {
                        pictureBox_EnterPic.Image = Resources.sssBackground;
                    }
                }
                catch
                {
                    pictureBox_EnterPic.Image = Resources.sssBackground;
                }
                if (superTabItem_Employee.Visible)
                {
                    ChkEmp1.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.EmpSeting, 0);
                    textBox_AutoEmpLeaveAfter.Value = _SysSetting.EmpLeaveAfter.Value;
                    radioButton_IsNotBackground.Checked = _SysSetting.IsNotBackground.Value;
                    checkBox_AttendanceManually.Checked = _SysSetting.AttendanceManually.Value;
                    checkBox_AutoLeave.Checked = _SysSetting.AutoLeave.Value;
                    checkBox_IsAlarmEmpContract.Checked = _SysSetting.IsAlarmEmpContract.Value;
                    checkBox_IsAlarmEmpDoc.Checked = _SysSetting.IsAlarmEmpDoc.Value;
                    checkBox_IsAlarmSecretariatsDoc.Checked = _SysSetting.IsAlarmSecretariatsDoc.Value;
                    checkBox_IsAlarmVisaGoBack.Checked = _SysSetting.IsAlarmVisaGoBack.Value;
                    checkBox_IsAlarmDepts.Checked = _SysSetting.IsAlarmDepts.Value;
                    checkBox_IsAlarmEndVaction.Checked = _SysSetting.IsAlarmEndVaction.Value;
                    checkBox_IsAlarmFamilyPassport.Checked = _SysSetting.IsAlarmFamilyPassport.Value;
                    checkBox_IsAlarmGuarantorDoc.Checked = _SysSetting.IsAlarmGuarantorDoc.Value;
                    checkBox_IsAlarmCarDoc.Checked = _SysSetting.IsAlarmCarDoc.Value;
                    integerInput_AlarmEmpContractBefore.Value = _SysSetting.AlarmEmpContractBefore.Value;
                    integerInput_AlarmEmpDocBefore.Value = _SysSetting.AlarmEmpDocBefore.Value;
                    integerInput_AlarmEndVactionBefore.Value = _SysSetting.AlarmEndVactionBefore.Value;
                    integerInput_AlarmFamilyPassportBefore.Value = _SysSetting.AlarmFamilyPassportBefore.Value;
                    integerInput_AlarmGuarantorDocBefore.Value = _SysSetting.AlarmGuarantorDocBefore.Value;
                    integerInput_AlarmCarDocBefore.Value = _SysSetting.AlarmCarDocBefore.Value;
                    integerInput_AlarmSecretariatsBefore.Value = _SysSetting.AlarmSecretariatsBefore.Value;
                    integerInput_AlarmVisaGoBack.Value = _SysSetting.AlarmVisaGoBack.Value;
                    integerInput_AlarmDeptsBefore.Value = _SysSetting.AlarmDeptsBefore.Value;
                    checkBox_VacationManually.Checked = _SysSetting.VacationManually.Value;
                    checkBox_Sponer.Checked = _SysSetting.Sponer.Value;
                    checkBox_AutoBackup.Checked = _SysSetting.IsAutoBackup.Value;
                    comboBox_AutoBackup.SelectedIndex = _SysSetting.AutoBackup.Value;
                    textBox_BackupPath.Text = _SysSetting.BackPath;
                    textBox_DocPath.Text = _SysSetting.DocumentPath;
                    if (_SysSetting.CalculateNo.HasValue)
                    {
                        comboBox_CalculateNo.SelectedValue = _SysSetting.CalculateNo.Value;
                    }
                    if (_SysSetting.CalculatliquidNo.HasValue)
                    {
                        comboBox_CalculatliquidNo.SelectedValue = _SysSetting.CalculatliquidNo.Value;
                    }
                    if (_SysSetting.DisVacationType.HasValue)
                    {
                        comboBox_DisVacationType.SelectedIndex = _SysSetting.DisVacationType.Value;
                    }
                    checkBox_AutoLeave_CheckedChanged(null, null);
                    checkBox_IsAlarmEmpContract_CheckedChanged(null, null);
                    checkBox_IsAlarmEmpDoc_CheckedChanged(null, null);
                    checkBox_IsAlarmEndVaction_CheckedChanged(null, null);
                    checkBox_IsAlarmFamilyPassport_CheckedChanged(null, null);
                    checkBox_IsAlarmGuarantorDoc_CheckedChanged(null, null);
                    checkBox_IsAlarmCarDoc_CheckedChanged(null, null);
                    checkBox_IsAlarmSecretariatsDoc_CheckedChanged(null, null);
                    checkBox_IsAlarmVisaGoBack_CheckedChanged(null, null);
                    checkBox_IsAlarmDepts_CheckedChanged(null, null);
                }
                FlxInv.Rows.Count = listAccDef.Count + 2;
                for (int iiCnt = 2; iiCnt <= listAccDef.Count + 1; iiCnt++)
                {
                    _AccDef = listAccDef[iiCnt - 2];
                    FlxInv.SetData(iiCnt, 0, iiCnt - 1);
                    FlxInv.SetData(iiCnt, 1, (LangArEn == 0) ? _AccDef.Arb_Des.Trim() : _AccDef.Eng_Des.Trim());
                    FlxInv.SetData(iiCnt, 2, VarGeneral.TString.TEmpty(_AccDef.DepreciationPercent.ToString()));
                    try
                    {
                        FlxInv.SetData(iiCnt, 3, _AccDef.ProofAcc);
                    }
                    catch
                    {
                        FlxInv.SetData(iiCnt, 3, " ");
                    }
                    try
                    {
                        FlxInv.SetData(iiCnt, 4, _AccDef.RelayAcc);
                    }
                    catch
                    {
                        FlxInv.SetData(iiCnt, 4, " ");
                    }
                    FlxInv.SetData(iiCnt, 5, _AccDef.AccDef_No);
                }
                FlxInv.SetData(1, 3, (LangArEn == 0) ? "حسـاب المصــروف - المدين" : "Expense Acc - debtor");
                FlxInv.SetData(1, 4, (LangArEn == 0) ? "الصندوق / البنك - الدائن" : "Box / Bank - creditor");
                FlxInv.SetCellStyle(1, 3, "SubTotal0");
                FlxInv.SetCellStyle(1, 4, "SubTotal0");
                FlxInv.SetCellStyle(1, 2, "SubTotal0");
                FlxInv.SetCellStyle(1, 1, "SubTotal0");
                CmbPrintTyp_SelectedIndexChanged(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillComboCustDis()
        {
            cmbPort.Items.Clear();
            cmbPort.Items.Add("COM1");
            cmbPort.Items.Add("COM2");
            cmbPort.Items.Add("COM3");
            cmbPort.Items.Add("COM4");
            cmbPort.Items.Add("COM5");
            cmbPort.Items.Add("COM6");
            cmbPort.Items.Add("COM7");
            cmbPort.Items.Add("COM8");
            cmbPort.Items.Add("COM9");
            cmbPort.Items.Add("COM10");
            cmbPort.Items.Add("COM11");
            cmbPort.Items.Add("COM12");
            cmbPort.Items.Add("COM13");
            cmbPort.Items.Add("COM14");
            cmbPort.Items.Add("COM15");
            cmbPort.Items.Add("USB");
            cmbPort.Items.Add("USB1");
            cmbPort.Items.Add("USB2");
            cmbPort.Items.Add("USB3");
            cmbPort.Items.Add("USB4");
            cmbPort.Items.Add("USB5");
            cmbPort.Items.Add("USB6");
            cmbPort.SelectedIndex = 0;
            cmbFast.Items.Clear();
            cmbFast.Items.Add("110");
            cmbFast.Items.Add("300");
            cmbFast.Items.Add("600");
            cmbFast.Items.Add("1200");
            cmbFast.Items.Add("2400");
            cmbFast.Items.Add("9600");
            cmbFast.Items.Add("14400");
            cmbFast.Items.Add("19200");
            cmbFast.Items.Add("28800");
            cmbFast.Items.Add("38400");
            cmbFast.Items.Add("56000");
            cmbFast.Items.Add("128000");
            cmbFast.Items.Add("256000");
            cmbFast.SelectedIndex = 0;
            cmbShowState.Items.Clear();
            cmbShowState.Items.Add((LangArEn == 0) ? "الكـــــــل" : "ALL");
            cmbShowState.Items.Add((LangArEn == 0) ? "السعــر فقط" : "Only Price");
            cmbShowState.Items.Add((LangArEn == 0) ? "الإجمالي فقط" : "Only Total");
            cmbShowState.SelectedIndex = 0;
        }

        void loadcustdis()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmCustomerDisplay));
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                Language.ChangeLanguage("ar-SA", this, resources);
                LangArEn = 0;
            }
            else
            {
                Language.ChangeLanguage("en", this, resources);
                LangArEn = 1;
            }
            this.button_CheckConn.Click += new System.EventHandler(this.button_CheckConn_Click);
            this.txtHello.Click += new System.EventHandler(this.txtHello_Click);
            this.chkIsActive.CheckedChanged += new System.EventHandler(this.chkIsActive_CheckedChanged);
            cmbPort.Click += Button_Edit_Click;
            cmbFast.Click += Button_Edit_Click;
            cmbShowState.Click += Button_Edit_Click;
            chkStop1.Click += Button_Edit_Click;
            chkStop2.Click += Button_Edit_Click;
            chkStop3.Click += Button_Edit_Click;
            chkData1.Click += Button_Edit_Click;
            chkData2.Click += Button_Edit_Click;
            chkData3.Click += Button_Edit_Click;
            chkData4.Click += Button_Edit_Click;
            chkData5.Click += Button_Edit_Click;
            chkSync1.Click += Button_Edit_Click;
            chkSync2.Click += Button_Edit_Click;
            chkSync3.Click += Button_Edit_Click;
            chkSync4.Click += Button_Edit_Click;
            chkSync5.Click += Button_Edit_Click;
            txtHello.Click += Button_Edit_Click;
            chkIsActive.Click += Button_Edit_Click;
            try
            {
                //ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmCustomerDisplay));
                //if (VarGeneral.CurrentLang.ToString() == "0"||VarGeneral.CurrentLang.ToString() == "")
                //{
                //    Language.ChangeLanguage("ar-SA", this, resources);
                //    LangArEn = 0;
                //}
                //else
                //{
                //    Language.ChangeLanguage("en", this, resources);
                //    LangArEn = 1;
                //}
                //RibunButtonsCustDis();
                listInvSettingCustDis = db.StockInvSettingList(VarGeneral.UserID);
                _InvSettingCustDis = listInvSettingCustDis[0];
                _SysSettingCustDis = db.SystemSettingStock();
                listCompanyCustDis = db.StockCompanyList();
                _CompanyCustDis = listCompanyCustDis[0];
                _GdAutoCustDis = db.GdAutoStock();
                listInfotbCustDis = db.StockInfoList();
                _InfotbCustDis = listInfotbCustDis[0];
                listAccDefCustDis = db.FillAccDef_2(string.Empty).ToList();
                listAccDefCustDis = listAccDefCustDis.Where((T_AccDef q) => q.Trn == 3 && q.Lev == 4 && q.AccDef_No.StartsWith("1") && q.AccCat != 2 && q.AccCat != 3).ToList();
                try
                {
                    FillComboCustDis();
                }
                catch
                {
                }
                try
                {
                    BindDataCustDis();
                }
                catch
                {
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void BindDataCustDis()
        {
            chkIsActive.CheckedChanged -= chkIsActive_CheckedChanged;
            try
            {
                State = FormState.Saved;
                ButWithSave.Enabled = false;
                chkIsActive.Checked = _SysSettingCustDis.IsCustomerDisplay.Value;
                cmbPort.Text = _SysSettingCustDis.Port;
                cmbFast.Text = _SysSettingCustDis.Fast.Value.ToString();
                cmbShowState.SelectedIndex = _SysSettingCustDis.DisplayTypeShow.Value;
                if (_SysSettingCustDis.BitStop.Value == 1)
                {
                    chkStop1.Checked = true;
                }
                else if (_SysSettingCustDis.BitStop.Value == 2)
                {
                    chkStop2.Checked = true;
                }
                else
                {
                    chkStop3.Checked = true;
                }
                if (_SysSettingCustDis.BitData.Value == 4)
                {
                    chkData1.Checked = true;
                }
                else if (_SysSettingCustDis.BitData.Value == 5)
                {
                    chkData2.Checked = true;
                }
                else if (_SysSettingCustDis.BitData.Value == 6)
                {
                    chkData3.Checked = true;
                }
                else if (_SysSettingCustDis.BitData.Value == 7)
                {
                    chkData4.Checked = true;
                }
                else
                {
                    chkData5.Checked = true;
                }
                if (_SysSettingCustDis.Parity.Value == 1)
                {
                    chkSync1.Checked = true;
                }
                else if (_SysSettingCustDis.Parity.Value == 2)
                {
                    chkSync2.Checked = true;
                }
                else if (_SysSettingCustDis.Parity.Value == 3)
                {
                    chkSync3.Checked = true;
                }
                else if (_SysSettingCustDis.Parity.Value == 4)
                {
                    chkSync4.Checked = true;
                }
                else
                {
                    chkSync5.Checked = true;
                }
                txtHello.Text = _SysSettingCustDis.CustomerHello;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            chkIsActive.CheckedChanged += chkIsActive_CheckedChanged;
            chkIsActive_CheckedChanged(null, null);
        }
        private void SaveDataCustDis()
        {
            try
            {
                db.ExecuteCommand("update T_SYSSETTING set IsCustomerDisplay = " + (chkIsActive.Checked ? 1 : 0));
                db.ExecuteCommand("update T_SYSSETTING set Port = '" + cmbPort.Text + "'");
                db.ExecuteCommand("update T_SYSSETTING set Fast = " + cmbFast.Text);
                db.ExecuteCommand("update T_SYSSETTING set DisplayTypeShow = " + cmbShowState.SelectedIndex);
                db.ExecuteCommand("update T_SYSSETTING set BitStop = " + (chkStop1.Checked ? 1 : (chkStop2.Checked ? 2 : 3)));
                db.ExecuteCommand("update T_SYSSETTING set BitData = " + (chkData1.Checked ? 4 : (chkData2.Checked ? 5 : (chkData3.Checked ? 6 : (chkData4.Checked ? 7 : 8)))));
                db.ExecuteCommand("update T_SYSSETTING set Parity = " + (chkSync1.Checked ? 1 : (chkSync2.Checked ? 2 : (chkSync3.Checked ? 3 : (chkSync4.Checked ? 4 : 5)))));
                db.ExecuteCommand("update T_SYSSETTING set CustomerHello = '" + txtHello.Text + "'");
                using (Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS))
                {
                    VarGeneral.Settings_Sys = new T_SYSSETTING();
                    VarGeneral.Settings_Sys = dbc.SystemSettingStock();
                    VarGeneral._SysDirPath = VarGeneral.Settings_Sys.SysDir;
                    VarGeneral._BackPath = VarGeneral.Settings_Sys.BackPath;
                    try
                    {
                        VarGeneral._AutoSync = VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 41);
                    }
                    catch
                    {
                        VarGeneral._AutoSync = false;
                    }
                }
                //                MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Close();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Save:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void chkIsActive_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsActive.Checked)
            {
                groupPanel_Main.Enabled = true;
            }
            else
            {
                groupPanel_Main.Enabled = false;
            }
        }

        public Dictionary<string, ColumnDictinaryTax> columns_Names_visibleTax = new Dictionary<string, ColumnDictinaryTax>();
        private List<T_INVSETTING> listInvSettingTax = new List<T_INVSETTING>();
        private T_INVSETTING _InvSettingTax = new T_INVSETTING();
        private List<T_SYSSETTING> listSysSettingTax = new List<T_SYSSETTING>();
        private T_SYSSETTING _SysSettingTax = new T_SYSSETTING();
        private List<T_AccDef> listAccDefTax = new List<T_AccDef>();
        private T_AccDef _AccDefTax = new T_AccDef();
        private List<T_Company> listCompanyTax = new List<T_Company>();
        private T_Company _CompanyTax = new T_Company();
        private List<T_GdAuto> listGdAutoTax = new List<T_GdAuto>();
        private T_GdAuto _GdAutoTax = new T_GdAuto();
        private List<T_InfoTb> listInfotbTax = new List<T_InfoTb>();
        private void FillComboTax()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                try
                {
                    c1FlexGriadTax.SetData(0, 1, "الفاتورة");
                    c1FlexGriadTax.SetData(0, 2, "إظهار");
                    c1FlexGriadTax.SetData(0, 3, "طباعة");
                    c1FlexGriadTax.SetData(0, 4, "ض .مبيعات");
                    c1FlexGriadTax.SetData(0, 5, "ض .مشتريات");
                    c1FlexGriadTax.SetData(0, 9, "ح. المدين - نقدي");
                    c1FlexGriadTax.SetData(0, 10, "ح. الدائن - نقدي");
                    c1FlexGriadTax.SetData(0, 11, "إصدار قيد");
                    c1FlexGriadTax.SetData(0, 12, "+ الصافي");
                    c1FlexGriadTax.SetData(0, 13, "+ السطور");
                    c1FlexGriadTax.SetData(0, 14, "إجمالي السطر");
                    c1FlexGriadTax.SetData(0, 15, "صافي الفاتورة");
                    c1FlexGriadTax.SetData(0, 16, "ح. المدين - آجل");
                    c1FlexGriadTax.SetData(0, 17, "ح. الدائن - آجل");
                    c1FlexGriadTax.SetData(1, 1, "فاتورة مبيعات");
                    c1FlexGriadTax.SetData(1, 6, 1);
                    c1FlexGriadTax.SetData(1, 7, 0);
                    c1FlexGriadTax.SetData(2, 1, "فاتورة مشتريات");
                    c1FlexGriadTax.SetData(2, 6, 2);
                    c1FlexGriadTax.SetData(2, 7, 0);
                    c1FlexGriadTax.SetData(3, 1, "مرتجع مبيعات");
                    c1FlexGriadTax.SetData(3, 6, 3);
                    c1FlexGriadTax.SetData(3, 7, 0);
                    c1FlexGriadTax.SetData(4, 1, "مرتجع مشتريات");
                    c1FlexGriadTax.SetData(4, 6, 4);
                    c1FlexGriadTax.SetData(4, 7, 0);
                    c1FlexGriadTax.SetData(5, 1, "سند أدخال بضاعة");
                    c1FlexGriadTax.SetData(5, 6, 5);
                    c1FlexGriadTax.SetData(5, 7, 0);
                    c1FlexGriadTax.SetData(6, 1, "سند أخراج بضاعة");
                    c1FlexGriadTax.SetData(6, 6, 6);
                    c1FlexGriadTax.SetData(6, 7, 0);
                    c1FlexGriadTax.SetData(7, 1, "عرض سعر عملاء");
                    c1FlexGriadTax.SetData(7, 6, 7);
                    c1FlexGriadTax.SetData(7, 7, 0);
                    c1FlexGriadTax.SetData(8, 1, "عرض سعر مورد");
                    c1FlexGriadTax.SetData(8, 6, 8);
                    c1FlexGriadTax.SetData(8, 7, 0);
                    c1FlexGriadTax.SetData(9, 1, "طلب شراء");
                    c1FlexGriadTax.SetData(9, 6, 9);
                    c1FlexGriadTax.SetData(9, 7, 0);
                    c1FlexGriadTax.SetData(10, 1, "سند تسوية بضاعة");
                    c1FlexGriadTax.SetData(10, 6, 10);
                    c1FlexGriadTax.SetData(10, 7, 0);
                    c1FlexGriadTax.SetData(11, 1, "بضاعة اول المدة");
                    c1FlexGriadTax.SetData(11, 6, 14);
                    c1FlexGriadTax.SetData(11, 7, 0);
                    c1FlexGriadTax.SetData(12, 1, "أمر صرف بضاعة");
                    c1FlexGriadTax.SetData(12, 6, 17);
                    c1FlexGriadTax.SetData(12, 7, 0);
                    c1FlexGriadTax.SetData(13, 1, "مرتجع صرف بضاعة");
                    c1FlexGriadTax.SetData(13, 6, 20);
                    c1FlexGriadTax.SetData(13, 7, 0);
                    c1FlexGriadTax.SetData(14, 1, "الطلبات المحلية");
                    c1FlexGriadTax.SetData(14, 6, 21);
                    c1FlexGriadTax.SetData(14, 7, 0);
                    if (VarGeneral.SSSLev == "R" || VarGeneral.SSSLev == "C" || VarGeneral.SSSLev == "H")
                    {
                        c1FlexGriadTax.Rows[14].Visible = true;
                    }
                    else
                    {
                        c1FlexGriadTax.Rows[14].Visible = false;
                    }
                }
                catch
                {
                }
                return;
            }
            try
            {
                c1FlexGriadTax.SetData(0, 1, "Invoice");
                c1FlexGriadTax.SetData(0, 2, "Show");
                c1FlexGriadTax.SetData(0, 3, "Print");
                c1FlexGriadTax.SetData(0, 4, "Sale Tax");
                c1FlexGriadTax.SetData(0, 5, "Purch Tax");
                c1FlexGriadTax.SetData(0, 9, "Debit Acc Cash");
                c1FlexGriadTax.SetData(0, 10, "Credit Acc Cash");
                c1FlexGriadTax.SetData(0, 11, "Create Gaid");
                c1FlexGriadTax.SetData(0, 12, "+ Net");
                c1FlexGriadTax.SetData(0, 13, "+ Lines");
                c1FlexGriadTax.SetData(0, 14, "Line Total");
                c1FlexGriadTax.SetData(0, 15, "Invoice Net");
                c1FlexGriadTax.SetData(0, 16, "Debit Acc Cr");
                c1FlexGriadTax.SetData(0, 17, "Credit Acc Cr");
                c1FlexGriadTax.SetData(1, 1, "Sales Invoice");
                c1FlexGriadTax.SetData(1, 6, 1);
                c1FlexGriadTax.SetData(1, 7, 0);
                c1FlexGriadTax.SetData(2, 1, "Purchase Receipt");
                c1FlexGriadTax.SetData(2, 6, 2);
                c1FlexGriadTax.SetData(2, 7, 0);
                c1FlexGriadTax.SetData(3, 1, "Sales Return");
                c1FlexGriadTax.SetData(3, 6, 3);
                c1FlexGriadTax.SetData(3, 7, 0);
                c1FlexGriadTax.SetData(4, 1, "Purchase Return");
                c1FlexGriadTax.SetData(4, 6, 4);
                c1FlexGriadTax.SetData(4, 7, 0);
                c1FlexGriadTax.SetData(5, 1, "Transfer In");
                c1FlexGriadTax.SetData(5, 6, 5);
                c1FlexGriadTax.SetData(5, 7, 0);
                c1FlexGriadTax.SetData(6, 1, "Transfer Out");
                c1FlexGriadTax.SetData(6, 6, 6);
                c1FlexGriadTax.SetData(6, 7, 0);
                c1FlexGriadTax.SetData(7, 1, "Customer Qutation");
                c1FlexGriadTax.SetData(7, 6, 7);
                c1FlexGriadTax.SetData(7, 7, 0);
                c1FlexGriadTax.SetData(8, 1, "Supplier Qutation");
                c1FlexGriadTax.SetData(8, 6, 8);
                c1FlexGriadTax.SetData(8, 7, 0);
                c1FlexGriadTax.SetData(9, 1, "Purchase Order");
                c1FlexGriadTax.SetData(9, 6, 9);
                c1FlexGriadTax.SetData(9, 7, 0);
                c1FlexGriadTax.SetData(10, 1, "Stock Adjustment");
                c1FlexGriadTax.SetData(10, 6, 10);
                c1FlexGriadTax.SetData(10, 7, 0);
                c1FlexGriadTax.SetData(11, 1, "Open Quantities");
                c1FlexGriadTax.SetData(11, 6, 14);
                c1FlexGriadTax.SetData(11, 7, 0);
                c1FlexGriadTax.SetData(12, 1, "Payment Order");
                c1FlexGriadTax.SetData(12, 6, 17);
                c1FlexGriadTax.SetData(12, 7, 0);
                c1FlexGriadTax.SetData(13, 1, "Payment Order Return");
                c1FlexGriadTax.SetData(13, 6, 20);
                c1FlexGriadTax.SetData(13, 7, 0);
                c1FlexGriadTax.SetData(14, 1, "Local Orders");
                c1FlexGriadTax.SetData(14, 6, 21);
                c1FlexGriadTax.SetData(14, 7, 0);
                if (VarGeneral.SSSLev == "R" || VarGeneral.SSSLev == "C" || VarGeneral.SSSLev == "H")
                {
                    c1FlexGriadTax.Rows[14].Visible = true;
                }
                else
                {
                    c1FlexGriadTax.Rows[14].Visible = false;
                }
            }
            catch
            {
            }
        }
        private void BindDataTax()
        {
            try
            {
                State = FormState.Saved;
                ButWithSave.Enabled = false;
                for (int iiCnt = 1; iiCnt < c1FlexGriadTax.Rows.Count; iiCnt++)
                {
                    for (int i = 0; i < listInvSettingTax.Count; i++)
                    {
                        _InvSettingTax = listInvSettingTax[i];
                        if (_InvSettingTax.InvID == int.Parse(c1FlexGriadTax.GetData(iiCnt, 6).ToString()))
                        {
                            c1FlexGriadTax.SetData(iiCnt, 2, VarGeneral.TString.ChkStatShow(_InvSettingTax.TaxOptions, 0));
                            c1FlexGriadTax.SetData(iiCnt, 3, VarGeneral.TString.ChkStatShow(_InvSettingTax.TaxOptions, 1));
                            c1FlexGriadTax.SetData(iiCnt, 4, VarGeneral.TString.ChkStatShow(_InvSettingTax.TaxOptions, 2));
                            c1FlexGriadTax.SetData(iiCnt, 5, VarGeneral.TString.ChkStatShow(_InvSettingTax.TaxOptions, 3));
                            c1FlexGriadTax.SetData(iiCnt, 9, _InvSettingTax.TaxDebit);
                            c1FlexGriadTax.SetData(iiCnt, 10, _InvSettingTax.TaxCredit);
                            c1FlexGriadTax.SetData(iiCnt, 11, _InvSettingTax.autoTaxGaid);
                            c1FlexGriadTax.SetData(iiCnt, 12, VarGeneral.TString.ChkStatShow(_InvSettingTax.TaxOptions, 4));
                            c1FlexGriadTax.SetData(iiCnt, 13, VarGeneral.TString.ChkStatShow(_InvSettingTax.TaxOptions, 5));
                            c1FlexGriadTax.SetData(iiCnt, 14, VarGeneral.TString.ChkStatShow(_InvSettingTax.TaxOptions, 6));
                            c1FlexGriadTax.SetData(iiCnt, 15, VarGeneral.TString.ChkStatShow(_InvSettingTax.TaxOptions, 7));
                            c1FlexGriadTax.SetData(iiCnt, 16, _InvSettingTax.TaxDebitCredit);
                            c1FlexGriadTax.SetData(iiCnt, 17, _InvSettingTax.TaxCreditCredit);
                            break;
                        }
                    }
                }
                txtPurchaesTax.Value = _SysSettingTax.DefPurchaesTax.Value;
                txtSalesTax.Value = _SysSettingTax.DefSalesTax.Value;

                txtTaxNote.Text = _SysSettingTax.TaxNoteInv;
                txtTaxNote.Text = "السعر شامل الضريبه";

                if (!string.IsNullOrEmpty(_SysSettingTax.TaxAcc))
                {
                    txtTaxNo.Text = _SysSettingTax.TaxAcc;
                    txtTaxName.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(_SysSettingTax.TaxAcc.ToString()).Arb_Des : db.StockAccDefWithOutBalance(_SysSettingTax.TaxAcc.ToString()).Eng_Des);
                    txtTaxID.Text = db.StockAccDefWithOutBalance(_SysSettingTax.TaxAcc.ToString()).TaxNo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private T_InfoTb _InfotbTax = new T_InfoTb();
        private void RibunButtonsTax()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                ButWithSave.Text = "حفظ";
              // "F2";
                ButWithoutSave.Text = "خروج";
                // = "Esc";
                Text = "خيارات الضريبة";
            }
            else
            {
                ButWithSave.Text = "Save";
                ButWithoutSave.Text = "Exit";
              // "F2";
                // = "Esc";
                Text = "Taxes Options";
            }
        }
        private void c1FlexGrid1_CellChecked(object sender, RowColEventArgs e)
        {
        }
        private void txtSalesTax_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
        }
        private void txtPurchaesTax_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
        }
        private void ButGeneralSalesTax_Click(object sender, EventArgs e)
        {
            FrmGeneralTax frm = new FrmGeneralTax(0);
            frm.Tag = LangArEn;
            frm.txtSalesTax.Value = txtSalesTax.Value;
            frm.TopMost = true;
            frm.ShowDialog();
        }
        private void ButGeneralPurchaesTax_Click(object sender, EventArgs e)
        {
            FrmGeneralTax frm = new FrmGeneralTax(1);
            frm.Tag = LangArEn;
            frm.txtSalesTax.Value = txtPurchaesTax.Value;
            frm.TopMost = true;
            frm.ShowDialog();
        }
        private void c1FlexGrid1Tax_DoubleClick(object sender, EventArgs e)
        {
            if ((c1FlexGriadTax.Col != 9 && c1FlexGriadTax.Col != 10 && c1FlexGriadTax.Col != 16 && c1FlexGriadTax.Col != 17) || c1FlexGriadTax.Row <= 0)
            {
                return;
            }
            columns_Names_visibleTax.Clear();
            columns_Names_visibleTax.Add("AccDef_No", new ColumnDictinaryTax("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visibleTax.Add("Arb_Des", new ColumnDictinaryTax("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visibleTax.Add("Eng_Des", new ColumnDictinaryTax("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visibleTax.Add("AccDef_ID", new ColumnDictinaryTax(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visibleTax.Add("Mobile", new ColumnDictinaryTax("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinaryTax>> animalsAsCollection = columns_Names_visibleTax;
            foreach (KeyValuePair<string, ColumnDictinaryTax> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    c1FlexGriadTax.SetData(c1FlexGriadTax.Row, c1FlexGriadTax.Col, _AccDef.AccDef_No.ToString());
                }
                else
                {
                    c1FlexGriadTax.SetData(c1FlexGriadTax.Row, c1FlexGriadTax.Col, "***");
                }
            }
            catch
            {
                c1FlexGriadTax.SetData(c1FlexGriadTax.Row, c1FlexGriadTax.Col, "***");
            }
            VarGeneral.Flush();
        }
        public class ColumnDictinaryTax
        {
            public string AText = string.Empty;
            public string EText = string.Empty;
            public bool IfDefault = false;
            public string Format = string.Empty;
            public ColumnDictinaryTax(string aText, string eText, bool ifDefault, string format)
            {
                AText = aText;
                EText = eText;
                IfDefault = ifDefault;
                Format = format;
            }
        }
        private void button_SrchTaxNo_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            columns_Names_visibleTax.Clear();
            columns_Names_visibleTax.Add("AccDef_No", new ColumnDictinaryTax("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visibleTax.Add("Arb_Des", new ColumnDictinaryTax("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visibleTax.Add("Eng_Des", new ColumnDictinaryTax("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visibleTax.Add("AccDef_ID", new ColumnDictinaryTax(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visibleTax.Add("Mobile", new ColumnDictinaryTax("الجوال", "Mobile", ifDefault: false, string.Empty));
            columns_Names_visibleTax.Add("TaxNo", new ColumnDictinaryTax("الرقم الضريبي", "Tax No", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinaryTax>> animalsAsCollection = columns_Names_visibleTax;
            foreach (KeyValuePair<string, ColumnDictinaryTax> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                txtTaxNo.Text = _AccDef.AccDef_No.ToString();
                txtTaxName.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(txtTaxNo.Text).Arb_Des : db.StockAccDefWithOutBalance(txtTaxNo.Text).Eng_Des);
                txtTaxID.Text = db.StockAccDefWithOutBalance(txtTaxNo.Text).TaxNo;
            }
            else
            {
                txtTaxNo.Text = string.Empty;
                txtTaxName.Text = string.Empty;
                txtTaxID.Text = string.Empty;
            }
        }
        private void txtTaxNote_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
        }
        private void SaveDataTax()
        {
            try
            {
                for (int iiCnt = 1; iiCnt < c1FlexGriadTax.Rows.Count; iiCnt++)
                {
                    for (int i = 0; i < listInvSettingTax.Count; i++)
                    {
                        _InvSettingTax = listInvSettingTax[i];
                        if (_InvSettingTax.InvID == int.Parse(c1FlexGriadTax.GetData(iiCnt, 6).ToString()))
                        {
                            _InvSettingTax.TaxOptions = VarGeneral.TString.ChkStatSave((bool)c1FlexGriadTax.GetData(iiCnt, 2)) + VarGeneral.TString.ChkStatSave((bool)c1FlexGriadTax.GetData(iiCnt, 3)) + VarGeneral.TString.ChkStatSave((bool)c1FlexGriadTax.GetData(iiCnt, 4)) + VarGeneral.TString.ChkStatSave((bool)c1FlexGriadTax.GetData(iiCnt, 5)) + VarGeneral.TString.ChkStatSave((bool)c1FlexGriadTax.GetData(iiCnt, 12)) + VarGeneral.TString.ChkStatSave((bool)c1FlexGriadTax.GetData(iiCnt, 13)) + VarGeneral.TString.ChkStatSave((bool)c1FlexGriadTax.GetData(iiCnt, 14)) + VarGeneral.TString.ChkStatSave((bool)c1FlexGriadTax.GetData(iiCnt, 15));
                            try
                            {
                                _InvSettingTax.TaxDebit = c1FlexGriadTax.GetData(iiCnt, 9).ToString();
                            }
                            catch
                            {
                                _InvSettingTax.TaxDebit = "***";
                            }
                            try
                            {
                                _InvSettingTax.TaxCredit = c1FlexGriadTax.GetData(iiCnt, 10).ToString();
                            }
                            catch
                            {
                                _InvSettingTax.TaxCredit = "***";
                            }
                            try
                            {
                                _InvSettingTax.TaxDebitCredit = c1FlexGriadTax.GetData(iiCnt, 16).ToString();
                            }
                            catch
                            {
                                _InvSettingTax.TaxDebitCredit = "***";
                            }
                            try
                            {
                                _InvSettingTax.TaxCreditCredit = c1FlexGriadTax.GetData(iiCnt, 17).ToString();
                            }
                            catch
                            {
                                _InvSettingTax.TaxCreditCredit = "***";
                            }
                            _InvSettingTax.autoTaxGaid = Convert.ToBoolean(c1FlexGriadTax.GetData(iiCnt, 11));
                            db.Log = VarGeneral.DebugLog;
                            db.SubmitChanges(ConflictMode.ContinueOnConflict);
                            break;
                        }
                    }
                }
                db.ExecuteCommand("update T_SYSSETTING set DefSalesTax = " + txtSalesTax.Value);
                db.ExecuteCommand("update T_SYSSETTING set DefPurchaesTax = " + txtPurchaesTax.Value);
                db.ExecuteCommand("update T_SYSSETTING set TaxAcc = '" + txtTaxNo.Text + "'");
                db.ExecuteCommand("update T_SYSSETTING set TaxNoteInv = '" + txtTaxNote.Text + "'");
           //     using (Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS))
                {
                    VarGeneral.Settings_Sys = new T_SYSSETTING();
                    VarGeneral.Settings_Sys = db.SystemSettingStock();
                    VarGeneral._SysDirPath = VarGeneral.Settings_Sys.SysDir;
                    VarGeneral._BackPath = VarGeneral.Settings_Sys.BackPath;
                    try
                    {
                        VarGeneral._AutoSync = VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 41);
                    }
                    catch
                    {
                        VarGeneral._AutoSync = false;
                    }
                }
                //MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Close();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Save:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void FrmTaxOpiton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && ButWithSave.Enabled && ButWithSave.Visible)
            {
                ButWithSave_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void FrmTaxOpiton_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void label3Tax_Click(object sender, EventArgs e)
        {
        }
        void load()
        {
            ButGeneralPurchaesTax.Click += new System.EventHandler(ButGeneralPurchaesTax_Click);
            ButGeneralSalesTax.Click += new System.EventHandler(ButGeneralSalesTax_Click);
            button_SrchTaxNo.Click += new System.EventHandler(button_SrchTaxNo_Click);
            txtTaxNote.Click += new System.EventHandler(txtTaxNote_Click);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(FrmTaxOpiton_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(FrmTaxOpiton_KeyDown);
            txtPurchaesTax.Click += new System.EventHandler(txtPurchaesTax_Click);
            txtSalesTax.Click += new System.EventHandler(txtSalesTax_Click);
            //ButWithSave.Click += new System.EventHandler(ButWithSave_Click);
            //ButWithoutSave.Click += new System.EventHandler(ButExit_Click);
            // c1FlexGriadTax.CellChecked += new C1.Win.C1FlexGrid.RowColEventHandler(c1FlexGrid1_CellChecked);
            //   c1FlexGriadTax.Click += new System.EventHandler(c1FlexGrid1_Click);
            // c1FlexGriadTax.DoubleClick += new System.EventHandler(c1FlexGrid1_DoubleClick);
            try
            {
                //try
                //{
                // //   ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmTaxOpiton));
                //    if (VarGeneral.CurrentLang.ToString() == "0" ||VarGeneral.CurrentLang.ToString() == "")
                //    {
                //        Language.ChangeLanguage("ar-SA", this, resources);
                //        LangArEn = 0;
                //    }
                //    else
                //    {
                //        Language.ChangeLanguage("en", this, resources);
                //        LangArEn = 1;
                //    }
                //}
                //catch
                //{
                //}
                //RibunButtonsTax();
                listInvSettingTax = db.StockInvSettingList(VarGeneral.UserID);
                _InvSettingTax = listInvSettingTax[0];
                _SysSettingTax = db.SystemSettingStock();
                listCompanyTax = db.StockCompanyList();
                _CompanyTax = listCompanyTax[0];
                _GdAutoTax = db.GdAutoStock();
                listInfotbTax = db.StockInfoList();
                _InfotbTax = listInfotbTax[0];
                listAccDefTax = db.FillAccDef_2(string.Empty).ToList();
                listAccDefTax = listAccDefTax.Where((T_AccDef q) => q.Trn == 3 && q.Lev == 4 && q.AccDef_No.StartsWith("1") && q.AccCat != 2 && q.AccCat != 3).ToList();
                try
                {
                    FillComboTax();
                }
                catch
                {
                }
                try
                {
                    BindDataTax();
                }
                catch
                {
                }
                if (VarGeneral.SSSTyp == 0)
                {
                    c1FlexGriadTax.Cols[11].Visible = false;
                    c1FlexGriadTax.Cols[16].Visible = false;
                    c1FlexGriadTax.Cols[17].Visible = false;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void checkBox_BalanceActivated_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_BalanceActivated.Checked)
            {
                groupBox7.Enabled = true;
            }
            else
            {
                groupBox7.Enabled = false;
            }
        }

        void LoadBalance()
        {
            // this.labelHeader.Click += new System.EventHandler(this.labelHeader_Click);
            this.checkBox_BalanceActivated.CheckedChanged += new System.EventHandler(this.checkBox_BalanceActivated_CheckedChanged);
            checkBox_BalanceActivated.Click += Button_Edit_Click;
            RedButWight.Click += Button_Edit_Click;
            RedButPrice.Click += Button_Edit_Click;
            RedButWightPrice.Click += Button_Edit_Click;
            txtWightFrom.Click += Button_Edit_Click;
            txtWightTo.Click += Button_Edit_Click;
            txtPriceFrom.Click += Button_Edit_Click;
            txtPriceTo.Click += Button_Edit_Click;
            txtBarcodFrom.Click += Button_Edit_Click;
            txtBarcodTo.Click += Button_Edit_Click;
            txtWieghtQ.Click += Button_Edit_Click;
            txtPriceQ.Click += Button_Edit_Click;
            try
            {
                //ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmBalance));
                //if (VarGeneral.CurrentLang.ToString() == "0"||VarGeneral.CurrentLang.ToString() == "")
                //{
                //    Language.ChangeLanguage("ar-SA", this, resources);
                //    LangArEn = 0;
                //}
                //else
                //{
                //    Language.ChangeLanguage("en", this, resources);
                //    LangArEn = 1;
                //}
                //RibunButtonsBalance();
                _SysSettingBalance = db.SystemSettingStock();
                try
                {
                    BindDataBalance();
                }
                catch
                {
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("FrmBalance_Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void RibunButtonsBalance()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                ButWithSave.Text = "حفظ";
                //	ButWithSave.Tooltip = "F2";
                ButWithoutSave.Text = "خروج";
                //// = "Esc";
                //    labelHeader.Text = "إعدادات الميزان الباركود";
            }
            else
            {
                ButWithSave.Text = "Save";
                ButWithoutSave.Text = "Exit";
                //ButWithSave.Tooltip = "F2";
                //// = "Esc";
                //  labelHeader.Text = "Balance Setting";
            }
        }

        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private List<T_INVSETTING> listInvSetting = new List<T_INVSETTING>();
        private T_INVSETTING _InvSetting = new T_INVSETTING();
        private List<T_SYSSETTING> listSysSetting = new List<T_SYSSETTING>();
        private T_SYSSETTING _SysSetting = new T_SYSSETTING();
        private List<T_AccDef> listAccDef = new List<T_AccDef>();
        private T_AccDef _AccDef = new T_AccDef();
        private List<T_Company> listCompany = new List<T_Company>();
        private T_Company _Company = new T_Company();
        private List<T_GdAuto> listGdAuto = new List<T_GdAuto>();
        private T_GdAuto _GdAuto = new T_GdAuto();
        private List<T_InfoTb> listInfotb = new List<T_InfoTb>();
        private T_InfoTb _Infotb = new T_InfoTb();
        private int LangArEn = 0;
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
        // private IContainer components = null;

        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private List<T_Room> listTableFamily = new List<T_Room>();
        private T_Room _TableFamily = new T_Room();
        private List<T_Room> listTableBoys = new List<T_Room>();
        private T_Room _TableBoys = new T_Room();
        private List<T_Room> listTableOut = new List<T_Room>();
        private T_Room _TableOut = new T_Room();
        private List<T_Room> listTableOther = new List<T_Room>();
        private T_Room _TableOther = new T_Room();
      //  private int optionflag;
        public static int optionflag = 0;
        public static List<int> nn = new List<int>();
        private OpenFileDialog openFileDialog1;
        private void txtAct_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(null, null);
        }
        private void Script_InvitationCards()
        {
            chk46.Enabled = false;
            label51.Visible = false;
            CmbPointImages.Visible = false;
            //button_TaxOption.Visible = false;
            //button_CommOption.Visible = false;
            expandablePanel_NewColumn.Visible = false;
            //label8.Visible = false;
         //   CmbCost.Visible = false;
            //chk53.Enabled = false;
            //chk54.Enabled = false;
            //chk55.Enabled = false;
            //chk56.Enabled = false;
            //chk57.Enabled = false;
            chk58.Enabled = false;
            //chk59.Enabled = false;
            //chk60.Enabled = false;
            //chk61.Enabled = false;
            //chk52.Enabled = false;
            //chk51.Enabled = false;
            //chk21.Enabled = false;
            //chk31.Enabled = false;
            //chk6.Enabled = false;
            //chk5.Enabled = false;
            //chk4.Enabled = false;
            //chk16.Enabled = false;
            //chk11.Enabled = false;
            //chk12.Enabled = false;
            //chk20.Enabled = false;
            //chk48.Enabled = false;
            //chk47.Enabled = false;
            //chk18.Enabled = false;
            //chk14.Enabled = false;
            //chk10.Enabled = false;
            //chk23.Enabled = false;
            //chk22.Enabled = false;
            for (int i = 4; i < c1FlexGrid1.Rows.Count; i++)
            {
                c1FlexGrid1.Rows[i].Visible = false;
            }
        }

        private void XtraForm1_SizeChanged(object sender, EventArgs e)
        {
            netResize1.Refresh();
        }

        private void ButWithSave_ItemClick(object sender, TileItemEventArgs e)
        {
            ButWithSave_Click(null, null);
        }

        private void ButWithoutSave_ItemClick(object sender, TileItemEventArgs e)
        {
            Close();
        }

        private void CmbCalendar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_EnterImg_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox_BackupPath_ButtonCustomClick_1(object sender, EventArgs e)
        {

        }
    }
}