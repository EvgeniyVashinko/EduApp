import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminCourseListComponent } from './admin-course-list/admin-course-list.component';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { MatButtonModule, MatCardModule, MatFormFieldModule, MatInputModule, MatTableModule } from '@angular/material';



@NgModule({
  declarations: [AdminCourseListComponent],
  imports: [
    CommonModule,
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      {
        path: "admin/courselist",
        component: AdminCourseListComponent,
      },
    ]),
    MatTableModule,
    MatButtonModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
  ]
})
export class AdminModule { }
