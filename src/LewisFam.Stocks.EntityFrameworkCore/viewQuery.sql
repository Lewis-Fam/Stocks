

DROP VIEW [trading].[vOptionPrices]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create view [trading].[vOptionPrices] as (select *, CONVERT(DATE, EXPIREDATE) [ExpireDateShort] from trading.OptionPrices where ExpireDate > GETDATE() - 3)
GO
