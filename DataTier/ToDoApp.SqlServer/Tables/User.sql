CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Phone] NVARCHAR(10) NOT NULL, 
    [Email Address] NVARCHAR(50) NOT NULL, 
    [Home Address] NVARCHAR(50) NULL, 
    [Age] INT NULL, 
    [Gender] NVARCHAR(10) NULL, 
    [LinkImage] NVARCHAR(100) NULL,
    [IsDelete] BIT NOT NULL, 
    [CreateAt] DATETIME NULL, 
    [DeleteAt] DATETIME NULL, 
)
