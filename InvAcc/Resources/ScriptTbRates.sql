USE [master]
GO
/****** Object:  Database [DBPROSOFT]    Script Date: 04/13/2015 04:21:39 ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'DBPROSOFT')
BEGIN
CREATE DATABASE [DBPROSOFT] ON  PRIMARY 
( NAME = N'DBPROSOFT', FILENAME = N'PathRate1' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DBPROSOFT_log', FILENAME = N'PathRate2' , SIZE = 1280KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
END
GO
ALTER DATABASE [DBPROSOFT] SET COMPATIBILITY_LEVEL = 90
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBPROSOFT].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBPROSOFT] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [DBPROSOFT] SET ANSI_NULLS OFF
GO
ALTER DATABASE [DBPROSOFT] SET ANSI_PADDING OFF
GO
ALTER DATABASE [DBPROSOFT] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [DBPROSOFT] SET ARITHABORT OFF
GO
ALTER DATABASE [DBPROSOFT] SET AUTO_CLOSE ON
GO
ALTER DATABASE [DBPROSOFT] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [DBPROSOFT] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [DBPROSOFT] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [DBPROSOFT] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [DBPROSOFT] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [DBPROSOFT] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [DBPROSOFT] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [DBPROSOFT] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [DBPROSOFT] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [DBPROSOFT] SET  DISABLE_BROKER
GO
ALTER DATABASE [DBPROSOFT] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [DBPROSOFT] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [DBPROSOFT] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [DBPROSOFT] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [DBPROSOFT] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [DBPROSOFT] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [DBPROSOFT] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [DBPROSOFT] SET  READ_WRITE
GO
ALTER DATABASE [DBPROSOFT] SET RECOVERY SIMPLE
GO
ALTER DATABASE [DBPROSOFT] SET  MULTI_USER
GO
ALTER DATABASE [DBPROSOFT] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [DBPROSOFT] SET DB_CHAINING OFF
GO
USE [DBPROSOFT]
GO
/****** Object:  User [omar]    Script Date: 08/15/2014 07:50:27 ******/
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'omar')
CREATE USER [omar] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[T_Branch]    Script Date: 04/13/2015 04:21:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Branch]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[T_Branch](
	[Branch_ID] [int] IDENTITY(1,1) NOT NULL,
	[Branch_no] [varchar](50) NOT NULL,
	[Branch_Name] [varchar](50) NULL,
	[Branch_NameE] [varchar](50) NULL,
	[Branch_address] [varchar](50) NULL,
	[Branch_city] [varchar](50) NULL,
	[Branch_phone] [varchar](50) NULL,
	[Branch_fax] [varchar](50) NULL,
	[Branch_mem] [varchar](max) NULL,
	[REP_FLG] [int] NULL,
	[StartEg] [varchar](30) NULL,
	[EndEg] [varchar](30) NULL,
	[crNo] [varchar](50) NULL,
	[crIssu] [varchar](50) NULL,
	[crExp] [varchar](50) NULL,
	[BldNo] [varchar](50) NULL,
	[BldIssu] [varchar](50) NULL,
	[BldExp] [varchar](50) NULL,
	[dfNo] [varchar](50) NULL,
	[dfIssu] [varchar](10) NULL,
	[dfExp] [varchar](10) NULL,
 CONSTRAINT [PK_T_Branch] PRIMARY KEY CLUSTERED 
(
	[Branch_no] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[T_Branch] ON
INSERT [dbo].[T_Branch] ([Branch_ID], [Branch_no], [Branch_Name], [Branch_NameE], [Branch_address], [Branch_city], [Branch_phone], [Branch_fax], [Branch_mem], [REP_FLG], [StartEg], [EndEg], [crNo], [crIssu], [crExp], [BldNo], [BldIssu], [BldExp], [dfNo], [dfIssu], [dfExp]) VALUES (1, N'1', N'الفرع الرئيسي', N'Main Branch', N'----------', N'------------', N'-------------', N'', N'-------------', 0, N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
SET IDENTITY_INSERT [dbo].[T_Branch] OFF
GO
/****** Object:  StoredProcedure [dbo].[S_T_Report]    Script Date: 04/13/2015 04:21:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[S_T_Report]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

Create PROCEDURE [dbo].[S_T_Report](
                    
                   @Tables VARCHAR(100),
                   @Fields VARCHAR(1000)=''*'',
				   @Rule VARCHAR(1000)= NULL     
      )
      AS
      BEGIN
      DECLARE @sql AS NVARCHAR(MAX);

      SET @sql = N''SELECT '' + @Fields
      
      + N'' FROM '' +@Tables + '' ''

	  + CASE WHEN @Rule IS NOT NULL THEN
      + @Rule + '';'' ELSE N'''' END
      
      EXEC sp_executesql
      @sql,
      N''
      @P_Tables VARCHAR(100),
      @P_Fields VARCHAR(1000),
	  @P_Rule VARCHAR(1000)''
      
      ,@P_Tables = @Tables
      ,@P_Fields = @Fields
	  ,@P_Rule = @Rule;
      
      RETURN
      END


' 
END
GO
/****** Object:  Table [dbo].[T_Users]    Script Date: 04/13/2015 04:21:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Users]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[T_Users](
	[Usr_ID] [int] IDENTITY(1,1) NOT NULL,
	[UsrNo] [varchar](3) NOT NULL,
	[UsrNamA] [varchar](50) NULL,
	[UsrNamE] [varchar](50) NULL,
	[Pass] [varchar](250) NULL,
	[Brn] [varchar](50) NULL,
	[Sts] [int] NULL,
	[Typ] [int] NULL,
	[ProLng] [int] NULL,
	[FilStr] [varchar](150) NULL,
	[InvStr] [varchar](150) NULL,
	[SndStr] [varchar](150) NULL,
	[StkRep] [varchar](150) NULL,
	[AccRep] [varchar](150) NULL,
	[SetStr] [varchar](150) NULL,
	[EditCost] [varchar](1) NULL,
	[PassQty] [varchar](150) NULL,
	[RepInv1] [varchar](100) NULL,
	[RepInv2] [varchar](100) NULL,
	[RepInv3] [varchar](100) NULL,
	[RepInv4] [varchar](100) NULL,
	[RepInv5] [varchar](100) NULL,
	[RepInv6] [varchar](100) NULL,
	[RepAcc1] [varchar](100) NULL,
	[RepAcc2] [varchar](100) NULL,
	[RepAcc3] [varchar](100) NULL,
	[RepAcc4] [varchar](100) NULL,
	[RepAcc5] [varchar](100) NULL,
	[RepAcc6] [varchar](100) NULL,
 CONSTRAINT [PK_T_Users] PRIMARY KEY CLUSTERED 
(
	[UsrNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[T_Users] ON
INSERT [dbo].[T_Users] ([Usr_ID], [UsrNo], [UsrNamA], [UsrNamE], [Pass], [Brn], [Sts], [Typ], [ProLng], [FilStr], [InvStr], [SndStr], [StkRep], [AccRep], [SetStr], [EditCost], [PassQty], [RepInv1], [RepInv2], [RepInv3], [RepInv4], [RepInv5], [RepInv6], [RepAcc1], [RepAcc2], [RepAcc3], [RepAcc4], [RepAcc5], [RepAcc6]) VALUES (1, N'1', N'الدعم الفني', N'Support', N'flm8ZAF33tWSzGqBtqx+7z3fzGlwHHymse1vRjXS93smXO4DliC+wNFW5VWj9v7o', N'1', 0, 0, 0, N'1111111111111111111111111111111111111111', N'1111111111111111111111111111111111111111111111111111', N'1111111111111111111111111111111111111111', N'111111111111111111111111111', N'111111111111', N'11111111111111111111111111', N'0', N'1111111', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
SET IDENTITY_INSERT [dbo].[T_Users] OFF
INSERT INTO [dbo].[T_Users] ([UsrNo], [UsrNamA], [UsrNamE], [Pass], [Brn], [Sts], [Typ], [ProLng], [FilStr], [InvStr], [SndStr], [StkRep], [AccRep], [SetStr], [EditCost], [PassQty], [RepInv1], [RepInv2], [RepInv3], [RepInv4], [RepInv5], [RepInv6], [RepAcc1], [RepAcc2], [RepAcc3], [RepAcc4], [RepAcc5], [RepAcc6]) VALUES (N'2', N'الرئيسي', N'Main', N'mELirpUhRYksFj7k8/XBcQ==', N'1', 0, 0, 0, N'1111111111111111111111111111111111111111', N'1111111111111111111111111111111111111111111111111111', N'1111111111111111111111111111111111111111', N'111111111111111111111111111', N'111111111111', N'11111111111111111111111111', N'0', N'1110111', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
GO
/****** Object:  ForeignKey [FK_T_Users_T_Branch]    Script Date: 04/13/2015 04:21:42 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Users_T_Branch]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Users]'))
ALTER TABLE [dbo].[T_Users]  WITH CHECK ADD  CONSTRAINT [FK_T_Users_T_Branch] FOREIGN KEY([Brn])
REFERENCES [dbo].[T_Branch] ([Branch_no])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Users_T_Branch]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Users]'))
ALTER TABLE [dbo].[T_Users] CHECK CONSTRAINT [FK_T_Users_T_Branch]
GO