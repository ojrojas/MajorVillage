import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StudentsRoutingModule } from './students-routing.module';
import { StudentsComponent } from './components/students/students.component';
import { SharedModule } from '../shared/shared.module';
import { StudentsResourceService } from './components/students/students.resources';


@NgModule({
  declarations: [
    StudentsComponent
  ],
  imports: [
    CommonModule,
    StudentsRoutingModule,
    SharedModule
  ],
  providers:[ StudentsResourceService]
})
export class StudentsModule { }
