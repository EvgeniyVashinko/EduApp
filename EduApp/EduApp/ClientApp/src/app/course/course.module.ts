import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { CourseViewComponent } from "./course-view/course-view.component";
import { RouterModule } from "@angular/router";
import {
  MatButtonModule,
  MatCardModule,
  MatExpansionModule,
  MatFormFieldModule,
  MatInputModule,
  MatProgressSpinnerModule,
  MatSnackBarModule,
} from "@angular/material";
import { CourseCreateComponent } from "./course-create/course-create.component";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { CourseUpdateComponent } from "./course-update/course-update.component";
import { ReviewModule } from "../review/review.module";

@NgModule({
  declarations: [
    CourseViewComponent,
    CourseCreateComponent,
    CourseUpdateComponent,
  ],
  imports: [
    CommonModule,
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    ReviewModule,
    RouterModule.forRoot([
      {
        path: "course/create",
        component: CourseCreateComponent,
      },
      {
        path: "course/update/:id",
        component: CourseUpdateComponent,
      },
      {
        path: "course/:id",
        component: CourseViewComponent,
      },
    ]),
    MatCardModule,
    MatButtonModule,
    MatExpansionModule,
    MatProgressSpinnerModule,
    MatFormFieldModule,
    MatInputModule,
    MatSnackBarModule,
  ],
  exports: [CourseViewComponent],
})
export class CourseModule {}
