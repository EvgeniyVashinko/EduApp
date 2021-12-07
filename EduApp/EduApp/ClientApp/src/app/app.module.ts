import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { RouterModule } from "@angular/router";
import { AccountModule } from "./account/account.module";

import { AppComponent } from "./app.component";
import { NavMenuComponent } from "./nav-menu/nav-menu.component";
import { HomeComponent } from "./home/home.component";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { CookieService } from "ngx-cookie-service";
import {
  MatButtonModule,
  MatCardModule,
  MatProgressSpinnerModule,
  MatTabsModule,
} from "@angular/material";
import { CourseModule } from "./course/course.module";
import { UserModule } from "./user/user.module";
import { LessonModule } from "./lesson/lesson.module";
import { ReviewModule } from "./review/review.module";
import { HomeworkModule } from "./homework/homework.module";
import { AdminModule } from "./admin/admin.module";

@NgModule({
  declarations: [AppComponent, NavMenuComponent, HomeComponent],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: "", component: HomeComponent, pathMatch: "full" },
    ]),
    BrowserAnimationsModule,
    AccountModule,
    CourseModule,
    UserModule,
    LessonModule,
    MatCardModule,
    MatButtonModule,
    MatProgressSpinnerModule,
    ReviewModule,
    MatTabsModule,
    HomeworkModule,
    AdminModule
  ],
  providers: [CookieService],
  bootstrap: [AppComponent],
})
export class AppModule {}
