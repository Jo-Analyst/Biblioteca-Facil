﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 
using Controle_de_livros.Properties;
using Tulpep.NotificationWindow;

namespace Controle_de_livros
{
    public partial class FrmTelaPrincipal : Form
    {
        string Usuario, _sql;
        public FrmTelaPrincipal(string Usuario)
        {
            InitializeComponent();
            this.Text = "Bibloteca Fácil Acesso - SISTEMA PARA CONTROLE DE LIVROS (Escola Estadual Felício dos Santos) === Usuário(a): " + Usuario.ToUpper();
            this.Usuario = Usuario;
            NotifcarPrazoVencido();
        }

        private bool VerificarEmprestimos()
        {
            SqlConnection conexao = new SqlConnection(Security.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdHWKfmyaZUAVO0njyONut81BbsmC4qd/GoI/eT/EcT+zAGgeLhaA4je9fdqhya3ASLYqkMPUjT+zc="));
            
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@DataAtual", DateTime.Now.ToShortDateString());

            conexao.Open();
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.Read())
            {
                conexao.Close();
                return true;
            }
            else
            {
                conexao.Close();
                return false;
            }
        }

        private void NotifcarPrazoVencido()
        {
            SqlConnection conexao = new SqlConnection(Security.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdHWKfmyaZUAVO0njyONut81BbsmC4qd/GoI/eT/EcT+zAGgeLhaA4je9fdqhya3ASLYqkMPUjT+zc="));
            string _sql = "select * from Emprestimo_Livro_Literario inner join Livro_Literario on Livro_Literario.N_Registro =  Emprestimo_Livro_Literario.N_Registro inner join Usuario on Usuario.Cod_Usuario = Emprestimo_Livro_Literario.Cod_Usuario where Emprestimo_Livro_Literario.Data_Entrega = ''  and Convert(date, Prazo_Entrega, 103) = Convert(date, @DataAtual, 103)";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@DataAtual", DateTime.Now.ToShortDateString());
            try
            {
                conexao.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    SoundPlayer sound = new SoundPlayer(Resources.Toque);
                    sound.Play();
                    PopupNotifier popup = new PopupNotifier();
                    popup.Image = Resources.Apps_Notifications_icon;
                    popup.TitleText = "Biblioteca Fácil Acesso - Notification";
                    popup.ContentText = "O sistema notifica que existe prazos de empréstimos de livros que vencem hoje";
                    popup.Popup();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Biblioteca Fácil Acesso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }            
        }

        private void menu_Sair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menu_CadastroAlunoFuncionarioOutros_Click(object sender, EventArgs e)
        {
            FrmCadastroUsuarios cadastroUsuarios = new FrmCadastroUsuarios();
            cadastroUsuarios.ShowDialog();
        }

        private void btn_Cadastrar_Usuario_Click(object sender, EventArgs e)
        {
            FrmCadastroUsuarios Ca_Us = new FrmCadastroUsuarios();
            Ca_Us.ShowDialog();
        }

        private void btn_Cadastrar_Livro_Click(object sender, EventArgs e)
        {
            FrmLivroLiterario CL = new FrmLivroLiterario();
            CL.ShowDialog();
        }

        Backup gerarBackup = new Backup();
        string Confirmacao;
        private void Fomulario_Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Confirmacao == null)
            {
                DialogResult dr = MessageBox.Show("Deseja gerar o backup de segurança agora?", "Mensagem do sistema 'Gerenciamento de Caixa Fácil'", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    gerarBackup.ShowDialog();
                    if (gerarBackup.confirmacao == null)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        Confirmacao = "ok";
                        Application.Exit();
                    }
                }
                else if (dr == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else if (dr == DialogResult.No)
                {
                    Confirmacao = "ok";
                    Application.Exit();
                }
            }
            else
            {
                Application.Exit();
            }
        }

        private void menu_Buscar_Todos_Dados_Click(object sender, EventArgs e)
        {
            BFrmBuscarUsuáriosLivros bul = new BFrmBuscarUsuáriosLivros();
            bul.ShowDialog();
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            BFrmBuscarUsuáriosLivros bul = new BFrmBuscarUsuáriosLivros();
            bul.ShowDialog();
        }

