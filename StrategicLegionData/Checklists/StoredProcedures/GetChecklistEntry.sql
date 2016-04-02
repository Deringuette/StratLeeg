CREATE PROCEDURE [ChecklistSchema].[GetChecklistEntry]
	@ChecklistId int
AS
	SELECT
		[Checklists].[ChecklistId] As [ChecklistId],
		[Checklists].[ChecklistName] As [ChecklistName]
	FROM
		[ChecklistSchema].[Checklists] checklists
	WHERE [Checklists].ChecklistId = @ChecklistId
RETURN 0
