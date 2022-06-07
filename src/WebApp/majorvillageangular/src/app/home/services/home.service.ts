import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})

export class HomeService {
    constructor() { }

    getHomeHeader = () => {
        return {
            titlePage:'Home', 
            subTitle:'HomeComponent', 
            buttons:[
                {
                    styles:`background-color: #grey;
                    border: none;
                    padding: 5px;
                    text-align: center;
                    text-decoration: none;
                    display: inline-block;
                    font-size: 10px;`,
                    action: ()=> { alert("hi i'm button #1")},
                    description:'SEND 1',
                    type:'button'
                },
                {
                    styles:`background-color: #grey;
                    border: none;
                    padding: 5px;
                    text-align: center;
                    text-decoration: none;
                    display: inline-block;
                    font-size: 10px;`,
                    action: ()=> { alert("hi i'm button #2")},
                    description:'SEND 2',
                    type:'button'
                },
                {
                    styles:`background-color: #grey;
                    border: none;
                    padding: 5px;
                    text-align: center;
                    text-decoration: none;
                    display: inline-block;
                    font-size: 10px;`,
                    action: ()=> { alert("hi i'm button #2")},
                    description:'SEND 3',
                    type:'button'
                },
                {
                    styles:`background-color: #grey;
                    border: none;
                    padding: 5px;
                    text-align: center;
                    text-decoration: none;
                    display: inline-block;
                    font-size: 10px;`,
                    action: ()=> { alert("hi i'm button #2")},
                    description:'SEND 4',
                    type:'button'
                },
            ]
        };
    }
}