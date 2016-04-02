CREATE PROCEDURE [ChecklistSchema].[InsertChecklistGroupEntry]
	@ParentChecklistId int,
	@ChecklistGroupId int OUTPUT
AS
	INSERT INTO [ChecklistSchema].[ChecklistGroups](
		ParentChecklistId
	)
	VALUES(
		@ParentChecklistId
	)
	SET @ChecklistGroupId = SCOPE_IDENTITY()
RETURN @ChecklistGroupId
