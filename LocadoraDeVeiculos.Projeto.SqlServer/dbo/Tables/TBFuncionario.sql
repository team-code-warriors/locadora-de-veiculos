CREATE TABLE [dbo].[TBFuncionario] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Nome]         VARCHAR (200) NOT NULL,
    [Salario]      DECIMAL (18)  NOT NULL,
    [DataAdmissao] DATE          NOT NULL,
    [Login]        VARCHAR (50)  NOT NULL,
    [Senha]        VARCHAR (50)  NOT NULL,
    [TipoPerfil]   VARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_TBFuncionario] PRIMARY KEY CLUSTERED ([Id] ASC)
);

