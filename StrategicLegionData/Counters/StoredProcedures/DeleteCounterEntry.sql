CREATE PROCEDURE [CounterSchema].[DeleteCounterEntry]
	@CounterId int
AS
	DELETE FROM CounterSchema.Counters
	WHERE CounterId = @CounterId
RETURN 0
