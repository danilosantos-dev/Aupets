import { Injectable } from '@angular/core';

import { EnvironmentUrlService } from './environment-url.service';
import { Usuario } from 'src/app/interfaces/Usuario.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UsuarioForCreation } from 'src/app/interfaces/UsuarioForCreation.model';


@Injectable({
  providedIn: 'root',
})
export class UsuarioRepositoryService {
  constructor(
    private http: HttpClient,
    private envUrl: EnvironmentUrlService
  ) {}

  // verificarExistenciaUsuario(email: string) {
  //   const url = 'https://localhost:7098/api/usuario'
  //   return this.http.get<any>(`${url} ${email}`);
  // }

  public getOwners = (route: string) => {
    return this.http.get<Usuario[]>(
      this.createCompleteRoute(route, this.envUrl.urlAddress)
    );
  };
  public createUsuario = (route: string, owner: UsuarioForCreation) => {
    return this.http.post<Usuario>(
      this.createCompleteRoute(route, this.envUrl.urlAddress),
      owner,
      this.generateHeaders()
    );
  };
  public updateUsuario = (route: string, usuario: Usuario) => {
    return this.http.put(
      this.createCompleteRoute(route, this.envUrl.urlAddress),
      usuario,
      this.generateHeaders()
    );
  };
  public deleteUsuario = (route: string) => {
    return this.http.delete(
      this.createCompleteRoute(route, this.envUrl.urlAddress)
    );
  };
  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  };
  private generateHeaders = () => {
    return {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    };
  };
}
