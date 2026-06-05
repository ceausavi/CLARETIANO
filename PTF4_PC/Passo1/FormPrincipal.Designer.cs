// FormPrincipal.Designer.cs — Layout gerado pelo designer
namespace Passo1;

partial class FormPrincipal
{
    private System.ComponentModel.IContainer components = null;

    // ── Controles do formulário ──────────────────────────────────────────
    private System.Windows.Forms.GroupBox   grpCadastro;
    private System.Windows.Forms.GroupBox   grpLista;
    private System.Windows.Forms.GroupBox   grpConsultas;
    private System.Windows.Forms.GroupBox   grpResultados;

    private System.Windows.Forms.Label      lblNome;
    private System.Windows.Forms.Label      lblIdade;
    private System.Windows.Forms.Label      lblNota;
    private System.Windows.Forms.Label      lblStatus;
    private System.Windows.Forms.Label      lblTotalAlunos;

    private System.Windows.Forms.TextBox    txNome;
    private System.Windows.Forms.TextBox    txIdade;
    private System.Windows.Forms.TextBox    txNota;

    private System.Windows.Forms.Button     btnAdicionar;
    private System.Windows.Forms.Button     btnLimpar;
    private System.Windows.Forms.Button     btnRemover;
    private System.Windows.Forms.Button     btnAprovados;
    private System.Windows.Forms.Button     btnMedia;
    private System.Windows.Forms.Button     btnMaiores;
    private System.Windows.Forms.Button     btnTodos;
    private System.Windows.Forms.Button     btnLimparResultados;

