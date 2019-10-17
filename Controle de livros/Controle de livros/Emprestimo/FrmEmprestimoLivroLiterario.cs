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
using Controle_de_livros.Properties;

namespace Controle_de_livros
{
    public partial class FrmEmprestimoLivro : Form
    {
        public FrmEmprestimoLivro()
        {
            InitializeComponent();
            lblBiblioteca.Text = "Bibloteca " + Settings.Default["Biblioteca"].ToString();
            lblInstituicao.Text = Settings.Default["Instituicao"].ToString();
        }

        int registro, countLinhas, qtdLivrosEmprestados;
        string titulo, autor, genero;
        Livro_Literario livroLiterario = new Livro_Literario();
        Emprestimo_Livro_Literario Emprestimo_Livro_Literario = new Emprestimo_Livro_Literario();

        private void FrmEmprestimoLivro_Load(object sender, EventArgs e)
        {
            
        }

        private void BtnAdicionar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRegistro.Text))
            {
                livroLiterario.registro = int.Parse(txtRegistro.Text);

                if (livroLiterario.buscar() == true)
                {
                    registro = livroLiterario.registro;
                    titulo = livroLiterario.titulo;
                    autor = livroLiterario.autor;
                    genero = livroLiterario.genero;

                    AdicionarItens();
                }
                else
                    MessageBox.Show("Registro inválido! Tente outra opção...", "Biblioteca Fácil Acesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Informe o registro do livro!", "Biblioteca Fácil Acesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void AdicionarItens()
        {
            if (!string.IsNullOrEmpty(lblCodigo.Text))
            {
                Emprestimo_Livro_Literario._Registro = registro;
                if (Emprestimo_Livro_Literario.VerificarLivrosEmprestados() == false)
                {
                    verificarDuplicidade();
                    if (duplicata == true)
                    {
                        MessageBox.Show("Este livro já foi adicionado.", "Biblioteca Fácil Acesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        duplicata = false;
                    }
                    else
                    {
                        countLinhas = int.Parse(Settings.Default["qtdLimiteEmprestimo"].ToString());
                        if (dgvLivro.Rows.Count == (countLinhas - qtdLivrosEmprestados))
                        {
                            if (qtdLivrosEmprestados == 0)
                                MessageBox.Show("Não é permitido empréstimo acima de " + countLinhas + " livros!", "Biblioteca Fácil Acesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            else
                                MessageBox.Show("A quantidade de empréstimo é de " + countLinhas + " livros e constamos que " + txtNome.Text.ToUpper() + " tem em suas mãos " + qtdLivrosEmprestados + " livros emprestados. Para adicionar mais itens para empréstimos, altere o valor da quantidade no menu de configurações.", "Biblioteca Fácil Acesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtRegistro.Clear();
                        }
                        else
                        {
                            dgvLivro.Rows.Add(registro, titulo, autor, genero);
                            txtRegistro.Clear();
                            txtRegistro.Focus();
                            dgvLivro.ClearSelection();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Existe um empréstimo com este registro. Verifique se há erros de digitação ou erro na busca de livro com o mesmo titulo.", "Biblioteca Fácil Acesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Informe o Aluno/Funcionário/Outro para prosseguir!", "Biblioteca Fácil Acesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errorProvider.Clear();
                errorProvider.SetError(txtNome, "Informe aqui");
                txtNome.Focus();
                return;
            }
        }

        bool duplicata = false;
        ErrorProvider errorProvider = new ErrorProvider();
        private void verificarDuplicidade()
        {
            for(int i = 0; i < dgvLivro.Rows.Count; i++)
            {
                if(registro == int.Parse(dgvLivro.Rows[i].Cells["ColRegistro"].Value.ToString()))
                {
                    duplicata =  true;
                    break;
                }               
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            lblDataHora.Text = "Biblioteca Fácil Acesso - " + DateTime.Now.ToLongDateString() + ", " + DateTime.Now.ToLongTimeString();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            FrmNovo novo = new FrmNovo();
            novo.ShowDialog();
        }

        private void FrmEmprestimoLivro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btnFinalizarEmprestimo_Click(sender, e);
            }
            if (e.KeyCode == Keys.F2)
            {
                btnNovo_Click(sender, e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                btnSair_Click(sender, e);
            }
            if (e.KeyCode == Keys.F3)
            {
                btnLivro_Click(sender, e);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (dgvLivro.Rows.Count == 0)
                this.Close();
            else
            {
                DialogResult dr = MessageBox.Show("Deseja sair sem concluir o empréstimo?", "Biblioteca Fácil Acesso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if(dr == DialogResult.Yes)
                {
                    sair = false;
                    this.Close();
                }
            }
        }

        private void btnLivro_Click(object sender, EventArgs e)
        {
            FrmBuscaLivroLiterario buscaLivroLiterario = new FrmBuscaLivroLiterario();
            buscaLivroLiterario.ShowDialog();
            if(buscaLivroLiterario.registro > 0)
            {
                registro = buscaLivroLiterario.registro;
                titulo = buscaLivroLiterario.titulo;
                autor = buscaLivroLiterario.autor;
                genero = buscaLivroLiterario.genero;

                AdicionarItens();
            }
        }

        private void btnFinalizarEmprestimo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblCodigo.Text))
            {
                if(dgvLivro.Rows.Count > 0)
                {
                    FinalizarEmprestimo();
                    MessageBox.Show("Operação efetuado com sucesso.", "Biblioteca Fácil Acesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limparCampos();
                }
                else
                {
                    MessageBox.Show("Não há livros adicionados!", "Biblioteca Fácil Acesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Informe o Aluno/Funcionário/Outro para prosseguir!", "Biblioteca Fácil Acesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errorProvider.Clear();
                errorProvider.SetError(txtNome, "Informe aqui");
                txtNome.Focus();
                return;
            }
        }

        private void limparCampos()
        {
            dgvLivro.Rows.Clear();
            txtNome.Clear();
            lblCodigo.Text = "";
            lblQuantidadeLivrosEmprestados.Text = "";
        }

        private void FinalizarEmprestimo()
        {
            try
            {
                for (int i = 0; i < dgvLivro.Rows.Count; i++)
                {
                    Emprestimo_Livro_Literario._Registro = int.Parse(dgvLivro.Rows[i].Cells["ColRegistro"].Value.ToString());
                    Emprestimo_Livro_Literario._Codigo = int.Parse(lblCodigo.Text);
                    Emprestimo_Livro_Literario._Entrega = "";
                    Emprestimo_Livro_Literario._Solicitacao = DateTime.Now.ToShortDateString();
                    Emprestimo_Livro_Literario.efetuarEmprestino();
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (dgvLivro.Rows.Count > 0)
            {
                if (dgvLivro.CurrentRow.Selected == true)
                {
                    if (dgvLivro.Rows.Count > 0)
                    {
                        dgvLivro.Rows.Remove(dgvLivro.CurrentRow);
                        dgvLivro.ClearSelection();
                    }
                }
                else
                    MessageBox.Show("Selecione o item para remover!", "Biblioteca Fácil Acesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Não há itens!", "Biblioteca Fácil Acesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void TxtRegistro_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                BtnAdicionar_Click(sender, e);
            }
        }

        private void MenuRemover_Click(object sender, EventArgs e)
        {
            btnRemover_Click(sender, e);
        }

        bool sair = true;
        private void FrmEmprestimoLivro_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (sair)
            {
                if (dgvLivro.Rows.Count > 0)
                {

                    DialogResult dr = MessageBox.Show("Deseja sair sem concluir o empréstimo?", "Biblioteca Fácil Acesso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (dr == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                    else
                    {

                        sair = false;
                    }
                }
            }
        }


        private void DgvLivro_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView dgv;
            dgv = (DataGridView)sender;
            dgvLivro.ClearSelection();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            FrmBuscarUsuario usuario = new FrmBuscarUsuario();
            usuario.ShowDialog();
            if (usuario.Codigo > 0)
            {
                lblCodigo.Text = usuario.Codigo.ToString();
                txtNome.Text = usuario.nome;
                Emprestimo_Livro_Literario._Codigo = usuario.Codigo;
                lblQuantidadeLivrosEmprestados.Text = "Quantidade de livros emprestados: " + Emprestimo_Livro_Literario.VerificarQuantidadeLivrosEmprestados() + " livro(s)";
                qtdLivrosEmprestados = Emprestimo_Livro_Literario.VerificarQuantidadeLivrosEmprestados();
                errorProvider.Clear();
            }
        }

        private void TxtRegistro_KeyPress(object sender, KeyPressEventArgs e)
        {
            //aceita só números
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (Char)8)
            {
                e.Handled = true;
            }
        }
    }
}
