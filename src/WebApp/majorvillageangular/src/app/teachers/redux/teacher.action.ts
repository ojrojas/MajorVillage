import { HttpErrorResponse } from "@angular/common/http";
import { createAction, props } from "@ngrx/store";
import { IUser } from "src/app/core/models/iuser.model";

export const getAllTeachers = createAction(
    '[Teachers] get all teachers'
);

export const getAllTeachersSuccess = createAction(
    '[Teachers] get all teachers success',
    props<{ users: IUser[] | null}>()
)

export const onError = createAction(
    '[Teachers] Error request',
    props<{error: any}>()
)