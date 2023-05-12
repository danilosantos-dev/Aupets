import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './components/admin/admin.component';
import { HomeComponent } from './components/home/home.component';
import { CadastroPrestadorComponent } from './components/pages/cadastro-prestador/cadastro-prestador.component';
import { CadastroUsuarioComponent } from './components/pages/cadastro-usuario/cadastro-usuario.component';
import { LoginComponent } from './components/pages/login/login.component';
import { PrestadorComponent } from './components/pages/prestador/prestador.component';


const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'cadastro-usuario', component: CadastroUsuarioComponent },
  { path: 'cadastro-prestador',component: CadastroPrestadorComponent },
  { path: 'admin', component: AdminComponent },
  { path: 'prestador', component: PrestadorComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' }

];

@NgModule({
  imports: [RouterModule.forRoot(routes, { anchorScrolling: 'enabled' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
