import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { HeaderComponent } from 'src/app/compontnts/header/header.component';
import {  HttpClientModule } from '@angular/common/http';
import { AuthModule } from 'src/auth/auth.module';
import { DotaStatisticModule } from 'src/dota-statistic/dota-statistic.module';

@NgModule({
  declarations: [
    AppComponent, HeaderComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,AuthModule,DotaStatisticModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
