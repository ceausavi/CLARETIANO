import { Injectable } from '@angular/core';
import { Chamado } from '../models/chamado.model';
import { Tecnico } from '../models/tecnico.model';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  // Arrays para armazenar os dados em memória (sem banco de dados)
  public chamados: Chamado[] = [
    {
      id: 1,
      solicitante: 'João Silva',
      setor: 'Financeiro',
      titulo: 'Computador não liga',
      descricao: 'O computador do setor financeiro não está ligando após queda de energia.',
      prioridade: 'Alta',
      dataAbertura: new Date().toISOString(),
      tecnico: 'Carlos Técnico',
      status: 'Aberto',
      observacao: ''
    },
    {
      id: 2,
      solicitante: 'Maria Oliveira',
      setor: 'RH',
      titulo: 'Problema no sistema de ponto',
      descricao: 'Não consigo acessar o sistema para bater o ponto hoje.',
      prioridade: 'Média',
      dataAbertura: new Date().toISOString(),
      tecnico: '',
      status: 'Aberto',
      observacao: ''
    }
  ];

  public tecnicos: Tecnico[] = [
    {
      id: 1,
      nome: 'Carlos Técnico',
      especialidade: 'Hardware',
      contato: 'carlos@email.com',
      situacao: 'Ativo'
    },
    {
      id: 2,
      nome: 'Ana Dev',
      especialidade: 'Sistema interno',
      contato: 'ana@email.com',
      situacao: 'Ativo'
    }
  ];

  constructor() { }

  // ====================== MÉTODOS DE CHAMADOS ======================

  listarChamados(): Chamado[] {
    return this.chamados;
  }

  obterChamado(id: number): Chamado | undefined {
    return this.chamados.find(c => c.id === id);
  }

  adicionarChamado(chamado: Omit<Chamado, 'id'>) {
    const novoId = this.chamados.length > 0 ? Math.max(...this.chamados.map(c => c.id)) + 1 : 1;
    const novoChamado: Chamado = { ...chamado, id: novoId };
    this.chamados.unshift(novoChamado); // Coloca no início da lista
  }

  excluirChamado(id: number) {
    this.chamados = this.chamados.filter(c => c.id !== id);
  }

  atualizarStatus(id: number, status: Chamado['status'], observacao: string) {
    const chamado = this.chamados.find(c => c.id === id);
    if (chamado) {
      chamado.status = status;
      chamado.observacao = observacao;
    }
  }

  // ====================== MÉTODOS DE TÉCNICOS ======================

  listarTecnicos(): Tecnico[] {
    return this.tecnicos;
  }

  adicionarTecnico(tecnico: Omit<Tecnico, 'id'>) {
    const novoId = this.tecnicos.length > 0 ? Math.max(...this.tecnicos.map(t => t.id)) + 1 : 1;
    const novoTecnico: Tecnico = { ...tecnico, id: novoId };
    this.tecnicos.push(novoTecnico);
  }

  excluirTecnico(id: number) {
    this.tecnicos = this.tecnicos.filter(t => t.id !== id);
  }

  // ====================== MÉTODOS PARA RESUMO ======================

  obterResumoChamados() {
    return {
      total: this.chamados.length,
      abertos: this.chamados.filter(c => c.status === 'Aberto').length,
      emAtendimento: this.chamados.filter(c => c.status === 'Em atendimento').length,
      concluidos: this.chamados.filter(c => c.status === 'Concluído').length,
      cancelados: this.chamados.filter(c => c.status === 'Cancelado').length,
      
      baixa: this.chamados.filter(c => c.prioridade === 'Baixa').length,
      media: this.chamados.filter(c => c.prioridade === 'Média').length,
      alta: this.chamados.filter(c => c.prioridade === 'Alta').length,
      urgente: this.chamados.filter(c => c.prioridade === 'Urgente').length
    };
  }

}
