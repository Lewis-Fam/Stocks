USE [master]
GO
/****** Object:  Database [alltdl_lewisfam1]    Script Date: 12/31/2020 9:15:27 PM ******/
CREATE DATABASE [alltdl_lewisfam1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'alltdl_lewisfam1_data', FILENAME = N'\\ss9\WDB2_S1\MSSQL13.MSSQLSERVER\MSSQL\DATA\alltdl_lewisfam1_data.mdf' , SIZE = 25370624KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'alltdl_lewisfam1_log', FILENAME = N'\\ss9\WDB2_S1\MSSQL13.MSSQLSERVER\MSSQL\DATA\alltdl_lewisfam1_log.ldf' , SIZE = 83904KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [alltdl_lewisfam1] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [alltdl_lewisfam1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [alltdl_lewisfam1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [alltdl_lewisfam1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [alltdl_lewisfam1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [alltdl_lewisfam1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [alltdl_lewisfam1] SET ARITHABORT OFF 
GO
ALTER DATABASE [alltdl_lewisfam1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [alltdl_lewisfam1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [alltdl_lewisfam1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [alltdl_lewisfam1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [alltdl_lewisfam1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [alltdl_lewisfam1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [alltdl_lewisfam1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [alltdl_lewisfam1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [alltdl_lewisfam1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [alltdl_lewisfam1] SET  ENABLE_BROKER 
GO
ALTER DATABASE [alltdl_lewisfam1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [alltdl_lewisfam1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [alltdl_lewisfam1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [alltdl_lewisfam1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [alltdl_lewisfam1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [alltdl_lewisfam1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [alltdl_lewisfam1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [alltdl_lewisfam1] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [alltdl_lewisfam1] SET  MULTI_USER 
GO
ALTER DATABASE [alltdl_lewisfam1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [alltdl_lewisfam1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [alltdl_lewisfam1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [alltdl_lewisfam1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [alltdl_lewisfam1] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'alltdl_lewisfam1', N'ON'
GO
ALTER DATABASE [alltdl_lewisfam1] SET QUERY_STORE = OFF
GO
USE [alltdl_lewisfam1]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [alltdl_lewisfam1]
GO
/****** Object:  User [alltdl_daddy]    Script Date: 12/31/2020 9:15:28 PM ******/
CREATE USER [alltdl_daddy] FOR LOGIN [alltdl_daddy] WITH DEFAULT_SCHEMA=[alltdl_daddy]
GO
/****** Object:  User [alltdl_admin_lewisfam]    Script Date: 12/31/2020 9:15:28 PM ******/
CREATE USER [alltdl_admin_lewisfam] FOR LOGIN [alltdl_admin_lewisfam] WITH DEFAULT_SCHEMA=[alltdl_admin_lewisfam]
GO
ALTER ROLE [db_owner] ADD MEMBER [alltdl_daddy]
GO
ALTER ROLE [db_owner] ADD MEMBER [alltdl_admin_lewisfam]
GO
/****** Object:  Schema [alltdl_admin_lewisfam]    Script Date: 12/31/2020 9:15:29 PM ******/
CREATE SCHEMA [alltdl_admin_lewisfam]
GO
/****** Object:  Schema [alltdl_daddy]    Script Date: 12/31/2020 9:15:29 PM ******/
CREATE SCHEMA [alltdl_daddy]
GO
/****** Object:  Schema [security]    Script Date: 12/31/2020 9:15:29 PM ******/
CREATE SCHEMA [security]
GO
/****** Object:  Schema [todo]    Script Date: 12/31/2020 9:15:29 PM ******/
CREATE SCHEMA [todo]
GO
/****** Object:  Schema [trading]    Script Date: 12/31/2020 9:15:29 PM ******/
CREATE SCHEMA [trading]
GO
/****** Object:  Table [trading].[OptionPrices2020]    Script Date: 12/31/2020 9:15:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trading].[OptionPrices2020](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[StrikePrice] [float] NOT NULL,
	[ExpireDate] [datetimeoffset](7) NOT NULL,
	[Direction] [int] NOT NULL,
	[ActiveLevel] [bigint] NOT NULL,
	[AskPrice] [float] NULL,
	[AskVolume] [bigint] NULL,
	[BatchId] [uniqueidentifier] NOT NULL,
	[BidPrice] [float] NULL,
	[BidVolume] [bigint] NULL,
	[Change] [float] NOT NULL,
	[ChangeRatio] [float] NOT NULL,
	[Close] [float] NOT NULL,
	[Delta] [float] NOT NULL,
	[Gamma] [float] NOT NULL,
	[High] [float] NOT NULL,
	[ImpVol] [float] NOT NULL,
	[Low] [float] NOT NULL,
	[Open] [float] NOT NULL,
	[OpenIntChange] [bigint] NOT NULL,
	[OpenInterest] [bigint] NOT NULL,
	[PreClose] [float] NOT NULL,
	[QuoteMultiplier] [float] NOT NULL,
	[Rho] [float] NOT NULL,
	[SpotPrice] [float] NOT NULL,
	[Theta] [float] NOT NULL,
	[TickerId] [bigint] NOT NULL,
	[UnSymbol] [nvarchar](20) NULL,
	[UpdatedOn] [datetimeoffset](7) NULL,
	[Vega] [float] NOT NULL,
	[Volume] [bigint] NOT NULL,
	[Weekly] [float] NOT NULL,
 CONSTRAINT [PK_OptionPrices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [trading].[OptionPrices]    Script Date: 12/31/2020 9:15:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trading].[OptionPrices](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[StrikePrice] [float] NOT NULL,
	[ExpireDate] [datetimeoffset](7) NOT NULL,
	[Direction] [int] NOT NULL,
	[ActiveLevel] [bigint] NOT NULL,
	[AskPrice] [float] NULL,
	[AskVolume] [bigint] NULL,
	[BatchId] [uniqueidentifier] NOT NULL,
	[BidPrice] [float] NULL,
	[BidVolume] [bigint] NULL,
	[Change] [float] NOT NULL,
	[ChangeRatio] [float] NOT NULL,
	[Close] [float] NOT NULL,
	[Delta] [float] NOT NULL,
	[Gamma] [float] NOT NULL,
	[High] [float] NOT NULL,
	[ImpVol] [float] NOT NULL,
	[Low] [float] NOT NULL,
	[Open] [float] NOT NULL,
	[OpenIntChange] [bigint] NOT NULL,
	[OpenInterest] [bigint] NOT NULL,
	[PreClose] [float] NOT NULL,
	[QuoteMultiplier] [float] NOT NULL,
	[Rho] [float] NOT NULL,
	[SpotPrice] [float] NOT NULL,
	[Theta] [float] NOT NULL,
	[TickerId] [bigint] NOT NULL,
	[UnSymbol] [nvarchar](20) NULL,
	[UpdatedOn] [datetimeoffset](7) NULL,
	[Vega] [float] NOT NULL,
	[Volume] [bigint] NOT NULL,
	[Weekly] [float] NOT NULL,
 CONSTRAINT [PK_OptionPrices2021] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [trading].[vOptionPrices]    Script Date: 12/31/2020 9:15:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE             VIEW [trading].[vOptionPrices] AS
SELECT *
, ([AskPrice] + [BidPrice]) / 2 [MidPrice]
--, [Close] [LastPrice]
, CONVERT(DATE, EXPIREDATE) [ExpireDateShort]
, CONVERT(DATE, UpdatedOn) [UpdatedOnShort]
, Slide = CASE
WHEN [Direction] BETWEEN 1 AND 2 THEN 'Call' 
WHEN [Direction] BETWEEN 3 AND 4 THEN 'Put' 
ELSE NULL END,
[BreakEven] = CASE
WHEN [Direction] BETWEEN 1 AND 2 THEN [Close] + [StrikePrice]
WHEN [Direction] BETWEEN 3 AND 4 THEN [Close] - [StrikePrice]
ELSE NULL END,
[IntrinsicValue] = CASE
WHEN [Direction] BETWEEN 1 AND 2 AND [SpotPrice] >= [StrikePrice] THEN [SpotPrice] - [StrikePrice]
WHEN [Direction] BETWEEN 3 AND 4 AND [SpotPrice] <= [StrikePrice] THEN [SpotPrice] - [StrikePrice]
ELSE 0 END
FROM [trading].[OptionPrices2020] WHERE [ExpireDate] >= GETDATE()


UNION


SELECT *
, ([AskPrice] + [BidPrice]) / 2 [MidPrice]
--, [Close] [LastPrice]
, CONVERT(DATE, EXPIREDATE) [ExpireDateShort]
, CONVERT(DATE, UpdatedOn) [UpdatedOnShort]
, Slide = CASE
WHEN [Direction] BETWEEN 1 AND 2 THEN 'Call' 
WHEN [Direction] BETWEEN 3 AND 4 THEN 'Put' 
ELSE NULL END,
[BreakEven] = CASE
WHEN [Direction] BETWEEN 1 AND 2 THEN [Close] + [StrikePrice]
WHEN [Direction] BETWEEN 3 AND 4 THEN [Close] - [StrikePrice]
ELSE NULL END,
[IntrinsicValue] = CASE
WHEN [Direction] BETWEEN 1 AND 2 AND [SpotPrice] >= [StrikePrice] THEN [SpotPrice] - [StrikePrice]
WHEN [Direction] BETWEEN 3 AND 4 AND [SpotPrice] <= [StrikePrice] THEN [SpotPrice] - [StrikePrice]
ELSE 0 END
FROM [trading].[OptionPrices] WHERE [ExpireDate] >= GETDATE()
GO
/****** Object:  View [trading].[v_OptionPricesDaily]    Script Date: 12/31/2020 9:15:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE           VIEW [trading].[v_OptionPricesDaily] as
select distinct  
TickerId,
UnSymbol,
StrikePrice,
ExpireDateShort [ExpireDate],
[Direction],
Slide,
Weekly,
CAST(UpdatedOn as date) [UpdatedOnDate],
Avg([ActiveLevel]) [ActiveLevel],
Max(OpenInterest) [OpenInterest],
Max(OpenIntChange) [OpenIntChange],
Max(Change) [Change],
Max(ChangeRatio) [ChangeRatio]

, Max([Volume]) [Volume]
, Avg([SpotPrice]) [SpotPrice]
, Max([PreClose]) [PreClose]
, Max([Open]) [Open]
, Max([Low]) [Low]
, Max([High]) [High]
, Avg([Close]) [Close]
, Avg(MidPrice) [MidPrice]
, Avg([AskPrice]) [AskPrice]
, Avg([BidPrice]) [BidPrice]
, Avg([AskVolume]) [AskVolume]
, Avg([BidVolume]) [BidVolume]
, Max([Close]) - Max([Open]) [OpenClose_Range]
, Max([High]) - Max([Low]) [HighLow_Range]

, Avg(ImpVol) [ImpVol]

, Avg(Delta) [Delta]
, Avg(Gamma) [Gamma]
, Avg(Rho) [Rho]
, Avg(Theta) [Theta]
, Avg(Vega) [Vega]
, Avg([BreakEven]) [BreakEven]
, Avg([IntrinsicValue]) [IntrinsicValue] 
, (Avg([SpotPrice]) - Avg([BreakEven])) / ((Avg([SpotPrice]) + Avg([BreakEven]))/2) * 100.0 [PercDiffBetweenSpotPriceAndBreakEven]
, (Avg([BreakEven]) - Avg([SpotPrice])) / ((Avg([BreakEven]) + Avg([SpotPrice]))/2) * 100.0 [PercDiffBetweenBreakEvenAndSpotPrice]

from trading.vOptionPrices
--where 
--tickerid = 1016770654
--UnSymbol = 'spce' 
--and StrikePrice between 30 and 30 and Direction = 2 
GROUP BY
CAST(UpdatedOn as date),
TickerId,
UnSymbol,
StrikePrice,
ExpireDateShort,
[Direction],
Slide,
Weekly
HAVING Avg(AskPrice) is not null
GO
/****** Object:  Table [trading].[Options]    Script Date: 12/31/2020 9:15:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trading].[Options](
	[UnSymbol] [nvarchar](20) NULL,
	[TickerId] [bigint] NOT NULL,
	[StrikePrice] [float] NOT NULL,
	[ExpireDate] [datetimeoffset](7) NOT NULL,
	[Direction] [int] NOT NULL,
	[FirstSeenOn] [date] NULL,
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Weekly] [bit] NOT NULL,
 CONSTRAINT [PK__Options] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [trading].[vOptions]    Script Date: 12/31/2020 9:15:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE                         
VIEW [trading].[vOptions] AS 
SELECT *
, Slide = CASE 
WHEN [Direction] between 1 and 2 then 'Call'
WHEN [Direction] BETWEEN 3 AND 4 THEN 'Put' 
ELSE NULL END 
FROM trading.Options
WHERE [ExpireDate] >= GETDATE()
--SELECT b.UnSymbol, b.TickerId, a.StrikePrice, a.ExpireDate, a.Direction, b.FirstSeenOn
--FROM trading.vOptions_FirstSeen b 
--JOIN trading.vOptionPrices a on a.TickerId = b.TickerId and a.UnSymbol = b.UnSymbol
----where b.UnSymbol = 'spce' AND a.Direction = 2
--GROUP BY  b.UnSymbol, b.TickerId, a.StrikePrice, a.ExpireDate, a.Direction, b.FirstSeenOn
--UNION 
--SELECT UnSymbol, TickerId, StrikePrice, ExpireDate, Direction, FirstSeenOn
--FROM trading.Options c
----where c.UnSymbol = 'spce' AND c.Direction = 2
----HAVING datediff(day, Min(convert(date, UpdatedOn)), getdate()) < 8
----ORDER BY [FirstSeenOnNumberOfDays] DESC
----ORDER BY TickerId
GO
/****** Object:  View [trading].[vOptions_FirstSeen]    Script Date: 12/31/2020 9:15:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE         view [trading].[vOptions_FirstSeen] as 
SELECT DISTINCT UnSymbol, TickerId, Min(UpdatedOnShort) FirstSeenOn
FROM trading.vOptionPrices
--where UnSymbol = 'spce' AND Direction = 2
GROUP BY UnSymbol, TickerId
--order by TickerId desc
GO
/****** Object:  View [trading].[vOptions_tmp_union]    Script Date: 12/31/2020 9:15:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO










CREATE                 view [trading].[vOptions_tmp_union] as 
SELECT b.UnSymbol, b.TickerId, a.StrikePrice, a.ExpireDate, a.Direction, b.FirstSeenOn, NULL [Id]
FROM trading.vOptions_FirstSeen b 
JOIN trading.vOptionPrices a on a.TickerId = b.TickerId and a.UnSymbol = b.UnSymbol
--where b.UnSymbol = 'spce' AND a.Direction = 2
GROUP BY  b.UnSymbol, b.TickerId, a.StrikePrice, a.ExpireDate, a.Direction, b.FirstSeenOn
UNION 
SELECT UnSymbol, TickerId, StrikePrice, ExpireDate, Direction, FirstSeenOn, c.Id
FROM trading.Options c
--where c.UnSymbol = 'spce' AND c.Direction = 2
--HAVING datediff(day, Min(convert(date, UpdatedOn)), getdate()) < 8
--ORDER BY [FirstSeenOnNumberOfDays] DESC
--ORDER BY TickerId
GO
/****** Object:  View [trading].[vOptions_tmp_union_savedForScript]    Script Date: 12/31/2020 9:15:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO










CREATE                 view [trading].[vOptions_tmp_union_savedForScript] as 
SELECT DISTINCT b.UnSymbol, b.TickerId
--, a.StrikePrice, a.ExpireDate, a.Direction
, b.FirstSeenOn
FROM trading.vOptions_FirstSeen b 
--JOIN trading.vOptionPrices a on a.TickerId = b.TickerId and a.UnSymbol = b.UnSymbol
--where b.UnSymbol = 'spce' 
--WHERE FIRSTSEENON >= GETDATE() - 8
--AND UnSymbol = 'SPCE'
--AND a.Direction = 2
--GROUP BY  b.UnSymbol, b.TickerId
--, a.StrikePrice, a.ExpireDate, a.Direction
--, b.FirstSeenOn
--UNION 
--SELECT UnSymbol, TickerId, StrikePrice, ExpireDate, Direction, FirstSeenOn, c.Id
--FROM trading.Options c
--where c.UnSymbol = 'spce' AND c.Direction = 2
--HAVING datediff(day, Min(convert(date, UpdatedOn)), getdate()) < 8
--ORDER BY [FirstSeenOnNumberOfDays] DESC
GO
/****** Object:  View [trading].[vOptionPrices_SummaryByBatchDay]    Script Date: 12/31/2020 9:15:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE     VIEW [trading].[vOptionPrices_SummaryByBatchDay] as
select distinct  
TickerId,
UnSymbol,
StrikePrice,
ExpireDateShort [ExpireDate],
Direction,
--'call' [Slide], 
CAST(UpdatedOn as date) [UpdatedOn]
, Avg([SpotPrice]) [SpotPrice]
, Avg([Close]) [AvgClose]
, PreClose
, Max([Open]) [Open]
, Max([High]) [High]
, Max([Low]) [Low]
--, Avg([Close]) [AvgClose]
, Avg([AskPrice]) [AvgAskPrice]
, Avg([BidPrice]) [AvgBidPrice]
, Max([Close]) - Max([Open]) [OpenClose_Range]
, Max([High]) - Max([Low]) [HighLow_Range]
from trading.vOptionPrices
--where 
--UnSymbol = 'spce' 
----and StrikePrice between 30 and 30 and Direction = 2 
--and tickerid = 1017536959
GROUP BY
TickerId,
UnSymbol,
StrikePrice,
ExpireDateShort,
Direction,
PreClose,
CAST(UpdatedOn as date)
--order by UpdatedOn desc

HAVING Avg(AskPrice) is not null

GO
/****** Object:  View [trading].[vOptionPrices_ChartDatas]    Script Date: 12/31/2020 9:15:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE     VIEW [trading].[vOptionPrices_ChartDatas] as
SELECT UnSymbol, TickerId, ExpireDate, UpdatedOn, SpotPrice, AvgClose, PreClose, [Open], [High], [Low], AvgAskPrice, AvgBidPrice, OpenClose_Range, HighLow_Range
FROM trading.vOptionPrices_SummaryByBatchDay
GO
/****** Object:  View [trading].[vOptions_BySlide_ActiveCount]    Script Date: 12/31/2020 9:15:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   VIEW [trading].[vOptions_BySlide_ActiveCount] AS
SELECT UnSymbol, Direction, count(*) [ActiveOptionsCount]
  FROM [alltdl_lewisfam1].[trading].[vOptions]
  GROUP BY UnSymbol, Direction
GO
/****** Object:  View [trading].[vOptionPrices_LastBatch]    Script Date: 12/31/2020 9:15:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE   VIEW [trading].[vOptionPrices_LastBatch] as
select top 1
BatchId, Id
, [UpdatedOnShort]
from trading.vOptionPrices
order by Id desc
GO
/****** Object:  View [trading].[vOptionPrices_Slim]    Script Date: 12/31/2020 9:15:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE   VIEW [trading].[vOptionPrices_Slim] AS 
select --top 100
Id, TickerId, SpotPrice, UnSymbol 
--StrikePrice
--, CONVERT(DATE, EXPIREDATE) [ExpireDateShort]
--, [ExpireDate]
--, Slide
, AskPrice, BidPrice
, MidPrice
, [Close] [LastPrice], [Open], [High], Low, Volume, UpdatedOn
from trading.vOptionPrices
--where UnSymbol = 'spce' and direction = 2 and StrikePrice between 24 and 24
--order by UpdatedOn desc
GO
/****** Object:  View [trading].[vOptionPrices_All]    Script Date: 12/31/2020 9:15:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE   VIEW [trading].[vOptionPrices_All] as
SELECT *
, ([AskPrice] + [BidPrice]) / 2 [MidPrice]
  FROM [trading].[OptionPrices]  
GO
/****** Object:  View [trading].[vOptionPrices_TotalRecordsByUpdatedOn]    Script Date: 12/31/2020 9:15:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [trading].[vOptionPrices_TotalRecordsByUpdatedOn] AS
SELECT CONVERT(DATE, UpdatedOn) [UpdatedOn], count(*) [TotalRecords]
  FROM [alltdl_lewisfam1].[trading].[OptionPrices]
  GROUP BY CONVERT(DATE, UpdatedOn) 
GO
/****** Object:  View [trading].[vOptionPrices_TotalRecordsByOption]    Script Date: 12/31/2020 9:15:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [trading].[vOptionPrices_TotalRecordsByOption] AS
SELECT [TickerId], [UnSymbol], count(*) [TotalRecords]
  FROM [alltdl_lewisfam1].[trading].[OptionPrices]
  GROUP BY [TickerId], [UnSymbol]  
GO
/****** Object:  Table [trading].[OptionWatchListItems]    Script Date: 12/31/2020 9:15:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trading].[OptionWatchListItems](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Symbol] [nvarchar](max) NULL,
	[Direction] [int] NOT NULL,
	[StrikePrice] [float] NOT NULL,
	[ExpireDate] [datetimeoffset](7) NOT NULL,
	[TickerId] [bigint] NOT NULL,
 CONSTRAINT [PK_OptionWatchListItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [trading].[vOptionWatchlistItem_Datas]    Script Date: 12/31/2020 9:15:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE   VIEW [trading].[vOptionWatchlistItem_Datas] as
SELECT a.[Id] [WatchlistItemId]      
	  ,b.*
  FROM [alltdl_lewisfam1].[trading].[OptionWatchListItems] a
  JOIN trading.vOptionPrices b on a.TickerId = b.TickerId and a.Symbol = b.UnSymbol
  --WHERE a.TickerId = 1017536959 --this id may be invalid as time passes.
  --ORDER BY TickerId
GO
/****** Object:  Table [alltdl_daddy].[__EFMigrationsHistory]    Script Date: 12/31/2020 9:15:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [alltdl_daddy].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [security].[RoleClaims]    Script Date: 12/31/2020 9:15:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [security].[RoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_RoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [security].[Roles]    Script Date: 12/31/2020 9:15:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [security].[Roles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [security].[UserClaims]    Script Date: 12/31/2020 9:15:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [security].[UserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [security].[UserLogins]    Script Date: 12/31/2020 9:15:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [security].[UserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_UserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [security].[Users]    Script Date: 12/31/2020 9:15:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [security].[Users](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [security].[UsersRoles]    Script Date: 12/31/2020 9:15:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [security].[UsersRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_UsersRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [security].[UserTokens]    Script Date: 12/31/2020 9:15:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [security].[UserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [todo].[ToDo]    Script Date: 12/31/2020 9:15:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [todo].[ToDo](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[ParentId] [uniqueidentifier] NULL,
	[IsCompleted] [bit] NOT NULL,
	[CompletedOnDate] [datetimeoffset](7) NULL,
	[Inactive] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [todo].[ToDoItems]    Script Date: 12/31/2020 9:15:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [todo].[ToDoItems](
	[Id] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](255) NULL,
	[Status] [nvarchar](55) NULL,
	[Inactive] [bit] NOT NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[LastUpdatedOn] [datetimeoffset](7) NOT NULL,
	[CompletedOn] [datetimeoffset](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [trading].[Notes]    Script Date: 12/31/2020 9:15:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trading].[Notes](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UnSymbol] [nvarchar](20) NOT NULL,
	[NoteType] [int] NULL,
	[Note] [nvarchar](1) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[Inactive] [bit] NULL,
 CONSTRAINT [PK_Notes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [trading].[OptionPricesDaily]    Script Date: 12/31/2020 9:15:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trading].[OptionPricesDaily](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[TickerId] [bigint] NOT NULL,
	[UnSymbol] [nvarchar](20) NULL,
	[StrikePrice] [float] NOT NULL,
	[ExpireDate] [date] NULL,
	[Direction] [int] NOT NULL,
	[Slide] [varchar](4) NULL,
	[OpenInterest] [bigint] NOT NULL,
	[OpenIntChange] [bigint] NOT NULL,
	[Change] [float] NOT NULL,
	[ChangeRatio] [float] NOT NULL,
	[Weekly] [float] NOT NULL,
	[UpdatedOn] [date] NULL,
	[Volume] [bigint] NULL,
	[SpotPrice] [float] NULL,
	[PreClose] [float] NULL,
	[Open] [float] NULL,
	[Low] [float] NULL,
	[High] [float] NULL,
	[Close] [float] NULL,
	[MidPrice] [float] NULL,
	[AskPrice] [float] NULL,
	[BidPrice] [float] NULL,
	[AskVolume] [bigint] NULL,
	[BidVolume] [bigint] NULL,
	[OpenClose_Range] [float] NULL,
	[HighLow_Range] [float] NULL,
	[ImpVol] [float] NULL,
	[Delta] [float] NULL,
	[Gamma] [float] NULL,
	[Rho] [float] NULL,
	[Theta] [float] NULL,
	[Vega] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [trading].[Tickers]    Script Date: 12/31/2020 9:15:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trading].[Tickers](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Symbol] [nvarchar](10) NOT NULL,
	[TickerId] [bigint] NOT NULL,
 CONSTRAINT [PK_Tickers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [trading].[Transactions]    Script Date: 12/31/2020 9:15:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trading].[Transactions](
	[Id] [uniqueidentifier] NOT NULL,
	[OptionId] [bigint] NOT NULL,
	[BuySell_Slide] [int] NOT NULL,
	[OpenClose_Slide] [int] NOT NULL,
	[Qty] [float] NOT NULL,
	[Price] [float] NOT NULL,
	[VendorId] [int] NOT NULL,
	[Note] [nvarchar](max) NULL,
	[TimeStamp] [datetimeoffset](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [trading].[TransactionsDev]    Script Date: 12/31/2020 9:15:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trading].[TransactionsDev](
	[Id] [uniqueidentifier] NOT NULL,
	[OptionId] [bigint] NULL,
	[BuySell_Slide] [int] NOT NULL,
	[OpenClose_Slide] [int] NOT NULL,
	[Qty] [float] NULL,
	[Price] [float] NULL,
	[VendorId] [int] NOT NULL,
	[Note] [nvarchar](255) NULL,
	[TimeStamp] [datetimeoffset](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RoleClaims_RoleId]    Script Date: 12/31/2020 9:15:29 PM ******/
CREATE NONCLUSTERED INDEX [IX_RoleClaims_RoleId] ON [security].[RoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 12/31/2020 9:15:29 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [security].[Roles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserClaims_UserId]    Script Date: 12/31/2020 9:15:29 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserClaims_UserId] ON [security].[UserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserLogins_UserId]    Script Date: 12/31/2020 9:15:29 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserLogins_UserId] ON [security].[UserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 12/31/2020 9:15:29 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [security].[Users]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 12/31/2020 9:15:29 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [security].[Users]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UsersRoles_RoleId]    Script Date: 12/31/2020 9:15:29 PM ******/
CREATE NONCLUSTERED INDEX [IX_UsersRoles_RoleId] ON [security].[UsersRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [x_OptionPrices2021]    Script Date: 12/31/2020 9:15:29 PM ******/
CREATE NONCLUSTERED INDEX [x_OptionPrices2021] ON [trading].[OptionPrices]
(
	[UnSymbol] ASC,
	[TickerId] ASC,
	[UpdatedOn] DESC
)
INCLUDE([StrikePrice],[ExpireDate],[Direction]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [x_OptionPrices2021_a]    Script Date: 12/31/2020 9:15:29 PM ******/
CREATE NONCLUSTERED INDEX [x_OptionPrices2021_a] ON [trading].[OptionPrices]
(
	[TickerId] ASC,
	[UnSymbol] ASC
)
INCLUDE([BatchId],[UpdatedOn],[Id]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [x_Options2021]    Script Date: 12/31/2020 9:15:29 PM ******/
CREATE NONCLUSTERED INDEX [x_Options2021] ON [trading].[OptionPrices]
(
	[UnSymbol] ASC,
	[TickerId] ASC
)
INCLUDE([StrikePrice],[ExpireDate],[Direction]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [x_OptionPrices]    Script Date: 12/31/2020 9:15:29 PM ******/
CREATE NONCLUSTERED INDEX [x_OptionPrices] ON [trading].[OptionPrices2020]
(
	[UnSymbol] ASC,
	[TickerId] ASC,
	[UpdatedOn] DESC
)
INCLUDE([StrikePrice],[ExpireDate],[Direction]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [x_OptionPrices_a]    Script Date: 12/31/2020 9:15:29 PM ******/
CREATE NONCLUSTERED INDEX [x_OptionPrices_a] ON [trading].[OptionPrices2020]
(
	[TickerId] ASC,
	[UnSymbol] ASC
)
INCLUDE([BatchId],[UpdatedOn],[Id]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [x_Options]    Script Date: 12/31/2020 9:15:29 PM ******/
CREATE NONCLUSTERED INDEX [x_Options] ON [trading].[OptionPrices2020]
(
	[UnSymbol] ASC,
	[TickerId] ASC
)
INCLUDE([StrikePrice],[ExpireDate],[Direction]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [xu_Option]    Script Date: 12/31/2020 9:15:29 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [xu_Option] ON [trading].[Options]
(
	[UnSymbol] ASC,
	[TickerId] ASC,
	[StrikePrice] ASC,
	[ExpireDate] ASC,
	[Direction] ASC
)
INCLUDE([FirstSeenOn]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [todo].[ToDo] ADD  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [todo].[ToDo] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [todo].[ToDo] ADD  DEFAULT ((0)) FOR [IsCompleted]
GO
ALTER TABLE [todo].[ToDo] ADD  DEFAULT ((0)) FOR [Inactive]
GO
ALTER TABLE [todo].[ToDoItems] ADD  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [todo].[ToDoItems] ADD  DEFAULT ((0)) FOR [Inactive]
GO
ALTER TABLE [todo].[ToDoItems] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [todo].[ToDoItems] ADD  DEFAULT (getdate()) FOR [LastUpdatedOn]
GO
ALTER TABLE [todo].[ToDoItems] ADD  DEFAULT (getdate()) FOR [CompletedOn]
GO
ALTER TABLE [trading].[Notes] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [trading].[Transactions] ADD  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [trading].[Transactions] ADD  DEFAULT (getdate()) FOR [TimeStamp]
GO
ALTER TABLE [trading].[TransactionsDev] ADD  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [trading].[TransactionsDev] ADD  DEFAULT (getdate()) FOR [TimeStamp]
GO
ALTER TABLE [security].[RoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_RoleClaims_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [security].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [security].[RoleClaims] CHECK CONSTRAINT [FK_RoleClaims_Roles_RoleId]
GO
ALTER TABLE [security].[UserClaims]  WITH CHECK ADD  CONSTRAINT [FK_UserClaims_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [security].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [security].[UserClaims] CHECK CONSTRAINT [FK_UserClaims_Users_UserId]
GO
ALTER TABLE [security].[UserLogins]  WITH CHECK ADD  CONSTRAINT [FK_UserLogins_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [security].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [security].[UserLogins] CHECK CONSTRAINT [FK_UserLogins_Users_UserId]
GO
ALTER TABLE [security].[UsersRoles]  WITH CHECK ADD  CONSTRAINT [FK_UsersRoles_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [security].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [security].[UsersRoles] CHECK CONSTRAINT [FK_UsersRoles_Roles_RoleId]
GO
ALTER TABLE [security].[UsersRoles]  WITH CHECK ADD  CONSTRAINT [FK_UsersRoles_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [security].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [security].[UsersRoles] CHECK CONSTRAINT [FK_UsersRoles_Users_UserId]
GO
ALTER TABLE [security].[UserTokens]  WITH CHECK ADD  CONSTRAINT [FK_UserTokens_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [security].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [security].[UserTokens] CHECK CONSTRAINT [FK_UserTokens_Users_UserId]
GO
ALTER TABLE [trading].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_OptionId] FOREIGN KEY([OptionId])
REFERENCES [trading].[Options] ([Id])
GO
ALTER TABLE [trading].[Transactions] CHECK CONSTRAINT [FK_OptionId]
GO
ALTER TABLE [trading].[TransactionsDev]  WITH CHECK ADD  CONSTRAINT [FK_OptionIdDev] FOREIGN KEY([OptionId])
REFERENCES [trading].[Options] ([Id])
GO
ALTER TABLE [trading].[TransactionsDev] CHECK CONSTRAINT [FK_OptionIdDev]
GO
/****** Object:  StoredProcedure [trading].[InsertFirstSeenOptions]    Script Date: 12/31/2020 9:15:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [trading].[InsertFirstSeenOptions] AS
INSERT INTO trading.vOptions (UnSymbol, TickerId, StrikePrice, [ExpireDate], Direction, FirstSeenOn, Weekly)
SELECT DISTINCT fs.[UnSymbol]
      ,fs.[TickerId]      
	  ,op.StrikePrice
	  ,op.ExpireDate
	  ,op.Direction
	  ,fs.FirstSeenOn
	  ,op.Weekly	  
	  --, o.Id
  FROM [alltdl_lewisfam1].[trading].[vOptions_FirstSeen] fs 
  INNER JOIN [trading].[vOptionPrices] op on op.TickerId = fs.TickerId and op.UnSymbol = fs.UnSymbol  
  LEFT JOIN [trading].[vOptions] o on o.TickerId = op.TickerId
  --WHERE o.UnSymbol = 'VRNT'
  --where 
  --fs.UnSymbol = 'vrnt'
  --WHERE op.UnSymbol = 'vrnt'
  WHERE o.Id IS NULL --AND fs.FirstSeenOn >= GETDATE() - 5
  --AND o.Weekly IS NOT NULL
GO
USE [master]
GO
ALTER DATABASE [alltdl_lewisfam1] SET  READ_WRITE 
GO
