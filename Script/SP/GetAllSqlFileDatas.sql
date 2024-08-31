USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[GetAllSqlFileDatas]    Script Date: 05/30/2024 08:41:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAllSqlFileDatas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetAllSqlFileDatas]
GO

USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[GetAllSqlFileDatas]    Script Date: 05/30/2024 08:41:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllSqlFileDatas]
    @PageNumber INT,
    @PageSize INT
AS
BEGIN
    WITH SqlFileData_CTE AS
    (
        SELECT  [Id]
      ,[RequestId]
      ,[Description]
      ,[SqlFileData] as SqlFileDataContent
      ,[CreatedDate]
      ,[UpdatedDate]
      ,[CreatedBy]
      ,[UpdatedBy],
               ROW_NUMBER() OVER (ORDER BY [Id]) AS RowNum
        FROM [dbo].[SqlFileData]
    )
    SELECT *
    FROM SqlFileData_CTE
    WHERE RowNum BETWEEN (@PageNumber - 1) * @PageSize + 1 AND @PageNumber * @PageSize;
END



