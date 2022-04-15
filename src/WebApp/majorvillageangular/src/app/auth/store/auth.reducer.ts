import { createReducer, on } from '@ngrx/store';
import { IUser } from 'src/app/core/models/iuser.model';
import * as fromActions from './auth.actions';

export const authFeatureKey = 'auth';

export interface State {
    user: IUser | undefined;
    isLoading: boolean;
    token: string | undefined;
    error: any
}

export const initialState: State = {
    user: undefined,
    isLoading: false,
    token: undefined,
    error: null
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
    on(fromActions.setClaimsAuth, (state, { user, token }) => ({
        ...state,
        user,
        token,
        isLoading: false
    })),
    on(fromActions.OnError, (state, { error }) => ({
        ...state,
        error,
        isLoading: false
    })),

);