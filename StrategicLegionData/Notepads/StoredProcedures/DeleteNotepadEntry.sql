CREATE PROCEDURE [NotepadSchema].[DeleteNotepadEntry]
	@NotepadId int
AS
	DELETE FROM NotepadSchema.Notepads
	WHERE NotepadId = @NotepadId
RETURN 0
