CREATE TABLE [dbo].[Projects] (
    [Id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (500) NOT NULL,
    [Union]       NVARCHAR (MAX) NOT NULL,
    [WordNumber]  INT            NOT NULL,
    [Avatar]      NVARCHAR (MAX) NULL,
    [CreatedBy]   BIGINT         NULL,
    [CreatedDate] DATETIME2 (7)  NULL,
    [UpdatedBy]   BIGINT         NULL,
    [UpdatedDate] DATETIME2 (7)  NULL,
    [IsDeleted]   BIT            NOT NULL,
    CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED ([Id] ASC)
);

