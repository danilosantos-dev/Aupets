import { Injectable } from '@angular/core';
import { Usuario } from 'src/app/interfaces/usuario.model';
import { EnvironmentUrlService } from './environment-url.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UsuarioRepositoryService {

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }

  public login(){}

  public logout(){}

  public getUsuarios = (route: string) => {
    return this.http.get<Usuario[]>(this.createCompleteRoute(route, this.envUrl.urlAddress))
  }

  public createUsuario = (route: string, usuario: Usuario) => {
    return this.http.post<Usuario>(this.createCompleteRoute(route, this.envUrl.urlAddress),
      usuario, this.generateHeaders());
  }

  public updateUsuario = (route: string, usuario: Usuario) => {
    return this.http.put(this.createCompleteRoute(route, this.envUrl.urlAddress),
    usuario, this.generateHeaders());
  }
  public deleteUsuario = (route: string) => {
    return this.http.delete(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }

  private generateHeaders = () => {
    return {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }
  }



}
