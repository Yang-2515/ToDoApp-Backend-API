CREATE TABLE [dbo].[Attackment]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [LinkFile] NVARCHAR(100) NOT NULL, 
    [TaskId] INT NOT NULL,
    [IsDelete] BIT NOT NULL, 
    [CreateAt] DATETIME NULL, 
    [DeleteAt] DATETIME NULL, 
    CONSTRAINT fk_id_taskattachment
    FOREIGN KEY (TaskId)
    REFERENCES [dbo].[Task] (Id),
)
