CREATE TABLE [NotepadSchema].[Notepads]
(
	[NotepadId] INT NOT NULL IDENTITY PRIMARY KEY, 
    [NotepadName] VARCHAR(25) NULL, 
    [NotepadContent] VARCHAR(MAX) NULL
)
