import { Component, OnInit, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IonicModule, ToastController, NavController } from '@ionic/angular';
import { FormsModule, NgForm } from '@angular/forms';
import { DataService } from '../../services/data.service';
import { Chamado } from '../../models/chamado.model';
import { Tecnico } from '../../models/tecnico.model';

/**
 * Tela de Cadastro de Chamado
 * Permite registrar um novo chamado técnico com todos os campos obrigatórios.
 * Validações: solicitante, título, descrição, prioridade e técnico são obrigatórios.
 */
@Component({
  selector: 'app-cadastro-chamado',
  templateUrl: './cadastro-chamado.component.html',
  styleUrls: ['./cadastro-chamado.component.scss'],
  standalone: true,
  imports: [IonicModule, CommonModule, FormsModule]
})
export class CadastroChamadoComponent implements OnInit {
  // Objeto parcial que será preenchido pelo formulário
  chamado: Partial<Chamado> = {
    prioridade: 'Média',   // Prioridade padrão
    status: 'Aberto'       // Status inicial sempre "Aberto"
  };

  // Lista de técnicos ativos disponíveis para seleção
  tecnicosDisponiveis: Tecnico[] = [];

  // Referência ao formulário para controle de validação
  @ViewChild('formChamado') formChamado!: NgForm;

  constructor(
    private dataService: DataService,
    private toastController: ToastController,
    private navCtrl: NavController
  ) {}

  ngOnInit() {
    // Carrega apenas técnicos com situação "Ativo"
    this.tecnicosDisponiveis = this.dataService.listarTecnicos()
      .filter(t => t.situacao === 'Ativo');
  }

  /**
   * Salva o chamado no array do service.
   * Marca todos os campos como tocados para exibir erros de validação.
   * Exige: solicitante, título, descrição, prioridade e técnico.
   */
  async salvar() {
    // Marca todos os campos como tocados para disparar validação visual
    if (this.formChamado) {
      Object.keys(this.formChamado.controls).forEach(key => {
        this.formChamado.controls[key].markAsTouched();
      });
    }

    // Verifica se todos os campos obrigatórios estão preenchidos
    if (
      this.chamado.solicitante?.trim() &&
      this.chamado.titulo?.trim() &&
      this.chamado.descricao?.trim() &&
      this.chamado.prioridade &&
      this.chamado.tecnico
    ) {
      // Monta o objeto do novo chamado
      const novoChamado: Omit<Chamado, 'id'> = {
        solicitante: this.chamado.solicitante!,
        setor: this.chamado.setor || 'Não informado',
        titulo: this.chamado.titulo!,
        descricao: this.chamado.descricao!,
        prioridade: this.chamado.prioridade as Chamado['prioridade'],
        dataAbertura: new Date().toISOString(),
        tecnico: this.chamado.tecnico!,
        status: 'Aberto',
        observacao: ''
      };

      // Adiciona ao array global via service
      this.dataService.adicionarChamado(novoChamado);

      const toast = await this.toastController.create({
        message: '✅ Chamado registrado com sucesso!',
        duration: 2500,
        color: 'success',
        position: 'top'
      });
      await toast.present();

      // Retorna para a lista de chamados
      this.navCtrl.navigateBack('/chamados');
    } else {
      // Exibe toast de erro se campos obrigatórios não estiverem preenchidos
      const toast = await this.toastController.create({
        message: 'Preencha todos os campos obrigatórios.',
        duration: 3000,
        color: 'danger',
        position: 'top',
        icon: 'warning-outline'
      });
      await toast.present();
    }
  }
}
