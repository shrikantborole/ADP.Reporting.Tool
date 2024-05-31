USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[DeleteRequestInformation]    Script Date: 05/30/2024 08:39:30 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteRequestInformation]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DeleteRequestInformation]
GO

USE [Explore.ADP.Report]
GO

/****** Object:  StoredProcedure [dbo].[DeleteRequestInformation]    Script Date: 05/30/2024 08:39:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteRequestInformation]
    @Id INT
AS
BEGIN
    DELETE FROM [dbo].[RequestInformation]
    WHERE [Id] = @Id;
END

GO


