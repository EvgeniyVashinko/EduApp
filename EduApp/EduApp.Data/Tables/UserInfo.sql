CREATE TABLE [dbo].[UserInfo]
(
	[UserInfoId] UNIQUEIDENTIFIER NOT NULL, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Birthday] DATE NOT NULL, 
    [Sex] BIT NOT NULL,
    [Email] NVARCHAR(256) NOT NULL, 
    [Image] NVARCHAR(MAX) NULL,
    [AccountId] UNIQUEIDENTIFIER NOT NULL
        CONSTRAINT [FK_UserInfo_Account] FOREIGN KEY
        REFERENCES [dbo].[Account]([AccountId]),

    CONSTRAINT [PK_UserInfo] PRIMARY KEY([UserInfoId]),

);
GO

CREATE INDEX [IX_UserInfo_AccountId] ON [dbo].[UserInfo] ([AccountId]);
GO