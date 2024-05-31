USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[UpdateSqlFileData]    Script Date: 05/30/2024 08:45:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateSqlFileData]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UpdateSqlFileData]
GO

USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[UpdateSqlFileData]    Script Date: 05/30/2024 08:45:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateSqlFileData]
    @Id INT,
    @RequestId INT,
    @Description NVARCHAR(500) = NULL,
    @SqlFileData NVARCHAR(MAX),
    @UpdatedDate DATE = NULL,
    @UpdatedBy DATETIME = NULL
AS
BEGIN
    UPDATE [dbo].[SqlFileData]
    SET [RequestId] = @RequestId,
        [Description] = @Description,
        [SqlFileData] = @SqlFileData,
        [UpdatedDate] = @UpdatedDate,
        [UpdatedBy] = @UpdatedBy
    WHERE [Id] = @Id;
END

GO


