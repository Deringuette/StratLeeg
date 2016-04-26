CREATE PROCEDURE [ImageSchema].[UpdateImageEntry]
	@ImageId int,
	@ImageName varchar(25),
	@DateSubmitted Datetime,
	@Submitter varchar(25)
AS
	UPDATE [ImageSchema].Images
	SET
	ImageName = @ImageName,
	DateSubmitted = @DateSubmitted,
	Submitter = @Submitter
	WHERE ImageId = @ImageId
RETURN 0
