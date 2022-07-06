import { Injectable } from "@angular/core";
import { HeaderModel } from "src/app/shared/models/header/headermodel";

@Injectable()
export class StudentsResourceService {
    constructor() { }

    getHeaderStudetns = (): HeaderModel => {
        return {
            titlePage: 'List Students',
            subTitle: 'Students',
            buttons: [
                {
                    styles: `background-color: #grey;
                    border: none;
                    padding: 5px;
                    text-align: center;
                    text-decoration: none;
                    display: inline-block;
                    font-size: 10px;`,
                    description: 'Create Students',
                    action: (): void => { },
                    type: 'button'
                }
            ]
        }
    }
}