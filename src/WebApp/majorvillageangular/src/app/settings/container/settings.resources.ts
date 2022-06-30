import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { ConfigureButton, HeaderModel } from "src/app/shared/models/header/headermodel";

@Injectable()
export class SettingsResources {

    constructor(private router: Router) { }

    getHeaderSettings = (): HeaderModel => {
        return {
            titlePage: 'Settings',
            subTitle: 'Settings Application',
            buttons: []
        }
    }

    getButtons = (): Array<ConfigureButton> => {
        return [{
            description: 'Add Students',
            type: 'button',
            icon: 'add' , 
            action: () => { this.router.navigate(['/students']) }
        },
        {
            description: 'Add Teachers',
            type: 'button',
            icon:'add',
            action: () => { this.router.navigate(['/teachers']) }
        }];
    }
}