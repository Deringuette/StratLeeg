CREATE PROCEDURE [WhiteboardSchema].[InsertWhiteboardEntry]
	@WhiteboardName varchar(25),
	@Submitter varchar(25),
	@WhiteboardId int
AS
	INSERT INTO WhiteboardSchema.Whiteboards(
		WhiteboardName,
		Submitter
	)VALUES(
		@WhiteboardName,
		@Submitter
	)
	SET @WhiteboardId = SCOPE_IDENTITY()
RETURN @WhiteboardId
