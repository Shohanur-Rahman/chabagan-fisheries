CREATE TABLE [dbo].[Products] (
    [Id]          BIGINT          IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX)  NOT NULL,
    [CategoryId]  BIGINT          NOT NULL,
    [MRP]         DECIMAL (18, 2) NOT NULL,
    [Avatar]      NVARCHAR (MAX)  NULL,
    [Description] NVARCHAR (MAX)  NULL,
    [CreatedBy]   BIGINT          NULL,
    [CreatedDate] DATETIME2 (7)   NULL,
    [UpdatedBy]   BIGINT          NULL,
    [UpdatedDate] DATETIME2 (7)   NULL,
    [IsDeleted]   BIT             NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Products_StockCategories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[StockCategories] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Products_CategoryId]
    ON [dbo].[Products]([CategoryId] ASC);

