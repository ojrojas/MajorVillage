import { Injectable } from '@angular/core';
import { HeaderModel } from 'src/app/shared/models/header/headermodel';

@Injectable({
  providedIn: 'root'
})
export class TeacherService {

  constructor() { }

  getHeaderTeachers = (): HeaderModel => {
    return {
      titlePage: "List Teachers",
      subTitle: "Teachers"
    }

  }
}
