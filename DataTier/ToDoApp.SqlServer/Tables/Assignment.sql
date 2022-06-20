CREATE TABLE [dbo].[Assignment]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NOT NULL, 
    [TaskId] INT NOT NULL,
    [IsDelete] BIT NOT NULL, 
    [CreateAt] DATETIME NULL, 
    [DeleteAt] DATETIME NULL, 
    CONSTRAINT fk_id_usertask
    FOREIGN KEY (UserId)
    REFERENCES [dbo].[User] (Id),
    CONSTRAINT fk_id_task
    FOREIGN KEY (TaskId)
    REFERENCES [dbo].[Task] (Id),
)
