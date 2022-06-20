CREATE TABLE [dbo].[Board]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(255) NULL, 
    [LinkImage] NVARCHAR(100) NULL,
    [IsDelete] BIT NOT NULL, 
    [CreateAt] DATETIME NULL, 
    [DeleteAt] DATETIME NULL,
    ManageId INT NOT NULL,
    CONSTRAINT fk_id_manageboard
    FOREIGN KEY (ManageId)
    REFERENCES [dbo].[User] (Id),
)
