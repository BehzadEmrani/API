import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { HideEyeDirective } from './shared/directives/hide-eye.directive';
import { MaterialModule } from './shared/modules/material/material.module';

import { SharedModule } from './shared/shared.module';
import { PageLayoutComponent } from 'src/layouts/page-layout/page-layout.component';
import { LoginLayoutComponent } from 'src/layouts/login-layout/login-layout.component';

@NgModule({
  declarations: [
    AppComponent,
    PageLayoutComponent,
    LoginLayoutComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    SharedModule.forRoot(),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
