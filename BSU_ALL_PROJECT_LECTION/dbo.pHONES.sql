CREATE TABLE [dbo].[pHONES] (
    [Id]      INT        IDENTITY (1, 1) NOT NULL,
    [Title]   NCHAR (10) NOT NULL,
    [Company] NCHAR (10) NULL,
    [Price]   INT        NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

