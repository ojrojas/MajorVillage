import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SettingsRoutingModule } from './settings-routing.module';
import { SettingsComponent } from './container/settings.component';
import { SharedModule } from '../shared/shared.module';
import { SettingsResources } from './container/settings.resources';


@NgModule({
  declarations: [
    SettingsComponent
  ],
  imports: [
    CommonModule,
    SettingsRoutingModule,
    SharedModule
  ],
  providers:[SettingsResources]
})
export class SettingsModule { }
