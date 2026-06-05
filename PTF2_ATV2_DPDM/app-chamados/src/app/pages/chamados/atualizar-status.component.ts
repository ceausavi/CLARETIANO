import { Component, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IonicModule, ToastController, NavController } from '@ionic/angular';
import { FormsModule, NgForm } from '@angular/forms';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { DataService } from '../../services/data.service';
import { Chamado } from '../../models/chamado.model';

/**
 * Tela de Atualização de Status
 * Permite alterar o status do chamado e registrar uma observação do atendimento.
 * O campo status é obrigatório; observação é opcional.
 */
@Component({
  selector: 'app-atualizar-status',
  templateUrl: './atualizar-status.component.html',
  styleUrls: ['./atualizar-status.component.scss'],
  standalone: true,
  imports: [IonicModule, CommonModule, FormsModule, RouterModule]
})
export class AtualizarStatusComponent {
  // Chamado atual carregado pelo ID da rota
  chamado: Chamado | undefined;

  // Campos do formulário
  novoStatus: string = '';
  observacao: string = '';

  // Referência ao formulário para controle de validação
  @ViewChild('formAtualizar') formAtualizar!: NgForm;

  constructor(
    private dataService: DataService,
    private route: ActivatedRoute,
    private toastController: ToastController,
    private navCtrl: NavController
  ) {}

  /**
   * Carrega o chamado pelo ID na rota toda vez que a tela é exibida.
   * Preenche os campos com os valores atuais do chamado.
   */
  ionViewWillEnter() {
    const idParam = this.route.snapshot.paramMap.get('id');
    if (idParam) {
      const id = parseInt(idParam, 10);
      this.chamado = this.dataService.obterChamado(id);

      if (this.chamado) {
        // Pré-preenche os campos com os valores atuais do chamado
        this.novoStatus = this.chamado.status;
        this.observacao = this.chamado.observacao || '';
      }
    }
  }

  /**
   * Salva a atualização de status e observação no array via service.
   * Valida se o campo status está preenchido.
   * Após salvar, retorna para a tela de detalhes do chamado.
   */
  async salvar() {
    // Marca campos como tocados para exibir validação visual
    if (this.formAtualizar) {
      Object.keys(this.formAtualizar.controls).forEach(key => {
        this.formAtualizar.controls[key].markAsTouched();
      });
    }

    if (this.chamado && this.novoStatus) {
      // Atualiza status e observação no array global via service
      this.dataService.atualizarStatus(
        this.chamado.id,
        this.novoStatus as Chamado['status'],
        this.observacao
      );

      const toast = await this.toastController.create({
        message: '✅ Status atualizado com sucesso!',
        duration: 2500,
        color: 'success',
        position: 'top'
      });
      await toast.present();

      // Retorna para os detalhes do chamado atualizado
      this.navCtrl.navigateBack(`/chamados/detalhes/${this.chamado.id}`);
    }
  }
}
