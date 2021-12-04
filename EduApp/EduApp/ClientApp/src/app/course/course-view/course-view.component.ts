import { Component, Input, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Lesson } from "src/app/common/models/lesson";
import { PagedListContainer } from "src/app/common/models/pagedList";
import { LessonService } from "src/app/common/services/lesson.service";
import { Course } from "../../common/models/course";
import { CourseService } from "../../common/services/course.service";

@Component({
  selector: "app-course-view",
  templateUrl: "./course-view.component.html",
  styleUrls: ["./course-view.component.css"],
})
export class CourseViewComponent implements OnInit {
  course: Course;
  lessonsOpenState: boolean = false;
  courseLessons: Lesson[] = null;

  @Input() courseId: string = this.activatedRoute.snapshot.paramMap.get("id");

  constructor(
    private activatedRoute: ActivatedRoute,
    private courseService: CourseService,
    private lessonService: LessonService
  ) {}

  ngOnInit() {
    this.courseService
      .getCourseById(this.courseId)
      .subscribe((result: Course) => {
        this.course = result;
      });
  }

  getLessons() {
    this.lessonsOpenState = true;
    if (this.courseLessons === null) {
      this.lessonService
        .getLessonsByCourseId(this.courseId)
        .subscribe((result: PagedListContainer<Lesson>) => {
          this.courseLessons = result.pagedList.items;
        });
    }
  }
}
