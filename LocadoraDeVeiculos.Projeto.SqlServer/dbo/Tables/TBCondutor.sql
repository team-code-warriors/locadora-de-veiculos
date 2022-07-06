CREATE TABLE [dbo].[TBCondutor] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [Cliente_Id]      INT           NOT NULL,
    [Nome]            VARCHAR (200) NOT NULL,
    [Cpf]             VARCHAR (20)  NOT NULL,
    [Cnh]             VARCHAR (20)  NOT NULL,
    [DataValidadeCnh] DATE          NOT NULL,
    [Email]           VARCHAR (200) NOT NULL,
    [Telefone]        VARCHAR (20)  NOT NULL,
    [Endereco]        VARCHAR (500) NOT NULL,
    CONSTRAINT [PK_TBCondutor] PRIMARY KEY CLUSTERED ([Id] ASC)
);

