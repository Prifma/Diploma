import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OptionPanelComponent } from './option-panel/option-panel.component';
import { FormsModule } from '@angular/forms';
import { ServerService } from 'src/servisec/server';
import { DotaSideComponent } from './dota-side/dota-side.component';
import { StatisticRootComponent } from './statistic-root/statistic-root.component';
import { ProfileComponent } from './profile/profile.component';
import { ProfileInfoComponent } from './profile-info/profile-info.component';
import { ProfileRecentComponent } from './profile-recent/profile-recent.component';
import { ProfileTotalsComponent } from './profile-totals/profile-totals.component';
import { ResultComponent } from './result/result.component';
import { DotaMatchComponent } from './dota-match/dota-match.component';
import { TableBuilderService } from 'src/servisec/tables';
import { LoadComponent } from 'src/app/compontnts/load/load.component';



@NgModule({
  declarations: [OptionPanelComponent,
                DotaMatchComponent,
                DotaSideComponent, 
                StatisticRootComponent, 
                ProfileComponent,
                ProfileInfoComponent,
                ProfileRecentComponent,
                ProfileTotalsComponent,
                ResultComponent,
                LoadComponent],
  imports: [
    CommonModule, FormsModule
  ],
  exports:[StatisticRootComponent ],
  providers:[ServerService,TableBuilderService]
})
export class DotaStatisticModule { }
