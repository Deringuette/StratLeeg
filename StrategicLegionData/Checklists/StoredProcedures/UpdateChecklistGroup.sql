CREATE PROCEDURE [ChecklistSchema].[UpdateChecklistGroup]
	@ChecklistGroupId int,
	@GroupName varchar(25)
AS
	UPDATE [ChecklistSchema].ChecklistGroups
	SET	GroupName = @GroupName

	WHERE ChecklistGroupId = @ChecklistGroupId
RETURN 0
