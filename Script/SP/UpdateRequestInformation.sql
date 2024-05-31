USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[UpdateRequestInformation]    Script Date: 05/30/2024 08:45:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateRequestInformation]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UpdateRequestInformation]
GO

USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[UpdateRequestInformation]    Script Date: 05/30/2024 08:45:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateRequestInformation]
    @Id INT,
    @ClientId INT,
    @RequestType NVARCHAR(200) = NULL,
    @Description NVARCHAR(1000) = NULL,
    @UpdatedDate DATETIME = NULL,
    @UpdateBy NVARCHAR(200) = NULL,
    @ReportId INT
AS
BEGIN
    UPDATE [dbo].[RequestInformation]
    SET [ClientId] = @ClientId,
        [RequestType] = @RequestType,
        [Description] = @Description,
        [UpdatedDate] = @UpdatedDate,
        [UpdateBy] = @UpdateBy,
        [ReportId] = @ReportId
    WHERE [Id] = @Id;
END

GO


