import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private router: Router){}

  ngOnInit(): void {
  }

  goToNextPage() {
    this.router.navigate(['/prestador']).then(() => {
      window.scrollTo(0, 0); // Rola para o topo da nova página
    });
  }

}
