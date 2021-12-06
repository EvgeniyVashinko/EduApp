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
import { CourseProgressComponent } from "./course-progress/course-progress.component";
import { LessonModule } from "../lesson/lesson.module";

@NgModule({
  declarations: [
    CourseViewComponent,
    CourseCreateComponent,
    CourseUpdateComponent,
    CourseProgressComponent,
  ],
  imports: [
    CommonModule,
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    ReviewModule,
    LessonModule,
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
        path: "course/progress/:id",
        component: CourseProgressComponent,
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
