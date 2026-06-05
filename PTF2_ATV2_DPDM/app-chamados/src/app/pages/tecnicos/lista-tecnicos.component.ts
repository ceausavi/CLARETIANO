import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IonicModule, AlertController, ToastController } from '@ionic/angular';
import { RouterModule } from '@angular/router';
import { DataService } from '../../services/data.service';
import { Tecnico } from '../../models/tecnico.model';

/**
 * Tela de Lista de Técnicos
 * Exibe todos os técnicos cadastrados no array do service.
 * Permite excluir técnicos com confirmação via alert.
 * Lista recarrega toda vez que a tela é acessada (ionViewWillEnter).
 */
@Component({
  selector: 'app-lista-tecnicos',
  templateUrl: './lista-tecnicos.component.html',
  styleUrls: ['./lista-tecnicos.component.scss'],
  standalone: true,
  imports: [IonicModule, CommonModule, RouterModule]
})
export class ListaTecnicosComponent {
  // Array local que reflete o array do service
  tecnicos: Tecnico[] = [];

  constructor(
    private dataService: DataService,
    private alertController: AlertController,
    private toastController: ToastController
  ) {}

  /**
   * Recarrega a lista toda vez que a tela é exibida.
   * Garante que alterações feitas em outras telas sejam refletidas.
   */
  ionViewWillEnter() {
    this.carregarTecnicos();
  }

  /**
   * Busca os técnicos atuais do service e atualiza a lista local.
   */
  carregarTecnicos() {
    // Cria uma cópia do array para forçar detecção de mudanças no Angular
    this.tecnicos = [...this.dataService.listarTecnicos()];
  }

  /**
   * Exibe alerta de confirmação antes de excluir o técnico.
   * @param id ID do técnico a ser excluído
   * @param nome Nome do técnico para exibir no alerta
   */
  async confirmarExclusao(id: number, nome: string) {
    const alert = await this.alertController.create({
      header: 'Confirmar Exclusão',
      message: `Tem certeza que deseja excluir <strong>${nome}</strong>?`,
      buttons: [
        {
          text: 'Cancelar',
          role: 'cancel'
        },
        {
          text: 'Excluir',
          role: 'destructive',
          handler: async () => {
            // Remove o técnico do array global via service
            this.dataService.excluirTecnico(id);
            // Recarrega a lista local após exclusão
            this.carregarTecnicos();

            const toast = await this.toastController.create({
              message: 'Técnico excluído.',
              duration: 2000,
              color: 'medium',
              position: 'top'
            });
            await toast.present();
          }
        }
      ]
    });

    await alert.present();
  }

  /**
   * Retorna a cor do badge de situação do técnico.
   * @param situacao 'Ativo' | 'Inativo'
   */
  getCorSituacao(situacao: string): string {
    return situacao === 'Ativo' ? 'success' : 'medium';
  }

  /**
   * Retorna a inicial do nome para o avatar.
   * @param nome Nome do técnico
   */
  getInicial(nome: string): string {
    return nome ? nome.charAt(0).toUpperCase() : '?';
  }
}
