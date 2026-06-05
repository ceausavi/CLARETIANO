import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'login',
    loadComponent: () => import('./pages/login/login.component').then(m => m.LoginComponent)
  },
  {
    path: 'menu',
    loadComponent: () => import('./pages/menu/menu.component').then(m => m.MenuComponent)
  },
  {
    path: 'tecnicos',
    loadComponent: () => import('./pages/tecnicos/lista-tecnicos.component').then(m => m.ListaTecnicosComponent)
  },
  {
    path: 'tecnicos/novo',
    loadComponent: () => import('./pages/tecnicos/cadastro-tecnico.component').then(m => m.CadastroTecnicoComponent)
  },
  {
    path: 'chamados',
    loadComponent: () => import('./pages/chamados/lista-chamados.component').then(m => m.ListaChamadosComponent)
  },
  {
    path: 'chamados/novo',
    loadComponent: () => import('./pages/chamados/cadastro-chamado.component').then(m => m.CadastroChamadoComponent)
  },
  {
    path: 'chamados/detalhes/:id',
    loadComponent: () => import('./pages/chamados/detalhes-chamado.component').then(m => m.DetalhesChamadoComponent)
  },
  {
    path: 'chamados/atualizar/:id',
    loadComponent: () => import('./pages/chamados/atualizar-status.component').then(m => m.AtualizarStatusComponent)
  },
  {
    path: 'resumo',
    loadComponent: () => import('./pages/resumo/resumo.component').then(m => m.ResumoComponent)
  },
  {
    path: 'sobre',
    loadComponent: () => import('./pages/sobre/sobre.component').then(m => m.SobreComponent)
  },
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
