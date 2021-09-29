using System;
using System.Data;

namespace InvAcc.DBUdate
{
    class CarRepParameters
    {
        DataTable ts = new DataTable();
        public CarRepParameters()
        {
            DataColumn c = new DataColumn();
            c = new DataColumn("Invoice_No");
            c.DataType = typeof(string);
            ts.Columns.Add(c);
            c = new DataColumn("Invoice_Date");
            c.DataType = typeof(DateTime);
            ts.Columns.Add(c);
            c = new DataColumn("Invoice_Status");
            c.DataType = typeof(string);
            ts.Columns.Add(c);
            c = new DataColumn("Invoice_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Branch_ID");
            c.DataType = typeof(string);
            ts.Columns.Add(c);
            c = new DataColumn("Car_Type");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Car_Name");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Car_Model");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Customer_ID");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Invoice_Type");
            c.DataType = typeof(string);
            ts.Columns.Add(c);
            c = new DataColumn("Document_Type");
            c.DataType = typeof(string);
            ts.Columns.Add(c);
            c = new DataColumn("PlateNo_1st_dgt");
            c.DataType = typeof(string);
            ts.Columns.Add(c);
            c = new DataColumn("PlateNo_2nd_dgt");
            c.DataType = typeof(string);
            ts.Columns.Add(c);
            c = new DataColumn("PlateNo_3rd_dgt");
            c.DataType = typeof(string);
            ts.Columns.Add(c);
            c = new DataColumn("PlateNo_Numeric");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Complete_Car");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Complete_Product");
            c.DataType = typeof(string);
            ts.Columns.Add(c);
            c = new DataColumn("Complete_Code");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Complete_Remarks");
            c.DataType = typeof(string);
            ts.Columns.Add(c);
            c = new DataColumn("FrontGlass");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("FrontGlass_Product");
            c.DataType = typeof(string);
            ts.Columns.Add(c);
            c = new DataColumn("FrontGlass_Code");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("FrontGlass_Remarks");
            c.DataType = typeof(string);
            ts.Columns.Add(c);
            c = new DataColumn("RearGlass");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("RearGlass_Product");
            c.DataType = typeof(string);
            ts.Columns.Add(c);
            c = new DataColumn("RearGlass_Code");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("RearGlass_Remarks");
            c.DataType = typeof(string);
            ts.Columns.Add(c);
            c = new DataColumn("FrontDoors");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("FrontDoors_Product");
            c.DataType = typeof(string);
            ts.Columns.Add(c);
            c = new DataColumn("FrontDoors_Code");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("FrontDoors_Remarks");
            c.DataType = typeof(string);
            ts.Columns.Add(c);
            c = new DataColumn("RearDoors");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("RearDoors_Product");
            c.DataType = typeof(string);
            ts.Columns.Add(c);
            c = new DataColumn("RearDoors_Code");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("RearDoors_Remarks");
            c.DataType = typeof(string);
            ts.Columns.Add(c);
            c = new DataColumn("Triangle");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Triangle_Product");
            c.DataType = typeof(string);
            ts.Columns.Add(c);
            c = new DataColumn("Triangle_Code");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Triangle_Remarks");
            c.DataType = typeof(string);
            ts.Columns.Add(c);
            c = new DataColumn("Ceiling");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Ceiling_Product");
            c.DataType = typeof(string);
            ts.Columns.Add(c);
            c = new DataColumn("Ceiling_Code");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Ceiling_Remarks");
            c.DataType = typeof(string);
            ts.Columns.Add(c);
            c = new DataColumn("Protection_All");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Pro_FrontBumper");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Pro_RearBumper");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Pro_Kaboot");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Pro_Kotoof");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Pro_Mirrors");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Pro_Body");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Pro_Headlights");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Paint_Protection");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Car_CleanInside");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Car_CleanOutside");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Car_Leather");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Pro_Other");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Pro_Detail");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("CarbonFiber");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("FrontBumper_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("RearBumper_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Headlights_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Kaboot_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Kotoof_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Mirrors_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Body_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Paint_Pro_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("CleanInside_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("CleanOutside_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Leather_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("ProOther_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("ProDetail_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("CarbonFiber_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Operator_ID");
            c.DataType = typeof(string);
            ts.Columns.Add(c);
            c = new DataColumn("Payment_Method");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("HDY_Know_Us");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Payment_Other");
            c.DataType = typeof(string);
            ts.Columns.Add(c);
            c = new DataColumn("HDY_Other");
            c.DataType = typeof(string);
            ts.Columns.Add(c);
            c = new DataColumn("Tinting_Price");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Discount");
            c.DataType = typeof(double);
            ts.Columns.Add(c);
            c = new DataColumn("Less_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Protection_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Protection_Less");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Detailing_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Detailing_Less");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("OtherServices_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("OtherServices_Less");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("chkFloor");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Floor_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Mat_Option");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Mat_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("TV_Option");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("TV_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Total_Discount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Service_ID");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("SalesMan_ID");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Coupon_No");
            c.DataType = typeof(string);
            ts.Columns.Add(c);
            c = new DataColumn("Scratch");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Scratch_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("CeilingCover");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Ceiling_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Hemdi");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Hemdi_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Ox");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Ox_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Rust");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Rust_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Smell");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Smell_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Doors");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Doors_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Tire");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Tire_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Lights");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Lights_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Seats");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Seats_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Decor");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Decor_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Wood");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Wood_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Tablon");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Tablon_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Glass_Protection");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Glass_Protection_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Collected_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Warranty_Type");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("SalesMan_ID2");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Coupon_No2");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("SMSFlag");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Cobone_Offer");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Shabak");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Shabak_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Kashaf");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Kashaf_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("UnderCar");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("UnderCar_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("CarbonFiber_Complete_Car");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("CarbonFiber_Complete_Car_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Printed");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("SendSMS");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Offer_ID");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("MtUsed_FrontGlass");
            c.DataType = typeof(double);
            ts.Columns.Add(c);
            c = new DataColumn("MtUsed_RearGlass");
            c.DataType = typeof(double);
            ts.Columns.Add(c);
            c = new DataColumn("MtUsed_FrontDoors");
            c.DataType = typeof(double);
            ts.Columns.Add(c);
            c = new DataColumn("MtUsed_RearDoors");
            c.DataType = typeof(double);
            ts.Columns.Add(c);
            c = new DataColumn("MtUsed_Triangle");
            c.DataType = typeof(double);
            ts.Columns.Add(c);
            c = new DataColumn("MtUsed_Ceiling");
            c.DataType = typeof(double);
            ts.Columns.Add(c);
            c = new DataColumn("Sales_Commission1");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Sales_Commission2");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("No_Of_Visits");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("RemoveTinting");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("RemoveTinting_Price");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("RemoveProtection");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("RemoveProtection_Price");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("MtUsed_FrontBumper");
            c.DataType = typeof(double);
            ts.Columns.Add(c);
            c = new DataColumn("MtUsed_RearBumper");
            c.DataType = typeof(double);
            ts.Columns.Add(c);
            c = new DataColumn("MtUsed_Lights");
            c.DataType = typeof(double);
            ts.Columns.Add(c);
            c = new DataColumn("MtUsed_Kaboot");
            c.DataType = typeof(double);
            ts.Columns.Add(c);
            c = new DataColumn("MtUsed_Rafraf");
            c.DataType = typeof(double);
            ts.Columns.Add(c);
            c = new DataColumn("MtUsed_Mirrors");
            c.DataType = typeof(double);
            ts.Columns.Add(c);
            c = new DataColumn("InsideWash");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("InsideWash_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("OutsideWash");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("OutsideWash_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Whs");
            c.DataType = typeof(string);
            ts.Columns.Add(c);
            c = new DataColumn("SteamWash");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("SteamWash_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("OtherWash");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("OtherWash_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Remarks");
            c.DataType = typeof(string);
            ts.Columns.Add(c);
            c = new DataColumn("FrontGlass_Price");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("FrontDoors_Price");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("RearDoors_Price");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Triangle_Price");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Ceiling_Price");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("RearGlass_Price");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Ceramic_Layers");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Ceramic_Layers_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Mokhmal");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Mokhmal_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Ceramic_Leather");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Ceramic_Leather_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Plastic");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Plastic_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Rain");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Rain_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Pro_OtherServices");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Pro_OtherServices_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Pro_Inside");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Pro_Inside_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Pro_Outside");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Pro_Outside_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Pro_Correction");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Pro_Correction_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Pro_9H");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Pro_Light");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Pro_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Pro_Less");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Vin_No");
            c.DataType = typeof(string);
            ts.Columns.Add(c);
            c = new DataColumn("Pro_FrontGlass");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("Pro_FrontGlass_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Delivery_Date");
            c.DataType = typeof(DateTime);
            ts.Columns.Add(c);
            c = new DataColumn("Car_Color");
            c.DataType = typeof(string);
            ts.Columns.Add(c);
            c = new DataColumn("Span_Value");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Cash_Value");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Wash_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Wash_Less");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Line_No");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Reservation_Amount");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("VAT");
            c.DataType = typeof(bool);
            ts.Columns.Add(c);
            c = new DataColumn("VAT_Value");
            c.DataType = typeof(double);
            ts.Columns.Add(c);
            c = new DataColumn("Tech_Insentive");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Emp_Insentive");
            c.DataType = typeof(int);
            ts.Columns.Add(c);
            c = new DataColumn("Created_Date");
            c.DataType = typeof(DateTime);
            ts.Columns.Add(c);
            c = new DataColumn("Created_By");
            c.DataType = typeof(string);
            ts.Columns.Add(c);
            c = new DataColumn("Upd_Date");
            c.DataType = typeof(DateTime);
            ts.Columns.Add(c);
            c = new DataColumn("Upd_By");
            c.DataType = typeof(string);
            ts.Columns.Add(c);
            c = new DataColumn("Deleted_Date");
            c.DataType = typeof(DateTime);
            ts.Columns.Add(c);
            c = new DataColumn("Deleted_By");
            c.DataType = typeof(string);
            ts.Columns.Add(c);

        }
