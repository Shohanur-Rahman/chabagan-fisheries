CREATE TABLE [dbo].[SalesReturns] (
    [Id]             BIGINT          IDENTITY (1, 1) NOT NULL,
    [BillNo]         NVARCHAR (450)  NOT NULL,
    [BillDate]       DATETIME2 (7)   NULL,
    [SupplierId]     BIGINT          NOT NULL,
    [ProjectId]      BIGINT          NOT NULL,
    [TotalAmount]    DECIMAL (18, 2) NOT NULL,
    [Discount]       DECIMAL (18, 2) NOT NULL,
    [NetAmount]      DECIMAL (18, 2) NOT NULL,
    [PaidAmount]     DECIMAL (18, 2) NOT NULL,
    [DuesAmount]     DECIMAL (18, 2) NOT NULL,
    [Note]           NVARCHAR (MAX)  NULL,
    [ApprovalStatus] BIT             NOT NULL,
    [CreatedBy]      BIGINT          NULL,
    [CreatedDate]    DATETIME2 (7)   NULL,
    [UpdatedBy]      BIGINT          NULL,
    [UpdatedDate]    DATETIME2 (7)   NULL,
    [IsDeleted]      BIT             NOT NULL,
    CONSTRAINT [PK_SalesReturns] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SalesReturns_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_SalesReturns_Suppliers_SupplierId] FOREIGN KEY ([SupplierId]) REFERENCES [dbo].[Suppliers] ([Id]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SalesReturns_BillNo]
    ON [dbo].[SalesReturns]([BillNo] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SalesReturns_ProjectId]
    ON [dbo].[SalesReturns]([ProjectId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SalesReturns_SupplierId]
    ON [dbo].[SalesReturns]([SupplierId] ASC);

