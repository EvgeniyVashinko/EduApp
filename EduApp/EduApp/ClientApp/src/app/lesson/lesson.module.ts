import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { LessonViewComponent } from "./lesson-view/lesson-view.component";
import { LessonCreateComponent } from "./lesson-create/lesson-create.component";
import { RouterModule } from "@angular/router";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import {
  MatButtonModule,
  MatCardModule,
  MatExpansionModule,
  MatFormFieldModule,
  MatInputModule,
  MatProgressSpinnerModule,
} from "@angular/material";
import { LessonUpdateComponent } from "./lesson-update/lesson-update.component";

@NgModule({
  declarations: [
    LessonViewComponent,
    LessonCreateComponent,
    LessonUpdateComponent,
  ],
  imports: [
    CommonModule,
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: "lesson/create/:id", component: LessonCreateComponent },
      { path: "lesson/update/:id", component: LessonUpdateComponent },
    ]),
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule,
    MatExpansionModule,
    MatProgressSpinnerModule,
  ],
  exports: [LessonViewComponent],
})
export class LessonModule {}
