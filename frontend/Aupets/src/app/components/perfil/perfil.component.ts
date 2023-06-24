import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Prestador } from 'src/app/interfaces/prestador.model';
import { PrestadorRepositoryService } from 'src/app/shared/services/prestador-repository.service';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.css']
})
export class PerfilComponent {
  prestador!: Prestador;

  constructor(private prestadorService: PrestadorRepositoryService, private activatedRoute: ActivatedRoute){}

  ngOnInit(): void{
  }

  getPrestador(){
    const id = this.activatedRoute.snapshot.params['id'];
    const apiUrl: string = `api/usuario/${id}`;

    this.prestadorService.getPrestadorById(apiUrl).subscribe({
      next: (prest: Prestador) => {
        this.prestador = prest
      }, 
      error: (err) => {
        console.log(err.error);
      }
    })

  }

}
