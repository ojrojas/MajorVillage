import { Component, OnInit } from '@angular/core';
import { ConfigureButton, HeaderModel } from 'src/app/shared/models/header/headermodel';
import { SettingsResources } from './settings.resources';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.scss']
})
export class SettingsComponent implements OnInit {
  headerSettings: HeaderModel | undefined;
  buttonsScreen: Array<ConfigureButton>;
  constructor(private settingResources: SettingsResources) {
    this.headerSettings = this.settingResources.getHeaderSettings();
    this.buttonsScreen = this.settingResources.getButtons();
  }

  ngOnInit(): void {
  }
}
