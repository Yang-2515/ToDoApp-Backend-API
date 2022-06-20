CREATE PROCEDURE [dbo].[spGetLabels]
	@pId int = NULL
AS
	SELECT * FROM [dbo].[vwLabels]
	WHERE Id = @pId OR @pId IS NULL
RETURN 0
