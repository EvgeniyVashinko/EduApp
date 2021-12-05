import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-lesson-create",
  templateUrl: "./lesson-create.component.html",
  styleUrls: ["./lesson-create.component.css"],
})
export class LessonCreateComponent implements OnInit {
  courseId: string = this.activatedRoute.snapshot.paramMap.get("id");

  constructor(private activatedRoute: ActivatedRoute) {}

  ngOnInit() {
    console.log(this.courseId);
  }
}
