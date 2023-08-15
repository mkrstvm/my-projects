import { Component, Input, OnInit } from '@angular/core';
import { Course } from '../model/course';

@Component({
  selector: 'app-course-card-list',
  templateUrl: './course-card-list.component.html',
  styleUrls: ['./course-card-list.component.css']
})
export class CourseCardListComponent implements OnInit
{
editCourse(_t3: Course) {
throw new Error('Method not implemented.');
}
  @Input()
  courses: Course[] = []!;

  ngOnInit(): void 
  {
    
  }

}
