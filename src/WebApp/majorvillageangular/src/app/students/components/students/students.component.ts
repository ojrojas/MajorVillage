import { Component, OnInit } from '@angular/core';
import { HeaderModel } from 'src/app/shared/models/header/headermodel';
import  {StudentsResourceService}  from '../students/students.resources';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.scss']
})
export class StudentsComponent implements OnInit {

  headerStudents: HeaderModel;
  constructor(private serviceResoure: StudentsResourceService) { 
    this.headerStudents = this.serviceResoure.getHeaderStudetns();
  }

  ngOnInit(): void {
  }

}
