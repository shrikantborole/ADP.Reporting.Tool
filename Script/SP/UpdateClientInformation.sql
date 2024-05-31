USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[UpdateClientInformation]    Script Date: 05/30/2024 08:44:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateClientInformation]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UpdateClientInformation]
GO

USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[UpdateClientInformation]    Script Date: 05/30/2024 08:44:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateClientInformation]
    @Id INT,
    @AlphabetId INT,
    @Name NVARCHAR(200),
    @Description NVARCHAR(500) = NULL,
    @UpdatedDate DATETIME,
    @UpdateBy NVARCHAR(100) = NULL
AS
BEGIN
    UPDATE [dbo].[ClientInformation]
    SET [AlphabetId] = @AlphabetId,
        [Name] = @Name,
        [Description] = @Description,
        [UpdatedDate] = @UpdatedDate,
        [UpdateBy] = @UpdateBy
    WHERE [Id] = @Id;
END

GO


