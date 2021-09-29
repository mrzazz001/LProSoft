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
GO
ALTER DATABASE [PROSOFT] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [PROSOFT] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PROSOFT] SET AUTO_UPDATE_STATISTICS ON 
GO
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
/****** Object:  User [omar]    Script Date: 8/10/2021 6:18:45 PM ******/
CREATE USER [omar] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  UserDefinedFunction [dbo].[get_date]    Script Date: 8/10/2021 6:18:45 PM ******/
/****** Object:  Table [dbo].[cod]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_AccCat]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_AccDef]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Add]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_AddTyp]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Advances]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_AinNatural]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_AinsData]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_AinTyp]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_AlarmTenant]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Attend]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_AttendOperat]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Authorization]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Bank]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_BankPeaper]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_BirthPlace]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_BlackList]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_BloodTyp]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Boss]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_CallPhone]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_CarCheckPIC]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_CarNames]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Cars]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_CarTyp]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_CATEGORY]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Chauffeur]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_City]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Colors]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Commentary]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Company]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Contract]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_CstTbl]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Curency]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_DayOfWeek]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_DaysOfMonth]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Dept]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_EditItemPrice]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Emp]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_EmpCards]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_EndService]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_EqarContract]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_EqarNatural]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_EqarSale]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_EqarsData]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_EqarTyp]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Family]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_GdAuto]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_GDDET]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_GDHEAD]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Guarantor]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_IDType]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Info]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_InfoTb]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Insurance]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_INVDET]    Script Date: 8/10/2021 6:18:45 PM ******/
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
	[ItmAddCost] [float] NULL,
	[RunCod] [varchar](100) NULL,
	[LineDetails] [varchar](250) NULL,
	[Serial_Key] [varchar](100) NULL,
	[ItmTax] [float] NULL,
	[OfferTyp] [int] NULL,
	[CInvType] [int] NULL,
	[CaExState] [int] NULL,
	[IfRet] [int] NULL,
	[RetQty] [float] NULL,
 CONSTRAINT [PK_T_INVDET] PRIMARY KEY CLUSTERED 
(
	[InvDet_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_INVDET_Repair]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_InvDetNote]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_INVHED]    Script Date: 8/10/2021 6:18:45 PM ******/
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
 CONSTRAINT [PK_T_INVHED] PRIMARY KEY CLUSTERED 
