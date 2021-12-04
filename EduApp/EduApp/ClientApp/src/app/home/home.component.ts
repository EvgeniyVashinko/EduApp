import { Component } from "@angular/core";
import { Course } from "../common/models/course";
import { PagedList, PagedListContainer } from "../common/models/pagedList";
import { CourseService } from "../common/services/course.service";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
})
export class HomeComponent {
  courses: Course[] = null;

  constructor(private courseService: CourseService) {}

  ngOnInit() {
    this.courseService
      .getAllCourses({})
      .subscribe((result: PagedListContainer<Course>) => {
        this.courses = result.pagedList.items;
      });
  }
}
