import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LoginRoutingModule } from './login-routing.module';
import { LoginComponent } from './login.component';
import { SharedModule } from '../shared/shared.module';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { LoginEffects } from './redux/login.effects';
import * as fromReducer from './redux/login.reducer';
import { AuthEffects } from '../auth/redux/auth.effects';


@NgModule({
  declarations: [LoginComponent],
  imports: [
    CommonModule,
    LoginRoutingModule,
    SharedModule,
    StoreModule.forFeature(fromReducer.loginFeatureKey, fromReducer.reducer),
    EffectsModule.forFeature([LoginEffects, AuthEffects])
  ]
})
export class LoginModule { }
