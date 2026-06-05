import { Component, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IonicModule, ToastController, NavController } from '@ionic/angular';
import { FormsModule, NgForm } from '@angular/forms';
import { DataService } from '../../services/data.service';
import { Tecnico } from '../../models/tecnico.model';

/**
 * Tela de Cadastro de Técnico
 * Permite registrar um novo técnico para atendimento de chamados.
 * Validações obrigatórias: nome, especialidade e contato.
 */
@Component({
  selector: 'app-cadastro-tecnico',
  templateUrl: './cadastro-tecnico.component.html',
  styleUrls: ['./cadastro-tecnico.component.scss'],
  standalone: true,
  imports: [IonicModule, CommonModule, FormsModule]
})
export class CadastroTecnicoComponent {
  // Objeto parcial preenchido pelo formulário; situação padrão: Ativo
  tecnico: Partial<Tecnico> = {
    situacao: 'Ativo'
  };

  // Referência ao formulário para controle de validação
  @ViewChild('formTecnico') formTecnico!: NgForm;

  constructor(
    private dataService: DataService,
    private toastController: ToastController,
    private navCtrl: NavController
  ) {}

  /**
   * Salva o técnico no array do service.
   * Marca todos os campos como tocados para exibir erros de validação visual.
   */
  async salvar() {
    // Marca todos os campos como tocados para acionar validação visual
    if (this.formTecnico) {
      Object.keys(this.formTecnico.controls).forEach(key => {
        this.formTecnico.controls[key].markAsTouched();
      });
    }

    // Verifica os campos obrigatórios: nome, especialidade e contato
    if (
      this.tecnico.nome?.trim() &&
      this.tecnico.especialidade &&
      this.tecnico.contato?.trim()
    ) {
      // Adiciona o técnico ao array global via service
      this.dataService.adicionarTecnico(this.tecnico as Omit<Tecnico, 'id'>);

      const toast = await this.toastController.create({
        message: '✅ Técnico cadastrado com sucesso!',
        duration: 2500,
        color: 'success',
        position: 'top'
      });
      await toast.present();

      // Retorna para a lista de técnicos
      this.navCtrl.navigateBack('/tecnicos');
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
