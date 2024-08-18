USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[UpdateSqlFileData]    Script Date: 05/30/2024 08:45:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpSertSqlFileData]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UpSertSqlFileData]
GO

USE [Explore.ADP.Report]
GO

CREATE PROCEDURE UpSertSqlFileData  
    @RequestId INT,  
    @Description NVARCHAR(500) = NULL,  
    @SqlFileData NVARCHAR(MAX),  
    @CreatedDate DATE = NULL,  
    @UpdatedDate DATE = NULL,  
    @CreatedBy NVARCHAR(100) = NULL,  
    @UpdatedBy NVARCHAR(100) = NULL  
AS  
BEGIN 
    IF NOT EXISTS (SELECT 1 FROM  [dbo].[SqlFileData] WHERE RequestId = @RequestId)
    BEGIN 
		INSERT INTO [dbo].[SqlFileData] ([RequestId], [Description], [SqlFileData], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy])  
		VALUES (@RequestId, @Description, @SqlFileData, @CreatedDate, @UpdatedDate, @CreatedBy, @UpdatedBy);  
	    DECLARE @Id AS INT = (SELECT Scope_identity())
	    EXEC GetSqlFileDataById @Id
    END
    ELSE
    BEGIN 
       EXEC GetSqlFileDataById @RequestId
    END 
END  