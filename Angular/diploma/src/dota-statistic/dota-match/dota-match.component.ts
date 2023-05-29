
import { Component,Input } from '@angular/core';
import { MatchModel } from 'src/models/MatchModel';

@Component({
  selector: 'app-dota-match',
  templateUrl: './dota-match.component.html',
})
export class DotaMatchComponent {
    @Input()
    match?:MatchModel
}