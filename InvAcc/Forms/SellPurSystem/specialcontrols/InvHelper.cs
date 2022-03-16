using Framework.Data;
using ProShared.GeneralM;
using ProShared.Stock_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
 
using System.Linq;
using System.Collections.Generic;
using ProShared;

namespace InvAcc.Forms.SellPurSystem.specialcontrols
{
    class InvHelper
    {
        public  static bool Add_Cridte_Recorde(T_INVHED inv)
        {


            // List<  T_GDHEAD> list=VarGeneral.dbshared
            List < T_GDHEAD > list = VarGeneral.dbshared.StockGdHeadid((int)inv.GadeId.Value);
            return true;

        }

        public static bool Add_Depite_Recorde(T_INVHED inv)
        {

            return true;
        }
        public static int INVHED_INSERT( T_INVHED data_this)
        {
            IDatabase dbHead = Database.GetDatabase(VarGeneral.BranchCS);
            dbHead.ClearParameters();

            string ss = Utilites.GetInvSetring(data_this);
            data_this.Hash_Value = Utilites.HashEncrypt(ss);
            dbHead.AddOutParameter("InvHed_ID", DbType.Int32);
            dbHead.AddParameter("InvId", DbType.Double, data_this.InvId);
            dbHead.AddParameter("InvNo", DbType.String, data_this.InvNo);
            dbHead.AddParameter("InvTyp", DbType.Int32, data_this.InvTyp);
            dbHead.AddParameter("InvCashPay", DbType.Int32, data_this.InvCashPay);
            dbHead.AddParameter("CusVenNo", DbType.String, data_this.CusVenNo);
            dbHead.AddParameter("CusVenNm", DbType.String, data_this.CusVenNm);
            dbHead.AddParameter("CusVenAdd", DbType.String, data_this.CusVenAdd);
            dbHead.AddParameter("CusVenTel", DbType.String, data_this.CusVenTel);
            dbHead.AddParameter("Remark", DbType.String, data_this.Remark);
            dbHead.AddParameter("HDat", DbType.String, data_this.HDat);
            dbHead.AddParameter("GDat", DbType.String, data_this.GDat);
            dbHead.AddParameter("MndNo", DbType.Int32, data_this.MndNo);
            dbHead.AddParameter("SalsManNo", DbType.String, data_this.SalsManNo);
            dbHead.AddParameter("SalsManNam", DbType.String, data_this.SalsManNam);
            dbHead.AddParameter("InvTot", DbType.Double, data_this.InvTot);
            dbHead.AddParameter("InvTotLocCur", DbType.Double, data_this.InvTotLocCur);
            dbHead.AddParameter("InvDisPrs", DbType.Double, data_this.InvDisPrs);
            dbHead.AddParameter("InvDisVal", DbType.Double, data_this.InvDisVal);
            dbHead.AddParameter("CusVenMob", DbType.String, data_this.CusVenMob);
            dbHead.AddParameter("PriceIncludeTax", DbType.Boolean, data_this.PriceIncludTax);
            dbHead.AddParameter("InvDisValLocCur", DbType.Double, data_this.InvDisValLocCur);
            dbHead.AddParameter("InvNet", DbType.Double, data_this.InvNet);
            dbHead.AddParameter("InvNetLocCur", DbType.Double, data_this.InvNetLocCur);
            dbHead.AddParameter("CashPay", DbType.Double, data_this.CashPay);
            dbHead.AddParameter("CashPayLocCur", DbType.Double, data_this.CashPayLocCur);
            dbHead.AddParameter("IfRet", DbType.Int32, data_this.IfRet);
            dbHead.AddParameter("GadeNo", DbType.Double, data_this.GadeNo);
            dbHead.AddParameter("GadeId", DbType.Double, data_this.GadeId);
            dbHead.AddParameter("IfDel", DbType.Int32, data_this.IfDel);
            dbHead.AddParameter("RetNo", DbType.String, data_this.RetNo);
            dbHead.AddParameter("RetId", DbType.Double, data_this.RetId);
            dbHead.AddParameter("InvCstNo", DbType.Int32, data_this.InvCstNo);
            dbHead.AddParameter("InvCashPayNm", DbType.String, data_this.InvCashPayNm);
            dbHead.AddParameter("RefNo", DbType.String, data_this.RefNo);
            dbHead.AddParameter("InvCost", DbType.Int32, data_this.InvCost);
            dbHead.AddParameter("EstDat", DbType.String, data_this.EstDat);
            dbHead.AddParameter("CustPri", DbType.Int32, data_this.CustPri);
            dbHead.AddParameter("ArbTaf", DbType.String, data_this.ArbTaf);
            dbHead.AddParameter("CurTyp", DbType.Int32, data_this.CurTyp);
            dbHead.AddParameter("InvCash", DbType.String, data_this.InvCash);
            dbHead.AddParameter("ToStore", DbType.String, data_this.ToStore);
            dbHead.AddParameter("ToStoreNm", DbType.String, data_this.ToStoreNm);
            dbHead.AddParameter("InvQty", DbType.Double, data_this.InvQty);
            dbHead.AddParameter("EngTaf", DbType.String, data_this.EngTaf);
            dbHead.AddParameter("IfTrans", DbType.Int32, data_this.IfTrans);
            dbHead.AddParameter("CustRep", DbType.Double, data_this.CustRep);
            dbHead.AddParameter("CustNet", DbType.Double, data_this.CustNet);
            dbHead.AddParameter("InvWight_T", DbType.Double, data_this.InvWight_T);
            dbHead.AddParameter("IfPrint", DbType.Int32, data_this.IfPrint);
            dbHead.AddParameter("LTim", DbType.String, data_this.LTim);
            dbHead.AddParameter("CREATED_BY", DbType.String, data_this.CREATED_BY);
            dbHead.AddParameter("DATE_CREATED", DbType.DateTime, data_this.DATE_CREATED);
            dbHead.AddParameter("MODIFIED_BY", DbType.String, data_this.MODIFIED_BY);
            dbHead.AddParameter("DATE_MODIFIED", DbType.DateTime, data_this.DATE_MODIFIED);
            dbHead.AddParameter("CreditPay", DbType.Double, data_this.CreditPay);
            dbHead.AddParameter("CreditPayLocCur", DbType.Double, data_this.CreditPayLocCur);
            dbHead.AddParameter("NetworkPay", DbType.Double, data_this.NetworkPay);
            dbHead.AddParameter("NetworkPayLocCur", DbType.Double, data_this.NetworkPayLocCur);
            dbHead.AddParameter("CommMnd_Inv", DbType.Double, data_this.CommMnd_Inv);
            dbHead.AddParameter("MndExtrnal", DbType.Boolean, data_this.MndExtrnal);
            dbHead.AddParameter("CompanyID", DbType.Int32, data_this.CompanyID);
            dbHead.AddParameter("InvAddCost", DbType.Double, data_this.InvAddCost);
            dbHead.AddParameter("InvAddCostLoc", DbType.Double, data_this.InvAddCostLoc);
            dbHead.AddParameter("InvAddCostExtrnal", DbType.Double, data_this.InvAddCostExtrnal);
            dbHead.AddParameter("InvAddCostExtrnalLoc", DbType.Double, data_this.InvAddCostExtrnalLoc);
            dbHead.AddParameter("IsExtrnalGaid", DbType.Boolean, data_this.IsExtrnalGaid);
            dbHead.AddParameter("ExtrnalCostGaidID", DbType.Double, data_this.ExtrnalCostGaidID);
            dbHead.AddParameter("Puyaid", DbType.Double, data_this.Puyaid);
            dbHead.AddParameter("Remming", DbType.Double, data_this.Remming);
            dbHead.AddParameter("RoomNo", DbType.Int32, data_this.RoomNo);
            dbHead.AddParameter("OrderTyp", DbType.Int32, data_this.OrderTyp);
            dbHead.AddParameter("RoomSts", DbType.Boolean, data_this.RoomSts);
            dbHead.AddParameter("chauffeurNo", DbType.Int32, data_this.chauffeurNo);
            dbHead.AddParameter("RoomPerson", DbType.Int32, data_this.RoomPerson);
            dbHead.AddParameter("ServiceValue", DbType.Double, data_this.ServiceValue);
            dbHead.AddParameter("Sts", DbType.Boolean, data_this.Sts);
            dbHead.AddParameter("PaymentOrderTyp", DbType.Int32, data_this.PaymentOrderTyp);
            dbHead.AddParameter("AdminLock", DbType.Boolean, data_this.AdminLock);
            dbHead.AddParameter("DeleteDate", DbType.String, data_this.DeleteDate);
            dbHead.AddParameter("DeleteTime", DbType.String, data_this.DeleteTime);
            dbHead.AddParameter("UserNew", DbType.String, data_this.UserNew);
            dbHead.AddParameter("IfEnter", DbType.Int32, data_this.IfEnter);
            dbHead.AddParameter("InvAddTax", DbType.Double, data_this.InvAddTax);
            dbHead.AddParameter("InvAddTaxlLoc", DbType.Double, data_this.InvAddTaxlLoc);
            dbHead.AddParameter("IsTaxGaid", DbType.Boolean, data_this.IsTaxGaid);
            dbHead.AddParameter("TaxGaidID", DbType.Double, data_this.TaxGaidID);
            dbHead.AddParameter("IsTaxUse", DbType.Boolean, data_this.IsTaxUse);
            dbHead.AddParameter("InvValGaidDis", DbType.Double, data_this.InvValGaidDis);
            dbHead.AddParameter("InvValGaidDislLoc", DbType.Double, data_this.InvValGaidDislLoc);
            dbHead.AddParameter("IsDisGaid", DbType.Boolean, data_this.IsDisGaid);
            dbHead.AddParameter("DisGaidID1", DbType.Double, data_this.DisGaidID1);
            dbHead.AddParameter("IsDisUse1", DbType.Boolean, data_this.IsDisUse1);
            dbHead.AddParameter("InvComm", DbType.Double, data_this.InvComm);
            dbHead.AddParameter("InvCommLoc", DbType.Double, data_this.InvCommLoc);
            dbHead.AddParameter("IsCommGaid", DbType.Boolean, data_this.IsCommGaid);
            dbHead.AddParameter("CommGaidID", DbType.Double, data_this.CommGaidID);
            dbHead.AddParameter("IsCommUse", DbType.Boolean, data_this.IsCommUse);
            dbHead.AddParameter("IsTaxLines", DbType.Boolean, data_this.IsTaxLines);
            dbHead.AddParameter("IsTaxByTotal", DbType.Boolean, data_this.IsTaxByTotal);
            dbHead.AddParameter("IsTaxByNet", DbType.Boolean, data_this.IsTaxByNet);
            dbHead.AddParameter("TaxByNetValue", DbType.Double, data_this.TaxByNetValue);
            dbHead.AddParameter("DesPointsValue", DbType.Double, data_this.DesPointsValue);
            dbHead.AddParameter("DesPointsValueLocCur", DbType.Double, data_this.DesPointsValueLocCur);
            dbHead.AddParameter("PointsCount", DbType.Double, data_this.PointsCount);
            dbHead.AddParameter("IsPoints", DbType.Boolean, data_this.IsPoints);
            dbHead.AddParameter("tailor20", DbType.String, data_this.tailor20);
            dbHead.AddParameter("CINVType", DbType.Int32, data_this.CInvType);
            dbHead.AddParameter("CusVenTaxNo", DbType.String, data_this.CusVenTaxNo);
            dbHead.AddParameter("IS_ServiceBill", DbType.Boolean, data_this.IS_ServiceBill);
            dbHead.AddParameter("Hash_Value", DbType.String, data_this.Hash_Value);
            dbHead.AddParameter("CusVenCRN", DbType.String, data_this.CusVenCRN);
            dbHead.ExecuteNonQuery(storedProcedure: true, "S_T_INVHED_INSERT");
           return   int.Parse(dbHead.GetParameterValue("InvHed_ID").ToString());
        }
        public static void INVDET_INSERT(T_INVDET data_this)
        {
            IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
            db_.ClearParameters();
            db_.AddParameter("InvDet_ID", DbType.Int32, data_this.InvDet_ID);
            db_.AddParameter("InvNo", DbType.String, data_this.InvNo);
            db_.AddParameter("InvId", DbType.Int32, data_this.InvId);
            db_.AddParameter("InvSer", DbType.Int32, data_this.InvSer);
            db_.AddParameter("ItmNo", DbType.String, string.Concat(data_this.ItmNo));
            db_.AddParameter("Cost", DbType.Double, data_this.Cost);
            db_.AddParameter("Qty", DbType.Double, data_this.Qty);
            db_.AddParameter("ItmDes", DbType.String, data_this.ItmDes);
            db_.AddParameter("ItmUnt", DbType.String, data_this.ItmUnt);
            db_.AddParameter("ItmDesE", DbType.String, data_this.ItmDesE);
            db_.AddParameter("ItmUntE", DbType.String, data_this.ItmUntE);
            db_.AddParameter("ItmUntPak", DbType.Double, data_this.ItmUntPak);
            db_.AddParameter("StoreNo", DbType.Int32, data_this.StoreNo);
            db_.AddParameter("Price", DbType.Double, data_this.Price);
            db_.AddParameter("Amount", DbType.Double, data_this.Amount);
            db_.AddParameter("RealQty", DbType.Double, data_this.RealQty);
            db_.AddParameter("itmInvDsc", DbType.Double, data_this.itmInvDsc);
            db_.AddParameter("CInvType", DbType.Double, data_this.CInvType);
            db_.AddParameter("DatExper", DbType.String, data_this.DatExper);
            db_.AddParameter("ItmDis", DbType.Double, data_this.ItmDis);
            db_.AddParameter("ItmAddCost", DbType.Double, data_this.ItmAddCost);
            db_.AddParameter("ItmTyp", DbType.Int32, data_this.ItmTyp);
            db_.AddParameter("ItmIndex", DbType.Int32, data_this.ItmIndex);
            db_.AddParameter("ItmWight", DbType.Double, data_this.ItmWight);
            db_.AddParameter("ItmWight_T", DbType.Double, data_this.ItmWight_T);
            db_.AddParameter("RunCod", DbType.String, (data_this.RunCod == "0" ? "" : data_this.RunCod));
            db_.AddParameter("LineDetails", DbType.String, data_this.LineDetails);
            db_.AddParameter("ItmTax", DbType.Double, data_this.ItmTax);
            db_.AddParameter("Serial_Key", DbType.String, data_this.Serial_Key);
            db_.AddParameter("OfferTyp", DbType.Int32, data_this.OfferTyp);
            db_.AddParameter("CaExState", DbType.Int32, data_this.CaExState);
            db_.ExecuteNonQuery(storedProcedure: true, "S_T_INVDET_INSERT");

        }
        public static void INVDET_UPDATE(T_INVDET data_this)
        {
            IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
            db_.ClearParameters();
            db_.AddParameter("InvDet_ID", DbType.Int32, data_this.InvDet_ID);
            db_.AddParameter("InvNo", DbType.String, data_this.InvNo);
            db_.AddParameter("InvId", DbType.Int32, data_this.InvId);
            db_.AddParameter("InvSer", DbType.Int32, data_this.InvSer);
            db_.AddParameter("ItmNo", DbType.String, string.Concat(data_this.ItmNo));
            db_.AddParameter("Cost", DbType.Double, data_this.Cost);
            db_.AddParameter("Qty", DbType.Double, data_this.Qty);
            db_.AddParameter("ItmDes", DbType.String, data_this.ItmDes);
            db_.AddParameter("ItmUnt", DbType.String, data_this.ItmUnt);
            db_.AddParameter("ItmDesE", DbType.String, data_this.ItmDesE);
            db_.AddParameter("ItmUntE", DbType.String, data_this.ItmUntE);
            db_.AddParameter("ItmUntPak", DbType.Double, data_this.ItmUntPak);
            db_.AddParameter("StoreNo", DbType.Int32, data_this.StoreNo);
            db_.AddParameter("Price", DbType.Double, data_this.Price);
            db_.AddParameter("Amount", DbType.Double, data_this.Amount);
            db_.AddParameter("RealQty", DbType.Double, data_this.RealQty);
            db_.AddParameter("itmInvDsc", DbType.Double, data_this.itmInvDsc);
            db_.AddParameter("CInvType", DbType.Double, data_this.itmInvDsc);
            db_.AddParameter("DatExper", DbType.String, data_this.DatExper);
            db_.AddParameter("ItmDis", DbType.Double, data_this.ItmDis);
            db_.AddParameter("ItmAddCost", DbType.Double, data_this.ItmAddCost);
            db_.AddParameter("ItmTyp", DbType.Int32, data_this.ItmTyp);
            db_.AddParameter("ItmIndex", DbType.Int32, data_this.ItmIndex);
            db_.AddParameter("ItmWight", DbType.Double, data_this.ItmWight);
            db_.AddParameter("ItmWight_T", DbType.Double, data_this.ItmWight_T);
            db_.AddParameter("RunCod", DbType.String, data_this.RunCod);
            db_.AddParameter("LineDetails", DbType.String, data_this.RunCod);
            db_.AddParameter("ItmTax", DbType.Double, data_this.ItmTax);
            db_.AddParameter("Serial_Key", DbType.String, data_this.Serial_Key);
            db_.AddParameter("OfferTyp", DbType.Int32, data_this.Serial_Key);   

            db_.AddParameter("CaExState", DbType.Int32, data_this.CaExState);
            db_.ExecuteNonQuery(storedProcedure: true, "S_T_INVDET_UPDATE");

        }
        public static void GDDEDT_INSERT(T_GDDET data_this)
        {IDatabase db_= Database.GetDatabase(VarGeneral.BranchCS);
            db_.StartTransaction();
            db_.ClearParameters();
            db_.AddParameter("GDDET_ID", DbType.Int32, 0);
            db_.AddParameter("gdID", DbType.Int32, data_this.gdID);
            db_.AddParameter("gdNo", DbType.String, data_this.gdNo);
            db_.AddParameter("gdDes", DbType.String,data_this.gdDes);
            db_.AddParameter("gdDesE", DbType.String, data_this.gdDesE);
            db_.AddParameter("recptTyp", DbType.String, data_this.recptTyp);
            db_.AddParameter("AccNo", DbType.String, data_this.AccNo);
            db_.AddParameter("AccName", DbType.String, data_this.AccName);
            db_.AddParameter("gdValue", DbType.Double,data_this.gdValue);
            db_.AddParameter("recptNo", DbType.String, data_this.recptNo);
            db_.AddParameter("Lin", DbType.Int32, data_this.Lin);
            db_.AddParameter("AccNoDestruction", DbType.String, data_this.AccNoDestruction);
            db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
            db_.EndTransaction();
        }
        public static void  INVHED_Update(T_INVHED data_this)

