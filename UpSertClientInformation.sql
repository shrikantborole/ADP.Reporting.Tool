USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[UpdateSqlFileData]    Script Date: 05/30/2024 08:45:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpSertClientInformation]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].UpSertClientInformation
GO

USE [Explore.ADP.Report]
GO
CREATE PROCEDURE [dbo].[UpSertClientInformation]      
    @AlphabetId INT,      
    @Name NVARCHAR(200),      
    @Description NVARCHAR(500) = NULL,      
    @CreatedDate DATETIME,      
    @UpdatedDate DATETIME,      
    @CreatedBy NVARCHAR(100) = NULL,      
    @UpdatedBy NVARCHAR(100) = NULL      
AS      
BEGIN      
 IF NOT EXISTS(SELECT 1 FROM ClientInformation WHERE UPPER(Name) = UPPER(@Name) AND AlphabetId = @AlphabetId)    
 BEGIN    
	  INSERT INTO [dbo].[ClientInformation] ([AlphabetId], [Name], [Description], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy])  
	  VALUES (@AlphabetId, @Name, @Description, @CreatedDate, @UpdatedDate, @CreatedBy, @UpdatedBy);  
	  DECLARE @Id AS INT = (SELECT Scope_identity())    
	  EXEC GetClientInformationById @Id    
 END     
 ELSE    
 BEGIN    
	  SELECT Id,  
	  AlphabetId,  
	  Name,  
	  Description,  
	  CreatedDate,  
	  UpdatedDate,  
	  CreatedBy,  
	  UpdatedBy  
	  FROM [dbo].[ClientInformation]    
	  WHERE UPPER([NAME]) = UPPER(@Name)AND AlphabetId = @AlphabetId  
 END    
END