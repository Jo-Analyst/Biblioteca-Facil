﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 

namespace Controle_de_livros
{
    public partial class FrmBuscarUsuario : Form
    {
        string stringConn = Security.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdHWKfmyaZUAVO0njyONut81BbsmC4qd/GoI/eT/EcT+zAGgeLhaA4je9fdqhya3ASLYqkMPUjT+zc="), _sql;

        public int Codigo { get; set; }
        public string nome { get; set; }
        public string ano { get; set; }
        public string turma { get; set; }
        public string cep { get; set; }
        public string bairro { get; set; }
        public string endereco { get; set; }
        public string numero { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string fone { get; set; }
        public string ocupacao { get; set; }


        public FrmBuscarUsuario()
        {
            InitializeComponent();
        }

        private void FrmBuscarCliente_Load(object sender, EventArgs e)
        {
            cb_Opcao.SelectedIndex = 0;
            CarregarDgv();
        }

        private void txt_Dados_TextChanged(object sender, EventArgs e)
        {
            if (txt_Dados.Text == "")
            {
                CarregarDgv();
            }
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            string opcao = cb_Opcao.Text;
            if (txt_Dados.Text != "")
            {

                if (cb_Opcao.SelectedIndex == 0)
                {
                    opcao = "Nome_Usuario";
                }
                else if (cb_Opcao.SelectedIndex == 3)
                {
                    opcao = "Ocupacao";
                }
                SqlConnection conexao = new SqlConnection(stringConn);
                _sql = "Select * from Usuario where " + opcao + " like '%" + txt_Dados.Text.Trim() + "%'";
                SqlDataAdapter adapter = new SqlDataAdapter(_sql, conexao);
                adapter.SelectCommand.CommandText = _sql;
                DataTable table = new DataTable();
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    dgv_Busca.DataSource = table;
                }
                else
                {
                    MessageBox.Show("Dados não encontrado!", "Biblioteca Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_Dados.Focus();
                }
            }
            else
            {
                MessageBox.Show("Campo de busca vazio!", "Biblioteca Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_Dados.Focus();
            }
        }

         private void dgv_Busca_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow row = dgv_Busca.Rows[e.RowIndex];
                Codigo = int.Parse(row.Cells["ColCod"].Value.ToString());
                nome = row.Cells["ColNome"].Value.ToString();
                ano = row.Cells["ColAno"].Value.ToString();
                turma = row.Cells["ColTurma"].Value.ToString();
                cep = row.Cells["ColCep"].Value.ToString();
                bairro = row.Cells["ColBairro"].Value.ToString();
                endereco = row.Cells["ColEndereco"].Value.ToString();
                numero = row.Cells["ColNumero"].Value.ToString();
                cidade = row.Cells["ColCidade"].Value.ToString();
                estado = row.Cells["ColEstado"].Value.ToString();
                fone = row.Cells["ColFone"].Value.ToString();
                ocupacao = row.Cells["ColOcupacao"].Value.ToString();
                botãoBuscarAcionado = true;
                Close();
            }
        }

        bool botãoBuscarAcionado = false;

        private void btnCancelar_Click(object sender, EventArgs e)
        {  
            Codigo = 0;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Codigo >= 1)
            {
                botãoBuscarAcionado = true;
                Close();
            }
            else
                MessageBox.Show("Selecione o dado a ser confirmado!", "Biblioteca Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void dgv_Busca_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {

                Codigo = int.Parse(dgv_Busca[0, e.RowIndex].Value.ToString());
                nome = dgv_Busca[1, e.RowIndex].Value.ToString();
                ano = dgv_Busca[2, e.RowIndex].Value.ToString();
                turma = dgv_Busca[3, e.RowIndex].Value.ToString();
                cep = dgv_Busca[4, e.RowIndex].Value.ToString();
                bairro = dgv_Busca[5, e.RowIndex].Value.ToString();
                endereco = dgv_Busca[6, e.RowIndex].Value.ToString();
                numero = dgv_Busca[7, e.RowIndex].Value.ToString();
                cidade = dgv_Busca[8, e.RowIndex].Value.ToString();
                estado = dgv_Busca[9, e.RowIndex].Value.ToString();
                fone = dgv_Busca[10, e.RowIndex].Value.ToString();
                ocupacao = dgv_Busca[11, e.RowIndex].Value.ToString();
            }
        }

        private void dgv_Busca_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView dgv;
            dgv = (DataGridView)sender;
            dgv_Busca.ClearSelection();
        }

        private void txt_Dados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Pesquisar_Click(sender, e);
            }
        }

        private void FrmBuscarUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!botãoBuscarAcionado)
            {
                Codigo = 0;
            }
        }

        private void CarregarDgv()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "Select * from Usuario";
            SqlDataAdapter adapter = new SqlDataAdapter(_sql, conexao);
            adapter.SelectCommand.CommandText = _sql;
            DataTable table = new DataTable();
            adapter.Fill(table);
            dgv_Busca.DataSource = table;
        }
    }
}
