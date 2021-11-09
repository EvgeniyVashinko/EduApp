CREATE TABLE [dbo].[Order]
(
	[OrderId] UNIQUEIDENTIFIER NOT NULL, 
    [AccountId] UNIQUEIDENTIFIER NOT NULL
        CONSTRAINT [FK_Order_Account] FOREIGN KEY
        REFERENCES [Account]([AccountId]), 
    [CourseId] UNIQUEIDENTIFIER NOT NULL
        CONSTRAINT [FK_Order_Course] FOREIGN KEY
        REFERENCES [Course]([CourseId]), 
    [CreationDate] DATETIME2 NOT NULL, 
    [Sum] DECIMAL NOT NULL, 

    CONSTRAINT [PK_Order] PRIMARY KEY ([OrderId]), 
)
GO

CREATE INDEX [IX_Order_AccountId] ON [dbo].[Order] ([AccountId])
GO

CREATE INDEX [IX_Order_CourseId] ON [dbo].[Order] ([CourseId])
GO
