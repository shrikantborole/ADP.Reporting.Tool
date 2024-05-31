USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[DeleteClientInformation]    Script Date: 05/30/2024 08:38:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteClientInformation]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DeleteClientInformation]
GO

USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[DeleteClientInformation]    Script Date: 05/30/2024 08:38:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteClientInformation]
    @Id INT
AS
BEGIN
    DELETE FROM [dbo].[ClientInformation]
    WHERE [Id] = @Id;
END

GO


