CREATE PROCEDURE [ChecklistSchema].[InsertChecklistItemEntry]
	@ParentChecklistGroupId int,
	@ChecklistItemId int OUTPUT
AS
INSERT INTO [ChecklistSchema].ChecklistItems(
	ParentChecklistGroupId
)
Values(
	@ParentChecklistGroupId
)
	SET @ChecklistItemId = SCOPE_IDENTITY()
RETURN @ChecklistItemId
