CREATE TABLE [dbo].[TBTaxa] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Descricao]   VARCHAR (500)   NOT NULL,
    [Valor]       DECIMAL (18, 2) NOT NULL,
    [TipoCalculo] VARCHAR (50)    NOT NULL,
    CONSTRAINT [PK_TBTaxa] PRIMARY KEY CLUSTERED ([Id] ASC)
);

