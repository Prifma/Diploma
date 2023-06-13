
import { Component,Input } from '@angular/core';
import { HeroModel } from 'src/models/HeroModel';
import { MatchModel } from 'src/models/MatchModel';
import { ServerService } from 'src/servisec/server';

@Component({
  selector: 'app-dota-match',
  templateUrl: './dota-match.component.html',
  styleUrls:[`./dota-match.component.css`]
})
export class DotaMatchComponent {
    @Input() set matchID(value:number){
      this._id = value;
      this.matchRecive = false;
      this.getMatch()
    }

    matchExist:boolean = false;
    matchRecive:boolean = false;

    _id:number = 0;

    model:MatchModel = new MatchModel;
    radiantHero:HeroModel[] = [];
    direHero:HeroModel[] = [];

    getMatch(){
      this.server.getMatch(this._id).subscribe({next:(data:any) => {
        this.matchRecive = true;
        this.model=data;
        console.log(this.model)
        if(this.model.matchId === null){
          this.matchExist = false;
          return;
        }
        this.matchExist = true;
        let k:HeroModel[] =[];
        for (let index = 0; index < 5; index++) {
          const element = this.model.heroes[index];
          k.push(element);
        }
        this.radiantHero = k;
        let j:HeroModel[] =[];
        for (let index = 5; index < 10; index++) {
          const element = this.model.heroes[index];
          j.push(element);
        }
        this.direHero=j
        
      }});
    }
    constructor(private server:ServerService){}
}