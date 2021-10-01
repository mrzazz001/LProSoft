using C1.Win.C1FlexGrid;
using Framework.Data;
using ProShared.GeneralM;
using ProShared.Stock_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvAcc.Forms 
{
  partial  class FrmInvPuchaes
    {
        private void GlassSR_Load(object sender, EventArgs e)
        {
            this.FlxInv.RowValidated += new C1.Win.C1FlexGrid.RowColEventHandler(this.GFlxInv_RowValidated);
            this.FlxInv.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.GFlxInv_AfterRowColChange);
            xGmesures1.Visible = true;
            this.FlxInv.CellChanged += cellcontent_change;
            int i = FlxInv.Cols.Count - 1;
            FlxInv.Cols.Add(10);

            FlxInv.Cols[i].Name = "RSPH";
            FlxInv.Cols[i].Caption = "RSPH";
            FlxInv.Cols[i++].Visible = false;

            FlxInv.Cols[i].Name = "RCYL";

            FlxInv.Cols[i].Caption = "RCYL";
            FlxInv.Cols[i++].Visible = false;
            FlxInv.Cols[i].Name = "RAXIS";

            FlxInv.Cols[i].Caption = "RAXIS";
            FlxInv.Cols[i++].Visible = false;
            FlxInv.Cols[i].Name = "RADD";

            FlxInv.Cols[i].Caption = "RADD";
            FlxInv.Cols[i++].Visible = false;
            FlxInv.Cols[i].Name = "RIPD";

            FlxInv.Cols[i].Caption = "RIPD";
            FlxInv.Cols[i++].Visible = false;
            FlxInv.Cols[i].Name = "LSPH";

            FlxInv.Cols[i].Caption = "LSPH";
            FlxInv.Cols[i++].Visible = false;
            FlxInv.Cols[i].Name = "LCYL";

            FlxInv.Cols[i].Caption = "LCYL";
            FlxInv.Cols[i++].Visible = false;
            FlxInv.Cols[i].Name = "LAXIS";

            FlxInv.Cols[i].Caption = "LAXIS";
            FlxInv.Cols[i++].Visible = false;
            FlxInv.Cols[i].Name = "LADD";

            FlxInv.Cols[i].Caption = "LADD";
            FlxInv.Cols[i++].Visible = false;
            
            FlxInv.Cols[i].Name = "LIPD";

            FlxInv.Cols[i].Caption = "LIPD";
            FlxInv.Cols[i++].Visible = false;
            xGmesures1.Leave += Leav_XGmeSures1;

        }

        private void Leav_XGmeSures1(object sender, EventArgs e)
        {
            FlxInv.Focus();
            GFlxInv_RowValidated(FlxInv, new RowColEventArgs(FlxInv.Row, 0));
        }

        private void cellcontent_change(object sender, RowColEventArgs e)
        {
            if (e.Col == 2)
            {
                setextransversionfields(e.Row);
            }
        }

        public void addDetParameters(IDatabase dbLines, int iiCnt)
        {

            dbLines.AddParameter("RSph", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, "RSPH")))));
            dbLines.AddParameter("RCyl", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, "RCYL")))));
            dbLines.AddParameter("RAxis", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, "RAXIS")))));
            dbLines.AddParameter("RAdd_", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, "RADD")))));
            dbLines.AddParameter("RIPD", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, "RIPD")))));
            dbLines.AddParameter("LSph", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, "LSPH")))));
            dbLines.AddParameter("LCyl", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, "LCYL")))));
            dbLines.AddParameter("LAxis", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, "LAXIS")))));
            dbLines.AddParameter("LAdd_", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, "LADD")))));
            dbLines.AddParameter("LIPD", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, "LIPD")))));
            dbLines.AddParameter("RLOption", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, "LIPD")))));
            dbLines.AddParameter("LLOption", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, "LIPD")))));

        }
        string Version = "GSR";
        private void GFlxInv_AfterRowColChange(object sender, RangeEventArgs e)
        {
            if (e.OldRange.r1 != e.NewRange.r1)
            {
                superTabControl_Info.SelectedTabIndex = 0;
                FlxInv.Focus();
                try
                {

                    setextransversionfields(e.NewRange.r1);

                }
                catch { }
            }

        }
        void setextransversionfields(int r)
        {
            if (FlxInv.GetData(r, 1) != null)
            {
                if (FlxInv.GetData(r, 1).ToString() != "")
                {
                    T_INVDET t = new T_INVDET();

                    try
                    {
                        t.RSph = double.Parse(FlxInv.GetData(r, "RSPH").ToString());

                    }
                    catch
                    { }
                    try
                    {
                        t.RCyl = double.Parse(FlxInv.GetData(r, "RCYL").ToString());

                    }
                    catch
                    { }
                    try
                    {
                        t.RAxis = double.Parse(FlxInv.GetData(r, "RAXIS").ToString());

                    }
                    catch
                    { }
                    try
                    {
                        t.RAdd_ = double.Parse(FlxInv.GetData(r, "RADD").ToString());

                    }
                    catch
                    { }
                    try
                    {
                        t.RIPD = double.Parse(FlxInv.GetData(r, "RPID").ToString());

                    }
                    catch
                    { }
                    try
                    {
                        t.LSph = double.Parse(FlxInv.GetData(r, "LSPH").ToString());

                    }
                    catch
                    { }
                    try
                    {
                        t.LCyl = double.Parse(FlxInv.GetData(r, "LCYL").ToString());

                    }
                    catch
                    { }
                    try
                    {
                        t.LAxis = double.Parse(FlxInv.GetData(r, "LAXIS").ToString());
                    }
                    catch
                    { }
                    try
                    {
                        t.LAdd_ = double.Parse(FlxInv.GetData(r, "LADD").ToString());

                    }
                    catch
                    { }
                    try
                    {
                        t.LIPD = double.Parse(FlxInv.GetData(r, "LPID").ToString());
                    }
                    catch
                    { }
                    try
                    {
                        t.ItmDes = (FlxInv.GetData(r, 2).ToString());
                    }
                    catch
                    { }

                    try
                    {
                        xGmesures1.setvalues(t);
                    }
                    catch { }
                }
                else
                    xGmesures1.clear();

            }
            else
                xGmesures1.clear();

        }
        private void GFlxInv_RowValidated(object sender, RowColEventArgs e)
        {
            if (Version == "GSR")
            {
                T_INVDET t = new
                       T_INVDET();
                xGmesures1.getValues(t);
                try
                {

                    FlxInv.SetData(e.Row, "RSPH", t.RSph.GetValueOrDefault());

                    FlxInv.SetData(e.Row, "RCYL", t.RCyl.GetValueOrDefault());

                    FlxInv.SetData(e.Row, "RAXIS", t.RAxis.GetValueOrDefault());
                    FlxInv.SetData(e.Row, "RADD", t.RAdd_.GetValueOrDefault());
                    FlxInv.SetData(e.Row, "RIPD", t.RIPD.GetValueOrDefault());

                    FlxInv.SetData(e.Row, "LSPH", t.LSph.GetValueOrDefault());

                    FlxInv.SetData(e.Row, "LCYL", t.LCyl.GetValueOrDefault()); ;

                    FlxInv.SetData(e.Row, "LAXIS", t.LAxis.GetValueOrDefault());
                    FlxInv.SetData(e.Row, "LADD", t.LAdd_.GetValueOrDefault());
                    FlxInv.SetData(e.Row, "LIPD", t.LIPD.GetValueOrDefault()); ;
                }
                catch
                {
                }

            }
        }

    }
}
