CREATE TABLE [dbo].[Person] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [FirstName]        VARCHAR (MAX)   NULL,
    [LastName]       VARCHAR (MAX)   NOT NULL,
    [Age] INT  NOT NULL
);