        private void btn_CadastrarLivroDidatico_Click(object sender, EventArgs e)
        {
           FrmLivroDidatico CL = new FrmLivroDidatico();
            CL.ShowDialog();
        }

        private void menu_EmprestimoLivroDidatico_Click(object sender, EventArgs e)
        {
            FrmEmprestimoLivroDidatico emprestimolivrodidatico = new FrmEmprestimoLivroDidatico();
            emprestimolivrodidatico.ShowDialog();
        }

        private void menu_DevolucaoLivroLiterario_Click(object sender, EventArgs e)
        {
            FrmDevolucaoLivrosLiterarios devolucaoLivros = new FrmDevolucaoLivrosLiterarios();
            devolucaoLivros.ShowDialog();
        }

        private void menu_DevolucaoLivroDidatico_Click(object sender, EventArgs e)
        {
          FrmDevolucaoLivrosDidatico devolucaoLivrosDidatico = new FrmDevolucaoLivrosDidatico();
            devolucaoLivrosDidatico.ShowDialog();
        }

        private void menu_AlterarLogin_Click(object sender, EventArgs e)
        {
            FrmAlterarSenha AS = new FrmAlterarSenha();
            AS.ShowDialog();
        }

        private void menu_ExcluirLogin_Click(object sender, EventArgs e)
        {
            FrmExcluirUsuario EU = new FrmExcluirUsuario();
            EU.ShowDialog();
        }

