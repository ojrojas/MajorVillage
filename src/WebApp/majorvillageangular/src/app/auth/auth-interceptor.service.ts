import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { select, Store } from "@ngrx/store";
import { catchError, Observable, throwError } from "rxjs";
import { AppState, getAppStateAuthData } from "../app.reducer";

@Injectable({
    providedIn: 'root'
})
export class AuthInterceptor implements HttpInterceptor {
    constructor(private store: Store<AppState>,
        private route: Router) { }
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        let token: string | undefined = undefined;
        this.store.pipe(select(getAppStateAuthData)).subscribe((response) => {
            if (response !== undefined) {
                token = response.token as string;
            }
        }).unsubscribe();

        const auth = req.clone({
            setHeaders: {
                Authorization: `Bearer ${token}`
            }
        });

        return next.handle(auth).pipe(catchError(error => {
            if (error instanceof HttpErrorResponse) {
                if (error.status === 401) {
                    this.route.navigate(['/unauthorize']);
                }
            }
            throw throwError(error);
        }));
    }
}