import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Prestador } from 'src/app/interfaces/prestador.model';
import { PrestadorRepositoryService } from 'src/app/shared/services/prestador-repository.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  prestadores!: Prestador[];


  constructor(private router: Router, private prestadorService: PrestadorRepositoryService) { }

  ngOnInit(): void {
    this.getAllPrestadores();
  }

  private getAllPrestadores = () => {
    const apiAddress: string = 'api/prestador';
    this.prestadorService.getPrestadores(apiAddress)
      .subscribe({
        next: (prest: Prestador[]) => this.prestadores = prest,
      })
  }

  redirectToPrestPage(id: number){
      const prestUrl: string = `/prestador/${id}`
      window.scrollTo(0, 0);
      this.router.navigate([prestUrl]);
  }


}
