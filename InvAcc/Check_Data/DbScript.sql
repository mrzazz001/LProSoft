
USE [master]
GO
/****** Object:  Database [PROSOFT]    Script Date: 08/15/2014 07:50:27 ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'PROSOFT')
BEGIN
CREATE DATABASE [PROSOFT] ON  PRIMARY 
( NAME = N'PROSOFT', FILENAME = N'Path1' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PROSOFT_log', FILENAME = N'Path2' , SIZE = 4224KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
END
GO
ALTER DATABASE [PROSOFT] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PROSOFT].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PROSOFT] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [PROSOFT] SET ANSI_NULLS OFF
GO
ALTER DATABASE [PROSOFT] SET ANSI_PADDING OFF
GO
ALTER DATABASE [PROSOFT] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [PROSOFT] SET ARITHABORT OFF
ALTER DATABASE [PROSOFT] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PROSOFT] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PROSOFT] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PROSOFT] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PROSOFT] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PROSOFT] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PROSOFT] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PROSOFT] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PROSOFT] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PROSOFT] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PROSOFT] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PROSOFT] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PROSOFT] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PROSOFT] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PROSOFT] SET RECOVERY FULL 
GO
ALTER DATABASE [PROSOFT] SET  MULTI_USER 
GO
ALTER DATABASE [PROSOFT] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PROSOFT] SET DB_CHAINING OFF 
GO
USE [PROSOFT]
GO

/****** Object:  Table [dbo].[cod]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cod](
	[cod] [int] NOT NULL,
 CONSTRAINT [PK_cod] PRIMARY KEY CLUSTERED 
(
	[cod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_AccCat]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_AccCat](
	[AccCat_ID] [int] IDENTITY(1,1) NOT NULL,
	[AccCat_No] [varchar](30) NULL,
	[Arb_Des] [varchar](100) NULL,
	[Eng_Des] [varchar](100) NULL,
	[CompanyID] [int] NULL,
 CONSTRAINT [PK_T_AccCat] PRIMARY KEY CLUSTERED 
(
	[AccCat_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_AccDef]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_AccDef](
	[AccDef_ID] [int] IDENTITY(1,1) NOT NULL,
	[AccDef_No] [varchar](30) NOT NULL,
	[Arb_Des] [varchar](100) NULL,
	[Eng_Des] [varchar](100) NULL,
	[ParAcc] [varchar](12) NULL,
	[Lev] [int] NULL,
	[Typ] [varchar](4) NULL,
	[AccCat] [int] NULL,
	[DC] [int] NULL,
	[Sts] [int] NULL,
	[Debit] [float] NULL,
	[Credit] [float] NULL,
	[Balance] [float] NULL,
	[Trn] [int] NULL,
	[City] [varchar](30) NULL,
	[Email] [varchar](50) NULL,
	[Telphone1] [varchar](30) NULL,
	[Telphone2] [varchar](30) NULL,
	[Fax] [varchar](30) NULL,
	[Mobile] [varchar](30) NULL,
	[MaxLemt] [float] NULL,
	[DesPers] [varchar](10) NULL,
	[StrAm] [int] NULL,
	[Adders] [varchar](100) NULL,
	[Mnd] [int] NULL,
	[Price] [int] NULL,
	[zipCod] [varchar](30) NULL,
	[PersonalNm] [varchar](30) NULL,
	[RessonStoped] [varchar](30) NULL,
	[StopedState] [bit] NULL,
	[CompanyID] [int] NULL,
	[StopInvTyp] [int] NULL,
	[DateAppointment] [varchar](10) NULL,
	[ID_Date] [varchar](10) NULL,
	[ID_DateEnd] [varchar](10) NULL,
	[Passport_Date] [varchar](10) NULL,
	[Insurance_Date] [varchar](10) NULL,
	[Passport_DateEnd] [varchar](10) NULL,
	[Insurance_DateEnd] [varchar](10) NULL,
	[ID_No] [varchar](15) NULL,
	[Passport_No] [varchar](15) NULL,
	[Insurance_No] [varchar](15) NULL,
	[ID_From] [varchar](50) NULL,
	[Passport_From] [varchar](50) NULL,
	[Insurance_From] [varchar](50) NULL,
	[MainSal] [float] NULL,
	[BankComm] [float] NULL,
	[TaxNo] [varchar](50) NULL,
	[TotPoints] [float] NULL,
	[MaxDisCust] [float] NULL,
	[vColNum1] [float] NULL,
	[vColNum2] [float] NULL,
	[vColStr1] [varchar](250) NULL,
	[vColStr2] [varchar](250) NULL,
	[vColStr3] [varchar](250) NULL,
	[DepreciationPercent] [float] NULL,
	[ProofAcc] [varchar](30) NULL,
	[RelayAcc] [varchar](30) NULL,
 CONSTRAINT [PK_T_AccDef] PRIMARY KEY CLUSTERED 
(
	[AccDef_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Add]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Add](
	[Add_ID] [varchar](40) NOT NULL,
	[warnNo] [int] NOT NULL,
	[EmpID] [varchar](40) NULL,
	[warnDate] [varchar](10) NULL,
	[SalDate] [varchar](10) NULL,
	[CalculateNo] [int] NULL,
	[AddTyp] [int] NULL,
	[DayOfMonth] [int] NULL,
	[CountDay] [float] NULL,
	[AddValue] [float] NULL,
	[AddTotaly] [float] NULL,
	[Note] [varchar](250) NULL,
	[IFState] [bit] NULL,
	[MinuteTyp] [bit] NULL,
 CONSTRAINT [PK_T_Add_1] PRIMARY KEY CLUSTERED 
(
	[warnNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_AddTyp]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_AddTyp](
	[AddTyp_No] [int] NOT NULL,
	[NameA] [varchar](20) NULL,
	[NameE] [varchar](20) NULL,
 CONSTRAINT [PK_T_AddTyp] PRIMARY KEY CLUSTERED 
(
	[AddTyp_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Advances]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Advances](
	[Advances_ID] [varchar](40) NOT NULL,
	[Advances_No] [int] NOT NULL,
	[ResolutionNo] [varchar](10) NULL,
	[ResolutionDate] [varchar](10) NULL,
	[EmpID] [varchar](40) NULL,
	[Salary] [float] NULL,
	[SalDate] [varchar](10) NULL,
	[ValueAdvances] [float] NULL,
	[Remaining] [float] NULL,
	[TotalPremiums] [int] NULL,
	[ValuePremium] [float] NULL,
	[ValuePremiumEdit] [float] NULL,
	[Note] [varchar](250) NULL,
	[LoanAcc] [varchar](30) NULL,
	[fGUID] [varchar](40) NULL,
	[AccountID] [varchar](30) NULL,
	[BankBR] [varchar](30) NULL,
	[CostCenterEmp] [int] NULL,
	[AutoDisFromSalary] [bit] NULL,
	[AccID] [bit] NULL,
	[GadeId] [float] NULL,
 CONSTRAINT [PK_T_Advances_1] PRIMARY KEY CLUSTERED 
(
	[Advances_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_AinNatural]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_AinNatural](
	[AinNatural_ID] [varchar](40) NOT NULL,
	[AinNatural_No] [int] NOT NULL,
	[NameA] [varchar](30) NULL,
	[NameE] [varchar](30) NULL,
	[Note] [varchar](50) NULL,
 CONSTRAINT [PK_T_AinNatural] PRIMARY KEY CLUSTERED 
(
	[AinNatural_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_AinsData]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_AinsData](
	[AinID] [int] IDENTITY(1,1) NOT NULL,
	[AinNo] [varchar](100) NOT NULL,
	[EqarID] [int] NOT NULL,
	[AinTyp] [int] NOT NULL,
	[AinNature] [int] NOT NULL,
	[AinStatus] [int] NULL,
	[RentOfYear] [float] NULL,
	[EyeValue] [float] NULL,
	[EyeDetail] [varchar](750) NULL,
 CONSTRAINT [PK_T_Ain] PRIMARY KEY CLUSTERED 
(
	[AinID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_AinTyp]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_AinTyp](
	[AinTyp_ID] [varchar](40) NOT NULL,
	[AinTyp_No] [int] NOT NULL,
	[NameA] [varchar](30) NULL,
	[NameE] [varchar](30) NULL,
	[Note] [varchar](50) NULL,
 CONSTRAINT [PK_T_AinTyp] PRIMARY KEY CLUSTERED 
(
	[AinTyp_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_AlarmTenant]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_AlarmTenant](
	[AlarmTenantID] [int] IDENTITY(1,1) NOT NULL,
	[AlarmTenantNo] [int] NOT NULL,
	[AlarmDateG] [varchar](10) NOT NULL,
	[AlarmDateH] [varchar](10) NOT NULL,
	[tenant_ID] [int] NOT NULL,
	[AlarmSubject] [varchar](100) NOT NULL,
	[AlarmDetail] [varchar](1500) NULL,
	[AlarmAdmin] [varchar](100) NULL,
 CONSTRAINT [PK_T_AlarmTenant] PRIMARY KEY CLUSTERED 
(
	[AlarmTenantNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Attend]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Attend](
	[Attend_ID] [varchar](40) NOT NULL,
	[EmpID] [varchar](40) NULL,
	[Day_No] [int] NULL,
	[Periods] [int] NULL,
	[Time1] [varchar](10) NULL,
	[TimeAllow1] [varchar](10) NULL,
	[LeaveTime1] [varchar](10) NULL,
	[Time2] [varchar](10) NULL,
	[TimeAlow2] [varchar](10) NULL,
	[LeaveTime2] [varchar](10) NULL,
 CONSTRAINT [PK_T_Attend] PRIMARY KEY CLUSTERED 
(
	[Attend_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_AttendOperat]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_AttendOperat](
	[AttendOperat_ID] [varchar](40) NOT NULL,
	[EmpID] [varchar](40) NULL,
	[Day] [int] NULL,
	[Date] [varchar](10) NULL,
	[ComeTime] [varchar](20) NULL,
	[LateTime] [float] NULL,
	[Time1] [varchar](20) NULL,
	[Time2] [varchar](20) NULL,
	[LeaveTime] [varchar](20) NULL,
	[LeaveTime2] [varchar](20) NULL,
	[Note] [varchar](50) NULL,
	[Operation] [varchar](10) NULL,
	[Usr_No] [int] NULL,
	[DateEdit] [varchar](10) NULL,
	[ProjectNo] [int] NULL,
 CONSTRAINT [PK_T_AttendOperat] PRIMARY KEY CLUSTERED 
(
	[AttendOperat_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Authorization]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Authorization](
	[Authorization_ID] [varchar](40) NOT NULL,
	[Authorization_No] [int] NOT NULL,
	[Date] [varchar](10) NULL,
	[EmpID] [varchar](40) NULL,
	[ExitTime] [varchar](20) NULL,
	[BackTime] [varchar](20) NULL,
	[reason] [varchar](250) NULL,
	[Note] [varchar](250) NULL,
	[RTime] [varchar](10) NULL,
	[IFState] [bit] NULL,
 CONSTRAINT [PK_T_Authorization] PRIMARY KEY CLUSTERED 
(
	[Authorization_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Bank]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Bank](
	[Bank_ID] [varchar](40) NOT NULL,
	[Bank_No] [int] NOT NULL,
	[Cod] [varchar](50) NULL,
	[NameA] [varchar](50) NULL,
	[NameE] [varchar](50) NULL,
	[Note] [varchar](250) NULL,
 CONSTRAINT [PK_T_Bank] PRIMARY KEY CLUSTERED 
(
	[Bank_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_BankPeaper]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_BankPeaper](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PageNo] [varchar](20) NULL,
	[CustAcc] [varchar](30) NULL,
	[BankAcc] [varchar](30) NULL,
	[BranchAcc] [varchar](30) NULL,
	[PageDate] [varchar](50) NULL,
	[PageDatePay] [varchar](50) NULL,
	[Amount] [float] NULL,
	[PageType] [bit] NULL,
	[vTyp] [bit] NULL,
	[PayState] [int] NULL,
	[gdID] [int] NULL,
	[IfDel] [int] NULL,
	[gdTyp] [int] NULL,
	[gdUser] [varchar](3) NULL,
	[CompanyID] [int] NULL,
 CONSTRAINT [PK_T_BankPeaper] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_BirthPlace]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_BirthPlace](
	[BirthPlaceNo] [int] NOT NULL,
	[NameA] [varchar](20) NULL,
	[NameE] [varchar](20) NULL,
 CONSTRAINT [PK_T_BirthPlace] PRIMARY KEY CLUSTERED 
(
	[BirthPlaceNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_BlackList]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_BlackList](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CustNum] [varchar](50) NOT NULL,
	[CustNam] [varchar](250) NULL,
	[IdNo] [varchar](100) NULL,
	[LecnId] [varchar](100) NULL,
	[Dis] [varchar](100) NULL,
 CONSTRAINT [PK_T_BlackList] PRIMARY KEY CLUSTERED 
(
	[CustNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_BloodTyp]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_BloodTyp](
	[BloodTyp_No] [int] NOT NULL,
	[NameA] [varchar](10) NULL,
	[NameE] [varchar](10) NULL,
 CONSTRAINT [PK_T_BloodTyp] PRIMARY KEY CLUSTERED 
(
	[BloodTyp_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Boss]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Boss](
	[Boss_ID] [varchar](40) NOT NULL,
	[Boss_No] [int] NOT NULL,
	[NameA] [varchar](30) NULL,
	[NameE] [varchar](30) NULL,
	[Note] [varchar](250) NULL,
 CONSTRAINT [PK_T_Boss] PRIMARY KEY CLUSTERED 
(
	[Boss_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_CallPhone]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_CallPhone](
	[Phone_ID] [varchar](40) NOT NULL,
	[Phone_No] [int] NOT NULL,
	[PhoneDate] [varchar](10) NULL,
	[EmpID] [varchar](40) NULL,
	[SalDate] [varchar](10) NULL,
	[PhoneValue] [float] NULL,
	[Note] [varchar](250) NULL,
	[IFState] [bit] NULL,
 CONSTRAINT [PK_T_CallPhone] PRIMARY KEY CLUSTERED 
(
	[Phone_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_CarCheckPIC]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_CarCheckPIC](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[INVHED_ID] [varchar](max) NULL,
	[Pic_1] [image] NULL,
	[Pic_2] [image] NULL,
	[Pic_3] [image] NULL,
	[Pic_4] [image] NULL,
	[Pic_5] [image] NULL,
 CONSTRAINT [PK_T_CarCheckPIC] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_CarNames]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_CarNames](
	[Car_ID] [varchar](40) NOT NULL,
	[Car_No] [int] NOT NULL,
	[NameA] [varchar](50) NULL,
	[NameE] [varchar](50) NULL,
	[Note] [varchar](250) NULL,
	[CarType] [int] NULL,
 CONSTRAINT [PK_T_CarNames] PRIMARY KEY CLUSTERED 
(
	[Car_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Cars]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Cars](
	[Car_ID] [varchar](40) NOT NULL,
	[Car_No] [int] NOT NULL,
	[NameA] [varchar](50) NULL,
	[NameE] [varchar](50) NULL,
	[Model] [varchar](20) NULL,
	[PlateNo] [varchar](20) NULL,
	[Color] [varchar](30) NULL,
	[Note] [varchar](250) NULL,
	[CarType] [int] NULL,
	[FormNo] [varchar](20) NULL,
	[FormBeginDate] [varchar](20) NULL,
	[FormEndDate] [varchar](20) NULL,
	[AllownceNo] [varchar](20) NULL,
	[AllownceBeginDate] [varchar](20) NULL,
	[AllownceEndDate] [varchar](20) NULL,
	[AllownceName] [varchar](40) NULL,
	[PlayCardNo] [varchar](20) NULL,
	[PlayCardBeginDate] [varchar](20) NULL,
	[PlayCardEndDate] [varchar](20) NULL,
	[CompanyID] [int] NULL,
	[EmpID] [varchar](40) NULL,
 CONSTRAINT [PK_T_Cars] PRIMARY KEY CLUSTERED 
(
	[Car_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_CarTyp]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_CarTyp](
	[CarTyp_ID] [varchar](40) NOT NULL,
	[CarTyp_No] [int] NOT NULL,
	[NameA] [varchar](50) NULL,
	[NameE] [varchar](50) NULL,
	[Note] [varchar](250) NULL,
 CONSTRAINT [PK_T_CarTyp] PRIMARY KEY CLUSTERED 
(
	[CarTyp_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_CATEGORY]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_CATEGORY](
	[CAT_ID] [int] IDENTITY(1,1) NOT NULL,
	[CAT_No] [varchar](30) NULL,
	[Arb_Des] [varchar](100) NULL,
	[Eng_Des] [varchar](100) NULL,
	[CompanyID] [int] NULL,
	[TotalPurchaes] [float] NULL,
	[TotalPoint] [float] NULL,
	[CAT_Symbol] [varchar](100) NULL,
 CONSTRAINT [PK_T_CATERY] PRIMARY KEY CLUSTERED 
(
	[CAT_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Chauffeur]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Chauffeur](
	[chauffeur_ID] [int] IDENTITY(1,1) NOT NULL,
	[chauffeur_No] [varchar](30) NULL,
	[Arb_Des] [varchar](100) NULL,
	[Eng_Des] [varchar](100) NULL,
	[chauffeurSts] [int] NULL,
	[CompanyID] [int] NULL,
 CONSTRAINT [PK_T_Driv] PRIMARY KEY CLUSTERED 
(
	[chauffeur_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_City]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_City](
	[City_ID] [varchar](40) NOT NULL,
	[City_No] [int] NOT NULL,
	[NameA] [varchar](30) NULL,
	[NameE] [varchar](30) NULL,
	[Note] [varchar](250) NULL,
 CONSTRAINT [PK_T_City] PRIMARY KEY CLUSTERED 
(
	[City_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Colors]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Colors](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Color_Name] [varchar](50) NULL,
	[Color_NameE] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Commentary]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Commentary](
	[Commentary_ID] [varchar](40) NOT NULL,
	[warnNo] [int] NOT NULL,
	[EmpID] [varchar](40) NULL,
	[warnDate] [varchar](10) NULL,
	[SalDate] [varchar](10) NULL,
	[Value] [float] NULL,
	[Note] [varchar](250) NULL,
	[IFState] [bit] NULL,
	[treatmentNo] [int] NULL,
	[CommentaryName] [varchar](40) NULL,
 CONSTRAINT [PK_T_Commentary] PRIMARY KEY CLUSTERED 
(
	[warnNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Company]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Company](
	[Cop_ID] [int] IDENTITY(1,1) NOT NULL,
	[CopNam] [varchar](50) NULL,
	[Active] [varchar](50) NULL,
	[Adder] [varchar](50) NULL,
	[Tel1] [varchar](20) NULL,
	[Tel2] [varchar](50) NULL,
	[Fax] [varchar](20) NULL,
	[Pox] [varchar](20) NULL,
	[Symbl] [varchar](20) NULL,
	[Eamil] [varchar](100) NULL,
	[Mobl] [varchar](20) NULL,
 CONSTRAINT [PK_T_Company] PRIMARY KEY CLUSTERED 
(
	[Cop_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Contract]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Contract](
	[Contract_ID] [varchar](40) NOT NULL,
	[Contract_No] [int] NOT NULL,
	[NameA] [varchar](30) NULL,
	[NameE] [varchar](30) NULL,
	[Note] [varchar](250) NULL,
 CONSTRAINT [PK_T_Contract] PRIMARY KEY CLUSTERED 
(
	[Contract_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_CstTbl]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_CstTbl](
	[Cst_ID] [int] IDENTITY(1,1) NOT NULL,
	[Cst_No] [varchar](30) NULL,
	[Arb_Des] [varchar](100) NULL,
	[Eng_Des] [varchar](100) NULL,
	[CompanyID] [int] NULL,
	[CstFlied1] [varchar](250) NULL,
	[CstFlied2] [varchar](250) NULL,
	[CstFlied3] [varchar](250) NULL,
	[CstFlied4] [varchar](250) NULL,
	[CstFlied5] [varchar](250) NULL,
 CONSTRAINT [PK_T_CstTbl] PRIMARY KEY CLUSTERED 
(
	[Cst_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Curency]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Curency](
	[Curency_ID] [int] IDENTITY(1,1) NOT NULL,
	[Curency_No] [varchar](40) NULL,
	[Arb_Des] [varchar](100) NULL,
	[Eng_Des] [varchar](100) NULL,
	[Rate] [float] NULL,
	[Symbol] [varchar](4) NULL,
	[CompanyID] [int] NULL,
 CONSTRAINT [PK_T_Curency] PRIMARY KEY CLUSTERED 
(
	[Curency_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_DayOfWeek]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_DayOfWeek](
	[Day_No] [int] NOT NULL,
	[NameA] [varchar](10) NULL,
	[NameE] [varchar](10) NULL,
 CONSTRAINT [PK_T_DayOfWeek] PRIMARY KEY CLUSTERED 
(
	[Day_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_DaysOfMonth]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_DaysOfMonth](
	[ID] [varchar](40) NOT NULL,
	[DaysOfMonth] [int] NULL,
	[Year] [int] NULL,
	[Month] [int] NULL,
 CONSTRAINT [PK_T_DaysOfMonth] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Dept]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Dept](
	[Dept_ID] [varchar](40) NOT NULL,
	[Dept_No] [int] NOT NULL,
	[NameA] [varchar](50) NULL,
	[NameE] [varchar](50) NULL,
	[Note] [varchar](250) NULL,
	[BossName] [varchar](30) NULL,
	[Phone] [varchar](15) NULL,
	[Fax] [varchar](15) NULL,
	[AllownceNo] [varchar](20) NULL,
	[AllownceBeginDate] [varchar](20) NULL,
	[AllownceEndDate] [varchar](20) NULL,
	[ZakaaNo] [varchar](20) NULL,
	[ZakaaBeginDate] [varchar](20) NULL,
	[ZakaaEndDate1] [varchar](20) NULL,
 CONSTRAINT [PK_T_Dept] PRIMARY KEY CLUSTERED 
(
	[Dept_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_EditItemPrice]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_EditItemPrice](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ItmNo] [varchar](50) NOT NULL,
	[SelPriceNow1] [float] NULL,
	[SelPriceNew1] [float] NULL,
	[SelCostNow] [float] NULL,
	[SelCostNew] [float] NULL,
	[Legates] [float] NULL,
	[LegatesNew] [float] NULL,
	[Distributors] [float] NULL,
	[DistributorsNew] [float] NULL,
	[Sentence] [float] NULL,
	[SentenceNew] [float] NULL,
	[Sectorial] [float] NULL,
	[SectorialNew] [float] NULL,
	[VIP] [float] NULL,
	[VIPNew] [float] NULL,
	[SelPriceNow2] [float] NULL,
	[SelPriceNew2] [float] NULL,
	[SelPriceNow3] [float] NULL,
	[SelPriceNew3] [float] NULL,
	[SelPriceNow4] [float] NULL,
	[SelPriceNew4] [float] NULL,
	[SelPriceNow5] [float] NULL,
	[SelPriceNew5] [float] NULL,
	[LTim] [varchar](10) NULL,
	[HDate] [varchar](10) NULL,
	[GDate] [varchar](10) NULL,
	[UsrNm] [varchar](50) NULL,
 CONSTRAINT [PK_T_EditItemPrice] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Emp]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Emp](
	[Emp_ID] [varchar](40) NOT NULL,
	[Emp_No] [varchar](6) NOT NULL,
	[Pass] [varchar](50) NULL,
	[NameA] [varchar](30) NULL,
	[NameE] [varchar](30) NULL,
	[DateAppointment] [varchar](10) NOT NULL,
	[StartContr] [varchar](10) NULL,
	[EndContr] [varchar](10) NULL,
	[LastFilter] [varchar](10) NULL,
	[ID_Date] [varchar](10) NULL,
	[ID_DateEnd] [varchar](10) NULL,
	[Passport_Date] [varchar](10) NULL,
	[Passport_DateEnd] [varchar](10) NULL,
	[License_Date] [varchar](10) NULL,
	[License_DateEnd] [varchar](10) NULL,
	[Form_Date] [varchar](10) NULL,
	[Form_DateEnd] [varchar](10) NULL,
	[Insurance_Date] [varchar](10) NULL,
	[Insurance_DateEnd] [varchar](10) NULL,
	[BirthDate] [varchar](10) NULL,
	[AutoReturnContr] [bit] NULL,
	[WorkHours] [float] NULL,
	[DayOfMonth] [int] NULL,
	[VacationCount] [int] NULL,
	[VacationBalance] [float] NULL,
	[TicketsCount] [float] NULL,
	[TicketsPrice] [float] NULL,
	[TicketsBalance] [float] NULL,
	[IsDesSocialInsurance] [bit] NULL,
	[SocialInsuranceNo] [varchar](15) NULL,
	[MainSal] [float] NULL,
	[HousingAllowance] [float] NULL,
	[TransferAllowance] [float] NULL,
	[SubsistenceAllowance] [float] NULL,
	[NaturalWorkAllowance] [float] NULL,
	[OtherAllowance] [float] NULL,
	[DisOneDay] [float] NULL,
	[LateHours] [float] NULL,
	[SocialInsuranceComp] [float] NULL,
	[SocialInsurance] [float] NULL,
	[InsuranceMedicalCom] [float] NULL,
	[InsuranceMedical] [float] NULL,
	[AddDay] [float] NULL,
	[AddHours] [float] NULL,
	[MandateDay] [float] NULL,
	[BankBR] [varchar](30) NULL,
	[AccountID] [varchar](30) NULL,
	[ID_No] [varchar](15) NULL,
	[Passport_No] [varchar](15) NULL,
	[License_No] [varchar](15) NULL,
	[Form_No] [varchar](15) NULL,
	[Insurance_No] [varchar](15) NULL,
	[AddressA] [varchar](30) NULL,
	[AddressE] [varchar](30) NULL,
	[PO_Box] [varchar](10) NULL,
	[ZipCode] [varchar](15) NULL,
	[Tel] [varchar](30) NULL,
	[Email] [varchar](30) NULL,
	[QualificationA] [varchar](30) NULL,
	[QualificatioE] [varchar](30) NULL,
	[ExperiencesA] [varchar](100) NULL,
	[ExperiencesE] [varchar](100) NULL,
	[Note] [varchar](30) NULL,
	[EmpState] [bit] NULL,
	[EmpPic] [varbinary](max) NULL,
	[Job] [int] NULL,
	[Dept] [int] NULL,
	[Section] [int] NULL,
	[Guarantor] [int] NULL,
	[ContrTyp] [int] NULL,
	[DirBoss] [int] NULL,
	[StatusSal] [int] NULL,
	[Bank] [int] NULL,
	[ID_From] [int] NULL,
	[Passport_From] [int] NULL,
	[License_From] [int] NULL,
	[Form_From] [int] NULL,
	[Insurance_From] [int] NULL,
	[Religion] [int] NULL,
	[Sex] [int] NULL,
	[Nationalty] [int] NULL,
	[BloodTyp] [int] NULL,
	[MaritalStatus] [int] NULL,
	[BirthPlace] [int] NULL,
	[CityNo] [int] NULL,
	[CalculateNo] [int] NULL,
	[FatherA] [varchar](30) NULL,
	[GrandFA] [varchar](30) NULL,
	[FamilyA] [varchar](30) NULL,
	[FatherE] [varchar](30) NULL,
	[GrandFE] [varchar](30) NULL,
	[FamilyE] [varchar](30) NULL,
	[FirstNameA] [varchar](30) NULL,
	[FirstNameE] [varchar](30) NULL,
	[CompanyID] [int] NULL,
	[SalAcc] [varchar](30) NULL,
	[LoanAcc] [varchar](30) NULL,
	[HouseAcc] [varchar](30) NULL,
	[Allowances] [int] NULL,
	[AllowancesTime] [int] NULL,
	[WorkNo] [varchar](30) NULL,
	[VisaNo] [varchar](30) NULL,
	[VisaEnterNo] [varchar](30) NULL,
	[VisaDate] [varchar](30) NULL,
	[VisaCountry] [varchar](30) NULL,
	[CostCenterEmp] [int] NULL,
	[ProjectNo] [int] NULL,
	[Insurance_Name] [varchar](100) NULL,
	[InsuranceNo] [int] NULL,
	[SocialInsuranceDate] [varchar](10) NULL,
	[ExclusionDate] [varchar](10) NULL,
	[Boss] [int] NULL,
 CONSTRAINT [PK_T_Emp] PRIMARY KEY CLUSTERED 
(
	[Emp_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_EmpCards]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_EmpCards](
	[EmpCards_ID] [int] IDENTITY(1,1) NOT NULL,
	[Employes_No] [varchar](30) NULL,
	[fldFlg] [int] NULL,
	[crdName] [varchar](40) NULL,
	[crdNo] [varchar](20) NULL,
	[crdSource] [varchar](40) NULL,
	[crdIssu] [varchar](10) NULL,
	[crdExp] [varchar](10) NULL,
	[crdAlarm] [int] NULL,
	[crdBef] [int] NULL,
	[tmpStr1] [varchar](10) NULL,
	[tmpStr2] [varchar](10) NULL,
	[tmpNo1] [int] NULL,
	[tmpNo2] [int] NULL,
	[CompanyID] [int] NULL,
 CONSTRAINT [PK_T_EmpCards] PRIMARY KEY CLUSTERED 
(
	[EmpCards_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_EndService]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_EndService](
	[EndService_ID] [varchar](40) NOT NULL,
	[warnNo] [int] NOT NULL,
	[EmpID] [varchar](40) NOT NULL,
	[warnDate] [varchar](10) NULL,
	[CauseLiquidation] [int] NULL,
	[DateAppointment] [varchar](10) NULL,
	[LastFilter] [varchar](10) NULL,
	[Salary] [float] NULL,
	[DateFilter] [varchar](10) NULL,
	[Years] [int] NULL,
	[Months] [int] NULL,
	[Days] [int] NULL,
	[ServLess] [int] NULL,
	[LessWorth] [int] NULL,
	[ServMore] [int] NULL,
	[AndLess] [int] NULL,
	[LessMoreWorth] [int] NULL,
	[ServMoreOnly] [int] NULL,
	[MoreWorth] [int] NULL,
	[IFState] [bit] NULL,
	[GenTotal] [float] NULL,
	[ISCalculatTicketVal] [bit] NULL,
	[ValueAdvances] [float] NULL,
	[Paid] [float] NULL,
	[Remaining] [float] NULL,
	[WagesDetails] [varchar](max) NULL,
	[Note] [varchar](50) NULL,
	[EAdvancesRemainning] [float] NULL,
	[EWagesValue] [float] NULL,
	[eEndServisValue] [float] NULL,
	[TicketCount] [float] NULL,
	[Tickets] [float] NULL,
	[TicketUsed] [float] NULL,
	[TicketBalance] [float] NULL,
	[TicketValue] [float] NULL,
	[TicketTotal] [float] NULL,
	[VacDayCount] [int] NULL,
	[VacUsed] [float] NULL,
	[VacAcout] [float] NULL,
	[VacBalance] [float] NULL,
	[VacTotal] [float] NULL,
	[ExclusionDt] [varchar](10) NULL,
 CONSTRAINT [PK_T_EndService_1] PRIMARY KEY CLUSTERED 
(
	[warnNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_EqarContract]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_EqarContract](
	[ContractID] [int] IDENTITY(1,1) NOT NULL,
	[ContractNo] [varchar](100) NOT NULL,
	[EqarID] [int] NOT NULL,
	[AinID] [int] NOT NULL,
	[StartDate] [varchar](10) NOT NULL,
	[EndDate] [varchar](10) NOT NULL,
	[RentOfYear] [float] NOT NULL,
	[tenant] [int] NOT NULL,
	[Note] [varchar](500) NULL,
 CONSTRAINT [PK_T_EqarContract] PRIMARY KEY CLUSTERED 
(
	[ContractID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_EqarNatural]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_EqarNatural](
	[EqarNatural_ID] [varchar](40) NOT NULL,
	[EqarNatural_No] [int] NOT NULL,
	[NameA] [varchar](30) NULL,
	[NameE] [varchar](30) NULL,
	[Note] [varchar](50) NULL,
 CONSTRAINT [PK_T_EqarNatural] PRIMARY KEY CLUSTERED 
(
	[EqarNatural_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_EqarSale]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_EqarSale](
	[EqarSaleID] [int] IDENTITY(1,1) NOT NULL,
	[EqarSaleNo] [varchar](100) NOT NULL,
	[EqarID] [int] NOT NULL,
	[AinID] [int] NULL,
	[GDate] [varchar](10) NOT NULL,
	[HDate] [varchar](10) NOT NULL,
	[SaleValue] [float] NULL,
	[Note] [varchar](500) NULL,
 CONSTRAINT [PK_T_EqarSale] PRIMARY KEY CLUSTERED 
(
	[EqarSaleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_EqarsData]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_EqarsData](
	[EqarID] [int] IDENTITY(1,1) NOT NULL,
	[EqarNo] [int] NOT NULL,
	[NameA] [varchar](100) NULL,
	[NameE] [varchar](100) NULL,
	[EqarStatus] [int] NULL,
	[AccNo] [varchar](30) NULL,
	[Nationalty] [int] NULL,
	[CityNo] [int] NULL,
	[EqarTypNo] [int] NULL,
	[EqarNatureNo] [int] NULL,
	[OwnerNo] [int] NULL,
	[ContractValue] [float] NULL,
	[ContractRentValue] [float] NULL,
	[SQNo] [varchar](100) NULL,
	[SQDate] [varchar](10) NULL,
	[Neighborhood] [varchar](100) NULL,
	[Street] [varchar](100) NULL,
	[FloorsCount] [int] NULL,
	[EyesCount] [int] NULL,
	[Space] [varchar](100) NULL,
	[Note] [varchar](500) NULL,
 CONSTRAINT [PK_T_EqarsData] PRIMARY KEY CLUSTERED 
(
	[EqarID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_EqarTyp]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_EqarTyp](
	[EqarTyp_ID] [varchar](40) NOT NULL,
	[EqarTyp_No] [int] NOT NULL,
	[NameA] [varchar](30) NULL,
	[NameE] [varchar](30) NULL,
	[Note] [varchar](50) NULL,
 CONSTRAINT [PK_T_EqarTyp] PRIMARY KEY CLUSTERED 
(
	[EqarTyp_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Family]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Family](
	[Family_ID] [varchar](40) NOT NULL,
	[Person_No] [int] NOT NULL,
	[EmpID] [varchar](40) NOT NULL,
	[Name] [varchar](20) NULL,
	[BirthDay] [varchar](10) NULL,
	[Link] [varchar](20) NULL,
	[PassNo] [varchar](15) NULL,
	[PassEnd] [varchar](10) NULL,
 CONSTRAINT [PK_T_Family] PRIMARY KEY CLUSTERED 
(
	[Person_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_GdAuto]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_GdAuto](
	[GdAuto_Id] [int] IDENTITY(1,1) NOT NULL,
	[Acc0] [int] NOT NULL,
	[Acc1] [int] NOT NULL,
	[Acc2] [int] NOT NULL,
	[Acc3] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_GDDET]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_GDDET](
	[GDDET_ID] [int] IDENTITY(1,1) NOT NULL,
	[gdID] [int] NULL,
	[gdNo] [varchar](10) NULL,
	[gdDes] [varchar](max) NULL,
	[recptTyp] [varchar](20) NULL,
	[AccNo] [varchar](30) NULL,
	[AccName] [varchar](100) NULL,
	[gdValue] [float] NULL,
	[recptNo] [varchar](20) NULL,
	[Lin] [int] NULL,
	[gdDesE] [varchar](max) NULL,
	[AccNoDestruction] [varchar](30) NULL,
 CONSTRAINT [PK_T_GDDET] PRIMARY KEY CLUSTERED 
(
	[GDDET_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_GDHEAD]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_GDHEAD](
	[gdhead_ID] [int] IDENTITY(1,1) NOT NULL,
	[gdID] [int] NULL,
	[gdTyp] [int] NULL,
	[gdNo] [varchar](10) NULL,
	[gdMem] [varchar](max) NULL,
	[gdTot] [float] NULL,
	[gdLok] [bit] NOT NULL,
	[gdHDate] [varchar](10) NULL,
	[gdGDate] [varchar](10) NULL,
	[gdMnd] [int] NULL,
	[gdCstNo] [int] NULL,
	[gdUser] [varchar](3) NULL,
	[gdUserNam] [varchar](50) NULL,
	[gdTp] [int] NULL,
	[gdRcptID] [float] NULL,
	[CurTyp] [int] NULL,
	[ArbTaf] [varchar](150) NULL,
	[RefNo] [varchar](20) NULL,
	[salMonth] [varchar](50) NULL,
	[EngTaf] [varchar](150) NULL,
	[ChekNo] [varchar](50) NULL,
	[BName] [varchar](50) NULL,
	[CREATED_BY] [varchar](100) NULL,
	[MODIFIED_BY] [varchar](100) NULL,
	[DATE_CREATED] [datetime] NULL,
	[DATE_MODIFIED] [datetime] NULL,
	[CommMnd_Gaid] [float] NULL,
	[CompanyID] [int] NULL,
	[AdminLock] [bit] NULL,
 CONSTRAINT [PK_T_gdhead] PRIMARY KEY CLUSTERED 
(
	[gdhead_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Guarantor]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Guarantor](
	[Guarantor_ID] [varchar](40) NOT NULL,
	[Guarantor_No] [int] NOT NULL,
	[CodPc] [varchar](15) NULL,
	[NameA] [varchar](30) NULL,
	[NameE] [varchar](30) NULL,
	[Address] [varchar](30) NULL,
	[Tel] [varchar](15) NULL,
	[Fax] [varchar](15) NULL,
	[Mobil] [varchar](15) NULL,
	[MdniNo] [varchar](20) NULL,
	[MdniBeginDate] [varchar](20) NULL,
	[MdniEndDate] [varchar](20) NULL,
	[BusnisNo] [varchar](20) NULL,
	[BusnisBeginDate] [varchar](20) NULL,
	[BusnisEndDate] [varchar](20) NULL,
	[BusnisFrom] [varchar](20) NULL,
	[MdniFrom] [varchar](20) NULL,
 CONSTRAINT [PK_T_Guarantor] PRIMARY KEY CLUSTERED 
(
	[Guarantor_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_IDType]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_IDType](
	[IDType_ID] [int] NOT NULL,
	[Arb_Des] [varchar](100) NULL,
	[Eng_Des] [varchar](100) NULL,
	[Usr] [varchar](3) NULL,
	[UsrNam] [varchar](50) NULL,
	[CompanyID] [int] NULL,
 CONSTRAINT [PK_T_IDType] PRIMARY KEY CLUSTERED 
(
	[IDType_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Info]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Info](
	[Company_ID] [int] IDENTITY(1,1) NOT NULL,
	[CompName] [varchar](50) NOT NULL,
	[Address] [varchar](30) NULL,
	[Tel1] [varchar](15) NULL,
	[Mobile] [varchar](15) NULL,
	[Fax] [varchar](15) NULL,
	[PBox] [varchar](15) NULL,
	[MailCode] [varchar](15) NULL,
	[NaturalJob] [varchar](20) NULL,
	[Note] [varchar](250) NULL,
	[BannarCompNameA] [varchar](100) NULL,
	[BannarCompAddressA] [varchar](50) NULL,
	[BannarTelA] [varchar](15) NULL,
	[BannarFaxA] [varchar](15) NULL,
	[CurrA1] [varchar](10) NULL,
	[CurrA2] [varchar](10) NULL,
	[CurrE1] [varchar](10) NULL,
	[CurrE2] [varchar](10) NULL,
	[AlarmDoc] [bit] NULL,
	[AlarmDocBefore] [int] NULL,
	[AutoLeave] [bit] NULL,
	[EmpLeaveAfter] [int] NULL,
	[AttendanceManually] [bit] NULL,
	[VacationManually] [bit] NULL,
	[CalculateNo] [int] NULL,
	[CalculatliquidNo] [int] NULL,
	[Allowances] [int] NULL,
	[AllowancesTime] [int] NULL,
	[CleanderType] [int] NULL,
	[ShowBanner] [bit] NULL,
	[ShowPageNo] [bit] NULL,
	[ShowDateH] [bit] NULL,
	[ShowDateG] [bit] NULL,
	[LogoPic] [varbinary](max) NULL,
	[SalDate] [varchar](10) NULL,
	[BackPath] [varchar](max) NULL,
	[ShowEmpNo] [bit] NULL,
	[ShowSigne] [bit] NULL,
	[CalculateAddDis] [int] NULL,
 CONSTRAINT [PK_T_Info] PRIMARY KEY CLUSTERED 
(
	[Company_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_InfoTb]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_InfoTb](
	[InfoTb_ID] [int] IDENTITY(1,1) NOT NULL,
	[fldFlag] [varchar](10) NULL,
	[fldValue] [varchar](200) NULL,
	[grpFlag] [varchar](20) NULL,
	[emptFld1] [varchar](50) NULL,
	[emptFld2] [varchar](50) NULL,
	[emptFld3] [varchar](50) NULL,
	[FontN] [varchar](50) NULL,
	[FontS] [float] NULL,
	[FontB] [int] NULL,
	[FontI] [int] NULL,
	[CompanyID] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Insurance]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Insurance](
	[Insurance_ID] [varchar](40) NOT NULL,
	[Insurance_No] [int] NOT NULL,
	[NameA] [varchar](30) NULL,
	[NameE] [varchar](30) NULL,
	[Note] [varchar](250) NULL,
 CONSTRAINT [PK_T_Insurance] PRIMARY KEY CLUSTERED 
(
	[Insurance_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_INVDET]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_INVDET](
	[InvDet_ID] [int] IDENTITY(1,1) NOT NULL,
	[InvNo] [varchar](10) NULL,
	[InvId] [int] NULL,
	[InvSer] [int] NULL,
	[ItmNo] [varchar](50) NULL,
	[Cost] [float] NULL,
	[Qty] [float] NULL,
	[ItmDes] [varchar](100) NULL,
	[ItmUnt] [varchar](100) NULL,
	[ItmDesE] [varchar](100) NULL,
	[ItmUntE] [varchar](100) NULL,
	[ItmUntPak] [float] NULL,
	[StoreNo] [int] NULL,
	[Price] [float] NULL,
	[Amount] [float] NULL,
	[RealQty] [float] NULL,
	[itmInvDsc] [float] NULL,
	[DatExper] [varchar](11) NULL,
	[ItmDis] [float] NULL,
	[ItmTyp] [int] NULL,
	[ItmIndex] [int] NULL,
	[ItmWight] [float] NULL,
	[ItmWight_T] [float] NULL,
	[CaExState] [int] NULL,
	[ItmAddCost] [float] NULL,
	[RunCod] [varchar](100) NULL,
	[LineDetails] [varchar](250) NULL,
	[Serial_Key] [varchar](100) NULL,
	[ItmTax] [float] NULL,
	[OfferTyp] [int] NULL,
	[CInvType] [int] NULL,
 CONSTRAINT [PK_T_INVDET] PRIMARY KEY CLUSTERED 
(
	[InvDet_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_INVDET_Repair]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_INVDET_Repair](
	[InvDet_ID_Repair] [int] IDENTITY(1,1) NOT NULL,
	[InvNo_Repair] [varchar](10) NULL,
	[InvId_Repair] [int] NULL,
	[InvSer_Repair] [int] NULL,
	[ItmNo_Repair] [varchar](50) NULL,
	[Cost_Repair] [float] NULL,
	[Qty_Repair] [float] NULL,
	[ItmDes_Repair] [varchar](100) NULL,
	[ItmUnt_Repair] [varchar](15) NULL,
	[ItmDesE_Repair] [varchar](100) NULL,
	[ItmUntE_Repair] [varchar](15) NULL,
	[ItmUntPak_Repair] [float] NULL,
	[StoreNo_Repair] [int] NULL,
	[Price_Repair] [float] NULL,
	[Amount_Repair] [float] NULL,
	[RealQty_Repair] [float] NULL,
	[itmInvDsc_Repair] [float] NULL,
	[DatExper_Repair] [varchar](11) NULL,
	[ItmDis_Repair] [float] NULL,
	[ItmTyp_Repair] [int] NULL,
	[ItmIndex_Repair] [int] NULL,
	[ItmWight_Repair] [float] NULL,
	[ItmWight_T_Repair] [float] NULL,
	[ItmAddCost_Repair] [float] NULL,
	[RunCod_Repair] [varchar](100) NULL,
	[LineDetails_Repair] [varchar](250) NULL,
	[InvDet_ID] [int] NOT NULL,
	[TypeRepair] [int] NULL,
	[Serial_Key_Repair] [varchar](100) NULL,
	[ItmTax_Repair] [float] NULL,
 CONSTRAINT [PK_T_INVDET_Repair] PRIMARY KEY CLUSTERED 
(
	[InvDet_ID_Repair] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_InvDetNote]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_InvDetNote](
	[InvDetNote_ID] [int] IDENTITY(1,1) NOT NULL,
	[InvDetNote_No] [varchar](30) NULL,
	[Arb_Des] [varchar](max) NULL,
	[Eng_Des] [varchar](max) NULL,
	[Price] [float] NULL,
	[BrNo] [int] NULL,
 CONSTRAINT [PK_T_InvDetNote_1] PRIMARY KEY CLUSTERED 
(
	[InvDetNote_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_INVHED]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_INVHED](
	[InvHed_ID] [int] IDENTITY(1,1) NOT NULL,
	[InvId] [float] NULL,
	[InvNo] [varchar](10) NULL,
	[InvTyp] [int] NULL,
	[InvCashPay] [int] NULL,
	[CusVenNo] [varchar](20) NULL,
	[CusVenNm] [varchar](50) NULL,
	[CusVenAdd] [varchar](100) NULL,
	[CusVenTel] [varchar](30) NULL,
	[Remark] [varchar](max) NULL,
	[HDat] [varchar](10) NULL,
	[GDat] [varchar](10) NULL,
	[MndNo] [int] NULL,
	[SalsManNo] [varchar](3) NULL,
	[SalsManNam] [varchar](50) NULL,
	[InvTot] [float] NULL,
	[InvTotLocCur] [float] NULL,
	[InvDisPrs] [float] NULL,
	[InvDisVal] [float] NULL,
	[InvDisValLocCur] [float] NULL,
	[InvNet] [float] NULL,
	[InvNetLocCur] [float] NULL,
	[CashPay] [float] NULL,
	[CashPayLocCur] [float] NULL,
	[IfRet] [int] NULL,
	[GadeNo] [float] NULL,
	[GadeId] [float] NULL,
	[IfDel] [int] NULL,
	[RetNo] [varchar](10) NULL,
	[RetId] [float] NULL,
	[InvCstNo] [int] NULL,
	[InvCashPayNm] [varchar](100) NULL,
	[RefNo] [varchar](20) NULL,
	[InvCost] [float] NULL,
	[EstDat] [varchar](10) NULL,
	[CustPri] [int] NULL,
	[ArbTaf] [varchar](150) NULL,
	[CurTyp] [int] NULL,
	[InvCash] [varchar](20) NULL,
	[ToStore] [varchar](3) NULL,
	[ToStoreNm] [varchar](50) NULL,
	[InvQty] [float] NULL,
	[EngTaf] [varchar](150) NULL,
	[IfTrans] [int] NULL,
	[CustRep] [float] NULL,
	[CustNet] [float] NULL,
	[InvWight_T] [float] NULL,
	[IfPrint] [int] NULL,
	[LTim] [varchar](10) NULL,
	[CREATED_BY] [varchar](100) NULL,
	[DATE_CREATED] [datetime] NULL,
	[MODIFIED_BY] [varchar](100) NULL,
	[DATE_MODIFIED] [datetime] NULL,
	[CreditPay] [float] NULL,
	[CreditPayLocCur] [float] NULL,
	[NetworkPay] [float] NULL,
	[NetworkPayLocCur] [float] NULL,
	[CommMnd_Inv] [float] NULL,
	[MndExtrnal] [bit] NULL,
	[CompanyID] [int] NULL,
	[OrderStatus] [int] NULL,
	[VehiclechassisNumber] [varchar](100) NULL,
	[Car_ID] [int] NULL,
	[Car_TypeNameA] [varchar](50) NULL,
	[Car_TypeNameE] [varchar](50) NULL,
	[Car_NameA] [varchar](50) NULL,
	[Car_NameE] [varchar](50) NULL,
	[PlateNo] [varchar](50) NULL,
	[Color] [varchar](50) NULL,
	[ModelNo] [varchar](50) NULL,
	[Delevery_Date] [date] NULL,
	[InvAddCost] [float] NULL,
	[InvAddCostLoc] [float] NULL,
	[InvAddCostExtrnal] [float] NULL,
	[InvAddCostExtrnalLoc] [float] NULL,
	[IsExtrnalGaid] [bit] NULL,
	[ExtrnalCostGaidID] [float] NULL,
	[Puyaid] [float] NULL,
	[Remming] [float] NULL,
	[RoomNo] [int] NULL,
	[OrderTyp] [int] NULL,
	[RoomSts] [bit] NULL,
	[chauffeurNo] [int] NULL,
	[RoomPerson] [int] NULL,
	[ServiceValue] [float] NULL,
	[Sts] [bit] NULL,
	[PaymentOrderTyp] [int] NULL,
	[AdminLock] [bit] NULL,
	[DeleteDate] [varchar](10) NULL,
	[DeleteTime] [varchar](10) NULL,
	[UserNew] [varchar](3) NULL,
	[IfEnter] [int] NULL,
	[InvAddTax] [float] NULL,
	[InvAddTaxlLoc] [float] NULL,
	[IsTaxGaid] [bit] NULL,
	[TaxGaidID] [float] NULL,
	[IsTaxUse] [bit] NULL,
	[InvValGaidDis] [float] NULL,
	[InvValGaidDislLoc] [float] NULL,
	[IsDisGaid] [bit] NULL,
	[DisGaidID1] [float] NULL,
	[IsDisUse1] [bit] NULL,
	[InvComm] [float] NULL,
	[InvCommLoc] [float] NULL,
	[IsCommGaid] [bit] NULL,
	[CommGaidID] [float] NULL,
	[IsCommUse] [bit] NULL,
	[IsTaxLines] [bit] NULL,
	[IsTaxByTotal] [bit] NULL,
	[IsTaxByNet] [bit] NULL,
	[TaxByNetValue] [float] NULL,
	[DesPointsValue] [float] NULL,
	[DesPointsValueLocCur] [float] NULL,
	[PointsCount] [float] NULL,
	[IsPoints] [bit] NULL,
	[tailor1] [varchar](100) NULL,
	[tailor2] [varchar](100) NULL,
	[tailor3] [varchar](100) NULL,
	[tailor4] [varchar](100) NULL,
	[tailor5] [varchar](100) NULL,
	[tailor6] [varchar](100) NULL,
	[tailor7] [varchar](100) NULL,
	[tailor8] [varchar](100) NULL,
	[tailor9] [varchar](100) NULL,
	[tailor10] [varchar](100) NULL,
	[tailor11] [varchar](100) NULL,
	[tailor12] [varchar](100) NULL,
	[tailor13] [varchar](100) NULL,
	[tailor14] [varchar](100) NULL,
	[tailor15] [varchar](100) NULL,
	[tailor16] [varchar](100) NULL,
	[tailor17] [varchar](100) NULL,
	[tailor18] [varchar](100) NULL,
	[tailor19] [varchar](100) NULL,
	[tailor20] [varchar](100) NULL,
	[InvImg] [varbinary](max) NULL,
	[PriceIncludTax] [bit] NULL,
	[CusVenMob] [varchar](50) NULL,
	[CInvType] [int] NULL,
 CONSTRAINT [PK_T_INVHED] PRIMARY KEY CLUSTERED 
(
	[InvHed_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_INVSETTING]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_INVSETTING](
	[InvSet_ID] [int] IDENTITY(1,1) NOT NULL,
	[InvID] [int] NOT NULL,
	[InvNamA] [varchar](50) NULL,
	[InvNamE] [varchar](50) NULL,
	[InvSetting] [varchar](50) NULL,
	[InvStartNo] [varchar](10) NULL,
	[InvTypA0] [varchar](50) NULL,
	[InvTypA1] [varchar](10) NULL,
	[InvTypA2] [varchar](10) NULL,
	[InvTypA3] [varchar](10) NULL,
	[InvTypA4] [varchar](10) NULL,
	[InvTypE0] [varchar](10) NULL,
	[InvTypE1] [varchar](10) NULL,
	[InvTypE2] [varchar](10) NULL,
	[InvTypE3] [varchar](10) NULL,
	[InvTypE4] [varchar](10) NULL,
	[InvColorH] [float] NULL,
	[InvColorD] [float] NULL,
	[InvPrice] [int] NULL,
	[FldA1] [varchar](20) NULL,
	[FldA2] [varchar](20) NULL,
	[FldA3] [varchar](20) NULL,
	[FldA4] [varchar](20) NULL,
	[FldA5] [varchar](20) NULL,
	[FldE1] [varchar](20) NULL,
	[FldE2] [varchar](20) NULL,
	[FldE3] [varchar](20) NULL,
	[FldE4] [varchar](20) NULL,
	[FldE5] [varchar](20) NULL,
	[AccCredit0] [varchar](15) NULL,
	[AccDebit0] [varchar](15) NULL,
	[invALogo] [varchar](20) NULL,
	[invELogo] [varchar](20) NULL,
	[invGdADesc] [varchar](max) NULL,
	[invGdEDesc] [varchar](max) NULL,
	[invGdStng] [varchar](10) NULL,
	[AccCredit1] [varchar](15) NULL,
	[AccDebit1] [varchar](15) NULL,
	[AccCredit2] [varchar](15) NULL,
	[AccDebit2] [varchar](15) NULL,
	[AccCredit3] [varchar](15) NULL,
	[AccDebit3] [varchar](15) NULL,
	[AccCredit4] [varchar](15) NULL,
	[AccDebit4] [varchar](15) NULL,
	[hAl] [float] NULL,
	[hAs] [float] NULL,
	[hYm] [float] NULL,
	[hYs] [float] NULL,
	[lnPg] [float] NULL,
	[lnSpc] [float] NULL,
	[defPrn] [varchar](100) NULL,
	[nTyp] [varchar](3) NULL,
	[ItmTyp] [varchar](10) NULL,
	[InvNum] [int] NULL,
	[InvNum1] [int] NULL,
	[DefLines] [int] NULL,
	[defSizePaper] [varchar](100) NULL,
	[Orientation] [int] NULL,
	[CatID] [int] NULL,
	[PrintCat] [bit] NULL,
	[TaxOptions] [varchar](100) NULL,
	[autoTaxGaid] [bit] NULL,
	[TaxDebit] [varchar](15) NULL,
	[TaxCredit] [varchar](15) NULL,
	[autoDisGaid] [bit] NULL,
	[DisDebit] [varchar](15) NULL,
	[DisCredit] [varchar](15) NULL,
	[CommOptions] [varchar](100) NULL,
	[autoCommGaid] [bit] NULL,
	[CommDebit] [varchar](15) NULL,
	[CommCredit] [varchar](15) NULL,
	[TaxDebitCredit] [varchar](15) NULL,
	[TaxCreditCredit] [varchar](15) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_ItemDet]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_ItemDet](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ItmNo] [varchar](50) NULL,
	[Qty] [float] NULL,
	[GItmNo] [varchar](50) NOT NULL,
	[Unit_] [int] NULL,
	[Price] [float] NULL,
	[StoreNo] [int] NULL,
 CONSTRAINT [PK_T_ItemDet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Items]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Items](
	[Itm_ID] [int] IDENTITY(1,1) NOT NULL,
	[Itm_No] [varchar](50) NOT NULL,
	[ItmCat] [int] NULL,
	[Arb_Des] [varchar](200) NULL,
	[Eng_Des] [varchar](200) NULL,
	[StartCost] [float] NULL,
	[AvrageCost] [float] NULL,
	[LastCost] [float] NULL,
	[Price1] [float] NULL,
	[Price2] [float] NULL,
	[Price3] [float] NULL,
	[Price4] [float] NULL,
	[Price5] [float] NULL,
	[Price6] [float] NULL,
	[Unit1] [int] NULL,
	[UntPri1] [float] NULL,
	[Pack1] [float] NULL,
	[Unit2] [int] NULL,
	[UntPri2] [float] NULL,
	[Pack2] [float] NULL,
	[Unit3] [int] NULL,
	[UntPri3] [float] NULL,
	[Pack3] [float] NULL,
	[Unit4] [int] NULL,
	[UntPri4] [float] NULL,
	[Pack4] [float] NULL,
	[Unit5] [int] NULL,
	[UntPri5] [float] NULL,
	[Pack5] [float] NULL,
	[DefultUnit] [int] NULL,
	[DefultVendor] [int] NULL,
	[OpenQty] [float] NULL,
	[QtyLvl] [float] NULL,
	[ItmLoc] [varchar](40) NULL,
	[BarCod1] [varchar](250) NULL,
	[BarCod2] [varchar](250) NULL,
	[BarCod3] [varchar](250) NULL,
	[BarCod4] [varchar](250) NULL,
	[BarCod5] [varchar](250) NULL,
	[Lot] [int] NULL,
	[QtyMax] [float] NULL,
	[LrnExp] [int] NULL,
	[DMY] [int] NULL,
	[ItmTyp] [int] NULL,
	[DefPack] [float] NULL,
	[ItmImg] [varbinary](max) NULL,
	[InvSaleStoped] [bit] NULL,
	[InvSaleReturnStoped] [bit] NULL,
	[InvPaymentStoped] [bit] NULL,
	[InvPaymentReturnStoped] [bit] NULL,
	[CompanyID] [int] NULL,
	[FirstCost] [float] NULL,
	[SerialKey] [varchar](100) NULL,
	[ItemComm] [float] NULL,
	[TaxSales] [float] NULL,
	[TaxPurchas] [float] NULL,
	[InvEnterStoped] [bit] NULL,
	[InvOutStoped] [bit] NULL,
	[ItemDis] [float] NULL,
	[SecriptCeramicCombo] [varchar](100) NULL,
	[SecriptCeramic] [varchar](100) NULL,
	[IsBalance] [bit] NULL,
	[IsPoints] [bit] NULL,
	[vSize1] [varchar](100) NULL,
	[vSize2] [varchar](100) NULL,
	[vSize3] [varchar](100) NULL,
	[vSize4] [varchar](100) NULL,
	[vSize5] [varchar](100) NULL,
	[vSize6] [varchar](100) NULL,
	[ProductionDate] [varchar](max) NULL,
	[ExpirationDate] [varchar](max) NULL,
 CONSTRAINT [PK_T_Items] PRIMARY KEY CLUSTERED 
(
	[Itm_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_ItemSerial]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_ItemSerial](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[SerialKey] [varchar](100) NOT NULL,
	[ItmNo] [varchar](50) NULL,
	[SerialStatus] [bit] NULL,
 CONSTRAINT [PK_T_ItemSerial] PRIMARY KEY CLUSTERED 
(
	[SerialKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Job]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Job](
	[Job_ID] [varchar](40) NOT NULL,
	[Job_No] [int] NOT NULL,
	[NameA] [varchar](30) NULL,
	[NameE] [varchar](30) NULL,
	[Note] [varchar](250) NULL,
 CONSTRAINT [PK_T_Job] PRIMARY KEY CLUSTERED 
(
	[Job_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_LiquidationTyp]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_LiquidationTyp](
	[LiquidationT_ID] [varchar](40) NULL,
	[LiquidationT_No] [int] NOT NULL,
	[NameA] [varchar](20) NULL,
	[NameE] [varchar](20) NULL,
 CONSTRAINT [PK_T_LiquidationT] PRIMARY KEY CLUSTERED 
(
	[LiquidationT_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Loc]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Loc](
	[Loc_ID] [int] IDENTITY(1,1) NOT NULL,
	[Loc_No] [varchar](30) NULL,
	[Arb_Des] [varchar](100) NULL,
	[Eng_Des] [varchar](100) NULL,
	[CompanyID] [int] NULL,
 CONSTRAINT [PK_T_Loc] PRIMARY KEY CLUSTERED 
(
	[Loc_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_mInvPrint]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_mInvPrint](
	[mInvPrint_ID] [int] IDENTITY(1,1) NOT NULL,
	[InvSndNo] [int] NULL,
	[nTyp] [int] NULL,
	[IsPrint] [int] NULL,
	[pField] [varchar](50) NULL,
	[vCol] [int] NULL,
	[vRow] [int] NULL,
	[vFont] [varchar](50) NULL,
	[vEt] [int] NULL,
	[vBold] [int] NULL,
	[vFldNo] [int] NULL,
	[vSize] [int] NULL,
	[MaxW] [int] NULL,
	[IsPrntHd] [int] NULL,
	[fldName] [varchar](50) NULL,
	[inRows] [int] NULL,
	[IsSum] [int] NULL,
	[repNum] [int] NULL,
	[repTyp] [int] NULL,
	[uChr] [varchar](50) NULL,
	[vWer] [int] NULL,
	[BarcodeTyp] [int] NULL,
 CONSTRAINT [PK_T_mInvPrint] PRIMARY KEY CLUSTERED 
(
	[mInvPrint_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Mndob]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Mndob](
	[Mnd_ID] [int] IDENTITY(1,1) NOT NULL,
	[Mnd_No] [varchar](30) NULL,
	[Arb_Des] [varchar](100) NULL,
	[Eng_Des] [varchar](100) NULL,
	[MndPri] [int] NULL,
	[Mnd_Typ] [int] NULL,
	[Comm_Inv] [float] NULL,
	[Comm_Gaid] [float] NULL,
	[CompanyID] [int] NULL,
	[PriceDoctor] [float] NULL,
	[DoctorJob] [varchar](100) NULL,
	[MndFlied1] [varchar](250) NULL,
	[MndFlied2] [varchar](250) NULL,
	[MndFlied3] [varchar](250) NULL,
	[MndFlied4] [varchar](250) NULL,
 CONSTRAINT [PK_T_Mndob] PRIMARY KEY CLUSTERED 
(
	[Mnd_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_MStatus]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_MStatus](
	[MStatusNo] [int] NOT NULL,
	[NameA] [varchar](20) NULL,
	[NameE] [varchar](20) NULL,
 CONSTRAINT [PK_T_MStatus] PRIMARY KEY CLUSTERED 
(
	[MStatusNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_MTemplates]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_MTemplates](
	[ID] [int] NOT NULL,
	[TemplateNo] [varchar](50) NULL,
	[Tamplate_Name] [varchar](50) NULL,
	[Message] [varchar](max) NULL,
 CONSTRAINT [PK_T_MTemplates] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Nationalities]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Nationalities](
	[Nation_ID] [varchar](40) NOT NULL,
	[Nation_No] [int] NOT NULL,
	[NameA] [varchar](30) NULL,
	[NameE] [varchar](30) NULL,
	[Note] [varchar](50) NULL,
	[SalSubtract] [float] NULL,
	[CompPaying] [float] NULL,
 CONSTRAINT [PK_T_Nationalities] PRIMARY KEY CLUSTERED 
(
	[Nation_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Offer]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Offer](
	[OfferHeadID] [int] IDENTITY(1,1) NOT NULL,
	[OfferHeadNo] [varchar](10) NULL,
	[OfferHeadName] [varchar](250) NULL,
	[OfferHeadTyp] [int] NULL,
	[StartDat] [varchar](10) NULL,
	[EndDat] [varchar](10) NULL,
	[OfferHeadCashCredit] [int] NULL,
	[CustPri] [int] NULL,
	[CusVenNo] [varchar](20) NULL,
	[OfferSalsManNo] [varchar](3) NULL,
	[OfferRemark] [varchar](max) NULL,
 CONSTRAINT [PK_T_Offer] PRIMARY KEY CLUSTERED 
(
	[OfferHeadID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_OfferDet]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_OfferDet](
	[OfferDet_ID] [int] IDENTITY(1,1) NOT NULL,
	[OfferDetNo] [varchar](10) NULL,
	[OfferID] [int] NULL,
	[OfferDetSer] [int] NULL,
	[ItmNo] [varchar](50) NULL,
	[ItmUnt] [int] NULL,
	[Price] [float] NULL,
	[DisVal] [float] NULL,
	[UnitPriVal] [float] NULL,
	[Qty] [float] NULL,
	[QtyTo] [float] NULL,
 CONSTRAINT [PK_T_OfferDet] PRIMARY KEY CLUSTERED 
(
	[OfferDet_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_OfferQFree]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_OfferQFree](
	[OfferQFree_ID] [int] IDENTITY(1,1) NOT NULL,
	[OfferQFreeNo] [varchar](10) NULL,
	[OfferQFreeID] [int] NULL,
	[OfferQFreeSer] [int] NULL,
	[OfferQFreeItmNo] [varchar](50) NULL,
	[OfferQFreeItmUnt] [int] NULL,
	[OfferQFreePrice] [float] NULL,
	[OfferQFreeDisVal] [float] NULL,
	[OfferQFreeUnitPriVal] [float] NULL,
	[OfferIDQ] [int] NULL,
	[OfferQFreeQty] [float] NULL,
	[OfferQFreeStoreNo] [int] NULL,
	[OfferQFreeItmTax] [float] NULL,
	[OfferQFreeRunCod] [varchar](100) NULL,
	[OfferQFreeDatExper] [varchar](11) NULL,
 CONSTRAINT [PK_T_OfferQFree] PRIMARY KEY CLUSTERED 
(
	[OfferQFree_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_OpMethod]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_OpMethod](
	[Method_No] [int] NOT NULL,
	[Name] [varchar](50) NULL,
	[NameE] [varchar](50) NULL,
 CONSTRAINT [PK_T_OpMethod] PRIMARY KEY CLUSTERED 
(
	[Method_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Owner]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Owner](
	[Owner_ID] [int] IDENTITY(1,1) NOT NULL,
	[Owner_No] [int] NOT NULL,
	[NameA] [varchar](50) NULL,
	[NameE] [varchar](50) NULL,
	[OwnerIdent] [varchar](50) NULL,
	[OwnerIdentDate] [varchar](10) NULL,
	[OwnerIdentSource] [varchar](100) NULL,
	[Nationalty] [int] NULL,
	[Address] [varchar](30) NULL,
	[Tel] [varchar](30) NULL,
	[Mobile] [varchar](30) NULL,
 CONSTRAINT [PK_T_Owner] PRIMARY KEY CLUSTERED 
(
	[Owner_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_PatientCout]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_PatientCout](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ItmNo] [varchar](50) NOT NULL,
	[Mnth] [float] NULL,
	[Total] [float] NULL,
	[Filed1] [float] NULL,
	[Field2] [float] NULL,
	[Field3] [varchar](50) NULL,
	[Field4] [varchar](50) NULL,
 CONSTRAINT [PK_T_PatientCout] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_per]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_per](
	[perno] [int] NOT NULL,
	[romno] [int] NULL,
	[nm] [varchar](100) NULL,
	[nath] [int] NULL,
	[day] [varchar](12) NULL,
	[dt1] [varchar](10) NULL,
	[price] [float] NULL,
	[pasno] [varchar](15) NULL,
	[dt2] [varchar](10) NULL,
	[dt3] [varchar](10) NULL,
	[ch] [int] NULL,
	[dis] [float] NULL,
	[actyp] [int] NULL,
	[ps1] [varchar](30) NULL,
	[ps2] [varchar](30) NULL,
	[cc] [int] NULL,
	[pastyp] [int] NULL,
	[tm1] [varchar](11) NULL,
	[tm2] [varchar](11) NULL,
	[tax] [float] NULL,
	[ser] [float] NULL,
	[DOL] [float] NULL,
	[vip] [int] NULL,
	[job] [int] NULL,
	[curr] [int] NULL,
	[distyp] [int] NULL,
	[cust] [int] NULL,
	[disknd] [int] NULL,
	[jobpls] [varchar](150) NULL,
	[bdt] [varchar](10) NULL,
	[bpls] [varchar](30) NULL,
	[paspls] [varchar](30) NULL,
	[passt] [varchar](10) NULL,
	[pasend] [varchar](10) NULL,
	[enddt] [varchar](10) NULL,
	[pict] [varbinary](max) NULL,
	[fat] [float] NULL,
	[gropno] [int] NULL,
	[Cust_no] [varchar](30) NULL,
	[Totel] [int] NULL,
	[DayEdit] [int] NULL,
	[DayImport] [int] NULL,
	[dt4] [varchar](255) NULL,
	[KindPer] [int] NULL,
	[DayOfM] [int] NULL,
	[vAmPm] [varchar](5) NULL,
	[romnoNew] [int] NULL,
 CONSTRAINT [PK_T_per] PRIMARY KEY CLUSTERED 
(
	[perno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_per1]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_per1](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[perno] [int] NULL,
	[nm] [varchar](100) NULL,
	[natNm] [varchar](100) NULL,
	[nat] [int] NULL,
	[bdt] [varchar](10) NULL,
	[bpls] [varchar](50) NULL,
	[pastyp] [int] NULL,
	[pasno] [varchar](25) NULL,
	[paspls] [varchar](30) NULL,
	[passt] [varchar](10) NULL,
	[pasend] [varchar](10) NULL,
	[entdt] [varchar](10) NULL,
	[job] [int] NULL,
	[jobNm] [varchar](100) NULL,
	[jobpls] [varchar](50) NULL,
	[romno] [int] NULL,
	[fNo] [int] NULL,
	[romnoNew] [int] NULL,
 CONSTRAINT [PK_T_per1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Pine]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Pine](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Pic_no] [int] NULL,
	[Inv_ID] [varchar](50) NULL,
	[X] [int] NULL,
	[Y] [int] NULL,
	[Note] [varchar](max) NULL,
 CONSTRAINT [PK_T_Pine] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Premiums]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Premiums](
	[Premiums_ID] [varchar](40) NOT NULL,
	[Premiums_No] [int] NOT NULL,
	[Advances_No] [int] NULL,
	[PremiumsDate] [varchar](10) NULL,
	[ValuePremiums] [float] NULL,
	[Paying] [float] NULL,
	[IFState] [bit] NULL,
 CONSTRAINT [PK_T_Premiums] PRIMARY KEY CLUSTERED 
(
	[Premiums_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Printers]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Printers](
	[P_ID] [int] IDENTITY(1,1) NOT NULL,
	[Printer_Name] [varchar](max) NULL,
	[Paper_Size] [varchar](50) NULL,
	[Default_Operation] [varchar](max) NULL,
	[DefLines_Setting] [int] NULL,
	[hAl_Setting] [float] NULL,
	[hAs_Setting] [float] NULL,
	[hYm_Setting] [float] NULL,
	[hYs_Setting] [float] NULL,
	[lnPg_Setting] [float] NULL,
	[lnSpc_Setting] [float] NULL,
	[defPrn_Setting] [varchar](100) NULL,
	[nTyp_Setting] [varchar](3) NULL,
	[defSizePaper_Setting] [varchar](100) NULL,
	[Orientation_Setting] [int] NULL,
	[DefLines] [int] NULL,
	[hAl] [float] NULL,
	[hAs] [float] NULL,
	[hYm] [float] NULL,
	[hYs] [float] NULL,
	[lnPg] [float] NULL,
	[lnSpc] [float] NULL,
	[defPrn] [varchar](100) NULL,
	[nTyp] [varchar](3) NULL,
	[defSizePaper] [varchar](100) NULL,
	[Orientation] [int] NULL,
	[InvID] [int] NOT NULL,
	[User_ID] [int] NULL,
	[Branch_ID] [varchar](50) NULL,
	[Company] [varchar](50) NULL,
	[invGdADesc] [varchar](max) NULL,
	[invGdEDesc] [varchar](max) NULL,
	[InvTypA4] [varchar](50) NULL,
 CONSTRAINT [PK_T_Printers] PRIMARY KEY CLUSTERED 
(
	[P_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Project]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Project](
	[Project_ID] [varchar](40) NOT NULL,
	[Project_No] [int] NOT NULL,
	[NameA] [varchar](30) NULL,
	[NameE] [varchar](30) NULL,
	[Note] [varchar](250) NULL,
	[BossName] [varchar](30) NULL,
	[Phone] [varchar](15) NULL,
	[Fax] [varchar](15) NULL,
 CONSTRAINT [PK_T_Project] PRIMARY KEY CLUSTERED 
(
	[Project_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_QTYEXP]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_QTYEXP](
	[QtyExp_ID] [int] IDENTITY(1,1) NOT NULL,
	[itmNo] [varchar](50) NULL,
	[storeNo] [int] NULL,
	[stkQty] [float] NULL,
	[DatExper] [varchar](10) NULL,
	[RunCod] [varchar](100) NULL,
 CONSTRAINT [PK_T_QTYEXP] PRIMARY KEY CLUSTERED 
(
	[QtyExp_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Religion]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Religion](
	[Religion_ID] [varchar](40) NOT NULL,
	[Religion_No] [int] NOT NULL,
	[NameA] [varchar](30) NULL,
	[NameE] [varchar](30) NULL,
	[Note] [varchar](30) NULL,
 CONSTRAINT [PK_T_Religion] PRIMARY KEY CLUSTERED 
(
	[Religion_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Reserv]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Reserv](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ResrvNo] [int] NOT NULL,
	[Dat] [varchar](10) NULL,
	[Rom] [int] NULL,
	[PerNm] [varchar](150) NULL,
	[Dt] [varchar](10) NULL,
	[Tm] [varchar](11) NULL,
	[vAmPm] [varchar](5) NULL,
	[IdNo] [varchar](25) NULL,
	[Nat] [int] NULL,
	[Remark] [varchar](300) NULL,
	[Sts] [int] NULL,
	[Usr] [varchar](100) NULL,
	[DayImport] [int] NULL,
	[Dat2] [varchar](10) NULL,
	[CompanyID] [int] NULL,
	[romnoNew] [int] NULL,
 CONSTRAINT [PK_T_Reserv] PRIMARY KEY CLUSTERED 
(
	[ResrvNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Rewards]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Rewards](
	[Reward_ID] [varchar](40) NOT NULL,
	[Reward_No] [int] NOT NULL,
	[RewardDate] [varchar](10) NULL,
	[EmpID] [varchar](40) NULL,
	[SalDate] [varchar](10) NULL,
	[RewardValue] [float] NULL,
	[Note] [varchar](250) NULL,
	[IFState] [bit] NULL,
 CONSTRAINT [PK_T_Rewards] PRIMARY KEY CLUSTERED 
(
	[Reward_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Rom]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Rom](
	[romno] [int] NOT NULL,
	[flore] [int] NULL,
	[ch] [int] NULL,
	[state] [int] NULL,
	[row] [int] NULL,
	[col] [int] NULL,
	[wcno] [int] NULL,
	[wc] [int] NULL,
	[perno] [int] NULL,
	[bedno] [int] NULL,
	[bed] [int] NULL,
	[tv] [int] NULL,
	[bl] [int] NULL,
	[aline] [int] NULL,
	[typ] [int] NULL,
	[gropno] [int] NULL,
	[price] [float] NULL,
	[hed] [int] NULL,
	[tax] [int] NULL,
	[ser] [int] NULL,
	[dt] [varchar](10) NULL,
	[tm] [varchar](11) NULL,
	[pri0] [float] NULL,
	[pri1] [float] NULL,
	[pri2] [float] NULL,
	[pri3] [float] NULL,
	[priM0] [float] NULL,
	[priM1] [float] NULL,
	[ShortDsc] [varchar](50) NULL,
	[Numcounter] [varchar](50) NULL,
	[CompanyID] [int] NULL,
	[perno_Old] [int] NULL,
	[Furnished] [int] NULL,
	[AreaDetail] [varchar](250) NULL,
	[RoomCount] [int] NULL,
	[loungesCount] [int] NULL,
	[kitchensCount] [int] NULL,
 CONSTRAINT [PK_T_Rom] PRIMARY KEY CLUSTERED 
(
	[romno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_RomChart]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_RomChart](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FName] [varchar](100) NULL,
	[FNameE] [varchar](100) NULL,
	[col1] [int] NULL,
	[col2] [int] NULL,
	[col3] [int] NULL,
	[col4] [int] NULL,
	[col5] [int] NULL,
	[col6] [int] NULL,
	[col7] [int] NULL,
	[col8] [int] NULL,
	[col9] [int] NULL,
	[col10] [int] NULL,
	[col11] [int] NULL,
	[col12] [int] NULL,
	[col13] [int] NULL,
	[col14] [int] NULL,
	[col15] [int] NULL,
	[col16] [int] NULL,
	[col17] [int] NULL,
	[col18] [int] NULL,
	[col19] [int] NULL,
	[col20] [int] NULL,
	[col21] [int] NULL,
	[col22] [int] NULL,
	[col23] [int] NULL,
	[col24] [int] NULL,
	[col25] [int] NULL,
	[col26] [int] NULL,
	[col27] [int] NULL,
	[col28] [int] NULL,
	[col29] [int] NULL,
	[col30] [int] NULL,
	[col31] [int] NULL,
	[col32] [int] NULL,
	[col33] [int] NULL,
	[col34] [int] NULL,
	[col35] [int] NULL,
	[col36] [int] NULL,
	[col37] [int] NULL,
	[col38] [int] NULL,
	[col39] [int] NULL,
	[col40] [int] NULL,
	[col41] [int] NULL,
	[col42] [int] NULL,
	[col43] [int] NULL,
	[col44] [int] NULL,
	[col45] [int] NULL,
	[col46] [int] NULL,
	[col47] [int] NULL,
	[col48] [int] NULL,
	[col49] [int] NULL,
	[col50] [int] NULL,
	[col51] [int] NULL,
	[col52] [int] NULL,
	[col53] [int] NULL,
	[col54] [int] NULL,
	[col55] [int] NULL,
	[col56] [int] NULL,
	[col57] [int] NULL,
	[col58] [int] NULL,
	[col59] [int] NULL,
	[col60] [int] NULL,
	[col61] [int] NULL,
	[col62] [int] NULL,
	[col63] [int] NULL,
	[col64] [int] NULL,
	[col65] [int] NULL,
	[col66] [int] NULL,
	[col67] [int] NULL,
	[col68] [int] NULL,
	[col69] [int] NULL,
	[col70] [int] NULL,
	[col71] [int] NULL,
	[col72] [int] NULL,
	[col73] [int] NULL,
	[col74] [int] NULL,
	[col75] [int] NULL,
	[col76] [int] NULL,
	[col77] [int] NULL,
	[col78] [int] NULL,
	[col79] [int] NULL,
	[col80] [int] NULL,
	[col81] [int] NULL,
	[col82] [int] NULL,
	[col83] [int] NULL,
	[col84] [int] NULL,
	[col85] [int] NULL,
	[col86] [int] NULL,
	[col87] [int] NULL,
	[col88] [int] NULL,
	[col89] [int] NULL,
	[col90] [int] NULL,
	[col91] [int] NULL,
	[col92] [int] NULL,
	[col93] [int] NULL,
	[col94] [int] NULL,
	[col95] [int] NULL,
	[col96] [int] NULL,
	[col97] [int] NULL,
	[col98] [int] NULL,
	[col99] [int] NULL,
	[col100] [int] NULL,
 CONSTRAINT [PK_T_RomChart] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_romtrn]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_romtrn](
	[ID] [int] NOT NULL,
	[romno1] [int] NULL,
	[romno2] [int] NULL,
	[perno] [int] NULL,
	[dt] [varchar](10) NULL,
	[tm] [varchar](11) NULL,
	[Usr] [varchar](3) NULL,
	[UsrNam] [varchar](50) NULL,
	[typ] [int] NULL,
	[romnoNew] [int] NULL,
	[romnoNew1] [int] NULL,
	[romnoNew2] [int] NULL,
 CONSTRAINT [PK_T_romtrn] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Rooms]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Rooms](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RomeNo] [int] NOT NULL,
	[RomeStatus] [bit] NULL,
	[Type] [int] NULL,
	[Stop] [bit] NULL,
	[reserved] [bit] NULL,
	[chair] [int] NULL,
	[Note] [varchar](150) NULL,
	[waiterNo] [int] NULL,
 CONSTRAINT [PK_T_Rooms] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Sal]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Sal](
	[SalaryID] [varchar](40) NOT NULL,
	[EmpID] [varchar](30) NOT NULL,
	[SalMonth] [int] NULL,
	[SalYear] [int] NULL,
	[DirBoss] [int] NULL,
	[DeptNo] [int] NULL,
	[Job] [int] NULL,
	[Salary] [float] NULL,
	[HousingAllowance] [float] NULL,
	[TransferAllowance] [float] NULL,
	[OtherAllowance] [float] NULL,
	[SubDay] [float] NULL,
	[LateHours] [float] NULL,
	[SubJaza] [float] NULL,
	[SubOther] [float] NULL,
	[MandateDay] [float] NULL,
	[SocialInsuranceComp] [float] NULL,
	[SocialInsurance] [float] NULL,
	[InsuranceMedicalCom] [float] NULL,
	[InsuranceMedical] [float] NULL,
	[Advance] [float] NULL,
	[Rewards] [float] NULL,
	[Bank] [int] NULL,
	[AccountNo] [varchar](30) NULL,
	[SalaryStatus] [bit] NULL,
	[IsPrint] [bit] NULL,
	[SalSpell] [varchar](max) NULL,
	[AddDay] [float] NULL,
	[AddHour] [float] NULL,
	[SectionNo] [int] NULL,
	[SalAcc] [varchar](30) NULL,
	[SubCallPhone] [float] NULL,
	[SubCommentary] [float] NULL,
	[LoanAcc] [varchar](30) NULL,
	[HouseAcc] [varchar](30) NULL,
	[fGUID] [varchar](40) NULL,
	[Total] [float] NULL,
	[CostCenterEmp] [int] NULL,
	[BankBR] [varchar](30) NULL,
	[AccID] [bit] NULL,
	[GadeId] [float] NULL,
	[GadeId2] [float] NULL,
 CONSTRAINT [PK_T_Sal] PRIMARY KEY CLUSTERED 
(
	[SalaryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Salary]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Salary](
	[SalaryID] [varchar](40) NOT NULL,
	[EmpID] [varchar](40) NOT NULL,
	[SalMonth] [int] NULL,
	[SalYear] [int] NULL,
	[DirBoss] [int] NULL,
	[DeptNo] [int] NULL,
	[Job] [int] NULL,
	[Salary] [float] NULL,
	[HousingAllowance] [float] NULL,
	[TransferAllowance] [float] NULL,
	[OtherAllowance] [float] NULL,
	[SubDay] [float] NULL,
	[LateHours] [float] NULL,
	[SubJaza] [float] NULL,
	[SubOther] [float] NULL,
	[MandateDay] [float] NULL,
	[SocialInsuranceComp] [float] NULL,
	[SocialInsurance] [float] NULL,
	[InsuranceMedicalCom] [float] NULL,
	[InsuranceMedical] [float] NULL,
	[Advance] [float] NULL,
	[Rewards] [float] NULL,
	[Bank] [int] NULL,
	[AccountNo] [varchar](30) NULL,
	[SalaryStatus] [bit] NULL,
	[IsPrint] [bit] NULL,
	[SalSpell] [varchar](max) NULL,
	[AddDay] [float] NULL,
	[AddHour] [float] NULL,
	[SectionNo] [int] NULL,
	[GadeId2] [float] NULL,
	[SalAcc] [varchar](30) NULL,
	[SubCallPhone] [float] NULL,
	[SubCommentary] [float] NULL,
	[LoanAcc] [varchar](30) NULL,
	[HouseAcc] [varchar](30) NULL,
	[fGUID] [varchar](40) NULL,
	[Total] [float] NULL,
	[CostCenterEmp] [int] NULL,
	[BankBR] [varchar](30) NULL,
	[AccID] [bit] NULL,
	[GadeId] [float] NULL,
 CONSTRAINT [PK_T_Salary] PRIMARY KEY CLUSTERED 
(
	[SalaryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_SalaryOp]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_SalaryOp](
	[SalaryOp_ID] [varchar](40) NOT NULL,
	[warnNo] [int] NOT NULL,
	[EmpID] [varchar](40) NULL,
	[warnDate] [varchar](10) NULL,
	[opTyp] [int] NULL,
	[opMethod] [int] NULL,
	[AddTo] [int] NULL,
	[opCalc] [int] NULL,
	[AddValue] [float] NULL,
	[Usr_No] [int] NULL,
	[Usr_NoEdite] [int] NULL,
	[DateEdit] [varchar](10) NULL,
	[Note] [varchar](250) NULL,
	[ValueBefor] [float] NULL,
	[ValueAfter] [float] NULL,
 CONSTRAINT [PK_T_SalaryOp] PRIMARY KEY CLUSTERED 
(
	[warnNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_SalDiscount]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_SalDiscount](
	[Discont_ID] [varchar](40) NOT NULL,
	[warnNo] [int] NOT NULL,
	[warnDate] [varchar](10) NULL,
	[SubTyp] [int] NULL,
	[SalDate] [varchar](10) NULL,
	[CalculateNo] [int] NULL,
	[DayOfMonth] [int] NULL,
	[EmpID] [varchar](40) NULL,
	[ACount] [float] NULL,
	[SubValue] [float] NULL,
	[SubTotaly] [float] NULL,
	[Note] [varchar](250) NULL,
	[IFState] [bit] NULL,
	[MinuteTyp] [bit] NULL,
 CONSTRAINT [PK_T_SalDiscount_1] PRIMARY KEY CLUSTERED 
(
	[warnNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_SalStatus]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_SalStatus](
	[SalStatusNo] [int] NOT NULL,
	[NameA] [varchar](20) NULL,
	[NameE] [varchar](20) NULL,
 CONSTRAINT [PK_T_SalStatus] PRIMARY KEY CLUSTERED 
(
	[SalStatusNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Secretariats]    Script Date: 08/21/2021 5:55:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Secretariats](
	[Secretariats_ID] [varchar](40) NOT NULL,
	[warnNo] [int] NOT NULL,
	[EmpID] [varchar](40) NULL,
	[warnDate] [varchar](10) NULL,
	[StartDate] [varchar](10) NULL,
	[EndDate] [varchar](10) NULL,
	[SecretariatsTyp] [int] NULL,
	[Note] [varchar](250) NULL,
	[IFState] [bit] NULL,
 CONSTRAINT [PK_T_Secretariats] PRIMARY KEY CLUSTERED 
(
	[warnNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_SecretariatsTyp]    Script Date: 08/21/2021 5:55:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_SecretariatsTyp](
	[SecretariatTyp_ID] [varchar](40) NOT NULL,
	[SecretariatTyp_No] [int] NOT NULL,
	[NameA] [varchar](50) NULL,
	[NameE] [varchar](50) NULL,
	[Note] [varchar](250) NULL,
 CONSTRAINT [PK_T_SecretariatsTyp] PRIMARY KEY CLUSTERED 
(
	[SecretariatTyp_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Section]    Script Date: 08/21/2021 5:55:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Section](
	[Section_ID] [varchar](40) NOT NULL,
	[Section_No] [int] NOT NULL,
	[NameA] [varchar](30) NULL,
	[NameE] [varchar](30) NULL,
	[Note] [varchar](250) NULL,
	[BossName] [varchar](30) NULL,
	[Phone] [varchar](15) NULL,
	[Fax] [varchar](15) NULL,
 CONSTRAINT [PK_T_Section] PRIMARY KEY CLUSTERED 
(
	[Section_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_sertyp]    Script Date: 08/21/2021 5:55:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_sertyp](
	[Serv_ID] [int] IDENTITY(1,1) NOT NULL,
	[Serv_No] [varchar](30) NULL,
	[Arb_Des] [varchar](100) NULL,
	[Eng_Des] [varchar](100) NULL,
	[accno] [varchar](30) NULL,
	[acched] [varchar](30) NULL,
	[Usr] [varchar](3) NULL,
	[UsrNam] [varchar](50) NULL,
	[CompanyID] [int] NULL,
 CONSTRAINT [PK_T_sertyp] PRIMARY KEY CLUSTERED 
(
	[Serv_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Sex]    Script Date: 08/21/2021 5:55:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Sex](
	[SexNo] [int] NOT NULL,
	[NameA] [varchar](20) NULL,
	[NameE] [varchar](20) NULL,
 CONSTRAINT [PK_T_Sex] PRIMARY KEY CLUSTERED 
(
	[SexNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_SINVDET]    Script Date: 08/21/2021 5:55:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_SINVDET](
	[SInvDet_ID] [int] IDENTITY(1,1) NOT NULL,
	[SInvNo] [varchar](10) NULL,
	[SInvId] [int] NULL,
	[SInvSer] [int] NULL,
	[SItmNo] [varchar](50) NULL,
	[SCost] [float] NULL,
	[SQty] [float] NULL,
	[SItmDes] [varchar](100) NULL,
	[SItmUnt] [varchar](100) NULL,
	[SItmDesE] [varchar](100) NULL,
	[SItmUntE] [varchar](100) NULL,
	[SItmUntPak] [float] NULL,
	[SStoreNo] [int] NULL,
	[SPrice] [float] NULL,
	[SAmount] [float] NULL,
	[SRealQty] [float] NULL,
	[SitmInvDsc] [float] NULL,
	[SDatExper] [varchar](11) NULL,
	[SItmDis] [float] NULL,
	[SItmTyp] [int] NULL,
	[SItmIndex] [int] NULL,
	[SItmWight] [float] NULL,
	[SItmWight_T] [float] NULL,
	[SQtyDef] [float] NULL,
	[SPriceDef] [float] NULL,
	[SInvIdHEAD] [int] NULL,
	[SItmTax] [float] NULL,
 CONSTRAINT [PK_T_SINVDET] PRIMARY KEY CLUSTERED 
(
	[SInvDet_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Snd]    Script Date: 08/21/2021 5:55:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Snd](
	[gd_ID] [int] IDENTITY(1,1) NOT NULL,
	[fNo] [int] NOT NULL,
	[SndName] [varchar](100) NULL,
	[romno] [int] NULL,
	[price] [float] NULL,
	[det] [varchar](250) NULL,
	[typ] [int] NULL,
	[Usr] [varchar](30) NULL,
	[gdUser] [varchar](3) NULL,
	[gdUserNam] [varchar](50) NULL,
	[perno] [int] NULL,
	[dt] [varchar](10) NULL,
	[curr] [int] NULL,
	[tm] [varchar](11) NULL,
	[ch] [int] NULL,
	[curcost] [float] NULL,
	[sala] [int] NULL,
	[typN] [int] NULL,
	[ShekNo] [varchar](50) NULL,
	[ShekDate] [varchar](20) NULL,
	[ShekBank] [varchar](50) NULL,
	[IfTrans] [int] NULL,
	[RStat] [int] NULL,
	[GadeNo] [float] NULL,
	[GadeId] [float] NULL,
 CONSTRAINT [PK_T_Snd] PRIMARY KEY CLUSTERED 
(
	[gd_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_STKSQTY]    Script Date: 08/21/2021 5:55:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_STKSQTY](
	[StksQty_ID] [int] IDENTITY(1,1) NOT NULL,
	[itmNo] [varchar](50) NULL,
	[storeNo] [int] NULL,
	[stkQty] [float] NULL,
	[stkInt] [float] NULL,
	[stkLoc] [nchar](20) NULL,
	[tmpQty] [int] NULL,
 CONSTRAINT [PK_T_STKSQTY] PRIMARY KEY CLUSTERED 
(
	[StksQty_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Store]    Script Date: 08/21/2021 5:55:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Store](
	[Stor_ID] [int] NOT NULL,
	[Arb_Des] [varchar](100) NULL,
	[Eng_Des] [varchar](100) NULL,
	[Address] [varchar](100) NULL,
	[City] [varchar](30) NULL,
	[Tel] [varchar](30) NULL,
	[Fax] [varchar](30) NULL,
	[Nots] [varchar](100) NULL,
	[CompanyID] [int] NULL,
 CONSTRAINT [PK_T_Store] PRIMARY KEY CLUSTERED 
(
	[Stor_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_StoreMnd]    Script Date: 08/21/2021 5:55:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_StoreMnd](
	[StksQty_ID] [int] IDENTITY(1,1) NOT NULL,
	[itmNo] [varchar](50) NULL,
	[storeNo] [int] NULL,
	[stkQty] [float] NULL,
	[stkInt] [float] NULL,
	[stkLoc] [nchar](20) NULL,
	[tmpQty] [int] NULL,
	[MndNo] [int] NULL,
	[CusVenNo] [varchar](30) NULL,
 CONSTRAINT [PK_T_StoreMnd] PRIMARY KEY CLUSTERED 
(
	[StksQty_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_StsReas]    Script Date: 08/21/2021 5:55:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_StsReas](
	[ID] [int] NOT NULL,
	[NameSts] [varchar](250) NULL,
	[NameStsE] [varchar](250) NULL,
 CONSTRAINT [PK_T_StsReas] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_SubTyp]    Script Date: 08/21/2021 5:55:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_SubTyp](
	[SubNo] [int] NOT NULL,
	[NameA] [varchar](20) NULL,
	[NameE] [varchar](20) NULL,
 CONSTRAINT [PK_T_SubTyp] PRIMARY KEY CLUSTERED 
(
	[SubNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_SYSSETTING]    Script Date: 08/21/2021 5:55:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_SYSSETTING](
	[SYSSETTING_ID] [int] IDENTITY(1,1) NOT NULL,
	[AutoItm] [int] NULL,
	[AccCus] [nchar](20) NULL,
	[AccCusDes] [nchar](50) NULL,
	[AccSup] [varchar](10) NULL,
	[AccSupDes] [nchar](50) NULL,
	[Seting] [nchar](100) NULL,
	[DefLines_Setting] [int] NULL,
	[SysDir] [varchar](max) NULL,
	[HDat] [int] NULL,
	[Calendr] [int] NULL,
	[LrnExp] [int] NULL,
	[DMY] [int] NULL,
	[AutoEmp] [int] NULL,
	[InvID] [int] NULL,
	[GedID] [int] NULL,
	[InvMod] [int] NULL,
	[LogImg] [varbinary](max) NULL,
	[BackPath] [varchar](max) NULL,
	[IsAutoBackup] [bit] NULL,
	[AutoBackup] [int] NULL,
	[AutoBackupDate] [varchar](15) NULL,
	[hAl_Setting] [float] NULL,
	[hAs_Setting] [float] NULL,
	[hYm_Setting] [float] NULL,
	[hYs_Setting] [float] NULL,
	[lnPg_Setting] [float] NULL,
	[lnSpc_Setting] [float] NULL,
	[defPrn_Setting] [varchar](100) NULL,
	[nTyp_Setting] [varchar](3) NULL,
	[IsBackground] [bit] NULL,
	[IsNotBackground] [bit] NULL,
	[BackgroundPic] [varbinary](max) NULL,
	[defSizePaper_Setting] [varchar](100) NULL,
	[Orientation_Setting] [int] NULL,
	[Sponer] [bit] NULL,
	[IsAlarmVisaGoBack] [bit] NULL,
	[IsAlarmVisaIntro] [bit] NULL,
	[AlarmVisaGoBack] [int] NULL,
	[AlarmVisaIntro] [int] NULL,
	[IsAlarmDepts] [bit] NULL,
	[AlarmDeptsBefore] [int] NULL,
	[AutoChangSalStatus] [bit] NULL,
	[AccUsrNo] [int] NULL,
	[DocumentPath] [varchar](max) NULL,
	[ImportFilePath] [varchar](max) NULL,
	[ImportIp] [varchar](20) NULL,
	[ImportEmpNo] [varchar](5) NULL,
	[ImportDate] [varchar](5) NULL,
	[ImportTime1] [varchar](5) NULL,
	[ImportTimeLeave1] [varchar](5) NULL,
	[ImportStart] [varchar](5) NULL,
	[ImportEnd] [varchar](5) NULL,
	[AccPath] [varchar](max) NULL,
	[ServerNm] [varchar](50) NULL,
	[DataBaseNm] [varchar](50) NULL,
	[Sa_Pass] [varchar](100) NULL,
	[Path_Kind] [int] NULL,
	[AlarmDoc] [bit] NULL,
	[AlarmDocBefore] [int] NULL,
	[AutoLeave] [bit] NULL,
	[EmpLeaveAfter] [int] NULL,
	[AttendanceManually] [bit] NULL,
	[VacationManually] [bit] NULL,
	[CalculateNo] [int] NULL,
	[CalculatliquidNo] [int] NULL,
	[Allowances] [int] NULL,
	[AllowancesTime] [int] NULL,
	[ShowBanner] [bit] NULL,
	[ShowPageNo] [bit] NULL,
	[ShowDateH] [bit] NULL,
	[ShowDateG] [bit] NULL,
	[SalDate] [varchar](10) NULL,
	[DisVacationType] [int] NULL,
	[IsAlarmEmpDoc] [bit] NULL,
	[IsAlarmEmpContract] [bit] NULL,
	[IsAlarmFamilyPassport] [bit] NULL,
	[IsAlarmGuarantorDoc] [bit] NULL,
	[IsAlarmEndVaction] [bit] NULL,
	[IsAlarmBranchDoc] [bit] NULL,
	[IsAlarmCarDoc] [bit] NULL,
	[IsAlarmSecretariatsDoc] [bit] NULL,
	[AlarmEmpDocBefore] [int] NULL,
	[AlarmEmpContractBefore] [int] NULL,
	[AlarmFamilyPassportBefore] [int] NULL,
	[AlarmGuarantorDocBefore] [int] NULL,
	[AlarmEndVactionBefore] [int] NULL,
	[AlarmBranchDocBefore] [int] NULL,
	[AlarmCarDocBefore] [int] NULL,
	[AlarmSecretariatsBefore] [int] NULL,
	[smsUserName] [varchar](500) NULL,
	[smsPass] [varchar](500) NULL,
	[smsSenderName] [varchar](15) NULL,
	[smsMessage1] [varchar](500) NULL,
	[smsMessage2] [varchar](500) NULL,
	[smsMessage3] [varchar](500) NULL,
	[smsMessage4] [varchar](500) NULL,
	[AlarmEmployee] [int] NULL,
	[LineDetailSts] [varchar](100) NULL,
	[LineDetailNameA] [varchar](30) NULL,
	[LineDetailNameE] [varchar](30) NULL,
	[LineGiftSts] [varchar](100) NULL,
	[LineGiftlNameA] [varchar](30) NULL,
	[LineGiftlNameE] [varchar](30) NULL,
	[TableFamily] [int] NULL,
	[TableBoys] [int] NULL,
	[TableExtrnal] [int] NULL,
	[TableOther] [int] NULL,
	[MainDirPath] [varchar](max) NULL,
	[BColor0] [varchar](50) NULL,
	[BColor1] [varchar](50) NULL,
	[BColor2] [varchar](50) NULL,
	[BColor3] [varchar](50) NULL,
	[BColor4] [varchar](50) NULL,
	[BColor5] [varchar](50) NULL,
	[BColor6] [varchar](50) NULL,
	[BColor7] [varchar](50) NULL,
	[FColor0] [varchar](50) NULL,
	[FColor1] [varchar](50) NULL,
	[FColor2] [varchar](50) NULL,
	[FColor3] [varchar](50) NULL,
	[FColor4] [varchar](50) NULL,
	[FColor5] [varchar](50) NULL,
	[FColor6] [varchar](50) NULL,
	[FColor7] [varchar](50) NULL,
	[Fld_w] [int] NULL,
	[Fld_H] [int] NULL,
	[DayOfM] [int] NULL,
	[ch] [bit] NULL,
	[flore] [int] NULL,
	[rom] [int] NULL,
	[vStart] [varchar](10) NULL,
	[vEnd] [varchar](10) NULL,
	[vStartTyp] [varchar](5) NULL,
	[vEndTyp] [varchar](5) NULL,
	[GuestAcc] [varchar](30) NULL,
	[GuestBoxAcc] [varchar](30) NULL,
	[DefSalesTax] [float] NULL,
	[DefPurchaesTax] [float] NULL,
	[TaxAcc] [varchar](30) NULL,
	[TaxNoteInv] [varchar](150) NULL,
	[IsCustomerDisplay] [bit] NULL,
	[Port] [varchar](15) NULL,
	[Fast] [int] NULL,
	[BitStop] [int] NULL,
	[BitData] [int] NULL,
	[Parity] [int] NULL,
	[CustomerHello] [varchar](100) NULL,
	[DisplayTypeShow] [int] NULL,
	[LineOfInvoices] [int] NULL,
	[IsActiveBalance] [bit] NULL,
	[BalanceType] [int] NULL,
	[BarcodFrom] [int] NULL,
	[BarcodTo] [int] NULL,
	[WightFrom] [int] NULL,
	[WightTo] [int] NULL,
	[PriceFrom] [int] NULL,
	[PriceTo] [int] NULL,
	[WightQ] [int] NULL,
	[PriceQ] [int] NULL,
	[PointOfRyal] [float] NULL,
	[ItemTyp1] [varchar](100) NULL,
	[ItemTyp2] [varchar](100) NULL,
	[ItemTyp3] [varchar](100) NULL,
	[ItemTyp1E] [varchar](100) NULL,
	[ItemTyp2E] [varchar](100) NULL,
	[ItemTyp3E] [varchar](100) NULL,
	[AlarmDueoBefore] [int] NULL,
	[EmpSeting] [varchar](100) NULL,
	[SyncPath] [varchar](max) NULL,
	[vFiledA] [varchar](100) NULL,
	[vFiledB] [varchar](100) NULL,
	[vFiledC] [varchar](100) NULL,
	[vFiledInt] [int] NULL,
	[vFiledBool] [bit] NULL,
	[EqarAlarmContractEnd] [int] NULL,
	[EqarAlarmDayPay] [int] NULL,
	[EqarAcc] [varchar](30) NULL,
	[tenantAcc] [varchar](30) NULL,
	[AfterDotNum] [int] NULL,
 CONSTRAINT [PK_T_SYSSETTING] PRIMARY KEY CLUSTERED 
(
	[SYSSETTING_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_TbSalary]    Script Date: 08/21/2021 5:55:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_TbSalary](
	[TbSalary_ID] [int] IDENTITY(1,1) NOT NULL,
	[Employes_No] [varchar](30) NULL,
	[fldFlg] [int] NULL,
	[valDesc] [varchar](40) NULL,
	[vValue] [int] NULL,
	[autoCalc] [int] NULL,
	[autoDisc] [int] NULL,
	[vStart] [varchar](10) NULL,
	[vEnd] [varchar](10) NULL,
	[Mem] [varchar](50) NULL,
	[tmpStr1] [varchar](10) NULL,
	[tmpStr2] [varchar](10) NULL,
	[tmpNo1] [int] NULL,
	[tmpNo2] [int] NULL,
	[byYear] [int] NULL,
	[CompanyID] [int] NULL,
 CONSTRAINT [PK_T_TbSalary] PRIMARY KEY CLUSTERED 
(
	[TbSalary_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_tel]    Script Date: 08/21/2021 5:55:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_tel](
	[ID] [int] NOT NULL,
	[perno] [int] NULL,
	[ino] [int] NULL,
	[romno] [int] NULL,
	[tel] [varchar](25) NULL,
	[s] [float] NULL,
	[m] [int] NULL,
	[op] [int] NULL,
	[price] [float] NULL,
	[dt] [varchar](10) NULL,
	[tm] [varchar](10) NULL,
	[h] [int] NULL,
	[Usr] [varchar](3) NULL,
	[UsrNam] [varchar](50) NULL,
	[romnoNew] [int] NULL,
	[GadeNo] [float] NULL,
	[GadeId] [float] NULL,
	[IsGaid] [bit] NULL,
 CONSTRAINT [PK_T_tel] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_telmn]    Script Date: 08/21/2021 5:55:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_telmn](
	[pl] [int] NOT NULL,
	[price] [float] NULL,
	[d] [int] NULL,
	[accno] [varchar](30) NULL,
 CONSTRAINT [PK_T_telmn] PRIMARY KEY CLUSTERED 
(
	[pl] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Tenant]    Script Date: 08/21/2021 5:55:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Tenant](
	[tenantID] [int] IDENTITY(1,1) NOT NULL,
	[tenantNo] [int] NOT NULL,
	[NameA] [varchar](100) NULL,
	[NameE] [varchar](100) NULL,
	[AccNo] [varchar](30) NULL,
	[Nationalty] [int] NULL,
	[IDNo] [varchar](100) NULL,
	[IDDate] [varchar](10) NULL,
	[IDSource] [varchar](200) NULL,
	[Tel] [varchar](100) NULL,
	[Mobile] [varchar](100) NULL,
	[workAdd] [varchar](200) NULL,
	[workPhone] [varchar](100) NULL,
	[BossName] [varchar](100) NULL,
	[BossID] [varchar](100) NULL,
	[BossIDDate] [varchar](10) NULL,
	[BossIDSource] [varchar](200) NULL,
	[BossAdd] [varchar](200) NULL,
	[BossPhone] [varchar](100) NULL,
	[BossMobile] [varchar](100) NULL,
 CONSTRAINT [PK_T_Tenant] PRIMARY KEY CLUSTERED 
(
	[tenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_TenantContract]    Script Date: 08/21/2021 5:55:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_TenantContract](
	[ContractID] [int] IDENTITY(1,1) NOT NULL,
	[ContractNo] [int] NOT NULL,
	[tenant_ID] [int] NOT NULL,
	[Eqar_ID] [int] NOT NULL,
	[Ain_ID] [int] NULL,
	[RentOfYear] [float] NULL,
	[ContractStart] [varchar](10) NOT NULL,
	[ContractEnd] [varchar](10) NOT NULL,
	[RentOfYearPayment] [float] NULL,
	[PayMethod] [int] NULL,
 CONSTRAINT [PK_T_TenantContract] PRIMARY KEY CLUSTERED 
(
	[ContractID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_TenantPayment]    Script Date: 08/21/2021 5:55:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_TenantPayment](
	[PaymentID] [int] IDENTITY(1,1) NOT NULL,
	[PaymentNo] [int] NOT NULL,
	[tenantContract_ID] [int] NOT NULL,
	[Value] [float] NULL,
	[PayMonth] [varchar](10) NULL,
	[Statue] [bit] NULL,
	[Remining] [float] NULL,
	[SndNo] [int] NULL,
 CONSTRAINT [PK_T_TenantPayment] PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_TicetTyp]    Script Date: 08/21/2021 5:55:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_TicetTyp](
	[TicetT_No] [int] NOT NULL,
	[NameA] [varchar](20) NULL,
	[NameE] [varchar](20) NULL,
 CONSTRAINT [PK_T_TicetTyp] PRIMARY KEY CLUSTERED 
(
	[TicetT_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Tickets]    Script Date: 08/21/2021 5:55:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Tickets](
	[Ticket_ID] [varchar](40) NOT NULL,
	[warnNo] [int] NOT NULL,
	[warnDate] [varchar](10) NULL,
	[EmpID] [varchar](40) NULL,
	[GoLine] [varchar](50) NULL,
	[TickTyp] [int] NULL,
	[TicketValue] [float] NULL,
	[TicketCount] [float] NULL,
	[AllTicketValue] [float] NULL,
	[Note] [varchar](250) NULL,
	[IFState] [bit] NULL,
 CONSTRAINT [PK_T_Tickets_1] PRIMARY KEY CLUSTERED 
(
	[warnNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_tran]    Script Date: 08/21/2021 5:55:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_tran](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[dt] [varchar](10) NULL,
	[romno] [int] NULL,
	[price] [float] NULL,
	[fat] [int] NULL,
	[detal] [varchar](100) NULL,
	[Usr] [varchar](3) NULL,
	[UsrNam] [varchar](50) NULL,
	[tm] [varchar](11) NULL,
	[perno] [int] NULL,
	[typ] [int] NULL,
	[GadeNo] [float] NULL,
	[GadeId] [float] NULL,
	[IsGaid] [bit] NULL,
	[romnoNew] [int] NULL,
 CONSTRAINT [PK_T_tran] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_TransEmployee]    Script Date: 08/21/2021 5:55:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_TransEmployee](
	[Trans_ID] [varchar](40) NOT NULL,
	[warnNo] [int] NOT NULL,
	[EmpID] [varchar](40) NULL,
	[warnDate] [varchar](10) NULL,
	[DateFrom] [varchar](10) NULL,
	[DateTo] [varchar](10) NULL,
	[BranchFrom] [int] NULL,
	[BranchTo] [int] NULL,
	[Usr_No] [int] NULL,
	[Usr_NoEdite] [int] NULL,
	[DateEdit] [varchar](10) NULL,
	[Note] [varchar](250) NULL,
	[TransTyp] [bit] NULL,
 CONSTRAINT [PK_T_TransEmployee] PRIMARY KEY CLUSTERED 
(
	[warnNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_treatment]    Script Date: 08/21/2021 5:55:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_treatment](
	[treatment_ID] [varchar](40) NOT NULL,
	[treatment_No] [int] NOT NULL,
	[NameA] [varchar](100) NULL,
	[NameE] [varchar](100) NULL,
	[Note] [varchar](250) NULL,
 CONSTRAINT [PK_T_treatment] PRIMARY KEY CLUSTERED 
(
	[treatment_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Unit]    Script Date: 08/21/2021 5:55:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Unit](
	[Unit_ID] [int] IDENTITY(1,1) NOT NULL,
	[Unit_No] [varchar](30) NULL,
	[Arb_Des] [varchar](100) NULL,
	[Eng_Des] [varchar](100) NULL,
	[CompanyID] [int] NULL,
 CONSTRAINT [PK_T_Unit] PRIMARY KEY CLUSTERED 
(
	[Unit_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_UpdateDoc]    Script Date: 08/21/2021 5:55:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_UpdateDoc](
	[UpdateDoc_ID] [varchar](40) NOT NULL,
	[warnNo] [int] NOT NULL,
	[EmpID] [varchar](40) NULL,
	[warnDate] [varchar](10) NULL,
	[Usr_No] [int] NULL,
	[Usr_NoEdite] [int] NULL,
	[DateEdit] [varchar](10) NULL,
	[Note] [varchar](250) NULL,
	[BeginDateBefor] [varchar](10) NULL,
	[BeginDateAfter] [varchar](10) NULL,
	[EndDateBefor] [varchar](10) NULL,
	[EndDateAfter] [varchar](10) NULL,
	[DocNo] [varchar](15) NULL,
	[DocFrom] [int] NULL,
	[Insurance_NameBefor] [varchar](100) NULL,
	[InsuranceNoBefor] [int] NULL,
	[Insurance_NameAfter] [varchar](100) NULL,
	[InsuranceNoAfter] [int] NULL,
	[DocTyp] [int] NULL,
	[DocNoAfter] [varchar](15) NULL,
	[DocFromAfter] [int] NULL,
 CONSTRAINT [PK_T_UpdateDoc] PRIMARY KEY CLUSTERED 
(
	[warnNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Vacation]    Script Date: 08/21/2021 5:55:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Vacation](
	[vacation_ID] [varchar](40) NOT NULL,
	[warnNo] [int] NOT NULL,
	[warnDate] [varchar](10) NULL,
	[EmpID] [varchar](40) NULL,
	[VacCountDay] [int] NULL,
	[VacTyp] [int] NULL,
	[StartDate] [varchar](10) NOT NULL,
	[EndDate] [varchar](10) NOT NULL,
	[StopSalFrom] [varchar](10) NULL,
	[VacAllowance] [bit] NULL,
	[CalculateNo] [int] NULL,
	[WithDateSal] [varchar](10) NULL,
	[Amount] [float] NULL,
	[Note] [varchar](250) NULL,
	[IFState] [bit] NULL,
	[EmpCover] [varchar](40) NULL,
	[AdminLock] [bit] NULL,
 CONSTRAINT [PK_T_Vacation_1] PRIMARY KEY CLUSTERED 
(
	[warnNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_VacTyp]    Script Date: 08/21/2021 5:55:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_VacTyp](
	[VacT_ID] [varchar](40) NOT NULL,
	[VacT_No] [int] NOT NULL,
	[NameA] [varchar](30) NULL,
	[NameE] [varchar](30) NULL,
	[Dis_VacT] [bit] NULL,
	[Dis_Sal] [bit] NULL,
	[Dis_Sal_Sts] [int] NULL,
 CONSTRAINT [PK_T_HolidayTyp] PRIMARY KEY CLUSTERED 
(
	[VacT_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_VisaGoBack]    Script Date: 08/21/2021 5:55:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_VisaGoBack](
	[Visa_ID] [varchar](40) NOT NULL,
	[warnNo] [int] NOT NULL,
	[EmpID] [varchar](40) NULL,
	[warnDate] [varchar](10) NULL,
	[VisaNo] [varchar](40) NULL,
	[VisaPlace] [varchar](40) NULL,
	[VisaBeginDate] [varchar](20) NULL,
	[VisaEndDate] [varchar](20) NULL,
	[DateGo] [varchar](20) NULL,
	[DateBack] [varchar](20) NULL,
	[Note] [varchar](250) NULL,
	[CountDay] [int] NULL,
	[PlaceGo] [varchar](150) NULL,
	[PlaceBack] [varchar](150) NULL,
 CONSTRAINT [PK_VisaGoBack] PRIMARY KEY CLUSTERED 
(
	[warnNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_VisaIntroduction]    Script Date: 08/21/2021 5:55:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_VisaIntroduction](
	[Visa_ID] [varchar](40) NOT NULL,
	[warnNo] [int] NOT NULL,
	[EmpID] [varchar](40) NULL,
	[warnDate] [varchar](10) NULL,
	[VisaNo] [varchar](40) NULL,
	[VisaPlace] [varchar](40) NULL,
	[VisaBeginDate] [varchar](20) NULL,
	[VisaEndDate] [varchar](20) NULL,
	[DateGo] [varchar](20) NULL,
	[DateBack] [varchar](20) NULL,
	[Note] [varchar](250) NULL,
 CONSTRAINT [PK_T_VisaIntroduction] PRIMARY KEY CLUSTERED 
(
	[warnNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Waiter]    Script Date: 08/21/2021 5:55:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Waiter](
	[waiter_ID] [int] IDENTITY(1,1) NOT NULL,
	[waiter_No] [varchar](30) NULL,
	[Arb_Des] [varchar](100) NULL,
	[Eng_Des] [varchar](100) NULL,
	[CompanyID] [int] NULL,
	[Pass] [varchar](250) NULL,
	[Brn] [varchar](50) NULL,
	[ProLng] [int] NULL,
 CONSTRAINT [PK_T_Waiter] PRIMARY KEY CLUSTERED 
(
	[waiter_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_version]    Script Date: 08/21/2021 5:55:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_version](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[dbv] [varchar](max) NULL,
	[lastupdate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TmpTbl]    Script Date: 08/21/2021 5:55:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TmpTbl](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AccNo] [varchar](50) NULL,
	[AccNm] [varchar](100) NULL,
	[Num1] [float] NULL,
	[Num2] [float] NULL,
	[Num3] [float] NULL,
	[Num4] [float] NULL,
	[Num5] [float] NULL,
	[Num6] [float] NULL,
	[Num7] [float] NULL,
	[Num8] [float] NULL,
	[Num9] [float] NULL,
	[Num10] [float] NULL,
	[Num11] [float] NULL,
	[Num12] [float] NULL,
	[Num13] [float] NULL,
	[Num14] [float] NULL,
	[Str1] [varchar](50) NULL,
	[Str2] [varchar](50) NULL,
	[str3] [varchar](100) NULL,
	[str4] [varchar](50) NULL,
	[str5] [varchar](50) NULL,
	[str6] [varchar](100) NULL,
 CONSTRAINT [PK_TmpTbl] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[cod] ([cod]) VALUES (201)
GO
INSERT [dbo].[cod] ([cod]) VALUES (202)
GO
INSERT [dbo].[cod] ([cod]) VALUES (212)
GO
INSERT [dbo].[cod] ([cod]) VALUES (213)
GO
INSERT [dbo].[cod] ([cod]) VALUES (216)
GO
INSERT [dbo].[cod] ([cod]) VALUES (218)
GO
INSERT [dbo].[cod] ([cod]) VALUES (222)
GO
INSERT [dbo].[cod] ([cod]) VALUES (249)
GO
INSERT [dbo].[cod] ([cod]) VALUES (252)
GO
INSERT [dbo].[cod] ([cod]) VALUES (253)
GO
INSERT [dbo].[cod] ([cod]) VALUES (291)
GO
INSERT [dbo].[cod] ([cod]) VALUES (962)
GO
INSERT [dbo].[cod] ([cod]) VALUES (963)
GO
INSERT [dbo].[cod] ([cod]) VALUES (964)
GO
INSERT [dbo].[cod] ([cod]) VALUES (965)
GO
INSERT [dbo].[cod] ([cod]) VALUES (966)
GO
INSERT [dbo].[cod] ([cod]) VALUES (967)
GO
INSERT [dbo].[cod] ([cod]) VALUES (968)
GO
INSERT [dbo].[cod] ([cod]) VALUES (970)
GO
INSERT [dbo].[cod] ([cod]) VALUES (971)
GO
INSERT [dbo].[cod] ([cod]) VALUES (973)
GO
INSERT [dbo].[cod] ([cod]) VALUES (974)
GO
SET IDENTITY_INSERT [dbo].[T_AccCat] ON 
GO
INSERT [dbo].[T_AccCat] ([AccCat_ID], [AccCat_No], [Arb_Des], [Eng_Des], [CompanyID]) VALUES (1, N'1', N'الموجودات', N'Assets', 1)
GO
INSERT [dbo].[T_AccCat] ([AccCat_ID], [AccCat_No], [Arb_Des], [Eng_Des], [CompanyID]) VALUES (2, N'2', N'الصندوق', N'Box', 1)
GO
INSERT [dbo].[T_AccCat] ([AccCat_ID], [AccCat_No], [Arb_Des], [Eng_Des], [CompanyID]) VALUES (3, N'3', N'المصرف', N'Bank', 1)
GO
INSERT [dbo].[T_AccCat] ([AccCat_ID], [AccCat_No], [Arb_Des], [Eng_Des], [CompanyID]) VALUES (4, N'4', N'العملاء', N'Customer', 1)
GO
INSERT [dbo].[T_AccCat] ([AccCat_ID], [AccCat_No], [Arb_Des], [Eng_Des], [CompanyID]) VALUES (5, N'5', N'الموردين', N'Supplayr', 1)
GO
INSERT [dbo].[T_AccCat] ([AccCat_ID], [AccCat_No], [Arb_Des], [Eng_Des], [CompanyID]) VALUES (6, N'6', N'الموظفين', N'Employees', 1)
GO
INSERT [dbo].[T_AccCat] ([AccCat_ID], [AccCat_No], [Arb_Des], [Eng_Des], [CompanyID]) VALUES (7, N'7', N'الإيرادات', N'The Revenues', 1)
GO
INSERT [dbo].[T_AccCat] ([AccCat_ID], [AccCat_No], [Arb_Des], [Eng_Des], [CompanyID]) VALUES (8, N'8', N'المصاريف', N'Expenses', 1)
GO
INSERT [dbo].[T_AccCat] ([AccCat_ID], [AccCat_No], [Arb_Des], [Eng_Des], [CompanyID]) VALUES (9, N'9', N'خصوم', N'LIABILITIES', 1)
GO
INSERT [dbo].[T_AccCat] ([AccCat_ID], [AccCat_No], [Arb_Des], [Eng_Des], [CompanyID]) VALUES (10, N'10', N'حقوق الملكية', N'Property Rights', 1)
GO
INSERT [dbo].[T_AccCat] ([AccCat_ID], [AccCat_No], [Arb_Des], [Eng_Des], [CompanyID]) VALUES (11, N'11', N'النزلاء', N'Guests', 1)
GO
INSERT [dbo].[T_AccCat] ([AccCat_ID], [AccCat_No], [Arb_Des], [Eng_Des], [CompanyID]) VALUES (12, N'12', N'المستأجرين', N'Tenant', 1)
GO
SET IDENTITY_INSERT [dbo].[T_AccCat] OFF
GO
SET IDENTITY_INSERT [dbo].[T_AccDef] ON 
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (1, N'1', N'الموجودات', N'Assets', N'', 1, N'', 1, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (2, N'101', N'الموجودات الثابتة', N'Fixed Assets', N'1', 2, N'', 1, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (3, N'1011', N'الأراضي', N'The Lands', N'101', 3, N'', 1, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (247, N'10110', N'العقارات', N'Real Est', N'101', 3, NULL, 1, 0, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (4, N'1011001', N'الأراضي', N'Lands', N'1011', 4, N'', 1, 0, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (5, N'1012', N'المباني', N'The Buildings', N'101', 3, N'', 1, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (6, N'1012001', N'مباني', N'Buildings', N'1012', 4, N'', 1, 0, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (7, N'1013', N'السيارات', N'Cars', N'101', 3, N'', 1, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (8, N'1013001', N'سيارات وادوات النقل', N'Cars and transport tools', N'1013', 4, N'', 1, 0, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (9, N'1014', N'الأجهزة والمعدات', N'The Machin and Equipment', N'101', 3, N'', 1, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (10, N'1014001', N'أجهزة ومعدات', N'Machin and Equipment', N'1014', 4, N'', 1, 0, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (11, N'1015', N'الأثاث والمفروشات', N'The Furniture', N'101', 3, N'', 1, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (12, N'1015001', N'أثاث ومفروشات', N'Furniture', N'1015', 4, N'', 1, 0, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (13, N'1016', N'الديكورات', N'Decorations', N'101', 3, N'', 1, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (14, N'1016001', N'تحسينات وديكورات وتجهيزات', N'Decorations and equipment', N'1016', 4, N'', 1, 0, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (15, N'1017', N'الأجهزة المكتبية وبرامج', N'Office Devices and programs', N'101', 3, N'', 1, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (16, N'1017001', N'أجهزة حاسب آلي وبرامج', N'computers and programs', N'1017', 4, N'', 1, 0, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (17, N'1018', N'أجهزة التكييف', N'Air conditioners Devices', N'101', 3, N'', 1, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (18, N'1018001', N'المكيفات', N'Air conditioners', N'1018', 4, N'', 1, 0, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (19, N'1019', N'مصروفات ما قبل التشغيل', N'Pre-operating expenses', N'101', 3, N'', 1, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (20, N'1019001', N'مصاريف التأسيس', N'Incorporation expenses', N'1019', 4, N'', 1, 0, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (21, N'102', N'الموجودات المتداوله', N'Current Assets', N'1', 2, N'', 1, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (22, N'1020', N'الصندوق', N'Box', N'102', 3, N'', 2, 0, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (23, N'1020001', N'الصندوق النقدي', N'Box', N'1020', 4, N'', 2, 0, 0, 0, 0, 0, 3, N'', N'', N'', N'', N'', N'', 0, N'', 0, N'', NULL, 0, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (24, N'1021', N'المخزون', N'Inventory', N'102', 3, N'', 1, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (25, N'1021001', N'أول المدة', N'First time', N'1021', 4, N'', 1, 0, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (26, N'1021002', N'أخر المدة', N'Lastt time', N'1021', 4, N'', 1, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (27, N'1021005', N'تسوية المخزون', N'Inventory settlement', N'1021', 4, N'', 1, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (28, N'1022', N'العملاء', N'Customers', N'102', 3, N'', 4, 0, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (29, N'1022001', N'عميل', N'Customer', N'1022', 4, N'', 4, 0, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (30, N'1023', N'التأمينات لدى الغير', N'Insurance for others', N'102', 3, N'', 1, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (31, N'1023001', N'تأمين لدى الغير', N'Insurance for others', N'1023', 4, N'', 1, 0, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (32, N'1023002', N'تامينات الإعتمادات المستندية', N'Insurance Documentary Credits', N'1023', 4, N'', 1, 0, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (33, N'1023003', N'تأمينات الضمان البنكي', N'Insurance Bank Guarantee', N'1023', 4, N'', 1, 0, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (34, N'1024', N'العهد والسلف', N'Covenant and advances', N'102', 3, N'', 1, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (35, N'1024001', N'حساب السلف', N'Loans', N'1024', 4, N'', 1, 0, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (36, N'1024002', N'الأمانات', N'Secretariats', N'1024', 4, N'', 1, 0, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (37, N'1025', N'أصول متداولة أخرى', N'Other Current Assets', N'102', 3, N'', 1, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (38, N'1025001', N'مدينون متنوعون', N'Owe diverse', N'1025', 4, N'', 1, 0, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (39, N'1025002', N'أوراق القبض', N'Notes receivable', N'1025', 4, N'', 1, 0, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (40, N'1025003', N'مصروفات مدفوعة مقدماً', N'Expenses paid in advance', N'1025', 4, N'', 1, 0, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (242, N'1026', N'النزلاء', N'Guests', N'102', 3, NULL, 11, 0, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (248, N'1027', N'المستأجرين', N'Tenant', N'102', 3, NULL, 12, 0, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (41, N'103', N'البنـــوك', N'Banks', N'1', 2, N'', 1, 3, 0, 0, 0, 0, 0, N'3', NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (42, N'1031', N'البنك الراجحي', N'Al Rajhi Bank', N'103', 3, N'', 3, 0, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (43, N'1031001', N'الراحجي - جدة', N'Al Rajhi - Jeddah', N'1031', 4, N'', 3, 0, 0, 0, 0, 0, 3, N'السعودية', N'--------', N'--------', N'--------', N'--------', N'--------', 0, NULL, 0, N' طريق المدينة', NULL, NULL, N'--------', NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0.008, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (44, N'1031002', N'الراحجي - الريــاض', N'Al Rajhi - Riydh', N'1031', 4, N'', 3, 0, 0, 0, 0, 0, 3, N'السعودية', N'--------', N'--------', N'--------', N'--------', N'--------', 0, NULL, 0, N' الخالدية', NULL, NULL, N'--------', NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0.008, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (45, N'1032', N'البنك الأهلي', N'Ahli Bank', N'103', 3, N'', 3, 0, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (46, N'1032001', N'الأهلي - جدة', N'Ahli - Jeddah', N'1032', 4, N'', 3, 0, 0, 0, 0, 0, 3, N'السعودية', N'--------', N'--------', N'--------', N'--------', N'--------', 0, NULL, 0, N' البلد', NULL, NULL, N'--------', NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0.008, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (47, N'1032002', N'الأهلي - أبها', N'ِAhli - Abhaa', N'1032', 4, N'', 3, 0, 0, 0, 0, 0, 3, N'السعودية', N'--------', N'--------', N'--------', N'--------', N'--------', 0, NULL, 0, N' السبعين', NULL, NULL, N'--------', NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0.008, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (46, N'2', N'الخصوم', N'LIABILITIES', N'', 1, N'', 9, 1, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (47, N'201', N'الخصوم الغير متداولة ( حقوق الملكية )', N'Non-current liabilities', N'2', 2, N'', 10, 1, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (48, N'2011', N'راس المال ', N'The Share capital', N'201', 3, N'', 10, 1, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (49, N'2011001', N'راس المال', N'Share capital', N'2011', 4, N'', 10, 1, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (50, N'2012', N'جاري الشركاء', N'Owners  Current Accounts', N'201', 3, N'', 10, 1, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (51, N'2012001', N'حساب جاري', N'Running account', N'2012', 4, N'', 10, 1, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (52, N'2012002', N'جاري الشريك 1', N'Owners Current Acc 1', N'2012', 4, N'', 10, 1, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (53, N'2012003', N'جاري الشريك 2', N'Owners  Current Acc 2', N'2012', 4, N'', 10, 1, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (54, N'2013', N'المسحوبات', N'Withdrawals', N'201', 3, N'', 10, 1, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (55, N'2013001', N'مسحوبات الشركاء', N'Withdrawals Partners', N'2013', 4, N'', 10, 1, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (56, N'2014', N'الأرباح والخسائر ( ملخص الدخل )', N'Income Summary - ( Profit and loss )', N'201', 3, N'', 10, 1, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (57, N'2014001', N'الأرباح و الخسائر المرحلة', N'Profits and losses', N'2014', 4, N'', 10, 1, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (58, N'2015', N'مجمع إهلاك', N'Depreciation complex', N'201', 3, N'', 10, 1, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (59, N'2015001', N'مجمع إهلاك أصول ثابتة', N'Depreciation of fixed assets complex', N'2015', 4, N'', 10, 1, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (60, N'2016', N'المخصصات', N'The Allocations', N'201', 3, N'', 10, 1, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (61, N'2016001', N'مخصصات', N'Allocations', N'2016', 4, N'', 10, 1, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (62, N'202', N'الخصوم المتداولة', N'Current liabilities', N'2', 2, N'', 9, 1, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (63, N'2021', N'الموردين', N'The Suppliers', N'202', 3, N'', 5, 0, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (64, N'2021001', N'مورد ', N'Supplier', N'2021', 4, N'', 5, 1, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (65, N'2022', N'خصوم متداولة أخرى', N'Other', N'202', 3, N'', 9, 1, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (66, N'2022001', N'دائنون متنوعون', N'Creditors diverse', N'2022', 4, N'', 9, 1, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (67, N'2022002', N'أوراق الدفع', N'Notes payable', N'2022', 4, N'', 9, 1, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (68, N'2022003', N'مصروفات مستحقة', N'Accrued expenses', N'2022', 4, N'', 9, 1, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (241, N'2023', N'ذمم الموظفين', N'Employee', N'202', 3, N'', 6, 1, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (69, N'3', N'الايرادات', N'The Revenues', N'', 1, N'', 7, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (70, N'301', N'إيرادات اخرى', N'Other Revenues', N'3', 2, N'1', 7, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (71, N'3011', N'إيرادات نشاط غير عادي', N'Revenue unusual activity', N'301', 3, N'', 7, 1, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (72, N'3011001', N'ايرادات خاصة', N'Special revenue', N'3011', 4, N'1', 7, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (243, N'3011002', N'إيرادات الفندق', N'Hotel Income', N'3011', 4, N'1', 7, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (73, N'3012', N'فوائد', N'Interest', N'301', 3, N'', 7, 1, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (74, N'3012001', N'فوائد دائنة', N'Interest payable', N'3012', 4, N'', 7, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (75, N'302', N'صافي المبيعات', N'Net sales', N'3', 2, N'', 7, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (76, N'3021', N'صافي المبيعات النقدية', N'Net cash sales', N'302', 3, N'', 7, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (77, N'3021001', N'المبيعات النقدية', N'Cash sales', N'3021', 4, N'4', 7, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (78, N'3021002', N'مردودات مبيعات نقدية', N'Returns cash sales', N'3021', 4, N'4', 7, 0, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (79, N'3021003', N'خصم مسموح به لمبيعات  نقدية', N'Discount is permitted for cash sales', N'3021', 4, N'4', 7, 0, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (80, N'3021004', N'خصم مسموح به لمردودات مبيعات  نقدية', N'Discount permitted returns cash sales', N'3021', 4, N'4', 7, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (81, N'3021005', N'المبيعات الآجلة', N'Sales futures', N'3021', 4, N'4', 7, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (82, N'3021006', N'مردودات مبيعات  الآجلة', N'Returns futures sales', N'3021', 4, N'4', 7, 0, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (83, N'3021007', N'خصم مسموح به لمبيعات  آجله', N'Discount allowed for futures sales', N'3021', 4, N'4', 7, 0, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (84, N'3021008', N'خصم مسموح به لمرتجع مبيعات  آجله', N'Discount permitted discards forward sales', N'3021', 4, N'4', 7, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (85, N'304', N'صافي المشتريات', N'Net purchases', N'3', 2, N'', 7, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (86, N'3041', N'صافي المشتريات نقدية', N'Net cash purchases', N'304', 3, N'', 7, 0, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (87, N'3041001', N'المشتريات النقدية', N'Cash purchases', N'3041', 4, N'4', 7, 0, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (88, N'3041002', N'مردودات مشتريات نقدية', N'Purchases cash returns', N'3041', 4, N'4', 7, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (89, N'3041003', N'خصم مكتسب لمشتريات نقدية', N'Purchases unearned cash discount', N'3041', 4, N'4', 7, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (90, N'3041004', N'خصم مكتسب مردودات مشتريات نقدية', N'Discount acquired cash returns Purchases', N'3041', 4, N'4', 7, 0, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (91, N'3041005', N'المشتريات الآجلة', N'Purchases futures', N'3041', 4, N'4', 7, 0, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (92, N'3041006', N'مردودات مشتريات الآجلة', N'Returns purchases futures', N'3041', 4, N'4', 7, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (93, N'3041007', N'خصم مكتسب لمشتريات آجله*', N'Acquired forward purchase discount', N'3041', 4, N'4', 7, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (94, N'3041008', N'خصم مكتسب مردودات مشتريات آجله', N'Purchases returns unearned discount futures', N'3041', 4, N'4', 7, 0, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (95, N'305', N'تكلفة البضاعة', N'Cost of goods', N'3', 2, N'', 7, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (96, N'3051', N'تكلفة البضاعة المباعة', N'Cost of goods sold', N'305', 3, N'', 7, 0, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (97, N'3051001', N'إنتاج أصناف - تصنيع', N'Production of varieties', N'3051', 4, N'', 7, 0, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (244, N'3051002', N'تكلفة المواد الخام', N'Cost of raw materials', N'3051', 4, N'', 7, 0, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (98, N'4', N'المصروفات', N'Expenses', N'', 1, N'', 8, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (99, N'401', N'مصروفات عمومية و إدارية', N'General expenses', N'4', 2, N'', 8, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (100, N'4011', N'المصـروفات العامة', N'Expenses', N'401', 3, N'', 8, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (101, N'4011001', N'أجور ومرتبات', N'Salaries and wages', N'4011', 4, N'', 8, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (102, N'4011002', N'أجر إضافي', N'Additional', N'4011', 4, N'', 8, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (185, N'4011003', N'بدلات ومكافآت العاملين', N'Allowances and bonuses of employees', N'4011', 4, N'', 8, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (186, N'4011004', N'تأمينات اجتماعية وطبية', N' Social and medical insurance', N'4011', 4, N'', 8, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (187, N'4011005', N'تذاكر طيران وسفر', N'Airline and travel tickets', N'4011', 4, N'', 8, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (188, N'4011006', N'قرطاسية', N'Stationery', N'4011', 4, N'', 8, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (189, N'4011007', N'محروقات', N'Fuel', N'4011', 4, N'', 8, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (190, N'4011008', N'هاتف', N'Phone', N'4011', 4, N'', 8, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (191, N'4011009', N'كهرباء', N'Electricity', N'4011', 4, N'', 8, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (192, N'4011010', N'إيجارات', N'Rents', N'4011', 4, N'', 8, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (193, N'4011011', N'رسوم حكومية', N'Governmental fees', N'4011', 4, N'', 8, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (194, N'4011012', N'عمولات بنكية', N'Bank commissions', N'4011', 4, N'', 8, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (195, N'4011013', N'أجور شحن', N'Shipping fees', N'4011', 4, N'', 8, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (196, N'4011014', N'نظافة', N'Cleanliness', N'4011', 4, N'', 8, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (230, N'4011015', N'صيانة عامة', N'General Maintenance', N'4011', 4, N'', 8, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (231, N'4011016', N'تأشيرات واستقدام', N'The introduction of visas', N'4011', 4, N'', 8, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (232, N'4011017', N'رسوم إقامات وتراخيص عمل', N'Residency and work permit fees', N'4011', 4, N'', 8, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (233, N'4011018', N'نقل وتعتيق', N'Transport and aging', N'4011', 4, N'', 8, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (234, N'4011019', N'ضيافة واستقبال', N'Hospitality', N'4011', 4, N'', 8, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (235, N'4011020', N'مياه', N'Water', N'4011', 4, N'', 8, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (236, N'4011021', N'مصاريف نثرية', N'Incidental expenses', N'4011', 4, N'', 8, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (237, N'4011022', N'دعم فني', N'Technical Support', N'4011', 4, N'', 8, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (238, N'4011023', N'أتعاب واستشارات', N'Consulting', N'4011', 4, N'', 8, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (239, N'4011024', N'الزكاة', N'Tax', N'4011', 4, N'', 8, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (240, N'4011025', N'مصروف إهلاك اصول ثابتة', N'Depreciation of fixed assets expense', N'4011', 4, N'', 8, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (245, N'4011026', N'القيمة المضافة - ضريبة المبيعات', N'Sales Tax', N'4011', 4, N'', 8, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (246, N'4011027', N'القيمة المضافة - ضريبة المشتريات', N'Purchaes Tax', N'4011', 4, N'', 8, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (221, N'402', N'مصروفات صناعية', N'Industrial expenses', N'4', 2, N'', 8, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (222, N'4021', N'مصروفات تشغيلية ( صناعية )', N'Operating expenses (industrial)', N'402', 3, N'', 8, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (223, N'4021001', N'مواد صناعية', N'Industrial materials', N'4021', 4, N'', 8, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (224, N'4021002', N'أدوات ومعدات تشغيلية', N'Operational tools and equipment', N'4021', 4, N'', 8, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (225, N'403', N'مصروفات تسويقية', N'Marketing expenses', N'4', 2, N'', 8, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (226, N'4031', N'دعاية واعلان', N'Propaganda', N'403', 3, N'', 8, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (228, N'4031001', N'إعلانات تجارية', N'Commercials', N'4031', 4, N'', 8, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
INSERT [dbo].[T_AccDef] ([AccDef_ID], [AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [BankComm], [TaxNo], [TotPoints], [MaxDisCust], [vColNum1], [vColNum2], [vColStr1], [vColStr2], [vColStr3], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES (229, N'4031002', N'البرشورات والبطائق الترويجية', N'Promotional Card', N'4031', 4, N'', 8, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, NULL, NULL, N'', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, N'', N'', N'', NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'', 0, 0, 0, 0, N'', N'', N'', 0, N'', N'')
GO
SET IDENTITY_INSERT [dbo].[T_AccDef] OFF
GO
INSERT [dbo].[T_AddTyp] ([AddTyp_No], [NameA], [NameE]) VALUES (1, N'إضافي يوم           ', N'For Day’s        ')
GO
INSERT [dbo].[T_AddTyp] ([AddTyp_No], [NameA], [NameE]) VALUES (2, N'إضافي ساعة          ', N'For Hour’s         ')
GO
INSERT [dbo].[T_AddTyp] ([AddTyp_No], [NameA], [NameE]) VALUES (3, N'إنتداب سفر          ', N'Delegate            ')
GO
INSERT [dbo].[T_AinNatural] ([AinNatural_ID], [AinNatural_No], [NameA], [NameE], [Note]) VALUES (N'08696a45-14e0-4ee3-bd98-858dc4861c8e', 1, N'للإيجار', N'to Rent', N'----------')
GO
INSERT [dbo].[T_AinNatural] ([AinNatural_ID], [AinNatural_No], [NameA], [NameE], [Note]) VALUES (N'ffb6c5ee-e85a-4e8e-a0f5-d453d4ff463d', 2, N'للبيع', N'To Sales', N'--------')
GO
INSERT [dbo].[T_AinTyp] ([AinTyp_ID], [AinTyp_No], [NameA], [NameE], [Note]) VALUES (N'8f9260d3-3c6c-4e00-a989-89ed520c8230', 1, N'شقة', N'Flat', N'----------')
GO
INSERT [dbo].[T_AinTyp] ([AinTyp_ID], [AinTyp_No], [NameA], [NameE], [Note]) VALUES (N'f1fbd4c5-7fe3-4830-ae5f-b92b0f4b64f3', 2, N'مستودع', N'Store', N'--------')
GO
INSERT [dbo].[T_AinTyp] ([AinTyp_ID], [AinTyp_No], [NameA], [NameE], [Note]) VALUES (N'e32f19df-d0e5-45c6-b26c-49aa9d4e0a1e', 3, N'محل', N'Shop commercial', N'--------')
GO
INSERT [dbo].[T_AinTyp] ([AinTyp_ID], [AinTyp_No], [NameA], [NameE], [Note]) VALUES (N'35d46f05-6b84-47ea-bfa3-315429288c63', 4, N'معرض', N'Exhibition', N'--------')
GO
INSERT [dbo].[T_AinTyp] ([AinTyp_ID], [AinTyp_No], [NameA], [NameE], [Note]) VALUES (N'40f0228b-27c4-4569-bb41-6966aca524cb', 5, N'قاعة', N'Hall', N'--------')
GO
INSERT [dbo].[T_Bank] ([Bank_ID], [Bank_No], [Cod], [NameA], [NameE], [Note]) VALUES (N'2fc43218-2c8e-4ce0-8139-411ac61bbeb5', 1, N'', N'البنك الأهلي', N'', N'')
GO
INSERT [dbo].[T_Bank] ([Bank_ID], [Bank_No], [Cod], [NameA], [NameE], [Note]) VALUES (N'1c6add1c-ba68-4251-a46f-b8983185ebd3', 2, N'', N'الراحجي', N'', N'----------')
GO
INSERT [dbo].[T_Bank] ([Bank_ID], [Bank_No], [Cod], [NameA], [NameE], [Note]) VALUES (N'7ea6b450-0d15-49d3-becb-4c7b55978a6e', 3, N'', N'السعودي الهولندي', N'', N'----------')
GO
INSERT [dbo].[T_Bank] ([Bank_ID], [Bank_No], [Cod], [NameA], [NameE], [Note]) VALUES (N'c30b857d-a2cd-4fc3-9526-bd12d68deeef', 4, N'', N'الجزيرة', N'', N'----------')
GO
INSERT [dbo].[T_Bank] ([Bank_ID], [Bank_No], [Cod], [NameA], [NameE], [Note]) VALUES (N'e04fd042-28ee-4342-be95-c8d1ab60aefb', 5, N'', N'العربي', N'', N'----------')
GO
INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (1, N'أبها', N'Abha')
GO
INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (2, N'أبو عريش', N'Abo Aresh')
GO
INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (3, N'الباحة', N'Baha')
GO
INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (4, N'بريدة', N'Bridaa')
GO
INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (5, N'البكيرية', N'alBakeria')
GO
INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (6, N'بلجرشي', N'BoLjorashi')
GO
INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (7, N'بيشة', N'Bisha')
GO
INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (8, N'تبوك', N'Tabook')
GO
INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (9, N'تنومة', N'Tnomaa')
GO
INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (10, N'جدة', N'Jeddah')
GO
INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (11, N'جيزان', N'Jezaan')
GO
INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (12, N'الرياض', N'Riyadh')
GO
INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (13, N'الدمام', N'Damaam')
GO
INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (14, N'حائل', N'Haiel')
GO
INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (15, N'خميس مشيط', N'Khmiss Meshiat')
GO
INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (16, N'حفر الباطن          ', N'Haafr Albaten')
GO
INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (17, N'عرعر                ', N'Aar Aar ')
GO
INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (18, N'القطيف              ', N'Gatif')
GO
INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (20, N'القصيم              ', N'Qussim')
GO
INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (21, N'القاهرة             ', N'Cairo')
GO
INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (22, N'الاسكندرية          ', N'Iskendrya')
GO
INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (23, N'صنعاء               ', NULL)
GO
INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (24, N'عدن                 ', NULL)
GO
INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (25, N'دمشق                ', NULL)
GO
INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (26, N'حمص                 ', NULL)
GO
INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (27, N'عمان                ', NULL)
GO
INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (28, N'الدوحة              ', NULL)
GO
INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (29, N'المنامة             ', NULL)
GO
INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (30, N'دبي                 ', NULL)
GO
INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (31, N'مومباي              ', NULL)
GO
INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (32, N'الفلبين             ', NULL)
GO
INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (33, N'لاس فيغاس           ', NULL)
GO
INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (34, N'شيكاغو              ', NULL)
GO
INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (35, N'كوالامبور           ', NULL)
GO
INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (36, N'فيتنام              ', NULL)
GO
INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (37, N'بغداد               ', NULL)
GO
INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (38, N'الكويت              ', NULL)
GO
INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (39, N'تونس                ', NULL)
GO
INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (40, N'بيروت               ', NULL)
GO
INSERT [dbo].[T_BloodTyp] ([BloodTyp_No], [NameA], [NameE]) VALUES (1, N'A+   ', N'A+   ')
GO
INSERT [dbo].[T_BloodTyp] ([BloodTyp_No], [NameA], [NameE]) VALUES (2, N'A-   ', N'A-   ')
GO
INSERT [dbo].[T_BloodTyp] ([BloodTyp_No], [NameA], [NameE]) VALUES (3, N'B+   ', N'B+   ')
GO
INSERT [dbo].[T_BloodTyp] ([BloodTyp_No], [NameA], [NameE]) VALUES (4, N'B-   ', N'B-   ')
GO
INSERT [dbo].[T_BloodTyp] ([BloodTyp_No], [NameA], [NameE]) VALUES (5, N'O    ', N'O    ')
GO
INSERT [dbo].[T_CarTyp] ([CarTyp_ID], [CarTyp_No], [NameA], [NameE], [Note]) VALUES (N'916e164e-3f77-4690-a7cb-707764ba8d7c', 1, N'شفرليه', N'Ch', N'-----------')
GO
INSERT [dbo].[T_CarTyp] ([CarTyp_ID], [CarTyp_No], [NameA], [NameE], [Note]) VALUES (N'64a1b30d-230e-4940-a971-3006662537a3', 2, N'جمس', N'GMC', N'-----------')
GO
INSERT [dbo].[T_CarTyp] ([CarTyp_ID], [CarTyp_No], [NameA], [NameE], [Note]) VALUES (N'7e7ee1f8-3a55-4ba7-bb34-bcbecd1b3ec0', 3, N'هونداي', N'Hyundai', N'-----------')
GO
INSERT [dbo].[T_CarTyp] ([CarTyp_ID], [CarTyp_No], [NameA], [NameE], [Note]) VALUES (N'4a0543b5-56f2-4e32-8dad-f79d8ffe8896', 4, N'تويوتا', N'Toyota', N'-----------')
GO
SET IDENTITY_INSERT [dbo].[T_CATEGORY] ON 
GO
INSERT [dbo].[T_CATEGORY] ([CAT_ID], [CAT_No], [Arb_Des], [Eng_Des], [CompanyID], [TotalPurchaes], [TotalPoint], [CAT_Symbol]) VALUES (1, N'1', N'عـــام', N'Public', 1, 0, 0, N'')
GO
SET IDENTITY_INSERT [dbo].[T_CATEGORY] OFF
GO
INSERT [dbo].[T_City] ([City_ID], [City_No], [NameA], [NameE], [Note]) VALUES (N'7781ea2d-d8b2-4c72-8ddd-b67985e94fe2', 1, N'جدة', N'Jeddah', N'')
GO
INSERT [dbo].[T_City] ([City_ID], [City_No], [NameA], [NameE], [Note]) VALUES (N'823914d8-3203-4fec-a6ac-abda3efc7607', 2, N'الرياض', N'Riyadh', N'')
GO
INSERT [dbo].[T_City] ([City_ID], [City_No], [NameA], [NameE], [Note]) VALUES (N'ff3af6cd-0e00-4cd2-ac88-f0d4c939a577', 3, N'القاهرة', N'Cairo', N'')
GO
INSERT [dbo].[T_City] ([City_ID], [City_No], [NameA], [NameE], [Note]) VALUES (N'14b9aef8-7704-4a1e-9a44-7592fa9f4f82', 4, N'صنعاء', N'San''a', N'')
GO
INSERT [dbo].[T_City] ([City_ID], [City_No], [NameA], [NameE], [Note]) VALUES (N'cb2a73a6-c68b-42b4-ad14-8e12f64930fc', 5, N'ابها', N'Abhaa', N'')
GO
INSERT [dbo].[T_City] ([City_ID], [City_No], [NameA], [NameE], [Note]) VALUES (N'1166d7ba-34de-4871-b9d6-8544164adf1e', 6, N'بيروت', N'Birute', N'')
GO
INSERT [dbo].[T_City] ([City_ID], [City_No], [NameA], [NameE], [Note]) VALUES (N'9e94d17b-0f4b-4c46-aa69-091a302db846', 7, N'تونس', N'Tunisia', N'')
GO
INSERT [dbo].[T_City] ([City_ID], [City_No], [NameA], [NameE], [Note]) VALUES (N'768c4d11-a4ff-49c6-bc32-12667b53adad', 8, N'المنامة', N'Manaama', N'')
GO
INSERT [dbo].[T_City] ([City_ID], [City_No], [NameA], [NameE], [Note]) VALUES (N'9b58b074-4be0-4fc0-9cdc-7e9b19d0745e', 9, N'الاسكندرية', N'Iskendriaa', N'')
GO
INSERT [dbo].[T_City] ([City_ID], [City_No], [NameA], [NameE], [Note]) VALUES (N'15ab5c93-3023-4a91-a128-abf48a4a09ed', 10, N'بيشة', N'Bishaa', N'')
GO
INSERT [dbo].[T_City] ([City_ID], [City_No], [NameA], [NameE], [Note]) VALUES (N'6c719c20-51d6-42b7-94bc-d02272102d32', 11, N'دمشق', N'Demasq', N'')
GO
INSERT [dbo].[T_City] ([City_ID], [City_No], [NameA], [NameE], [Note]) VALUES (N'41bf61a2-d6ae-497d-a59f-460df25972a9', 12, N'بلجرشي', N'Blgoraashi', N'')
GO
INSERT [dbo].[T_City] ([City_ID], [City_No], [NameA], [NameE], [Note]) VALUES (N'bce7c960-e279-4ef9-8d59-e8858ca8e666', 13, N'عريش', N'Aarish', N'')
GO
INSERT [dbo].[T_City] ([City_ID], [City_No], [NameA], [NameE], [Note]) VALUES (N'31ee5d45-94de-47f3-840a-30c1eb6b41cf', 14, N'الدمام', N'Dammam', N'')
GO
INSERT [dbo].[T_City] ([City_ID], [City_No], [NameA], [NameE], [Note]) VALUES (N'42ef8d1e-162d-4868-b45c-208791d6391f', 15, N'الخرطوم', N'Khartoom', N'')
GO
SET IDENTITY_INSERT [dbo].[T_Company] ON 
GO
INSERT [dbo].[T_Company] ([Cop_ID], [CopNam], [Active], [Adder], [Tel1], [Tel2], [Fax], [Pox], [Symbl], [Eamil], [Mobl]) VALUES (1, N'مؤسسة       ', N'برامج', N'جدة', N'-------', N'---------', N'----------', N'-------', N'----------', N'----------', N'--------------')
GO
SET IDENTITY_INSERT [dbo].[T_Company] OFF
GO
INSERT [dbo].[T_Contract] ([Contract_ID], [Contract_No], [NameA], [NameE], [Note]) VALUES (N'd75681e4-ecb5-416e-b2ce-64be0417911b', 1, N'رئيسي', N'Main', N'----------')
GO
INSERT [dbo].[T_Contract] ([Contract_ID], [Contract_No], [NameA], [NameE], [Note]) VALUES (N'192c7bf7-4976-4a06-80d5-44a8a39132e1', 2, N'مؤقت', N'Temporary', N'-----------')
GO
SET IDENTITY_INSERT [dbo].[T_CstTbl] ON 
GO
INSERT [dbo].[T_CstTbl] ([Cst_ID], [Cst_No], [Arb_Des], [Eng_Des], [CompanyID], [CstFlied1], [CstFlied2], [CstFlied3], [CstFlied4], [CstFlied5]) VALUES (1, N'1', N'مركز تكلفة عام', N'Cost Center ', 1, N'', N'', N'', N'', N'')
GO
SET IDENTITY_INSERT [dbo].[T_CstTbl] OFF
GO
SET IDENTITY_INSERT [dbo].[T_Curency] ON 
GO
INSERT [dbo].[T_Curency] ([Curency_ID], [Curency_No], [Arb_Des], [Eng_Des], [Rate], [Symbol], [CompanyID]) VALUES (1, N'1', N'ريال سعودي', N'Rs', 1, N'RS', 1)
GO
INSERT [dbo].[T_Curency] ([Curency_ID], [Curency_No], [Arb_Des], [Eng_Des], [Rate], [Symbol], [CompanyID]) VALUES (2, N'2', N'دولا أمريكي', N'US', 3.75, N'$', 1)
GO
SET IDENTITY_INSERT [dbo].[T_Curency] OFF
GO
INSERT [dbo].[T_DayOfWeek] ([Day_No], [NameA], [NameE]) VALUES (1, N'السبت     ', N'Sat       ')
GO
INSERT [dbo].[T_DayOfWeek] ([Day_No], [NameA], [NameE]) VALUES (2, N'الأحد     ', N'Sun       ')
GO
INSERT [dbo].[T_DayOfWeek] ([Day_No], [NameA], [NameE]) VALUES (3, N'الأثنين   ', N'Mon       ')
GO
INSERT [dbo].[T_DayOfWeek] ([Day_No], [NameA], [NameE]) VALUES (4, N'الثلاثاء  ', N'Tues      ')
GO
INSERT [dbo].[T_DayOfWeek] ([Day_No], [NameA], [NameE]) VALUES (5, N'الأربعاء  ', N'Wednes    ')
GO
INSERT [dbo].[T_DayOfWeek] ([Day_No], [NameA], [NameE]) VALUES (6, N'الخميس    ', N'Thurs     ')
GO
INSERT [dbo].[T_DayOfWeek] ([Day_No], [NameA], [NameE]) VALUES (7, N'الجمعة    ', N'Fri       ')
GO
INSERT [dbo].[T_EqarNatural] ([EqarNatural_ID], [EqarNatural_No], [NameA], [NameE], [Note]) VALUES (N'a0724d8d-4764-4d44-90a4-138bec9a0dec', 1, N'للإيجار', N'to Rent', N'----------')
GO
INSERT [dbo].[T_EqarNatural] ([EqarNatural_ID], [EqarNatural_No], [NameA], [NameE], [Note]) VALUES (N'4bcb64e1-1897-40a7-b705-955a70f641a4', 2, N'للبيع', N'To Sales', N'--------')
GO
INSERT [dbo].[T_EqarTyp] ([EqarTyp_ID], [EqarTyp_No], [NameA], [NameE], [Note]) VALUES (N'404d5799-d96c-4461-bd43-4d88ddea630e', 1, N'سكني', N'residential', N'----------')
GO
INSERT [dbo].[T_EqarTyp] ([EqarTyp_ID], [EqarTyp_No], [NameA], [NameE], [Note]) VALUES (N'326ec889-2aee-4d38-b22e-f152a5796c6a', 2, N'تجاري', N'commercial', N'--------')
GO
INSERT [dbo].[T_EqarTyp] ([EqarTyp_ID], [EqarTyp_No], [NameA], [NameE], [Note]) VALUES (N'8a56f18d-cadd-4541-9e5a-63d1d06b3a93', 3, N'سكني تجاري', N'residential commercial', N'--------')
GO
SET IDENTITY_INSERT [dbo].[T_GdAuto] ON 
GO
INSERT [dbo].[T_GdAuto] ([GdAuto_Id], [Acc0], [Acc1], [Acc2], [Acc3]) VALUES (1, 1020001, 2014001, 1021001, 1021002)
GO
SET IDENTITY_INSERT [dbo].[T_GdAuto] OFF
GO
INSERT [dbo].[T_IDType] ([IDType_ID], [Arb_Des], [Eng_Des], [Usr], [UsrNam], [CompanyID]) VALUES (1, N'بطاقة أحوال', N'Status Card', NULL, NULL, 1)
GO
INSERT [dbo].[T_IDType] ([IDType_ID], [Arb_Des], [Eng_Des], [Usr], [UsrNam], [CompanyID]) VALUES (2, N'جواز سفر عادي', N'Normal Passport', NULL, NULL, 1)
GO
INSERT [dbo].[T_IDType] ([IDType_ID], [Arb_Des], [Eng_Des], [Usr], [UsrNam], [CompanyID]) VALUES (3, N'جواز سفر دبلوماسي', N'Diplomatic passport', NULL, NULL, 1)
GO
INSERT [dbo].[T_IDType] ([IDType_ID], [Arb_Des], [Eng_Des], [Usr], [UsrNam], [CompanyID]) VALUES (4, N'إقامة', N'ID', NULL, NULL, 1)
GO
INSERT [dbo].[T_IDType] ([IDType_ID], [Arb_Des], [Eng_Des], [Usr], [UsrNam], [CompanyID]) VALUES (5, N'كرت عائلة', N'Family Card', NULL, NULL, 1)
GO
INSERT [dbo].[T_IDType] ([IDType_ID], [Arb_Des], [Eng_Des], [Usr], [UsrNam], [CompanyID]) VALUES (6, N'عقد نكاح', N'Marriage contract', NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[T_InfoTb] ON 
GO
INSERT [dbo].[T_InfoTb] ([InfoTb_ID], [fldFlag], [fldValue], [grpFlag], [emptFld1], [emptFld2], [emptFld3], [FontN], [FontS], [FontB], [FontI], [CompanyID]) VALUES (1, N'rTrwes', N'0', N'PRNTINF', N'', N'', N'', N'Arabic Transparent', 12, NULL, NULL, NULL)
GO
INSERT [dbo].[T_InfoTb] ([InfoTb_ID], [fldFlag], [fldValue], [grpFlag], [emptFld1], [emptFld2], [emptFld3], [FontN], [FontS], [FontB], [FontI], [CompanyID]) VALUES (2, N'lTrwes', N'0', N'PRNTINF', N'', N'', N'', N'Arabic Transparent', 12, NULL, NULL, NULL)
GO
INSERT [dbo].[T_InfoTb] ([InfoTb_ID], [fldFlag], [fldValue], [grpFlag], [emptFld1], [emptFld2], [emptFld3], [FontN], [FontS], [FontB], [FontI], [CompanyID]) VALUES (3, N'rMrg', N'0.5', N'PRNTINF', N'', N'', N'', N'Arabic Transparent', 12, NULL, NULL, NULL)
GO
INSERT [dbo].[T_InfoTb] ([InfoTb_ID], [fldFlag], [fldValue], [grpFlag], [emptFld1], [emptFld2], [emptFld3], [FontN], [FontS], [FontB], [FontI], [CompanyID]) VALUES (4, N'lMrg', N'1', N'PRNTINF', N'', N'', N'', N'Arabic Transparent', 12, NULL, NULL, NULL)
GO
INSERT [dbo].[T_InfoTb] ([InfoTb_ID], [fldFlag], [fldValue], [grpFlag], [emptFld1], [emptFld2], [emptFld3], [FontN], [FontS], [FontB], [FontI], [CompanyID]) VALUES (5, N'tMrg', N'0.5', N'PRNTINF', N'', N'', N'', N'Arabic Transparent', 12, NULL, NULL, NULL)
GO
INSERT [dbo].[T_InfoTb] ([InfoTb_ID], [fldFlag], [fldValue], [grpFlag], [emptFld1], [emptFld2], [emptFld3], [FontN], [FontS], [FontB], [FontI], [CompanyID]) VALUES (6, N'bMrg', N'0.5', N'PRNTINF', N'', N'', N'', N'Arabic Transparent', 12, NULL, NULL, NULL)
GO
INSERT [dbo].[T_InfoTb] ([InfoTb_ID], [fldFlag], [fldValue], [grpFlag], [emptFld1], [emptFld2], [emptFld3], [FontN], [FontS], [FontB], [FontI], [CompanyID]) VALUES (7, N'wLogo', N'0.5', N'PRNTINF', N'', N'', N'', N'Arabic Transparent', 12, NULL, NULL, NULL)
GO
INSERT [dbo].[T_InfoTb] ([InfoTb_ID], [fldFlag], [fldValue], [grpFlag], [emptFld1], [emptFld2], [emptFld3], [FontN], [FontS], [FontB], [FontI], [CompanyID]) VALUES (8, N'hLogo', N'1', N'PRNTINF', N'', N'', N'', N'Arabic Transparent', 12, NULL, NULL, NULL)
GO
INSERT [dbo].[T_InfoTb] ([InfoTb_ID], [fldFlag], [fldValue], [grpFlag], [emptFld1], [emptFld2], [emptFld3], [FontN], [FontS], [FontB], [FontI], [CompanyID]) VALUES (9, N'rTrwes1', N'مؤسسة       ', N'PRNTINF', N'', N'', N'', N'Arial', 12, 1, 0, NULL)
GO
INSERT [dbo].[T_InfoTb] ([InfoTb_ID], [fldFlag], [fldValue], [grpFlag], [emptFld1], [emptFld2], [emptFld3], [FontN], [FontS], [FontB], [FontI], [CompanyID]) VALUES (10, N'rTrwes2', N'المملكة العربية السعودية - جدة ', N'PRNTINF', N'', N'', N'', N'Arial', 12, 1, 0, NULL)
GO
INSERT [dbo].[T_InfoTb] ([InfoTb_ID], [fldFlag], [fldValue], [grpFlag], [emptFld1], [emptFld2], [emptFld3], [FontN], [FontS], [FontB], [FontI], [CompanyID]) VALUES (11, N'rTrwes3', N'ص.ب ------ جدة -------', N'PRNTINF', N'', N'', N'', N'Arial', 12, 1, 0, NULL)
GO
INSERT [dbo].[T_InfoTb] ([InfoTb_ID], [fldFlag], [fldValue], [grpFlag], [emptFld1], [emptFld2], [emptFld3], [FontN], [FontS], [FontB], [FontI], [CompanyID]) VALUES (12, N'rTrwes4', N'هاتف : ------- / ------- فاكس ------', N'PRNTINF', N'', N'', N'', N'Arial', 12, 1, 0, NULL)
GO
INSERT [dbo].[T_InfoTb] ([InfoTb_ID], [fldFlag], [fldValue], [grpFlag], [emptFld1], [emptFld2], [emptFld3], [FontN], [FontS], [FontB], [FontI], [CompanyID]) VALUES (13, N'lTrwes1', N'Application Software Solutions', N'PRNTINF', N'', N'', N'', N'Arial', 12, 1, 0, NULL)
GO
INSERT [dbo].[T_InfoTb] ([InfoTb_ID], [fldFlag], [fldValue], [grpFlag], [emptFld1], [emptFld2], [emptFld3], [FontN], [FontS], [FontB], [FontI], [CompanyID]) VALUES (14, N'lTrwes2', N'Kingdom of Saudi Arabia - Jeddah', N'PRNTINF', N'', N'', N'', N'Arial', 12, 1, 0, NULL)
GO
INSERT [dbo].[T_InfoTb] ([InfoTb_ID], [fldFlag], [fldValue], [grpFlag], [emptFld1], [emptFld2], [emptFld3], [FontN], [FontS], [FontB], [FontI], [CompanyID]) VALUES (15, N'lTrwes3', N'P.O. Box ------- Jeddah ------', N'PRNTINF', N'', N'', N'', N'Arial', 12, 1, 0, NULL)
GO
INSERT [dbo].[T_InfoTb] ([InfoTb_ID], [fldFlag], [fldValue], [grpFlag], [emptFld1], [emptFld2], [emptFld3], [FontN], [FontS], [FontB], [FontI], [CompanyID]) VALUES (16, N'lTrwes4', N'Tel.: -------- / --------- Ex. Fax -----', N'PRNTINF', N'', N'', N'', N'Arial', 12, 1, 0, NULL)
GO
SET IDENTITY_INSERT [dbo].[T_InfoTb] OFF
GO
INSERT [dbo].[T_Insurance] ([Insurance_ID], [Insurance_No], [NameA], [NameE], [Note]) VALUES (N'5ccc3b97-79e1-406c-8604-89e612e544aa', 1, N'بوبا', N'bupa', N'------')
GO
INSERT [dbo].[T_Insurance] ([Insurance_ID], [Insurance_No], [NameA], [NameE], [Note]) VALUES (N'0475b5ea-92ff-4604-88d4-965c16840017', 2, N'التعاونية', N'AL-Tawniya', N'------')
GO
SET IDENTITY_INSERT [dbo].[T_INVSETTING] ON 
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (1, 1, N'فاتورة مبيعات                                     ', N'Sales Invoice                                     ', N'212', N'1         ', N'نقدي                          ', N'آجل       ', NULL, NULL, NULL, N'Cash      ', N'Credit    ', NULL, NULL, NULL, -2147483633, 12640511, 0, N'العميل              ', NULL, NULL, NULL, NULL, N'Customer            ', NULL, NULL, NULL, NULL, N'3021001        ', N'1020001        ', NULL, NULL, NULL, NULL, NULL, N'3021005        ', N'***', N'3021005', N'1022001', N'3021001', N'1020001', N'3021005', N'***', 1, 1, 1, 1, 0, 6, N'Microsoft XPS Document Writer', N'111', N'1011 ', 1, 1, 1, N'', 1, NULL, 0, N'11011011', 0, N'1020001        ', N'4011026', 0, N'3021003', N'3021001', N'10', 0, N'***', N'4011012', N'***', N'4011026')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (2, 2, N'فاتورة مشتريات                                    ', N'Purchase Receipt                                  ', N'111', N'1         ', N'نقدي                          ', N'آجل       ', NULL, NULL, NULL, N'Cash      ', N'Credit    ', NULL, NULL, NULL, -2147483633, 14737632, 8, N'المورد              ', NULL, NULL, NULL, NULL, N'Supplyer            ', NULL, NULL, NULL, NULL, N'1020001', N'3041001', NULL, NULL, NULL, NULL, NULL, N'***', N'3041005', N'1022001', N'3041005', N'1020001', N'3041001', N'***', N'3041005', 1, 1, 1, 1, 0, 6, NULL, N'111', N'1100 ', 1, 1, 1, N'', 1, NULL, 0, N'11101011', 0, N'4011027', N'1020001', 0, N'3041001', N'3041003', N'10', 0, N'4011012', N'***', N'4011027', N'***')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (3, 3, N' مرتجع مبيعات                                     ', N'Sales Return                                      ', N'111', N'1         ', N'نقدي                          ', N'آجل       ', NULL, NULL, NULL, N'Cash      ', N'Credit    ', NULL, NULL, NULL, -2147483633, 12640511, 0, N'العميل              ', NULL, NULL, NULL, NULL, N'Customer            ', NULL, NULL, NULL, NULL, N'1020001', N'3021002', NULL, NULL, NULL, NULL, NULL, N'***', N'3021006', N'1022001', N'3021006', N'1020001', N'3021002', N'***', N'3021006', 1, 1, 1, 1, 0, 6, NULL, N'111', N'1011 ', 1, 1, 1, N'', 1, NULL, 0, N'11011011', 0, N'4011026', N'1020001', 0, N'3021002', N'3021004', N'10', 0, N'***', N'***', N'4011026', N'***')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (4, 4, N'مرتجع مشتريات                                     ', N'Purchase Return                                   ', N'212', N'1         ', N'نقدي                          ', N'آجل       ', NULL, NULL, NULL, N'Cash      ', N'Credit    ', NULL, NULL, NULL, -2147483633, 14737632, 8, N'المورد              ', NULL, NULL, NULL, NULL, N'Supplyer            ', NULL, NULL, NULL, NULL, N'3041002', N'1020001', NULL, NULL, NULL, NULL, NULL, N'3041006', N'***', N'3041006', N'1022001', N'3041002', N'1020001', N'3041006', N'***', 1, 1, 1, 1, 0, 6, NULL, N'111', N'1100 ', 1, 1, 1, N'', 1, NULL, 0, N'11101011', 0, N'1020001', N'4011027', 0, N'3041004', N'3041002', N'10', 0, N'***', N'***', N'***', N'4011027')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (5, 5, N'سند إدخال بضاعة                                   ', N'Transfer In                                       ', N'101', N'1         ', N'إدخال                         ', NULL, NULL, NULL, NULL, N'Entry     ', NULL, NULL, NULL, NULL, -2147483633, 16777152, 6, N'من مستودع           ', NULL, NULL, NULL, NULL, N'Store               ', NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, NULL, N'111', N'1110 ', 1, 1, 1, N'', 1, NULL, 0, N'11101011', 0, N'***', N'***', 0, N'***', N'***', N'10', 0, N'***', N'***', N'***', N'***')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (6, 6, N'سند إخراج بضاعة                                   ', N'Transfer Out                                      ', N'202', N'1         ', N'إخراج                         ', NULL, NULL, NULL, NULL, N'Out       ', NULL, NULL, NULL, NULL, -2147483633, 16777152, 6, N'من مستودع           ', NULL, NULL, NULL, NULL, N'Store               ', NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, NULL, N'111', N'1110 ', 1, 1, 1, N'', 1, NULL, 0, N'11101011', 0, N'***', N'***', 0, N'***', N'***', N'10', 0, N'***', N'***', N'***', N'***')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (7, 7, N'عرض سعر للعملاء                                   ', N'Sales Qutation                                    ', N'000', N'1         ', N'عرض                           ', NULL, NULL, NULL, NULL, N'Qutation  ', NULL, NULL, NULL, NULL, -2147483633, 12640511, 0, N'العميل              ', NULL, NULL, NULL, NULL, N'Customer            ', NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, NULL, N'111', N'1011 ', 1, 1, 1, N'', 1, NULL, 0, N'11011011', 0, N'***', N'***', 0, N'***', N'***', N'10', 0, N'***', N'***', N'***', N'***')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (8, 8, N'عرض سعر للموردين                                  ', N'Goods Receipt                                     ', N'101', N'1         ', N'عرض                           ', NULL, NULL, NULL, NULL, N'Receipt   ', NULL, NULL, NULL, NULL, -2147483633, 14737632, 6, N'المورد              ', NULL, NULL, NULL, NULL, N'Supplyer            ', NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, NULL, N'111', N'1100 ', 1, 1, 1, N'', 1, NULL, 0, N'11011011', 0, N'***', N'***', 0, N'***', N'***', N'10', 0, N'***', N'***', N'***', N'***')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (9, 9, N'طلب شراء                                          ', N'Purchase Order                                    ', N'000', N'1         ', N'طلب                           ', NULL, NULL, NULL, NULL, N'Order     ', NULL, NULL, NULL, NULL, -2147483633, 16771816, 7, N'المورد              ', NULL, NULL, NULL, NULL, N'Supplyer            ', NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, NULL, N'111', N'1100 ', 1, 1, 1, N'', 1, NULL, 0, N'11101011', 0, N'***', N'***', 0, N'***', N'***', N'10', 0, N'***', N'***', N'***', N'***')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (21, 21, N'الطلبات المحلية', N'Local Orders', N'910', N'1         ', N'سند                           ', NULL, NULL, NULL, NULL, N'Snad      ', NULL, NULL, NULL, NULL, -2147483633, 12641511, 8, N'الحساب              ', NULL, NULL, NULL, NULL, N'Account             ', NULL, NULL, NULL, NULL, N'3021005        ', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, NULL, N'111', N'1011      ', 1, 1, 1, N'', 1, NULL, 0, NULL, 0, N'***', N'***', 0, N'***', N'***', NULL, 0, N'***', N'***', N'***', N'***')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (22, 22, N'طباعة الباركود', N'Print BarCode', N'2', N'1', NULL, NULL, NULL, NULL, N'0', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 1, N'ZDesigner TLP 2844', N'101', NULL, 1, 1, 1, N'', 1, NULL, 0, NULL, 0, N'***', N'***', 0, N'***', N'***', NULL, 0, N'***', N'***', N'***', N'***')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (23, 23, N'ورقة قبض                                          ', N'Receipt Peaper                                   ', N'1', N'1         ', N'أستلمنا من المكرم             ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, -2147483633, 16706518, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 10, N'', N'111', NULL, 1, 1, 1, N'', 1, NULL, 0, NULL, 0, N'***', N'***', 0, N'***', N'***', NULL, 0, N'***', N'***', N'***', N'***')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (24, 24, N'ورقة صرف                                          ', N'Payment Peaper                                   ', N'1', N'1         ', N'أصرفوا لي المكرم              ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, -2147483633, 14737632, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, N'', N'101', NULL, 1, 1, 1, N'', 1, NULL, 0, NULL, 0, N'***', N'***', 0, N'***', N'***', NULL, 0, N'***', N'***', N'***', N'***')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (25, 25, N'إيداع بنكي                                        ', N'Receipt Peaper                                   ', N'1', N'1         ', N'أستلمنا من المكرم             ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, -2147483633, 16706518, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 10, N'', N'111', NULL, 1, 1, 1, N'', 1, NULL, 0, NULL, 0, N'***', N'***', 0, N'***', N'***', NULL, 0, N'***', N'***', N'***', N'***')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (26, 26, N'سحب بنكي                                          ', N'Payment Peaper                                   ', N'1', N'1         ', N'أصرفوا لي المكرم              ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, -2147483633, 14737632, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, N'', N'101', NULL, 1, 1, 1, N'', 1, NULL, 0, NULL, 0, N'***', N'***', 0, N'***', N'***', NULL, 0, N'***', N'***', N'***', N'***')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (27, 27, N'سند قبض نزيل', N'Catch Receipt Guest', N'1', N'1         ', N'أستلمنا من المكرم             ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, -2147483633, 16706518, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 10, N'', N'111', NULL, 1, 1, 1, N'', 1, NULL, 0, NULL, 0, N'***', N'***', 0, N'***', N'***', NULL, 0, N'***', N'***', N'***', N'***')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (28, 28, N'سند صرف نزيل', N'receipt Guest', N'1', N'1         ', N'أصرفوا لي المكرم              ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, -2147483633, 16706518, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 10, N'', N'111', NULL, 1, 1, 1, N'', 1, NULL, 0, NULL, 0, N'***', N'***', 0, N'***', N'***', NULL, 0, N'***', N'***', N'***', N'***')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (29, 29, N'سند قبض مستأجر', N'Catch Receipt Tenant', N'1', N'1         ', N'أستلمنا من المكرم             ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, -2147483633, 16706518, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 10, N'', N'111', NULL, 1, 1, 1, N'', 1, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (30, 30, N'سند صرف مستأجر', N'receipt Tenant', N'1', N'1         ', N'أصرفوا لي المكرم              ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, -2147483633, 16706518, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 10, N'', N'111', NULL, 1, 1, 1, N'', 1, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (100, 100, N'عـــام', N'Public', N'212', N'1         ', N'نقدي                          ', N'آجل       ', NULL, NULL, NULL, N'Cash      ', N'Credit    ', NULL, NULL, NULL, -2147483633, 12640511, 0, N'العميل              ', NULL, NULL, NULL, NULL, N'Customer            ', NULL, NULL, NULL, NULL, N'3021001        ', N'1020001        ', NULL, NULL, NULL, NULL, NULL, N'3021005        ', N'***', N'3021005', N'1022001', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, N'Microsoft XPS Document Writer', N'110', N'1011 ', 1, 1, 1, NULL, NULL, 1, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (10, 10, N'سند تسوية                                         ', N'Stock Adjustment', N'101', N'1         ', N'سند                           ', NULL, NULL, NULL, NULL, N'Snad      ', NULL, NULL, NULL, NULL, -2147483633, 16771816, 6, N'المستودع            ', NULL, NULL, NULL, NULL, N'Store               ', NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, NULL, N'111', N'1110 ', 1, 1, 1, N'', 1, NULL, 0, N'11101011', 0, N'***', N'***', 0, N'***', N'***', N'10', 0, N'***', N'***', N'***', N'***')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (11, 11, N'سند قيد                                           ', N'Journal Voucher                                   ', N'1', N'1         ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, -2147483633, 12640511, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 10, N'', N'101', NULL, 1, 1, 1, N'', 1, NULL, 0, NULL, 0, N'***', N'***', 0, N'***', N'***', NULL, 0, N'***', N'***', N'***', N'***')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (12, 12, N'سند قبض                                           ', N'Receipt Voucher                                   ', N'1', N'1         ', N'أستلمنا من المكرم             ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, -2147483633, 16706518, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 10, N'', N'111', NULL, 1, 1, 1, N'', 1, NULL, 0, NULL, 0, N'***', N'***', 0, N'***', N'***', NULL, 0, N'***', N'***', N'***', N'***')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (13, 13, N'سند صرف                                           ', N'Payment Voucher                                   ', N'1', N'1         ', N'أصرفوا لي المكرم              ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, -2147483633, 14737632, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, N'', N'101', NULL, 1, 1, 1, N'', 1, NULL, 0, NULL, 0, N'***', N'***', 0, N'***', N'***', NULL, 0, N'***', N'***', N'***', N'***')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (14, 14, N'بضاعة اول المدة', N'Open Quantities                                   ', N'303', N'1         ', N'سند                           ', NULL, NULL, NULL, NULL, N'Snad      ', NULL, NULL, NULL, NULL, -2147483633, 16706518, 6, N'المستودع            ', NULL, NULL, NULL, NULL, N'Store               ', NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, NULL, N'111', N'1110 ', 1, 1, 1, N'', 1, NULL, 0, N'11101011', 0, N'***', N'***', 0, N'***', N'***', N'10', 0, N'***', N'***', N'***', N'***')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (15, 15, N'خدمات النزلاء', N'Guests Services', N'414', N'1         ', N'سند                           ', NULL, NULL, NULL, NULL, N'Snad      ', NULL, NULL, NULL, NULL, -2147483633, 16706518, 6, N'المستودع            ', NULL, NULL, NULL, NULL, N'Store               ', NULL, NULL, NULL, NULL, N'4011002        ', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, NULL, N'111', N'1110 ', 1, 1, 1, N'', 1, NULL, 0, NULL, 0, N'***', N'***', 0, N'***', N'***', NULL, 0, N'***', N'***', N'***', N'***')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (16, 16, N'شؤون الموظفين', N'HR', N'1', N'1         ', N'أمر تصنيع                     ', NULL, NULL, NULL, NULL, N'Snad      ', NULL, NULL, NULL, NULL, -2147483633, 16706518, 8, N'نوع السند           ', NULL, NULL, NULL, NULL, N'Store               ', NULL, NULL, NULL, NULL, N'3051002        ', N'3051001        ', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, N'', N'101', NULL, 1, 1, 1, N'', 1, NULL, 0, N'11101011', 0, N'***', N'***', 0, N'***', N'***', N'10', 0, N'***', N'***', N'***', N'***')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (17, 17, N'أمر صرف بضاعة                                     ', N'Payment Order                                     ', N'212', N'1         ', N'سند                           ', NULL, NULL, NULL, NULL, N'Snad      ', NULL, NULL, NULL, NULL, -2147483633, 12641511, 0, N'الحساب              ', NULL, NULL, NULL, NULL, N'Account             ', NULL, NULL, NULL, NULL, N'3021001        ', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, NULL, N'111', N'1011 ', 1, 1, 1, N'', 1, NULL, 0, N'11011011', 0, N'***', N'***', 0, N'***', N'***', N'10', 0, N'***', N'***', N'***', N'***')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (18, 18, N'سند قبض                                           ', N'Receipt Voucher                                   ', N'418', N'1         ', N'أستلمنا من المكرم             ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, -2147483633, 16706518, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 10, NULL, N'101', NULL, 1, 1, 1, N'', 1, NULL, 0, NULL, 0, N'***', N'***', 0, N'***', N'***', NULL, 0, N'***', N'***', N'***', N'***')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (19, 19, N'سند صرف                                           ', N'Payment Voucher                                   ', N'419', N'1         ', N'أصرفوا لي المكرم              ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, -2147483633, 14737632, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, N'', N'101', NULL, 1, 1, 1, N'', 1, NULL, 0, NULL, 0, N'***', N'***', 0, N'***', N'***', NULL, 0, N'***', N'***', N'***', N'***')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (20, 20, N'مرتجع صرف بضاعة                                   ', N'Payment Order Return                              ', N'111', N'1         ', N'سند                           ', NULL, NULL, NULL, NULL, N'Snad      ', NULL, NULL, NULL, NULL, -2147483633, 12641511, 8, N'الحساب              ', NULL, NULL, NULL, NULL, N'Account             ', NULL, NULL, NULL, NULL, N'3021001        ', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, NULL, N'111', N'1011 ', 1, 1, 1, N'', 1, NULL, 0, N'11011011', 0, N'***', N'***', 0, N'***', N'***', N'10', 0, N'***', N'***', N'***', N'***')
GO
SET IDENTITY_INSERT [dbo].[T_INVSETTING] OFF
GO
INSERT [dbo].[T_Job] ([Job_ID], [Job_No], [NameA], [NameE], [Note]) VALUES (N'608d3d80-b898-450f-bb06-bcb5d1512a84', 1, N'طبيب', N'Doctor', N'-------')
GO
INSERT [dbo].[T_Job] ([Job_ID], [Job_No], [NameA], [NameE], [Note]) VALUES (N'5358dff2-2054-45a6-a833-75e6cdc04b34', 2, N'مهندس', N'Eng', N'-------')
GO
INSERT [dbo].[T_Job] ([Job_ID], [Job_No], [NameA], [NameE], [Note]) VALUES (N'3bbe6c85-a1d5-449a-a984-5a0698976d5b', 3, N'بائع', N'salesman', N'---------')
GO
INSERT [dbo].[T_Job] ([Job_ID], [Job_No], [NameA], [NameE], [Note]) VALUES (N'75ae2b9e-991e-41c6-8c4f-1708c043cb51', 4, N'مبرمج', N'Programming', N'--------')
GO
INSERT [dbo].[T_Job] ([Job_ID], [Job_No], [NameA], [NameE], [Note]) VALUES (N'b5a8ead1-dc09-4a38-bf27-22647a40268e', 5, N'سائق', N'Driver', N'----------')
GO
INSERT [dbo].[T_LiquidationTyp] ([LiquidationT_ID], [LiquidationT_No], [NameA], [NameE]) VALUES (N'71a645e1-6d96-49ac-99ff-19b97ac2a912', 1, N'تصفية', N'Settlement')
GO
INSERT [dbo].[T_LiquidationTyp] ([LiquidationT_ID], [LiquidationT_No], [NameA], [NameE]) VALUES (N'a5191621-1a86-482f-8007-a2ffe27f5b81', 2, N'استقالة', N'Resign')
GO
INSERT [dbo].[T_LiquidationTyp] ([LiquidationT_ID], [LiquidationT_No], [NameA], [NameE]) VALUES (N'898392e4-3512-440e-aa02-7a386874f210', 3, N'استغناء', N'Layoff')
GO
INSERT [dbo].[T_LiquidationTyp] ([LiquidationT_ID], [LiquidationT_No], [NameA], [NameE]) VALUES (N'ae625aef-55a9-49ae-ba14-907736cbdec5', 4, N'فصل', N'Dismiss')
GO
SET IDENTITY_INSERT [dbo].[T_Loc] ON 
GO
INSERT [dbo].[T_Loc] ([Loc_ID], [Loc_No], [Arb_Des], [Eng_Des], [CompanyID]) VALUES (1, N'1', N'شمالي', N'South', 1)
GO
INSERT [dbo].[T_Loc] ([Loc_ID], [Loc_No], [Arb_Des], [Eng_Des], [CompanyID]) VALUES (2, N'2', N'جنوبي', N'North', 1)
GO
INSERT [dbo].[T_Loc] ([Loc_ID], [Loc_No], [Arb_Des], [Eng_Des], [CompanyID]) VALUES (3, N'3', N'شرقي', N'East', 1)
GO
INSERT [dbo].[T_Loc] ([Loc_ID], [Loc_No], [Arb_Des], [Eng_Des], [CompanyID]) VALUES (4, N'4', N'غربي', N'West', 1)
GO
SET IDENTITY_INSERT [dbo].[T_Loc] OFF
GO
SET IDENTITY_INSERT [dbo].[T_Mndob] ON 
GO
INSERT [dbo].[T_Mndob] ([Mnd_ID], [Mnd_No], [Arb_Des], [Eng_Des], [MndPri], [Mnd_Typ], [Comm_Inv], [Comm_Gaid], [CompanyID], [PriceDoctor], [DoctorJob], [MndFlied1], [MndFlied2], [MndFlied3], [MndFlied4]) VALUES (1, N'1', N'عام', N'General', 0, 0, 0, 0, 1, 0, N'', N'', N'', N'', N'')
GO
SET IDENTITY_INSERT [dbo].[T_Mndob] OFF
GO
INSERT [dbo].[T_MStatus] ([MStatusNo], [NameA], [NameE]) VALUES (1, N'أعزب', N'Single')
GO
INSERT [dbo].[T_MStatus] ([MStatusNo], [NameA], [NameE]) VALUES (2, N'متزوج', N'Married')
GO
INSERT [dbo].[T_MStatus] ([MStatusNo], [NameA], [NameE]) VALUES (3, N'مطلق', N'Separate')
GO
INSERT [dbo].[T_MStatus] ([MStatusNo], [NameA], [NameE]) VALUES (4, N'أرمل', N'Widower')
GO
INSERT [dbo].[T_Nationalities] ([Nation_ID], [Nation_No], [NameA], [NameE], [Note], [SalSubtract], [CompPaying]) VALUES (N'0ddda9a3-32fc-46aa-a28b-1b93503e9037', 1, N'سعودي', N'Saudi', N'----------', 0, 0)
GO
INSERT [dbo].[T_Nationalities] ([Nation_ID], [Nation_No], [NameA], [NameE], [Note], [SalSubtract], [CompPaying]) VALUES (N'6750a26a-e616-4f1a-9b61-5c1b28dbaac5', 2, N'يمني', N'yemeni', N'--------', 0, 0)
GO
INSERT [dbo].[T_Nationalities] ([Nation_ID], [Nation_No], [NameA], [NameE], [Note], [SalSubtract], [CompPaying]) VALUES (N'e4ec98ab-5865-4e44-9707-8fc2a0eec675', 3, N'مصري', N'Egypt', N'--------', 0, 0)
GO
INSERT [dbo].[T_Nationalities] ([Nation_ID], [Nation_No], [NameA], [NameE], [Note], [SalSubtract], [CompPaying]) VALUES (N'7f1207b9-7a7f-48ba-9aa7-917a1d7f62a3', 4, N'سوري', N'syria', N'--------', 0, 0)
GO
INSERT [dbo].[T_Nationalities] ([Nation_ID], [Nation_No], [NameA], [NameE], [Note], [SalSubtract], [CompPaying]) VALUES (N'43d390f1-e6d5-456a-a97b-396b90140e85', 5, N'لبناني', N'lebanon', N'', 0, 0)
GO
INSERT [dbo].[T_Nationalities] ([Nation_ID], [Nation_No], [NameA], [NameE], [Note], [SalSubtract], [CompPaying]) VALUES (N'75f01556-2850-4c11-86ef-6d0fffbbe8e8', 6, N'هندي', N'india', N'--------', 0, 0)
GO
INSERT [dbo].[T_Nationalities] ([Nation_ID], [Nation_No], [NameA], [NameE], [Note], [SalSubtract], [CompPaying]) VALUES (N'18203d93-9ffc-4314-a104-60f90740fd59', 7, N'إندونيسي', N'indonisia', N'--------', 0, 0)
GO
INSERT [dbo].[T_Nationalities] ([Nation_ID], [Nation_No], [NameA], [NameE], [Note], [SalSubtract], [CompPaying]) VALUES (N'92ee3102-3a9e-43a3-b6c2-17d3610c9ade', 8, N'عراقي', N'iraq', N'--------', 0, 0)
GO
INSERT [dbo].[T_Nationalities] ([Nation_ID], [Nation_No], [NameA], [NameE], [Note], [SalSubtract], [CompPaying]) VALUES (N'66799e62-0b56-4974-8122-d2bd04deccd5', 9, N'كويتي', N'kuwait', N'--------', 0, 0)
GO
INSERT [dbo].[T_Nationalities] ([Nation_ID], [Nation_No], [NameA], [NameE], [Note], [SalSubtract], [CompPaying]) VALUES (N'aec0e758-75fa-4d62-9fc1-c63e6029f782', 10, N'امريكي', N'USA', N'--------', 0, 0)
GO
INSERT [dbo].[T_Nationalities] ([Nation_ID], [Nation_No], [NameA], [NameE], [Note], [SalSubtract], [CompPaying]) VALUES (N'918a3f7a-e57a-4587-90fa-2da3d452c87e', 11, N'سوداني', N'Sudan', N'--------', 0, 0)
GO
INSERT [dbo].[T_Nationalities] ([Nation_ID], [Nation_No], [NameA], [NameE], [Note], [SalSubtract], [CompPaying]) VALUES (N'63c13cc3-597e-4aba-bebb-7b6538478927', 12, N'كندي', N'canada', N'--------', 0, 0)
GO
INSERT [dbo].[T_OpMethod] ([Method_No], [Name], [NameE]) VALUES (1, N'الإضافي المحدد في شاشة بيانات الموظف', N'As specified in employee data')
GO
INSERT [dbo].[T_OpMethod] ([Method_No], [Name], [NameE]) VALUES (2, N'الراتب الأساسي', N'Main Salary')
GO
INSERT [dbo].[T_OpMethod] ([Method_No], [Name], [NameE]) VALUES (3, N'الراتب الاساسي + القسط الشهري من بدل السكن', N'Main salary+Monthly installment of housing')
GO
INSERT [dbo].[T_OpMethod] ([Method_No], [Name], [NameE]) VALUES (4, N'الراتب الأساسي + جميع البدلات', N'Main Salary+All Allowance')
GO
INSERT [dbo].[T_OpMethod] ([Method_No], [Name], [NameE]) VALUES (5, N'الراتب الأساسي + بدل المواصلات + بدل السكن', N'Main salary+Installment of housing+Transport')
GO
INSERT [dbo].[T_OpMethod] ([Method_No], [Name], [NameE]) VALUES (6, N'الراتب الأساسي + بدل الإعاشة', N'Main salary+Food allowance')
GO
INSERT [dbo].[T_OpMethod] ([Method_No], [Name], [NameE]) VALUES (7, N'الراتب الأساسي + بدل المواصلات', N'Main salary+Transport')
GO
INSERT [dbo].[T_OpMethod] ([Method_No], [Name], [NameE]) VALUES (8, N'مبلغ مقطوع', N'Fixed Sum')
GO
INSERT [dbo].[T_OpMethod] ([Method_No], [Name], [NameE]) VALUES (9, N'بدل السكن السنوي', N'Anuall housing')
GO
INSERT [dbo].[T_OpMethod] ([Method_No], [Name], [NameE]) VALUES (10, N'بدل المواصلات', N'Transportation')
GO
INSERT [dbo].[T_OpMethod] ([Method_No], [Name], [NameE]) VALUES (11, N'بدل الإعاشة', N'Food allowance')
GO
INSERT [dbo].[T_OpMethod] ([Method_No], [Name], [NameE]) VALUES (12, N'بدل طبيعة عمل', N'Job allowance')
GO
INSERT [dbo].[T_OpMethod] ([Method_No], [Name], [NameE]) VALUES (13, N'بدلات أخرى', N'Other allowance')
GO
SET IDENTITY_INSERT [dbo].[T_Printers] ON 
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, N'Microsoft XPS Document Writer', N'111', N'', 1, 1, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, NULL, N'111', N'', 1, 2, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, NULL, N'111', N'', 1, 3, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, NULL, N'111', N'', 1, 4, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, NULL, N'111', N'', 1, 5, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, NULL, N'111', N'', 1, 6, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (7, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, NULL, N'111', N'', 1, 7, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (8, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, NULL, N'111', N'', 1, 8, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, NULL, N'111', N'', 1, 9, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (10, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, NULL, N'111', N'', 1, 21, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (11, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 1, N'ZDesigner TLP 2844', N'101', N'', 1, 22, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (12, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 10, N'', N'111', N'', 1, 23, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (13, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, N'', N'101', N'', 1, 24, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (14, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 10, N'', N'111', N'', 1, 25, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (15, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, N'', N'101', N'', 1, 26, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (16, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 10, N'', N'111', N'', 1, 27, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (17, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 10, N'', N'111', N'', 1, 28, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (18, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 10, N'', N'111', N'', 1, 29, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (19, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 10, N'', N'111', N'', 1, 30, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (20, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, N'Microsoft XPS Document Writer', N'110', NULL, NULL, 100, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (21, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, NULL, N'111', N'', 1, 10, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (22, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 10, N'', N'101', N'', 1, 11, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (23, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 10, N'', N'111', N'', 1, 12, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (24, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, N'', N'101', N'', 1, 13, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (25, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, NULL, N'111', N'', 1, 14, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (26, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, NULL, N'111', N'', 1, 15, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (27, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, N'', N'101', N'', 1, 16, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (28, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, NULL, N'111', N'', 1, 17, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (29, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 10, NULL, N'101', N'', 1, 18, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (30, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, N'', N'101', N'', 1, 19, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (31, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, NULL, N'111', N'', 1, 20, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (32, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, N'Microsoft XPS Document Writer', N'11 ', N'', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1091, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (33, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, N'Microsoft XPS Document Writer', N'111', N'', 1, 1, 3, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (34, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, NULL, N'111', N'', 1, 2, 3, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (35, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, NULL, N'111', N'', 1, 3, 3, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (36, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, NULL, N'111', N'', 1, 4, 3, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (37, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, NULL, N'111', N'', 1, 5, 3, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (38, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, NULL, N'111', N'', 1, 6, 3, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (39, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, NULL, N'111', N'', 1, 7, 3, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (40, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, NULL, N'111', N'', 1, 8, 3, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (41, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, NULL, N'111', N'', 1, 9, 3, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (42, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, NULL, N'111', N'', 1, 21, 3, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (43, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 1, N'ZDesigner TLP 2844', N'101', N'', 1, 22, 3, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (44, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 10, N'', N'111', N'', 1, 23, 3, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (45, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, N'', N'101', N'', 1, 24, 3, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (46, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 10, N'', N'111', N'', 1, 25, 3, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (47, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, N'', N'101', N'', 1, 26, 3, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (48, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 10, N'', N'111', N'', 1, 27, 3, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (49, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 10, N'', N'111', N'', 1, 28, 3, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 10, N'', N'111', N'', 1, 29, 3, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (51, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 10, N'', N'111', N'', 1, 30, 3, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (52, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, N'Microsoft XPS Document Writer', N'110', NULL, NULL, 100, 3, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (53, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, NULL, N'111', N'', 1, 10, 3, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (54, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 10, N'', N'101', N'', 1, 11, 3, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (55, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 10, N'', N'111', N'', 1, 12, 3, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (56, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, N'', N'101', N'', 1, 13, 3, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (57, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, NULL, N'111', N'', 1, 14, 3, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (58, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, NULL, N'111', N'', 1, 15, 3, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (59, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, N'', N'101', N'', 1, 16, 3, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (60, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, NULL, N'111', N'', 1, 17, 3, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (61, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 10, NULL, N'101', N'', 1, 18, 3, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (62, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, N'', N'101', N'', 1, 19, 3, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (63, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, NULL, N'111', N'', 1, 20, 3, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (64, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, N'Microsoft XPS Document Writer', N'11 ', N'', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1091, 3, NULL, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[T_Printers] OFF
GO
INSERT [dbo].[T_Religion] ([Religion_ID], [Religion_No], [NameA], [NameE], [Note]) VALUES (N'2ab2a6f3-e237-4e94-a10f-04fe1d4a73b4', 1, N'مسلم', N'Muslim', N'----------')
GO
INSERT [dbo].[T_Religion] ([Religion_ID], [Religion_No], [NameA], [NameE], [Note]) VALUES (N'8ee8b3d4-0fed-4ceb-92ef-acb97699a319', 2, N'مسيحي', N'Christian', N'-------------')
GO
INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID], [perno_Old], [Furnished], [AreaDetail], [RoomCount], [loungesCount], [kitchensCount]) VALUES (101, 1, 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1, NULL, 0, N'', 1, 0, 0)
GO
INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID], [perno_Old], [Furnished], [AreaDetail], [RoomCount], [loungesCount], [kitchensCount]) VALUES (102, 1, 0, 1, 1, 3, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1, NULL, 0, N'', 1, 0, 0)
GO
INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID], [perno_Old], [Furnished], [AreaDetail], [RoomCount], [loungesCount], [kitchensCount]) VALUES (103, 1, 0, 1, 1, 5, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1, NULL, 0, N'', 1, 0, 0)
GO
INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID], [perno_Old], [Furnished], [AreaDetail], [RoomCount], [loungesCount], [kitchensCount]) VALUES (104, 1, 0, 1, 1, 7, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1, NULL, 0, N'', 1, 0, 0)
GO
INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID], [perno_Old], [Furnished], [AreaDetail], [RoomCount], [loungesCount], [kitchensCount]) VALUES (105, 1, 0, 1, 1, 9, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1, NULL, 0, N'', 1, 0, 0)
GO
INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID], [perno_Old], [Furnished], [AreaDetail], [RoomCount], [loungesCount], [kitchensCount]) VALUES (106, 1, 0, 1, 1, 11, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1, NULL, 0, N'', 1, 0, 0)
GO
INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID], [perno_Old], [Furnished], [AreaDetail], [RoomCount], [loungesCount], [kitchensCount]) VALUES (201, 2, 0, 1, 3, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1, NULL, 0, N'', 1, 0, 0)
GO
INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID], [perno_Old], [Furnished], [AreaDetail], [RoomCount], [loungesCount], [kitchensCount]) VALUES (202, 2, 0, 1, 3, 3, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1, NULL, 0, N'', 1, 0, 0)
GO
INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID], [perno_Old], [Furnished], [AreaDetail], [RoomCount], [loungesCount], [kitchensCount]) VALUES (203, 2, 0, 1, 3, 5, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1, NULL, 0, N'', 1, 0, 0)
GO
INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID], [perno_Old], [Furnished], [AreaDetail], [RoomCount], [loungesCount], [kitchensCount]) VALUES (204, 2, 0, 1, 3, 7, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1, NULL, 0, N'', 1, 0, 0)
GO
INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID], [perno_Old], [Furnished], [AreaDetail], [RoomCount], [loungesCount], [kitchensCount]) VALUES (205, 2, 0, 1, 3, 9, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1, NULL, 0, N'', 1, 0, 0)
GO
INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID], [perno_Old], [Furnished], [AreaDetail], [RoomCount], [loungesCount], [kitchensCount]) VALUES (206, 2, 0, 1, 3, 11, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1, NULL, 0, N'', 1, 0, 0)
GO
INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID], [perno_Old], [Furnished], [AreaDetail], [RoomCount], [loungesCount], [kitchensCount]) VALUES (301, 3, 0, 1, 5, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1, NULL, 0, N'', 1, 0, 0)
GO
INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID], [perno_Old], [Furnished], [AreaDetail], [RoomCount], [loungesCount], [kitchensCount]) VALUES (302, 3, 0, 1, 5, 3, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1, NULL, 0, N'', 1, 0, 0)
GO
INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID], [perno_Old], [Furnished], [AreaDetail], [RoomCount], [loungesCount], [kitchensCount]) VALUES (303, 3, 0, 1, 5, 5, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1, NULL, 0, N'', 1, 0, 0)
GO
INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID], [perno_Old], [Furnished], [AreaDetail], [RoomCount], [loungesCount], [kitchensCount]) VALUES (304, 3, 0, 1, 5, 7, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1, NULL, 0, N'', 1, 0, 0)
GO
INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID], [perno_Old], [Furnished], [AreaDetail], [RoomCount], [loungesCount], [kitchensCount]) VALUES (305, 3, 0, 1, 5, 9, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1, NULL, 0, N'', 1, 0, 0)
GO
INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID], [perno_Old], [Furnished], [AreaDetail], [RoomCount], [loungesCount], [kitchensCount]) VALUES (306, 3, 0, 1, 5, 11, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1, NULL, 0, N'', 1, 0, 0)
GO
INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID], [perno_Old], [Furnished], [AreaDetail], [RoomCount], [loungesCount], [kitchensCount]) VALUES (401, 4, 0, 1, 7, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1, NULL, 0, N'', 1, 0, 0)
GO
INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID], [perno_Old], [Furnished], [AreaDetail], [RoomCount], [loungesCount], [kitchensCount]) VALUES (402, 4, 0, 1, 7, 3, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1, NULL, 0, N'', 1, 0, 0)
GO
INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID], [perno_Old], [Furnished], [AreaDetail], [RoomCount], [loungesCount], [kitchensCount]) VALUES (403, 4, 0, 1, 7, 5, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1, NULL, 0, N'', 1, 0, 0)
GO
INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID], [perno_Old], [Furnished], [AreaDetail], [RoomCount], [loungesCount], [kitchensCount]) VALUES (404, 4, 0, 1, 7, 7, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1, NULL, 0, N'', 1, 0, 0)
GO
INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID], [perno_Old], [Furnished], [AreaDetail], [RoomCount], [loungesCount], [kitchensCount]) VALUES (405, 4, 0, 1, 7, 9, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1, NULL, 0, N'', 1, 0, 0)
GO
INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID], [perno_Old], [Furnished], [AreaDetail], [RoomCount], [loungesCount], [kitchensCount]) VALUES (406, 4, 0, 1, 7, 11, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1, NULL, 0, N'', 1, 0, 0)
GO
SET IDENTITY_INSERT [dbo].[T_RomChart] ON 
GO
INSERT [dbo].[T_RomChart] ([ID], [FName], [FNameE], [col1], [col2], [col3], [col4], [col5], [col6], [col7], [col8], [col9], [col10], [col11], [col12], [col13], [col14], [col15], [col16], [col17], [col18], [col19], [col20], [col21], [col22], [col23], [col24], [col25], [col26], [col27], [col28], [col29], [col30], [col31], [col32], [col33], [col34], [col35], [col36], [col37], [col38], [col39], [col40], [col41], [col42], [col43], [col44], [col45], [col46], [col47], [col48], [col49], [col50], [col51], [col52], [col53], [col54], [col55], [col56], [col57], [col58], [col59], [col60], [col61], [col62], [col63], [col64], [col65], [col66], [col67], [col68], [col69], [col70], [col71], [col72], [col73], [col74], [col75], [col76], [col77], [col78], [col79], [col80], [col81], [col82], [col83], [col84], [col85], [col86], [col87], [col88], [col89], [col90], [col91], [col92], [col93], [col94], [col95], [col96], [col97], [col98], [col99], [col100]) VALUES (1, N'الطابق 1', N'floor 1', 101, 102, 103, 104, 105, 106, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
GO
INSERT [dbo].[T_RomChart] ([ID], [FName], [FNameE], [col1], [col2], [col3], [col4], [col5], [col6], [col7], [col8], [col9], [col10], [col11], [col12], [col13], [col14], [col15], [col16], [col17], [col18], [col19], [col20], [col21], [col22], [col23], [col24], [col25], [col26], [col27], [col28], [col29], [col30], [col31], [col32], [col33], [col34], [col35], [col36], [col37], [col38], [col39], [col40], [col41], [col42], [col43], [col44], [col45], [col46], [col47], [col48], [col49], [col50], [col51], [col52], [col53], [col54], [col55], [col56], [col57], [col58], [col59], [col60], [col61], [col62], [col63], [col64], [col65], [col66], [col67], [col68], [col69], [col70], [col71], [col72], [col73], [col74], [col75], [col76], [col77], [col78], [col79], [col80], [col81], [col82], [col83], [col84], [col85], [col86], [col87], [col88], [col89], [col90], [col91], [col92], [col93], [col94], [col95], [col96], [col97], [col98], [col99], [col100]) VALUES (2, N'الطابق 2', N'floor 2', 201, 202, 203, 204, 205, 206, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
GO
INSERT [dbo].[T_RomChart] ([ID], [FName], [FNameE], [col1], [col2], [col3], [col4], [col5], [col6], [col7], [col8], [col9], [col10], [col11], [col12], [col13], [col14], [col15], [col16], [col17], [col18], [col19], [col20], [col21], [col22], [col23], [col24], [col25], [col26], [col27], [col28], [col29], [col30], [col31], [col32], [col33], [col34], [col35], [col36], [col37], [col38], [col39], [col40], [col41], [col42], [col43], [col44], [col45], [col46], [col47], [col48], [col49], [col50], [col51], [col52], [col53], [col54], [col55], [col56], [col57], [col58], [col59], [col60], [col61], [col62], [col63], [col64], [col65], [col66], [col67], [col68], [col69], [col70], [col71], [col72], [col73], [col74], [col75], [col76], [col77], [col78], [col79], [col80], [col81], [col82], [col83], [col84], [col85], [col86], [col87], [col88], [col89], [col90], [col91], [col92], [col93], [col94], [col95], [col96], [col97], [col98], [col99], [col100]) VALUES (3, N'الطابق 3', N'floor 3', 301, 302, 303, 304, 305, 306, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
GO
INSERT [dbo].[T_RomChart] ([ID], [FName], [FNameE], [col1], [col2], [col3], [col4], [col5], [col6], [col7], [col8], [col9], [col10], [col11], [col12], [col13], [col14], [col15], [col16], [col17], [col18], [col19], [col20], [col21], [col22], [col23], [col24], [col25], [col26], [col27], [col28], [col29], [col30], [col31], [col32], [col33], [col34], [col35], [col36], [col37], [col38], [col39], [col40], [col41], [col42], [col43], [col44], [col45], [col46], [col47], [col48], [col49], [col50], [col51], [col52], [col53], [col54], [col55], [col56], [col57], [col58], [col59], [col60], [col61], [col62], [col63], [col64], [col65], [col66], [col67], [col68], [col69], [col70], [col71], [col72], [col73], [col74], [col75], [col76], [col77], [col78], [col79], [col80], [col81], [col82], [col83], [col84], [col85], [col86], [col87], [col88], [col89], [col90], [col91], [col92], [col93], [col94], [col95], [col96], [col97], [col98], [col99], [col100]) VALUES (4, N'الطابق 4', N'floor 4', 401, 402, 403, 404, 405, 406, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
GO
SET IDENTITY_INSERT [dbo].[T_RomChart] OFF
GO
SET IDENTITY_INSERT [dbo].[T_Rooms] ON 
GO
INSERT [dbo].[T_Rooms] ([ID], [RomeNo], [RomeStatus], [Type], [Stop], [reserved], [chair], [Note], [waiterNo]) VALUES (1, 0, 0, 0, 0, 0, 1, N'', NULL)
GO
SET IDENTITY_INSERT [dbo].[T_Rooms] OFF
GO
INSERT [dbo].[T_SalStatus] ([SalStatusNo], [NameA], [NameE]) VALUES (1, N'ساري', N'Valid')
GO
INSERT [dbo].[T_SalStatus] ([SalStatusNo], [NameA], [NameE]) VALUES (2, N'موقوف', N'Stopped')
GO
INSERT [dbo].[T_SecretariatsTyp] ([SecretariatTyp_ID], [SecretariatTyp_No], [NameA], [NameE], [Note]) VALUES (N'4ffa2a1e-2c92-4602-96e8-33913bc94aad', 1, N'معدات كهربائية', N'Electrical Equipment', N'مروحة + اسلاك + مسامير + جهاز قياس التيار الكهربائي')
GO
INSERT [dbo].[T_SecretariatsTyp] ([SecretariatTyp_ID], [SecretariatTyp_No], [NameA], [NameE], [Note]) VALUES (N'd5de0711-a330-4c76-8a66-56ee2bc547ac', 2, N'هاتف محمول', N'Mobile', N'جوال ايفون 5 + شريحة بيانات')
GO
INSERT [dbo].[T_SecretariatsTyp] ([SecretariatTyp_ID], [SecretariatTyp_No], [NameA], [NameE], [Note]) VALUES (N'48c1f772-101b-4492-88dd-dd57b4c49ccd', 3, N'صندوق العمل', N'Job Box', N'مكينة حلاقة + موس الحلاقة + معجون الحلاقة')
GO
INSERT [dbo].[T_SecretariatsTyp] ([SecretariatTyp_ID], [SecretariatTyp_No], [NameA], [NameE], [Note]) VALUES (N'ea779b85-aceb-4a18-afe9-44660661e657', 4, N'ادوات تشطيب', N'Finishing Tools', N'فرشة التلوين ( بوية) + دريل + مطرقة + مفك')
GO
SET IDENTITY_INSERT [dbo].[T_sertyp] ON 
GO
INSERT [dbo].[T_sertyp] ([Serv_ID], [Serv_No], [Arb_Des], [Eng_Des], [accno], [acched], [Usr], [UsrNam], [CompanyID]) VALUES (1, N'1', N'مستحقات سابقة', N'Previous receivables', N'3011002', NULL, NULL, NULL, 1)
GO
INSERT [dbo].[T_sertyp] ([Serv_ID], [Serv_No], [Arb_Des], [Eng_Des], [accno], [acched], [Usr], [UsrNam], [CompanyID]) VALUES (2, N'2', N'تلّفيات', N'Damage', N'3011002', NULL, NULL, NULL, 1)
GO
INSERT [dbo].[T_sertyp] ([Serv_ID], [Serv_No], [Arb_Des], [Eng_Des], [accno], [acched], [Usr], [UsrNam], [CompanyID]) VALUES (3, N'3', N'فرش ومخدات', N'furniture', N'3011002', NULL, NULL, NULL, 1)
GO
INSERT [dbo].[T_sertyp] ([Serv_ID], [Serv_No], [Arb_Des], [Eng_Des], [accno], [acched], [Usr], [UsrNam], [CompanyID]) VALUES (4, N'4', N'تلفون', N'Phone', N'3011002', NULL, NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[T_sertyp] OFF
GO
INSERT [dbo].[T_Sex] ([SexNo], [NameA], [NameE]) VALUES (1, N'ذكر', N'Male')
GO
INSERT [dbo].[T_Sex] ([SexNo], [NameA], [NameE]) VALUES (2, N'انثى', N'Female')
GO
INSERT [dbo].[T_Store] ([Stor_ID], [Arb_Des], [Eng_Des], [Address], [City], [Tel], [Fax], [Nots], [CompanyID]) VALUES (1, N'رئيسي', N'Main', N'----------', N'------------', N'------------', N'---------------', N'---------------', 1)
GO
INSERT [dbo].[T_StsReas] ([ID], [NameSts], [NameStsE]) VALUES (1, N'الحجز ساري', N'Reservations are valid')
GO
INSERT [dbo].[T_StsReas] ([ID], [NameSts], [NameStsE]) VALUES (2, N'تم التسكين', N'It was settled')
GO
INSERT [dbo].[T_StsReas] ([ID], [NameSts], [NameStsE]) VALUES (3, N'الغي الحجز', N'Reservation canceled')
GO
INSERT [dbo].[T_SubTyp] ([SubNo], [NameA], [NameE]) VALUES (1, N'غياب يوم', N'Day’s Absent        ')
GO
INSERT [dbo].[T_SubTyp] ([SubNo], [NameA], [NameE]) VALUES (2, N'تأخير ساعة', N'Hour’s late         ')
GO
INSERT [dbo].[T_SubTyp] ([SubNo], [NameA], [NameE]) VALUES (3, N'خصم جزئي', N'Penalty Deduction   ')
GO
INSERT [dbo].[T_SubTyp] ([SubNo], [NameA], [NameE]) VALUES (4, N'خصومات أخرى', N'Other Deduction     ')
GO
SET IDENTITY_INSERT [dbo].[T_SYSSETTING] ON 
GO
INSERT [dbo].[T_SYSSETTING] ([SYSSETTING_ID], [AutoItm], [AccCus], [AccCusDes], [AccSup], [AccSupDes], [Seting], [DefLines_Setting], [SysDir], [HDat], [Calendr], [LrnExp], [DMY], [AutoEmp], [InvID], [GedID], [InvMod], [LogImg], [BackPath], [IsAutoBackup], [AutoBackup], [AutoBackupDate], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [IsBackground], [IsNotBackground], [BackgroundPic], [defSizePaper_Setting], [Orientation_Setting], [Sponer], [IsAlarmVisaGoBack], [IsAlarmVisaIntro], [AlarmVisaGoBack], [AlarmVisaIntro], [IsAlarmDepts], [AlarmDeptsBefore], [AutoChangSalStatus], [AccUsrNo], [DocumentPath], [ImportFilePath], [ImportIp], [ImportEmpNo], [ImportDate], [ImportTime1], [ImportTimeLeave1], [ImportStart], [ImportEnd], [AccPath], [ServerNm], [DataBaseNm], [Sa_Pass], [Path_Kind], [AlarmDoc], [AlarmDocBefore], [AutoLeave], [EmpLeaveAfter], [AttendanceManually], [VacationManually], [CalculateNo], [CalculatliquidNo], [Allowances], [AllowancesTime], [ShowBanner], [ShowPageNo], [ShowDateH], [ShowDateG], [SalDate], [DisVacationType], [IsAlarmEmpDoc], [IsAlarmEmpContract], [IsAlarmFamilyPassport], [IsAlarmGuarantorDoc], [IsAlarmEndVaction], [IsAlarmBranchDoc], [IsAlarmCarDoc], [IsAlarmSecretariatsDoc], [AlarmEmpDocBefore], [AlarmEmpContractBefore], [AlarmFamilyPassportBefore], [AlarmGuarantorDocBefore], [AlarmEndVactionBefore], [AlarmBranchDocBefore], [AlarmCarDocBefore], [AlarmSecretariatsBefore], [smsUserName], [smsPass], [smsSenderName], [smsMessage1], [smsMessage2], [smsMessage3], [smsMessage4], [AlarmEmployee], [LineDetailSts], [LineDetailNameA], [LineDetailNameE], [LineGiftSts], [LineGiftlNameA], [LineGiftlNameE], [TableFamily], [TableBoys], [TableExtrnal], [TableOther], [MainDirPath], [BColor0], [BColor1], [BColor2], [BColor3], [BColor4], [BColor5], [BColor6], [BColor7], [FColor0], [FColor1], [FColor2], [FColor3], [FColor4], [FColor5], [FColor6], [FColor7], [Fld_w], [Fld_H], [DayOfM], [ch], [flore], [rom], [vStart], [vEnd], [vStartTyp], [vEndTyp], [GuestAcc], [GuestBoxAcc], [DefSalesTax], [DefPurchaesTax], [TaxAcc], [TaxNoteInv], [IsCustomerDisplay], [Port], [Fast], [BitStop], [BitData], [Parity], [CustomerHello], [DisplayTypeShow], [LineOfInvoices], [IsActiveBalance], [BalanceType], [BarcodFrom], [BarcodTo], [WightFrom], [WightTo], [PriceFrom], [PriceTo], [WightQ], [PriceQ], [PointOfRyal], [ItemTyp1], [ItemTyp2], [ItemTyp3], [ItemTyp1E], [ItemTyp2E], [ItemTyp3E], [AlarmDueoBefore], [EmpSeting], [SyncPath], [vFiledA], [vFiledB], [vFiledC], [vFiledInt], [vFiledBool], [EqarAlarmContractEnd], [EqarAlarmDayPay], [EqarAcc], [tenantAcc], [AfterDotNum]) VALUES (1, 1, N'30                  ', N'                                                  ', N'          ', N'                                                  ', N'11010000111111001                                                                                   ', 1, N' ', 0, 0, 5, 0, 0, 1, 1, 0, NULL, N'', 1, 1, N'', 1, 1, 1, 1, 0, 6, N'Microsoft XPS Document Writer', N'1 ', 1, 0, NULL, N'', 1, 0, 0, 0, 0, 0, 0, 0, 1, NULL, N'', NULL, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'', N'0', N'', 0, 1, 1, 0, 0, 0, 1, 2, 2, 12, 1, 1, 0, 0, 0, N'', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N'', N'', N'', N'أهلا وسهلا بكم عملائنا الأعزاء', N'شكرا لزيارتنا', N'نتمنى لكم أوقات سعيدة', N'كل عام وانتم بخير', 0, N'0000000000000000000000000000', N'تفاصيل أخرى', N'Other Details', N'0000000000000000000000000000', N'مكآفأة', N'Gift', 0, 0, 0, 0, N'F:\AlmohtarifERP\PROSOFT\bin\Debug', N'255,255,255', N'224,224,224', N'255,0,0', N'128,64,0', N'255,128,0', N'64,64,64', N'255,128,128', N'0,128,0', N'0,64,0', N'0,64,0', N'255,255,255', N'255,255,255', N'0,0,0', N'255,255,255', N'0,0,0', N'255,255,255', 125, 100, 30, 0, 4, 6, N'05:00:00', N'06:00:00', N'AM', N'PM', N'1026', N'3011002', 0, 0, N'4011026', N'Tax is 5%    |   الضريبة 5 %', 0, N'COM4', 9600, 1, 8, 3, N'App.Soft-Solution', 0, 100, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0.01, N'سلعة', N'مواد خامة', N'خدمة', N'Commodity', N'Raw materials', N'Service', 0, N'0', N'', N'', N'', N'', 0, 0, 30, 5, N'10110', N'1027', NULL)
GO
SET IDENTITY_INSERT [dbo].[T_SYSSETTING] OFF
GO
INSERT [dbo].[T_telmn] ([pl], [price], [d], [accno]) VALUES (0, 2, 0, N'3011002')
GO
INSERT [dbo].[T_telmn] ([pl], [price], [d], [accno]) VALUES (1, 3, 0, N'3011002')
GO
INSERT [dbo].[T_telmn] ([pl], [price], [d], [accno]) VALUES (2, 7, 0, N'3011002')
GO
INSERT [dbo].[T_telmn] ([pl], [price], [d], [accno]) VALUES (3, 12, 0, N'3011002')
GO
INSERT [dbo].[T_telmn] ([pl], [price], [d], [accno]) VALUES (4, 50, 0, N'3011002')
GO
INSERT [dbo].[T_TicetTyp] ([TicetT_No], [NameA], [NameE]) VALUES (1, N'أعمال         ', N'Busniss       ')
GO
INSERT [dbo].[T_TicetTyp] ([TicetT_No], [NameA], [NameE]) VALUES (2, N'أولى           ', N'First         ')
GO
INSERT [dbo].[T_TicetTyp] ([TicetT_No], [NameA], [NameE]) VALUES (3, N'سياحي          ', N'Touring       ')
GO
INSERT [dbo].[T_TicetTyp] ([TicetT_No], [NameA], [NameE]) VALUES (4, N'الضيافة        ', N'Hospitality ')
GO
INSERT [dbo].[T_TicetTyp] ([TicetT_No], [NameA], [NameE]) VALUES (5, N'آخر                ', N'Other               ')
GO
INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'e762c504-f115-4e05-9191-6b82a6f7c569', 1, N'نقل كفالة مؤسسات', N'Ensure the transfer of institu', N'')
GO
INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'aa2badfa-99ce-448b-9fd3-9a83d0d63446', 2, N'نقل كفالة افراد', N'Ensure the transfer of personn', N'')
GO
INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'ebdf0a93-703f-4779-8952-be4f6215a796', 3, N'نقل خدمات العمال (الكفالات)', N'Transport workers'' services (g', N'')
GO
INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'd9e8126b-6529-4bd8-87ce-54c20c60d96e', 4, N'معلومات (إثبات رقم الجواز الجديد بالحاسب)', N'Information (No. prove the new passport to the computer)', N'')
GO
INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'a7f2ff6e-69ce-4a50-82cd-8a67830516f0', 5, N'فتح محل للمنشأة لدى مكتب العمل', N'Opening of the facility ', N'')
GO
INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'c9870ff2-c99d-4843-b3fc-22cb7e5de148', 6, N'فتح الملف بنظام الحاسب لآلي الجديد (الرقم الموحد)', N'Open the file new automated computer system (uniform number)', N'')
GO
INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'8250c48b-8821-4228-a704-a0746e2c8b00', 7, N'طلب تأشيرات الزيارة', N'Request visas', N'')
GO
INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'ec1c1162-88cc-4fe2-812e-2691fe74bb6e', 8, N'تغير مهنة', N'change occupation', N'')
GO
INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'137104e5-2d3c-4232-b148-ad8d921e1c21', 9, N'تعليمات عن الشخص المتوفى بالنسبة - للأفراد والمؤسسات ', N'Instructions for the deceased person for - for individuals and institutions.', N'')
GO
INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'bc84a1a8-a5de-4c08-8c83-743bf3199162', 10, N'تعديل مهنة', N'Amendment profession', N'')
GO
INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'36f428e0-392f-41c1-909c-0e01af275df0', 11, N'تجديد دفتر الإقامة', N'Book accommodation renewal', N'')
GO
INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'28d2f42b-6eaa-43a4-b9d4-3937b486b943', 12, N'تأشيرة خروج وعودة', N'Exit and return visa', N'')
GO
INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'0a4c35dc-711c-4357-a5a3-8754cd483d26', 13, N'إلغاء بلاغ', N'Cancellation author', N'')
GO
INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'29abadc3-e647-4481-9833-b307ced49b66', 14, N'الحصول على جواز السفر السعودي', N'Get the Saudi passport', N'')
GO
INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'547dabf2-f2f7-40c4-912c-494313ba4a39', 15, N'التبليغ عن الهروب الداخلي(للمؤسسات والشركات )', N'Report internal flight (for institutions and companies)', N'')
GO
INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'94ba1ed1-c845-4846-8c1e-9196c91396f8', 16, N'التبليغ عن الهروب الداخلي (للأفراد)', N'Report internal flight (for individuals)', N'')
GO
INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'51670f93-6f48-4e9b-b93e-2832b05f0601', 17, N'التبليغ عن الهروب الخارجي للمؤسسات - خروج وعودة', N'Report external Escape institutions - out and back', N'')
GO
INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'86018217-8135-43bb-9e7d-b3c15c382a90', 18, N'التبليغ عن الهروب الخارجي (للأفراد (خروج وعودة ))', N'Report external escape (for individuals (out and back))', N'')
GO
INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'79d3b7c8-69a5-4b4e-9b81-c7f316f2d6e2', 19, N'الإعارة للعمالة المنزلية (الخادم -السائق-الحارس)', N'Circulation domestic workers (server -alsaiq-Sentinel)', N'')
GO
INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'e0705ad8-a640-44fb-963b-ba2fda9c7d28', 20, N'استقدام زوجة', N'Recruitment wife', N'')
GO
INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'2296ada4-b351-4a7f-a18b-e2e1110bb718', 21, N'استقدام', N'Recruitment', N'')
GO
INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'ae05fc69-22f6-438c-af1e-afa1c9b3ccd3', 22, N'استخراج رخصة عمل', N'Extraction work permit', N'')
GO
INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'f64b18a8-484b-464a-86d9-a71595a15e87', 23, N'إستخراج دفتر إقامة جديد', N'The extraction of a new residence Book', N'')
GO
SET IDENTITY_INSERT [dbo].[T_Unit] ON 
GO
INSERT [dbo].[T_Unit] ([Unit_ID], [Unit_No], [Arb_Des], [Eng_Des], [CompanyID]) VALUES (1, N'1', N'حبة', N'Unit', 1)
GO
INSERT [dbo].[T_Unit] ([Unit_ID], [Unit_No], [Arb_Des], [Eng_Des], [CompanyID]) VALUES (2, N'2', N'درزن', N'Drzn', 1)
GO
INSERT [dbo].[T_Unit] ([Unit_ID], [Unit_No], [Arb_Des], [Eng_Des], [CompanyID]) VALUES (3, N'3', N'كرتون', N'Carton', 1)
GO
SET IDENTITY_INSERT [dbo].[T_Unit] OFF
GO
INSERT [dbo].[T_VacTyp] ([VacT_ID], [VacT_No], [NameA], [NameE], [Dis_VacT], [Dis_Sal], [Dis_Sal_Sts]) VALUES (N'23b1e997-be89-422b-8db3-0bab0cd9c789', 1, N'الأعياد', N'Eid', 0, 0, 0)
GO
INSERT [dbo].[T_VacTyp] ([VacT_ID], [VacT_No], [NameA], [NameE], [Dis_VacT], [Dis_Sal], [Dis_Sal_Sts]) VALUES (N'a848fcdd-1f12-429b-a24e-b2037cd20e12', 2, N'مرض', N'disease', 0, 0, 0)
GO
INSERT [dbo].[T_VacTyp] ([VacT_ID], [VacT_No], [NameA], [NameE], [Dis_VacT], [Dis_Sal], [Dis_Sal_Sts]) VALUES (N'd0c15470-637d-404f-a45c-557702794691', 3, N'اعتيادي', N'Normal', 0, 0, 0)
GO
INSERT [dbo].[T_VacTyp] ([VacT_ID], [VacT_No], [NameA], [NameE], [Dis_VacT], [Dis_Sal], [Dis_Sal_Sts]) VALUES (N'b76e8627-cd73-4744-b560-b5ec8c4e310b', 4, N'مولود', N'Baby', 0, 0, 0)
GO
SET IDENTITY_INSERT [dbo].[tb_version] ON 
GO
INSERT [dbo].[tb_version] ([id], [dbv], [lastupdate]) VALUES (1, N'0', NULL)
GO
SET IDENTITY_INSERT [dbo].[tb_version] OFF
GO
ALTER TABLE [dbo].[T_GDHEAD] ADD  CONSTRAINT [DF__T_GDHEAD__DATE_C__7EC1CEDB]  DEFAULT (getdate()) FOR [DATE_CREATED]
GO
ALTER TABLE [dbo].[T_GDHEAD] ADD  CONSTRAINT [DF__T_GDHEAD__DATE_M__7FB5F314]  DEFAULT (getdate()) FOR [DATE_MODIFIED]
GO
ALTER TABLE [dbo].[T_INVHED] ADD  CONSTRAINT [DF__T_INVHED__DATE_C__5B78929E]  DEFAULT (getdate()) FOR [DATE_CREATED]
GO
ALTER TABLE [dbo].[T_INVHED] ADD  CONSTRAINT [DF__T_INVHED__DATE_M__5C6CB6D7]  DEFAULT (getdate()) FOR [DATE_MODIFIED]
GO
ALTER TABLE [dbo].[T_INVSETTING] ADD  CONSTRAINT [DF_T_INVSETTING_PrintCat]  DEFAULT ((0)) FOR [PrintCat]
GO
ALTER TABLE [dbo].[T_Items] ADD  CONSTRAINT [DF_T_Items_FirstCost]  DEFAULT ((0)) FOR [FirstCost]
GO
ALTER TABLE [dbo].[T_per] ADD  CONSTRAINT [DF_T_per_ch]  DEFAULT ((0)) FOR [ch]
GO
ALTER TABLE [dbo].[T_Rom] ADD  CONSTRAINT [DF_T_Rom_ch]  DEFAULT ((0)) FOR [ch]
GO
ALTER TABLE [dbo].[T_Rom] ADD  CONSTRAINT [DF_T_Rom_state]  DEFAULT ((0)) FOR [state]
GO
ALTER TABLE [dbo].[T_Sal] ADD  CONSTRAINT [DF_T_Sal_SalaryStatus]  DEFAULT ((0)) FOR [SalaryStatus]
GO
ALTER TABLE [dbo].[T_Salary] ADD  CONSTRAINT [DF_T_Salary_SalaryStatus]  DEFAULT ((0)) FOR [SalaryStatus]
GO
ALTER TABLE [dbo].[T_VacTyp] ADD  CONSTRAINT [DF_T_VacTyp_Dis_Sal_Sts]  DEFAULT ((0)) FOR [Dis_Sal_Sts]
GO
ALTER TABLE [dbo].[T_VisaGoBack] ADD  CONSTRAINT [DF_T_VisaGoBack_CountDay]  DEFAULT ((0)) FOR [CountDay]
GO
ALTER TABLE [dbo].[T_AccCat]  WITH CHECK ADD  CONSTRAINT [FK_T_AccCat_T_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[T_SYSSETTING] ([SYSSETTING_ID])
GO
ALTER TABLE [dbo].[T_AccCat] CHECK CONSTRAINT [FK_T_AccCat_T_Company]
GO
ALTER TABLE [dbo].[T_AccDef]  WITH CHECK ADD  CONSTRAINT [FK_T_AccDef_T_AccCat] FOREIGN KEY([AccCat])
REFERENCES [dbo].[T_AccCat] ([AccCat_ID])
GO
ALTER TABLE [dbo].[T_AccDef] CHECK CONSTRAINT [FK_T_AccDef_T_AccCat]
GO
ALTER TABLE [dbo].[T_AccDef]  WITH CHECK ADD  CONSTRAINT [FK_T_AccDef_T_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[T_SYSSETTING] ([SYSSETTING_ID])
GO
ALTER TABLE [dbo].[T_AccDef] CHECK CONSTRAINT [FK_T_AccDef_T_Company]
GO
ALTER TABLE [dbo].[T_AccDef]  WITH CHECK ADD  CONSTRAINT [FK_T_AccDef_T_Mndob] FOREIGN KEY([Mnd])
REFERENCES [dbo].[T_Mndob] ([Mnd_ID])
GO
ALTER TABLE [dbo].[T_AccDef] CHECK CONSTRAINT [FK_T_AccDef_T_Mndob]
GO
ALTER TABLE [dbo].[T_Add]  WITH CHECK ADD  CONSTRAINT [FK_T_Add_T_Emp] FOREIGN KEY([EmpID])
REFERENCES [dbo].[T_Emp] ([Emp_ID])
GO
ALTER TABLE [dbo].[T_Add] CHECK CONSTRAINT [FK_T_Add_T_Emp]
GO
ALTER TABLE [dbo].[T_Add]  WITH CHECK ADD  CONSTRAINT [FK_T_Add_T_OpMethod] FOREIGN KEY([CalculateNo])
REFERENCES [dbo].[T_OpMethod] ([Method_No])
GO
ALTER TABLE [dbo].[T_Add] CHECK CONSTRAINT [FK_T_Add_T_OpMethod]
GO
ALTER TABLE [dbo].[T_Advances]  WITH CHECK ADD  CONSTRAINT [FK_T_Advances_T_AccDef_AccountID] FOREIGN KEY([AccountID])
REFERENCES [dbo].[T_AccDef] ([AccDef_No])
GO
ALTER TABLE [dbo].[T_Advances] CHECK CONSTRAINT [FK_T_Advances_T_AccDef_AccountID]
GO
ALTER TABLE [dbo].[T_Advances]  WITH CHECK ADD  CONSTRAINT [FK_T_Advances_T_AccDef_BankBR] FOREIGN KEY([BankBR])
REFERENCES [dbo].[T_AccDef] ([AccDef_No])
GO
ALTER TABLE [dbo].[T_Advances] CHECK CONSTRAINT [FK_T_Advances_T_AccDef_BankBR]
GO
ALTER TABLE [dbo].[T_Advances]  WITH CHECK ADD  CONSTRAINT [FK_T_Advances_T_AccDef_LoanAcc] FOREIGN KEY([LoanAcc])
REFERENCES [dbo].[T_AccDef] ([AccDef_No])
GO
ALTER TABLE [dbo].[T_Advances] CHECK CONSTRAINT [FK_T_Advances_T_AccDef_LoanAcc]
GO
ALTER TABLE [dbo].[T_Advances]  WITH CHECK ADD  CONSTRAINT [FK_T_Advances_T_CstTbl] FOREIGN KEY([CostCenterEmp])
REFERENCES [dbo].[T_CstTbl] ([Cst_ID])
GO
ALTER TABLE [dbo].[T_Advances] CHECK CONSTRAINT [FK_T_Advances_T_CstTbl]
GO
ALTER TABLE [dbo].[T_Advances]  WITH CHECK ADD  CONSTRAINT [FK_T_Advances_T_Emp] FOREIGN KEY([EmpID])
REFERENCES [dbo].[T_Emp] ([Emp_ID])
GO
ALTER TABLE [dbo].[T_Advances] CHECK CONSTRAINT [FK_T_Advances_T_Emp]
GO
ALTER TABLE [dbo].[T_AinsData]  WITH CHECK ADD  CONSTRAINT [FK_T_AinsData_T_AinNatural] FOREIGN KEY([AinNature])
REFERENCES [dbo].[T_AinNatural] ([AinNatural_No])
GO
ALTER TABLE [dbo].[T_AinsData] CHECK CONSTRAINT [FK_T_AinsData_T_AinNatural]
GO
ALTER TABLE [dbo].[T_AinsData]  WITH CHECK ADD  CONSTRAINT [FK_T_AinsData_T_AinTyp] FOREIGN KEY([AinTyp])
REFERENCES [dbo].[T_AinTyp] ([AinTyp_No])
GO
ALTER TABLE [dbo].[T_AinsData] CHECK CONSTRAINT [FK_T_AinsData_T_AinTyp]
GO
ALTER TABLE [dbo].[T_AinsData]  WITH CHECK ADD  CONSTRAINT [FK_T_AinsData_T_EqarsData] FOREIGN KEY([EqarID])
REFERENCES [dbo].[T_EqarsData] ([EqarID])
GO
ALTER TABLE [dbo].[T_AinsData] CHECK CONSTRAINT [FK_T_AinsData_T_EqarsData]
GO
ALTER TABLE [dbo].[T_AlarmTenant]  WITH CHECK ADD  CONSTRAINT [FK_T_AlarmTenant_T_Tenant] FOREIGN KEY([tenant_ID])
REFERENCES [dbo].[T_Tenant] ([tenantID])
GO
ALTER TABLE [dbo].[T_AlarmTenant] CHECK CONSTRAINT [FK_T_AlarmTenant_T_Tenant]
GO
ALTER TABLE [dbo].[T_Attend]  WITH CHECK ADD  CONSTRAINT [FK_T_Attend_T_DayOfWeek] FOREIGN KEY([Day_No])
REFERENCES [dbo].[T_DayOfWeek] ([Day_No])
GO
ALTER TABLE [dbo].[T_Attend] CHECK CONSTRAINT [FK_T_Attend_T_DayOfWeek]
GO
ALTER TABLE [dbo].[T_Attend]  WITH CHECK ADD  CONSTRAINT [FK_T_Attend_T_Emp] FOREIGN KEY([EmpID])
REFERENCES [dbo].[T_Emp] ([Emp_ID])
GO
ALTER TABLE [dbo].[T_Attend] CHECK CONSTRAINT [FK_T_Attend_T_Emp]
GO
ALTER TABLE [dbo].[T_AttendOperat]  WITH CHECK ADD  CONSTRAINT [FK_T_AttendOperat_T_DayOfWeek] FOREIGN KEY([Day])
REFERENCES [dbo].[T_DayOfWeek] ([Day_No])
GO
ALTER TABLE [dbo].[T_AttendOperat] CHECK CONSTRAINT [FK_T_AttendOperat_T_DayOfWeek]
GO
ALTER TABLE [dbo].[T_AttendOperat]  WITH CHECK ADD  CONSTRAINT [FK_T_AttendOperat_T_Emp] FOREIGN KEY([EmpID])
REFERENCES [dbo].[T_Emp] ([Emp_ID])
GO
ALTER TABLE [dbo].[T_AttendOperat] CHECK CONSTRAINT [FK_T_AttendOperat_T_Emp]
GO
ALTER TABLE [dbo].[T_AttendOperat]  WITH CHECK ADD  CONSTRAINT [FK_T_AttendOperat_T_Project] FOREIGN KEY([ProjectNo])
REFERENCES [dbo].[T_Project] ([Project_No])
GO
ALTER TABLE [dbo].[T_AttendOperat] CHECK CONSTRAINT [FK_T_AttendOperat_T_Project]
GO
ALTER TABLE [dbo].[T_Authorization]  WITH CHECK ADD  CONSTRAINT [FK_T_Authorization_T_Emp] FOREIGN KEY([EmpID])
REFERENCES [dbo].[T_Emp] ([Emp_ID])
GO
ALTER TABLE [dbo].[T_Authorization] CHECK CONSTRAINT [FK_T_Authorization_T_Emp]
GO
ALTER TABLE [dbo].[T_BankPeaper]  WITH CHECK ADD  CONSTRAINT [FK_T_BankPeaper_T_AccDef] FOREIGN KEY([CustAcc])
REFERENCES [dbo].[T_AccDef] ([AccDef_No])
GO
ALTER TABLE [dbo].[T_BankPeaper] CHECK CONSTRAINT [FK_T_BankPeaper_T_AccDef]
GO
ALTER TABLE [dbo].[T_BankPeaper]  WITH CHECK ADD  CONSTRAINT [FK_T_BankPeaper_T_AccDef1] FOREIGN KEY([BankAcc])
REFERENCES [dbo].[T_AccDef] ([AccDef_No])
GO
ALTER TABLE [dbo].[T_BankPeaper] CHECK CONSTRAINT [FK_T_BankPeaper_T_AccDef1]
GO
ALTER TABLE [dbo].[T_BankPeaper]  WITH CHECK ADD  CONSTRAINT [FK_T_BankPeaper_T_AccDef2] FOREIGN KEY([BranchAcc])
REFERENCES [dbo].[T_AccDef] ([AccDef_No])
GO
ALTER TABLE [dbo].[T_BankPeaper] CHECK CONSTRAINT [FK_T_BankPeaper_T_AccDef2]
GO
ALTER TABLE [dbo].[T_BankPeaper]  WITH CHECK ADD  CONSTRAINT [FK_T_BankPeaper_T_GDHEAD] FOREIGN KEY([gdID])
REFERENCES [dbo].[T_GDHEAD] ([gdhead_ID])
GO
ALTER TABLE [dbo].[T_BankPeaper] CHECK CONSTRAINT [FK_T_BankPeaper_T_GDHEAD]
GO
ALTER TABLE [dbo].[T_BankPeaper]  WITH CHECK ADD  CONSTRAINT [FK_T_BankPeaper_T_SYSSETTING] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[T_SYSSETTING] ([SYSSETTING_ID])
GO
ALTER TABLE [dbo].[T_BankPeaper] CHECK CONSTRAINT [FK_T_BankPeaper_T_SYSSETTING]
GO
ALTER TABLE [dbo].[T_CallPhone]  WITH CHECK ADD  CONSTRAINT [FK_T_CallPhone_T_Emp] FOREIGN KEY([EmpID])
REFERENCES [dbo].[T_Emp] ([Emp_ID])
GO
ALTER TABLE [dbo].[T_CallPhone] CHECK CONSTRAINT [FK_T_CallPhone_T_Emp]
GO
ALTER TABLE [dbo].[T_Cars]  WITH CHECK ADD  CONSTRAINT [FK_T_Cars_T_CarTyp] FOREIGN KEY([CarType])
REFERENCES [dbo].[T_CarTyp] ([CarTyp_No])
GO
ALTER TABLE [dbo].[T_Cars] CHECK CONSTRAINT [FK_T_Cars_T_CarTyp]
GO
ALTER TABLE [dbo].[T_Cars]  WITH CHECK ADD  CONSTRAINT [FK_T_Cars_T_Emp] FOREIGN KEY([EmpID])
REFERENCES [dbo].[T_Emp] ([Emp_ID])
GO
ALTER TABLE [dbo].[T_Cars] CHECK CONSTRAINT [FK_T_Cars_T_Emp]
GO
ALTER TABLE [dbo].[T_CATEGORY]  WITH CHECK ADD  CONSTRAINT [FK_T_CATERY_T_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[T_SYSSETTING] ([SYSSETTING_ID])
GO
ALTER TABLE [dbo].[T_CATEGORY] CHECK CONSTRAINT [FK_T_CATERY_T_Company]
GO
ALTER TABLE [dbo].[T_Commentary]  WITH CHECK ADD  CONSTRAINT [FK_T_Commentary_T_Emp] FOREIGN KEY([EmpID])
REFERENCES [dbo].[T_Emp] ([Emp_ID])
GO
ALTER TABLE [dbo].[T_Commentary] CHECK CONSTRAINT [FK_T_Commentary_T_Emp]
GO
ALTER TABLE [dbo].[T_Commentary]  WITH CHECK ADD  CONSTRAINT [FK_T_Commentary_T_treatment] FOREIGN KEY([treatmentNo])
REFERENCES [dbo].[T_treatment] ([treatment_No])
GO
ALTER TABLE [dbo].[T_Commentary] CHECK CONSTRAINT [FK_T_Commentary_T_treatment]
GO
ALTER TABLE [dbo].[T_CstTbl]  WITH CHECK ADD  CONSTRAINT [FK_T_CstTbl_T_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[T_SYSSETTING] ([SYSSETTING_ID])
GO
ALTER TABLE [dbo].[T_CstTbl] CHECK CONSTRAINT [FK_T_CstTbl_T_Company]
GO
ALTER TABLE [dbo].[T_Curency]  WITH CHECK ADD  CONSTRAINT [FK_T_Curency_T_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[T_SYSSETTING] ([SYSSETTING_ID])
GO
ALTER TABLE [dbo].[T_Curency] CHECK CONSTRAINT [FK_T_Curency_T_Company]
GO
ALTER TABLE [dbo].[T_EditItemPrice]  WITH CHECK ADD  CONSTRAINT [FK_T_EditItemPrice_T_Items] FOREIGN KEY([ItmNo])
REFERENCES [dbo].[T_Items] ([Itm_No])
GO
ALTER TABLE [dbo].[T_EditItemPrice] CHECK CONSTRAINT [FK_T_EditItemPrice_T_Items]
GO
ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_AccDef_AccountID] FOREIGN KEY([AccountID])
REFERENCES [dbo].[T_AccDef] ([AccDef_No])
GO
ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_AccDef_AccountID]
GO
ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_AccDef_BankBR] FOREIGN KEY([BankBR])
REFERENCES [dbo].[T_AccDef] ([AccDef_No])
GO
ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_AccDef_BankBR]
GO
ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_AccDef_HousAcc] FOREIGN KEY([HouseAcc])
REFERENCES [dbo].[T_AccDef] ([AccDef_No])
GO
ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_AccDef_HousAcc]
GO
ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_AccDef_LoanAcc] FOREIGN KEY([LoanAcc])
REFERENCES [dbo].[T_AccDef] ([AccDef_No])
GO
ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_AccDef_LoanAcc]
GO
ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_AccDef_SalAcc] FOREIGN KEY([SalAcc])
REFERENCES [dbo].[T_AccDef] ([AccDef_No])
GO
ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_AccDef_SalAcc]
GO
ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_Bank] FOREIGN KEY([Bank])
REFERENCES [dbo].[T_Bank] ([Bank_No])
GO
ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_Bank]
GO
ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_BirthPlace] FOREIGN KEY([BirthPlace])
REFERENCES [dbo].[T_BirthPlace] ([BirthPlaceNo])
GO
ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_BirthPlace]
GO
ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_BloodTyp] FOREIGN KEY([BloodTyp])
REFERENCES [dbo].[T_BloodTyp] ([BloodTyp_No])
GO
ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_BloodTyp]
GO
ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_City] FOREIGN KEY([CityNo])
REFERENCES [dbo].[T_City] ([City_No])
GO
ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_City]
GO
ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_City1] FOREIGN KEY([ID_From])
REFERENCES [dbo].[T_City] ([City_No])
GO
ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_City1]
GO
ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_City2] FOREIGN KEY([Passport_From])
REFERENCES [dbo].[T_City] ([City_No])
GO
ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_City2]
GO
ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_City3] FOREIGN KEY([License_From])
REFERENCES [dbo].[T_City] ([City_No])
GO
ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_City3]
GO
ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_City4] FOREIGN KEY([Form_From])
REFERENCES [dbo].[T_City] ([City_No])
GO
ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_City4]
GO
ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_City5] FOREIGN KEY([Insurance_From])
REFERENCES [dbo].[T_City] ([City_No])
GO
ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_City5]
GO
ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_Contract] FOREIGN KEY([ContrTyp])
REFERENCES [dbo].[T_Contract] ([Contract_No])
GO
ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_Contract]
GO
ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_CstTbl] FOREIGN KEY([CostCenterEmp])
REFERENCES [dbo].[T_CstTbl] ([Cst_ID])
GO
ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_CstTbl]
GO
ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_Dept] FOREIGN KEY([Dept])
REFERENCES [dbo].[T_Dept] ([Dept_No])
GO
ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_Dept]
GO
ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_Guarantor] FOREIGN KEY([Guarantor])
REFERENCES [dbo].[T_Guarantor] ([Guarantor_No])
GO
ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_Guarantor]
GO
ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_Info] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[T_Info] ([Company_ID])
GO
ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_Info]
GO
ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_Job] FOREIGN KEY([Job])
REFERENCES [dbo].[T_Job] ([Job_No])
GO
ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_Job]
GO
ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_MStatus] FOREIGN KEY([MaritalStatus])
REFERENCES [dbo].[T_MStatus] ([MStatusNo])
GO
ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_MStatus]
GO
ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_Nationalities] FOREIGN KEY([Nationalty])
REFERENCES [dbo].[T_Nationalities] ([Nation_No])
GO
ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_Nationalities]
GO
ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_OpMethod] FOREIGN KEY([CalculateNo])
REFERENCES [dbo].[T_OpMethod] ([Method_No])
GO
ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_OpMethod]
GO
ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_Project] FOREIGN KEY([ProjectNo])
REFERENCES [dbo].[T_Project] ([Project_No])
GO
ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_Project]
GO
ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_Religion] FOREIGN KEY([Religion])
REFERENCES [dbo].[T_Religion] ([Religion_No])
GO
ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_Religion]
GO
ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_SalStatus] FOREIGN KEY([StatusSal])
REFERENCES [dbo].[T_SalStatus] ([SalStatusNo])
GO
ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_SalStatus]
GO
ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_Section] FOREIGN KEY([Section])
REFERENCES [dbo].[T_Section] ([Section_No])
GO
ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_Section]
GO
ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_Sex] FOREIGN KEY([Sex])
REFERENCES [dbo].[T_Sex] ([SexNo])
GO
ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_Sex]
GO
ALTER TABLE [dbo].[T_EmpCards]  WITH CHECK ADD  CONSTRAINT [FK_T_EmpCards_T_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[T_SYSSETTING] ([SYSSETTING_ID])
GO
ALTER TABLE [dbo].[T_EmpCards] CHECK CONSTRAINT [FK_T_EmpCards_T_Company]
GO
ALTER TABLE [dbo].[T_EndService]  WITH CHECK ADD  CONSTRAINT [FK_T_EndService_T_Emp] FOREIGN KEY([EmpID])
REFERENCES [dbo].[T_Emp] ([Emp_ID])
GO
ALTER TABLE [dbo].[T_EndService] CHECK CONSTRAINT [FK_T_EndService_T_Emp]
GO
ALTER TABLE [dbo].[T_EndService]  WITH CHECK ADD  CONSTRAINT [FK_T_EndService_T_LiquidationTyp] FOREIGN KEY([CauseLiquidation])
REFERENCES [dbo].[T_LiquidationTyp] ([LiquidationT_No])
GO
ALTER TABLE [dbo].[T_EndService] CHECK CONSTRAINT [FK_T_EndService_T_LiquidationTyp]
GO
ALTER TABLE [dbo].[T_EqarContract]  WITH CHECK ADD  CONSTRAINT [FK_T_EqarContract_T_AinsData] FOREIGN KEY([AinID])
REFERENCES [dbo].[T_AinsData] ([AinID])
GO
ALTER TABLE [dbo].[T_EqarContract] CHECK CONSTRAINT [FK_T_EqarContract_T_AinsData]
GO
ALTER TABLE [dbo].[T_EqarContract]  WITH CHECK ADD  CONSTRAINT [FK_T_EqarContract_T_EqarsData] FOREIGN KEY([EqarID])
REFERENCES [dbo].[T_EqarsData] ([EqarID])
GO
ALTER TABLE [dbo].[T_EqarContract] CHECK CONSTRAINT [FK_T_EqarContract_T_EqarsData]
GO
ALTER TABLE [dbo].[T_EqarSale]  WITH CHECK ADD  CONSTRAINT [FK_T_EqarSale_T_AinsData] FOREIGN KEY([AinID])
REFERENCES [dbo].[T_AinsData] ([AinID])
GO
ALTER TABLE [dbo].[T_EqarSale] CHECK CONSTRAINT [FK_T_EqarSale_T_AinsData]
GO
ALTER TABLE [dbo].[T_EqarSale]  WITH CHECK ADD  CONSTRAINT [FK_T_EqarSale_T_EqarsData] FOREIGN KEY([EqarID])
REFERENCES [dbo].[T_EqarsData] ([EqarID])
GO
ALTER TABLE [dbo].[T_EqarSale] CHECK CONSTRAINT [FK_T_EqarSale_T_EqarsData]
GO
ALTER TABLE [dbo].[T_EqarsData]  WITH CHECK ADD  CONSTRAINT [FK_T_EqarsData_T_AccDef] FOREIGN KEY([AccNo])
REFERENCES [dbo].[T_AccDef] ([AccDef_No])
GO
ALTER TABLE [dbo].[T_EqarsData] CHECK CONSTRAINT [FK_T_EqarsData_T_AccDef]
GO
ALTER TABLE [dbo].[T_EqarsData]  WITH CHECK ADD  CONSTRAINT [FK_T_EqarsData_T_City] FOREIGN KEY([CityNo])
REFERENCES [dbo].[T_City] ([City_No])
GO
ALTER TABLE [dbo].[T_EqarsData] CHECK CONSTRAINT [FK_T_EqarsData_T_City]
GO
ALTER TABLE [dbo].[T_EqarsData]  WITH CHECK ADD  CONSTRAINT [FK_T_EqarsData_T_EqarNatural] FOREIGN KEY([EqarNatureNo])
REFERENCES [dbo].[T_EqarNatural] ([EqarNatural_No])
GO
ALTER TABLE [dbo].[T_EqarsData] CHECK CONSTRAINT [FK_T_EqarsData_T_EqarNatural]
GO
ALTER TABLE [dbo].[T_EqarsData]  WITH CHECK ADD  CONSTRAINT [FK_T_EqarsData_T_EqarTyp] FOREIGN KEY([EqarTypNo])
REFERENCES [dbo].[T_EqarTyp] ([EqarTyp_No])
GO
ALTER TABLE [dbo].[T_EqarsData] CHECK CONSTRAINT [FK_T_EqarsData_T_EqarTyp]
GO
ALTER TABLE [dbo].[T_EqarsData]  WITH CHECK ADD  CONSTRAINT [FK_T_EqarsData_T_Nationalities] FOREIGN KEY([Nationalty])
REFERENCES [dbo].[T_Nationalities] ([Nation_No])
GO
ALTER TABLE [dbo].[T_EqarsData] CHECK CONSTRAINT [FK_T_EqarsData_T_Nationalities]
GO
ALTER TABLE [dbo].[T_EqarsData]  WITH CHECK ADD  CONSTRAINT [FK_T_EqarsData_T_Owner] FOREIGN KEY([OwnerNo])
REFERENCES [dbo].[T_Owner] ([Owner_No])
GO
ALTER TABLE [dbo].[T_EqarsData] CHECK CONSTRAINT [FK_T_EqarsData_T_Owner]
GO
ALTER TABLE [dbo].[T_Family]  WITH CHECK ADD  CONSTRAINT [FK_T_Family_T_Emp1] FOREIGN KEY([EmpID])
REFERENCES [dbo].[T_Emp] ([Emp_ID])
GO
ALTER TABLE [dbo].[T_Family] CHECK CONSTRAINT [FK_T_Family_T_Emp1]
GO
ALTER TABLE [dbo].[T_GDDET]  WITH CHECK ADD  CONSTRAINT [FK_T_GDDET_T_AccDef] FOREIGN KEY([AccNo])
REFERENCES [dbo].[T_AccDef] ([AccDef_No])
GO
ALTER TABLE [dbo].[T_GDDET] CHECK CONSTRAINT [FK_T_GDDET_T_AccDef]
GO
ALTER TABLE [dbo].[T_GDDET]  WITH CHECK ADD  CONSTRAINT [FK_T_GDDET_T_GDHEAD] FOREIGN KEY([gdID])
REFERENCES [dbo].[T_GDHEAD] ([gdhead_ID])
GO
ALTER TABLE [dbo].[T_GDDET] CHECK CONSTRAINT [FK_T_GDDET_T_GDHEAD]
GO
ALTER TABLE [dbo].[T_GDHEAD]  WITH CHECK ADD  CONSTRAINT [FK_T_GDHEAD_T_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[T_SYSSETTING] ([SYSSETTING_ID])
GO
ALTER TABLE [dbo].[T_GDHEAD] CHECK CONSTRAINT [FK_T_GDHEAD_T_Company]
GO
ALTER TABLE [dbo].[T_GDHEAD]  WITH CHECK ADD  CONSTRAINT [FK_T_GDHEAD_T_CstTbl] FOREIGN KEY([gdCstNo])
REFERENCES [dbo].[T_CstTbl] ([Cst_ID])
GO
ALTER TABLE [dbo].[T_GDHEAD] CHECK CONSTRAINT [FK_T_GDHEAD_T_CstTbl]
GO
ALTER TABLE [dbo].[T_GDHEAD]  WITH CHECK ADD  CONSTRAINT [FK_T_GDHEAD_T_Curency] FOREIGN KEY([CurTyp])
REFERENCES [dbo].[T_Curency] ([Curency_ID])
GO
ALTER TABLE [dbo].[T_GDHEAD] CHECK CONSTRAINT [FK_T_GDHEAD_T_Curency]
GO
ALTER TABLE [dbo].[T_GDHEAD]  WITH CHECK ADD  CONSTRAINT [FK_T_GDHEAD_T_Mndob] FOREIGN KEY([gdMnd])
REFERENCES [dbo].[T_Mndob] ([Mnd_ID])
GO
ALTER TABLE [dbo].[T_GDHEAD] CHECK CONSTRAINT [FK_T_GDHEAD_T_Mndob]
GO
ALTER TABLE [dbo].[T_Info]  WITH CHECK ADD  CONSTRAINT [FK_T_Info_T_OpMethod] FOREIGN KEY([CalculateNo])
REFERENCES [dbo].[T_OpMethod] ([Method_No])
GO
ALTER TABLE [dbo].[T_Info] CHECK CONSTRAINT [FK_T_Info_T_OpMethod]
GO
ALTER TABLE [dbo].[T_Info]  WITH CHECK ADD  CONSTRAINT [FK_T_Info_T_OpMethod1] FOREIGN KEY([CalculatliquidNo])
REFERENCES [dbo].[T_OpMethod] ([Method_No])
GO
ALTER TABLE [dbo].[T_Info] CHECK CONSTRAINT [FK_T_Info_T_OpMethod1]
GO
ALTER TABLE [dbo].[T_InfoTb]  WITH CHECK ADD  CONSTRAINT [FK_T_InfoTb_T_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[T_SYSSETTING] ([SYSSETTING_ID])
GO
ALTER TABLE [dbo].[T_InfoTb] CHECK CONSTRAINT [FK_T_InfoTb_T_Company]
GO
ALTER TABLE [dbo].[T_INVDET]  WITH CHECK ADD  CONSTRAINT [FK_T_INVDET_T_INVHED] FOREIGN KEY([InvId])
REFERENCES [dbo].[T_INVHED] ([InvHed_ID])
GO
ALTER TABLE [dbo].[T_INVDET] CHECK CONSTRAINT [FK_T_INVDET_T_INVHED]
GO
ALTER TABLE [dbo].[T_INVDET]  WITH CHECK ADD  CONSTRAINT [FK_T_INVDET_T_Items] FOREIGN KEY([ItmNo])
REFERENCES [dbo].[T_Items] ([Itm_No])
GO
ALTER TABLE [dbo].[T_INVDET] CHECK CONSTRAINT [FK_T_INVDET_T_Items]
GO
ALTER TABLE [dbo].[T_INVDET]  WITH CHECK ADD  CONSTRAINT [FK_T_INVDET_T_Store] FOREIGN KEY([StoreNo])
REFERENCES [dbo].[T_Store] ([Stor_ID])
GO
ALTER TABLE [dbo].[T_INVDET] CHECK CONSTRAINT [FK_T_INVDET_T_Store]
GO
ALTER TABLE [dbo].[T_INVHED]  WITH CHECK ADD  CONSTRAINT [FK_T_INVHED_T_Chauffeur] FOREIGN KEY([chauffeurNo])
REFERENCES [dbo].[T_Chauffeur] ([chauffeur_ID])
GO
ALTER TABLE [dbo].[T_INVHED] CHECK CONSTRAINT [FK_T_INVHED_T_Chauffeur]
GO
ALTER TABLE [dbo].[T_INVHED]  WITH CHECK ADD  CONSTRAINT [FK_T_INVHED_T_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[T_SYSSETTING] ([SYSSETTING_ID])
GO
ALTER TABLE [dbo].[T_INVHED] CHECK CONSTRAINT [FK_T_INVHED_T_Company]
GO
ALTER TABLE [dbo].[T_INVHED]  WITH CHECK ADD  CONSTRAINT [FK_T_INVHED_T_CstTbl] FOREIGN KEY([InvCstNo])
REFERENCES [dbo].[T_CstTbl] ([Cst_ID])
GO
ALTER TABLE [dbo].[T_INVHED] CHECK CONSTRAINT [FK_T_INVHED_T_CstTbl]
GO
ALTER TABLE [dbo].[T_INVHED]  WITH CHECK ADD  CONSTRAINT [FK_T_INVHED_T_Curency] FOREIGN KEY([CurTyp])
REFERENCES [dbo].[T_Curency] ([Curency_ID])
GO
ALTER TABLE [dbo].[T_INVHED] CHECK CONSTRAINT [FK_T_INVHED_T_Curency]
GO
ALTER TABLE [dbo].[T_INVHED]  WITH CHECK ADD  CONSTRAINT [FK_T_INVHED_T_Mndob] FOREIGN KEY([MndNo])
REFERENCES [dbo].[T_Mndob] ([Mnd_ID])
GO
ALTER TABLE [dbo].[T_INVHED] CHECK CONSTRAINT [FK_T_INVHED_T_Mndob]
GO
ALTER TABLE [dbo].[T_INVHED]  WITH CHECK ADD  CONSTRAINT [FK_T_INVHED_T_Rooms] FOREIGN KEY([RoomNo])
REFERENCES [dbo].[T_Rooms] ([ID])
GO
ALTER TABLE [dbo].[T_INVHED] CHECK CONSTRAINT [FK_T_INVHED_T_Rooms]
GO
ALTER TABLE [dbo].[T_INVSETTING]  WITH CHECK ADD  CONSTRAINT [FK_T_INVSETTING_T_CATEGORY] FOREIGN KEY([CatID])
REFERENCES [dbo].[T_CATEGORY] ([CAT_ID])
GO
ALTER TABLE [dbo].[T_INVSETTING] CHECK CONSTRAINT [FK_T_INVSETTING_T_CATEGORY]
GO
ALTER TABLE [dbo].[T_ItemDet]  WITH CHECK ADD  CONSTRAINT [FK_T_ItemDet_T_Items] FOREIGN KEY([ItmNo])
REFERENCES [dbo].[T_Items] ([Itm_No])
GO
ALTER TABLE [dbo].[T_ItemDet] CHECK CONSTRAINT [FK_T_ItemDet_T_Items]
GO
ALTER TABLE [dbo].[T_ItemDet]  WITH CHECK ADD  CONSTRAINT [FK_T_ItemDet_T_Store] FOREIGN KEY([StoreNo])
REFERENCES [dbo].[T_Store] ([Stor_ID])
GO
ALTER TABLE [dbo].[T_ItemDet] CHECK CONSTRAINT [FK_T_ItemDet_T_Store]
GO
ALTER TABLE [dbo].[T_ItemDet]  WITH CHECK ADD  CONSTRAINT [FK_T_ItemDet_T_Unit] FOREIGN KEY([Unit_])
REFERENCES [dbo].[T_Unit] ([Unit_ID])
GO
ALTER TABLE [dbo].[T_ItemDet] CHECK CONSTRAINT [FK_T_ItemDet_T_Unit]
GO
ALTER TABLE [dbo].[T_Items]  WITH CHECK ADD  CONSTRAINT [FK_T_Items_T_CATERY] FOREIGN KEY([ItmCat])
REFERENCES [dbo].[T_CATEGORY] ([CAT_ID])
GO
ALTER TABLE [dbo].[T_Items] CHECK CONSTRAINT [FK_T_Items_T_CATERY]
GO
ALTER TABLE [dbo].[T_Items]  WITH CHECK ADD  CONSTRAINT [FK_T_Items_T_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[T_SYSSETTING] ([SYSSETTING_ID])
GO
ALTER TABLE [dbo].[T_Items] CHECK CONSTRAINT [FK_T_Items_T_Company]
GO
ALTER TABLE [dbo].[T_Items]  WITH CHECK ADD  CONSTRAINT [FK_T_Items_T_Unit] FOREIGN KEY([Unit1])
REFERENCES [dbo].[T_Unit] ([Unit_ID])
GO
ALTER TABLE [dbo].[T_Items] CHECK CONSTRAINT [FK_T_Items_T_Unit]
GO
ALTER TABLE [dbo].[T_Items]  WITH CHECK ADD  CONSTRAINT [FK_T_Items_T_Unit1] FOREIGN KEY([Unit2])
REFERENCES [dbo].[T_Unit] ([Unit_ID])
GO
ALTER TABLE [dbo].[T_Items] CHECK CONSTRAINT [FK_T_Items_T_Unit1]
GO
ALTER TABLE [dbo].[T_Items]  WITH CHECK ADD  CONSTRAINT [FK_T_Items_T_Unit2] FOREIGN KEY([Unit3])
REFERENCES [dbo].[T_Unit] ([Unit_ID])
GO
ALTER TABLE [dbo].[T_Items] CHECK CONSTRAINT [FK_T_Items_T_Unit2]
GO
ALTER TABLE [dbo].[T_Items]  WITH CHECK ADD  CONSTRAINT [FK_T_Items_T_Unit3] FOREIGN KEY([Unit4])
REFERENCES [dbo].[T_Unit] ([Unit_ID])
GO
ALTER TABLE [dbo].[T_Items] CHECK CONSTRAINT [FK_T_Items_T_Unit3]
GO
ALTER TABLE [dbo].[T_Items]  WITH CHECK ADD  CONSTRAINT [FK_T_Items_T_Unit4] FOREIGN KEY([Unit5])
REFERENCES [dbo].[T_Unit] ([Unit_ID])
GO
ALTER TABLE [dbo].[T_Items] CHECK CONSTRAINT [FK_T_Items_T_Unit4]
GO
ALTER TABLE [dbo].[T_ItemSerial]  WITH CHECK ADD  CONSTRAINT [FK_T_ItemSerial_T_Items] FOREIGN KEY([ItmNo])
REFERENCES [dbo].[T_Items] ([Itm_No])
GO
ALTER TABLE [dbo].[T_ItemSerial] CHECK CONSTRAINT [FK_T_ItemSerial_T_Items]
GO
ALTER TABLE [dbo].[T_Mndob]  WITH CHECK ADD  CONSTRAINT [FK_T_Mndob_T_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[T_SYSSETTING] ([SYSSETTING_ID])
GO
ALTER TABLE [dbo].[T_Mndob] CHECK CONSTRAINT [FK_T_Mndob_T_Company]
GO
ALTER TABLE [dbo].[T_OfferDet]  WITH CHECK ADD  CONSTRAINT [FK_T_OfferDet_T_Items] FOREIGN KEY([ItmNo])
REFERENCES [dbo].[T_Items] ([Itm_No])
GO
ALTER TABLE [dbo].[T_OfferDet] CHECK CONSTRAINT [FK_T_OfferDet_T_Items]
GO
ALTER TABLE [dbo].[T_OfferDet]  WITH CHECK ADD  CONSTRAINT [FK_T_OfferDet_T_Offer] FOREIGN KEY([OfferID])
REFERENCES [dbo].[T_Offer] ([OfferHeadID])
GO
ALTER TABLE [dbo].[T_OfferDet] CHECK CONSTRAINT [FK_T_OfferDet_T_Offer]
GO
ALTER TABLE [dbo].[T_OfferDet]  WITH CHECK ADD  CONSTRAINT [FK_T_OfferDet_T_Unit] FOREIGN KEY([ItmUnt])
REFERENCES [dbo].[T_Unit] ([Unit_ID])
GO
ALTER TABLE [dbo].[T_OfferDet] CHECK CONSTRAINT [FK_T_OfferDet_T_Unit]
GO
ALTER TABLE [dbo].[T_OfferQFree]  WITH CHECK ADD  CONSTRAINT [FK_T_OfferQFree_T_Items] FOREIGN KEY([OfferQFreeItmNo])
REFERENCES [dbo].[T_Items] ([Itm_No])
GO
ALTER TABLE [dbo].[T_OfferQFree] CHECK CONSTRAINT [FK_T_OfferQFree_T_Items]
GO
ALTER TABLE [dbo].[T_OfferQFree]  WITH CHECK ADD  CONSTRAINT [FK_T_OfferQFree_T_Offer] FOREIGN KEY([OfferIDQ])
REFERENCES [dbo].[T_Offer] ([OfferHeadID])
GO
ALTER TABLE [dbo].[T_OfferQFree] CHECK CONSTRAINT [FK_T_OfferQFree_T_Offer]
GO
ALTER TABLE [dbo].[T_OfferQFree]  WITH CHECK ADD  CONSTRAINT [FK_T_OfferQFree_T_OfferDet] FOREIGN KEY([OfferQFreeID])
REFERENCES [dbo].[T_OfferDet] ([OfferDet_ID])
GO
ALTER TABLE [dbo].[T_OfferQFree] CHECK CONSTRAINT [FK_T_OfferQFree_T_OfferDet]
GO
ALTER TABLE [dbo].[T_OfferQFree]  WITH CHECK ADD  CONSTRAINT [FK_T_OfferQFree_T_Unit] FOREIGN KEY([OfferQFreeItmUnt])
REFERENCES [dbo].[T_Unit] ([Unit_ID])
GO
ALTER TABLE [dbo].[T_OfferQFree] CHECK CONSTRAINT [FK_T_OfferQFree_T_Unit]
GO
ALTER TABLE [dbo].[T_Owner]  WITH CHECK ADD  CONSTRAINT [FK_T_Owner_T_Nationalities] FOREIGN KEY([Nationalty])
REFERENCES [dbo].[T_Nationalities] ([Nation_No])
GO
ALTER TABLE [dbo].[T_Owner] CHECK CONSTRAINT [FK_T_Owner_T_Nationalities]
GO
ALTER TABLE [dbo].[T_PatientCout]  WITH CHECK ADD  CONSTRAINT [FK_T_PatientCout_T_Items] FOREIGN KEY([ItmNo])
REFERENCES [dbo].[T_Items] ([Itm_No])
GO
ALTER TABLE [dbo].[T_PatientCout] CHECK CONSTRAINT [FK_T_PatientCout_T_Items]
GO
ALTER TABLE [dbo].[T_per]  WITH CHECK ADD  CONSTRAINT [FK_T_per_T_AccDef] FOREIGN KEY([Cust_no])
REFERENCES [dbo].[T_AccDef] ([AccDef_No])
GO
ALTER TABLE [dbo].[T_per] CHECK CONSTRAINT [FK_T_per_T_AccDef]
GO
ALTER TABLE [dbo].[T_per]  WITH CHECK ADD  CONSTRAINT [FK_T_per_T_Curency] FOREIGN KEY([curr])
REFERENCES [dbo].[T_Curency] ([Curency_ID])
GO
ALTER TABLE [dbo].[T_per] CHECK CONSTRAINT [FK_T_per_T_Curency]
GO
ALTER TABLE [dbo].[T_per]  WITH CHECK ADD  CONSTRAINT [FK_T_per_T_IDType] FOREIGN KEY([pastyp])
REFERENCES [dbo].[T_IDType] ([IDType_ID])
GO
ALTER TABLE [dbo].[T_per] CHECK CONSTRAINT [FK_T_per_T_IDType]
GO
ALTER TABLE [dbo].[T_per]  WITH CHECK ADD  CONSTRAINT [FK_T_per_T_Job] FOREIGN KEY([job])
REFERENCES [dbo].[T_Job] ([Job_No])
GO
ALTER TABLE [dbo].[T_per] CHECK CONSTRAINT [FK_T_per_T_Job]
GO
ALTER TABLE [dbo].[T_per]  WITH CHECK ADD  CONSTRAINT [FK_T_per_T_Nationalities] FOREIGN KEY([nath])
REFERENCES [dbo].[T_Nationalities] ([Nation_No])
GO
ALTER TABLE [dbo].[T_per] CHECK CONSTRAINT [FK_T_per_T_Nationalities]
GO
ALTER TABLE [dbo].[T_per1]  WITH CHECK ADD  CONSTRAINT [FK_T_per1_T_IDType] FOREIGN KEY([pastyp])
REFERENCES [dbo].[T_IDType] ([IDType_ID])
GO
ALTER TABLE [dbo].[T_per1] CHECK CONSTRAINT [FK_T_per1_T_IDType]
GO
ALTER TABLE [dbo].[T_per1]  WITH CHECK ADD  CONSTRAINT [FK_T_per1_T_Job] FOREIGN KEY([job])
REFERENCES [dbo].[T_Job] ([Job_No])
GO
ALTER TABLE [dbo].[T_per1] CHECK CONSTRAINT [FK_T_per1_T_Job]
GO
ALTER TABLE [dbo].[T_per1]  WITH CHECK ADD  CONSTRAINT [FK_T_per1_T_Nationalities] FOREIGN KEY([nat])
REFERENCES [dbo].[T_Nationalities] ([Nation_No])
GO
ALTER TABLE [dbo].[T_per1] CHECK CONSTRAINT [FK_T_per1_T_Nationalities]
GO
ALTER TABLE [dbo].[T_per1]  WITH CHECK ADD  CONSTRAINT [FK_T_per1_T_per] FOREIGN KEY([perno])
REFERENCES [dbo].[T_per] ([perno])
GO
ALTER TABLE [dbo].[T_per1] CHECK CONSTRAINT [FK_T_per1_T_per]
GO
ALTER TABLE [dbo].[T_Premiums]  WITH CHECK ADD  CONSTRAINT [FK_T_Premiums_T_Advances] FOREIGN KEY([Advances_No])
REFERENCES [dbo].[T_Advances] ([Advances_No])
GO
ALTER TABLE [dbo].[T_Premiums] CHECK CONSTRAINT [FK_T_Premiums_T_Advances]
GO
ALTER TABLE [dbo].[T_QTYEXP]  WITH CHECK ADD  CONSTRAINT [FK_T_QTYEXP_T_Items] FOREIGN KEY([itmNo])
REFERENCES [dbo].[T_Items] ([Itm_No])
GO
ALTER TABLE [dbo].[T_QTYEXP] CHECK CONSTRAINT [FK_T_QTYEXP_T_Items]
GO
ALTER TABLE [dbo].[T_QTYEXP]  WITH CHECK ADD  CONSTRAINT [FK_T_QTYEXP_T_Store] FOREIGN KEY([storeNo])
REFERENCES [dbo].[T_Store] ([Stor_ID])
GO
ALTER TABLE [dbo].[T_QTYEXP] CHECK CONSTRAINT [FK_T_QTYEXP_T_Store]
GO
ALTER TABLE [dbo].[T_Reserv]  WITH CHECK ADD  CONSTRAINT [FK_T_Reserv_T_Nationalities] FOREIGN KEY([Nat])
REFERENCES [dbo].[T_Nationalities] ([Nation_No])
GO
ALTER TABLE [dbo].[T_Reserv] CHECK CONSTRAINT [FK_T_Reserv_T_Nationalities]
GO
ALTER TABLE [dbo].[T_Rewards]  WITH CHECK ADD  CONSTRAINT [FK_T_Rewards_T_Emp] FOREIGN KEY([EmpID])
REFERENCES [dbo].[T_Emp] ([Emp_ID])
GO
ALTER TABLE [dbo].[T_Rewards] CHECK CONSTRAINT [FK_T_Rewards_T_Emp]
GO
ALTER TABLE [dbo].[T_Rewards]  WITH CHECK ADD  CONSTRAINT [FK_T_Rewards_T_Emp1] FOREIGN KEY([EmpID])
REFERENCES [dbo].[T_Emp] ([Emp_ID])
GO
ALTER TABLE [dbo].[T_Rewards] CHECK CONSTRAINT [FK_T_Rewards_T_Emp1]
GO
ALTER TABLE [dbo].[T_Rom]  WITH CHECK ADD  CONSTRAINT [FK_T_Rom_T_Loc] FOREIGN KEY([aline])
REFERENCES [dbo].[T_Loc] ([Loc_ID])
GO
ALTER TABLE [dbo].[T_Rom] CHECK CONSTRAINT [FK_T_Rom_T_Loc]
GO
ALTER TABLE [dbo].[T_Rom]  WITH CHECK ADD  CONSTRAINT [FK_T_Rom_T_per] FOREIGN KEY([perno])
REFERENCES [dbo].[T_per] ([perno])
GO
ALTER TABLE [dbo].[T_Rom] CHECK CONSTRAINT [FK_T_Rom_T_per]
GO
ALTER TABLE [dbo].[T_Rooms]  WITH CHECK ADD  CONSTRAINT [FK_T_Rooms_T_Waiter] FOREIGN KEY([waiterNo])
REFERENCES [dbo].[T_Waiter] ([waiter_ID])
GO
ALTER TABLE [dbo].[T_Rooms] CHECK CONSTRAINT [FK_T_Rooms_T_Waiter]
GO
ALTER TABLE [dbo].[T_Sal]  WITH CHECK ADD  CONSTRAINT [FK_T_Sal_T_AccDef] FOREIGN KEY([EmpID])
REFERENCES [dbo].[T_AccDef] ([AccDef_No])
GO
ALTER TABLE [dbo].[T_Sal] CHECK CONSTRAINT [FK_T_Sal_T_AccDef]
GO
ALTER TABLE [dbo].[T_Salary]  WITH CHECK ADD  CONSTRAINT [FK_T_Salary_T_AccDef_AccountNo] FOREIGN KEY([AccountNo])
REFERENCES [dbo].[T_AccDef] ([AccDef_No])
GO
ALTER TABLE [dbo].[T_Salary] CHECK CONSTRAINT [FK_T_Salary_T_AccDef_AccountNo]
GO
ALTER TABLE [dbo].[T_Salary]  WITH CHECK ADD  CONSTRAINT [FK_T_Salary_T_AccDef_BankBr] FOREIGN KEY([BankBR])
REFERENCES [dbo].[T_AccDef] ([AccDef_No])
GO
ALTER TABLE [dbo].[T_Salary] CHECK CONSTRAINT [FK_T_Salary_T_AccDef_BankBr]
GO
ALTER TABLE [dbo].[T_Salary]  WITH CHECK ADD  CONSTRAINT [FK_T_Salary_T_AccDef_HousAcc] FOREIGN KEY([HouseAcc])
REFERENCES [dbo].[T_AccDef] ([AccDef_No])
GO
ALTER TABLE [dbo].[T_Salary] CHECK CONSTRAINT [FK_T_Salary_T_AccDef_HousAcc]
GO
ALTER TABLE [dbo].[T_Salary]  WITH CHECK ADD  CONSTRAINT [FK_T_Salary_T_AccDef_LoanAcc] FOREIGN KEY([LoanAcc])
REFERENCES [dbo].[T_AccDef] ([AccDef_No])
GO
ALTER TABLE [dbo].[T_Salary] CHECK CONSTRAINT [FK_T_Salary_T_AccDef_LoanAcc]
GO
ALTER TABLE [dbo].[T_Salary]  WITH CHECK ADD  CONSTRAINT [FK_T_Salary_T_AccDef_SalAcc] FOREIGN KEY([SalAcc])
REFERENCES [dbo].[T_AccDef] ([AccDef_No])
GO
ALTER TABLE [dbo].[T_Salary] CHECK CONSTRAINT [FK_T_Salary_T_AccDef_SalAcc]
GO
ALTER TABLE [dbo].[T_Salary]  WITH CHECK ADD  CONSTRAINT [FK_T_Salary_T_Bank] FOREIGN KEY([Bank])
REFERENCES [dbo].[T_Bank] ([Bank_No])
GO
ALTER TABLE [dbo].[T_Salary] CHECK CONSTRAINT [FK_T_Salary_T_Bank]
GO
ALTER TABLE [dbo].[T_Salary]  WITH CHECK ADD  CONSTRAINT [FK_T_Salary_T_CstTbl] FOREIGN KEY([CostCenterEmp])
REFERENCES [dbo].[T_CstTbl] ([Cst_ID])
GO
ALTER TABLE [dbo].[T_Salary] CHECK CONSTRAINT [FK_T_Salary_T_CstTbl]
GO
ALTER TABLE [dbo].[T_Salary]  WITH CHECK ADD  CONSTRAINT [FK_T_Salary_T_Dept] FOREIGN KEY([DeptNo])
REFERENCES [dbo].[T_Dept] ([Dept_No])
GO
ALTER TABLE [dbo].[T_Salary] CHECK CONSTRAINT [FK_T_Salary_T_Dept]
GO
ALTER TABLE [dbo].[T_Salary]  WITH CHECK ADD  CONSTRAINT [FK_T_Salary_T_Emp] FOREIGN KEY([EmpID])
REFERENCES [dbo].[T_Emp] ([Emp_ID])
GO
ALTER TABLE [dbo].[T_Salary] CHECK CONSTRAINT [FK_T_Salary_T_Emp]
GO
ALTER TABLE [dbo].[T_Salary]  WITH CHECK ADD  CONSTRAINT [FK_T_Salary_T_Guarantor] FOREIGN KEY([DirBoss])
REFERENCES [dbo].[T_Guarantor] ([Guarantor_No])
GO
ALTER TABLE [dbo].[T_Salary] CHECK CONSTRAINT [FK_T_Salary_T_Guarantor]
GO
ALTER TABLE [dbo].[T_Salary]  WITH CHECK ADD  CONSTRAINT [FK_T_Salary_T_Job] FOREIGN KEY([Job])
REFERENCES [dbo].[T_Job] ([Job_No])
GO
ALTER TABLE [dbo].[T_Salary] CHECK CONSTRAINT [FK_T_Salary_T_Job]
GO
ALTER TABLE [dbo].[T_Salary]  WITH CHECK ADD  CONSTRAINT [FK_T_Salary_T_Section] FOREIGN KEY([SectionNo])
REFERENCES [dbo].[T_Section] ([Section_No])
GO
ALTER TABLE [dbo].[T_Salary] CHECK CONSTRAINT [FK_T_Salary_T_Section]
GO
ALTER TABLE [dbo].[T_SalaryOp]  WITH CHECK ADD  CONSTRAINT [FK_T_SalaryOp_T_Emp] FOREIGN KEY([EmpID])
REFERENCES [dbo].[T_Emp] ([Emp_ID])
GO
ALTER TABLE [dbo].[T_SalaryOp] CHECK CONSTRAINT [FK_T_SalaryOp_T_Emp]
GO
ALTER TABLE [dbo].[T_SalaryOp]  WITH CHECK ADD  CONSTRAINT [FK_T_SalaryOp_T_OpMethod] FOREIGN KEY([opCalc])
REFERENCES [dbo].[T_OpMethod] ([Method_No])
GO
ALTER TABLE [dbo].[T_SalaryOp] CHECK CONSTRAINT [FK_T_SalaryOp_T_OpMethod]
GO
ALTER TABLE [dbo].[T_SalaryOp]  WITH CHECK ADD  CONSTRAINT [FK_T_SalaryOp_T_OpMethod1] FOREIGN KEY([AddTo])
REFERENCES [dbo].[T_OpMethod] ([Method_No])
GO
ALTER TABLE [dbo].[T_SalaryOp] CHECK CONSTRAINT [FK_T_SalaryOp_T_OpMethod1]
GO
ALTER TABLE [dbo].[T_SalDiscount]  WITH CHECK ADD  CONSTRAINT [FK_T_SalDiscount_T_Emp] FOREIGN KEY([EmpID])
REFERENCES [dbo].[T_Emp] ([Emp_ID])
GO
ALTER TABLE [dbo].[T_SalDiscount] CHECK CONSTRAINT [FK_T_SalDiscount_T_Emp]
GO
ALTER TABLE [dbo].[T_SalDiscount]  WITH CHECK ADD  CONSTRAINT [FK_T_SalDiscount_T_OpMethod] FOREIGN KEY([CalculateNo])
REFERENCES [dbo].[T_OpMethod] ([Method_No])
GO
ALTER TABLE [dbo].[T_SalDiscount] CHECK CONSTRAINT [FK_T_SalDiscount_T_OpMethod]
GO
ALTER TABLE [dbo].[T_SalDiscount]  WITH CHECK ADD  CONSTRAINT [FK_T_SalDiscount_T_SubTyp] FOREIGN KEY([SubTyp])
REFERENCES [dbo].[T_SubTyp] ([SubNo])
GO
ALTER TABLE [dbo].[T_SalDiscount] CHECK CONSTRAINT [FK_T_SalDiscount_T_SubTyp]
GO
ALTER TABLE [dbo].[T_Secretariats]  WITH CHECK ADD  CONSTRAINT [FK_T_Secretariats_T_Emp] FOREIGN KEY([EmpID])
REFERENCES [dbo].[T_Emp] ([Emp_ID])
GO
ALTER TABLE [dbo].[T_Secretariats] CHECK CONSTRAINT [FK_T_Secretariats_T_Emp]
GO
ALTER TABLE [dbo].[T_Secretariats]  WITH CHECK ADD  CONSTRAINT [FK_T_Secretariats_T_SecretariatsTyp] FOREIGN KEY([SecretariatsTyp])
REFERENCES [dbo].[T_SecretariatsTyp] ([SecretariatTyp_No])
GO
ALTER TABLE [dbo].[T_Secretariats] CHECK CONSTRAINT [FK_T_Secretariats_T_SecretariatsTyp]
GO
ALTER TABLE [dbo].[T_sertyp]  WITH CHECK ADD  CONSTRAINT [FK_T_sertyp_T_AccDef] FOREIGN KEY([accno])
REFERENCES [dbo].[T_AccDef] ([AccDef_No])
GO
ALTER TABLE [dbo].[T_sertyp] CHECK CONSTRAINT [FK_T_sertyp_T_AccDef]
GO
ALTER TABLE [dbo].[T_SINVDET]  WITH CHECK ADD  CONSTRAINT [FK_T_SINVDET_T_INVDET] FOREIGN KEY([SInvId])
REFERENCES [dbo].[T_INVDET] ([InvDet_ID])
GO
ALTER TABLE [dbo].[T_SINVDET] CHECK CONSTRAINT [FK_T_SINVDET_T_INVDET]
GO
ALTER TABLE [dbo].[T_SINVDET]  WITH CHECK ADD  CONSTRAINT [FK_T_SINVDET_T_INVHED] FOREIGN KEY([SInvIdHEAD])
REFERENCES [dbo].[T_INVHED] ([InvHed_ID])
GO
ALTER TABLE [dbo].[T_SINVDET] CHECK CONSTRAINT [FK_T_SINVDET_T_INVHED]
GO
ALTER TABLE [dbo].[T_SINVDET]  WITH CHECK ADD  CONSTRAINT [FK_T_SINVDET_T_Items] FOREIGN KEY([SItmNo])
REFERENCES [dbo].[T_Items] ([Itm_No])
GO
ALTER TABLE [dbo].[T_SINVDET] CHECK CONSTRAINT [FK_T_SINVDET_T_Items]
GO
ALTER TABLE [dbo].[T_Snd]  WITH CHECK ADD  CONSTRAINT [FK_T_Snd_T_Curency] FOREIGN KEY([curr])
REFERENCES [dbo].[T_Curency] ([Curency_ID])
GO
ALTER TABLE [dbo].[T_Snd] CHECK CONSTRAINT [FK_T_Snd_T_Curency]
GO
ALTER TABLE [dbo].[T_Snd]  WITH CHECK ADD  CONSTRAINT [FK_T_Snd_T_per] FOREIGN KEY([perno])
REFERENCES [dbo].[T_per] ([perno])
GO
ALTER TABLE [dbo].[T_Snd] CHECK CONSTRAINT [FK_T_Snd_T_per]
GO
ALTER TABLE [dbo].[T_STKSQTY]  WITH CHECK ADD  CONSTRAINT [FK_T_STKSQTY_T_Items] FOREIGN KEY([itmNo])
REFERENCES [dbo].[T_Items] ([Itm_No])
GO
ALTER TABLE [dbo].[T_STKSQTY] CHECK CONSTRAINT [FK_T_STKSQTY_T_Items]
GO
ALTER TABLE [dbo].[T_STKSQTY]  WITH CHECK ADD  CONSTRAINT [FK_T_STKSQTY_T_Store] FOREIGN KEY([storeNo])
REFERENCES [dbo].[T_Store] ([Stor_ID])
GO
ALTER TABLE [dbo].[T_STKSQTY] CHECK CONSTRAINT [FK_T_STKSQTY_T_Store]
GO
ALTER TABLE [dbo].[T_Store]  WITH CHECK ADD  CONSTRAINT [FK_T_Store_T_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[T_SYSSETTING] ([SYSSETTING_ID])
GO
ALTER TABLE [dbo].[T_Store] CHECK CONSTRAINT [FK_T_Store_T_Company]
GO
ALTER TABLE [dbo].[T_StoreMnd]  WITH CHECK ADD  CONSTRAINT [FK_T_StoreMnd_T_AccDef] FOREIGN KEY([CusVenNo])
REFERENCES [dbo].[T_AccDef] ([AccDef_No])
GO
ALTER TABLE [dbo].[T_StoreMnd] CHECK CONSTRAINT [FK_T_StoreMnd_T_AccDef]
GO
ALTER TABLE [dbo].[T_StoreMnd]  WITH CHECK ADD  CONSTRAINT [FK_T_StoreMnd_T_Items] FOREIGN KEY([itmNo])
REFERENCES [dbo].[T_Items] ([Itm_No])
GO
ALTER TABLE [dbo].[T_StoreMnd] CHECK CONSTRAINT [FK_T_StoreMnd_T_Items]
GO
ALTER TABLE [dbo].[T_StoreMnd]  WITH CHECK ADD  CONSTRAINT [FK_T_StoreMnd_T_Mndob] FOREIGN KEY([MndNo])
REFERENCES [dbo].[T_Mndob] ([Mnd_ID])
GO
ALTER TABLE [dbo].[T_StoreMnd] CHECK CONSTRAINT [FK_T_StoreMnd_T_Mndob]
GO
ALTER TABLE [dbo].[T_StoreMnd]  WITH CHECK ADD  CONSTRAINT [FK_T_StoreMnd_T_Store] FOREIGN KEY([storeNo])
REFERENCES [dbo].[T_Store] ([Stor_ID])
GO
ALTER TABLE [dbo].[T_StoreMnd] CHECK CONSTRAINT [FK_T_StoreMnd_T_Store]
GO
ALTER TABLE [dbo].[T_TbSalary]  WITH CHECK ADD  CONSTRAINT [FK_T_TbSalary_T_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[T_SYSSETTING] ([SYSSETTING_ID])
GO
ALTER TABLE [dbo].[T_TbSalary] CHECK CONSTRAINT [FK_T_TbSalary_T_Company]
GO
ALTER TABLE [dbo].[T_tel]  WITH CHECK ADD  CONSTRAINT [FK_T_tel_T_per] FOREIGN KEY([perno])
REFERENCES [dbo].[T_per] ([perno])
GO
ALTER TABLE [dbo].[T_tel] CHECK CONSTRAINT [FK_T_tel_T_per]
GO
ALTER TABLE [dbo].[T_Tenant]  WITH CHECK ADD  CONSTRAINT [FK_T_Tenant_T_AccDef] FOREIGN KEY([AccNo])
REFERENCES [dbo].[T_AccDef] ([AccDef_No])
GO
ALTER TABLE [dbo].[T_Tenant] CHECK CONSTRAINT [FK_T_Tenant_T_AccDef]
GO
ALTER TABLE [dbo].[T_Tenant]  WITH CHECK ADD  CONSTRAINT [FK_T_Tenant_T_Nationalities] FOREIGN KEY([Nationalty])
REFERENCES [dbo].[T_Nationalities] ([Nation_No])
GO
ALTER TABLE [dbo].[T_Tenant] CHECK CONSTRAINT [FK_T_Tenant_T_Nationalities]
GO
ALTER TABLE [dbo].[T_TenantContract]  WITH CHECK ADD  CONSTRAINT [FK_T_TenantContract_T_AinsData] FOREIGN KEY([Ain_ID])
REFERENCES [dbo].[T_AinsData] ([AinID])
GO
ALTER TABLE [dbo].[T_TenantContract] CHECK CONSTRAINT [FK_T_TenantContract_T_AinsData]
GO
ALTER TABLE [dbo].[T_TenantContract]  WITH CHECK ADD  CONSTRAINT [FK_T_TenantContract_T_EqarsData] FOREIGN KEY([Eqar_ID])
REFERENCES [dbo].[T_EqarsData] ([EqarID])
GO
ALTER TABLE [dbo].[T_TenantContract] CHECK CONSTRAINT [FK_T_TenantContract_T_EqarsData]
GO
ALTER TABLE [dbo].[T_TenantContract]  WITH CHECK ADD  CONSTRAINT [FK_T_TenantContract_T_Tenant] FOREIGN KEY([tenant_ID])
REFERENCES [dbo].[T_Tenant] ([tenantID])
GO
ALTER TABLE [dbo].[T_TenantContract] CHECK CONSTRAINT [FK_T_TenantContract_T_Tenant]
GO
ALTER TABLE [dbo].[T_TenantPayment]  WITH CHECK ADD  CONSTRAINT [FK_T_TenantPayment_T_GDHEAD] FOREIGN KEY([SndNo])
REFERENCES [dbo].[T_GDHEAD] ([gdhead_ID])
GO
ALTER TABLE [dbo].[T_TenantPayment] CHECK CONSTRAINT [FK_T_TenantPayment_T_GDHEAD]
GO
ALTER TABLE [dbo].[T_TenantPayment]  WITH CHECK ADD  CONSTRAINT [FK_T_TenantPayment_T_TenantContract] FOREIGN KEY([tenantContract_ID])
REFERENCES [dbo].[T_TenantContract] ([ContractID])
GO
ALTER TABLE [dbo].[T_TenantPayment] CHECK CONSTRAINT [FK_T_TenantPayment_T_TenantContract]
GO
ALTER TABLE [dbo].[T_Tickets]  WITH CHECK ADD  CONSTRAINT [FK_T_Tickets_T_Emp] FOREIGN KEY([EmpID])
REFERENCES [dbo].[T_Emp] ([Emp_ID])
GO
ALTER TABLE [dbo].[T_Tickets] CHECK CONSTRAINT [FK_T_Tickets_T_Emp]
GO
ALTER TABLE [dbo].[T_Tickets]  WITH CHECK ADD  CONSTRAINT [FK_T_Tickets_T_TicetTyp] FOREIGN KEY([TickTyp])
REFERENCES [dbo].[T_TicetTyp] ([TicetT_No])
GO
ALTER TABLE [dbo].[T_Tickets] CHECK CONSTRAINT [FK_T_Tickets_T_TicetTyp]
GO
ALTER TABLE [dbo].[T_tran]  WITH CHECK ADD  CONSTRAINT [FK_T_tran_T_per] FOREIGN KEY([perno])
REFERENCES [dbo].[T_per] ([perno])
GO
ALTER TABLE [dbo].[T_tran] CHECK CONSTRAINT [FK_T_tran_T_per]
GO
ALTER TABLE [dbo].[T_tran]  WITH CHECK ADD  CONSTRAINT [FK_T_tran_T_sertyp] FOREIGN KEY([typ])
REFERENCES [dbo].[T_sertyp] ([Serv_ID])
GO
ALTER TABLE [dbo].[T_tran] CHECK CONSTRAINT [FK_T_tran_T_sertyp]
GO
ALTER TABLE [dbo].[T_TransEmployee]  WITH CHECK ADD  CONSTRAINT [FK_T_TransEmployee_T_Emp] FOREIGN KEY([EmpID])
REFERENCES [dbo].[T_Emp] ([Emp_ID])
GO
ALTER TABLE [dbo].[T_TransEmployee] CHECK CONSTRAINT [FK_T_TransEmployee_T_Emp]
GO
ALTER TABLE [dbo].[T_Unit]  WITH CHECK ADD  CONSTRAINT [FK_T_Unit_T_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[T_SYSSETTING] ([SYSSETTING_ID])
GO
ALTER TABLE [dbo].[T_Unit] CHECK CONSTRAINT [FK_T_Unit_T_Company]
GO
ALTER TABLE [dbo].[T_UpdateDoc]  WITH CHECK ADD  CONSTRAINT [FK_T_UpdateDoc_T_City] FOREIGN KEY([DocFrom])
REFERENCES [dbo].[T_City] ([City_No])
GO
ALTER TABLE [dbo].[T_UpdateDoc] CHECK CONSTRAINT [FK_T_UpdateDoc_T_City]
GO
ALTER TABLE [dbo].[T_UpdateDoc]  WITH CHECK ADD  CONSTRAINT [FK_T_UpdateDoc_T_City_After] FOREIGN KEY([DocFromAfter])
REFERENCES [dbo].[T_City] ([City_No])
GO
ALTER TABLE [dbo].[T_UpdateDoc] CHECK CONSTRAINT [FK_T_UpdateDoc_T_City_After]
GO
ALTER TABLE [dbo].[T_UpdateDoc]  WITH CHECK ADD  CONSTRAINT [FK_T_UpdateDoc_T_Emp] FOREIGN KEY([EmpID])
REFERENCES [dbo].[T_Emp] ([Emp_ID])
GO
ALTER TABLE [dbo].[T_UpdateDoc] CHECK CONSTRAINT [FK_T_UpdateDoc_T_Emp]
GO
ALTER TABLE [dbo].[T_UpdateDoc]  WITH CHECK ADD  CONSTRAINT [FK_T_UpdateDoc_T_Insurance_After] FOREIGN KEY([InsuranceNoAfter])
REFERENCES [dbo].[T_Insurance] ([Insurance_No])
GO
ALTER TABLE [dbo].[T_UpdateDoc] CHECK CONSTRAINT [FK_T_UpdateDoc_T_Insurance_After]
GO
ALTER TABLE [dbo].[T_UpdateDoc]  WITH CHECK ADD  CONSTRAINT [FK_T_UpdateDoc_T_Insurance_Befor] FOREIGN KEY([InsuranceNoBefor])
REFERENCES [dbo].[T_Insurance] ([Insurance_No])
GO
ALTER TABLE [dbo].[T_UpdateDoc] CHECK CONSTRAINT [FK_T_UpdateDoc_T_Insurance_Befor]
GO
ALTER TABLE [dbo].[T_Vacation]  WITH CHECK ADD  CONSTRAINT [FK_T_Vacation_T_Emp] FOREIGN KEY([EmpID])
REFERENCES [dbo].[T_Emp] ([Emp_ID])
GO
ALTER TABLE [dbo].[T_Vacation] CHECK CONSTRAINT [FK_T_Vacation_T_Emp]
GO
ALTER TABLE [dbo].[T_Vacation]  WITH CHECK ADD  CONSTRAINT [FK_T_Vacation_T_Emp1] FOREIGN KEY([EmpCover])
REFERENCES [dbo].[T_Emp] ([Emp_ID])
GO
ALTER TABLE [dbo].[T_Vacation] CHECK CONSTRAINT [FK_T_Vacation_T_Emp1]
GO
ALTER TABLE [dbo].[T_Vacation]  WITH CHECK ADD  CONSTRAINT [FK_T_Vacation_T_OpMethod] FOREIGN KEY([CalculateNo])
REFERENCES [dbo].[T_OpMethod] ([Method_No])
GO
ALTER TABLE [dbo].[T_Vacation] CHECK CONSTRAINT [FK_T_Vacation_T_OpMethod]
GO
ALTER TABLE [dbo].[T_Vacation]  WITH CHECK ADD  CONSTRAINT [FK_T_Vacation_T_VacTyp] FOREIGN KEY([VacTyp])
REFERENCES [dbo].[T_VacTyp] ([VacT_No])
GO
ALTER TABLE [dbo].[T_Vacation] CHECK CONSTRAINT [FK_T_Vacation_T_VacTyp]
GO
ALTER TABLE [dbo].[T_VisaGoBack]  WITH CHECK ADD  CONSTRAINT [FK_T_VisaGoBack_T_Emp] FOREIGN KEY([EmpID])
REFERENCES [dbo].[T_Emp] ([Emp_ID])
GO
ALTER TABLE [dbo].[T_VisaGoBack] CHECK CONSTRAINT [FK_T_VisaGoBack_T_Emp]
GO
ALTER TABLE [dbo].[T_VisaIntroduction]  WITH CHECK ADD  CONSTRAINT [FK_T_VisaIntroduction_T_Emp] FOREIGN KEY([EmpID])
REFERENCES [dbo].[T_Emp] ([Emp_ID])
GO
ALTER TABLE [dbo].[T_VisaIntroduction] CHECK CONSTRAINT [FK_T_VisaIntroduction_T_Emp]
GO
/****** Object:  UserDefinedFunction [dbo].[get_date]    Script Date: 08/21/2021 5:56:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[get_date]()
                                    returns VARCHAR(10)
                                    as
                                    begin
                                    DECLARE @GETDATE AS DATETIME = GETDATE()
                                    return  CONVERT(VARCHAR(4),DATEPART(YEAR, @GETDATE)) 
                                    + '/'+ CONVERT(VARCHAR(2),DATEPART(MONTH, @GETDATE)) 
                                    + '/' + CONVERT(VARCHAR(2),DATEPART(DAY, @GETDATE)) end
GO
/****** Object:  UserDefinedFunction [dbo].[GetTickeUsed]    Script Date: 08/21/2021 5:56:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

                                    CREATE FUNCTION [dbo].[GetTickeUsed] (@EmpID varchar(40))
                                    RETURNS Float
                                    WITH EXECUTE AS CALLER
                                    AS
                                    begin
	                                    DECLARE @valueIn int;
	                                    DECLARE @value int;
		                                    set @valueIn = ISNull((SELECT sum(TicketCount) from T_Tickets Where EmpID=@EmpID),'0')

	                                    set @value = @valueIn ;
	                                    return (@value);
                                    end

                                    
GO
/****** Object:  UserDefinedFunction [dbo].[GetVacUsed]    Script Date: 08/21/2021 5:56:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    CREATE FUNCTION [dbo].[GetVacUsed](@EmpID varchar(40))
                                            RETURNS INT
                                            WITH EXECUTE AS CALLER
                                            AS
                                            begin
	                                            DECLARE @valueIn int;
	                                            DECLARE @value int;
		                                            set @valueIn = ISNull((SELECT sum(VacCountDay) from T_Vacation join T_VacTyp on T_Vacation.VacTyp = T_VacTyp.VacT_No Where T_Vacation.EmpID=@EmpID AND T_VacTyp.Dis_VacT = 1 AND T_Vacation.AdminLock = 1),'0')

	                                            set @value = @valueIn ;
	                                            return (@value);
                                            end
GO
/****** Object:  StoredProcedure [dbo].[S_T_GDDET_DELETE]    Script Date: 08/21/2021 5:56:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[S_T_GDDET_DELETE](
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
/****** Object:  StoredProcedure [dbo].[S_T_GDDET_INSERT]    Script Date: 08/21/2021 5:56:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE PROCEDURE [dbo].[S_T_GDDET_INSERT](   
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
/****** Object:  StoredProcedure [dbo].[S_T_GDHEAD_DELETE]    Script Date: 08/21/2021 5:56:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE PROCEDURE [dbo].[S_T_GDHEAD_DELETE](
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
/****** Object:  StoredProcedure [dbo].[S_T_INVDET_DELETE]    Script Date: 08/21/2021 5:56:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE PROCEDURE [dbo].[S_T_INVDET_DELETE](
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
/****** Object:  StoredProcedure [dbo].[S_T_INVDET_INSERT]    Script Date: 08/21/2021 5:56:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[S_T_INVDET_INSERT](   
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
/****** Object:  StoredProcedure [dbo].[S_T_INVHED_DELETE]    Script Date: 08/21/2021 5:56:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[S_T_INVHED_DELETE](
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
/****** Object:  StoredProcedure [dbo].[S_T_INVHED_INSERT]    Script Date: 08/21/2021 5:56:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE[dbo].[S_T_INVHED_INSERT]
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
/****** Object:  StoredProcedure [dbo].[S_T_INVHED_UPDATE]    Script Date: 08/21/2021 5:56:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[S_T_INVHED_UPDATE](
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
/****** Object:  StoredProcedure [dbo].[S_T_Report]    Script Date: 08/21/2021 5:56:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[S_T_Report](
                    
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
/****** Object:  StoredProcedure [dbo].[S_T_SINVDET_DELETE]    Script Date: 08/21/2021 5:56:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[S_T_SINVDET_DELETE](
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
/****** Object:  StoredProcedure [dbo].[S_T_SINVDET_INSERT]    Script Date: 08/21/2021 5:56:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[S_T_SINVDET_INSERT](   
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
/****** Object:  StoredProcedure [dbo].[UpdateBalance]    Script Date: 08/21/2021 5:56:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateBalance]
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
