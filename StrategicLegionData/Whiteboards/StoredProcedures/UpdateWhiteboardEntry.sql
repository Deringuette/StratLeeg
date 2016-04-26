CREATE PROCEDURE [WhiteboardSchema].[UpdateWhiteboardEntry]
	@WhiteboardId int,
	@WhiteboardName varchar(25),
	@Submitter varchar(25)
AS
	UPDATE [WhiteboardSchema].Whiteboards
	SET
	WhiteboardName = @WhiteboardName,
	Submitter = @Submitter
	WHERE WhiteboardId = @WhiteboardId
RETURN 0
