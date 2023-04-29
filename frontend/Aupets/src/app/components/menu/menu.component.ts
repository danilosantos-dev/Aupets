import { Component } from '@angular/core';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent {
  isCollapsed: boolean = false;

  //scrool da pagina
  scrollTo(element: any): void {
    (document.getElementById(element) as HTMLElement)
    .scrollIntoView({behavior: "smooth", block: "start", inline: "nearest"});
  }

}
