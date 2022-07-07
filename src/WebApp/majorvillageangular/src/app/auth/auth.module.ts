import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthRoutingModule } from './auth-routing.module';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import * as fromReducer from './redux/auth.reducer';
import { AuthEffects } from './redux/auth.effects';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    AuthRoutingModule,
    StoreModule.forFeature(fromReducer.authFeatureKey, fromReducer.reducer),
    EffectsModule.forFeature([AuthEffects])
  ]
})
export class AuthModule { }
