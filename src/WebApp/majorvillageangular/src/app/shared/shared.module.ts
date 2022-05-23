import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HeaderPageComponent } from './components/headerpages/headerpage.component';



@NgModule({
  declarations: [HeaderPageComponent],
  imports: [
    CommonModule,
  ],
  exports:[
    HeaderPageComponent,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class SharedModule { }
