CREATE TABLE [dbo].[CourseParticipants]
(
	[CourseParticipantsId] UNIQUEIDENTIFIER NOT NULL, 
	[CourseId] UNIQUEIDENTIFIER NOT NULL
	    CONSTRAINT [FK_CourseParticipants_Course] FOREIGN KEY
        REFERENCES [dbo].[Course]([CourseId]),
    [AccountId] UNIQUEIDENTIFIER NOT NULL
	    CONSTRAINT [FK_CourseParticipants_Account] FOREIGN KEY
        REFERENCES [dbo].[Account]([AccountId]),

    CONSTRAINT [PK_CourseParticipants] PRIMARY KEY ([CourseParticipantsId])
)
GO

CREATE INDEX [IX_CourseParticipants_RCourseId] ON [dbo].[CourseParticipants] ([CourseId]);
GO

CREATE INDEX [IX_CourseParticipants_AccountId] ON [dbo].[CourseParticipants] ([AccountId]);
GO
