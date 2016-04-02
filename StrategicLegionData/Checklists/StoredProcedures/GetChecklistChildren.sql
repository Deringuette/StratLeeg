CREATE PROCEDURE [ChecklistSchema].[GetChecklistChildren]
	@ChecklistId int
AS
        SELECT
		[ChecklistGroups].[ChecklistGroupId]	AS	[ChecklistGroupId],
        [ChecklistGroups].[ParentChecklistId]	AS  [ParentChecklistId],
        [ChecklistGroups].[GroupName]			AS  [GroupName]

        FROM [ChecklistSchema].[ChecklistGroups] checklistGroups
		INNER JOIN [ChecklistSchema].Checklists checklists
		ON checklistGroups.ParentChecklistId=checklists.ChecklistId
	
		WHERE ParentChecklistId = @ChecklistId
RETURN 0