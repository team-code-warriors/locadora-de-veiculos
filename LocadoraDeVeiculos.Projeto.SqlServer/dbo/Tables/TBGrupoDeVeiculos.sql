﻿CREATE TABLE [dbo].[TBGrupoDeVeiculos] (
    [Id]   INT          IDENTITY (1, 1) NOT NULL,
    [Nome] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_TBGrupoDeVeiculos] PRIMARY KEY CLUSTERED ([Id] ASC)
);

