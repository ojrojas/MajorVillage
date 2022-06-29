import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { ConfigureButton, HeaderModel } from "src/app/shared/models/header/headermodel";


@Injectable()
export class SettingsResources {

    constructor(private router:Router) {}

    getHeaderSettings = (): HeaderModel => {
        return {
            titlePage: 'Settings',
            subTitle: 'Settings Application',
            buttons: []
        }
    }

    getButtons = (): Array<ConfigureButton> => {
        return [
            {
                description: 'Students',
                type: 'button',
                action: () => { this.router.navigate(['/students']) }
            },
            {
                description: 'Teachers',
                type: 'button',
                action: () => { this.router.navigate(['/teachers']) }
            }
        ];
    }
}