        {
            IDatabase dbHead = Database.GetDatabase(VarGeneral.BranchCS);
            dbHead.ClearParameters();
            dbHead.AddParameter("InvHed_ID", DbType.Int32, data_this.InvHed_ID);
            dbHead.AddParameter("InvId", DbType.Double, data_this.InvId);
            dbHead.AddParameter("InvNo", DbType.String, data_this.InvNo);
            dbHead.AddParameter("InvTyp", DbType.Int32, data_this.InvTyp);
            dbHead.AddParameter("InvCashPay", DbType.Int32, data_this.InvCashPay);
            dbHead.AddParameter("CusVenNo", DbType.String, data_this.CusVenNo);
            dbHead.AddParameter("CusVenNm", DbType.String, data_this.CusVenNm);
            dbHead.AddParameter("CusVenAdd", DbType.String, data_this.CusVenAdd);
            dbHead.AddParameter("CusVenTel", DbType.String, data_this.CusVenTel);
            dbHead.AddParameter("Remark", DbType.String, data_this.Remark);
            dbHead.AddParameter("HDat", DbType.String, data_this.HDat);
            dbHead.AddParameter("GDat", DbType.String, data_this.GDat);
            dbHead.AddParameter("MndNo", DbType.Int32, data_this.MndNo);
            dbHead.AddParameter("SalsManNo", DbType.String, data_this.SalsManNo);
            dbHead.AddParameter("SalsManNam", DbType.String, data_this.SalsManNam);
            dbHead.AddParameter("InvTot", DbType.Double, data_this.InvTot);
            dbHead.AddParameter("InvTotLocCur", DbType.Double, data_this.InvTotLocCur);
            dbHead.AddParameter("InvDisPrs", DbType.Double, data_this.InvDisPrs);
            dbHead.AddParameter("InvDisVal", DbType.Double, data_this.InvDisVal);
            dbHead.AddParameter("CusVenMob", DbType.String, data_this.CusVenMob);
            dbHead.AddParameter("PriceIncludeTax", DbType.Boolean, data_this.PriceIncludTax);
            dbHead.AddParameter("InvDisValLocCur", DbType.Double, data_this.InvDisValLocCur);
            dbHead.AddParameter("InvNet", DbType.Double, data_this.InvNet);
            dbHead.AddParameter("InvNetLocCur", DbType.Double, data_this.InvNetLocCur);
            dbHead.AddParameter("CashPay", DbType.Double, data_this.CashPay);
            dbHead.AddParameter("CashPayLocCur", DbType.Double, data_this.CashPayLocCur);
            dbHead.AddParameter("IfRet", DbType.Int32, data_this.IfRet);
            dbHead.AddParameter("GadeNo", DbType.Double, data_this.GadeNo);
            dbHead.AddParameter("GadeId", DbType.Double, data_this.GadeId);
            dbHead.AddParameter("IfDel", DbType.Int32, data_this.IfDel);
            dbHead.AddParameter("RetNo", DbType.String, data_this.RetNo);
            dbHead.AddParameter("RetId", DbType.Double, data_this.RetId);
            dbHead.AddParameter("InvCstNo", DbType.Int32, data_this.InvCstNo);
            dbHead.AddParameter("InvCashPayNm", DbType.String, data_this.InvCashPayNm);
            dbHead.AddParameter("RefNo", DbType.String, data_this.RefNo);
            dbHead.AddParameter("InvCost", DbType.Int32, data_this.InvCost);
            dbHead.AddParameter("EstDat", DbType.String, data_this.EstDat);
            dbHead.AddParameter("CustPri", DbType.Int32, data_this.CustPri);
            dbHead.AddParameter("ArbTaf", DbType.String, data_this.ArbTaf);
            dbHead.AddParameter("CurTyp", DbType.Int32, data_this.CurTyp);
            dbHead.AddParameter("InvCash", DbType.String, data_this.InvCash);
            dbHead.AddParameter("ToStore", DbType.String, data_this.ToStore);
            dbHead.AddParameter("ToStoreNm", DbType.String, data_this.ToStoreNm);
            dbHead.AddParameter("InvQty", DbType.Double, data_this.InvQty);
            dbHead.AddParameter("EngTaf", DbType.String, data_this.EngTaf);
            dbHead.AddParameter("IfTrans", DbType.Int32, data_this.IfTrans);
            dbHead.AddParameter("CustRep", DbType.Double, data_this.CustRep);
            dbHead.AddParameter("CustNet", DbType.Double, data_this.CustNet);
            dbHead.AddParameter("InvWight_T", DbType.Double, data_this.InvWight_T);
            dbHead.AddParameter("IfPrint", DbType.Int32, data_this.IfPrint);
            dbHead.AddParameter("LTim", DbType.String, data_this.LTim);
            dbHead.AddParameter("CREATED_BY", DbType.String, data_this.CREATED_BY);
            dbHead.AddParameter("DATE_CREATED", DbType.DateTime, data_this.DATE_CREATED);
            dbHead.AddParameter("MODIFIED_BY", DbType.String, data_this.MODIFIED_BY);
            dbHead.AddParameter("DATE_MODIFIED", DbType.DateTime, data_this.DATE_MODIFIED);
            dbHead.AddParameter("CreditPay", DbType.Double, data_this.CreditPay);
            dbHead.AddParameter("CreditPayLocCur", DbType.Double, data_this.CreditPayLocCur);
            dbHead.AddParameter("NetworkPay", DbType.Double, data_this.NetworkPay);
            dbHead.AddParameter("NetworkPayLocCur", DbType.Double, data_this.NetworkPayLocCur);
            dbHead.AddParameter("CommMnd_Inv", DbType.Double, data_this.CommMnd_Inv);
            dbHead.AddParameter("MndExtrnal", DbType.Boolean, data_this.MndExtrnal);
            dbHead.AddParameter("CompanyID", DbType.Int32, data_this.CompanyID);
            dbHead.AddParameter("InvAddCost", DbType.Double, data_this.InvAddCost);
            dbHead.AddParameter("InvAddCostLoc", DbType.Double, data_this.InvAddCostLoc);
            dbHead.AddParameter("InvAddCostExtrnal", DbType.Double, data_this.InvAddCostExtrnal);
            dbHead.AddParameter("InvAddCostExtrnalLoc", DbType.Double, data_this.InvAddCostExtrnalLoc);
            dbHead.AddParameter("IsExtrnalGaid", DbType.Boolean, data_this.IsExtrnalGaid);
            dbHead.AddParameter("ExtrnalCostGaidID", DbType.Double, data_this.ExtrnalCostGaidID);
            dbHead.AddParameter("Puyaid", DbType.Double, data_this.Puyaid);
            dbHead.AddParameter("Remming", DbType.Double, data_this.Remming);
            dbHead.AddParameter("RoomNo", DbType.Int32, data_this.RoomNo);
            dbHead.AddParameter("OrderTyp", DbType.Int32, data_this.OrderTyp);
            dbHead.AddParameter("RoomSts", DbType.Boolean, data_this.RoomSts);
            dbHead.AddParameter("chauffeurNo", DbType.Int32, data_this.chauffeurNo);
            dbHead.AddParameter("RoomPerson", DbType.Int32, data_this.RoomPerson);
            dbHead.AddParameter("ServiceValue", DbType.Double, data_this.ServiceValue);
            dbHead.AddParameter("Sts", DbType.Boolean, data_this.Sts);
            dbHead.AddParameter("PaymentOrderTyp", DbType.Int32, data_this.PaymentOrderTyp);
            dbHead.AddParameter("AdminLock", DbType.Boolean, data_this.AdminLock);
            dbHead.AddParameter("DeleteDate", DbType.String, data_this.DeleteDate);
            dbHead.AddParameter("DeleteTime", DbType.String, data_this.DeleteTime);
            dbHead.AddParameter("UserNew", DbType.String, data_this.UserNew);
            dbHead.AddParameter("IfEnter", DbType.Int32, data_this.IfEnter);
            dbHead.AddParameter("InvAddTax", DbType.Double, data_this.InvAddTax);
            dbHead.AddParameter("InvAddTaxlLoc", DbType.Double, data_this.InvAddTaxlLoc);
            dbHead.AddParameter("IsTaxGaid", DbType.Boolean, data_this.IsTaxGaid);
            dbHead.AddParameter("TaxGaidID", DbType.Double, data_this.TaxGaidID);
            dbHead.AddParameter("IsTaxUse", DbType.Boolean, data_this.IsTaxUse);
            dbHead.AddParameter("InvValGaidDis", DbType.Double, data_this.InvValGaidDis);
            dbHead.AddParameter("InvValGaidDislLoc", DbType.Double, data_this.InvValGaidDislLoc);
            dbHead.AddParameter("IsDisGaid", DbType.Boolean, data_this.IsDisGaid);
            dbHead.AddParameter("DisGaidID1", DbType.Double, data_this.DisGaidID1);
            dbHead.AddParameter("IsDisUse1", DbType.Boolean, data_this.IsDisUse1);
            dbHead.AddParameter("InvComm", DbType.Double, data_this.InvComm);
            dbHead.AddParameter("InvCommLoc", DbType.Double, data_this.InvCommLoc);
            dbHead.AddParameter("IsCommGaid", DbType.Boolean, data_this.IsCommGaid);
            dbHead.AddParameter("CommGaidID", DbType.Double, data_this.CommGaidID);
            dbHead.AddParameter("IsCommUse", DbType.Boolean, data_this.IsCommUse);
            dbHead.AddParameter("IsTaxLines", DbType.Boolean, data_this.IsTaxLines);
            dbHead.AddParameter("IsTaxByTotal", DbType.Boolean, data_this.IsTaxByTotal);
            dbHead.AddParameter("IsTaxByNet", DbType.Boolean, data_this.IsTaxByNet);
            dbHead.AddParameter("TaxByNetValue", DbType.Double, data_this.TaxByNetValue);
            dbHead.AddParameter("DesPointsValue", DbType.Double, data_this.DesPointsValue);
            dbHead.AddParameter("DesPointsValueLocCur", DbType.Double, data_this.DesPointsValueLocCur);
            dbHead.AddParameter("PointsCount", DbType.Double, data_this.PointsCount);
            dbHead.AddParameter("IsPoints", DbType.Boolean, data_this.IsPoints);
            dbHead.AddParameter("tailor20", DbType.String, data_this.tailor20);
            dbHead.AddParameter("CusVenTaxNo", DbType.String, data_this.CusVenTaxNo);
            dbHead.AddParameter("IS_ServiceBill", DbType.Boolean, data_this.IS_ServiceBill);
            dbHead.AddParameter("Hash_Value", DbType.String, data_this.Hash_Value);
            dbHead.AddParameter("CusVenCRN", DbType.String, data_this.CusVenCRN);
            dbHead.ExecuteNonQuery(storedProcedure: true, "S_T_INVHED_UPDATE");

        }
        public static void ConvertsetDbParameter( object k, string Name, DbType tj, object value=null)
        {
            Type t = k.GetType();
               PropertyInfo myPropInfo = t.GetProperty(Name);
            int k1 = 0;

            if (value.GetType()==typeof(double))
            { k1 = 1; myPropInfo.SetValue(k, double.Parse(value.ToString())); }
            else if (value.GetType() == typeof(Int32))
            { k1 = 1; myPropInfo.SetValue(k, int.Parse(value.ToString())); }
            else if (value.GetType() == typeof(bool))
            { k1 = 1; myPropInfo.SetValue(k, (bool)value); }
            else if (value.GetType() == typeof(string))
                { k1 = 1; myPropInfo.SetValue(k, (string)value); }
if(k1==0)
            { }
        }
        public static void ConvertsetDbParameter(object k, string Name, object value )
        {
            Type t = k.GetType();
            PropertyInfo myPropInfo = t.GetProperty(Name);
            int k1 = 0;

            if (value.GetType() == typeof(double))
            { k1 = 1; myPropInfo.SetValue(k, double.Parse(value.ToString())); }
            else if (value.GetType() == typeof(Int32))
            { k1 = 1; myPropInfo.SetValue(k, int.Parse(value.ToString())); }
            else if (value.GetType() == typeof(bool))
            { k1 = 1; myPropInfo.SetValue(k, (bool)value); }
            else if (value.GetType() == typeof(string))
            { k1 = 1; myPropInfo.SetValue(k, (string)value); }
            if (k1 == 0)
            { }
        }

    }
    class DataBaseParamerts
    {

    }
}
