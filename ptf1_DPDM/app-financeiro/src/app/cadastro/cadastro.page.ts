import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

interface Usuario{
  nome:string;
  endereco:string;
  tipo:string;
}

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.page.html',
  styleUrls: ['./cadastro.page.scss'],
  standalone: false,
})
export class CadastroPage implements OnInit {

    usuario= {
    nome: '',
    endereco: '',
    tipo: '',
  }

  usuariosCadastrados: Usuario[] = [];
  lista: any;
  tipo: any;

  listaCadastros: any[] = [];
  router: any;

 cadastrarUsuario() {

  if (!this.usuario.tipo || 
      !this.usuario.nome.trim() || 
      !this.usuario.endereco.trim()) {

    alert('Preencha todos os campos!');
    return;
  }

  this.listaCadastros.unshift({
    tipo: this.usuario.tipo,
    nome: this.usuario.nome,
    endereco: this.usuario.endereco
  });

  
  this.usuario = {
    nome: '',
    endereco: '',
    tipo: '',
  };
}


 limparFormulario() {
  this.listaCadastros = [];
}


excluir(index: number) {
 this.listaCadastros.splice(index, 1);
}


  constructor() { }
  

  ngOnInit() {
  }

}
