import { Component, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
import { IonicModule, ToastController } from '@ionic/angular';
import { Router } from '@angular/router';

/**
 * Tela de Login
 * Valida usuário e senha antes de permitir acesso ao sistema.
 * Ambos os campos são obrigatórios para prosseguir.
 */
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  standalone: true,
  imports: [IonicModule, CommonModule, FormsModule]
})
export class LoginComponent {
  // Campos do formulário de login
  usuario = '';
  senha = '';

  // Referência ao formulário para controlar validação
  @ViewChild('formLogin') formLogin!: NgForm;

  constructor(
    private router: Router,
    private toastController: ToastController
  ) {}

  /**
   * Tenta realizar o login.
   * Verifica se os campos estão preenchidos e redireciona ao menu.
   * Caso contrário, exibe mensagem de erro e marca os campos como tocados.
   */
  async fazerLogin() {
    // Marca todos os campos como tocados para exibir mensagens de erro
    if (this.formLogin) {
      Object.keys(this.formLogin.controls).forEach(key => {
        this.formLogin.controls[key].markAsTouched();
      });
    }

    if (this.usuario.trim() && this.senha.trim()) {
      // Login bem-sucedido: redireciona para o menu principal
      this.router.navigate(['/menu']);
    } else {
      // Exibe toast de erro para o usuário
      const toast = await this.toastController.create({
        message: 'Preencha o usuário e a senha para continuar.',
        duration: 3000,
        color: 'danger',
        position: 'top',
        icon: 'warning-outline'
      });
      await toast.present();
    }
  }
}
