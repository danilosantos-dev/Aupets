import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RequestLogin } from 'src/app/interfaces/RequestLogin.model';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private url = 'https://localhost:7098/api/usuario/login'

  constructor(private http: HttpClient) { }

  public Login(requestLogin: RequestLogin):Observable<RequestLogin> {
    return  this.http.post<RequestLogin>(this.url, requestLogin);
  }

  public LogOut(){}

}
