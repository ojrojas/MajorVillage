import { Component } from "@angular/core";
import { Router } from "@angular/router";

@Component({
    selector:'app-home',
    template: '<h1>Home</h1>'
})
export class HomeComponent{
    constructor(private route: Router){
      
    }
}