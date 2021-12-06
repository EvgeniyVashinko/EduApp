import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Homework } from '../models/homework';
import { PagedListContainer } from '../models/pagedList';

@Injectable({
  providedIn: 'root'
})
export class HomeworkService {

  constructor(private httpClient: HttpClient) { }

  getHomeworkById(id: string): Observable<Homework> {
    return this.httpClient.get<Homework>(
      environment.apiUrl + `/api/homework/${id}`,
      environment.options
    );
  }

  getHomeworksByCourseId(id: string) {
    let requestBody = { courseId: id };
    return this.httpClient.post<PagedListContainer<Homework>>(
      environment.apiUrl + "/api/homework/list",
      requestBody,
      environment.options
    );
  }

  addHomework(accountId: string, lessonId: string, url: string) {
    let requestBody = 
    { 
      lessonId: lessonId,
      accountId: accountId,
      url: url
    };
    return this.httpClient.post<Homework>(
      environment.apiUrl + "/api/homework/create",
      requestBody,
      environment.options
    );
  }

  removeReview(homeworkId: string) {
    return this.httpClient.delete<Homework>(
      environment.apiUrl + `/api/homework/${homeworkId}`,
      environment.options
    );
  }
}
