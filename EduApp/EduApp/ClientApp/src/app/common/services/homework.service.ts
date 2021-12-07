import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { Homework } from "../models/homework";
import { PagedListContainer } from "../models/pagedList";

@Injectable({
  providedIn: "root",
})
export class HomeworkService {
  constructor(private httpClient: HttpClient) {}

  getHomeworkById(id: string): Observable<Homework> {
    return this.httpClient.get<Homework>(
      environment.apiUrl + `/api/homework/${id}`,
      environment.options
    );
  }

  getHomeworksByLessonId(id: string) {
    let requestBody = { lessonId: id, isTableRequest: false };
    return this.httpClient.post<PagedListContainer<Homework>>(
      environment.apiUrl + "/api/homework/list",
      requestBody,
      environment.options
    );
  }

  getHomeworksByCourseId(id: string) {
    let requestBody = { courseId: id, isTableRequest: true };
    return this.httpClient.post<PagedListContainer<Homework>>(
      environment.apiUrl + "/api/homework/list",
      requestBody,
      environment.options
    );
  }

  addHomework(homework: Partial<Homework>) {
    return this.httpClient.post<Homework>(
      environment.apiUrl + "/api/homework/create",
      homework,
      environment.options
    );
  }

  updateHomework(homework: Homework) {
    return this.httpClient.post<Homework>(
      environment.apiUrl + `/api/homework/update/${homework.id}`,
      homework,
      environment.options
    );
  }

  removeHomework(homeworkId: string) {
    return this.httpClient.delete<Homework>(
      environment.apiUrl + `/api/homework/${homeworkId}`,
      environment.options
    );
  }
}
