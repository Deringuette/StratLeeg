CREATE TABLE [ChecklistSchema].[ChecklistGroups]
(
	[ChecklistGroupId] INT IDENTITY(1,1) PRIMARY KEY,
    [ParentChecklistId] INT NOT NULL FOREIGN KEY REFERENCES [ChecklistSchema].Checklists(ChecklistId), 
    [GroupName] VARCHAR(25) NULL
)
