CREATE TABLE [dbo].[Users] (
    [Id]                  BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]                NVARCHAR (100) NOT NULL,
    [Email]               NVARCHAR (100) NOT NULL,
    [Password]            NVARCHAR (MAX) NOT NULL,
    [PasswordSalt]        NVARCHAR (MAX) NOT NULL,
    [RoleId]              INT            NOT NULL,
    [Mobile]              NVARCHAR (MAX) NULL,
    [Address]             NVARCHAR (MAX) NULL,
    [Avatar]              NVARCHAR (MAX) NULL,
    [IsLock]              BIT            NOT NULL,
    [ForgetPasswordToken] NVARCHAR (MAX) NULL,
    [PasswordRequestDate] DATETIME2 (7)  NULL,
    [CreatedBy]           BIGINT         NULL,
    [CreatedDate]         DATETIME2 (7)  NULL,
    [UpdatedBy]           BIGINT         NULL,
    [UpdatedDate]         DATETIME2 (7)  NULL,
    [IsDeleted]           BIT            NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Users_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([Id]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_Email]
    ON [dbo].[Users]([Email] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Users_RoleId]
    ON [dbo].[Users]([RoleId] ASC);

