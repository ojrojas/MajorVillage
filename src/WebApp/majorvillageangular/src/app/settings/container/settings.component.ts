import { Component, OnInit } from '@angular/core';
import { HeaderModel } from 'src/app/shared/models/header/headermodel';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.scss']
})
export class SettingsComponent implements OnInit {
  headerSettings: HeaderModel | undefined;
  constructor() { }

  ngOnInit(): void {
  }
}
