import { Component,Output,EventEmitter } from '@angular/core';
import { ServerService } from 'src/servisec/server';
import { NgForm} from '@angular/forms';
import { MatchModel } from 'src/models/MatchModel';

@Component({
  selector: 'app-option-panel',
  templateUrl: './option-panel.component.html'
})
export class OptionPanelComponent {
  constructor(private server:ServerService){}
  matchId:number=0;
  getMatch(form: NgForm){
    this.server.getMatch(form.value.match).subscribe({next:(data:any) => {
      let match:MatchModel = data;  
      console.log(match);
      this.change(1,match);
    }})
  }

  getPlayer(form: NgForm){
    this.change(2,form.value.player)
    
  }

  @Output() onChanged = new EventEmitter<any>();
  change(a:number,m:any) {
    this.onChanged.emit({a, m});
  }
}
