CREATE PROCEDURE [ImageSchema].[DeleteImageEntry]
	@ImageId int
AS
	DELETE FROM [ImageSchema].Images
	WHERE ImageId = @ImageId
RETURN 0
