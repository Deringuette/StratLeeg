CREATE PROCEDURE [ChecklistSchema].[UpdateChecklistItem]
	@ChecklistItemId int,
	@ChecklistItemName varchar(25)
AS
	UPDATE [ChecklistSchema].ChecklistItems
	SET ChecklistItemName = @ChecklistItemName

	WHERE ChecklistItemId = @ChecklistItemId
RETURN 0