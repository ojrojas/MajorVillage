import { createReducer, on } from '@ngrx/store';
import { IUser } from 'src/app/core/models/iuser.model';
import * as fromActions from './auth.actions';

export const authFeatureKey = 'auth';

export interface State {
    user: IUser | undefined;
    isLoading: boolean;
    token: string | undefined;
    isLogged: boolean;
    userInfo: IUser | null;
    error: any
}

export const initialState: State = {
    user: undefined,
    isLoading: false,
    token: undefined,
    error: null,
    isLogged: false,
    userInfo: null
};

export const reducer = createReducer(
    initialState,
    on(fromActions.loadAuths, (state) => ({
        ...state,
        isLoading: false
    })),
    on(fromActions.loadAuthsSuccess, (state, { user }) => ({
        ...state,
        user,
        isLoading: false
    })),
    on(fromActions.setClaimsAuth, (state,  {token} ) => ({
        ...state,
        token,
        isLoading: false
    })),
    on(fromActions.setClaimsAuthSuccess, (state, { user }) => ({
        ...state,
        userInfo: user,
        isLogged: true,
        isLoading: false
    })),
    on(fromActions.logOutAuth, (state) => ({
        ...state,
        isLogged:false,
        isLoading:true,
    })),
    on(fromActions.logOutAuth, (state) => ({
        ...state,
        isLoading:false,
    })),
    on(fromActions.onError, (state, { error }) => ({
        ...state,
        error,
        isLoading: false,
        isLogged: false
    })),

);