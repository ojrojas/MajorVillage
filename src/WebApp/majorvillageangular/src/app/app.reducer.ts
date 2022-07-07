import { inject, InjectionToken } from '@angular/core';
import {  ActionReducerMap, createSelector } from '@ngrx/store';
import { AppReducerService } from './app.reducer.service';
import * as fromLoginReducer from './login/redux/login.reducer';
import * as fromAuthReducer from './auth/redux/auth.reducer';
import * as fromTeacherReducer from './teachers/redux/teacher.reducer';

export interface AppState {
    loginState: fromLoginReducer.State;
    authState: fromAuthReducer.State;
    teacherState: fromTeacherReducer.State;
}

export const REDUCER_TOKEN = new InjectionToken<ActionReducerMap<AppState>>
('Registered reducers', {
    factory: () => {
        const serv = inject(AppReducerService);
        return serv.getReducers();
    }
});

export const getAppStateAuthState = (state: AppState) => state.authState;

export const getAppStateAuthData = createSelector(
    getAppStateAuthState,
    (state) => state
);