CREATE PROCEDURE [CounterSchema].[InsertCounterEntry]
	@CounterName varchar(25),
	@CounterValue int,
	@SubmitterName varchar(25),
	@CounterId int OUTPUT
AS
	INSERT INTO CounterSchema.Counters(
		CounterName,
		CounterValue,
		SubmitterName
	)VALUES(
		@CounterName,
		@CounterValue,
		@SubmitterName
	)
	SET @CounterId = SCOPE_IDENTITY()
RETURN @CounterId
