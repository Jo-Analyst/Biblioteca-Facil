﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controle_de_livros
{
    public partial class FrmNovo : Form
    {
        string JanelaEmprestimo;
        public FrmNovo(string JanelaEmprestimo)
        {
            InitializeComponent();
            this.JanelaEmprestimo = JanelaEmprestimo;
        }

        private void Btn_CadastrarLivroDidatico_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Cadastrar_Livro_Click(object sender, EventArgs e)
        {
            if (JanelaEmprestimo == "Emprestimo Livro Literario")
            {
                FrmLivroLiterario livroLiterario = new FrmLivroLiterario();
                livroLiterario.ShowDialog();
            }
            else
            {
                FrmLivroDidatico livroDidatico = new FrmLivroDidatico();
                livroDidatico.ShowDialog();
            }
        }

        private void Btn_Cadastrar_Usuario_Click(object sender, EventArgs e)
        {
            FrmCadastroUsuarios cadastroUsuarios = new FrmCadastroUsuarios();
            cadastroUsuarios.ShowDialog();
        }
    }
}
