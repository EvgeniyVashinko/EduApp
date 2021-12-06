import { Component, Input, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Lesson } from "src/app/common/models/lesson";
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

  constructor(private lessonService: LessonService, private router: Router) {}

  ngOnInit() {
    this.lessonService.getLessonById(this.lessonId).subscribe(
      (result) => {
        this.lesson = result;
      },
      (error) => {
        this.router.navigate(["/"]);
        console.log(error);
      }
    );
  }
}
