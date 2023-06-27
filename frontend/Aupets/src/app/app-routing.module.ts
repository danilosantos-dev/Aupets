import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { NotificacoesComponent } from './components/notificacoes/notificacoes.component';
import { CadastroPrestadorComponent } from './components/pages/cadastro-prestador/cadastro-prestador.component';
import { CadastroUsuarioComponent } from './components/pages/cadastro-usuario/cadastro-usuario.component';
import { LoginComponent } from './components/pages/login/login.component';
import { PrestadorComponent } from './components/pages/prestador/prestador.component';
import { PerfilComponent } from './components/perfil/perfil.component';
import { InternalServerComponent } from './error-pages/internal-server/internal-server.component';
import { NotFoundComponent } from './error-pages/not-found/not-found.component';
import { AuthGuardService } from './shared/services/auth-guard.service';


const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'cadastro', component: CadastroUsuarioComponent },
  { path: 'cadastro-prestador', component: CadastroPrestadorComponent },
  { path: 'admin', loadChildren: () => import('../app/modules/admin-module/admin-module.module').then(m => m.AdminModuleModule), canActivate: [AuthGuardService] },
  { path: 'admin/perfil/:id', component: PerfilComponent},
  { path: 'admin/notificacoes', component: NotificacoesComponent },
  { path: 'prestador/:id', component: PrestadorComponent },
  { path: '404', component: NotFoundComponent },
  { path: '500', component: InternalServerComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: '**', redirectTo: '/404', pathMatch: 'full' }

];

@NgModule({
  imports: [RouterModule.forRoot(routes, { anchorScrolling: 'enabled' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
