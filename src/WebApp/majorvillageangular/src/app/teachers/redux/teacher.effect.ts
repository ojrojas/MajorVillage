import { Injectable } from "@angular/core";
import { createEffect, ofType, Actions } from "@ngrx/effects";
import { catchError, concatMap, of, map } from "rxjs";
import { RouteApiConstants } from "src/app/core/enums/routeapi.constants";
import { IUser } from "src/app/core/models/iuser.model";
import { ApiService } from "src/app/core/services/api.service";
import * as fromActions from './teacher.action';

@Injectable()
export class TeacherEffect {

    $getAllTeachers = createEffect(() => {
        return this.actions.pipe(
            ofType(fromActions.getAllTeachers),
            concatMap(() => this.api.get<IUser[]>(RouteApiConstants.teachers).pipe(
                map(response => fromActions.getAllTeachersSuccess({ users: response.body })),
                catchError(error => of(fromActions.onError({ error: error }))))
            )
        )
    });


    constructor(
        private actions: Actions, 
        private api: ApiService) { }
}