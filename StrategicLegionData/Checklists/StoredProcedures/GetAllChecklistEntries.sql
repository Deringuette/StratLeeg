CREATE PROCEDURE [ChecklistSchema].[GetAllChecklistEntries]
AS
	SELECT
	[Checklists].[ChecklistId] As [ChecklistId],
	[Checklists].[ChecklistName] As [ChecklistName],
	[Checklists].[DateSubmitted] As [DateSubmitted],
	[Checklists].[Submitter] As [Submitter]
	
	FROM 
	[ChecklistSchema].[Checklists]
RETURN 0
