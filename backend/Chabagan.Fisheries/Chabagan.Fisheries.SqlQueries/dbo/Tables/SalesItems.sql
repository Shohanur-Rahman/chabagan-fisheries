CREATE TABLE [dbo].[SalesItems] (
    [Id]         BIGINT          IDENTITY (1, 1) NOT NULL,
    [ProductId]  BIGINT          NOT NULL,
    [PurchaseId] BIGINT          NOT NULL,
    [BrandId]    BIGINT          NULL,
    [Qty]        DECIMAL (18, 2) NOT NULL,
    [Rate]       DECIMAL (18, 2) NOT NULL,
    [Discount]   DECIMAL (18, 2) NOT NULL,
    [TotalPrice] DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_SalesItems] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SalesItems_Brands_BrandId] FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brands] ([Id]),
    CONSTRAINT [FK_SalesItems_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_SalesItems_Sales_PurchaseId] FOREIGN KEY ([PurchaseId]) REFERENCES [dbo].[Sales] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_SalesItems_BrandId]
    ON [dbo].[SalesItems]([BrandId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SalesItems_ProductId]
    ON [dbo].[SalesItems]([ProductId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SalesItems_PurchaseId]
    ON [dbo].[SalesItems]([PurchaseId] ASC);

