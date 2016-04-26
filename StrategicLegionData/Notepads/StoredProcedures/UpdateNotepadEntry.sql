CREATE PROCEDURE [NotepadSchema].[UpdateNotepadEntry]
	@NotepadId int,
	@NotepadName varchar(25),
	@NotepadContent varchar(MAX)
AS
	Update NotepadSchema.Notepads
	SET
	NotepadName = @NotepadName,
	NotepadContent = @NotepadContent
	WHERE NotepadId = @NotepadId
RETURN 0
