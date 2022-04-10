import { createAction, props } from '@ngrx/store';
import { ILogin } from 'src/app/core/models/ILogin';

export const login = createAction(
  '[Login] Login',
  props<{login: ILogin}>()
);

export const loginSuccess = createAction(
  '[Login] Login Success',
  props<{ token: string }>()
);

export const OnError = createAction(
  '[Login] On Error',
  props<{ error: any }>()
);