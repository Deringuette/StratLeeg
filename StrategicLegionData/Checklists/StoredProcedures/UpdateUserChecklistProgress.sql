CREATE PROCEDURE [ChecklistSchema].[UpdateUserChecklistProgress]
	@UserId int,
	@ChecklistItemId int,
	@IsChecked bit
AS
	UPDATE [ChecklistSchema].UserSavedChecklistItems
		SET	IsChecked = @IsChecked
		WHERE UserId = @UserId AND ChecklistItemId = @ChecklistItemId
RETURN 0
