import { Location } from "@angular/common";
import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { CookieService } from "ngx-cookie-service";
import { Homework } from "src/app/common/models/homework";
import { HomeworkService } from "src/app/common/services/homework.service";

@Component({
  selector: "app-homework-view",
  templateUrl: "./homework-view.component.html",
  styleUrls: ["./homework-view.component.css"],
})
export class HomeworkViewComponent implements OnInit {
  constructor(
    private activatedRoute: ActivatedRoute,
    private cookieService: CookieService,
    private homeworkService: HomeworkService,
    private router: Router,
    private location: Location
  ) {}

  homeworkId: string;
  homework: Homework;

  setMarkForm = new FormGroup({
    mark: new FormControl(1),
  });

  ngOnInit() {
    if (this.homeworkId === "" || this.homeworkId === undefined) {
      this.homeworkId = this.activatedRoute.snapshot.paramMap.get("id");
    }
    this.homeworkService
      .getHomeworkById(this.homeworkId)
      .subscribe((result: Homework) => {
        this.homework = result;
        this.setMarkForm.get("mark").setValue(result.mark);
      });
  }

  setMark() {
    if (this.setMarkForm.valid) {
      this.homework.mark = this.setMarkForm.get("mark").value;
      this.homeworkService.updateHomework(this.homework).subscribe(
        (result) => {
          this.location.back();
        },
        (error) => console.log(error)
      );
    }
  }
}
