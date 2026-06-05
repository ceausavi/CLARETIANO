import { Component } from '@angular/core';

@Component({
  selector: 'app-receber',
  templateUrl: './receber.page.html',
  styleUrls: ['./receber.page.scss'],
  standalone: false,
})
export class ReceberPage {

  recebimento = {
    cliente: '',
    vencimento: '',
    pagamento: '',
    valor: null
  };

  listaRecebimentos: any[] = [];

 salvar() {
  if (!this.recebimento.cliente.trim() ||
      !this.recebimento.vencimento ||
      !this.recebimento.pagamento ||
      !this.recebimento.valor) {
    alert('Preencha todos os campos!');
    return;
  }

  this.listaRecebimentos.unshift({ ...this.recebimento });

  this.recebimento = {
    cliente: '',
    vencimento: '',
    pagamento: '',
    valor: null
  };
}

limpar() {
  this.listaRecebimentos = [];
}

  excluir(index: number) {
  this.listaRecebimentos.splice(index, 1);
}
}