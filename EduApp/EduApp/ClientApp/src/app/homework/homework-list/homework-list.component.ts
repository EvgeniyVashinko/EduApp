import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { Homework } from 'src/app/common/models/homework';
import { PagedListContainer } from 'src/app/common/models/pagedList';
import { HomeworkService } from 'src/app/common/services/homework.service';

@Component({
  selector: 'app-homework-list',
  templateUrl: './homework-list.component.html',
  styleUrls: ['./homework-list.component.css']
})
export class HomeworkListComponent implements OnInit {

  constructor(
    private activatedRoute: ActivatedRoute,
    private cookieService: CookieService,
    private homeworkService: HomeworkService,
  ) { }

  // @Input("courseId") courseId: string;
  courseId: string;
  homeworks: Homework[];
  displayedColumns: string[] = ['username', 'lesson', 'actions'];;

  ngOnInit() {
    if (this.courseId === "" || this.courseId === undefined) {
      this.courseId = this.activatedRoute.snapshot.paramMap.get("courseId");
    }
    this.homeworkService
      .getHomeworksByCourseId(this.courseId)
      .subscribe((result: PagedListContainer<Homework>) => {
        this.homeworks = result.pagedList.items;
    });
  }

}
