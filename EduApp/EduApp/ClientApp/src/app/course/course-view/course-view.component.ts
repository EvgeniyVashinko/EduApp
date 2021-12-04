import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Course } from "../../common/models/course";
import { CourseService } from "../../common/services/course.service";

@Component({
  selector: "app-course-view",
  templateUrl: "./course-view.component.html",
  styleUrls: ["./course-view.component.css"],
})
export class CourseViewComponent implements OnInit {
  courseId: string;
  course: Course;

  constructor(
    private activatedRoute: ActivatedRoute,
    private courseService: CourseService
  ) {}

  ngOnInit() {
    this.courseId = this.activatedRoute.snapshot.paramMap.get("id");
    this.courseService
      .getCourseById(this.courseId)
      .subscribe((result: Course) => {
        this.course = result;
        console.log(this.course);
      });
  }
}
