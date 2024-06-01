USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[UpdateReportType]    Script Date: 05/30/2024 08:44:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateReportType]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UpdateReportType]
GO

USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[UpdateReportType]    Script Date: 05/30/2024 08:44:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateReportType]
    @Id INT,
    @ClientId INT = NULL,
    @Type NVARCHAR(200) = NULL,
    @Description NVARCHAR(500) = NULL,
    @UpdatedDate DATETIME = NULL,
    @UpdatedBy NVARCHAR(100) = NULL
AS
BEGIN
    UPDATE [dbo].[ReportType]
    SET [ClientId] = @ClientId,
        [Type] = @Type,
        [Description] = @Description,
        [UpdatedDate] = @UpdatedDate,
        [UpdatedBy] = @UpdatedBy
    WHERE [Id] = @Id;
END

GO


