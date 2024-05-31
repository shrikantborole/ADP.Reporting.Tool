USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[GetClientInformationById]    Script Date: 05/30/2024 08:42:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetClientInformationById]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetClientInformationById]
GO

USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[GetClientInformationById]    Script Date: 05/30/2024 08:42:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetClientInformationById]
    @Id INT
AS
BEGIN
    SELECT * FROM [dbo].[ClientInformation]
    WHERE [Id] = @Id;
END

GO


