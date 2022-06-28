CREATE TABLE [dbo].[TBCliente] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Nome]     VARCHAR (200) NOT NULL,
    [Email]    VARCHAR (500) NOT NULL,
    [Endereco] VARCHAR (500) NOT NULL,
    [Cpf]      VARCHAR (20)  NOT NULL,
    [Telefone] VARCHAR (20)  NOT NULL,
    [Cnh]      VARCHAR (20)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

