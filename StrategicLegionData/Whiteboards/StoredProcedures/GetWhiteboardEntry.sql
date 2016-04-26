CREATE PROCEDURE [WhiteboardSchema].[GetWhiteboardEntry]
	@WhiteboardId int
AS
	SELECT
		Whiteboards.WhiteboardName AS WhiteboardName,
		Whiteboards.Submitter AS Submitter,
		Whiteboards.WhiteboardId AS WhiteboardId
	FROM WhiteboardSchema.Whiteboards
	WHERE Whiteboards.WhiteboardId = @WhiteboardId
RETURN 0
