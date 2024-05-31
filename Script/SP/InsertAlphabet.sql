USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[InsertAlphabet]    Script Date: 05/30/2024 08:43:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertAlphabet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[InsertAlphabet]
GO

USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[InsertAlphabet]    Script Date: 05/30/2024 08:43:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertAlphabet]  
    @Alphabet NVARCHAR(50),  
    @CreatedDate DATETIME,  
    @UpdatedDate DATETIME,  
    @CreatedBy NVARCHAR(100) = NULL,  
    @UpdatedBy NVARCHAR(100) = NULL,  
    @Description NVARCHAR(500) = NULL  
AS  
BEGIN  
    INSERT INTO [dbo].[Alphabet] ([Alphabet], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdateBy], [Description])  
    VALUES (@Alphabet, @CreatedDate, @UpdatedDate, @CreatedBy, @UpdatedBy, @Description);  
    
    SELECT Id, Alphabet as 'Name', CreatedDate, UpdatedDate, CreatedBy, UpdateBy, Description FROM [dbo].[Alphabet] 
    WHERE ID = (SELECT SCOPE_IDENTITY())
END

GO


