import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { CookieService } from "ngx-cookie-service";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { Course } from "../models/course";
import { PagedList, PagedListContainer } from "../models/pagedList";

@Injectable({
  providedIn: "root",
})
export class CourseService {
  constructor(private httpClient: HttpClient) {}

  getAllCourses(param): Observable<PagedListContainer<Course>> {
    return this.httpClient.post<PagedListContainer<Course>>(
      environment.apiUrl + "/api/course/list",
      param,
      environment.options
    );
  }

  getCourseById(id: string): Observable<Course> {
    return this.httpClient.get<Course>(
      environment.apiUrl + `/api/course/${id}`,
      environment.options
    );
  }

  createCourse(course: Course) {
    return this.httpClient.post(
      environment.apiUrl + `/api/course/create`,
      course,
      environment.options
    );
  }

  getCoursesByOwnerId(id: string) {
    let requestBody = { ownerId: id };
    return this.httpClient.post<PagedListContainer<Course>>(
      environment.apiUrl + "/api/course/list",
      requestBody,
      environment.options
    );
  }

  getCoursesByParticipantId(id: string) {
    let requestBody = { participantId: id };
    return this.httpClient.post<PagedListContainer<Course>>(
      environment.apiUrl + "/api/course/list",
      requestBody,
      environment.options
    );
  }
}
