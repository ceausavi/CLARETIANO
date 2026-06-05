// FormPrincipal.cs — Lógica do formulário + consultas LINQ
// Disciplina: Programação Comercial em C#
// Prof. Me. Pablo Rodrigo Gonçalves

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Passo1;

public partial class FormPrincipal : Form
{
    // Lista em memória sincronizada com o banco MySQL
    private List<Aluno> _alunos = new();

    public FormPrincipal()
    {
        InitializeComponent();
        VerificarConexao();
        CarregarDosBanco();
    }

    // ── Verifica conexão com MySQL ao abrir ─────────────────────────────
    private void VerificarConexao()
    {
        bool ok = DatabaseHelper.TestarConexao(out string msg);
        MostrarStatus(ok ? $"✔ {msg}" : $"✘ {msg}", ok ? Color.SeaGreen : Color.OrangeRed);
    }

    // ── Carrega alunos do banco e atualiza a grid ───────────────────────
    private void CarregarDosBanco()
    {
        try
        {
            _alunos = DatabaseHelper.CarregarAlunos();
            AtualizarGrid();
        }
        catch (Exception ex)
        {
            MostrarStatus($"✘ Erro ao carregar dados: {ex.Message}", Color.OrangeRed);
        }
    }

    // ── Atualiza o DataGridView com a lista atual ───────────────────────
    private void AtualizarGrid()
    {
        dgAlunos.DataSource = null;
        dgAlunos.DataSource = _alunos
            .Select(a => new { a.Id, a.Nome, a.Idade, Nota = a.Nota.ToString("F1") })
            .ToList();

        if (dgAlunos.Columns.Count >= 4)
        {
            dgAlunos.Columns[0].HeaderText = "ID";
            dgAlunos.Columns[1].HeaderText = "Nome";
            dgAlunos.Columns[2].HeaderText = "Idade";
            dgAlunos.Columns[3].HeaderText = "Nota";

            dgAlunos.Columns[0].Width = 50;
            dgAlunos.Columns[1].Width = 280;
            dgAlunos.Columns[2].Width = 80;
            dgAlunos.Columns[3].Width = 80;
        }

        lblTotalAlunos.Text = $"Total de alunos: {_alunos.Count}";
    }

    // ── BOTÃO: Adicionar Aluno ──────────────────────────────────────────
    private void btnAdicionar_Click(object sender, EventArgs e)
    {
        string nome = txNome.Text.Trim();

        if (string.IsNullOrEmpty(nome))
        {
            MostrarStatus("⚠ Informe o nome do aluno.", Color.OrangeRed);
            txNome.Focus();
            return;
        }

        if (!int.TryParse(txIdade.Text, out int idade) || idade < 1 || idade > 120)
        {
            MostrarStatus("⚠ Informe uma idade válida (1–120).", Color.OrangeRed);
            txIdade.Focus();
            return;
        }

        if (!double.TryParse(txNota.Text.Replace('.', ','), out double nota) || nota < 0 || nota > 10)
        {
            MostrarStatus("⚠ Informe uma nota válida (0,0 – 10,0).", Color.OrangeRed);
            txNota.Focus();
            return;
        }

        try
        {
            var novoAluno = new Aluno { Nome = nome, Idade = idade, Nota = nota };
            DatabaseHelper.InserirAluno(novoAluno); // salva no MySQL e preenche o Id
            _alunos.Add(novoAluno);
            AtualizarGrid();
            LimparCamposCadastro();
            MostrarStatus($"✔ Aluno \"{nome}\" salvo no banco com sucesso! (ID: {novoAluno.Id})", Color.SeaGreen);
            txNome.Focus();
        }
        catch (Exception ex)
        {
            MostrarStatus($"✘ Erro ao salvar: {ex.Message}", Color.OrangeRed);
        }
    }

