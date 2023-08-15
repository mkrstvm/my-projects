import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Course } from '../model/course';
import { CoursesService } from '../services/courses.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent  implements OnInit
{
  beginnerCourses$!: Observable<Course[]>;
  advancedCourses$!: Observable<Course[]>;

  constructor(private courseService : CoursesService){}

  ngOnInit(): void 
  {
    this.reloadCourses();  
  }
  reloadCourses() {
    this.beginnerCourses$ = this.courseService.loadAllCourses();
    this.advancedCourses$ = this.courseService.loadAllCourses();
  }

}
