import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { Lesson } from "../models/lesson";
import { PagedList, PagedListContainer } from "../models/pagedList";

@Injectable({
  providedIn: "root",
})
export class LessonService {
  constructor(private httpClient: HttpClient) {}

  getLessonsByCourseId(id: string): Observable<PagedListContainer<Lesson>> {
    let body = { courseId: id };
    return this.httpClient.post<PagedListContainer<Lesson>>(
      environment.apiUrl + "/api/lesson/list",
      body,
      environment.options
    );
  }

  createLesson(lesson: Partial<Lesson>) {
    return this.httpClient.post<Lesson>(
      environment.apiUrl + "/api/lesson/create",
      lesson,
      environment.options
    );
  }
}
