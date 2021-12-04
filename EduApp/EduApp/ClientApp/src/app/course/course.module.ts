import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { CourseViewComponent } from "../course-view/course-view.component";
import { RouterModule } from "@angular/router";
import {
  MatButtonModule,
  MatCardModule,
  MatExpansionModule,
  MatProgressSpinnerModule,
} from "@angular/material";

@NgModule({
  declarations: [CourseViewComponent],
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
})
export class CourseModule {}
