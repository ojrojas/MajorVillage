import { createReducer, on } from '@ngrx/store';
import { IUser } from 'src/app/core/models/iuser.model';
import * as fromActions from './login.actions';

export const loginFeatureKey = 'login';

export interface State {
    isLoading: boolean;
    token: string | null;
    error: any;
}

export const initialState: State = {
    isLoading: false,
    token: null,
    error: null
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
        isLoading: false
    })),
    on(fromActions.onError, (state, { error }) => ({
        ...state,
        error,
        isLoading: false
    }))
);
