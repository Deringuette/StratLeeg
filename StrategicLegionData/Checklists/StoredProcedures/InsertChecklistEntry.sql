CREATE PROCEDURE [ChecklistSchema].[InsertChecklistEntry]
	@ChecklistName nvarchar(25),
	@ChecklistId int OUTPUT
AS
	INSERT INTO [ChecklistSchema].[Checklists](
		ChecklistName
	)
	VALUES(
		@ChecklistName
	)
	SET @ChecklistId = SCOPE_IDENTITY()
RETURN  @ChecklistId