USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[GetAllClientInformations]    Script Date: 05/30/2024 08:40:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAllClientInformations]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetAllClientInformations]
GO

USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[GetAllClientInformations]    Script Date: 05/30/2024 08:40:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllClientInformations]
    @PageNumber INT,
    @PageSize INT
AS
BEGIN
    WITH ClientInformation_CTE AS
    (
        SELECT *,
               ROW_NUMBER() OVER (ORDER BY [Id]) AS RowNum
        FROM [dbo].[ClientInformation]
    )
    SELECT *
    FROM ClientInformation_CTE
    WHERE RowNum BETWEEN (@PageNumber - 1) * @PageSize + 1 AND @PageNumber * @PageSize;
END

GO


