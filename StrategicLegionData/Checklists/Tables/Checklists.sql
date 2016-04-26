CREATE TABLE [ChecklistSchema].[Checklists]
(
	[ChecklistId] INT IDENTITY(1,1) PRIMARY KEY, 
    [ChecklistName] VARCHAR(25) NULL, 
    [DateSubmitted] DATETIME NOT NULL, 
    [Submitter] NVARCHAR(25) NOT NULL
)
