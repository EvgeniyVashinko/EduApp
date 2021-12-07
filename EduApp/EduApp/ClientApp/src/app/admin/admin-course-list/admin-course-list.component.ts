import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { Course } from 'src/app/common/models/course';
import { PagedListContainer } from 'src/app/common/models/pagedList';
import { CourseService } from 'src/app/common/services/course.service';

@Component({
  selector: 'app-admin-course-list',
  templateUrl: './admin-course-list.component.html',
  styleUrls: ['./admin-course-list.component.css']
})
export class AdminCourseListComponent implements OnInit {

  constructor(
    private activatedRoute: ActivatedRoute,
    private cookieService: CookieService,
    private courseService: CourseService,
  ) { }

  courses: Course[];
  displayedColumns: string[] = ['title', 'owner', 'status', 'actions'];;

  ngOnInit() {
    this.courseService
      .getAllCourses({isActive: null})
      .subscribe((result: PagedListContainer<Course>) => {
        this.courses = result.pagedList.items;
    });
  }

  ApproveCourse(course: Course){
    course.isActive = true;
    this.courseService
    .approveCourse(course.id)
    .subscribe((result: Course) => {}, 
    (error) => console.log(error));
  }

  DeclineCourse(course: Course){
    course.isActive = false;
    this.courseService
    .declineCourse(course.id)
    .subscribe((result: Course) => {}, 
    (error) => console.log(error));
  }
}
