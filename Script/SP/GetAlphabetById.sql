USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[GetAlphabetById]    Script Date: 05/30/2024 08:41:24 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAlphabetById]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetAlphabetById]
GO

USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[GetAlphabetById]    Script Date: 05/30/2024 08:41:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAlphabetById]
    @Id INT
AS
BEGIN
    SELECT * FROM [dbo].[Alphabet] WITH(NOLOCK)
    WHERE [Id] = @Id;
END

GO


