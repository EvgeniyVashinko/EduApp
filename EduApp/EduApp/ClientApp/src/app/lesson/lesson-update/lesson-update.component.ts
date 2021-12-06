import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { Lesson } from "src/app/common/models/lesson";
import { LessonService } from "src/app/common/services/lesson.service";

@Component({
  selector: "app-lesson-update",
  templateUrl: "./lesson-update.component.html",
  styleUrls: ["./lesson-update.component.css"],
})
export class LessonUpdateComponent implements OnInit {
  lessonId: string = this.activatedRoute.snapshot.paramMap.get("id");

  lesson: Lesson;

  updateLessonForm = new FormGroup({
    title: new FormControl(""),
    description: new FormControl(""),
    externalLink: new FormControl(""),
  });

  constructor(
    private activatedRoute: ActivatedRoute,
    private lessonService: LessonService,
    private router: Router
  ) {}

  ngOnInit() {
    this.lessonService.getLessonById(this.lessonId).subscribe(
      (result) => {
        this.updateLessonForm.get("title").setValue(result.title);
        this.updateLessonForm.get("description").setValue(result.description);
        this.updateLessonForm.get("externalLink").setValue(result.externalLink);
        this.lesson = result;
      },
      () => {
        this.router.navigate(["/user/myProfile"]);
      }
    );
  }

  updateLesson() {
    if (this.updateLessonForm.valid) {
      let lessonRequest = this.lesson;
      lessonRequest.title = this.updateLessonForm.get("title").value;
      lessonRequest.description =
        this.updateLessonForm.get("description").value;
      lessonRequest.externalLink =
        this.updateLessonForm.get("externalLink").value;
      this.lessonService.updateLesson(lessonRequest).subscribe((result) => {
        this.router.navigate(["/course/update", this.lesson.courseId]);
      });
    }
  }
}
