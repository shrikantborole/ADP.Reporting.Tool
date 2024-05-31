USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[GetSqlFileDataById]    Script Date: 05/30/2024 08:43:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetSqlFileDataById]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetSqlFileDataById]
GO

USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[GetSqlFileDataById]    Script Date: 05/30/2024 08:43:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetSqlFileDataById]
    @Id INT
AS
BEGIN
    SELECT * FROM [dbo].[SqlFileData]
    WHERE [Id] = @Id;
END

GO


