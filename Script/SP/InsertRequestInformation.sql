USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[InsertRequestInformation]    Script Date: 05/30/2024 08:44:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertRequestInformation]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[InsertRequestInformation]
GO

USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[InsertRequestInformation]    Script Date: 05/30/2024 08:44:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertRequestInformation]
    @ClientId INT,
    @RequestType NVARCHAR(200) = NULL,
    @Description NVARCHAR(1000) = NULL,
    @CreatedDate DATETIME = NULL,
    @UpdatedDate DATETIME = NULL,
    @CreatedBy NVARCHAR(200) = NULL,
    @UpdatedBy NVARCHAR(200) = NULL,
    @ReportId INT
AS
BEGIN
    INSERT INTO [dbo].[RequestInformation] ([ClientId], [RequestType], [Description], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy], [ReportId])
    VALUES (@ClientId, @RequestType, @Description, @CreatedDate, @UpdatedDate, @CreatedBy, @UpdatedBy, @ReportId);
END

GO


