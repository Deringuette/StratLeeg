CREATE PROCEDURE [WhiteboardSchema].[DeleteWhiteboardEntry]
	@WhiteboardId int
AS
	DELETE FROM WhiteboardSchema.Whiteboards
	WHERE WhiteboardId = @WhiteboardId
RETURN 0
