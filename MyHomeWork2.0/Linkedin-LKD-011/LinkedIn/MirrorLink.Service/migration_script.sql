IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220712140849_InitialMigration')
BEGIN
    CREATE TABLE [AdditionInfo] (
        [Id] int NOT NULL IDENTITY,
        [UrlPersonSite] nvarchar(max) NULL,
        [Comment] nvarchar(max) NULL,
        CONSTRAINT [PK_AdditionInfo] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220712140849_InitialMigration')
BEGIN
    CREATE TABLE [Address] (
        [Id] int NOT NULL IDENTITY,
        [Country] nvarchar(max) NULL,
        [City] nvarchar(max) NULL,
        CONSTRAINT [PK_Address] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220712140849_InitialMigration')
BEGIN
    CREATE TABLE [ContactInfo] (
        [Id] int NOT NULL IDENTITY,
        [UrlProfileLinkedIn] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        CONSTRAINT [PK_ContactInfo] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220712140849_InitialMigration')
BEGIN
    CREATE TABLE [CurrentStatus] (
        [Id] int NOT NULL IDENTITY,
        [WaitOffer] bit NOT NULL,
        [SectorJob] nvarchar(max) NULL,
        [Role] nvarchar(max) NULL,
        [TypeJob] nvarchar(max) NULL,
        CONSTRAINT [PK_CurrentStatus] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220712140849_InitialMigration')
BEGIN
    CREATE TABLE [Persons] (
        [Id] int NOT NULL IDENTITY,
        [FirstName] nvarchar(50) NOT NULL,
        [LastName] nvarchar(max) NULL,
        [AddressId] int NULL,
        [ContactInfoId] int NULL,
        [CurrentStatusId] int NULL,
        [AdditionInfoId] int NULL,
        CONSTRAINT [PK_Persons] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Persons_AdditionInfo_AdditionInfoId] FOREIGN KEY ([AdditionInfoId]) REFERENCES [AdditionInfo] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Persons_Address_AddressId] FOREIGN KEY ([AddressId]) REFERENCES [Address] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Persons_ContactInfo_ContactInfoId] FOREIGN KEY ([ContactInfoId]) REFERENCES [ContactInfo] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Persons_CurrentStatus_CurrentStatusId] FOREIGN KEY ([CurrentStatusId]) REFERENCES [CurrentStatus] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220712140849_InitialMigration')
BEGIN
    CREATE TABLE [Attachment] (
        [Id] int NOT NULL IDENTITY,
        [FileName] nvarchar(max) NULL,
        [Content] varbinary(max) NULL,
        [FileType] int NOT NULL,
        [PersonId] int NULL,
        CONSTRAINT [PK_Attachment] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Attachment_Persons_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [Persons] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220712140849_InitialMigration')
BEGIN
    CREATE TABLE [Certificate] (
        [Id] int NOT NULL IDENTITY,
        [CategoryName] nvarchar(max) NULL,
        [IssuedBy] nvarchar(max) NULL,
        [Date] datetime2 NOT NULL,
        [PersonId] int NULL,
        CONSTRAINT [PK_Certificate] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Certificate_Persons_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [Persons] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220712140849_InitialMigration')
BEGIN
    CREATE TABLE [Education] (
        [Id] int NOT NULL IDENTITY,
        [NameEstablishment] nvarchar(max) NULL,
        [Speciality] nvarchar(max) NULL,
        [Degree] nvarchar(max) NULL,
        [StudyBegin] datetime2 NOT NULL,
        [StudyFinish] datetime2 NOT NULL,
        [PersonId] int NULL,
        CONSTRAINT [PK_Education] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Education_Persons_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [Persons] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220712140849_InitialMigration')
BEGIN
    CREATE TABLE [Language] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Level] nvarchar(max) NULL,
        [PersonId] int NULL,
        CONSTRAINT [PK_Language] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Language_Persons_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [Persons] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220712140849_InitialMigration')
BEGIN
    CREATE TABLE [Skill] (
        [Id] int NOT NULL IDENTITY,
        [SkillType] int NOT NULL,
        [SkillLevel] int NOT NULL,
        [PersonId] int NULL,
        CONSTRAINT [PK_Skill] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Skill_Persons_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [Persons] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220712140849_InitialMigration')
BEGIN
    CREATE TABLE [WorkExperience] (
        [Id] int NOT NULL IDENTITY,
        [NameCompany] nvarchar(max) NULL,
        [UrlCompany] nvarchar(max) NULL,
        [Role] nvarchar(max) NULL,
        [TypeJob] nvarchar(max) NULL,
        [Started] datetime2 NOT NULL,
        [Unemployed] datetime2 NOT NULL,
        [Duration] int NOT NULL,
        [PersonId] int NULL,
        CONSTRAINT [PK_WorkExperience] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_WorkExperience_Persons_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [Persons] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220712140849_InitialMigration')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AdditionInfoId', N'AddressId', N'ContactInfoId', N'CurrentStatusId', N'FirstName', N'LastName') AND [object_id] = OBJECT_ID(N'[Persons]'))
        SET IDENTITY_INSERT [Persons] ON;
    INSERT INTO [Persons] ([Id], [AdditionInfoId], [AddressId], [ContactInfoId], [CurrentStatusId], [FirstName], [LastName])
    VALUES (1, NULL, NULL, NULL, NULL, N'TestPersonName', N'TestPersonLastName');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AdditionInfoId', N'AddressId', N'ContactInfoId', N'CurrentStatusId', N'FirstName', N'LastName') AND [object_id] = OBJECT_ID(N'[Persons]'))
        SET IDENTITY_INSERT [Persons] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220712140849_InitialMigration')
BEGIN
    CREATE INDEX [IX_Attachment_PersonId] ON [Attachment] ([PersonId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220712140849_InitialMigration')
BEGIN
    CREATE INDEX [IX_Certificate_PersonId] ON [Certificate] ([PersonId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220712140849_InitialMigration')
BEGIN
    CREATE INDEX [IX_Education_PersonId] ON [Education] ([PersonId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220712140849_InitialMigration')
BEGIN
    CREATE INDEX [IX_Language_PersonId] ON [Language] ([PersonId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220712140849_InitialMigration')
BEGIN
    CREATE INDEX [IX_Persons_AdditionInfoId] ON [Persons] ([AdditionInfoId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220712140849_InitialMigration')
BEGIN
    CREATE INDEX [IX_Persons_AddressId] ON [Persons] ([AddressId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220712140849_InitialMigration')
BEGIN
    CREATE INDEX [IX_Persons_ContactInfoId] ON [Persons] ([ContactInfoId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220712140849_InitialMigration')
BEGIN
    CREATE INDEX [IX_Persons_CurrentStatusId] ON [Persons] ([CurrentStatusId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220712140849_InitialMigration')
BEGIN
    CREATE INDEX [IX_Skill_PersonId] ON [Skill] ([PersonId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220712140849_InitialMigration')
BEGIN
    CREATE INDEX [IX_WorkExperience_PersonId] ON [WorkExperience] ([PersonId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220712140849_InitialMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220712140849_InitialMigration', N'3.1.10');
END;

GO

