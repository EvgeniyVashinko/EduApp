import { Component, Input, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { CookieService } from "ngx-cookie-service";
import { Course } from "src/app/common/models/course";
import { Lesson } from "src/app/common/models/lesson";
import { CourseService } from "src/app/common/services/course.service";
import { LessonService } from "src/app/common/services/lesson.service";

@Component({
  selector: "app-course-progress",
  templateUrl: "./course-progress.component.html",
  styleUrls: ["./course-progress.component.css"],
})
export class CourseProgressComponent implements OnInit {
  @Input() courseId: string;

  userId: string = this.cookieService.get("accountId");
  course: Course = null;
  lessons: Lesson[] = null;

  constructor(
    private activatedRoute: ActivatedRoute,
    private courseService: CourseService,
    private lessonService: LessonService,
    private router: Router,
    private cookieService: CookieService
  ) {}

  ngOnInit() {
    if (this.courseId === "" || this.courseId === undefined) {
      this.courseId = this.activatedRoute.snapshot.paramMap.get("id");
    }

    this.checkParticipation();
    this.courseService.getCourseById(this.courseId).subscribe(
      (result) => {
        this.course = result;
        this.lessonService
          .getLessonsByCourseId(this.courseId)
          .subscribe((courseLessons) => {
            this.lessons = courseLessons.pagedList.items;
          });
      },
      (error) => {
        this.router.navigate(["/"]);
      }
    );
  }

  checkParticipation() {
    this.courseService.getCourseParticipants(this.courseId).subscribe(
      (result) => {
        let courseParticipants = result.pagedList.items;
        if (!courseParticipants.some((x) => x.accountId === this.userId)) {
          this.router.navigate(["/course", this.courseId]);
        }
      },
      (error) => {
        this.router.navigate(["/"]);
      }
    );
  }
}
