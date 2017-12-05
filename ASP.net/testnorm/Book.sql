CREATE TABLE [dbo].[Book] (
    [Id]     INT            IDENTITY (1, 1) NOT NULL,
    [Author] NVARCHAR (MAX) NULL,
    [Name]   NVARCHAR (MAX) NULL,
    [Genre]  NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);