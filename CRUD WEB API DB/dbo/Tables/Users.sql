CREATE TABLE [dbo].[Users] (
    [Id]        INT           NOT NULL,
    [firstname] VARCHAR (100) NOT NULL,
    [lastname]  VARCHAR (100) NOT NULL,
    [email]     VARCHAR (100) NOT NULL,
    [usertype]  VARCHAR (20)  NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);

