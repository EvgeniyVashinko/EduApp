import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup } from "@angular/forms";
import { Router } from "@angular/router";
import { CookieService } from "ngx-cookie-service";
import { Category } from "src/app/common/models/category";
import { Course } from "src/app/common/models/course";
import { CategoryService } from "src/app/common/services/category.service";
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
    categories: new FormControl(""),
  });

  categoriesList: Category[];
  error: string;

  constructor(
    private cookieService: CookieService,
    private courseService: CourseService,
    private categoryService: CategoryService,
    private router: Router
  ) {}

  ngOnInit() {
    this.categoryService.getAllCategories("12").subscribe((result) => {
      this.categoriesList = result;
    });
  }

  createCourse() {
    let course: Course = {
      title: this.createCourseForm.get("title").value,
      description: this.createCourseForm.get("description").value,
      price: this.createCourseForm.get("price").value,
      ownerId: this.cookieService.get("accountId"),
      id: undefined,
      categories: this.createCourseForm.get("categories").value,
      isActive: false
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
