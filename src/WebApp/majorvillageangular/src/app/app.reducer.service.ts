import { Injectable } from '@angular/core';
import { ActionReducerMap } from '@ngrx/store';
import { AppState } from './app.reducer';
import * as fromLoginReducer from './login/redux/login.reducer';
import * as fromAuthReducer from './auth/store/auth.reducer';

@Injectable({
  providedIn: 'root'
})
export class AppReducerService {

  constructor() { }

  getReducers(): ActionReducerMap<AppState>{
    return {
      loginState: fromLoginReducer.reducer,
      authState : fromAuthReducer.reducer,
    };
  }
}