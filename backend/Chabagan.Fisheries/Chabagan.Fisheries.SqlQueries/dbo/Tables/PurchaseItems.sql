CREATE TABLE [dbo].[PurchaseItems] (
    [Id]         BIGINT          IDENTITY (1, 1) NOT NULL,
    [ProductId]  BIGINT          NOT NULL,
    [PurchaseId] BIGINT          NOT NULL,
    [BrandId]    BIGINT          NULL,
    [Qty]        DECIMAL (18, 2) NOT NULL,
    [Rate]       DECIMAL (18, 2) NOT NULL,
    [Discount]   DECIMAL (18, 2) NOT NULL,
    [TotalPrice] DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_PurchaseItems] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PurchaseItems_Brands_BrandId] FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brands] ([Id]),
    CONSTRAINT [FK_PurchaseItems_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PurchaseItems_Purchases_PurchaseId] FOREIGN KEY ([PurchaseId]) REFERENCES [dbo].[Purchases] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseItems_BrandId]
    ON [dbo].[PurchaseItems]([BrandId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseItems_ProductId]
    ON [dbo].[PurchaseItems]([ProductId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseItems_PurchaseId]
    ON [dbo].[PurchaseItems]([PurchaseId] ASC);

