CREATE TABLE [dbo].[Review]
(
	[ReviewId] UNIQUEIDENTIFIER NOT NULL,
	[AccountId] UNIQUEIDENTIFIER NOT NULL
        CONSTRAINT [FK_Review_Account] FOREIGN KEY
        REFERENCES [dbo].[Account]([AccountId]),
	[CourseId] UNIQUEIDENTIFIER NOT NULL
        CONSTRAINT [FK_Review_Course] FOREIGN KEY
        REFERENCES [dbo].[Course]([CourseId]), 
    [Value] INT NULL, 
    [Description] VARCHAR(MAX) NULL, 
    [CreationDate] DATETIME2 NULL, 
    [UpdatedDate] DATETIME2 NULL, 
    CONSTRAINT [PK_Review] PRIMARY KEY ([ReviewId]),
)
GO

CREATE INDEX [IX_Review_AccountId] ON [dbo].[Homework] ([AccountId])
GO

CREATE INDEX [IX_Review_LessonId] ON [dbo].[Homework] ([LessonId])
GO