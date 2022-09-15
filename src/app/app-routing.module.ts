import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginLayoutComponent } from 'src/layouts/login-layout/login-layout.component';

const routes: Routes = [
  {
    component: LoginLayoutComponent,
    path: 'login',
    loadChildren: () =>
      import('../app/components/login/login.module').then((m) => m.LoginModule),
  },
  { path: '**', pathMatch: 'full', redirectTo: '/login' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
