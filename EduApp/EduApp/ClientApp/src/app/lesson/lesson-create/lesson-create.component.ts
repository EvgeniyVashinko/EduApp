import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { CookieService } from "ngx-cookie-service";
import { Course } from "src/app/common/models/course";
import { Lesson } from "src/app/common/models/lesson";
import { CourseService } from "src/app/common/services/course.service";
import { LessonService } from "src/app/common/services/lesson.service";

@Component({
  selector: "app-lesson-create",
  templateUrl: "./lesson-create.component.html",
  styleUrls: ["./lesson-create.component.css"],
})
export class LessonCreateComponent implements OnInit {
  courseId: string = this.activatedRoute.snapshot.paramMap.get("id");

  createLessonForm = new FormGroup({
    title: new FormControl(""),
    description: new FormControl(""),
    externalLink: new FormControl(""),
  });

  error: string;
  constructor(
    private activatedRoute: ActivatedRoute,
    private cookieService: CookieService,
    private router: Router,
    private courseService: CourseService,
    private lessonService: LessonService
  ) {}

  ngOnInit() {}

  createLesson() {
    if (this.createLessonForm.valid) {
      this.courseService.getCourseById(this.courseId).subscribe(
        (result: Course) => {
          if (result.ownerId !== this.cookieService.get("accountId")) {
            this.router.navigate(["/user/myProfile"]);
          }
          let lesson: Partial<Lesson> = {
            title: this.createLessonForm.get("title").value,
            description: this.createLessonForm.get("description").value,
            externalLink: this.createLessonForm.get("externalLink").value,
            courseId: this.courseId,
          };
          this.lessonService.createLesson(lesson).subscribe((result) => {
            this.router.navigate(["/course/update", this.courseId]);
          });
        },
        (error) => {
          this.error = error;
          console.log(error);
        }
      );
    }
  }
}
