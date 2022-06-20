CREATE TABLE [dbo].[ListTask]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(100) NOT NULL, 
    [FromDate] DATETIME NULL, 
    [ToDate] DATETIME NULL, 
    [Color] NVARCHAR(50) NULL, 
    [BoardId] INT NULL,
    [IsDelete] BIT NOT NULL, 
    [CreateAt] DATETIME NULL, 
    [DeleteAt] DATETIME NULL, 
    CONSTRAINT fk_id_boardlisttask
    FOREIGN KEY (BoardId)
    REFERENCES [dbo].[Board] (Id),
)
