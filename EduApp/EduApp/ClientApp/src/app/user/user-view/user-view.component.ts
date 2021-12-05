import { Component, Input, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { CookieService } from "ngx-cookie-service";
import { Course } from "src/app/common/models/course";
import { PagedListContainer } from "src/app/common/models/pagedList";
import { User } from "src/app/common/models/user";
import { CourseService } from "src/app/common/services/course.service";
import { UserService } from "src/app/common/services/user.service";

@Component({
  selector: "app-user-view",
  templateUrl: "./user-view.component.html",
  styleUrls: ["./user-view.component.css"],
})
export class UserViewComponent implements OnInit {
  userId: string = this.activatedRoute.snapshot.paramMap.get("id");

  user: User = null;

  isMyPage: boolean = false;
  myOwnCourses: Course[] = null;
  myParticipatingCourses: Course[] = null;

  constructor(
    private activatedRoute: ActivatedRoute,
    private cookieService: CookieService,
    private userService: UserService,
    private courseService: CourseService,
    private router: Router
  ) {}

  ngOnInit() {
    if (this.userId === "myProfile") {
      this.userId = this.cookieService.get("accountId");
    }

    if (this.userId === this.cookieService.get("accountId")) {
      this.isMyPage = true;
    }
    this.userService.getUserById(this.userId).subscribe(
      (result: User) => {
        this.user = result;
      },
      (error) => {
        this.router.navigate(["/"]).then(() => window.location.reload());
      }
    );

    this.getMyParticipatingCourses();
    this.getMyOwnCourses();
  }

  getMyOwnCourses() {
    this.courseService
      .getCoursesByOwnerId(this.userId)
      .subscribe((result: PagedListContainer<Course>) => {
        this.myOwnCourses = result.pagedList.items;
      });
  }

  getMyParticipatingCourses() {
    this.courseService
      .getCoursesByParticipantId(this.userId)
      .subscribe((result: PagedListContainer<Course>) => {
        this.myParticipatingCourses = result.pagedList.items;
      });
  }
}
