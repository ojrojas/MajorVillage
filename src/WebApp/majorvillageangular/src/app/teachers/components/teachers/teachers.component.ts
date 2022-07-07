import { Component, OnInit } from '@angular/core';
import { IUser } from 'src/app/core/models/iuser.model';
import { HeaderModel } from 'src/app/shared/models/header/headermodel';
import { TeacherService } from '../../services/teacher.service';

@Component({
  selector: 'app-teachers',
  templateUrl: './teachers.component.html',
  styleUrls: ['./teachers.component.scss']
})
export class TeachersComponent implements OnInit {
  headerTeachers: HeaderModel;
  namesColumns: string[] = ['name', 'lastName', 'createdOn'];
  teachersList: Array<IUser> = [];

  constructor(private service: TeacherService) {
    this.headerTeachers = service.getHeaderTeachers();
  }

  ngOnInit(): void {
  }

}
