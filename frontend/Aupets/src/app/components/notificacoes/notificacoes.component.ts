import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-notificacoes',
  templateUrl: './notificacoes.component.html',
  styleUrls: ['./notificacoes.component.css']
})
export class NotificacoesComponent {
  usuarioId: any = localStorage.getItem('userId');

  constructor(){}

}
