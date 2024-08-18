USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[UpdateSqlFileData]    Script Date: 05/30/2024 08:45:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpSertRequestInformation]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UpSertRequestInformation]
GO

USE [Explore.ADP.Report]
GO

CREATE PROCEDURE [dbo].[UpSertRequestInformation]    
    @ClientId INT,    
    @RequestType NVARCHAR(200) = NULL,    
    @Description NVARCHAR(1000) = NULL,    
    @CreatedDate DATETIME = NULL,    
    @UpdatedDate DATETIME = NULL,    
    @CreatedBy NVARCHAR(200) = NULL,    
    @UpdatedBy NVARCHAR(200) = NULL,    
    @ReportId INT    
AS    
BEGIN   
    IF NOT EXISTS (SELECT 1 FROM  [RequestInformation] WHERE ClientId = @ClientId AND ReportId = @ReportId AND UPPER(RequestType) = UPPER(@RequestType))  
    BEGIN  
   INSERT INTO [dbo].[RequestInformation] ([ClientId], [RequestType], [Description], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy], [ReportId])  
    VALUES (@ClientId, @RequestType, @Description, @CreatedDate, @UpdatedDate, @CreatedBy, @UpdatedBy, @ReportId);
  DECLARE @Id AS INT = (SELECT Scope_identity())  
  EXEC GetRequestInformationById @Id  
 END  
 ELSE  
 BEGIN  
  SELECT * FROM [dbo].[RequestInformation]    
        WHERE ClientId = @ClientId AND ReportId = @ReportId AND UPPER(RequestType) = UPPER(@RequestType)    
 END  
END    