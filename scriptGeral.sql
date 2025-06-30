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
CREATE TABLE [Eventos] (
    [IdEvento] int NOT NULL IDENTITY,
    [TituloEvento] nvarchar(max) NULL,
    [DescricaoEvento] nvarchar(max) NULL,
    [DataEvento] nvarchar(max) NULL,
    [HoraEvento] nvarchar(max) NULL,
    [QtVoluntarios] int NOT NULL,
    [DuracaoEvento] int NOT NULL,
    [PontuacaoEvento] int NOT NULL,
    [LocalEvento] nvarchar(max) NULL,
    [Situacao] int NOT NULL,
    [IdUsuario] int NOT NULL,
    CONSTRAINT [PK_Eventos] PRIMARY KEY ([IdEvento])
);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250623224758_InitialCreate', N'9.0.6');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250628020319_Eventos', N'9.0.6');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250628020804_ApenasEventos', N'9.0.6');

COMMIT;
GO

