import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { CourseViewComponent } from "./course-view/course-view.component";
import { RouterModule } from "@angular/router";
import {
  MatButtonModule,
  MatCardModule,
  MatExpansionModule,
  MatProgressSpinnerModule,
} from "@angular/material";
import { CourseCreateComponent } from "./course-create/course-create.component";

@NgModule({
  declarations: [CourseViewComponent, CourseCreateComponent],
  imports: [
    CommonModule,
    RouterModule.forRoot([
      {
        path: "course/:id",
        component: CourseViewComponent,
      },
    ]),
    MatCardModule,
    MatButtonModule,
    MatExpansionModule,
    MatProgressSpinnerModule,
  ],
  exports: [CourseViewComponent],
})
export class CourseModule {}
