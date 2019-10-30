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
    public partial class FrmEmprestimoLivroDidatico : Form
    {
        public FrmEmprestimoLivroDidatico()
        {
            InitializeComponent();
            lblBiblioteca.Text = "Bibloteca " + Settings.Default["Biblioteca"].ToString();
            lblInstituicao.Text = Settings.Default["Instituicao"].ToString();
        }

        int registro, countLinhas, qtdLivrosEmprestados;
        string Disciplina, autor, volume, ensino, stringConn = Security.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdHWKfmyaZUAVO0njyONut81BbsmC4qd/GoI/eT/EcT+zAGgeLhaA4je9fdqhya3ASLYqkMPUjT+zc="), ocupacao;


        Livro_Didatico livroDidatico = new Livro_Didatico();
        EmprestimoLivroDidatico emprestimoLivroDidatico = new EmprestimoLivroDidatico();

        private void FrmEmprestimoLivro_Load(object sender, EventArgs e)
        {
            
        }

        private void BtnAdicionar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRegistro.Text))
            {
                livroDidatico.registro = int.Parse(txtRegistro.Text);

                if (livroDidatico.buscar() == true)
                {
                    registro = livroDidatico.registro;
                    Disciplina = livroDidatico.disciplina;
                    autor = livroDidatico.autor;
                    ensino = livroDidatico.ensino;
                    volume = livroDidatico.volume;

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
            emprestimoLivroDidatico._Registro = registro;
            if (!emprestimoLivroDidatico.VerificarLivrosEmprestados())
            {
                if (!string.IsNullOrEmpty(lblCodigo.Text))
                {
                    if (ocupacao == "Funcionário")
                    {
                        if (VerificarLivrosEmprestados() == false || cbProfessor.Checked == true)
                        {
                            verificarDuplicidade();
                            if (duplicata == true && cbProfessor.Checked == false)
                            {
                                MessageBox.Show("Este livro já foi adicionado.", "Biblioteca Fácil Acesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                duplicata = false;
                            }
                            else
                            {
                                dgvLivro.Rows.Add(registro, Disciplina, autor, ensino, volume);
                                txtRegistro.Clear();
                                txtRegistro.Focus();
                                dgvLivro.ClearSelection();
                            }
                        }
                        else
                        {
                            MessageBox.Show("O(A) funcionário(a)" + txtNome.Text.ToUpper() + " já tem um livro desta disciplina. Tente outra opção...", "Biblioteca Fácil Acesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else if (ocupacao == "Aluno")
                    {
                        if (VerificarLivrosEmprestados() == false || cbEmprestimoTemporario.Checked)
                        {
                            verificarDuplicidade();
                            if (duplicata == true && cbEmprestimoTemporario.Checked == false)
                            {
                                MessageBox.Show("Este livro já foi adicionado.", "Biblioteca Fácil Acesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                duplicata = false;
                            }
                            else
                            {
                                dgvLivro.Rows.Add(registro, Disciplina, autor, ensino, volume);
                                txtRegistro.Clear();
                                txtRegistro.Focus();
                                dgvLivro.ClearSelection();
                            }
                        }
                        else
                        {
                            MessageBox.Show("O(A) aluno(a) " + txtNome.Text.ToUpper() + " já tem um livro desta disciplina. Tente outra opção...", "Biblioteca Fácil Acesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        if (VerificarLivrosEmprestados() == false)
                        {
                            verificarDuplicidade();
                            if (duplicata == true)
                            {
                                MessageBox.Show("Este livro já foi adicionado.", "Biblioteca Fácil Acesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                duplicata = false;
                            }
                            else
                            {
                                dgvLivro.Rows.Add(registro, Disciplina, autor, ensino, volume);
                                txtRegistro.Clear();
                                txtRegistro.Focus();
                                dgvLivro.ClearSelection();
                            }
                        }
                        else
                        {
                            MessageBox.Show(txtNome.Text.ToUpper() + " já tem um livro desta disciplina. Tente outra opção...", "Biblioteca Fácil Acesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Informe o(a) Aluno(a)/Funcionário(a)/Ex-aluno(a) ou Outro(a) para prosseguir!", "Biblioteca Fácil Acesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    errorProvider.Clear();
                    errorProvider.SetError(txtNome, "Informe aqui");
                    txtNome.Focus();
                    return;
                }
            }
            else
                MessageBox.Show("O livro com este registro já foi emprestado. Verifique se não houve erro de digitação ou erro na seleção da busca.", "Biblioteca Fácil Acesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public bool VerificarLivrosEmprestados()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            string _sql = "select * from Emprestimo_Livro_Didatico inner join Livro_Didatico on Emprestimo_Livro_Didatico.N_Registro = Livro_Didatico.N_Registro where Livro_Didatico.Disciplina = @Disciplina and Cod_Usuario = @Codigo and Emprestimo_Livro_Didatico.Data_Entrega = ''";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@Disciplina", Disciplina);
            comando.Parameters.AddWithValue("@Codigo", lblCodigo.Text);
            comando.CommandText = _sql;
            try
            {
                conexao.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                conexao.Close();
            }
        }

        bool duplicata = false;
        ErrorProvider errorProvider = new ErrorProvider();
        private void verificarDuplicidade()
        {
            for(int i = 0; i < dgvLivro.Rows.Count; i++)
            {
                if(Disciplina == dgvLivro.Rows[i].Cells["ColDisciplina"].Value.ToString())
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
            FrmNovo novo = new FrmNovo("Emprestimo Livro Didatico");
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
            FrmBuscarLivroDidatico buscaLivroDidatico = new FrmBuscarLivroDidatico();
            buscaLivroDidatico.ShowDialog();
            if(buscaLivroDidatico.registro > 0)
            {
                registro = buscaLivroDidatico.registro;
                Disciplina = buscaLivroDidatico.disciplina;
                ensino = buscaLivroDidatico.ensino;
                autor = buscaLivroDidatico.autor;
                volume = buscaLivroDidatico.volume;

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
                MessageBox.Show("Informe o(a) Aluno(a)/Funcionário(a)/Ex-aluno(a) ou Outro(a) para prosseguir!", "Biblioteca Fácil Acesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            btnVerHistorico.Enabled = false;
            cbProfessor.Visible = false;
            cbProfessor.Checked = false;
            cbEmprestimoTemporario.Visible = false;
            cbEmprestimoTemporario.Checked = false;
        }

        private void FinalizarEmprestimo()
        {
            try
            {
                for (int i = 0; i < dgvLivro.Rows.Count; i++)
                {                   
                    emprestimoLivroDidatico._Registro = int.Parse(dgvLivro.Rows[i].Cells["ColRegistro"].Value.ToString());
                    emprestimoLivroDidatico._Codigo = int.Parse(lblCodigo.Text);
                    emprestimoLivroDidatico._Entrega = "";
                    emprestimoLivroDidatico._Solicitacao = DateTime.Now.ToShortDateString();
                    emprestimoLivroDidatico.EfetuarEmprestimo();
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

        private void cbProfessor_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbProfessor.Checked && ocupacao == "Funcionário" &&dgvLivro.Rows.Count > 0)
            {
                MessageBox.Show("Para não haver duplicidade os itens adicionados serão removidos. Refaça tudo novamente.", "Biblioteca Fácil Acesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvLivro.Rows.Clear();
                duplicata = false;
            }
        }

        bool sair = true;

        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnPesquisar_Click(sender, e);
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbProcurarPorCodigo.Checked)
            {       //aceita só números
                if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (Char)8)
                {
                    e.Handled = true;
                }
            }
        }

        private void cbProcurarPorCodigo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbProcurarPorCodigo.Checked)
            {
                cbProfessor.Visible = false;
                cbProfessor.Checked = false;
                cbEmprestimoTemporario.Visible = false;
                cbEmprestimoTemporario.Checked = false;
                txtNome.ReadOnly = false;
                txtNome.BackColor = Color.White;
                lblCodigo.Text = "";
                txtNome.Clear();
                lblQuantidadeLivrosEmprestados.Text = "";
                txtNome.Focus();
                txtNome.TextAlign = HorizontalAlignment.Right;
                txtNome.MaxLength = 9;
                lblCampoNome.Text = "Código do Aluno/Funcionário/Outro";
            }
            else
            {
                txtNome.ReadOnly = true;
                txtNome.BackColor = SystemColors.Control;
                txtNome.TextAlign = HorizontalAlignment.Left;
                txtNome.MaxLength = 32767;
                lblCampoNome.Text = "Aluno/Funcionário/Outro";
            }
        }

        private void txtNome_Click(object sender, EventArgs e)
        {
            if (cbProcurarPorCodigo.Checked)
            {
                cbProfessor.Visible = false;
                cbProfessor.Checked = false;
                txtNome.TextAlign = HorizontalAlignment.Right;
                txtNome.Clear();
                lblCodigo.Text = "";
                lblQuantidadeLivrosEmprestados.Text = "";
                btnVerHistorico.Enabled = false;
                lblCampoNome.Text = "Código do Aluno/Funcionário/Outro";
            }
        }

        private void cbEmprestimoTemporario_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbEmprestimoTemporario.Checked && ocupacao == "Aluno" && dgvLivro.Rows.Count > 0)
            {
                MessageBox.Show("Para não haver duplicidade os itens adicionados serão removidos. Refaça tudo novamente.", "Biblioteca Fácil Acesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvLivro.Rows.Clear();
                duplicata = false;
            }
        }

        private void btnVerHistorico_Click(object sender, EventArgs e)
        {
            FrmHistoricoEmprestimoDidatico historico = new FrmHistoricoEmprestimoDidatico(lblCodigo.Text, txtNome.Text, qtdLivrosEmprestados);
            historico.ShowDialog();
        }

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

        Usuario usuario = new Usuario();

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!cbProcurarPorCodigo.Checked)
                {
                    FrmBuscarUsuario usuario = new FrmBuscarUsuario();
                    usuario.ShowDialog();
                    if (usuario.Codigo > 0)
                    {
                        dgvLivro.Rows.Clear();
                        lblCodigo.Text = usuario.Codigo.ToString();
                        txtNome.Text = usuario.nome;
                        VerificarQuantidadeLivroDidaticoEmprestado_E_OcupacaoUsuario(usuario.Codigo, usuario.ocupacao);
                        errorProvider.Clear();
                        txtNome.TextAlign = HorizontalAlignment.Left;
                        txtNome.MaxLength = 32767;
                    }
                }
                else
                {                    
                    if (!string.IsNullOrEmpty(txtNome.Text))
                    {
                        if (!string.IsNullOrEmpty(lblCodigo.Text))
                            usuario.codigo = int.Parse(lblCodigo.Text);
                        else
                            usuario.codigo = int.Parse(txtNome.Text);

                        if (usuario.Buscar())
                        {
                            dgvLivro.Rows.Clear();
                            txtNome.Text = usuario.nome;
                            lblCodigo.Text = usuario.codigo.ToString();
                            VerificarQuantidadeLivroDidaticoEmprestado_E_OcupacaoUsuario(int.Parse(lblCodigo.Text), usuario.ocupacao);
                            txtNome.TextAlign = HorizontalAlignment.Left;
                            txtRegistro.Focus();
                            txtNome.MaxLength = 32767;
                            lblCampoNome.Text = "Aluno/Funcionário/Outro";
                        }
                        else
                        {
                            MessageBox.Show("Aluno(a)/Funcionário(a)/Outro não encontrado!", "Biblioteca Fácil Acesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            lblCodigo.Text = string.Empty;
                            txtNome.Clear();
                            txtNome.Focus();
                        }
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void VerificarQuantidadeLivroDidaticoEmprestado_E_OcupacaoUsuario(int Codigo, string ocupacao)
        {
            emprestimoLivroDidatico._Codigo = Codigo;
            lblQuantidadeLivrosEmprestados.Text = "Quantidade de livros emprestados: " + emprestimoLivroDidatico.VerificarQuantidadeLivrosEmprestados() + " livro(s)";
            qtdLivrosEmprestados = emprestimoLivroDidatico.VerificarQuantidadeLivrosEmprestados();
            this.ocupacao = ocupacao;
            if (ocupacao == "Funcionário")
            {
                cbProfessor.Visible = true;
                cbProfessor.Checked = false;
            }
            else
            {
                cbProfessor.Checked = false;
                cbProfessor.Visible = false;
            }

            if(ocupacao == "Aluno")
            {
                cbEmprestimoTemporario.Visible = true;
                cbEmprestimoTemporario.Checked = false;
            }
            else
            {
                cbEmprestimoTemporario.Visible = false;
                cbEmprestimoTemporario.Checked = false;
            }
            if (qtdLivrosEmprestados > 0)
            {
                btnVerHistorico.Enabled = true;
            }
            else
            {
                btnVerHistorico.Enabled = false;
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
