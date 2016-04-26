CREATE TABLE [ImageSchema].[Images]
(
	[ImageId] INT NOT NULL IDENTITY PRIMARY KEY, 
    [ImageName] VARCHAR(25) NULL, 
    [DateSubmitted] DATETIME NULL, 
    [Submitter] VARCHAR(25) NULL
)
