import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RouteApiConstants } from '../enums/routeapi.constants';
import { IRequestService } from '../interfaces/irequest.interface'
import { ILoginService } from '../interfaces/login.interface';
import { ILogin } from '../models/ILogin';
import { ApiService } from './api.service';

@Injectable({
    providedIn:'root',
    useFactory: (service:IRequestService,http:HttpClient) => service = new ApiService(http)
})
export class LoginService implements ILoginService{
    private _service: IRequestService;
    constructor(private service: IRequestService) {
        this._service = this.service;
    }
    Login(login: ILogin): Observable<string> {
        this._service.post("login" as RouteApiConstants,{});
        throw new Error('Method not implemented.');
    }
}