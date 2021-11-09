CREATE TABLE [dbo].[Homework]
(
	[HomeworkId] UNIQUEIDENTIFIER NOT NULL,
	[AccountId] UNIQUEIDENTIFIER NOT NULL
        CONSTRAINT [FK_Homework_Account] FOREIGN KEY
        REFERENCES [dbo].[Account]([AccountId]),
	[LessonId] UNIQUEIDENTIFIER NOT NULL
        CONSTRAINT [FK_Homework_Lesson] FOREIGN KEY
        REFERENCES [dbo].[Lesson]([LessonId]), 
	[Answer] VARCHAR(MAX) NULL, 
    [URL] VARCHAR(200) NULL, 
    [Mark] INT NULL, 

    CONSTRAINT [PK_Homework] PRIMARY KEY ([HomeworkId]),
)
GO

CREATE INDEX [IX_Homework_AccountId] ON [dbo].[Homework] ([AccountId])
GO

CREATE INDEX [IX_Homework_LessonId] ON [dbo].[Homework] ([LessonId])
GO