import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup } from "@angular/forms";
import { Router } from "@angular/router";
import { CookieService } from "ngx-cookie-service";
import { Course } from "src/app/common/models/course";
import { CourseService } from "src/app/common/services/course.service";

@Component({
  selector: "app-course-create",
  templateUrl: "./course-create.component.html",
  styleUrls: ["./course-create.component.css"],
})
export class CourseCreateComponent implements OnInit {
  createCourseForm = new FormGroup({
    title: new FormControl(""),
    description: new FormControl(""),
    price: new FormControl(""),
  });

  error: string;
  constructor(
    private cookieService: CookieService,
    private courseService: CourseService,
    private router: Router
  ) {}

  ngOnInit() {}

  createCourse() {
    let course: Course = {
      title: this.createCourseForm.get("title").value,
      description: this.createCourseForm.get("description").value,
      price: this.createCourseForm.get("price").value,
      ownerId: this.cookieService.get("accountId"),
      id: undefined,
    };

    if (course.price < 0) {
      this.error = "Price cannot be negative";
      return;
    }

    this.courseService.createCourse(course).subscribe((result: Course) => {
      this.router.navigate(["/course/update", result.id]);
    });
  }
}
