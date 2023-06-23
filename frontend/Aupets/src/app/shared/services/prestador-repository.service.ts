import { Injectable } from '@angular/core';

import { EnvironmentUrlService } from './environment-url.service';
import { Prestador } from 'src/app/interfaces/prestador.model';
import { PrestadorForCreation } from 'src/app/interfaces/prestadorForCreation.mode';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class PrestadorRepositoryService {
  constructor(
    private http: HttpClient,
    private envUrl: EnvironmentUrlService
  ) {}

  public getPrestadores = (route: string) => {
    return this.http.get<Prestador[]>(
      this.createCompleteRoute(route, this.envUrl.urlAddress)
    );
  };

  public getPrestadorById = (route: string) => {
    return this.http.get<Prestador>(
      this.createCompleteRoute(route, this.envUrl.urlAddress)
    );
  };

  public createPrestador = (route: string, formData: FormData) => {
    return this.http.post<FormData>(
      this.createCompleteRoute(route, this.envUrl.urlAddress),
      formData,
      this.generateHeaders()
    );
  };
  
  public updatePrestador = (route: string, prestador: Prestador) => {
    return this.http.put(
      this.createCompleteRoute(route, this.envUrl.urlAddress),
      prestador,
      this.generateHeaders()
    );
  };

  public deletePrestador = (route: string) => {
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
