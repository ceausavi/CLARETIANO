import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IonicModule, NavController } from '@ionic/angular';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss'],
  standalone: true,
  imports: [IonicModule, CommonModule]
})
export class MenuComponent {

  constructor(private navCtrl: NavController) {}

  navegar(rota: string) {
    this.navCtrl.navigateForward(rota);
  }

  sair() {
    this.navCtrl.navigateRoot('/login');
  }
}
