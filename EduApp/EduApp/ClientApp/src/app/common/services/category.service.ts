import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { Category } from "../models/category";

@Injectable({
  providedIn: "root",
})
export class CategoryService {
  constructor(private httpClient: HttpClient) {}

  getAllCategories(id: string) {
    return this.httpClient.get<Category[]>(
      environment.apiUrl + "/api/category/list",
      environment.options
    );
  }
}