#pragma warning disable CS0169 // The field 'CarRepParameters.Complete_Car' is never used
        bool Complete_Car;
#pragma warning restore CS0169 // The field 'CarRepParameters.Complete_Car' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.FrontGlass' is never used
        bool FrontGlass;
#pragma warning restore CS0169 // The field 'CarRepParameters.FrontGlass' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.RearGlass' is never used
        bool RearGlass;
#pragma warning restore CS0169 // The field 'CarRepParameters.RearGlass' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.FrontDoors' is never used
        bool FrontDoors;
#pragma warning restore CS0169 // The field 'CarRepParameters.FrontDoors' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.RearDoors' is never used
        bool RearDoors;
#pragma warning restore CS0169 // The field 'CarRepParameters.RearDoors' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Triangle' is never used
        bool Triangle;
#pragma warning restore CS0169 // The field 'CarRepParameters.Triangle' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Ceiling' is never used
        bool Ceiling;
#pragma warning restore CS0169 // The field 'CarRepParameters.Ceiling' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Protection_All' is never used
        bool Protection_All;
#pragma warning restore CS0169 // The field 'CarRepParameters.Protection_All' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Pro_FrontBumper' is never used
        bool Pro_FrontBumper;
#pragma warning restore CS0169 // The field 'CarRepParameters.Pro_FrontBumper' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Pro_RearBumper' is never used
        bool Pro_RearBumper;
