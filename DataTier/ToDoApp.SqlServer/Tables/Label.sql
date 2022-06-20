CREATE TABLE [dbo].[Label]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Color] NVARCHAR(50) NULL,
    [IsDelete] BIT NOT NULL, 
    [CreateAt] DATETIME NULL, 
    [DeleteAt] DATETIME NULL, 
)
