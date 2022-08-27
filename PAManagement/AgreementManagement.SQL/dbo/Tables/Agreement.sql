CREATE TABLE [dbo].[Agreement] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [UserId]         INT           NOT NULL,
    [ProductId]      INT           NOT NULL,
    [ProductGroupId] INT           NOT NULL,
    [EffectiveDate]  DATETIME2 (7) NOT NULL,
    [ExpirationDate] DATETIME2 (7) NOT NULL,
    [ProductPrice]   BIGINT        NOT NULL,
    [NewPrice]       BIGINT        NOT NULL,
    [IsDeleted]      BIT           NOT NULL,
    [CreatedOn]      DATETIME2 (7) NOT NULL,
    [UpdatedOn]      DATETIME2 (7) NOT NULL,
    [Active]         BIT           DEFAULT (CONVERT([bit],(0))) NOT NULL,
    CONSTRAINT [PK_Agreement] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Agreement_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_Agreement_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id]),
    CONSTRAINT [FK_Agreement_ProductGroup_ProductGroupId] FOREIGN KEY ([ProductGroupId]) REFERENCES [dbo].[ProductGroup] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Agreement_UserId]
    ON [dbo].[Agreement]([UserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Agreement_ProductId]
    ON [dbo].[Agreement]([ProductId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Agreement_ProductGroupId]
    ON [dbo].[Agreement]([ProductGroupId] ASC);

