import { Component } from '@angular/core';
import { HttpClient,HttpParams} from '@angular/common/http';
import { AccInfo } from 'src/models/AccInfo';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  constructor(private http: HttpClient){
    http.get("/auth/loaduser").subscribe({next:(data: any) => 
      {
        this.Acc.steamId = data.m;
        if(this.Acc.steamId){
          this.Acc.isAuth = true;
        }
        else this.Acc.isAuth = false;
        console.log(this.Acc)
      }});
  }
  Acc:AccInfo = new AccInfo();
  
}
