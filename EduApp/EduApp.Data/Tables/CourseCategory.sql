CREATE TABLE [dbo].[CourseCategory]
(
	[CourseCategoryId] UNIQUEIDENTIFIER NOT NULL, 
	[CategoryId] UNIQUEIDENTIFIER NOT NULL
	    CONSTRAINT [FK_CourseCategory_Category] FOREIGN KEY
        REFERENCES [dbo].[Category]([CategoryId]),
    [CourseId] UNIQUEIDENTIFIER NOT NULL
	    CONSTRAINT [FK_CourseCategory_Course] FOREIGN KEY
        REFERENCES [dbo].[Course]([CourseId]),

    CONSTRAINT [PK_CourseCategory] PRIMARY KEY([CourseCategoryId])
);
GO

CREATE INDEX [IX_CourseCategory_CategoryId] ON [dbo].[CourseCategory] ([CategoryId])
GO

CREATE INDEX [IX_CourseCategory_CourseId] ON [dbo].[CourseCategory] ([CourseId])
GO