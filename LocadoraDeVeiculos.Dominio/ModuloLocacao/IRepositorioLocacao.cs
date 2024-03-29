﻿using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloLocacao
{
    public interface IRepositorioLocacao : IRepositorio<Locacao>
    {
        Locacao SelecionarLocacaoPorPlacaDoVeiculo(string placa);
        List<Locacao> SelecionarPorLocacaoAtivaEInativa();
        void Devolver(Locacao registro);
    }
}
