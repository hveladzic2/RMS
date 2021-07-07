IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210507014026_Initial')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210507014026_Initial')
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
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210507014026_Initial')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210507014026_Initial')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210507014026_Initial')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210507014026_Initial')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210507014026_Initial')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210507014026_Initial')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210507014026_Initial')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210507014026_Initial')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210507014026_Initial')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210507014026_Initial')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210507014026_Initial')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210507014026_Initial')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210507014026_Initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210507014026_Initial', N'5.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210507212020_Aplikant-Lokacija_Relationship')
BEGIN
    CREATE TABLE [Aplikanti] (
        [Id] int NOT NULL IDENTITY,
        [Ime] nvarchar(max) NULL,
        [Prezime] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [KontakTelefon] nvarchar(max) NULL,
        CONSTRAINT [PK_Aplikanti] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210507212020_Aplikant-Lokacija_Relationship')
BEGIN
    CREATE TABLE [Lokacije] (
        [Id] int NOT NULL IDENTITY,
        [Drzava] nvarchar(max) NULL,
        [Grad] nvarchar(max) NULL,
        [Ulica] nvarchar(max) NULL,
        CONSTRAINT [PK_Lokacije] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210507212020_Aplikant-Lokacija_Relationship')
BEGIN
    CREATE TABLE [AplikantLokacija] (
        [AplikantiId] int NOT NULL,
        [LokacijeId] int NOT NULL,
        CONSTRAINT [PK_AplikantLokacija] PRIMARY KEY ([AplikantiId], [LokacijeId]),
        CONSTRAINT [FK_AplikantLokacija_Aplikanti_AplikantiId] FOREIGN KEY ([AplikantiId]) REFERENCES [Aplikanti] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AplikantLokacija_Lokacije_LokacijeId] FOREIGN KEY ([LokacijeId]) REFERENCES [Lokacije] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210507212020_Aplikant-Lokacija_Relationship')
BEGIN
    CREATE INDEX [IX_AplikantLokacija_LokacijeId] ON [AplikantLokacija] ([LokacijeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210507212020_Aplikant-Lokacija_Relationship')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210507212020_Aplikant-Lokacija_Relationship', N'5.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210507212308_changeFKNames')
BEGIN
    ALTER TABLE [AplikantLokacija] DROP CONSTRAINT [FK_AplikantLokacija_Aplikanti_AplikantiId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210507212308_changeFKNames')
BEGIN
    ALTER TABLE [AplikantLokacija] DROP CONSTRAINT [FK_AplikantLokacija_Lokacije_LokacijeId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210507212308_changeFKNames')
BEGIN
    EXEC sp_rename N'[AplikantLokacija].[LokacijeId]', N'LokacijaId', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210507212308_changeFKNames')
BEGIN
    EXEC sp_rename N'[AplikantLokacija].[AplikantiId]', N'AplikantId', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210507212308_changeFKNames')
BEGIN
    EXEC sp_rename N'[AplikantLokacija].[IX_AplikantLokacija_LokacijeId]', N'IX_AplikantLokacija_LokacijaId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210507212308_changeFKNames')
BEGIN
    ALTER TABLE [AplikantLokacija] ADD CONSTRAINT [FK_AplikantLokacija_Aplikanti_AplikantId] FOREIGN KEY ([AplikantId]) REFERENCES [Aplikanti] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210507212308_changeFKNames')
BEGIN
    ALTER TABLE [AplikantLokacija] ADD CONSTRAINT [FK_AplikantLokacija_Lokacije_LokacijaId] FOREIGN KEY ([LokacijaId]) REFERENCES [Lokacije] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210507212308_changeFKNames')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210507212308_changeFKNames', N'5.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508000239_DBModel')
BEGIN
    DROP TABLE [AplikantLokacija];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508000239_DBModel')
BEGIN
    ALTER TABLE [Lokacije] DROP CONSTRAINT [PK_Lokacije];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508000239_DBModel')
BEGIN
    ALTER TABLE [Aplikanti] DROP CONSTRAINT [PK_Aplikanti];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508000239_DBModel')
BEGIN
    EXEC sp_rename N'[Lokacije]', N'Adresa';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508000239_DBModel')
BEGIN
    EXEC sp_rename N'[Aplikanti]', N'ProfilAplikanta';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508000239_DBModel')
BEGIN
    ALTER TABLE [ProfilAplikanta] ADD [AdresaId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508000239_DBModel')
BEGIN
    ALTER TABLE [ProfilAplikanta] ADD [ProfilaSlika] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508000239_DBModel')
BEGIN
    ALTER TABLE [Adresa] ADD CONSTRAINT [PK_AdresaAplikanta] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508000239_DBModel')
BEGIN
    ALTER TABLE [ProfilAplikanta] ADD CONSTRAINT [PK_ProfilAplikanta] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508000239_DBModel')
BEGIN
    CREATE TABLE [Lokacija] (
        [Id] int NOT NULL IDENTITY,
        [Drzava] nvarchar(max) NULL,
        [Grad] nvarchar(max) NULL,
        [Ulica] nvarchar(max) NULL,
        CONSTRAINT [PK_AdresaKompanije] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508000239_DBModel')
BEGIN
    CREATE TABLE [Obrazovanje] (
        [Id] int NOT NULL IDENTITY,
        [Zvanje] nvarchar(max) NULL,
        [StepenCertifikata] nvarchar(max) NULL,
        [NazivObrazovneInstitucije] nvarchar(max) NULL,
        [Drzava] nvarchar(max) NULL,
        [Grad] nvarchar(max) NULL,
        [ProfilAplikantaId] int NULL,
        CONSTRAINT [PK_Obrazovanje] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Obrazovanje_ProfilAplikanta_ProfilAplikantaId] FOREIGN KEY ([ProfilAplikantaId]) REFERENCES [ProfilAplikanta] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508000239_DBModel')
BEGIN
    CREATE TABLE [RadnoIskustvo] (
        [Id] int NOT NULL IDENTITY,
        [NazivKompanije] nvarchar(max) NULL,
        [Adresa] nvarchar(max) NULL,
        [RadnaPozicija] nvarchar(max) NULL,
        [DatumPocetka] int NOT NULL,
        [DatumZavrsetka] int NOT NULL,
        [ProfilAplikantaId] int NULL,
        CONSTRAINT [PK_RadnoIskustvo] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_RadnoIskustvo_ProfilAplikanta_ProfilAplikantaId] FOREIGN KEY ([ProfilAplikantaId]) REFERENCES [ProfilAplikanta] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508000239_DBModel')
BEGIN
    CREATE TABLE [Status] (
        [Id] int NOT NULL IDENTITY,
        [OpisniAtribut] nvarchar(max) NULL,
        CONSTRAINT [PK_Status] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508000239_DBModel')
BEGIN
    CREATE TABLE [Vjestine] (
        [Id] int NOT NULL IDENTITY,
        [Vjestina] nvarchar(max) NULL,
        [NivoPoznavanja] nvarchar(max) NULL,
        [ProfilAplikantaId] int NULL,
        CONSTRAINT [PK_Vjestine] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Vjestine_ProfilAplikanta_ProfilAplikantaId] FOREIGN KEY ([ProfilAplikantaId]) REFERENCES [ProfilAplikanta] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508000239_DBModel')
BEGIN
    CREATE TABLE [ProfilKompanije] (
        [Id] int NOT NULL IDENTITY,
        [Naziv] nvarchar(max) NULL,
        [Misija] nvarchar(max) NULL,
        [Logo] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [tTelefon] nvarchar(max) NULL,
        [WebSiteURL] nvarchar(max) NULL,
        [AdresaId] int NULL,
        CONSTRAINT [PK_ProfilKompanije] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ProfilKompanije_AdresaKompanije_AdresaId] FOREIGN KEY ([AdresaId]) REFERENCES [Lokacija] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508000239_DBModel')
BEGIN
    CREATE TABLE [Oglas] (
        [Id] int NOT NULL IDENTITY,
        [RadnoMjesto] nvarchar(max) NULL,
        [DodatneInformacije] nvarchar(max) NULL,
        [PocetakPrijave] int NOT NULL,
        [DatumIsteka] int NOT NULL,
        [StatusId] int NULL,
        [ProfilKompanijeId] int NULL,
        CONSTRAINT [PK_Oglas] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Oglas_ProfilKompanije_ProfilKompanijeId] FOREIGN KEY ([ProfilKompanijeId]) REFERENCES [ProfilKompanije] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Oglas_Status_StatusId] FOREIGN KEY ([StatusId]) REFERENCES [Status] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508000239_DBModel')
BEGIN
    CREATE TABLE [OglasProfilAplikanta] (
        [OglasiId] int NOT NULL,
        [ProfiliAplikanataId] int NOT NULL,
        CONSTRAINT [PK_OglasProfilAplikanta] PRIMARY KEY ([OglasiId], [ProfiliAplikanataId]),
        CONSTRAINT [FK_OglasProfilAplikanta_Oglas_OglasiId] FOREIGN KEY ([OglasiId]) REFERENCES [Oglas] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_OglasProfilAplikanta_ProfilAplikanta_ProfiliAplikanataId] FOREIGN KEY ([ProfiliAplikanataId]) REFERENCES [ProfilAplikanta] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508000239_DBModel')
BEGIN
    CREATE INDEX [IX_ProfilAplikanta_AdresaId] ON [ProfilAplikanta] ([AdresaId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508000239_DBModel')
BEGIN
    CREATE INDEX [IX_Obrazovanje_ProfilAplikantaId] ON [Obrazovanje] ([ProfilAplikantaId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508000239_DBModel')
BEGIN
    CREATE INDEX [IX_Oglas_ProfilKompanijeId] ON [Oglas] ([ProfilKompanijeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508000239_DBModel')
BEGIN
    CREATE INDEX [IX_Oglas_StatusId] ON [Oglas] ([StatusId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508000239_DBModel')
BEGIN
    CREATE INDEX [IX_OglasProfilAplikanta_ProfiliAplikanataId] ON [OglasProfilAplikanta] ([ProfiliAplikanataId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508000239_DBModel')
BEGIN
    CREATE INDEX [IX_ProfilKompanije_AdresaId] ON [ProfilKompanije] ([AdresaId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508000239_DBModel')
BEGIN
    CREATE INDEX [IX_RadnoIskustvo_ProfilAplikantaId] ON [RadnoIskustvo] ([ProfilAplikantaId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508000239_DBModel')
BEGIN
    CREATE INDEX [IX_Vjestine_ProfilAplikantaId] ON [Vjestine] ([ProfilAplikantaId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508000239_DBModel')
BEGIN
    ALTER TABLE [ProfilAplikanta] ADD CONSTRAINT [FK_ProfilAplikanta_AdresaAplikanta_AdresaId] FOREIGN KEY ([AdresaId]) REFERENCES [Adresa] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508000239_DBModel')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210508000239_DBModel', N'5.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508015635_ProfileCon')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProfilAplikanta]') AND [c].[name] = N'Email');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [ProfilAplikanta] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [ProfilAplikanta] DROP COLUMN [Email];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508015635_ProfileCon')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProfilAplikanta]') AND [c].[name] = N'ProfilaSlika');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [ProfilAplikanta] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [ProfilAplikanta] DROP COLUMN [ProfilaSlika];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508015635_ProfileCon')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProfilAplikanta]') AND [c].[name] = N'Prezime');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [ProfilAplikanta] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [ProfilAplikanta] ALTER COLUMN [Prezime] nvarchar(50) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508015635_ProfileCon')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProfilAplikanta]') AND [c].[name] = N'KontakTelefon');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [ProfilAplikanta] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [ProfilAplikanta] ALTER COLUMN [KontakTelefon] nvarchar(50) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508015635_ProfileCon')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProfilAplikanta]') AND [c].[name] = N'Ime');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [ProfilAplikanta] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [ProfilAplikanta] ALTER COLUMN [Ime] nvarchar(50) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508015635_ProfileCon')
BEGIN
    ALTER TABLE [ProfilAplikanta] ADD [SlikaProfila] nvarchar(50) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508015635_ProfileCon')
BEGIN
    ALTER TABLE [ProfilAplikanta] ADD [UserId] nvarchar(450) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508015635_ProfileCon')
BEGIN
    CREATE INDEX [IX_ProfilAplikanta_UserId] ON [ProfilAplikanta] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508015635_ProfileCon')
BEGIN
    ALTER TABLE [ProfilAplikanta] ADD CONSTRAINT [FK_ProfilAplikanta_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508015635_ProfileCon')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210508015635_ProfileCon', N'5.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508021548_updateDB')
BEGIN
    EXEC sp_rename N'[ProfilAplikanta].[KontakTelefon]', N'KontaktTelefon', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508021548_updateDB')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210508021548_updateDB', N'5.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508022358_ne')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210508022358_ne', N'5.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508131445_update')
BEGIN
    ALTER TABLE [ProfilAplikanta] ADD [DatumRodjenja] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508131445_update')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210508131445_update', N'5.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508132850_migration1')
BEGIN
    ALTER TABLE [Lokacija] ADD [Broj] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508132850_migration1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210508132850_migration1', N'5.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508133315_updateProfile')
BEGIN
    ALTER TABLE [ProfilAplikanta] ADD [Drzava] nvarchar(50) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508133315_updateProfile')
BEGIN
    ALTER TABLE [ProfilAplikanta] ADD [Grad] nvarchar(50) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508133315_updateProfile')
BEGIN
    ALTER TABLE [ProfilAplikanta] ADD [Ulica] nvarchar(50) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508133315_updateProfile')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210508133315_updateProfile', N'5.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508134426_izmjene')
BEGIN
    EXEC sp_rename N'[ProfilAplikanta].[Ulica]', N'Adresa', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508134426_izmjene')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210508134426_izmjene', N'5.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508144621_m')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210508144621_m', N'5.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508150459_RefreshToken')
BEGIN
    CREATE TABLE [RefreshToken] (
        [Id] int NOT NULL IDENTITY,
        [Token] nvarchar(max) NULL,
        [JwtId] nvarchar(max) NULL,
        [CreatedDateTimeUtc] datetime2 NOT NULL,
        [ExpiryDateTimeUtc] datetime2 NOT NULL,
        [Used] bit NOT NULL,
        [Invalidated] bit NOT NULL,
        [UserId] nvarchar(450) NULL,
        CONSTRAINT [PK_RefreshToken] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_RefreshToken_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508150459_RefreshToken')
BEGIN
    CREATE INDEX [IX_RefreshToken_UserId] ON [RefreshToken] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210508150459_RefreshToken')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210508150459_RefreshToken', N'5.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210509220830_update1')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Lokacija]') AND [c].[name] = N'Broj');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Lokacija] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [Lokacija] DROP COLUMN [Broj];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210509220830_update1')
BEGIN
    CREATE TABLE [GetUserByIds] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(max) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [Ime] nvarchar(max) NULL,
        [Prezime] nvarchar(max) NULL,
        [Drzava] nvarchar(max) NULL,
        [Grad] nvarchar(max) NULL,
        [Adresa] nvarchar(max) NULL,
        [DatumRodjenja] int NOT NULL,
        [SlikaProfila] nvarchar(max) NULL,
        [KontaktTelefon] nvarchar(max) NULL,
        CONSTRAINT [PK_GetUserByIds] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210509220830_update1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210509220830_update1', N'5.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210510215609_addedNewRoles')
BEGIN
    EXEC sp_rename N'[ProfilKompanije].[Email]', N'KontaktEmail', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210510215609_addedNewRoles')
BEGIN
    ALTER TABLE [ProfilKompanije] ADD [UserId] nvarchar(450) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210510215609_addedNewRoles')
BEGIN
    CREATE TABLE [ProfilAdministratora] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NULL,
        [Ime] nvarchar(50) NULL,
        [Prezime] nvarchar(50) NULL,
        [KontaktTelefon] nvarchar(50) NULL,
        [SlikaProfila] nvarchar(50) NULL,
        CONSTRAINT [PK_ProfilAdministratora] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ProfilAdministratora_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210510215609_addedNewRoles')
BEGIN
    CREATE INDEX [IX_ProfilKompanije_UserId] ON [ProfilKompanije] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210510215609_addedNewRoles')
BEGIN
    CREATE INDEX [IX_ProfilAdministratora_UserId] ON [ProfilAdministratora] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210510215609_addedNewRoles')
BEGIN
    ALTER TABLE [ProfilKompanije] ADD CONSTRAINT [FK_ProfilKompanije_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210510215609_addedNewRoles')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210510215609_addedNewRoles', N'5.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210510234033_updateProfilKompanije')
BEGIN
    ALTER TABLE [Lokacija] ADD [ProfilKompanijaId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210510234033_updateProfilKompanije')
BEGIN
    CREATE INDEX [IX_Lokacija_ProfilKompanijaId] ON [Lokacija] ([ProfilKompanijaId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210510234033_updateProfilKompanije')
BEGIN
    ALTER TABLE [Lokacija] ADD CONSTRAINT [FK_Lokacija_ProfilKompanije_ProfilKompanijaId] FOREIGN KEY ([ProfilKompanijaId]) REFERENCES [ProfilKompanije] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210510234033_updateProfilKompanije')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210510234033_updateProfilKompanije', N'5.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511000740_Oglas-LokacijaRelationship')
BEGIN
    CREATE TABLE [LokacijaOglas] (
        [LokacijaId] int NOT NULL,
        [OglasId] int NOT NULL,
        CONSTRAINT [PK_LokacijaOglas] PRIMARY KEY ([LokacijaId], [OglasId]),
        CONSTRAINT [FK_LokacijaOglas_Lokacija_LokacijaId] FOREIGN KEY ([LokacijaId]) REFERENCES [Lokacija] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_LokacijaOglas_Oglas_OglasId] FOREIGN KEY ([OglasId]) REFERENCES [Oglas] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511000740_Oglas-LokacijaRelationship')
BEGIN
    CREATE INDEX [IX_LokacijaOglas_OglasId] ON [LokacijaOglas] ([OglasId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511000740_Oglas-LokacijaRelationship')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210511000740_Oglas-LokacijaRelationship', N'5.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210523183443_Oglas_Table_update')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProfilAdministratora]') AND [c].[name] = N'KontaktTelefon');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [ProfilAdministratora] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [ProfilAdministratora] DROP COLUMN [KontaktTelefon];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210523183443_Oglas_Table_update')
BEGIN
    EXEC sp_rename N'[Oglas].[RadnoMjesto]', N'Pozicija', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210523183443_Oglas_Table_update')
BEGIN
    ALTER TABLE [Oglas] ADD [Odjel] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210523183443_Oglas_Table_update')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210523183443_Oglas_Table_update', N'5.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210523192714_little_change')
BEGIN
    ALTER TABLE [ProfilAplikanta] ADD [MotivacionoPismo] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210523192714_little_change')
BEGIN
    ALTER TABLE [ProfilAplikanta] ADD [Spol] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210523192714_little_change')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210523192714_little_change', N'5.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210523193247_table_Aplikacija')
BEGIN
    CREATE TABLE [Aplikacija] (
        [Id] int NOT NULL IDENTITY,
        [Ime] nvarchar(50) NULL,
        [Prezime] nvarchar(50) NULL,
        [KontaktTelefon] nvarchar(50) NULL,
        [SlikaProfila] nvarchar(50) NULL,
        [CVdokument] nvarchar(50) NULL,
        [Drzava] nvarchar(50) NULL,
        [Grad] nvarchar(50) NULL,
        [Adresa] nvarchar(50) NULL,
        [Spol] nvarchar(max) NULL,
        [MotivacionoPismo] nvarchar(max) NULL,
        [DatumRodjenja] nvarchar(max) NULL,
        CONSTRAINT [PK_Aplikacija] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210523193247_table_Aplikacija')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210523193247_table_Aplikacija', N'5.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210523210716_Oglas_edited')
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Oglas]') AND [c].[name] = N'PocetakPrijave');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Oglas] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [Oglas] ALTER COLUMN [PocetakPrijave] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210523210716_Oglas_edited')
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Oglas]') AND [c].[name] = N'DatumIsteka');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Oglas] DROP CONSTRAINT [' + @var8 + '];');
    ALTER TABLE [Oglas] ALTER COLUMN [DatumIsteka] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210523210716_Oglas_edited')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210523210716_Oglas_edited', N'5.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210526194453_fk_oglasi')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210526194453_fk_oglasi', N'5.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210526194800_update-oglasi_fk')
