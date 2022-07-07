import { createAction, props } from "@ngrx/store";
import { IUser } from "src/app/core/models/iuser.model";

export const loadAuths = createAction(
    '[Auths] Load authorize',
);

export const loadAuthsSuccess = createAction(
    '[Auths] Load Authorize Success',
    props<{ user: IUser }>()
);

export const setClaimsAuth = createAction(
    '[Auth] set Claims Auth',
    props<{ token: string }>()
);

export const setClaimsAuthSuccess = createAction(
    '[Auth] set Claims Auth Success',
    props<{ user: IUser }>()
);

export const logOutAuth = createAction(
    '[Auth] set logout application'
);

export const logOutAuthSuccess = createAction(
    '[Auth] set logout application success'
);

export const onError = createAction(
    '[Auth] Error module auth',
    props<{ error: any }>()
);
