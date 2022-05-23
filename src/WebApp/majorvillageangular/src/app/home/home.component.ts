import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { HeaderModel } from "../shared/models/header/headermodel";

@Component({
    selector: 'app-home',
    templateUrl: 'home.component.html',
    styleUrls: ['home.component.scss']
})
export class HomeComponent {
    headerHome:HeaderModel;
    constructor(private route: Router) {
        this.headerHome = {} as HeaderModel;
    }
}