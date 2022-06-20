﻿/*
Deployment script for ToDoApp.Database

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "ToDoApp.Database"
:setvar DefaultFilePrefix "ToDoApp.Database"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Creating database $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF),
                MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = OFF,
                DELAYED_DURABILITY = DISABLED 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_PLANS_PER_QUERY = 200, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE = OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET TEMPORAL_HISTORY_RETENTION ON 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'Creating Table [dbo].[Assignment]...';


GO
CREATE TABLE [dbo].[Assignment] (
    [Id]       INT      IDENTITY (1, 1) NOT NULL,
    [UserId]   INT      NOT NULL,
    [TaskId]   INT      NOT NULL,
    [IsDelete] BIT      NOT NULL,
    [CreateAt] DATETIME NULL,
    [DeleteAt] DATETIME NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[Attackment]...';


GO
CREATE TABLE [dbo].[Attackment] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [LinkFile] NVARCHAR (100) NOT NULL,
    [TaskId]   INT            NOT NULL,
    [IsDelete] BIT            NOT NULL,
    [CreateAt] DATETIME       NULL,
    [DeleteAt] DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[Board]...';


GO
CREATE TABLE [dbo].[Board] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [Description] NVARCHAR (255) NULL,
    [LinkImage]   NVARCHAR (100) NULL,
    [IsDelete]    BIT            NOT NULL,
    [CreateAt]    DATETIME       NULL,
    [DeleteAt]    DATETIME       NULL,
    [ManageId]    INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[BoardMember]...';


GO
CREATE TABLE [dbo].[BoardMember] (
    [Id]       INT      IDENTITY (1, 1) NOT NULL,
    [UserId]   INT      NOT NULL,
    [BoardId]  INT      NOT NULL,
    [IsDelete] BIT      NOT NULL,
    [CreateAt] DATETIME NULL,
    [DeleteAt] DATETIME NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[Label]...';


GO
CREATE TABLE [dbo].[Label] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (50) NOT NULL,
    [Color]    NVARCHAR (50) NULL,
    [IsDelete] BIT           NOT NULL,
    [CreateAt] DATETIME      NULL,
    [DeleteAt] DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[ListTask]...';


GO
CREATE TABLE [dbo].[ListTask] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (100) NOT NULL,
    [FromDate] DATETIME       NULL,
    [ToDate]   DATETIME       NULL,
    [Color]    NVARCHAR (50)  NULL,
    [BoardId]  INT            NULL,
    [IsDelete] BIT            NOT NULL,
    [CreateAt] DATETIME       NULL,
    [DeleteAt] DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[Task]...';


GO
CREATE TABLE [dbo].[Task] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [Description] NVARCHAR (255) NULL,
    [StartDate]   DATE           NULL,
    [DueDate]     DATE           NULL,
    [ListTaskId]  INT            NOT NULL,
    [ParentId]    INT            NULL,
    [IsDelete]    BIT            NOT NULL,
    [CreateAt]    DATETIME       NULL,
    [DeleteAt]    DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[TaskLabel]...';


GO
CREATE TABLE [dbo].[TaskLabel] (
    [Id]       INT      IDENTITY (1, 1) NOT NULL,
    [TaskId]   INT      NOT NULL,
    [LabelId]  INT      NOT NULL,
    [IsDelete] BIT      NOT NULL,
    [CreateAt] DATETIME NULL,
    [DeleteAt] DATETIME NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[User]...';


GO
CREATE TABLE [dbo].[User] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (50)  NOT NULL,
    [Phone]         NVARCHAR (10)  NOT NULL,
    [Email Address] NVARCHAR (50)  NOT NULL,
    [Home Address]  NVARCHAR (50)  NULL,
    [Age]           INT            NULL,
    [Gender]        NVARCHAR (10)  NULL,
    [LinkImage]     NVARCHAR (100) NULL,
    [IsDelete]      BIT            NOT NULL,
    [CreateAt]      DATETIME       NULL,
    [DeleteAt]      DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Foreign Key [dbo].[fk_id_usertask]...';


GO
ALTER TABLE [dbo].[Assignment]
    ADD CONSTRAINT [fk_id_usertask] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[fk_id_task]...';


GO
ALTER TABLE [dbo].[Assignment]
    ADD CONSTRAINT [fk_id_task] FOREIGN KEY ([TaskId]) REFERENCES [dbo].[Task] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[fk_id_taskattachment]...';


GO
ALTER TABLE [dbo].[Attackment]
    ADD CONSTRAINT [fk_id_taskattachment] FOREIGN KEY ([TaskId]) REFERENCES [dbo].[Task] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[fk_id_manageboard]...';


GO
ALTER TABLE [dbo].[Board]
    ADD CONSTRAINT [fk_id_manageboard] FOREIGN KEY ([ManageId]) REFERENCES [dbo].[User] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[fk_id_user]...';


GO
ALTER TABLE [dbo].[BoardMember]
    ADD CONSTRAINT [fk_id_user] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[fk_id_board]...';


GO
ALTER TABLE [dbo].[BoardMember]
    ADD CONSTRAINT [fk_id_board] FOREIGN KEY ([BoardId]) REFERENCES [dbo].[Board] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[fk_id_boardlisttask]...';


GO
ALTER TABLE [dbo].[ListTask]
    ADD CONSTRAINT [fk_id_boardlisttask] FOREIGN KEY ([BoardId]) REFERENCES [dbo].[Board] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[fk_id_listtask]...';


GO
ALTER TABLE [dbo].[Task]
    ADD CONSTRAINT [fk_id_listtask] FOREIGN KEY ([ListTaskId]) REFERENCES [dbo].[ListTask] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[fk_id_tasklabel]...';


GO
ALTER TABLE [dbo].[TaskLabel]
    ADD CONSTRAINT [fk_id_tasklabel] FOREIGN KEY ([TaskId]) REFERENCES [dbo].[Task] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[fk_id_labeltask]...';


GO
ALTER TABLE [dbo].[TaskLabel]
    ADD CONSTRAINT [fk_id_labeltask] FOREIGN KEY ([LabelId]) REFERENCES [dbo].[Label] ([Id]);


GO
PRINT N'Creating View [dbo].[vwLabels]...';


GO
CREATE VIEW [dbo].[vwLabels]
	AS 
	SELECT * 
	FROM [Label]
GO
PRINT N'Creating Procedure [dbo].[spGetLabels]...';


GO
CREATE PROCEDURE [dbo].[spGetLabels]
	@pId int = NULL
AS
	SELECT * FROM [dbo].[vwLabels]
	WHERE Id = @pId OR @pId IS NULL
RETURN 0
GO

INSERT INTO Label (Name, Color, IsDelete) 
VALUES ('.NET', '#fff', 0), 
	('.ANGULAR', '#fff0', 0),
	('.DONE', '#8f0d', 0)
GO

GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Update complete.';


GO