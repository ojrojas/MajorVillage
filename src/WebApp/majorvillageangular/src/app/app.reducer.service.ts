import { Injectable } from '@angular/core';
import { ActionReducerMap } from '@ngrx/store';
import { AppState } from './app.reducer';
import * as fromLoginReducer from './login/redux/login.reducer';

@Injectable({
  providedIn: 'root'
})
export class AppReducerService {

  constructor() { }

  getReducers(): ActionReducerMap<AppState>{
    return {
      loginState: fromLoginReducer.reducer,
    };
  }
}