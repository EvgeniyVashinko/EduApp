import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { LessonViewComponent } from "./lesson-view/lesson-view.component";
import { LessonCreateComponent } from "./lesson-create/lesson-create.component";
import { RouterModule } from "@angular/router";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import {
  MatButtonModule,
  MatFormFieldModule,
  MatInputModule,
} from "@angular/material";

@NgModule({
  declarations: [LessonViewComponent, LessonCreateComponent],
  imports: [
    CommonModule,
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: "lesson/create/:id", component: LessonCreateComponent },
    ]),
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
  ],
})
export class LessonModule {}
