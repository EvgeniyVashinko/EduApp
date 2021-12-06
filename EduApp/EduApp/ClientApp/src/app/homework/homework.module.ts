import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { HomeworkListComponent } from "./homework-list/homework-list.component";
import { HomeworkViewComponent } from "./homework-view/homework-view.component";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import {
  MatButtonModule,
  MatCardModule,
  MatFormFieldModule,
  MatInputModule,
  MatTableModule,
} from "@angular/material";
import { HomeworkCreateComponent } from "./homework-create/homework-create.component";

@NgModule({
  declarations: [
    HomeworkListComponent,
    HomeworkViewComponent,
    HomeworkCreateComponent,
  ],
  imports: [
    CommonModule,
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      {
        path: "homework/list/:courseId",
        component: HomeworkListComponent,
      },
      {
        path: "homework/create/:lessonId",
        component: HomeworkCreateComponent,
      },
      {
        path: "homework/:id",
        component: HomeworkViewComponent,
      },
    ]),
    MatTableModule,
    MatButtonModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
  ],
})
export class HomeworkModule {}
