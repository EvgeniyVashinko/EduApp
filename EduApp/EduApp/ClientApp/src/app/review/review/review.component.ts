import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PagedListContainer } from 'src/app/common/models/pagedList';
import { Review } from 'src/app/common/models/review';
import { ReviewService } from 'src/app/common/services/review.service';

@Component({
  selector: 'app-review',
  templateUrl: './review.component.html',
  styleUrls: ['./review.component.css']
})
export class ReviewComponent implements OnInit {

  constructor(
    private activatedRoute: ActivatedRoute,
    private reviewService: ReviewService,
  ) { }

  @Input("courseId") courseId: string;

  reviews: Review[];
  
  ngOnInit() {
    if (this.courseId === "" || this.courseId === undefined) {
      this.courseId = this.activatedRoute.snapshot.paramMap.get("id");
    }
    this.reviewService
      .getReviewsByCourseId(this.courseId)
      .subscribe((result: PagedListContainer<Review>) => {
        this.reviews = result.pagedList.items;
      });
  }

  addItem(newItem: Review) {
    this.reviews.push(newItem);
  }

  removeItem(item: Review) {
    let idx = this.reviews.findIndex(x => x.id === item.id);
    this.reviews.splice(idx,1);
  }
}
