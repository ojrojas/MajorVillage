import { Component } from "@angular/core";
import { ILogin } from "../core/models/ILogin";
import { LoginService } from "../core/services/login.service";

@Component({
    selector: 'app-login',
    templateUrl: 'login.component.html',
    styleUrls: ['login.component.scss']
})
export class LoginComponent {

    constructor(private loginService: LoginService) {

    }
    Login(login:ILogin):void{
        this.loginService.Login(login);
    }

}