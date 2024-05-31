USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[DeleteSqlFileData]    Script Date: 05/30/2024 08:39:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteSqlFileData]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DeleteSqlFileData]
GO

USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[DeleteSqlFileData]    Script Date: 05/30/2024 08:39:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteSqlFileData]
    @Id INT
AS
BEGIN
    DELETE FROM [dbo].[SqlFileData]
    WHERE [Id] = @Id;
END

GO


