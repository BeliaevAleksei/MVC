GO
CREATE TABLE [dbo].[BookReview] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (MAX) NULL,
    [BookName]     NVARCHAR (MAX) NULL,
    [Review]       NVARCHAR (MAX) NULL,
    [IdBook]       INT            NULL,
    [Likes]        INT            NULL,
    [IsOffensive]  BIT            NULL,
    [ReportReason] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);