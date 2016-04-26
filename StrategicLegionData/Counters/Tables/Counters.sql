CREATE TABLE [CounterSchema].[Counters]
(
	[CounterId] INT NOT NULL IDENTITY PRIMARY KEY, 
    [CounterName] VARCHAR(25) NULL, 
    [CounterValue] INT NOT NULL, 
    [SubmitterName] VARCHAR(25) NOT NULL
)
