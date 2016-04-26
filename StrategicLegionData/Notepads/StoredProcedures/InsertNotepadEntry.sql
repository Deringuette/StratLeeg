CREATE PROCEDURE [NotepadSchema].[InsertNotepadEntry]
	@NotepadName varchar(25),
	@NotepadContent varchar(MAX),
	@NotepadId int OUTPUT
AS
	INSERT INTO NotepadSchema.Notepads(
		NotepadName,
		NotepadContent
	)VALUES(
		@NotepadName,
		@NotepadContent
	)
		SET @NotepadId = SCOPe_IDENTITY()
RETURN @NotepadId
