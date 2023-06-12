import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import {Routes, RouterModule} from '@angular/router';

import { AppComponent } from './app.component';
import { HeaderComponent } from 'src/app/compontnts/header/header.component';
import {  HttpClientModule } from '@angular/common/http';
import { AuthModule } from 'src/auth/auth.module';
import { DotaStatisticModule } from 'src/dota-statistic/dota-statistic.module';
import { ComunityModule, ComunityRoutes } from 'src/comunity/comunity.module';
import { ModalService } from 'src/servisec/modal';
import { ModalComponent } from './compontnts/modal/modal.component';
import { ComunityComponent } from 'src/comunity/comunity-root/comunity-root.component';
import { StatisticRootComponent } from 'src/dota-statistic/statistic-root/statistic-root.component';


const appRoutes: Routes =[
  { path: 'comunity', component: ComunityComponent, children: ComunityRoutes},
  { path: 'statistic', component: StatisticRootComponent},
  { path: '**',  redirectTo: '/statistic' }
];

@NgModule({
  declarations: [
    AppComponent, HeaderComponent,ModalComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,AuthModule,DotaStatisticModule,ComunityModule,RouterModule.forRoot(appRoutes)
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
