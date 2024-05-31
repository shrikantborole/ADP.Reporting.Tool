USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[InsertReportType]    Script Date: 05/30/2024 08:43:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertReportType]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[InsertReportType]
GO

USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[InsertReportType]    Script Date: 05/30/2024 08:43:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertReportType]
    @ClientId INT = NULL,
    @Type NVARCHAR(200) = NULL,
    @Description NVARCHAR(500) = NULL,
    @CreatedDate DATETIME = NULL,
    @UpdatedDate DATETIME = NULL,
    @CreatedBy NVARCHAR(100) = NULL,
    @UpdateBy NVARCHAR(100) = NULL
AS
BEGIN
    INSERT INTO [dbo].[ReportType] ([ClientId], [Type], [Description], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdateBy])
    VALUES (@ClientId, @Type, @Description, @CreatedDate, @UpdatedDate, @CreatedBy, @UpdateBy);
END

GO


