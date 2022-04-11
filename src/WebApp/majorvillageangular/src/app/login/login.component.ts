import { Component, Injector } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ILogin } from "../core/models/ilogin";
import { LoginService } from "../core/services/login.service";

@Component({
    selector: 'app-login',
    templateUrl: 'login.component.html',
    styleUrls: ['login.component.scss']
})
export class LoginComponent {
    form: FormGroup;
    private loginService:LoginService;
    constructor(private injector: Injector,
        private formBuilder: FormBuilder,
    ) {
        this.loginService= this.injector.get(LoginService);
        this.form = this.formBuilder.group({
            userName:['', Validators.required],
            password:['', Validators.required]
        })
    }
   
    submit(): void {
        alert(this.form.get('userName')?.value + " " + this.form.get('password')?.value);
        this.loginService.Login(this.form.value);
    }

}
