USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[UpdateSqlFileData]    Script Date: 05/30/2024 08:45:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpSertAlphabet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UpSertAlphabet]
GO

USE [Explore.ADP.Report]
GO

  
CREATE PROCEDURE [dbo].[UpSertAlphabet] @Alphabet    NVARCHAR(50),    
                                        @CreatedDate DATETIME,    
                                        @UpdatedDate DATETIME,    
                                        @CreatedBy   NVARCHAR(100) = NULL,    
                                        @UpdatedBy   NVARCHAR(100) = NULL,    
                                        @Description NVARCHAR(500) = NULL    
AS    
  BEGIN    
      IF NOT EXISTS(SELECT 1    
                    FROM   [dbo].[alphabet]    
                    WHERE  UPPER(alphabet) = UPPER(@Alphabet))    
        BEGIN    
              
            INSERT INTO [dbo].[alphabet]    
                        ([alphabet],    
                         [createddate],    
                         [updateddate],    
                         [createdby],    
                         [updatedby],    
                         [description])    
            VALUES      (UPPER(@Alphabet),    
                         @CreatedDate,    
                         @UpdatedDate,    
                         @CreatedBy,    
                         @UpdatedBy,    
                         @Description);      
            DECLARE @Id AS INT = (SELECT Scope_identity())  
            EXEC GetAlphabetById @Id  
        END    
      ELSE    
        BEGIN    
            SELECT id,    
                   alphabet AS 'Name',    
                   createddate,    
                   updateddate,    
                   createdby,    
                   [updatedby],    
                   description    
            FROM   [dbo].[alphabet]    
            WHERE  UPPER(alphabet) = UPPER(@Alphabet)    
        END    
  END   
  GO