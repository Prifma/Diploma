
import { Component,Input } from '@angular/core';
import { ProfileModel } from 'src/models/ProfileModel';

@Component({
  selector: 'app-profile-info',
  templateUrl: './profile-info.component.html',
})
export class ProfileInfoComponent {
    @Input() set profile(value:ProfileModel){
      this._profile = value;
    }
    _profile:ProfileModel = {};

}