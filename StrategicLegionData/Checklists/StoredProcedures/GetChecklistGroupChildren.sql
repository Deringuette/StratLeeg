CREATE PROCEDURE [ChecklistSchema].[GetChecklistGroupChildren]
	@ChecklistGroupId int
AS
        SELECT
		[ChecklistItems].[ChecklistItemId]	AS	[ChecklistItemId],
        [ChecklistItems].[ParentChecklistGroupId]	AS  [ParentChecklistGroupId],
        [ChecklistItems].ChecklistItemName		AS  [ItemName]

        FROM [ChecklistSchema].[ChecklistItems] checklistItems
		INNER JOIN [ChecklistSchema].[ChecklistGroups] checklistGroups
		ON checklistItems.ParentChecklistGroupId=checklistGroups.ChecklistGroupId

		WHERE ParentChecklistGroupId=@ChecklistGroupId
	
RETURN 0
