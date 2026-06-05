-- ============================================
-- Script de criação do banco de dados e tabela
-- para o projeto banco_repository1
-- ============================================

-- Criar o banco de dados
CREATE DATABASE IF NOT EXISTS banco_clientes;

-- Usar o banco de dados
USE banco_clientes;

-- Criar a tabela Clientes
CREATE TABLE IF NOT EXISTS Clientes (
    IdClientes INT PRIMARY KEY NOT NULL,
    Nome VARCHAR(100) NOT NULL,
    Endereco VARCHAR(200) NOT NULL,
    Telefone VARCHAR(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Criar índices para melhorar performance
CREATE INDEX idx_nome ON Clientes(Nome);

-- Inserir dados de exemplo (opcional)
INSERT INTO Clientes (IdClientes, Nome, Endereco, Telefone) VALUES
(1, 'João Silva', 'Rua A, 123', '(11) 98765-4321'),
(2, 'Maria Santos', 'Rua B, 456', '(11) 99876-5432'),
(3, 'Pedro Oliveira', 'Rua C, 789', '(11) 97654-3210');

-- Verificar os dados inseridos
SELECT * FROM Clientes;
