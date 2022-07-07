import { createFeatureSelector, createSelector } from '@ngrx/store';
import * as fromReducer from './auth.reducer';

export const getStateAuth = createFeatureSelector<fromReducer.State>(fromReducer.authFeatureKey);

export const getApplicationUser = createSelector(
    getStateAuth,
    (state) => state.user
);


export const IsLogged = createSelector(
    getStateAuth,
    (state) => state.isLogged
);

export const GetUserClaims = createSelector(
    getStateAuth,
    (state) => state.userInfo
)