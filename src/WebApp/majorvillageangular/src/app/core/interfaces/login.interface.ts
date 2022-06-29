import { Observable } from "rxjs";
import { State } from "src/app/login/redux/login.reducer";
import { ILogin } from "../models/ilogin.model";
export interface ILoginService{
    Login(login:ILogin): void;
    GetState(): Observable<State>;
}