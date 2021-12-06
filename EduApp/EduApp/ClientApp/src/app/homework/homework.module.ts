import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeworkListComponent } from './homework-list/homework-list.component';
import { HomeworkViewComponent } from './homework-view/homework-view.component';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { MatButtonModule, MatCardModule, MatTableModule } from '@angular/material';



@NgModule({
  declarations: [HomeworkListComponent, HomeworkViewComponent],
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
        path: "homework/:id",
        component: HomeworkViewComponent,
      },
    ]),
    MatTableModule,
    MatButtonModule,
    MatCardModule
  ]
})
export class HomeworkModule { }
