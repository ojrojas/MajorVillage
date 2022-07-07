import { Injectable } from '@angular/core';
import { ActionReducerMap } from '@ngrx/store';
import { AppState } from './app.reducer';
import * as fromLoginReducer from './login/redux/login.reducer';
import * as fromAuthReducer from './auth/redux/auth.reducer';
import * as fromTeacherReducer from './teachers/redux/teacher.reducer';

@Injectable({
  providedIn: 'root'
})
export class AppReducerService {

  constructor() { }

  getReducers(): ActionReducerMap<AppState>{
    return {
      loginState: fromLoginReducer.reducer,
      teacherState: fromTeacherReducer.reducer,
      authState : fromAuthReducer.reducer,
    };
  }
}