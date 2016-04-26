CREATE PROCEDURE [CounterSchema].[GetCounterEntry]
	@CounterId int
AS
	SELECT 
	[Counters].[CounterId] AS CounterId,
	[Counters].[CounterName] AS CounterName,
	[Counters].[CounterValue] AS CounterValue,
	[Counters].[SubmitterName] AS SubmitterName
	FROM [CounterSchema].[Counters]
	WHERE [Counters].[CounterId] = @CounterId
RETURN 0