    // ── BOTÃO: Remover aluno selecionado na grid ────────────────────────
    private void btnRemover_Click(object sender, EventArgs e)
    {
        if (dgAlunos.CurrentRow == null)
        {
            MostrarStatus("⚠ Selecione um aluno na lista para remover.", Color.OrangeRed);
            return;
        }

        int idx = dgAlunos.CurrentRow.Index;
        if (idx < 0 || idx >= _alunos.Count) return;

        var aluno = _alunos[idx];

        var confirm = MessageBox.Show(
            $"Deseja remover o aluno \"{aluno.Nome}\" do banco de dados?",
            "Confirmar Remoção",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (confirm == DialogResult.Yes)
        {
            try
            {
                DatabaseHelper.RemoverAluno(aluno.Id);
                _alunos.RemoveAt(idx);
                AtualizarGrid();
                MostrarStatus($"✔ Aluno \"{aluno.Nome}\" removido do banco.", Color.SeaGreen);
            }
            catch (Exception ex)
            {
                MostrarStatus($"✘ Erro ao remover: {ex.Message}", Color.OrangeRed);
            }
        }
    }

    // ── CONSULTA LINQ 1: Aprovados (nota > 7) ──────────────────────────
    private void btnAprovados_Click(object sender, EventArgs e)
    {
        var aprovados = from a in _alunos
                        where a.Nota > 7
                        orderby a.Nota descending
                        select a;

        var lista = aprovados.ToList();

        var sb = new System.Text.StringBuilder();
        sb.AppendLine("══════════════════════════════════════");
        sb.AppendLine("  CONSULTA LINQ — Alunos Aprovados (nota > 7)");
        sb.AppendLine("  Ordenados por nota decrescente");
        sb.AppendLine("══════════════════════════════════════");

        if (!lista.Any())
            sb.AppendLine("  Nenhum aluno aprovado.");
        else
        {
            int pos = 1;
            foreach (var a in lista)
                sb.AppendLine($"  {pos++}. {a.Nome,-15} │ Nota: {a.Nota:F1}  │  Idade: {a.Idade}");

            sb.AppendLine($"\n  Total aprovados: {lista.Count} de {_alunos.Count} aluno(s)");
        }

        ExibirResultado(sb.ToString());
    }

    // ── CONSULTA LINQ 2: Estatísticas ───────────────────────────────────
    private void btnMedia_Click(object sender, EventArgs e)
    {
        if (!_alunos.Any()) { ExibirResultado("Nenhum aluno cadastrado."); return; }

        double media = _alunos.Average(a => a.Nota);
        var melhor = _alunos.MaxBy(a => a.Nota)!;
        var pior = _alunos.MinBy(a => a.Nota)!;

        var sb = new System.Text.StringBuilder();
        sb.AppendLine("══════════════════════════════════════");
        sb.AppendLine("  CONSULTA LINQ — Estatísticas das Notas");
        sb.AppendLine("══════════════════════════════════════");
        sb.AppendLine($"  Média geral .....: {media:F2}");
        sb.AppendLine($"  Maior nota ......: {melhor.Nota:F1}  ({melhor.Nome})");
        sb.AppendLine($"  Menor nota ......: {pior.Nota:F1}  ({pior.Nome})");
        sb.AppendLine($"  Total de alunos .: {_alunos.Count}");
        ExibirResultado(sb.ToString());
    }

    // ── CONSULTA LINQ 3: Alunos com mais de 20 anos ────────────────────
    private void btnMaiores_Click(object sender, EventArgs e)
    {
        var maiores = _alunos.Where(a => a.Idade > 20).OrderBy(a => a.Nome).ToList();

        var sb = new System.Text.StringBuilder();
        sb.AppendLine("══════════════════════════════════════");
        sb.AppendLine("  CONSULTA LINQ — Alunos com mais de 20 anos");
        sb.AppendLine("══════════════════════════════════════");

        if (!maiores.Any())
            sb.AppendLine("  Nenhum aluno com mais de 20 anos.");
        else
        {
            foreach (var a in maiores)
                sb.AppendLine($"  • {a.Nome,-15} │ Idade: {a.Idade}  │  Nota: {a.Nota:F1}");
            sb.AppendLine($"\n  Encontrados: {maiores.Count} aluno(s)");
        }

        ExibirResultado(sb.ToString());
    }

    // ── CONSULTA LINQ 4: Todos os alunos com situação ──────────────────
    private void btnTodos_Click(object sender, EventArgs e)
    {
        var todos = _alunos.OrderBy(a => a.Nome).ToList();

        var sb = new System.Text.StringBuilder();
        sb.AppendLine("══════════════════════════════════════");
        sb.AppendLine("  CONSULTA LINQ — Todos os Alunos (A→Z)");
        sb.AppendLine("══════════════════════════════════════");

        if (!todos.Any())
            sb.AppendLine("  Nenhum aluno cadastrado.");
        else
            foreach (var a in todos)
            {
                string situacao = a.Nota > 7 ? "✔ Aprovado" : a.Nota >= 5 ? "~ Recuperação" : "✘ Reprovado";
                sb.AppendLine($"  {a.Nome,-15} │ Nota: {a.Nota:F1}  │  {situacao}");
            }

        ExibirResultado(sb.ToString());
    }

    // ── BOTÃO: Limpar Resultados ────────────────────────────────────────
    private void btnLimparResultados_Click(object sender, EventArgs e)
    {
        rtResultados.Clear();
        MostrarStatus("Resultados limpos.", Color.Gray);
    }

    // ── BOTÃO: Limpar Campos ────────────────────────────────────────────
    private void btnLimpar_Click(object sender, EventArgs e)
    {
        LimparCamposCadastro();
        MostrarStatus("Campos limpos.", Color.Gray);
        txNome.Focus();
    }

    // ── Helpers ─────────────────────────────────────────────────────────
    private void LimparCamposCadastro()
    {
        txNome.Clear();
        txIdade.Clear();
        txNota.Clear();
    }

    private void ExibirResultado(string texto)
    {
        rtResultados.Clear();
        rtResultados.AppendText(texto);
    }

    private void MostrarStatus(string mensagem, Color cor)
    {
        lblStatus.ForeColor = cor;
        lblStatus.Text = mensagem;
    }

    // ── Tecla Enter nos campos de texto ─────────────────────────────────
    private void txNome_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter) { txIdade.Focus(); e.SuppressKeyPress = true; }
    }

    private void txIdade_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter) { txNota.Focus(); e.SuppressKeyPress = true; }
    }

    private void txNota_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter) { btnAdicionar_Click(sender, e); e.SuppressKeyPress = true; }
    }

    private void FormPrincipal_Load(object sender, EventArgs e)
    {

    }
}

