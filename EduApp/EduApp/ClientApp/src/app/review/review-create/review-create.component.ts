import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { Review } from 'src/app/common/models/review';
import { ReviewService } from 'src/app/common/services/review.service';

@Component({
  selector: 'app-review-create',
  templateUrl: './review-create.component.html',
  styleUrls: ['./review-create.component.css']
})
export class ReviewCreateComponent implements OnInit {

  constructor(
    private activatedRoute: ActivatedRoute,
    private reviewService: ReviewService,
    private cookieService: CookieService
  ) {}

  @Input("courseId") courseId: string;
  @Input("accountId") accountId: string;

  @Output() newItemEvent = new EventEmitter<Review>();

  createReviewForm = new FormGroup({
    value: new FormControl(5),
    description: new FormControl(""),
  });

  ngOnInit() {
    if (this.courseId === "" || this.courseId === undefined) {
      this.courseId = this.activatedRoute.snapshot.paramMap.get("id");
    }

    if (this.accountId === "" || this.accountId === undefined) {
      this.accountId = this.cookieService.get("accountId");
    }
  }

  leaveReview() {  
    this.reviewService.addReview
    (
      this.accountId,
      this.courseId,
      this.createReviewForm.get("value").value,
      this.createReviewForm.get("description").value,
    )
    .subscribe(
      (result) => {
        this.newItemEvent.emit(result);
        this.createReviewForm.get("value").setValue(5);
        this.createReviewForm.get("description").setValue(" ");
      }, 
      (error) => console.log(error)    
    );
  }
}
