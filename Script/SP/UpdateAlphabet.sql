USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[UpdateAlphabet]    Script Date: 05/30/2024 08:44:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateAlphabet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UpdateAlphabet]
GO

USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[UpdateAlphabet]    Script Date: 05/30/2024 08:44:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateAlphabet]
    @Id INT,
    @Alphabet NVARCHAR(50),
    @UpdatedDate DATETIME,
    @UpdateBy NVARCHAR(100) = NULL,
    @Description NVARCHAR(500) = NULL
AS
BEGIN
    UPDATE [dbo].[Alphabet]
    SET [Alphabet] = @Alphabet,
        [UpdatedDate] = @UpdatedDate,
        [UpdateBy] = @UpdateBy,
        [Description] = @Description
    WHERE [Id] = @Id;
END

GO


