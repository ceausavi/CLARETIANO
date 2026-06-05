import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IonicModule, NavController } from '@ionic/angular';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { DataService } from '../../services/data.service';
import { Chamado } from '../../models/chamado.model';

@Component({
  selector: 'app-detalhes-chamado',
  templateUrl: './detalhes-chamado.component.html',
  styleUrls: ['./detalhes-chamado.component.scss'],
  standalone: true,
  imports: [IonicModule, CommonModule, RouterModule]
})
export class DetalhesChamadoComponent implements OnInit {
  chamado: Chamado | undefined;

  constructor(
    private dataService: DataService,
    private route: ActivatedRoute,
    private navCtrl: NavController
  ) {}

  ngOnInit() {
    // This will run once, but we use ionViewWillEnter to refresh when coming back
  }

  ionViewWillEnter() {
    const idParam = this.route.snapshot.paramMap.get('id');
    if (idParam) {
      const id = parseInt(idParam, 10);
      this.chamado = this.dataService.obterChamado(id);
    }
  }

  atualizarStatus() {
    if (this.chamado) {
      this.navCtrl.navigateForward(`/chamados/atualizar/${this.chamado.id}`);
    }
  }

  getCorPrioridade(prioridade: string): string {
    switch(prioridade) {
      case 'Baixa': return 'medium';
      case 'Média': return 'secondary';
      case 'Alta': return 'warning';
      case 'Urgente': return 'danger';
      default: return 'primary';
    }
  }

  getCorStatus(status: string): string {
    switch(status) {
      case 'Aberto': return 'primary';
      case 'Em atendimento': return 'warning';
      case 'Concluído': return 'success';
      case 'Cancelado': return 'danger';
      default: return 'medium';
    }
  }
}
