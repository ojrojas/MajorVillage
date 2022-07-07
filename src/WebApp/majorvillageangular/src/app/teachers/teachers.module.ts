import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TeachersRoutingModule } from './teachers-routing.module';
import { TeachersComponent } from './components/teachers/teachers.component';
import { SharedModule } from '../shared/shared.module';
import { EffectsModule } from '@ngrx/effects';
import * as fromReducer from './redux/teacher.reducer';
import { TeacherEffect } from './redux/teacher.effect';
import { StoreModule } from '@ngrx/store';



@NgModule({
  declarations: [
    TeachersComponent
  ],
  imports: [
    CommonModule,
    TeachersRoutingModule,
    SharedModule,
    StoreModule.forFeature(fromReducer.teacherFeatureKey, fromReducer.reducer),
    EffectsModule.forFeature([TeacherEffect])
  ]
})
export class TeachersModule { }
