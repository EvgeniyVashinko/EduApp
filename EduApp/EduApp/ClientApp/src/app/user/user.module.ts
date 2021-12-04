import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { UserViewComponent } from "./user-view/user-view.component";
import { RouterModule } from "@angular/router";
import {
  MatCardModule,
  MatProgressSpinnerModule,
  MatTabsModule,
} from "@angular/material";

@NgModule({
  declarations: [UserViewComponent],
  imports: [
    CommonModule,
    RouterModule.forRoot([{ path: "user/:id", component: UserViewComponent }]),
    MatProgressSpinnerModule,
    MatCardModule,
    MatTabsModule,
  ],
})
export class UserModule {}
