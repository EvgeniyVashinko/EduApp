import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { UserViewComponent } from "./user-view/user-view.component";
import { RouterModule } from "@angular/router";
import {
  MatCardModule,
  MatListModule,
  MatProgressSpinnerModule,
  MatTabsModule,
} from "@angular/material";
import { CourseViewComponent } from "../course/course-view/course-view.component";
import { CourseModule } from "../course/course.module";
import { BrowserModule } from "@angular/platform-browser";

@NgModule({
  declarations: [UserViewComponent],
  imports: [
    CommonModule,
    BrowserModule,
    CourseModule,
    RouterModule.forRoot([{ path: "user/:id", component: UserViewComponent }]),
    MatProgressSpinnerModule,
    MatCardModule,
    MatTabsModule,
    MatListModule,
  ],
})
export class UserModule {}
