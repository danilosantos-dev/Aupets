import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(){}

  ngOnInit(): void {
  }

  //scrool da pagina
  scrollTo(element: any): void {
    (document.getElementById(element) as HTMLElement)
    .scrollIntoView({behavior: "smooth", block: "start", inline: "nearest"});
  }

}