#pragma warning restore CS0169 // The field 'CarRepParameters.Pro_RearBumper' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Pro_Kaboot' is never used
        bool Pro_Kaboot;
#pragma warning restore CS0169 // The field 'CarRepParameters.Pro_Kaboot' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Pro_Kotoof' is never used
        bool Pro_Kotoof;
#pragma warning restore CS0169 // The field 'CarRepParameters.Pro_Kotoof' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Pro_Mirrors' is never used
        bool Pro_Mirrors;
#pragma warning restore CS0169 // The field 'CarRepParameters.Pro_Mirrors' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Pro_Body' is never used
        bool Pro_Body;
#pragma warning restore CS0169 // The field 'CarRepParameters.Pro_Body' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Pro_Headlights' is never used
        bool Pro_Headlights;
#pragma warning restore CS0169 // The field 'CarRepParameters.Pro_Headlights' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Paint_Protection' is never used
        bool Paint_Protection;
#pragma warning restore CS0169 // The field 'CarRepParameters.Paint_Protection' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Car_CleanInside' is never used
        bool Car_CleanInside;
#pragma warning restore CS0169 // The field 'CarRepParameters.Car_CleanInside' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Car_CleanOutside' is never used
        bool Car_CleanOutside;
#pragma warning restore CS0169 // The field 'CarRepParameters.Car_CleanOutside' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Car_Leather' is never used
        bool Car_Leather;
#pragma warning restore CS0169 // The field 'CarRepParameters.Car_Leather' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Pro_Other' is never used
        bool Pro_Other;
#pragma warning restore CS0169 // The field 'CarRepParameters.Pro_Other' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Pro_Detail' is never used
        bool Pro_Detail;
#pragma warning restore CS0169 // The field 'CarRepParameters.Pro_Detail' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.CarbonFiber' is never used
        bool CarbonFiber;
#pragma warning restore CS0169 // The field 'CarRepParameters.CarbonFiber' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.chkFloor' is never used
        bool chkFloor;
#pragma warning restore CS0169 // The field 'CarRepParameters.chkFloor' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Scratch' is never used
        bool Scratch;
#pragma warning restore CS0169 // The field 'CarRepParameters.Scratch' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.CeilingCover' is never used
        bool CeilingCover;
#pragma warning restore CS0169 // The field 'CarRepParameters.CeilingCover' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Hemdi' is never used
        bool Hemdi;
#pragma warning restore CS0169 // The field 'CarRepParameters.Hemdi' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Ox' is never used
        bool Ox;
#pragma warning restore CS0169 // The field 'CarRepParameters.Ox' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Rust' is never used
        bool Rust;
#pragma warning restore CS0169 // The field 'CarRepParameters.Rust' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Smell' is never used
        bool Smell;
#pragma warning restore CS0169 // The field 'CarRepParameters.Smell' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Doors' is never used
        bool Doors;
