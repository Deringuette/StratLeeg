CREATE PROCEDURE [CounterSchema].[UpdateCounterEntry]
	@CounterId int,
	@CounterValue int
AS
	UPDATE CounterSchema.Counters
	SET CounterValue = @CounterValue
	WHERE CounterId = @CounterId
RETURN 0
