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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210924192751_PrimeiraMigracao')
BEGIN
    CREATE TABLE [Paciente] (
        [Id] int NOT NULL IDENTITY,
        [Nome] VARCHAR(300) NOT NULL,
        [Cpf] VARCHAR(14) NOT NULL,
        [DataNascimento] DATETIME NOT NULL,
        [Sexo] CHAR(1) NOT NULL,
        [Telefone] CHAR(11) NOT NULL,
        [Email] VARCHAR(400) NOT NULL,
        CONSTRAINT [PK_Paciente] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210924192751_PrimeiraMigracao')
BEGIN
    CREATE TABLE [TipoExame] (
        [Id] int NOT NULL IDENTITY,
        [Nome] VARCHAR(300) NOT NULL,
        [Descricao] VARCHAR(300) NOT NULL,
        CONSTRAINT [PK_TipoExame] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210924192751_PrimeiraMigracao')
BEGIN
    CREATE TABLE [Exame] (
        [Id] int NOT NULL IDENTITY,
        [Nome] VARCHAR(300) NOT NULL,
        [Observacao] VARCHAR(300) NOT NULL,
        [TipoExameId] int NULL,
        CONSTRAINT [PK_Exame] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Exame_TipoExame_TipoExameId] FOREIGN KEY ([TipoExameId]) REFERENCES [TipoExame] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210924192751_PrimeiraMigracao')
BEGIN
    CREATE TABLE [ConsultaMedica] (
        [Id] int NOT NULL IDENTITY,
        [PacienteId] int NULL,
        [ExameId] int NULL,
        [DataHoraExame] DATETIME NOT NULL,
        [Protocolo] int NOT NULL,
        CONSTRAINT [PK_ConsultaMedica] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ConsultaMedica_Exame_ExameId] FOREIGN KEY ([ExameId]) REFERENCES [Exame] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_ConsultaMedica_Paciente_PacienteId] FOREIGN KEY ([PacienteId]) REFERENCES [Paciente] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210924192751_PrimeiraMigracao')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Descricao', N'Nome') AND [object_id] = OBJECT_ID(N'[TipoExame]'))
        SET IDENTITY_INSERT [TipoExame] ON;
    EXEC(N'INSERT INTO [TipoExame] ([Id], [Descricao], [Nome])
    VALUES (1, ''Exame de sangue, jejum 12 horas.'', ''Hemograma'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Descricao', N'Nome') AND [object_id] = OBJECT_ID(N'[TipoExame]'))
        SET IDENTITY_INSERT [TipoExame] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210924192751_PrimeiraMigracao')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Descricao', N'Nome') AND [object_id] = OBJECT_ID(N'[TipoExame]'))
        SET IDENTITY_INSERT [TipoExame] ON;
    EXEC(N'INSERT INTO [TipoExame] ([Id], [Descricao], [Nome])
    VALUES (2, ''Exame de imagem.'', ''Raio X'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Descricao', N'Nome') AND [object_id] = OBJECT_ID(N'[TipoExame]'))
        SET IDENTITY_INSERT [TipoExame] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210924192751_PrimeiraMigracao')
BEGIN
    CREATE INDEX [IX_ConsultaMedica_ExameId] ON [ConsultaMedica] ([ExameId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210924192751_PrimeiraMigracao')
BEGIN
    CREATE INDEX [IX_ConsultaMedica_PacienteId] ON [ConsultaMedica] ([PacienteId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210924192751_PrimeiraMigracao')
BEGIN
    CREATE INDEX [IX_Exame_TipoExameId] ON [Exame] ([TipoExameId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210924192751_PrimeiraMigracao')
BEGIN
    CREATE INDEX [IX_PACIENTE_CPF] ON [Paciente] ([Cpf]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210924192751_PrimeiraMigracao')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210924192751_PrimeiraMigracao', N'5.0.10');
END;
GO

COMMIT;
GO

