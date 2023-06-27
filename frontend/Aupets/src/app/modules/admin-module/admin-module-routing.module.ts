import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from 'src/app/components/admin/admin.component';
import { NotificacoesComponent } from 'src/app/components/notificacoes/notificacoes.component';
import { PerfilComponent } from 'src/app/components/perfil/perfil.component';

const routes: Routes = [

  { path: '', component: AdminComponent }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminModuleRoutingModule { }
