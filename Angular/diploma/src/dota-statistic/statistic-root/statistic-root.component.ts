
import { Component,Input } from '@angular/core';
import { MatchModel } from 'src/models/MatchModel';

@Component({
  selector: 'app-statistic-root',
  templateUrl: './statistic-root.component.html',
})
export class StatisticRootComponent {
  action?:number;
  model?:any;
  onChanged(e:any){
    this.action = e.a;
    this.model = e.m;
  }
}