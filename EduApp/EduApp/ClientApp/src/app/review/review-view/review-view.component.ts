import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { User } from 'src/app/common/models/user';
import { ReviewService } from 'src/app/common/services/review.service';
import { UserService } from 'src/app/common/services/user.service';
import { Review } from "../../common/models/review";

@Component({
  selector: 'app-review-view',
  templateUrl: './review-view.component.html',
  styleUrls: ['./review-view.component.css']
})
export class ReviewViewComponent implements OnInit {

  constructor(
    private cookieService: CookieService,
    private reviewService: ReviewService,
  ) { }

  @Input("review") review: Review;

  @Output() removeItemEvent = new EventEmitter<Review>();

  isOwner: boolean;

  ngOnInit() {
    if (this.review.accountId === this.cookieService.get("accountId")) {
      this.isOwner = true;
    }
  }

  removeReview() {  
    this.reviewService.removeReview
    (
      this.review.id
    )
    .subscribe(
      (result) => {
        this.removeItemEvent.emit(result);
      }, 
      (error) => console.log(error)    
    );
  }
}
