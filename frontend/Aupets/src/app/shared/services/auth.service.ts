import { Injectable } from '@angular/core';

import { EnvironmentUrlService } from './environment-url.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Usuario } from 'src/app/interfaces/usuario.model';
import { RequestLogin } from 'src/app/interfaces/RequestLogin.model';

@Injectable({
  providedIn: 'root',
})
export class AuthService {

  private isAuthenticated: boolean = false;
  private loggedInUserId!: string;

  constructor(
    private http: HttpClient,
    private envUrl: EnvironmentUrlService
  ) {}

  public Login(route: string, requestLogin: RequestLogin) {
    this.isAuthenticated = true;
    return this.http.post<Usuario>(
      this.createCompleteRoute(route, this.envUrl.urlAddress),
      requestLogin,
      this.generateHeaders()
    );
  }

  public LogOut() {
    this.isAuthenticated = false;
  }

  public isLogged(){
    return this.isAuthenticated;
  }

  public setLoggedInUserId(userId :string): void{
    this.loggedInUserId = userId;
  }

  public getLoggedInUserId(): string{
    return this.loggedInUserId;
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
