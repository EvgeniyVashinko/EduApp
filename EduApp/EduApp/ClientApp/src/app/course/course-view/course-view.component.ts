import { Component, Input, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { CookieService } from "ngx-cookie-service";
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
  constructor(
    private activatedRoute: ActivatedRoute,
    private courseService: CourseService,
    private lessonService: LessonService,
    private cookieService: CookieService
  ) {}

  @Input("courseId") courseId: string;

  course: Course;
  isOwner: boolean = false;
  lessonsOpenState: boolean = false;
  courseLessons: Lesson[] = null;

  ngOnInit() {
    if (this.courseId === "" || this.courseId === undefined) {
      this.courseId = this.activatedRoute.snapshot.paramMap.get("id");
    }
    this.courseService
      .getCourseById(this.courseId)
      .subscribe((result: Course) => {
        this.course = result;
        if (this.course.ownerId === this.cookieService.get("accountId")) {
          this.isOwner = true;
        }
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
