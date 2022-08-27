CREATE TABLE [dbo].[ProductGroup] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [GroupDescription] NVARCHAR (MAX) NULL,
    [GroupCode]        NVARCHAR (MAX) NULL,
    [IsDeleted]        BIT            NOT NULL,
    [CreatedOn]        DATETIME2 (7)  NOT NULL,
    [UpdatedOn]        DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_ProductGroup] PRIMARY KEY CLUSTERED ([Id] ASC)
);

