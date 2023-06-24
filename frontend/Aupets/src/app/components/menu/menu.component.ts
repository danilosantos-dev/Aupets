import { Component } from '@angular/core';
import { AuthService } from 'src/app/shared/services/auth.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent {
  isCollapsed: boolean = false;

  constructor (public authService: AuthService) {}

  // //scrool da pagina
  // scrollTo(element: any): void {
  //   (document.getElementById(element) as HTMLElement)
  //   .scrollIntoView({behavior: "smooth", block: "start", inline: "nearest"});
  // }

}
