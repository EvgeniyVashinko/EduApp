import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { User } from "../models/user";

@Injectable({
  providedIn: "root",
})
export class UserService {
  constructor(private httpClient: HttpClient) {}

  getUserById(id: string): Observable<User> {
    return this.httpClient.get<User>(
      environment.apiUrl + "/api/user/" + id,
      environment.options
    );
  }
}
