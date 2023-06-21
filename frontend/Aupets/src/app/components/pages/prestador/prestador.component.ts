import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Prestador } from 'src/app/interfaces/prestador.model';
import { PrestadorRepositoryService } from 'src/app/shared/services/prestador-repository.service';

@Component({
  selector: 'app-prestador',
  templateUrl: './prestador.component.html',
  styleUrls: ['./prestador.component.css']
})
export class PrestadorComponent {

  prestador!: Prestador;

  constructor(private prestadorService: PrestadorRepositoryService, private activatedRoute: ActivatedRoute){
  }

  ngOnInit(): void{
    this.getPrestador();
  }

  getPrestador(){
    const id = this.activatedRoute.snapshot.params['id'];
    const apiUrl: string = `api/prestador/${id}`;

    this.prestadorService.getPrestadorById(apiUrl).subscribe({
      next: (prest: Prestador) => this.prestador = prest
    })
  }

}
