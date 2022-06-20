CREATE TABLE [dbo].[TaskLabel]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TaskId] INT NOT NULL, 
    [LabelId] INT NOT NULL,
    [IsDelete] BIT NOT NULL, 
    [CreateAt] DATETIME NULL, 
    [DeleteAt] DATETIME NULL, 
    CONSTRAINT fk_id_tasklabel
    FOREIGN KEY (TaskId)
    REFERENCES [dbo].[Task] (Id),
    CONSTRAINT fk_id_labeltask
    FOREIGN KEY (LabelId)
    REFERENCES [dbo].[Label] (Id)
)
