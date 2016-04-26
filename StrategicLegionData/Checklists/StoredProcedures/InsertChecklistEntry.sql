CREATE PROCEDURE [ChecklistSchema].[InsertChecklistEntry]
	@ChecklistName nvarchar(25),
	@Submitter nvarchar(25),
	@ChecklistId int OUTPUT
AS
	INSERT INTO [ChecklistSchema].[Checklists](
		ChecklistName,
		DateSubmitted,
		Submitter
	)
	VALUES(
		@ChecklistName,
		CURRENT_TIMESTAMP,
		@Submitter
	)
	SET @ChecklistId = SCOPE_IDENTITY()
RETURN  @ChecklistId