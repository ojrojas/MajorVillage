import { Observable } from "rxjs";
import { IUser } from "../models/iuser.model";

export interface IClaimService {
    GetClaims(token:string): Observable<IUser>;
}