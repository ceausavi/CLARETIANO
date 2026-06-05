import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IonicModule, NavController } from '@ionic/angular';
import { RouterModule } from '@angular/router';
import { DataService } from '../../services/data.service';
import { Chamado } from '../../models/chamado.model';

/**
 * Tela de Lista de Chamados
 * Exibe todos os chamados registrados no array do service.
 * Clicando em um chamado, navega para a tela de detalhes.
 * Lista recarrega ao entrar na tela (ionViewWillEnter).
 */
@Component({
  selector: 'app-lista-chamados',
  templateUrl: './lista-chamados.component.html',
  styleUrls: ['./lista-chamados.component.scss'],
  standalone: true,
  imports: [IonicModule, CommonModule, RouterModule]
})
export class ListaChamadosComponent {
  // Array local que espelha o array do service
  chamados: Chamado[] = [];

  constructor(
    private dataService: DataService,
    private navCtrl: NavController
  ) {}

  /**
   * Recarrega a lista a cada vez que a tela é exibida.
   * Necessário para refletir novos chamados ou atualizações de status.
   */
  ionViewWillEnter() {
    this.carregarChamados();
  }

  /**
   * Busca os chamados atuais do service e atualiza a lista local.
   */
  carregarChamados() {
    // Cria uma cópia do array para forçar detecção de mudanças
    this.chamados = [...this.dataService.listarChamados()];
  }

  /**
   * Navega para a tela de detalhes do chamado selecionado.
   * @param id ID do chamado
   */
  verDetalhes(id: number) {
    this.navCtrl.navigateForward(`/chamados/detalhes/${id}`);
  }

  /**
   * Retorna a cor Ionic baseada na prioridade do chamado.
   * @param prioridade 'Baixa' | 'Média' | 'Alta' | 'Urgente'
   */
  getCorPrioridade(prioridade: string): string {
    switch (prioridade) {
      case 'Baixa':    return 'medium';
      case 'Média':    return 'secondary';
      case 'Alta':     return 'warning';
      case 'Urgente':  return 'danger';
      default:         return 'primary';
    }
  }

  /**
   * Retorna a cor Ionic baseada no status do chamado.
   * @param status 'Aberto' | 'Em atendimento' | 'Concluído' | 'Cancelado'
   */
  getCorStatus(status: string): string {
    switch (status) {
      case 'Aberto':         return 'primary';
      case 'Em atendimento': return 'warning';
      case 'Concluído':      return 'success';
      case 'Cancelado':      return 'danger';
      default:               return 'medium';
    }
  }
}
