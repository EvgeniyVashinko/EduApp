import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { MatInputModule } from "@angular/material";
import { MatFormFieldModule } from "@angular/material";
import { MatIconModule } from "@angular/material";
import { MatCardModule } from "@angular/material";
import { MatButtonModule } from "@angular/material";
import { MatSelectModule } from "@angular/material";
import { MatToolbarModule } from "@angular/material";
import { AccountRegistrationComponent } from "../account-registration/account-registration.component";
import { AccountLoginComponent } from "./account-login/account-login.component";

@NgModule({
  declarations: [AccountLoginComponent, AccountRegistrationComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatInputModule,
    MatFormFieldModule,
    MatIconModule,
    MatCardModule,
    MatButtonModule,
    MatSelectModule,
    MatToolbarModule,
    RouterModule.forRoot([
      {
        path: "account/login",
        component: AccountLoginComponent,
        pathMatch: "full",
      },
      {
        path: "account/registration",
        component: AccountRegistrationComponent,
        pathMatch: "full",
      },
    ]),
  ],
})
export class AccountModule {}
