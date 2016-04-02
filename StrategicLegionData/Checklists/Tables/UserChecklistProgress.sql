CREATE TABLE [ChecklistSchema].[UserSavedChecklistItems]
(
	[UserItemProgressEntryId] INT IDENTITY(1,1) PRIMARY KEY,
    [UserId] INT NOT NULL,
    [ChecklistItemId] int NOT NULL FOREIGN KEY REFERENCES [ChecklistSchema].ChecklistItems(ChecklistItemId), 
    [IsChecked] BIT NOT NULL
)
