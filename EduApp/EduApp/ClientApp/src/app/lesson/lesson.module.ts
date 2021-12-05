import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { LessonViewComponent } from "./lesson-view/lesson-view.component";
import { LessonCreateComponent } from "./lesson-create/lesson-create.component";
import { RouterModule } from "@angular/router";

@NgModule({
  declarations: [LessonViewComponent, LessonCreateComponent],
  imports: [
    CommonModule,
    RouterModule.forRoot([
      { path: "lesson/create/:id", component: LessonCreateComponent },
    ]),
  ],
})
export class LessonModule {}
