IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200131120823_Add Identity')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200131120823_Add Identity')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        [Discriminator] nvarchar(max) NOT NULL,
        [JwtToken] nvarchar(250) NULL,
        [RoleId] int NULL,
        [IsActive] bit NULL,
        [CreatedBy] int NULL,
        [CreatedDate] datetime2 NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200131120823_Add Identity')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200131120823_Add Identity')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200131120823_Add Identity')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200131120823_Add Identity')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200131120823_Add Identity')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200131120823_Add Identity')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200131120823_Add Identity')
BEGIN
    CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200131120823_Add Identity')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200131120823_Add Identity')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200131120823_Add Identity')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200131120823_Add Identity')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200131120823_Add Identity')
BEGIN
    CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200131120823_Add Identity')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200131120823_Add Identity', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200131121632_Add table Candidate')
BEGIN
    CREATE TABLE [TblCandidate] (
        [CandidateId] int NOT NULL IDENTITY,
        [FirstName] nvarchar(250) NOT NULL,
        [LastName] nvarchar(250) NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        [CurrentCompany] nvarchar(250) NULL,
        [TechStack] nvarchar(250) NULL,
        [IsActive] bit NULL,
        [VacancyId] int NULL,
        [CreatedBy] int NULL,
        [CreatedDate] datetime2 NULL,
        CONSTRAINT [PK_TblCandidate] PRIMARY KEY ([CandidateId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200131121632_Add table Candidate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200131121632_Add table Candidate', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200131121835_Add table Category')
BEGIN
    CREATE TABLE [TblCategory] (
        [CategoryId] int NOT NULL IDENTITY,
        [Name] nvarchar(250) NOT NULL,
        [IsActive] bit NULL,
        [CreatedBy] int NULL,
        [CreatedDate] datetime2 NULL,
        CONSTRAINT [PK_TblCategory] PRIMARY KEY ([CategoryId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200131121835_Add table Category')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200131121835_Add table Category', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200131122043_Add table TblExperienceLevel')
BEGIN
    CREATE TABLE [TblExperienceLevel] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(250) NOT NULL,
        [MinExp] int NULL,
        [MaxExp] int NULL,
        [IsActive] bit NULL,
        [CreatedBy] int NULL,
        [CreatedDate] datetime2 NULL,
        [UpdatedBy] int NULL,
        [UpdatedDate] datetime2 NULL,
        CONSTRAINT [PK_TblExperienceLevel] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200131122043_Add table TblExperienceLevel')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200131122043_Add table TblExperienceLevel', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200131122222_Add table TblOption')
BEGIN
    CREATE TABLE [TblOption] (
        [OptionId] int NOT NULL IDENTITY,
        [OptionDescription] nvarchar(500) NOT NULL,
        [IsCorrect] bit NULL,
        [QuestionId] int NULL,
        [Duration] datetime2 NULL,
        [IsActive] bit NULL,
        [CreatedBy] int NULL,
        [CreatedDate] datetime2 NULL,
        [UpdatedBy] int NULL,
        [UpdatedDate] datetime2 NULL,
        CONSTRAINT [PK_TblOption] PRIMARY KEY ([OptionId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200131122222_Add table TblOption')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200131122222_Add table TblOption', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200131122509_Add table TblQuestion')
BEGIN
    CREATE TABLE [TblQuestion] (
        [QuestionId] int NOT NULL IDENTITY,
        [Description] nvarchar(1000) NOT NULL,
        [Type] nvarchar(max) NULL,
        [Time] datetime2 NULL,
        [Marks] int NULL,
        [IsActive] bit NULL,
        [CreatedBy] int NULL,
        [CreatedDate] datetime2 NULL,
        [UpdatedBy] int NULL,
        [UpdatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_TblQuestion] PRIMARY KEY ([QuestionId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200131122509_Add table TblQuestion')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200131122509_Add table TblQuestion', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200131122745_Add table Tbl QuestionCategoryAndExpMapping')
BEGIN
    CREATE TABLE [TblQuestionCategoryAndExpMapping] (
        [Id] int NOT NULL IDENTITY,
        [QuestionId] int NULL,
        [CategoryId] int NULL,
        [ExpLevelId] int NULL,
        CONSTRAINT [PK_TblQuestionCategoryAndExpMapping] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200131122745_Add table Tbl QuestionCategoryAndExpMapping')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200131122745_Add table Tbl QuestionCategoryAndExpMapping', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200131122931_Add table TblRole')
BEGIN
    CREATE TABLE [TblRole] (
        [RoleId] int NOT NULL IDENTITY,
        [RoleName] nvarchar(50) NOT NULL,
        [IsActive] bit NOT NULL,
        CONSTRAINT [PK_TblRole] PRIMARY KEY ([RoleId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200131122931_Add table TblRole')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200131122931_Add table TblRole', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200131123103_Add table TbSessionHistory')
BEGIN
    CREATE TABLE [TblSessionHistory] (
        [Id] int NOT NULL IDENTITY,
        [UserId] int NULL,
        [SessionId] int NULL,
        [IsActive] bit NULL,
        [Jwt] nvarchar(250) NULL,
        [Created] datetime2 NULL,
        CONSTRAINT [PK_TblSessionHistory] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200131123103_Add table TbSessionHistory')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200131123103_Add table TbSessionHistory', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200131123305_Add table TblTest')
BEGIN
    CREATE TABLE [TblTest] (
        [TestId] int NOT NULL IDENTITY,
        [CandidateId] int NULL,
        [CategoryId] int NULL,
        [ExpLevelId] int NULL,
        [TestDate] datetime2 NULL,
        [TestStatus] nvarchar(500) NULL,
        [TotalQuestion] int NULL,
        [AttemptedQuestion] int NULL,
        [Percentage] real NULL,
        [CorrectAnswer] int NULL,
        [WrongAnswer] int NULL,
        [QuestionSkipped] int NULL,
        [Duration] datetime2 NULL,
        [IsActive] bit NULL,
        [CreatedBy] int NULL,
        [CreatedDate] datetime2 NULL,
        [UpdatedBy] int NULL,
        [UpdatedDate] datetime2 NULL,
        CONSTRAINT [PK_TblTest] PRIMARY KEY ([TestId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200131123305_Add table TblTest')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200131123305_Add table TblTest', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200131123431_Add table TblTestDetail')
BEGIN
    CREATE TABLE [TblTestDetails] (
        [TestId] int NOT NULL IDENTITY,
        [QuestionId] int NULL,
        [SelectedOptionId] int NULL,
        [CorrectOptionId] int NULL,
        [AttemptedInDuration] datetime2 NULL,
        [IsActive] bit NULL,
        [CreatedBy] int NULL,
        [CreatedDate] datetime2 NULL,
        [UpdatedBy] int NULL,
        [UpdatedDate] datetime2 NULL,
        CONSTRAINT [PK_TblTestDetails] PRIMARY KEY ([TestId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200131123431_Add table TblTestDetail')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200131123431_Add table TblTestDetail', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200131123624_Add table TblUserRole')
BEGIN
    CREATE TABLE [TblUserRole] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] int NULL,
        [UserId] int NULL,
        CONSTRAINT [PK_TblUserRole] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200131123624_Add table TblUserRole')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200131123624_Add table TblUserRole', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200203043629_Add Table Logging')
BEGIN
    CREATE TABLE [TblLogging] (
        [Id] int NOT NULL IDENTITY,
        [Application] nvarchar(max) NULL,
        [Logged] nvarchar(max) NULL,
        [Level] nvarchar(max) NULL,
        [Message] nvarchar(max) NULL,
        [Logger] nvarchar(max) NULL,
        [CallSite] nvarchar(max) NULL,
        [Exception] nvarchar(max) NULL,
        CONSTRAINT [PK_TblLogging] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200203043629_Add Table Logging')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200203043629_Add Table Logging', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200212042522_add FilePath Property To Logging')
BEGIN
    ALTER TABLE [TblLogging] ADD [FilePath] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200212042522_add FilePath Property To Logging')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200212042522_add FilePath Property To Logging', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200212111542_Increase length of jwt in tbl user')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'JwtToken');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [AspNetUsers] ALTER COLUMN [JwtToken] nvarchar(1000) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200212111542_Increase length of jwt in tbl user')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200212111542_Increase length of jwt in tbl user', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200212112458_Increase length to 2000 of jwt in tbl user')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'JwtToken');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [AspNetUsers] ALTER COLUMN [JwtToken] nvarchar(2000) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200212112458_Increase length to 2000 of jwt in tbl user')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200212112458_Increase length to 2000 of jwt in tbl user', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200214061831_Change Datatype of CreatedBy to String')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TblExperienceLevel]') AND [c].[name] = N'CreatedBy');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [TblExperienceLevel] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [TblExperienceLevel] ALTER COLUMN [CreatedBy] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200214061831_Change Datatype of CreatedBy to String')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200214061831_Change Datatype of CreatedBy to String', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200214062151_Change Datatype of UpdatedBy to String in TblExperienceLevel')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TblExperienceLevel]') AND [c].[name] = N'UpdatedBy');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [TblExperienceLevel] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [TblExperienceLevel] ALTER COLUMN [UpdatedBy] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200214062151_Change Datatype of UpdatedBy to String in TblExperienceLevel')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200214062151_Change Datatype of UpdatedBy to String in TblExperienceLevel', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200214062430_Change Datatype of CreatedBy to String in TblCandidate')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TblCandidate]') AND [c].[name] = N'CreatedBy');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [TblCandidate] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [TblCandidate] ALTER COLUMN [CreatedBy] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200214062430_Change Datatype of CreatedBy to String in TblCandidate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200214062430_Change Datatype of CreatedBy to String in TblCandidate', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200214063237_Change Datatype of CreatedBy to String in TblCategory')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TblCategory]') AND [c].[name] = N'CreatedBy');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [TblCategory] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [TblCategory] ALTER COLUMN [CreatedBy] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200214063237_Change Datatype of CreatedBy to String in TblCategory')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200214063237_Change Datatype of CreatedBy to String in TblCategory', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200214063355_Change Datatype of CreatedBy and UpdatedBy to String in TblOption')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TblOption]') AND [c].[name] = N'UpdatedBy');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [TblOption] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [TblOption] ALTER COLUMN [UpdatedBy] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200214063355_Change Datatype of CreatedBy and UpdatedBy to String in TblOption')
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TblOption]') AND [c].[name] = N'CreatedBy');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [TblOption] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [TblOption] ALTER COLUMN [CreatedBy] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200214063355_Change Datatype of CreatedBy and UpdatedBy to String in TblOption')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200214063355_Change Datatype of CreatedBy and UpdatedBy to String in TblOption', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200214063459_Change Datatype of CreatedBy and UpdatedBy to String in TblQuestion')
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TblQuestion]') AND [c].[name] = N'UpdatedBy');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [TblQuestion] DROP CONSTRAINT [' + @var8 + '];');
    ALTER TABLE [TblQuestion] ALTER COLUMN [UpdatedBy] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200214063459_Change Datatype of CreatedBy and UpdatedBy to String in TblQuestion')
BEGIN
    DECLARE @var9 sysname;
    SELECT @var9 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TblQuestion]') AND [c].[name] = N'CreatedBy');
    IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [TblQuestion] DROP CONSTRAINT [' + @var9 + '];');
    ALTER TABLE [TblQuestion] ALTER COLUMN [CreatedBy] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200214063459_Change Datatype of CreatedBy and UpdatedBy to String in TblQuestion')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200214063459_Change Datatype of CreatedBy and UpdatedBy to String in TblQuestion', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200214063626_Change Datatype of CreatedBy and UpdatedBy to String in TblTest')
BEGIN
    DECLARE @var10 sysname;
    SELECT @var10 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TblTest]') AND [c].[name] = N'UpdatedBy');
    IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [TblTest] DROP CONSTRAINT [' + @var10 + '];');
    ALTER TABLE [TblTest] ALTER COLUMN [UpdatedBy] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200214063626_Change Datatype of CreatedBy and UpdatedBy to String in TblTest')
