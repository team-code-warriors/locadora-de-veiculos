CREATE TABLE [dbo].[TBCliente] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Nome]     VARCHAR (200) NOT NULL,
    [Email]    VARCHAR (500) NOT NULL,
    [Endereco] VARCHAR (500) NOT NULL,
    [Cpf]      VARCHAR (20)  NULL,
    [Cnpj]     VARCHAR (50)  NULL,
    [Telefone] VARCHAR (20)  NOT NULL,
    CONSTRAINT [PK__tmp_ms_x__3214EC0775BAE198] PRIMARY KEY CLUSTERED ([Id] ASC)
);

