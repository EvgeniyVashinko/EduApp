CREATE TABLE [dbo].[Course]
(
	[CourseId] UNIQUEIDENTIFIER NOT NULL, 
    [AccountId] UNIQUEIDENTIFIER NOT NULL
        CONSTRAINT [FK_Course_Account] FOREIGN KEY
        REFERENCES [dbo].[Account]([AccountId]),
    [Title] NVARCHAR(150) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [CreationDate] DATETIME2 NOT NULL, 
    [UpdatedDate] DATETIME2 NULL, 
    [Price] DECIMAL(10,2) NULL,

    [IsActive] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [PK_Course] PRIMARY KEY([CourseId]), 
)
GO

CREATE INDEX [IX_Course_AccountId] ON [dbo].[Course] ([AccountId])
GO
