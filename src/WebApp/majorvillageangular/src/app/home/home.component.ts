import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { ConfigureButton, HeaderModel } from "../shared/models/header/headermodel";

@Component({
    selector: 'app-home',
    templateUrl: 'home.component.html',
    styleUrls: ['home.component.scss']
})
export class HomeComponent {
    headerHome:HeaderModel;
    constructor(private route: Router) {
        this.headerHome = {
            titlePage:'Home', 
            subTitle:'HomeComponent', 
            buttons:[
                {
                    action: ()=> { alert("hi i'm button #1")},
                    description:'SEND 1',
                    type:'button'
                } ,
                {
                    action: ()=> { alert("hi i'm button #2")},
                    description:'SEND 2',
                    type:'button'
                } 
            ]
        };
    }
}