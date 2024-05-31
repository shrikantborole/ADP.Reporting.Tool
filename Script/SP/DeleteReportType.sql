USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[DeleteReportType]    Script Date: 05/30/2024 08:39:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteReportType]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DeleteReportType]
GO

USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[DeleteReportType]    Script Date: 05/30/2024 08:39:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteReportType]
    @Id INT
AS
BEGIN
    DELETE FROM [dbo].[ReportType]
    WHERE [Id] = @Id;
END

GO


