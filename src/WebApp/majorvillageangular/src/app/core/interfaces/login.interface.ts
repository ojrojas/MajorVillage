import { Observable } from "rxjs";
import { ILogin } from "../models/ilogin";

export interface ILoginService{
    Login(login:ILogin): Observable<string>;
}