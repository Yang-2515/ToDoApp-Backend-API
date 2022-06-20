CREATE TABLE [dbo].[BoardMember]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NOT NULL, 
    [BoardId] INT NOT NULL,
    [IsDelete] BIT NOT NULL, 
    [CreateAt] DATETIME NULL, 
    [DeleteAt] DATETIME NULL, 
    CONSTRAINT fk_id_user
    FOREIGN KEY (UserId)
    REFERENCES [dbo].[User] (Id),
    CONSTRAINT fk_id_board
    FOREIGN KEY (BoardId)
    REFERENCES [dbo].[Board] (Id),

)
