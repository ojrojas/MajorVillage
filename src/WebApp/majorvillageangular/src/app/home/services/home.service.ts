import { Injectable } from "@angular/core";
import { HeaderModel } from "src/app/shared/models/header/headermodel";

@Injectable({
    providedIn: 'root'
})

export class HomeService {
    constructor() { }

    getHomeHeader = (): HeaderModel => 
  {
    return {
        titlePage:"Home",
        subTitle: "Dashboard"
    }

  }
}