CREATE PROCEDURE [ImageSchema].[GetImageEntry]
	@ImageId int
AS
	SELECT
		[Images].[ImageId] AS ImageId,
		[Images].[ImageName] AS ImageName,
		[Images].[DateSubmitted] AS DateSubmitted,
		[Images].[Submitter] AS Submitter
	FROM [ImageSchema].[Images]
	WHERE ImageId = @ImageId
RETURN 0