#pragma warning restore CS0169 // The field 'CarRepParameters.Doors' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Tire' is never used
        bool Tire;
#pragma warning restore CS0169 // The field 'CarRepParameters.Tire' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Lights' is never used
        bool Lights;
#pragma warning restore CS0169 // The field 'CarRepParameters.Lights' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Seats' is never used
        bool Seats;
#pragma warning restore CS0169 // The field 'CarRepParameters.Seats' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Decor' is never used
        bool Decor;
#pragma warning restore CS0169 // The field 'CarRepParameters.Decor' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Wood' is never used
        bool Wood;
#pragma warning restore CS0169 // The field 'CarRepParameters.Wood' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Tablon' is never used
        bool Tablon;
#pragma warning restore CS0169 // The field 'CarRepParameters.Tablon' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Glass_Protection' is never used
        bool Glass_Protection;
#pragma warning restore CS0169 // The field 'CarRepParameters.Glass_Protection' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.SMSFlag' is never used
        bool SMSFlag;
#pragma warning restore CS0169 // The field 'CarRepParameters.SMSFlag' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Cobone_Offer' is never used
        bool Cobone_Offer;
#pragma warning restore CS0169 // The field 'CarRepParameters.Cobone_Offer' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Shabak' is never used
        bool Shabak;
#pragma warning restore CS0169 // The field 'CarRepParameters.Shabak' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Kashaf' is never used
        bool Kashaf;
#pragma warning restore CS0169 // The field 'CarRepParameters.Kashaf' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.UnderCar' is never used
        bool UnderCar;
#pragma warning restore CS0169 // The field 'CarRepParameters.UnderCar' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.CarbonFiber_Complete_Car' is never used
        bool CarbonFiber_Complete_Car;
#pragma warning restore CS0169 // The field 'CarRepParameters.CarbonFiber_Complete_Car' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Printed' is never used
        bool Printed;
#pragma warning restore CS0169 // The field 'CarRepParameters.Printed' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.SendSMS' is never used
        bool SendSMS;
#pragma warning restore CS0169 // The field 'CarRepParameters.SendSMS' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.RemoveTinting' is never used
        bool RemoveTinting;
#pragma warning restore CS0169 // The field 'CarRepParameters.RemoveTinting' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.RemoveProtection' is never used
        bool RemoveProtection;
#pragma warning restore CS0169 // The field 'CarRepParameters.RemoveProtection' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.InsideWash' is never used
        bool InsideWash;
#pragma warning restore CS0169 // The field 'CarRepParameters.InsideWash' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.OutsideWash' is never used
        bool OutsideWash;
#pragma warning restore CS0169 // The field 'CarRepParameters.OutsideWash' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.SteamWash' is never used
        bool SteamWash;
#pragma warning restore CS0169 // The field 'CarRepParameters.SteamWash' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.OtherWash' is never used
        bool OtherWash;
#pragma warning restore CS0169 // The field 'CarRepParameters.OtherWash' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Mokhmal' is never used
        bool Mokhmal;
#pragma warning restore CS0169 // The field 'CarRepParameters.Mokhmal' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Ceramic_Leather' is never used
        bool Ceramic_Leather;
#pragma warning restore CS0169 // The field 'CarRepParameters.Ceramic_Leather' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Plastic' is never used
        bool Plastic;
#pragma warning restore CS0169 // The field 'CarRepParameters.Plastic' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Rain' is never used
        bool Rain;
#pragma warning restore CS0169 // The field 'CarRepParameters.Rain' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Pro_OtherServices' is never used
        bool Pro_OtherServices;
#pragma warning restore CS0169 // The field 'CarRepParameters.Pro_OtherServices' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Pro_Inside' is never used
        bool Pro_Inside;
#pragma warning restore CS0169 // The field 'CarRepParameters.Pro_Inside' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Pro_Outside' is never used
        bool Pro_Outside;
#pragma warning restore CS0169 // The field 'CarRepParameters.Pro_Outside' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Pro_Correction' is never used
        bool Pro_Correction;
#pragma warning restore CS0169 // The field 'CarRepParameters.Pro_Correction' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Pro_9H' is never used
        bool Pro_9H;
#pragma warning restore CS0169 // The field 'CarRepParameters.Pro_9H' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Pro_Light' is never used
        bool Pro_Light;
#pragma warning restore CS0169 // The field 'CarRepParameters.Pro_Light' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.Pro_FrontGlass' is never used
        bool Pro_FrontGlass;
#pragma warning restore CS0169 // The field 'CarRepParameters.Pro_FrontGlass' is never used
#pragma warning disable CS0169 // The field 'CarRepParameters.VAT' is never used
        bool VAT;
#pragma warning restore CS0169 // The field 'CarRepParameters.VAT' is never used


    }
}
