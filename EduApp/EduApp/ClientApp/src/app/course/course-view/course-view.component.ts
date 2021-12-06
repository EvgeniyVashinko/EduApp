import { Component, Input, OnInit } from "@angular/core";
import { MatSnackBar } from "@angular/material";
import { ActivatedRoute, Router } from "@angular/router";
import { CookieService } from "ngx-cookie-service";
import { Lesson } from "src/app/common/models/lesson";
import { PagedListContainer } from "src/app/common/models/pagedList";
import { Review } from "src/app/common/models/review";
import { User } from "src/app/common/models/user";
import { LessonService } from "src/app/common/services/lesson.service";
import { ReviewService } from "src/app/common/services/review.service";
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
    private cookieService: CookieService,
    private _snackBar: MatSnackBar,
    private router: Router,
    private rewievService: ReviewService
  ) {}

  @Input("courseId") courseId: string;

  course: Course;
  isOwner: boolean = false;
  isParticipant: boolean = false;
  lessonsOpenState: boolean = false;
  courseLessons: Lesson[] = null;

  reviews: Review[] = null;
  userId: string = this.cookieService.get("accountId");

  ngOnInit() {
    if (this.courseId === "" || this.courseId === undefined) {
      this.courseId = this.activatedRoute.snapshot.paramMap.get("id");
    }
    this.courseService
      .getCourseById(this.courseId)
      .subscribe((result: Course) => {
        this.course = result;
        if (this.course.ownerId === this.userId) {
          this.isOwner = true;
        }
        this.getReviews();
      });
    this.courseService
      .getCourseParticipants(this.courseId)
      .subscribe((result) => {
        let courseParticipants = result.pagedList.items;
        if (courseParticipants.some((x) => x.accountId === this.userId)) {
          this.isParticipant = true;
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

  getReviews() {
    this.rewievService
      .getReviewsByCourseId(this.courseId)
      .subscribe((result) => {
        this.reviews = result.pagedList.items;
      });
  }

  buyCourse() {
    if (this.userId == "") {
      this._snackBar.open("We don't know you. Are you signed in?", "Ok");
      return;
    }
    this.courseService
      .addParticipantToCourse(this.userId, this.course.id)
      .subscribe(
        (result) => {
          this._snackBar.open("You've bought this course", "Ok");
          window.location.reload();
        },
        (error) => {
          this._snackBar.open("You don't have enogh money", "Ok");
        }
      );
  }
}
