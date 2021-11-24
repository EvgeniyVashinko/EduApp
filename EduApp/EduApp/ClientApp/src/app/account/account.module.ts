import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { AccountLoginComponent } from "./account-login/account-login.component";
import { RouterModule } from "@angular/router";
import { MatInputModule } from "@angular/material";
import { MatFormFieldModule } from "@angular/material";
import { MatIconModule } from "@angular/material";
import { MatCardModule } from "@angular/material";
import { MatButtonModule } from "@angular/material";

@NgModule({
  declarations: [AccountLoginComponent],
  imports: [
    CommonModule,
    FormsModule,
    MatInputModule,
    MatFormFieldModule,
    MatIconModule,
    MatCardModule,
    MatButtonModule,
    RouterModule.forRoot([
      {
        path: "account/login",
        component: AccountLoginComponent,
        pathMatch: "full",
      },
    ]),
  ],
})
export class AccountModule {}
