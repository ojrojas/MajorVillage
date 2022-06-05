import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HeaderPageComponent } from './components/headerpages/headerpage.component';
import { LoadingComponent } from './components/loading/loading.component';
import { InputComponent } from './components/input/input.component';
import { SelectComponent } from './components/select/select.component';
import { TextareaComponent } from './components/textarea/textarea.component';
import { RouterModule } from '@angular/router';
import { SidenavComponent } from './components/sidenav/sidenav.component';

@NgModule({
  declarations: [
    HeaderPageComponent,
    LoadingComponent,
    InputComponent,
    SelectComponent,
    TextareaComponent,
    SidenavComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
  ],
  exports: [
    HeaderPageComponent,
    FormsModule,
    ReactiveFormsModule,
    LoadingComponent,
    InputComponent,
    SelectComponent,
    TextareaComponent,
    SidenavComponent
  ]
})
export class SharedModule { }
