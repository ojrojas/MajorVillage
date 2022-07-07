import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, map, of, concatMap, tap } from 'rxjs';
import { ClaimService } from 'src/app/core/services/getclaims.service';
import * as fromActions from './auth.actions';

@Injectable()
export class AuthEffects {

    getClaims$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(fromActions.setClaimsAuth),
            concatMap((props) => this.claimService.GetClaims(props.token).pipe(
                map(response => fromActions.setClaimsAuthSuccess({ user: response})),
                catchError(error => of(fromActions.onError({ error }))))
            )
        );
    });

    getClaimsSuccess$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(fromActions.setClaimsAuthSuccess),
            tap((props) => {
                if (props.user !== null) {
                    this.router.navigate(['/home']);
                } else {
                }
                return;
            })
        );
    }, { dispatch: false });

    // logOut$ = createEffect(() => {
    //     return this.actions$.pipe(
    //         ofType(fromActions.logOutAuth),
    //         concatMap((props) => this.claimService.GetClaims(props.token).pipe(
    //             map(response => fromActions.setClaimsAuthSuccess({ user: response})),
    //             catchError(error => of(fromActions.onError({ error }))))
    //         )
    //     );
    // });

    // logOutSuccess$ = createEffect(() => {
    //     return this.actions$.pipe(
    //         ofType(fromActions.setClaimsAuthSuccess),
    //         tap((props) => {
    //             if (props.user !== null) {
    //                 this.router.navigate(['/home']);
    //             } else {
    //             }
    //             return;
    //         })
    //     );
    // }, { dispatch: false });

    constructor(
        private actions$: Actions,
        private claimService: ClaimService,
        private router:Router) { }
}