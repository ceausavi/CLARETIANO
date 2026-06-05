import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IonicModule } from '@ionic/angular';
import { DataService } from '../../services/data.service';

@Component({
  selector: 'app-resumo',
  templateUrl: './resumo.component.html',
  styleUrls: ['./resumo.component.scss'],
  standalone: true,
  imports: [IonicModule, CommonModule]
})
export class ResumoComponent {
  resumo: any = {};

  constructor(private dataService: DataService) {}

  ionViewWillEnter() {
    this.resumo = this.dataService.obterResumoChamados();
  }
}
