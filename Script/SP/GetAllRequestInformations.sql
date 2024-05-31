USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[GetAllRequestInformations]    Script Date: 05/30/2024 08:40:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAllRequestInformations]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetAllRequestInformations]
GO

USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[GetAllRequestInformations]    Script Date: 05/30/2024 08:40:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllRequestInformations]
    @PageNumber INT,
    @PageSize INT
AS
BEGIN
    WITH RequestInformation_CTE AS
    (
        SELECT *,
               ROW_NUMBER() OVER (ORDER BY [Id]) AS RowNum
        FROM [dbo].[RequestInformation]
    )
    SELECT *
    FROM RequestInformation_CTE
    WHERE RowNum BETWEEN (@PageNumber - 1) * @PageSize + 1 AND @PageNumber * @PageSize;
END

GO


