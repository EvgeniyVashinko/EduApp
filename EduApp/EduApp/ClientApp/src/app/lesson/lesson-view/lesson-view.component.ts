import { Component, Input, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Homework } from "src/app/common/models/homework";
import { Lesson } from "src/app/common/models/lesson";
import { HomeworkService } from "src/app/common/services/homework.service";
import { LessonService } from "src/app/common/services/lesson.service";

@Component({
  selector: "app-lesson-view",
  templateUrl: "./lesson-view.component.html",
  styleUrls: ["./lesson-view.component.css"],
})
export class LessonViewComponent implements OnInit {
  @Input() lessonId: string;
  @Input() lessonProgressView: boolean = false;

  lesson: Lesson = null;
  homework: Homework = null;

  constructor(
    private lessonService: LessonService,
    private router: Router,
    private homeworkService: HomeworkService
  ) {}

  ngOnInit() {
    this.lessonService.getLessonById(this.lessonId).subscribe(
      (result) => {
        this.lesson = result;
        this.homeworkService
          .getHomeworksByLessonId(this.lessonId)
          .subscribe((result) => {
            this.homework =
              result.pagedList.totalItems > 0
                ? result.pagedList.items[0]
                : null;
          });
      },
      (error) => {
        this.router.navigate(["/"]);
        console.log(error);
      }
    );
  }
}
