CREATE TABLE [dbo].[Task]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(255) NULL, 
    [StartDate] DATE NULL, 
    [DueDate] DATE NULL,
    [ListTaskId] INT NOT NULL, 
    [ParentId] INT NULL, 
    [IsDelete] BIT NOT NULL, 
    [CreateAt] DATETIME NULL, 
    [DeleteAt] DATETIME NULL, 
    CONSTRAINT fk_id_listtask
    FOREIGN KEY (ListTaskId)
    REFERENCES [dbo].[ListTask] (Id),
)
