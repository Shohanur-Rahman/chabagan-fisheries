CREATE TABLE [dbo].[Ponds] (
    [Id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [ProjectId]   BIGINT         NOT NULL,
    [Avatar]      NVARCHAR (MAX) NULL,
    [CreatedBy]   BIGINT         NULL,
    [CreatedDate] DATETIME2 (7)  NULL,
    [UpdatedBy]   BIGINT         NULL,
    [UpdatedDate] DATETIME2 (7)  NULL,
    [IsDeleted]   BIT            NOT NULL,
    CONSTRAINT [PK_Ponds] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Ponds_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Ponds_ProjectId]
    ON [dbo].[Ponds]([ProjectId] ASC);

