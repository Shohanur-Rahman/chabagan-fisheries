﻿CREATE TABLE [dbo].[StockCategories] (
    [Id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [CreatedBy]   BIGINT         NULL,
    [CreatedDate] DATETIME2 (7)  NULL,
    [UpdatedBy]   BIGINT         NULL,
    [UpdatedDate] DATETIME2 (7)  NULL,
    [IsDeleted]   BIT            NOT NULL,
    CONSTRAINT [PK_StockCategories] PRIMARY KEY CLUSTERED ([Id] ASC)
);

