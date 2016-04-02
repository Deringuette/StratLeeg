CREATE TABLE [ChecklistSchema].[ChecklistItems]
(
	[ChecklistItemId] INT IDENTITY(1,1) PRIMARY KEY,
	[ParentChecklistGroupId] INT Not NULL FOREIGN KEY REFERENCES [ChecklistSchema].ChecklistGroups(ChecklistGroupId),
    [ChecklistItemName] VARCHAR(25) NULL
)
