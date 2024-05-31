-- Drop the database if it exists
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'Explore.ADP.Report')
BEGIN
    ALTER DATABASE [Explore.ADP.Report] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [Explore.ADP.Report];
END
GO

-- Create the database
CREATE DATABASE [Explore.ADP.Report];
GO
