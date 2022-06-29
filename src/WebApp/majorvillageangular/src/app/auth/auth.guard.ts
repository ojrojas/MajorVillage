import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { AppState, getAppStateAuthData } from '../app.reducer';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private store: Store<AppState>, private router: Router) {
  }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    let isLogged = false;
    let algo = state.root.data;
    console.log("Data stateurl =0>", state);
    this.store.pipe(select(getAppStateAuthData)).subscribe(result => {
      isLogged = result.isLogged;

    }).unsubscribe();
    if (isLogged) { return true; }
    else {
      this.router.navigate(['/login']);
      return false;
    }
  }
}
