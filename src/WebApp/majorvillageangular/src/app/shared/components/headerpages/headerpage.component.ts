import { Component, Input } from "@angular/core";
import { HeaderModel } from "../../models/header/headermodel";

@Component({
    selector: 'app-header-page',
    templateUrl: 'headerpage.component.html',
    styleUrls: ['headerpage.component.scss']
})
export class HeaderPageComponent {
    @Input() headerModel: HeaderModel | undefined;
    constructor() { }
}