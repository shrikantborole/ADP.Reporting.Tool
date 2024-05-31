USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[GetReportTypeById]    Script Date: 05/30/2024 08:42:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetReportTypeById]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetReportTypeById]
GO

USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[GetReportTypeById]    Script Date: 05/30/2024 08:42:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetReportTypeById]
    @Id INT
AS
BEGIN
    SELECT * FROM [dbo].[ReportType]
    WHERE [Id] = @Id;
END

GO


