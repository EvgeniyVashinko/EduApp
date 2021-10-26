CREATE TABLE [dbo].[Comment]
(
	[CommentId] UNIQUEIDENTIFIER NOT NULL,
	[AccountId] UNIQUEIDENTIFIER NOT NULL
        CONSTRAINT [FK_Comment_Account] FOREIGN KEY
        REFERENCES [dbo].[Account]([AccountId]),
	[LessonId] UNIQUEIDENTIFIER NOT NULL
        CONSTRAINT [FK_Comment_Lesson] FOREIGN KEY
        REFERENCES [dbo].[Lesson]([LessonId]), 
	[Text] VARCHAR(MAX) NOT NULL, 
    [CreationDate] DATETIME2 NOT NULL, 
    [UpdatedDate] DATETIME2 NULL, 

    CONSTRAINT [PK_Comment] PRIMARY KEY ([CommentId]),
)
GO

CREATE INDEX [IX_Comment_AccountId] ON [dbo].[Comment] ([AccountId])
GO

CREATE INDEX [IX_Comment_LessonId] ON [dbo].[Comment] ([LessonId])
GO