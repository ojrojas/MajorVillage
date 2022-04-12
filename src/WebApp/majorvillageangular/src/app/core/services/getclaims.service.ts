import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IClaimService } from "../interfaces/igetclaims.interface";
import { IUser } from "../models/iuser.model";

@Injectable({
    providedIn: 'root'
})
export class ClaimService implements IClaimService {

    GetClaims(token: string): Observable<IUser> {
        const userInfo = JSON.parse(atob(token.split('.')[1]));
        const user = new Observable<IUser>((observer) => {
            let user: IUser = {
                id: userInfo.Id,
                firstName: userInfo.firstName,
                middlename: userInfo.middleName,
                lastName: userInfo.lastName,
                surName: userInfo.surName,
                email: userInfo.email,
                typeUser: userInfo.typeUser,
                typeIdentification: userInfo.typeIdentification,
                identification: userInfo.identification,
                age: userInfo.age,
                birthDate: userInfo.birthDate,
                createdOn: userInfo.CreatedOn,
                modifiedOn: userInfo.ModifiedOn,
                createdBy: userInfo.CreatedBy,
                modifiedBy: userInfo.ModifiedBy
            };
            observer.next(user);
        });
        return user;
    }
}