(
	[InvHed_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_INVSETTING]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_ItemDet]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Items]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_ItemSerial]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Job]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_LiquidationTyp]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Loc]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_mInvPrint]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Mndob]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_MStatus]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_MTemplates]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Nationalities]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Offer]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_OfferDet]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_OfferQFree]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_OpMethod]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Owner]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_PatientCout]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_per]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_per1]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Pine]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Premiums]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Printers]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Project]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_QTYEXP]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Religion]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Reserv]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Rewards]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Rom]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_RomChart]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_romtrn]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Rooms]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Sal]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Salary]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_SalaryOp]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_SalDiscount]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_SalStatus]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Secretariats]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_SecretariatsTyp]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Section]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_sertyp]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Sex]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_SINVDET]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Snd]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_STKSQTY]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Store]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_StoreMnd]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_StsReas]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_SubTyp]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_SYSSETTING]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_TbSalary]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_tel]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_telmn]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Tenant]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_TenantContract]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_TenantPayment]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_TicetTyp]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Tickets]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_tran]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_TransEmployee]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_treatment]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Unit]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_UpdateDoc]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Vacation]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_VacTyp]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_VisaGoBack]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_VisaIntroduction]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[T_Waiter]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[tb_version]    Script Date: 8/10/2021 6:18:45 PM ******/
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
/****** Object:  Table [dbo].[TmpTbl]    Script Date: 8/10/2021 6:18:45 PM ******/
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
INSERT [dbo].[T_Company] ([Cop_ID], [CopNam], [Active], [Adder], [Tel1], [Tel2], [Fax], [Pox], [Symbl], [Eamil], [Mobl]) VALUES (1, N'مؤسسة    ', N'برامج', N'جدة', N'-------', N'---------', N'----------', N'-------', N'----------', N'----------', N'--------------')
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
INSERT [dbo].[T_InfoTb] ([InfoTb_ID], [fldFlag], [fldValue], [grpFlag], [emptFld1], [emptFld2], [emptFld3], [FontN], [FontS], [FontB], [FontI], [CompanyID]) VALUES (9, N'rTrwes1', N'مؤسسة    ', N'PRNTINF', N'', N'', N'', N'Arial', 12, 1, 0, NULL)
GO
INSERT [dbo].[T_InfoTb] ([InfoTb_ID], [fldFlag], [fldValue], [grpFlag], [emptFld1], [emptFld2], [emptFld3], [FontN], [FontS], [FontB], [FontI], [CompanyID]) VALUES (10, N'rTrwes2', N'', N'PRNTINF', N'', N'', N'', N'Arial', 12, 1, 0, NULL)
GO
INSERT [dbo].[T_InfoTb] ([InfoTb_ID], [fldFlag], [fldValue], [grpFlag], [emptFld1], [emptFld2], [emptFld3], [FontN], [FontS], [FontB], [FontI], [CompanyID]) VALUES (11, N'rTrwes3', N'ص.ب ------ جدة -------', N'PRNTINF', N'', N'', N'', N'Arial', 12, 1, 0, NULL)
GO
INSERT [dbo].[T_InfoTb] ([InfoTb_ID], [fldFlag], [fldValue], [grpFlag], [emptFld1], [emptFld2], [emptFld3], [FontN], [FontS], [FontB], [FontI], [CompanyID]) VALUES (12, N'rTrwes4', N'هاتف : ------- / ------- فاكس ------', N'PRNTINF', N'', N'', N'', N'Arial', 12, 1, 0, NULL)
GO
INSERT [dbo].[T_InfoTb] ([InfoTb_ID], [fldFlag], [fldValue], [grpFlag], [emptFld1], [emptFld2], [emptFld3], [FontN], [FontS], [FontB], [FontI], [CompanyID]) VALUES (13, N'lTrwes1', N'', N'PRNTINF', N'', N'', N'', N'Arial', 12, 1, 0, NULL)
GO
INSERT [dbo].[T_InfoTb] ([InfoTb_ID], [fldFlag], [fldValue], [grpFlag], [emptFld1], [emptFld2], [emptFld3], [FontN], [FontS], [FontB], [FontI], [CompanyID]) VALUES (14, N'lTrwes2', N'', N'PRNTINF', N'', N'', N'', N'Arial', 12, 1, 0, NULL)
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
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (101, -101, N'فاتورة معلقة', N'SaveOverBill', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (1, 1, N'فاتورة مبيعات                                     ', N'Sales Invoice                                     ', N'212', N'1         ', N'نقدي                          ', N'آجل       ', NULL, NULL, NULL, N'Cash      ', N'Credit    ', NULL, NULL, NULL, -2147483633, 12640511, 0, N'العميل              ', NULL, NULL, NULL, NULL, N'Customer            ', NULL, NULL, NULL, NULL, N'3021001        ', N'1020001        ', NULL, NULL, NULL, NULL, NULL, N'3021005        ', N'***', N'3021005', N'1031001', N'3021001', N'1020001', N'3021005', N'***', 1, 1, 1, 1, 0, 6, N'Microsoft XPS Document Writer', N'111', N'1011 ', 1, 1, 1, N'', 1, NULL, 0, N'11011001', 0, N'1020001        ', N'4011026', 0, N'3021003', N'3021001', N'10', 0, N'***', N'4011012', N'***', N'4011026')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (2, 2, N'فاتورة مشتريات                                    ', N'Purchase Receipt                                  ', N'111', N'1         ', N'نقدي                          ', N'آجل       ', NULL, NULL, NULL, N'Cash      ', N'Credit    ', NULL, NULL, NULL, -2147483633, 14737632, 8, N'المورد              ', NULL, NULL, NULL, NULL, N'Supplyer            ', NULL, NULL, NULL, NULL, N'1031001', N'3041001', NULL, NULL, NULL, NULL, NULL, N'***', N'3041005', N'1031001', N'3041005', N'1020001', N'3041001', N'***', N'3041005', 1, 1, 1, 1, 0, 6, NULL, N'111', N'1100 ', 1, 1, 1, N'', 1, NULL, 0, N'11101001', 0, N'4011027', N'1020001', 0, N'3041001', N'3041003', N'10', 0, N'4011012', N'***', N'4011027', N'***')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (3, 3, N' مرتجع مبيعات                                     ', N'Sales Return                                      ', N'111', N'1         ', N'نقدي                          ', N'آجل       ', NULL, NULL, NULL, N'Cash      ', N'Credit    ', NULL, NULL, NULL, -2147483633, 12640511, 0, N'العميل              ', NULL, NULL, NULL, NULL, N'Customer            ', NULL, NULL, NULL, NULL, N'1020001', N'3021002', NULL, NULL, NULL, NULL, NULL, N'***', N'3021006', N'1031001', N'3021006', N'1020001', N'3021002', N'***', N'3021006', 1, 1, 1, 1, 0, 6, NULL, N'111', N'1011 ', 1, 1, 1, N'', 1, NULL, 0, N'11011001', 0, N'4011026', N'1020001', 0, N'3021002', N'3021004', N'10', 0, N'***', N'***', N'4011026', N'***')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (4, 4, N'مرتجع مشتريات                                     ', N'Purchase Return                                   ', N'212', N'1         ', N'نقدي                          ', N'آجل       ', NULL, NULL, NULL, N'Cash      ', N'Credit    ', NULL, NULL, NULL, -2147483633, 14737632, 8, N'المورد              ', NULL, NULL, NULL, NULL, N'Supplyer            ', NULL, NULL, NULL, NULL, N'3041002', N'1020001', NULL, NULL, NULL, NULL, NULL, N'3041006', N'***', N'3041006', N'1031001', N'3041002', N'1020001', N'3041006', N'***', 1, 1, 1, 1, 0, 6, NULL, N'111', N'1100 ', 1, 1, 1, N'', 1, NULL, 0, N'11101001', 0, N'1020001', N'4011027', 0, N'3041004', N'3041002', N'10', 0, N'***', N'***', N'***', N'4011027')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (5, 5, N'سند إدخال بضاعة                                   ', N'Transfer In                                       ', N'101', N'1         ', N'إدخال                         ', NULL, NULL, NULL, NULL, N'Entry     ', NULL, NULL, NULL, NULL, -2147483633, 16777152, 6, N'من مستودع           ', NULL, NULL, NULL, NULL, N'Store               ', NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, NULL, N'111', N'1110 ', 1, 1, 1, N'', 1, NULL, 0, N'11101001', 0, N'***', N'***', 0, N'***', N'***', N'10', 0, N'***', N'***', N'***', N'***')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (6, 6, N'سند إخراج بضاعة                                   ', N'Transfer Out                                      ', N'202', N'1         ', N'إخراج                         ', NULL, NULL, NULL, NULL, N'Out       ', NULL, NULL, NULL, NULL, -2147483633, 16777152, 6, N'من مستودع           ', NULL, NULL, NULL, NULL, N'Store               ', NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, NULL, N'111', N'1110 ', 1, 1, 1, N'', 1, NULL, 0, N'11101001', 0, N'***', N'***', 0, N'***', N'***', N'10', 0, N'***', N'***', N'***', N'***')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (7, 7, N'عرض سعر للعملاء                                   ', N'Sales Qutation                                    ', N'000', N'1         ', N'عرض                           ', NULL, NULL, NULL, NULL, N'Qutation  ', NULL, NULL, NULL, NULL, -2147483633, 12640511, 0, N'العميل              ', NULL, NULL, NULL, NULL, N'Customer            ', NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, NULL, N'111', N'1011 ', 1, 1, 1, N'', 1, NULL, 0, N'11011001', 0, N'***', N'***', 0, N'***', N'***', N'10', 0, N'***', N'***', N'***', N'***')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (8, 8, N'عرض سعر للموردين                                  ', N'Goods Receipt                                     ', N'101', N'1         ', N'عرض                           ', NULL, NULL, NULL, NULL, N'Receipt   ', NULL, NULL, NULL, NULL, -2147483633, 14737632, 6, N'المورد              ', NULL, NULL, NULL, NULL, N'Supplyer            ', NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, NULL, N'111', N'1100 ', 1, 1, 1, N'', 1, NULL, 0, N'11011001', 0, N'***', N'***', 0, N'***', N'***', N'10', 0, N'***', N'***', N'***', N'***')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (9, 9, N'طلب شراء                                          ', N'Purchase Order                                    ', N'000', N'1         ', N'طلب                           ', NULL, NULL, NULL, NULL, N'Order     ', NULL, NULL, NULL, NULL, -2147483633, 16771816, 7, N'المورد              ', NULL, NULL, NULL, NULL, N'Supplyer            ', NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, NULL, N'111', N'1100 ', 1, 1, 1, N'', 1, NULL, 0, N'11101001', 0, N'***', N'***', 0, N'***', N'***', N'10', 0, N'***', N'***', N'***', N'***')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (21, 21, N'الطلبات المحلية', N'Local Orders', N'910', N'1         ', N'سند                           ', NULL, NULL, NULL, NULL, N'Snad      ', NULL, NULL, NULL, NULL, -2147483633, 12641511, 8, N'الحساب              ', NULL, NULL, NULL, NULL, N'Account             ', NULL, NULL, NULL, NULL, N'3021005        ', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, NULL, N'111', N'1011      ', 1, 1, 1, N'', 1, NULL, 0, N'00000000', 0, N'***', N'***', 0, N'***', N'***', NULL, 0, N'***', N'***', N'***', N'***')
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
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (10, 10, N'سند تسوية                                         ', N'Stock Adjustment', N'101', N'1         ', N'سند                           ', NULL, NULL, NULL, NULL, N'Snad      ', NULL, NULL, NULL, NULL, -2147483633, 16771816, 6, N'المستودع            ', NULL, NULL, NULL, NULL, N'Store               ', NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, NULL, N'111', N'1110 ', 1, 1, 1, N'', 1, NULL, 0, N'11101001', 0, N'***', N'***', 0, N'***', N'***', N'10', 0, N'***', N'***', N'***', N'***')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (11, 11, N'سند قيد                                           ', N'Journal Voucher                                   ', N'1', N'1         ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, -2147483633, 12640511, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 10, N'', N'101', NULL, 1, 1, 1, N'', 1, NULL, 0, NULL, 0, N'***', N'***', 0, N'***', N'***', NULL, 0, N'***', N'***', N'***', N'***')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (12, 12, N'سند قبض                                           ', N'Receipt Voucher                                   ', N'1', N'1         ', N'أستلمنا من المكرم             ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, -2147483633, 16706518, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 10, N'', N'111', NULL, 1, 1, 1, N'', 1, NULL, 0, NULL, 0, N'***', N'***', 0, N'***', N'***', NULL, 0, N'***', N'***', N'***', N'***')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (13, 13, N'سند صرف                                           ', N'Payment Voucher                                   ', N'1', N'1         ', N'أصرفوا لي المكرم              ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, -2147483633, 14737632, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, N'', N'101', NULL, 1, 1, 1, N'', 1, NULL, 0, NULL, 0, N'***', N'***', 0, N'***', N'***', NULL, 0, N'***', N'***', N'***', N'***')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (14, 14, N'بضاعة اول المدة', N'Open Quantities                                   ', N'303', N'1         ', N'سند                           ', NULL, NULL, NULL, NULL, N'Snad      ', NULL, NULL, NULL, NULL, -2147483633, 16706518, 6, N'المستودع            ', NULL, NULL, NULL, NULL, N'Store               ', NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, NULL, N'111', N'1110 ', 1, 1, 1, N'', 1, NULL, 0, N'11101001', 0, N'***', N'***', 0, N'***', N'***', N'10', 0, N'***', N'***', N'***', N'***')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (15, 15, N'خدمات النزلاء', N'Guests Services', N'414', N'1         ', N'سند                           ', NULL, NULL, NULL, NULL, N'Snad      ', NULL, NULL, NULL, NULL, -2147483633, 16706518, 6, N'المستودع            ', NULL, NULL, NULL, NULL, N'Store               ', NULL, NULL, NULL, NULL, N'4011002        ', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, NULL, N'111', N'1110 ', 1, 1, 1, N'', 1, NULL, 0, NULL, 0, N'***', N'***', 0, N'***', N'***', NULL, 0, N'***', N'***', N'***', N'***')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (16, 16, N'شؤون الموظفين', N'HR', N'101', N'1         ', N'أمر تصنيع                     ', NULL, NULL, NULL, NULL, N'Snad      ', NULL, NULL, NULL, NULL, -2147483633, 16706518, 8, N'نوع السند           ', NULL, NULL, NULL, NULL, N'Store               ', NULL, NULL, NULL, NULL, N'3051002        ', N'3051001        ', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, N'', N'101', NULL, 1, 1, 1, N'', 1, NULL, 0, N'11101011', 0, N'***', N'***', 0, N'***', N'***', N'10', 0, N'***', N'***', N'***', N'***')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (17, 17, N'أمر صرف بضاعة                                     ', N'Payment Order                                     ', N'212', N'1         ', N'سند                           ', NULL, NULL, NULL, NULL, N'Snad      ', NULL, NULL, NULL, NULL, -2147483633, 12641511, 0, N'الحساب              ', NULL, NULL, NULL, NULL, N'Account             ', NULL, NULL, NULL, NULL, N'3021001        ', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, NULL, N'111', N'1011 ', 1, 1, 1, N'', 1, NULL, 0, N'11011001', 0, N'***', N'***', 0, N'***', N'***', N'10', 0, N'***', N'***', N'***', N'***')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (18, 18, N'سند قبض                                           ', N'Receipt Voucher                                   ', N'418', N'1         ', N'أستلمنا من المكرم             ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, -2147483633, 16706518, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 10, NULL, N'101', NULL, 1, 1, 1, N'', 1, NULL, 0, NULL, 0, N'***', N'***', 0, N'***', N'***', NULL, 0, N'***', N'***', N'***', N'***')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (19, 19, N'سند صرف                                           ', N'Payment Voucher                                   ', N'419', N'1         ', N'أصرفوا لي المكرم              ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, -2147483633, 14737632, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'***', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, N'', N'101', NULL, 1, 1, 1, N'', 1, NULL, 0, NULL, 0, N'***', N'***', 0, N'***', N'***', NULL, 0, N'***', N'***', N'***', N'***')
GO
INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines], [defSizePaper], [Orientation], [CatID], [PrintCat], [TaxOptions], [autoTaxGaid], [TaxDebit], [TaxCredit], [autoDisGaid], [DisDebit], [DisCredit], [CommOptions], [autoCommGaid], [CommDebit], [CommCredit], [TaxDebitCredit], [TaxCreditCredit]) VALUES (20, 20, N'مرتجع صرف بضاعة                                   ', N'Payment Order Return                              ', N'111', N'1         ', N'سند                           ', NULL, NULL, NULL, NULL, N'Snad      ', NULL, NULL, NULL, NULL, -2147483633, 12641511, 8, N'الحساب              ', NULL, NULL, NULL, NULL, N'Account             ', NULL, NULL, NULL, NULL, N'3021001        ', N'***', NULL, NULL, NULL, NULL, NULL, N'***', N'***', N'***', N'***', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, NULL, N'111', N'1011 ', 1, 1, 1, N'', 1, NULL, 0, N'11011001', 0, N'***', N'***', 0, N'***', N'***', N'10', 0, N'***', N'***', N'***', N'***')
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
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (33, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 10, N'Microsoft XPS Document Writer', N'111', N'', 1, 1, 2, NULL, NULL, N'', N'', NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (34, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, NULL, N'111', N'', 1, 2, 2, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (35, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, NULL, N'111', N'', 1, 3, 2, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (36, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, NULL, N'111', N'', 1, 4, 2, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (37, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, NULL, N'111', N'', 1, 5, 2, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (38, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, NULL, N'111', N'', 1, 6, 2, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (39, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, NULL, N'111', N'', 1, 7, 2, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (40, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, NULL, N'111', N'', 1, 8, 2, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (41, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, NULL, N'111', N'', 1, 9, 2, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (42, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, NULL, N'111', N'', 1, 21, 2, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (43, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 1, N'Microsoft Print to PDF (redirected 4)', N'101', N'', 1, 22, 2, NULL, NULL, NULL, NULL, N'0')
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (44, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 10, N'', N'111', N'', 1, 23, 2, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (45, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, N'', N'101', N'', 1, 24, 2, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (46, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 10, N'', N'111', N'', 1, 25, 2, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (47, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, N'', N'101', N'', 1, 26, 2, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (48, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 10, N'', N'111', N'', 1, 27, 2, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (49, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 10, N'', N'111', N'', 1, 28, 2, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 10, N'', N'111', N'', 1, 29, 2, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (51, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 10, N'', N'111', N'', 1, 30, 2, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (52, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, N'Microsoft XPS Document Writer', N'110', NULL, NULL, 100, 2, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (53, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, NULL, N'111', N'', 1, 10, 2, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (54, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 10, N'Microsoft Print to PDF (redirected 4)', N'101', N'', 1, 11, 2, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (55, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 10, N'', N'111', N'', 1, 12, 2, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (56, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, N'', N'101', N'', 1, 13, 2, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (57, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, NULL, N'111', N'', 1, 14, 2, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (58, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, NULL, N'111', N'', 1, 15, 2, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (59, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, N'', N'101', N'', 1, 16, 2, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (60, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, NULL, N'111', N'', 1, 17, 2, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (61, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 10, NULL, N'101', N'', 1, 18, 2, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (62, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, N'', N'101', N'', 1, 19, 2, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (63, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 6, NULL, N'111', N'', 1, 20, 2, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[T_Printers] ([P_ID], [Printer_Name], [Paper_Size], [Default_Operation], [DefLines_Setting], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [defSizePaper_Setting], [Orientation_Setting], [DefLines], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [defSizePaper], [Orientation], [InvID], [User_ID], [Branch_ID], [Company], [invGdADesc], [invGdEDesc], [InvTypA4]) VALUES (64, NULL, NULL, NULL, 1, 1, 1, 1, 1, 0, 10, N'Microsoft XPS Document Writer', N'101', N'', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1091, 2, NULL, NULL, NULL, NULL, NULL)
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
INSERT [dbo].[T_SYSSETTING] ([SYSSETTING_ID], [AutoItm], [AccCus], [AccCusDes], [AccSup], [AccSupDes], [Seting], [DefLines_Setting], [SysDir], [HDat], [Calendr], [LrnExp], [DMY], [AutoEmp], [InvID], [GedID], [InvMod], [LogImg], [BackPath], [IsAutoBackup], [AutoBackup], [AutoBackupDate], [hAl_Setting], [hAs_Setting], [hYm_Setting], [hYs_Setting], [lnPg_Setting], [lnSpc_Setting], [defPrn_Setting], [nTyp_Setting], [IsBackground], [IsNotBackground], [BackgroundPic], [defSizePaper_Setting], [Orientation_Setting], [Sponer], [IsAlarmVisaGoBack], [IsAlarmVisaIntro], [AlarmVisaGoBack], [AlarmVisaIntro], [IsAlarmDepts], [AlarmDeptsBefore], [AutoChangSalStatus], [AccUsrNo], [DocumentPath], [ImportFilePath], [ImportIp], [ImportEmpNo], [ImportDate], [ImportTime1], [ImportTimeLeave1], [ImportStart], [ImportEnd], [AccPath], [ServerNm], [DataBaseNm], [Sa_Pass], [Path_Kind], [AlarmDoc], [AlarmDocBefore], [AutoLeave], [EmpLeaveAfter], [AttendanceManually], [VacationManually], [CalculateNo], [CalculatliquidNo], [Allowances], [AllowancesTime], [ShowBanner], [ShowPageNo], [ShowDateH], [ShowDateG], [SalDate], [DisVacationType], [IsAlarmEmpDoc], [IsAlarmEmpContract], [IsAlarmFamilyPassport], [IsAlarmGuarantorDoc], [IsAlarmEndVaction], [IsAlarmBranchDoc], [IsAlarmCarDoc], [IsAlarmSecretariatsDoc], [AlarmEmpDocBefore], [AlarmEmpContractBefore], [AlarmFamilyPassportBefore], [AlarmGuarantorDocBefore], [AlarmEndVactionBefore], [AlarmBranchDocBefore], [AlarmCarDocBefore], [AlarmSecretariatsBefore], [smsUserName], [smsPass], [smsSenderName], [smsMessage1], [smsMessage2], [smsMessage3], [smsMessage4], [AlarmEmployee], [LineDetailSts], [LineDetailNameA], [LineDetailNameE], [LineGiftSts], [LineGiftlNameA], [LineGiftlNameE], [TableFamily], [TableBoys], [TableExtrnal], [TableOther], [MainDirPath], [BColor0], [BColor1], [BColor2], [BColor3], [BColor4], [BColor5], [BColor6], [BColor7], [FColor0], [FColor1], [FColor2], [FColor3], [FColor4], [FColor5], [FColor6], [FColor7], [Fld_w], [Fld_H], [DayOfM], [ch], [flore], [rom], [vStart], [vEnd], [vStartTyp], [vEndTyp], [GuestAcc], [GuestBoxAcc], [DefSalesTax], [DefPurchaesTax], [TaxAcc], [TaxNoteInv], [IsCustomerDisplay], [Port], [Fast], [BitStop], [BitData], [Parity], [CustomerHello], [DisplayTypeShow], [LineOfInvoices], [IsActiveBalance], [BalanceType], [BarcodFrom], [BarcodTo], [WightFrom], [WightTo], [PriceFrom], [PriceTo], [WightQ], [PriceQ], [PointOfRyal], [ItemTyp1], [ItemTyp2], [ItemTyp3], [ItemTyp1E], [ItemTyp2E], [ItemTyp3E], [AlarmDueoBefore], [EmpSeting], [SyncPath], [vFiledA], [vFiledB], [vFiledC], [vFiledInt], [vFiledBool], [EqarAlarmContractEnd], [EqarAlarmDayPay], [EqarAcc], [tenantAcc], [AfterDotNum]) VALUES (1, 1, N'30                  ', N'                                                  ', N'', N'                                                  ', N'110100001111110010000000000000000000000000000000000000000000000000000000000000000000000             ', 1, N' ', 0, 0, 5, 0, 0, 1, 1, 0, NULL, N'', 1, 1, N'', 1, 1, 1, 1, 0, 6, N'Microsoft XPS Document Writer', N'1 ', 0, 1, 0xFFD8FFE000104A46494600010101006000600000FFDB004300080606070605080707070909080A0C140D0C0B0B0C1912130F141D1A1F1E1D1A1C1C20242E2720222C231C1C2837292C30313434341F27393D38323C2E333432FFDB0043010909090C0B0C180D0D1832211C213232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232FFC000110802AB046E03012200021101031101FFC4001F0000010501010101010100000000000000000102030405060708090A0BFFC400B5100002010303020403050504040000017D01020300041105122131410613516107227114328191A1082342B1C11552D1F02433627282090A161718191A25262728292A3435363738393A434445464748494A535455565758595A636465666768696A737475767778797A838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE1E2E3E4E5E6E7E8E9EAF1F2F3F4F5F6F7F8F9FAFFC4001F0100030101010101010101010000000000000102030405060708090A0BFFC400B51100020102040403040705040400010277000102031104052131061241510761711322328108144291A1B1C109233352F0156272D10A162434E125F11718191A262728292A35363738393A434445464748494A535455565758595A636465666768696A737475767778797A82838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE2E3E4E5E6E7E8E9EAF2F3F4F5F6F7F8F9FAFFDA000C03010002110311003F00F3EA28A2B42028A51D68A004A2968A0033451450014B45140062945252D001498A5A2800A28C514005146696800A4A5A2800A2978A4A0029734514005145140052D252D0014514B8A00434014B450018A3DA8A2800E94668A5A004A31CD2D14005252D14000A31452D0020A31462968012968A2800A28A2800A28A5A004A31452D00145252D002514B45001452E28C5002514B49400514B4500145145001451450014514B40098A2968A004A2968A00414538D2500262968A5A004A294D25001462968A004A2968A004A2968A004A3B52D14005277A5A2800A28A5A004A29692800A29692800A2968A0028A28A004A5A29714009451462800A5A28ED40051474A2800A5A4A5A004A5A28A00292968A0028A5C5140082908A5A2800A28C5140052D145001494B4500145145001451450014B494B40052D25140051451400514B8A4A003AD2D14500145145001474A28A0028A5A28032E8A534500252D14500028A5A050026297145140052D14500145068A0028A5A2800A28A5A004A2968A004A297145001452D25001462968A004A5A281CD002D14514000A28A2800A28A5A004C52D1462800A28C52E280128A5A3BD0018A28A3B50014514B40094514B40094B4514005145140051451400514B45002514B4500252D252D0014514500145068A0028C514EA004A4A5C5140051452D002014B494B4009452D1400514514005145140051452D0021A2968A004A2968A004A2968A004A314B45002518A5A28012968A2800A28A280133452D1400514B49400514B45002514B8A28012968A2800A31452D00262968A2800A28A2800A28A5A004A2968A004A2968A0005145140094A28A2800A28A2800A28A2800A28A2800A28A05001451450014B45140051452D001494B4500141A28C50019A28A2800A29692800A5A4A280168A28A00CCA334B45001451450014B8A4A5A004C52D145001452D140094B451400514B45001CD1451400514A68C5002518A75140098A2978A3B74A0028C51462800C51452D002514A29680128A294500277A28A5EF40094B8A28A0028A28A0028A28A0028A5A4A005A28A314005145140051451400514B40A004A5A3BD1400514518A0028A28A0031452D1C500262968A2800A28A280168C5028A0029296B4B4CD0EF7546FDC44420EB2370A2A2738C17349D90D26DD919B4575F17819F6E65BE4CF608A4FF003A593C0CC57315F26EFF006D0FF4AE1FED6C1DEDED11B7D5EAF638FA5AD3D4B40BED30EE963DF17691391FFD6ACCAEE8548D48F345DD18B4E2ECC4A2968AB1094B8A28A004A5A28A0028A5EF41A00293AD2D25001452D1C500252D18A2800A4A5A2800C5252E28C500262968C514005145140051450050018A314B4940051474A5A00292968A004A5A314500145145002D252D14009452F4A280131452F7A2800A28A2800A28A2800A28A2800A28A2801692968A004A2968A004A2968140094B45276A005A28A2800A28A2800A514514005145140052D251400B49451DA80168A28A003145145001451450066F3452D25002D14514005145140052D14500145145001452D140052F6A4A5140094B452D00252D252D00145145001452D140094B4514005145140076A314B450018A28A2800A28A5A004A28A5A0031C5262968A0028A28A0028A294E28012968A2800A4A5A28012968A2800ED451450018A5A3B5140077A28A5C50025145140052D2014B40098A5C5145001452D14009451DE9F1C6F348B1A025D8E001EB480D9F0E688754B86964045BC446E3FDE3E82BD0E38D228D638D42A28C051D0555D2EC174ED3E1B6503722FCE47763D4D5CAF80CE3319E26B3845FBA8F630D4142377BB0A28A2BC53A84650CACAC015618208C835C1F89B42FB04BF6AB643F657383CE761F4AEF6A1BBB58EF6D25B6940D92A95FA1EC6BD6CA7319E16B24DFBAF739F1145548F99E4BDA8C54F756CF69772DBC80878D8A9A86BF434D357478AF40C514734530129714629680131477A5A2801051452D001494B462800A28A2800E9451450014514B8A004A28A28012968EA28ED4005028A2800A2968A004A2968A00292968A0028A28A0028A28A0028A28A0028A28A0028A28A0028A5A4A0028A297BD00275A5A28A0028A28A0028A28A0028A28A0028A5A280128A5A280128A5A280128A5A2800A28A2800A28A2800EF4B45250014B494B400514514005145140052D252D006652D14500145145002D1483AD2D001452D140094B451400514514000A7628A28012968EF4500140A5CD140094B452D002518A5A4A000D2D14500145140A0028A5A280131452D1400514628A0028A28A0028A5A4A0028A514628012968A2800A28A5A004A2814B4009452D18A004A5A29680128A5A2800A28A2800A28A5C5002514B4500262968A2800A29692800AEA7C1DA679D74D7F22E521E133DDBD7F0AE6628DA59523404B3100015EA7A7D9A69F610DB463845E4FA93D6BC6CEF19F56C3B51DE5A1D585A5CF3D7645AA29A6451D58528656E841AFCF9DF73D8D05A28A2800A28A280390F1969B9F2F508D7FD897FA1AE42BD62EADA3BBB592DE51F248BB4F1D2BCBAF2D64B2BC96DA404346C54D7DEE458DF6F87E493D627918BA5C93BAD995E8A5C52D7BA7209452D14009452D140094514B40094B4514005145140094B4518A0028A28A0028A5A0D002514514005252D18A0028A5A280128A5A4A0028A5A280128A5A28012968A2800A4A5A3B500145145002514B462800A297B52500145252D001451462800A28A5A004A5A28EF400514514005145140052D252D002514B4940051451400514B4500251DE968A00290D2D18A0028A28A0028A296800A28A28012968A39A00CDA5C5145001451450014514A28001452D250014B45140051451400B8A3145140051451DE800E2973451400502968A0028A28A0028A314B40094B4514009DE968A2800A2968A004A5A3145001EF45140A0028EF45140052F6A4A2800A28C52D00252D28A280128A5A3BD00145068A00314519A5A004A2968A004A052D14005252D140051451400514629714009452F6A92185E79D228C65DD8281EF49BB6AC0E8FC23A787B87BF9946C8B84CF76FF00EB575924AEFD0E05416566B656515AA748C73EE7B9A9F15F9FE6D8BFACE25B5B2D11EB5087242DDC84A67B934DF994E5490454C453715E7266A58B7B8F33E56E187EB562B267945AC4F7054B0894BB0079C0AD1B5B98EF2D22B88B3B2550C33D47B1A27427C9ED52F74B8CD5F95EE4B45145739A05727E30D337A25FC60EF1F24807A7635D654571025CDBC904A32922ED22BD1CAF18F0B8853E8F731C453F69068F27E68AB17D68F657B2DBC83E646C557AFD222D495D1E27512968A298828A28A0028A28A0028A28C5001451477A002968A280128A5ED45001494B4500145145001452D140094528A2801297140A280128A5A280128A5A4A0028A5A28010514B45002528EB477A2800A28A2800A2968A004A28EF4B4009452D277A003BD14B4940051451400514B49400514A68A004A5A28A0028A29450025145140051451400528A4A2800A0D2D250014B494B40094B4514005145140094B4514019D451450014514B40051474A31400B498A5A2800EF4BDA8145002734B451400A05252D140051452F1400514514005145140052D145001451450014514B4005141A2800A28A2800A5A28A004A2971450018A28A2800A29714940052F6A28A0028A28A00051451DE800A29693140076A5A28A0028A3140A0028A29680128EF4B4500145145001452D140095D3784F4E2F335F38F963F963E33F37FF005AB9E8217B89D22452CCC71815E9565689656915BA63083048EE7B9AF1F3AC67D5F0EE2B791D386A5CF3BBD91350452E293A57C15CF54434D229FF008535D9234679085450598FB55C22E72518EEC97A2B9CF789EFFECF682CD0FEF26F99FD97D3F1A3C1BA96E5934F91B91F3C5FD45733A8DE35FDFCB70DD19BE51E83B0A8ED2E5ECEEE2B88C90D1B06AFBD596C3EA5F567DBF13CBF6CD55E73D5E8A86D6E63BCB58EE2220A48BB863B7B54D5F9F55A72A537096E8F662D495D051451598CE53C63A7EE8E3BE40772FC921ED8ED5C7015EAF736E9756EF0C801571839EDEF5E617B6AF657725BC808646239EE3D6BEF722C67B7C3FB37BC4F27174B92775B32BE2929DC521AF70E46252D145310628A28A0028A28A00292968A0028A5C514009452D14009452E28A004A5A28A003BD145140077A28A2800A29692800A28A2800A28A2800A28A5A004A314B450018A28A2800A28A5C5002518A5C51400945145001494B45002514B498A002968A2800A28A2800A28C5140051452D002514518A0028A5A2800A28A28012979A28A004A5C51450014514500145140A0028A28A0028A296803368A5A3340050052D140094BD28A0D002D140A2800A29692800A5A4A5A0028A2968012968A2800A28C518A000528A28A0028A2968012968A3BD001451450014514B4009452D140076A28A28017BD14514005145140051451400514B4500262968A280128A5A2800A28A5A004A28A5A004A5A28A0031452D140094514B8A0029314B45002E2929714F8217B89D218C65DD8281EE693692BB03A5F0869E1E592FA45044676C7FEF773F9575F51595925859456B1F48C727D4F7353D7E779B633EB3886D6CB447B587A5C905DC662929D8A4C579A6C348AE77C57A8186D52C9090F2FCCFFEEF615D0CB22C313CB21C2202CC7D00AF35BFBB6BEBE9AE5FABB67F0ED5F47C3F83F6951D796D1DBD4E2C654E58F22EA56A28A5AFB43CC3AEF076A4487D3DC9E32F17F515D75794DADC3DA5D473A7DE8D830AF50B4B94BBB58EE23394917238FD2BE3388B05C935888AD1EE7A782AB75C8FA13514515F307785727E31D377247A846BC8C24B8FD0D759515C411DD5BC904A32922ED35E8E578B785C429F47A331C452F6906BA9E52283562F2D1EC6F25B6907CD1B63EB55CD7E8F169ABA3C47D828C1F4A29C0D3B80DC514A692801A73D8D28CD2D14C4252D1450014514500145145001451450014514B4009452D140094B4514005252D277A005A28A2800A28A2800A29714500252E28C5285A004C518A7E38A4240A004C5071499CD2500293E94945140051451400514514005145140051452E280128A5A28012968A2800A28A2800A28A2800A28A2800A2969280168A28A004A29692800A28A2800A29692800A28A2800A0506814019F4514B40094B494EA004A2968C50018A2814B40094BDE8A5C50025145140052D252D001476A052D0020A5A4A5A0028A28A005A28A2800A28A2800A5A28A0028A314A280128A5A4A002968A2800A3A52D140094B451400514514005145140052D252D00252D140A0028A31462800E9477A296800A28A2800A29714500251452E28012968A2800AEB7C1FA6E5DF5091785F963CF73DCD72F6F03DCDC470A0CB3B0515EA1656A9676715BA001635C71DCF735E26798CFABE1F962F591D585A5CF3BBD913E29314EA2BE00F606629A45498CD453CA96F0492BE36A2963CD694E12A93508EEC993495D9CD78B35111C09651B7CF27CD260F41D8571DF8559BFBB7BEBD96E1C925D8919EC3B0AAD5FA5E0B0D1C3518D34787566E727261452D15D66602BADF07EA3CBD848DD7E78F27F302B92A9AD6E1ED2EA39E324321C8C57362F0F1C4D195297534A737092923D568A86D6E52EED63B88CFCB22EEFA7A8A9ABF32AB4A54A6E12DD1EEC64A4AE828A28ACC6731E2ED38CB025F46BF327CB263B8EC6B8CAF569A149E078A419475DAC2BCCAFECDEC6F65B77EA871F515F7990E37DBD0F672DE3F91E4E2E9724EEB6656A55FBD49457BA720AD4DA5CE692840C5C5252D277A620A2968A00292968A004A5A4C518A005A28A2800A28A2800A28A2800A28A2800A28A2800A28A5C50014628A5E6801314EDB4A052EEC5002014120534B1A4CD002924D36968A00293AD2D1400514514005252D140051494B4005145140094B451400514518A0028A3145002D2514500068A28A002968A2800A28A2800A28A3A500145145002514B4500141E945140094B45250014B4514019F4514B8A0028A39A39A002814A05250014A28C52F6A004A2968A000514514000A28A5ED40082969052D0014514B40094B4628A0028A296800A28A2800A0D2D140094B4502800A28A2800A5A4E696800A28A2800A29692800A51494B400514628A004A5A28A002968A2800A297145001494B4500145145001DE8A28A0028A28A0028A2A6B6B77BAB88E08D4B3BB0000A4DA4AEC7B9D3783F4EDCEF7F22F03E58FEBDCD7635059DB259DAC56F18F9635DB9C6327B9A9EBF39CDB18F1588725B2D11ED61E97B385BA8514515E61B8572BE30D48C7125847D641BE439EDD8574B713A5ADBC93CA7091A9635E61797725EDDC97129CB3B13F4AFA6E1DC173D478892D16DEA70E36AD9722EA57A514515F68796145145002D1451401D6F83F51FF00596121FF006A3FAF715D6D795DADCBDA5D473C670D1B0615E9D69729796915CC646D9173F43DC57C6F1160B966B1115A3DCF4F0556EB9193514515F2E778572FE2FD3C4902DF20F9930AFF004ED5D454573025CDBBC520055C1072335E86578B785C4467D366635E9FB483479551566F6D5ECAF2481C1CA311923A8F5AAD5FA426A4AE8F13662514B8A2A84145145001451450014514500145145001451450014514B40094B477A28012968A2800A28C51400629714B8A5E05002629781499A4A000934945140051451400514514005145140051452E280128A5A4A0028A28A0028A314B40094114B482800A2968A0028A28A0028A28A0028A28A0028A28A0028A28A0028EF451400514B4940076A28A2800A28A2800A28ED40A0028A28A00A145145002D145140051477A514005145140051452D001494BDE8340094B451400514528A0028A28A002968A2800A28A2800A5A3A514005145140051452D001451450014518A534009452D140094B4502800A2968FC28012968A2800A31452D00251DE968A0028A28A0028A29680128A314B40094751452D002518A5A2800AEB3C21A682CF7F22838F963C8E73DC8AE66D6DA4BBBA8EDE219791828AF50B4B64B3B58ADE31848D768E7F335E1E7B8DFABE1F923BC8EBC252E79DDEC89A8A28AF813D70A28A8AE6E23B4B692E2538489771ABA54E5526A11DD8A4D455D9CD78C752DB1C7A7467E6387971FA0AE3AA7BCB97BDBC96E246DCEEC4935057E9B82C3470D42349743C2AB3739B930A51495A3A568D73AACB888058D7EF48DD056F39C611729BB24424DBB233E8C57751783F4E5502492776F5520034EFF84474BF5B8FFBEC7F85792F3DC1276E63A3EA957B1C1D15DD1F096963BDCFFDF63FC290F8534B1FF3F3FF007D8FF0A3FB7707FCC1F54ABD8E16BADF07EA277496123707E78FD8F7156CF85B4BFF00A79FFBEC7F853A1D02C2D2E127885C6F8D830F9C7515CF8BCD30389A32A4DEE553A1561252B1D0D14D47122EE0319ED4EAF877A33D75B051451480E57C5DA76E8D2F900CAFCB27A91D8D7219AF559A04B985E093EE48A55BF1AF2FBB80DB5E4D011831B95AFBCC8719EDF0FECE5BC7F23C8C5D2E49DD6CC868A28AF78E40A28A5C500251452E280128A5A4A0028A28A002968A0D0014518A2800A2834B8A004A053B1474A00314519A43400A4D3734B494005145140051451DA800A5A4A39A0028A283400514B49400514B450014514500145145001451450014514500145145001494BE94500145145002F5A4A5A4EF400628A5A4A0028A28A0028A5A4A005A28A280128A5A280128A296800A4A5C525001451450051A4A296800A28A2800A5A28A0028A3B5140052D145001451450014B494B400514514005140A5A00293BD2D140052D14500145145001DA8A29680014514B40094A68A2800A28A2800A28A5A004A2968A0028A28A005EF4514500252D145001451450014514B4005145140051452D00252F6A28A004A296AC58D9C97D791DBC432CC403EC3B9A52928ABB1ADCE9FC1DA6ED57D4641C9CA459FD4D75951DBC11DB5BC70443091A855FF001A92BF37CD318F158873E8B63DBA14BD9C120A28A2BCE360AE53C61A88091D821049F9E4F51E82BA4BCBA8ECAD64B8908DB18CF3DCF615E637570F777524F2125A462C6BE9F87705CF378896CB63831B56CB917521A5A4A5AFB33CC25B681AE6EA2857EF48C147E35E9D67691D95AA5BC606D51D4773DCD701E1CC7FC241640F4F33FA1AF46AF93E25AF35C9496CF53D1C0C13BC828A28AF913D1186A3352B5466A909919A635487AD31AAD19B1D6A7965F4E6AD555B61FBD3F4AB5513DCB86C14514549415E7BE2740BE20B9C7F1104FD702BD0B201C9200EE4D799EAF75F6CD5AE67ECCE71F41C57D4F0CC25CF39F43831CD59228D14B457D89E6094B451400514514005145140051477A5A004A2968A0028A5A2800A28A2800A33494500145145002514B45001451450014514500145145001451450014514A280128C52D140094514B400945145001451450014514B4009452D1400514514005252D14009477A5C514005145250014B451400514525002F6A28A28001494B45001474A28A00292968A0029296928028F5A314B4500145145001451450014B4514005145140052D252D0014514500140A5A2800A28A5A004A5A28A0028A31450014B46292800A51451400B4514500145028A0028A318A2801692968A002968C5140094BDE8A2800A3B51450014514B400940A28C5002D148696800A2968A003145145001DE8A28A002BB3F08E9BE542D7EE3E793E58FD87735CAD85A3DF5EC56E8325DB9FA77AF4E8214B7823863FBB1A855FA0AF073EC67B0A1ECE2F597E4766129734F99EC8928A28AF833D60A28A86EEE52D2D64B890E16319E9DFB0AD29529559A847764CA4A2AECE5FC61A81CC7608C71F7E400F07D0572752DCDC3DDDCC93C872EEC58D455FA660F0D1C3518D28F43C3A937393930A28A2BA8CC9AD6736B790CEB9CC6E1B8AF4EB5BA8EEEDD2784E51C647B7B5795D6AE8FAE4FA4B900092063F3464FF2AF2336CB7EBB4FDDF896C74E1ABFB296BB33D168AC6B6F13E973A92F2BC2C3B3AFF5A9FF00B7F4AFF9FD5FC8D7C6CB2AC645D9D367A6B1149EB7341AA33548EBFA57FCFE2FE469A75DD2CFFCBE27E4692CB317FF003ED83AF4FB970F5A63554FEDAD2CF5BD41F81A72EB7A4839378A4FFBA6ABFB3716BFE5DB27DB53EE68411ED52C7A9A96B37FB7F4AFF9FC5FC8D2FF006FE95FF3F8BF91A8796E31EBECD94ABD25D4D1A2B267F12E950AE7ED0F213D04699AC6D43C5EEE852C632991CC8FD7F0AE9C3E498BAD2B4A3CABBB2278AA715A3B97BC4DAC25A5BB59C4C1AE24187C1E107F8D70FDE9CEED23B3B92CCC7249EE692BEDB0583861292A70F99E555A8EA4B9989452D15D8662518A5A2800A28A2800A28A2800A2968C5001452D26680014668EF4500252D145002514B45002514B4500252E28A2800A4EF4B450014514500145145002528A05140051451400514514005252D1400628A29280168A28A003BD1451400514518A0028A28A0028A28EF40075A28A2800A28A2800A28A2800A05145001451450014514500145149400B41A29280169296928028D2D1DA8EF4005145140052D14500145145001452D140051451400514B4500252D140A0028A314B4005140A2800A28A5A0028C5145002D1498A5C734000A29692801452514B400518A28A002968A2800CD14514005145140051452D00276A5A28A002968C514009452D25002D1DA8A2800A28A2800A28AB5A7D9BDF5EC56F18E5CF2719C0F5A9949455D8D2B9D5784B4DF2ADDEF24521E4F95323B7AD74F51C112C30AC718011405007A5495F9BE678B78AC44A7D3A1EDD0A7ECE090514515E79B05721E2FD40974B0423E5F9E4C1EFD857537774967692DCC87E58D738F53D85798DCDC3DD5CC93C849776C926BEA787305CD278892D16C70636AD972221A28A515F627982514E5566385049F402A5FB25CE7FE3DE5FFBE0D4B925BB1D9905153FD8EE7FE7DE5FFBE0D1F64B9FF9F797FEF834B9E3DC2CC8692A7FB25CFF00CFBCBFF7C1A3EC773FF3EF2FFDF068E78F70B320ED4B537D92E7FE7DE5FF00BE0D1F63B9FF009F797FEF83473C7B85990D1537D92E7FE7DE5FFBE0D1F63B9FF9F797FEF83473C7B85990D1537D8EE7FE7DE5FF00BE0D2FD92E7FE7DE5FFBE0D1CF1EE16643454DF64B9FF9F797FEF8347D92E7FE7DE5FF00BE0D1CF1EE166418A5A9BEC973FF003EF2FF00DF068FB25CFF00CFBCBFF7C1A39E3DC2CC868A91E1963E5E275FAA914CAA4D3D842514B45300A28A2800A5A4A5A004A5A434500068A28A0028A28A0028A28A0028A28EF40051451400514B45002628A5A4A0028C514B400945145001452D14009452D1400945145001452D250014B8A28ED4009452D2D0037BD14B45002514A68A004A2968A004A5A4C52D00251451400518A28A0028A28C5001452D14009451450014B49D68A0028A28E9400514514005252D1401468A28A0028A5A2800A28A2800A28A5A0028A28A0028A2968012968A280168A4A5A000D145140052D14500140A28C5000297BD028A0028A281400514B4B4009476A29680128A5A31400514514005145140052D14500145145001452D140051494B4005145140051452D002514B450015D9F8474DF2AD9AF9C7CF2E5539E8BDEB97D36C5F50BF8ADD013B9BE6C761DCD7A6C71AC51A4718C2200AA3D857CFE7F8DF6347D947797E47660E9734B99EC87514515F0A7AC1451505E5DC763692DCC846D41900F73D85694694AACD538EEC52928ABB397F186A3B9D2C233C2FCD2F1DFB0AE52A5B899EE6E2499CE59D8B1A8EBF4DC261E387A31A51E8785526E72726157F49D2E5D52EBCB4F9635E5DFD0550AF41F0D598B5D1A16E0B4DFBC3FD2B9F34C67D530EEA2DFA174297B49D9976CF4DB5B0844704417D58F2C4FD696EDA4575224603D8D5AA8E78FCC8C81D4722BF3F962AB549F34E4D9EBFB38A8D922889653FF2D5FF003A904927FCF57FFBEAA200827229E2A9D49F733B21E2493FE7A3FE74EDEFFF003D1FF3A8FD29F52EA4FB8F950E0EFF00DF6FCE943BFF007DBF3A68EB4B4BDA4FB8D242991C7F1B7E74BE63FF007DBF3A61E94B4BDA4FB8F950FF00324FF9E8DF9D2F98FF00DF6FCE994BDA97B49F71F2A1E247FEFB7E74BE63FF007DBF3A652D1ED27DC7CA87877FEFB7E74077FEFB7E74D14A3B52F693EE3E542488B2A9122875230430C8AE535FF0F241135DD92108BCC91E7381EA3DABAEA4650EA55802A7820F715DF80CCEB61AA277BC7AA32AD42338EDA9E57466AF6AF67F60D56E2DB39D847EA01FEB546BF438494E2A4B6678AD59D98514B455884A5A28A00292968A0028A28A0028A2968013BD145140094B45140094B4B494005145140051452D002514B49400628A5A4A0028A5A4A0028A5A4A0028A5A280128A29680128A5A4A0028A5A280128A5A4A002971494500145145001452D25001451450014514500145145001486968A0028A28EF40094529EB450025145140051451400628A28A00A34B4514005252D140052D1DE8A0028A28A0028A5A2800A28A08A002971494B400628A2968012968A2800A28A2800A5A4A5A0028A28A005A4A5A280168A28A0028A28A0028A28A0028A28A002968A2800A28A280171494B41A0028A28A0028A2968012968C514005145140051466AE69764DA86A30DB83C337CC7D077A9949462E4F6434AEEC8EABC25A6F9168D7B20F9E6E1323A2FAFE35D253511228D638C61100551E8053ABF35CC716F1588753A743DCA34FD9C120A28A2B84D42B8EF176A45E54B18D8ED5F9A4C1E09F4FC2BA6D4AF534FB192E1FF0084600CF527A579ACD2BCF33CAE72EE4B13EA6BEAB8770376F1325B6C79F8DAB65C888E814515F6079A15E8FA0CC9368969B4FDC4D8DF515E735BDE1AD616C276B79DB16F21C83FDD6F5AF2738C24B1386718EEB53A30D51539DD9DD5148082A181054F420E41A5AFCF651717667B29A7AA219A0127CCBC37F3AAC415382306AFD232AB0C119A6A4D68C4E3728D3EA56B71FC26986365ED5574C8716841D6969075A01A0101E94B487A52D031452F6A414BDAA462D2D252D03169476A4145218FED4A3AFE34958DAF6B09A75BB431BFFA538C003F807A9AE9C1E12A626AA8411152A2846ECE5FC4370975AF5D4D19CAB1503F0503FA565D29249249C93457E994E0A9C141743C393BBB877A28A5AB244A28A5C500252E28A28012971451400514514000A28A2800A28A2800C5252D140094BDA8A2800A28A2800A3B5145001451450019A28A2800A28A2800A28C514005145140052514B4005145140051451400514514001A28A2800A0D145002514B450014521A33400B494B45002514B4940051DE8A2800A28A2800A29314B4009452D25002D262968A00A3451450014A29296800A28A2800A052D14007340A5ED4940052D140140051452D0014514500149DE9DDA92800A5A28A002814BD28A0043452D2D00252D14500145145001451450002968A2800A28A514009452D140051451400514629680128C52D140074A28A2800EF451462800A28A2800AEDBC25A6FD9ECDAF2452249B84C8FE1AE574AB16D47518ADD7EEB1CB1F41DEBD3111638D51142A280A00F4AF9EE20C6FB1A3EC63BCBF23B7074B9A5CCF643A8A28AF863D50A28AA7A9DF2E9F6125C3632A3080F76ED5B61E8CAB5554E3BB2672518B93396F176A1E75DA5921F921E5BFDE35CDD3A491A591A47396639269B5FA6E1A8468528D38F4478539B9C9C98515345677338CC56F2B8F55426A4FECCD43FE7CAE3FEFD37F8568E715D49B32AD156FFB32FF00FE7CAE3FEFD37F851FD997FF00F3E571FF007E9BFC28F691EE3B325B0D6AFF004EE2DE73B33F71B91F95698F196A1FF3CA0FFBE6B1FF00B32FFF00E7CAE3FEFD37F851FD997FFF003E571FF7E9BFC2B9EA50C2D4779C537F2294E6B44D9B1FF0996A1FF3CA1FFBE68FF84CB50FF9E50FFDF358FF00D997FF00F3E571FF007EDBFC28FECCBFFF009F3B8FFBF4DFE159FD4F07FC91FC07ED2AF766C7FC265A87FCF283FEF9A3FE132D43FE7943FF007CD63FF665F7FCF95C7FDFB6FF000A3FB32FFF00E7CEE3FEFD37F851F53C1FF2443DA55EECD83E31BFEF141FF7CD27FC25F7DFF3C60FFBE6B23FB32FFF00E7CAE3FEFD9FF0AACCA558AB0208E08354B05847B417DC1ED6A7766FFF00C25B7BFF003C60FF00BE68FF0084BAF7FE78C1FF007CD73F498AAFA861BF917DC2F6B3EE743FF0975EFF00CF283FEF9A5FF84BEF7FE78C1FF7CD73B4A28FA861BF917DC1ED67DCE87FE12FBEFF009E307FDF34BFF097DF7FCF183FEF9AE7A8A5F50C37F22FB83DACFB9D0FFC25F7DFF3CA1FFBE68FF84BEFBFE7943FF7CD73D451F50C37F22FB83DAD4EE6DDCF8A7529D7623AC2B8C1F2C609FC6B19999D8B3B1663D4939269296B7A7469D2568452265272DD876A3B526696B5243145252D00145145001452D14009452D18A004A28A5A004A2968A004A5A28A004A2968A0028A4A5A004A5A38A2800A4C52D140098A294D1400514514009462968A0028A28A0028A28A002928A5A004A28A2800A29692800A29692800A2971450025141A5A004A28A2800A28A2800A28EF477A00292968A004A29692800A5A28A004A28A2800A28A2800A28A4A00A74514500145140A005A334518A0028A5E28A0028A28A002968A2800A28A2800A28A5A0028A28A0028EB4B450014514A28012968A2800A283450014B451400514514005145140052D1450014518A2801692968A0028A28A0028A28A0028A5A2800A28A2800A4A5A43480EDFC25A7FD9EC9AEDC0DF370BCF45FF00F5D74754B480A347B2DBFF003C133F5C73576BF37CDAB4AAE2E6E5D343DCC3C5469AB0514515E71B05715E2DD43CEBB5B243F243CB63BB1AEA754BE1A769F2DC1EAA3083D58F4AF3591DA591A4639662493EF5F59C3982DF1125E48F3B1B576821B8AEBBC3DE1D4F2D6F6F532C798E23E9EA7FC2B9DD2ED96EF54B78181D8EE0363D2BD3000071D0703E95DD9EE613C35354E9BB39196128A9C9B96C8146C50AA02A8E800C0A327D4D1457C3CA7293BB67AA925A24193EA68C9F534514B998EC193EA68C9F534514733EE160C9F53464FA9A28A399F70B064FA9A327D4D1451CCFB8585C9F535E7DE27B616DAE4C17A380FF009D7A0570BE306075CC0FE18941FD4FF5AFA4E1A9CBDBCA3D2C70E392E44CC1A28A2BED4F2C5A29B45003A8CD2519A005A29334B9A005A5A4A280168A28A0028A0D25002D1494B40052D252D0014514500149DE968A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028EF4B8A4A0028A28A0028A28A0028A28A0028A28A00292968A000D145140051451400514514009452D1F85002514B450025145140051451400514514009452D14005252D1400945145001452D140146968C52E2801B4A2968C5001452D18A004EF466968C5002628A5A2800A2968C7340094B4B8A31400940A5A5A004A3BD2D14005252D18A00281452D002514B45001DA814B4500252D1450018A314518A0028A5A2800A28A2800A28A5C5002514B4500252D14500145145001452D250014B4514009DA834B462803B7F0AEA4971602D18812C3D07765FFEB57435E5D6B732D9CEB342E55D7D2BADB3F175ABA28BB478DFB941907F0AF92CDF25A952A3AD415EFBA3D1C362A2A3CB33A4A2B1CF8A748C713CBFF7E8D63EA7E2C334462B143186E19DBAFE15E561B24C5559DA51E55E6744F154E2AE9DCAFE2AD496EAF16DA270D1439048EEDDEB9FA53C9CD15F79428C685354E3B23C89C9CE4E4CBFA24C2DF5AB576202F98013EC6BD23A71E95E50090723B577FA16B29A8DB247232ADD28C15FEF0F515E0710E0E75611AB057E53B3055545B8BEA6C514515F147A814514500145145001451450014514C92548A33248EAAA3A9278AB85394E5CB1576C4DA4AEC592458A367720228CB13E95E65A8DDBDF6A135C37F1B1207A0EC2B63C45E20FB766D2D0916E0FCCFDDCFF008573A057DDE49974B0B4F9EA7C523C9C557552565B2170697140A2BDC3904A4A71A6D001452D140051C514B40052D20A5A005A28A3140084D14528A0028A28A002979A414B9A0028A29680128A5A4A0028A5A280128A5EF4940051452D002514A68A004A5ED4514009452D140094B45140094B451400514503A500252F14514005252F6A280128A28A0028A28C5001451450014628A2800A2968A004A28A2800A28A2800C5252D14005145250019A28A5A004A297AD25001C51476A2800A28A2800A28A2800A28A2802951452D0014514500140A5145001452D140094514B40051451400B9A4A51450014514B400514514005145140052D252D0014514B40094B476A05001451450014514B400514514005145140052D145001451450014514B4005145140051451400A28EF45140052E2814B40098A0D2D06801B451462800A28A2800A723BC4EAE8C5594E41079149477A406D41E28D46188465C498E85C026A5FF84B2FFF00BB1FFDF23FC2B07BD15CD2C161A4EEE0BEE345566B4B9BBFF0965FFA47FF007C8FF0A3FE12DBFF00EEC7FF007C8FF0AC2A4353F50C2FFCFB5F720F6D53B9BA7C5DA87A47FF007C8FF0A3FE12EBFF0048FF00EF91FE15806928FA8617FE7DAFB907B6A9DCE83FE12EBFFEEC7FF7C8FF000A3FE12ED43FBB1FFDF23FC2B9FC5147D430BFF3ED7DC83DB54EE6F9F176A3B485F2D58F43B471FA5655DEA3797C73713BB8CE402781F8556A39AD69E1A8D377A71484E7296EC4E69D4515B902D2D1450034D253A8C5002628C52E2971400DA7628C518A004C52D2D140094B4514009452D2500145145002D251450002969296801692968A0028A28A0028A28EF40051451400518A28A0028A28EF40051451400514514005145140051451400514514005145140094B4514009DE9714514009452D14009451450014514500145145001451450014514500149CD2D19A0028A28A00292968A004A29692800A28A2800A28A2800A28A334014F14514B40094B4514000A5A00A2800A28A2800A2968A004A5A28A0028A296800A28A2800A28C52D00252D14500145145001452D14005145140052D145001451450014514B4000A3BD145001451450018A5A28A0028A28A0028A5A4A005A28A2800A2814B40052D252D00145145002514BDE908A0028C52D1400DA5A296800A28A2800A4A5A2801A7AD2529A3140094B452D002628A5C52D0020A5A28C50014114629714009DA81411462800A28A28016929692800A5A4A5A0028A2814005253A8C500368A52293F1A0028A5A280129694518A0028A5A4C5001451450014514500145145001451450014514500141A28A0028A5A4A0028A5A4A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A004A0D2D14009452D18A004A28A5A004A28A2800A28A2800A28A28012968A5ED400DA2968A004A29693B50014B494B4014E8A28A005A28A2800A28A5A004A5A28A0028A2968012968A2800A28A2800A28A5A004A5A28A0028A28A002969296800A28A2800C528A28A005A4A29D1C6D2CA91A637310A32C00CFD4F02801B456DFFC221AEFFCF8FF00E468FF00F8AA5FF84435DFF9F1FF00C8D1FF00F154AE33128ADA3E12D715493627819E2543FD6B2EEACEE2CA5F2AE609227EB875C668021A2AE69FA55E6A8EE967109190658798AA71EB82466B43FE111D77FE7C7FF22A7FF15401874B5B7FF088EBBFF3E3FF009153FF008AA8E6F0B6B50A6F7B0723FD86573F9024D1703228A732B2315652AC0E0823041A4A62129715AB63E1BD57504F322B52B19E43C87683F4CF26B48F813550A489AD0903A076C9FF00C7695C76397A5AD1D4342D4B4C1BEE6D9847FF003D14EE5FCC74FC6B3A81051452D300A2AFE9FA26A1AA736B6ECC8382E7E55FCCF5FC2B617C0BAA1504CD68091D0BB71FF8ED2B8CE668ADABAF0A6B16A0B7D9BCD51DE16DDFA75FD2B19959090CA411C10474A004A28AD5B2F0DEAB7F1F9915B158C8C8790ED07E99E4D0232A8AE98F817540A489AD0903A076C9FF00C76B2B50D0B51D3177DCDB308FFE7A29DCBF98E9F8D17199DC5145685868B7FA9C6D259C02555386FDE2820FD09CD0233E8ADAFF00844B5BFF009F2FFC8A9FFC551FF0896B9FF3E5FF009153FC68B8CC5A2B6BFE112D73FE7CBFF22A7F8D3BFE117BF91A74B6026920904722E42E3E5073927DF145C0C3A0D6D7FC225AE7FCF97FE454FF001A3FE112D6FF00E7CBFF0022A7F8D17031296B6BFE112D73FE7C7FF22A7F8D52D4B4C9F4996186E7025922F30A020EDF988C6475E99FC68029628E28A920B79AEA6586089E591BA2A0C9A62194715D141E0AD5A55CBF9109F4924E7FF1D06926F056AF12E504137B2498FF00D080A5743B1CF5153DD58DD5949E5DCDBC9131E9BD719FA7AD57A62168AB367A7DDEA12797696EF2B0EB81C0FA9E82B6E2F046AAEB967B68CFA339CFE80D2B8CE6CD256F5D784357B65661124EA3FE79364FE4706B0DD191CABA956070411820D00368A9AD6DA5BCB8482050D239C282C1727EA78AD293C2DACC48D2496811146599A68C003FEFAA00C7A28A2988297BD3E0824B99D218803239C282C1413F53C56AB78535A452ED6615546493347803FEFAA433228A08C1C7A5280598018E4E3938A62128AD81E15D64AEE1660A919CF9C98C7FDF551DA6817D7F048F6A8B2BC5298DD03AF1C75073823E94AE332E8C56D7FC227ADFFCF97FE454FF001A3FE114D6FF00E7CBFF0022A7F8D17031714B5B3FF089EB7FF3E5FF009153FC6AB5EE9173A7DCDBDB4DB44F3206DA5800A4B100139C76EBEF45C0CFC52E2B67FE115D6B19367C7FD754FF001AC86528EC87195241C1047E63834086F145490C324F2AC70C6D23B74541926B720F076AD380592287233FBC7FF0CD0339EA4AE8E6F05EAB1AE53C894FA24983FF008F01587736B3D9CC62B985E271D98628020A29719AD84F0B6B0E81D2D032B0C82268C823FEFAA046352D4F79673D85C182E5024A00254306C7E44D57A602D15A163A26A1A942D2DA402545383FBC5041FA139A86FF004CBBD31D52EE358DD8642EF5638FC09C5202AD2558B4B2B9BF98456B0BCAFE8A3A7D4F6ADC8BC13AAC89966B68CFF75DCE7F406819CDD2D6FDC783B5780128914D819FDDBFF8E2B167B69ED6531CF0C9138EA1D48340115252D21A620A5A4A5A0029075A28A005A4CD2D2500141A3B51400514519A0028A28A0028A28A0028A28A00292968A004A5A28A0028A4A5E94005252D14005149450014B494B400945145001451450014514500277A28A2801690D14B8A00A74514B4000A5A28A004C52D1450014514B40094B451400514514005145140075A5A28A0033450296800C5145140051EF45140051452D001451450014514B401EC7E698749F35402C906E19E990B5C2FFC27BAA7FCFBD9FF00DF0DFF00C55776B179FA5AC59DBE643B738CE32B8AE47FE15EFF00D453FF0025FF00FB2A856EA532BDBF8F6F44CBF69B5B768B3F379618363DB24D755AFD843AA68930201658CC913E39040CF1F5E95876FE00863995A7BF69630725162DB9FC726B57C4DABC1A6E952C21D7ED12A148E31D403C67D80147A07A9C97823FE4611FF5C5BFA5755E28D6EE74482DDED922732B153E6027A0F622B95F047FC8C03FEB937F4AEC7C41A17F6EC30C7F69F23CA62D9D9BB39FC4537B82D8E53FE13CD53FE7859FFDF0DFFC556B787FC5D3EA7A8AD95DC112B480EC78B20640CE0824FA1AADFF000AFBFEA29FF92FFF00D9569E89E128348BC176F72D3CAA084F93685C8C138C9E7AFE74681A99FE3BD3E210DBEA08A1642FE53903EF0C1209FA60D55F06E831DD13A8DD2068D1B6C487A123A93F4A93C6FABC13AC3A7C0E24647DF2153900E0803EBC9AE9BC3D12C5E1FB1551C18837E2793FCE8E81D4CCF11F8A869521B4B44592E71962DF7533D38EE6B985F18EB6B2EF3728CB9CEC312E3F419FD6B26FA66B8D42E26724B3C8CC73F5AAF4D215CF4DD03C4316B913C1346A972ABF3C7D55C77233FCAB94F166869A55DA4F6CB8B69F385FEE3771F4F4FC6A9F86E6687C4564CA7EF49B4FD08C7F5AED7C671ABF872562398DD187D738FEB4B663E879AD4F6908B9BDB7809C09645427D3271505391991D5D490CA4107D0D5127AAEA7771E83A234B6F002B1055441C0193819AE15FC5FAD3B122E9501FE1589703F306BA4D3FC61A75EDA887525114846D7DC9BA37FF0FC69E2D3C257ADC1B3CE7A094C6493ED9151EA5197A778E67491535085648C9E648C6187E1D0FE9543C5BABAEA5A8AC303EEB780601078663D4FF4AE8A7F0569573197B59658B392A55B7AFEBD7F3AE2F55D2AE348BC36F7001E372BAF461EA29AB0B53A0F076851DD13A8DD2068D1B6C487A123A93F4AD6F1178A469721B4B44592E71962DF7533D3EA6B4FC3F1AC5E1FB155030620DF89E4FF003AF30BE99EE2FEE25724B3C8CC73F5A37633557C61AD2C9BCDCAB2E7EE18971FA0CFEB5D7E81E218B5C89E09A354B955F9E3EAAE3B919FE55E675A9E1B95A1F10D9329FBD26D3F43C1FE743424CBBE2BD0D34BBB49EDC62DA7CE17FB8DDC7D3D2AF7807FE3EEF7FDC5FE66B6FC65187F0ECAC7AC6E8C3EB9C7F5AC5F017FC7DDEFFD735FE668E83EA69F89BC4577A35D4115B47032C8858F98A49CE7D88AC3FF0084EF54FF009E167FF7C37FF155D5EAFE1DB4D6668E5B9927568D768F2D8018CFB8359FFF00082699FF003DEEFF00EFB5FF00E269681A98BFF09D6A9FF3C2CFFEF86FFE2A9A9E2E96D65BA96D604DF712891BCD048036818183EB9AA7E26D3E0D33528ED6DC1D8B08393D5892793EF58B556423AB87C71A9C93C6860B4C3300708DDCFF00BD5DA6A772F67A65CDCC614BC519650DD32077AF26B51FE970FF00BE3F9D7A9EBBFF00201BEFFAE2DFCA9343471DFF0009D6A9FF003C2CFF00EF86FF00E2AB275AD59B59B882E248C248B08470BF772198F1F81159F8A4A7615C4AF44F0559450E8DF6A0A0CB3B1DCDDF00E00FD335E795D2786BC4CBA4C6D6B748CD6E4EE5641CA1EFC77143044DABF8C35117F3436856DE389CA0CA0663838E73556DBC69AB42F995E3B85EE1D00FFD0715D2CB75E15D4E4F3267B4677CE59C1427EA78FD6907863C3D7ABFE8A4743CC13EEFC79269683296A7E2D86EBC3CDF660D1DCCC4C4509C9418E4E7D30700D72BA469CFAAEA515A21DA18E5DBFBAA3A9AD6D7BC2726970B5D5B4A66B607E6047CC9F5F51EF573C051A9BABD9481B951547D0939FE428E9A08E96E67B1F0D6900AA6D8D3E5441D5DBFC7D4D71773E32D5E690B43224099E1110371EE581ABFE3D95CDE5A4393B0465B1EE4E3FA57238A1206CEC347F1ACDE7A43A98431B1C79CA3057DC8E98FA56B789F428B52B37BB8500BA8977023FE5A01D8FF004AF39AF54F0F4AD3787EC9DCE5BCB0BF971FD287A0D6A798D8FF00C842DBFEBAAFF315E99E24FF009176F7FDCFEA2BCF7CA587C43E528F952EF68FA07AF42F127FC8BB7BFEE7F514304796518A5A2A891F07FAF8FF00DE1FCEBD535DFF00900DF7FD716FE55E590FFAF8FF00DE1FCEBD4F5DFF00900DF7FD716FE552CA4794514515449EA969FF0022B41FF5E4BFFA0570BA4F8866D1AC9E2B68A36924937132024018ED8239AEE6D3FE45683FEBC97FF40AF2CA94533AA87C6DA9493C6860B4C3300708DEBFEF5767A95CBD9E9B73731852F146594374C81DEBCA2DBFE3EE1FFAE83F9D7A8EB9FF00202BEFFAE2DFCA86811C87FC271A9FFCF0B4FF00BE1BFF008AACBD67556D62E21B8910248B10470BF772198F1F81159B453B08F5997FE408FF00F5EE7FF41AF2844323AA28CB31C01EA6BD5E5FF9023FFD7B9FFD06BCEFC391ACBE21B356C603EEFC40247F2A486CEE748D2ADB41D399E42A24D9BA794FB0C91F415CCEA5E34BB96665B00B0C40E158A8663EFCF02B7BC612B45E1F75524798EAA7E9D7FA579CD0B50674767E33D460947DA4A5C479E4150AD8F623FC2BAE9EDEC7C49A4AB7DE8DC6637C7CC87FC7D45796D775E04959AC6EA23F75240C3F11CFF2A1A1238BBBB692CAEE5B69461E262A7FC6BD3B40FF0090058FFD7215C678D2254D7F70EB244AC7EBC8FE95D868DFF22CDAFF00D70FE9431A33BC4FE1B17EAD7B68BFE9407CE9FF003D00FEB5C0152AC4104107041ED5DC7863C4C2709617CFFBD1F2C5293F7FD8FBFF003FE72F89BC342F435ED920172065D07FCB4F7FAFF3A13E81B94BC05FEB2FFE91FF00ECD59BE32FF9181FFEB9AFF2AD3F018225BF046080991FF7D56678CBFE4617FF00AE6BFCA85B8743AEF0E5AC563A040E899692312B903962467FFAD5C9DDF8CB549A666B7912DE3CFCAA1031C7B920D5CF0EF8AE2B3B54B2BE0C11388E5519C0F423FC2B59CF852FDCB3B59EE719249F2F3FCB9FD68039FB3F1AEA50B8FB408EE13BE542B7E0471FA55CF11F8960BED22182D18833FCD283D5403F74FD48FC87BD6A1F0A68578BBAD8B28C0E619B77E3CE6B97D77C393E8FB650FE75B31C07C60A9F4228D05A9894514550828A28A00292968A004A2968A004A28C502800A29692800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A280128A28A0028A5C525001451450014514500145145002514B4500251451401568A5A2800A28A280168A3A51400514514005145140051452D0018A314638A2800A5C5252D00028A28A0028A3BD2D00252D145001451476A005A29296800A28A7C6AAF2AABB88D4900B904851EBC73401EBAEC53456652430B7241079076D796FF6CEA9FF00412BCFFBFEDFE35DEBF89B436B06B61A8726231EEF264F4C67A579B3A857650C1C0240619C1F7E79A94365B3ABEA6CA55B51BB2A460833B60FEB551999D8B331663D493926928AA11D1F823FE4611FF5C5BFA56F78DEEEE6D2D6D0DB5C4B0967604C6E573C0F4AE73C297967A7EA6F757974215542AA36331627E80FA56978B756D3756B287EC978AF244E4EC31B82C0F1C123153D47D0CAD2BC4B7F637F1CB3DD4F7109F9648E490B71EA327AD77BAADA0D6F4565B6B8652EA1E27462037A03EA0D794575FE13F105B69F673417F761230C0C49B1988F5E808C74FD686811C9CB13C12BC52A9491095653D4115E91E0FBF4BBD0E38723CCB7FDDB0F6EC7F2FE55CEF89A6D13546FB659DEAADD0186431381201D39DBC1AC3D2F54B9D26F16E2DDB9E8CA7A30F4346E8362EF89B49974CD5656D87ECF33178DFB73C91F8562D7A3C1E28D1754B6315E858B70F9A29D72BF81E9FC8D37FB3FC208E65DF6248C9C7DA723F2DD8FD28B858C1F066932DCEA4B7EE845BC19209E8CD8C003E9D7F2AD8F1D5F247A7C562ADFBC9583B0F451FF00D7FE46A6BEF17E9761079560A276518458D76A2FE3FE15C1DE5E4FA85D3DCDCBEE91CF3E807A0F6A37D4362BD2FB5153D94E9697B0DC3C4251136E084E0123A67DB38AA116353D26EB499512E10E1D0307C7192391F5078AA15E876DE2FD26FE2F2AF6230EEE0ACABBD0FE3FE20506C7C2171890BD90CF617053F4DC2A6E3B185E08FB41D69BCB2DE488C99476F6FC73FD6B4FC7A13ECD644E3CCDED8FA6067FA56836BDA068D6E62B578CE33FBBB75CE4FD7A7EB5C46B3AC4BACDE99E41B1146D8D01FBA3FC68EA0771E10BF5BBD0E38B23CCB7F9187B763F97F2AE3BC4BA54BA6EAB236C3F67998BC6FDB9E48FC2A9699A9DCE9378B716EDCF4653D187A1AEEA0F13E8BAA5A98AF42C5B87CD14EB95FC0F4FE546C3DCF3935D378374996E7525BE7422DE0C904F466EC07D3AFE55BBF60F08A39977D9123271F69C8FCB7628BDF17E9961079560A267518558D76A2FE3FE145EE2B10F8E6FD23B08AC548F32560EC3D147FF005FF91AA3E02FF8FBBDFF00717F99AE62F6F27BFBA7B9B87DF239E7D00F41ED5D0784B51B0D2CDC4D7976236900554F2D89C0EF903145B40EA4BE3CFF009085AFFD723FCEB92AE9BC5B7F63A9CD6F3D9DD090A29464D8CA477CF2315CDE29A063A49A494462462DE5AEC5CF619271FA9A6D2E28A6224B5FF8FB87FDF1FCEBD4B5DFF900DF7FD716FE55E616623FB643E6CA2240E0B39048007B0E6BBCD47C45A35EE9D716C97E15A58CA82627C0247FBB52C68F3CC518A7639C673EF498AA10DC55E8348BAB9D2E6BF890B471385200C93C649FC38FCEA9575BA1F8AED34FB38ECE5B4748D07FAC460C493D491C77A4C671F8A7C5E60957CA2C24C8DBB3AE7B62BD0DE4F0AEAA4BC8D69B9864963E531FA9E0D3A03E17D25BCE825B457E70CB279AC3E9C92295C2C6A5C29FEC3956EF93F663E6FD76F35C3F836F96D35830C8404B85D809FEF751FD47E3567C43E2A5BFB76B3B256585BEFC8DC161E807A572C320820E08E868481B3BEF196952DE5A477702967B7C8751D4A9EFF87F535E7F8AED746F19A08960D4C3065E04EA3391FED0EB9F7157E587C29A8319A47B3DC4F27CDF2C93EE3228D837382B4B49AF6E92DEDD0BC8E7007F53ED5EA43C8D134650EDFBBB688027FBC40FE64FF3ACE4D4FC3BA2C6C2D9E00780441F3B37E3DFF135CA6BDE229B58611A298AD54E4267963EA7FC28DC36336DA469B568657FBCF3863F52D5E91E23FF00917AF7FDCFEA2BCDF4FF00286A1034F30863570CCE549C01CF41CD7A049E27D0268DA396E95D1B82AF0B907F0DB430479A8A5E2BBFFED4F08FFCF3B4FF00C033FF00C4D1FDA9E11FF9E769FF008067FF0089A2E163838C156494A9D818738E33E95EABAA44D75A3DDC717CCCF0B0503B9C715C87896E74CB9D32D8E982211ACC7708E3D9CED1DB02AD687E2E822B58ED751DCA631B566032081D320739A18238C208382314052CC000493C003BD7A2CEBE17D4DDA69A4B32E4F2DE6F9649F7E4134909F0BE94C26864B40E3243093CD61F4E49145C2C686C369E1BD927061B4C37E09CD795FE15D5F88BC551DF5B3D958AB794DC3CAC31B87A01E95CA5090326B6FF008FA87FDF1FCEBD3F5CFF009015F7FD716FE55E636613ED90F9B288A30E0B39048007B0C9AEF351F1168D79A75C5B25F8569632A0989F0091FEED0C11E7B494E380700E7DE96355791559C22920172090A3D78E6A847AB4BFF2047FFAF73FFA0D79869B77F61D4ADEE71911B8623D477FD2BBB6F11E8AD62D6C2FF93194CF92FE98CF4AF3C750AECA18300480CB9C1F7E6A50D9EA3ABD9AEB1A2C9142C18BA8789B3C12391F9FF5AF2E963786568A4428EA70CA460835D0681E28934B416D72AD2DAFF0E3EF27D3D47B57472DDF8675A01EE25B666C759098D87B678346C3DCF3A0092001927A0AF4AF0BE96FA66923CE5DB34CDE6383FC23B0FCBF9D430B785B4A6134325A07192183F9AC3E9C922B1F5CF17FDAA17B5D3C3A2370F2B70C47A01DA8DC3631FC477CBA86B73CB19CC6B88D0FA81DFF003CD779A37FC8B36BFF005C3FA579757A0586BFA35AE930D9BEA00B245B0B0864C671F4A1891E7FCF51C5775E18F128B954B0BE7FDF0E23909FBFEC7DFF009FD7AF0F2AAA4ACA8E2450701C02030F5E79A68241C83CD3680F5D86C2DEDEF27BA893649381E663A1233CFD79AE07C65FF2303FFD735FE55BDA2F8AACD34B8D352BD1F685C8FF0056E4E3B64818CD73BE27BBB4BED4C5D5A5C0991902901194A91F503AD25B8D94DB49BA5D263D442130BB15E07DD03B9F62723F0ACFAEDF4BF1858C56F1DACF6AF0468A114A9DE303D7A1FD2AE32784F50CC8CD6609C1277F944FEA28B8AC711A67DA3FB4ED85A961319005DBF5FE55E8DE25087C3B79E674D831F5C8C7EB8AA90DD786B4552F6F2DB2B11D636F318FB67935CD788BC4A756516D6E8D1DB29C9DDF79CFBFA0A371EC73D494B495448514B49400B4514500145275A5A004A28A5A004A28A0500145145001DA8A28ED40051451400628A28A0028A28ED4005145140051451400514514005252D25001451450014514500145145001451450021A28A2802B5252D140052E29296800A28A2800A28A31400BDA92968A004A5A5ED498C5002D145140051451400514B4500252D1450014514500028A51C5140094B45140062968A2800A28A2800A28C52D0014514500145145002F4A4A5A2800A28A2800A5A3145001477A28A005A4A5A4A0028A28A002969296800A4A5A00CD00253A8C52D00252D145002D2519A5A0028A28A002969296801292968A0028E6968A004E68C52E68A0031451450014514500145149400B45252D00145145002D277A2928016928C51400BCD14514005252D250014514940051451400514525002D14514005277A296800A28A2800A28A2800A4A5A28012968A2800A4A5A2800A4A2968012968A4CD002D252D1400828A5A280128A29680128A3141A0028A5A4A0028A28A0028A28A0028A28A0028A4EF4B400514514009452D140094668A2800A28A2800A28ED4500145145001494B450055A5C5252D00145145001451450014B451DE800A2968A004A5A28A0028A052D00252D14500145145001452D140094B4514005146296800A28A2800A28A5E940094B45140051451400514B4500252E28A2800A28A2800A5A28A0028A28A0028A28A0028A28A0028A28A002969281400B4B494B400B4B4DCD2D002D2519A280168A28A005EF45251400B49451400B45251DA800A28A280168A28A002929692800A5A28A0028A28A0028A28A003145145001494B49400B4519A2800A4CD2D25001451450018A3145140098A296834804A28A5E94C04A28A28010D2D2D25001DA8A28A0028A28A004A5A28A0028A28A0028A28A0028A28A0028A28A0028A28A002928A5A002928A280168A292800A28A5340074A4A5A4A0028C5145001451450014514500145145001494B45002529A28A004A28A5A004A28A2800A28A2800EF486968A00AD451450014514B4005145140051451400B4514500145145001452D1400514628A005A4A5A2800A28A2800A28A280168A28A0028A28A002968A2800A28A050014514B400B49494B40051451400514B49400B451462800A28A2800A28A5A004EF4514500145145001DA81476A5ED40052F6A4A2800A51494B400B4528A2800A28A2800A28A2800A28A2800A28A2800A2968A00292968A004A5A28A0028A28A0028A4A5A0028A28A004A2969280168A28A00292968A004E6968A4A0028A28A0028A28A0028A28A0028A28A0028A28A00292968A00292968A0028A28A0031494B4500252E68A4A0028A5A4A005C5252D14009452D14009452E292800A28A2800A28A280128A5A28012968A2800A4C52D140094628A5A004A28C514005140A2800A28A2800A28A2800A28A2800A4A5A280034945140051475A2800A28A2802B51451400B45252D00252D14B40051494B4005145140051451400B4519A3340052D251400B45145001451450018A28CD2D00145145001452D1400514514005140A5A004C51D29D49400514BDA92800A28A5A004A5A28A0028A28A0028A5A4A005A28A280128A0D140076A051DA9680128A296800A28A514006297B5145002D1451400514514005145140051DA8A2800A5A4A28016928A2800A28A280168A3349400B45251400B45251400B49452D0018A28A2800A4A5A28012968A2800A4A5A2800ED45145001451450021A28A2800A28A2800A051DE8A0028A28A0028A28A0028A28A003B5252D1400514518A0028A28A0028A28A0028A33450014514500145252D001C52514B40094B494B40094514B400DA5A28A0028A293BD002D145140098A2968A004A29692800A29690D001451450014514500252D14500145145002514B494015A8A28A005CD140A3340052D252F4A002834514005145140051451400B45145001452E28A0028A28A0028A296801052D21A5A002969052D00145145001450296800A28A2800A28A2801692968A0028A28A0028A297140094B4525002D145140051451400525145002D1C514500140A281D680168A296800A5A28A0028A4A280168CD25140052E69B9A33400ECD02928CD002E6928CD1400B45145001451450014514500145145001451450014B4514009452D140094B494B4005145140051494B400514525002D251450014514500145145001451450014514500145145001451450018A314B49400628A5A280128A28A0028A29680128A28A0028A28A003AD1451400514514005145140051494B400514514005252D140094514500145145001451450014514500251DA968A004A28C52D00251451400514514009452D14015A928A5A0028A2968012968A2800A28A0D0014528A2800A5A4A5140094B494B40051451400514B4500145145001452E28A0005145140052D252D001451450014B8A4A5A004A5A3B502800A28A5A004C52D14500252D145001451450014514500141A5A4A004A2969280168A293B5002D1451400B45145002D1494668016929692800A4A5A4EF400B451450014514A2800A2968A0028A28A0028A28A0028A28A0028A28A002969296800A4CD2E292800A5A28A0028A28A0028A4A5A004A5A29280168CD252D001494B4940051452D002514EC71494009F8514B45001494B4B4009494BDE8A0028A28A0028A28A0028A28A00292968EF4009452D1DA80128A5A2800A4A5A280128A28A0028A28A0028A28A0028A28A0028A29280168A3145002514B49400514514005145140051451400514514005252D140094669692800A283D68A0028A28A00AD4514B40094B494B40051452D002628C52D1400514B4500252D145001451450019A5A4A5A0028A28A0028A5A2800A28A2800A5A4A5A0028A28A00296928A002968A2800A28A3140051451400514B45001451C5140051452D002514B45001498A5A28012929D4940082968A2800A28A2800A28A280168A2928016929692801692968A0028A2968012968A5A0028A28A0028A28A0028A28A0028A28A002969296800A2928A005A28A4A005A28A2800A4A5A2800A28A2800A38A4A5C50014514B40094514B4009452D14000A28A280128A5A28012968EF45002514B46680128A28A005ED49452E2800E2929692800A28A2800A28A2800A28A2800A4A5A4A003B514514005145140051451400514514005145140051451DE800A4A5A4A005A4A5A4A0028A28A0028A28A0028A28A0028A2938A005A4A28A0028A28C5001451450056A2968A0028A28A0028A5A2800A28A2800A2968A0028A28A0028A28C50019A5A28A002969296800A28A3140051451400514B45001451401400B9A4A5A2800A28A2800A281D2971400514514005145140052E2928A0028A296800A28A2800A28A0D0006928349400B45145001451450014514500145145002D277A28A005A28A28001D6945252D002D145140051451400514514005140A2800E2969296800A2928A005A29296800A28ED4500145252D00252D145001498A5A2800A28A2800A2968E280128A297140094B4628A0028A28A0033451DE8CD00145251400B494B45002514B4940052D251400514514005145140051451400514945002D252D14009451450014514500145145001451450014514500145141A002928A2800A28A2800A28A2800A28CD140094B494B400945145001451450014514500145252D0056A5A28A0028A5A2800A28A2800A5A28A0028A28A0028A296801052D14500252D14A280129475A28A0028A28C50014514B4005145140052D14500145141EB40051452D00145252D001451450014514B4005145267DA80168A28A0028A28A005A4A5A2801B453A905001452D14009452D14005145140098A2968A4026296968A602514B49DA800A5A28A0028A314500145145001451450014514B400514514005149450028A28A2800A28A2800A28A3BD00252D14500028A28EF400514525002D145140052D2528A0028C519A2800EF45145001494B4940051451400514679A2800A283450014514500145145001476A28A0028A28A004A297BD140051494B4009CE28A28A0028A28A0028A28A0028A28A0028A28A004A28A280171494B46680128A28A00292968A0028A28A004A2968A002928A2800A28A2800ED4514500252D149401051451400B451450014514A680129451450018A28A5A0028A28A00281452D00252D252D001451477A0028A5A4A005C51494B40052D251400B45252D001451DA8A002969296800A28A2800A28A280168A4ED450014B451400514514005145140052D14500252D149400B45145001451476A0028A28A0038A28A280168A28A0028A28A0028A28A0028A28ED40051451400514B494000A29693BD001452D14009451DE96800A28A2800A28A2800E94514500145145001451450014514500145140A0028A53498A0028A296800A4A5A280128A2968013BD1452D00251451400514514005145140051451DA800A28A2800A28A2800A28A2800A4A5A4A0028A29680128A3145001451CD14005145140094B451400514514005252D25001451450018A28A2800A28A2800A2928A0028A28A0028A28A0028A28A0028A4A28021A29296800A29296800A28A2800A5A28A0028A29680128A5ED450014514B40094B4514005145140052D252D0014514500145145002D068A2800A29692800A5A28A0028A28A0028A296800ED4514500252D145001451450014B494B400828A5A31400514514005145140051DE8A28016929714500251452D00252D145001451DE8A0028A28A0028A28A0028A2968012979A4A5A00292834B4005145140051DE8A3AD001451450014514500145145001452D14009452D140094BDA929680128A5EF49400514B45001451DE8A004A5CD14500251451400514506800A4EF4B450014514500145145001451450014514500145145001494B45001494B49400B49452D0025145140051451400514514005145250014B49450014514500145145001451450021A5A28A0028A28A002929690F5A0028A28A0028A28A00292968A00AF4B45140051451400B45252D001451450014B4945002F34514500145145002D141A2800A5A4A2800A5A4A5A0028A28A005A28A2800A28A28017B525145002D145140051451400B45251400B45149400B45145001451450014B49476A005A29296800A4A296800A28A2800A28ED450014B4945002D252D277A005A28A2800A28A2800A28A2800A31451400629693B51400BC51451400514514005145140051451400514B45001494B450018A4A5EB462800EF4628A2800A28A2800A28A2800A5A4A2800EF4B49DE9680128A28A0028A3145001DA8A28A0031494B4500251CD14500145145001451450014514500145145001494B4500252D1D68A0028A28A004A5A4C52D002514B45002514514000E28A28A00292968A004A2968EF400945145002D252D140094B494B4009451450014628A2800A28A2800A43D6968A004A28A5C50025145140105145140051451400B4514500145145002D252D140051451400B4945140052D145001451450014B45140051451400A28A3145001451450014B49450014B494B400514514005145140052D252D0018A28A2800A281CD1400B45252D00252D145001451477A0028A28A0028A28A0028A297140094B494B40051451400514514005145140051451D6800A5A4C51400B45149400A68A4A5A0028A28A0028A28A005A3349DE8A005A28CD25002D1451400945145002D1451400514668A0028A28FC6800A5A4A334005147E3471EB400514645140051451400514514005149919A5CF140051CD19A28012968A692075A0076293B526E146E1DCD002D14DDE28F305003A8A4DC3D68DC3D680168A01147140051452D00251451400514514009450481D69A587AD003A8A69718A4320EC2801F454464269A5D8F7A009B348580EA6A1C9A4EB4013EF146E18EA2A0A28027DEBEA28DC3D4541F8514016370F5149B87AD4145004FB87AD1BC7AD57A5A009F70F5A370F5AAF450058A5AAF93EB46E340163AD27E3506E3EB4BBCFAD004D8A5A8379F5A4DEDEB4013D150AB91D69DE60A0065140A2800A5A4A280168A28A0028A28A002945252D001451450014B8A314500145145001451450014B494B4005145140051452F6A0028A28A00297149450014514B4005145140051451400B8A28A2800A28A2800A28A2800A5A4A5A0028A28A00292968A0028A28A00296928A005EF45252D001451450019A28A2800A28A2800A28A2800A5A4A28016928A2800A28A5A004A28A5A0028A4A5A002834514005145140051451400B45264D1BBD6800A29A5C534B9A00933499151EE26933400F2F485CD368A0052C4F7A4E7D68A2800C9F5A5C9A4A280179F5A327D6928A00327D68C9F5A4A5A005DCC3BD1B8FAD2525003B27D69093EB45140064D2E7DCD251400BB8D1B8FAD368A007EE3D334D24F734945002F3451450025145140067DA8A28A005C91DE8C9F5A28A005DC68DC69B45003F79A4DE69B49400F2E73485DBD69A28A00324F5A4A31462800A28A2800A28A2800A28A280128A5A280128A5A4A0028A5A4A004A29D49400514514009452D14005252D140098A28A01A0028A2968012968A4A002968A2800A5A4A5A0028A4EF4B40052D251400B451482801D45252D00145028A0028A28A002968A280014514A6800A2814500145145002D25145002D145140051451400529A3DE8A0028A28A0028A28A00296928A005A29296800A28A2800A28A2800A28A2800A28A280145149450014B4945002D145140051451400514514005145140051451400514514005145140052D251400B452669A5C5003E9322985C9A6939EF401216029A64A652D002EE269292968010D1477A2800A0514B4005145140077A28A2800A28A2800A28A2800A051450014668A2801052D14B400945145001452D250014514B400945145001451DE8CD001499A28A0028FC68ED45001CD252D14009452D0280128A5C7346280128C53B1498E6801314629D8A31400DA4A7E2971400CA314FC5262801B8A4A7E29314009498A7628C714009498A7628A006E28C53A8A006FE14629D4500371453B14500371453A93140098A314B45003714114EA4A004A29296800A28A2800A5A4A28017BD14514005028A5A0028A28A0028A296800A28CD14005145140052D251400B45145002D145140051451400B45251400B49452D0014514500038A28A5A0028A28A0028A28E2800A28A2800A29692800A5A2834005145140051451400514B4940051451400B45252D00145145001451450014521200E6986603A0A009290903BD406463DE9A79A00B1E628EF4798BEB55F3450058F313D68F317D6ABD14013F9A293CD1E86A1A514012F9B4D2E4D328A005DC6941A6D2F1400ECD19A651400FCD19A6D19A00752D373466801D49466941A0028A5A2800C518A28A00314628A2800A28A280131452E28A004A5A297140098A2968C5002514B45002628A5A280131452D250014514500145145002514A28A004A2968A004A5C514500146297B52500262971452D00262968A28012968A2800A28A280128A296801296929680128A5A28012929D494009452D18A004A4C52D2D002628A31450018A4A5A4A0028A53494006292968CD001494B49400DA293345002D145140052D277A2800A5A31450014B4945002D14945002D1494B40051452D0019A05252D001451450014B494B400B452519E680168A4CD2D0014668A4A005A5A4EF4B400519A2928016969B46680168E949B8530B6680242C29BBFDA994B400FDD4A1AA3A28025C8A030F5A8F9A28024CE68A8F3EF467DE8024C8A3351D1400F2D49BE9B45003B751B8D368A0076EA5DD4CA3340126FA370A8F34849A009B70A3350E69A589A0099A451DEA3329351D1400A493DE928A2801692968A0028A28A0028A5C5140098A28A51EF400628A28A0028C52D140094B452D002514B45002518A5A2800A28A280168CD251400B9A7034DA4A0093228A8F34B9A007D029A09A50680168A4C8A5CD001451450014B494B4009451450029A4ED451400514514005262968A0029314B45001DA92968A004A5A28A0041EB4B463145001DA8A28A0028A28A0033494B499A005A2928A0028CD1450014519A280173466928EF40051452679A00752519A4A005A434669280168CD252D0019A2928A005A2928A0028A4CD19A0028A4CD1400B452519A006D149BA8DD400EA2985A93750049499A6649A2801FBA9770EF51D2D003F70A0114CA28024C8A3351D19A009296A3A3340121A2A3CD19A0092814CE7D6804D00499A3351E4E69726801E2806999A3340125151E68C9A007D2D479A334012E4526466A3A33400FDC29770A8E8A007EE1416A6D25003B26928A280168A4A2800A3BD14B400514514005145140052D25266801D4669B9A33400B9A5A6E78A28017346693345002E6933451400B9A4240A693E949400A4E69296939A002945252D001494B45001451450014B4628A0028A28A0028A28A005A28A2800A28A280014514B40051451400514668A0028A4A5A005A4A28A005A2928A005A4A296800A28A0D00145145002E4D19A4A2801734B9A6D1400ECD19A6D1400ECD19A6D1400EA5ED4CCD19A007D14CCD2E6801D4537752E6800CD2E69B9A33400B9A5A6E68CD003B34669B9A33400EA4A33499A005A2928A005CF149499A2801D452671499A0076692909A33400EA29B9A2801D9A334DA280168A4CD25003A8A6D1400B452525003B34669290D003B3499A4A2801738A4CD252E6800A28A4A005A4A28A0028A4A33401152D251400B451DA8EF40052D21A05002D2D251400B451477A0028A28A002968A4EF400B4525140052E68A4A005A5A4A075A002968A4A005145028EFF008D0014B494B400514941A005A29B4A6801734B4D145002D19A4A3B5002E68CD251400B9A334941A005CD2E69B45002D1451400B4940E94500145145002D14506800A29290D00293499A4A3BD0014514B4005145140051452D0025145140052F6A4A5A004A5A28A0028A28A002968A2800EF4514B40098A5A28A0028A28A0028A28A0028A28A003BD1452D0025145140051451400514528A0028CD251400B4525140051451400A2928A2800A290D2F6A0028A28A005A4A28ED40051DA8A2800A3B51450019A2928A005A28A0D0019A334945002E68CD2525003F34DCD149400ECD19A6D1400B9A334945002E68CD3696801734669292801D9A334D14B400B9A2928A005CD14945002D2521A2801D4669B45002D14868A0029734949400B4668348280168A4A4A005CD14945007FFFD9, N'', 1, 0, 0, 0, 0, 0, 0, 0, 1, NULL, N'', NULL, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'', N'0', N'', 0, 1, 1, 0, 0, 0, 1, 2, 2, 12, 1, 1, 0, 0, 0, N'', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N'', N'', N'', N'أهلا وسهلا بكم عملائنا الأعزاء', N'شكرا لزيارتنا', N'نتمنى لكم أوقات سعيدة', N'كل عام وانتم بخير', 0, N'0000000000000000000000000000', N'تفاصيل أخرى', N'Other Details', N'0000000000000000000000000000', N'مكآفأة', N'Gift', 0, 0, 0, 0, N'C:\Users\mrzazz\Dropbox\Psoft302\InvAcc\bin\Debug', N'255,255,255', N'224,224,224', N'255,0,0', N'128,64,0', N'255,128,0', N'64,64,64', N'255,128,128', N'0,128,0', N'0,64,0', N'0,64,0', N'255,255,255', N'255,255,255', N'0,0,0', N'255,255,255', N'0,0,0', N'255,255,255', 125, 100, 30, 0, 4, 6, N'05:00:00', N'06:00:00', N'AM', N'PM', N'1026', N'3011002', 0, 0, N'4011026', N'Tax is 5%    |   الضريبة 5 %', 0, N'COM4', 9600, 1, 8, 3, N'Pro.Soft-Solution', 0, 100, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0.01, N'سلعة', N'مواد خامة', N'خدمة', N'Commodity', N'Raw materials', N'Service', 0, N'0', N'', N'', N'', N'', 0, 0, 30, 5, N'10110', N'1027', 3)
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
INSERT [dbo].[tb_version] ([id], [dbv], [lastupdate]) VALUES (1, N'db.0.CR.311.1', NULL)
GO
SET IDENTITY_INSERT [dbo].[tb_version] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_T_CATERY]    Script Date: 8/10/2021 6:18:46 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_T_CATERY] ON [dbo].[T_CATEGORY]
(
	[CAT_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
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

GO
USE [master]
GO
ALTER DATABASE [PROSOFT] SET  READ_WRITE 
GO
