CREATE PROCEDURE [ImageSchema].[InsertImageEntry]
	@ImageName varchar(25),
	@DateSubmitted Datetime,
	@Submitter varchar(25),
	@ImageId int OUTPUT
AS
	INSERT INTO [ImageSchema].Images(
		ImageName,
		DateSubmitted,
		Submitter
	)VALUES(
		@ImageName,
		@DateSubmitted,
		@Submitter
	)
	SET @ImageId = SCOPE_IDENTITY()
RETURN @ImageId
