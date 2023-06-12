import { Component, Input } from '@angular/core';
import { Route, Router } from '@angular/router';
import { AccInfo } from 'src/models/AccInfo';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
  statistic:string = "#1C242D";
  statisticText:string = "white"
  statisticBlock:string = "#242F39";
  statisticBlock2:string = "#2E3740";
  statisticBlock3:string = "#0b221b";
  comunity:string = "#cbeaf2";
  comunityText:string = "#333"
  comunityBlock:string = "#FFBF69";
  comunityBlock2:string = "#2EC4B6";
  comunityBlock3:string = "#FF9F1C";
  constructor(private router:Router){
    
  }
  
  first:boolean = false;
  second:boolean = true;
  third:boolean = false;
  @Input()
  acc?:AccInfo
  onItemChange(value:any){
    switch(value.target.value){
      case "1" :
        this.OnComunity()
        this.router.navigate(['comunity']);
        this.first = true;
        this.second= false
        this.third= false
        break;
        case "2" :
          this.OnStatistic()
          this.router.navigate(['statistic']);
          this.first = false;
          this.second= true
          this.third= false
        break;
    }
  }

  OnComunity(){
    document.documentElement.style.setProperty(`--background`,this.comunity);
    document.documentElement.style.setProperty(`--text-color`,this.comunityText);
    document.documentElement.style.setProperty(`--block`,this.comunityBlock);
    document.documentElement.style.setProperty(`--block2`,this.comunityBlock2);
    document.documentElement.style.setProperty(`--block3`,this.comunityBlock3);
  }

  OnStatistic(){
    document.documentElement.style.setProperty(`--background`,this.statistic);
    document.documentElement.style.setProperty(`--text-color`,this.statisticText);
    document.documentElement.style.setProperty(`--block`,this.statisticBlock);
    document.documentElement.style.setProperty(`--block2`,this.statisticBlock2);
    document.documentElement.style.setProperty(`--block3`,this.statisticBlock3);
  }
}
