USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[DeleteAlphabet]    Script Date: 05/30/2024 08:38:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteAlphabet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DeleteAlphabet]
GO

USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[DeleteAlphabet]    Script Date: 05/30/2024 08:38:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteAlphabet]
    @Id INT
AS
BEGIN
    DELETE FROM [dbo].[Alphabet]
    WHERE [Id] = @Id;
END

GO


