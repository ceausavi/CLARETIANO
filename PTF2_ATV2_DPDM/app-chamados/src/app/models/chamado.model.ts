export interface Chamado {
  id: number;
  solicitante: string;
  setor: string;
  titulo: string;
  descricao: string;
  prioridade: 'Baixa' | 'Média' | 'Alta' | 'Urgente';
  dataAbertura: string;
  tecnico: string; // Nome do técnico responsável
  status: 'Aberto' | 'Em atendimento' | 'Concluído' | 'Cancelado';
  observacao: string;
}
