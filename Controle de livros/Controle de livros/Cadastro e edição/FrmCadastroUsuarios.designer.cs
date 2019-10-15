﻿namespace Controle_de_livros
{
    partial class FrmCadastroUsuarios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadastroUsuarios));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_Outros = new System.Windows.Forms.RadioButton();
            this.rb_Funcionario = new System.Windows.Forms.RadioButton();
            this.rb_Aluno = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbl_Codigo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_Turma = new System.Windows.Forms.ComboBox();
            this.usuarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_Usuario = new Controle_de_livros.DataSet_s.DataSet_Usuario();
            this.label8 = new System.Windows.Forms.Label();
            this.cb_Ano = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Nome = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_Tel_Cel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Endereco = new System.Windows.Forms.TextBox();
            this.txt_Numero = new System.Windows.Forms.TextBox();
            this.error_Provider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btn_Salvar = new System.Windows.Forms.Button();
            this.usuarioTableAdapter = new Controle_de_livros.DataSet_s.DataSet_UsuarioTableAdapters.UsuarioTableAdapter();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usuarioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Usuario)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.error_Provider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_Outros);
            this.groupBox1.Controls.Add(this.rb_Funcionario);
            this.groupBox1.Controls.Add(this.rb_Aluno);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(18, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(745, 89);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selecíone a ocupação do usuário:";
            // 
            // rb_Outros
            // 
            this.rb_Outros.AutoSize = true;
            this.rb_Outros.Location = new System.Drawing.Point(616, 40);
            this.rb_Outros.Margin = new System.Windows.Forms.Padding(4);
            this.rb_Outros.Name = "rb_Outros";
            this.rb_Outros.Size = new System.Drawing.Size(73, 23);
            this.rb_Outros.TabIndex = 2;
            this.rb_Outros.Text = "Outros";
            this.rb_Outros.UseVisualStyleBackColor = true;
            this.rb_Outros.CheckedChanged += new System.EventHandler(this.rb_Outros_CheckedChanged);
            // 
            // rb_Funcionario
            // 
            this.rb_Funcionario.AutoSize = true;
            this.rb_Funcionario.Location = new System.Drawing.Point(307, 40);
            this.rb_Funcionario.Margin = new System.Windows.Forms.Padding(4);
            this.rb_Funcionario.Name = "rb_Funcionario";
            this.rb_Funcionario.Size = new System.Drawing.Size(105, 23);
            this.rb_Funcionario.TabIndex = 1;
            this.rb_Funcionario.Text = "Funcionário";
            this.rb_Funcionario.UseVisualStyleBackColor = true;
            this.rb_Funcionario.CheckedChanged += new System.EventHandler(this.rb_Funcionario_CheckedChanged);
            // 
            // rb_Aluno
            // 
            this.rb_Aluno.AutoSize = true;
            this.rb_Aluno.Checked = true;
            this.rb_Aluno.Location = new System.Drawing.Point(33, 40);
            this.rb_Aluno.Margin = new System.Windows.Forms.Padding(4);
            this.rb_Aluno.Name = "rb_Aluno";
            this.rb_Aluno.Size = new System.Drawing.Size(66, 23);
            this.rb_Aluno.TabIndex = 0;
            this.rb_Aluno.TabStop = true;
            this.rb_Aluno.Text = "Aluno";
            this.rb_Aluno.UseVisualStyleBackColor = true;
            this.rb_Aluno.CheckedChanged += new System.EventHandler(this.rb_Aluno_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbl_Codigo);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cb_Turma);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cb_Ano);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txt_Nome);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(18, 113);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(745, 153);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dados do usuário:";
            // 
            // lbl_Codigo
            // 
            this.lbl_Codigo.BackColor = System.Drawing.Color.White;
            this.lbl_Codigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Codigo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Codigo.Location = new System.Drawing.Point(45, 43);
            this.lbl_Codigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Codigo.Name = "lbl_Codigo";
            this.lbl_Codigo.Size = new System.Drawing.Size(92, 27);
            this.lbl_Codigo.TabIndex = 19;
            this.lbl_Codigo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 19);
            this.label1.TabIndex = 18;
            this.label1.Text = "Código:";
            // 
            // cb_Turma
            // 
            this.cb_Turma.AccessibleDescription = "";
            this.cb_Turma.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cb_Turma.DataSource = this.usuarioBindingSource;
            this.cb_Turma.DisplayMember = "Turma";
            this.cb_Turma.FormattingEnabled = true;
            this.cb_Turma.Location = new System.Drawing.Point(347, 103);
            this.cb_Turma.Name = "cb_Turma";
            this.cb_Turma.Size = new System.Drawing.Size(121, 27);
            this.cb_Turma.TabIndex = 3;
            // 
            // usuarioBindingSource
            // 
            this.usuarioBindingSource.DataMember = "Usuario";
            this.usuarioBindingSource.DataSource = this.dataSet_Usuario;
            // 
            // dataSet_Usuario
            // 
            this.dataSet_Usuario.DataSetName = "DataSet_Usuario";
            this.dataSet_Usuario.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(45, 81);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 19);
            this.label8.TabIndex = 16;
            this.label8.Text = "Ano:";
            // 
            // cb_Ano
            // 
            this.cb_Ano.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cb_Ano.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Ano.FormattingEnabled = true;
            this.cb_Ano.Items.AddRange(new object[] {
            "",
            "1º - ENSINO FUNDAMENTAL",
            "2º - ENSINO FUNDAMENTAL",
            "3º - ENSINO FUNDAMENTAL",
            "4º - ENSINO FUNDAMENTAL",
            "5º - ENSINO FUNDAMENTAL",
            "6º - ENSINO FUNDAMENTAL",
            "7º - ENSINO FUNDAMENTAL",
            "8º - ENSINO FUNDAMENTAL",
            "9º - ENSINO FUNDAMENTAL",
            "1º - ENSINO MÉDIO",
            "2º - ENSINO MÉDIO",
            "3º - ENSINO MÉDIO",
            "EJA "});
            this.cb_Ano.Location = new System.Drawing.Point(45, 103);
            this.cb_Ano.Name = "cb_Ano";
            this.cb_Ano.Size = new System.Drawing.Size(274, 27);
            this.cb_Ano.TabIndex = 2;
            this.cb_Ano.SelectedIndexChanged += new System.EventHandler(this.cb_Ano_SelectedIndexChanged);
            this.cb_Ano.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cb_Ano_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(343, 81);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 19);
            this.label3.TabIndex = 15;
            this.label3.Text = "Turma:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(155, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nome:";
            // 
            // txt_Nome
            // 
            this.txt_Nome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Nome.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Nome.Location = new System.Drawing.Point(159, 43);
            this.txt_Nome.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Nome.MaxLength = 100;
            this.txt_Nome.Name = "txt_Nome";
            this.txt_Nome.Size = new System.Drawing.Size(565, 26);
            this.txt_Nome.TabIndex = 1;
            this.txt_Nome.TextChanged += new System.EventHandler(this.txt_Nome_TextChanged);
            this.txt_Nome.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Nome_KeyDown);
            this.txt_Nome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Nome_KeyPress);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_Tel_Cel);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txt_Endereco);
            this.groupBox3.Controls.Add(this.txt_Numero);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(18, 274);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(745, 100);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Localização:";
            // 
            // txt_Tel_Cel
            // 
            this.txt_Tel_Cel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Tel_Cel.Location = new System.Drawing.Point(461, 41);
            this.txt_Tel_Cel.MaxLength = 14;
            this.txt_Tel_Cel.Name = "txt_Tel_Cel";
            this.txt_Tel_Cel.Size = new System.Drawing.Size(115, 26);
            this.txt_Tel_Cel.TabIndex = 6;
            this.txt_Tel_Cel.TextChanged += new System.EventHandler(this.txt_Telefone_TextChanged);
            this.txt_Tel_Cel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_Telefone_KeyDown);
            this.txt_Tel_Cel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Telefone_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(457, 18);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 19);
            this.label6.TabIndex = 6;
            this.label6.Text = "Tel/Cel:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(45, 18);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 19);
            this.label5.TabIndex = 5;
            this.label5.Text = "Endereço:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(340, 18);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Número:";
            // 
            // txt_Endereco
            // 
            this.txt_Endereco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Endereco.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Endereco.Location = new System.Drawing.Point(45, 41);
            this.txt_Endereco.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Endereco.MaxLength = 30;
            this.txt_Endereco.Name = "txt_Endereco";
            this.txt_Endereco.Size = new System.Drawing.Size(267, 26);
            this.txt_Endereco.TabIndex = 4;
            this.txt_Endereco.TextChanged += new System.EventHandler(this.txt_Endereco_TextChanged);
            this.txt_Endereco.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Endereco_KeyDown);
            // 
            // txt_Numero
            // 
            this.txt_Numero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Numero.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Numero.Location = new System.Drawing.Point(338, 41);
            this.txt_Numero.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Numero.Name = "txt_Numero";
            this.txt_Numero.Size = new System.Drawing.Size(92, 26);
            this.txt_Numero.TabIndex = 5;
            this.txt_Numero.TextChanged += new System.EventHandler(this.txt_Numero_TextChanged);
            this.txt_Numero.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Numero_KeyDown);
            this.txt_Numero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Numero_KeyPress);
            // 
            // error_Provider
            // 
            this.error_Provider.ContainerControl = this;
            // 
            // btn_Salvar
            // 
            this.btn_Salvar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Salvar.Image = global::Controle_de_livros.Properties.Resources.Zerode_Plump_Drive_Floppy_blue;
            this.btn_Salvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Salvar.Location = new System.Drawing.Point(94, 382);
            this.btn_Salvar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Salvar.Name = "btn_Salvar";
            this.btn_Salvar.Size = new System.Drawing.Size(132, 41);
            this.btn_Salvar.TabIndex = 7;
            this.btn_Salvar.Text = "Salvar";
            this.btn_Salvar.UseVisualStyleBackColor = true;
            this.btn_Salvar.Click += new System.EventHandler(this.btn_Salvar_Click);
            // 
            // usuarioTableAdapter
            // 
            this.usuarioTableAdapter.ClearBeforeFill = true;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPesquisar.Location = new System.Drawing.Point(234, 382);
            this.btnPesquisar.Margin = new System.Windows.Forms.Padding(4);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(136, 41);
            this.btnPesquisar.TabIndex = 8;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditar.Image = global::Controle_de_livros.Properties.Resources.Hopstarter_Soft_Scraps_Edit_Document;
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.Location = new System.Drawing.Point(378, 382);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(132, 41);
            this.btnEditar.TabIndex = 9;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcluir.Image = global::Controle_de_livros.Properties.Resources.Button_Delete_icon_32x32;
            this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcluir.Location = new System.Drawing.Point(518, 382);
            this.btnExcluir.Margin = new System.Windows.Forms.Padding(4);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(132, 41);
            this.btnExcluir.TabIndex = 10;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.BtnExcluir_Click);
            // 
            // FrmCadastroUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(776, 428);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btn_Salvar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmCadastroUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CADASTRO USUÁRIO";
            this.Load += new System.EventHandler(this.FrmCadastroUsuarios_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usuarioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Usuario)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.error_Provider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_Outros;
        private System.Windows.Forms.RadioButton rb_Funcionario;
        private System.Windows.Forms.RadioButton rb_Aluno;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Nome;
        private System.Windows.Forms.Button btn_Salvar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Endereco;
        private System.Windows.Forms.TextBox txt_Numero;
        private System.Windows.Forms.TextBox txt_Tel_Cel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cb_Ano;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider error_Provider;
        private System.Windows.Forms.ComboBox cb_Turma;
        private DataSet_s.DataSet_Usuario dataSet_Usuario;
        private System.Windows.Forms.BindingSource usuarioBindingSource;
        private DataSet_s.DataSet_UsuarioTableAdapters.UsuarioTableAdapter usuarioTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Codigo;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnPesquisar;
    }
}