USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[GetAllAlphabets]    Script Date: 05/30/2024 08:39:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAllAlphabets]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetAllAlphabets]
GO

USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[GetAllAlphabets]    Script Date: 05/30/2024 08:39:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllAlphabets]  
    @PageNumber INT,  
    @PageSize INT  
AS  
BEGIN  
    WITH Alphabet_CTE AS  
    (  
        SELECT Id,
			   Alphabet as Name,
			   CreatedDate,
			   UpdatedDate,
			   CreatedBy,
			   UpdateBy,
			   Description,  
               ROW_NUMBER() OVER (ORDER BY [Id]) AS RowNum 
        FROM [dbo].[Alphabet]  
    )  
    SELECT *  
    FROM Alphabet_CTE  
    WHERE RowNum BETWEEN (@PageNumber - 1) * @PageSize + 1 AND @PageNumber * @PageSize;  
END  
GO


