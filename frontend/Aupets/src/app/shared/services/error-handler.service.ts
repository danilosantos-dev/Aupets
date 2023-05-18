import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ErrorHandlerService {

  /*Aqui acontece o tratamento de erros, 
  existem metodos que são responsaveis por capturar o status do erro
  e assim exibir a tela e a mensagem de erro*/

  constructor(private router: Router) { }

  public handleError = (error: HttpErrorResponse) => {
    if (error.status === 500) {
      this.handle500Error(error);
    }
    else if (error.status === 404) {
      this.handle404Error(error)
    }
  }

  private handle500Error = (error: HttpErrorResponse) => {
    console.log(error);
    this.router.navigate(['/500']);
  }

  private handle404Error = (error: HttpErrorResponse) => {
    console.log(error);
    this.router.navigate(['/404']);
  }

}



