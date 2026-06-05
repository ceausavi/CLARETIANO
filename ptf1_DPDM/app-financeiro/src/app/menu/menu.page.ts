import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.page.html',
  styleUrls: ['./menu.page.scss'],
  standalone: false,
})
export class MenuPage implements OnInit {

  constructor(private router: Router) { }

  cadUsuario() {
    this.router.navigate(['/cadastro']);
  }

  ctsReceber() {
    this.router.navigate(['/receber']);
  }

  ctsPagar() {
    this.router.navigate(['/pagar']);
  }

  ngOnInit() {
  }

}
