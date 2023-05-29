
import { Component,Input } from '@angular/core';
import { MatchModel } from 'src/models/MatchModel';
import { ServerService } from 'src/servisec/server';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
})
export class ProfileComponent {
  @Input()
  model:number = 0;
  json:any
    change(x:number){
      switch(x){
        case 1:{
          this.server.getPlayer(this.model).subscribe({next:(data:any)=>this.json=data});
          break
        }
        case 2:{
          this.server.getRecentMatches(this.model).subscribe({next:(data:any)=>this.json=data});
          break
        }
        case 3:{
          this.server.getTotals(this.model).subscribe({next:(data:any)=>this.json=data});
          break
        }
      }
    }
    constructor(private server:ServerService){
      
    }

}