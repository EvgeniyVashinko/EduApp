import { Component, OnInit } from "@angular/core";
import * as internal from "assert";

@Component({
  selector: "app-account-registration",
  templateUrl: "./account-registration.component.html",
  styleUrls: ["./account-registration.component.css"],
})
export class AccountRegistrationComponent implements OnInit {
  firstName: string;
  lastName: string;
  email: string;
  username: string;
  password: string;
  birthday: Date;
  sex: number;
  avatar: string;

  constructor() {}

  registration() {
    console.log(
      `${this.firstName}+${this.lastName}+${this.email}+${this.username}+${this.password}+${this.birthday}+${this.sex}+${this.avatar}`
    );
  }

  ngOnInit() {}
}
