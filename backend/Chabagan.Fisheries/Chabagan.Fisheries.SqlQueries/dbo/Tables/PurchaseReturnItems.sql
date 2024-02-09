CREATE TABLE [dbo].[PurchaseReturnItems] (
    [Id]         BIGINT          IDENTITY (1, 1) NOT NULL,
    [ProductId]  BIGINT          NOT NULL,
    [PurchaseId] BIGINT          NOT NULL,
    [BrandId]    BIGINT          NULL,
    [Qty]        DECIMAL (18, 2) NOT NULL,
    [Rate]       DECIMAL (18, 2) NOT NULL,
    [Discount]   DECIMAL (18, 2) NOT NULL,
    [TotalPrice] DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_PurchaseReturnItems] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PurchaseReturnItems_Brands_BrandId] FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brands] ([Id]),
    CONSTRAINT [FK_PurchaseReturnItems_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PurchaseReturnItems_PurchaseReturns_PurchaseId] FOREIGN KEY ([PurchaseId]) REFERENCES [dbo].[PurchaseReturns] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseReturnItems_BrandId]
    ON [dbo].[PurchaseReturnItems]([BrandId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseReturnItems_ProductId]
    ON [dbo].[PurchaseReturnItems]([ProductId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseReturnItems_PurchaseId]
    ON [dbo].[PurchaseReturnItems]([PurchaseId] ASC);

