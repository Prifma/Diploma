
import { Component,Input } from '@angular/core';
import { HeroModel } from 'src/models/HeroModel';
import { TableBuilderService } from 'src/servisec/tables';

@Component({
  selector: 'app-dota-side',
  templateUrl: './dota-side.component.html',
  
})
export class DotaSideComponent {

    @Input() set heroes(value:HeroModel[]){
      this._heroes = value;
      if(this._heroes.length>1){
        this.setTable()
      }
      
    }
    _heroes: HeroModel[] = [];
    htmlTable:string = "";

    setTable(){
      console.log(this._heroes);
      this.htmlTable = this.table.matchSideTable(this._heroes)
    }
    constructor(private table:TableBuilderService){}
}