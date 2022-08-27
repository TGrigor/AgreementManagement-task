CREATE TABLE [dbo].[Product] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [ProductGroupId]     INT            NOT NULL,
    [ProductDescription] NVARCHAR (MAX) NULL,
    [ProductNumber]      NVARCHAR (MAX) NULL,
    [Price]              BIGINT         NOT NULL,
    [IsDeleted]          BIT            NOT NULL,
    [CreatedOn]          DATETIME2 (7)  NOT NULL,
    [UpdatedOn]          DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Product_ProductGroup_ProductGroupId] FOREIGN KEY ([ProductGroupId]) REFERENCES [dbo].[ProductGroup] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Product_ProductGroupId]
    ON [dbo].[Product]([ProductGroupId] ASC);

