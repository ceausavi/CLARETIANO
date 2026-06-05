// DatabaseHelper.cs — Acesso ao banco de dados MySQL
// Banco: escola | Tabela: alunos

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Passo1;

public static class DatabaseHelper
{
    private const string CONNECTION_STRING =
        "Server=localhost;" +
        "Database=escola;" +
        "Uid=root;" +
        "Pwd=;" +
        "CharSet=utf8;" +
        "SslMode=none;" +
        "AllowPublicKeyRetrieval=True;";

    // ── Testa a conexão com o banco ──────────────────────────────────────
    public static bool TestarConexao(out string mensagem)
    {
        try
        {
            using var conn = new MySqlConnection(CONNECTION_STRING);
            conn.Open();
            mensagem = "Conectado ao MySQL com sucesso!";
            return true;
        }
        catch (Exception ex)
        {
            mensagem = $"Erro de conexão: {ex.Message}";
            return false;
        }
    }

    // ── Carrega todos os alunos do banco ─────────────────────────────────
    public static List<Aluno> CarregarAlunos()
    {
        var lista = new List<Aluno>();

        using var conn = new MySqlConnection(CONNECTION_STRING);
        conn.Open();

        string sql = "SELECT id, nome, idade, nota FROM alunos ORDER BY nome";
        using var cmd = new MySqlCommand(sql, conn);
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            lista.Add(new Aluno
            {
                Id = reader.GetInt32("id"),
                Nome = reader.GetString("nome"),
                Idade = reader.GetInt32("idade"),
                Nota = reader.GetDouble("nota")
            });
        }

        return lista;
    }

    // ── Insere um novo aluno no banco ────────────────────────────────────
    public static void InserirAluno(Aluno aluno)
    {
        using var conn = new MySqlConnection(CONNECTION_STRING);
        conn.Open();

        string sql = "INSERT INTO alunos (nome, idade, nota) VALUES (@nome, @idade, @nota)";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@nome", aluno.Nome);
        cmd.Parameters.AddWithValue("@idade", aluno.Idade);
        cmd.Parameters.AddWithValue("@nota", aluno.Nota);
        cmd.ExecuteNonQuery();

        aluno.Id = (int)cmd.LastInsertedId;
    }

    // ── Remove um aluno pelo ID ──────────────────────────────────────────
    public static void RemoverAluno(int id)
    {
        using var conn = new MySqlConnection(CONNECTION_STRING);
        conn.Open();

        string sql = "DELETE FROM alunos WHERE id = @id";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }
}