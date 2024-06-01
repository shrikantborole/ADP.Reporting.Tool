USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[InsertClientInformation]    Script Date: 05/30/2024 08:43:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertClientInformation]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[InsertClientInformation]
GO

USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[InsertClientInformation]    Script Date: 05/30/2024 08:43:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertClientInformation]
    @AlphabetId INT,
    @Name NVARCHAR(200),
    @Description NVARCHAR(500) = NULL,
    @CreatedDate DATETIME,
    @UpdatedDate DATETIME,
    @CreatedBy NVARCHAR(100) = NULL,
    @UpdatedBy NVARCHAR(100) = NULL
AS
BEGIN
    INSERT INTO [dbo].[ClientInformation] ([AlphabetId], [Name], [Description], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy])
    VALUES (@AlphabetId, @Name, @Description, @CreatedDate, @UpdatedDate, @CreatedBy, @UpdatedBy);
END

GO


