CREATE TABLE [dbo].[SalesReturnItems] (
    [Id]         BIGINT          IDENTITY (1, 1) NOT NULL,
    [ProductId]  BIGINT          NOT NULL,
    [PurchaseId] BIGINT          NOT NULL,
    [BrandId]    BIGINT          NULL,
    [Qty]        DECIMAL (18, 2) NOT NULL,
    [Rate]       DECIMAL (18, 2) NOT NULL,
    [Discount]   DECIMAL (18, 2) NOT NULL,
    [TotalPrice] DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_SalesReturnItems] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SalesReturnItems_Brands_BrandId] FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brands] ([Id]),
    CONSTRAINT [FK_SalesReturnItems_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_SalesReturnItems_SalesReturns_PurchaseId] FOREIGN KEY ([PurchaseId]) REFERENCES [dbo].[SalesReturns] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_SalesReturnItems_BrandId]
    ON [dbo].[SalesReturnItems]([BrandId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SalesReturnItems_ProductId]
    ON [dbo].[SalesReturnItems]([ProductId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SalesReturnItems_PurchaseId]
    ON [dbo].[SalesReturnItems]([PurchaseId] ASC);

