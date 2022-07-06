CREATE TABLE [dbo].[TBVeiculo] (
    [Id]                 INT             IDENTITY (1, 1) NOT NULL,
    [Modelo]             VARCHAR (50)    NOT NULL,
    [Fabricante]         VARCHAR (50)    NOT NULL,
    [Ano]                INT             NOT NULL,
    [Cambio]             VARCHAR (20)    NOT NULL,
    [Cor]                VARCHAR (50)    NOT NULL,
    [Placa]              VARCHAR (50)    NOT NULL,
    [Kilometragem]       INT             NOT NULL,
    [TipoDeCombustivel]  VARCHAR (50)    NOT NULL,
    [CapacidadeDoTanque] DECIMAL (18, 2) NOT NULL,
    [Grupo_Id]           INT             NOT NULL,
    [Foto]               VARBINARY (MAX) NOT NULL,
    CONSTRAINT [PK_TBVeiculo] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBVeiculo_TBGrupo] FOREIGN KEY ([Grupo_Id]) REFERENCES [dbo].[TBGrupoDeVeiculos] ([Id])
);

