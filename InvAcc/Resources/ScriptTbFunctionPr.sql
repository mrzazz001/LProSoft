GO
/****** Object:  UserDefinedFunction [dbo].[get_date]    Script Date: 8/10/2021 10:35:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[get_date]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE function [dbo].[get_date]()
                                    returns VARCHAR(10)
                                    as
                                    begin
                                    DECLARE @GETDATE AS DATETIME = GETDATE()
                                    return  CONVERT(VARCHAR(4),DATEPART(YEAR, @GETDATE)) 
                                    + ''/''+ CONVERT(VARCHAR(2),DATEPART(MONTH, @GETDATE)) 
                                    + ''/'' + CONVERT(VARCHAR(2),DATEPART(DAY, @GETDATE)) end' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetTickeUsed]    Script Date: 8/10/2021 10:35:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetTickeUsed]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
                                    CREATE FUNCTION [dbo].[GetTickeUsed] (@EmpID varchar(40))
                                    RETURNS Float
                                    WITH EXECUTE AS CALLER
                                    AS
                                    begin
	                                    DECLARE @valueIn int;
	                                    DECLARE @value int;
		                                    set @valueIn = ISNull((SELECT sum(TicketCount) from T_Tickets Where EmpID=@EmpID),''0'')

	                                    set @value = @valueIn ;
	                                    return (@value);
                                    end

                                    ' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetVacUsed]    Script Date: 8/10/2021 10:35:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetVacUsed]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'    CREATE FUNCTION [dbo].[GetVacUsed](@EmpID varchar(40))
                                            RETURNS INT
                                            WITH EXECUTE AS CALLER
                                            AS
                                            begin
	                                            DECLARE @valueIn int;
	                                            DECLARE @value int;
		                                            set @valueIn = ISNull((SELECT sum(VacCountDay) from T_Vacation join T_VacTyp on T_Vacation.VacTyp = T_VacTyp.VacT_No Where T_Vacation.EmpID=@EmpID AND T_VacTyp.Dis_VacT = 1 AND T_Vacation.AdminLock = 1),''0'')

	                                            set @value = @valueIn ;
	                                            return (@value);
                                            end' 
END
GO
/****** Object:  StoredProcedure [dbo].[S_T_GDDET_DELETE]    Script Date: 8/10/2021 10:35:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[S_T_GDDET_DELETE]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[S_T_GDDET_DELETE] AS' 
END
GO


ALTER PROCEDURE [dbo].[S_T_GDDET_DELETE](
                  @GDDET_ID INT 
      )
      AS
      BEGIN
     
      --UPDATE T_AccDef SET T_AccDef.Debit = T_AccDef.Debit - T_GDDET.gdValue
      --From T_AccDef Left Join T_GDDET ON (T_AccDef.AccDef_No = T_GDDET.AccNo) 
      --where @GDDET_ID = GDDET_ID and  T_GDDET.gdValue > 0 ;

      --UPDATE T_AccDef SET T_AccDef.Credit = T_AccDef.Credit - ABS(T_GDDET.gdValue)
      --From T_AccDef Left Join T_GDDET ON (T_AccDef.AccDef_No = T_GDDET.AccNo) 
      --where @GDDET_ID = GDDET_ID and  T_GDDET.gdValue < 0 ;

      --UPDATE T_AccDef SET T_AccDef.Balance = T_AccDef.Debit - T_AccDef.Credit 
      --From T_AccDef Left Join T_GDDET ON (T_AccDef.AccDef_No = T_GDDET.AccNo) 
      --where @GDDET_ID = GDDET_ID ;

      DELETE FROM T_GDDET
      WHERE      @GDDET_ID = GDDET_ID

      RETURN
      END


GO
/****** Object:  StoredProcedure [dbo].[S_T_GDDET_INSERT]    Script Date: 8/10/2021 10:35:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[S_T_GDDET_INSERT]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[S_T_GDDET_INSERT] AS' 
END
GO
  ALTER PROCEDURE [dbo].[S_T_GDDET_INSERT](   
                                                 @GDDET_ID INT OUTPUT,
                                                 @gdID INT =NULL,
                                                 @gdNo VARCHAR (10)=NULL,
                                                 @gdDes VARCHAR (100)=NULL,
                                                 @gdDesE VARCHAR (100)=NULL,
                                                 @recptTyp VARCHAR (20)=NULL,
                                                 @AccNo VARCHAR (30)=NULL,
                                                 @AccName VARCHAR (50)=NULL,
                                                 @gdValue FLOAT =NULL,
                                                 @recptNo VARCHAR (20)=NULL,
                                                 @Lin INT =NULL,
                                                 @AccNoDestruction VARCHAR (30)=NULL
                                                 
                                          )
                                          AS
                                          BEGIN
                                          INSERT INTO T_GDDET(
                                                 gdID,
                                                 gdNo,
                                                 gdDes,
                                                 gdDesE,
                                                 recptTyp,
                                                 AccNo,
                                                 AccName,
                                                 gdValue,
                                                 recptNo,
                                                 Lin,
                                                 AccNoDestruction
                                          )
                                          VALUES
                                          (
                                                 
                                                @gdID,
                                                @gdNo,
                                                @gdDes,
                                                @gdDesE,
                                                @recptTyp,
                                                @AccNo,
                                                @AccName,
                                                @gdValue,
                                                @recptNo,
                                                @Lin,
                                                @AccNoDestruction
                                          )
                                          SELECT @GDDET_ID = SCOPE_IDENTITY()
                                          UPDATE T_AccDef SET T_AccDef.Debit = T_AccDef.Debit + ROUND( T_GDDET.gdValue, case when Substring((select MAX(T_SYSSETTING.Seting) from T_SYSSETTING),49,1) = 0 then 2 else 3 end)
                                          From T_AccDef Left Join T_GDDET ON (T_AccDef.AccDef_No = T_GDDET.AccNo) 
                                          where @GDDET_ID = GDDET_ID and  T_GDDET.gdValue > 0 ;
                                          UPDATE T_AccDef SET T_AccDef.Credit = T_AccDef.Credit + ABS(ROUND( T_GDDET.gdValue, case when Substring((select MAX(T_SYSSETTING.Seting) from T_SYSSETTING),49,1) = 0 then 2 else 3 end))
                                          From T_AccDef Left Join T_GDDET ON (T_AccDef.AccDef_No = T_GDDET.AccNo) 
                                          where @GDDET_ID = GDDET_ID and  T_GDDET.gdValue < 0 ;
                                          UPDATE T_AccDef SET T_AccDef.Balance = T_AccDef.Debit - T_AccDef.Credit
                                          From T_AccDef Left Join T_GDDET ON (T_AccDef.AccDef_No = T_GDDET.AccNo) 
                                          where @GDDET_ID = GDDET_ID ;
                                          RETURN
                                          END
GO
/****** Object:  StoredProcedure [dbo].[S_T_GDHEAD_DELETE]    Script Date: 8/10/2021 10:35:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[S_T_GDHEAD_DELETE]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[S_T_GDHEAD_DELETE] AS' 
END
GO
  ALTER PROCEDURE [dbo].[S_T_GDHEAD_DELETE](
                                          @gdhead_ID INT 
                                          )
                                          AS
                                          BEGIN
                                          
                                          UPDATE T_GDHEAD SET T_GDHEAD.gdLok = 'True',T_GDHEAD.gdTp = null,T_GDHEAD.gdRcptID = null 
                                          From T_GDHEAD
                                          where @gdhead_ID = gdhead_ID
                                          
                                          RETURN
                                          END
GO
/****** Object:  StoredProcedure [dbo].[S_T_INVDET_DELETE]    Script Date: 8/10/2021 10:35:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[S_T_INVDET_DELETE]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[S_T_INVDET_DELETE] AS' 
END
GO
  ALTER PROCEDURE [dbo].[S_T_INVDET_DELETE](
                                                      @InvDet_ID INT 
                                          )
                                          AS
                                          BEGIN
                                        declare @InvTyp int 
                                        declare @InvId int
                                        declare @MndID int
                                        declare @CusVenNo varchar(30)
                                        declare @PaymentOrderTyp int
                                        declare @ItemCountMnd int 
                                        declare @MndKind int 
                                         
                                        select @InvId = InvId from T_INVDET where InvDet_ID = @InvDet_ID;
                                        select @InvTyp = InvTyp from T_INVHED where InvHed_ID = @InvId;
                                        select @MndID = MndNo from T_INVHED where InvHed_ID = @InvId;
                                        
                                        select @PaymentOrderTyp = PaymentOrderTyp from T_INVHED where InvHed_ID = @InvId;
                                        select @CusVenNo = CusVenNo from T_INVHED where InvHed_ID = @InvId;
                                        
                                        select @MndKind = Mnd_Typ from T_Mndob where Mnd_ID = @MndID;
                                        
                                        if(@InvTyp != 7 and @InvTyp != 8 and @InvTyp != 9 and @InvTyp != 21)
                                        begin
                                             if((@PaymentOrderTyp <= 0 or @PaymentOrderTyp is null) or  ((@PaymentOrderTyp = 1 or @PaymentOrderTyp = 2) and (@InvTyp = 17 or @InvTyp = 20) ))
		                                      begin
			                                      UPDATE T_Items SET T_Items.OpenQty = T_Items.OpenQty - T_INVDET.RealQty 
			                                      From T_INVDET Left Join T_Items ON (T_INVDET.ItmNo = T_Items.Itm_No) 
			                                      where (InvDet_ID = @InvDet_ID) and (T_INVDET.ItmTyp <> 3) and (T_INVDET.ItmTyp <> 2);
			                                      UPDATE T_STKSQTY SET T_STKSQTY.stkQty = T_STKSQTY.stkQty - T_INVDET.RealQty 
			                                      From T_INVDET Left Join T_STKSQTY ON (T_INVDET.ItmNo = T_STKSQTY.itmNo) AND (T_INVDET.StoreNo = T_STKSQTY.storeNo)  
			                                      where @InvDet_ID = InvDet_ID and T_INVDET.ItmTyp <> 3 and (T_INVDET.ItmTyp <> 2);
                                    			  
			                                      UPDATE T_QTYEXP SET T_QTYEXP.stkQty = T_QTYEXP.stkQty - T_INVDET.RealQty 
			                                      From  T_INVDET Left Join T_QTYEXP ON (T_INVDET.ItmNo = T_QTYEXP.itmNo) AND (T_INVDET.StoreNo = T_QTYEXP.storeNo) AND (T_INVDET.DatExper = T_QTYEXP.DatExper and T_INVDET.RunCod = T_QTYEXP.RunCod )
			                                      where @InvDet_ID = InvDet_ID and T_INVDET.ItmTyp <> 3 and (T_INVDET.ItmTyp <> 2);
                                             end
                                             if(@InvTyp = 14)
		                                      begin
			                                      UPDATE T_STKSQTY SET T_STKSQTY.stkInt = T_STKSQTY.stkInt - T_INVDET.RealQty 
			                                      From T_INVDET Left Join T_STKSQTY ON (T_INVDET.ItmNo = T_STKSQTY.itmNo) AND (T_INVDET.StoreNo = T_STKSQTY.storeNo)  
			                                      where @InvDet_ID = InvDet_ID and T_INVDET.ItmTyp <> 3 and (T_INVDET.ItmTyp <> 2);
		                                      end
                                         if(@InvTyp = 17)
	                                     begin
                                    				  
													  select @MndID = MndNo from T_INVHED where InvHed_ID = @InvId;
													  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty - abs(T_INVDET.RealQty)
													  From T_INVDET Left Join T_StoreMnd ON (T_INVDET.ItmNo = T_StoreMnd.itmNo) AND (T_INVDET.StoreNo = T_StoreMnd.storeNo)  
													  where @InvDet_ID = InvDet_ID and T_INVDET.ItmTyp <> 3 and T_StoreMnd.MndNo = @MndID ;
				                                      
													  select @CusVenNo = CusVenNo from T_INVHED where InvHed_ID = @InvId;
													  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty - abs(T_INVDET.RealQty)
													  From T_INVDET Left Join T_StoreMnd ON (T_INVDET.ItmNo = T_StoreMnd.itmNo) AND (T_INVDET.StoreNo = T_StoreMnd.storeNo)  
													  where @InvDet_ID = InvDet_ID and T_INVDET.ItmTyp <> 3 and T_StoreMnd.CusVenNo = @CusVenNo ;
                                         end
                                         
                                         if(@InvTyp = 20)
	                                     begin
                                    				   
														  select @MndID = MndNo from T_INVHED where InvHed_ID = @InvId;
														  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty + T_INVDET.RealQty 
														  From T_INVDET Left Join T_StoreMnd ON (T_INVDET.ItmNo = T_StoreMnd.itmNo) AND (T_INVDET.StoreNo = T_StoreMnd.storeNo)  
														  where @InvDet_ID = InvDet_ID and T_INVDET.ItmTyp <> 3 and T_StoreMnd.MndNo = @MndID ;
					                                      
														  select @CusVenNo = CusVenNo from T_INVHED where InvHed_ID = @InvId;
														  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty + T_INVDET.RealQty 
														  From T_INVDET Left Join T_StoreMnd ON (T_INVDET.ItmNo = T_StoreMnd.itmNo) AND (T_INVDET.StoreNo = T_StoreMnd.storeNo)  
														  where @InvDet_ID = InvDet_ID and T_INVDET.ItmTyp <> 3 and T_StoreMnd.CusVenNo = @CusVenNo ;
                                         end
                                        end
                                         
                                          DELETE FROM T_INVDET
                                          WHERE      @InvDet_ID = InvDet_ID    
                                          RETURN
                                          END
GO
/****** Object:  StoredProcedure [dbo].[S_T_INVDET_INSERT]    Script Date: 8/10/2021 10:35:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[S_T_INVDET_INSERT]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[S_T_INVDET_INSERT] AS' 
END
GO
ALTER PROCEDURE [dbo].[S_T_INVDET_INSERT](   
                                                                 @InvDet_ID INT OUTPUT,
                                                                 @InvNo VARCHAR (10)=NULL,
                                                                 @InvId INT =NULL,
                                                                 @InvSer INT =NULL,
                                                                 @ItmNo VARCHAR (50)=NULL,
                                                                 @Cost FLOAT =NULL,
                                                                 @Qty FLOAT =NULL,
                                                                 @ItmDes VARCHAR (50)=NULL,
                                                                 @ItmUnt VARCHAR (100)=NULL,
                                                                 @ItmDesE VARCHAR (50)=NULL,
                                                                 @ItmUntE VARCHAR (100)=NULL,
                                                                 @ItmUntPak FLOAT =NULL,
                                                                 @StoreNo INT=NULL,
                                                                 @Price FLOAT =NULL,
                                                                 @Amount FLOAT =NULL,
                                                                 @RealQty FLOAT =NULL,
                                                                 @itmInvDsc FLOAT =NULL,
                                                                 @DatExper VARCHAR (11)=NULL,
                                                                 @ItmDis FLOAT =NULL,
                                                                 @ItmTyp INT =NULL,
                                                                 @ItmIndex INT =NULL,
                                                                 @ItmWight FLOAT =NULL,
                                                                 @ItmWight_T FLOAT =NULL,
                                                                 @ItmAddCost FLOAT =NULL,
                                                                 @RunCod VARCHAR (100)=NULL,
                                                                 @LineDetails VARCHAR (250)=NULL,
                                                                 @Serial_Key VARCHAR (100)=NULL,
                                                                 @ItmTax FLOAT =NULL,
                                                                 @OfferTyp INT =NULL,
																 @CInvType INT =NULL,
@CaExState INT =0
                                                          )
                                                          AS
                                                          BEGIN
                                                          INSERT INTO T_INVDET(
                                                                 InvNo,
                                                                 InvId,
                                                                 InvSer,
                                                                 ItmNo,
                                                                 Cost,
                                                                 Qty,
                                                                 ItmDes,
                                                                 ItmUnt,
                                                                 ItmDesE,
                                                                 ItmUntE,
                                                                 ItmUntPak,
                                                                 StoreNo,
                                                                 Price,
                                                                 Amount,
                                                                 RealQty,
                                                                 itmInvDsc,
                                                                 DatExper,
                                                                 ItmDis,
                                                                 ItmTyp,
                                                                 ItmIndex,
                                                                 ItmWight,
                                                                 ItmWight_T,
                                                                 ItmAddCost,
                                                                 RunCod,
                                                                 LineDetails,
                                                                 Serial_Key,
                                                                 ItmTax,
                                                                OfferTyp ,
																CInvType,
CaExState
                                                          )
                                                          VALUES
                                                          (
                                                                 
                                                                @InvNo,
                                                                @InvId,
                                                                @InvSer,
                                                                @ItmNo,
                                                                @Cost,
                                                                @Qty,
                                                                @ItmDes,
                                                                @ItmUnt,
                                                                @ItmDesE,
                                                                @ItmUntE,
                                                                @ItmUntPak,
                                                                @StoreNo,
                                                                @Price,
                                                                @Amount,
                                                                @RealQty,
                                                                @itmInvDsc,
                                                                @DatExper,
                                                                @ItmDis,
                                                                @ItmTyp,
                                                                @ItmIndex,
                                                                @ItmWight,
                                                                @ItmWight_T,
                                                                @ItmAddCost,
                                                                @RunCod,
                                                                @LineDetails,
                                                                @Serial_Key,
                                                                @ItmTax,
                                                                @OfferTyp,
																@CInvType
,@CaExState
                                                          )
                                                          SELECT @InvDet_ID = SCOPE_IDENTITY()
                                                            declare @ItemCount int  
                                                            declare @InvTyp int
                                                            declare @MndID int
                                                            declare @CusVenNo varchar(30)
                                                            declare @ItemCountMnd int 
                                                            declare @ItemCountCust int 
		                                                    select @ItemCount = Count(*) from T_STKSQTY where itmNo = @ItmNo and storeNo =@StoreNo;
                                                            select @InvTyp = InvTyp from T_INVHED where InvHed_ID = @InvId;
                                                            if((@InvTyp !=-101
AND @InvTyp != 7 and @InvTyp != 8 and @InvTyp != 9 and @InvTyp != 21) and @ItmTyp <> 3)
                                                            begin
			                                                          if(@ItmTyp <> 2)
			                                                          begin
		                                                                    Update T_Items SET OpenQty = OpenQty+@RealQty WHERE Itm_No = @ItmNo;
			                                                                if(@ItemCount > 0)
			                                                                begin
			                                                                Update T_STKSQTY SET stkQty = stkQty+@RealQty WHERE itmNo = @ItmNo and storeNo = @StoreNo;
			                                                                end
			                                                                if(@ItemCount = 0)
			                                                                begin 
			                                                                INSERT INTO T_STKSQTY(itmNo,storeNo,stkQty,stkInt) VALUES(@ItmNo,@StoreNo,@RealQty,0);
			                                                                END
                                                                            if(@InvTyp = 14)
                                                                            begin
				                                                                Update T_STKSQTY SET stkInt = stkInt+@RealQty WHERE itmNo = @ItmNo and storeNo = @StoreNo;
                                                                            end
			                                                                select @ItemCount = Count(*) from T_QTYEXP where itmNo = @ItmNo and storeNo =@StoreNo and (DatExper = @DatExper and RunCod = @RunCod);
			                                                                if(@ItemCount > 0 and (@DatExper <> '' or @RunCod <> ''))
			                                                                begin
			                                                                Update T_QTYEXP SET stkQty = stkQty+@RealQty WHERE itmNo = @ItmNo and storeNo = @StoreNo and (DatExper = @DatExper and RunCod = @RunCod);
			                                                                end
			                                                                if(@ItemCount = 0 and (@DatExper <> '' or @RunCod <> ''))
			                                                                begin 
			                                                                INSERT INTO T_QTYEXP(itmNo,storeNo,DatExper,stkQty,RunCod) VALUES(@ItmNo,@StoreNo,@DatExper,@RealQty,@RunCod);
			                                                                END
                                                                END
			                                                          if(@InvTyp = 17)
				                                                          begin
														                       select @MndID = MndNo from T_INVHED where InvHed_ID = @InvId;
														                       select @CusVenNo = CusVenNo from T_INVHED where InvHed_ID = @InvId;
														                       if(@MndID > 0 )
															                    begin
															                              select @ItemCountMnd = Count(*) from T_StoreMnd where itmNo = @ItmNo and storeNo =@StoreNo and MndNo = @MndID;
																	                      if(@ItemCountMnd > 0)
																	                      begin
																		                       Update T_StoreMnd SET stkQty = stkQty + abs(@RealQty) WHERE itmNo = @ItmNo and storeNo = @StoreNo and MndNo = @MndID;
																	                      end
																	                      if(@ItemCountMnd = 0)
																	                      begin 
																		                       INSERT INTO T_StoreMnd(itmNo,storeNo,stkQty,stkInt,MndNo) VALUES(@ItmNo,@StoreNo,abs(@RealQty),0,@MndID);
																	                      END
															                    END
														                      else
									                                            begin
															                             select @ItemCountCust = Count(*) from T_StoreMnd where itmNo = @ItmNo and storeNo =@StoreNo and CusVenNo = @CusVenNo;
																	                      if(@ItemCountCust > 0)
																	                      begin
																		                       Update T_StoreMnd SET stkQty = stkQty + abs(@RealQty) WHERE itmNo = @ItmNo and storeNo = @StoreNo and CusVenNo = @CusVenNo;
																	                      end
																	                      if(@ItemCountCust = 0)
																	                      begin 
																		                       INSERT INTO T_StoreMnd(itmNo,storeNo,stkQty,stkInt,CusVenNo) VALUES(@ItmNo,@StoreNo,abs(@RealQty),0,@CusVenNo);
																	                      END
															                    END
				                                                          END	
			                                                          if(@InvTyp = 20)
				                                                          begin
				                                                              select @MndID = MndNo from T_INVHED where InvHed_ID = @InvId;
														                      select @CusVenNo = CusVenNo from T_INVHED where InvHed_ID = @InvId;
														                        if(@MndID > 0 )
																                    begin
																	                     select @ItemCountMnd = Count(*) from T_StoreMnd where itmNo = @ItmNo and storeNo =@StoreNo and MndNo = @MndID;
																	                      if(@ItemCountMnd > 0)
																	                      begin
																		                       Update T_StoreMnd SET stkQty = stkQty + (-@RealQty) WHERE itmNo = @ItmNo and storeNo = @StoreNo and MndNo = @MndID;
																	                      end
																	                      if(@ItemCountMnd = 0)
																	                      begin 
																		                       INSERT INTO T_StoreMnd(itmNo,storeNo,stkQty,stkInt,MndNo) VALUES(@ItmNo,@StoreNo,-@RealQty,0,@MndID);
																	                      END
																                     END
							                                                     else
							                                                         begin
																	                     select @ItemCountCust = Count(*) from T_StoreMnd where itmNo = @ItmNo and storeNo =@StoreNo and CusVenNo = @CusVenNo;
																	                      if(@ItemCountCust > 0)
																	                      begin
																		                       Update T_StoreMnd SET stkQty = stkQty + (-@RealQty) WHERE itmNo = @ItmNo and storeNo = @StoreNo and CusVenNo = @CusVenNo;
																	                      end
																	                      if(@ItemCountCust = 0)
																	                      begin 
																		                       INSERT INTO T_StoreMnd(itmNo,storeNo,stkQty,stkInt,CusVenNo) VALUES(@ItmNo,@StoreNo,-@RealQty,0,@CusVenNo);
																	                      END
																                     END
				                                                          end
                                                            end
                                                          RETURN @InvDet_ID
                                                          END
GO
/****** Object:  StoredProcedure [dbo].[S_T_INVHED_DELETE]    Script Date: 8/10/2021 10:35:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[S_T_INVHED_DELETE]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[S_T_INVHED_DELETE] AS' 
END
GO
ALTER PROCEDURE [dbo].[S_T_INVHED_DELETE](
                                              @InvHed_ID INT 
                                  )
                                  AS
                                  BEGIN
                                  declare @InvTyp int
                                  declare @MndID int
                                  declare @CusVenNo varchar(30)
                                  declare @PaymentOrderTyp int
                                  declare @MndKind int 
                                       
                                  select @InvTyp = InvTyp from T_INVHED where InvHed_ID = @InvHed_ID;
                                select @MndID = MndNo from T_INVHED where InvHed_ID = @InvHed_ID;
                                
                                select @PaymentOrderTyp = PaymentOrderTyp from T_INVHED where InvHed_ID = @InvHed_ID;
                                select @CusVenNo = CusVenNo from T_INVHED where InvHed_ID = @InvHed_ID;
                                select @MndKind = Mnd_Typ from T_Mndob where Mnd_ID = @MndID;
                                
                                  if(@InvTyp != 7 and @InvTyp != 8 and @InvTyp != 9 and @InvTyp != 21)
                                begin
                                  if(@PaymentOrderTyp <= 0 or @PaymentOrderTyp is null)
	                              begin
		                              UPDATE T_Items SET T_Items.OpenQty = T_Items.OpenQty - T_INVDET.RealQty 
		                              From T_INVDET Left Join T_Items ON (T_INVDET.ItmNo = T_Items.Itm_No) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID) 
		                              where (InvHed_ID = @InvHed_ID) and (T_INVDET.ItmTyp <> 3) and (T_INVDET.ItmTyp <> 2);
		                              UPDATE T_STKSQTY SET T_STKSQTY.stkQty = T_STKSQTY.stkQty - T_INVDET.RealQty 
		                              From T_INVDET Left Join T_STKSQTY ON (T_INVDET.ItmNo = T_STKSQTY.itmNo) AND (T_INVDET.StoreNo = T_STKSQTY.storeNo) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)  
		                              where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and (T_INVDET.ItmTyp <> 2);
                            		  
		                              UPDATE T_QTYEXP SET T_QTYEXP.stkQty = T_QTYEXP.stkQty - T_INVDET.RealQty 
		                              From  T_INVDET Left Join T_QTYEXP ON (T_INVDET.ItmNo = T_QTYEXP.itmNo) AND (T_INVDET.StoreNo = T_QTYEXP.storeNo) AND (T_INVDET.DatExper = T_QTYEXP.DatExper and T_INVDET.RunCod = T_QTYEXP.RunCod ) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)
		                              where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and (T_INVDET.ItmTyp <> 2);
                                  end
                                 if(@InvTyp = 17)
	                             begin
                                         if(@PaymentOrderTyp > 0)
	                                      begin
 										      UPDATE T_Items SET T_Items.OpenQty = T_Items.OpenQty - T_INVDET.RealQty 
										      From T_INVDET Left Join T_Items ON (T_INVDET.ItmNo = T_Items.Itm_No) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID) 
										      where (InvHed_ID = @InvHed_ID) and (T_INVDET.ItmTyp <> 3) and (T_INVDET.ItmTyp <> 2);
										      UPDATE T_STKSQTY SET T_STKSQTY.stkQty = T_STKSQTY.stkQty - T_INVDET.RealQty 
										      From T_INVDET Left Join T_STKSQTY ON (T_INVDET.ItmNo = T_STKSQTY.itmNo) AND (T_INVDET.StoreNo = T_STKSQTY.storeNo) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)  
										      where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and (T_INVDET.ItmTyp <> 2);
                                			  
										      UPDATE T_QTYEXP SET T_QTYEXP.stkQty = T_QTYEXP.stkQty - T_INVDET.RealQty 
										      From  T_INVDET Left Join T_QTYEXP ON (T_INVDET.ItmNo = T_QTYEXP.itmNo) AND (T_INVDET.StoreNo = T_QTYEXP.storeNo) AND (T_INVDET.DatExper = T_QTYEXP.DatExper and T_INVDET.RunCod = T_QTYEXP.RunCod ) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)
										      where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and (T_INVDET.ItmTyp <> 2);
                                          end
										  select @MndID = MndNo from T_INVHED where InvHed_ID = @InvHed_ID;  	  
										  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty - abs(T_INVDET.RealQty)
										  From T_INVDET Left Join T_StoreMnd ON (T_INVDET.ItmNo = T_StoreMnd.itmNo) AND (T_INVDET.StoreNo = T_StoreMnd.storeNo) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)  
										  where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and T_StoreMnd.MndNo = @MndID ;
										  
										  select @CusVenNo = CusVenNo from T_INVHED where InvHed_ID = @InvHed_ID;  	  
										  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty - abs(T_INVDET.RealQty)
										  From T_INVDET Left Join T_StoreMnd ON (T_INVDET.ItmNo = T_StoreMnd.itmNo) AND (T_INVDET.StoreNo = T_StoreMnd.storeNo) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)  
										  where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and T_StoreMnd.CusVenNo = @CusVenNo ;
                                 end
                                 
                                 if(@InvTyp = 20)
	                             begin
                                         if(@PaymentOrderTyp > 0)
	                                      begin
 										      UPDATE T_Items SET T_Items.OpenQty = T_Items.OpenQty - T_INVDET.RealQty 
										      From T_INVDET Left Join T_Items ON (T_INVDET.ItmNo = T_Items.Itm_No) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID) 
										      where (InvHed_ID = @InvHed_ID) and (T_INVDET.ItmTyp <> 3) and (T_INVDET.ItmTyp <> 2);
										      UPDATE T_STKSQTY SET T_STKSQTY.stkQty = T_STKSQTY.stkQty - T_INVDET.RealQty 
										      From T_INVDET Left Join T_STKSQTY ON (T_INVDET.ItmNo = T_STKSQTY.itmNo) AND (T_INVDET.StoreNo = T_STKSQTY.storeNo) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)  
										      where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and (T_INVDET.ItmTyp <> 2);
                                			  
										      UPDATE T_QTYEXP SET T_QTYEXP.stkQty = T_QTYEXP.stkQty - T_INVDET.RealQty 
										      From  T_INVDET Left Join T_QTYEXP ON (T_INVDET.ItmNo = T_QTYEXP.itmNo) AND (T_INVDET.StoreNo = T_QTYEXP.storeNo) AND (T_INVDET.DatExper = T_QTYEXP.DatExper and T_INVDET.RunCod = T_QTYEXP.RunCod ) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)
										      where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and (T_INVDET.ItmTyp <> 2);
                                          end
												  select @MndID = MndNo from T_INVHED where InvHed_ID = @InvHed_ID;  	  
												  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty + T_INVDET.RealQty 
												  From T_INVDET Left Join T_StoreMnd ON (T_INVDET.ItmNo = T_StoreMnd.itmNo) AND (T_INVDET.StoreNo = T_StoreMnd.storeNo) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)  
												  where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and T_StoreMnd.MndNo = @MndID ;
												  
												  select @CusVenNo = CusVenNo from T_INVHED where InvHed_ID = @InvHed_ID;  	  
												  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty + T_INVDET.RealQty 
												  From T_INVDET Left Join T_StoreMnd ON (T_INVDET.ItmNo = T_StoreMnd.itmNo) AND (T_INVDET.StoreNo = T_StoreMnd.storeNo) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)  
												  where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and T_StoreMnd.CusVenNo = @CusVenNo ;
                                 end
                             
                                  if(@InvTyp = 14)
                                  begin
		                              UPDATE T_STKSQTY SET T_STKSQTY.stkInt = T_STKSQTY.stkInt - T_INVDET.RealQty 
		                              From T_INVDET Left Join T_STKSQTY ON (T_INVDET.ItmNo = T_STKSQTY.itmNo) AND (T_INVDET.StoreNo = T_STKSQTY.storeNo) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)  
		                              where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and (T_INVDET.ItmTyp <> 2);
                                  end       
                                  
                                end
                                  UPDATE T_INVHED SET T_INVHED.IfDel = 1 
                                  FROM  T_INVHED
                                  WHERE  @InvHed_ID = InvHed_ID
                                  RETURN
                                  END
GO
/****** Object:  StoredProcedure [dbo].[S_T_INVHED_INSERT]    Script Date: 8/10/2021 10:35:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[S_T_INVHED_INSERT]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[S_T_INVHED_INSERT] AS' 
END
GO
ALTER PROCEDURE[dbo].[S_T_INVHED_INSERT]
        (
                                                                    @InvHed_ID INT OUTPUT,
                                                                    @InvId FLOAT =NULL,
                                                                     @InvNo VARCHAR(10),
                                                                     @InvTyp INT = NULL,
                                                                     @InvCashPay INT =NULL,
                                                                     @CusVenNo VARCHAR(20)=NULL,
                                                                     @CusVenNm VARCHAR(50)=NULL,
                                                                     @CusVenAdd VARCHAR(100)=NULL,
                                                                     @CusVenTel VARCHAR(30)=NULL,
                                                                     @Remark VARCHAR(MAX)=NULL,
                                                                     @HDat VARCHAR(10)=NULL,
                                                                     @GDat VARCHAR(10)=NULL,
                                                                     @MndNo INT = NULL,
                                                                     @SalsManNo VARCHAR(3)=NULL,
                                                                     @SalsManNam VARCHAR(50)=NULL,
                                                                     @InvTot FLOAT = NULL,
                                                                     @InvTotLocCur FLOAT =NULL,
                                                                     @InvDisPrs FLOAT = NULL,
                                                                     @InvDisVal FLOAT =NULL,
                                                                     @InvDisValLocCur FLOAT = NULL,
                                                                     @InvNet FLOAT =NULL,
                                                                     @InvNetLocCur FLOAT = NULL,
                                                                     @CashPay FLOAT =NULL,
                                                                     @CashPayLocCur FLOAT = NULL,
                                                                     @IfRet INT =NULL,
                                                                     @GadeNo FLOAT = NULL,
                                                                     @GadeId FLOAT =NULL,
                                                                     @IfDel INT = NULL,
                                                                     @RetNo VARCHAR(10)=NULL,
                                                                     @RetId FLOAT = NULL,
                                                                     @InvCstNo INT =NULL,
                                                                     @InvCashPayNm VARCHAR(100)=NULL,
                                                                     @RefNo VARCHAR(20)=NULL,
                                                                     @InvCost FLOAT = NULL,
                                                                     @EstDat VARCHAR(10)=NULL,
                                                                     @CustPri INT = NULL,
                                                                     @ArbTaf VARCHAR(150)=NULL,
                                                                     @CurTyp INT = NULL,
                                                                     @InvCash VARCHAR(20)=NULL,
                                                                     @ToStore VARCHAR(3)=NULL,
                                                                     @ToStoreNm VARCHAR(50)=NULL,
                                                                     @InvQty FLOAT = NULL,
                                                                     @EngTaf VARCHAR(150)=NULL,
                                                                     @IfTrans INT = NULL,
                                                                     @CustRep FLOAT =NULL,
                                                                     @CustNet FLOAT = NULL,
                                                                     @InvWight_T FLOAT =NULL,
                                                                     @IfPrint INT = NULL,
                                                                     @LTim VARCHAR(10)=NULL,
                                                                     @CREATED_BY VARCHAR(100) =NULL,
                                                                     @DATE_CREATED datetime = NULL,
                                                                     @MODIFIED_BY VARCHAR(100)=NULL,
                                                                     @DATE_MODIFIED datetime = NULL,
                                                                     @CreditPay float=NULL,
                                                                     @CreditPayLocCur float=NULL,
                                                                     @NetworkPay float=NULL,
                                                                     @NetworkPayLocCur float=NULL,
                                                                     @CommMnd_Inv float=NULL,
                                                                     @MndExtrnal bit = NULL,
                                                                     @CompanyID int=NULL,
                                                                     @InvAddCost float=NULL,
                                                                     @InvAddCostLoc float=NULL,
                                                                     @InvAddCostExtrnal float=NULL,
                                                                     @InvAddCostExtrnalLoc float=NULL,
                                                                     @IsExtrnalGaid bit = NULL,
                                                                     @ExtrnalCostGaidID float=NULL,
                                                                     @Puyaid float=NULL,
                                                                     @Remming float=NULL,
                                                                     @RoomNo int=NULL,
                                                                     @OrderTyp int=NULL,
                                                                     @RoomSts bit = NULL,
                                                                     @chauffeurNo int=NULL,
                                                                     @RoomPerson int=NULL,
                                                                     @ServiceValue float=NULL,
                                                                     @Sts bit = NULL,
                                                                     @PaymentOrderTyp int=NULL,
                                                                     @AdminLock bit = NULL,
                                                                     @DeleteDate VARCHAR(10)=NULL,
                                                                     @DeleteTime VARCHAR(10)=NULL,
                                                                     @UserNew VARCHAR(3)=NULL,
                                                                     @IfEnter int=NULL,
                                                                     @InvAddTax float=NULL,
                                                                     @InvAddTaxlLoc float=NULL,
                                                                     @IsTaxGaid bit = NULL,
                                                                     @TaxGaidID float=NULL,
                                                                     @IsTaxUse bit = NULL,
                                                                     @InvValGaidDis float=NULL,
                                                                     @InvValGaidDislLoc float=NULL,
                                                                     @IsDisGaid bit = NULL,
                                                                     @DisGaidID1 float=NULL,
                                                                     @IsDisUse1 bit = NULL,
                                                                     @InvComm float=NULL,
                                                                     @InvCommLoc float=NULL,
                                                                     @IsCommGaid bit = NULL,
                                                                     @CommGaidID float=NULL,
                                                                     @IsCommUse bit = NULL,
                                                                     @IsTaxLines bit=NULL,
                                                                     @IsTaxByTotal bit = NULL,
                                                                     @IsTaxByNet bit=NULL,
                                                                     @TaxByNetValue float=NULL,
                                                                     @DesPointsValue float=NULL,
                                                                     @DesPointsValueLocCur float=NULL,
                                                                     @PointsCount float=NULL,
                                                                     @IsPoints bit = NULL,
                                                                     @tailor1 VARCHAR(100)=NULL,
                                                                     @tailor2 VARCHAR(100)=NULL,
                                                                     @tailor3 VARCHAR(100)=NULL,
                                                                     @tailor4 VARCHAR(100)=NULL,
                                                                     @tailor5 VARCHAR(100)=NULL,
                                                                     @tailor6 VARCHAR(100)=NULL,
                                                                     @tailor7 VARCHAR(100)=NULL,
                                                                     @tailor8 VARCHAR(100)=NULL,
                                                                     @tailor9 VARCHAR(100)=NULL,
                                                                     @tailor10 VARCHAR(100)=NULL,
                                                                     @tailor11 VARCHAR(100)=NULL,
                                                                     @tailor12 VARCHAR(100)=NULL,
                                                                     @tailor13 VARCHAR(100)=NULL,
                                                                     @tailor14 VARCHAR(100)=NULL,
                                                                     @tailor15 VARCHAR(100)=NULL,
                                                                     @tailor16 VARCHAR(100)=NULL,
                                                                     @tailor17 VARCHAR(100)=NULL,
                                                                     @tailor18 VARCHAR(100)=NULL,
                                                                     @tailor19 VARCHAR(100)=NULL,
                                                                     @tailor20 VARCHAR(100)=NULL,
                                                                     @InvImg[varbinary] (max) =NULL,
                                                                     @CusVenMob VARCHAR(50) =NULL,
                                                                     @PriceIncludeTax BIT = NULL,
																	 @CInvType INT =NULL,
																	 @Car_ID int =NULL,
	@Car_TypeNameA varchar(50) =NULL,
	@Car_TypeNameE varchar(50) =NULL,
	@Car_NameA varchar(50) =NULL,
	@Car_NameE varchar(50) =NULL,
	@PlateNo varchar(50) =NULL,
	@Color varchar(50) =NULL,
	@ModelNo varchar(50) =NULL,
	@Delevery_Date date =NULL,
	@VehiclechassisNumber varchar(100) =NULL,
	@OrderStatus INT =NULL
                                                              )
                                                              AS
                                                              BEGIN
                                                              INSERT INTO T_INVHED(
                                                                     InvId,
                                                                     InvNo,
                                                                     InvTyp,
                                                                     InvCashPay,
                                                                     CusVenNo,
                                                                     CusVenNm,
                                                                     HDat,
                                                                     CusVenAdd,
                                                                     CusVenTel,
                                                                     Remark,
                                                                     GDat,
                                                                     MndNo,
                                                                     SalsManNo,
                                                                     SalsManNam,
                                                                     InvTot,
                                                                     InvTotLocCur,
                                                                     InvDisPrs,
                                                                     InvDisVal,
                                                                     InvDisValLocCur,
                                                                     InvNet,
                                                                     InvNetLocCur,
                                                                     CashPay,
                                                                     CashPayLocCur,
                                                                     IfRet,
                                                                     GadeNo,
                                                                     GadeId,
                                                                     IfDel,
                                                                     RetNo,
                                                                     RetId,
                                                                     InvCstNo,
                                                                     InvCashPayNm,
                                                                     RefNo,
                                                                     InvCost,
                                                                     EstDat,
                                                                     CustPri,
                                                                     ArbTaf,
                                                                     CurTyp,
                                                                     InvCash,
                                                                     ToStore,
                                                                     ToStoreNm,
                                                                     InvQty,
                                                                     EngTaf,
                                                                     IfTrans,
                                                                     CustRep,
                                                                     CustNet,
                                                                     InvWight_T,
                                                                     IfPrint,
                                                                     LTim,
                                                                     CREATED_BY,
                                                                     DATE_CREATED,
                                                                     MODIFIED_BY ,
                                                                     DATE_MODIFIED ,
                                                                     CreditPay ,
                                                                     CreditPayLocCur ,
                                                                     NetworkPay ,
                                                                     NetworkPayLocCur ,
                                                                     CommMnd_Inv ,
                                                                     MndExtrnal ,
                                                                     CompanyID ,
                                                                     InvAddCost ,
                                                                     InvAddCostLoc ,
                                                                     InvAddCostExtrnal ,
                                                                     InvAddCostExtrnalLoc ,
                                                                     IsExtrnalGaid ,
                                                                     ExtrnalCostGaidID ,
                                                                     Puyaid ,
                                                                     Remming ,
                                                                     RoomNo ,
                                                                     OrderTyp ,
                                                                     RoomSts ,
                                                                     chauffeurNo ,
                                                                     RoomPerson ,
                                                                     ServiceValue ,
                                                                     Sts ,
                                                                     PaymentOrderTyp ,
                                                                     AdminLock ,
                                                                     DeleteDate ,
                                                                     DeleteTime ,
                                                                     UserNew ,
                                                                     IfEnter ,
                                                                     InvAddTax ,
                                                                     InvAddTaxlLoc ,
                                                                     IsTaxGaid ,
                                                                     TaxGaidID ,
                                                                     IsTaxUse ,
                                                                     InvValGaidDis ,
                                                                     InvValGaidDislLoc ,
                                                                     IsDisGaid ,
                                                                     DisGaidID1 ,
                                                                     IsDisUse1 ,
                                                                     InvComm ,
                                                                     InvCommLoc ,
                                                                     IsCommGaid ,
                                                                     CommGaidID ,
                                                                     IsCommUse ,
                                                                     IsTaxLines ,
                                                                     IsTaxByTotal ,
                                                                     IsTaxByNet ,
                                                                     TaxByNetValue ,
                                                                     DesPointsValue ,
                                                                     DesPointsValueLocCur ,
                                                                     PointsCount,
                                                                     IsPoints,
                                                                     tailor1 ,
                                                                     tailor2 ,
                                                                     tailor3 ,
                                                                     tailor4 ,
                                                                     tailor5 ,
                                                                     tailor6 ,
                                                                     tailor7 ,
                                                                     tailor8 ,
                                                                     tailor9 ,
                                                                     tailor10 ,
                                                                     tailor11 ,
                                                                     tailor12 ,
                                                                     tailor13 ,
                                                                     tailor14 ,
                                                                     tailor15 ,
                                                                     tailor16 ,
                                                                     tailor17 ,
                                                                     tailor18 ,
                                                                     tailor19 ,
                                                                     tailor20,
                                                                     InvImg,
                                                                     CusVenMob,
                                                                     PriceIncludTax,
																	 CInvType,
																	 Car_ID,
																	 Car_TypeNameA,
																	 Car_TypeNameE,
																	 Car_NameA,
																	 Car_NameE,
																	 PlateNo,
																	 Color,
																	 ModelNo,
																	 Delevery_Date
																	 ,VehiclechassisNumber,
																	 OrderStatus
                                                              )
                                                              VALUES
                                                              (
                                                                    @InvId,
                                                                    @InvNo,
                                                                    @InvTyp,
                                                                    @InvCashPay,
                                                                    @CusVenNo,
                                                                    @CusVenNm,
                                                                    @HDat,
                                                                    @CusVenAdd,
                                                                    @CusVenTel,
                                                                    @Remark,
                                                                    @GDat,
                                                                    @MndNo,
                                                                    @SalsManNo,
                                                                    @SalsManNam,
                                                                    @InvTot,
                                                                    @InvTotLocCur,
                                                                    @InvDisPrs,
                                                                    @InvDisVal,
                                                                    @InvDisValLocCur,
                                                                    @InvNet,
                                                                    @InvNetLocCur,
                                                                    @CashPay,
                                                                    @CashPayLocCur,
                                                                    @IfRet,
                                                                    @GadeNo,
                                                                    @GadeId,
                                                                    @IfDel,
                                                                    @RetNo,
                                                                    @RetId,
                                                                    @InvCstNo,
                                                                    @InvCashPayNm,
                                                                    @RefNo,
                                                                    @InvCost,
                                                                    @EstDat,
                                                                    @CustPri,
                                                                    @ArbTaf,
                                                                    @CurTyp,
                                                                    @InvCash,
                                                                    @ToStore,
                                                                    @ToStoreNm,
                                                                    @InvQty,
                                                                    @EngTaf,
                                                                    @IfTrans,
                                                                    @CustRep,
                                                                    @CustNet,
                                                                    @InvWight_T,
                                                                    @IfPrint,
                                                                    @LTim,
                                                                    @CREATED_BY,
                                                                    @DATE_CREATED,
                                                                    @MODIFIED_BY ,
                                                                    @DATE_MODIFIED ,
                                                                    @CreditPay ,
                                                                    @CreditPayLocCur ,
                                                                    @NetworkPay ,
                                                                    @NetworkPayLocCur ,
                                                                    @CommMnd_Inv ,
                                                                    @MndExtrnal ,
                                                                    @CompanyID ,
                                                                    @InvAddCost ,
                                                                    @InvAddCostLoc ,
                                                                    @InvAddCostExtrnal ,
                                                                    @InvAddCostExtrnalLoc ,
                                                                    @IsExtrnalGaid ,
                                                                    @ExtrnalCostGaidID ,
                                                                    @Puyaid ,
                                                                    @Remming ,
                                                                    @RoomNo ,
                                                                    @OrderTyp ,
                                                                    @RoomSts ,
                                                                    @chauffeurNo ,
                                                                    @RoomPerson ,
                                                                    @ServiceValue ,
                                                                    @Sts ,
                                                                    @PaymentOrderTyp ,
                                                                    @AdminLock ,
                                                                    @DeleteDate ,
                                                                    @DeleteTime ,
                                                                    @UserNew ,
                                                                    @IfEnter ,
                                                                    @InvAddTax ,
                                                                    @InvAddTaxlLoc ,
                                                                    @IsTaxGaid ,
                                                                    @TaxGaidID ,
                                                                    @IsTaxUse ,
                                                                    @InvValGaidDis ,
                                                                    @InvValGaidDislLoc ,
                                                                    @IsDisGaid ,
                                                                    @DisGaidID1 ,
                                                                    @IsDisUse1 ,
                                                                    @InvComm ,
                                                                    @InvCommLoc ,
                                                                    @IsCommGaid ,
                                                                    @CommGaidID ,
                                                                    @IsCommUse ,
                                                                    @IsTaxLines ,
                                                                    @IsTaxByTotal ,
                                                                    @IsTaxByNet ,
                                                                    @TaxByNetValue ,
                                                                    @DesPointsValue ,
                                                                    @DesPointsValueLocCur ,
                                                                    @PointsCount,
                                                                    @IsPoints,
                                                                    @tailor1 ,
                                                                    @tailor2 ,
                                                                    @tailor3 ,
                                                                    @tailor4 ,
                                                                    @tailor5 ,
                                                                    @tailor6 ,
                                                                    @tailor7 ,
                                                                    @tailor8 ,
                                                                    @tailor9 ,
                                                                    @tailor10 ,
                                                                    @tailor11 ,
                                                                    @tailor12 ,
                                                                    @tailor13 ,
                                                                    @tailor14 ,
                                                                    @tailor15 ,
                                                                    @tailor16 ,
                                                                    @tailor17 ,
                                                                    @tailor18 ,
                                                                    @tailor19 ,
                                                                    @tailor20,
                                                                    @InvImg,
                                                                    @CusVenMob,
                                                                    @PriceIncludeTax,
																	@CInvType,
																	@Car_ID,
																	@Car_TypeNameA,
																	@Car_TypeNameE,
																	@Car_NameA,
																	@Car_NameE,
																	@PlateNo,
																	@Color,
																@ModelNo,
																@Delevery_Date,
																@VehiclechassisNumber,
																@OrderStatus
                                                              )
                                                              SELECT @InvHed_ID = SCOPE_IDENTITY()
                                                              RETURN 
                                                              END; 

GO
/****** Object:  StoredProcedure [dbo].[S_T_INVHED_UPDATE]    Script Date: 8/10/2021 10:35:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[S_T_INVHED_UPDATE]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[S_T_INVHED_UPDATE] AS' 
END
GO
ALTER PROCEDURE [dbo].[S_T_INVHED_UPDATE](
                                                                                 @InvHed_ID INT ,
                                                                                 @InvId FLOAT =NULL,
                                                                                 @InvNo VARCHAR (10),
                                                                                 @InvTyp INT =NULL,
                                                                                 @InvCashPay INT =NULL,
                                                                                 @CusVenNo VARCHAR (20)=NULL,
                                                                                 @CusVenNm VARCHAR (50)=NULL,
                                                                                 @CusVenAdd VARCHAR (100)=NULL,
                                                                                 @CusVenTel VARCHAR (30)=NULL,
                                                                                 @Remark VARCHAR (MAX)=NULL,
                                                                                 @HDat VARCHAR (10)=NULL,
                                                                                 @GDat VARCHAR (10)=NULL,
                                                                                 @MndNo INT =NULL,
                                                                                 @SalsManNo VARCHAR (3)=NULL,
                                                                                 @SalsManNam VARCHAR (50)=NULL,
                                                                                 @InvTot FLOAT =NULL,
                                                                                 @InvTotLocCur FLOAT =NULL,
                                                                                 @InvDisPrs FLOAT =NULL,
                                                                                 @InvDisVal FLOAT =NULL,
                                                                                 @InvDisValLocCur FLOAT =NULL,
                                                                                 @InvNet FLOAT =NULL,
                                                                                 @InvNetLocCur FLOAT =NULL,
                                                                                 @CashPay FLOAT =NULL,
                                                                                 @CashPayLocCur FLOAT =NULL,
                                                                                 @IfRet INT =NULL,
                                                                                 @GadeNo FLOAT =NULL,
                                                                                 @GadeId FLOAT =NULL,
                                                                                 @IfDel INT =NULL,
                                                                                 @RetNo VARCHAR (10)=NULL,
                                                                                 @RetId FLOAT =NULL,
                                                                                 @InvCstNo INT =NULL,
                                                                                 @InvCashPayNm VARCHAR (100)=NULL,
                                                                                 @RefNo VARCHAR (20)=NULL,
                                                                                 @InvCost FLOAT =NULL,
                                                                                 @EstDat VARCHAR (10)=NULL,
                                                                                 @CustPri INT =NULL,
                                                                                 @ArbTaf VARCHAR (150)=NULL,
                                                                                 @CurTyp INT =NULL,
                                                                                 @InvCash VARCHAR (20)=NULL,
                                                                                 @ToStore VARCHAR (3)=NULL,
                                                                                 @ToStoreNm VARCHAR (50)=NULL,
                                                                                 @InvQty FLOAT =NULL,
                                                                                 @EngTaf VARCHAR (150)=NULL,
                                                                                 @IfTrans INT =NULL,
                                                                                 @CustRep FLOAT =NULL,
                                                                                 @CustNet FLOAT =NULL,
                                                                                 @InvWight_T FLOAT =NULL,
                                                                                 @IfPrint INT =NULL,
                                                                                 @LTim VARCHAR (10)=NULL,
                                                                                 @CREATED_BY VARCHAR(100) =NULL,
                                                                                 @DATE_CREATED datetime =NULL,
                                                                                 @MODIFIED_BY VARCHAR (100)=NULL,
                                                                                 @DATE_MODIFIED datetime=NULL,
                                                                                 @CreditPay float=NULL,
                                                                                 @CreditPayLocCur float=NULL,
                                                                                 @NetworkPay float=NULL,
                                                                                 @NetworkPayLocCur float=NULL,
                                                                                 @CommMnd_Inv float=NULL,
                                                                                 @MndExtrnal bit=NULL,
                                                                                 @CompanyID int=NULL,
                                                                                 @InvAddCost float=NULL,
                                                                                 @InvAddCostLoc float=NULL,
                                                                                 @InvAddCostExtrnal float=NULL,
                                                                                 @InvAddCostExtrnalLoc float=NULL,
                                                                                 @IsExtrnalGaid bit=NULL,
                                                                                 @ExtrnalCostGaidID float=NULL,
                                                                                 @Puyaid float=NULL,
                                                                                 @Remming float=NULL,
                                                                                 @RoomNo int=NULL,
                                                                                 @OrderTyp int=NULL,
                                                                                 @RoomSts bit=NULL,
                                                                                 @chauffeurNo int=NULL,
                                                                                 @RoomPerson int=NULL,
                                                                                 @ServiceValue float=NULL,
                                                                                 @Sts bit=NULL,
                                                                                 @PaymentOrderTyp int=NULL,
                                                                                 @AdminLock bit=NULL,
                                                                                 @DeleteDate VARCHAR (10)=NULL,
                                                                                 @DeleteTime VARCHAR (10)=NULL,
                                                                                 @UserNew VARCHAR (3)=NULL,
                                                                                 @IfEnter int=NULL,
                                                                                 @InvAddTax float=NULL,
                                                                                 @InvAddTaxlLoc float=NULL,
                                                                                 @IsTaxGaid bit=NULL,
                                                                                 @TaxGaidID float=NULL,
                                                                                 @IsTaxUse bit=NULL,
                                                                                 @InvValGaidDis float=NULL,
                                                                                 @InvValGaidDislLoc float=NULL,
                                                                                 @IsDisGaid bit=NULL,
                                                                                 @DisGaidID1 float=NULL,
                                                                                 @IsDisUse1 bit=NULL,
                                                                                 @InvComm float=NULL,
                                                                                 @InvCommLoc float=NULL,
                                                                                 @IsCommGaid bit=NULL,
                                                                                 @CommGaidID float=NULL,
                                                                                 @IsCommUse bit=NULL,
                                                                                 @IsTaxLines bit=NULL,
                                                                                 @IsTaxByTotal bit=NULL,
                                                                                 @IsTaxByNet bit=NULL,
                                                                                 @TaxByNetValue float=NULL,
                                                                                 @DesPointsValue float=NULL,
																			     @DesPointsValueLocCur float=NULL,
																			     @PointsCount float=NULL,
                                                                                 @IsPoints bit=NULL,
                                                                                 @tailor1 VARCHAR (100)=NULL,
                                                                                 @tailor2 VARCHAR (100)=NULL,
                                                                                 @tailor3 VARCHAR (100)=NULL,
                                                                                 @tailor4 VARCHAR (100)=NULL,
                                                                                 @tailor5 VARCHAR (100)=NULL,
                                                                                 @tailor6 VARCHAR (100)=NULL,
                                                                                 @tailor7 VARCHAR (100)=NULL,
                                                                                 @tailor8 VARCHAR (100)=NULL,
                                                                                 @tailor9 VARCHAR (100)=NULL,
                                                                                 @tailor10 VARCHAR (100)=NULL,
                                                                                 @tailor11 VARCHAR (100)=NULL,
                                                                                 @tailor12 VARCHAR (100)=NULL,
                                                                                 @tailor13 VARCHAR (100)=NULL,
                                                                                 @tailor14 VARCHAR (100)=NULL,
                                                                                 @tailor15 VARCHAR (100)=NULL,
                                                                                 @tailor16 VARCHAR (100)=NULL,
                                                                                 @tailor17 VARCHAR (100)=NULL,
                                                                                 @tailor18 VARCHAR (100)=NULL,
                                                                                 @tailor19 VARCHAR (100)=NULL,
                                                                                 @tailor20 VARCHAR (100)=NULL,
                                                                                 @InvImg VARBINARY(max) =NULL,
                                                                                 @CusVenMob VARCHAR(50) =NULL,
                                                                                 @PriceIncludeTax BIT = NULL,
																				 													 @CInvType INT =NULL,
																	 @Car_ID int =NULL,
	@Car_TypeNameA varchar(50) =NULL,
	@Car_TypeNameE varchar(50) =NULL,
	@Car_NameA varchar(50) =NULL,
	@Car_NameE varchar(50) =NULL,
	@PlateNo varchar(50) =NULL,
	@Color varchar(50) =NULL,
	@ModelNo varchar(50) =NULL,
	@Delevery_Date date =NULL,
	@VehiclechassisNumber Varchar(100) =Null,
	@OrderStatus INT =NULL
                                                                 
                                  )
                                  AS
                                  BEGIN
                                  UPDATE T_INVHED
                                  SET    InvId = @InvId,
                                         InvNo = @InvNo,
                                         InvTyp = @InvTyp,
                                         InvCashPay = @InvCashPay,
                                         CusVenNo = @CusVenNo,
                                         CusVenNm = @CusVenNm,
                                         CusVenAdd = @CusVenAdd,
                                         CusVenTel = @CusVenTel,
                                         Remark = @Remark,
                                         HDat = @HDat,
                                         GDat = @GDat,
                                         MndNo = @MndNo,
                                         SalsManNo = @SalsManNo,
                                         SalsManNam = @SalsManNam,
                                         InvTot = @InvTot,
                                         InvTotLocCur = @InvTotLocCur,
                                         InvDisPrs = @InvDisPrs,
                                         InvDisVal = @InvDisVal,
                                         InvDisValLocCur = @InvDisValLocCur,
                                         InvNet = @InvNet,
                                         InvNetLocCur = @InvNetLocCur,
                                         CashPay = @CashPay,
                                         CashPayLocCur = @CashPayLocCur,
                                         IfRet = @IfRet,
                                         GadeNo = @GadeNo,
                                         GadeId = @GadeId,
                                         IfDel = @IfDel,
                                         RetNo = @RetNo,
                                         RetId = @RetId,
                                         InvCstNo = @InvCstNo,
                                         InvCashPayNm = @InvCashPayNm,
                                         RefNo = @RefNo,
                                         InvCost = @InvCost,
                                         EstDat = @EstDat,
                                         CustPri = @CustPri,
                                         ArbTaf = @ArbTaf,
                                         CurTyp = @CurTyp,
                                         InvCash = @InvCash,
                                         ToStore = @ToStore,
                                         ToStoreNm = @ToStoreNm,
                                         InvQty = @InvQty,
                                         EngTaf = @EngTaf,
                                         IfTrans = @IfTrans,
                                         CustRep = @CustRep,
                                         CustNet = @CustNet,
                                         InvWight_T = @InvWight_T,
                                         IfPrint = @IfPrint,
                                         LTim = @LTim,
                                         MODIFIED_BY = @MODIFIED_BY,
                                         DATE_MODIFIED = @DATE_MODIFIED,
                                                                                 CreditPay = @CreditPay,
                                                                                 CreditPayLocCur = @CreditPayLocCur,
                                                                                 NetworkPay = @NetworkPay,
                                                                                 NetworkPayLocCur = @NetworkPayLocCur,
                                                                                 CommMnd_Inv = @CommMnd_Inv,
                                                                                 MndExtrnal = @MndExtrnal,
                                                                                 CompanyID = @CompanyID,
                                                                                 InvAddCost = @InvAddCost,
                                                                                 InvAddCostLoc = @InvAddCostLoc,
                                                                                 InvAddCostExtrnal = @InvAddCostExtrnal,
                                                                                 InvAddCostExtrnalLoc = @InvAddCostExtrnalLoc,
                                                                                 IsExtrnalGaid = @IsExtrnalGaid,
                                                                                 ExtrnalCostGaidID = @ExtrnalCostGaidID,
                                                                                 Puyaid = @Puyaid,
                                                                                 Remming = @Remming,
                                                                                 RoomNo = @RoomNo,
                                                                                 OrderTyp = @OrderTyp,
                                                                                 RoomSts = @RoomSts,
                                                                                 chauffeurNo = @chauffeurNo,
                                                                                 RoomPerson = @RoomPerson,
                                                                                 ServiceValue = @ServiceValue,
                                                                                 Sts = @Sts,
                                                                                 PaymentOrderTyp = @PaymentOrderTyp,
                                                                                 AdminLock = @AdminLock,
                                                                                 DeleteDate = @DeleteDate,
                                                                                 DeleteTime = @DeleteTime,
                                                                                 UserNew = @UserNew,
                                                                                 IfEnter = @IfEnter,
                                                                                 InvAddTax = @InvAddTax,
                                                                                 InvAddTaxlLoc = @InvAddTaxlLoc,
                                                                                 IsTaxGaid = @IsTaxGaid,
                                                                                 TaxGaidID = @TaxGaidID,
                                                                                 IsTaxUse = @IsTaxUse,
                                                                                 InvValGaidDis = @InvValGaidDis,
                                                                                 InvValGaidDislLoc = @InvValGaidDislLoc,
                                                                                 IsDisGaid = @IsDisGaid,
                                                                                 DisGaidID1 = @DisGaidID1,
                                                                                 IsDisUse1 = @IsDisUse1,
                                                                                 InvComm = @InvComm,
                                                                                 InvCommLoc = @InvCommLoc,
                                                                                 IsCommGaid = @IsCommGaid,
                                                                                 CommGaidID = @CommGaidID,
                                                                                 IsCommUse = @IsCommUse,
                                                                                 IsTaxLines = @IsTaxLines,
                                                                                 IsTaxByTotal = @IsTaxByTotal,
                                                                                 IsTaxByNet = @IsTaxByNet,
                                                                                 TaxByNetValue = @TaxByNetValue,
                                                                                 DesPointsValue = @DesPointsValue ,
																				 DesPointsValueLocCur = @DesPointsValueLocCur ,
																				 PointsCount = @PointsCount,
                                                                                 IsPoints = @IsPoints,
                                                                                 tailor1 = @tailor1 ,
																				 tailor2 = @tailor2,
																				 tailor3 = @tailor3,
																				 tailor4 = @tailor4,
																				 tailor5 = @tailor5,
																				 tailor6 = @tailor6,
																				 tailor7 = @tailor7,
																				 tailor8 = @tailor8,
																				 tailor9 = @tailor9,
																				 tailor10 = @tailor10,
																				 tailor11 = @tailor11,
																				 tailor12 = @tailor12,
																				 tailor13 = @tailor13,
																				 tailor14 = @tailor14,
																				 tailor15 = @tailor15,
																				 tailor16 = @tailor16,
																				 tailor17 = @tailor17,
																				 tailor18 = @tailor18,
																				 tailor19 = @tailor19,
																				 tailor20 = @tailor20,
                                                                                 InvImg   = @InvImg,
                                                                                 CusVenMob = @CusVenMob,
                                                                                 PriceIncludTax =@PriceIncludeTax,
																				 Car_ID=@Car_ID,
																				 Car_TypeNameA=@Car_TypeNameA,
																				 Car_TypeNameE=@Car_TypeNameE,
																				 Car_NameA=@Car_NameA,
																				 Car_NameE=@Car_NameE,
																				 PlateNo=@PlateNo,
																				 color=@Color,
																				 ModelNo=@ModelNo,
																				 Delevery_Date=@Delevery_Date
                                                                                ,VehiclechassisNumber=@VehiclechassisNumber,
																				OrderStatus=@OrderStatus
							 							 WHERE  @InvHed_ID = InvHed_ID
                                  RETURN
                                  END;
GO
/****** Object:  StoredProcedure [dbo].[S_T_Report]    Script Date: 8/10/2021 10:35:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[S_T_Report]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[S_T_Report] AS' 
END
GO



ALTER PROCEDURE [dbo].[S_T_Report](
                    
                   @Tables VARCHAR(Max),
                   @Fields VARCHAR(Max)='*',
				   @Rule VARCHAR(Max)= NULL     
      )
      AS
      BEGIN
      DECLARE @sql AS NVARCHAR(MAX);

      SET @sql = N'SELECT ' + @Fields
      
      + N' FROM ' +@Tables + ' '

	  + CASE WHEN @Rule IS NOT NULL THEN
      + @Rule + ';' ELSE N'' END
      
      EXEC sp_executesql
      @sql,
      N'
      @P_Tables VARCHAR(Max),
      @P_Fields VARCHAR(Max),
	  @P_Rule VARCHAR(Max)'
      
      ,@P_Tables = @Tables
      ,@P_Fields = @Fields
	  ,@P_Rule = @Rule;
      
      RETURN
      END



GO
/****** Object:  StoredProcedure [dbo].[S_T_SINVDET_DELETE]    Script Date: 8/10/2021 10:35:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[S_T_SINVDET_DELETE]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[S_T_SINVDET_DELETE] AS' 
END
GO
ALTER PROCEDURE [dbo].[S_T_SINVDET_DELETE](
                                                                @SInvDet_ID INT 
                                          )
                                          AS
                                          BEGIN
                                            declare @SInvTyp int 
                                            declare @SInvId int
                                            declare @SMndID int
                                            declare @SItemCountMnd int 
                                            declare @SMndKind int 
                                            declare @SRelation int
                                                   
                                            select @SInvId = SInvId from T_SINVDET where SInvDet_ID = @SInvDet_ID;
                                            select @SRelation = InvId from T_INVDET where InvDet_ID = @SInvId;
                                            select @SInvTyp = InvTyp from T_INVHED where InvHed_ID = @SRelation;
                                            select @SMndID = MndNo from T_INVHED where InvHed_ID = @SRelation;
                                            
                                            select @SMndKind = Mnd_Typ from T_Mndob where Mnd_ID = @SMndID;
                                            
                                            if(@SInvTyp != 7 and @SInvTyp != 8 and @SInvTyp != 9 and @SInvTyp != 21)
                                            begin
                                              if(@SMndKind != 1 or @SMndKind is null)
		                                          begin
			                                          UPDATE T_Items SET T_Items.OpenQty = T_Items.OpenQty - T_SINVDET.SRealQty 
			                                          From T_SINVDET Left Join T_Items ON (T_SINVDET.SItmNo = T_Items.Itm_No) 
			                                          where (SInvDet_ID = @SInvDet_ID) and (T_SINVDET.SItmTyp <> 3) and (T_SINVDET.SItmTyp <> 2);
			                                          UPDATE T_STKSQTY SET T_STKSQTY.stkQty = T_STKSQTY.stkQty - T_SINVDET.SRealQty 
			                                          From T_SINVDET Left Join T_STKSQTY ON (T_SINVDET.SItmNo = T_STKSQTY.itmNo) AND (T_SINVDET.SStoreNo = T_STKSQTY.storeNo)  
			                                          where @SInvDet_ID = SInvDet_ID and T_SINVDET.SItmTyp <> 3 and (T_SINVDET.SItmTyp <> 2);
                                        			  
			                                          UPDATE T_QTYEXP SET T_QTYEXP.stkQty = T_QTYEXP.stkQty - T_SINVDET.SRealQty 
			                                          From  T_SINVDET Left Join T_QTYEXP ON (T_SINVDET.SItmNo = T_QTYEXP.itmNo) AND (T_SINVDET.SStoreNo = T_QTYEXP.storeNo) AND (T_SINVDET.SDatExper = T_QTYEXP.DatExper)
			                                          where @SInvDet_ID = SInvDet_ID and T_SINVDET.SItmTyp <> 3 and (T_SINVDET.SItmTyp <> 2);
		                                          end
                                              if(@SInvTyp = 14)
		                                          begin
			                                          UPDATE T_STKSQTY SET T_STKSQTY.stkInt = T_STKSQTY.stkInt - T_SINVDET.SRealQty 
			                                          From T_SINVDET Left Join T_STKSQTY ON (T_SINVDET.SItmNo = T_STKSQTY.itmNo) AND (T_SINVDET.SStoreNo = T_STKSQTY.storeNo)  
			                                          where @SInvDet_ID = SInvDet_ID and T_SINVDET.SItmTyp <> 3 and (T_SINVDET.SItmTyp <> 2);
		                                          end
                                             if(@SInvTyp = 17)
	                                         begin
	 		                                          UPDATE T_Items SET T_Items.OpenQty = T_Items.OpenQty - T_SINVDET.SRealQty 
			                                          From T_SINVDET Left Join T_Items ON (T_SINVDET.SItmNo = T_Items.Itm_No) 
			                                          where (SInvDet_ID = @SInvDet_ID) and (T_SINVDET.SItmTyp <> 3) and (T_SINVDET.SItmTyp <> 2);
			                                          UPDATE T_STKSQTY SET T_STKSQTY.stkQty = T_STKSQTY.stkQty - T_SINVDET.SRealQty 
			                                          From T_SINVDET Left Join T_STKSQTY ON (T_SINVDET.SItmNo = T_STKSQTY.itmNo) AND (T_SINVDET.SStoreNo = T_STKSQTY.storeNo)  
			                                          where @SInvDet_ID = SInvDet_ID and T_SINVDET.SItmTyp <> 3 and (T_SINVDET.SItmTyp <> 2);
                                        			  
			                                          UPDATE T_QTYEXP SET T_QTYEXP.stkQty = T_QTYEXP.stkQty - T_SINVDET.SRealQty 
			                                          From  T_SINVDET Left Join T_QTYEXP ON (T_SINVDET.SItmNo = T_QTYEXP.itmNo) AND (T_SINVDET.SStoreNo = T_QTYEXP.storeNo) AND (T_SINVDET.SDatExper = T_QTYEXP.DatExper)
			                                          where @SInvDet_ID = SInvDet_ID and T_SINVDET.SItmTyp <> 3 ;
                                        			  
	                                             -- select @SMndID = MndNo from T_INVHED where InvHed_ID = @SRelation;
		                                         -- UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty - abs(T_SINVDET.SRealQty)
		                                         -- From T_SINVDET Left Join T_StoreMnd ON (T_SINVDET.SItmNo = T_StoreMnd.itmNo) AND (T_SINVDET.SStoreNo = T_StoreMnd.storeNo)  
		                                         -- where @SInvDet_ID = SInvDet_ID and T_SINVDET.SItmTyp <> 3 and (T_SINVDET.SItmTyp <> 2) and T_StoreMnd.MndNo = @SMndID ;
                                             end
                                             
                                             if(@SInvTyp = 20)
	                                         begin
	       	                                          UPDATE T_Items SET T_Items.OpenQty = T_Items.OpenQty - T_SINVDET.SRealQty 
			                                          From T_SINVDET Left Join T_Items ON (T_SINVDET.SItmNo = T_Items.Itm_No) 
			                                          where (SInvDet_ID = @SInvDet_ID) and (T_SINVDET.SItmTyp <> 3) and (T_SINVDET.SItmTyp <> 2);
			                                          UPDATE T_STKSQTY SET T_STKSQTY.stkQty = T_STKSQTY.stkQty - T_SINVDET.SRealQty 
			                                          From T_SINVDET Left Join T_STKSQTY ON (T_SINVDET.SItmNo = T_STKSQTY.itmNo) AND (T_SINVDET.SStoreNo = T_STKSQTY.storeNo)  
			                                          where @SInvDet_ID = SInvDet_ID and T_SINVDET.SItmTyp <> 3 and (T_SINVDET.SItmTyp <> 2);
                                        			  
			                                          UPDATE T_QTYEXP SET T_QTYEXP.stkQty = T_QTYEXP.stkQty - T_SINVDET.SRealQty 
			                                          From  T_SINVDET Left Join T_QTYEXP ON (T_SINVDET.SItmNo = T_QTYEXP.itmNo) AND (T_SINVDET.SStoreNo = T_QTYEXP.storeNo) AND (T_SINVDET.SDatExper = T_QTYEXP.DatExper)
			                                          where @SInvDet_ID = SInvDet_ID and T_SINVDET.SItmTyp <> 3 and (T_SINVDET.SItmTyp <> 2);
                                        			  
	                                            --  select @SMndID = MndNo from T_INVHED where InvHed_ID = @SRelation;
		                                        --  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty + T_SINVDET.SRealQty 
		                                        --  From T_SINVDET Left Join T_StoreMnd ON (T_SINVDET.SItmNo = T_StoreMnd.itmNo) AND (T_SINVDET.SStoreNo = T_StoreMnd.storeNo)  
		                                        --  where @SInvDet_ID = SInvDet_ID and T_SINVDET.SItmTyp <> 3 and (T_SINVDET.SItmTyp <> 2) and T_StoreMnd.MndNo = @SMndID ;
                                             end
                                            end
                                        
                                          DELETE FROM T_SINVDET
                                          WHERE      @SInvDet_ID = SInvDet_ID   
                                          RETURN
                                          END
GO
/****** Object:  StoredProcedure [dbo].[S_T_SINVDET_INSERT]    Script Date: 8/10/2021 10:35:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[S_T_SINVDET_INSERT]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[S_T_SINVDET_INSERT] AS' 
END
GO
 ALTER PROCEDURE [dbo].[S_T_SINVDET_INSERT](   
                                                 @SInvDet_ID INT OUTPUT,
                                                 @SInvNo VARCHAR (10)=NULL,
                                                 @SInvId INT =NULL,
                                                 @SInvSer INT =NULL,
                                                 @SItmNo VARCHAR (50)=NULL,
                                                 @SCost FLOAT =NULL,
                                                 @SQty FLOAT =NULL,
                                                 @SItmDes VARCHAR (50)=NULL,
                                                 @SItmUnt VARCHAR (100)=NULL,
                                                 @SItmDesE VARCHAR (50)=NULL,
                                                 @SItmUntE VARCHAR (100)=NULL,
                                                 @SItmUntPak FLOAT =NULL,
                                                 @SStoreNo INT=NULL,
                                                 @SPrice FLOAT =NULL,
                                                 @SAmount FLOAT =NULL,
                                                 @SRealQty FLOAT =NULL,
                                                 @SitmInvDsc FLOAT =NULL,
                                                 @SDatExper VARCHAR (11)=NULL,
                                                 @SItmDis FLOAT =NULL,
                                                 @SItmTyp INT =NULL,
                                                 @SItmIndex INT =NULL,
                                                 @SItmWight FLOAT =NULL,
                                                 @SItmWight_T FLOAT =NULL,
                                                 @SQtyDef FLOAT =NULL,
                                                 @SPriceDef FLOAT =NULL,
                                                 @SInvIdHEAD INT =NULL,
                                                 @SItmTax FLOAT =NULL  
                                                 
                                          )
                                          AS
                                          BEGIN
                                          INSERT INTO T_SINVDET(
                                                 SInvNo,
                                                 SInvId,
                                                 SInvSer,
                                                 SItmNo,
                                                 SCost,
                                                 SQty,
                                                 SItmDes,
                                                 SItmUnt,
                                                 SItmDesE,
                                                 SItmUntE,
                                                 SItmUntPak,
                                                 SStoreNo,
                                                 SPrice,
                                                 SAmount,
                                                 SRealQty,
                                                 SitmInvDsc,
                                                 SDatExper,
                                                 SItmDis,
                                                 SItmTyp,
                                                 SItmIndex,
                                                 SItmWight,
                                                 SItmWight_T,
                                                 SQtyDef,
                                                 SPriceDef,
                                                 SInvIdHEAD,
                                                 SItmTax
                                          )
                                          VALUES
                                          (
                                                @SInvNo,
                                                @SInvId,
                                                @SInvSer,
                                                @SItmNo,
                                                @SCost,
                                                @SQty,
                                                @SItmDes,
                                                @SItmUnt,
                                                @SItmDesE,
                                                @SItmUntE,
                                                @SItmUntPak,
                                                @SStoreNo,
                                                @SPrice,
                                                @SAmount,
                                                @SRealQty,
                                                @SitmInvDsc,
                                                @SDatExper,
                                                @SItmDis,
                                                @SItmTyp,
                                                @SItmIndex,
                                                @SItmWight,
                                                @SItmWight_T,
                                                @SQtyDef,
                                                @SPriceDef,
                                                @SInvIdHEAD,
                                                @SItmTax
                                          )
                                          SELECT @SInvDet_ID = SCOPE_IDENTITY()
                                                declare @SItemCount int  
                                                declare @SInvTyp int
                                                declare @SMndID int
                                                declare @SItemCountMnd int 
                                                declare @SRelation int
                                                   
                                                select @SRelation = InvId from T_INVDET where InvDet_ID = @SInvId;
                                                select @SItemCount = Count(*) from T_STKSQTY where itmNo = @SItmNo and storeNo =@SStoreNo;
                                                select @SInvTyp = InvTyp from T_INVHED where InvHed_ID = @SRelation;
                                                if((@SInvTyp != 7 and @SInvTyp != 8 and @SInvTyp != 9 and @SInvTyp != 21) and @SItmTyp <> 3 and @SItmTyp <> 2)
                                                begin
                                                    Update T_Items SET OpenQty = OpenQty+@SRealQty WHERE Itm_No = @SItmNo;
                                                    if(@SItemCount > 0)
                                                    begin
                                                    Update T_STKSQTY SET stkQty = stkQty+@SRealQty WHERE itmNo = @SItmNo and storeNo = @SStoreNo;
                                                    end
                                                    if(@SItemCount = 0)
                                                    begin 
                                                    INSERT INTO T_STKSQTY(itmNo,storeNo,stkQty,stkInt) VALUES(@SItmNo,@SStoreNo,@SRealQty,0);
                                                    END
                                                    if(@SInvTyp = 14)
                                                    begin
                                                        Update T_STKSQTY SET stkInt = stkInt+@SRealQty WHERE itmNo = @SItmNo and storeNo = @SStoreNo;
                                                    end
                                                    select @SItemCount = Count(*) from T_QTYEXP where itmNo = @SItmNo and storeNo =@SStoreNo and DatExper = @SDatExper;
                                                    if(@SItemCount > 0 and @SDatExper <> '')
                                                    begin
                                                    Update T_QTYEXP SET stkQty = stkQty+@SRealQty WHERE itmNo = @SItmNo and storeNo = @SStoreNo and DatExper = @SDatExper;
                                                    end
                                                    if(@SItemCount = 0 and @SDatExper <> '')
                                                    begin 
                                                    INSERT INTO T_QTYEXP(itmNo,storeNo,DatExper,stkQty) VALUES(@SItmNo,@SStoreNo,@SDatExper,@SRealQty);
                                                    END
--                                                    if(@SInvTyp = 17)
--                                                        begin
--                                                         select @SMndID = MndNo from T_INVHED where InvHed_ID = @SRelation;
--                                                            select @SItemCountMnd = Count(*) from T_StoreMnd where itmNo = @SItmNo and storeNo =@SStoreNo and MndNo = @SMndID;
--                                                                    if(@SItemCountMnd > 0)
--                                                                    begin
--                                                                         Update T_StoreMnd SET stkQty = stkQty + abs(@SRealQty) WHERE itmNo = @SItmNo and storeNo = @SStoreNo and MndNo = @SMndID;
--                                                                    end
--
--                                                                    if(@SItemCountMnd = 0)
--                                                                    begin 
--                                                                         INSERT INTO T_StoreMnd(itmNo,storeNo,stkQty,stkInt,MndNo) VALUES(@SItmNo,@SStoreNo,abs(@SRealQty),0,@SMndID);
--                                                                    END
--                                                        end	
--                                                    if(@SInvTyp = 20)
--                                                        begin
--                                                         select @SMndID = MndNo from T_INVHED where InvHed_ID = @SRelation;
--                                                            select @SItemCountMnd = Count(*) from T_StoreMnd where itmNo = @SItmNo and storeNo =@SStoreNo and MndNo = @SMndID;
--                                                                    if(@SItemCountMnd > 0)
--                                                                    begin
--                                                                         Update T_StoreMnd SET stkQty = stkQty + (-@SRealQty) WHERE itmNo = @SItmNo and storeNo = @SStoreNo and MndNo = @SMndID;
--                                                                    end
--
--                                                                    if(@SItemCountMnd = 0)
--                                                                    begin 
--                                                                         INSERT INTO T_StoreMnd(itmNo,storeNo,stkQty,stkInt,MndNo) VALUES(@SItmNo,@SStoreNo,-@SRealQty,0,@SMndID);
--                                                                    END
--                                                        end
                                                end
                                              RETURN
                                              END
GO
/****** Object:  StoredProcedure [dbo].[SqlQueryNotificationStoredProcedure-fe8281da-7d95-4889-87a0-2d3d2bc39ff4]    Script Date: 8/10/2021 10:35:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SqlQueryNotificationStoredProcedure-fe8281da-7d95-4889-87a0-2d3d2bc39ff4]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SqlQueryNotificationStoredProcedure-fe8281da-7d95-4889-87a0-2d3d2bc39ff4] AS' 
END
GO
ALTER PROCEDURE [dbo].[SqlQueryNotificationStoredProcedure-fe8281da-7d95-4889-87a0-2d3d2bc39ff4] AS BEGIN BEGIN TRANSACTION; RECEIVE TOP(0) conversation_handle FROM [SqlQueryNotificationService-fe8281da-7d95-4889-87a0-2d3d2bc39ff4]; IF (SELECT COUNT(*) FROM [SqlQueryNotificationService-fe8281da-7d95-4889-87a0-2d3d2bc39ff4] WHERE message_type_name = 'http://schemas.microsoft.com/SQL/ServiceBroker/DialogTimer') > 0 BEGIN DROP SERVICE [SqlQueryNotificationService-fe8281da-7d95-4889-87a0-2d3d2bc39ff4]; DROP QUEUE [SqlQueryNotificationService-fe8281da-7d95-4889-87a0-2d3d2bc39ff4]; DROP PROCEDURE [SqlQueryNotificationStoredProcedure-fe8281da-7d95-4889-87a0-2d3d2bc39ff4]; END COMMIT TRANSACTION; END
GO
/****** Object:  StoredProcedure [dbo].[UpdateBalance]    Script Date: 8/10/2021 10:35:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateBalance]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[UpdateBalance] AS' 
END
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[UpdateBalance]
	-- Add the parameters for the stored procedure here
	@NewCredit decimal,
	@NewDebit decimal,
	@AccountNumber VARCHAR(50)
AS
BEGIN
	DECLARE @Amount1 decimal, @Amount2 decimal, @Amount3 decimal;

select @Amount1 = Debit, @Amount2 = Credit, @Amount3 = Balance from T_AccDef where AccDef_No = @AccountNumber

update T_AccDef SET Credit = Credit+@NewCredit, 
					Debit = Debit + @NewDebit,
					Balance = Balance+@NewCredit-@NewDebit
				WHERE AccDef_No = @AccountNumber;

END


GO
