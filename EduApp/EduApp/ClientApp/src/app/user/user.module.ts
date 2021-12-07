import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { UserViewComponent } from "./user-view/user-view.component";
import { RouterModule } from "@angular/router";
import {
  MatButtonModule,
  MatCardModule,
  MatFormFieldModule,
  MatIconModule,
  MatInputModule,
  MatListModule,
  MatProgressSpinnerModule,
  MatSelectModule,
  MatSnackBarModule,
  MatTabsModule,
  MatToolbarModule,
} from "@angular/material";
import { CourseViewComponent } from "../course/course-view/course-view.component";
import { CourseModule } from "../course/course.module";
import { BrowserModule } from "@angular/platform-browser";
import { UserUpdateComponent } from "./user-update/user-update.component";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";

@NgModule({
  declarations: [UserViewComponent, UserUpdateComponent],
  imports: [
    CommonModule,
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    MatInputModule,
    MatFormFieldModule,
    MatSelectModule,
    MatIconModule,
    CourseModule,
    RouterModule.forRoot([
      {
        path: "user/update/:id",
        component: UserUpdateComponent,
      },
      { path: "user/:id", component: UserViewComponent },
    ]),
    MatProgressSpinnerModule,
    MatCardModule,
    MatTabsModule,
    MatListModule,
    MatSnackBarModule,
    MatButtonModule,
  ],
})
export class UserModule {}
