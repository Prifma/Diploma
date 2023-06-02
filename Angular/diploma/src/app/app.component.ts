import { Component } from '@angular/core';
import { HttpClient,HttpParams} from '@angular/common/http';
import { AccInfo } from 'src/models/AccInfo';
import { ServerService } from 'src/servisec/server';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  constructor(private server:ServerService){
    server.loadUser().subscribe({next:(data: any) => 
      {
        this.Acc.steamId = data.m;
        if(this.Acc.steamId){
          this.Acc.isAuth = true;
          server.getUser(this.Acc.steamId).subscribe({next:(data: any) => {this.Acc = data; this.Acc.isAuth = true; console.log(this.Acc)}})
        }
        else this.Acc.isAuth = false;
        console.log(this.Acc)
      }});
  }
  Acc:AccInfo = new AccInfo();
  
}
