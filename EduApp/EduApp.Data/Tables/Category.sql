CREATE TABLE [dbo].[Category]
(
	[CategoryId] UNIQUEIDENTIFIER NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 

    CONSTRAINT [PK_Category] PRIMARY KEY ([CategoryId])
)
