import { Component, Input, OnInit } from "@angular/core";

@Component({
  selector: "app-lesson-view",
  templateUrl: "./lesson-view.component.html",
  styleUrls: ["./lesson-view.component.css"],
})
export class LessonViewComponent implements OnInit {
  @Input() lessonId: string;

  constructor() {}

  ngOnInit() {}
}
