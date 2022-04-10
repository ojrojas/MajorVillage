import { Observable } from "rxjs";
import { ILogin } from "../models/ILogin";

export interface ILoginService{
    Login(login:ILogin): Observable<string>;
}