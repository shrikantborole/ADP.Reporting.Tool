USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[InsertSqlFileData]    Script Date: 05/30/2024 08:44:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertSqlFileData]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[InsertSqlFileData]
GO

USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[InsertSqlFileData]    Script Date: 05/30/2024 08:44:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertSqlFileData]
    @RequestId INT,
    @Description NVARCHAR(500) = NULL,
    @SqlFileData NVARCHAR(MAX),
    @CreatedDate DATE = NULL,
    @UpdatedDate DATE = NULL,
    @CreatedBy DATETIME = NULL,
    @UpdatedBy DATETIME = NULL
AS
BEGIN
    INSERT INTO [dbo].[SqlFileData] ([RequestId], [Description], [SqlFileData], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy])
    VALUES (@RequestId, @Description, @SqlFileData, @CreatedDate, @UpdatedDate, @CreatedBy, @UpdatedBy);
END

GO