BEGIN
    DECLARE @var9 sysname;
    SELECT @var9 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Oglas]') AND [c].[name] = N'ProfilKompanijeId');
    IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [Oglas] DROP CONSTRAINT [' + @var9 + '];');
    ALTER TABLE [Oglas] DROP COLUMN [ProfilKompanijeId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210526194800_update-oglasi_fk')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210526194800_update-oglasi_fk', N'5.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210526195603_neka...')
BEGIN
    ALTER TABLE [Oglas] ADD [ProfilKompanijeId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210526195603_neka...')
BEGIN
    CREATE INDEX [IX_Oglas_ProfilKompanijeId] ON [Oglas] ([ProfilKompanijeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210526195603_neka...')
BEGIN
    ALTER TABLE [Oglas] ADD CONSTRAINT [FK_Oglas_ProfilKompanije_ProfilKompanijeId] FOREIGN KEY ([ProfilKompanijeId]) REFERENCES [ProfilKompanije] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210526195603_neka...')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210526195603_neka...', N'5.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210526200736_app-company')
BEGIN
    ALTER TABLE [Aplikacija] ADD [ProfilKompanijeId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210526200736_app-company')
BEGIN
    CREATE INDEX [IX_Aplikacija_ProfilKompanijeId] ON [Aplikacija] ([ProfilKompanijeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210526200736_app-company')
BEGIN
    ALTER TABLE [Aplikacija] ADD CONSTRAINT [FK_Aplikacija_ProfilKompanije_ProfilKompanijeId] FOREIGN KEY ([ProfilKompanijeId]) REFERENCES [ProfilKompanije] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210526200736_app-company')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210526200736_app-company', N'5.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210526202107_status-lokacija')
BEGIN
    ALTER TABLE [Status] ADD [LokacijaId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210526202107_status-lokacija')
BEGIN
    CREATE INDEX [IX_Status_LokacijaId] ON [Status] ([LokacijaId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210526202107_status-lokacija')
BEGIN
    ALTER TABLE [Status] ADD CONSTRAINT [FK_Status_Lokacija_LokacijaId] FOREIGN KEY ([LokacijaId]) REFERENCES [Lokacija] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210526202107_status-lokacija')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210526202107_status-lokacija', N'5.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210526204027_delete-fk')
BEGIN
    DECLARE @var10 sysname;
    SELECT @var10 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Oglas]') AND [c].[name] = N'ProfilKompanijeId');
    IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [Oglas] DROP CONSTRAINT [' + @var10 + '];');
    ALTER TABLE [Oglas] DROP COLUMN [ProfilKompanijeId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210526204027_delete-fk')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210526204027_delete-fk', N'5.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210527071749_ispravke')
BEGIN
    ALTER TABLE [Oglas] ADD [ProfilKompanijeId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210527071749_ispravke')
BEGIN
    CREATE INDEX [IX_Oglas_ProfilKompanijeId] ON [Oglas] ([ProfilKompanijeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210527071749_ispravke')
BEGIN
    ALTER TABLE [Oglas] ADD CONSTRAINT [FK_Oglas_ProfilKompanije_ProfilKompanijeId] FOREIGN KEY ([ProfilKompanijeId]) REFERENCES [ProfilKompanije] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210527071749_ispravke')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210527071749_ispravke', N'5.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528132600_Oglasi')
BEGIN
    DROP TABLE [LokacijaOglas];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528132600_Oglasi')
BEGIN
    DROP TABLE [OglasProfilAplikanta];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528132600_Oglasi')
BEGIN
    EXEC sp_rename N'[Oglas].[ProfilKompanijeId]', N'ProfilKompanijeId1', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528132600_Oglasi')
BEGIN
    EXEC sp_rename N'[Oglas].[IX_Oglas_ProfilKompanijeId]', N'IX_Oglas_ProfilKompanijeId1', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528132600_Oglasi')
BEGIN
    CREATE TABLE [LokacijaOglasi] (
        [LokacijaId] int NOT NULL,
        [OglasId] int NOT NULL,
        CONSTRAINT [PK_LokacijaOglasi] PRIMARY KEY ([LokacijaId], [OglasId]),
        CONSTRAINT [FK_LokacijaOglasi_Lokacija_LokacijaId] FOREIGN KEY ([LokacijaId]) REFERENCES [Lokacija] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_LokacijaOglasi_Oglas_OglasId] FOREIGN KEY ([OglasId]) REFERENCES [Oglas] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528132600_Oglasi')
BEGIN
    CREATE TABLE [OglasiProfilAplikanta] (
        [OglasiId] int NOT NULL,
        [ProfiliAplikanataId] int NOT NULL,
        CONSTRAINT [PK_OglasiProfilAplikanta] PRIMARY KEY ([OglasiId], [ProfiliAplikanataId]),
        CONSTRAINT [FK_OglasiProfilAplikanta_Oglas_OglasiId] FOREIGN KEY ([OglasiId]) REFERENCES [Oglas] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_OglasiProfilAplikanta_ProfilAplikanta_ProfiliAplikanataId] FOREIGN KEY ([ProfiliAplikanataId]) REFERENCES [ProfilAplikanta] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528132600_Oglasi')
BEGIN
    CREATE INDEX [IX_LokacijaOglasi_OglasId] ON [LokacijaOglasi] ([OglasId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528132600_Oglasi')
BEGIN
    CREATE INDEX [IX_OglasiProfilAplikanta_ProfiliAplikanataId] ON [OglasiProfilAplikanta] ([ProfiliAplikanataId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528132600_Oglasi')
BEGIN
    ALTER TABLE [Oglas] ADD CONSTRAINT [FK_Oglas_ProfilKompanije_ProfilKompanijeId1] FOREIGN KEY ([ProfilKompanijeId1]) REFERENCES [ProfilKompanije] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528132600_Oglasi')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210528132600_Oglasi', N'5.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528133744_migracij2')
BEGIN
    ALTER TABLE [LokacijaOglasi] DROP CONSTRAINT [FK_LokacijaOglasi_Oglas_OglasId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528133744_migracij2')
BEGIN
    ALTER TABLE [OglasiProfilAplikanta] DROP CONSTRAINT [FK_OglasiProfilAplikanta_Oglas_OglasiId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528133744_migracij2')
BEGIN
    ALTER TABLE [ProfilAplikanta] ADD [OglasId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528133744_migracij2')
BEGIN
    ALTER TABLE [Lokacija] ADD [OglasId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528133744_migracij2')
BEGIN
    CREATE TABLE [Oglasi] (
        [Id] int NOT NULL IDENTITY,
        [Odjel] nvarchar(max) NULL,
        [Pozicija] nvarchar(max) NULL,
        [DodatneInformacije] nvarchar(max) NULL,
        [PocetakPrijave] nvarchar(max) NULL,
        [DatumIsteka] nvarchar(max) NULL,
        [ProfilKompanijeId1] int NULL,
        [StatusId] int NULL,
        CONSTRAINT [PK_Oglasi] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Oglasi_ProfilKompanije_ProfilKompanijeId1] FOREIGN KEY ([ProfilKompanijeId1]) REFERENCES [ProfilKompanije] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Oglasi_Status_StatusId] FOREIGN KEY ([StatusId]) REFERENCES [Status] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528133744_migracij2')
BEGIN
    CREATE INDEX [IX_ProfilAplikanta_OglasId] ON [ProfilAplikanta] ([OglasId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528133744_migracij2')
BEGIN
    CREATE INDEX [IX_Lokacija_OglasId] ON [Lokacija] ([OglasId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528133744_migracij2')
BEGIN
    CREATE INDEX [IX_Oglasi_ProfilKompanijeId1] ON [Oglasi] ([ProfilKompanijeId1]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528133744_migracij2')
BEGIN
    CREATE INDEX [IX_Oglasi_StatusId] ON [Oglasi] ([StatusId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528133744_migracij2')
BEGIN
    ALTER TABLE [Lokacija] ADD CONSTRAINT [FK_Lokacija_Oglas_OglasId] FOREIGN KEY ([OglasId]) REFERENCES [Oglas] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528133744_migracij2')
BEGIN
    ALTER TABLE [LokacijaOglasi] ADD CONSTRAINT [FK_LokacijaOglasi_Oglasi_OglasId] FOREIGN KEY ([OglasId]) REFERENCES [Oglasi] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528133744_migracij2')
BEGIN
    ALTER TABLE [OglasiProfilAplikanta] ADD CONSTRAINT [FK_OglasiProfilAplikanta_Oglasi_OglasiId] FOREIGN KEY ([OglasiId]) REFERENCES [Oglasi] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528133744_migracij2')
BEGIN
    ALTER TABLE [ProfilAplikanta] ADD CONSTRAINT [FK_ProfilAplikanta_Oglas_OglasId] FOREIGN KEY ([OglasId]) REFERENCES [Oglas] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528133744_migracij2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210528133744_migracij2', N'5.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528133907_migracija2')
BEGIN
    ALTER TABLE [Lokacija] DROP CONSTRAINT [FK_Lokacija_Oglas_OglasId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528133907_migracija2')
BEGIN
    ALTER TABLE [ProfilAplikanta] DROP CONSTRAINT [FK_ProfilAplikanta_Oglas_OglasId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528133907_migracija2')
BEGIN
    DROP TABLE [Oglas];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528133907_migracija2')
BEGIN
    DROP INDEX [IX_ProfilAplikanta_OglasId] ON [ProfilAplikanta];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528133907_migracija2')
BEGIN
    DROP INDEX [IX_Lokacija_OglasId] ON [Lokacija];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528133907_migracija2')
BEGIN
    DECLARE @var11 sysname;
    SELECT @var11 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProfilAplikanta]') AND [c].[name] = N'OglasId');
    IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [ProfilAplikanta] DROP CONSTRAINT [' + @var11 + '];');
    ALTER TABLE [ProfilAplikanta] DROP COLUMN [OglasId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528133907_migracija2')
BEGIN
    DECLARE @var12 sysname;
    SELECT @var12 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Lokacija]') AND [c].[name] = N'OglasId');
    IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [Lokacija] DROP CONSTRAINT [' + @var12 + '];');
    ALTER TABLE [Lokacija] DROP COLUMN [OglasId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528133907_migracija2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210528133907_migracija2', N'5.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528134953_oglasiTable')
BEGIN
    DROP TABLE [LokacijaOglasi];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528134953_oglasiTable')
BEGIN
    DROP TABLE [OglasiProfilAplikanta];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528134953_oglasiTable')
BEGIN
    DROP TABLE [Oglasi];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528134953_oglasiTable')
BEGIN
    CREATE TABLE [OglasiTable] (
        [Id] int NOT NULL IDENTITY,
        [Odjel] nvarchar(max) NULL,
        [Pozicija] nvarchar(max) NULL,
        [DodatneInformacije] nvarchar(max) NULL,
        [PocetakPrijave] nvarchar(max) NULL,
        [DatumIsteka] nvarchar(max) NULL,
        [ProfilKompanijeId1] int NULL,
        [StatusId] int NULL,
        CONSTRAINT [PK_OglasiTable] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_OglasiTable_ProfilKompanije_ProfilKompanijeId1] FOREIGN KEY ([ProfilKompanijeId1]) REFERENCES [ProfilKompanije] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_OglasiTable_Status_StatusId] FOREIGN KEY ([StatusId]) REFERENCES [Status] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528134953_oglasiTable')
BEGIN
    CREATE TABLE [LokacijaOglasiTable] (
        [LokacijaId] int NOT NULL,
        [OglasId] int NOT NULL,
        CONSTRAINT [PK_LokacijaOglasiTable] PRIMARY KEY ([LokacijaId], [OglasId]),
        CONSTRAINT [FK_LokacijaOglasiTable_Lokacija_LokacijaId] FOREIGN KEY ([LokacijaId]) REFERENCES [Lokacija] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_LokacijaOglasiTable_OglasiTable_OglasId] FOREIGN KEY ([OglasId]) REFERENCES [OglasiTable] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528134953_oglasiTable')
BEGIN
    CREATE TABLE [OglasiTableProfilAplikanta] (
        [OglasiId] int NOT NULL,
        [ProfiliAplikanataId] int NOT NULL,
        CONSTRAINT [PK_OglasiTableProfilAplikanta] PRIMARY KEY ([OglasiId], [ProfiliAplikanataId]),
        CONSTRAINT [FK_OglasiTableProfilAplikanta_OglasiTable_OglasiId] FOREIGN KEY ([OglasiId]) REFERENCES [OglasiTable] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_OglasiTableProfilAplikanta_ProfilAplikanta_ProfiliAplikanataId] FOREIGN KEY ([ProfiliAplikanataId]) REFERENCES [ProfilAplikanta] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528134953_oglasiTable')
BEGIN
    CREATE INDEX [IX_LokacijaOglasiTable_OglasId] ON [LokacijaOglasiTable] ([OglasId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528134953_oglasiTable')
BEGIN
    CREATE INDEX [IX_OglasiTable_ProfilKompanijeId1] ON [OglasiTable] ([ProfilKompanijeId1]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528134953_oglasiTable')
BEGIN
    CREATE INDEX [IX_OglasiTable_StatusId] ON [OglasiTable] ([StatusId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528134953_oglasiTable')
BEGIN
    CREATE INDEX [IX_OglasiTableProfilAplikanta_ProfiliAplikanataId] ON [OglasiTableProfilAplikanta] ([ProfiliAplikanataId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528134953_oglasiTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210528134953_oglasiTable', N'5.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528140328_dropFkOglasi-Kompanija')
BEGIN
    DECLARE @var13 sysname;
    SELECT @var13 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[OglasiTable]') AND [c].[name] = N'ProfilKompanijeId1');
    IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [OglasiTable] DROP CONSTRAINT [' + @var13 + '];');
    ALTER TABLE [OglasiTable] DROP COLUMN [ProfilKompanijeId1];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528140328_dropFkOglasi-Kompanija')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210528140328_dropFkOglasi-Kompanija', N'5.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528140531_dodaj_Fk')
BEGIN
    ALTER TABLE [OglasiTable] ADD [ProfilKompanijeId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528140531_dodaj_Fk')
BEGIN
    CREATE INDEX [IX_OglasiTable_ProfilKompanijeId] ON [OglasiTable] ([ProfilKompanijeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528140531_dodaj_Fk')
BEGIN
    ALTER TABLE [OglasiTable] ADD CONSTRAINT [FK_OglasiTable_ProfilKompanije_ProfilKompanijeId] FOREIGN KEY ([ProfilKompanijeId]) REFERENCES [ProfilKompanije] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210528140531_dodaj_Fk')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210528140531_dodaj_Fk', N'5.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210601190805_oglas-aplikacion-relationship')
BEGIN
    ALTER TABLE [Aplikacija] ADD [oglasId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210601190805_oglas-aplikacion-relationship')
BEGIN
    CREATE INDEX [IX_Aplikacija_oglasId] ON [Aplikacija] ([oglasId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210601190805_oglas-aplikacion-relationship')
BEGIN
    ALTER TABLE [Aplikacija] ADD CONSTRAINT [FK_Aplikacija_OglasiTable_oglasId] FOREIGN KEY ([oglasId]) REFERENCES [OglasiTable] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210601190805_oglas-aplikacion-relationship')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210601190805_oglas-aplikacion-relationship', N'5.0.5');
END;
GO

COMMIT;
GO