    private System.Windows.Forms.DataGridView   dgAlunos;
    private System.Windows.Forms.RichTextBox    rtResultados;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        grpCadastro = new GroupBox();
        lblNome = new Label();
        txNome = new TextBox();
        lblIdade = new Label();
        txIdade = new TextBox();
        lblNota = new Label();
        txNota = new TextBox();
        btnAdicionar = new Button();
        btnLimpar = new Button();
        lblStatus = new Label();
        grpLista = new GroupBox();
        dgAlunos = new DataGridView();
        btnRemover = new Button();
        lblTotalAlunos = new Label();
        grpConsultas = new GroupBox();
        btnAprovados = new Button();
        btnMedia = new Button();
        btnMaiores = new Button();
        btnTodos = new Button();
        btnLimparResultados = new Button();
        grpResultados = new GroupBox();
        rtResultados = new RichTextBox();
        grpCadastro.SuspendLayout();
        grpLista.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgAlunos).BeginInit();
        grpConsultas.SuspendLayout();
        grpResultados.SuspendLayout();
        SuspendLayout();
        // 
        // grpCadastro
        // 
        grpCadastro.BackColor = Color.White;
        grpCadastro.Controls.Add(lblNome);
        grpCadastro.Controls.Add(txNome);
        grpCadastro.Controls.Add(lblIdade);
        grpCadastro.Controls.Add(txIdade);
        grpCadastro.Controls.Add(lblNota);
        grpCadastro.Controls.Add(txNota);
        grpCadastro.Controls.Add(btnAdicionar);
        grpCadastro.Controls.Add(btnLimpar);
        grpCadastro.Controls.Add(lblStatus);
        grpCadastro.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        grpCadastro.Location = new Point(12, 10);
        grpCadastro.Name = "grpCadastro";
        grpCadastro.Size = new Size(800, 110);
        grpCadastro.TabIndex = 0;
        grpCadastro.TabStop = false;
        grpCadastro.Text = "Cadastro de Aluno";
        // 
        // lblNome
        // 
        lblNome.AutoSize = true;
        lblNome.Font = new Font("Segoe UI", 9.5F);
        lblNome.Location = new Point(12, 30);
        lblNome.Name = "lblNome";
        lblNome.Size = new Size(47, 17);
        lblNome.TabIndex = 0;
        lblNome.Text = "Nome:";
        // 
        // txNome
        // 
        txNome.Font = new Font("Segoe UI", 9.5F);
        txNome.Location = new Point(12, 50);
        txNome.MaxLength = 100;
        txNome.Name = "txNome";
        txNome.Size = new Size(200, 24);
        txNome.TabIndex = 1;
        txNome.KeyDown += txNome_KeyDown;
        // 
        // lblIdade
        // 
        lblIdade.AutoSize = true;
        lblIdade.Font = new Font("Segoe UI", 9.5F);
        lblIdade.Location = new Point(228, 30);
        lblIdade.Name = "lblIdade";
        lblIdade.Size = new Size(44, 17);
        lblIdade.TabIndex = 2;
        lblIdade.Text = "Idade:";
        // 
        // txIdade
        // 
        txIdade.Font = new Font("Segoe UI", 9.5F);
        txIdade.Location = new Point(228, 50);
        txIdade.MaxLength = 3;
        txIdade.Name = "txIdade";
        txIdade.Size = new Size(80, 24);
        txIdade.TabIndex = 3;
        txIdade.KeyDown += txIdade_KeyDown;
        // 
        // lblNota
        // 
        lblNota.AutoSize = true;
        lblNota.Font = new Font("Segoe UI", 9.5F);
        lblNota.Location = new Point(324, 30);
        lblNota.Name = "lblNota";
        lblNota.Size = new Size(108, 17);
        lblNota.TabIndex = 4;
        lblNota.Text = "Nota (0,0 – 10,0):";
        // 
        // txNota
        // 
        txNota.Font = new Font("Segoe UI", 9.5F);
        txNota.Location = new Point(324, 50);
        txNota.MaxLength = 5;
        txNota.Name = "txNota";
        txNota.Size = new Size(90, 24);
        txNota.TabIndex = 5;
        txNota.KeyDown += txNota_KeyDown;
        // 
        // btnAdicionar
        // 
        btnAdicionar.BackColor = Color.FromArgb(40, 120, 220);
        btnAdicionar.Cursor = Cursors.Hand;
        btnAdicionar.FlatAppearance.BorderSize = 0;
        btnAdicionar.FlatStyle = FlatStyle.Flat;
        btnAdicionar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnAdicionar.ForeColor = Color.White;
        btnAdicionar.Location = new Point(432, 46);
        btnAdicionar.Name = "btnAdicionar";
        btnAdicionar.Size = new Size(130, 32);
        btnAdicionar.TabIndex = 6;
        btnAdicionar.Text = "➕  Adicionar";
        btnAdicionar.UseVisualStyleBackColor = false;
        btnAdicionar.Click += btnAdicionar_Click;
        // 
        // btnLimpar
        // 
        btnLimpar.BackColor = Color.FromArgb(200, 200, 210);
        btnLimpar.Cursor = Cursors.Hand;
        btnLimpar.FlatAppearance.BorderSize = 0;
        btnLimpar.FlatStyle = FlatStyle.Flat;
        btnLimpar.Font = new Font("Segoe UI", 9.5F);
        btnLimpar.Location = new Point(578, 46);
        btnLimpar.Name = "btnLimpar";
        btnLimpar.Size = new Size(110, 32);
        btnLimpar.TabIndex = 7;
        btnLimpar.Text = "🗑  Limpar";
        btnLimpar.UseVisualStyleBackColor = false;
        btnLimpar.Click += btnLimpar_Click;
        // 
        // lblStatus
        // 
        lblStatus.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
        lblStatus.ForeColor = Color.Gray;
        lblStatus.Location = new Point(12, 84);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(760, 18);
        lblStatus.TabIndex = 8;
        lblStatus.Text = "Preencha os campos e clique em Adicionar.";
        // 
        // grpLista
        // 
        grpLista.BackColor = Color.White;
        grpLista.Controls.Add(dgAlunos);
        grpLista.Controls.Add(btnRemover);
        grpLista.Controls.Add(lblTotalAlunos);
        grpLista.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        grpLista.Location = new Point(12, 130);
        grpLista.Name = "grpLista";
        grpLista.Size = new Size(800, 185);
        grpLista.TabIndex = 1;
        grpLista.TabStop = false;
        grpLista.Text = "Lista de Alunos Cadastrados";
        // 
        // dgAlunos
        // 
        dgAlunos.AllowUserToAddRows = false;
        dgAlunos.AllowUserToDeleteRows = false;
        dgAlunos.BackgroundColor = Color.White;
        dgAlunos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgAlunos.Font = new Font("Segoe UI", 9.5F);
        dgAlunos.GridColor = Color.FromArgb(220, 225, 235);
        dgAlunos.Location = new Point(12, 22);
        dgAlunos.MultiSelect = false;
        dgAlunos.Name = "dgAlunos";
        dgAlunos.ReadOnly = true;
        dgAlunos.RowHeadersVisible = false;
        dgAlunos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgAlunos.Size = new Size(670, 148);
        dgAlunos.TabIndex = 0;
        // 
        // btnRemover
        // 
        btnRemover.BackColor = Color.FromArgb(220, 60, 60);
        btnRemover.Cursor = Cursors.Hand;
        btnRemover.FlatAppearance.BorderSize = 0;
        btnRemover.FlatStyle = FlatStyle.Flat;
        btnRemover.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        btnRemover.ForeColor = Color.White;
        btnRemover.Location = new Point(694, 22);
        btnRemover.Name = "btnRemover";
        btnRemover.Size = new Size(96, 55);
        btnRemover.TabIndex = 1;
        btnRemover.Text = "🗑 Remover\nSelecionado";
        btnRemover.UseVisualStyleBackColor = false;
        btnRemover.Click += btnRemover_Click;
        // 
        // lblTotalAlunos
        // 
        lblTotalAlunos.AutoSize = true;
        lblTotalAlunos.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
        lblTotalAlunos.ForeColor = Color.FromArgb(80, 80, 100);
        lblTotalAlunos.Location = new Point(12, 158);
        lblTotalAlunos.Name = "lblTotalAlunos";
        lblTotalAlunos.Size = new Size(99, 15);
        lblTotalAlunos.TabIndex = 2;
        lblTotalAlunos.Text = "Total de alunos: 0";
        // 
        // grpConsultas
        // 
        grpConsultas.BackColor = Color.White;
        grpConsultas.Controls.Add(btnAprovados);
        grpConsultas.Controls.Add(btnMedia);
        grpConsultas.Controls.Add(btnMaiores);
        grpConsultas.Controls.Add(btnTodos);
        grpConsultas.Controls.Add(btnLimparResultados);
        grpConsultas.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        grpConsultas.Location = new Point(12, 326);
        grpConsultas.Name = "grpConsultas";
        grpConsultas.Size = new Size(800, 65);
        grpConsultas.TabIndex = 2;
        grpConsultas.TabStop = false;
        grpConsultas.Text = "Consultas LINQ";
        // 
        // btnAprovados
        // 
        btnAprovados.Location = new Point(12, 22);
        btnAprovados.Name = "btnAprovados";
        btnAprovados.Size = new Size(99, 23);
        btnAprovados.TabIndex = 0;
        btnAprovados.Text = "APROVADOS";
        btnAprovados.Click += btnAprovados_Click;
        // 
        // btnMedia
        // 
        btnMedia.Location = new Point(168, 22);
        btnMedia.Name = "btnMedia";
        btnMedia.Size = new Size(104, 23);
        btnMedia.TabIndex = 1;
        btnMedia.Text = "ESTATISTICAS";
        btnMedia.Click += btnMedia_Click;
        // 
        // btnMaiores
        // 
        btnMaiores.Location = new Point(324, 22);
        btnMaiores.Name = "btnMaiores";
        btnMaiores.Size = new Size(90, 23);
        btnMaiores.TabIndex = 2;
        btnMaiores.Text = "> 20 ANOS";
        btnMaiores.Click += btnMaiores_Click;
        // 
        // btnTodos
        // 
        btnTodos.Location = new Point(480, 22);
        btnTodos.Name = "btnTodos";
        btnTodos.Size = new Size(75, 23);
        btnTodos.TabIndex = 3;
        btnTodos.Text = "TODOS";
        btnTodos.Click += btnTodos_Click;
        // 
        // btnLimparResultados
        // 
        btnLimparResultados.Location = new Point(690, 22);
        btnLimparResultados.Name = "btnLimparResultados";
        btnLimparResultados.Size = new Size(75, 23);
        btnLimparResultados.TabIndex = 4;
        btnLimparResultados.Text = "LIMPAR";
        btnLimparResultados.Click += btnLimparResultados_Click;
        // 
        // grpResultados
        // 
        grpResultados.BackColor = Color.White;
        grpResultados.Controls.Add(rtResultados);
        grpResultados.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        grpResultados.Location = new Point(12, 402);
        grpResultados.Name = "grpResultados";
        grpResultados.Size = new Size(800, 206);
        grpResultados.TabIndex = 3;
        grpResultados.TabStop = false;
        grpResultados.Text = "Resultado da Consulta LINQ";
        // 
        // rtResultados
        // 
        rtResultados.BackColor = Color.FromArgb(250, 251, 255);
        rtResultados.BorderStyle = BorderStyle.FixedSingle;
        rtResultados.Font = new Font("Consolas", 9.5F);
        rtResultados.ForeColor = Color.FromArgb(100, 100, 120);
        rtResultados.Location = new Point(12, 22);
        rtResultados.Name = "rtResultados";
        rtResultados.ReadOnly = true;
        rtResultados.ScrollBars = RichTextBoxScrollBars.Vertical;
        rtResultados.Size = new Size(772, 172);
        rtResultados.TabIndex = 0;
        rtResultados.Text = "Clique em uma consulta para ver os resultados aqui.";
        // 
        // FormPrincipal
        // 
        BackColor = Color.FromArgb(245, 246, 250);
        ClientSize = new Size(824, 621);
        Controls.Add(grpCadastro);
        Controls.Add(grpLista);
        Controls.Add(grpConsultas);
        Controls.Add(grpResultados);
        Font = new Font("Segoe UI", 9.5F);
        MinimumSize = new Size(840, 660);
        Name = "FormPrincipal";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Sistema de Alunos — LINQ  |  Passo 1";
        Load += FormPrincipal_Load;
        grpCadastro.ResumeLayout(false);
        grpCadastro.PerformLayout();
        grpLista.ResumeLayout(false);
        grpLista.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgAlunos).EndInit();
        grpConsultas.ResumeLayout(false);
        grpResultados.ResumeLayout(false);
        ResumeLayout(false);
    }

    // ── Helper para estilizar botões de consulta de forma uniforme ───────
    private static void EstilizarBotaoConsulta(
        System.Windows.Forms.Button btn, string texto, System.Drawing.Color cor)
    {
        btn.Text      = texto;
        btn.Size      = new System.Drawing.Size(148, 34);
        btn.BackColor = cor;
        btn.ForeColor = System.Drawing.Color.White;
        btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btn.Font      = new System.Drawing.Font("Segoe UI", 8.5f, System.Drawing.FontStyle.Bold);
        btn.FlatAppearance.BorderSize = 0;
        btn.Cursor    = System.Windows.Forms.Cursors.Hand;
    }
}
