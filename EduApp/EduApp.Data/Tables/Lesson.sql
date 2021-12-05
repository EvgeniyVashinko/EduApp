CREATE TABLE [dbo].[Lesson]
(
	[LessonId] UNIQUEIDENTIFIER NOT NULL, 
    [CourseId] UNIQUEIDENTIFIER NOT NULL
        CONSTRAINT [FK_Lesson_Course] FOREIGN KEY
        REFERENCES [dbo].[Course]([CourseId]), 
    [Title] NVARCHAR(150) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [CreationDate] DATETIME2 NOT NULL, 
    [UpdatedDate] DATETIME2 NULL,

    CONSTRAINT [PK_Lesson] PRIMARY KEY ([LessonId]), 
)
GO

CREATE INDEX [IX_Lesson_CourseId] ON [dbo].[Lesson] ([CourseId])
GO
