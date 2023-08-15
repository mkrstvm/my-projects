import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Observable, share, shareReplay } from 'rxjs';
import { map } from 'rxjs/operators';
import { Course } from '../model/course';
import { Lesson } from '../model/lesson';

@Injectable({
  providedIn: 'root'
})
export class CoursesService {

  constructor(private http:HttpClient) { }

  loadCourseByid(courseId : number)
  {
    return this.http.get<Course>(`/api/courses/${courseId}`).pipe(shareReplay());
  }

  loadAllCourseLessons(courseId : number)
  {
    return this.http.get<Lesson[]>('/api/lessons', 
    {
      params : {
        pageSize:"10",
        courseId:courseId.toString()
      }
    }).pipe(shareReplay());
  }

  loadAllCourses(): Observable<Course[]>
  {
    return this.http.get<Course[]>("/api/courses").pipe();
  }

  saveCourse(courseId: number)
  {

  }

  searchLesson(search:string)
  {

  }

}
