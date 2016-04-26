CREATE PROCEDURE [NotepadSchema].[GetNotepadEntry]
	@NotepadId int
AS
	SELECT 
	Notepads.NotepadId AS NotpadId,
	Notepads.NotepadName AS NotepadName,
	Notepads.NotepadContent AS NotepadContent

	FROM NotepadSchema.Notepads
	WHERE NotepadId = @NotepadId
RETURN 0
