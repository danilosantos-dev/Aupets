import { Injectable } from '@angular/core';

import { EnvironmentUrlService } from './environment-url.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Usuario } from 'src/app/interfaces/usuario.model';
import { RequestLogin } from 'src/app/interfaces/RequestLogin.model';

@Injectable({
  providedIn: 'root',
})
export class AuthService {

  private loggedInUserId!: string;

  constructor(
    private http: HttpClient,
    private envUrl: EnvironmentUrlService
  ) {}

  public Login(route: string, requestLogin: RequestLogin) {
    return this.http.post<any>(
      this.createCompleteRoute(route, this.envUrl.urlAddress),
      requestLogin,
      this.generateHeaders()
    );
  }

  public LogOut() {
    localStorage.removeItem('userId');
  }

  public isLogged(){
    var uId = localStorage.getItem('userId');
    if (uId == null){
      return false
    } else return true
  }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  };

  private generateHeaders = () => {
    return {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    };
  };

}
