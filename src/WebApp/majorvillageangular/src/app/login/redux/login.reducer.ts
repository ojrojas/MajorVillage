import { createReducer, on } from '@ngrx/store';
import { IUser } from 'src/app/core/models/iuser.model';
import * as fromActions from './login.actions';

export const loginFeatureKey = 'login';

export interface State {
    isLoading: boolean;
    token: string | null;
    error: any;
    isLogged: boolean;
    userInfo: IUser | null;
}

export const initialState: State = {
    isLoading: false,
    token: null,
    error: null,
    isLogged: false,
    userInfo: null
};

export const reducer = createReducer(
    initialState,

    on(fromActions.login, (state) => ({
        ...state,
        isLoading: true
    })),
    on(fromActions.loginSuccess, (state, { token }) => ({
        ...state,
        token,
        isLogged: true,
        isLoading: false
    })),
    on(fromActions.getClaims, (state, { token }) => ({
        ...state,
        token
    })),
    on(fromActions.getClaimsSuccess, (state, { userInfo }) => ({
        ...state,
        userInfo,
        isLogged: true,
        isLoading: false
    })),
    on(fromActions.onError, (state, { error }) => ({
        ...state,
        error,
        isLogged: false,
        isLoading: false
    }))
);
