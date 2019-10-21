﻿using System;
using System.Data;
using System.Windows.Forms;

namespace Controle_de_livros
{
    public partial class FrmHistoricoEmprestimoLiterario : Form
    {
        EmprestimoLivroLiterario emprestimo_Livro_Literario = new EmprestimoLivroLiterario();
        public FrmHistoricoEmprestimoLiterario(string id, string nome, int qtdLivros)
        {
            InitializeComponent();
            lblUsuario.Text = "Aluno/Funcionário/Outro: " + id + " - " + nome;
            emprestimo_Livro_Literario._Codigo = int.Parse(id);
            lblQuantidadeLivrosEmprestados.Text += qtdLivros + " livro(s)";
            foreach (DataRow dataRow in emprestimo_Livro_Literario.BuscarLivrosLiterariosEmprestados().Rows)
            {
                int newRow = dgvHistorico.Rows.Add();
                dgvHistorico.Rows[newRow].Cells["ColRegistro"].Value = dataRow["N_Registro"].ToString();
                dgvHistorico.Rows[newRow].Cells["ColTitulo"].Value = dataRow["Titulo"].ToString();
                dgvHistorico.Rows[newRow].Cells["ColAutor"].Value = dataRow["Autor"].ToString();
                dgvHistorico.Rows[newRow].Cells["ColGenero"].Value = dataRow["Genero"].ToString();
                dgvHistorico.Rows[newRow].Cells["ColPrazo"].Value = dataRow["Prazo_Entrega"].ToString();
                dgvHistorico.Rows[newRow].Cells["ColSolicitacao"].Value = dataRow["Data_Solicitacao"].ToString();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void FrmHistoricoEmprestimoLivro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnSair_Click(sender, e);
            }
        }

        private void dgvHistorico_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView dgv;
            dgv = (DataGridView)sender;
            dgv.ClearSelection();
        }

        private void dgvHistorico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvHistorico.ClearSelection();
        }

        private void dgvHistorico_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvHistorico.ClearSelection();
        }
    }
}