        private void menu_Relatorio_Livro_Literarios_Click(object sender, EventArgs e)
        {
            _sql = "SELECT Livro_Literario.Titulo, Usuario.Nome_Usuario, Usuario.Turma, Emprestimo_Livro_Literario.Data_Solicitacao, Emprestimo_Livro_Literario.Prazo_Entrega, Usuario.Ano FROM            Emprestimo_Livro_Literario INNER JOIN Livro_Literario ON Emprestimo_Livro_Literario.N_Registro = Livro_Literario.N_Registro INNER JOIN Usuario ON Emprestimo_Livro_Literario.Cod_Usuario = Usuario.Cod_Usuario WHERE(Usuario.Ocupacao = 'ALUNO') AND(Emprestimo_Livro_Literario.Data_Solicitacao <> '') AND(Emprestimo_Livro_Literario.Data_Entrega = '') AND(CONVERT(date, Emprestimo_Livro_Literario.Prazo_Entrega, 103) < CONVERT(date, @DataAtual, 103)) ORDER BY Usuario.Turma, Usuario.Ano, Usuario.Nome_Usuario";
            if (VerificarEmprestimos())
            {
                Relatório_Livros_Literários_Nao_Entregues RL = new Relatório_Livros_Literários_Nao_Entregues();
                RL.ShowDialog();
            }
            else
            {
                MessageBox.Show("Não há empréstimo de livros que ultrapassaram a data limite de entrega.", "Biblioteca Fácil Acesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void menu_Relatorio_Livro_Didatico_Click(object sender, EventArgs e)
        {
            _sql = "SELECT  Livro_Didatico.Disciplina, Usuario.Nome_Usuario, Usuario.Turma, Emprestimo_Livro_Didatico.Data_Solicitacao, Usuario.Ano FROM Emprestimo_Livro_Didatico INNER JOIN Livro_Didatico ON Emprestimo_Livro_Didatico.N_Registro = Livro_Didatico.N_Registro INNER JOIN Usuario ON Emprestimo_Livro_Didatico.Cod_Usuario = Usuario.Cod_Usuario WHERE(Usuario.Ocupacao = 'aluno') AND(Emprestimo_Livro_Didatico.Data_Solicitacao <> '') AND(Emprestimo_Livro_Didatico.Data_Entrega = '') ORDER BY Usuario.Ano, Usuario.Turma, Usuario.Nome_Usuario";
            if (VerificarEmprestimos())
            {
                Relatorio_Livros_Didaticos_Nao_Entregues rld = new Relatorio_Livros_Didaticos_Nao_Entregues();
                rld.ShowDialog();
            }
            else
            {
                MessageBox.Show("Não há empréstimo de livros didáticos realizados.", "Biblioteca Fácil Acesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
        }

        private void menu_CadastrarLogin_Click_1(object sender, EventArgs e)
        {
            FrmCadastrarLogin cls = new FrmCadastrarLogin();
            cls.Show();
        }

        private void menu_Temporario_LD_Click(object sender, EventArgs e)
        {
            FrmEmprestimoLivroDidaticoTemporaria epdt = new FrmEmprestimoLivroDidaticoTemporaria();
            epdt.ShowDialog();
        }

        private void menu_LivroLiterarioDevolvido_Click(object sender, EventArgs e)
        {
            _sql = "SELECT Livro_Literario.N_Registro, Livro_Literario.Titulo, Usuario.Cod_Usuario, Usuario.Nome_Usuario, Usuario.Turma, Emprestimo_Livro_Literario.Data_Solicitacao, Emprestimo_Livro_Literario.Data_Entrega FROM            Emprestimo_Livro_Literario INNER JOIN Livro_Literario ON Emprestimo_Livro_Literario.N_Registro = Livro_Literario.N_Registro INNER JOIN Usuario ON Emprestimo_Livro_Literario.Cod_Usuario = Usuario.Cod_Usuario WHERE (Usuario.Ocupacao = 'Aluno') AND(Emprestimo_Livro_Literario.Data_Solicitacao <> '') AND(Emprestimo_Livro_Literario.Data_Entrega <> '')";
            if (VerificarEmprestimos())
            {
                RELATORIO_DE_LIVROS_LITERARIOS_DEVOLVIDOS RLD = new RELATORIO_DE_LIVROS_LITERARIOS_DEVOLVIDOS();
                RLD.ShowDialog();
            }
            else
            {
                MessageBox.Show("Não há registro de livros devolvidos realizados.", "Biblioteca Fácil Acesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }           
        }

        private void menu_VerificarAlunos_Click(object sender, EventArgs e)
        {
            FrmBuscarSituacaoUsuarioAluno bsu = new FrmBuscarSituacaoUsuarioAluno();
            bsu.ShowDialog();
        }

        private void menu_BuscarObrasEspecificas_Click(object sender, EventArgs e)
        {
            FrmBuscarLivrosLiterarios bl = new FrmBuscarLivrosLiterarios();
            bl.ShowDialog();
        }

       private void Menu_BuscarObrasLiterarioAutor_Click(object sender, EventArgs e)
        {
            FrmBuscarLivrosAutor BLA = new FrmBuscarLivrosAutor();
            BLA.ShowDialog();
        }

        private void dELIVROLITERÁRIOEMPRESTADOAFUNCIONÁRIOEATERCEIROSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _sql = "SELECT  Livro_Literario.Titulo, Usuario.Nome_Usuario, Emprestimo_Livro_Literario.Data_Solicitacao, Emprestimo_Livro_Literario.Prazo_Entrega FROM Emprestimo_Livro_Literario INNER JOIN  Livro_Literario ON Emprestimo_Livro_Literario.N_Registro = Livro_Literario.N_Registro INNER JOIN Usuario ON Emprestimo_Livro_Literario.Cod_Usuario = Usuario.Cod_Usuario WHERE (Usuario.Ocupacao = 'Funcionário') AND(Emprestimo_Livro_Literario.Data_Solicitacao <> '') AND(Emprestimo_Livro_Literario.Data_Entrega = '') AND (CONVERT(date, Emprestimo_Livro_Literario.Prazo_Entrega, 103) < CONVERT(date, @DataAtual, 103))";
            if (VerificarEmprestimos())
            {
                RelatorioEmpretimoLivrosLiterariosFuncionario rfo = new RelatorioEmpretimoLivrosLiterariosFuncionario();
                rfo.ShowDialog();
            }
            else
            {
                MessageBox.Show("Não há empréstimo de livros que ultrapassaram a data limite de entrega.", "Biblioteca Fácil Acesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }           
        }

        private void menu_EmprestimoLivrosLiterarioTerceiros_Click(object sender, EventArgs e)
        {
            _sql = "SELECT Livro_Literario.Titulo, Usuario.Cod_Usuario, Usuario.Nome_Usuario, Emprestimo_Livro_Literario.Data_Solicitacao,  Emprestimo_Livro_Literario.Prazo_Entrega FROM            Emprestimo_Livro_Literario INNER JOIN Livro_Literario ON Emprestimo_Livro_Literario.N_Registro = Livro_Literario.N_Registro INNER JOIN Usuario ON Emprestimo_Livro_Literario.Cod_Usuario = Usuario.Cod_Usuario WHERE(Usuario.Ocupacao = 'Outros') AND(Emprestimo_Livro_Literario.Data_Solicitacao <> '') AND(Emprestimo_Livro_Literario.Data_Entrega = '') AND(CONVERT(date, Emprestimo_Livro_Literario.Prazo_Entrega, 103) < CONVERT(date, @DataAtual, 103))";
            if (VerificarEmprestimos())
            {
                RelatorioEmpretimoLivrosLiterariosTerceiroscs rlt = new RelatorioEmpretimoLivrosLiterariosTerceiroscs();
                rlt.ShowDialog();

            }
            else
            {
                MessageBox.Show("Não há empréstimo de livros que ultrapassaram a data limite de entrega.", "Biblioteca Fácil Acesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void menu_VerificarSituacaoFT_Click(object sender, EventArgs e)
        {
            FrmVerificarSituacaoFuncionariosTerceiros vft = new FrmVerificarSituacaoFuncionariosTerceiros();
            vft.ShowDialog();
        }

        private void menu_RelatorioEmprestimoLivrosDidaticoFuncionario_Click(object sender, EventArgs e)
        {
            _sql = "SELECT Livro_Didatico.Disciplina, Usuario.Nome_Usuario, Emprestimo_Livro_Didatico.Data_Solicitacao FROM Emprestimo_Livro_Didatico INNER JOIN Usuario ON Emprestimo_Livro_Didatico.Cod_Usuario = Usuario.Cod_Usuario INNER JOIN Livro_Didatico ON Emprestimo_Livro_Didatico.N_Registro = Livro_Didatico.N_Registro WHERE(Usuario.Ocupacao = 'Funcionário') AND(Emprestimo_Livro_Didatico.Data_Solicitacao <> '') AND(Emprestimo_Livro_Didatico.Data_Entrega = '')";
            if (VerificarEmprestimos())
            {
                RelatorioLivrosDidaticosEmprestadosFuncionarios rf = new RelatorioLivrosDidaticosEmprestadosFuncionarios();
                rf.ShowDialog();

            }
            else
            {
                MessageBox.Show("Não há empréstimo de livros didáticos realizados.", "Biblioteca Fácil Acesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void menu_RelatorioEmprestimoLivrosDidaticoTerceiros_Click(object sender, EventArgs e)
        {
            _sql = "SELECT Livro_Didatico.Disciplina, Usuario.Cod_Usuario, Usuario.Nome_Usuario, Emprestimo_Livro_Didatico.Data_Solicitacao FROM Emprestimo_Livro_Didatico INNER JOIN Usuario ON Emprestimo_Livro_Didatico.Cod_Usuario = Usuario.Cod_Usuario INNER JOIN Livro_Didatico ON Emprestimo_Livro_Didatico.N_Registro = Livro_Didatico.N_Registro WHERE(Usuario.Ocupacao = 'Outros') AND(Emprestimo_Livro_Didatico.Data_Solicitacao <> '') AND(Emprestimo_Livro_Didatico.Data_Entrega = '')";
            if (VerificarEmprestimos())
            {
                RELATORIO_DE_LIVROS_DIDATICOS_EMPRESTADOS_A_TERCEIROS rt = new RELATORIO_DE_LIVROS_DIDATICOS_EMPRESTADOS_A_TERCEIROS();
                rt.ShowDialog();


            }
            else
            {
                MessageBox.Show("Não há empréstimo de livros didáticos realizados.", "Biblioteca Fácil Acesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }    
        }

        private void Menu_AnaliseAlunosLetrados_Click(object sender, EventArgs e)
        {
            FrmAnaliseUsuarioMaisLeu AlunosLetrados = new FrmAnaliseUsuarioMaisLeu();
            AlunosLetrados.ShowDialog();
        }

        private void Menu_AnaliseLivrosMaisLidos_Click(object sender, EventArgs e)
        {
            FrmAnaliseLivroMaisEmprestado Al = new FrmAnaliseLivroMaisEmprestado();
            Al.ShowDialog();
        }

        private void Menu_BuscarObrasLiterarioGenero_Click(object sender, EventArgs e)
        {
            FrmBuscarLivrosGenero buscar_Livros_Por_Genero = new FrmBuscarLivrosGenero();
            buscar_Livros_Por_Genero.ShowDialog();
        }

       private void Fomulario_Principal_Load(object sender, EventArgs e)
        {
            lblNomeBiblioteca.Text = "BIBLIOTECA " + Settings.Default["Biblioteca"].ToString().ToUpper();
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSettings settings = new FrmSettings();
            settings.ShowDialog();
        }

        private void Menu_LivroLiterario_Click(object sender, EventArgs e)
        {
            FrmLivroLiterario livroLiterario = new FrmLivroLiterario();
            livroLiterario.ShowDialog();
        }

        private void Menu_LivroDidatico_Click(object sender, EventArgs e)
        {
            FrmLivroDidatico LivroDidatico = new FrmLivroDidatico();
            LivroDidatico.ShowDialog();
        }

        private void MenuCadastroInstituicao_Click(object sender, EventArgs e)
        {
            FrmInstituicao instituicao = new FrmInstituicao();
            instituicao.ShowDialog();
            lblNomeBiblioteca.Text = "BIBLIOTECA " + Settings.Default["Biblioteca"].ToString().ToUpper();
        }

        private void MenuQuantidadeLivrosCadastrados_Click(object sender, EventArgs e)
        {
            QuantidadeLivrosCadastrados quantidadeLivros = new QuantidadeLivrosCadastrados();
            quantidadeLivros.ShowDialog();
        }

        private void menu_EmprestimoLivroLiterario_Click(object sender, EventArgs e)
        {
            FrmEmprestimoLivroLiterario emprestimoLivro = new FrmEmprestimoLivroLiterario();
            emprestimoLivro.ShowDialog();
        }

        private void menu_CadastrarLogin_Click(object sender, EventArgs e)
        {
            FrmCadastrarLogin cadastrarLogin = new FrmCadastrarLogin();
            cadastrarLogin.ShowDialog();
        }

        private void menuAlterarSenha_Click(object sender, EventArgs e)
        {
            FrmAlterarSenha alterarSenha = new FrmAlterarSenha();
            alterarSenha.ShowDialog();
        }

        private void menuExcluirLogin_Click(object sender, EventArgs e)
        {
            FrmExcluirUsuario excluirUsuario = new FrmExcluirUsuario();
            excluirUsuario.ShowDialog();
        }

        private void prazoDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOpcaoPrazoEmprestimo opcaoPrazoEmprestimo = new FrmOpcaoPrazoEmprestimo();
            opcaoPrazoEmprestimo.ShowDialog();
        }

        private void tODOSOSLIVROSEMPRESTADOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _sql = "SELECT Livro_Literario.Titulo, Usuario.Nome_Usuario,  Usuario.Ano, Emprestimo_Livro_Literario.Data_Solicitacao, " +
                "Emprestimo_Livro_Literario.Prazo_Entrega, Usuario.Turma FROM            Emprestimo_Livro_Literario INNER JOIN Livro_Literario ON " +
                "Emprestimo_Livro_Literario.N_Registro = Livro_Literario.N_Registro " +
                "INNER JOIN Usuario ON Emprestimo_Livro_Literario.Cod_Usuario = " +
                "Usuario.Cod_Usuario WHERE(Emprestimo_Livro_Literario.Data_Solicitacao <> '') " +
                "AND (Emprestimo_Livro_Literario.Data_Entrega = '') ORDER BY " +
                "Usuario.Ocupacao, Usuario.Turma, Usuario.Ano, Usuario.Nome_Usuario";
            if (VerificarEmprestimos())
            {
                FrmRelatorioListaLivrosLiteráriosEmprestados listaLivrosLiteráriosEmprestados = new FrmRelatorioListaLivrosLiteráriosEmprestados();
                listaLivrosLiteráriosEmprestados.ShowDialog();
            }
            else
            {
                MessageBox.Show("Não há empréstimos realizados.", "Biblioteca Fácil Acesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
