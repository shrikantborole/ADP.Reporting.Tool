USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[UpdateSqlFileData]    Script Date: 05/30/2024 08:45:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpSertReportType]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UpSertReportType]
GO

USE [Explore.ADP.Report]
GO

CREATE PROCEDURE [dbo].[UpSertReportType]      
    @ClientId INT = NULL,      
    @Type NVARCHAR(200) = NULL,      
    @Description NVARCHAR(500) = NULL,      
    @CreatedDate DATETIME = NULL,      
    @UpdatedDate DATETIME = NULL,      
    @CreatedBy NVARCHAR(100) = NULL,      
    @UpdatedBy NVARCHAR(100) = NULL      
AS      
BEGIN      
    IF NOT EXISTS(SELECT 1 FROM [ReportType] WHERE ClientId = @ClientId AND UPPER(Type) = UPPER(@Type))    
    BEGIN    
      INSERT INTO [dbo].[ReportType] ([ClientId], [Type], [Description], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy])    
      VALUES (@ClientId, @Type, @Description, @CreatedDate, @UpdatedDate, @CreatedBy, @UpdatedBy)    
      DECLARE @Id AS INT = (SELECT Scope_identity())    
      EXEC GetReportTypeById @Id    
    END    
    ELSE    
    BEGIN    
  SELECT * FROM [dbo].[ReportType]      
        WHERE ClientId = @ClientId AND UPPER(Type) = UPPER(@Type)    
    END    
END 
GO