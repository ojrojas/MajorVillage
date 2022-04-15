import { createAction, props } from "@ngrx/store";
import { IUser } from "src/app/core/models/iuser.model";

export const loadAuths = createAction(
    '[Auths] Load authorize',
);

export const loadAuthsSuccess = createAction(
    '[Auths] Load Authorize Success',
    props<{ user: IUser }>()
);

export const OnError = createAction(
    '[Auth] Error module auth',
    props<{ error: any }>()
);

export const setClaimsAuth = createAction(
    '[Auth] set Claims Auth',
    props<{ user: IUser, token: string }>()
);
