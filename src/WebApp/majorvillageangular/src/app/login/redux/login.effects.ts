
import { Inject, Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { of } from 'rxjs';
import { catchError, concatMap, map, tap } from 'rxjs/operators';
import { RouteApiConstants } from 'src/app/core/enums/routeapi.constants';
import { IRequestService } from 'src/app/core/interfaces/irequest.interface';
import { ApiService } from 'src/app/core/services/api.service';
import { LoginService } from 'src/app/core/services/login.service';
import * as fromActions from './login.actions';

@Injectable()
export class LoginEffects {

    login$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(fromActions.login),
            concatMap((props) => this.service.post<string>(RouteApiConstants.loginRoute, props.login).pipe(
                map(response => fromActions.loginSuccess({ token: response.body as string })),
                catchError(error => of(fromActions.OnError({ error }))))
            )
        );
    });

    loginSuccess$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(fromActions.loginSuccess),
            tap((props) => {
                if (props.token !== null) {

                    this.router.navigate(['/home']);
                } else {

                }
                return;
            })
        );
    }, { dispatch: false });



    constructor(
        private router: Router,
        private actions$: Actions,
        private service: ApiService) {
    }
}