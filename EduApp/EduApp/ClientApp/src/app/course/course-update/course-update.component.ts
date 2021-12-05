import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { CookieService } from "ngx-cookie-service";
import { Course } from "src/app/common/models/course";
import { CourseService } from "src/app/common/services/course.service";
import { MatSnackBar } from "@angular/material/snack-bar";

@Component({
  selector: "app-course-update",
  templateUrl: "./course-update.component.html",
  styleUrls: ["./course-update.component.css"],
})
export class CourseUpdateComponent implements OnInit {
  id: string = this.activatedRoute.snapshot.paramMap.get("id");

  course: Course = null;

  updateCourseForm = new FormGroup({
    title: new FormControl(""),
    description: new FormControl(""),
    price: new FormControl(""),
  });

  constructor(
    private activatedRoute: ActivatedRoute,
    private courseService: CourseService,
    private cookieService: CookieService,
    private router: Router,
    private _snackBar: MatSnackBar
  ) {}

  ngOnInit() {
    this.courseService.getCourseById(this.id).subscribe(
      (result) => {
        if (result.ownerId != this.cookieService.get("accountId")) {
          this.router.navigate(["/course", result.id]);
        }
        this.course = result;
        this.updateCourseForm.get("title").setValue(this.course.title);
        this.updateCourseForm
          .get("description")
          .setValue(this.course.description);
        this.updateCourseForm.get("price").setValue(this.course.price);
      },
      (error) => {
        this.router.navigate(["/user/myProfile"]);
      }
    );
  }

  updateCourse() {
    this.course.title = this.updateCourseForm.get("title").value;
    this.course.description = this.updateCourseForm.get("description").value;
    this.course.price = this.updateCourseForm.get("price").value;
    this.courseService.updateCourse(this.course).subscribe((result) => {
      this._snackBar.open("Course updated", "Ok");
    });
  }
}
