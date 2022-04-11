import {  Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RouteApiConstants } from '../enums/routeapi.constants';
import { IRequestService } from '../interfaces/irequest.interface'
import { ILoginService } from '../interfaces/login.interface';
import { ILogin } from '../models/ilogin';
import { ApiService } from './api.service';

@Injectable({
    providedIn:'root',
    useFactory: (service:ApiService) => new LoginService(service)
})
export class LoginService implements ILoginService{
   
    constructor(private service: ApiService) {
    }
    Login(login: ILogin): Observable<string> {
        debugger;
        this.service.post("login" as RouteApiConstants,{});
        throw new Error('Method not implemented.');
    }
}