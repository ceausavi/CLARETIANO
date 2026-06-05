import { Component } from '@angular/core';

@Component({
  selector: 'app-pagar',
  templateUrl: './pagar.page.html',
  styleUrls: ['./pagar.page.scss'],
  standalone: false,
})
export class PagarPage {

  pagamento = {
    fornecedor: '',
    vencimento: '',
    formaPagamento: '',
    valor: null
  };

  listaPagamentos: any[] = [];

  salvar() {
    if (!this.pagamento.fornecedor.trim() ||
        !this.pagamento.vencimento ||
        !this.pagamento.formaPagamento ||
        !this.pagamento.valor) {
      alert('Preencha todos os campos!');
      return;
    }

    this.listaPagamentos.unshift({ ...this.pagamento });

    this.pagamento = {
      fornecedor: '',
      vencimento: '',
      formaPagamento: '',
      valor: null
    };
  }

  limpar() {
    this.listaPagamentos = [];
  }

  excluir(index: number) {
    this.listaPagamentos.splice(index, 1);
  }
}
