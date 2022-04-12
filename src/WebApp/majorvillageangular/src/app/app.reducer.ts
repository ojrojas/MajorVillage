import { inject, InjectionToken } from '@angular/core';
import {  ActionReducerMap, createSelector } from '@ngrx/store';
import { AppReducerService } from './app.reducer.service';
import * as fromLoginReducer from './login/redux/login.reducer';

export interface AppState {
    loginState: fromLoginReducer.State;
}

export const REDUCER_TOKEN = new InjectionToken<ActionReducerMap<AppState>>
('Registered reducers', {
    factory: () => {
        const serv = inject(AppReducerService);
        return serv.getReducers();
    }
});

export const getAppStateLoginState = (state: AppState) => state.loginState;

export const getAppStateLoginData = createSelector(
    getAppStateLoginState,
    (state) => state
);