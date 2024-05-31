USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[GetRequestInformationById]    Script Date: 05/30/2024 08:42:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetRequestInformationById]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetRequestInformationById]
GO

USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[GetRequestInformationById]    Script Date: 05/30/2024 08:42:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetRequestInformationById]
    @Id INT
AS
BEGIN
    SELECT * FROM [dbo].[RequestInformation]
    WHERE [Id] = @Id;
END

GO


