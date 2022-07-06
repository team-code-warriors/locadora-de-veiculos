CREATE TABLE [dbo].[TBPlanoDeCobranca] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Grupo_Id]    INT             NOT NULL,
    [TipoPlano]   VARCHAR (50)    NOT NULL,
    [ValorDiaria] DECIMAL (18, 2) NOT NULL,
    [KmIncluso]   DECIMAL (18, 2) NOT NULL,
    [PrecoKm]     DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_TBPlanoDeCobranca] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBGrupo_PK_TBPlano] FOREIGN KEY ([Grupo_Id]) REFERENCES [dbo].[TBGrupoDeVeiculos] ([Id])
);

