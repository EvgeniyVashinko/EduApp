CREATE TABLE [dbo].[CourseParticipants]
(
	[CourseParticipantsId] UNIQUEIDENTIFIER NOT NULL, 
	[RoleId] UNIQUEIDENTIFIER NOT NULL
	    CONSTRAINT [FK_CourseParticipants_Role] FOREIGN KEY
        REFERENCES [dbo].[Role]([RoleId]),
    [AccountId] UNIQUEIDENTIFIER NOT NULL
	    CONSTRAINT [FK_CourseParticipants_Account] FOREIGN KEY
        REFERENCES [dbo].[Account]([AccountId]),

    CONSTRAINT [PK_CourseParticipants] PRIMARY KEY ([CourseParticipantsId])
)
GO

CREATE INDEX [IX_CourseParticipants_RoleId] ON [dbo].[AccountRole] ([RoleId]);
GO

CREATE INDEX [IX_CourseParticipants_AccountId] ON [dbo].[AccountRole] ([AccountId]);
GO