BEGIN
    DECLARE @var11 sysname;
    SELECT @var11 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TblTest]') AND [c].[name] = N'CreatedBy');
    IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [TblTest] DROP CONSTRAINT [' + @var11 + '];');
    ALTER TABLE [TblTest] ALTER COLUMN [CreatedBy] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200214063626_Change Datatype of CreatedBy and UpdatedBy to String in TblTest')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200214063626_Change Datatype of CreatedBy and UpdatedBy to String in TblTest', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200214063742_Change Datatype of CreatedBy and UpdatedBy to String in TblTestDetails')
BEGIN
    DECLARE @var12 sysname;
    SELECT @var12 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TblTestDetails]') AND [c].[name] = N'UpdatedBy');
    IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [TblTestDetails] DROP CONSTRAINT [' + @var12 + '];');
    ALTER TABLE [TblTestDetails] ALTER COLUMN [UpdatedBy] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200214063742_Change Datatype of CreatedBy and UpdatedBy to String in TblTestDetails')
BEGIN
    DECLARE @var13 sysname;
    SELECT @var13 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TblTestDetails]') AND [c].[name] = N'CreatedBy');
    IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [TblTestDetails] DROP CONSTRAINT [' + @var13 + '];');
    ALTER TABLE [TblTestDetails] ALTER COLUMN [CreatedBy] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200214063742_Change Datatype of CreatedBy and UpdatedBy to String in TblTestDetails')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200214063742_Change Datatype of CreatedBy and UpdatedBy to String in TblTestDetails', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200214063856_Change Datatype of CreatedBy to String in TblUser')
BEGIN
    DECLARE @var14 sysname;
    SELECT @var14 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'CreatedBy');
    IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var14 + '];');
    ALTER TABLE [AspNetUsers] ALTER COLUMN [CreatedBy] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200214063856_Change Datatype of CreatedBy to String in TblUser')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200214063856_Change Datatype of CreatedBy to String in TblUser', N'3.1.1');
END;

GO

