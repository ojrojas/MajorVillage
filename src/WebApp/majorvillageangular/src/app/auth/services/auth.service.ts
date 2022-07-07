import { Injectable } from "@angular/core";
import { Store } from "@ngrx/store";
import { IUser } from "src/app/core/models/iuser.model";
import { State } from "../redux/auth.reducer";
import * as fromActions from '../redux/auth.actions';

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    constructor(private store: Store<State>) { }
    loadAuth(user: IUser): void {
        this.store.dispatch(fromActions.loadAuths());
    }

    setClaims( token: string): void {
        this.store.dispatch(fromActions.setClaimsAuth({ token }));
    }
}
