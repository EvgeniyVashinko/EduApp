import { Location } from "@angular/common";
import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { CookieService } from "ngx-cookie-service";
import { Homework } from "src/app/common/models/homework";
import { HomeworkService } from "src/app/common/services/homework.service";

@Component({
  selector: "app-homework-create",
  templateUrl: "./homework-create.component.html",
  styleUrls: ["./homework-create.component.css"],
})
export class HomeworkCreateComponent implements OnInit {
  lessonId: string = this.activatedRoute.snapshot.paramMap.get("lessonId");
  userId: string = this.cookieService.get("accountId");

  createHomeworkForm = new FormGroup({
    answer: new FormControl(""),
    url: new FormControl(""),
  });

  error: string;
  constructor(
    private activatedRoute: ActivatedRoute,
    private cookieService: CookieService,
    private homeworkService: HomeworkService,
    private location: Location
  ) {}

  ngOnInit() {}

  createHomework() {
    if (this.createHomeworkForm.valid) {
      let homework: Partial<Homework> = {
        accountId: this.userId,
        lessonId: this.lessonId,
        answer: this.createHomeworkForm.get("answer").value,
        url: this.createHomeworkForm.get("url").value,
      };
      this.homeworkService.addHomework(homework).subscribe((result) => {
        this.location.back();
      });
    }
  }
}
