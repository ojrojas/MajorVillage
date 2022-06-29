import { createAction, props } from '@ngrx/store';
import { ILogin } from 'src/app/core/models/ilogin.model';
import { IUser } from 'src/app/core/models/iuser.model';

export const login = createAction(
  '[Login] Login',
  props<{login: ILogin}>()
);

export const loginSuccess = createAction(
  '[Login] Login Success',
  props<{ token: string }>()
);

export const onError = createAction(
  '[Login] On Error',
  props<{ error: any }>()
);