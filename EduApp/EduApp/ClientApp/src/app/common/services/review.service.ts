import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import * as internal from 'assert';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { PagedListContainer } from '../models/pagedList';
import { Review } from '../models/review';

@Injectable({
  providedIn: 'root'
})
export class ReviewService {

  constructor(private httpClient: HttpClient) { }

  getReviewById(id: string): Observable<Review> {
    return this.httpClient.get<Review>(
      environment.apiUrl + `/api/review/${id}`,
      environment.options
    );
  }

  getReviewsByCourseId(id: string) {
    let requestBody = { courseId: id };
    return this.httpClient.post<PagedListContainer<Review>>(
      environment.apiUrl + "/api/review/list",
      requestBody,
      environment.options
    );
  }

  addReview(accountId: string, courseId: string, value: number, description: string) {
    let requestBody = 
    { 
      courseId: courseId,
      accountId: accountId,
      value: value,
      description: description
    };
    return this.httpClient.post<Review>(
      environment.apiUrl + "/api/review/create",
      requestBody,
      environment.options
    );
  }

  removeReview(reviewId: string) {
    return this.httpClient.delete<Review>(
      environment.apiUrl + `/api/review/${reviewId}`,
      environment.options
    );
  }
}
