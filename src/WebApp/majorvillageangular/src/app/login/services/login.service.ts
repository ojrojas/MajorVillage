import { Injectable } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { State } from 'src/app/login/redux/login.reducer';
import { ILoginService } from '../../core/interfaces/login.interface';
import { ILogin } from '../../core/models/ilogin.model';
import * as fromAction from '../redux/login.actions';
import { getLoginState } from '../redux/login.selectors';

@Injectable({
    providedIn: 'root'
})
export class LoginService implements ILoginService {

    constructor(private store: Store<State>) {
    }

    GetState(): Observable<State> {
        return this.store.pipe(select(getLoginState));
    }

    Login(login: ILogin): void {
        this.store.dispatch(fromAction.login({ login }));
    }
}

