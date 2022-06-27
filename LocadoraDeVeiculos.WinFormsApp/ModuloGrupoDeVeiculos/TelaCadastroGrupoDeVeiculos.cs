﻿using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloGrupoDeVeiculos
{
    public partial class TelaCadastroGrupoDeVeiculos : Form
    {
        RepositorioGrupoDeVeiculosEmBancoDeDados repositorio = new RepositorioGrupoDeVeiculosEmBancoDeDados();
        ValidadorRegex validador = new ValidadorRegex();
        public TelaCadastroGrupoDeVeiculos()
        {
            InitializeComponent();
            this.ConfigurarTela();
        }

        private GrupoDeVeiculos grupo;

        public Func<GrupoDeVeiculos, ValidationResult> GravarRegistro { get; set; }

        public GrupoDeVeiculos Grupo
        {
            get { return grupo; }
            set
            {
                grupo = value;
                textBoxNome.Text = grupo.Nome;
            }
        }
        private void btnGravar_Click(object sender, System.EventArgs e)
        {
            if (validador.ApenasLetras(textBoxNome.Text))
            {
                grupo.Nome = textBoxNome.Text;

                var resultadoValidacao = GravarRegistro(grupo);

                if (resultadoValidacao.IsValid == false)
                {
                    string erro = resultadoValidacao.Errors[0].ErrorMessage;

                    TelaMenuPrincipal.Instancia.AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
            else
            {
                MessageBox.Show("Insira um nome válido no campo 'Nome'",
                "Cadastro de Grupo de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                DialogResult = DialogResult.None;

                return;
            }
        }


        private void TelaCadastroContatosForm_Load(object sender, EventArgs e)
        {
            TelaMenuPrincipal.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroContatosForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaMenuPrincipal.Instancia.AtualizarRodape("");
        }
    }
}

